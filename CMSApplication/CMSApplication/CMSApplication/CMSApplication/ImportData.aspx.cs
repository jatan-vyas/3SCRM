using CMSApplication.BAL.Company;
using CMSApplication.BAL.Employee;
using CMSApplication.BAL.Misc;
using CMSApplication.BAL.Partner;
using CMSApplication.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CMSApplication
{
    public partial class ImportData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string roleType = Convert.ToString(Session[ApplicationConstants.ROLETYPE]);
                if (string.IsNullOrEmpty(roleType))
                    Response.Redirect("Dashboard.aspx");

                if (roleType.ToLower().Trim() != "admin")
                    Response.Redirect("Dashboard.aspx");

            }
        }
        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {

        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string invalidExtensionFileName = "Following files has invalid extension";
            List<string> ErrorFileArray = new List<string>();
            string ExcelFile = Server.MapPath(@"~/ImportExcelData/");
            bool isFileInvalid = false;
            this.SuccessFailureMessageSpan.InnerText = "";

            if (!ExcelFileUpload.HasFile)
            {
                this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                this.SuccessFailureMessageSpan.InnerText = "Please upload a file.";
                return;
            }

            if (ExcelFileUpload.PostedFiles.Count == 1)
            {
                if (!ExcelFileUpload.FileName.Contains(".xlsx") || !ExcelFileUpload.FileName.Contains(".xls"))
                {
                    isFileInvalid = true;
                    invalidExtensionFileName += ExcelFileUpload.FileName;
                    this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                    this.SuccessFailureMessageSpan.InnerText += "File:" + ExcelFileUpload.FileName + " has Invalid file extension. Supported file formats are xls and xlsx..!";
                    return;
                }
                string fileName = ExcelFileUpload.FileName;
                ExcelFileUpload.SaveAs(ExcelFile + fileName);

            }
            else if (ExcelFileUpload.PostedFiles.Count > 1)
            {
                foreach (var currentExcelFile in ExcelFileUpload.PostedFiles)
                {
                    if (currentExcelFile.FileName.Contains("xlsx") || currentExcelFile.FileName.Contains("xls"))
                    {
                        string fileName = currentExcelFile.FileName;
                        ExcelFileUpload.SaveAs(ExcelFile + fileName);
                    }
                    else
                    {
                        isFileInvalid = true;
                        invalidExtensionFileName += currentExcelFile.FileName + ",";
                    }
                }
                if (isFileInvalid)
                {
                    this.SuccessFailureMessageSpan.InnerText = "";
                    this.SuccessFailureMessageSpan.InnerText += "File " + invalidExtensionFileName.TrimEnd(',') + " has Invalid file extension. Supported file formats are xls and xlsx..!";
                }
            }

            if (isFileInvalid)
                return;

            string oleDBConnectionString = ConfigurationManager.AppSettings.Get("OLEDBConnectionString");
            string folderPath = Server.MapPath(@"~/ImportExcelData/");
            string fileFullPath = string.Empty;
            var directory = new DirectoryInfo(folderPath);
            FileInfo[] files = directory.GetFiles();

            if (files == null || files.Count() == 0)
            {
                this.SuccessFailureMessageSpan.InnerText = "";
                this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                this.SuccessFailureMessageSpan.InnerText = "No files found in directory. Pleast try again";
                return;
            }

            try
            {
                foreach (FileInfo file in files)
                {
                    fileFullPath = folderPath + "\\" + file.Name;

                    //Create Excel Connection
                    string excelCS = string.Format(oleDBConnectionString, fileFullPath);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        //Get Sheet Name
                        con.Open();
                        DataTable dtSheet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        DataTable reArrangedDataTable = RearrangeDataTable(dtSheet, con);
                        if (reArrangedDataTable == null)
                        {
                            this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                            sb.Append("Some error occurred whille rearranging data for file -" + file.FullName);
                            sb.Append("<br/>");
                            this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                            continue;
                        }
                        long? latestCompanyID = 0;

                        string sheetname = string.Empty;
                        foreach (DataRow drSheet in reArrangedDataTable.Rows)
                        {
                            sheetname = Convert.ToString(drSheet[ApplicationConstants.TABLE_NAME]);

                            #region Start importing data from company table
                            if (sheetname.ToLower().Trim().Contains("company"))
                            {
                                #region Load the DataTable with Sheet Data so we can get the column header
                                OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
                                OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                DataTable companyDt = new DataTable();
                                adp.Fill(companyDt);
                                con.Close();
                                #endregion

                                #region Delete the row if all values are nulll
                                companyDt = RemoveNullValues(companyDt);
                                #endregion

                                #region Rename datatable column names to actual table names
                                for (int i = 0; i < companyDt.Columns.Count; i++)
                                {
                                    if (companyDt.Columns[i].ColumnName.ToLower().Trim().Equals("company name"))
                                        companyDt.Columns[i].ColumnName = DBConstants.COMP_NAME;
                                    if (companyDt.Columns[i].ColumnName.ToLower().Trim().Equals("trade license expiry"))
                                        companyDt.Columns[i].ColumnName = DBConstants.COMP_TRADE_LICENSE_EXP;
                                    if (companyDt.Columns[i].ColumnName.ToLower().Trim().Equals("immigration card expiry"))
                                        companyDt.Columns[i].ColumnName = DBConstants.COMP_IMMIGRATION_EXP;
                                    if (companyDt.Columns[i].ColumnName.ToLower().Trim().Equals("import code expiry"))
                                        companyDt.Columns[i].ColumnName = DBConstants.COMP_IMPORT_CODE_EXP;
                                    if (companyDt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
                                        companyDt.Columns[i].ColumnName = DBConstants.COMP_INSURANCE_EXP;
                                }
                                #endregion

                                #region Start dumping data into company database
                                try
                                {
                                    // There should only be one record for the company so we have taken only first row
                                    DataRow dr = companyDt.Rows[0];
                                    if (string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.COMP_NAME])))
                                    {
                                        sb.Append("Company Name field in file is empty -in" + file.FullName + " so processing of this file is skipped. Please correct the file and upload it again");
                                        this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                        break;
                                    }
                                    DAL.Company.Company company = new DAL.Company.Company();
                                    company.Comp_name = Convert.ToString(dr[DBConstants.COMP_NAME]).Trim();
                                    company.Comp_address = Convert.ToString(DBNull.Value);
                                    company.Comp_phone = Convert.ToString(DBNull.Value);
                                    company.Comp_trade_license_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_TRADE_LICENSE_EXP]));
                                    company.Comp_immigration_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_IMMIGRATION_EXP]));
                                    company.Comp_import_code_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_IMPORT_CODE_EXP]));
                                    company.Comp_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_INSURANCE_EXP]));
                                    company.Comp_email = Convert.ToString(DBNull.Value);
                                    company.Comp_contact_person = Convert.ToString(DBNull.Value);
                                    company.Comp_cp_phone = Convert.ToString(DBNull.Value);
                                    company.Notes = Convert.ToString(DBNull.Value);
                                    company.Is_active = true;
                                    company.Is_deleted = false;
                                    company.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                    company.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                    company.Created_date = DateTime.Now;
                                    company.Modified_date = DateTime.Now;

                                    bool isCompanyDumpToDatabase = new CompanyService().UPSertCompany(company, ApplicationConstants.Operation_Add);

                                    if (isCompanyDumpToDatabase)
                                        latestCompanyID = new CompanyService().GetLastInsertedCompanyID(Convert.ToString(dr[DBConstants.COMP_NAME]));
                                    else
                                    {
                                        sb.Append("<br/>");
                                        sb.Append("Company name " + Convert.ToString(dr[DBConstants.COMP_NAME]) + "is not dumped to database for " + file.FullName);
                                        this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    sb.Append("An error occurred while importing company name from file - " + file.FullName + "Please correct the file and upload it again");
                                    this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                    sb.Append("<br/>");
                                    continue;
                                }
                                #endregion

                            }
                            #endregion

                            #region Start importing data from partner table
                            else if (sheetname.ToLower().Trim().Contains("partner"))
                            {
                                if (latestCompanyID.HasValue && latestCompanyID > 0)
                                {

                                    #region Load the DataTable with Sheet Data so we can get the column header
                                    OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
                                    OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                    DataTable partnerDt = new DataTable();
                                    adp.Fill(partnerDt);
                                    con.Close();
                                    #endregion

                                    #region Delete the row if all values are nulll
                                    partnerDt = RemoveNullValues(partnerDt);
                                    #endregion

                                    #region Rename datatable column names to actual table names
                                    for (int i = 0; i < partnerDt.Columns.Count; i++)
                                    {
                                        if (partnerDt.Columns[i].ColumnName.ToLower().Trim().Equals("name of partner"))
                                            partnerDt.Columns[i].ColumnName = DBConstants.PAR_NAME;
                                        if (partnerDt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
                                            partnerDt.Columns[i].ColumnName = DBConstants.PAR_PASSPORT_EXP;
                                        if (partnerDt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
                                            partnerDt.Columns[i].ColumnName = DBConstants.PAR_VISA_EXP;
                                        if (partnerDt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
                                            partnerDt.Columns[i].ColumnName = DBConstants.PAR_INSURANCE_EXP;
                                    }
                                    #endregion

                                    #region Start dumping data into partner database
                                    for (int i = 0; i < partnerDt.Rows.Count; i++)
                                    {
                                        DataRow dr = partnerDt.Rows[i];
                                        if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.PAR_NAME])))
                                        {
                                            DAL.Partner.Partner par = new DAL.Partner.Partner();
                                            par.Fk_companyid = latestCompanyID.Value;
                                            par.Par_name = Convert.ToString(dr[DBConstants.PAR_NAME]);
                                            par.Par_mobile = Convert.ToString(DBNull.Value);
                                            par.Par_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_PASSPORT_EXP]));
                                            par.Par_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_INSURANCE_EXP]));
                                            par.Par_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_VISA_EXP]));
                                            par.Notes = Convert.ToString(DBNull.Value);
                                            par.Is_active = true;
                                            par.Is_deleted = false;
                                            par.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            par.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            par.Created_date = DateTime.Now;
                                            par.Modified_date = DateTime.Now;
                                            bool isPartnerDumpToDatabase = new PartnerService().UPSertPartner(par, ApplicationConstants.Operation_Add);
                                            if (!isPartnerDumpToDatabase)
                                            {
                                                sb.Append("<br/>");
                                                sb.Append("Partner entry with name name " + Convert.ToString(dr[DBConstants.PAR_NAME]) + " is not dumped to database for " + file.FullName);
                                                this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                            #region Start importing data from employee table
                            else if (sheetname.ToLower().Trim().Contains("employee"))
                            {
                                if (latestCompanyID.HasValue && latestCompanyID > 0)
                                {

                                    #region Load the DataTable with Sheet Data so we can get the column header
                                    OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
                                    OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                    DataTable employeeDt = new DataTable();
                                    adp.Fill(employeeDt);
                                    con.Close();
                                    #endregion

                                    #region Delete the row if all values are nulll
                                    employeeDt = RemoveNullValues(employeeDt);
                                    #endregion

                                    #region Rename datatable column names to actual table names
                                    for (int i = 0; i < employeeDt.Columns.Count; i++)
                                    {
                                        if (employeeDt.Columns[i].ColumnName.ToLower().Trim().Equals("name of employee"))
                                            employeeDt.Columns[i].ColumnName = DBConstants.EMP_NAME;
                                        if (employeeDt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
                                            employeeDt.Columns[i].ColumnName = DBConstants.EMP_PASSPORT_EXP;
                                        if (employeeDt.Columns[i].ColumnName.ToLower().Trim().Equals("labor card expiry"))
                                            employeeDt.Columns[i].ColumnName = DBConstants.EMP_LABOR_CARD_EXP;
                                        if (employeeDt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
                                            employeeDt.Columns[i].ColumnName = DBConstants.EMP_VISA_EXP;
                                        if (employeeDt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
                                            employeeDt.Columns[i].ColumnName = DBConstants.EMP_INSURANCE_EXP;
                                    }
                                    #endregion

                                    #region Start dumping data into employee database
                                    for (int i = 0; i < employeeDt.Rows.Count; i++)
                                    {
                                        DataRow dr = employeeDt.Rows[i];
                                        if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.EMP_NAME])))
                                        {
                                            DAL.Employee.Employee emp = new DAL.Employee.Employee();
                                            emp.Fk_companyid = latestCompanyID.Value;
                                            emp.Emp_name = Convert.ToString(dr[DBConstants.EMP_NAME]);
                                            emp.Emp_mobile = Convert.ToString(DBNull.Value);
                                            emp.Emp_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_PASSPORT_EXP]));
                                            emp.Emp_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_INSURANCE_EXP]));
                                            emp.Emp_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_VISA_EXP]));
                                            emp.Emp_labor_card_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_LABOR_CARD_EXP]));
                                            emp.Notes = Convert.ToString(DBNull.Value);
                                            emp.Is_active = true;
                                            emp.Is_deleted = false;
                                            emp.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            emp.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            emp.Created_date = DateTime.Now;
                                            emp.Modified_date = DateTime.Now;
                                            bool isEmployeeDumpToDatabase = new EmployeeService().UPSertEmployee(emp, ApplicationConstants.Operation_Add);
                                            if (!isEmployeeDumpToDatabase)
                                            {
                                                sb.Append("<br/>");
                                                sb.Append("Employee entry with name " + Convert.ToString(dr[DBConstants.EMP_NAME]) + " is not dumped to database for " + file.FullName);
                                                this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                            #region Start importing data from Partner family table
                            else if (sheetname.ToLower().Trim().Contains("family"))
                            {
                                if (latestCompanyID.HasValue && latestCompanyID > 0)
                                {
                                    #region Load the DataTable with Sheet Data so we can get the column header
                                    OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
                                    OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                    DataTable familyDt = new DataTable();
                                    adp.Fill(familyDt);
                                    con.Close();
                                    #endregion

                                    #region Delete the row if all values are nulll
                                    familyDt = RemoveNullValues(familyDt);
                                    #endregion

                                    #region Rename datatable column names to actual table names
                                    for (int i = 0; i < familyDt.Columns.Count; i++)
                                    {
                                        if (familyDt.Columns[i].ColumnName.ToLower().Trim().Equals("name"))
                                            familyDt.Columns[i].ColumnName = DBConstants.FML_NAME;
                                        if (familyDt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
                                            familyDt.Columns[i].ColumnName = DBConstants.FML_PASSPORT_EXP;
                                        if (familyDt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
                                            familyDt.Columns[i].ColumnName = DBConstants.FML_VISA_EXP;
                                        if (familyDt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
                                            familyDt.Columns[i].ColumnName = DBConstants.FML_INSURANCE_EXP;
                                        if (familyDt.Columns[i].ColumnName.ToLower().Trim().Equals("sponsor"))
                                            familyDt.Columns[i].ColumnName = "Sponsor";

                                    }
                                    #endregion

                                    #region Start dumping data into employee database
                                    for (int i = 0; i < familyDt.Rows.Count; i++)
                                    {
                                        DataRow dr = familyDt.Rows[i];
                                        if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.FML_NAME])) && !string.IsNullOrEmpty(Convert.ToString(dr["Sponsor"])))
                                        {

                                            long? partnerId = new PartnerService().GetPartnerIDFromPartnerName(latestCompanyID.Value, Convert.ToString(dr["Sponsor"]));

                                            if (partnerId.HasValue && partnerId > 0)
                                            {
                                                DAL.Partner.PartnerFamily fml = new DAL.Partner.PartnerFamily();
                                                fml.Fk_partnerid = partnerId.Value;
                                                fml.Fml_name = Convert.ToString(dr[DBConstants.FML_NAME]);
                                                fml.Fml_relation = Convert.ToString(DBNull.Value);
                                                fml.Fml_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_PASSPORT_EXP]));
                                                fml.Fml_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_INSURANCE_EXP]));
                                                fml.Fml_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_VISA_EXP]));
                                                fml.Notes = Convert.ToString(DBNull.Value);
                                                fml.Is_active = true;
                                                fml.Is_deleted = false;
                                                fml.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                                fml.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                                fml.Created_date = DateTime.Now;
                                                fml.Modified_date = DateTime.Now;
                                                bool isFamilyDumpToDatabase = new PartnerService().UPSertPartnerFamily(fml, ApplicationConstants.Operation_Add);
                                                if (!isFamilyDumpToDatabase)
                                                {
                                                    sb.Append("<br/>");
                                                    sb.Append("Family Entry with name +" + dr[DBConstants.FML_NAME] + " is not dumped to database for " + file.FullName);
                                                    this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                                }

                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                            #region Start importing data from misc table
                            else if (sheetname.ToLower().Trim().Contains("misc"))
                            {
                                if (latestCompanyID.HasValue && latestCompanyID > 0)
                                {

                                    #region Load the DataTable with Sheet Data so we can get the column header
                                    OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
                                    OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                                    DataTable miscDt = new DataTable();
                                    adp.Fill(miscDt);
                                    con.Close();
                                    #endregion

                                    #region Delete the row if all values are nulll
                                    miscDt = RemoveNullValues(miscDt);
                                    #endregion

                                    #region Rename datatable column names to actual table names
                                    for (int i = 0; i < miscDt.Columns.Count; i++)
                                    {
                                        if (miscDt.Columns[i].ColumnName.ToLower().Trim().Equals("name of misc"))
                                            miscDt.Columns[i].ColumnName = DBConstants.MISC_NAME;
                                        if (miscDt.Columns[i].ColumnName.ToLower().Trim().Equals("misc expiry"))
                                            miscDt.Columns[i].ColumnName = DBConstants.MISC_EXP_DATE;
                                    }
                                    #endregion

                                    #region Start dumping data into misc database
                                    for (int i = 0; i < miscDt.Rows.Count; i++)
                                    {
                                        DataRow dr = miscDt.Rows[i];
                                        if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.MISC_NAME])) && !string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.MISC_EXP_DATE])))
                                        {
                                            DAL.Misc.PartnerMisc emp = new DAL.Misc.PartnerMisc();
                                            emp.Fk_companyid = latestCompanyID.Value;
                                            emp.Misc_name = Convert.ToString(dr[DBConstants.MISC_NAME]);
                                            emp.Misc_exp_date = SanitizeDateFields(Convert.ToString(dr[DBConstants.MISC_EXP_DATE]));
                                            emp.Notes = Convert.ToString(DBNull.Value);
                                            emp.Is_active = true;
                                            emp.Is_deleted = false;
                                            emp.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            emp.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
                                            emp.Created_date = DateTime.Now;
                                            emp.Modified_date = DateTime.Now;
                                            bool isMiscDumpToDatabase = new MiscService().UPSertPartnerMisc(emp, ApplicationConstants.Operation_Add);
                                            if (!isMiscDumpToDatabase)
                                            {
                                                sb.Append("<br/>");
                                                sb.Append("Misc entry+" + dr[DBConstants.FML_NAME] + " is not dumped to database for " + file.FullName);

                                                this.SuccessFailureMessageSpan.InnerText = sb.ToString();
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                sb.Append("Some error occurred -" + ex.Message);
            }
            finally
            {
                //this.SuccessFailureMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                this.SuccessFailureMessageSpan.InnerText += sb.ToString();
                this.SuccessFailureMessageSpan.InnerText += "Import process completed";
                Array.ForEach(Directory.GetFiles(folderPath), File.Delete);
            }

        }
        public void RemoveFilesFromDirectory()
        {

        }
        public DataTable RemoveNullValues(DataTable sourceDatatable)
        {
            int columnCount = sourceDatatable.Columns.Count;
            for (int i = sourceDatatable.Rows.Count - 1; i >= 0; i--)
            {
                bool allNull = true;
                for (int j = 0; j < columnCount; j++)
                {
                    if (sourceDatatable.Rows[i][j] != DBNull.Value)
                    {
                        allNull = false;
                    }
                }
                if (allNull)
                {
                    sourceDatatable.Rows[i].Delete();
                }
            }
            sourceDatatable.AcceptChanges();
            return sourceDatatable;
        }
        public DataTable RearrangeDataTable(DataTable sourceDatatable, OleDbConnection con)
        {
            DataTable destinationDataTable = new DataTable();
            try
            {
                destinationDataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                destinationDataTable.Clear();
                bool isCompanyAdded = false; bool isEmployeeAdded = false; bool isPartnerAdded = false; bool isPartnerFamilyAdded = false; bool isMiscAdded = false;
                for (int i = 0; i < sourceDatatable.Rows.Count; i++)
                {
                    if (isCompanyAdded && isEmployeeAdded && isPartnerAdded && isMiscAdded && isPartnerFamilyAdded)
                        break;

                    DataRow _currentDRSheet = sourceDatatable.Rows[i];
                    string _sheetname = Convert.ToString(_currentDRSheet[ApplicationConstants.TABLE_NAME]);
                    if (!isCompanyAdded && _sheetname.ToLower().Trim().Contains("company"))
                    {
                        destinationDataTable.ImportRow(_currentDRSheet);
                        isCompanyAdded = true;
                        i = 0;
                        continue;
                    }
                    if (isCompanyAdded && !isEmployeeAdded && _sheetname.ToLower().Trim().Contains("employee"))
                    {
                        destinationDataTable.ImportRow(_currentDRSheet);
                        isEmployeeAdded = true;
                        i = 0;
                        continue;
                    }
                    if (isCompanyAdded && !isPartnerAdded && _sheetname.ToLower().Trim().Contains("partner"))
                    {
                        destinationDataTable.ImportRow(_currentDRSheet);
                        isPartnerAdded = true;
                        i = 0;
                        continue;
                    }
                    if (isCompanyAdded && isPartnerAdded && !isPartnerFamilyAdded && _sheetname.ToLower().Trim().Contains("family"))
                    {
                        destinationDataTable.ImportRow(_currentDRSheet);
                        isPartnerFamilyAdded = true;
                        i = 0;
                        continue;
                    }
                    if (isCompanyAdded && isPartnerAdded && !isMiscAdded && _sheetname.ToLower().Trim().Contains("misc"))
                    {
                        destinationDataTable.ImportRow(_currentDRSheet);
                        isMiscAdded = true;
                        i = 0;
                        continue;
                    }
                }
                return destinationDataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DateTime? SanitizeDateFields(string DbDates)
        {
            DateTime? dbDate = null;
            try
            {
                if (string.IsNullOrEmpty(DbDates.Trim()))
                    return null;

                string replacedDbDates = Regex.Replace(DbDates, "[A-Za-z() &%#$]", "");

                if (string.IsNullOrEmpty(replacedDbDates.Trim()))
                    return null;

                try
                {
                    dbDate = DateTime.ParseExact(replacedDbDates, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    return dbDate;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}