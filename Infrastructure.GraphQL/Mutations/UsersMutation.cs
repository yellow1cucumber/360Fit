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
        public async Task<User> UpdateUser(User payload,
                                          [Service] ITopicEventSender sender,
                                          [Service] Users users)
        {
            try
            {
                await users.UpdateAsync(payload);
                await sender.SendAsync(nameof(UsersSubscription.OnUserChanged), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"User with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<User> RemoveUser(User payload,
                                          [Service] ITopicEventSender sender,
                                          [Service] Users users)
        {
            try
            {
                await users.DeleteAsync(payload.Id);
                await sender.SendAsync(nameof(UsersSubscription.OnUserRemoved), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"User with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion Users
    }
}