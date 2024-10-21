using Infrastructure.DTO.Users;
using Domain.Core.Organization;

namespace Infrastructure.DTO.Organization
{
    public class RequisitesDTO
    {
        public Requisites.OrganizationTypes OrganizationType { get; set; }

        public string NameKZ { get; set; }
        public string NameRU { get; set; }
        public string? NameEN { get; set; }

        public StaffDTO? Director { get; set; }

        public string? BIN { get; set; }
        public string? KBE { get; set; }

        public string? LegalAddress { get; set; }
        public string? PhysicalAddress { get; set; }

        public IEnumerable<BankRequisitesDTO> BankRequisites { get; set; }
    }
}
