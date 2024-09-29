﻿using Domain.Core.Users;

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
    }
}
