namespace Domain.Core.Organization
{
    public class Company
    {
        public int Id { get; set; }

        public string PublicName { get; set; }
        public string Description {  get; set; }

        public Requisites Requisites { get; set; }
    }
}
