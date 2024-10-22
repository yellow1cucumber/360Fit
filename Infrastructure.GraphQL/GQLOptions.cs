using HotChocolate.Execution.Configuration;

namespace Infrastructure.GraphQL
{
    public class GQLOptions
    {
        public Action<IServiceProvider, IRequestExecutorBuilder> ConfigureSubscriptions { get; set; }
        public Action<IServiceProvider, IRequestExecutorBuilder> ConfigureDbContext { get; set; }
    }
}
