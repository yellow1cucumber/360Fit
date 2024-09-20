using DAL;
using Domain.ClienLogging;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Queries
{
    [GQLQuery]
    [ExtendObjectType("Query")]
    public class ClientLogsQuery
    {
        [UseSorting]
        [UseFiltering]
        public IQueryable<ClientLog> ReadLogs(Context context)
            => context.ClientLogs.AsQueryable();
    }
}
