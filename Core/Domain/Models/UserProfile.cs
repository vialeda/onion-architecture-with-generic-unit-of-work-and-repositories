using System.Collections.Generic;
using Viainternet.OnionArchitecture.Core.Interfaces;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    /// <summary>
    /// Extra personnal informations for user.
    /// </summary>
    public class UserProfile : Entity, IAdress
    {
        public UserProfile()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
        }
        public string UserMembershipId { get; set; }
        public int MunicipalityId { get; set; }
        public int LanguageId { get; set; }
        public int TimeZoneId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string PostalBox { get; set; }
        public virtual TimeZone TimeZone { get; set; }
        public virtual Language Language { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual UserMembership UserMembership { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}