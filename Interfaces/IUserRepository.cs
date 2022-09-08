using API_CRUD.Models;

namespace API_CRUD.Interfaces
{
  public interface IUserRepository
  {
    List<UserModel> FindAll();
    UserModel Find(string email);
    UserModel Create(UserModel newUser);
    UserModel Update(string email, UserModel updateUser);
    bool Delete(string email);

    bool ExistEmail(string email);
    bool ExistCpf(long cpf);

  }
}