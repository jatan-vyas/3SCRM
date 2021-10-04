using CMSApplication.DAL.USERS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSApplication.BAL.Login
{
    public class LoginService
    {
        UserDBAccess userDBAccess = null;

        public LoginService()
        {
            userDBAccess = new UserDBAccess();
        }
        public bool isUserAuthorize(string UserName,string Password,out int userId,out String ROLETYPE)
        {
            try
            {                
                return userDBAccess.isUserAuthorize(UserName, Password, out userId,out ROLETYPE);
            }
            catch (Exception ex)
            {
                userId = 0;
                ROLETYPE = "";
                return false;
            }
        }
        public DataTable GetUserDetail(string userID)
        {
            try
            {
                return userDBAccess.GetUserDetail(userID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertUser(DAL.USERS.User users, string ModeofOperation)
        {
            try
            {
                return userDBAccess.UPSertUser(users, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}