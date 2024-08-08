using DAL;
using Domain.ClienLogging;

namespace API.Gate.GraphQl.Queries
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
