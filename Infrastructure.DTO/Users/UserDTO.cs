using Infrastructure.DTO.Organization.Contact;

namespace Infrastructure.DTO.Users
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public PhoneNumberDTO PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public int CompanyId { get; set; }
    }
}
