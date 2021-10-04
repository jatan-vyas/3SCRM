using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApplication
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //the datetime and Log folder will be used for error log file in case error occured
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";
            try
            {
                //Provide the folder path where excel files are present
                String FolderPath = @"C:\Source\";
                String TableName = "";
                //Provide the schema for tables in which we want to load Excel files
                String SchemaName = "dbo";
                //Provide the Database Name in which table or view exists
                string DatabaseName = "TechbrothersIT";
                //Provide the SQL Server Name 
                string SQLServerName = "(local)";

                var directory = new DirectoryInfo(FolderPath);
                FileInfo[] files = directory.GetFiles();

                //Declare and initilize variables
                string fileFullPath = "";


                //Create Connection to SQL Server Database to import Excel file's data
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source = "
                    + SQLServerName + "; Initial Catalog ="
                    + DatabaseName + "; "
                    + "Integrated Security=true;";

                //Get one Book(Excel file at a time)
                foreach (FileInfo file in files)
                {
                    fileFullPath = FolderPath + "\\" + file.Name;

                    //Create Excel Connection
                    string ConStr;
                    string HDR;
                    HDR = "YES";
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath
                        + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                    OleDbConnection cnn = new OleDbConnection(ConStr);

                    //Remove All Numbers and other characters and leave alphabets for name
                    System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z]");
                    TableName = rgx.Replace(file.Name, "").Replace("xlsx", "");

                    //Get Sheet Name
                    cnn.Open();
                    DataTable dtSheet = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetname;
                    sheetname = "";
                    foreach (DataRow drSheet in dtSheet.Rows)
                    {
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                        {
                            sheetname = drSheet["TABLE_NAME"].ToString();

                            //Load the DataTable with Sheet Data so we can get the column header
                            OleDbCommand oconn = new OleDbCommand("select top 1 * from [" + sheetname + "]", cnn);
                            OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            cnn.Close();

                            //Prepare Header columns list so we can run against Database to get matching columns for a table.
                            //If columns does not exists in table, it will ignore and load only matching columns data
                            string ExcelHeaderColumn = "";
                            string SQLQueryToGetMatchingColumn = "";
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (i != dt.Columns.Count - 1)
                                    ExcelHeaderColumn += "'" + dt.Columns[i].ColumnName + "'" + ",";
                                else
                                    ExcelHeaderColumn += "'" + dt.Columns[i].ColumnName + "'";
                            }

                            SQLQueryToGetMatchingColumn = "select STUFF((Select  ',['+Column_Name+']' from Information_schema.Columns where Table_Name='" +
                            TableName + "' and Table_SChema='" + SchemaName + "'" +
                                         "and Column_Name in (" + @ExcelHeaderColumn + ") for xml path('')),1,1,'') AS ColumnList";


                            //Get Matching Column List from SQL Server
                            string SQLColumnList = "";
                            SqlCommand cmd = SQLConnection.CreateCommand();
                            cmd.CommandText = SQLQueryToGetMatchingColumn;
                            SQLConnection.Open();
                            SQLColumnList = (string)cmd.ExecuteScalar();
                            SQLConnection.Close();

                            //Use Actual Matching Columns to get data from Excel Sheet
                            OleDbConnection cnn1 = new OleDbConnection(ConStr);
                            cnn1.Open();
                            OleDbCommand oconn1 = new OleDbCommand("select " + SQLColumnList
                                + " from [" + sheetname + "]", cnn1);
                            OleDbDataAdapter adp1 = new OleDbDataAdapter(oconn1);
                            DataTable dt1 = new DataTable();
                            adp1.Fill(dt1);
                            cnn1.Close();


                            //Delete the row if all values are nulll
                            int columnCount = dt1.Columns.Count;
                            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
                            {
                                bool allNull = true;
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if (dt1.Rows[i][j] != DBNull.Value)
                                    {
                                        allNull = false;
                                    }
                                }
                                if (allNull)
                                {
                                    dt1.Rows[i].Delete();
                                }
                            }
                            dt1.AcceptChanges();


                            SQLConnection.Open();
                            //Load Data from DataTable to SQL Server Table.
                            using (SqlBulkCopy BC = new SqlBulkCopy(SQLConnection))
                            {
                                BC.DestinationTableName = SchemaName + "." + TableName;
                                foreach (var column in dt1.Columns)
                                    BC.ColumnMappings.Add(column.ToString(), column.ToString());
                                BC.WriteToServer(dt1);
                            }
                            SQLConnection.Close();

                        }
                    }
                }
            }

            catch (Exception exception)
            {
                // Create Log File for Errors
                using (StreamWriter sw = File.CreateText(LogFolder
                    + "\\" + "ErrorLog_" + datetime + ".log"))
                {
                    sw.WriteLine(exception.ToString());

                }

            }

        }
    }
}

