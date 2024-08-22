using Infrastructure.DTO.Organization;
using Infrastructure.DTO.Users;

namespace Infrastructure.DTO.Sells.Service
{
    public class ServiceDTO : SalableObjectDTO
    {
        public CategoryDTO Category { get; set; }
        public IEnumerable<UserDTO> Providers { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
