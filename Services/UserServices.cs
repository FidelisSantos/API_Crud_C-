using API_CRUD.Interfaces;
using API_CRUD.Models;
using API_CRUD.Validator;

namespace API_CRUD.Services
{

  public class UserServices : IUserServices
  {
    private IUserRepository repository;
    private UserValidator validator = new UserValidator();

    public UserServices(IUserRepository repository) => this.repository = repository;
    public UserModel Create(UserModel newUser)
    {
      if (!repository.ExistEmail(newUser.email) && !repository.ExistCpf(newUser.cpf))
      {
        Validate(newUser);
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

    public UserModel Update(string email, long cpf, UserModel updateUser)
    {
      if (Search(email) != null)
      {
        if (updateUser.email == email)
        {
          var user = Search(email);
          if (user.cpf == updateUser.cpf)
          {
            Validate(updateUser);
            return repository.Update(email, updateUser);
          }
          else if (!repository.ExistCpf(updateUser.cpf))
          {
            Validate(updateUser);
            return repository.Update(email, updateUser);
          }
          else
          {
            throw new Exception("CPF já existe na base");
          }
        }
        else if (!repository.ExistEmail(updateUser.email))
        {
          var user = Search(email);
          if (user.cpf == updateUser.cpf)
          {
            Validate(updateUser);
            return repository.Update(email, updateUser);
          }
          else if (!repository.ExistCpf(updateUser.cpf))
          {
            Validate(updateUser);
            return repository.Update(email, updateUser);
          }
          else
          {
            throw new Exception("CPF já existe na base");
          }
        }
        else
        {
          throw new Exception("Email já existe na base");
        }
      }
      return null;
    }

    private void Validate(UserModel model)
    {
      var validationResult = validator.Validate(model);
      if (!validationResult.IsValid)
      {
        var erros = validationResult.Errors.Select(x => x.ErrorMessage);
        string erroFormatter = string.Join(" ", erros);
        throw new Exception(erroFormatter);
      }
    }
  }
}