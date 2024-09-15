using Domain.Core.Sells.Service;
using Domain.Core.Users.Roles;

namespace Domain.Core.Users
{
    public class User : Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public Card? Card { get; set; }

        public UserCredentials Credentials { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
