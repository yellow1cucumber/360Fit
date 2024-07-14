using API.Gate.GraphQl.Exceptions;
using DAL;
using Domain.Core.Users;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class UsersMutation
    {
        [UseProjection]
        [UseFiltering]
        public async Task<User> CreateUser([Service]Context context, User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> UpdateUser([Service] Context context, User user)
        {
            if (context.Users.Any(x => x.Id == user.Id))
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
            throw new NotFound($"User with id == {user.Id} not found", user.Id);
        }


        [UseFiltering]
        public async Task<User> RemoveUser([Service] Context context, User user)
        {
            if (context.Users.Contains(user))
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return user;
            }
            throw new NotFound($"User with id == {user.Id} not found", user.Id);
        }
    }
}
