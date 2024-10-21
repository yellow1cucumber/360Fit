﻿using Domain.Core.Organization.Contact;

namespace Domain.Core.Users
{
    public class User : Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronomic { get; set; }
        public string? Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateOnly? DateOfBirth { get; set; }
    }
}
