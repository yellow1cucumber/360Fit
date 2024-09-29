using AutoMapper;
using Domain.Core.Users;
using HotChocolate.Subscriptions;
using Infrastructure.DTO.Users;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;

#region TYPEDEF
using Users = DAL.Repository<Domain.Core.Users.User>;
#endregion

namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class UsersMutation
    {
        private readonly IMapper mapper;

        public UsersMutation(IMapper mapper)
            => this.mapper = mapper;

        #region Users
        public async Task<User> CreateUser(UserDTO payload,
                                          [Service] ITopicEventSender sender,
                                          [Service] Users users)
        {
            var user = mapper.Map<User>(payload);
            await users.CreateAsync(user);
            await sender.SendAsync(nameof(UsersSubscription.OnUserCreated), user);
            return user;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> UpdateUser(UserDTO payload,
                                          [Service] ITopicEventSender sender,
                                          [Service] Users users)
        {
            var user = mapper.Map<User>(payload);
            try
            {
                await users.UpdateAsync(user);
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
        public async Task<User> RemoveUser(UserDTO payload,
                                          [Service] ITopicEventSender sender,
                                          [Service] Users users)
        {
            var user = mapper.Map<User>(payload);
            try
            {
                await users.DeleteAsync(user.Id);
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
        #endregion Users
    }
}