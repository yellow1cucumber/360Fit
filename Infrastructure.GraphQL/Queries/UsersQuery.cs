﻿using DAL;
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
        public IQueryable<User> ReadUsers(Context context)
            => context.Users.AsQueryable();
    }
}
