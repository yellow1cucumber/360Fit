using Domain.Barcode.Generators;
using Domain.Cards;

using Infrastructure.DTO.Sells.Service;
using Infrastructure.DTO.Users;

namespace Domain.Barcode
{
    public class CardService : ICardService
    {
        public CardDTO GenerateCard(int ownerId, 
                                    IBarcodeGenerator generator)
        {
            var barcode = generator.GenerateBarcode();
            return new CardDTO
            {
                Owner = ownerId,
                Barcode = barcode,
                ConnectedServices = []
            };
        }
    }
}
