using Domain.Core.Users.Roles;

namespace Domain.Core.Users
{
    public class UserCredentials : Model
    {
        public string PhoneNumber {  get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public Role Role { get; set; }
    }
}
