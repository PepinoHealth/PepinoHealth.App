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
        #endregion
    }
}
