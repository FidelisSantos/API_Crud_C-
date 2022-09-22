using Microsoft.AspNetCore.Mvc;
using API_CRUD.Request;
using API_CRUD.Models;
using API_CRUD.Interfaces;
using AutoMapper;
using API_CRUD.View;

namespace API_CRUD.Controller
{
  [Route("api/crud")]
  [ApiController]

  public class UserController : ControllerBase
  {

    private string notFound = "Usuário não encontrado";
    private string notFoundAll = "Nenhum Usuário encontrado";
    private IUserServices services;
    private readonly IMapper _mapper;

    public UserController(IUserServices services, IMapper mapper)
    {
      this.services = services;
      _mapper = mapper;
    }



    [HttpGet]
    public IActionResult FindAll()
    {
      var users = services.Search();
      var userViews = _mapper.Map<List<UserView>>(users);
      return (userViews == null || !userViews.Any() ? NotFound(notFoundAll) : Ok(userViews));
    }

    [HttpPost]
    public IActionResult NewModel([FromBody] UserRequest newUserRequest)
    {
      var model = _mapper.Map<UserModel>(newUserRequest);
      var newUser = services.Create(model);
      var userView = _mapper.Map<UserView>(newUser);
      return userView != null ? Created("", userView) : BadRequest();
    }

    [HttpGet]
    [Route("{email}")]
    public IActionResult FindModel([FromRoute] string email)
    {
      var user = services.Search(email);
      var userView = _mapper.Map<UserView>(user);
      return userView != null ? Ok(userView) : NotFound(notFound);
    }

    [HttpPut]
    [Route("{email}")]
    public IActionResult UpdateModel([FromRoute] string email, [FromBody] UserRequest updateUserRequest)
    {
      var model = _mapper.Map<UserModel>(updateUserRequest);
      var updateUser = services.Update(email, updateUserRequest.cpf, model);
      var userView = _mapper.Map<UserView>(updateUser);
      return userView != null ? Ok(userView) : NotFound(notFound);
    }

    [HttpDelete]
    [Route("{email}")]
    public IActionResult DeleteModel([FromRoute] string email)
    {
      bool delete = services.Delete(email);
      return delete == true ? Ok("Deletado") : BadRequest();
    }
  }
}