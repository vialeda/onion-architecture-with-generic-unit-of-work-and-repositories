using System;
using System.Collections.Generic;

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