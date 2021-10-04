using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Company
{
    public class CompanyDBAccess
    {
        public CompanyDBAccess()
        {
        }
        public DataTable GetcompanyAlert(string FromDate, string ToDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.FromDate ,FromDate),
                    new SqlParameter(DBConstants.ToDate ,ToDate)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetCompanyAlert, CommandType.StoredProcedure, parameters))
                {
                    if (table.Rows.Count > 0)
                    {
                        return table;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetCompanyDetail(string CompanyID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID ,CompanyID)

                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetCompanyDetails, CommandType.StoredProcedure, parameters))
                {
                    if (table.Rows.Count > 0)
                    {
                        return table;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertCompany(Company company, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.CompanyID,company.Pk_companyid),
                new SqlParameter(DBConstants.CompanyName,company.Comp_name),
                new SqlParameter(DBConstants.CompanyAddress,company.Comp_address),
                new SqlParameter(DBConstants.CompanyPhone,company.Comp_phone),
                new SqlParameter(DBConstants.CompanyTradeLicenceExp,company.Comp_trade_license_exp),
                new SqlParameter(DBConstants.CompanyImmigrationExp,company.Comp_immigration_exp),
                new SqlParameter(DBConstants.CompanyImportCodeExp,company.Comp_import_code_exp),
                new SqlParameter(DBConstants.CompanyInsuranceExp,company.Comp_insurance_exp),
                new SqlParameter(DBConstants.Notes,company.Notes),
                new SqlParameter(DBConstants.IsActive,company.Is_active),
                new SqlParameter(DBConstants.IsDeleted,company.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,company.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,company.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,company.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,company.Modified_date),
                new SqlParameter(DBConstants.CompanyEmail,company.Comp_email),
                new SqlParameter(DBConstants.CompanyContactPerson,company.Comp_contact_person),
                new SqlParameter(DBConstants.CompanyContactPersonPhone,company.Comp_cp_phone),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTCompany, CommandType.StoredProcedure, parameters);
        }
        public bool DeleteCompany(string CompanyID,int UserID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID,CompanyID),
                    new SqlParameter(DBConstants.ModifiedBy,UserID),
                    new SqlParameter(DBConstants.ModifiedDate,DateTime.Now)
                };
                return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_DeleteCompany, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public long? GetLastInsertedCompanyID(string CompanyName)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("CMSDatabaseConnectionString");
            long? newCompanyID = 0;
            string sql = "select top 1 PK_COMPANYID from COMPANY where COMP_NAME like '" + CompanyName.Trim() + "' order by PK_COMPANYID desc";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    newCompanyID = (long)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
            return (long?)newCompanyID;
        }
    }
}