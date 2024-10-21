using Domain.Core.Users;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Subscriptions
{
    [GQLSubscription]
    [ExtendObjectType("Subscriptions")]
    public class UsersSubscription
    {

        #region Users
        [Subscribe]
        public User OnUserCreated([EventMessage] User user)
            => user;

        [Subscribe]
        public User OnUserChanged([EventMessage] User user)
            => user;

        [Subscribe]
        public User OnUserRemoved([EventMessage] User user)
            => user;
        #endregion

        #region Staff
        [Subscribe]
        public Staff OnStaffUserCreated([EventMessage] Staff user)
            => user;

        [Subscribe]
        public Staff OnStaffUserUpdated([EventMessage] Staff user)
            => user;

        [Subscribe]
        public Staff OnStaffUserRemoved([EventMessage] Staff user)
            => user;
        #endregion

        #region Clients
        [Subscribe]
        public Client OnClientCreated([EventMessage] Client client)
            => client;

        [Subscribe]
        public Client OnClientUpdated([EventMessage] Client client)
            => client;

        [Subscribe]
        public Client OnClientRemoved([EventMessage] Client client)
            => client;
        #endregion
    }
}
