using Domain.Core.Organization;

namespace Domain.Core.Users.Roles
{
    public class Role
    {
        public Type UserType { get; set; }
        public Company Company { get; set; }

        public enum Type
        {
            Owner = 0,
            Admin = 1,
            Specialist = 2,
            Client = 3
        }
    }
}
