using SlnAssembly.Attributes;

namespace Domain.Core.Users
{
    [DALRepository]
    public class UserCredentials : Model
    {
        public string PhoneNumber {  get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
    }
}
