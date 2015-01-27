﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string UserMembershipId { get; set; }
        public int CompanyProfileId { get; set; }
        public int AreaCodeId { get; set; }
        public string DisplayName { get; set; }
        public string Number { get; set; }
        public AreaCode AreaCode { get; set; }
        public UserProfile UserProfile { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
    }
}
