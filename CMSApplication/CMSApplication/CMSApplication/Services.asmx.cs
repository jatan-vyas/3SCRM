using CMSApplication.BAL.Company;
using CMSApplication.BAL.Employee;
using CMSApplication.BAL.Misc;
using CMSApplication.BAL.Partner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace CMSApplication
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCompanyAlert(string fromDate, string toDate)
        {
            Status objStatus = new Status();
            try
            {
                if (string.IsNullOrEmpty(fromDate))
                    fromDate = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(toDate))
                    toDate = DateTime.Now.ToString();

                CompanyService companyService = new CompanyService();
                DataTable companyDataTable = companyService.GetCompanyAlert(fromDate, toDate);

                if (companyDataTable != null && companyDataTable.Rows.Count > 0)
                {
                    List<CompanyData> lst = new List<CompanyData>();

                    foreach (DataRow dr in companyDataTable.Rows)
                    {
                        CompanyData obj = new CompanyData();
                        obj.CompanyId = dr["PK_COMPANYID"].ToString();
                        obj.CompanyName = dr["COMP_NAME"].ToString();
                        obj.CompanyAddress = dr["COMP_ADDRESS"].ToString();
                        obj.CompanyPhone = dr["COMP_PHONE"].ToString();
                        obj.CompanyTradeLicense = dr["COMP_TRADE_LICENSE_EXP"].ToString();
                        obj.CompanyImmigration = dr["COMP_IMMIGRATION_EXP"].ToString();
                        obj.CompanyImportCode = dr["COMP_IMPORT_CODE_EXP"].ToString();
                        obj.CompanyInsurance = dr["COMP_INSURANCE_EXP"].ToString();

                        lst.Add(obj);
                    }

                    DataTableStatus ds = new DataTableStatus();
                    ds.status = "True";
                    ds.lstData = lst;
                    ds.message = "";
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(ds));
                    return serializer.Serialize(ds);
                }
                else
                {
                    objStatus.status = "False";
                    objStatus.message = "No company found.";
                    objStatus.errorMessage = string.Empty;
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(objStatus));
                    return serializer.Serialize(objStatus);
                }


            }
            catch (Exception ex)
            {
                objStatus.status = "False";
                objStatus.message = "There is an error while fetching company list.";
                objStatus.errorMessage = string.Empty;
                //this.Context.Response.ContentType = "application/json; charset=utf-8";
                //this.Context.Response.Write(serializer.Serialize(objStatus));
                return serializer.Serialize(objStatus);
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPartnerAlert(string fromDate, string toDate)
        {
            Status objStatus = new Status();
            try
            {
                if (string.IsNullOrEmpty(fromDate))
                    fromDate = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(toDate))
                    toDate = DateTime.Now.ToString();

                PartnerService partnerService = new PartnerService();
                DataTable partnerDataTable = partnerService.GetPartnerAlert(fromDate, toDate);

                if (partnerDataTable != null && partnerDataTable.Rows.Count > 0)
                {
                    List<PartnerData> lst = new List<PartnerData>();

                    foreach (DataRow dr in partnerDataTable.Rows)
                    {
                        PartnerData obj = new PartnerData();
                        obj.CompanyId = dr["PK_COMPANYID"].ToString();
                        obj.CompanyName = dr["COMP_NAME"].ToString();
                        obj.CompanyAddress = dr["COMP_ADDRESS"].ToString();
                        obj.CompanyPhone = dr["COMP_PHONE"].ToString();
                        obj.PartnerId = dr["PK_PARTNERID"].ToString();
                        obj.PartnerName = dr["PAR_NAME"].ToString();
                        obj.PartnerMobile = dr["PAR_MOBILE"].ToString();
                        obj.PassportExp = dr["PAR_PASSPORT_EXP"].ToString();
                        obj.InsuranceExp = dr["PAR_INSURANCE_EXP"].ToString();
                        obj.VisaExp = dr["PAR_VISA_EXP"].ToString();
                        lst.Add(obj);
                    }

                    PartnerList ds = new PartnerList();
                    ds.status = "True";
                    ds.lstData = lst;
                    ds.message = "";
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(ds));
                    return serializer.Serialize(ds);
                }
                else
                {
                    objStatus.status = "False";
                    objStatus.message = "No partner found.";
                    objStatus.errorMessage = string.Empty;
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(objStatus));
                    return serializer.Serialize(objStatus);
                }


            }
            catch (Exception ex)
            {
                objStatus.status = "False";
                objStatus.message = "There is an error while fetching partner list.";
                objStatus.errorMessage = string.Empty;
                //this.Context.Response.ContentType = "application/json; charset=utf-8";
                //this.Context.Response.Write(serializer.Serialize(objStatus));
                return serializer.Serialize(objStatus);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetEmployeeAlert(string fromDate, string toDate)
        {
            Status objStatus = new Status();
            try
            {
                if (string.IsNullOrEmpty(fromDate))
                    fromDate = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(toDate))
                    toDate = DateTime.Now.ToString();

                EmployeeService employeeService = new EmployeeService();
                DataTable employeeDataTable = employeeService.GetEmployeeAlert(fromDate, toDate);

                if (employeeDataTable != null && employeeDataTable.Rows.Count > 0)
                {
                    List<EmployeeData> lst = new List<EmployeeData>();

                    foreach (DataRow dr in employeeDataTable.Rows)
                    {
                        EmployeeData obj = new EmployeeData();
                        obj.CompanyId = dr["PK_COMPANYID"].ToString();
                        obj.CompanyName = dr["COMP_NAME"].ToString();
                        obj.CompanyAddress = dr["COMP_ADDRESS"].ToString();
                        obj.CompanyPhone = dr["COMP_PHONE"].ToString();
                        obj.EmpId = dr["PK_EMPLOYEEID"].ToString();
                        obj.EmpName = dr["EMP_NAME"].ToString();
                        obj.EmpMobile = dr["EMP_MOBILE"].ToString();
                        obj.PassportExp = dr["EMP_PASSPORT_EXP"].ToString();
                        obj.InsuranceExp = dr["EMP_INSURANCE_EXP"].ToString();
                        obj.VisaExp = dr["EMP_VISA_EXP"].ToString();
                        obj.LaborCardExp = dr["EMP_LABOR_CARD_EXP"].ToString();
                        lst.Add(obj);

                    }

                    EmployeeList ds = new EmployeeList();
                    ds.status = "True";
                    ds.lstData = lst;
                    ds.message = "";
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(ds));
                    return serializer.Serialize(ds);
                }
                else
                {
                    objStatus.status = "False";
                    objStatus.message = "No employee found.";
                    objStatus.errorMessage = string.Empty;
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(objStatus));
                    return serializer.Serialize(objStatus);
                }


            }
            catch (Exception ex)
            {
                objStatus.status = "False";
                objStatus.message = "There is an error while fetching employee list.";
                objStatus.errorMessage = string.Empty;
                //this.Context.Response.ContentType = "application/json; charset=utf-8";
                //this.Context.Response.Write(serializer.Serialize(objStatus));
                return serializer.Serialize(objStatus);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPartnerFamilyAlert(string fromDate, string toDate)
        {
            Status objStatus = new Status();
            try
            {
                if (string.IsNullOrEmpty(fromDate))
                    fromDate = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(toDate))
                    toDate = DateTime.Now.ToString();

                PartnerService partnerService = new PartnerService();
                DataTable partnerFamilyDataTable = partnerService.GetPartnerFamilyAlert(fromDate, toDate);

                if (partnerFamilyDataTable != null && partnerFamilyDataTable.Rows.Count > 0)
                {
                    List<PartnerFamilyData> lst = new List<PartnerFamilyData>();

                    foreach (DataRow dr in partnerFamilyDataTable.Rows)
                    {
                        PartnerFamilyData obj = new PartnerFamilyData();
                        obj.CompanyId = dr["PK_COMPANYID"].ToString();
                        obj.CompanyName = dr["COMP_NAME"].ToString();
                        obj.CompanyAddress = dr["COMP_ADDRESS"].ToString();
                        obj.CompanyPhone = dr["COMP_PHONE"].ToString();
                        obj.PartnerId = dr["PK_PARTNERID"].ToString();
                        obj.PartnerName = dr["PAR_NAME"].ToString();
                        obj.PartnerMobile = dr["PAR_MOBILE"].ToString();

                        obj.PartnerFamilyId = dr["PK_FAMILYID"].ToString();
                        obj.PartnerFamilyName = dr["FML_NAME"].ToString();
                        obj.PartnerFamilyRelation = dr["FML_RELATION"].ToString();

                        obj.PassportExp = dr["FML_PASSPORT_EXP"].ToString();
                        obj.InsuranceExp = dr["FML_INSURANCE_EXP"].ToString();
                        obj.VisaExp = dr["FML_VISA_EXP"].ToString();

                        lst.Add(obj);
                    }

                    PartnerFamilyList ds = new PartnerFamilyList();
                    ds.status = "True";
                    ds.lstData = lst;
                    ds.message = "";
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(ds));
                    return serializer.Serialize(ds);
                }
                else
                {
                    objStatus.status = "False";
                    objStatus.message = "No partner family found.";
                    objStatus.errorMessage = string.Empty;
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(objStatus));
                    return serializer.Serialize(objStatus);
                }


            }
            catch (Exception ex)
            {
                objStatus.status = "False";
                objStatus.message = "There is an error while fetching partner family list.";
                objStatus.errorMessage = string.Empty;
                //this.Context.Response.ContentType = "application/json; charset=utf-8";
                //this.Context.Response.Write(serializer.Serialize(objStatus));
                return serializer.Serialize(objStatus);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPartnerMiscAlert(string fromDate, string toDate)
        {
            Status objStatus = new Status();
            try
            {
                if (string.IsNullOrEmpty(fromDate))
                    fromDate = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(toDate))
                    toDate = DateTime.Now.ToString();

                MiscService partnerService = new MiscService();
                DataTable miscDataTable = partnerService.GetPartnerMiscAlert(fromDate, toDate);

                if (miscDataTable != null && miscDataTable.Rows.Count > 0)
                {
                    List<PartnerMiscData> lst = new List<PartnerMiscData>();

                    foreach (DataRow dr in miscDataTable.Rows)
                    {
                        PartnerMiscData obj = new PartnerMiscData();
                        obj.CompanyId = dr["PK_COMPANYID"].ToString();
                        obj.CompanyName = dr["COMP_NAME"].ToString();
                        obj.CompanyAddress = dr["COMP_ADDRESS"].ToString();
                        obj.CompanyPhone = dr["COMP_PHONE"].ToString();

                        obj.PartnerMiscId = dr["PK_MISCID"].ToString();
                        obj.PartnerMiscName = dr["MISC_NAME"].ToString();
                        obj.MiscExp = dr["MISC_EXP_DATE"].ToString();

                        lst.Add(obj);
                    }

                    PartnerMiscList ds = new PartnerMiscList();
                    ds.status = "True";
                    ds.lstData = lst;
                    ds.message = "";
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(ds));
                    return serializer.Serialize(ds);
                }
                else
                {
                    objStatus.status = "False";
                    objStatus.message = "No partner misc found.";
                    objStatus.errorMessage = string.Empty;
                    //this.Context.Response.ContentType = "application/json; charset=utf-8";
                    //this.Context.Response.Write(serializer.Serialize(objStatus));
                    return serializer.Serialize(objStatus);
                }


            }
            catch (Exception ex)
            {
                objStatus.status = "False";
                objStatus.message = "There is an error while fetching partner misc list.";
                objStatus.errorMessage = string.Empty;
                //this.Context.Response.ContentType = "application/json; charset=utf-8";
                //this.Context.Response.Write(serializer.Serialize(objStatus));
                return serializer.Serialize(objStatus);
            }
        }
    }
}
