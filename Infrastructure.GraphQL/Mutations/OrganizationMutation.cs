using AutoMapper;

using DAL;

using Domain.Core.Organization;
using Domain.Core.Organization.Contact;

using HotChocolate.Subscriptions;

using Infrastructure.DTO.Organization;
using Infrastructure.DTO.Organization.Contact;
using Infrastructure.GraphQL.Attributes;
using Infrastructure.GraphQL.Exceptions;
using Infrastructure.GraphQL.Subscriptions;


namespace Infrastructure.GraphQL.Mutations
{
    [GQLMutation]
    [ExtendObjectType("Mutations")]
    internal class OrganizationMutation
    {
        private readonly IMapper mapper;

        public OrganizationMutation(IMapper mapper)
            => this.mapper = mapper;

        #region Company
        [UseSorting]
        [UseFiltering]
        public async Task<Company> CreateCompany(CompanyDTO payload,
                                                [Service] ITopicEventSender sender,
                                                [Service] Repository<Company> repository)
        {
            var company = this.mapper.Map<Company>(payload);
            await repository.CreateAsync(company);
            await sender.SendAsync(nameof(OrganizationSubscriptions.OnCompanyCreated), company);
            return company;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Company> UpdateCompany(Company payload,
                                                 [Service] ITopicEventSender sender,
                                                 [Service] Repository<Company> repository)
        {
            var company = mapper.Map<Company>(payload);
            try
            {
                await repository.UpdateAsync(company);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnCompanyChanged), company);
                return company;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Company with id == {company.Id} not found", company.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseSorting]
        [UseFiltering]
        public async Task RemoveCompany (int id,
                                        [Service] ITopicEventSender sender,
                                        [Service] Repository<Company> repository)
        {
            var company = await repository.GetAsync(id);
            try
            {
                await repository.DeleteAsync(id);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnCompanyRemoved), company);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Company with id == {id} not found", id);
            }
            catch
            {
                throw;
            }
        }
        #endregion


        #region BankRequisites
        [UseSorting]
        [UseFiltering]
        public async Task<BankRequisites> CreateBankRequisites(BankRequisitesDTO payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Repository<BankRequisites> repository)
        {
            var requisites = this.mapper.Map<BankRequisites>(payload);
            await repository.CreateAsync(requisites);
            await sender.SendAsync(nameof(OrganizationSubscriptions.OnBankRequisitesCreated), requisites);
            return requisites;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<BankRequisites> UpdateBankRequisites(BankRequisites payload,
                                                               [Service] ITopicEventSender sender,
                                                               [Service] Repository<BankRequisites> repository)
        {
            var bankRequisites = mapper.Map<BankRequisites>(payload);
            try
            {
                await repository.UpdateAsync(bankRequisites);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnBankRequisitesCreated), bankRequisites);
                return bankRequisites;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"BankRequisites with id == {bankRequisites.Id} not found", bankRequisites.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseSorting]
        [UseFiltering]
        public async Task RemoveBankRequisites(int id,
                                               [Service] ITopicEventSender sender,
                                               [Service] Repository<BankRequisites> repository)
        {
            var bankRequisites = await repository.GetAsync(id);
            try
            {
                await repository.DeleteAsync(id);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnBankRequisitesCreated), bankRequisites);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"BankRequisites with id == {id} not found", id);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Requisites
        [UseSorting]
        [UseFiltering]
        public async Task<Requisites> CreateRequisites(Requisites payload,
                                                       [Service] ITopicEventSender sender,
                                                       [Service] Repository<Requisites> repository)
        {
            var requisites = this.mapper.Map<Requisites>(payload);
            await sender.SendAsync(nameof(OrganizationSubscriptions.OnRequisitesCreated), requisites);
            await repository.CreateAsync(requisites);
            return requisites;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Requisites> UpdateRequisites(Requisites payload,
                                                       [Service] ITopicEventSender sender,
                                                       [Service] Repository<Requisites> repository)
        {
            var requisites = mapper.Map<Requisites>(payload);
            try
            {
                await repository.UpdateAsync(requisites);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnRequisitesChanged), requisites);
                return requisites;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Requisites with id == {requisites.Id} not found", requisites.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseSorting]
        [UseFiltering]
        public async Task RemoveRequisites(int id,
                                           [Service] ITopicEventSender sender,
                                           [Service] Repository<BankRequisites> repository)
        {
            var requisites = await repository.GetAsync(id);
            try
            {
                await repository.DeleteAsync(id);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnRequisitesRemoved), requisites);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Requisites with id == {id} not found", id);
            }
            catch
            {
                throw;
            }
        }
        #endregion


        #region Contacts
        [UseSorting]
        [UseFiltering]
        public async Task<Contacts> CreateContacts(ContactsDTO payload,
                                                   [Service] ITopicEventSender sender,
                                                   [Service] Repository<Contacts> repository)
        {
            var contacts = this.mapper.Map<Contacts>(payload);
            await repository.CreateAsync(contacts);
            await sender.SendAsync(nameof(OrganizationSubscriptions.OnContactsCreated), contacts);
            return contacts;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Contacts> UpdateContacts(ContactsDTO payload,
                                                   [Service] ITopicEventSender sender,
                                                   [Service] Repository<Contacts> repository)
        {
            var contacts = mapper.Map<Contacts>(payload);
            try
            {
                await repository.UpdateAsync(contacts);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnContactsChanged), contacts);
                return contacts;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Contacts with id == {contacts.Id} not found", contacts.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseSorting]
        [UseFiltering]
        public async Task RemoveContacts(int id,
                                         [Service] ITopicEventSender sender,
                                         [Service] Repository<Contacts> repository)
        {
            var contacts = await repository.GetAsync(id);
            try
            {
                await repository.DeleteAsync(id);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnContactsRemoved), contacts);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"Contacts with id == {id} not found", id);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Contacts
        [UseSorting]
        [UseFiltering]
        public async Task<PhoneNumber> CreatePhoneNumber(PhoneNumber payload,
                                                        [Service] ITopicEventSender sender,
                                                        [Service] Repository<PhoneNumber> repository)
        {
            var phone = this.mapper.Map<PhoneNumber>(payload);
            await repository.CreateAsync(phone);
            await sender.SendAsync(nameof(OrganizationSubscriptions.OnPhoneNumberCreated), phone);
            return phone;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<PhoneNumber> UpdatePhoneNumber(PhoneNumberDTO payload,
                                                   [Service] ITopicEventSender sender,
                                                   [Service] Repository<PhoneNumber> repository)
        {
            var phone = mapper.Map<PhoneNumber>(payload);
            try
            {
                await repository.UpdateAsync(phone);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnPhoneNumberChanged), phone);
                return phone;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PhoneNumber with id == {phone.Id} not found", phone.Id);
            }
            catch
            {
                throw;
            }
        }

        [UseSorting]
        [UseFiltering]
        public async Task RemovePhoneNumber(int id,
                                            [Service] ITopicEventSender sender,
                                            [Service] Repository<PhoneNumber> repository)
        {
            var phone = await repository.GetAsync(id);
            try
            {
                await repository.DeleteAsync(id);
                await sender.SendAsync(nameof(OrganizationSubscriptions.OnPhoneNumberRemoved), phone);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFound($"PhoneNumber with id == {id} not found", id);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
