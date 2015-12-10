using System; 
using System.Collections;
using System.Text;
using System.Data; 
using DataAccessLayer;
using DataBaseAccessLayer;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using Common;
using System.Data.SqlClient;
using ExceptionHandling;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for MakeDeactiveCandidate.
	/// </summary>
	public class FieldPermission
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private string strFieldList;
		private string strConn;	
		private DataAccessLayer.DBConnection conn;

		public string FieldList
		{  
			get
			{	
				return strFieldList;
			}
			set
			{				 
				strFieldList = value;
			}
		}

		public DataSet getFieldName()
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 

				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetFieldName");
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

		public int UpdateField(string tmpFieldList)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(2);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				int i32NoOfRows = 0;

				dbManager.AddParameters(0,"@FieldList",tmpFieldList,ParameterDirection.Input);
				dbManager.AddParameters(1,"@NoOfRows",i32NoOfRows,ParameterDirection.Output);
				
				i32NoOfRows = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"UpdatePermission","@NoOfRows");
				dbManager.CommitTransaction();
				
				return i32NoOfRows;

				
			}
			catch(Exception ex)
			{
				dbManager.RollbackTransaction();
				throw ex;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public string GetFieldPermission()
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 

				return Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetFieldPermission"));
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

		public FieldPermission()
		{
			
		}
	}
}
