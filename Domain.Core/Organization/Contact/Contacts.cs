namespace Domain.Core.Organization.Contact
{
    public class Contacts : Model
    {
        public IEnumerable<PhoneNumber> Phones { get; set; }
        public IEnumerable<string> Emails { get; set; }

        public string Instagram { get; set; }
        public string WebSite { get; set; }
        public string LinkedIn { get; set; }
    }
}
