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
        public List<OPIPReportsModal.IPDPatients> GetIPDRegistrationDetails(string Department, DateTime StartDate, DateTime EndDate)
        {
            List<OPIPReportsModal.IPDPatients> IPDPatients = null;

            try
            {
                IPDPatients = OPIPReportsInfo().GetIPDRegistrationDetails(Department, StartDate, EndDate);
            }
            catch (Exception Ex)
            {
            }

            return IPDPatients;
        }
        #endregion
    }

}
