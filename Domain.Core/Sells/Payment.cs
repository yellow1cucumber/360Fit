using Domain.Core.Organization;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Users;

namespace Domain.Core.Sells
{
    public class Payment : Model
    {       
        public User Provider { get; set; }
        public User Customer { get; set; }

        public PaymentRule Rule { get; set; }

        public IEnumerable<SalableObject> Cart { get; set; }

        public bool IsCompleted { get; set; }

        public Company Company { get; set; }
    }
}
