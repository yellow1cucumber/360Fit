using Domain.Core.Organization;
using Domain.Core.Organization.Contact;

using Infrastructure.GraphQL.Attributes;

namespace Infrastructure.GraphQL.Subscriptions
{
    [GQLSubscription]
    [ExtendObjectType("Subscriptions")]
    class OrganizationSubscriptions
    {
        #region Company
        [Subscribe]
        public Company OnCompanyCreated([EventMessage] Company company)
            => company;

        public Company OnCompanyChanged([EventMessage] Company company)
            => company;

        public Company OnCompanyRemoved([EventMessage] Company company)
            => company;
        #endregion


        #region BankRequisites
        public BankRequisites OnBankRequisitesCreated([EventMessage] BankRequisites bankRequisites)
            => bankRequisites;

        public BankRequisites OnBankRequisitesChanged([EventMessage] BankRequisites bankRequisites)
                    => bankRequisites;

        public BankRequisites OnBankRequisitesRemoved([EventMessage] BankRequisites bankRequisites)
                    => bankRequisites;
        #endregion


        #region Requisites
        public Requisites OnRequisitesCreated([EventMessage] Requisites requisites)
            => requisites;

        public Requisites OnRequisitesChanged([EventMessage] Requisites requisites)
            => requisites;

        public Requisites OnRequisitesRemoved([EventMessage] Requisites requisites)
            => requisites;
        #endregion


        #region Contacts
        public Contacts OnContactsCreated([EventMessage] Contacts contacts)
            => contacts;

        public Contacts OnContactsChanged([EventMessage] Contacts contacts)
            => contacts;

        public Contacts OnContactsRemoved([EventMessage] Contacts contacts)
            => contacts;
        #endregion


        #region PhoneNumber
        public PhoneNumber OnPhoneNumberCreated([EventMessage] PhoneNumber phoneNumber)
            => phoneNumber;

        public PhoneNumber OnPhoneNumberChanged([EventMessage] PhoneNumber phoneNumber)
            => phoneNumber;

        public PhoneNumber OnPhoneNumberRemoved([EventMessage] PhoneNumber phoneNumber)
            => phoneNumber;
        #endregion
    }
}
