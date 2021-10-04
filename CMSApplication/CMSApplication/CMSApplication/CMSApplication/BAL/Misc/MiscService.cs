using CMSApplication.DAL.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSApplication.BAL.Misc
{
    public class MiscService
    {
        PartnerMiscDBAccess miscDBAccess = null;
        public MiscService()
        {
            miscDBAccess = new PartnerMiscDBAccess();
        }
        public DataTable GetPartnerMiscAlert(string FromDate, string ToDate)
        {
            try
            {
                return miscDBAccess.GetPartnerMiscAlert(FromDate, ToDate);
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
                return miscDBAccess.GetPartnerMiscDetail(CompanyID, PartnerMiscID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UPSertPartnerMisc(DAL.Misc.PartnerMisc partnerMisc, string ModeofOperation)
        {
            try
            {
                return miscDBAccess.UPSertPartnerMisc(partnerMisc, ModeofOperation);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteMisc(string MiscID, int UserID)
        {
            try
            {
                return miscDBAccess.DeleteMisc(MiscID, UserID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}