using Domain.Core.Users;

using SlnAssembly.Attributes;

namespace Domain.Core.Organization
{
    [DALRepository]
    public class Requisites : Model
    {
        public OrganizationTypes OrganizationType { get; set; }

        public string NameKZ { get; set; }
        public string NameRU { get; set; }
        public string? NameEN { get; set; }
        
        public User? Director { get; set; }

        public string? BIN { get; set; }
        public string? KBE { get; set; }

        public string? LegalAddress { get; set; }
        public string? PhysicalAddress {  get; set; }

        public IEnumerable<BankRequisites> BankRequisites { get; set; }


        public enum OrganizationTypes
        {
            IE = 0,
            LLP = 1,
            JSC = 2,
        }
    }
}
