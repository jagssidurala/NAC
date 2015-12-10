using System;
using DataBaseAccessLayer;
using DataAccessLayer;
using System.Web;
using System.Data;  
using Common;
using System.Data.SqlClient;
using ExceptionHandling;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLHtmlToPDF.
	/// </summary>
	public class BLHtmlToPDF
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	

		public DataSet GetAllUsersEmailIds(string strItemList)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer); 
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.AddParameters(0, "@CandidateRegistrationList", strItemList);			 
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllUsersEmailIds");
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public BLHtmlToPDF()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
