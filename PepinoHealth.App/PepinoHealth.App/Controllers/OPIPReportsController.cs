using System;
using System.Collections.Generic;
using System.Linq;
using PepinoHealth.App.Filters;
using PepinoHealth.Auth.User;
using PepinoHealth.CL.Common;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using PepinoHealth.CL.User;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using PepinoHealth.BL;

namespace PepinoHealth.App.Controllers
{
    public class OPIPReportsController : Controller
    {
        #region View Action Methods

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.IPDPatientRegistration)]
        public virtual ActionResult IPDPatientRegistration()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.OutPatientRegistration)]
        public virtual ActionResult OutPatientRegistration()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.PatientDischarge)]
        public virtual ActionResult PatientDischarge()
        {
            return View();
        }
        #endregion
    }
}