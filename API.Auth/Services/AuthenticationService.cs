using API.Auth.Exceptions;
using API.Auth.Requests;
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

        public async Task<User> AuthenticateUser(AuthenticationRequest request)
        {
            User user = await this.repository.GetAll().FirstOrDefaultAsync(
                user => 
                    user.Credentials.PhoneNumber == request.PhoneNumber &&
                    user.Credentials.Password == request.Password
                )
                ?? throw new UserNotAuthenticatedException(request.PhoneNumber);
            return user;
        }
    }
}
