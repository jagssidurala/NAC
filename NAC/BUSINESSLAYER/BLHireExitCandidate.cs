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
	/// Summary description for BLHireExitCandidate.
	/// </summary>
	public class BLHireExitCandidate
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private string strCandidateRegistrationId;
		private string strCompanyId;
		private string strRegistrationIdList ;


		private string strConn;	
		private DataAccessLayer.DBConnection conn;

		public string RegistrationId
		{  
			get
			{	
				return strCandidateRegistrationId;
			}
			set
			{				 
				strCandidateRegistrationId = value;
			}
		}

		public string CompanyId
		{  
			get
			{	
				return strCompanyId;
			}
			set
			{				 
				strCompanyId = value;
			}
		}
		
		public string RegistrationIdList
		{  
			get
			{	
				return strRegistrationIdList;
			}
			set
			{				 
				strRegistrationIdList = value;
			}
		}

		public BLHireExitCandidate()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int HireCandidate()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(3);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				int i32NoOfRows = 0;
				dbManager.AddParameters(0,"@RegistrationIdList",RegistrationIdList,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CompanyId",CompanyId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StatusId","1",ParameterDirection.Input);
				//dbManager.AddParameters(1,"@NoOfRows",i32NoOfRows,ParameterDirection.Output);
				
				i32NoOfRows = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, "UpdateCandidateHiringStatus"));
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
/*
		public int ExitCandidate()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(3);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				int i32NoOfRows = 0;
				dbManager.AddParameters(0,"@RegistrationId",RegistrationId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CompanyId",CompanyId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StatusId","0",ParameterDirection.Input);
				//dbManager.AddParameters(1,"@NoOfRows",i32NoOfRows,ParameterDirection.Output);
				
				i32NoOfRows = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, "UpdateCandidateHiringStatus"));
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
*/
		public int ExitCandidate()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(3);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				int i32NoOfRows = 0;
				dbManager.AddParameters(0,"@RegistrationIdList",RegistrationIdList,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CompanyId",CompanyId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StatusId","0",ParameterDirection.Input);
				i32NoOfRows = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, "UpdateCandidateHiringStatus"));
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


		public DataSet GetCandidateDetails()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				//dbManager.BeginTransaction();
				dbManager.AddParameters(0,"@RegistrationId",RegistrationId,ParameterDirection.Input);
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCandidateHiringDetails"));
				//dbManager.CommitTransaction();
				
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

		public DataSet GetHiredCandidateDetailsByCompany()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				//dbManager.BeginTransaction();
				dbManager.AddParameters(0,"@CompanyId",CompanyId,ParameterDirection.Input);
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetHiredCandidateDetails"));
				//dbManager.CommitTransaction();
				
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

	}
}
