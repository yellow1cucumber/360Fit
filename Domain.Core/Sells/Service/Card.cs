using SlnAssembly.Attributes;

namespace Domain.Core.Sells.Service
{
    [DALRepository]
    public class Card : Model
    {
        public string Barcode { get; set; }
        public int Owner { get; set; } //UserId

        public IEnumerable<Service> ConnectedServices { get; set; }
    }
}
