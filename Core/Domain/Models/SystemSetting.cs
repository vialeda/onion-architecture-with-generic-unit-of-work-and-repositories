using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class SystemSetting : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActivate { get; set; }
    }
}
