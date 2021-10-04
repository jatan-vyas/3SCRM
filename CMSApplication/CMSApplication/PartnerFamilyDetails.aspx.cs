using CMSApplication.BAL.Partner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class PartnerFamilyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = Request.QueryString["id"];
            string _partnerFamilyID = Request.QueryString["parfamid"];
            string _operation = Request.QueryString["op"];

            if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Add)
                partnerFamilyPageHeading.InnerText = "Add Partner Family";
            else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                partnerFamilyPageHeading.InnerText = "Update Partner Family";
            else
                partnerFamilyPageHeading.InnerText = "Partner Family";

            DataTable dataTable = new DataTable();

            if (!IsPostBack)
            {
                BindDropDownList(_companyID);
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {
                    if (!string.IsNullOrEmpty(_partnerFamilyID))
                        dataTable = new PartnerService().GetPartnerFamilyDetail(null, _partnerFamilyID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindPartnerFamilyInformation(dataTable);
                    }
                }
            }
        }
        private void BindDropDownList(String CompanyID)
        {
            try
            {
                DataTable partnerDatatable = new PartnerService().GetPartnerDetail(CompanyID, null);
                FillDropDownList(partnerDatatable);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void FillDropDownList(DataTable partnerDataTable)
        {
            if (partnerDataTable != null && partnerDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < partnerDataTable.Rows.Count; i++)
                {
                    DataRow dr = partnerDataTable.Rows[i];
                    drpPartnerList.Items.Add(new ListItem(Convert.ToString(dr[ApplicationConstants.PAR_NAME]), Convert.ToString(dr[ApplicationConstants.PK_PARTNERID])));
                }
            }
            else
            {
                drpPartnerList.Items.Add(new ListItem("-- No partner added for this company --", Convert.ToString(0)));
            }
        }
        private void BindPartnerFamilyInformation(DataTable PartnerFamilyDataTable)
        {
            DataRow dr = PartnerFamilyDataTable.Rows[0];
            try
            {
                txtPartnerFamilyName.Text = Convert.ToString(dr[ApplicationConstants.FML_NAME]);
                txtPartnerFamilyRelation.Text = Convert.ToString(dr[ApplicationConstants.FML_RELATION]);
                txtPartnerFamilyPassportExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.FML_PASSPORT_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.FML_PASSPORT_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtPartnerFamilyVisaExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.FML_VISA_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.FML_VISA_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtPartnerFamilyInsuranceExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.FML_INSURANCE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.FML_INSURANCE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtParterFamilyNotes.Text = dr[ApplicationConstants.NOTES].ToString();
                chkPartnerFamilyActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
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
        protected void btnPartnerFamilySave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.Partner.PartnerFamily partnerFamily = FillPartnerFamilyData(_operation);
                if (partnerFamily != null)
                {
                    bool res = new PartnerService().UPSertPartnerFamily(partnerFamily, _operation);
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
        // Fill PartnerFamilyDetails to fill partner object to store data in database
        private DAL.Partner.PartnerFamily FillPartnerFamilyData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.Partner.PartnerFamily
                {
                    Pk_familyid = !string.IsNullOrEmpty(Request.QueryString["parfamid"]) ? Convert.ToInt64(Request.QueryString["parfamid"]) : 0,
                    Fk_partnerid = Convert.ToInt32(drpPartnerList.SelectedValue.Trim()),
                    Fml_name = txtPartnerFamilyName.Text,
                    Fml_relation = txtPartnerFamilyRelation.Text,
                    Fml_passport_exp = !string.IsNullOrEmpty(txtPartnerFamilyPassportExpDate.Text) ? DateTime.ParseExact(txtPartnerFamilyPassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Fml_insurance_exp = !string.IsNullOrEmpty(txtPartnerFamilyInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtPartnerFamilyInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Fml_visa_exp = !string.IsNullOrEmpty(txtPartnerFamilyVisaExpiryDate.Text) ? DateTime.ParseExact(txtPartnerFamilyVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtParterFamilyNotes.Text,
                    Is_active = chkPartnerFamilyActive.Checked,
                    Is_deleted = false,
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return new DAL.Partner.PartnerFamily
                {
                    Pk_familyid = !string.IsNullOrEmpty(Request.QueryString["parfamid"]) ? Convert.ToInt64(Request.QueryString["parfamid"]) : 0,
                    Fk_partnerid = Convert.ToInt32(drpPartnerList.SelectedValue.Trim()),
                    Fml_name = txtPartnerFamilyName.Text,
                    Fml_relation = txtPartnerFamilyRelation.Text,
                    Fml_passport_exp = !string.IsNullOrEmpty(txtPartnerFamilyPassportExpDate.Text) ? DateTime.ParseExact(txtPartnerFamilyPassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Fml_insurance_exp = !string.IsNullOrEmpty(txtPartnerFamilyInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtPartnerFamilyInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Fml_visa_exp = !string.IsNullOrEmpty(txtPartnerFamilyVisaExpiryDate.Text) ? DateTime.ParseExact(txtPartnerFamilyVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtParterFamilyNotes.Text,
                    Is_active = chkPartnerFamilyActive.Checked,
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