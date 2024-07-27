﻿using Domain.Core.Organization.Contact;
using Domain.Core.Users;

namespace Domain.Core.Organization
{
    public class Company : Model
    {
        public string PublicName { get; set; }
        public string Description {  get; set; }

        public CompanyCategory Category { get; set; }

        public Requisites Requisites { get; set; }
        public Contacts Contacts { get; set; }

        public IEnumerable<User> Staff { get; set; }
        public IEnumerable<User> Clients { get; set; }

        public enum CompanyCategory
        {
            Developer = 0,
            FitnessCentre = 1,
            SportsNutritionStore = 2,
            SportsNutritionSupplier = 3
        }
    }
}
