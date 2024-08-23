using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Sells.Service
{
    public class CardDTO
    {
        public string Barcode { get; set; }
        public UserDTO Owner { get; set; }

        public IEnumerable<ServiceDTO> ConnectedServices { get; set; }
    }
}
