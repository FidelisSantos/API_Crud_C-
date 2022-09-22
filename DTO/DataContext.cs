using API_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD.DTO
{
  public class DataContext : DbContext
  {

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<UserModel> UserModels { get; set; }
  }
}