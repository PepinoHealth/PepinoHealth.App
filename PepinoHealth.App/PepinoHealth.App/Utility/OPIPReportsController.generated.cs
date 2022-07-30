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
    public partial class OPIPReportsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OPIPReportsController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected OPIPReportsController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult GetIPDRegistrationDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetIPDRegistrationDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult GetNewVisitPatientDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNewVisitPatientDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult GetReVisitPatientDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetReVisitPatientDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult GetBothVisitPatientDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetBothVisitPatientDetails);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public OPIPReportsController Actions { get { return MVC.OPIPReports; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "OPIPReports";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "OPIPReports";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string IPDPatientRegistration = "IPDPatientRegistration";
            public readonly string OutPatientRegistration = "OutPatientRegistration";
            public readonly string PatientDischarge = "PatientDischarge";
            public readonly string GetOutPatientDepartmentDetails = "GetOutPatientDepartmentDetails";
            public readonly string GetIPDRegistrationDetails = "GetIPDRegistrationDetails";
            public readonly string GetNewVisitPatientDetails = "GetNewVisitPatientDetails";
            public readonly string GetReVisitPatientDetails = "GetReVisitPatientDetails";
            public readonly string GetBothVisitPatientDetails = "GetBothVisitPatientDetails";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string IPDPatientRegistration = "IPDPatientRegistration";
            public const string OutPatientRegistration = "OutPatientRegistration";
            public const string PatientDischarge = "PatientDischarge";
            public const string GetOutPatientDepartmentDetails = "GetOutPatientDepartmentDetails";
            public const string GetIPDRegistrationDetails = "GetIPDRegistrationDetails";
            public const string GetNewVisitPatientDetails = "GetNewVisitPatientDetails";
            public const string GetReVisitPatientDetails = "GetReVisitPatientDetails";
            public const string GetBothVisitPatientDetails = "GetBothVisitPatientDetails";
        }


        static readonly ActionParamsClass_GetIPDRegistrationDetails s_params_GetIPDRegistrationDetails = new ActionParamsClass_GetIPDRegistrationDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetIPDRegistrationDetails GetIPDRegistrationDetailsParams { get { return s_params_GetIPDRegistrationDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetIPDRegistrationDetails
        {
            public readonly string Department = "Department";
            public readonly string StartDate = "StartDate";
            public readonly string EndDate = "EndDate";
        }
        static readonly ActionParamsClass_GetNewVisitPatientDetails s_params_GetNewVisitPatientDetails = new ActionParamsClass_GetNewVisitPatientDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetNewVisitPatientDetails GetNewVisitPatientDetailsParams { get { return s_params_GetNewVisitPatientDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetNewVisitPatientDetails
        {
            public readonly string Visit = "Visit";
            public readonly string Department = "Department";
            public readonly string StartDate = "StartDate";
            public readonly string EndDate = "EndDate";
        }
        static readonly ActionParamsClass_GetReVisitPatientDetails s_params_GetReVisitPatientDetails = new ActionParamsClass_GetReVisitPatientDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetReVisitPatientDetails GetReVisitPatientDetailsParams { get { return s_params_GetReVisitPatientDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetReVisitPatientDetails
        {
            public readonly string Visit = "Visit";
            public readonly string Department = "Department";
            public readonly string StartDate = "StartDate";
            public readonly string EndDate = "EndDate";
        }
        static readonly ActionParamsClass_GetBothVisitPatientDetails s_params_GetBothVisitPatientDetails = new ActionParamsClass_GetBothVisitPatientDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetBothVisitPatientDetails GetBothVisitPatientDetailsParams { get { return s_params_GetBothVisitPatientDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetBothVisitPatientDetails
        {
            public readonly string Visit = "Visit";
            public readonly string Department = "Department";
            public readonly string StartDate = "StartDate";
            public readonly string EndDate = "EndDate";
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
                public readonly string IPDPatientRegistration = "IPDPatientRegistration";
                public readonly string OutPatientRegistration = "OutPatientRegistration";
                public readonly string PatientDischarge = "PatientDischarge";
            }
            public readonly string IPDPatientRegistration = "~/Views/OPIPReports/IPDPatientRegistration.cshtml";
            public readonly string OutPatientRegistration = "~/Views/OPIPReports/OutPatientRegistration.cshtml";
            public readonly string PatientDischarge = "~/Views/OPIPReports/PatientDischarge.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_OPIPReportsController : PepinoHealth.App.Controllers.OPIPReportsController
    {
        public T4MVC_OPIPReportsController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IPDPatientRegistrationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult IPDPatientRegistration()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IPDPatientRegistration);
            IPDPatientRegistrationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void OutPatientRegistrationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult OutPatientRegistration()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.OutPatientRegistration);
            OutPatientRegistrationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void PatientDischargeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult PatientDischarge()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PatientDischarge);
            PatientDischargeOverride(callInfo);
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
        partial void GetIPDRegistrationDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string Department, string StartDate, string EndDate);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetIPDRegistrationDetails(string Department, string StartDate, string EndDate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetIPDRegistrationDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Department", Department);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "StartDate", StartDate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "EndDate", EndDate);
            GetIPDRegistrationDetailsOverride(callInfo, Department, StartDate, EndDate);
            return callInfo;
        }

        [NonAction]
        partial void GetNewVisitPatientDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string Visit, string Department, string StartDate, string EndDate);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetNewVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNewVisitPatientDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Visit", Visit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Department", Department);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "StartDate", StartDate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "EndDate", EndDate);
            GetNewVisitPatientDetailsOverride(callInfo, Visit, Department, StartDate, EndDate);
            return callInfo;
        }

        [NonAction]
        partial void GetReVisitPatientDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string Visit, string Department, string StartDate, string EndDate);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetReVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetReVisitPatientDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Visit", Visit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Department", Department);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "StartDate", StartDate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "EndDate", EndDate);
            GetReVisitPatientDetailsOverride(callInfo, Visit, Department, StartDate, EndDate);
            return callInfo;
        }

        [NonAction]
        partial void GetBothVisitPatientDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string Visit, string Department, string StartDate, string EndDate);

        [NonAction]
        public override System.Web.Mvc.ActionResult GetBothVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetBothVisitPatientDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Visit", Visit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Department", Department);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "StartDate", StartDate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "EndDate", EndDate);
            GetBothVisitPatientDetailsOverride(callInfo, Visit, Department, StartDate, EndDate);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114