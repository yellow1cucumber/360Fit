using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Sells.Service
{
    public class CardDTO
    {
        public string Barcode { get; set; }
        public int Owner { get; set; }

        public IEnumerable<ServiceDTO> ConnectedServices { get; set; }
    }
}
