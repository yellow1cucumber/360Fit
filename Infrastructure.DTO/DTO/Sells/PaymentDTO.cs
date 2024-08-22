using Domain.Core.Organization;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Users;

namespace Domain.Core.Sells
{
    public class PaymentDTO
    {       
        public UserDTO Provider { get; set; }
        public UserDTO Customer { get; set; }

        public PaymentRuleDTO Rule { get; set; }

        public IEnumerable<SalableObjectDTO> Cart { get; set; }

        public bool IsCompleted { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
