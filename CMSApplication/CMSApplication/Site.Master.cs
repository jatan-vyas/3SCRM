using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session[ApplicationConstants.USERNAME])))
            {
                userProfile.HRef = "userdetails.aspx?op=edit&userid=" + Convert.ToString(Session[ApplicationConstants.USERID]);
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session[ApplicationConstants.USERNAME])))
                {
                    lblLoggedInUser.Text = Session[ApplicationConstants.USERNAME].ToString();

                    lnkAImportData.Visible = false;
                    lnkAUser.Visible = false;
                    string roleType = Convert.ToString(Session[ApplicationConstants.ROLETYPE]);
                    if (!string.IsNullOrEmpty(roleType))
                    {
                        if (roleType.ToLower() == "admin")
                        {
                            lnkAImportData.Visible = true;
                            lnkAUser.Visible = true;;
                        }
                    }
                }
                else
                    Response.Redirect("Login.aspx");
            }
        }

        protected void lnlLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}