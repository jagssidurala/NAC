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
	/// Summary description for BLWSCandidateAttendance.
	/// </summary>
	public class BLWSCandidateAttendance
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private CandidateAttendanceRequest req = new CandidateAttendanceRequest();
		private Candidate res = new Candidate();
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		

		public CandidateAttendanceRequest AttendanceRequest
		{  
			get{return req;}
			set{req = value;}
		}		
		public Candidate AttendanceResponse
		{  
			get{return res;}
			set{res = value;}
		}


		#region MarkCandidateAttendance
		public  Candidate MarkCandidateAttendance(CandidateReq Req)
		{
			Candidate CandidateResponse = new Candidate();
			
			try
			{				 
				CandidateResponse.RegistrationId=Req.RegistrationId;
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);			
				dbManager.AddParameters(0, "@RegistrationId", Req.RegistrationId);
				int count = (Convert.ToInt32(dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"WSCandidateAttendance")));				 
				dbManager.CommitTransaction();

				if (count > 0)
				{
					CandidateResponse.ResponseID="1";
					CandidateResponse.Message="OK";
				}
				else
				{
					CandidateResponse.ResponseID="0";
					CandidateResponse.Message="NOK-Incorrect RegistrationId";
				}
				return CandidateResponse;
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

		public BLWSCandidateAttendance()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}

	public class CandidateAttendanceRequest
	{
		private CandidateReq[] strAttendanceList;	
		public CandidateReq[] AttendanceList
		{  
			get{return strAttendanceList;}
			set{strAttendanceList = value;}
		}	
	}

	public class CandidateReq
	{
		private string strRegistrationId;	
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}	
	}



	public class Candidate
	{
		private string strRegistrationId;	
		private string strResponseId;
		private string strResponseMessage;	
		
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}	

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
	}


}
