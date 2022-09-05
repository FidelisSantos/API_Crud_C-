using API_CRUD.Models;



namespace API_CRUD.Interfaces
{
  public interface IUserServices
  {
    List<UserModel> Search();
    UserModel Search(string email);
    UserModel Create(UserModel newUser);
    UserModel Update(string email, UserModel updateUser);
    bool Delete(string email);

  }
}