using DAL;
using Domain.Core.Users;

namespace API.Gate.GraphQl
{
    public class Query
    {
        private readonly Context context;
        public Query(Context context) 
            => this.context = context ?? throw new ArgumentNullException(nameof(context));

        public List<User> ReadUsers()
        {
            return this.context.Users.ToList();
        }
    }
}
