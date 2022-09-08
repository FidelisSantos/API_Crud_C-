using API_CRUD.Models;
using API_CRUD.Interfaces;

namespace API_CRUD.Repository
{
  public class UserList : IUserRepository
  {
    private static List<UserModel> models = new List<UserModel>();

    public UserModel Create(UserModel newUser)
    {
      newUser.created = DateTime.Now;
      models.Add(newUser);
      return newUser;
    }

    public bool Delete(string email)
    {
      int remove = models.RemoveAll(x => x.email == email);
      return remove > 0;

    }

    public bool ExistEmail(string email)
    {
      return models.Any(u => u.email == email);
    }

    public bool ExistCpf(long cpf)
    {
      return models.Any(u => u.cpf == cpf);
    }

    public UserModel Find(string email)
    {
      UserModel? searchModel = models.FirstOrDefault(f => f.email.Equals(email));
      return searchModel;
    }

    public List<UserModel> FindAll()
    {
      return models;
    }

    public UserModel Update(string email, UserModel updateUser)
    {
      var searchModel = models.FirstOrDefault(u => u.email == email);
      searchModel.cpf = updateUser.cpf;
      searchModel.email = updateUser.email;
      searchModel.name = updateUser.name;
      searchModel.update = DateTime.Now;

      return searchModel;
    }
  }
}