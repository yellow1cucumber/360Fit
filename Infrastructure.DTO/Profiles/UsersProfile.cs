using AutoMapper;
using Domain.Core.Users;
using Domain.Core.Users.Roles;

using Infrastructure.DTO.Users;
using Infrastructure.DTO.Users.Roles;

namespace Infrastructure.DTO.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<User, UserDTO>().ReverseMap();
            this.CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
