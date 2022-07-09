using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepinoHealth.CL.Admin
{
    public class AdminModal
    {
        //UserMasterDetails
        public class UserMaster
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Prepared_By { get; set; }
            public string Modified_By { get; set; }
            public string Admin_tools { get; set; }
            public string HMS { get; set; }
            public string Billing { get; set; }
            public string MRD { get; set; }
            public string Bloodbank { get; set; }
            public string Laboratory { get; set; }
            public string Radiology { get; set; }
            public string Certificate { get; set; }
            public string OT { get; set; }
            public string Hims { get; set; }
            public string Store { get; set; }
            public string Attendance { get; set; }
            public string DischargeSummary { get; set; }
            public string Casesheet { get; set; }
            public string Modify { get; set; }
            public string Refund { get; set; }
            public string Delete { get; set; }
            public string Cancel { get; set; }
            public string Module { get; set; }
            public string Pharmacy { get; set; }
            public string OPA { get; set; }
            public string GRNA { get; set; }
            public string PRefund { get; set; }
            public string Bill_Modify { get; set; }
            public bool Result { get; set; }
        }
        //DepotMasterDetails
        public class DepotMaster
        {
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string Flag { get; set; }
            public bool Result { get; set; }
            public string DeptGroupName { get; set; }
        }
        //DoctorMasterDetails
        public class DoctorMaster
        {
            public string Doctor_Id { get; set; }
            public string Doctor_Name { get; set; }
            public string Flag { get; set; }
            public bool Result { get; set; }
            public string Doc_Address { get; set; }
            public string Doc_Qualification { get; set; }
            public string Doc_Mobile_No { get; set; }
            public string Doc_Dept_Name { get; set; }
            public Decimal OPDCHARGE { get; set; }
            public Decimal OPRCHARGE { get; set; }
        }
        //WardTypeMasterDetails
        public class WardTypeMaster
        {
            public string ward_t_Slno { get; set; }
            public string Ward_T_Type { get; set; }
            public string Flag { get; set; }
            public bool Result { get; set; }
            public string Tarrif_Per { get; set; }
            public string Tarrif_per_type { get; set; }
        }
        //BedStrengthDetails
        public class BedStrength
        {
            public string BedCode { get; set; }
            public string DeptName { get; set; }
            public string Flag { get; set; }
            public bool Result { get; set; }
            public string NoofBeds { get; set; }
        }
    }
}
