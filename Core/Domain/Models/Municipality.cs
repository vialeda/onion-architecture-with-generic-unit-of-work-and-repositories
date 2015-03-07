using System.Collections.Generic;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class Municipality : Entity
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<CompanyProfile> CompanyProfiles { get; set; }
    }
}