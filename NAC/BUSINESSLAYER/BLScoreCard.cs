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
	/// Summary description for BLScoreCard.
	/// </summary>
	public class BLScoreCard
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);


		public BLScoreCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private int intCertificateId;
		private string strRegistrationId;
	
		 
		private string strTestCentreCode;
		private string strName;
		private DateTime strAdminDOB;
		private DateTime strDOB;
		private int intGender;
		private int intResidency;
		private int intEducation;
		private int intEmployeement;
		private int intMediumInstructions;
		private string strFormCode;
		
		private string strGroup;

		
		/// /
	
		private int intSpeaking;
		private int intListening;
		private int intWriting;
		private int intAnalytical;
		private int intStateId;
		private DataAccessLayer.DBConnection conn;
		private string strConn;		 

		public int CertificateId
		{  
			get
			{	
				return intCertificateId;
			}
			set
			{				 
				intCertificateId = value;
			}
		}

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

		public string TestCentreCode
		{  
			get
			{	
				return strTestCentreCode;
			}
			set
			{				 
				strTestCentreCode = value;
			}
		}

		public string Name
		{  
			get
			{	
				return strName;
			}
			set
			{				 
				strName = value;
			}
		}

		public DateTime AdminDOB
		{  
			get
			{	
				return strAdminDOB;
			}
			set
			{				 
				strAdminDOB = value;
			}
		}

	public DateTime DOB
	{  
		get
		{	
			return strDOB;
		}
		set
		{				 
			strDOB = value;
		}
	}
		public int Gender
		{  
			get
			{	
				return intGender;
			}
			set
			{				 
				intGender = value;
			}
		}


		public int Residency
		{  
			get
			{	
				return intResidency;
			}
			set
			{				 
				intResidency = value;
			}
		}

		public int Education
		{  
			get
			{	
				return intEducation;
			}
			set
			{				 
				intEducation = value;
			}
		}
		public int Employeement
		{  
			get
			{	
				return intEmployeement;
			}
			set
			{				 
				intEmployeement = value;
			}
		}

		public int MediumInstructions
		{  
			get
			{	
				return intMediumInstructions;
			}
			set
			{				 
				intMediumInstructions = value;
			}
		}

		public string FormCode
		{  
			get
			{	
				return strFormCode;
			}
			set
			{				 
				strFormCode = value;
			}
		}
		
		public int Listening
		{  
			get
			{	
				return intListening;
			}
			set
			{				 
				intListening = value;
			}
		}

		public int Speaking
		{  
			get
			{	
				return intSpeaking;
			}
			set
			{				 
				intSpeaking = value;
			}
		}
		public int Writing
		{  
			get
			{	
				return intWriting;
			}
			set
			{				 
				intWriting = value;
			}
		}


		public int Analytical
		{  
			get
			{	
				return intAnalytical;
			}
			set
			{				 
				intAnalytical = value;
			}
		}

		public string Group
		{  
			get
			{	
				return strGroup;
			}
			set
			{				 
				strGroup = value;
			}
		}


//		public BLScoreCard()
//		{
//			//
//			// TODO: Add constructor logic here
//			//			 
//		}

		public void InsertScore()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(11);
				dbManager.AddParameters(0,"@RegistrationId",RegistrationId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@Speaking",Speaking,ParameterDirection.Input);
				dbManager.AddParameters(2,"@Listening",Listening,ParameterDirection.Input);
				dbManager.AddParameters(3,"@Writing",Writing,ParameterDirection.Input);
				dbManager.AddParameters(4,"@Analytical",Analytical,ParameterDirection.Input);
				dbManager.AddParameters(5,"@StateId",StateId,ParameterDirection.Input);
				dbManager.AddParameters(6,"@CentreCode",TestCentreCode,ParameterDirection.Input);
				dbManager.AddParameters(7,"@AdminDate",AdminDOB,ParameterDirection.Input);
				dbManager.AddParameters(8,"@MediumInstruction",MediumInstructions,ParameterDirection.Input);
				dbManager.AddParameters(9,"@FormCode",FormCode,ParameterDirection.Input);
				dbManager.AddParameters(10,"@GroupName",Group,ParameterDirection.Input);
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddScore");
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

//		public DataSet GenerateScoreCard(string RegId)
//		{
//			try
//			{
//				DataAccessLayer.DBConnection objDb=new DBConnection();
//				string Con=objDb.GetConnectionString(); 
//				dbManager.ConnectionString =Con.ToString();
//				dbManager.Open();				 
//				dbManager.CreateParameters(1);
//				dbManager.AddParameters(0, "@RegistrationId", RegId);
//			    return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetScoreCardDetails");
//			 
//				
//			}
//			catch (Exception SysEx)
//			{
//				throw SysEx;
//			}
//			finally
//			{
//				dbManager.Close(); 
//				dbManager.Dispose(); 
//			}
//		}

		public DataSet GenerateScoreCard(string RegId)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", RegId);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetScoreCardDetails");
			 
				
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

		public bool ValidateScoreForState(int intStateId)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@StateId", intStateId);					 
				return Convert.ToBoolean(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"ValidateScoreForState"));			 
				
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

		 

		public string GetResonOfRejection(int intStateId)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@StateId", intStateId);					 
				return Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetResonOfRejection"));			 
				
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
		 

		public int CheckForApproval(int intStateId, int intUserId)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0, "@StateId", intStateId);	
				dbManager.AddParameters(1, "@UserId", intUserId);	
				return Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"CheckForApproval"));			 
				
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



	public DataTable GenerateMultipleScoreCardforJobCard(string strItemList)
	{
		try
		{
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			dbManager.ConnectionString =Con.ToString();
			dbManager.Open();
			dbManager.CreateParameters(1);
			dbManager.AddParameters(0, "@ItemList", strItemList);			
			return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleJobFairCardDetails").Tables[0];
			 
				
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

		public DataTable GenerateMultipleScoreCardforJobCard_MT(string strItemList)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@ItemList", strItemList);			
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleJobFairCardDetails_MT").Tables[0];
			 
				
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
		public DataTable GenerateMultipleScoreCard(string strItemList)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@ItemList", strItemList);			
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"[GetMultipleScoreCardDetailsPercentage_MTFormat]").Tables[0];
			 
				
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


		public DataTable GenerateMultipleScoreCard_MTFormat(string strItemList)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@ItemList", strItemList);			
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleScoreCardDetailsPercentage_MTFormat").Tables[0];
			 
				
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
		
	}
}
