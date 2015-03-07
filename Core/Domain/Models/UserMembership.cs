using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Domain.Models
{
    /// <summary>
    /// TODO: Regarder si je pourrais ajouter certaines informations dans la table de configurations 
    /// comme le TimeZone et la langue
    /// </summary>
    public class UserMembership : IdentityMembership
    {
        public UserMembership()
        {
            UnsubscribeDate = DateTime.MinValue;
            CompagnyProfiles = new HashSet<CompanyProfile>();
            UserMembershipSettings = new HashSet<UserMembershipSetting>();
        }
        public override string Id
        {
            get
            { return base.Id; }
            set 
            { base.Id = value; }
        }
        public override string PhoneNumber
        {
            get
            { return base.PhoneNumber; }
            set
            { base.PhoneNumber = value; }
        }
        public override string UserName
        {
            get
            { return base.UserName; }
            set
            { base.UserName = value; }
        }
        public override string Email
        {
            get
            { return base.Email; }
            set
            { base.Email = value; }
        }
        public override string SecurityStamp
        {
            get
            { return base.SecurityStamp; }
            set
            { base.SecurityStamp = value; }
        }
        public bool IsAccountClosed { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LatestLogonDate { get; set; }
        public DateTime UnsubscribeDate { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<CompanyProfile> CompagnyProfiles { get; set; }
        public virtual ICollection<UserMembershipSetting> UserMembershipSettings { get; set; }
    }
}