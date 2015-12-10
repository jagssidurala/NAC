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
	/// Summary description for NACVisitCount.
	/// </summary>
	public class NACVisitCount
	{
		public NACVisitCount()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private string strSessionId;
		private string strIpAddress;
		private string strConn;		   
		private DataAccessLayer.DBConnection conn;
		 

		public string SessionId
		{  
			get
			{	
				return strSessionId;
			}
			set
			{				 
				strSessionId = value;
			}
		}	

		public string IpAddress
		{  
			get
			{	
				return strIpAddress;
			}
			set
			{				 
				strIpAddress = value;
			}
		}

		public void SetNACVisitCount()
		{
		    
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@SessionId",SessionId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@IpAddress",IpAddress,ParameterDirection.Input);
				
				//Executing Command and storing Registrationid as Output Parameter in strRegistrationId
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"SetNACVisitCount");				 
				dbManager.CommitTransaction();				 
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
			 
		}

		public DataSet GetNACVisitCount()
		{
		    
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();

				//Returns a DataSet which contains a datewise count of Visitors.
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetNACVisitCount"));
				 
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
		}
		public DataSet GetTJVisitDetail(DateTime DateFrom, DateTime DateTo)
		{
		    
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();

				
					dbManager.CreateParameters(2);		//Number of parameters to be passed in StoredProcedure
					dbManager.AddParameters(0,"@From",DateFrom,ParameterDirection.Input);				
					dbManager.AddParameters(1,"@To",DateTo,ParameterDirection.Input);
			
				//Returns a DataSet which contains a datewise count of Visitors.
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTJVisitDetail"));
				 
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
		}
		public DataSet GetTJVisitDetailWithoutdate()
		{
		    
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();

				
			
				//Returns a DataSet which contains a datewise count of Visitors.
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTJVisitDetail"));
				 
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
		}
		public DataSet GetNACVisitCountRange(DateTime DateFrom, DateTime DateTo)
		{
		    
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();

				dbManager.CreateParameters(2);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@DateFrom",DateFrom,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@DateTo",DateTo,ParameterDirection.Input);

				//Returns a DataSet which contains a datewise count of Visitors.
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetNACVisitCountRange"));
				 
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
		}

	}
}
