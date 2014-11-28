using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Viainternet.OnionArchitecture.Core.Interfaces;
using Viainternet.OnionArchitecture.Core.Enumerations;

namespace Viainternet.OnionArchitecture.Core.Domain
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
