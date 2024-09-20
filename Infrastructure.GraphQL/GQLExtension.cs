using System.Reflection;

using DAL;

using HotChocolate.Execution.Configuration;
using Infrastructure.GraphQL.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.GraphQL
{
    public static class GQLExtension
    {
        public static IServiceCollection AddGQLService(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                    .RegisterDbContext<Context>()
                    .AddProjections()
                    .AddFiltering()
                    .AddSorting();

            return services;
        }

        private static IRequestExecutorBuilder AddQueries(this IRequestExecutorBuilder builder)
        {
            builder.AddQueryType(q => q.Name("Query"));
            return builder;
        }

        private static IRequestExecutorBuilder AddMutations(this IRequestExecutorBuilder builder)
        {
            builder.AddMutationType(m => m.Name("Mutations"));
            return builder;
        }

        private static IRequestExecutorBuilder AddSubscriptions(this IRequestExecutorBuilder builder)
        {
            builder.AddSubscriptionType(s => s.Name("Subscriptions"));
            return builder;
        }

        private static IEnumerable<Type> GetQueryTypes(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(GQLQuery), true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
