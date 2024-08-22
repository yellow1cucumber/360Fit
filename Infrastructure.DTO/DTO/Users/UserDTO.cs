﻿namespace Domain.Core.Users
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string? Email { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public UserCredentialsDTO Credentials { get; set; }
        
    }
}
