﻿using Domain.Core.Organization;
using Domain.Core.Users;

namespace Domain.Core.Sells.Service
{
    public class Service : SalableObject
    {
        public Category Category { get; set; }
        public IEnumerable<User> Providers { get; set; }

        public Company Company { get; set; }
    }
}
