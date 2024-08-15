using Domain.Core.Users;

namespace API.Gate.GraphQl.Subscriptions
{
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

        #region UserCredentials
        public UserCredentials OnUserCredentialsCreated([EventMessage] UserCredentials userCredentials)
            => userCredentials;

        [Subscribe]
        public UserCredentials OnUserCredentialsChanged([EventMessage] UserCredentials userCredentials)
            => userCredentials;
        #endregion
    }
}
