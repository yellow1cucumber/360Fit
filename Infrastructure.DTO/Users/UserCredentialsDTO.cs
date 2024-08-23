using Infrastructure.DTO.Users.Roles;

namespace Infrastructure.DTO.Users
{
    public class UserCredentialsDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
