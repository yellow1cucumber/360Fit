using Domain.Core.Users;

namespace API.Gate.GraphQl.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class UsersSubscription
    {
        [Subscribe]
        public User OnUserCreated([EventMessage] User user)
            => user;

        [Subscribe]
        public User OnUserChanged([EventMessage] User user)
            => user;
    }
}
