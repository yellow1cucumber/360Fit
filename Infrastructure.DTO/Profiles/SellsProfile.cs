using AutoMapper;
using Domain.Core.Sells;
using Domain.Core.Sells.PaymentRules;
using Domain.Core.Sells.Products;
using Domain.Core.Sells.Service;

namespace Infrastructure.DTO.Profiles
{
    public class SellsProfile : Profile
    {
        public SellsProfile()
        {
            this.MapSells();
            this.MapPayment();
            this.MapProducts();
            this.MapService();
        }

        private void MapPayment()
        {
            this.CreateMap<PaymentDate, PaymentDateDTO>().ReverseMap();
            this.CreateMap<PaymentRule, PaymentRuleDTO>().ReverseMap();
        }
        private void MapProducts()
        {
            this.CreateMap<CashRegister, CashRegisterDTO>().ReverseMap();
            this.CreateMap<Nomenclature, NomenclatureDTO>().ReverseMap();
            this.CreateMap<Product, ProductDTO>().ReverseMap();
            this.CreateMap<StoragedProduct, StoragedProductDTO>().ReverseMap();
            this.CreateMap<Storage, StorageDTO>().ReverseMap();
            this.CreateMap<Supplier, SupplierDTO>().ReverseMap();
        }
        private void MapService()
        {
            this.CreateMap<Card, CardDTO>().ReverseMap();
            this.CreateMap<Service, ServiceDTO>().ReverseMap();
        }
        private void MapSells()
        {
            this.CreateMap<Category, CategoryDTO>().ReverseMap();
            this.CreateMap<Payment, PaymentDTO>().ReverseMap();
            this.CreateMap<SalableObject, SalableObjectDTO>().ReverseMap();
        }
    }
}
