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

        public async Task<User?> IdentificateUser(string phoneNumber)
        {
            User? user = await this.repository.GetAll()
                                              .FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
            if (user is null)
            {
                throw new Exception("User not identificated");
            }

            return user;
        }
    }
}
