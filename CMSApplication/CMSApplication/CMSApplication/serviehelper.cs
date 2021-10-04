using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication
{
    public class servicehelper
    {
    }
    public class Status
    {
        public string status { get; set; }
        public string message { get; set; }
        public string errorMessage { get; set; }
    }

    public class DataTableStatus
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<CompanyData> lstData { get; set; }
    }

    public class CompanyData
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTradeLicense { get; set; }
        public string CompanyImmigration { get; set; }
        public string CompanyImportCode { get; set; }
        public string CompanyInsurance { get; set; }
    }

    public class PartnerData
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerMobile { get; set; }
        public string PassportExp { get; set; }
        public string InsuranceExp { get; set; }
        public string VisaExp { get; set; }
    }

    public class PartnerList
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PartnerData> lstData { get; set; }
    }

    public class EmployeeData
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpMobile { get; set; }
        public string PassportExp { get; set; }
        public string InsuranceExp { get; set; }
        public string VisaExp { get; set; }

        public string LaborCardExp { get; set; }
    }

    public class EmployeeList
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<EmployeeData> lstData { get; set; }
    }

    public class PartnerFamilyData
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerMobile { get; set; }
        public string PartnerFamilyId { get; set; }
        public string PartnerFamilyName { get; set; }
        public string PartnerFamilyRelation { get; set; }
        public string PassportExp { get; set; }
        public string InsuranceExp { get; set; }
        public string VisaExp { get; set; }
    }

    public class PartnerFamilyList
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PartnerFamilyData> lstData { get; set; }
    }

    public class PartnerMiscData
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string PartnerMiscId { get; set; }
        public string PartnerMiscName { get; set; }
        public string MiscExp { get; set; }
    }

    public class PartnerMiscList
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PartnerMiscData> lstData { get; set; }
    }
}