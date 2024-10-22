using AutoMapper;
using HotChocolate.Subscriptions;

using Domain.Core.Users;
using Domain.Cards;

using Infrastructure.DTO.Users;

using Infrastructure.GraphQL.Subscriptions;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Attributes;



#region TYPEDEF
using Users = DAL.Repository<Domain.Core.Users.User>;
using Staffs = DAL.Repository<Domain.Core.Users.Staff>;
using Clients = DAL.Repository<Domain.Core.Users.Client>;
using Infrastructure.DTO.Sells.Service;
using Domain.Barcode.Generators;
using Domain.Core.Sells.Service;
#endregion

namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    public class UsersMutation(IMapper mapper, 
                               ICardService cardService)
    {
        private readonly IMapper mapper = mapper;
        private readonly ICardService cardService = cardService;

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

        #region Staff
        public async Task<Staff> CreateStaffUser(StaffDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Staffs staff)
        {
            var staffUser = mapper.Map<Staff>(payload);
            await staff.CreateAsync(staffUser);
            await sender.SendAsync(nameof(UsersSubscription.OnStaffUserCreated), staff);
            return staffUser;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Staff> UpdateStaffUser(Staff payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Staffs staff)
        {
            try
            {
                await staff.UpdateAsync(payload);
                await sender.SendAsync(nameof(UsersSubscription.OnStaffUserUpdated), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Staff user with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Staff> RemoveStaffUser(Staff payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Staffs staff)
        {
            try
            {
                await staff.DeleteAsync(payload.Id);
                await sender.SendAsync(nameof(UsersSubscription.OnStaffUserRemoved), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Staff with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Client
        public async Task<Client> CreateClient(ClientDTO payload,
                                              [Service] ITopicEventSender sender,
                                              [Service] Clients clients)
        {
            var client = this.mapper.Map<Client>(payload);

            await clients.CreateAsync(client);

            var cardDto = this.GenerateCard(client);
            var card = this.mapper.Map<Card>(cardDto);

            client.Card = card;

            await clients.UpdateAsync(client);

            await sender.SendAsync(nameof(UsersSubscription.OnClientCreated), client);
            return client;
        }

        [UseProjection]
        [UseFiltering]
        public async Task<Client> UpdateClient(Client payload,
                                              [Service] ITopicEventSender sender,
                                              [Service] Clients clients)
        {
            try
            {
                await clients.UpdateAsync(payload);
                await sender.SendAsync(nameof(UsersSubscription.OnClientUpdated), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Client with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }


        [UseFiltering]
        public async Task<Client> RemoveClient(Client payload,
                                              [Service] ITopicEventSender sender,
                                              [Service] Clients clients)
        {
            try
            {
                await clients.DeleteAsync(payload.Id);
                await sender.SendAsync(nameof(UsersSubscription.OnStaffUserRemoved), payload);
                return payload;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Client with id == {payload.Id} not found", payload.Id);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region UTILS
        private CardDTO GenerateCard(Client client)
        {
            IBarcodeGenerator generator = new HashBarcodeGenerator<Client>(client, 3);
            CardDTO card = this.cardService.GenerateCard(client.Id, generator);
            return card;
        }
        #endregion
    }
}