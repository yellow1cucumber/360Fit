using Domain.Barcode.Generators;
using Domain.Cards;

using Infrastructure.DTO.Sells.Service;
using Infrastructure.DTO.Users;

namespace Domain.Barcode
{
    public class CardService : ICardService
    {
        public CardDTO GenerateCard(UserDTO owner, 
                                    IBarcodeGenerator generator)
        {
            var barcode = generator.GenerateBarcode();
            return new CardDTO
            {
                Owner = owner,
                Barcode = barcode,
                ConnectedServices = []
            };
        }
    }
}
