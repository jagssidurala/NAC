using System;
using DataBaseAccessLayer;
using DataAccessLayer;
using System.Data;  
using Common;
using System.Data.SqlClient;
using ExceptionHandling;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLLogin.
	/// </summary>
	public class BLLogin
	{
		//Creating object of IDBManager for making connection, creating parameter and executing commands
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		//Checking existing users in database on behalf of Photo ID, Photo Number and Password
        public DataSet ValidateUserCredential(string strPhotoId, string strDocumentNo, string strPassword, string strRegistrationID)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			dbManager.ConnectionString =Con.ToString();
			DataSet ds = new DataSet();
			try
			{
				dbManager.Open();
				dbManager.CreateParameters(4);
				dbManager.AddParameters(0,"@DocumentID",strPhotoId,ParameterDirection.Input);			//Photo ID
				dbManager.AddParameters(1,"@DocumentNo",strDocumentNo,ParameterDirection.Input);		//Photo Number
				dbManager.AddParameters(2,"@Password",strPassword,ParameterDirection.Input);			//Password
                dbManager.AddParameters(3, "@NACRegID", strRegistrationID, ParameterDirection.Input);   //Reg ID
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ValidateNACUser");
				return ds;
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

		//Validating the existence of PIN and SerialNo
		public DataSet ValidatePin(string strSerialNo,string PinNo)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			try
			{
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				DataSet ds = new DataSet();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@SerialNo",strSerialNo,ParameterDirection.Input);			//Seriaslno
				dbManager.AddParameters(1,"@PINNo",PinNo,ParameterDirection.Input);		//PINNo
						
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ValidatePIN");
				return ds;
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



		public DataSet GetStateDetail(string strStateName)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			try
			{
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@StateName",strStateName,ParameterDirection.Input);				 
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetStateDetail");
				 
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}

		}


		//Checking existing users in database on behalf of Photo ID, Photo Number and Password
		public DataSet ValidateAdminCredential(string strUserName,string strPassword)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			try
			{
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				DataSet ds = new DataSet();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@UserName",strUserName,ParameterDirection.Input);		
				dbManager.AddParameters(1,"@Password",strPassword,ParameterDirection.Input);
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ValidateAdminUser");
				return ds;
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
		//Fetching Registration ID/User ID on behalf of First Name, last name, Mother's Name and Date of birth
		public DataSet FetchForgotPassword(string strFirstName, string strLastName, string strMotherName, DateTime dtDOB)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string strConn = objDb.GetConnectionString();
			DataSet ds = new DataSet();
			try
			{
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(4);
				dbManager.AddParameters(0,"@FNAME",strFirstName,ParameterDirection.Input);						//First Name
				dbManager.AddParameters(1,"@LNAME",strLastName,ParameterDirection.Input);						//Last Name
				dbManager.AddParameters(2,"@MOTHERNAME",strMotherName,ParameterDirection.Input);				//Mother's Name
				dbManager.AddParameters(3,"@DateOFBirth",dtDOB,ParameterDirection.Input);						//Date of birth
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ForgotUserPassword");
				return ds;
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

		//Fetching Password on behalf of 
		public DataSet ValidateUserForPassword(string strRegistrationID, int valPhotoID, string strPhotoNumber)
		{
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string strConn = objDb.GetConnectionString();
			DataSet ds = new DataSet();
			try
			{
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@REGID",strRegistrationID,ParameterDirection.Input);
				dbManager.AddParameters(1,"@PhotoID",valPhotoID,ParameterDirection.Input);
				dbManager.AddParameters(2,"@PhotoNumber",strPhotoNumber,ParameterDirection.Input);
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"FetchPassword");	
				return ds;
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

		//Fetch welcome body text

		public string GetWelcomebodyText(int intUserType, int intStateId)
		{
			string strWelcomebodyText = null;
			try
			{

				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@UserType",intUserType,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@StateId",intStateId,ParameterDirection.Input);				 
									 
				strWelcomebodyText = Convert.ToString(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetWelcomeBodyText"));				 
				 
			 
				return strWelcomebodyText;
			}
			catch
			{
				 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	
		}

		public DataSet CheckStatus(int stateId,string strSerialNo,string PinNo)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			try
			{
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				DataSet ds = new DataSet();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@StateId",stateId,ParameterDirection.Input);			//StateId
				dbManager.AddParameters(1,"@SerialNo",strSerialNo,ParameterDirection.Input);			//Seriaslno
				dbManager.AddParameters(2,"@PINNo",PinNo,ParameterDirection.Input);		//PINNo
						
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStatus");
				return ds;
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
	}
}
