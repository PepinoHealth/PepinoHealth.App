using PepinoHealth.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PepinoHealth.CL.OPIPReports;

namespace PepinoHealth.BL
{
    

    
    public class OPIPReportsRepositary
    {
        #region Internal Common Methods

        private OPIPReportsInfo OPIPReportsInfo()
        {
            return new OPIPReportsInfo();
        }

        #endregion

        #region User Details Read, Write & Delete Methods
        public List<OPIPReportsModal.IPDPatients> GetIPDRegistrationDetails(string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.IPDPatients> IPDPatients = null;

            try
            {
                IPDPatients = OPIPReportsInfo().GetIPDRegistrationDetails(Department,StartDate, EndDate);
            }
            catch (Exception Ex)
            {
            }

            return IPDPatients;
        }

        public List<OPIPReportsModal.NewVisitPatients> GetNewVisitPatientDetails(string visit, string department, string startDate, string endDate)
        {
            List<OPIPReportsModal.NewVisitPatients> OPNew = null;

            try
            {
                OPNew = OPIPReportsInfo().GetNewVisitPatientDetails(visit, department, startDate, endDate);
            }
            catch (Exception Ex)
            {
            }

            return OPNew;
        }

        public List<OPIPReportsModal.ReVisitPatients> GetReVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.ReVisitPatients> OPReVisit = null;

            try
            {
                OPReVisit = OPIPReportsInfo().GetReVisitPatientDetails(Visit, Department, StartDate, EndDate);
            }
            catch (Exception Ex)
            {
            }

            return OPReVisit;
        }

        public List<OPIPReportsModal.BothVisitPatients> GetBothVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.BothVisitPatients> OPBoth = null;

            try
            {
                OPBoth = OPIPReportsInfo().GetBothVisitPatientDetails(Visit, Department, StartDate, EndDate);
            }
            catch (Exception Ex)
            {
            }

            return OPBoth;
        }
        #endregion
    }

}
