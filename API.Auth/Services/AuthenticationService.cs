using API.Auth.Exceptions;
using API.Auth.Requests;
using DAL;
using Domain.Core.Users;

namespace API.Auth.Services
{
    public class AuthenticationService
    {
        private readonly Context context;
        private readonly Repository<User> repository;

        public AuthenticationService(Context context)
        {
            this.context = context;
            this.repository = new Repository<User>(context);
        }

        public bool AuthenticateUser(AuthenticationRequest request, User user)
        {
            return request.Password == user.Credentials.Password;
        }
    }
}
