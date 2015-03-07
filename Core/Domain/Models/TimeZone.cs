using System.Collections.Generic;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class TimeZone : Entity
    {
        public TimeZone()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string StandardName { get; set; }
        public bool HasDaylightSavingTime { get; set; }
        public string UTCOffset { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
