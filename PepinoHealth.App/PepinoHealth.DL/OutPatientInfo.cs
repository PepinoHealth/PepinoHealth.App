using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PepinoHealth.DL.Common;

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
        #endregion
    }
}
