using System;
using System.Threading.Tasks;
using System.Linq;

namespace Viainternet.OnionArchitecture.Infrastructure.Repositories
{
    using Core.Domain.Models;
    using Core.Interfaces.IRepositories;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;

    public static partial class UserMembershipRepository
    {
        public static bool GetSomethingFromDatabase(this IRepositoryAsync<UserMembership> repository)
        {
            return false;
        }
        
    }
}