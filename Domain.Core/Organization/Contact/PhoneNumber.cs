using SlnAssembly.Attributes;

namespace Domain.Core.Organization.Contact
{
    [DALRepository]
    public class PhoneNumber : Model
    {
        public string Number { get; set; }
        public bool WhatsApp { get; set; }
    }
}
