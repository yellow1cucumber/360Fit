using Domain.Core.Users;

namespace Domain.Core.Sells.Service
{
    public class Card : Model
    {
        public string Barcode { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Service> ConnectedServices { get; set; }
    }
}
