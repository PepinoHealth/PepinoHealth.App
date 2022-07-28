using PepinoHealth.App.Filters;
using PepinoHealth.Auth.User;
using PepinoHealth.CL.Common;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using PepinoHealth.CL.User;

namespace PepinoHealth.App.Controllers
{
    public partial class HomeController : Controller
    {
        #region View Action Methods

        [NoCache]
        [NoAuth(Helper.QuickLinksV2)]
        [HttpGet]
        [Route(Helper.Login)]
        public virtual ActionResult Login()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin, PepinoHealth.CL.Common.Roles.User)]
        [HttpGet]
        [Route(Helper.QuickLinksV2)]
        public virtual ActionResult QuickLinksV2()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.RegistrationV2)]
        public virtual ActionResult RegistrationV2()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.RevisitRegistration)]
        public virtual ActionResult RevisitRegistration()
        {
            return View();
        }

        #endregion

        #region Common Action Methods

        [Route("logout/{*returnUrl?}")]
        public virtual ActionResult LogOut(string returnUrl)
        {
            Session.Abandon();
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            Helper.RemoveAuthenticationTicket();

            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            // Clear cache
            Helper.ClearCache();

            return RedirectToAction(MVC.Home.Login());
        }

        #endregion

        #region Other Action Methods

        [HttpGet]
        [Route(Helper.Home)]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route(Helper.DashBoard)]
        public virtual ActionResult DashBoard()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin, PepinoHealth.CL.Common.Roles.User)]
        [HttpGet]
        [Route(Helper.QuickLinks)]
        public virtual ActionResult QuickLinks()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.Registration)]
        public virtual ActionResult Registration()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        public virtual ActionResult Page1()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        public virtual ActionResult Page2()
        {
            return View();
        }

        public virtual ActionResult Datatable()
        {
            return View();
        }

        public virtual ActionResult AdvanceReceipt()
        {
            return View();
        }

        #endregion

        #region Business Methods

        [HttpPost]
        public virtual ActionResult ValidateUser(Profile profile)
        {
            bool valid = false;

            if (profile != null)
            {
                valid = ((profile.Username.Equals("admin") || profile.Username.Equals("user")) && profile.Password.Equals("123"));
            }

            return Json(
                new { Valid = valid },
                JsonRequestBehavior.AllowGet
                );
        }

        [HttpPost]
        public virtual ActionResult GrantAccess(Profile profile)
        {
            dynamic result = true;

            if (profile != null)
            {
                // Clear cache
                Helper.ClearCache();

                // Create session object
                Session[Helper.SES_USER_ID] = profile.Username;

                // Create user in object
                Session[Helper.SES_USER_IN] = true;

                // Create logged role
                Session[Helper.CHE_LOGGED_ROLE] = Helper.GetRoleID(profile.Username);

                // Grant the authentication cookie
                FormsAuthentication.SetAuthCookie(profile.Username, false);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}