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

        public async Task<bool> AuthentificateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
