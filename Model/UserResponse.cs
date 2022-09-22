namespace API_CRUD.Response
{
  public class UserResponse
  {
    public long cpf { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }

    public DateTime? created { get; set; }

    public DateTime? update { get; set; }
  }
}