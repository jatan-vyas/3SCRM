using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Employee
{
    public class EmployeeDBAccess
    {
        public EmployeeDBAccess()
        {

        }
        public DataTable GetEmployeeAlert(string FromDate, string ToDate)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.FromDate ,FromDate),
                    new SqlParameter(DBConstants.ToDate ,ToDate)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetEmployeeAlert, CommandType.StoredProcedure, parameters))
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
        public DataTable GetEmployeeDetail(string CompanyID, string EmployeeID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter(DBConstants.CompanyID ,CompanyID),
                    new SqlParameter(DBConstants.EmployeeID ,EmployeeID)
                };
                using (DataTable table = new SqlDBHelper().ExecuteParamerizedSelectCommand(DBConstants.SP_GetEmployeeDetails, CommandType.StoredProcedure, parameters))
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
        public bool UPSertEmployee(Employee employee, string OperationMode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.EmployeeID,employee.Pk_employeeid),
                new SqlParameter(DBConstants.CompanyID,employee.Fk_companyid),
                new SqlParameter(DBConstants.EmployeeName,employee.Emp_name),
                new SqlParameter(DBConstants.EmployeeMobile,employee.Emp_mobile),
                new SqlParameter(DBConstants.EmployeePassportExp,employee.Emp_passport_exp),
                new SqlParameter(DBConstants.EmployeeInsuranceExp,employee.Emp_insurance_exp),
                new SqlParameter(DBConstants.EmployeeVisaExp,employee.Emp_visa_exp),
                new SqlParameter(DBConstants.EmployeeLaborCardExp,employee.Emp_labor_card_exp),
                new SqlParameter(DBConstants.Notes,employee.Notes),
                new SqlParameter(DBConstants.IsActive,employee.Is_active),
                new SqlParameter(DBConstants.IsDeleted,employee.Is_deleted),
                new SqlParameter(DBConstants.CreatedBy,employee.Fk_created_by),
                new SqlParameter(DBConstants.ModifiedBy,employee.Fk_modified_by),
                new SqlParameter(DBConstants.CreatedDate,employee.Created_date),
                new SqlParameter(DBConstants.ModifiedDate,employee.Modified_date),
                new SqlParameter(DBConstants.ModeOfOpertion,OperationMode.ToLower().Trim() == ApplicationConstants.Operation_Add ? ApplicationConstants.Operation_Add : ApplicationConstants.Operation_Edit)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_UPSERTEmployee, CommandType.StoredProcedure, parameters);
        }
        public bool DeleteEmployee(string CompanyID, int UserID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(DBConstants.EmployeeID,CompanyID),
                new SqlParameter(DBConstants.ModifiedBy,UserID),
                new SqlParameter(DBConstants.ModifiedDate,DateTime.Now)
            };
            return new SqlDBHelper().ExecuteNonQuery(DBConstants.SP_DeleteEmployee, CommandType.StoredProcedure, parameters);
        }
    }
}