using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Setting : Entity
    {
        public Setting()
        {
            MembershipSettings = new HashSet<MembershipSetting>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ValueType { get; set; }
        public virtual ICollection<MembershipSetting> MembershipSettings { get; set; }
    }
}
