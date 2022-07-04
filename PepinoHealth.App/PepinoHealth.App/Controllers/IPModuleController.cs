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
        public virtual ActionResult DischargeSummary()
        {
            return View();
        }
        public virtual ActionResult ObstetricDischargeSummary()
        {
            return View();
        }

    }
}