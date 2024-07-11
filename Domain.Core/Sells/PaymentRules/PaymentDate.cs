namespace Domain.Core.Sells.PaymentRules
{
    public class PaymentDate : Model
    {
        public DateOnly Date { get; set; }
        public double Price { get; set; }
    }
}
