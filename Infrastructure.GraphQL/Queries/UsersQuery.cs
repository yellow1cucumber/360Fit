using DAL;
using Domain.Core.Users;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Queries
{
    [GQLQuery]
    [ExtendObjectType("Query")]
    public class UsersQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Staff> ReadStaff(Context context, int companyId)
            => context.Staff.Where(x => x.CompanyId == companyId).AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Client> ReadClients(Context context, int companyId)
            => context.Clients.Where(x => x.CompanyId == companyId).AsQueryable();
    }
}
