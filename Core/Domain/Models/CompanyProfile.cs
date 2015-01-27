using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viainternet.OnionArchitecture.Core.Interfaces;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class CompanyProfile : Entity, IAdress
    {
        public CompanyProfile()
        {
            UserMemberships = new HashSet<UserMembership>();
            PhoneNumbers = new HashSet<PhoneNumber>();
        }
        public int Id { get; set; }
        public string UserMembershipId { get; set; }
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string NE { get; set; }
        public string NEQ { get; set; }
        public int EmployeesNumber { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime LastestUpdateDate { get; set; }
        /// <summary>
        /// Flag if company profile is active because user can have more than one company in the same time.
        /// </summary>
        public bool IsActive { get; set; }
        public string FileName { get; set; }
        public string DisplayFileName { get; set; }
        public string FileDescription { get; set; }
        public string ContentType { get; set; }
        public string ContentLength { get; set; }
        public string FileExtension { get; set; }
        public byte[] File { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string PostalBox{ get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<UserMembership> UserMemberships { get; set; }
    }
}
