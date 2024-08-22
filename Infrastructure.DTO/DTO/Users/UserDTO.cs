using Domain.Core.Users.Roles;

namespace Infrastructure.DTO.Sells
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public UserCredentialsDTO Credentials { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
