using Microsoft.AspNetCore.Mvc;
using API_CRUD.Request;
using API_CRUD.Models;
using API_CRUD.Interfaces;
using AutoMapper;
using API_CRUD.Response;

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
      var userResponses = _mapper.Map<List<UserResponse>>(users);
      return (userResponses == null || !userResponses.Any() ? NotFound(notFoundAll) : Ok(userResponses));
    }

    [HttpPost]
    public IActionResult NewModel([FromBody] UserRequest newUserRequest)
    {
      var model = _mapper.Map<UserModel>(newUserRequest);
      var newUser = services.Create(model);
      var userResponse = _mapper.Map<UserResponse>(newUser);
      return userResponse != null ? Created("", userResponse) : BadRequest();
    }

    [HttpGet]
    [Route("{email}")]
    public IActionResult FindModel([FromRoute] string email)
    {
      var user = services.Search(email);
      var userResponse = _mapper.Map<UserResponse>(user);
      return userResponse != null ? Ok(userResponse) : NotFound(notFound);
    }

    [HttpPut]
    [Route("{email}")]
    public IActionResult UpdateModel([FromRoute] string email, [FromBody] UserRequest updateUserRequest)
    {
      var model = _mapper.Map<UserModel>(updateUserRequest);
      var updateUser = services.Update(email, updateUserRequest.cpf, model);
      var userResponse = _mapper.Map<UserResponse>(updateUser);
      return userResponse != null ? Ok(userResponse) : NotFound(notFound);
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