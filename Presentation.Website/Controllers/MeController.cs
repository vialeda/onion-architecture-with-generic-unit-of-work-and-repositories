using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Presentation.Website.Models;
using System.Web;
using System.Web.Http;
using Viainternet.OnionArchitecture.Infrastructure.Logging;

namespace Presentation.Website.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private UserMembershipManager _userManager;

        public MeController()
        {
        }

        public MeController(UserMembershipManager userManager)
        {
            UserManager = userManager;
        }

        public UserMembershipManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<UserMembershipManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return new GetViewModel() {  };
        }
    }
}