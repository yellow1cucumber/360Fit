namespace Infrastructure.DTO.Sells
{
    public class UserCredentialsDTO
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }
        public UserDTO.Roles Role { get; set; }
    }
}
