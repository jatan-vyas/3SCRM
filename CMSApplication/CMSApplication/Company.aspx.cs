using CMSApplication.BAL.Company;
using CMSApplication.DAL.Company;
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
    public partial class CompanyForm : System.Web.UI.Page
    {
        CompanyService companyService = null;
        public CompanyForm()
        {
            companyService = new CompanyService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dummy = new DataTable();
                dummy.Columns.Add("Comp_name");                
                dummy.Columns.Add("Comp_phone");
                dummy.Columns.Add("Comp_trade_license_exp");
                dummy.Columns.Add("Comp_immigration_exp");
                dummy.Columns.Add("Comp_import_code_exp");
                dummy.Columns.Add("Comp_insurance_exp");                
                dummy.Columns.Add("Is_active");
                dummy.Rows.Add();
                gvCompanyDetails.DataSource = dummy;
                //gvCompanyDetails.DataSource = companyService.GetCompanyDetail(null);
                gvCompanyDetails.DataBind();
                //Required for jQuery DataTables to work.
                gvCompanyDetails.UseAccessibleHeader = true;
                gvCompanyDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        [WebMethod]

        public static List<Company> GetCompanyDetails()
        {
            List<Company> companies = new List<Company>();
            DataTable dataTable = new CompanyService().GetCompanyDetail(null);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                companies.Add(new Company
                {
                    Pk_companyid = (long)dr["PK_COMPANYID"],
                    Comp_name = Convert.ToString(dr["COMP_NAME"]),
                    Comp_address = Convert.ToString(dr["COMP_ADDRESS"]),
                    Comp_phone = Convert.ToString(dr["COMP_PHONE"]),
                    Comp_trade_license_exp = !string.IsNullOrEmpty(dr["COMP_TRADE_LICENSE_EXP"].ToString()) ? Convert.ToDateTime(dr["COMP_TRADE_LICENSE_EXP"]) : (DateTime?)null,
                    Comp_immigration_exp = !string.IsNullOrEmpty(dr["COMP_IMMIGRATION_EXP"].ToString()) ? Convert.ToDateTime(dr["COMP_IMMIGRATION_EXP"]) : (DateTime?)null,
                    Comp_import_code_exp = !string.IsNullOrEmpty(dr["COMP_IMPORT_CODE_EXP"].ToString()) ? Convert.ToDateTime(dr["COMP_IMPORT_CODE_EXP"]) : (DateTime?)null,
                    Comp_insurance_exp = !string.IsNullOrEmpty(dr["COMP_INSURANCE_EXP"].ToString()) ? Convert.ToDateTime(dr["COMP_INSURANCE_EXP"]) : (DateTime?)null,
                    Notes = Convert.ToString(dr["NOTES"]),
                    Is_active = Convert.ToBoolean(dr["IS_ACTIVE"]),
                    Is_deleted = Convert.ToBoolean(dr["IS_DELETED"])
                });
            }
            return companies;
        }
        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompanyOperations.aspx?op=" + ApplicationConstants.Operation_Add);
        }
        protected void btnDeleteCompany_Click(object sender, EventArgs e)
        {
            string companyID = hdnCompanyID.Value;
            if (string.IsNullOrEmpty(companyID))
            {
                // show error message.
            }
            bool res = new CompanyService().DeleteCompany(companyID, Convert.ToInt32(Session[ApplicationConstants.USERID]));
            Response.Redirect("Company.aspx");
        }
    }
}