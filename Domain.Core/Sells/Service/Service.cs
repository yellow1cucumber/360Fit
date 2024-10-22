using Domain.Core.Organization;
using Domain.Core.Users;

using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Service
{
    [DALRepository]
    public class Service : SalableObject
    {
        public Category Category { get; set; }
        public IEnumerable<User> Providers { get; set; }

        public Company Company { get; set; }
    }
}
