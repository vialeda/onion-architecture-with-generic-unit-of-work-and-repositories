using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class Country : Entity
    {
        public Country()
        {
            States = new HashSet<State>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual AreaCode AreaCode { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
