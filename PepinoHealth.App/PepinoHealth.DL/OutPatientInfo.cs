using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PepinoHealth.DL.Common;
using PepinoHealth.CL.Admin;

namespace PepinoHealth.DL
{
    public class OutPatientInfo
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
        public string GetMaxOutPatientId()
        {
            string result = string.Empty;
            try
            {
                sqlConnection = AccessToDB();
                string query = "select ISNULL(MAX(OP_No), 0)+1 'MaxOPId' from [dbo].[Out_Paitent_Registration]";
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    result = Convert.ToString(sqlDataReader["MaxOPId"]);
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "CRUDOutPatientDetails");
            }
            finally
            {
                CheckNClose();
            }

            return result;
        }
        public List<AdminModal.DepotMaster> GetOutPatientDepartmentDetails()
        {
            List<AdminModal.DepotMaster> details = null;

            try
            {
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT Dept_Code,Dept_Name FROM [dbo].[Department_Master]";
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<AdminModal.DepotMaster>();
                while (sqlDataReader.Read())
                {
                    details.Add(new AdminModal.DepotMaster()
                    {
                        DeptCode = Convert.ToString(sqlDataReader["Dept_Code"]),
                        DeptName = Convert.ToString(sqlDataReader["Dept_Name"])
                    });
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "GetOutPatientDepartmentDetails");
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
