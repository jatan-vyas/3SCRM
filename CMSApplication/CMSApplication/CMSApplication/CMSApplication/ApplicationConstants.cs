using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication
{
    public static class ApplicationConstants
    {
        public const string Operation_Add = "add";
        public const string Operation_Edit = "edit";
        public const string Operation_View = "view";
        public const string Operation_Delete = "remove";
        public const string DateFormat = "yyyy-MM-dd";

        public const string COMPANYID = "companyid";
        public const string USERNAME = "username";
        public const string USERID = "user";
        public const string ROLETYPE = "ROLETYPE";

        #region Company Constants use to bind datatable
        public const string COMP_NAME = "COMP_NAME";
        public const string COMP_ADDRESS = "COMP_ADDRESS";
        public const string COMP_PHONE = "COMP_PHONE";
        public const string COMP_TRADE_LICENSE_EXP = "COMP_TRADE_LICENSE_EXP";
        public const string COMP_IMMIGRATION_EXP = "COMP_IMMIGRATION_EXP";
        public const string COMP_IMPORT_CODE_EXP = "COMP_IMPORT_CODE_EXP";
        public const string COMP_INSURANCE_EXP = "COMP_INSURANCE_EXP";
        public const string COMP_CONTACT_PERSON = "COMP_CONTACT_PERSON";
        public const string COMP_CP_PHONE = "COMP_CP_PHONE";
        public const string COMP_EMAIL = "COMP_EMAIL";
        #endregion

        #region Employee constants
        public const string EMP_NAME = "EMP_NAME";
        public const string EMP_MOBILE = "EMP_MOBILE";
        public const string EMP_PASSPORT_EXP = "EMP_PASSPORT_EXP";
        public const string EMP_INSURANCE_EXP = "EMP_INSURANCE_EXP";
        public const string EMP_VISA_EXP = "EMP_VISA_EXP";
        public const string EMP_LABOR_CARD_EXP = "EMP_LABOR_CARD_EXP";
        #endregion

        #region Partner constants
        public const string PK_PARTNERID = "PK_PARTNERID";
        public const string FK_PARTNERID = "FK_PARTNERID";
        public const string PAR_NAME = "PAR_NAME";
        public const string PAR_MOBILE = "PAR_MOBILE";
        public const string PAR_PASSPORT_EXP = "PAR_PASSPORT_EXP";
        public const string PAR_INSURANCE_EXP = "PAR_INSURANCE_EXP";
        public const string PAR_VISA_EXP = "PAR_VISA_EXP";
        #endregion

        #region Partner Family
        public const string FML_NAME = "FML_NAME";
        public const string FML_RELATION = "FML_RELATION";
        public const string FML_PASSPORT_EXP = "FML_PASSPORT_EXP";
        public const string FML_INSURANCE_EXP = "FML_INSURANCE_EXP";
        public const string FML_VISA_EXP = "FML_VISA_EXP";
        #endregion

        #region Partner Misc
        public const string PK_MISCID = "PK_MISCID";
        public const string MISC_NAME = "MISC_NAME";
        public const string MISC_EXP_DATE = "MISC_EXP_DATE";
        #endregion

        #region User related
        public const string USER_PK_USERID = "PK_MISCID";
        public const string USER_USERNAME = "USERNAME";
        public const string USER_PASSWORD = "PASSWORD";
        public const string USER_NAME = "NAME";
        public const string USER_MOBILE_NO = "MOBILE_NO";
        #endregion

        #region - Common fields
        public const string NOTES = "NOTES";
        public const string IS_ACTIVE = "IS_ACTIVE";
        public const string IS_DELETED = "IS_DELETED";
        public const string FK_CREATED_BY = "FK_CREATED_BY";
        public const string FK_MODIFIED_BY = "FK_MODIFIED_BY";
        public const string CREATED_DATE = "CREATED_DATE";
        public const string MODIFIED_DATE = "MODIFIED_DATE";
        #endregion


        #region Import related block
        public const string SCHEMA_NAME = "dbo";
        public const string TABLE_NAME = "TABLE_NAME";
        public const string TABLE_COMPANY = "COMPANY";
        public const string TABLE_EMPLOYEE = "EMPLOYEE";
        public const string TABLE_PARTNER = "PARTNER";
        public const string TABLE_PARTNER_FAMILY = "PARTNER_FAMILY";
        public const string TABLE_PARTNER_MISC = "PARTNER_MISC";
        public const string DATABASE = "3SCRM";
        #endregion
    }
}