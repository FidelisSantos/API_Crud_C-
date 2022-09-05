using Newtonsoft.Json;

namespace API_CRUD.Models
{
  public class UserModel
  {
    public int? cpf { get; set; }
    public string? name { get; set; }
    public string? email { get; set; }
    [JsonIgnore]
    public DateTime? created { get; set; }
    [JsonIgnore]
    public DateTime? update { get; set; }
  }
}