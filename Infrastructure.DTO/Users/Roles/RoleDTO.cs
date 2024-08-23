using Domain.Core.Organization;

namespace Infrastructure.DTO.Users.Roles
{
    public class RoleDTO
    {
        public Domain.Core.Users.Roles.Role.Type UserType { get; set; }
        public Company Company { get; set; }
    }
}
