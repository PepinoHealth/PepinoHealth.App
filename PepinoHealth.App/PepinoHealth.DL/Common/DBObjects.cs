namespace PepinoHealth.DL.Common
{
    internal class DBObjects
    {
        //Admin Master
        public const string Pro_AddUserCredential = "Pro_AddUserCredential";
        public const string Pro_CRUDDepotMasterDetails = "Pro_CRUDDepotMasterDetails";
        public const string Pro_CRUDDoctorMasterDetails = "Pro_CRUDDoctorMasterDetails";
        public const string Pro_CRUDWardTypeMasterDetails = "Pro_CRUDWardTypeMasterDetails";
        public const string Pro_CRUDBedStrengthMasterDetails = "[dbo].[Pro_CRUDBedStrengthMasterDetails]";

        //OP Master
        public const string SP_OUT_Patient_REGISTRATION = "[dbo].[SP_OUT_PAITENT_REGISTRATION]";
        public const string Pro_CRUDOutPatientDetails = "Pro_CRUDOutPatientDetails";
        public const string Pro_CheckUserCredential = "Pro_CheckUserCredential";
    }
}
