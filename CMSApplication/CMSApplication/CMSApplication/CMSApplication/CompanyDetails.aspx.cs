using CMSApplication.BAL.Company;
using CMSApplication.BAL.Employee;
using CMSApplication.BAL.Misc;
using CMSApplication.BAL.Partner;
using CMSApplication.DAL.Employee;
using CMSApplication.DAL.Misc;
using CMSApplication.DAL.Partner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class CompanyDetails : System.Web.UI.Page
    {
        public string companyId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = companyId = Request.QueryString["id"];
            string _operation = Request.QueryString["op"];
            DataTable dataTable = new DataTable();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {
                    if (!string.IsNullOrEmpty(_companyID))
                        dataTable = new CompanyService().GetCompanyDetail(_companyID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindCompanyInformation(dataTable);
                    }
                }

                #region Binding Partner Datatable
                DataTable partnerDataTable = new DataTable();
                partnerDataTable.Columns.Add("Par_name");
                partnerDataTable.Columns.Add("Par_mobile");
                partnerDataTable.Columns.Add("Par_passport_exp");
                partnerDataTable.Columns.Add("Par_insurance_exp");
                partnerDataTable.Columns.Add("Par_visa_exp");
                partnerDataTable.Columns.Add("Is_active");
                partnerDataTable.Rows.Add();
                gvPartnerDetails.DataSource = partnerDataTable;
                gvPartnerDetails.DataBind();

                //Required for jQuery DataTables to work.
                gvPartnerDetails.UseAccessibleHeader = true;
                gvPartnerDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                #endregion

                #region Binding Employee Datatable
                DataTable employeeDataTable = new DataTable();
                employeeDataTable.Columns.Add("Emp_name");
                employeeDataTable.Columns.Add("Emp_mobile");
                employeeDataTable.Columns.Add("Emp_passport_exp");
                employeeDataTable.Columns.Add("Emp_insurance_exp");
                employeeDataTable.Columns.Add("Emp_visa_exp");
                employeeDataTable.Columns.Add("Emp_labor_card_exp");
                employeeDataTable.Columns.Add("Is_active");
                employeeDataTable.Rows.Add();
                gvEmployeeDetails.DataSource = employeeDataTable;
                gvEmployeeDetails.DataBind();

                //Required for jQuery DataTables to work.
                gvEmployeeDetails.UseAccessibleHeader = true;
                gvEmployeeDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                #endregion

                #region Binding Partner Family Datatable
                DataTable partnerFamilyDataTable = new DataTable();
                partnerFamilyDataTable.Columns.Add("Fml_name");
                partnerFamilyDataTable.Columns.Add("Par_name");
                partnerFamilyDataTable.Columns.Add("Par_mobile");
                partnerFamilyDataTable.Columns.Add("Fml_relation");
                partnerFamilyDataTable.Columns.Add("Fml_passport_exp");
                partnerFamilyDataTable.Columns.Add("Fml_insurance_exp");
                partnerFamilyDataTable.Columns.Add("Fml_visa_exp");
                partnerFamilyDataTable.Columns.Add("Is_active");
                partnerFamilyDataTable.Rows.Add();
                gvPartnerFamilyDetails.DataSource = partnerFamilyDataTable;
                gvPartnerFamilyDetails.DataBind();

                //Required for jQuery DataTables to work.
                gvPartnerFamilyDetails.UseAccessibleHeader = true;
                gvPartnerFamilyDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                #endregion

                #region Binding Misc Datatable
                DataTable miscDataTable = new DataTable();
                miscDataTable.Columns.Add("Misc_name");
                miscDataTable.Columns.Add("Misc_exp_date");
                miscDataTable.Columns.Add("Is_active");
                miscDataTable.Rows.Add();
                gvMiscDetails.DataSource = miscDataTable;
                gvMiscDetails.DataBind();

                //Required for jQuery DataTables to work.
                gvMiscDetails.UseAccessibleHeader = true;
                gvMiscDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                #endregion
            }
        }

        private void BindCompanyInformation(DataTable CompanyDataTable)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                Session.Add(ApplicationConstants.COMPANYID, Request.QueryString["id"]);

            DataRow dr = CompanyDataTable.Rows[0];
            try
            {
                lblCompName.Text = dr[ApplicationConstants.COMP_NAME].ToString();

                txtCompanyName.Text = dr[ApplicationConstants.COMP_NAME].ToString();
                txtCompanyAddress.Text = dr[ApplicationConstants.COMP_ADDRESS].ToString();
                txtCompanyPhone.Text = dr[ApplicationConstants.COMP_PHONE].ToString();
                txtCompanyTradeLicenceExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.COMP_TRADE_LICENSE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.COMP_TRADE_LICENSE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyImmigraitonExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.COMP_IMMIGRATION_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.COMP_IMMIGRATION_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyImportCodeExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.COMP_IMPORT_CODE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.COMP_IMPORT_CODE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyInsuranceExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.COMP_INSURANCE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.COMP_INSURANCE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyNotes.Text = dr[ApplicationConstants.NOTES].ToString();
                txtCompanyEmail.Text = Convert.ToString(dr[ApplicationConstants.COMP_EMAIL]);
                txtCompanyContactPerson.Text = Convert.ToString(dr[ApplicationConstants.COMP_CONTACT_PERSON]);
                txtContactPersonPhone.Text = Convert.ToString(dr[ApplicationConstants.COMP_CP_PHONE]);
                chkCompanyActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company.aspx");
        }
        protected void btnCompanySave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.Company.Company company = FillComapnyData(_operation);
                if (company != null)
                {
                    bool res = new CompanyService().UPSertCompany(company, _operation);
                    if (!res) //res == false means some error occurred while inserting data into database
                    {
                        this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                        this.SuccessFailureMessageSpan.InnerText = "Some error occurred while adding information to database";

                    }
                    else // Let we show div with success message
                    {
                        this.SuccessFailureMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                        this.SuccessFailureMessageSpan.InnerText = "Information added  to database successfully";
                    }
                }
                else
                {
                    //Company is null which means entered data has some issue
                    this.SuccessFailureMessageSpan.InnerText = "Some error occurred while fetching entered data";
                    this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
                } 
            }
            else
            {
                //Page object is invalid which means some of the validations set on page are not working properly
                this.SuccessFailureMessageSpan.InnerText = "Please check entered values..!!";
                this.SuccessFailureMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show";
            }
        }
        private DAL.Company.Company FillComapnyData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.Company.Company
                {
                    Pk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    Comp_name = txtCompanyName.Text,
                    Comp_address = txtCompanyAddress.Text,
                    Comp_phone = txtCompanyPhone.Text,
                    Comp_trade_license_exp = !string.IsNullOrEmpty(txtCompanyTradeLicenceExpDate.Text) ? DateTime.ParseExact(txtCompanyTradeLicenceExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Comp_immigration_exp = !string.IsNullOrEmpty(txtCompanyImmigraitonExpDate.Text) ? DateTime.ParseExact(txtCompanyImmigraitonExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Comp_import_code_exp = !string.IsNullOrEmpty(txtCompanyImportCodeExpDate.Text) ? DateTime.ParseExact(txtCompanyImportCodeExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Comp_insurance_exp = !string.IsNullOrEmpty(txtCompanyInsuranceExpDate.Text) ? DateTime.ParseExact(txtCompanyInsuranceExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Comp_email = txtCompanyEmail.Text,
                    Comp_contact_person = txtCompanyContactPerson.Text,
                    Comp_cp_phone = txtContactPersonPhone.Text,
                    Notes = txtCompanyNotes.Text,
                    Is_active = chkCompanyActive.Checked,
                    Is_deleted = false,
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return null;
            }
        }

        #region - PARTNER RELATED BLOCK
        // Fetch data to bind grid
        [WebMethod]
        public static List<Partner> GetPartnerDetails(string companyID)
        {
            List<Partner> partners = new List<Partner>();
            string _compID = string.IsNullOrEmpty(companyID) ? null : companyID;
            DataTable dataTable = new PartnerService().GetPartnerDetail(_compID, null);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dr = dataTable.Rows[i];
                    partners.Add(new Partner
                    {
                        Pk_partnerid = (long)dr["PK_PARTNERID"],
                        Par_name = Convert.ToString(dr["PAR_NAME"]),
                        Par_mobile = Convert.ToString(dr["PAR_MOBILE"]),
                        Par_passport_exp = !string.IsNullOrEmpty(dr["PAR_PASSPORT_EXP"].ToString()) ? Convert.ToDateTime(dr["PAR_PASSPORT_EXP"]) : (DateTime?)null,
                        Par_insurance_exp = !string.IsNullOrEmpty(dr["PAR_INSURANCE_EXP"].ToString()) ? Convert.ToDateTime(dr["PAR_INSURANCE_EXP"]) : (DateTime?)null,
                        Par_visa_exp = !string.IsNullOrEmpty(dr["PAR_VISA_EXP"].ToString()) ? Convert.ToDateTime(dr["PAR_VISA_EXP"]) : (DateTime?)null,
                        Notes = Convert.ToString(dr["NOTES"]),
                        Is_active = Convert.ToBoolean(dr["IS_ACTIVE"])
                    });
                }
            }
            return partners;
        }
        protected void btnAddPartner_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartnerDetails.aspx?id=" + Request.QueryString["id"] + "&op=" + ApplicationConstants.Operation_Add);
        }

        #endregion

        #region EMPLOYEE RELATED OPERATIONS
        // Fetch data to bind grid
        [WebMethod]
        public static List<Employee> GetEmployeeDetails(string companyID)
        {
            List<Employee> employees = new List<Employee>();
            string _compID = string.IsNullOrEmpty(companyID) ? null : companyID;
            DataTable dataTable = new EmployeeService().GetEmployeeDetails(_compID, null);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dr = dataTable.Rows[i];
                    employees.Add(new Employee
                    {
                        Pk_employeeid = (long)dr["PK_EMPLOYEEID"],
                        Emp_name = Convert.ToString(dr["EMP_NAME"]),
                        Emp_mobile = Convert.ToString(dr["EMP_MOBILE"]),
                        Emp_passport_exp = !string.IsNullOrEmpty(dr["EMP_PASSPORT_EXP"].ToString()) ? Convert.ToDateTime(dr["EMP_PASSPORT_EXP"]) : (DateTime?)null,
                        Emp_insurance_exp = !string.IsNullOrEmpty(dr["EMP_INSURANCE_EXP"].ToString()) ? Convert.ToDateTime(dr["EMP_INSURANCE_EXP"]) : (DateTime?)null,
                        Emp_visa_exp = !string.IsNullOrEmpty(dr["EMP_VISA_EXP"].ToString()) ? Convert.ToDateTime(dr["EMP_VISA_EXP"]) : (DateTime?)null,
                        Emp_labor_card_exp = !string.IsNullOrEmpty(dr["EMP_LABOR_CARD_EXP"].ToString()) ? Convert.ToDateTime(dr["EMP_LABOR_CARD_EXP"]) : (DateTime?)null,
                        Notes = Convert.ToString(dr["NOTES"]),
                        Is_active = Convert.ToBoolean(dr["IS_ACTIVE"])
                    });
                }
            }
            return employees;
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeDetails.aspx?id=" + Request.QueryString["id"] + "&op=" + ApplicationConstants.Operation_Add);
        }
        #endregion

        #region PARTNER FAMILY RELATED OPERATIONS
        // Fetch data to bind grid
        [WebMethod]
        public static List<PartnerFamily> GetPartnerFamilyDetails(string companyID)
        {
            List<PartnerFamily> partnerFamily = new List<PartnerFamily>();
            string _compID = string.IsNullOrEmpty(companyID) ? null : companyID;
            DataTable dataTable = new PartnerService().GetPartnerFamilyDetail(_compID, null);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dr = dataTable.Rows[i];
                    partnerFamily.Add(new PartnerFamily
                    {
                        Pk_familyid = (long)dr["PK_FAMILYID"],
                        Fml_name = Convert.ToString(dr["FML_NAME"]),
                        Par_name = Convert.ToString(dr["PAR_NAME"]),
                        Par_mobile = Convert.ToString(dr["PAR_MOBILE"]),
                        Fml_relation = Convert.ToString(dr["FML_RELATION"]),
                        Fml_passport_exp = !string.IsNullOrEmpty(dr["FML_PASSPORT_EXP"].ToString()) ? Convert.ToDateTime(dr["FML_PASSPORT_EXP"]) : (DateTime?)null,
                        Fml_insurance_exp = !string.IsNullOrEmpty(dr["FML_INSURANCE_EXP"].ToString()) ? Convert.ToDateTime(dr["FML_INSURANCE_EXP"]) : (DateTime?)null,
                        Fml_visa_exp = !string.IsNullOrEmpty(dr["FML_VISA_EXP"].ToString()) ? Convert.ToDateTime(dr["FML_VISA_EXP"]) : (DateTime?)null,
                        Notes = Convert.ToString(dr["NOTES"]),
                        Is_active = Convert.ToBoolean(dr["IS_ACTIVE"])
                    });
                }
            }
            return partnerFamily;
        }

        protected void btnAddPartnerFamily_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartnerFamilyDetails.aspx?id=" + Request.QueryString["id"] + "&op="+ApplicationConstants.Operation_Add);
        }
        #endregion

        #region PARTNER MISC RELATED OPERATIONS
        // Fetch data to bind grid
        [WebMethod]
        public static List<PartnerMisc> GetPartnerMiscDetails(string companyID)
        {
            List<PartnerMisc> partnerMisc = new List<PartnerMisc>();
            string _compID = string.IsNullOrEmpty(companyID) ? null : companyID;
            DataTable dataTable = new MiscService().GetPartnerMiscDetail(_compID, null);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dr = dataTable.Rows[i];
                    partnerMisc.Add(new PartnerMisc
                    {
                        Pk_miscid = (long)dr["PK_MISCID"],
                        Misc_name = Convert.ToString(dr["MISC_NAME"]),
                        Misc_exp_date = !string.IsNullOrEmpty(dr["MISC_EXP_DATE"].ToString()) ? Convert.ToDateTime(dr["MISC_EXP_DATE"]) : (DateTime?)null,
                        Notes = Convert.ToString(dr["NOTES"]),
                        Is_active = Convert.ToBoolean(dr["IS_ACTIVE"])
                    });
                }
            }
            return partnerMisc;
        }
        protected void btnAddPartnerMisc_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartnerMiscDetails.aspx?id=" + Request.QueryString["id"] + "&op=" + ApplicationConstants.Operation_Add);
        }
        #endregion

        #region Delete Records
        protected void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            string employeeID = hdnEmployeeID.Value;
            if (string.IsNullOrEmpty(employeeID))
            {
                // show error message.
            }
            bool res = new EmployeeService().DeleteEmployee(employeeID, Convert.ToInt32(Session[ApplicationConstants.USERID]));
        }
        protected void btnDeletePartner_Click(object sender, EventArgs e)
        {
            string partnerID = hdnPartnerID.Value;
            if (string.IsNullOrEmpty(partnerID))
            {
                // show error message.
            }
            bool res = new PartnerService().DeletePartner(partnerID, Convert.ToInt32(Session[ApplicationConstants.USERID]));            
        }
        protected void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            string partnerFamilyID = hdnPartnerFamilyID.Value;
            if (string.IsNullOrEmpty(partnerFamilyID))
            {
                // show error message.
            }
            bool res = new PartnerService().DeletePartnerFamily(partnerFamilyID, Convert.ToInt32(Session[ApplicationConstants.USERID]));
        }
        protected void btnDeleteMisc_Click(object sender, EventArgs e)
        {
            string miscID = hdnMiscID.Value;
            if (string.IsNullOrEmpty(miscID))
            {
                // show error message.
            }
            bool res = new MiscService().DeleteMisc(miscID, Convert.ToInt32(Session[ApplicationConstants.USERID]));

        }
        #endregion
    }
}