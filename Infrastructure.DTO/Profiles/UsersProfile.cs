using AutoMapper;
using Domain.Core.Users;
using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<User, UserDTO>().ReverseMap();
            this.CreateMap<UserCredentials, UserCredentialsDTO>().ReverseMap();
        }
    }
}
