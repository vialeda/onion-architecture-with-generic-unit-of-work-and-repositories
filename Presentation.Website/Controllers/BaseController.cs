using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace Viainternet.OnionArchitecture.Presentation.Website.Controllers
{
    using Core.Domain.Models;
    using Infrastructure.Logging;

    public class BaseController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private UserMembershipManager _userManager;
        private UserMembership _authenticatedUser;

        public BaseController()
        {
        }

        public BaseController(UserMembershipManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public UserMembershipManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserMembershipManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserMembership AuthenticatedUser
        {
            get
            {
                return _authenticatedUser ?? UserManager.FindById(User.Identity.GetUserId());
            }
            private set
            {
                _authenticatedUser = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_authenticatedUser != null)
                {
                    _authenticatedUser = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}