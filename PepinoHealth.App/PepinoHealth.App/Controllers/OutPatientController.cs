using PepinoHealth.App.Filters;
using PepinoHealth.Auth.User;
using PepinoHealth.CL.Common;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using PepinoHealth.CL.User;

namespace PepinoHealth.App.Controllers
{
    public partial class OutPatientController : Controller
    {
        #region View Action Methods



        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.OPRegistration)]
        public virtual ActionResult OPRegistration()
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



        #endregion

        #region Other Action Methods



        #endregion

        #region Business Methods



        #endregion
    }
}