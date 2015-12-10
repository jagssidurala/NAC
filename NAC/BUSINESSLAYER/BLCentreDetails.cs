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
	/// Summary description for BLCentreDetails.
	/// </summary>
	public class BLCentreDetails
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);

		private string strStateId;
		private string strCityId;
		private string strState;
		private string strStateCode;
		private string strCityName;
		private string strCityCode;
		private string strUploadLogo;
		private string strETSAccess;
		private string strFlag;
		private string strConn;	
		
		private string strCentreId;
		private string strTestId;
		private string strCentre;
		private string strCentreCapacity;
		private string strCentreCode;
		private string strCentreAddress;
		// Start: added by Ankit
		private DateTime dtRegisterationStartDate;
		private DateTime dtRegisterationEndDate;
		private DateTime dtTestDate;
		private DateTime dtResultDeclarationDate;
		private string strEventComments;
		// End: added by Ankit
		private DataAccessLayer.DBConnection conn;


	

		public string StateId
		{  
			get
			{	
				return strStateId;
			}
			set
			{				 
				strStateId = value;
			}
		}	

		public string State
		{  
			get
			{	
				return strState;
			}
			set
			{				 
				strState = value;
			}
		}	

		public string StateCode
		{  
			get
			{	
				return strStateCode;
			}
			set
			{				 
				strStateCode = value;
			}
		}	
		public string UploadLogo
		{  
			get
			{	
				return strUploadLogo;
			}
			set
			{				 
				strUploadLogo = value;
			}
		}

		public string ETSAccess
		{  
			get
			{	
				return strETSAccess;
			}
			set
			{				 
				strETSAccess = value;
			}
		}
		public string Flag
		{  
			get
			{	
				return strFlag;
			}
			set
			{				 
				strFlag = value;
			}
		}

		public string CityId
		{  
			get
			{	
				return strCityId;
			}
			set
			{				 
				strCityId = value;
			}
		}	

		
		public string CityCode
		{  
			get
			{	
				return strCityCode;
			}
			set
			{				 
				strCityCode = value;
			}
		}	

		public string CityName
		{  
			get
			{	
				return strCityName;
			}
			set
			{				 
				strCityName = value;
			}
		}	

		public string CentreId
		{  
			get
			{	
				return strCentreId;
			}
			set
			{				 
				strCentreId = value;
			}
		}	
		
		
		public string Centre
		{  
			get
			{	
				return strCentre;
			}
			set
			{				 
				strCentre = value;
			}
		}	
		
		
		public string  CentreCapacity
		{  
			get
			{	
				return strCentreCapacity;
			}
			set
			{				 
				strCentreCapacity = value;
			}
		}	
		
		
		public string  CentreCode
		{  
			get
			{	
				return strCentreCode;
			}
			set
			{				 
				strCentreCode = value;
			}
		}	
		
		public string  CentreAddress
		{  
			get
			{	
				return strCentreAddress;
			}
			set
			{				 
				strCentreAddress = value;
			}
		}	

		public string TestId
		{  
			get
			{	
				return strTestId;
			}
			set
			{				 
				strTestId = value;
			}
		}	
		public DateTime RegisterationStartDate
		{  
			get
			{	
				return dtRegisterationStartDate;
			}
			set
			{				 
				dtRegisterationStartDate = value;
			}
		}	
		public DateTime RegisterationEndDate
		{  
			get
			{	
				return dtRegisterationEndDate;
			}
			set
			{				 
				dtRegisterationEndDate = value;
			}
		}	
		public DateTime TestDate
		{  
			get
			{	
				return dtTestDate;
			}
			set
			{				 
				dtTestDate = value;
			}
		}	
		public DateTime ResultDeclarationDate
		{  
			get
			{	
				return dtResultDeclarationDate;
			}
			set
			{				 
				dtResultDeclarationDate = value;
			}
		}	
		public string EventComments
		{  
			get
			{	
				return strEventComments;
			}
			set
			{				 
				strEventComments = value;
			}
		}	

		
		//Updating State details
		public void UpdateStateDetail()
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
				dbManager.CreateParameters(6);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@StateName",State,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@StateCode",StateCode,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StateLogo",UploadLogo,ParameterDirection.Input);
				dbManager.AddParameters(3,"@ETSAccess",ETSAccess,ParameterDirection.Input);
				dbManager.AddParameters(4,"@Flag",Flag,ParameterDirection.Input);
				dbManager.AddParameters(5,"@StateId",StateId,ParameterDirection.Input);
				
					
				//Executing Command and storing Registrationid as Output Parameter in strRegistrationId
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddState");				
				dbManager.CommitTransaction();
				dbManager.Close();
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


		public DataTable  FillTestAgainstCentre()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				
				dbManager.AddParameters(0,"@CentreId", CentreId,ParameterDirection.Input);
				
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestAgainstCentre").Tables[0];
				 
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

		public DataTable  FillShiftTimeAgainstTest()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				
				dbManager.AddParameters(0,"@TestId", TestId,ParameterDirection.Input);
				
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetShiftTimeAgainstTest").Tables[0];
				 
			}
			catch(Exception SysEx)
			{
				throw;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		//Get State details
		public DataTable GetCentreDetails()
		{
		 
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure
				
				dbManager.AddParameters(0,"@StateId",StateId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCentreDetails").Tables[0];
				
				
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
	
		//Get State details
		public DataTable GetStateDetails()
		{
		 
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure
				
				dbManager.AddParameters(0,"@StateId",StateId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetStateDetails").Tables[0];
				
				
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

		//Get City details
		public DataTable GetCityDetails_CityId()
		{
		 
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@CityId",CityId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCityDetail_CityId").Tables[0];				
				
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
		
		
		//Get Centre details
		/// <summary>
		/// Gets the centre details.
		/// </summary>
		/// <returns></returns>
		public DataTable GetCentreDetails_CentreId()
		{
		 
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@CentreId",CentreId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCentreDetail_CentreId").Tables[0];				
				
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



		//Updating City details
		public void UpdateCityDetail()
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
				dbManager.CreateParameters(5);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@StateId",StateId ,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@CityCode",CityCode,ParameterDirection.Input);
				dbManager.AddParameters(2,"@CityName",CityName,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@Flag","update",ParameterDirection.Input);	
				dbManager.AddParameters(4,"@CityId",CityId,ParameterDirection.Input);	
				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddCity");				
				dbManager.CommitTransaction();
				dbManager.Close();
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



		//Updating Centre details
		public void UpdateCentreDetail()
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
				dbManager.CreateParameters(7);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@Centre",Centre,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@Capacity",CentreCapacity,ParameterDirection.Input);
				dbManager.AddParameters(2,"@CentreCode",CentreCode,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@Flag","update",ParameterDirection.Input);	
				dbManager.AddParameters(4,"@CityId",CityId,ParameterDirection.Input);	
				dbManager.AddParameters(5,"@CentreAddress",CentreAddress,ParameterDirection.Input);		
				dbManager.AddParameters(6,"@CentreId",CentreId,ParameterDirection.Input);				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddCentre");				
				dbManager.CommitTransaction();
				dbManager.Close();
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

		//For populating Event Description on the basis of state selection in manage events
		public DataTable GetCentreAddress()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure
				
				dbManager.AddParameters(0,"@State",StateId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetActiveEventWithAddress").Tables[0];
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

		public void UpdateEvent()
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
				dbManager.CreateParameters(6);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@TestId",TestId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationStartDate",RegisterationStartDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@RegistrationEndDate",RegisterationEndDate,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@TestDate",TestDate,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@ResultDate",ResultDeclarationDate,ParameterDirection.Input);	
				dbManager.AddParameters(5,"@Comments",EventComments,ParameterDirection.Input);		
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"UpdateEvent");				
				dbManager.CommitTransaction();
				dbManager.Close();
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
		public int InsertEvents()
		{
			int intCheck = 0;
			try
			{
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(6);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@TestId",TestId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationStartDate",RegisterationStartDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@RegistrationEndDate",RegisterationEndDate,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@TestDate",TestDate,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@ResultDate",ResultDeclarationDate,ParameterDirection.Input);	
				dbManager.AddParameters(5,"@Comments",EventComments,ParameterDirection.Input);		
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"InsertEvents"));				
				dbManager.CommitTransaction();
				dbManager.Close();
				return intCheck;
			}
			catch
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
		}
		//Get Event details
		public DataSet GetEventDetails(int TestId)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@TestId", TestId);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetEventDetails");
			 
				
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

		//Creating new City 
		public void CreateCity()
		{
			try
			{
                int CityId = 0;
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(5);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@StateId",StateId ,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@CityName",CityName,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@CityCode",CityCode,ParameterDirection.Input);
				dbManager.AddParameters(3,"@Flag","insert",ParameterDirection.Input);
                dbManager.AddParameters(4, "@CityId", CityId, ParameterDirection.Input);	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddCity");				
				dbManager.CommitTransaction();
				dbManager.Close();
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

		public int DeleteCity()
		{
			try
			{
				int output=0;
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(1);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@CityId",CityId,ParameterDirection.Input);
				output = dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"DeleteCity");				
				dbManager.CommitTransaction();
				dbManager.Close();
				return output;
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				//ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				return 0;
			}			 
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}  
		}

		//Create New Centre 
		public void CreateCentre()
		{
		 
			try
			{
                int CentreId = 0;
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(7);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@CityId",CityId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@Centre",Centre,ParameterDirection.Input);				
				dbManager.AddParameters(2,"@CentreAddress",CentreAddress,ParameterDirection.Input);
				dbManager.AddParameters(3,"@Capacity",CentreCapacity,ParameterDirection.Input);
				dbManager.AddParameters(4,"@CentreCode",CentreCode,ParameterDirection.Input);		
				dbManager.AddParameters(5,"@Flag","insert",ParameterDirection.Input);
                dbManager.AddParameters(6, "@CentreId", CentreId, ParameterDirection.Input);	
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddCentre");				
				dbManager.CommitTransaction();
				dbManager.Close();
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

	}
}
