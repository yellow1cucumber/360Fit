namespace Domain.ClienLogging
{
    public class ClientLogDTO
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public ClientLog.Types Type { get; set; }
        public IEnumerable<ClientLog.SenderTags> Senders {  get; set; }
    }
}
