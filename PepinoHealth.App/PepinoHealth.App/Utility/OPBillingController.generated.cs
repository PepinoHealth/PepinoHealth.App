// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace PepinoHealth.App.Controllers
{
    public partial class OPBillingController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OPBillingController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OPBillingController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OPBillingController Actions { get { return MVC.OPBilling; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "OPBilling";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "OPBilling";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string OPBilling = "OPBilling";
            public readonly string IPDayWiseBilling = "IPDayWiseBilling";
            public readonly string DischargeBilling = "DischargeBilling";
            public readonly string PatientCashRefund = "PatientCashRefund";
            public readonly string DebitDetails = "DebitDetails";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string OPBilling = "OPBilling";
            public const string IPDayWiseBilling = "IPDayWiseBilling";
            public const string DischargeBilling = "DischargeBilling";
            public const string PatientCashRefund = "PatientCashRefund";
            public const string DebitDetails = "DebitDetails";
        }


        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string DebitDetails = "DebitDetails";
                public readonly string DischargeBilling = "DischargeBilling";
                public readonly string IPDayWiseBilling = "IPDayWiseBilling";
                public readonly string OPBilling = "OPBilling";
                public readonly string PatientCashRefund = "PatientCashRefund";
            }
            public readonly string DebitDetails = "~/Views/OPBilling/DebitDetails.cshtml";
            public readonly string DischargeBilling = "~/Views/OPBilling/DischargeBilling.cshtml";
            public readonly string IPDayWiseBilling = "~/Views/OPBilling/IPDayWiseBilling.cshtml";
            public readonly string OPBilling = "~/Views/OPBilling/OPBilling.cshtml";
            public readonly string PatientCashRefund = "~/Views/OPBilling/PatientCashRefund.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OPBillingController : PepinoHealth.App.Controllers.OPBillingController
    {
        public T4MVC_OPBillingController() : base(Dummy.Instance) { }

        [NonAction]
        partial void OPBillingOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult OPBilling()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.OPBilling);
            OPBillingOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void IPDayWiseBillingOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult IPDayWiseBilling()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IPDayWiseBilling);
            IPDayWiseBillingOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DischargeBillingOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DischargeBilling()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DischargeBilling);
            DischargeBillingOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void PatientCashRefundOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientCashRefund()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientCashRefund);
            PatientCashRefundOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DebitDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DebitDetails()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DebitDetails);
            DebitDetailsOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
