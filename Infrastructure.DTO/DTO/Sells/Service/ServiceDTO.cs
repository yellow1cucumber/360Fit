using Infrastructure.DTO.Organization;

namespace Infrastructure.DTO.Sells.Service
{
    public class ServiceDTO : SalableObjectDTO
    {
        public CategoryDTO Category { get; set; }
        public IEnumerable<UserDTO> Providers { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
