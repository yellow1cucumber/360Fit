using StackExchange.Redis;

namespace API.Gate.GraphQl.Redis
{
    public class RedisConnection
    {
        private readonly IConfiguration configuration;

        public RedisConnection(IConfiguration configuration)
            => this.configuration = configuration;

        public ConfigurationOptions GetConfigurationOptions()
        {
            var url = this.configuration["Redis:URL"]
                ?? throw new NullReferenceException();
            var port = this.configuration["Redis:Port"]
                ?? throw new NullReferenceException();
            var user = this.configuration["Redis:User"]
                ?? throw new NullReferenceException();
            var password = this.configuration["Redis:Password"] 
                ?? throw new NullReferenceException();

            var options = new ConfigurationOptions()
            {
                EndPoints =
                {
                    { url, int.Parse(port) },
                },
                User = user,
                Password = password,
                Ssl = false,
            };

            return options;
        }
    }
}
