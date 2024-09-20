using API.Gate.GraphQl.Exceptions;
using API.Gate.GraphQl.Subscriptions;
using AutoMapper;
using DAL;
using Domain.Core.Users;
using HotChocolate.Subscriptions;
using Infrastructure.DTO.Users;

namespace API.Gate.GraphQl.Mutations
{
    [ExtendObjectType("Mutations")]
    public class UsersMutation
    {
        private readonly Context context;
        private readonly Repository<User> usersRepository;
        private readonly Repository<UserCredentials> credentialsRepository;

        private readonly IMapper mapper;

        public UsersMutation([Service] Context context, IMapper mapper)
        {
            this.context = context;
            this.usersRepository = new Repository<User>(context);
            this.credentialsRepository = new Repository<UserCredentials>(context);

            this.mapper = mapper;
        }

        #region Users
        public async Task<User> CreateUser(UserDTO payload,
                                          [Service] ITopicEventSender sender)
        {
            var user = this.mapper.Map<User>(payload);
            await this.usersRepository.CreateAsync(user);
            await sender.SendAsync(nameof(UsersSubscription.OnUserCreated), user);
            return user;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<User> UpdateUser(UserDTO payload,
                                          [Service] ITopicEventSender sender)
        {
            var user = this.mapper.Map<User>(payload);
            try
            {
                await this.usersRepository.UpdateAsync(user);
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
                                          [Service] ITopicEventSender sender)
        {
            var user = this.mapper.Map<User>(payload);
            try
            {
                await this.usersRepository.DeleteAsync(user.Id);
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

        #region UserCredentials
        public async Task<UserCredentials> CreateUserCredentials(UserCredentialsDTO payload,
                                  [Service] ITopicEventSender sender)
        {
            var userCredentials = this.mapper.Map<UserCredentials>(payload);
            await this.credentialsRepository.CreateAsync(userCredentials);
            await sender.SendAsync(nameof(UsersSubscription.OnUserCredentialsCreated), userCredentials);
            return userCredentials;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<UserCredentials> UpdateUser(UserCredentialsDTO payload,
                                          [Service] ITopicEventSender sender)
        {
            var userCredentials = this.mapper.Map<UserCredentials>(payload);
            try
            {
                await this.credentialsRepository.UpdateAsync(userCredentials);
                await sender.SendAsync(nameof(UsersSubscription.OnUserCredentialsChanged), userCredentials);
                return userCredentials;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"UserCredentials with id == {userCredentials.Id} not found", userCredentials.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
