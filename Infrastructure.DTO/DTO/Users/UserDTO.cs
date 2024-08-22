using Domain.Core.Organization;

namespace Domain.Core.Users
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public UserCredentialsDTO Credentials { get; set; }

        public IEnumerable<CompanyDTO> StaffIn { get; set; }
        public IEnumerable<CompanyDTO> ClientIn { get; set; }
        
        public enum Roles
        {
            Owner = 0,
            Manager = 1,
            Admin = 2,
            Specialist = 3,
            Client = 4
        }
    }
}
