namespace Domain.Core.Organization
{
    public class Contacts : Model
    {
        public IEnumerable<string> Phones { get; set; }
        public IEnumerable<string> Emails { get; set; }
    }
}
