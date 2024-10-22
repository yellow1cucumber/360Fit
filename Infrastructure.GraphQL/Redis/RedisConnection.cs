using Microsoft.Extensions.Configuration;

using StackExchange.Redis;

namespace Infrastructure.GraphQL.Redis
{
    public class RedisConnection
    {
        private readonly IConfiguration configuration;

        public RedisConnection(IConfiguration configuration)
            => this.configuration = configuration;

        public ConfigurationOptions GetConfigurationOptions()
        {
            var url = configuration["Redis:URL"]
                ?? throw new NullReferenceException();
            var port = configuration["Redis:Port"]
                ?? throw new NullReferenceException();
            var user = configuration["Redis:User"]
                ?? throw new NullReferenceException();
            var password = configuration["Redis:Password"]
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
