using Domain.Core.Users;

namespace Domain.Core.Organization
{
    public class RequisitesDTO
    {
        public OrganizationTypes OrganizationType { get; set; }

        public string NameKZ { get; set; }
        public string NameRU { get; set; }
        public string? NameEN { get; set; }
        
        public UserDTO? Director { get; set; }

        public string? BIN { get; set; }
        public string? KBE { get; set; }

        public string? LegalAddress { get; set; }
        public string? PhysicalAddress {  get; set; }

        public IEnumerable<BankRequisitesDTO> BankRequisites { get; set; }


        public enum OrganizationTypes
        {
            IE = 0,
            LLP = 1,
            JSC = 2,
        }
    }
}
