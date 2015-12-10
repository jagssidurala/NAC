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
	/// Summary description for BLRegistration.
	/// </summary>
	public class BLRegistration
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);

		private string strRegistrationId;
		private string strPinNo;
		private int intSerialNumber;
		private string strFirstName;
		private string strMiddleName;
		private string strLastName;
		private DateTime dtDOB;
		private string strGender;
		private string strResidentialAddress;
		private string strCity;
		private string strPinCode;
		private string strSTDCode;
		private string strLandLine;
		private string strCellPhone;
		private string strUploadPhotograph;
		private string strEmailId;
		private string strMothersFullname;
		private string strFathersFullname;
		private int strAnnualHouseHoldIncome;
		private bool strYouBelongTo;
		private int strHighestEducationalQualification;		
		private int strQualificationDetail;
		private int strMarksObtained;
		private int intCentreId;
		private int intStateId;
		private int intCityId;
		private string strUniversity;
		private string strCollegeAddress;
		private string strEducationCity;
		private string strHighestEducationObtainedFrom;
		private string strHighestEducationObtainedCity;
		private int intAggregatePercentageScored;			
		private string strMediumOfInstructionUpTo10Th;
		private string strMediumOfInstructionUpTo12Th;
		private bool strEmploymentStatus;
		private bool strWillingToWorkOutOfHomeTown;
		private string strTestCity;
		private string strTestCentre;
		private string strTestState;
		private string strPassword;
		private string strConfirmPassword;
		private string strPhotoIdDocument;
		private string strPhotoIdNumber;		
		private string strConn;		    
		private int intTestId;
	    private string strTestType;		    
		private string strOtherQualification;
			 
		private int intRegistrationStartFrom;
		private int intNumberofRegistration;
		private int  intRegistrationMessage;
		   
		private string strPhotoIdDocumentName;
		private string strTestCentreName;
		private string strEmploymentStatusName;
		private string strWillingToWOUHTName;
		private string strQualificationDetailName;
		private string strHEQName;
		private string strYBTName;
		private string strAHHIName;
		private string strPhotoGraphLocalePath;
		private string strGenderName;			
		private DateTime dtRegistrationClosingDate;
		private DateTime dtRegistrationStartDate;

		private DataAccessLayer.DBConnection conn;
		//private IDBManager dbManager;
		//private DataAccessLayer.SimpleHash GenPWD;

		private int intYearOfPassing12Th;
		private int intYearOfGraduation;		
		private string strPGSpecialization; 
		private string strCurrentLocation;
		private string strLanguageSkills;
		private bool strHavePassport;
		private string strHavePassportName;
		private string strPassportNo;

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

		public string PinNo
		{
		
			get
			{	
				return strPinNo;
			}
			set
			{				 
				strPinNo = value;
			}
		
		}

		public int SerialNumber
		{  
			get
			{	
				return intSerialNumber;
			}
			set
			{				 
				intSerialNumber = value;
			}
		}	


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

		public string MiddleName
		{  
			get
			{	
				return strMiddleName;
			}
			set
			{				 
				strMiddleName = value;
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
		
		public DateTime DOB
		{  
			get
			{	
				return dtDOB;
			}
			set
			{				 
				dtDOB = value;
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
		
		public string ResidentialAddress
		{  
			get
			{	
				return strResidentialAddress;
			}
			set
			{				 
				strResidentialAddress = value;
			}
		}
		
		public string City
		{  
			get
			{	
				return strCity;
			}
			set
			{				 
				strCity = value;
			}
		}
		
		public string PinCode
		{  
			get
			{	
				return strPinCode;
			}
			set
			{				 
				strPinCode = value;
			}
		}
		
        

		public string STDCode
		{  
			get
			{	
				return strSTDCode;
			}
			set
			{				 
				strSTDCode = value;
			}
		}

		public string LandLine
		{  
			get
			{	
				return strLandLine;
			}
			set
			{				 
				strLandLine = value;
			}
		}
		
		public string CellPhone
		{  
			get
			{	
				return strCellPhone;
			}
			set
			{				 
				strCellPhone = value;
			}
		}
		
		public string UploadPhotograph
		{  
			get
			{	
				return strUploadPhotograph;
			}
			set
			{				 
				strUploadPhotograph = value;
			}
		}
		
		public string EmailId
		{  
			get
			{	
				return strEmailId;
			}
			set
			{				 
				strEmailId = value;
			}
		}
		
		public string MothersFullname
		{  
			get
			{	
				return strMothersFullname;
			}
			set
			{				 
				strMothersFullname = value;
			}
		}
	 

		public string FathersFullname
		{  
			get
			{	
				return strFathersFullname;
			}
			set
			{				 
				strFathersFullname = value;
			}
		}
		public int AnnualHouseHoldIncome
		{  
			get
			{	
				return strAnnualHouseHoldIncome;
			}
			set
			{				 
				strAnnualHouseHoldIncome = value;
			}
		}
		
		public bool YouBelongTo
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
			
		public int HighestEducationalQualification
		{
			get
			{	
				return strHighestEducationalQualification;
			}
			set
			{				 
				strHighestEducationalQualification = value;
			}
		}
		
		public int QualificationDetail
		{  
			get
			{	
				return strQualificationDetail;
			}
			set
			{				 
				strQualificationDetail = value;
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

		public int MarksObtained
		{  
			get
			{	
				return strMarksObtained;
			}
			set
			{				 
				strMarksObtained = value;
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

		public string HighestEducationObtainedFrom
		{  
			get
			{	
				return strHighestEducationObtainedFrom;
			}
			set
			{				 
				strHighestEducationObtainedFrom = value;
			}
		}

		public string HighestEducationObtainedCity
		{  
			get
			{	
				return strHighestEducationObtainedCity;
			}
			set
			{				 
				strHighestEducationObtainedCity = value;
			}
		}

		public int AggregatePercentageScored
		{  
			get
			{	
				return intAggregatePercentageScored;
			}
			set
			{				 
				intAggregatePercentageScored = value;
			}
		}		
		 
		
		public string MediumOfInstructionUpTo10Th
		{  
			get
			{	
				return strMediumOfInstructionUpTo10Th;
			}
			set
			{				 
				strMediumOfInstructionUpTo10Th = value;
			}
		}
		
		public string MediumOfInstructionUpTo12Th
		{  
			get
			{	
				return strMediumOfInstructionUpTo12Th;
			}
			set
			{				 
				strMediumOfInstructionUpTo12Th = value;
			}
		}
		public int YearOfPassing12Th
		{  
			get
			{	
				return intYearOfPassing12Th;
			}
			set
			{				 
				intYearOfPassing12Th = value;		
			}
		}
		public int YearOfGraduation
		{  
			get
			{	
				return intYearOfGraduation;
			}
			set
			{				 
				intYearOfGraduation = value;
			}
		}			
		public string PGSpecialization
		{  
			get
			{	
				return strPGSpecialization;
			}
			set
			{				 
				strPGSpecialization = value;
			}
		}
		public string CurrentLocation
		{  
			get
			{	
				return strCurrentLocation;
			}
			set
			{				 
				strCurrentLocation = value;
			}
		}
		public string LanguageSkills
		{  
			get
			{	
				return strLanguageSkills;
			}
			set
			{				 
				strLanguageSkills = value;
			}
		}	
		
		public bool HavePassport
		{  
			get
			{	
				return strHavePassport;
			}
			set
			{				 
				strHavePassport = value;
			}
		}
		public string HavePassportName
		{  
			get
			{	
				return strHavePassportName;
			}
			set
			{				 
				strHavePassportName = value;
			}
		}
		public string PassportNo
		{  
			get
			{	
				return strPassportNo;
			}
			set
			{				 
				strPassportNo = value;
			}
		}
		public bool EmploymentStatus
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
		
		public bool WillingToWorkOutOfHomeTown
		{  
			get
			{	
				return strWillingToWorkOutOfHomeTown;
			}
			set
			{				 
				strWillingToWorkOutOfHomeTown = value;
			}
		}	
		 

		public int CentreId
		{  
			get
			{	
				return intCentreId;
			}
			set
			{				 
				intCentreId = value;
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

		public int CityId
		{  
			get
			{	
				return intCityId;
			}
			set
			{				 
				intCityId = value;
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
		
		public string Password
		{  
			get
			{	
				return strPassword;
			}
			set
			{				 
				strPassword = value;
			}
		}
		
		public string ConfirmPassword
		{  
			get
			{	
				return strConfirmPassword;
			}
			set
			{				 
				strConfirmPassword = value;
			}
		}
		
		public string PhotoIdDocument
		{  
			get
			{	
				return strPhotoIdDocument;
			}
			set
			{				 
				strPhotoIdDocument = value;
			}
		}
		
		public string PhotoIdNumber
		{  
			get
			{	
				return strPhotoIdNumber;
			}
			set
			{				 
				strPhotoIdNumber = value;
			}
		}

		public string TestType
		{  
			get
			{	
				return strTestType;
			}
			set
			{				 
				strTestType = value;
			}
		}

		public int TestId
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
			
		public int RegistrationStartFrom
		{
			get
			{
				return intRegistrationStartFrom;
			}
			set
			{
				intRegistrationStartFrom = value;
			}
		}

		public int RegistrationMessage
		{
			get
			{
				return intRegistrationMessage;
			}
			set 
			{
				intRegistrationMessage = value;
			}
		}

		public int NumberOfRegistration
		{
			get
			{
				return intNumberofRegistration;
			}
			set
			{
				intNumberofRegistration = value;
			}
		}

		
		public string PhotoIdDocumentName
		{  
			get
			{	
				return strPhotoIdDocumentName;
			}
			set
			{				 
				strPhotoIdDocumentName = value;
			}
		}
		
		public string TestCentreName
		{  
			get
			{	
				return strTestCentreName;
			}
			set
			{				 
				strTestCentreName = value;
			}
		}

		public string EmploymentStatusName
		{  
			get
			{	
				return strEmploymentStatusName;
			}
			set
			{				 
				strEmploymentStatusName = value;
			}
		}
		 
		
		public string WillingToWOUHTName
		{  
			get
			{	
				return strWillingToWOUHTName;
			}
			set
			{				 
				strWillingToWOUHTName = value;
			}
		}
		
		public string QualificationDetailName
		{  
			get
			{	
				return strQualificationDetailName;
			}
			set
			{				 
				strQualificationDetailName = value;
			}
		}
		
		public string HEQName
		{  
			get
			{	
				return strHEQName;
			}
			set
			{				 
				strHEQName = value;
			}
		}
		
		public string YBTName
		{  
			get
			{	
				return strYBTName;
			}
			set
			{				 
				strYBTName = value;
			}
		}
		
		public string AHHIName
		{  
			get
			{	
				return strAHHIName;
			}
			set
			{				 
				strAHHIName = value;
			}
		}
		
		public string PhotoGraphLocalePath
		{  
			get
			{	
				return strPhotoGraphLocalePath;
			}
			set
			{				 
				strPhotoGraphLocalePath = value;
			}
		}
		
		public string GenderName
		{  
			get
			{	
				return strGenderName;
			}
			set
			{				 
				strGenderName = value;
			}
		}

		public DateTime RegistrationClosingDate
		{  
			get
			{	
				return dtRegistrationClosingDate;
			}
			set
			{				 
				dtRegistrationClosingDate = value;
			}
		}	

		public DateTime RegistrationStartDate
		{  
			get
			{	
				return dtRegistrationStartDate;
			}
			set
			{				 
				dtRegistrationStartDate = value;
			}
		}	

		
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int IsPinNumberInUse()
		{
			int intCheck = 0;
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@PinNo",PinNo,ParameterDirection.Input);		
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"IsPinNumberInUse"));				 
				dbManager.Close();
				return intCheck;
			}
			catch
			{					 
				dbManager.Close();
				dbManager.Dispose();
				throw;
			}	

		}


		public int IsPWDExits(string PhotoId, string PhotoIdNo, string Pass)
		{
			int intCheck = 0;
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@PhotoId",PhotoId,ParameterDirection.Input);		
				dbManager.AddParameters(1,"@PhotoIdNo",PhotoIdNo,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@Password",Pass,ParameterDirection.Input);	
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"IsPWDExits"));				 
				dbManager.Close();
				return intCheck;
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

		public int SetCandidateDetail()
		{
		 
			int intCheck = 0;
			try
			{

				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction(IsolationLevel.RepeatableRead);
				dbManager.CreateParameters(42);
				dbManager.AddParameters(0,"@PinNo",PinNo,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@FName",FirstName,ParameterDirection.Input);
				dbManager.AddParameters(2,"@MName",MiddleName,ParameterDirection.Input);
				dbManager.AddParameters(3,"@LName",LastName,ParameterDirection.Input);
				dbManager.AddParameters(4,"@DOB",DOB,ParameterDirection.Input);
				dbManager.AddParameters(5,"@Gender",Gender,ParameterDirection.Input);
				dbManager.AddParameters(6,"@Address",ResidentialAddress,ParameterDirection.Input);
				dbManager.AddParameters(7,"@City",City,ParameterDirection.Input);
				dbManager.AddParameters(8,"@Pincode",PinCode,ParameterDirection.Input);
				dbManager.AddParameters(9,"@STDCode",STDCode,ParameterDirection.Input);
				dbManager.AddParameters(10,"@LandlinePhoneNo",LandLine,ParameterDirection.Input);
				dbManager.AddParameters(11,"@MobilePhone",CellPhone,ParameterDirection.Input);
				dbManager.AddParameters(12,"@ImageFileName",UploadPhotograph,ParameterDirection.Input);
				dbManager.AddParameters(13,"@EmailId",EmailId,ParameterDirection.Input);
				dbManager.AddParameters(14,"@MotherName",MothersFullname,ParameterDirection.Input);
				dbManager.AddParameters(15,"@FatherName",FathersFullname,ParameterDirection.Input);	
				dbManager.AddParameters(16,"@IncomeRange",AnnualHouseHoldIncome,ParameterDirection.Input);
				dbManager.AddParameters(17,"@QualificationType",HighestEducationalQualification,ParameterDirection.Input);
				dbManager.AddParameters(18,"@Qualification",QualificationDetail,ParameterDirection.Input);
				dbManager.AddParameters(19,"@MarksObtained",AggregatePercentageScored,ParameterDirection.Input);
				dbManager.AddParameters(20,"@University",University,ParameterDirection.Input);
				dbManager.AddParameters(21,"@CollegeAddress",CollegeAddress,ParameterDirection.Input);
				dbManager.AddParameters(22,"@EducationCity",EducationCity,ParameterDirection.Input);
				dbManager.AddParameters(23,"@EmploymentStatus",EmploymentStatus,ParameterDirection.Input);
				dbManager.AddParameters(24,"@OutsideHome",WillingToWorkOutOfHomeTown,ParameterDirection.Input);
				dbManager.AddParameters(25,"@TestCity",TestCity,ParameterDirection.Input);
				dbManager.AddParameters(26,"@TestCentre",TestCentre,ParameterDirection.Input);					
				dbManager.AddParameters(27,"@PhotoId",PhotoIdDocument,ParameterDirection.Input);
				dbManager.AddParameters(28,"@PhotoIdNo",PhotoIdNumber,ParameterDirection.Input);
				dbManager.AddParameters(29,"@MediumSchool",MediumOfInstructionUpTo10Th,ParameterDirection.Input);
				dbManager.AddParameters(30,"@Medium12th",MediumOfInstructionUpTo12Th,ParameterDirection.Input);
				dbManager.AddParameters(31,"@BelongTo",YouBelongTo,ParameterDirection.Input);
				dbManager.AddParameters(32,"@Password",Password,ParameterDirection.Input);
				dbManager.AddParameters(33,"@OtherQualification",OtherQualification,ParameterDirection.Input);
				dbManager.AddParameters(34,"@SerialNumber",SerialNumber,ParameterDirection.Input);
				// New fields added by deepak
				dbManager.AddParameters(35,"@PassingYear12Th",YearOfPassing12Th,ParameterDirection.Input);
				dbManager.AddParameters(36,"@HighEduYear",YearOfGraduation,ParameterDirection.Input);
					
				dbManager.AddParameters(37,"@PGSpecialization",PGSpecialization,ParameterDirection.Input);
				dbManager.AddParameters(38,"@CurrentLocation",CurrentLocation,ParameterDirection.Input);
				dbManager.AddParameters(39,"@LanguageSkills",LanguageSkills,ParameterDirection.Input);
				dbManager.AddParameters(40,"@HavePassport",HavePassport,ParameterDirection.Input);
				dbManager.AddParameters(41,"@PassportNo",PassportNo,ParameterDirection.Input);
					 
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"AddCandidateDetail"));				 
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

		//Updating candidate details
		public void UpdateCandidateDetail(string strRegistrationId)
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
				dbManager.CreateParameters(41);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@RegistrationId",strRegistrationId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@FName",FirstName,ParameterDirection.Input);
				dbManager.AddParameters(2,"@MName",MiddleName,ParameterDirection.Input);
				dbManager.AddParameters(3,"@LName",LastName,ParameterDirection.Input);
				dbManager.AddParameters(4,"@DOB",DOB,ParameterDirection.Input);
				dbManager.AddParameters(5,"@Gender",Gender,ParameterDirection.Input);
				dbManager.AddParameters(6,"@Address",ResidentialAddress,ParameterDirection.Input);
				dbManager.AddParameters(7,"@City",City,ParameterDirection.Input);
				dbManager.AddParameters(8,"@Pincode",PinCode,ParameterDirection.Input);
				dbManager.AddParameters(9,"@STDCode",STDCode,ParameterDirection.Input);
				dbManager.AddParameters(10,"@LandlinePhoneNo",LandLine,ParameterDirection.Input);
				dbManager.AddParameters(11,"@MobilePhone",CellPhone,ParameterDirection.Input);
				dbManager.AddParameters(12,"@ImageFileName",UploadPhotograph,ParameterDirection.Input);
				dbManager.AddParameters(13,"@EmailId",EmailId,ParameterDirection.Input);
				dbManager.AddParameters(14,"@MotherName",MothersFullname,ParameterDirection.Input);
				dbManager.AddParameters(15,"@FatherName",FathersFullname,ParameterDirection.Input);				 
				dbManager.AddParameters(16,"@IncomeRange",AnnualHouseHoldIncome,ParameterDirection.Input);
				dbManager.AddParameters(17,"@QualificationType",HighestEducationalQualification,ParameterDirection.Input);
				dbManager.AddParameters(18,"@Qualification",QualificationDetail,ParameterDirection.Input);
				dbManager.AddParameters(19,"@MarksObtained",AggregatePercentageScored,ParameterDirection.Input);
				dbManager.AddParameters(20,"@University",University,ParameterDirection.Input);
				dbManager.AddParameters(21,"@CollegeAddress",CollegeAddress,ParameterDirection.Input);
				dbManager.AddParameters(22,"@EducationCity",EducationCity,ParameterDirection.Input);
				dbManager.AddParameters(23,"@EmploymentStatus",EmploymentStatus,ParameterDirection.Input);
				dbManager.AddParameters(24,"@OutsideHome",WillingToWorkOutOfHomeTown,ParameterDirection.Input);
				dbManager.AddParameters(25,"@TestCity",TestCity,ParameterDirection.Input);
				dbManager.AddParameters(26,"@TestCentre",TestCentre,ParameterDirection.Input);					
				dbManager.AddParameters(27,"@PhotoId",PhotoIdDocument,ParameterDirection.Input);
				dbManager.AddParameters(28,"@PhotoIdNo",PhotoIdNumber,ParameterDirection.Input);
				dbManager.AddParameters(29,"@MediumSchool",MediumOfInstructionUpTo10Th,ParameterDirection.Input);
				dbManager.AddParameters(30,"@Medium12th",MediumOfInstructionUpTo12Th,ParameterDirection.Input);
				dbManager.AddParameters(31,"@BelongTo",YouBelongTo,ParameterDirection.Input);
				dbManager.AddParameters(32,"@Password",Password,ParameterDirection.Input);
				dbManager.AddParameters(33,"@OtherQualification",OtherQualification,ParameterDirection.Input);

				// New fields added by deepak
				dbManager.AddParameters(34,"@PassingYear12Th",YearOfPassing12Th,ParameterDirection.Input);
				dbManager.AddParameters(35,"@HighEduYear",YearOfGraduation,ParameterDirection.Input);
				
				dbManager.AddParameters(36,"@PGSpecialization",PGSpecialization,ParameterDirection.Input);
				dbManager.AddParameters(37,"@CurrentLocation",CurrentLocation,ParameterDirection.Input);
				dbManager.AddParameters(38,"@LanguageSkills",LanguageSkills,ParameterDirection.Input);
				dbManager.AddParameters(39,"@HavePassport",HavePassport,ParameterDirection.Input);
				dbManager.AddParameters(40,"@PassportNo",PassportNo,ParameterDirection.Input);

				//Executing Command and storing Registrationid as Output Parameter in strRegistrationId
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"UpdateCandidateDetail");
				 
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


		public DataTable FillQualificationType()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetQualificationType").Tables[0];
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


		public DataTable FillQualificationTypeSecond()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetQualificationTypeSecond").Tables[0];
				 
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

		public DataTable FillQualificationDetails(int QualificationTypeID)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.AddParameters(0,"@QualificationTypeID",QualificationTypeID,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"PopulateQualificationSecond").Tables[0];
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

		public DataTable FillQualification()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetQualification").Tables[0];
				 
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


		public DataTable FillTestCitySecond(int intStateId)
		{
		    
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();    
				dbManager.AddParameters(0,"@TestState",intStateId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCitySecond").Tables[0];
				
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

		public DataTable FillTestCitySecond(int intStateId, int Flag)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(2);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();    
				dbManager.AddParameters(0,"@TestState",intStateId,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@Flag",1,ParameterDirection.Input);	
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCitySecond").Tables[0];
				
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

		//Created By Manoj to Fill test city based on SerialNo and PinNo. Date: 30 Sept 2010
		public DataTable FillTestCitySecond(string SerialNo, string PinNo)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(2);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();    
				dbManager.AddParameters(0,"@SerialNo",SerialNo,ParameterDirection.Input);	
				dbManager.AddParameters(1,"@PinNo",PinNo,ParameterDirection.Input);	
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCityRegistration").Tables[0];
				
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

		public DataTable FillTestSecond(int intStateId)
		{
		    
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();    
				dbManager.AddParameters(0,"@TestState",intStateId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestSecond").Tables[0];
				
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

		public DataTable FillTestCity(int intStateId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.CreateParameters(1);
				dbManager.Open(); 
				dbManager.AddParameters(0,"@StateId",intStateId,ParameterDirection.Input);        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCity").Tables[0];
				
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

		public DataTable FillCity()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 			        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCity").Tables[0];
				
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

		public DataTable GetTestCityV2()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 			        
				dbManager.AddParameters(0,"@TestType",strTestType,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCityV2").Tables[0];
				
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

		public DataTable GetTestCityV2(int StateId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.CreateParameters(2);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 			        
				dbManager.AddParameters(0,"@TestType",strTestType,ParameterDirection.Input);
				dbManager.AddParameters(1,"@StateId",StateId,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCityV2").Tables[0];
				
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


		public DataTable FillTest_State()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);					 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 			        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTest_State").Tables[0];
				
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

		public DataTable FillTestCentre()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 	        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCentreSecond").Tables[0];
				 
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

		//FillAllTestCentre(intCity, intStateId)
		public DataTable FillAllTestCentre(int intCity)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.CreateParameters(1);
				dbManager.Open();
				dbManager.AddParameters(0,"@CityId",intCity,ParameterDirection.Input);       
 				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllTestCentre").Tables[0];
				 
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

		public DataTable FillCentre()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);				 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				 				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCentre").Tables[0];
				 
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

		public DataTable FillTestCentreSecondAdmin(int intCityId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();   
				dbManager.AddParameters(0,"@TestCityId",intCityId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCentreListAdmin").Tables[0];
				 
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
		
		public DataTable FillTestCentreSecond(int intCityId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();   
				dbManager.AddParameters(0,"@TestCityId",intCityId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestCentreList").Tables[0];
				 
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

		public DataTable FillTestNameSecond(int intCentreId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();   
				dbManager.AddParameters(0,"@CentreId",intCentreId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestAgainstCentre").Tables[0];
				 
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

		public DataTable FillTestState()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestState").Tables[0];				 
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

		public DataTable FillTestStateForETS()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllTestStateForETS").Tables[0];
				 
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

		public DataTable FillAllTestState()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllTestState").Tables[0];
				 
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

		public DataTable FillTestStateV2()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.CreateParameters(1);
				dbManager.Open();            
				dbManager.AddParameters(0,"@TestType",strTestType,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestStateV2").Tables[0];
				 
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

		public DataTable FillState()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetState").Tables[0];
				 
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

		public DataTable FillPhotoIdDetail()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetPhotoIdDetail").Tables[0];
				 
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

		public DataTable FillIncomeRange()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetIncomeRange").Tables[0];
				 
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
		  
		 
		public BLRegistration()
		{
			/*
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
			}
			catch(Exception SysEx)
			{
				throw SysEx;
		
			}*/
		}

		public DataSet GenerateMultipleCandidateDetails(string RegistrationId)
		{
			try
			{
				DataSet dsCandidate = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();

				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@strRegistration", RegistrationId);			 
				dsCandidate =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleCandidateDetails");
				return dsCandidate;
				
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
		public DataSet PreviewCandidateDetails(string RegId)
		{
			try
			{
				DataSet dsRegistration = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();

				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();

				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", RegId,ParameterDirection.Input);
				dsRegistration =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ViewCandidateDetails");
				return dsRegistration;
				
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

		public DataTable GetTestNames(int ActiveStatus)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();  
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@isActive", ActiveStatus,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestNames").Tables[0];
				 
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

		public DataSet GetTestRegistrationStatus(string testName)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();   
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@TestName", testName,ParameterDirection.Input);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestRegistrationStatus");
				 
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


		public DataSet PreviewCandidateDetailsforAdmin(string RegId)
		{
			try
			{
				DataSet dsRegistration = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();

				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();

				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", RegId,ParameterDirection.Input);
				dsRegistration =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ViewCandidateDetailsForAdmin");
				return dsRegistration;
				
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
	
		public DataSet SearchCandidate(string FirstName,string LastName,string Gender,string Qualification,string Relocate, int TestState, int TestCity, int TestCentre, string EmpStatus)
		{
			try
			{
				DataSet dsCandidate = new DataSet();
				conn = new DBConnection();
				strConn = conn.GetConnectionString();

				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();

				dbManager.CreateParameters(9);
				dbManager.AddParameters(0, "@FName", FirstName);
				dbManager.AddParameters(1, "@LName", LastName);
				dbManager.AddParameters(2, "@Gender", Gender);
				dbManager.AddParameters(3, "@Qualification", Qualification);
				dbManager.AddParameters(4, "@Relocate", Relocate);
				dbManager.AddParameters(5, "@TestState", TestState);
				dbManager.AddParameters(6, "@TestCity", TestCity);
				dbManager.AddParameters(7, "@TestCentre", TestCentre);
				dbManager.AddParameters(8, "@EmpStatus", EmpStatus);
			
				dsCandidate =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidate");
				return dsCandidate;
				
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
		public ArrayList FetchPinNo()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				ArrayList arrList = new ArrayList();
				DataSet tmpDS = new DataSet();
				dbManager.Open();            
				tmpDS = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetRegId");
				for (int i = 0; i<=tmpDS.Tables[0].Rows.Count - 1;i++)
				{
					arrList.Add(tmpDS.Tables[0].Rows[i][0].ToString());
				}
				return arrList;
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
		public DataSet AddPinNo()
		{
			DataSet tmpDS=new DataSet(); 
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@PinNo",PinNo,ParameterDirection.Input);
				dbManager.AddParameters(1,"@TestId",TestId,ParameterDirection.Input);
				tmpDS= dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"AddPinNo");
				dbManager.CommitTransaction();
				dbManager.Close();
				return tmpDS;
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				return tmpDS;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void RemovePhotograph(string strRegistrationID)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@RegistrationID",strRegistrationID,ParameterDirection.Input);
				dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"RemoveImage");
				dbManager.CommitTransaction();
				dbManager.Close();
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public DataTable FillTest()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();            
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTest").Tables[0];
				 
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


		public void AddRegistrationID()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(6);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CentreId", CentreId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@CityId", CityId,ParameterDirection.Input);				
				dbManager.AddParameters(3,"@TestId", TestId,ParameterDirection.Input);				
				dbManager.AddParameters(4,"@NumberOfRegistration", NumberOfRegistration,ParameterDirection.Input);
				dbManager.AddParameters(5,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"AddRegistrationId","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(5).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void SetRegistrationClosingTime()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationClosingDate", RegistrationClosingDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"SetRegistrationClosingTime","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(2).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void SetRegistrationStartTime()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationStartDate", RegistrationStartDate,ParameterDirection.Input);
				dbManager.AddParameters(2,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"SetRegistrationStartTime","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(2).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void DeActivateCentre()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(4);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CentreId", CentreId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@CityId", CityId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"DeActivateCentre","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(3).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void DeActivateStateForETS()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"DeActivateStateForETS","@RegistrationMessage");
				dbManager.CommitTransaction();				
				String strReturnValue = dbManager.param_value(1).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void ActivateStateForETS()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				 
				dbManager.AddParameters(1,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"ActivateStateForETS","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(1).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void DeActivateStateForWelcomeMsg()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				
				dbManager.AddParameters(1,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"DeActivateStateForWelMsg","@RegistrationMessage");
				dbManager.CommitTransaction();				
				String strReturnValue = dbManager.param_value(1).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		public void ActivateStateForWelcomeMsg()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);				 
				dbManager.AddParameters(1,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"ActivateStateForWelMsg","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(1).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public void ActivateCentre()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(4);
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@CentreId", CentreId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@CityId", CityId,ParameterDirection.Input);
				dbManager.AddParameters(3,"@RegistrationMessage", RegistrationMessage,ParameterDirection.Output);
				intRegistrationMessage = dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"ActivateCentre","@RegistrationMessage");
				dbManager.CommitTransaction();
				
				String strReturnValue = dbManager.param_value(3).ToString();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}

		//Created by Manoj on 08 Oct 2010
		public DataSet IsTestActive(string SerialNo, string PinNo)
		{
			//string strStatus = "";
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				DataSet dsCentreStatus = new DataSet();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(2);
				dbManager.AddParameters(0,"@SerialNo",SerialNo,ParameterDirection.Input);
				dbManager.AddParameters(1,"@PinNo",PinNo,ParameterDirection.Input);
				//strStatus= Convert.ToString(dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStateCentreIsActive").Tables[0].Rows[0][0]);
				dsCentreStatus= dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"IsTestActive");
				return dsCentreStatus;
				//dbManager.CommitTransaction();
				//dbManager.Close();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public DataSet CheckStateCentreIsActive(int intStateId)
		{
			//string strStatus = "";
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				DataSet ds = new DataSet();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@StateId",intStateId,ParameterDirection.Input);
				//strStatus= Convert.ToString(dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStateCentreIsActive").Tables[0].Rows[0][0]);
				ds = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStateCentreIsActive");
				
				dbManager.CommitTransaction();
				dbManager.Close();
				//return strStatus;
				return ds;
			}
			catch(Exception SysEx)
			{
				throw;
				//dbManager.RollbackTransaction();
				//ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				//return strStatus;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public DataSet CheckStateCentreIsActive(int intStateId,string SerialNo, string PinNo)
		{
			//string strStatus = "";
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				DataSet dsCentreStatus = new DataSet();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@StateId",intStateId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@SerialNo",SerialNo,ParameterDirection.Input);
				dbManager.AddParameters(2,"@PinNo",PinNo,ParameterDirection.Input);
				//strStatus= Convert.ToString(dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStateCentreIsActive").Tables[0].Rows[0][0]);
				dsCentreStatus= dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"CheckStateCentreIsActive");
				return dsCentreStatus;
				//dbManager.CommitTransaction();
				//dbManager.Close();
				
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				throw;
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public DataTable FillRegistrationPinRecord()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);				 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				 				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetRegistrationPinRecord").Tables[0];
				 
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

		public void AddPinNoRecord(int StartId,int EndId)
		{
			
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(3);
				dbManager.AddParameters(0,"@StartId",StartId,ParameterDirection.Input);
				dbManager.AddParameters(1,"@EndId",EndId,ParameterDirection.Input);
				dbManager.AddParameters(2,"@TestId",TestId,ParameterDirection.Input);
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddPinNoRecord");
				dbManager.CommitTransaction();
				dbManager.Close();			
			}
			catch(Exception SysEx)
			{
				dbManager.RollbackTransaction();
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);				
			}
			finally
			{
				dbManager.Close();
				dbManager.Dispose();
			}
		}


		public DataTable FillRegistrationPinforExcel(int intRecordId)
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);	
				dbManager.CreateParameters(1);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();   
				dbManager.AddParameters(0,"@RecordId",intRecordId,ParameterDirection.Input);				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetRegistrationPinForExcel").Tables[0];
				 
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


		public DataTable  FillCenterAgainstCity()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				
				dbManager.AddParameters(0,"@CityId", CityId,ParameterDirection.Input);
				
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCenterAgainstCity").Tables[0];
				 
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

		public DataTable FillCityAgainstState()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(1);
				
				dbManager.AddParameters(0,"@StateId", StateId,ParameterDirection.Input);
				
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCityAgainstState").Tables[0];
				 
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

		public DataTable FillTestEvent()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);				 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open(); 				 				        
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestEvents").Tables[0];
				 
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

		public int CheckPassword()
		{
			try
			{
				
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);		 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.CreateParameters(2);				
				dbManager.AddParameters(0,"@Password", Password,ParameterDirection.Input);
				dbManager.AddParameters(1,"@RegistrationId", RegistrationId,ParameterDirection.Input);				
				return Convert.ToInt16(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"CheckPassword"));				 
				
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

		public DataSet GetStateDetail(string PinNo)
		{
			//Creating object of DataAccessLayer.DBConnection for fetching Connectionstring from config file
			DataAccessLayer.DBConnection objDb=new DBConnection();
			string Con=objDb.GetConnectionString(); 
			try
			{
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0,"@PinNo",PinNo,ParameterDirection.Input);				 
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetStateDetailForPinNo");
				 
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



	}	 
}