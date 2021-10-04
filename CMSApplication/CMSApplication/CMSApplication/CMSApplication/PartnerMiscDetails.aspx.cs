using CMSApplication.BAL.Misc;
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
    public partial class PartnerMiscDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _companyID = Request.QueryString["id"];
            string _miscID = Request.QueryString["miscid"];
            string _operation = Request.QueryString["op"];

            if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Add)
                miscPageHeading.InnerText = "Add Misc";
            else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                miscPageHeading.InnerText = "Update Misc";
            else
                miscPageHeading.InnerText = "Misc";

            DataTable dataTable = new DataTable();
            if (!IsPostBack)
            {
                //BindDropDownList(_companyID);
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {
                    if (!string.IsNullOrEmpty(_miscID))
                        dataTable = new MiscService().GetPartnerMiscDetail(null, _miscID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindMiscInformation(dataTable);
                    }
                }
            }
        }
        private void BindDropDownList(String CompanyID)
        {
            try
            {
                //DataTable partnerDatatable = new PartnerService().GetPartnerDetail(CompanyID, null);
                //FillDropDownList(partnerDatatable);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void FillDropDownList(DataTable partnerDataTable)
        {
            //if (partnerDataTable != null && partnerDataTable.Rows.Count > 0)
            //{
            //    for (int i = 0; i < partnerDataTable.Rows.Count; i++)
            //    {
            //        DataRow dr = partnerDataTable.Rows[i];
            //        drpPartnerList.Items.Add(new ListItem(Convert.ToString(dr[ApplicationConstants.PAR_NAME]), Convert.ToString(dr[ApplicationConstants.PK_PARTNERID])));
            //    }
            //}
            //else
            //{
            //    drpPartnerList.Items.Add(new ListItem("-- No partner added for this company --", Convert.ToString(0)));
            //}
        }
        private void BindMiscInformation(DataTable MiscDataTable)
        {
            DataRow dr = MiscDataTable.Rows[0];
            try
            {
                txtMiscName.Text = Convert.ToString(dr[ApplicationConstants.MISC_NAME]);
                txtMiscExpiryDate.Text = !string.IsNullOrEmpty(dr[ApplicationConstants.MISC_EXP_DATE].ToString()) ? DateTime.Parse(dr[ApplicationConstants.MISC_EXP_DATE].ToString()).ToString(ApplicationConstants.DateFormat) : "";
                txtMiscNotes.Text = dr[ApplicationConstants.NOTES].ToString();
                //drpPartnerList.Items.FindByValue(Convert.ToString(dr[ApplicationConstants.FK_PARTNERID])).Selected = true; 
                chkMiscActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
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
        protected void btnMiscSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.Misc.PartnerMisc partnerMisc = FillPartnerMiscData(_operation);
                if (partnerMisc != null)
                {
                    bool res = new MiscService().UPSertPartnerMisc(partnerMisc, _operation);
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
        private DAL.Misc.PartnerMisc FillPartnerMiscData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.Misc.PartnerMisc
                {
                    Pk_miscid = !string.IsNullOrEmpty(Request.QueryString["miscid"]) ? Convert.ToInt64(Request.QueryString["miscid"]) : 0,
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    //Fk_partnerid = Convert.ToInt32(drpPartnerList.SelectedValue.Trim()),
                    Misc_name = txtMiscName.Text,
                    Misc_exp_date = !string.IsNullOrEmpty(txtMiscExpiryDate.Text) ? DateTime.ParseExact(txtMiscExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtMiscNotes.Text,
                    Is_active = chkMiscActive.Checked,
                    Is_deleted = false,                    
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return new DAL.Misc.PartnerMisc
                {
                    Pk_miscid = !string.IsNullOrEmpty(Request.QueryString["miscid"]) ? Convert.ToInt64(Request.QueryString["miscid"]) : 0,
                    Fk_companyid = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Convert.ToInt64(Request.QueryString["id"]) : 0,
                    //Fk_partnerid= Convert.ToInt32(drpPartnerList.SelectedValue.Trim()),
                    Misc_name = txtMiscName.Text,
                    Misc_exp_date = !string.IsNullOrEmpty(txtMiscExpiryDate.Text) ? DateTime.ParseExact(txtMiscExpiryDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : (DateTime?)null,
                    Notes = txtMiscNotes.Text,
                    Is_active = chkMiscActive.Checked,
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