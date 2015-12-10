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
	/// Summary description for BLWSCandidateAuthentication.
	/// </summary>
	public class BLWSCandidateAuthentication
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private CandidateAuthenticationRequest req = new CandidateAuthenticationRequest();
		private CandidateAuthenticationResponse res = new CandidateAuthenticationResponse();
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
			

		public CandidateAuthenticationRequest AuthenticationRequest
		{  
			get{return req;}
			set{req = value;}
		}		
		public CandidateAuthenticationResponse AuthenticationResponse
		{  
			get{return res;}
			set{res = value;}
		}
		
		public BLWSCandidateAuthentication()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region AuthenticateCandidateDetails
		public  CandidateAuthenticationResponse AuthenticateCandidateDetails(CandidateAuthenticationRequest Req)
		{
			try
			{				 
				res.RegistrationId=Req.RegistrationId;
				res.FirstName=Req.FirstName;
				res.LastName=Req.LastName;
				res.DOB=Req.DOB;

				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(4);			
				dbManager.AddParameters(0, "@FirstName", Req.FirstName);
				dbManager.AddParameters(1, "@LastName", Req.LastName);
				dbManager.AddParameters(2, "@RegistrationId", Req.RegistrationId);
				dbManager.AddParameters(3, "@Dob", Req.DOB);
				DataSet dsTestDetails = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"WSVALIDATECANDIDATEDETAILSV2");
				dbManager.CommitTransaction();
				
				
				if (dsTestDetails.Tables[0].Rows.Count > 0)
				{
					res.Response.ResponseID="1";
					res.Response.Message="OK";
					res.Response.TestCentre=Convert.ToString(dsTestDetails.Tables[0].Rows[0]["CITY"]);
					res.Response.TestDate=Convert.ToDateTime(dsTestDetails.Tables[0].Rows[0]["TESTDATE"]).ToShortDateString().ToString();

				}
				else
				{
					res.Response.ResponseID="0";
					res.Response.Message="NOK-Incorrect credentials";
					res.Response.TestCentre="";
					res.Response.TestDate="";
				}
				return res;
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

	public class CandidateAuthenticationRequest
	{
		private string strFirstName;
		private string strLastName;
		private string strRegistrationId;	
		private string dtDOB="blank";			
		
	
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}	

		public string FirstName
		{  
			get{
			
				return strFirstName;}
			set{strFirstName = value;}
			
		}		
		public string LastName
		{  
			get{return strLastName;}
			set{strLastName = value;}
		}
		
		public string DOB
		{
			get{return dtDOB;}
			set{dtDOB=value;}
		}


		
	}

	public class CandidateAuthenticationResponse
	{
		private string strFirstName ;
		private string strLastName;
		private string strRegistrationId;	
		private string dtDOB;	
		private ResponseMessage rmResponse=new ResponseMessage();
		
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}		
		
		public string FirstName
		{  
			get{return strFirstName;}
			set
			{strFirstName = value;}
				
		}		
		public string LastName
		{  
			get{return strLastName;}
			set{strLastName = value;}
		}
		
	
		public string DOB
		{
			get{return dtDOB;}
			set{dtDOB=value;}
		}

		public ResponseMessage Response
		{
			get{return rmResponse;}
			set{rmResponse=value;}
		}


		
	}

	 public class ResponseMessage
	{
		private string strResponseId;
		private string strResponseMessage;
		private string strTestCentre;
		private string strTestDate;	 
			
		
		public string ResponseID
		{  
			get{return strResponseId;}
			set{strResponseId = value;}
		}		
		public string Message
		{  
			get{return strResponseMessage;}
			set{strResponseMessage = value;}
		}

		 public string TestCentre
		 {  
			 get{return strTestCentre;}
			 set{strTestCentre = value;}
		 }		
		 public string TestDate
		 {  
			 get{return strTestDate;}
			 set{strTestDate = value;}
		 }


						
	}

}


