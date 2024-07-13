using DAL;
using Domain.Core.Users;

namespace API.Gate.GraphQl.Mutations
{
    public class UsersMutation
    {
        [UseProjection]
        [UseFiltering]
        public async Task<IResult> CreateOrUpdateUser([Service]Context context, User user)
        {
            if (context.Users.Any(x => x.Id == user.Id)){
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return Results.Ok(user);
            }
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Results.Created(uri: String.Empty, value: user);
        }


        [UseFiltering]
        public async Task<IResult> RemoveUser([Service] Context context, User user)
        {
            if (context.Users.Contains(user))
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return Results.Ok();
            }
            return Results.NotFound(user);
        }
    }
}
