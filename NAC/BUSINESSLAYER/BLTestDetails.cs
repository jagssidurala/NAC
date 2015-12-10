using System; 
using System.Collections;
using System.Text;
using System.Data; 
using DataAccessLayer;
using DataBaseAccessLayer;
using System.Web;
using Common;
using System.Data.SqlClient;
using ExceptionHandling;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLTestDetails.
	/// </summary>
	public class  BLTestDetails
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);

		
		private string strTestCentre;
		private DateTime strTestDate;
		private DateTime strTestTime;
		private DateTime strRegistrationDate;
		private string strTestName;
		private string strIsActive;
		private string strIsShiftTime;
		private DataAccessLayer.DBConnection conn;
		private string strConn;	

		private int intTestId;
		private DateTime strShiftTestDate;
		private DateTime strShiftTestTime;
		private int intShiftCapacity;
		private string strIsShiftActive;
		

		public int  TestId
		{  
			get
			{	
				return intTestId;
			}
			set
			{				 
				intTestId = value;
			}
		}	

		public DateTime  ShiftTestDate
		{  
			get
			{	
				return strShiftTestDate;
			}
			set
			{				 
				strShiftTestDate = value;
			}
		}	

		public DateTime  ShiftTestTime
		{  
			get
			{	
				return strShiftTestTime;
			}
			set
			{				 
				strShiftTestTime = value;
			}
		}	

		public string IsShiftActive
		{  
			get
			{	
				return strIsShiftActive;
			}
			set
			{				 
				strIsShiftActive = value;
			}
		}	

		public int  ShiftCapacity
		{  
			get
			{	
				return intShiftCapacity;
			}
			set
			{				 
				intShiftCapacity = value;
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
		
		
		
		public DateTime TestDate
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
		

		public DateTime RegistrationDate
		{  
			get
			{	
				return strRegistrationDate;
			}
			set
			{				 
				strRegistrationDate = value;
			}
		}	
		public DateTime TestTime
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
		
		
		public string IsActive
		{  
			get
			{	
				return strIsActive;
			}
			set
			{				 
				strIsActive = value;
			}
		}	
		
		public string IsShiftTime
		{  
			get
			{	
				return strIsShiftTime;
			}
			set
			{				 
				strIsShiftTime = value;
			}
		}	

		
		
		//Adding Test Details
		public void AddTestDetail()
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
				dbManager.AddParameters(0,"@TestCentre",TestCentre,ParameterDirection.Input);
				dbManager.AddParameters(1,"@TestDate",TestDate,ParameterDirection.Input);		
				dbManager.AddParameters(2,"@TestTime",TestTime,ParameterDirection.Input);	
				dbManager.AddParameters(3,"@RegistrationDate",RegistrationDate,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@TestName",TestName,ParameterDirection.Input);	
				dbManager.AddParameters(5,"@IsActive",IsActive,ParameterDirection.Input);	
				dbManager.AddParameters(6,"@IsShiftTime",IsShiftTime,ParameterDirection.Input);	
				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddTestDetails");				
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



		public void AddShiftTimeDetail()
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
				dbManager.AddParameters(0,"@TestId",TestId ,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@ShiftTestDate",ShiftTestDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@ShiftTestTime",ShiftTestTime,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@ShiftCapacity",ShiftCapacity,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@IsShiftActive",IsShiftActive,ParameterDirection.Input);	
			
				
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddShiftTimeDetails");				
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
