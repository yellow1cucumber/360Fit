using Domain.Core.Organization;
using Domain.Core.Users;

namespace Domain.Core.Sells.Service
{
    public class ServiceDTO : SalableObjectDTO
    {
        public CategoryDTO Category { get; set; }
        public IEnumerable<UserDTO> Providers { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
