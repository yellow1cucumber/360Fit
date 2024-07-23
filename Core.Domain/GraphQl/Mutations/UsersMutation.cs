using API.Gate.GraphQl.Exceptions;
using API.Gate.GraphQl.Subscriptions;
using DAL;
using Domain.Core.Users;
using HotChocolate.Subscriptions;

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
        public async Task<User> CreateUser(User user,
                                          [Service] ITopicEventSender sender)
        {
            await this.repository.CreateAsync(user);
            await sender.SendAsync(nameof(UsersSubscription.OnUserCreated), user);
            return user;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> UpdateUser(User user,
                                          [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.UpdateAsync(user);
                await sender.SendAsync(nameof(UsersSubscription.OnUserChanged), user);
                return user;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"User with id == {user.Id} not found", user.Id);
            }
            catch
            {
                throw;
            }            
        }


        [UseFiltering]
        public async Task<User> RemoveUser(User user,
                                          [Service] ITopicEventSender sender)
        {
            try
            {
                await this.repository.DeleteAsync(user.Id);
                await sender.SendAsync(nameof(UsersSubscription.OnUserRemoved), user);
                return user;
            }
            catch (ArgumentOutOfRangeException)
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
