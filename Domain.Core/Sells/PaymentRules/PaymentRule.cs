using SlnAssembly.Attributes;

namespace Domain.Core.Sells.PaymentRules
{
    [DALRepository]
    public class PaymentRule : Model
    {
        public List<PaymentDate> Dates { get; set; }
    }
}
