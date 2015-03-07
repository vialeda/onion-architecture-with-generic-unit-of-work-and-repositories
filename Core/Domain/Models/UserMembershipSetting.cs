
namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    public class UserMembershipSetting : Entity
    {
        public int UserSettingId { get; set; }
        public string UserMembershipId { get; set; }
        public object Value { get; set; }
        public virtual UserMembership UserMembership { get; set; }
        public virtual UserSetting UserSetting { get; set; }
    }
}