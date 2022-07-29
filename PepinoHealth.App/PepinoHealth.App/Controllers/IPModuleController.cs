using PepinoHealth.App.Filters;
using PepinoHealth.Auth.User;
using PepinoHealth.CL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.App.Controllers
{
    public partial class IPModuleController : Controller
    {
        // GET: IPModule

        #region View Action Methods
        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.IPDRegistration)]
        public virtual ActionResult IPDRegistration()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.DischargeSummary)]
        public virtual ActionResult DischargeSummary()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.ObstetricDischargeSummary)]
        public virtual ActionResult ObstetricDischargeSummary()
        {
            return View();
        }
        
        #endregion
    }
}