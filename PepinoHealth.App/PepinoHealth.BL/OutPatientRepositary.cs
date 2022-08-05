using PepinoHealth.CL.Admin;
using PepinoHealth.CL.OPModal;
using PepinoHealth.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepinoHealth.BL
{
    public class OutPatientRepositary
    {
        #region Internal Common Methods

        private OutPatientInfo OutPatientInfo()
        {
            return new OutPatientInfo();
        }
        #endregion

        #region User Details Read, Write & Delete Methods
        public string GetMaxOutPatientId()
        {
            string result = string.Empty;
            try
            {
                result = OutPatientInfo().GetMaxOutPatientId();
            }
            catch (Exception Ex)
            {
            }
            return result;
        }

        public List<AdminModal.DepotMaster> GetOutPatientDepartmentDetails()
        {
            List<AdminModal.DepotMaster> depotMaster = null;

            try
            {
                depotMaster = OutPatientInfo().GetOutPatientDepartmentDetails();
            }
            catch (Exception Ex)
            {
            }

            return depotMaster;
        }

        public List<OutPatientModal.OutPatientRegistration> CRUDOPRegistrationDetails(OutPatientModal.OutPatientRegistration outPatientRegistration)
        {
            List<OutPatientModal.OutPatientRegistration> result = null;

            try
            {
                result = OutPatientInfo().CRUDOPRegistrationDetails(outPatientRegistration);
            }
            catch (Exception Ex)
            {
            }
            return result;
        }

        public List<OutPatientModal.OutPatientRegistration> SearchOPDetailsByUHID(string startDate, string endDate)
        {
            List<OutPatientModal.OutPatientRegistration> result = null;

            try
            {
                result = OutPatientInfo().SearchOPDetailsByUHID(startDate, endDate);
            }
            catch (Exception Ex)
            {
            }
            return result;
        }
        #endregion
    }
}
