using DAL;
using Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

namespace API.Gate.GraphQl
{
    public class Query
    {
        public IQueryable<User> ReadUsers(Context context)
            => context.Users.AsQueryable();
    }
}
