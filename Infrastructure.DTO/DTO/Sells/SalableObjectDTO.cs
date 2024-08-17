namespace Domain.Core.Sells
{
    public class SalableObjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double PriceBuy { get; set; }
        public double PriceSell { get; set; }
    }
}
