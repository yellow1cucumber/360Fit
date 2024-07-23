using DAL;
using Domain.Core.Users;

namespace API.Gate.GraphQl
{
    [ExtendObjectType("Query")]
    public class UsersQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> ReadUsers(Context context)
            => context.Users.AsQueryable();
    }
}
