namespace Domain.Core.Users.Roles
{
    public class Role : Model
    {
        public int UserId { get; set; }
        public Type UserType { get; set; }
        public int CompanyId { get; set; }

        public enum Type
        {
            Owner = 0,
            Admin = 1,
            Specialist = 2,
            Client = 3
        }
    }
}
