namespace API.Auth.Responses
{
    public class UserNotFoundResponse
    {
        public UserNotFoundResponse(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Description = $"User with phone number == {phoneNumber} not found";
        }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
