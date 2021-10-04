using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL
{
    public static class DBConstants
    {
        #region StoreProcedure Names
        public const string SP_GetCompanyAlert = "SP_GetCompanyAlert";
        public const string SP_GetEmployeeAlert = "SP_GetEmployeeAlert";
        public const string SP_GetPartnerAlert = "SP_GetPartnerAlert";
        public const string SP_GetPartnerFamilyAlert = "SP_GetPartnerFamilyAlert";
        public const string SP_GetPartnerMiscAlert = "SP_GetPartnerMiscAlert";
        public const string SP_GetCompanyDetails = "SP_GetCompanyDetails";
        public const string SP_GetPartnerDetails = "SP_GetPartnerDetails";
        public const string SP_GetEmployeeDetails = "SP_GetEmployeeDetails";
        public const string SP_GetLoginDetails = "SP_GetLoginDetails";
        public const string SP_GetPartnerMiscDetails = "SP_GetPartnerMiscDetails";
        public const string SP_GetUserDetails = "SP_GetUserDetails";
        public const string SP_GetPartnerFamilyDetails = "SP_GetPartnerFamilyDetails";
        public const string SP_UPSERTCompany = "SP_UPSERTCompany";
        public const string SP_UPSERTEmployee = "SP_UPSERTEmployee";
        public const string SP_UPSERTPartner = "SP_UPSERTPartner";
        public const string SP_UPSERTUser = "SP_UPSERTUser";
        public const string SP_UPSERTPartnerFamily = "SP_UPSERTPartnerFamily";
        public const string SP_UPSERTPartnerMisc = "SP_UPSERTPartnerMisc";
        public const string SP_DeleteCompany = "SP_DeleteCompany";
        public const string SP_DeleteEmployee = "SP_DeleteEmployee";
        public const string SP_DeletePartner = "SP_DeletePartner";
        public const string SP_DeletePartnerFamily = "SP_DeletePartnerFamily";
        public const string SP_DeleteMisc = "SP_DeleteMisc";
        #endregion
        #region StoreProcedure Parameters
        // Employee
        public const string EmployeeID = "@EmployeeID";
        public const string EmployeeName = "@EmployeeName";
        public const string EmployeeCompId = "@EmployeeCompId";
        public const string EmployeeMobile = "@EmployeeMobile";
        public const string EmployeePassportExp = "@EmployeePassportExp";
        public const string EmployeeInsuranceExp = "@EmployeeInsuranceExp";
        public const string EmployeeVisaExp = "@EmployeeVisaExp";
        public const string EmployeeLaborCardExp = "@EmployeeLaborCardExp";
        // Table Fields for bulk insert Employee
        public const string PK_EMPLOYEEID = "PK_EMPLOYEEID";
        public const string FK_COMPANYID = "FK_COMPANYID";
        public const string EMP_NAME = "EMP_NAME";
        public const string EMP_MOBILE = "EMP_MOBILE";
        public const string EMP_PASSPORT_EXP = "EMP_PASSPORT_EXP";
        public const string EMP_INSURANCE_EXP = "EMP_INSURANCE_EXP";
        public const string EMP_VISA_EXP = "EMP_VISA_EXP";
        public const string EMP_LABOR_CARD_EXP = "EMP_LABOR_CARD_EXP";
        // Company
        public const string CompanyID = "@CompanyID";
        public const string CompanyName = "@CompanyName";
        public const string CompanyAddress = "@CompanyAddress";
        public const string CompanyPhone = "@CompanyPhone";
        public const string CompanyTradeLicenceExp = "@CompanyTradeLicenceExp";
        public const string CompanyImmigrationExp = "@CompanyImmigrationExp";
        public const string CompanyImportCodeExp = "@CompanyImportCodeExp";
        public const string CompanyInsuranceExp = "@CompanyInsuranceExp";
        public const string CompanyEmail = "@CompanyEmail";
        public const string CompanyContactPerson = "@CompanyContactPerson";
        public const string CompanyContactPersonPhone = "@CompanyContactPersonPhone";
        // Table Fields for bulk insert Company
        public const string PK_COMPANYID = "PK_COMPANYID";
        public const string COMP_NAME = "COMP_NAME";
        public const string COMP_ADDRESS = "COMP_ADDRESS";
        public const string COMP_PHONE = "COMP_PHONE";
        public const string COMP_TRADE_LICENSE_EXP = "COMP_TRADE_LICENSE_EXP";
        public const string COMP_IMMIGRATION_EXP = "COMP_IMMIGRATION_EXP";
        public const string COMP_IMPORT_CODE_EXP = "COMP_IMPORT_CODE_EXP";
        public const string COMP_INSURANCE_EXP = "COMP_INSURANCE_EXP";
        public const string COMP_EMAIL = "COMP_EMAIL";
        public const string COMP_CONTACT_PERSON = "COMP_CONTACT_PERSON";
        public const string COMP_CP_PHONE = "COMP_CP_PHONE";
        // Partner
        public const string PartnerID = "@PartnerID";
        public const string PartnerName = "@PartnerName";
        public const string PartnerMobile = "@PartnerMobile";
        public const string PartnerPassportExp = "@PartnerPassportExp";
        public const string PartnerInsuranceExp = "@PartnerInsuranceExp";
        public const string PartnerVisaExp = "@PartnerVisaExp";
        // Table Fields for bulk insert Partner
        public const string PAR_NAME = "PAR_NAME";
        public const string PAR_MOBILE = "PAR_MOBILE";
        public const string PAR_PASSPORT_EXP = "PAR_PASSPORT_EXP";
        public const string PAR_INSURANCE_EXP = "PAR_INSURANCE_EXP";
        public const string PAR_VISA_EXP = "PAR_VISA_EXP";
        // Partner's Family
        public const string PartnerFamilyID = "@PartnerFamilyID";
        public const string PartnerFamilyName = "@PartnerFamilyName";
        public const string PartnerFamilyRelation = "@PartnerFamilyRelation";
        public const string PartnerFamilyMobile = "@PartnerFamilyMobile";
        public const string PartnerFamilyPassportExp = "@PartnerFamilyPassportExp";
        public const string PartnerFamilyInsuranceExp = "@PartnerFamilyInsuranceExp";
        public const string PartnerFamilyVisaExp = "@PartnerFamilyVisaExp";
        // Table Fields for bulk insert Partner Family
        public const string PK_FAMILYID = "PK_FAMILYID";
        public const string FK_PARTNERID = "FK_PARTNERID";
        public const string FML_NAME = "FML_NAME";
        public const string FML_RELATION = "FML_RELATION";
        public const string FML_PASSPORT_EXP = "FML_PASSPORT_EXP";
        public const string FML_INSURANCE_EXP = "FML_INSURANCE_EXP";
        public const string FML_VISA_EXP = "FML_VISA_EXP";

        // Partner's Misc 
        public const string PartnerMiscID = "@PartnerMiscID";
        public const string PartnerMiscName = "@PartnerMiscName";
        public const string PartnerMiscExpDate = "@PartnerMiscExpDate";
        // Table Fields for bulk insert Partner's Misc 
        public const string MISC_NAME = "MISC_NAME";
        public const string MISC_EXP_DATE = "MISC_EXP_DATE";
        // User's table
        public const string User_Name = "@Name";
        public const string User_MobileNo = "@MobileNo";
        //Common sp paramters
        public const string Notes = "@Notes";
        public const string IsActive = "@IsActive";
        public const string IsDeleted = "@IsDeleted";
        public const string CreatedBy = "@CreatedBy";
        public const string ModifiedBy = "@ModifiedBy";
        public const string CreatedDate = "@CreatedDate";
        public const string ModifiedDate = "@ModifiedDate";
        public const string ModeOfOpertion = "@ModeOfOpertion";
        public const string FromDate = "@FromDate";
        public const string ToDate = "@ToDate";
        public const string UserName = "@UserName";
        public const string UserID = "@UserID";
        public const string Password = "@Password";
        //Common database fields for bulk insert
        public const string NOTES = "NOTES";
        public const string IS_ACTIVE = "IS_ACTIVE";
        public const string IS_DELETED = "IS_DELETED";
        public const string FK_CREATED_BY = "FK_CREATED_BY";
        public const string FK_MODIFIED_BY = "FK_MODIFIED_BY";
        public const string CREATED_DATE = "CREATED_DATE";
        public const string MODIFIED_DATE = "MODIFIED_DATE";
        #endregion
    }
}