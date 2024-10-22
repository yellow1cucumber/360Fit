using Domain.Barcode.Generators;

using Infrastructure.DTO.Sells.Service;

namespace Domain.Cards
{
    public interface ICardService
    {
        public CardDTO GenerateCard(int ownerId, 
                                    IBarcodeGenerator generator);
    }
}
