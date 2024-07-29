namespace API.Auth.Exceptions
{
    public class UserNotIdentificatedException : Exception
    {
        public UserNotIdentificatedException(Exception? innerException, string phone)
            : base(UserNotIdentificatedException.CompileMessage(phone),
                  innerException)
            => this.Phone = phone;

        public string Phone { get; set; }

        private static string CompileMessage(string phonenumber) {
            return $"ERROR: user with phone number: {phonenumber} not found. Identification was unsuccessfull";
        }
    }
}
