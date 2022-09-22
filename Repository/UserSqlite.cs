using API_CRUD.Models;
using API_CRUD.Interfaces;
using API_CRUD.DTO;

namespace API_CRUD.Repository
{
  public class UserSqlite : IUserRepository
  {
    private readonly DataContext _context;

    public UserSqlite(DataContext context) => _context = context;

    public UserModel Create(UserModel newUser)
    {
      newUser.created = DateTime.Now;
      _context.UserModels.Add(newUser);
      _context.SaveChanges();
      return newUser;
    }

    public bool Delete(string email)
    {
      var remove = _context.Remove(_context.UserModels.Single(user => user.email == email));
      _context.SaveChanges();
      return !ExistEmail(email);
    }

    public bool ExistCpf(long cpf)
    {
      return _context.UserModels.Any(user => user.cpf == cpf);
    }

    public bool ExistEmail(string email)
    {
      return _context.UserModels.Any(user => user.email == email);
    }

    public UserModel Find(string email)
    {
      return _context.UserModels.FirstOrDefault(user => user.email == email);
    }

    public List<UserModel> FindAll()
    {
      return _context.UserModels.ToList();
    }

    public UserModel Update(string email, UserModel updateUser)
    {
      var searchModel = _context.UserModels.FirstOrDefault(u => u.email == email);
      searchModel.cpf = updateUser.cpf;
      searchModel.email = updateUser.email;
      searchModel.name = updateUser.name;
      searchModel.update = DateTime.Now;
      _context.SaveChanges();
      return searchModel;
    }
  }
}