using API.Auth.Exceptions;
using API.Auth.Requests;
using DAL;
using Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Auth.Services
{
    public class IdentificationService
    {
        private readonly Context context;
        private readonly Repository<User> repository;

        public IdentificationService(Context context)
        {
            this.context = context;
            this.repository = new Repository<User>(context);
        }

        public async Task<User> IdentificateUser(AuthenticationRequest request)
        {
            User user = await this.repository.GetAll()
                                              .FirstOrDefaultAsync(
                user => user.Credentials.PhoneNumber == request.PhoneNumber)
            ?? throw new UserNotIdentificatedException(request.PhoneNumber);

            return user;
        }
    }
}
