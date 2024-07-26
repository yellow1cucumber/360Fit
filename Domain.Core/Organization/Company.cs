namespace Domain.Core.Organization
{
    public class Company : Model
    {
        public string PublicName { get; set; }
        public string Description {  get; set; }

        public Requisites Requisites { get; set; }
    }
}
