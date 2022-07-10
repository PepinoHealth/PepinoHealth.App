using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PepinoHealth.DL.Common;
using PepinoHealth.CL.Admin;
using PepinoHealth.CL.OPModal;
using PepinoHealth.CL.OPIPReports;

namespace PepinoHealth.DL
{
   public class OPIPReportsInfo
    {
        #region Variable declarations
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlDataAdapter = null;
        DataTable dataTable = null;
        dynamic returnNull = null;
        #endregion
        #region Internal Common Methods

        private DBConnection DBConnection()
        {
            return new DBConnection();
        }

        private SqlConnection AccessToDB()
        {
            try
            {
                sqlConnection = DBConnection().AccessToSandvikApp();
            }
            catch (Exception ex)
            {
            }
            return sqlConnection;
        }

       private void CheckNOpen()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }



        private void CheckNClose()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        #endregion
        #region InvoiceDetails Read, Write and Delete Methods
        public List<OPIPReportsModal.IPDPatients> GetIPDRegistrationDetails(string Department, DateTime StartDate, DateTime EndDate)
        {
            List<OPIPReportsModal.IPDPatients> details = null;
            try
            {
                string query = string.Empty;
                if (Department.ToUpper() == "ALL")
                {
                    query = "SELECT IPD_No ,IPD_Date,IPD_Year,IPD_Sub_Name,IPD_Name,IPD_Fathers_Name,IPD_Husbands_Name,IPD_Address,IPD_Gender,IPD_Age,IPD_Dept_Name,IPD_Ref_Doctor FROM IPD_Registration where IPD_Date between '" + StartDate.ToString("MM/dd/yyyy") + "'" + " and '" + EndDate.ToString("MM/dd/yyyy") + "'";
                }
                else
                {
                    query = "SELECT IPD_No ,IPD_Date,IPD_Year,IPD_Sub_Name,IPD_Name,IPD_Fathers_Name,IPD_Husbands_Name,IPD_Address,IPD_Gender,IPD_Age,IPD_Dept_Name,IPD_Ref_Doctor FROM IPD_Registration where IPD_Dept_Name='" + Department + "'" + " and IPD_Date between '" + StartDate.ToString("MM/dd/yyyy") + "'" + " and '" + EndDate.ToString("MM/dd/yyyy") + "'";
                }
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<OPIPReportsModal.IPDPatients>();
                while (sqlDataReader.Read())
                {
                    details.Add(new OPIPReportsModal.IPDPatients()
                    {
                        IPD_No = Convert.ToString(sqlDataReader["IPD_No"]),
                        IPD_Date = Convert.ToDateTime(sqlDataReader["IPD_Date"]),
                        IPD_Year = Convert.ToString(sqlDataReader["IPD_Year"]),
                        IPD_Sub_Name = Convert.ToString(sqlDataReader["IPD_Sub_Name"]),
                        IPD_Name = Convert.ToString(sqlDataReader["IPD_Name"]),
                        IPD_Fathers_Name = Convert.ToString(sqlDataReader["IPD_Fathers_Name"]),
                        IPD_Husbands_Name = Convert.ToString(sqlDataReader["IPD_Husbands_Name"]),
                        IPD_Address = Convert.ToString(sqlDataReader["IPD_Address"]),
                        IPD_Gender = Convert.ToString(sqlDataReader["IPD_Gender"]),
                        IPD_Age = Convert.ToString(sqlDataReader["IPD_Age"]),
                        IPD_Dept_Name = Convert.ToString(sqlDataReader["IPD_Dept_Name"]),
                        IPD_Ref_Doctor = Convert.ToString(sqlDataReader["IPD_Ref_Doctor"]),
                    });
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "GetIPDRegistrationDetails");
            }
            finally
            {
                CheckNClose();
            }

            return details;
        }

        #endregion
    }
}
