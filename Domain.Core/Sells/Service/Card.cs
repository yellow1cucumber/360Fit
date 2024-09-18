using Domain.Core.Users;

namespace Domain.Core.Sells.Service
{
    public class Card : Model
    {
        public string Barcode { get; set; }
        public int Owner { get; set; } //UserId

        public IEnumerable<Service> ConnectedServices { get; set; }
    }
}
