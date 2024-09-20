using DAL;
using Domain.ClienLogging;

namespace Infrastructure.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ClientLogsQuery
    {
        [UseSorting]
        [UseFiltering]
        public IQueryable<ClientLog> ReadLogs(Context context)
            => context.ClientLogs.AsQueryable();
    }
}
