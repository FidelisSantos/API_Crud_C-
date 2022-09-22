using API_CRUD.Models;
using API_CRUD.Request;
using AutoMapper;

namespace API_CRUD.DTO
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<UserRequest, UserModel>()
        .ReverseMap();
    }
  }
}
