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
	/// Summary description for BLWSCandidateDetail.
	/// </summary>
	public class BLWSCandidateDetail
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		private string strFirstName;
		private string strLastName;
		private string strRegistrationId;	
		private DateTime dtDOB;		
		

		public string FirstName
		{  
			get{return strFirstName;}
			set{strFirstName = value;}
		}		
		public string LastName
		{  
			get{return strLastName;}
			set{strLastName = value;}
		}
		
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}		

		public DateTime Dob
		{
			get{return dtDOB;}
			set{dtDOB=value;}
		}

		#region getCandidateDetails()

		public DataSet getCandidateDetails()
		{
			try
			{				 
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(4);
				

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@RegistrationId", RegistrationId);
				dbManager.AddParameters(3, "@Dob", Dob);
			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"WSGetCandidateDetails"));				 
				 
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


		#endregion 

		#region ValidateCandidateDetails
		public int ValidateCandidateDetails()
		{
			try
			{				 
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(4);			
				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@RegistrationId", RegistrationId);
				dbManager.AddParameters(3, "@Dob", Dob);
				return (Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"WSVALIDATECANDIDATEDETAILS")));				 
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
		#endregion
	}
}
