using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.USERS
{
    public class User
    {
        string username;
        string password;
        string name;
        string mobile_no;
        string notes;
        bool is_active;
        bool is_deleted;
        long fk_created_by;
        long fk_modified_by;
        DateTime created_date;
        DateTime modified_date;
        long pk_userid;
        public long Pk_userid
        {
            get
            {
                return pk_userid;
            }
            set
            {
                pk_userid = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Mobile_No
        {
            get
            {
                return mobile_no;
            }
            set
            {
                mobile_no = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        public bool Is_active
        {
            get
            {
                return is_active;
            }
            set
            {
                is_active = value;
            }
        }
        public bool Is_deleted
        {
            get
            {
                return is_deleted;
            }
            set
            {
                is_deleted = value;
            }
        }
        public long Fk_created_by
        {
            get
            {
                return fk_created_by;
            }
            set
            {
                fk_created_by = value;
            }
        }
        public long Fk_modified_by
        {
            get
            {
                return fk_modified_by;
            }
            set
            {
                fk_modified_by = value;
            }
        }
        public DateTime Created_date
        {
            get
            {
                return created_date;
            }
            set
            {
                created_date = value;
            }
        }
        public DateTime Modified_date
        {
            get
            {
                return modified_date;
            }
            set
            {
                modified_date = value;
            }
        }
    }
}