using SlnAssembly.Attributes;

namespace Domain.Core.Organization
{
    [DALRepository]
    public class BankRequisites : Model
    {
        public string Name { get; set; }
        public string IIK { get; set; }
        public string BIK { get; set; }
    }
}
