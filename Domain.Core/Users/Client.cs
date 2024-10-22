using Domain.Core.Sells.Service;

using SlnAssembly.Attributes;

namespace Domain.Core.Users
{
    [DALRepository]
    public class Client : User
    {
        public DateOnly? LastVisit { get; set; }

        public Card? Card { get; set; }
        public double Deposit { get; set; }
    }
}
