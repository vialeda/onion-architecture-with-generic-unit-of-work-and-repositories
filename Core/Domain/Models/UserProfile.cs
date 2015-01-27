using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Interfaces;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    /// <summary>
    /// Extra personnal informations for user.
    /// </summary>
    public class UserProfile : Entity, IAdress
    {
        public int UserMembershipId { get; set; }
        public int MunicipalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string PostalBox { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual UserMembership UserMembership { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
