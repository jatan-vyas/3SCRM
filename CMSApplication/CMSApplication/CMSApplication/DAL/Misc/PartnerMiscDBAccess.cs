using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Misc
{
    public class PartnerMiscDBAccess
    {
        public PartnerMiscDBAccess()
        {
                
        }
        public DataTable GetPartnerMiscAlert(string FromDate, string ToDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.FromDate ,FromDate),
                    new SqlParameter(DBConstants.ToDate ,ToDate)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerMiscAlert, CommandType.StoredProcedure, parameters))
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
        public DataTable GetPartnerMiscDetail(string CompanyID, string PartnerMiscID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID ,CompanyID),
                    new SqlParameter(DBConstants.PartnerMiscID ,PartnerMiscID)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetPartnerMiscDetails, CommandType.StoredProcedure, parameters))
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
        public bool UPSertPartnerMisc(PartnerMisc partnerMisc, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerMiscID,partnerMisc.Pk_miscid),
                new SqlParameter(DBConstants.CompanyID,partnerMisc.Fk_companyid),
                new SqlParameter(DBConstants.PartnerMiscName,partnerMisc.Misc_name),
                new SqlParameter(DBConstants.PartnerMiscExpDate,partnerMisc.Misc_exp_date),                
                new SqlParameter(DBConstants.Notes,partnerMisc.Notes),
                new SqlParameter(DBConstants.IsActive,partnerMisc.Is_active),
                new SqlParameter(DBConstants.IsDeleted,partnerMisc.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,partnerMisc.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,partnerMisc.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,partnerMisc.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,partnerMisc.Modified_date),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTPartnerMisc, CommandType.StoredProcedure, parameters);
        }

        public bool DeleteMisc(string MiscID, int UserID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.PartnerMiscID,MiscID),
                new SqlParameter(DBConstants.ModifiedBy,UserID),
                new SqlParameter(DBConstants.ModifiedDate,DateTime.Now)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_DeleteMisc, CommandType.StoredProcedure, parameters);
        }
    }
}