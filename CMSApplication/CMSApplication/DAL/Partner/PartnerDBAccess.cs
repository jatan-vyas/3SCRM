using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Partner
{
    public class PartnerDBAccess
    {
        public PartnerDBAccess()
        {

        }
        #region PARTNER RELATED DATABASE OPERATIONS
        public DataTable GetPartnerAlert(string FromDate, string ToDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.FromDate ,FromDate),
                    new SqlParameter(DBConstants.ToDate ,ToDate)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerAlert, CommandType.StoredProcedure, parameters))
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
        public DataTable GetPartnerDetail(string CompanyID, string PartnerID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID ,CompanyID),
                    new SqlParameter(DBConstants.PartnerID ,PartnerID)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerDetails, CommandType.StoredProcedure, parameters))
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

        public bool UPSertPartner(Partner partner, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerID,partner.Pk_partnerid),
                new SqlParameter(DBConstants.CompanyID,partner.Fk_companyid),
                new SqlParameter(DBConstants.PartnerName,partner.Par_name),
                new SqlParameter(DBConstants.PartnerMobile,partner.Par_mobile),
                new SqlParameter(DBConstants.PartnerPassportExp,partner.Par_passport_exp),
                new SqlParameter(DBConstants.PartnerInsuranceExp,partner.Par_insurance_exp),
                new SqlParameter(DBConstants.PartnerVisaExp,partner.Par_visa_exp),
                new SqlParameter(DBConstants.Notes,partner.Notes),
                new SqlParameter(DBConstants.IsActive,partner.Is_active),
                new SqlParameter(DBConstants.IsDeleted,partner.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,partner.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,partner.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,partner.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,partner.Modified_date),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTPartner, CommandType.StoredProcedure, parameters);
        }

        #endregion

        #region PARTNER FAMILY RELATED DATABASE OPERATION
        public DataTable GetPartnerFamilyAlert(string FromDate, string ToDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.FromDate ,FromDate),
                    new SqlParameter(DBConstants.ToDate ,ToDate)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerFamilyAlert, CommandType.StoredProcedure, parameters))
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
        
        public DataTable GetPartnerFamilyDetail(string CompanyID, string PartnerFamilyID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID ,CompanyID),
                    new SqlParameter(DBConstants.PartnerFamilyID ,PartnerFamilyID)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerFamilyDetails, CommandType.StoredProcedure, parameters))
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

        public bool UPSertPartnerFamily(PartnerFamily partnerFamily, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerFamilyID,partnerFamily.Pk_familyid),
                new SqlParameter(DBConstants.PartnerID,partnerFamily.Fk_partnerid),
                new SqlParameter(DBConstants.PartnerFamilyName,partnerFamily.Fml_name),
                new SqlParameter(DBConstants.PartnerFamilyRelation,partnerFamily.Fml_relation),
                new SqlParameter(DBConstants.PartnerFamilyPassportExp,partnerFamily.Fml_passport_exp),
                new SqlParameter(DBConstants.PartnerFamilyInsuranceExp,partnerFamily.Fml_insurance_exp),
                new SqlParameter(DBConstants.PartnerFamilyVisaExp,partnerFamily.Fml_visa_exp),
                new SqlParameter(DBConstants.Notes,partnerFamily.Notes),
                new SqlParameter(DBConstants.IsActive,partnerFamily.Is_active),
                new SqlParameter(DBConstants.IsDeleted,partnerFamily.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,partnerFamily.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,partnerFamily.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,partnerFamily.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,partnerFamily.Modified_date),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTPartnerFamily, CommandType.StoredProcedure, parameters);
        }
        #endregion

        public long? GetPartnerIDFromPartnerName(long companyId, string partnerName)
        {
            string connectionString = ConfigurationManager.AppSettings.Get("CMSDatabaseConnectionString");
            long? newCompanyID = 0;
            string sql = "select top 1 PK_PARTNERID from [PARTNER] where PAR_NAME like '"+ partnerName +"' and FK_COMPANYID="+ companyId +" order by PK_PARTNERID desc";

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

        public bool DeletePartner(string PartnerID, int UserID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerID,PartnerID),
                new SqlParameter(DBConstants.ModifiedBy,UserID),
                new SqlParameter(DBConstants.ModifiedDate,DateTime.Now)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_DeletePartner, CommandType.StoredProcedure, parameters);
        }
        public bool DeleteFamily(string PartnerFamilyID, int UserID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerFamilyID,PartnerFamilyID),
                new SqlParameter(DBConstants.ModifiedBy,UserID),
                new SqlParameter(DBConstants.ModifiedDate,DateTime.Now)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_DeletePartnerFamily, CommandType.StoredProcedure, parameters);
        }
    }
}