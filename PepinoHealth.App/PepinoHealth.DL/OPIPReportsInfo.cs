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
        public List<OPIPReportsModal.IPDPatients> GetIPDRegistrationDetails(string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.IPDPatients> details = null;
            try
            {
                string query = string.Empty;
                if (Department.ToUpper() == "ALL")
                {
                    query = "SELECT IPD_No ,IPD_Date,IPD_Year,IPD_Sub_Name,IPD_Name,IPD_Fathers_Name,IPD_Husbands_Name,IPD_Address,IPD_Gender,IPD_Age,IPD_Dept_Name,IPD_Ref_Doctor FROM IPD_Registration where IPD_Date between '" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and '" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "'";
                }
                else
                {
                    query = "SELECT IPD_No ,IPD_Date,IPD_Year,IPD_Sub_Name,IPD_Name,IPD_Fathers_Name,IPD_Husbands_Name,IPD_Address,IPD_Gender,IPD_Age,IPD_Dept_Name,IPD_Ref_Doctor FROM IPD_Registration where IPD_Dept_Name='" + Department + "'" + " and IPD_Date between '" + StartDate + "'" + " and '" + EndDate + "'";
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

        #region GetNewVisitPatientDetails
        public List<OPIPReportsModal.NewVisitPatients> GetNewVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.NewVisitPatients> details = null;

            try
            {
                string query = string.Empty;
                if (Department.ToUpper() == "NONE")
                {
                    query = "SELECT OP_No ,Op_Date,Op_Year,Name_Sur,OP_Name,Op_Father_Name,Op_Husband,Op_Address,Op_Gender,OP_Age,Op_Dept_Name,Op_Ref_Doctor FROM Out_Paitent_Registration where Op_Date between '" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and '" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "'";
                }
                else
                {
                    query = "SELECT OP_No ,Op_Date,Op_Year,Name_Sur,OP_Name,Op_Father_Name,Op_Husband,Op_Address,Op_Gender,OP_Age,Op_Dept_Name,Op_Ref_Doctor FROM Out_Paitent_Registration where Op_Dept_Name='" + Department + "'" + " and Op_Date between '" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and '" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "'";
                }
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<OPIPReportsModal.NewVisitPatients>();
                while (sqlDataReader.Read())
                {
                    details.Add(new OPIPReportsModal.NewVisitPatients()
                    {
                        OP_NAME = Convert.ToString(sqlDataReader["OP_Name"]),
                        OP_DEPT_NAME = Convert.ToString(sqlDataReader["Op_Dept_Name"]),
                        OP_AGE = Convert.ToString(sqlDataReader["OP_Age"]),
                        OP_NO = Convert.ToString(sqlDataReader["OP_NO"]),
                        OP_DATE = Convert.ToString(sqlDataReader["OP_DATE"]),
                        OP_YEAR = Convert.ToString(sqlDataReader["OP_YEAR"]),
                        NAME_SUR = Convert.ToString(sqlDataReader["NAME_SUR"]),
                        OP_REF_DOCTOR = Convert.ToString(sqlDataReader["OP_REF_DOCTOR"]),
                        OP_Father_Name = Convert.ToString(sqlDataReader["Op_Father_Name"]),
                        OP_Husband = Convert.ToString(sqlDataReader["Op_Husband"]),
                        OP_Address = Convert.ToString(sqlDataReader["OP_Address"]),
                        OP_Gender = Convert.ToString(sqlDataReader["Op_Gender"]),
                    });
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "GetNewVisitPatientDetails");
            }
            finally
            {
                CheckNClose();
            }

            return details;
        }

        #endregion

        #region GetReVisitPatientDetails
        public List<OPIPReportsModal.ReVisitPatients> GetReVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.ReVisitPatients> details = null;

            try
            {
                string query = string.Empty;
                if (Department.ToUpper() == "NONE")
                {
                    query = "SELECT Opr_No,Opr_Date,Opr_Year,Opr_Name_Sur,Opr_Name, Opr_Age,Opr_Dept_Name,Opr_ref_Doctor FROM dbo.Opd_Relist_Registration where Opr_Date between '" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and '" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "'";
                }
                else
                {
                    query = "SELECT Opr_No,Opr_Date,Opr_Year,Opr_Name_Sur,Opr_Name, Opr_Age,Opr_Dept_Name,Opr_ref_Doctor FROM dbo.Opd_Relist_Registration where Opr_Dept_Name='" + Department + "'" + " and Opr_Date between '" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and '" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "'";
                }
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<OPIPReportsModal.ReVisitPatients>();
                while (sqlDataReader.Read())
                {
                    details.Add(new OPIPReportsModal.ReVisitPatients()
                    {
                        OP_NAME = Convert.ToString(sqlDataReader["Opr_Name"]),
                        OP_DEPT_NAME = Convert.ToString(sqlDataReader["Opr_Dept_Name"]),
                        OP_AGE = Convert.ToString(sqlDataReader["Opr_Age"]),
                        OP_NO = Convert.ToString(sqlDataReader["Opr_NO"]),
                        OP_DATE = Convert.ToString(sqlDataReader["Opr_DATE"]),
                        OP_YEAR = Convert.ToString(sqlDataReader["Opr_YEAR"]),
                        NAME_SUR = Convert.ToString(sqlDataReader["Opr_Name_Sur"]),
                        OP_REF_DOCTOR = Convert.ToString(sqlDataReader["Opr_REF_DOCTOR"]),
                    });
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "GetREVisitPatientDetails");
            }
            finally
            {
                CheckNClose();
            }

            return details;
        }

        #endregion

        #region GetBothVisitPatientDetails
        public List<OPIPReportsModal.BothVisitPatients> GetBothVisitPatientDetails(string Visit, string Department, string StartDate, string EndDate)
        {
            List<OPIPReportsModal.BothVisitPatients> details = null;

            try
            {
                string query = string.Empty;
                if (Department.ToUpper() == "ALL")
                {


                    query = "select  'OP_Old' as FCh,Opr_No,Opr_Date,Opr_Name,Opr_Age,Opr_Gender,Opr_Dept_Name,Opr_Category,Opr_unit,Opr_Name_Sur as MCh,Card_Number as O_FCh,'" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' as From_Date,'" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' as To_Date from Opd_Relist_Registration where Opr_Date>='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and Opr_Date<='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and  Opr_Category='Regular' "
                    + "union all select 'OP_New' as FCh,OP_No,Op_Date,OP_Name,OP_Age,Op_Gender,Op_Dept_Name,Op_Category,Op_Unit_No,Name_Sur as MCh,Card_Number as O_FCh,'" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' as From_Date,'" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' as To_Date from Out_Paitent_Registration where Op_Date>='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' and Op_Date<='" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' and  Op_Category='Regular' order by Opr_No asc";

                }
                else
                {
                    query = "select  'OP_Old' as FCh,Opr_No,Opr_Date,Opr_Name,Opr_Age,Opr_Gender,Opr_Dept_Name,Opr_Category,Opr_unit,Opr_Name_Sur as MCh,Card_Number as O_FCh,'" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' as From_Date,'" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' as To_Date from Opd_Relist_Registration where Opr_Dept_Name='" + Department + "'" + "and Opr_Date>='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and Opr_Date<='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "'" + " and  Opr_Category='Regular' "
                     + "union all select 'OP_New' as FCh,OP_No,Op_Date,OP_Name,OP_Age,Op_Gender,Op_Dept_Name,Op_Category,Op_Unit_No,Name_Sur as MCh,Card_Number as O_FCh,'" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' as From_Date,'" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' as To_Date from Out_Paitent_Registration where Op_Dept_Name='" + Department + "'" + "and Op_Date>='" + DateTime.ParseExact(StartDate, "dd/MM/yyyy", null) + "' and Op_Date<='" + DateTime.ParseExact(EndDate, "dd/MM/yyyy", null) + "' and  Op_Category='Regular' order by Opr_No asc";

                }
                sqlConnection = AccessToDB();

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                CheckNOpen();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                details = new List<OPIPReportsModal.BothVisitPatients>();
                while (sqlDataReader.Read())
                {
                    details.Add(new OPIPReportsModal.BothVisitPatients()
                    {
                        FCh = Convert.ToString(sqlDataReader["FCh"]),
                        Opr_No = Convert.ToString(sqlDataReader["Opr_No"]),
                        Opr_Date = Convert.ToString(sqlDataReader["Opr_Date"]),
                        Opr_Name = Convert.ToString(sqlDataReader["Opr_Name"]),
                        Opr_Age = Convert.ToString(sqlDataReader["Opr_Age"]),
                        Opr_Gender = Convert.ToString(sqlDataReader["Opr_Gender"]),
                        Opr_Dept_Name = Convert.ToString(sqlDataReader["Opr_Dept_Name"]),
                        Opr_Category = Convert.ToString(sqlDataReader["Opr_Category"]),
                        Opr_unit = Convert.ToString(sqlDataReader["Opr_unit"]),
                        MCh = Convert.ToString(sqlDataReader["MCh"]),
                        O_FCh = Convert.ToString(sqlDataReader["O_FCh"]),
                        From_Date = Convert.ToDateTime(sqlDataReader["From_Date"]),
                        To_Date = Convert.ToDateTime(sqlDataReader["To_Date"])
                    });
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, "GetNewVisitPatientDetails");
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
