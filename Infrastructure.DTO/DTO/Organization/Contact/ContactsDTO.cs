namespace Domain.Core.Organization.Contact
{
    public class ContactsDTO
    {
        public IEnumerable<PhoneNumberDTO> Phones { get; set; }
        public IEnumerable<string> Emails { get; set; }

        public string Instagram { get; set; }
        public string WebSite { get; set; }
        public string LinkedIn { get; set; }
    }
}
