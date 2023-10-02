using AutoMapper;
using runShop.Models.models;
using runShop.rest.Dto.user;
using runShop.rest.Dtos.user;

namespace runShop.rest.Mapper
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}
