﻿using DAL;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Queries
{
    [GQLQuery]
    [ExtendObjectType("Query")]
    public class SellsQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PaymentDate> ReadPaymentDates(Context context)
            => context.PaymentDates.AsQueryable();

        [UseProjection]
        [UseFiltering]
        public IQueryable<PaymentRule> ReadPaymentRules(Context context)
            => context.PaymentRules.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Payment> ReadPayments(Context context)
            => context.Payments.AsQueryable();
    }
}
