using CMSApplication.BAL.Partner;
using System;
using System.Data;
using System.Web.UI;

namespace CMSApplication
{
    public partial class PartnerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = Request.QueryString["id"];
            string _partnerID = Request.QueryString["parid"];
            string _operation = Request.QueryString["op"];

            if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Add)
                partnerpageHeading.InnerText = "Add Partner";
            else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                partnerpageHeading.InnerText = "Update Partner";
            else
                partnerpageHeading.InnerText = "Partner";

            DataTable dataTable = new DataTable();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {
                    if (!string.IsNullOrEmpty(_partnerID))
                        dataTable = new PartnerService().GetPartnerDetail(null, _partnerID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindPartnerInformation(dataTable);
                    }
                }
            }
        }

        private void BindPartnerInformation(DataTable PartnerDataTable)
        {
            DataRow dr = PartnerDataTable.Rows[0];
            try
            {
                txtPartnerName.Text = Convert.ToString(dr[ApplicationConstants.PAR_NAME]);
                txtPartnerPhone.Text = Convert.ToString(dr[ApplicationConstants.PAR_MOBILE]);
                txtPartnerPassportExpDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.PAR_PASSPORT_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.PAR_PASSPORT_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtPartnerVisaExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.PAR_VISA_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.PAR_VISA_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtPartnerInsuranceExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.PAR_INSURANCE_EXP].ToString()) ? DateTime.Parse(dr[ApplicationConstants.PAR_INSURANCE_EXP].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtParterNotes.Text = dr[ApplicationConstants.NOTES].ToString();
                chkPartnerActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
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
        protected void btnPartnerSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.Partner.Partner partner = FillPartnerData(_operation);
                if (partner != null)
                {
                    bool res = new PartnerService().UPSertPartner(partner, _operation);
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
        private DAL.Partner.Partner FillPartnerData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.Partner.Partner
                {
                    Pk_partnerid = !string.IsNullOrEmpty(Request.QueryString["parid"]) ? Convert.ToInt64(Request.QueryString["parid"]) : 0,
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    Par_name = txtPartnerName.Text,
                    Par_mobile = txtPartnerPhone.Text,
                    Par_passport_exp = !string.IsNullOrEmpty(txtPartnerPassportExpDate.Text) ? DateTime.ParseExact(txtPartnerPassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Par_insurance_exp = !string.IsNullOrEmpty(txtPartnerInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtPartnerInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Par_visa_exp = !string.IsNullOrEmpty(txtPartnerVisaExpiryDate.Text) ? DateTime.ParseExact(txtPartnerVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtParterNotes.Text,
                    Is_active = chkPartnerActive.Checked,
                    Is_deleted = false,                    
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return new DAL.Partner.Partner
                {
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    Par_name = txtPartnerName.Text,
                    Par_mobile = txtPartnerPhone.Text,
                    Par_passport_exp = !string.IsNullOrEmpty(txtPartnerPassportExpDate.Text) ? DateTime.ParseExact(txtPartnerPassportExpDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Par_insurance_exp = !string.IsNullOrEmpty(txtPartnerInsuranceExpiryDate.Text) ? DateTime.ParseExact(txtPartnerInsuranceExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Par_visa_exp = !string.IsNullOrEmpty(txtPartnerVisaExpiryDate.Text) ? DateTime.ParseExact(txtPartnerVisaExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtParterNotes.Text,
                    Is_active = chkPartnerActive.Checked,
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