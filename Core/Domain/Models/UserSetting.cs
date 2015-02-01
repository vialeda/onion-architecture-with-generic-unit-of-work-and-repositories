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
    public class UserSetting : Entity
    {
        public UserSetting()
        {
            UserMembershipSettings = new HashSet<UserMembershipSetting>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ValueType { get; set; }

        public virtual ICollection<UserMembershipSetting> UserMembershipSettings { get; set; }
    }
}
