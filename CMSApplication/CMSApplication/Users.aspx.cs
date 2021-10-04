using CMSApplication.BAL.Login;
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                string roleType = Convert.ToString(Session[ApplicationConstants.ROLETYPE]);
                if (string.IsNullOrEmpty(roleType))
                    Response.Redirect("Dashboard.aspx");

                if (roleType.ToLower().Trim() != "admin")
                    Response.Redirect("Dashboard.aspx");

                DataTable userDataTable = new DataTable();
                userDataTable.Columns.Add("Name");
                userDataTable.Columns.Add("UserName");
                userDataTable.Columns.Add("Mobile_No");
                userDataTable.Columns.Add("Is_active");
                userDataTable.Rows.Add();
                gvUserDetails.DataSource = userDataTable;
                gvUserDetails.DataBind();
                gvUserDetails.UseAccessibleHeader = true;
                gvUserDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        [WebMethod]
        public static List<DAL.USERS.User> GetUserDetails()
        {
            List<DAL.USERS.User> users = new List<DAL.USERS.User>();
            DataTable dataTable = new LoginService().GetUserDetail(null);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                users.Add(new DAL.USERS.User
                {
                    Pk_userid = (long)dr["PK_USERID"],
                    Username = Convert.ToString(dr["USERNAME"]),
                    Name = Convert.ToString(dr["NAME"]),
                    Mobile_No = Convert.ToString(dr["MOBILE_NO"]),
                    Notes = Convert.ToString(dr["NOTES"]),
                    Is_active = Convert.ToBoolean(dr["IS_ACTIVE"]),
                    Is_deleted = Convert.ToBoolean(dr["IS_DELETED"])
                });
            }
            return users;
        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx?op=add");
        }
    }
}