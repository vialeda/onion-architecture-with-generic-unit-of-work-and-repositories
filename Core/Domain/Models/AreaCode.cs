using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class AreaCode : Entity
    {
        public AreaCode()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
        }
        
        public int Id { get; set; }
        public Int16 Value { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}