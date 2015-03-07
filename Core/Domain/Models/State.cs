using System.Collections.Generic;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class State : Entity
    {
        public State()
        {
            Municipalities = new HashSet<Municipality>();
        }
        public int Id { get; set;}
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Municipality> Municipalities { get; set; }
    }
}