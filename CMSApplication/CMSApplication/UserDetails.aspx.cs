using CMSApplication.BAL.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string _userID = Request.QueryString["userid"];
            string _operation = Request.QueryString["op"];

            if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Add)
                userPageHeading.InnerText = "Add User";
            else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                userPageHeading.InnerText = "Update User";
            else
                userPageHeading.InnerText = "User";

            string roleType = Convert.ToString(Session[ApplicationConstants.ROLETYPE]);
            if (string.IsNullOrEmpty(roleType))
                Response.Redirect("Dashboard.aspx");

            if (roleType.ToLower().Trim() != "admin")
            {                
                if (_userID != Convert.ToString(Session[ApplicationConstants.USERID]))
                {
                    Response.Redirect("Dashboard.aspx");
                } 
            }

            DataTable dataTable = new DataTable();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_Edit)
                {
                    if (!string.IsNullOrEmpty(_userID))
                        dataTable = new LoginService().GetUserDetail(_userID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindUserInformation(dataTable);
                    }
                }
                else if (!string.IsNullOrEmpty(_operation) && _operation.ToLower().Trim() == ApplicationConstants.Operation_View)
                {
                    if (!string.IsNullOrEmpty(_userID))
                        dataTable = new LoginService().GetUserDetail(_userID);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        BindUserInformation(dataTable);
                    }
                    btnUser.Visible = false;
                }
            }
        }
        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
        protected void btnUserSave_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string _operation = Request.QueryString["op"];
                DAL.USERS.User user = FillUserData(_operation);
                if (user != null)
                {
                    bool res = new LoginService().UPSertUser(user, _operation);
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
        private void BindUserInformation(DataTable UserDataTable)
        {
            DataRow dr = UserDataTable.Rows[0];
            try
            {
                txtName.Text = Convert.ToString(dr[ApplicationConstants.USER_NAME]);
                txtUserName.Text = Convert.ToString(dr[ApplicationConstants.USER_USERNAME]);
                txtPassword.Text = Convert.ToString(dr[ApplicationConstants.USER_PASSWORD]);
                txtMobile.Text = Convert.ToString(dr[ApplicationConstants.USER_MOBILE_NO]);
                txtUserNotes.Text = Convert.ToString(dr[ApplicationConstants.NOTES]);
                chkUserActive.Checked = Convert.ToBoolean(dr[ApplicationConstants.IS_ACTIVE]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DAL.USERS.User FillUserData(string ModeOfOperation)
        {
            if (ModeOfOperation == ApplicationConstants.Operation_Edit)
            {
                return new DAL.USERS.User
                {
                    Pk_userid = !string.IsNullOrEmpty(Request.QueryString["userid"]) ? Convert.ToInt64(Request.QueryString["userid"]) : 0,
                    Name = txtName.Text,
                    Username = txtUserName.Text,
                    Password = txtPassword.Text,
                    Mobile_No = txtMobile.Text,
                    Notes = txtUserNotes.Text,
                    Is_active = chkUserActive.Checked,
                    Is_deleted = false,
                    Fk_modified_by = Convert.ToInt64(Session[ApplicationConstants.USERID]),
                    Created_date = DateTime.Now,
                    Modified_date = DateTime.Now
                };
            }
            else
            {
                return new DAL.USERS.User
                {
                    Pk_userid = !string.IsNullOrEmpty(Request.QueryString["userid"]) ? Convert.ToInt64(Request.QueryString["userid"]) : 0,
                    Name = txtName.Text,
                    Username = txtUserName.Text,
                    Password = txtPassword.Text,
                    Mobile_No = txtMobile.Text,
                    Notes = txtUserNotes.Text,
                    Is_active = chkUserActive.Checked,
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