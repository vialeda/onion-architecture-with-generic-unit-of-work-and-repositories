using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class MembershipSetting : Entity
    {
        public string UserMembershipId { get; set; }
        public int SettingId { get; set; }
        public object Value { get; set; }
        public virtual UserMembership UserMembership { get; set; }
        public virtual Setting Setting { get; set; }
    }
}
