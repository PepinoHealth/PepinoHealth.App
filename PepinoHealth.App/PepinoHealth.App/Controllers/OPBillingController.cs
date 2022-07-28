using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.App.Controllers
{
    public partial class OPBillingController : Controller
    {
        // GET: OPBilling
        public virtual ActionResult OPBilling()
        {
            return View();
        }

        public virtual ActionResult IPDayWiseBilling()
        {
            return View();
        }

        public virtual ActionResult DischargeBilling()
        {
            return View();
        }

        public virtual ActionResult PatientCashRefund()
        {
            return View();
        }

        public virtual ActionResult DebitDetails()
        {
            return View();
        }
        public virtual ActionResult AdvanceReceipt()
        {
            return View();
        }

    }
}