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
	/// Summary description for BLTest.
	/// </summary>
	public class BLTest
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		
		private string strTestCity;
		private string strTestCentre;
		private string strTestState;
		private string strTestDate;
		private string strTestTime;
		private DateTime testDate;
		private DateTime testTime;
		private DateTime regStartDate;
		private DateTime regEndDate;
		private string strTestName;
		private bool isShiftTime;
		private int intTestType;
		private int intTestCity;
		private int intTestCentre;
		private int intTestState;
		private int intTestCapacity;
		 

		 


		public BLTest()
		{
			//
			// TODO: Add constructor logic here
			//

		}
		public int TestStateId
		{
			get
			{	
				return intTestState;
			}
			set
			{				 
				intTestState = value;
			}
		}

		public int TestCityId
		{
		
			get
			{	
				return intTestCity;
			}
			set
			{				 
				intTestCity = value;
			}
		
		}
		public string TestCity
		{
		
			get
			{	
				return strTestCity;
			}
			set
			{				 
				strTestCity = value;
			}
		
		}
		public string TestCentre
		{
		
			get
			{	
				return strTestCentre;
			}
			set
			{				 
				strTestCentre = value;
			}
		
		}
		public string TestState
		{
		
			get
			{	
				return strTestState;
			}
			set
			{				 
				strTestState = value;
			}
		
		}
		public string TestDate
		{
		
			get
			{	
				return strTestDate;
			}
			set
			{				 
				strTestDate = value;
			}
		
		}
		public string TestTime
		{
		
			get
			{	
				return strTestTime;
			}
			set
			{				 
				strTestTime = value;
			}
		
		}
 
		
		public DateTime TestTimedt
		{
		
			get
			{	
				return testTime;
			}
			set
			{				 
				testTime = value;
			}
		} 

		public int TestCentreId
		{
			get
			{	
				return intTestCentre;
			}
			set
			{				 
				intTestCentre = value;
			}
		} 
		
		public string TestName
		{
		
			get
			{	
				return strTestName;
			}
			set
			{				 
				strTestName = value;
			}
		} 

		public DateTime TestDatedt
		{
			get
			{	
				return testDate;
			}
			set
			{				 
				testDate = value;
			}
		} 

		public DateTime RegEndDate
		{
			get
			{	
				return regEndDate;
			}
			set
			{				 
				regEndDate = value;
			}
		} 

		public DateTime RegStartDate
		{
			get
			{	
				return regStartDate;
			}
			set
			{				 
				regStartDate = value;
			}
		} 

		public bool IsShiftTime
		{
			get
			{	
				return isShiftTime;
			}
			set
			{				 
				isShiftTime = value;
			}
		} 

		public int TestType
		{
			get
			{	
				return intTestType;
			}
			set
			{				 
				intTestType = value;
			}
		} 

		public int TestCapacity
		{
			get
			{	
				return intTestCapacity;
			}
			set
			{				 
				intTestCapacity = value;
			}
		} 

	 
		public int SetTestDetail()
		{
		 
			int intCheck = 0;
			try
			{

				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(5);
				dbManager.AddParameters(0,"@TestCentre",TestCentre,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@TestCity",TestCity,ParameterDirection.Input);
				dbManager.AddParameters(2,"@TestState",TestState,ParameterDirection.Input);
				dbManager.AddParameters(3,"@TestDate",TestDate,ParameterDirection.Input);
				dbManager.AddParameters(4,"@TestTime",TestTime,ParameterDirection.Input);
									 
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"AddTest"));				 
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
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
				 
		}

		public int CreateTest()
		{
		 
			int intCheck = 0;
			try
			{

				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(11);
				dbManager.AddParameters(0,"@TestType",TestType,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@TestCentre",TestCentreId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@TestCity",TestCityId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@TestState",TestStateId,ParameterDirection.Input);
				dbManager.AddParameters(4,"@TestDate",TestDatedt,ParameterDirection.Input);
				dbManager.AddParameters(5,"@TestTime",TestTimedt,ParameterDirection.Input);				
				dbManager.AddParameters(6,"@TestName",TestName,ParameterDirection.Input);
				dbManager.AddParameters(7,"@RegStartDate",RegStartDate,ParameterDirection.Input);
				dbManager.AddParameters(8,"@RegEndDate",RegEndDate,ParameterDirection.Input);
				dbManager.AddParameters(9,"@IsShiftTime",IsShiftTime,ParameterDirection.Input);
				dbManager.AddParameters(10,"@TestCapacity",TestCapacity,ParameterDirection.Input);
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"AddTest"));				 
				dbManager.CommitTransaction();
				dbManager.Close();
				return intCheck;
			}
			catch(Exception ex)
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
				 
		}


		public string GetWelcomeBodyText(int intUserType, int intStateId, string strTestName)
		{
		 
			 
			try
			{
				 
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				 
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@UserType",intUserType,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@StateId",intStateId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@TestName",strTestName,ParameterDirection.Input);
				 
									 
				return Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetWelcomeBodyText"));				 
				 
				 
				 
			}
			catch
			{
				 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
				 
		}

		public string GetTestCentreID(int intCityId)
		{
		 
			 
			try
			{
				 
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@CityId",intCityId,ParameterDirection.Input);			
				 
									 
				return Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetTestCentreID"));				 
				 
				 
				 
			}
			catch
			{
				 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
				 
		}

		public string GetTestCentreName(int intCityId)
		{
		 
			 
			try
			{
				 
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@CityId",intCityId,ParameterDirection.Input);			
				 
									 
				return Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetTestCentreName"));				 
				 
				 
				 
			}
			catch
			{
				 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
				 
		}

		public int GetRequestStatus()
		{
			try
			{
				 
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();	 
				return Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetRequestStatus"));				 
			}
			catch
			{
				 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void SetWelcomeBodyText(int intUserType, string strWelcomeBodyText, int intStateId,string strTestName)
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
				dbManager.CreateParameters(4);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@UserType",intUserType,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@WelcomeBodyText",strWelcomeBodyText,ParameterDirection.Input);
				dbManager.AddParameters(2,"@StateId",intStateId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@TestName",strTestName,ParameterDirection.Input);
				
				//Executing Command and storing Registrationid as Output Parameter in strRegistrationId
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"SetWelcomeBodyText");				 
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

		public DataTable FillStates()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();	
			 
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllStates").Tables[0]);				 
				 
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				dbManager.Close();
			}
		}

		public DataSet PreAllocatedCentre(int intSerialNo, string strPinNo, string strState)
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(3);

				dbManager.AddParameters(0, "@SerialNo", intSerialNo);
				dbManager.AddParameters(1, "@PinNo", strPinNo);	
				dbManager.AddParameters(2, "@State", strState);	
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetPreAllocatedCentre"));				 
				 
			}
			catch(Exception ex)
			{
				dbManager.Close();
				dbManager.Dispose();
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
