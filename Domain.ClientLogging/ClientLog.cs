using Domain.Core;

using SlnAssembly.Attributes;

namespace Domain.ClienLogging
{
    [DALRepository]
    public class ClientLog : Model
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public Types Type { get; set; }
        public IEnumerable<SenderTags> Senders {  get; set; }

        public enum Types
        {
            Succsessfull = 0,
            Warning = 1,
            Error = 2,
            Log = 3,
            System = 4
        }

        public enum SenderTags
        {
            Clients = 0,
            Sells = 1,
            Service = 2,
            Organization = 3,
        }
    }
}
