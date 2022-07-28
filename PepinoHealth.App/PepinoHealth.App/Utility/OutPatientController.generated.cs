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
    public partial class OutPatientController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OutPatientController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OutPatientController(Dummy d) { }

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

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult CRUDOPRegistrationDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CRUDOPRegistrationDetails);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OutPatientController Actions { get { return MVC.OutPatient; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "OutPatient";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "OutPatient";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string OPRegistration = "OPRegistration";
            public readonly string OPRevisitRegistration = "OPRevisitRegistration";
            public readonly string DoctorDesk = "DoctorDesk";
            public readonly string GetMaxOutPatientId = "GetMaxOutPatientId";
            public readonly string GenerateBarcode = "GenerateBarcode";
            public readonly string GetOutPatientDepartmentDetails = "GetOutPatientDepartmentDetails";
            public readonly string CRUDOPRegistrationDetails = "CRUDOPRegistrationDetails";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string OPRegistration = "OPRegistration";
            public const string OPRevisitRegistration = "OPRevisitRegistration";
            public const string DoctorDesk = "DoctorDesk";
            public const string GetMaxOutPatientId = "GetMaxOutPatientId";
            public const string GenerateBarcode = "GenerateBarcode";
            public const string GetOutPatientDepartmentDetails = "GetOutPatientDepartmentDetails";
            public const string CRUDOPRegistrationDetails = "CRUDOPRegistrationDetails";
        }


        static readonly ActionParamsClass_CRUDOPRegistrationDetails s_params_CRUDOPRegistrationDetails = new ActionParamsClass_CRUDOPRegistrationDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CRUDOPRegistrationDetails CRUDOPRegistrationDetailsParams { get { return s_params_CRUDOPRegistrationDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CRUDOPRegistrationDetails
        {
            public readonly string outPatientRegistration = "outPatientRegistration";
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
                public readonly string DoctorDesk = "DoctorDesk";
                public readonly string OPRegistration = "OPRegistration";
                public readonly string OPRevisitRegistration = "OPRevisitRegistration";
            }
            public readonly string DoctorDesk = "~/Views/OutPatient/DoctorDesk.cshtml";
            public readonly string OPRegistration = "~/Views/OutPatient/OPRegistration.cshtml";
            public readonly string OPRevisitRegistration = "~/Views/OutPatient/OPRevisitRegistration.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OutPatientController : PepinoHealth.App.Controllers.OutPatientController
    {
        public T4MVC_OutPatientController() : base(Dummy.Instance) { }

        [NonAction]
        partial void OPRegistrationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult OPRegistration()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.OPRegistration);
            OPRegistrationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void OPRevisitRegistrationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult OPRevisitRegistration()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.OPRevisitRegistration);
            OPRevisitRegistrationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DoctorDeskOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DoctorDesk()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorDesk);
            DoctorDeskOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetMaxOutPatientIdOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetMaxOutPatientId()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetMaxOutPatientId);
            GetMaxOutPatientIdOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GenerateBarcodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult GenerateBarcode()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GenerateBarcode);
            GenerateBarcodeOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetOutPatientDepartmentDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetOutPatientDepartmentDetails()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetOutPatientDepartmentDetails);
            GetOutPatientDepartmentDetailsOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CRUDOPRegistrationDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, PepinoHealth.CL.OPModal.OutPatientModal.OutPatientRegistration outPatientRegistration);

        [NonAction]
        public override System.Web.Mvc.ActionResult CRUDOPRegistrationDetails(PepinoHealth.CL.OPModal.OutPatientModal.OutPatientRegistration outPatientRegistration)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CRUDOPRegistrationDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "outPatientRegistration", outPatientRegistration);
            CRUDOPRegistrationDetailsOverride(callInfo, outPatientRegistration);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
