using AutoMapper;
using runShop.rest.Dtos.user;
using runShop.Models.models;

namespace runShop.rest.Mapper;
public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}
