using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CMSAlertApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));


            string alertType = Convert.ToString(ConfigurationSettings.AppSettings["AlertType"]);
            log.Info("AlertType: " + alertType);
            string fromDate = "";
            string toDate = "";
            if (alertType.ToLower() == "overdue")
            {
                fromDate = new DateTime(2001, 01, 01).ToShortDateString();
                toDate = DateTime.Now.AddDays(-1).ToShortDateString();
            }
            else if (alertType.ToLower() == "30 days")
            {
                fromDate = DateTime.Now.ToShortDateString();
                toDate = DateTime.Now.AddDays(30).ToShortDateString();
            }
            else if (alertType.ToLower() == "15 days")
            {
                fromDate = DateTime.Now.ToShortDateString();
                toDate = DateTime.Now.AddDays(15).ToShortDateString();
            }
            else if (alertType.ToLower() == "7 days")
            {
                fromDate = DateTime.Now.ToShortDateString();
                toDate = DateTime.Now.AddDays(7).ToShortDateString();
            }
            else
            {
                fromDate = DateTime.Now.ToShortDateString();
                toDate = DateTime.Now.ToShortDateString();
            }

            log.Info("FromDate:: " + fromDate + "::ToDate::" + toDate);

            createExcel(fromDate, toDate);//obj.lstData);

            //if (obj.status == "True")
            //{
            //    createExcel(obj.lstData);
            //}


            Console.WriteLine("END");
        }

        public static void createExcel(string fromDate, string toDate)//List<CompanyData> lstCompany)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

            CRMService.Services service = new CRMService.Services();


            Application oXL;
            _Workbook oWB;
            _Worksheet oSheet;

            oXL = new Application();
            oXL.Visible = true;

            //oXL.Interactive = false;


            oWB = (_Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (_Worksheet)oWB.ActiveSheet;


            try
            {
                //List<string> SheetNames = new List<string>();
                //SheetNames.Add("Company");
                //SheetNames.Add("Partner");
                //SheetNames.Add("Employee");
                //SheetNames.Add("PartnerFamily");
                //SheetNames.Add("PartnerMisc");
                string jsonString;
                string[] colNames;
                int col;
                char lastColumn;

                #region Misc


                oSheet = (_Worksheet)oXL.Worksheets.Add();
                oSheet.Name = "Misc";

                colNames = new string[9];

                col = 0;

                colNames[col++] = "CompanyName";
                colNames[col++] = "Address";
                colNames[col++] = "Phone";
                colNames[col++] = "Misc";
                colNames[col++] = "MiscExp";


                lastColumn = (char)(65 + 5 - 1);

                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;

                jsonString = (service.GetPartnerMiscAlert(fromDate, toDate));
                var objMisc = JsonConvert.DeserializeObject<PartnerMiscList>(jsonString);
                if (objMisc.lstData == null)
                    log.Info("Misc Data is null");
                if (objMisc.lstData != null)
                {
                    string[,] rowData = new string[objMisc.lstData.Count + 1, 5];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (PartnerMiscData obj in objMisc.lstData)
                    {
                        //for (col = 0; col < dtProducts.Columns.Count; col++)
                        //{
                        rowData[rowCnt, 0] = obj.CompanyName;
                        rowData[rowCnt, 1] = obj.CompanyAddress;
                        rowData[rowCnt, 2] = obj.CompanyPhone;
                        rowData[rowCnt, 3] = obj.PartnerMiscName;
                        rowData[rowCnt, 4] = obj.MiscExp;
                        //}

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        redRows++;
                        rowCnt++;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        rowData[rowCnt, j] = string.Empty;
                    }
                    oSheet.get_Range("A2", lastColumn + (rowCnt + 1).ToString()).Value2 = rowData;
                }

                #endregion

                #region Partner Family


                oSheet = (_Worksheet)oXL.Worksheets.Add();
                oSheet.Name = "PartnerFamily";

                colNames = new string[10];

                col = 0;

                colNames[col++] = "CompanyName";
                colNames[col++] = "Address";
                colNames[col++] = "Phone";
                colNames[col++] = "PartnerName";
                colNames[col++] = "PartnerMobile";
                colNames[col++] = "FamilyName";
                colNames[col++] = "FamilyRelation";
                colNames[col++] = "Passport";
                colNames[col++] = "Insurance";
                colNames[col++] = "Visa";



                lastColumn = (char)(65 + 10 - 1);

                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;

                jsonString = (service.GetPartnerFamilyAlert(fromDate, toDate));
                var objFamily = JsonConvert.DeserializeObject<PartnerFamilyList>(jsonString);

                if (objFamily.lstData != null)
                {
                    string[,] rowData = new string[objFamily.lstData.Count + 1, 10];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (PartnerFamilyData obj in objFamily.lstData)
                    {
                        //for (col = 0; col < dtProducts.Columns.Count; col++)
                        //{
                        rowData[rowCnt, 0] = obj.CompanyName;
                        rowData[rowCnt, 1] = obj.CompanyAddress;
                        rowData[rowCnt, 2] = obj.CompanyPhone;
                        rowData[rowCnt, 3] = obj.PartnerName;
                        rowData[rowCnt, 4] = obj.PartnerMobile;
                        rowData[rowCnt, 5] = obj.PartnerFamilyName;
                        rowData[rowCnt, 6] = obj.PartnerFamilyRelation;
                        rowData[rowCnt, 7] = obj.PassportExp;
                        rowData[rowCnt, 8] = obj.InsuranceExp;
                        rowData[rowCnt, 9] = obj.VisaExp;
                        //}

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        redRows++;
                        rowCnt++;
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        rowData[rowCnt, j] = string.Empty;
                    }
                    oSheet.get_Range("A2", lastColumn + (rowCnt + 1).ToString()).Value2 = rowData;
                }

                #endregion

                #region Employee


                oSheet = (_Worksheet)oXL.Worksheets.Add();
                oSheet.Name = "Employee";

                colNames = new string[9];

                col = 0;

                colNames[col++] = "CompanyName";
                colNames[col++] = "Address";
                colNames[col++] = "Phone";
                colNames[col++] = "EmployeeName";
                colNames[col++] = "EmployeeMobile";
                colNames[col++] = "Passport";
                colNames[col++] = "Insurance";
                colNames[col++] = "Visa";
                colNames[col++] = "LaborCard";


                lastColumn = (char)(65 + 9 - 1);

                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;

                jsonString = (service.GetEmployeeAlert(fromDate, toDate));
                var objEmployee = JsonConvert.DeserializeObject<EmployeeList>(jsonString);

                if (objEmployee.lstData != null)
                {
                    string[,] rowData = new string[objEmployee.lstData.Count + 1, 9];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (EmployeeData obj in objEmployee.lstData)
                    {
                        //for (col = 0; col < dtProducts.Columns.Count; col++)
                        //{
                        rowData[rowCnt, 0] = obj.CompanyName;
                        rowData[rowCnt, 1] = obj.CompanyAddress;
                        rowData[rowCnt, 2] = obj.CompanyPhone;
                        rowData[rowCnt, 3] = obj.EmpName;
                        rowData[rowCnt, 4] = obj.EmpMobile;
                        rowData[rowCnt, 5] = obj.PassportExp;
                        rowData[rowCnt, 6] = obj.InsuranceExp;
                        rowData[rowCnt, 7] = obj.VisaExp;
                        rowData[rowCnt, 8] = obj.LaborCardExp;
                        //}

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        redRows++;
                        rowCnt++;
                    }
                    for (int j = 0; j < 9; j++)
                    {
                        rowData[rowCnt, j] = string.Empty;
                    }
                    oSheet.get_Range("A2", lastColumn + (rowCnt + 1).ToString()).Value2 = rowData;
                }

                #endregion

                #region Partner


                oSheet = (_Worksheet)oXL.Worksheets.Add();
                oSheet.Name = "Partner";

                colNames = new string[8];

                col = 0;

                colNames[col++] = "CompanyName";
                colNames[col++] = "Address";
                colNames[col++] = "Phone";
                colNames[col++] = "PartnerName";
                colNames[col++] = "PartnerMobile";
                colNames[col++] = "Passport";
                colNames[col++] = "Insurance";
                colNames[col++] = "Visa";


                lastColumn = (char)(65 + 8 - 1);

                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;

                jsonString = (service.GetPartnerAlert(fromDate, toDate));
                var objPartner = JsonConvert.DeserializeObject<PartnerList>(jsonString);

                if (objPartner.lstData != null)
                {
                    string[,] rowData = new string[objPartner.lstData.Count + 1, 8];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (PartnerData obj in objPartner.lstData)
                    {
                        //for (col = 0; col < dtProducts.Columns.Count; col++)
                        //{
                        rowData[rowCnt, 0] = obj.CompanyName;
                        rowData[rowCnt, 1] = obj.CompanyAddress;
                        rowData[rowCnt, 2] = obj.CompanyPhone;
                        rowData[rowCnt, 3] = obj.PartnerName;
                        rowData[rowCnt, 4] = obj.PartnerMobile;
                        rowData[rowCnt, 5] = obj.PassportExp;
                        rowData[rowCnt, 6] = obj.InsuranceExp;
                        rowData[rowCnt, 7] = obj.VisaExp;
                        //}

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        redRows++;
                        rowCnt++;
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        rowData[rowCnt, j] = string.Empty;
                    }
                    oSheet.get_Range("A2", lastColumn + (rowCnt + 1).ToString()).Value2 = rowData;
                }

                #endregion

                #region Company

                oSheet = (_Worksheet)oXL.Worksheets.Add();
                oSheet.Name = "Company";

                colNames = new string[7];

                col = 0;

                colNames[col++] = "CompanyName";
                colNames[col++] = "Address";
                colNames[col++] = "Phone";
                colNames[col++] = "TradeLicense";
                colNames[col++] = "Immigration";
                colNames[col++] = "ImportCode";
                colNames[col++] = "Insurance";

                lastColumn = (char)(65 + 7 - 1);

                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;

                jsonString = (service.GetCompanyAlert(fromDate, toDate));
                var objCompany = JsonConvert.DeserializeObject<DataTableStatus>(jsonString);

                if (objCompany.lstData != null)
                {
                    string[,] rowData = new string[objCompany.lstData.Count + 1, 7];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (CompanyData obj in objCompany.lstData)
                    {
                        //for (col = 0; col < dtProducts.Columns.Count; col++)
                        //{
                        rowData[rowCnt, 0] = obj.CompanyName;
                        rowData[rowCnt, 1] = obj.CompanyAddress;
                        rowData[rowCnt, 2] = obj.CompanyPhone;
                        rowData[rowCnt, 3] = obj.CompanyTradeLicense;
                        rowData[rowCnt, 4] = obj.CompanyImmigration;
                        rowData[rowCnt, 5] = obj.CompanyImportCode;
                        rowData[rowCnt, 6] = obj.CompanyInsurance;
                        //}

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        redRows++;
                        rowCnt++;
                    }
                    for (int j = 0; j < 7; j++)
                    {
                        rowData[rowCnt, j] = string.Empty;
                    }
                    oSheet.get_Range("A2", lastColumn + (rowCnt + 1).ToString()).Value2 = rowData;
                }
                #endregion






                oXL.Visible = true;
                oXL.UserControl = true;
                string path = Directory.GetCurrentDirectory();

                string fileName = path + "\\UploadFiles\\" + "3sGroupAlert_" + DateTime.Now.Ticks + ".xlsx";
                log.Info("FileName ::" + fileName);
                try
                {
                    oWB.SaveAs(fileName,
                                AccessMode: XlSaveAsAccessMode.xlShared);
                }
                catch (Exception ex)
                {
                    log.Error("An error occurred in saveAS", ex);
                }

                oWB.Close();

                oXL.Quit();

                //Email File
                sendMail(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                log.Error("Exception in create excel function ", ex);
            }
            finally
            {
                Marshal.ReleaseComObject(oWB);
            }

        }

        public static void createExcelFile(List<CompanyData> lstCompany)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Info("Inside create excelfile");
            string fileName = "D:\\Testing.xslx";
            Application ExcelApp = new Application();
            Workbook ExcelWorkBook = null;
            Worksheet ExcelWorkSheet = null;

            ExcelApp.Visible = true;
            ExcelWorkBook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            List<string> SheetNames = new List<string>();
            SheetNames.Add("Company");
            SheetNames.Add("Partner");
            SheetNames.Add("Employee");
            SheetNames.Add("PartnerFamily");
            SheetNames.Add("PartnerMisc");


            try
            {
                for (int i = 1; i < 5; i++)
                {
                    ExcelWorkBook.Worksheets.Add(); //Adding New sheet in Excel Workbook
                }
                ExcelWorkSheet = ExcelWorkBook.Worksheets[1];

                foreach (CompanyData dt in lstCompany)
                {


                }
                ExcelWorkSheet.Name = SheetNames[1];//Renaming the ExcelSheets
                /*
                for (int i = 0; i < ds.Tables.Count; i++)

                {

                    int r = 1; // Initialize Excel Row Start Position  = 1
                    ExcelWorkSheet = ExcelWorkBook.Worksheets[i + 1];

                    //Writing Columns Name in Excel Sheet
                    for (int col = 1; col < ds.Tables[i].Columns.Count; col++)

                        ExcelWorkSheet.Cells[r, col] = ds.Tables[i].Columns[col - 1].ColumnName;

                    r++;
                    //Writing Rows into Excel Sheet
                    for (int row = 0; row < ds.Tables[i].Rows.Count; row++) //r stands for ExcelRow and col for ExcelColumn

                    {

                        // Excel row and column start positions for writing Row=1 and Col=1

                        for (int col = 1; col < ds.Tables[i].Columns.Count; col++)

                            ExcelWorkSheet.Cells[r, col] = ds.Tables[i].Rows[row][col - 1].ToString();

                        r++;

                    }

                    ExcelWorkSheet.Name = SheetNames[i];//Renaming the ExcelSheets



                }
                */


                ExcelWorkBook.SaveAs(fileName);

                ExcelWorkBook.Close();

                ExcelApp.Quit();

                Marshal.ReleaseComObject(ExcelWorkSheet);

                Marshal.ReleaseComObject(ExcelWorkBook);

                Marshal.ReleaseComObject(ExcelApp);

            }
            catch (Exception exHandle)
            {
                Console.WriteLine("Exception: " + exHandle.Message);
                Console.ReadLine();
            }
            finally
            {
                //foreach (Process process in Process.GetProcessesByName("Excel"))
                //    process.Kill();
            }



        }

        public static void sendMail(string fileName)
        {
            try
            {
                string smtpserver = Convert.ToString(ConfigurationSettings.AppSettings["smtpServer"]);
                int smtpport = Convert.ToInt32(ConfigurationSettings.AppSettings["smtpPort"]);
                int Timeout = Convert.ToInt32(ConfigurationSettings.AppSettings["TimeoutP"]);
                bool isEnableSsl = Convert.ToBoolean(ConfigurationSettings.AppSettings["EnableSsl"]);
                string smtpemail = Convert.ToString(ConfigurationSettings.AppSettings["smtpUser"]);
                string PPassword = Convert.ToString(ConfigurationSettings.AppSettings["smtpPass"]);

                string emailTo = Convert.ToString(ConfigurationSettings.AppSettings["mailTo"]);

                SmtpClient objClient = new SmtpClient(smtpserver);
                objClient.Port = smtpport;
                objClient.EnableSsl = isEnableSsl;
                objClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objClient.UseDefaultCredentials = false;
                objClient.Credentials = new NetworkCredential(smtpemail.Trim(), PPassword.Trim());


                string alertType = Convert.ToString(ConfigurationSettings.AppSettings["AlertType"]);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(smtpemail);
                msg.Subject = "3sGroupCRM Alert : " + alertType;
                //Attachments
                //Stream stream = GetBillReceiptinStream(billId, Convert.ToInt64(Session["ContractorId"].ToString()));
                //if (stream != null)//&& file.ContentLength <= 1048576)
                //{
                //    string FileName = balreceipt.BILLNO + ".PDF";
                Attachment attach = new Attachment(fileName);
                msg.Attachments.Add(attach);
                //}
                msg.Body = "Hello ,<br/> Please find an attached the file for alert.  <br/><br/>Thanks,<br/> - 3s Group CRM Management";
                msg.IsBodyHtml = true;
                msg.To.Add(emailTo);
                objClient.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Mail : " + ex.Message);
            }
        }
    }

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
