using CMSApplication.BAL.Company;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = Request.QueryString["id"];
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
            }
        }
        private void BindCompanyInformation(DataTable CompanyDataTable)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                Session.Add(ApplicationConstants.COMPANYID, Request.QueryString["id"]);

            DataRow dr = CompanyDataTable.Rows[0];
            try
            {
                txtCompanyName.Text = Convert.ToString(dr[ApplicationConstants.COMP_NAME]);
                txtCompanyAddress.Text = Convert.ToString(dr[ApplicationConstants.COMP_ADDRESS]);
                txtCompanyPhone.Text = Convert.ToString(dr[ApplicationConstants.COMP_PHONE]);
                txtCompanyTradeLicenceExpDate.Text = !string.IsNullOrEmpty(Convert.ToString(dr[ApplicationConstants.COMP_TRADE_LICENSE_EXP])) ? DateTime.Parse(dr[ApplicationConstants.COMP_TRADE_LICENSE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyImmigraitonExpDate.Text = !string.IsNullOrEmpty(Convert.ToString(dr[ApplicationConstants.COMP_IMMIGRATION_EXP])) ? DateTime.Parse(dr[ApplicationConstants.COMP_IMMIGRATION_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyImportCodeExpDate.Text = !string.IsNullOrEmpty(Convert.ToString(dr[ApplicationConstants.COMP_IMPORT_CODE_EXP])) ? DateTime.Parse(dr[ApplicationConstants.COMP_IMPORT_CODE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyInsuranceExpDate.Text = !string.IsNullOrEmpty(Convert.ToString(dr[ApplicationConstants.COMP_INSURANCE_EXP])) ? DateTime.Parse(dr[ApplicationConstants.COMP_INSURANCE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtCompanyNotes.Text = Convert.ToString(dr[ApplicationConstants.NOTES]);
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
                        this.SuccessFailureMessageSpan.InnerText = "Some error occurred while adding company information to database";

                    }
                    else // Let we show div with success message
                    {
                        this.SuccessFailureMessage.Attributes["class"] = "alert alert-success alert-dismissible fade show";
                        this.SuccessFailureMessageSpan.InnerText = "Company information added  to database successfully";
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
                    Comp_trade_license_exp = !string.IsNullOrEmpty(txtCompanyTradeLicenceExpDate.Text) ? DateTime.ParseExact(txtCompanyTradeLicenceExpDate.Text,"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
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
            else if (ModeOfOperation == ApplicationConstants.Operation_Add)
            {
                return new DAL.Company.Company
                {
                    Comp_name = txtCompanyName.Text,
                    Comp_address = txtCompanyAddress.Text,
                    Comp_phone = txtCompanyPhone.Text,
                    //Comp_trade_license_exp = DateTime.ParseExact(txtCompanyTradeLicenceExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    //Comp_immigration_exp = DateTime.ParseExact(txtCompanyImmigraitonExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    //Comp_import_code_exp = DateTime.ParseExact(txtCompanyImportCodeExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    //Comp_insurance_exp = DateTime.ParseExact(txtCompanyInsuranceExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
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
                    Fk_created_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
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
    }
}