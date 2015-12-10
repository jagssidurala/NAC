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
	public class BLDeactiveCandidate
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private string strCandidateRegistrationList;
		private string strConn;	
		private DataAccessLayer.DBConnection conn;

		public string CandidateRegistrationList
		{  
			get
			{	
				return strCandidateRegistrationList;
			}
			set
			{				 
				strCandidateRegistrationList = value;
			}
		}

		public int DeactivateCandidates(string strItemList)
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

				dbManager.AddParameters(0,"@CandidateRegistrationList",CandidateRegistrationList,ParameterDirection.Input);
				dbManager.AddParameters(1,"@NoOfRows",i32NoOfRows,ParameterDirection.Output);
				
				i32NoOfRows = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"DeactivateCandidates","@NoOfRows");
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

		public int DeactivateCandidatesAdminV2(string strItemList)
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

				dbManager.AddParameters(0,"@CandidateRegistrationList",CandidateRegistrationList,ParameterDirection.Input);
				dbManager.AddParameters(1,"@NoOfRows",i32NoOfRows,ParameterDirection.Output);
				
                //i32NoOfRows = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"DeactivateCandidatesAdminV2","@NoOfRows");
                i32NoOfRows = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure, "DeactivateCandidates", "@NoOfRows");
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

		public BLDeactiveCandidate()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
