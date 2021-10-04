using CMSApplication.DAL.Company;
using CMSApplication.DAL.Employee;
using CMSApplication.DAL.Partner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSApplication.BAL.Company
{
    public class CompanyService
    {
        CompanyDBAccess companyDBAccess = null;
        PartnerDBAccess partnerDBAccess = null;
        EmployeeDBAccess employeeDBAccess = null;

        public CompanyService()
        {
            companyDBAccess = new CompanyDBAccess();
            partnerDBAccess = new PartnerDBAccess();
            employeeDBAccess = new EmployeeDBAccess();
        }
        #region COMPANY RELATED OPERATIONS
        public DataTable GetCompanyAlert(string FromDate,string ToDate)
        {
            try
            {
                return companyDBAccess.GetcompanyAlert(FromDate, ToDate);
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
                return companyDBAccess.GetCompanyDetail(CompanyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertCompany(DAL.Company.Company company,string ModeofOperation)
        {
            try
            {
                return companyDBAccess.UPSertCompany(company, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCompany(string CompanyID,int UserId)
        {
            try
            {
                return companyDBAccess.DeleteCompany(CompanyID,UserId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public long? GetLastInsertedCompanyID(string CompanyName)
        {
            try
            {
                return companyDBAccess.GetLastInsertedCompanyID(CompanyName);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        #endregion

    }
}