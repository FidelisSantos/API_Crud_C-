namespace API_CRUD.Models
{
  public class UserModel
  {
    public int Id { get; set; }
    public long cpf { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }

    public DateTime? created { get; set; }

    public DateTime? update { get; set; }
  }
}