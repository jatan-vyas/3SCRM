using CMSApplication.BAL.Employee;
using System;
using System.Data;
using System.Web.UI;

namespace CMSApplication
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = Request.QueryString["id"];
            string _employeeID = Request.QueryString["empid"];
            string _operation = Request.QueryString["op"];
            DataTable dataTable = new DataTable();

            if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Add)
                employeePageHeading.InnerText = "Add Employee";
            else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                employeePageHeading.InnerText = "Update Employee";
            else
                employeePageHeading.InnerText = "Employee";

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {                 
                    if (!string.IsNullOrEmpty(_employeeID))
                        dataTable = new EmployeeService().GetEmployeeDetails(null, _employeeID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindEmployeeInformation(dataTable);
                    }
                }
            }
        }
        private void BindEmployeeInformation(DataTable EmployeeDataTable)
        {
            DataRow dr = EmployeeDataTable.Rows[0];
            try
            {
                txtEmployeeName.Text = Convert.ToString(dr[ApplicationConstants.EMP_NAME]);
                txtEmployeePhone.Text = Convert.ToString(dr[ApplicationConstants.EMP_MOBILE]);
                txtEmployeePassportExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.EMP_PASSPORT_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.EMP_PASSPORT_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtEmployeeVisaExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.EMP_VISA_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.EMP_VISA_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtEmployeeInsuranceExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.EMP_INSURANCE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.EMP_INSURANCE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtEmployeeLaborCardExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.EMP_LABOR_CARD_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.EMP_LABOR_CARD_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtEmployeeNotes.Text = Convert.ToString(dr[ApplicationConstants.NOTES]);
                chkemployeeActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyDetails.aspx?id=" + Request.QueryString["id"] + "&op=edit");
        }
        protected void btnEmployeeSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.Employee.Employee employee= FillEmployeeData(_operation);
                if (employee != null)
                {
                    bool res = new EmployeeService().UPSertEmployee(employee, _operation);
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
        // Fill PartnerDetails to fill partner object to store data in database
        private DAL.Employee.Employee FillEmployeeData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.Employee.Employee
                {
                    Pk_employeeid = !string.IsNullOrEmpty(Request.QueryString["empid"]) ? Convert.ToInt64(Request.QueryString["empid"]) : 0,
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    Emp_name = txtEmployeeName.Text,
                    Emp_mobile = txtEmployeePhone.Text,
                    Emp_passport_exp = !string.IsNullOrEmpty(txtEmployeePassportExpDate.Text) ? DateTime.ParseExact(txtEmployeePassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_insurance_exp = !string.IsNullOrEmpty(txtEmployeeInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtEmployeeInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_visa_exp = !string.IsNullOrEmpty(txtEmployeeVisaExpiryDate.Text) ? DateTime.ParseExact(txtEmployeeVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_labor_card_exp = !string.IsNullOrEmpty(txtEmployeeLaborCardExpDate.Text) ? DateTime.ParseExact(txtEmployeeLaborCardExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtEmployeeNotes.Text,
                    Is_active = chkemployeeActive.Checked,
                    Is_deleted = false,
                    Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return new DAL.Employee.Employee
                {
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    Emp_name = txtEmployeeName.Text,
                    Emp_mobile = txtEmployeePhone.Text,
                    Emp_passport_exp = !string.IsNullOrEmpty(txtEmployeePassportExpDate.Text) ? DateTime.ParseExact(txtEmployeePassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_insurance_exp = !string.IsNullOrEmpty(txtEmployeeInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtEmployeeInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_visa_exp = !string.IsNullOrEmpty(txtEmployeeVisaExpiryDate.Text) ? DateTime.ParseExact(txtEmployeeVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Emp_labor_card_exp = !string.IsNullOrEmpty(txtEmployeeLaborCardExpDate.Text) ? DateTime.ParseExact(txtEmployeeLaborCardExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtEmployeeNotes.Text,
                    Is_active = chkemployeeActive.Checked,
                    Is_deleted = false,
                    Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
        }
    }
}