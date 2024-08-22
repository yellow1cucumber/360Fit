using AutoMapper;
using Domain.Core.Organization;
using Domain.Core.Organization.Contact;

namespace Infrastructure.DTO.Profiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            this.CreateMap<Contacts, ContactsDTO>();
            this.CreateMap<PhoneNumber, PhoneNumberDTO>();
            this.CreateMap<BankRequisites, BankRequisitesDTO>();
            this.CreateMap<Company, CompanyDTO>();
            this.CreateMap<Requisites, RequisitesDTO>();
        }
    }
}
