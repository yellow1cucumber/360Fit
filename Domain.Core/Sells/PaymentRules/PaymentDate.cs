using SlnAssembly.Attributes;

namespace Domain.Core.Sells.PaymentRules
{
    [DALRepository]
    public class PaymentDate : Model
    {
        public DateOnly Date { get; set; }
        public double Price { get; set; }
    }
}
