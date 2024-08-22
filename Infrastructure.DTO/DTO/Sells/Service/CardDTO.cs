using Domain.Core.Users;

namespace Domain.Core.Sells.Service
{
    public class CardDTO
    {
        public string Barcode { get; set; }
        public UserDTO Owner { get; set; }

        public IEnumerable<ServiceDTO> ConnectedServices { get; set; }
    }
}
