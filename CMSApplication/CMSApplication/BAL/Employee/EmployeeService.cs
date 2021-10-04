using CMSApplication.DAL.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSApplication.BAL.Employee
{
    public class EmployeeService
    {
        EmployeeDBAccess employeeDBAccess = null;
        public EmployeeService()
        {
            employeeDBAccess = new EmployeeDBAccess();
        }
        public DataTable GetEmployeeAlert(string FromDate, string ToDate)
        {
            try
            {
                return employeeDBAccess.GetEmployeeAlert(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetEmployeeDetails(string CompanyID, string EmployeeID)
        {
            try
            {
                return employeeDBAccess.GetEmployeeDetail(CompanyID, EmployeeID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertEmployee(DAL.Employee.Employee employee, string ModeofOperation)
        {
            try
            {
                return employeeDBAccess.UPSertEmployee(employee, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteEmployee(string EmployeeID,int UserID)
        {
            try
            {
                return employeeDBAccess.DeleteEmployee(EmployeeID, UserID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}