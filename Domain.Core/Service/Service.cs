using Domain.Core.Sells;
using Domain.Core.Users;

namespace Domain.Core.Service
{
    public class Service : SalableObject
    {
        public Category Category { get; set; }
        public IEnumerable<User> Providers { get; set; }
    }
}
