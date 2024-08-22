using AutoMapper;
using Domain.Core.Organization;
using Domain.Core.Organization.Contact;
using Infrastructure.DTO.Organization;
using Infrastructure.DTO.Organization.Contact;

namespace Infrastructure.DTO.Profiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            this.CreateMap<Contacts, ContactsDTO>().ReverseMap();
            this.CreateMap<PhoneNumber, PhoneNumberDTO>().ReverseMap();
            this.CreateMap<BankRequisites, BankRequisitesDTO>().ReverseMap();
            this.CreateMap<Company, CompanyDTO>().ReverseMap();
            this.CreateMap<Requisites, RequisitesDTO>().ReverseMap();
        }
    }
}
