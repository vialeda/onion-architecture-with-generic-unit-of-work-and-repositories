using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
