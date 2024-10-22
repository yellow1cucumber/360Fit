using DAL;

using Domain.Core.Organization;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Queries
{
    [GQLQuery]
    [ExtendObjectType("Query")]
    public class OrganizationQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Company> ReadCompanies([Service] Repository<Company> companies)
            => companies.GetAll();
    }
}
