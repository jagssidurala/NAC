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
	/// Summary description for ScoreOverwrite.
	/// </summary>
	public class ScoreOverwrite
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
	
		private int intStateId;
		private int intUserType;
		private string strETSComment;
		private string strAdminComment;
		private string strUserName;		
		private int intUserId;
		private string strStateName;
		private int intRowId;

		public int StateId
		{  
			get
			{	
				return intStateId;
			}
			set
			{				 
				intStateId = value;
			}
		}

		public int RowId
		{  
			get
			{	
				return intRowId;
			}
			set
			{				 
				intRowId = value;
			}
		}

		public int UserType
		{  
			get
			{	
				return intUserType;
			}
			set
			{				 
				intUserType = value;
			}
		}


		public string ETSComment
		{  
			get
			{	
				return strETSComment;
			}
			set
			{				 
				strETSComment = value;
			}
		}

		public string AdminComment
		{  
			get
			{	
				return strAdminComment;
			}
			set
			{				 
				strAdminComment = value;
			}
		}


		public string UserName
		{  
			get
			{	
				return strUserName;
			}
			set
			{				 
				strUserName = value;
			}
		}
		
		public string StateName
		{  
			get
			{	
				return strStateName;
			}
			set
			{				 
				strStateName = value;
			}
		}

		public int UserId
		{  
			get
			{	
				return intUserId;
			}
			set
			{				 
				intUserId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public void RequestForScoreOverwrite()
		{
			 
			try
			{ 
    
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(5);
				dbManager.AddParameters(0,"@RowId",RowId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@StateId",StateId,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@UserId",UserId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@UserName",UserName,ParameterDirection.Input);
				dbManager.AddParameters(4,"@ETSComment",ETSComment,ParameterDirection.Input);	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"RequestForScoreOverwrite");				 
				dbManager.CommitTransaction();
				 
			}
			catch(Exception ex)
			{					 
				dbManager.RollbackTransaction();
				throw(ex);
			}
			finally
			{				
				dbManager.Close();
				dbManager.Dispose();
			}

		}

		public void ApproveETSRequest(int intRowId, string strAdminComment, int intStateId)
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
				dbManager.AddParameters(0,"@intRowId",intRowId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@AdminComment",strAdminComment,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@StateId",intStateId,ParameterDirection.Input);	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"ApproveETSRequest");
				dbManager.CommitTransaction();
				
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
		 

		public void ChnageUploadStatusByAdmin()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(5);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();				
				dbManager.AddParameters(0,"@StateId",StateId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@UserName",UserName,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StateName",StateName,ParameterDirection.Input);
				dbManager.AddParameters(3,"@UserId",UserId,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@UserType",UserType,ParameterDirection.Input);
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"ChangeUploadStatusByAdmin");
				dbManager.CommitTransaction();
				
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

		public void ChnageUploadStatusByETS()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(5);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();			 
				dbManager.AddParameters(0,"@StateId",StateId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@UserName",UserName,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StateName",StateName,ParameterDirection.Input);
				dbManager.AddParameters(3,"@UserId",UserId,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@UserType",UserType,ParameterDirection.Input);	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"ChangeUploadStatus");
				dbManager.CommitTransaction();
				
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


		 

		public void CloseStatus(int intRowId, string strAdminComment, int intStateId)
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
				dbManager.AddParameters(0,"@intRowId",intRowId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@AdminComment",strAdminComment,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@StateId",intStateId,ParameterDirection.Input);	
	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"StatusCloseByAdmin");
				dbManager.CommitTransaction();
				
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


		public void RejectETSRequest(int intRowId, string strAdminComment, int intStateId)
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
				dbManager.AddParameters(0,"@intRowId",intRowId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@AdminComment",strAdminComment,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@StateId",intStateId,ParameterDirection.Input);	
	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"RejectETSRequest");
				dbManager.CommitTransaction();
				
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

		public DataSet FetchETSStatusRequest()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"FetchETSRequestDetail");
			}
			catch
			{
				throw;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}
		public DataSet FetchETSStatusRequestLog()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"FetchETSRequestDetailLog");
			}
			catch
			{
				throw;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public ScoreOverwrite()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
