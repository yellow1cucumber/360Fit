using API.Gate.GraphQl.Exceptions;
using DAL;
using Domain.Core.Users;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class UsersMutation
    {
        private readonly Context context;
        private readonly Repository<User> repository;

        public UsersMutation([Service] Context context)
        {
            this.context = context;
            this.repository = new Repository<User>(context);
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> CreateUser(User user)
        {
            await this.repository.CreateAsync(user);
            return user;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> UpdateUser(User user)
        {
            try
            {
                await this.repository.UpdateAsync(user);
                return user;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new NotFound($"User with id == {user.Id} not found", user.Id);
            }
            catch
            {
                throw;
            }            
        }


        [UseFiltering]
        public async Task<User> RemoveUser(User user)
        {
            try
            {
                await this.repository.DeleteAsync(user.Id);
                return user;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new NotFound($"User with id == {user.Id} not found", user.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
