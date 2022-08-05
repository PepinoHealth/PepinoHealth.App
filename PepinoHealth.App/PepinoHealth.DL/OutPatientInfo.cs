using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PepinoHealth.DL.Common;
using PepinoHealth.CL.Admin;
using PepinoHealth.CL.OPModal;

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

        public List<OutPatientModal.OutPatientRegistration> SearchOPDetailsByUHID(string startDate, string endDate)
        {
            List<OutPatientModal.OutPatientRegistration> details = null;
            if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                startDate = DateTime.Now.ToString("MM/dd/yyyy");
                endDate = DateTime.Now.ToString("MM/dd/yyyy");
            }
            try
            {
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT [UHID],[OP_Name],[Op_Dept_Name] ,[Op_Gender] ,[OP_Age] FROM Out_Paitent_Registration where Op_Date between '" + DateTime.ParseExact(startDate, "dd/MM/yyyy", null) + "' and '" + DateTime.ParseExact(endDate, "dd/MM/yyyy", null) + "'";
                sqlCommand.CommandType = CommandType.Text;
                //sqlCommand.Parameters.AddWithValue("@StartDate", startDate);
                //sqlCommand.Parameters.AddWithValue("@EndDate", endDate);
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<OutPatientModal.OutPatientRegistration>();
                while (sqlDataReader.Read())
                {
                    details.Add(new OutPatientModal.OutPatientRegistration()
                    {
                        UHID = Convert.ToString(sqlDataReader["UHID"]),
                        OP_NAME = Convert.ToString(sqlDataReader["OP_Name"]),
                        OP_DEPT_NAME = Convert.ToString(sqlDataReader["Op_Dept_Name"]),
                        OP_GENDER = Convert.ToString(sqlDataReader["Op_Gender"]),
                        OP_AGE = Convert.ToString(sqlDataReader["OP_Age"])

                    });
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

            return details;
        }

        public List<OutPatientModal.OutPatientRegistration> CRUDOPRegistrationDetails(OutPatientModal.OutPatientRegistration outPatientRegistration)
        {
            List<OutPatientModal.OutPatientRegistration> details = null;

            try
            {
                sqlConnection = AccessToDB();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = DBObjects.SP_OUT_Patient_REGISTRATION;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@OP_NO", outPatientRegistration.OP_NO != null ? outPatientRegistration.OP_NO : "");
                sqlCommand.Parameters.AddWithValue("@OP_DATE", outPatientRegistration.OP_DATE != null ? outPatientRegistration.OP_DATE : "");
                sqlCommand.Parameters.AddWithValue("@UHID", outPatientRegistration.UHID != null ? outPatientRegistration.UHID : "");
                sqlCommand.Parameters.AddWithValue("@OP_PREPARED_BY", outPatientRegistration.OP_PREPARED_BY != null ? outPatientRegistration.OP_PREPARED_BY : "");
                sqlCommand.Parameters.AddWithValue("@OP_PRINT_COUNT", outPatientRegistration.OP_PRINT_COUNT != null ? outPatientRegistration.OP_PRINT_COUNT : "");
                sqlCommand.Parameters.AddWithValue("@OP_YEAR", outPatientRegistration.OP_YEAR != null ? outPatientRegistration.OP_YEAR : "");
                sqlCommand.Parameters.AddWithValue("@OP_TIME", outPatientRegistration.OP_TIME != null ? outPatientRegistration.OP_TIME : "");
                sqlCommand.Parameters.AddWithValue("@OP_MODIFIED_BY", outPatientRegistration.OP_MODIFIED_BY != null ? outPatientRegistration.OP_MODIFIED_BY : "");
                sqlCommand.Parameters.AddWithValue("@NAME_SUR", outPatientRegistration.NAME_SUR != null ? outPatientRegistration.NAME_SUR : "");
                sqlCommand.Parameters.AddWithValue("@OP_NAME", outPatientRegistration.OP_NAME != null ? outPatientRegistration.OP_NAME : "");
                sqlCommand.Parameters.AddWithValue("@OP_FATHER_NAME", outPatientRegistration.OP_FATHER_NAME != null ? outPatientRegistration.OP_FATHER_NAME : "");
                sqlCommand.Parameters.AddWithValue("@OP_HUSBAND", outPatientRegistration.OP_HUSBAND != null ? outPatientRegistration.OP_HUSBAND : "");
                sqlCommand.Parameters.AddWithValue("@OP_ADDRESS", outPatientRegistration.OP_ADDRESS != null ? outPatientRegistration.OP_ADDRESS : "");
                sqlCommand.Parameters.AddWithValue("@OP_PLACE", outPatientRegistration.OP_PLACE != null ? outPatientRegistration.OP_PLACE : "");
                sqlCommand.Parameters.AddWithValue("@OP_PHONE_NUM", outPatientRegistration.OP_PHONE_NUM != null ? outPatientRegistration.OP_PHONE_NUM : "");
                sqlCommand.Parameters.AddWithValue("@OP_RELIGION", outPatientRegistration.OP_RELIGION != null ? outPatientRegistration.OP_RELIGION : "");
                sqlCommand.Parameters.AddWithValue("@OP_SUBCAST", outPatientRegistration.OP_SUBCAST != null ? outPatientRegistration.OP_SUBCAST : "");
                sqlCommand.Parameters.AddWithValue("@OP_CATEGORY", outPatientRegistration.OP_CATEGORY != null ? outPatientRegistration.OP_CATEGORY : "");
                sqlCommand.Parameters.AddWithValue("@OP_GENDER", outPatientRegistration.OP_GENDER != null ? outPatientRegistration.OP_GENDER : "");
                sqlCommand.Parameters.AddWithValue("@OP_DEPT_NAME", outPatientRegistration.OP_DEPT_NAME != null ? outPatientRegistration.OP_DEPT_NAME : "");
                sqlCommand.Parameters.AddWithValue("@OP_UNIT_NO", outPatientRegistration.OP_UNIT_NO != null ? outPatientRegistration.OP_UNIT_NO : "");
                sqlCommand.Parameters.AddWithValue("@OP_DOB", outPatientRegistration.OP_DOB != null ? outPatientRegistration.OP_DOB : "");
                sqlCommand.Parameters.AddWithValue("@OP_AGE", outPatientRegistration.OP_AGE != null ? outPatientRegistration.OP_AGE : "");
                sqlCommand.Parameters.AddWithValue("@OP_AGE1", outPatientRegistration.OP_AGE1 != null ? outPatientRegistration.OP_AGE1 : "");
                sqlCommand.Parameters.AddWithValue("@OP_ROOM_NO", outPatientRegistration.OP_ROOM_NO != null ? outPatientRegistration.OP_ROOM_NO : "");
                sqlCommand.Parameters.AddWithValue("@OP_OCCUPATION", outPatientRegistration.OP_OCCUPATION != null ? outPatientRegistration.OP_OCCUPATION : "");
                sqlCommand.Parameters.AddWithValue("@OP_INCOME", outPatientRegistration.OP_INCOME != null ? outPatientRegistration.OP_INCOME : "");
                sqlCommand.Parameters.AddWithValue("@OP_FEES", outPatientRegistration.OP_FEES != null ? outPatientRegistration.OP_FEES : "");
                sqlCommand.Parameters.AddWithValue("@OP_REF_DOCTOR", outPatientRegistration.OP_REF_DOCTOR != null ? outPatientRegistration.OP_REF_DOCTOR : "");
                sqlCommand.Parameters.AddWithValue("@OP_MARRRIED", outPatientRegistration.OP_MARRRIED != null ? outPatientRegistration.OP_MARRRIED : "");
                sqlCommand.Parameters.AddWithValue("@OP_COPERATE", outPatientRegistration.OP_COPERATE != null ? outPatientRegistration.OP_COPERATE : "");
                sqlCommand.Parameters.AddWithValue("@DUMMYYN", outPatientRegistration.DUMMYYN != null ? outPatientRegistration.DUMMYYN : "");
                sqlCommand.Parameters.AddWithValue("@OP_MONTH", outPatientRegistration.OP_MONTH != null ? outPatientRegistration.OP_MONTH : "");
                sqlCommand.Parameters.AddWithValue("@LABYN", outPatientRegistration.LABYN != null ? outPatientRegistration.LABYN : "");
                sqlCommand.Parameters.AddWithValue("@RAD_AGE", outPatientRegistration.RAD_AGE != null ? outPatientRegistration.RAD_AGE : "");
                sqlCommand.Parameters.AddWithValue("@CARD_NUMBER", outPatientRegistration.CARD_NUMBER != null ? outPatientRegistration.CARD_NUMBER : "");
                sqlCommand.Parameters.AddWithValue("@ALT_PHNO", outPatientRegistration.ALT_PHNO != null ? outPatientRegistration.ALT_PHNO : "");
                sqlCommand.Parameters.AddWithValue("@MODE", outPatientRegistration.MODE != null ? outPatientRegistration.MODE : "");
                sqlCommand.Parameters.AddWithValue("@Token_No", outPatientRegistration.Token_No != null ? outPatientRegistration.Token_No : "");
                sqlCommand.Parameters.AddWithValue("@ConsultantDR", outPatientRegistration.ConsultantDR != null ? outPatientRegistration.ConsultantDR : "");
                sqlCommand.Parameters.AddWithValue("@Location", outPatientRegistration.Location != null ? outPatientRegistration.Location : "");
                sqlCommand.Parameters.AddWithValue("@Barcode_No", outPatientRegistration.Barcode_No != null ? outPatientRegistration.Barcode_No : "");
                sqlCommand.Parameters.AddWithValue("@Barcode_Image", outPatientRegistration.Barcode_Image);
                //sqlCommand.Parameters.AddWithValue("@Barcode_Image", outPatientRegistration.Barcode_Image != null ? outPatientRegistration.Barcode_Image : "");
                sqlCommand.Parameters.AddWithValue("@MailID", outPatientRegistration.MailID != null ? outPatientRegistration.MailID : "");
                sqlCommand.Parameters.AddWithValue("@AadhaarID", outPatientRegistration.AadhaarID != null ? outPatientRegistration.AadhaarID : "");
                sqlCommand.Parameters.AddWithValue("@OPID", outPatientRegistration.OPID != null ? outPatientRegistration.OPID : "");
                sqlCommand.Parameters.AddWithValue("@COMPLAINTS", outPatientRegistration.COMPLAINTS != null ? outPatientRegistration.COMPLAINTS : "");
                sqlCommand.Parameters.AddWithValue("@ONEXAMINATIONS", outPatientRegistration.ONEXAMINATIONS != null ? outPatientRegistration.ONEXAMINATIONS : "");
                sqlCommand.Parameters.AddWithValue("@ADVICE", outPatientRegistration.ADVICE != null ? outPatientRegistration.ADVICE : "");
                sqlCommand.Parameters.AddWithValue("@PatientType", outPatientRegistration.PatientType != null ? outPatientRegistration.PatientType : "");
                //sqlCommand.Parameters.AddWithValue("@Flag", Flag);
                CheckNOpen();
                if (outPatientRegistration.MODE.ToLower().Trim() == "select")
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    details = new List<OutPatientModal.OutPatientRegistration>();
                    while (sqlDataReader.Read())
                    {
                        details.Add(new OutPatientModal.OutPatientRegistration()
                        {
                            // DeptCode = Convert.ToString(sqlDataReader["Dept_Code"]),
                            // DeptName = Convert.ToString(sqlDataReader["Dept_Name"])
                        });
                    }
                }
                if (outPatientRegistration.MODE.ToLower().Trim() == "save" || outPatientRegistration.MODE.ToLower().Trim() == "update" || outPatientRegistration.MODE.ToLower().Trim() == "delete")
                {
                    var output = sqlCommand.ExecuteNonQuery();
                    if (output >= 1)
                    {
                        details = new List<OutPatientModal.OutPatientRegistration>();
                        details.Add(new OutPatientModal.OutPatientRegistration()
                        {
                            Result = true
                        });
                    }
                    else
                    {
                        details = new List<OutPatientModal.OutPatientRegistration>();
                        details.Add(new OutPatientModal.OutPatientRegistration()
                        {
                            Result = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "CRUDOPRegistrationDetails");
            }
            finally
            {
                CheckNClose();
            }

            return details;
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
