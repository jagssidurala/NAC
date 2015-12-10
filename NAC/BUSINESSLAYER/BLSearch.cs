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
	/// Summary description for BLSearch.
	/// </summary>
	public class BLSearch
	{

		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		private string strFirstName;
		private string strLastName;
		private string strGender;
		private int intTestState;
		private int intTestCity;
		private string strEmploymentStatus;

		private string strQualification;
		private int strQualificationDetails;
		private string strOtherQualification;
		private string strUniversity;
		private string strCollegeAddress;
		private string strEducationCity;		 

		private int intTestCentre;
		private string strTestName;
		private string strWillingToRelocate;
		private int intSerialNoFrom;
		private int intSerialNoTo;
		private string strRegistrationIDFrom;
		private string strRegistrationIDTo;
		private string strYouBelongTo;
		private string strMediumOfInstruction;
		private string strMediumOfInstructionIn12Th;
		private int intSpeakingFrom;
		private int intSpeakingTo;
		private int intListeningFrom;
		private int intListeningTo;
		private int intWaitingFrom;
		private int intWaitingTo;
		private int intAnalyticalFrom;
		private int intAnalyticalTo;

		private string strResidentialCity;
		private DateTime strDOBFrom;
		private DateTime strDOBTo;

		private int intCurrentPage;
		private int intPageSize;
		private int intUserType;

		private string strCandidateList;

		//private string strTier;
		
		

		public string FirstName
		{  
			get
			{	
				return strFirstName;
			}
			set
			{				 
				strFirstName = value;
			}
		}
		
		public string LastName
		{  
			get
			{	
				return strLastName;
			}
			set
			{				 
				strLastName = value;
			}
		}
		
		public string Gender
		{  
			get
			{	
				return strGender;
			}
			set
			{				 
				strGender = value;
			}
		}
		
		public int TestState
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
		
		public int TestCity
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



		
		
		public string EmploymentStatus
		{  
			get
			{	
				return strEmploymentStatus;
			}
			set
			{				 
				strEmploymentStatus = value;
			}
		}
		
		public string Qualification
		{  
			get
			{	
				return strQualification;
			}
			set
			{				 
				strQualification = value;
			}
		}

		public int QualificationDetails
		{  
			get
			{	
				return strQualificationDetails;
			}
			set
			{				 
				strQualificationDetails = value;
			}
		}

		public string OtherQualification
		{  
			get
			{	
				return strOtherQualification;
			}
			set
			{				 
				strOtherQualification = value;
			}
		}

		public string University
		{  
			get
			{	
				return strUniversity;
			}
			set
			{				 
				strUniversity = value;
			}
		}

		public string CollegeAddress
		{  
			get
			{	
				return strCollegeAddress;
			}
			set
			{				 
				strCollegeAddress = value;
			}
		}

		public string EducationCity
		{  
			get
			{	
				return strEducationCity;
			}
			set
			{				 
				strEducationCity = value;
			}
		}

		//
		
		public int TestCentre
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
		
		public string WillingToRelocate
		{  
			get
			{	
				return strWillingToRelocate;
			}
			set
			{				 
				strWillingToRelocate = value;
			}
		}
		
		public int SerialNoFrom
		{  
			get
			{	
				return intSerialNoFrom;
			}
			set
			{				 
				intSerialNoFrom = value;
			}
		}
		
		public int SerialNoTo
		{  
			get
			{	
				return intSerialNoTo;
			}
			set
			{				 
				intSerialNoTo = value;
			}
		}
		
		public string RegistrationIDFrom
		{  
			get
			{	
				return strRegistrationIDFrom;
			}
			set
			{				 
				strRegistrationIDFrom = value;
			}
		}
		
		public string RegistrationIDTo
		{  
			get
			{	
				return strRegistrationIDTo;
			}
			set
			{				 
				strRegistrationIDTo = value;
			}
		}
		
		public string YouBelongTo
		{  
			get
			{	
				return strYouBelongTo;
			}
			set
			{				 
				strYouBelongTo = value;
			}
		}
		
		public string MediumOfInstruction
		{  
			get
			{	
				return strMediumOfInstruction;
			}
			set
			{				 
				strMediumOfInstruction = value;
			}
		}
		
		public string MediumOfInstructionIn12Th
		{  
			get
			{	
				return strMediumOfInstructionIn12Th;
			}
			set
			{				 
				strMediumOfInstructionIn12Th = value;
			}
		}
	
		public int SpeakingFrom
		{  
			get
			{	
				return intSpeakingFrom;
			}
			set
			{				 
				intSpeakingFrom = value;
			}
		}
		
		public int SpeakingTo
		{  
			get
			{	
				return intSpeakingTo;
			}
			set
			{				 
				intSpeakingTo = value;
			}
		}
		
		public int ListeningFrom
		{  
			get
			{	
				return intListeningFrom;
			}
			set
			{				 
				intListeningFrom = value;
			}
		}
		
		public int ListeningTo
		{  
			get
			{	
				return intListeningTo;
			}
			set
			{				 
				intListeningTo = value;
			}
		}
		
		public int WaitingFrom
		{  
			get
			{	
				return intWaitingFrom;
			}
			set
			{				 
				intWaitingFrom = value;
			}
		}
		
		public int WaitingTo
		{  
			get
			{	
				return intWaitingTo;
			}
			set
			{				 
				intWaitingTo = value;
			}
		}
		
		public int AnalyticalFrom
		{  
			get
			{	
				return intAnalyticalFrom;
			}
			set
			{				 
				intAnalyticalFrom = value;
			}
		}
		
		public int AnalyticalTo
		{  
			get
			{	
				return intAnalyticalTo;
			}
			set
			{				 
				intAnalyticalTo = value;
			}
		}		
		
		public string ResidentialCity
		{  
			get
			{	
				return strResidentialCity;
			}
			set
			{				 
				strResidentialCity = value;
			}
		}	

		public DateTime DOBFrom
		{  
			get
			{	
				return strDOBFrom;
			}
			set
			{				 
				strDOBFrom = value;
			}
		}	

		public DateTime DOBTo
		{  
			get
			{	
				return strDOBTo;
			}
			set
			{				 
				strDOBTo = value;
			}
		}	

		public int CurrentPage
		{  
			get
			{	
				return intCurrentPage;
			}
			set
			{				 
				intCurrentPage = value;
			}
		}	

		public int PageSize
		{  
			get
			{	
				return intPageSize;
			}
			set
			{				 
				intPageSize = value;
			}
		}	

		public string CandidateList
		{  
			get
			{	
				return strCandidateList;
			}
			set
			{				 
				strCandidateList = value;
			}
		}

		public int UserType
		{  
			get
			{	
				return intUserType;
			}
			set
			{				 
				intUserType = value;
			}
		}	

		#region SearchCandidate()

		public DataSet SearchCandidate()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(35);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@CurrentPage", CurrentPage);
				dbManager.AddParameters(33, "@PageSize", PageSize);
				dbManager.AddParameters(34, "@TestName", TestName);

				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidate"));				 
				 
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


		#region SearchCandidateList()

		public DataSet SearchCandidateList()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(35);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@CurrentPage", CurrentPage);
				dbManager.AddParameters(33, "@PageSize", PageSize);
				dbManager.AddParameters(34, "@TestName", TestName);

				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidateList"));				 
				 
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


		#region ExportAllCandidateListByAdmin

		public DataTable ExportAllCandidateListByAdmin()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(33);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@TestName", TestName);
			 
				 
				 			
			
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ExportAllCandidateListByAdmin").Tables[0]);				 
				 
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

		#region GenerateAllMultipleAdmitCard()

		public DataSet GenerateAllMultipleAdmitCard()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(34);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
				dbManager.AddParameters(33, "@TestName", TestName);
				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GeAllMultipleAdmitCard"));				 
				 
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

		#region GenerateAllMultipleScoreCard()

		public DataTable GenerateAllMultipleScoreCard()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(33);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
				 
				 			
			
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GeAllMultipleScoreCard").Tables[0]);				 
				 
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

		#region GenerateAllMultipleScoreCard_MTFormat()
		public DataTable GenerateAllMultipleScoreCard_MTFormat()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(34);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
				dbManager.AddParameters(33, "@TestName", TestName);

				 
				 			
			
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GeAllMultipleScoreCard_MTFormat").Tables[0]);				 
				 
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

		#region GenerateAllCandidateDetails()

		public DataSet GenerateAllCandidateDetails()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(34);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
				dbManager.AddParameters(33, "@TestName", TestName);
				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GeAllCandidateDetails"));				 
				 
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

		#region GenerateAllMultipleJobAdmitCard()

		public DataSet GenerateAllMultipleJobAdmitCard()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(33);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
			 
				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllJobAdmitCard"));				 
				 
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

		#region GenerateAllMultipleJobAdmitCard_MT()

		public DataSet GenerateAllMultipleJobAdmitCard_MT()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(33);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@UserType", UserType);
			 
				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllJobAdmitCard_MT"));				 
				 
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

		#region ExportAllCandidateListByETS

		public DataTable ExportAllCandidateListByETS()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(32);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
			 
				 
				 			
			
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ExportAllCandidateListByETS").Tables[0]);				 
				 
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

		#region SearchCandidateForETS()

		public DataSet SearchCandidateForETS()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(34);

				dbManager.AddParameters(0, "@FirstName", FirstName);
				dbManager.AddParameters(1, "@LastName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@TestState", TestState);
				dbManager.AddParameters(4, "@TestCity", TestCity);
				dbManager.AddParameters(5, "@EmploymentStatus", EmploymentStatus);
				dbManager.AddParameters(6, "@Qualification", Qualification);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@WillingToRelocate", WillingToRelocate);
				dbManager.AddParameters(9, "@SerialNoFrom", SerialNoFrom);
				dbManager.AddParameters(10, "@SerialNoTo", SerialNoTo);
				dbManager.AddParameters(11, "@RegistrationIDFrom", RegistrationIDFrom);
				dbManager.AddParameters(12, "@RegistrationIDTo", RegistrationIDTo);
				dbManager.AddParameters(13, "@YouBelongTo", YouBelongTo);
				dbManager.AddParameters(14, "@MediumOfInstruction", MediumOfInstruction);
				dbManager.AddParameters(15, "@MediumOfInstructionIn12Th", MediumOfInstructionIn12Th);
				dbManager.AddParameters(16, "@SpeakingFrom", SpeakingFrom);
				dbManager.AddParameters(17, "@SpeakingTo", SpeakingTo);
				dbManager.AddParameters(18, "@ListeningFrom", ListeningFrom);
				dbManager.AddParameters(19, "@ListeningTo", ListeningTo);
				dbManager.AddParameters(20, "@WaitingFrom", WaitingFrom);
				dbManager.AddParameters(21, "@WaitingTo", WaitingTo);
				dbManager.AddParameters(22, "@AnalyticalFrom", AnalyticalFrom);
				dbManager.AddParameters(23, "@AnalyticalTo", AnalyticalTo);				
				dbManager.AddParameters(24, "@OtherQualification", OtherQualification);
				dbManager.AddParameters(25, "@University", University);
				dbManager.AddParameters(26, "@CollegeAddress", CollegeAddress);
				dbManager.AddParameters(27, "@EducationCity", EducationCity);
				dbManager.AddParameters(28, "@ResidentialCity", ResidentialCity);
				dbManager.AddParameters(29, "@DOBFrom", DOBFrom);
				dbManager.AddParameters(30, "@DOBTo", DOBTo);
				dbManager.AddParameters(31, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(32, "@CurrentPage", CurrentPage);
				dbManager.AddParameters(33, "@PageSize", PageSize); 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidateForETS"));				 
				 
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

		public DataTable GenerateMultipleScoreCardV2(string strItemList)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@ItemList", strItemList);			
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleScoreCardDetailsV2").Tables[0];
			 
				
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

		public BLSearch()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	}
}
