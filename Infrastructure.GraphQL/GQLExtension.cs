using System.Reflection;

using DAL;

using HotChocolate.Execution.Configuration;
using Infrastructure.GraphQL.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.GraphQL
{
    public static class GQLExtension
    {
        public static IServiceCollection AddGQLService(this IServiceCollection services, Action<GQLOptions> configureOptions)
        {
            var gqlOptions = new GQLOptions();
            configureOptions?.Invoke(gqlOptions);

            var graphQLBuilder = services.AddGraphQLServer()
                                         .RegisterDbContext<Context>()
                                         .AddProjections()
                                         .AddFiltering()
                                         .AddSorting()
                                         .AddQueries()
                                         .AddMutations()
                                         .AddSubscriptions();

            gqlOptions.ConfigureSubscriptions?.Invoke(services.BuildServiceProvider(), graphQLBuilder);

            return services;
        }


        private static IRequestExecutorBuilder AddQueries(this IRequestExecutorBuilder builder)
        {
            builder.AddQueryType(q => q.Name("Query"));
            var queries = GetGQLTypes(Assembly.GetExecutingAssembly(), typeof(GQLQuery));

            foreach (var query in queries)
            {
                builder.AddType(query);
            }
            return builder;
        }

        private static IRequestExecutorBuilder AddMutations(this IRequestExecutorBuilder builder)
        {
            builder.AddMutationType(m => m.Name("Mutations"));
            var queries = GetGQLTypes(Assembly.GetExecutingAssembly(), typeof(GQLMutation));

            foreach (var query in queries)
            {
                builder.AddType(query);
            }
            return builder;
        }

        private static IRequestExecutorBuilder AddSubscriptions(this IRequestExecutorBuilder builder)
        {
            builder.AddSubscriptionType(s => s.Name("Subscriptions"));
            var queries = GetGQLTypes(Assembly.GetExecutingAssembly(), typeof(GQLSubscription));

            foreach (var query in queries)
            {
                builder.AddType(query);
            }
            return builder;
        }

        private static IEnumerable<Type> GetGQLTypes(Assembly assembly, Type gqlType)
        {
            if (!gqlType.IsSubclassOf(typeof(GQLAttribute)))
            {
                throw new ArgumentException("Invalid argument. gqlType is not inherits GQLAttributes.", gqlType.Name);
            }
            
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(gqlType, true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
