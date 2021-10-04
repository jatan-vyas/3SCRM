using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.USERS
{
    public class UserDBAccess
    {
        public User GetLoginDetails(string UserName, string Password)
        {
            try
            {
                User userDetails = null;
                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter(DBConstants.UserName, UserName),
                        new SqlParameter(DBConstants.Password,Password)
                    };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetLoginDetails, CommandType.StoredProcedure, parameters))
                {
                    if (table.Rows.Count > 0)
                    {

                    }
                }
                return userDetails;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool isUserAuthorize(string UserName, string Password, out int userID,out string ROLETYPE)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter(DBConstants.UserName, UserName),
                        new SqlParameter(DBConstants.Password,Password)
                    };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetLoginDetails, CommandType.StoredProcedure, parameters))
                {
                    if (table.Rows.Count > 0)
                    {
                        userID = Convert.ToInt32(table.Rows[0]["PK_USERID"]);
                        ROLETYPE = Convert.ToString(table.Rows[0]["ROLETYPE"]);
                        return true;
                    }
                    else
                    {
                        userID = 0;
                        ROLETYPE = "";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                userID = 0;
                ROLETYPE = "";
                return false;
            }
        }
        public DataTable GetUserDetail(string UserID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.UserID ,UserID)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetUserDetails, CommandType.StoredProcedure, parameters))
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
        public bool UPSertUser(User user, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.UserID,user.Pk_userid),
                new SqlParameter(DBConstants.UserName,user.Username),
                new SqlParameter(DBConstants.Password,user.Password),
                new SqlParameter(DBConstants.User_Name,user.Name),
                new SqlParameter(DBConstants.User_MobileNo,user.Mobile_No),
                new SqlParameter(DBConstants.Notes,user.Notes),
                new SqlParameter(DBConstants.IsActive,user.Is_active),
                new SqlParameter(DBConstants.IsDeleted,user.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,user.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,user.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,user.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,user.Modified_date),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTUser, CommandType.StoredProcedure, parameters);
        }
    }
}