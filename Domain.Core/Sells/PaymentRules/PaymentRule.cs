namespace Domain.Core.Sells.PaymentRules
{
    public class PaymentRule : Model
    {
        public List<PaymentDate> Dates { get; set; }
    }
}
