using System;
using System.Threading.Tasks;
using System.Linq;

namespace Viainternet.OnionArchitecture.Infrastructure.Repositories
{
    using Core.Domain.Models;
    using Core.Interfaces.IRepositories;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;

    public static partial class ThisUserMembershipRepository
    {
        /// <summary>
        /// Return true if user have phone number with his membership, otherwise return false.
        /// </summary>
        /// <param name="loggedUser"></param>
        /// <returns></returns>
        public static bool HasPhoneNumber(this UserMembership loggedUser)
        {
            const string unauthenticatedUser = "Unauthenticated user. Cannot proceed to verification.";
            const string noUserProfile = "User do not have a profile associate with his membership. Cannot proceed to verification.";

            if (loggedUser == null)
                throw new NullReferenceException(unauthenticatedUser);
            if (loggedUser.UserProfile == null)
                throw new NullReferenceException(noUserProfile);

            return loggedUser.UserProfile.PhoneNumbers.Count() > 0;
        }

        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this UserMembership loggedUser, UserManager<UserMembership> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(loggedUser, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
