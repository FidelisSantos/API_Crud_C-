namespace API_CRUD.Request
{
  public class UserRequest
  {
    public long cpf { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
  }
}