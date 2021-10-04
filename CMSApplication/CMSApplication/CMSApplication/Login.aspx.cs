using CMSApplication.BAL.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSingIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            int userId = 0;
            string roletype = "";
            LoginService loginService = new LoginService();
            bool res = loginService.isUserAuthorize(userName, passWord, out userId, out roletype);
            if (res)
            {
                Session.Add(ApplicationConstants.USERNAME, userName);                
                Session.Add(ApplicationConstants.USERID, userId);
                Session.Add(ApplicationConstants.ROLETYPE, roletype);
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}