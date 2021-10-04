using CMSApplication.BAL.Company;
using CMSApplication.BAL.Employee;
using CMSApplication.BAL.Misc;
using CMSApplication.BAL.Partner;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSApplication.DAL;
using System.Text.RegularExpressions;

namespace CMSApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindCompanyAlertRepeater(txtFromDate.Text, txtToDate.Text);
                BindEmployeeAlertRepeater(txtFromDate.Text, txtToDate.Text);
                BindPartnerAlertRepeater(txtFromDate.Text, txtToDate.Text);
                BindPartnerFamilyAlertRepeater(txtFromDate.Text, txtToDate.Text);
                BindMiscAlertRepeater(txtFromDate.Text, txtToDate.Text);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromDate = txtFromDate.Text.Trim();
            string toDate = txtToDate.Text.Trim();

            #region Fetch Alerts
            #region Fetch Company Alert             
            BindCompanyAlertRepeater(fromDate, toDate);
            #endregion

            #region Fetch Employee Alert            
            BindEmployeeAlertRepeater(fromDate, toDate);
            #endregion

            #region Fetch Partner Alert            
            BindPartnerAlertRepeater(fromDate, toDate);
            #endregion

            #region Fetch Partner's Family Alert
            BindPartnerFamilyAlertRepeater(fromDate, toDate);
            #endregion

            #region Fetch Misc Alert
            BindMiscAlertRepeater(fromDate, toDate);
            #endregion
            #endregion
        }
        private void BindCompanyAlertRepeater(string fromDate, string toDate)
        {
            CompanyService companyService = new CompanyService();
            DataTable companyDataTable = companyService.GetCompanyAlert(txtFromDate.Text, txtToDate.Text);

            if (companyDataTable != null && companyDataTable.Rows.Count > 0)
                lblCompanyAlertCount.Text = companyDataTable.Rows.Count.ToString();
            else
                lblCompanyAlertCount.Text = "0";

            companyAlertRepeater.DataSource = companyDataTable;
            companyAlertRepeater.DataBind();
        }
        private void BindEmployeeAlertRepeater(string fromDate, string toDate)
        {
            EmployeeService employeeService = new EmployeeService();
            DataTable employeeDataTable = employeeService.GetEmployeeAlert(txtFromDate.Text, txtToDate.Text);

            if (employeeDataTable != null && employeeDataTable.Rows.Count > 0)
                lblEmployeeAlertCount.Text = employeeDataTable.Rows.Count.ToString();
            else
                lblEmployeeAlertCount.Text = "0";

            employeeAlertRepeater.DataSource = employeeDataTable;
            employeeAlertRepeater.DataBind();
        }
        private void BindPartnerAlertRepeater(string fromDate, string toDate)
        {
            PartnerService partnerService = new PartnerService();
            DataTable partnerDataTable = partnerService.GetPartnerAlert(txtFromDate.Text, txtToDate.Text);

            if (partnerDataTable != null && partnerDataTable.Rows.Count > 0)
                lblPartnerAlertCount.Text = partnerDataTable.Rows.Count.ToString();
            else
                lblPartnerAlertCount.Text = "0";

            partnerAlertRepeater.DataSource = partnerDataTable;
            partnerAlertRepeater.DataBind();
        }
        private void BindPartnerFamilyAlertRepeater(string fromDate, string toDate)
        {
            PartnerService partnerService = new PartnerService();
            DataTable partnerFamilyDataTable = partnerService.GetPartnerFamilyAlert(txtFromDate.Text, txtToDate.Text);

            if (partnerFamilyDataTable != null && partnerFamilyDataTable.Rows.Count > 0)
                lblPartnerFamilyAlertCount.Text = partnerFamilyDataTable.Rows.Count.ToString();
            else
                lblPartnerFamilyAlertCount.Text = "0";

            partnerFamilyAlertRepeater.DataSource = partnerFamilyDataTable;
            partnerFamilyAlertRepeater.DataBind();
        }
        private void BindMiscAlertRepeater(string fromDate, string toDate)
        {
            MiscService miscService = new MiscService();
            DataTable miscDataTable = miscService.GetPartnerMiscAlert(txtFromDate.Text, txtToDate.Text);

            if (miscDataTable != null && miscDataTable.Rows.Count > 0)
                lblMiscAlertCount.Text = miscDataTable.Rows.Count.ToString();
            else
                lblMiscAlertCount.Text = "0";

            miscAlertRepeater.DataSource = miscDataTable;
            miscAlertRepeater.DataBind();
        }
        //protected void btnImport_Click(object sender, EventArgs e)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string invalidExtensionFileName = "Following files has invalid extension";
        //    List<string> ErrorFileArray = new List<string>();
        //    string ExcelFile = Server.MapPath(@"~/ImportExcelData/");
        //    if (ExcelFileUpload.HasFile)
        //    {
        //        if (ExcelFileUpload.PostedFiles.Count == 1)
        //        {
        //            if (ExcelFileUpload.FileName.Contains(".xlsx") || !ExcelFileUpload.FileName.Contains(".xls"))
        //            {
        //                string fileName = ExcelFileUpload.FileName;
        //                //string path = Server.MapPath(@"~/ImportExcelData/" + fileName);
        //                //string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        //                ExcelFileUpload.SaveAs(ExcelFile + fileName);
        //            }
        //            else
        //            {
        //                invalidExtensionFileName += ExcelFileUpload.FileName;
        //            }
        //        }
        //        else if (ExcelFileUpload.PostedFiles.Count > 1)
        //        {
        //            foreach (var currentExcelFile in ExcelFileUpload.PostedFiles)
        //            {
        //                if (currentExcelFile.FileName.Contains("xlsx") || currentExcelFile.FileName.Contains("xls"))
        //                {
        //                    string fileName = currentExcelFile.FileName;
        //                    ExcelFileUpload.SaveAs(ExcelFile + fileName);
        //                }
        //                else
        //                {
        //                    invalidExtensionFileName += currentExcelFile.FileName;
        //                }
        //            }
        //        }
        //    }
        //    string connectionString = ConfigurationManager.AppSettings.Get("CMSDatabaseConnectionString");
        //    string oleDBConnectionString = ConfigurationManager.AppSettings.Get("OLEDBConnectionString");
        //    SqlConnection SQLConnection = new SqlConnection();
        //    SQLConnection.ConnectionString = connectionString;
        //    string folderPath = Server.MapPath(@"~/ImportExcelData/");
        //    string fileFullPath = string.Empty;

        //    var directory = new DirectoryInfo(folderPath);
        //    FileInfo[] files = directory.GetFiles();

        //    foreach (FileInfo file in files)
        //    {
        //        fileFullPath = folderPath + "\\" + file.Name;
        //        //Create Excel Connection
        //        string excelCS = string.Format(oleDBConnectionString, fileFullPath);

        //        using (OleDbConnection con = new OleDbConnection(excelCS))
        //        {
        //            //Get Sheet Name
        //            con.Open();
        //            DataTable dtSheet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //            //DataTable tableColumns = con.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,null);

        //            #region Arrange sheet

        //            DataTable dtSheetRearranged = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //            dtSheetRearranged.Clear();
        //            bool isCompanyAdded = false; bool isEmployeeAdded = false; bool isPartnerAdded = false; bool isPartnerFamilyAdded = false; bool isMiscAdded = false;
        //            for (int i = 0; i < dtSheet.Rows.Count; i++)
        //            {
        //                if (isCompanyAdded && isEmployeeAdded && isPartnerAdded && isMiscAdded && isPartnerFamilyAdded)
        //                    break;
        //                DataRow _currentDRSheet = dtSheet.Rows[i];
        //                string _sheetname = Convert.ToString(_currentDRSheet[ApplicationConstants.TABLE_NAME]);
        //                if (!isCompanyAdded && _sheetname.ToLower().Trim().Contains("company"))
        //                {
        //                    dtSheetRearranged.ImportRow(_currentDRSheet);
        //                    isCompanyAdded = true;
        //                    i = 0;
        //                    continue;
        //                }
        //                if (isCompanyAdded && !isEmployeeAdded && _sheetname.ToLower().Trim().Contains("employee"))
        //                {
        //                    dtSheetRearranged.ImportRow(_currentDRSheet);
        //                    isEmployeeAdded = true;
        //                    i = 0;
        //                    continue;
        //                }
        //                if (isCompanyAdded && !isPartnerAdded && _sheetname.ToLower().Trim().Contains("partner"))
        //                {
        //                    dtSheetRearranged.ImportRow(_currentDRSheet);
        //                    isPartnerAdded = true;
        //                    i = 0;
        //                    continue;
        //                }
        //                if (isCompanyAdded && isPartnerAdded && !isPartnerFamilyAdded && _sheetname.ToLower().Trim().Contains("family"))
        //                {
        //                    dtSheetRearranged.ImportRow(_currentDRSheet);
        //                    isPartnerFamilyAdded = true;
        //                    i = 0;
        //                    continue;
        //                }
        //                if (isCompanyAdded && isPartnerAdded && !isMiscAdded && _sheetname.ToLower().Trim().Contains("misc"))
        //                {
        //                    dtSheetRearranged.ImportRow(_currentDRSheet);
        //                    isMiscAdded = true;
        //                    i = 0;
        //                    continue;
        //                }
        //            }

        //            #endregion

        //            long? latestCompanyID = 0;
        //            string sheetname = string.Empty;
        //            foreach (DataRow drSheet in dtSheetRearranged.Rows)
        //            {
        //                sheetname = Convert.ToString(drSheet[ApplicationConstants.TABLE_NAME]);
        //                #region Start importing data from company table
        //                if (sheetname.ToLower().Trim().Contains("company"))
        //                {
        //                    #region Load the DataTable with Sheet Data so we can get the column header
        //                    OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
        //                    OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
        //                    DataTable dt = new DataTable();
        //                    adp.Fill(dt);
        //                    con.Close();
        //                    #endregion

        //                    #region Delete the row if all values are nulll
        //                    int columnCount = dt.Columns.Count;
        //                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                    {
        //                        bool allNull = true;
        //                        for (int j = 0; j < columnCount; j++)
        //                        {
        //                            if (dt.Rows[i][j] != DBNull.Value)
        //                            {
        //                                allNull = false;
        //                            }
        //                        }
        //                        if (allNull)
        //                        {
        //                            dt.Rows[i].Delete();
        //                        }
        //                    }
        //                    dt.AcceptChanges();
        //                    #endregion

        //                    #region Rename datatable column names to actual table names
        //                    for (int i = 0; i < dt.Columns.Count; i++)
        //                    {
        //                        if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("company name"))
        //                            dt.Columns[i].ColumnName = DBConstants.COMP_NAME;
        //                        if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("trade license expiry"))
        //                            dt.Columns[i].ColumnName = DBConstants.COMP_TRADE_LICENSE_EXP;
        //                        if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("immigration card expiry"))
        //                            dt.Columns[i].ColumnName = DBConstants.COMP_IMMIGRATION_EXP;
        //                        if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("import code expiry"))
        //                            dt.Columns[i].ColumnName = DBConstants.COMP_IMPORT_CODE_EXP;
        //                        if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
        //                            dt.Columns[i].ColumnName = DBConstants.COMP_INSURANCE_EXP;
        //                    }
        //                    #endregion

        //                    #region Start dumping data into company database
        //                    try
        //                    {
        //                        // There should only be one record for the company
        //                        DataRow dr = dt.Rows[0];
        //                        if (string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.COMP_NAME])))
        //                        {
        //                            break;
        //                        }
        //                        DAL.Company.Company company = new DAL.Company.Company();
        //                        company.Comp_name = Convert.ToString(dr[DBConstants.COMP_NAME]).Trim();
        //                        company.Comp_address = Convert.ToString(DBNull.Value);
        //                        company.Comp_phone = Convert.ToString(DBNull.Value);
        //                        company.Comp_trade_license_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_TRADE_LICENSE_EXP]));
        //                        company.Comp_immigration_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_IMMIGRATION_EXP]));
        //                        company.Comp_import_code_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_IMPORT_CODE_EXP]));
        //                        company.Comp_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.COMP_INSURANCE_EXP]));
        //                        company.Comp_email = Convert.ToString(DBNull.Value);
        //                        company.Comp_contact_person = Convert.ToString(DBNull.Value);
        //                        company.Comp_cp_phone = Convert.ToString(DBNull.Value);
        //                        company.Notes = Convert.ToString(DBNull.Value);
        //                        company.Is_active = true;
        //                        company.Is_deleted = false;
        //                        company.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                        company.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                        company.Created_date = DateTime.Now;
        //                        company.Modified_date = DateTime.Now;

        //                        bool isCompanyDumpToDatabase = new CompanyService().UPSertCompany(company, ApplicationConstants.Operation_Add);
        //                        if (isCompanyDumpToDatabase)
        //                        {
        //                            // return latest inserted companyID
        //                            latestCompanyID = new CompanyService().GetLastInsertedCompanyID(Convert.ToString(dr[DBConstants.COMP_NAME]));
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        // Some error occurred while inserting this company row
        //                        continue;
        //                    }

        //                    #endregion

        //                }
        //                #endregion
        //                #region Start importing data from partner table
        //                else if (sheetname.ToLower().Trim().Contains("partner"))
        //                {
        //                    if (latestCompanyID.HasValue && latestCompanyID > 0)
        //                    {
        //                        string TableName = ApplicationConstants.TABLE_PARTNER;

        //                        #region Load the DataTable with Sheet Data so we can get the column header
        //                        OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
        //                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
        //                        DataTable dt = new DataTable();
        //                        adp.Fill(dt);
        //                        con.Close();
        //                        #endregion

        //                        #region Delete the row if all values are nulll
        //                        int columnCount = dt.Columns.Count;
        //                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                        {
        //                            bool allNull = true;
        //                            for (int j = 0; j < columnCount; j++)
        //                            {
        //                                if (dt.Rows[i][j] != DBNull.Value)
        //                                {
        //                                    allNull = false;
        //                                }
        //                            }
        //                            if (allNull)
        //                            {
        //                                dt.Rows[i].Delete();
        //                            }
        //                        }
        //                        dt.AcceptChanges();
        //                        #endregion

        //                        #region Rename datatable column names to actual table names
        //                        for (int i = 0; i < dt.Columns.Count; i++)
        //                        {
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("name of partner"))
        //                                dt.Columns[i].ColumnName = DBConstants.PAR_NAME;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.PAR_PASSPORT_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.PAR_VISA_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.PAR_INSURANCE_EXP;
        //                        }
        //                        #endregion

        //                        #region Start dumping data into partner database
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            DataRow dr = dt.Rows[i];
        //                            if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.PAR_NAME])))
        //                            {
        //                                DAL.Partner.Partner par = new DAL.Partner.Partner();
        //                                par.Fk_companyid = latestCompanyID.Value;
        //                                par.Par_name = Convert.ToString(dr[DBConstants.PAR_NAME]);
        //                                par.Par_mobile = Convert.ToString(DBNull.Value);
        //                                par.Par_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_PASSPORT_EXP]));
        //                                par.Par_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_INSURANCE_EXP]));
        //                                par.Par_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.PAR_VISA_EXP]));
        //                                par.Notes = Convert.ToString(DBNull.Value);
        //                                par.Is_active = true;
        //                                par.Is_deleted = false;
        //                                par.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                par.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                par.Created_date = DateTime.Now;
        //                                par.Modified_date = DateTime.Now;
        //                                bool isCompanyDumpToDatabase = new PartnerService().UPSertPartner(par, ApplicationConstants.Operation_Add);
        //                            }
        //                        }
        //                        #endregion
        //                    }
        //                }
        //                #endregion
        //                #region Start importing data from employee table
        //                else if (sheetname.ToLower().Trim().Contains("employee"))
        //                {
        //                    if (latestCompanyID.HasValue && latestCompanyID > 0)
        //                    {
        //                        string TableName = ApplicationConstants.TABLE_EMPLOYEE;

        //                        #region Load the DataTable with Sheet Data so we can get the column header
        //                        OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
        //                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
        //                        DataTable dt = new DataTable();
        //                        adp.Fill(dt);
        //                        con.Close();
        //                        #endregion

        //                        #region Delete the row if all values are nulll
        //                        int columnCount = dt.Columns.Count;
        //                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                        {
        //                            bool allNull = true;
        //                            for (int j = 0; j < columnCount; j++)
        //                            {
        //                                if (dt.Rows[i][j] != DBNull.Value)
        //                                {
        //                                    allNull = false;
        //                                }
        //                            }
        //                            if (allNull)
        //                            {
        //                                dt.Rows[i].Delete();
        //                            }
        //                        }
        //                        dt.AcceptChanges();
        //                        #endregion

        //                        #region Rename datatable column names to actual table names
        //                        for (int i = 0; i < dt.Columns.Count; i++)
        //                        {
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("name of employee"))
        //                                dt.Columns[i].ColumnName = DBConstants.EMP_NAME;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.EMP_PASSPORT_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("labor card expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.EMP_LABOR_CARD_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.EMP_VISA_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.EMP_INSURANCE_EXP;
        //                        }
        //                        #endregion

        //                        #region Start dumping data into employee database
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            DataRow dr = dt.Rows[i];
        //                            if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.EMP_NAME])))
        //                            {
        //                                DAL.Employee.Employee emp = new DAL.Employee.Employee();
        //                                emp.Fk_companyid = latestCompanyID.Value;
        //                                emp.Emp_name = Convert.ToString(dr[DBConstants.EMP_NAME]);
        //                                emp.Emp_mobile = Convert.ToString(DBNull.Value);
        //                                emp.Emp_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_PASSPORT_EXP]));
        //                                emp.Emp_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_INSURANCE_EXP]));
        //                                emp.Emp_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_VISA_EXP]));
        //                                emp.Emp_labor_card_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.EMP_LABOR_CARD_EXP]));
        //                                emp.Notes = Convert.ToString(DBNull.Value);
        //                                emp.Is_active = true;
        //                                emp.Is_deleted = false;
        //                                emp.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                emp.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                emp.Created_date = DateTime.Now;
        //                                emp.Modified_date = DateTime.Now;
        //                                bool isCompanyDumpToDatabase = new EmployeeService().UPSertEmployee(emp, ApplicationConstants.Operation_Add);
        //                            }
        //                        }
        //                        #endregion
        //                    }
        //                }
        //                #endregion

        //                #region Start importing data from Partner family table
        //                else if (sheetname.ToLower().Trim().Contains("family"))
        //                {
        //                    if (latestCompanyID.HasValue && latestCompanyID > 0)
        //                    {
        //                        string TableName = ApplicationConstants.TABLE_PARTNER_FAMILY;

        //                        #region Load the DataTable with Sheet Data so we can get the column header
        //                        OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
        //                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
        //                        DataTable dt = new DataTable();
        //                        adp.Fill(dt);
        //                        con.Close();
        //                        #endregion

        //                        #region Delete the row if all values are nulll
        //                        int columnCount = dt.Columns.Count;
        //                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                        {
        //                            bool allNull = true;
        //                            for (int j = 0; j < columnCount; j++)
        //                            {
        //                                if (dt.Rows[i][j] != DBNull.Value)
        //                                {
        //                                    allNull = false;
        //                                }
        //                            }
        //                            if (allNull)
        //                            {
        //                                dt.Rows[i].Delete();
        //                            }
        //                        }
        //                        dt.AcceptChanges();
        //                        #endregion

        //                        #region Rename datatable column names to actual table names
        //                        for (int i = 0; i < dt.Columns.Count; i++)
        //                        {
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("name"))
        //                                dt.Columns[i].ColumnName = DBConstants.FML_NAME;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("passport expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.FML_PASSPORT_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("visa expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.FML_VISA_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("insurance expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.FML_INSURANCE_EXP;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("sponsor"))
        //                                dt.Columns[i].ColumnName = "Sponsor";

        //                        }
        //                        #endregion

        //                        #region Start dumping data into employee database
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            DataRow dr = dt.Rows[i];
        //                            if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.FML_NAME])) && !string.IsNullOrEmpty(Convert.ToString(dr["Sponsor"])))
        //                            {

        //                                long? partnerId = new PartnerService().GetPartnerIDFromPartnerName( latestCompanyID.Value ,Convert.ToString(dr["Sponsor"]));

        //                                if (partnerId.HasValue && partnerId > 0)
        //                                {
        //                                    DAL.Partner.PartnerFamily fml = new DAL.Partner.PartnerFamily();
        //                                    fml.Fk_partnerid = partnerId.Value;
        //                                    fml.Fml_name = Convert.ToString(dr[DBConstants.FML_NAME]);
        //                                    fml.Fml_relation = Convert.ToString(DBNull.Value);
        //                                    fml.Fml_passport_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_PASSPORT_EXP]));
        //                                    fml.Fml_insurance_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_INSURANCE_EXP]));
        //                                    fml.Fml_visa_exp = SanitizeDateFields(Convert.ToString(dr[DBConstants.FML_VISA_EXP]));
        //                                    fml.Notes = Convert.ToString(DBNull.Value);
        //                                    fml.Is_active = true;
        //                                    fml.Is_deleted = false;
        //                                    fml.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                    fml.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                    fml.Created_date = DateTime.Now;
        //                                    fml.Modified_date = DateTime.Now;
        //                                    bool isCompanyDumpToDatabase = new PartnerService().UPSertPartnerFamily(fml, ApplicationConstants.Operation_Add);


        //                                }
        //                            }
        //                        }
        //                        #endregion
        //                    }
        //                }
        //                #endregion

        //                #region Start importing data from misc table
        //                else if (sheetname.ToLower().Trim().Contains("misc"))
        //                {
        //                    if (latestCompanyID.HasValue && latestCompanyID > 0)
        //                    {
        //                        string TableName = ApplicationConstants.TABLE_PARTNER_MISC;

        //                        #region Load the DataTable with Sheet Data so we can get the column header
        //                        OleDbCommand oconn = new OleDbCommand("select * from [" + sheetname + "]", con);
        //                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
        //                        DataTable dt = new DataTable();
        //                        adp.Fill(dt);
        //                        con.Close();
        //                        #endregion

        //                        #region Delete the row if all values are nulll
        //                        int columnCount = dt.Columns.Count;
        //                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        //                        {
        //                            bool allNull = true;
        //                            for (int j = 0; j < columnCount; j++)
        //                            {
        //                                if (dt.Rows[i][j] != DBNull.Value)
        //                                {
        //                                    allNull = false;
        //                                }
        //                            }
        //                            if (allNull)
        //                            {
        //                                dt.Rows[i].Delete();
        //                            }
        //                        }
        //                        dt.AcceptChanges();
        //                        #endregion

        //                        #region Rename datatable column names to actual table names
        //                        for (int i = 0; i < dt.Columns.Count; i++)
        //                        {
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("name of misc"))
        //                                dt.Columns[i].ColumnName = DBConstants.MISC_NAME;
        //                            if (dt.Columns[i].ColumnName.ToLower().Trim().Equals("misc expiry"))
        //                                dt.Columns[i].ColumnName = DBConstants.MISC_EXP_DATE;
        //                        }
        //                        #endregion

        //                        #region Start dumping data into misc database
        //                        for (int i = 0; i < dt.Rows.Count; i++)
        //                        {
        //                            DataRow dr = dt.Rows[i];
        //                            if (!string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.MISC_NAME])) && !string.IsNullOrEmpty(Convert.ToString(dr[DBConstants.MISC_EXP_DATE])))
        //                            {
        //                                DAL.Misc.PartnerMisc emp = new DAL.Misc.PartnerMisc();
        //                                emp.Fk_companyid = latestCompanyID.Value;
        //                                emp.Misc_name = Convert.ToString(dr[DBConstants.MISC_NAME]);
        //                                emp.Misc_exp_date = SanitizeDateFields(Convert.ToString(dr[DBConstants.MISC_EXP_DATE]));
        //                                emp.Notes = Convert.ToString(DBNull.Value);
        //                                emp.Is_active = true;
        //                                emp.Is_deleted = false;
        //                                emp.Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                emp.Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]);
        //                                emp.Created_date = DateTime.Now;
        //                                emp.Modified_date = DateTime.Now;
        //                                bool isCompanyDumpToDatabase = new MiscService().UPSertPartnerMisc(emp, ApplicationConstants.Operation_Add);
        //                            }
        //                        }
        //                        #endregion
        //                    }
        //                }
        //                #endregion

        //            }


        //        }

        //        /*OleDbCommand cmd = new OleDbCommand("select * from Company Details", con);                    
        //        con.Open();
        //        // Create DbDataReader to Data Worksheet  
        //        DbDataReader dr = cmd.ExecuteReader();
        //        // SQL Server Connection String  
        //        string CS = connectionString;
        //        // Bulk Copy to SQL Server   
        //        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
        //        bulkInsert.DestinationTableName = "Employee";
        //        bulkInsert.WriteToServer(dr);*/
        //    }

        //}

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
