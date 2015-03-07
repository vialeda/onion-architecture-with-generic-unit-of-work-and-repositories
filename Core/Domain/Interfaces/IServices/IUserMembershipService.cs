using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Viainternet.OnionArchitecture.Core.Interfaces.IServices
{
    using Core.Domain.Models;
    
    public interface IUserMembershipService : IService<UserMembership>
    {
    }
}
