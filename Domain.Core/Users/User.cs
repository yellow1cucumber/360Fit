namespace Domain.Core.Users
{
    public class User : Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronomic { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Roles Role { get; set; }      
        
        public enum Roles
        {
            Owner = 0,
            Admin = 1,
            Specialist = 2,
            Client = 3
        }
    }
}
