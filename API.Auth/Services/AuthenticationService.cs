using API.Auth.Exceptions;
using DAL;
using Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> AuthentificateUser(UserCredentials userCredentials)
        {
            User user = await this.repository.GetAll().FirstOrDefaultAsync(
                user => 
                    user.Credentials.PhoneNumber == userCredentials.PhoneNumber &&
                    user.Credentials.Password == userCredentials.Password
                )
                ?? throw new UserNotAuthenticatedException(userCredentials.PhoneNumber);
            return user;
        }
    }
}
