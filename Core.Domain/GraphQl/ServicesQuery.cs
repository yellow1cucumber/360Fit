using DAL;
using Domain.Core.Sells.Service;

namespace API.Gate.GraphQl
{
    public class ServicesQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Card> ReadCards(Context context)
            => context.Cards.AsQueryable();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Service> ReadServices(Context context)
            => context.Services.AsQueryable();
    }
}
