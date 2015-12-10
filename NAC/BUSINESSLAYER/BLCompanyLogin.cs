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
	/// Summary description for BLCompanyLogin.
	/// </summary>
	public class BLCompanyLogin
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		public BLCompanyLogin()
		{
		}

		private string loginId;
		public string LoginId
		{
			get
			{
				return loginId;
			}
			set
			{
				loginId = value;
			}
		}

		private string newPassword;
		public string NewPassword
		{
			get
			{
				return newPassword;
			}
			set
			{
				newPassword = value;
			}
		}
		
		private string password;
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
			}
		}

		private string rejectReason;
		public string RejectReason
		{
			get
			{
				return rejectReason;
			}
			set
			{
				rejectReason = value;
			}
		}

		private DateTime agreementExpiryDate;
		public DateTime AgreementExpiryDate
		{
			get
			{
				return agreementExpiryDate;
			}
			set
			{
				agreementExpiryDate = value;
			}
		}

		private int companyId;
		public int CompanyId
		{
			get
			{
				return companyId;
			}
			set
			{
				companyId = value;
			}
		}

		private int status;
		public int Status
		{
			get
			{
				return status;
			}
			set
			{
				if(status < 3 && status > -1)
				{
					status = value;
				}
				else
				{
					status = -1;
				}
			}
		}
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		
		private string companyName;
		public string CompanyName
		{
			get
			{
				return companyName;
			}
			set
			{
				companyName = value;
			}
		}
		
		private string companyAddress;
		public string CompanyAddress
		{
			get
			{
				return companyAddress;
			}
			set
			{
				companyAddress = value;
			}
		}
		private string officialPhone;
		public string OfficialPhone
		{
			get
			{
				return officialPhone;
			}
			set
			{
				officialPhone = value;
			}
		}
		private string companySPOCName;
		public string CompanySPOCName
		{
			get
			{
				return companySPOCName;
			}
			set
			{
				companySPOCName = value;
			}
		}
		private string companySPOCPhone;
		public string CompanySPOCPhone
		{
			get
			{
				return companySPOCPhone;
			}
			set
			{
				companySPOCPhone = value;
			}
		}
		private string companySPOCEmail;
		public string CompanySPOCEmail
		{
			get
			{
				return companySPOCEmail;
			}
			set
			{
				companySPOCEmail = value;
			}
		}

		
		public DataSet AddMember()
		{
			try
			{
				DataSet dsAddMemberStatus = new DataSet();
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(6);		//Number of parameters to be passed in StoredProcedure				
				dbManager.AddParameters(0,"@CompanyName",CompanyName,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CompanyAddress",CompanyAddress,ParameterDirection.Input);
				dbManager.AddParameters(2,"@OfficialPhone",OfficialPhone,ParameterDirection.Input);
				dbManager.AddParameters(3,"@CompanySPOCName",CompanySPOCName,ParameterDirection.Input);
				dbManager.AddParameters(4,"@CompanySPOCPhone",CompanySPOCPhone,ParameterDirection.Input);
				dbManager.AddParameters(5,"@CompanySPOCEmail",CompanySPOCEmail,ParameterDirection.Input);
				dsAddMemberStatus = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"AddCompanyInfo");		
				return dsAddMemberStatus;
			}
			catch(Exception SysEx)
			{
				throw;
			}
			finally
			{
				dbManager.CommitTransaction();
				if(dbManager != null)
				{
					dbManager.Close();
					dbManager.Dispose();
				}
			}
		}

		public DataSet GetMembersByStatus()
		{
			try
			{
				DataSet dsApprovedMembers = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0, "@Status", Status);
				dsApprovedMembers =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCompanyDetailByStatus");
				return dsApprovedMembers;
				
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

		public DataSet GetCompanyDetailById()
		{
			try
			{
				DataSet dsApprovedMembers = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0, "@CompanyId", CompanyId);
				dsApprovedMembers =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCompanyDetailById");
				return dsApprovedMembers;
				
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

		public DataSet UpdateCompanyStatus()
		{
			try
			{
				DataSet dsUpdateStatus = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				if(Status == 1)
				{
					dbManager.CreateParameters(3);
					dbManager.AddParameters(0, "@CompanyId", CompanyId);
					dbManager.AddParameters(1, "@Status", Status);
					dbManager.AddParameters(2, "@AgreementExpiryDate", AgreementExpiryDate);
				}
				else if(Status == 2)
				{
					dbManager.CreateParameters(3);
					dbManager.AddParameters(0, "@CompanyId", CompanyId);
					dbManager.AddParameters(1, "@Status", Status);
					dbManager.AddParameters(2, "@RejectReason", RejectReason);
				}
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dsUpdateStatus = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"UpdateCompanyStatus");
				return dsUpdateStatus;
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet GenerateLoginDetail()
		{
			try
			{
				DataSet dsUpdateStatus = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@CompanyId", CompanyId);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dsUpdateStatus = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GenerateLoginPassword");
				return dsUpdateStatus;
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet ValidateCompanyLogin()
		{
			try
			{
				DataSet dsUpdateStatus = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0, "@LoginId", LoginId);
				dbManager.AddParameters(1, "@Password", Password);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dsUpdateStatus = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ValidateCompany");
				return dsUpdateStatus;
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet ChangeCompanyPassword()
		{
			try
			{
				DataSet dsChangePassword = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(3);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0, "@CompanyId", CompanyId);
				dbManager.AddParameters(1, "@Password", Password);
				dbManager.AddParameters(2, "@NewPassword", NewPassword);
				dsChangePassword = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ChangeCompanyPassword");
				return dsChangePassword;
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet GetCompanyLoginDetail()
		{
			try
			{
				DataSet dsCompanyLoginDetail = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(3);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0, "@CompanyName", CompanyName);
				dbManager.AddParameters(1, "@CompanySPOCName",CompanySPOCName);
				dbManager.AddParameters(2, "@CompanySPOCEmail", CompanySPOCEmail);
				dsCompanyLoginDetail = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCompanyLoginDetail");
				return dsCompanyLoginDetail;
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet UpdateCompanyDetail()
		{
			try
			{
				DataSet dsCompanyLoginDetail = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(9);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0,"@CompanyName",CompanyName,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CompanyAddress",CompanyAddress,ParameterDirection.Input);
				dbManager.AddParameters(2,"@OfficialPhone",OfficialPhone,ParameterDirection.Input);
				dbManager.AddParameters(3,"@CompanySPOCName",CompanySPOCName,ParameterDirection.Input);
				dbManager.AddParameters(4,"@CompanySPOCPhone",CompanySPOCPhone,ParameterDirection.Input);
				dbManager.AddParameters(5,"@CompanySPOCEmail",CompanySPOCEmail,ParameterDirection.Input);
				dbManager.AddParameters(6,"@FlagUpdate",1,ParameterDirection.Input);
				dbManager.AddParameters(7,"@AgreementExpiryDate",AgreementExpiryDate,ParameterDirection.Input);
				dbManager.AddParameters(8,"@CompanyId",CompanyId,ParameterDirection.Input);
				dsCompanyLoginDetail = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"AddCompanyInfo");
				return dsCompanyLoginDetail;
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}


		public bool IsCompanyPasswordValid()
		{
			try
			{
				int IsPasswordValid = 0;
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.AddParameters(0,"@Password",Password,ParameterDirection.Input);
				IsPasswordValid = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"IsCompanyPasswordValid"));
				if(IsPasswordValid >0)
					return true;
				else
					return false;

			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.CommitTransaction();
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public string base64Encode(string sData)
		{
			try
			{
				byte[] encData_byte = new byte[sData.Length];
				encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
				string encodedData = Convert.ToBase64String(encData_byte);
				return encodedData;
			}
			catch(Exception ex)
			{
				throw new Exception("Error in base64Encode" + ex.Message);
			}
		}

		public string base64Decode(string sData)
		{
			System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
			System.Text.Decoder utf8Decode = encoder.GetDecoder();
			byte[] todecode_byte = Convert.FromBase64String(sData);
			int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
			char[] decoded_char = new char[charCount];
			utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
			string result = new String(decoded_char);return result;
		}

	}
}
