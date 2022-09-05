using Microsoft.AspNetCore.Mvc;
using API_CRUD.Request;
using API_CRUD.Models;
using API_CRUD.Interfaces;

namespace API_CRUD.Controller
{
  [Route("api/crud")]
  [ApiController]

  public class UserController : ControllerBase
  {

    private string notFound = "Usuário não encontrado";
    private string notFoundAll = "Nenhum Usuário encontrado";
    private IUserServices services;

    public UserController(IUserServices services) => this.services = services;

    [HttpGet]
    public IActionResult FindAll()
    {
      var users = services.Search();
      return (users == null || !users.Any() ? NotFound(notFoundAll) : Ok(users));
    }

    [HttpPost]
    public IActionResult NewModel([FromBody] UserRequest newUserRequest)
    {
      UserModel model = new UserModel();
      model.name = newUserRequest.name;
      model.cpf = newUserRequest.cpf;
      model.email = newUserRequest.email;
      var newUser = services.Create(model);
      return newUser != null ? Created("", newUser) : BadRequest();
    }

    [HttpGet]
    [Route("{email}")]
    public IActionResult FindModel([FromRoute] string email)
    {
      var user = services.Search(email);
      return user != null ? Ok(user) : NotFound(notFound);
    }

    [HttpPut]
    [Route("{email}")]
    public IActionResult UpdateModel([FromRoute] string email, [FromBody] UserRequest updateUserRequest)
    {
      UserModel model = new UserModel();
      model.name = updateUserRequest.name;
      model.cpf = updateUserRequest.cpf;
      model.email = updateUserRequest.email;
      var updateUser = services.Update(email, model);
      return updateUser != null ? Ok(updateUser) : NotFound(notFound);

    }

    [HttpDelete]
    [Route("{email}")]
    public IActionResult DeleteModel([FromRoute] string email)
    {
      bool delete = services.Delete(email);
      return delete == true ? Ok() : BadRequest();
    }
  }
}