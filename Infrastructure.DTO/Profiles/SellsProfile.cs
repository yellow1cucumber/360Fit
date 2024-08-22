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
            this.CreateMap<PaymentDate, PaymentDateDTO>();
            this.CreateMap<PaymentRule, PaymentRuleDTO>();
        }
        private void MapProducts()
        {
            this.CreateMap<CashRegister, CashRegisterDTO>();
            this.CreateMap<Nomenclature, NomenclatureDTO>();
            this.CreateMap<Product, ProductDTO>();
            this.CreateMap<StoragedProduct, StoragedProductDTO>();
            this.CreateMap<Storage, StorageDTO>();
            this.CreateMap<Supplier, SupplierDTO>();
        }
        private void MapService()
        {
            this.CreateMap<Card, CardDTO>();
            this.CreateMap<Service, ServiceDTO>();
        }
        private void MapSells()
        {
            this.CreateMap<Category, CategoryDTO>();
            this.CreateMap<Payment, PaymentDTO>();
            this.CreateMap<SalableObject, SalableObjectDTO>();
        }
    }
}
