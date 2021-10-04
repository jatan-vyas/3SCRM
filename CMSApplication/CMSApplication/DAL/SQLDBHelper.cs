using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSApplication.DAL
{
    public class SqlDBHelper
	{
		string CONNECTION_STRING;
        public SqlDBHelper()
        {
			CONNECTION_STRING = ConfigurationManager.AppSettings.Get("CMSDatabaseConnectionString");
			//CONNECTION_STRING = ConfigurationManager.ConnectionStrings["CMSDatabaseConnectionString"].ToString();
			
		}
		//const string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;User Instance=True";

		// This function will be used to execute R(CRUD) operation of parameterless commands
		public DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
		{
			DataTable table = null;
			using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
			{
				using (SqlCommand cmd = con.CreateCommand())
				{
					cmd.CommandType = cmdType;
					cmd.CommandText = CommandName;

					try
					{
						if (con.State != ConnectionState.Open)
						{
							con.Open();
						}

						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							table = new DataTable();
							da.Fill(table);
						}
					}
					catch
					{
						throw;
					}
				}
			}

			return table;
		}

		// This function will be used to execute R(CRUD) operation of parameterized commands
		public DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
		{
			DataTable table = new DataTable();

			using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
			{
				using (SqlCommand cmd = con.CreateCommand())
				{
					cmd.CommandType = cmdType;
					cmd.CommandText = CommandName;
					cmd.Parameters.AddRange(param);

					try
					{
						if (con.State != ConnectionState.Open)
						{
							con.Open();
						}

						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(table);
						}
					}
					catch(Exception ex)
					{
						throw;
					}
				}
			}

			return table;
		}

		// This function will be used to execute CUD(CRUD) operation of parameterized commands
		public bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
		{
			int result = 0;

			using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
			{
				using (SqlCommand cmd = con.CreateCommand())
				{
					cmd.CommandType = cmdType;
					cmd.CommandText = CommandName;
					cmd.Parameters.AddRange(pars);

					try
					{
						if (con.State != ConnectionState.Open)
						{
							con.Open();
						}
						result = cmd.ExecuteNonQuery();
					}
					catch(Exception ex)
					{
						throw ex;
					}
				}
			}

			return (result > 0);
		}
	}
}