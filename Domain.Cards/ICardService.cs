using Domain.Barcode.Generators;

using Infrastructure.DTO.Sells.Service;
using Infrastructure.DTO.Users;

namespace Domain.Cards
{
    public interface ICardService
    {
        public CardDTO GenerateCard(UserDTO owner, 
                                    IBarcodeGenerator generator);
    }
}
