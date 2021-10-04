using CMSApplication.DAL.Partner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSApplication.BAL.Partner
{
    public class PartnerService
    {
        PartnerDBAccess partnerDBAccess = null; 
        public PartnerService()
        {
            partnerDBAccess = new PartnerDBAccess();
        }
        #region PARTNER RELATED METHODS
        public DataTable GetPartnerAlert(string FromDate, string ToDate)
        {
            try
            {
                return partnerDBAccess.GetPartnerAlert(FromDate, ToDate);
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
                return partnerDBAccess.GetPartnerDetail(CompanyID, PartnerID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertPartner(DAL.Partner.Partner partner, string ModeofOperation)
        {
            try
            {
                return partnerDBAccess.UPSertPartner(partner, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region PARTNER FAMILY RELATED METHODS
        public DataTable GetPartnerFamilyAlert(string FromDate,string ToDate)
        {
            try
            {
                return partnerDBAccess.GetPartnerFamilyAlert(FromDate, ToDate);
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
                return partnerDBAccess.GetPartnerFamilyDetail(CompanyID, PartnerFamilyID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertPartnerFamily(DAL.Partner.PartnerFamily partnerFamily, string ModeofOperation)
        {
            try
            {
                return partnerDBAccess.UPSertPartnerFamily(partnerFamily, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        public long? GetPartnerIDFromPartnerName(long companyId,string partnerName)
        {
            try
            {
                return partnerDBAccess.GetPartnerIDFromPartnerName(companyId,partnerName);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public bool DeletePartner(string PartnerID, int UserID)
        {
            try
            {
                return partnerDBAccess.DeletePartner(PartnerID, UserID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeletePartnerFamily(string PartnerFamilyID, int UserID)
        {
            try
            {
                return partnerDBAccess.DeleteFamily(PartnerFamilyID, UserID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}