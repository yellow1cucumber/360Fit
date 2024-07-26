namespace Domain.Core.Organization.Contact
{
    public class Contacts : Model
    {
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<string> Emails { get; set; }
    }
}
