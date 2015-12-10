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
	///<remarks>
	///===================================================================
	/// Name: File Name				: BLCandidateSearchByCompany.cs
	/// Construction Date			: 
	/// Author: Developer's Name	: Manoj Kuamr Sijwali
	/// Description					: Candidates can be search on basis of registration id,
	///								  name, scores, qualification information through administrator
	///								  login, This class provides functionality to search candidates
	///								  on these search parameters.
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2010-2011 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 
	///
	public class BLCandidateSearchByCompany
	{

		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
		
		private string registrationID;
		private DateTime testDateFrom;
		private DateTime testDateTo;
		private DateTime dobDateFrom;
		private DateTime dobDateTo;

		private int testState;
		private int testCity;

		private string gender;
		private string employmentStatus;
		private int yearOfPassing12;
		private int percentage10Min;		
		private int percentage10Max;
		private int percentage12Min;
		private int percentage12Max;
		private int percentageGraduationMin;
		private int percentageGraduationMax;

		private int graduationStream;
		private int yearOfGraduation;

		//ScoreCard Data Min Marks
		private string  analyticalMin;
		private string  quantitativeMin;
		
		private string  ewOverallMin;		
		private string  ewGrammarMin;
		private string  ewContentMin;
		private string  ewVocabularyMin;
		private string  ewSpellingMin;

		private string  slOverallMin;
		private string  slSentenceMin;
		private string  slVocabularyMin;
		private string  slFluencyMin;
		private string  slPronunciationMin;
		
		private string  kstSpeedMin;
		private string  kstAccuracyMin;
		
		
		//ScoreCard Data Max Marks
		private string  analyticalMax;
		private string  quantitativeMax;
		
		private string  ewOverallMax;		
		private string  ewGrammarMax;
		private string  ewContentMax;
		private string  ewVocabularyMax;
		private string  ewSpellingMax;
		
		private string  slOverallMax;	
		private string  slSentenceMax;
		private string  slVocabularyMax;
		private string  slFluencyMax;
		private string  slPronunciationMax;
		
		private string  kstSpeedMax;
		private string  kstAccuracyMax;

		private int currentPage;
		private int pageSize;
		private string  sortBy;

		private string candidateList;
		//private bool isActive;

		/// <summary>
		/// Added for export
		/// </summary>

		//IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		//private DataAccessLayer.DBConnection conn;
		//private string strConn;	
		private string strFirstName;
		private string strLastName;
		private string strGender;
		private int intTestState;
		private int intTestCity;
		private string strEmploymentStatus;
		
		private int strQualificationDetails;
		private string strOtherQualification;
		private string strUniversity;
		private string strCollegeAddress;
		private string strEducationCity;		 

		private int strPGQualificationDetails;
		private string strPGOtherQualification;
		private string strPGUniversity;
		private string strPGCollegeAddress;
		private string strPGEducationCity;
		private string strScoreCardFormat;

		private int intTestCentre;
		private string strWillingToRelocate;
		private int intSerialNoFrom;
		private int intSerialNoTo;
		private string strRegistrationIDFrom;
		private string strRegistrationIDTo;
		private string strYouBelongTo;
		private string strMediumOfInstruction;
		private string strMediumOfInstructionIn12Th;
		//ScoreCard Data From Marks
		private int  intAnalyticalFrom;
		private int  intQuantitativeFrom;
		private int  intEWOverallFrom;
		private int  intEWGrammarFrom;
		private int  intEWContentFrom;
		private int  intEWVocabularyFrom;
		private int  intEWSpellingFrom;
		private int  intSLOverallFrom;		
		private int  intSLSentenceFrom;
		private int  intSLVocabularyFrom;
		private int  intSLFluencyFrom;
		private int  intSLPronunciationFrom;
		private int  intKSTSpeedFrom;
		private int  intKSTAccuracyFrom;
		//ScoreCard Data To Marks
		private int  intAnalyticalTo;
		private int  intQuantitativeTo;
		private int  intEWOverallTo;		
		private int  intEWGrammarTo;
		private int  intEWContentTo;
		private int  intEWVocabularyTo;
		private int  intEWSpellingTo;
		private int  intSLOverallTo;		
		private int  intSLSentenceTo;
		private int  intSLVocabularyTo;
		private int  intSLFluencyTo;
		private int  intSLPronunciationTo;
		private int  intKSTSpeedTo;
		private int  intKSTAccuracyTo;

		private string strResidentialCity;
		private DateTime strDOBFrom;
		private DateTime strDOBTo;

		private int intCurrentPage;
		private int intPageSize;
		private string strSortBy;
		private int intUserType;

		private string strCandidateList;
		//private int isActive;
		
		

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

		public int PGQualificationDetails
		{  
			get
			{	
				return strPGQualificationDetails;
			}
			set
			{				 
				strPGQualificationDetails = value;
			}
		}

		public string PGOtherQualification
		{  
			get
			{	
				return strPGOtherQualification;
			}
			set
			{				 
				strPGOtherQualification = value;
			}
		}

		public string PGUniversity
		{  
			get
			{	
				return strPGUniversity;
			}
			set
			{				 
				strPGUniversity = value;
			}
		}

		public string PGCollegeAddress
		{  
			get
			{	
				return strPGCollegeAddress;
			}
			set
			{				 
				strPGCollegeAddress = value;
			}
		}

		public string PGEducationCity
		{  
			get
			{	
				return strPGEducationCity;
			}
			set
			{				 
				strPGEducationCity = value;
			}
		}
		
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


		//Score Card
		public int	AnalyticalFrom
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

		public int	QuantitativeFrom
		{  
			get
			{	
				return intQuantitativeFrom;
			}
			set
			{				 
				intQuantitativeFrom = value;
			}
		}
		
		public int	EWOverallFrom
		{  
			get
			{	
				return intEWOverallFrom;
			}
			set
			{				 
				intEWOverallFrom = value;
			}
		}

		public int	EWGrammarFrom
		{  
			get
			{	
				return intEWGrammarFrom;
			}
			set
			{				 
				intEWGrammarFrom = value;
			}
		}
		
		
		public int	EWContentFrom
		{  
			get
			{	
				return intEWContentFrom;
			}
			set
			{				 
				intEWContentFrom = value;
			}
		}
		
		

		public int 	EWVocabularyFrom
		{  
			get
			{	
				return intEWVocabularyFrom;
			}
			set
			{				 
				intEWVocabularyFrom = value;
			}
		}
		
		public int EWSpellingFrom
		{  
			get
			{	
				return intEWSpellingFrom;
			}
			set
			{				 
				intEWSpellingFrom = value;
			}
		}

		public int	SLOverallFrom
		{  
			get
			{	
				return intSLOverallFrom;
			}
			set
			{				 
				intSLOverallFrom = value;
			}
		}

		public int SLSentenceFrom
		{  
			get
			{	
				return intSLSentenceFrom;
			}
			set
			{				 
				intSLSentenceFrom = value;
			}
		}
		
		public int SLVocabularyFrom
		{  
			get
			{	
				return intSLVocabularyFrom;
			}
			set
			{				 
				intSLVocabularyFrom = value;
			}
		}
		
		public int SLFluencyFrom
		{  
			get
			{	
				return intSLFluencyFrom;
			}
			set
			{				 
				intSLFluencyFrom = value;
			}
		}
			
		public int SLPronunciationFrom
		{  
			get
			{	
				return intSLPronunciationFrom;
			}
			set
			{				 
				intSLPronunciationFrom = value;
			}
		}
		
		public int KSTSpeedFrom
		{  
			get
			{	
				return intKSTSpeedFrom;
			}
			set
			{				 
				intKSTSpeedFrom = value;
			}
		}
		
		public int KSTAccuracyFrom
		{  
			get
			{	
				return intKSTAccuracyFrom;
			}
			set
			{				 
				intKSTAccuracyFrom = value;
			}
		}
		
		
		public int	AnalyticalTo
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

		public int	QuantitativeTo
		{  
			get
			{	
				return intQuantitativeTo;
			}
			set
			{				 
				intQuantitativeTo = value;
			}
		}
		
		public int	EWOverallTo
		{  
			get
			{	
				return intEWOverallTo;
			}
			set
			{				 
				intEWOverallTo = value;
			}
		}

		public int	EWGrammarTo
		{  
			get
			{	
				return intEWGrammarTo;
			}
			set
			{				 
				intEWGrammarTo = value;
			}
		}
		
		
		public int	EWContentTo
		{  
			get
			{	
				return intEWContentTo;
			}
			set
			{				 
				intEWContentTo = value;
			}
		}
		
		

		public int 	EWVocabularyTo
		{  
			get
			{	
				return intEWVocabularyTo;
			}
			set
			{				 
				intEWVocabularyTo = value;
			}
		}
		
		public int EWSpellingTo
		{  
			get
			{	
				return intEWSpellingTo;
			}
			set
			{				 
				intEWSpellingTo = value;
			}
		}

		public int	SLOverallTo
		{  
			get
			{	
				return intSLOverallTo;
			}
			set
			{				 
				intSLOverallTo = value;
			}
		}

		public int SLSentenceTo
		{  
			get
			{	
				return intSLSentenceTo;
			}
			set
			{				 
				intSLSentenceTo = value;
			}
		}
		
		public int SLVocabularyTo
		{  
			get
			{	
				return intSLVocabularyTo;
			}
			set
			{				 
				intSLVocabularyTo = value;
			}
		}
		
		public int SLFluencyTo
		{  
			get
			{	
				return intSLFluencyTo;
			}
			set
			{				 
				intSLFluencyTo= value;
			}
		}
			
		public int SLPronunciationTo
		{  
			get
			{	
				return intSLPronunciationTo;
			}
			set
			{				 
				intSLPronunciationTo = value;
			}
		}
		
		public int KSTSpeedTo
		{  
			get
			{	
				return intKSTSpeedTo;
			}
			set
			{				 
				intKSTSpeedTo = value;
			}
		}
		
		public int KSTAccuracyTo
		{  
			get
			{	
				return intKSTAccuracyTo;
			}
			set
			{				 
				intKSTAccuracyTo = value;
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
	
		public string SortBy
		{  
			get
			{	
				return strSortBy;
			}
			set
			{				 
				strSortBy = value;
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

		public string ScoreCardFormat
		{
			get
			{
				return strScoreCardFormat;
			}
			set 
			{
				strScoreCardFormat=value; 
			}
		}

		/// <summary>
		/// End
		/// </summary>
		public string RegistrationID
		{  
			get
			{	
				return registrationID;
			}
			set
			{				 
				registrationID = value;
			}
		}
		
		public DateTime TestDateFrom
		{  
			get
			{	
				return testDateFrom;
			}
			set
			{				 
				testDateFrom = value;
			}
		}	

		public DateTime TestDateTo
		{  
			get
			{	
				return testDateTo;
			}
			set
			{				 
				testDateTo = value;
			}
		}

		public int YearOfPassing12
		{  
			get
			{	
				return yearOfPassing12;
			}
			set
			{				 
				yearOfPassing12 = value;
			}
		}

		public int Percentage10Min
		{  
			get
			{	
				return percentage10Min;
			}
			set
			{				 
				percentage10Min = value;
			}
		}

		public int Percentage10Max
		{  
			get
			{	
				return percentage10Max;
			}
			set
			{				 
				percentage10Max = value;
			}
		}

		public int Percentage12Min
		{  
			get
			{	
				return percentage12Min;
			}
			set
			{				 
				percentage12Min = value;
			}
		}

		public int Percentage12Max
		{  
			get
			{	
				return percentage12Max;
			}
			set
			{				 
				percentage12Max = value;
			}
		}

		public int PercentageGraduationMin
		{  
			get
			{	
				return percentageGraduationMin;
			}
			set
			{				 
				percentageGraduationMin = value;
			}
		}

		public int PercentageGraduationMax
		{  
			get
			{	
				return percentageGraduationMax;
			}
			set
			{				 
				percentageGraduationMax = value;
			}
		}

		public int GraduationStream
		{
			get
			{
				return graduationStream;
			}
			set
			{
				graduationStream = value;
			}
		}

		public int YearOfGraduation
		{  
			get
			{	
				return yearOfGraduation;
			}
			set
			{				 
				yearOfGraduation = value;
			}
		}

		//Score Card
		public string AnalyticalMin
		{  
			get
			{	
				return analyticalMin;
			}
			set
			{				 
				analyticalMin = value;
			}
		}

		public string QuantitativeMin
		{  
			get
			{	
				return quantitativeMin;
			}
			set
			{				 
				quantitativeMin = value;
			}
		}
	
		public string EWOverallMin
		{  
			get
			{	
				return ewOverallMin;
			}
			set
			{				 
				ewOverallMin = value;
			}
		}

		public string EWGrammarMin
		{  
			get
			{	
				return ewGrammarMin;
			}
			set
			{				 
				ewGrammarMin = value;
			}
		}
		
		

		public string 	EWContentMin
		{  
			get
			{	
				return ewContentMin;
			}
			set
			{				 
				ewContentMin = value;
			}
		}
		
		public string EWVocabularyMin
		{  
			get
			{	
				return ewVocabularyMin;
			}
			set
			{				 
				ewVocabularyMin = value;
			}
		}

		public string EWSpellingMin
		{  
			get
			{	
				return ewSpellingMin;
			}
			set
			{				 
				ewSpellingMin = value;
			}
		}
		
		public string SLOverallMin
		{  
			get
			{	
				return slOverallMin;
			}
			set
			{				 
				slOverallMin = value;
			}
		}

		public string SLSentenceMin
		{  
			get
			{	
				return slSentenceMin;
			}
			set
			{				 
				slSentenceMin = value;
			}
		}
		
		public string SLVocabularyMin
		{  
			get
			{	
				return slVocabularyMin;
			}
			set
			{				 
				slVocabularyMin = value;
			}
		}
			
		public string SLFluencyMin
		{  
			get
			{	
				return slFluencyMin;
			}
			set
			{				 
				slFluencyMin = value;
			}
		}
		
		public string SLPronunciationMin
		{  
			get
			{	
				return slPronunciationMin;
			}
			set
			{				 
				slPronunciationMin = value;
			}
		}
		
		public string KSTSpeedMin
		{  
			get
			{	
				return kstSpeedMin;
			}
			set
			{				 
				kstSpeedMin = value;
			}
		}
		
		public string KSTAccuracyMin
		{  
			get
			{	
				return kstAccuracyMin;
			}
			set
			{				 
				kstAccuracyMin = value;
			}
		}
		

		public string AnalyticalMax
		{  
			get
			{	
				return analyticalMax;
			}
			set
			{				 
				analyticalMax = value;
			}
		}

		public string QuantitativeMax
		{  
			get
			{	
				return quantitativeMax;
			}
			set
			{				 
				quantitativeMax = value;
			}
		}

		public string EWOverallMax
		{  
			get
			{	
				return ewOverallMax;
			}
			set
			{				 
				ewOverallMax = value;
			}
		}
		
		public string EWGrammarMax
		{  
			get
			{	
				return ewGrammarMax;
			}
			set
			{				 
				ewGrammarMax = value;
			}
		}
		
		

		public string 	EWContentMax
		{  
			get
			{	
				return ewContentMax;
			}
			set
			{				 
				ewContentMax = value;
			}
		}
		
		public string EWVocabularyMax
		{  
			get
			{	
				return ewVocabularyMax;
			}
			set
			{				 
				ewVocabularyMax = value;
			}
		}

		public string EWSpellingMax
		{  
			get
			{	
				return ewSpellingMax;
			}
			set
			{				 
				ewSpellingMax = value;
			}
		}
		
		public string SLOverallMax
		{  
			get
			{	
				return slOverallMax;
			}
			set
			{				 
				slOverallMax = value;
			}
		}

		public string SLSentenceMax
		{  
			get
			{	
				return slSentenceMax;
			}
			set
			{				 
				slSentenceMax = value;
			}
		}
		
		public string SLVocabularyMax
		{  
			get
			{	
				return slVocabularyMax;
			}
			set
			{				 
				slVocabularyMax = value;
			}
		}
			
		public string SLFluencyMax
		{  
			get
			{	
				return slFluencyMax;
			}
			set
			{				 
				slFluencyMax = value;
			}
		}
		
		public string SLPronunciationMax
		{  
			get
			{	
				return slPronunciationMax;
			}
			set
			{				 
				slPronunciationMax = value;
			}
		}
		
		public string KSTSpeedMax
		{  
			get
			{	
				return kstSpeedMax;
			}
			set
			{				 
				kstSpeedMax = value;
			}
		}
		
		public string KSTAccuracyMax
		{  
			get
			{	
				return kstAccuracyMax;
			}
			set
			{				 
				kstAccuracyMax = value;
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
				dbManager.CreateParameters(45);
				int counter = 0;
				dbManager.AddParameters(counter++, "@RegistrationId", RegistrationID);
				dbManager.AddParameters(counter++, "@TestDateFrom", TestDateFrom);
				dbManager.AddParameters(counter++, "@TestDateTo", TestDateTo);
				
				dbManager.AddParameters(counter++, "@TestState", TestState);
				dbManager.AddParameters(counter++, "@TestCity", TestCity);
				
				dbManager.AddParameters(counter++, "@DOBDateFrom", DOBFrom);
				dbManager.AddParameters(counter++, "@DOBDateTo", DOBTo);
				dbManager.AddParameters(counter++, "@Gender", Gender);
				dbManager.AddParameters(counter++, "@YearOfPassing12", YearOfPassing12);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMin", PercentageGraduationMin);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMax", PercentageGraduationMax);	
				dbManager.AddParameters(counter++, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(counter++, "@GraduationStream", GraduationStream);
				dbManager.AddParameters(counter++, "@GraduationYearOfPassing", YearOfGraduation);

				dbManager.AddParameters(counter++, "@AnalyticalMin",AnalyticalMin);
				dbManager.AddParameters(counter++, "@QuantitativeMin",QuantitativeMin);
				
				dbManager.AddParameters(counter++, "@EWOverallMin",EWOverallMin);
				dbManager.AddParameters(counter++, "@EWGrammarMin",EWGrammarMin);
				dbManager.AddParameters(counter++, "@EWContentMin",EWContentMin);
				dbManager.AddParameters(counter++, "@EWVocabularyMin",EWVocabularyMin);
				dbManager.AddParameters(counter++, "@EWSpellingMin",EWSpellingMin);

				dbManager.AddParameters(counter++, "@SLOverallMin",SLOverallMin);
				dbManager.AddParameters(counter++, "@SLSentenceMin",SLSentenceMin);
				dbManager.AddParameters(counter++, "@SLVocabularyMin",SLVocabularyMin);
				dbManager.AddParameters(counter++, "@SLFluencyMin",SLFluencyMin);
				dbManager.AddParameters(counter++, "@SLPronunciationMin",SLPronunciationMin);

				dbManager.AddParameters(counter++, "@KSTSpeedMin",KSTSpeedMin);
				dbManager.AddParameters(counter++, "@KSTAccuracyMin",KSTAccuracyMin);

				dbManager.AddParameters(counter++, "@AnalyticalMax",AnalyticalMax);
				dbManager.AddParameters(counter++, "@QuantitativeMax",QuantitativeMax);
				
				dbManager.AddParameters(counter++, "@EWOverallMax",EWOverallMax);
				dbManager.AddParameters(counter++, "@EWGrammarMax",EWGrammarMax);
				dbManager.AddParameters(counter++, "@EWContentMax",EWContentMax);
				dbManager.AddParameters(counter++, "@EWVocabularyMax",EWVocabularyMax);
				dbManager.AddParameters(counter++, "@EWSpellingMax",EWSpellingMax);

				dbManager.AddParameters(counter++, "@SLOverallMax",SLOverallMax);
				dbManager.AddParameters(counter++, "@SLSentenceMax",SLSentenceMax);
				dbManager.AddParameters(counter++, "@SLVocabularyMax",SLVocabularyMax);
				dbManager.AddParameters(counter++, "@SLFluencyMax",SLFluencyMax);
				dbManager.AddParameters(counter++, "@SLPronunciationMax",SLPronunciationMax);

				dbManager.AddParameters(counter++, "@KSTSpeedMax",KSTSpeedMax);
				dbManager.AddParameters(counter++, "@KSTAccuracyMax",KSTAccuracyMax);
				
				dbManager.AddParameters(counter++, "@CurrentPage", CurrentPage);
				dbManager.AddParameters(counter++, "@PageSize", PageSize);	
				dbManager.AddParameters(counter++, "@SortBy", SortBy);	

				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidateByCompany"));				 
				 
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

		#region ExportAllCandidateListByCompany

		public DataTable ExportAllCandidateListByCompany()
		{
			try
			{				 
				conn = new DBConnection();			
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(42);
				
				int counter = 0;
				dbManager.AddParameters(counter++, "@RegistrationId", RegistrationID);
				dbManager.AddParameters(counter++, "@TestDateFrom", TestDateFrom);
				dbManager.AddParameters(counter++, "@TestDateTo", TestDateTo);
				
				dbManager.AddParameters(counter++, "@TestState", TestState);
				dbManager.AddParameters(counter++, "@TestCity", TestCity);
				
				dbManager.AddParameters(counter++, "@DOBDateFrom", DOBFrom);
				dbManager.AddParameters(counter++, "@DOBDateTo", DOBTo);
				dbManager.AddParameters(counter++, "@Gender", Gender);
				dbManager.AddParameters(counter++, "@YearOfPassing12", YearOfPassing12);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMin", PercentageGraduationMin);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMax", PercentageGraduationMax);	
				dbManager.AddParameters(counter++, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(counter++, "@GraduationStream", GraduationStream);
				dbManager.AddParameters(counter++, "@GraduationYearOfPassing", YearOfGraduation);

				dbManager.AddParameters(counter++, "@AnalyticalMin",AnalyticalMin);
				dbManager.AddParameters(counter++, "@QuantitativeMin",QuantitativeMin);
				
				dbManager.AddParameters(counter++, "@EWOverallMin",EWOverallMin);
				dbManager.AddParameters(counter++, "@EWGrammarMin",EWGrammarMin);
				dbManager.AddParameters(counter++, "@EWContentMin",EWContentMin);
				dbManager.AddParameters(counter++, "@EWVocabularyMin",EWVocabularyMin);
				dbManager.AddParameters(counter++, "@EWSpellingMin",EWSpellingMin);

				dbManager.AddParameters(counter++, "@SLOverallMin",SLOverallMin);
				dbManager.AddParameters(counter++, "@SLSentenceMin",SLSentenceMin);
				dbManager.AddParameters(counter++, "@SLVocabularyMin",SLVocabularyMin);
				dbManager.AddParameters(counter++, "@SLFluencyMin",SLFluencyMin);
				dbManager.AddParameters(counter++, "@SLPronunciationMin",SLPronunciationMin);

				dbManager.AddParameters(counter++, "@KSTSpeedMin",KSTSpeedMin);
				dbManager.AddParameters(counter++, "@KSTAccuracyMin",KSTAccuracyMin);

				dbManager.AddParameters(counter++, "@AnalyticalMax",AnalyticalMax);
				dbManager.AddParameters(counter++, "@QuantitativeMax",QuantitativeMax);

				dbManager.AddParameters(counter++, "@EWOverallMax",EWOverallMax);
				dbManager.AddParameters(counter++, "@EWGrammarMax",EWGrammarMax);
				dbManager.AddParameters(counter++, "@EWContentMax",EWContentMax);
				dbManager.AddParameters(counter++, "@EWVocabularyMax",EWVocabularyMax);
				dbManager.AddParameters(counter++, "@EWSpellingMax",EWSpellingMax);

				dbManager.AddParameters(counter++, "@SLOverallMax",SLOverallMax);
				dbManager.AddParameters(counter++, "@SLSentenceMax",SLSentenceMax);
				dbManager.AddParameters(counter++, "@SLVocabularyMax",SLVocabularyMax);
				dbManager.AddParameters(counter++, "@SLFluencyMax",SLFluencyMax);
				dbManager.AddParameters(counter++, "@SLPronunciationMax",SLPronunciationMax);

				dbManager.AddParameters(counter++, "@KSTSpeedMax",KSTSpeedMax);
				dbManager.AddParameters(counter++, "@KSTAccuracyMax",KSTAccuracyMax);

				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ExportAllCandidateListByCompanyV2").Tables[0]);				 
				 
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

		#region GenerateAllPercentMultipleScoreCard()

		public DataTable GenerateAllPercentMultipleScoreCard()
		{
			try
			{				 
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(42);
				int counter = 0;
				dbManager.AddParameters(counter++, "@RegistrationId", RegistrationID);
				dbManager.AddParameters(counter++, "@TestDateFrom", TestDateFrom);
				dbManager.AddParameters(counter++, "@TestDateTo", TestDateTo);
				
				dbManager.AddParameters(counter++, "@TestState", TestState);
				dbManager.AddParameters(counter++, "@TestCity", TestCity);
				
				dbManager.AddParameters(counter++, "@DOBDateFrom", DOBFrom);
				dbManager.AddParameters(counter++, "@DOBDateTo", DOBTo);
				dbManager.AddParameters(counter++, "@Gender", Gender);
				dbManager.AddParameters(counter++, "@YearOfPassing12", YearOfPassing12);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMin", PercentageGraduationMin);	
				dbManager.AddParameters(counter++, "@PercentageGraduationMax", PercentageGraduationMax);	
				dbManager.AddParameters(counter++, "@QualificationDetails", QualificationDetails);
				dbManager.AddParameters(counter++, "@GraduationStream", GraduationStream);
				dbManager.AddParameters(counter++, "@GraduationYearOfPassing", YearOfGraduation);

				dbManager.AddParameters(counter++, "@AnalyticalMin",AnalyticalMin);
				dbManager.AddParameters(counter++, "@QuantitativeMin",QuantitativeMin);
				
				dbManager.AddParameters(counter++, "@EWOverallMin",EWOverallMin);
				dbManager.AddParameters(counter++, "@EWGrammarMin",EWGrammarMin);
				dbManager.AddParameters(counter++, "@EWContentMin",EWContentMin);
				dbManager.AddParameters(counter++, "@EWVocabularyMin",EWVocabularyMin);
				dbManager.AddParameters(counter++, "@EWSpellingMin",EWSpellingMin);

				dbManager.AddParameters(counter++, "@SLOverallMin",SLOverallMin);
				dbManager.AddParameters(counter++, "@SLSentenceMin",SLSentenceMin);
				dbManager.AddParameters(counter++, "@SLVocabularyMin",SLVocabularyMin);
				dbManager.AddParameters(counter++, "@SLFluencyMin",SLFluencyMin);
				dbManager.AddParameters(counter++, "@SLPronunciationMin",SLPronunciationMin);

				dbManager.AddParameters(counter++, "@KSTSpeedMin",KSTSpeedMin);
				dbManager.AddParameters(counter++, "@KSTAccuracyMin",KSTAccuracyMin);

				dbManager.AddParameters(counter++, "@AnalyticalMax",AnalyticalMax);
				dbManager.AddParameters(counter++, "@QuantitativeMax",QuantitativeMax);
				
				dbManager.AddParameters(counter++, "@EWOverallMax",EWOverallMax);
				dbManager.AddParameters(counter++, "@EWGrammarMax",EWGrammarMax);
				dbManager.AddParameters(counter++, "@EWContentMax",EWContentMax);
				dbManager.AddParameters(counter++, "@EWVocabularyMax",EWVocabularyMax);
				dbManager.AddParameters(counter++, "@EWSpellingMax",EWSpellingMax);

				dbManager.AddParameters(counter++, "@SLOverallMax",SLOverallMax);
				dbManager.AddParameters(counter++, "@SLSentenceMax",SLSentenceMax);
				dbManager.AddParameters(counter++, "@SLVocabularyMax",SLVocabularyMax);
				dbManager.AddParameters(counter++, "@SLFluencyMax",SLFluencyMax);
				dbManager.AddParameters(counter++, "@SLPronunciationMax",SLPronunciationMax);

				dbManager.AddParameters(counter++, "@KSTSpeedMax",KSTSpeedMax);
				dbManager.AddParameters(counter++, "@KSTAccuracyMax",KSTAccuracyMax);
				
//				dbManager.AddParameters(counter++, "@CurrentPage", CurrentPage);
//				dbManager.AddParameters(counter++, "@PageSize", PageSize);	

				//return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"SearchCandidateByCompany"));	
		
				return ((DataTable) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetAllScoreCardForCompanyV2").Tables[0]);				 
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


		public BLCandidateSearchByCompany()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
