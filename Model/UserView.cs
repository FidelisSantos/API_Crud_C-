namespace API_CRUD.View
{
  public class UserView
  {
    public long cpf { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }

    public DateTime? created { get; set; }

    public DateTime? update { get; set; }
  }
}