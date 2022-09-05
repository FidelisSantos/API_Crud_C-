using API_CRUD.Interfaces;
using API_CRUD.Models;

namespace API_CRUD.Services
{

  public class UserServices : IUserServices
  {
    private IUserRepository repository;
    public UserServices(IUserRepository repository) => this.repository = repository;
    public UserModel Create(UserModel newUser)
    {
      if (!repository.Exist(newUser.email))
      {
        return repository.Create(newUser);
      }
      return null;
    }

    public bool Delete(string email)
    {
      return repository.Delete(email);
    }

    public List<UserModel> Search() => repository.FindAll();

    public UserModel Search(string email)
    {
      var getData = repository.Find(email);

      return getData;
    }

    public UserModel Update(string email, UserModel updateUser)
    {
      if (repository.Exist(email))
      {
        if (updateUser.cpf == null) throw new Exception("preencha o cpf");
        if (updateUser.email == null) throw new Exception("preencha o email");
        if (updateUser.name == null) throw new Exception("preencha o Nome");

        return repository.Update(email, updateUser);
      }
      return null;
    }
  }
}