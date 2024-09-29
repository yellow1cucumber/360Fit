using Domain.Core.Organization.Contact;
using Domain.Core.Sells.Service;
using Domain.Core.Users.Roles;

using SlnAssembly.Attributes;

namespace Domain.Core.Users
{
    [DALRepository]
    public class User : Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronomic { get; set; }
        public string? Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public Card? Card { get; set; }
        public double Deposit { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}
