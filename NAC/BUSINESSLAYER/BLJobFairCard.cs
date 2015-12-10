using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; 
using System.Web; 
using ExceptionHandling;
using Common;
using System.IO;
using DataAccessLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLJobFairCard.
	/// </summary>
	public class BLJobFairCard
	{

		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		public BLJobFairCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		
		private string strRegistrationId;
		private string strCompanyName;
		private int intStateId;
		private DateTime strFirstJobFairDate;
		private DateTime strSecondJobFairDate;
		private DateTime strInterviewDate;
		private DateTime strInterviewTime;

		private DataAccessLayer.DBConnection conn;
		private string strConn;		 
		
	
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


		public string RegistrationId
		{  
			get
			{	
				return strRegistrationId;
			}
			set
			{				 
				strRegistrationId = value;
			}
		}

		public string CompanyName
		{  
			get
			{	
				return strCompanyName;
			}
			set
			{				 
				strCompanyName = value;
			}
		}

		public DateTime FirstJobFairDate
		{  
			get
			{	
				return strFirstJobFairDate;
			}
			set
			{				 
				strFirstJobFairDate = value;
			}
		}

		public DateTime SecondJobFairDate
		{  
			get
			{	
				return strSecondJobFairDate;
			}
			set
			{				 
				strSecondJobFairDate = value;
			}
		}
		public DateTime Interviewdate
		{  
			get
			{	
				return strInterviewDate;
			}
			set
			{				 
				strInterviewDate = value;
			}
		}

		public DateTime Interviewtime
		{  
			get
			{	
				return strInterviewTime;
			}
			set
			{				 
				strInterviewTime = value;
			}
		}


		

		#region  Get Job fair Card Details


	public DataSet GenerateMultipuleJobFairCardCompanyDetails(string strRegistrationId)
	{
		try
		{
			conn = new DBConnection();
			strConn = conn.GetConnectionString();
			dbManager = new DBManager(DataProvider.SqlServer);			 
			dbManager.ConnectionString = strConn.ToString();
			dbManager.Open();
			//int flag=1;
			//int StateId=1;				
			DataSet dsJobFairCardCompanyDetails = new DataSet();
			dbManager.CreateParameters(1);
			dbManager.AddParameters(0, "@RegistrationId", strRegistrationId);
			
			dsJobFairCardCompanyDetails =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipuleJobFairCompanyDetails");
			return dsJobFairCardCompanyDetails;
				
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


		public DataSet GenerateJobFairCardStateDateDetails(string strRegistartionId)
		{
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				
				
				DataSet dsJobFairCardCompanyDetails = new DataSet();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", strRegistartionId);				
				dsJobFairCardCompanyDetails =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"multJobFairCardDateDetails");
				
				return dsJobFairCardCompanyDetails;
				
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


		public DataSet GenerateJobFairCardCompanyDetails(string strRegistrationId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 		
				DataSet dsJobFairCardCompanyDetails = new DataSet();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", strRegistrationId);
				dsJobFairCardCompanyDetails =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetJobFairCompanyDetails");
				return dsJobFairCardCompanyDetails;
				
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

		#endregion
		#region Insert Job Fair card


		public void InsertJobFairCardDetail()
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
				dbManager.AddParameters(0,"@RegistrationId",RegistrationId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@CompanyName",CompanyName,ParameterDirection.Input);				
				dbManager.AddParameters(2,"@StateId",StateId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@InterviewDate",strInterviewDate,ParameterDirection.Input);
				dbManager.AddParameters(4,"@InterviewTime",strInterviewTime,ParameterDirection.Input);
				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"InserJobFairCardDetail");
				dbManager.CommitTransaction();
			}
			catch
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				throw;
			}	
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}

		}
		public void InsertJobFairCompanydetail()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(4);
				dbManager.AddParameters(0,"@CompanyName",CompanyName,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@FirstJobFairDate",FirstJobFairDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@SecondJobFairDate",SecondJobFairDate,ParameterDirection.Input);
				dbManager.AddParameters(3,"@StateId",StateId,ParameterDirection.Input);
				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"InsertJobFairCompanyDetail");
				dbManager.CommitTransaction();
			}
			catch
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				throw;
			}	
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}		 
		}

		#endregion


		
	}
}
