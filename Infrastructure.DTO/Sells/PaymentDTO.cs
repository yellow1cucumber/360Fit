using Infrastructure.DTO.Organization;
using Infrastructure.DTO.Sells.PaymentRules;
using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Sells
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
