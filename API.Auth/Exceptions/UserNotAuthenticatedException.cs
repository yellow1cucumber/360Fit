namespace API.Auth.Exceptions
{
    public class UserNotAuthenticatedException : Exception
    {
        public UserNotAuthenticatedException(string phone, Exception? innerException = null)
            : base(UserNotAuthenticatedException.CompileMessage(phone),
                  innerException)
            => this.Phone = phone;

        public string Phone { get; set; }

        private static string CompileMessage(string phonenumber)
        {
            return $"ERROR: user with phone number: {phonenumber} not found. Identification was unsuccessfull";
        }
    }
}
