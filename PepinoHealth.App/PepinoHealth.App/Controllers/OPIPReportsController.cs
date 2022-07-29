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
    public partial class OPIPReportsController : Controller
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

        #region Common Action Methods
        dynamic returnNull = null;
        private OPIPReportsRepositary OPIPReportsRepositary()
        {
            return new OPIPReportsRepositary();
        }
        private OutPatientRepositary OutPatientRepositary()
        {
            return new OutPatientRepositary();
        }

        #endregion

        #region Other Action Methods

        #region GetOutPatientDepartmentDetails
        [HttpPost]
        public virtual ActionResult GetOutPatientDepartmentDetails()
        {
            try
            {
                var result = OutPatientRepositary().GetOutPatientDepartmentDetails();

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
            }
            return returnNull;

        }
        #region GetIPDRegistrationDetails
        [HttpPost]
        public virtual ActionResult GetIPDRegistrationDetails(string Department, string StartDate, string EndDate)
        {
            try
            {
                var result = OPIPReportsRepositary().GetIPDRegistrationDetails(Department, StartDate, EndDate);

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
            }
            return returnNull;
        }
        #endregion
        #region GetRegistrationPatientDetails
        #region GetNewVisitPatientDetails
        [HttpPost]
        public virtual ActionResult GetNewVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            try
            {
                var result = OPIPReportsRepositary().GetNewVisitPatientDetails(Visit, Department, StartDate, EndDate);

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }


            catch (Exception ex)
            {
            }

            return returnNull;
        }
        #endregion
        #region GetReVisitPatientDetails
        [HttpPost]
        public virtual ActionResult GetReVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            try
            {
                var result = OPIPReportsRepositary().GetReVisitPatientDetails(Visit, Department, StartDate, EndDate);

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }


            catch (Exception ex)
            {
            }

            return returnNull;
        }
        #endregion
        #region GetBothVisitPatientDetails
        [HttpPost]
        public virtual ActionResult GetBothVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            try
            {
                var result = OPIPReportsRepositary().GetBothVisitPatientDetails(Visit, Department, StartDate, EndDate);

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }


            catch (Exception ex)
            {
            }

            return returnNull;
        }
        #endregion
        #endregion
        #endregion
        #endregion
    }
}