using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepinoHealth.CL.OPIPReports
{
    public class OPIPReportsModal
    {
        public class BothVisitPatients
        {
            public string FCh { get; set; }
            public string Opr_No { get; set; }
            public string Opr_Date { get; set; }
            public string Opr_Name { get; set; }
            public string Opr_Age { get; set; }
            public string Opr_Gender { get; set; }
            public string Opr_Dept_Name { get; set; }
            public string Opr_Category { get; set; }
            public string Opr_unit { get; set; }
            public string MCh { get; set; }
            public string O_FCh { get; set; }

            public DateTime? From_Date { get; set; }
            public DateTime? To_Date { get; set; }
        }
        public class ReVisitPatients
        {
            public string OP_NAME { get; set; }
            public string OP_DEPT_NAME { get; set; }
            public string OP_AGE { get; set; }
            public string OP_NO { get; set; }
            public string OP_DATE { get; set; }
            public string OP_YEAR { get; set; }
            public string NAME_SUR { get; set; }
            public string OP_REF_DOCTOR { get; set; }
        }
        public class NewVisitPatients
        {
            public string OP_NAME { get; set; }
            public string OP_DEPT_NAME { get; set; }
            public string OP_AGE { get; set; }
            public string OP_NO { get; set; }
            public string OP_DATE { get; set; }
            public string OP_YEAR { get; set; }
            public string NAME_SUR { get; set; }
            public string OP_REF_DOCTOR { get; set; }
            public string OP_Father_Name { get; set; }
            public string OP_Husband { get; set; }
            public string OP_Address { get; set; }
            public string OP_Gender { get; set; }
        }
        public class IPDPatients
        {
            public string IPD_No { get; set; }
            public DateTime IPD_Date { get; set; }
            public string IPD_Year { get; set; }
            public string IPD_Sub_Name { get; set; }
            public string IPD_Name { get; set; }
            public string IPD_Fathers_Name { get; set; }
            public string IPD_Husbands_Name { get; set; }
            public string IPD_Address { get; set; }
            public string IPD_Gender { get; set; }
            public string IPD_Age { get; set; }
            public string IPD_Dept_Name { get; set; }
            public string IPD_Ref_Doctor { get; set; }
        }
        public class Discharge
        {
            public string IP_No { get; set; }
            public string Discharge_Date { get; set; }
            public string SL_Year { get; set; }
            public string Patient_Name { get; set; }
            public string DOA { get; set; }
            public string Status_Of_Discharge { get; set; }
            public string Final_Diagnosis { get; set; }
            public string BriefHistory { get; set; }
            public string FollowUP { get; set; }
            public string ConsultantDrs { get; set; }
            public string Dept_Name { get; set; }
            public string Doctor_Name { get; set; }
        }
    }
}
