﻿using Infrastructure.DTO.Organization.Contact;
using Infrastructure.DTO.Users.Roles;

namespace Infrastructure.DTO.Users
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string? Email { get; set; }
        public PhoneNumberDTO PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
