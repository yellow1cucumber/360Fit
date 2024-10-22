using Domain.Core.Organization.Contact;

using SlnAssembly.Attributes;

namespace Domain.Core.Users
{
    [DALRepository]
    public class Staff : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronomic { get; set; }
        public string? Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
