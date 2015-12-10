using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; 
using System.Web; 
using ExceptionHandling;
using Common;
using System.IO;
using DataAccessLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLScoreCard.
	/// </summary>
	public class BLNACScoreCard
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);


		public BLNACScoreCard()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		private DataAccessLayer.DBConnection conn;
		private string strConn;			
		private string strNACRegID;
		private string strCandidateName;
		private string strFirstName;
		private string strMiddleName;
		private string strLastName;
		private DateTime  dtDOB;
		private string strTestLocation;
		private DateTime   dtTestDate;
		private string intAQRScore;
		private string intAQRMaxScore;
		private string strAQRPercentage;
		private string  strAQRPercentile;
		private string intWritingScore;
		private string intWritingMaxScore;
		private string strWritingPercentage;
		private string strWritingPercentile;
		private string intLAScore;
		private string intLAMaxScore;
		private string strLAPercentage;
		private string strLAPercentile;
		private string intListeningScore;
		private string intListeningMaxScore;
		private string strListeningPercentage;
		private string strListeningPercentile;
		private string intKeyboardGrossSpeed;
		private string intKeyboardAccuracy;
		private string intKeyboardNetSpeed;
		private string strKeyboardPercentile;

		private string intSpeakingMaxScore;
		private string intSpeakingVoiceClarity;		
		private string intSpeakingAccent;
		private string intSpeakingFluency;
		private string intSpeakingGrammar;
		private string intSpeakingProsody;
		private string strSpeakingPercentile;

		private string strSpeakingPercentage;
//		private string strSpeakingVoiceClarityPercentage;		
//		private string strSpeakingAccentPercentage;
//		private string strSpeakingFluencyPercentage;
//		private string strSpeakingGrammarPercentage;
//		private string strSpeakingProsodyPercentage;

		private string intWritingEssayMaxScore;		
		private string intWritingEssayGrammar;
		private string intWritingEssayContent;
		private string intWritingEssayVocabulary;
		private string intWritingEssaySpelling_Punctuation;
		private string strWritingEssayPercentile;

		private string strWritingEssayPercentage;
		private string strIPAddress;
		private DateTime strfirstclickdate;
//		private string strWritingEssayGrammarPercentage;
//		private string strWritingEssayContentPercentage;
//		private string strWritingEssayVocabularyPercentage;
//		private string strWritingEssaySpelling_PunctuationPercentage;

		private string strTierInfo;

		public string  NACRegID
		{  
			get
			{
				return strNACRegID;
			}
			set
			{			
				strNACRegID= value;
			} 		
		}


		public string  CandidateName
		{  
			get
			{
				return strCandidateName; 
			}
			set
			{
				strCandidateName= value; 			
			} 		
		}
		public DateTime  firstclickdate
		{  
			get
			{
				return strfirstclickdate; 
			}
			set
			{
				strfirstclickdate= value; 			
			} 		
		}
		public string  IPAddress
		{  
			get
			{
				return strIPAddress; 
			}
			set
			{
				strIPAddress= value; 			
			} 		
		}

		public DateTime  DOB
		{  
			get
			{	 	
				return dtDOB; 		
			}
			set
			{
				dtDOB= value;
			} 		
		}


		public string  TestLocation
		{  
			get
			{	 	
				return strTestLocation;
			}
			set
			{
				strTestLocation= value;
			} 		
		}


		public DateTime  TestDate
		{  
			get
			{
				return dtTestDate;
			}
			set
			{
				dtTestDate= value;
			} 		
		}


		public string  AQRScore
		{  
			get
			{	
				return intAQRScore;
			}
			set
			{
				intAQRScore= value; 
			} 		
		}


		public string  AQRMaxScore
		{  
			get
			{	
				return intAQRMaxScore;
			}
			set
			{
				intAQRMaxScore= value; 
			} 		
		}


		public string  AQRPercentage
		{  
			get
			{
				return strAQRPercentage; 
			}
			set
			{
				strAQRPercentage= value; 
			} 		
		}


		public string AQRPercentile
		{  
			get
			{
				return strAQRPercentile;
			}
			set
			{
				strAQRPercentile= value; 
			} 		
		}


		public string  WritingScore
		{  
			get
			{
				return intWritingScore;
			}
			set
			{
				intWritingScore= value;
			} 		
		}

		public string  WritingMaxScore
		{  
			get
			{	
				return intWritingMaxScore;
			}
			set
			{
				intWritingMaxScore= value; 
			} 		
		}


		public string  WritingPercentage
		{  
			get
			{
				return strWritingPercentage; 
			}
			set
			{
				strWritingPercentage= value; 	
			} 		
		}


		public string  WritingPercentile
		{  
			get
			{
				return strWritingPercentile;
			}
			set
			{
				strWritingPercentile= value;
			} 		
		}


		public string  LAScore
		{  
			get
			{
				return intLAScore; 
			}
			set
			{
				intLAScore= value; 
			} 		
		}

		public string  LAMaxScore
		{  
			get
			{	
				return intLAMaxScore;
			}
			set
			{
				intLAMaxScore= value; 
			} 		
		}


		public string  LAPercentage
		{  
			get
			{
				 return strLAPercentage; 			
			}
			set
			{
				strLAPercentage= value;
			} 		
		}


		public string  LAPercentile
		{  
			get
			{
				return strLAPercentile; 			
			}
			set
			{
				strLAPercentile= value; 			
			} 		
		}


		public string  ListeningScore
		{  
			get
			{
				return intListeningScore; 			
			}
			set
			{
				intListeningScore= value; 			
			} 		
		}

		public string  ListeningMaxScore
		{  
			get
			{	
				return intListeningMaxScore;
			}
			set
			{
				intListeningMaxScore= value; 
			} 		
		}


		public string  ListeningPercentage
		{  
			get
			{
				return strListeningPercentage; 			
			}
			set
			{
				strListeningPercentage= value; 	
			} 		
		}


		public string  ListeningPercentile
		{  
			get
			{
				return strListeningPercentile;
			}
			set
			{
				strListeningPercentile= value; 	
			} 		
		}


		public string  KeyboardGrossSpeed
		{  
			get
			{	 
				return intKeyboardGrossSpeed; 	
			}
			set
			{				
				intKeyboardGrossSpeed= value; 	
			} 		
		}


		public string  KeyboardAccuracy
		{  
			get
			{	 	
				return intKeyboardAccuracy; 	
			}
			set
			{			
				intKeyboardAccuracy= value; 	
			} 		
		}



		public string  KeyboardNetSpeed
		{  
			get
			{	 		
				return intKeyboardNetSpeed; 
			}
			set
			{				
				intKeyboardNetSpeed= value; 	
			} 		
		}


		public string  KeyboardPercentile
		{  
			get
			{	 		
				return strKeyboardPercentile; 		
			}
			set
			{			
				strKeyboardPercentile= value; 		
			} 		
		}


		public string  SpeakingVoiceClarity
		{  
			get
			{	 	
				return intSpeakingVoiceClarity; 		
			}
			set
			{		
				intSpeakingVoiceClarity= value; 		
			} 		
		}

		public string  SpeakingMaxScore
		{  
			get
			{	 	
				return intSpeakingMaxScore; 		
			}
			set
			{		
				intSpeakingMaxScore= value; 		
			} 		
		}


		public string  SpeakingAccent
		{  
			get
			{	 	
				return intSpeakingAccent; 		
			}
			set
			{			
				intSpeakingAccent= value; 		
			} 		
		}


		public string  SpeakingFluency
		{  
			get
			{	 	
				return intSpeakingFluency; 		
			}
			set
			{			
				intSpeakingFluency= value; 		
			} 		
		}


		public string  SpeakingGrammar
		{  
			get
			{	 			
				return intSpeakingGrammar; 		
			}
			set
			{			
				intSpeakingGrammar= value; 	
			} 		
		}


		public string  SpeakingProsody
		{  
			get
			{	 	
				return intSpeakingProsody; 	
			}
			set
			{		
				intSpeakingProsody= value; 	
			} 		
		}


		public string  SpeakingPercentile
		{  
			get
			{	 		
				return strSpeakingPercentile; 	
			}
			set
			{			
				strSpeakingPercentile= value; 	
			} 		
		}


		public string  WritingEssayMaxScore
		{  
			get
			{	 		
				return intWritingEssayMaxScore; 	
			}
			set
			{			
				intWritingEssayMaxScore= value; 		
			} 		
		}

		public string  WritingEssayGrammar
		{  
			get
			{	 		
				return intWritingEssayGrammar; 	
			}
			set
			{			
				intWritingEssayGrammar= value; 		
			} 		
		}


		public string  WritingEssayContent
		{  
			get
			{	 
				return intWritingEssayContent; 	
			}
			set
			{	
				intWritingEssayContent= value; 	
			} 		
		}


		public string  WritingEssayVocabulary
		{  
			get
			{	 	
				return intWritingEssayVocabulary; 
			}
			set
			{		
				intWritingEssayVocabulary= value; 	
			} 		
		}


		public string  WritingEssaySpelling_Punctuation
		{  
			get
			{	 		
				return intWritingEssaySpelling_Punctuation; 
			}
			set
			{			
				intWritingEssaySpelling_Punctuation= value; 	
			} 		
		}


		public string WritingEssayPercentile   
		{  
			get
			{	 			
				return strWritingEssayPercentile; 	
			}
			set
			{			
				strWritingEssayPercentile   = value; 
			} 		
		}		

		public string SpeakingPercentage   
		{  
			get
			{	 			
				return strSpeakingPercentage; 	
			}
			set
			{			
				strSpeakingPercentage   = value; 
			} 		
		}

//		public string SpeakingAccentPercentage   
//		{  
//			get
//			{	 			
//				return strSpeakingAccentPercentage; 	
//			}
//			set
//			{			
//				strSpeakingAccentPercentage   = value; 
//			} 		
//		}
//
//		public string SpeakingFluencyPercentage   
//		{  
//			get
//			{	 			
//				return strSpeakingFluencyPercentage; 	
//			}
//			set
//			{			
//				strSpeakingFluencyPercentage   = value; 
//			} 		
//		}
//
//		public string SpeakingGrammarPercentage   
//		{  
//			get
//			{	 			
//				return strSpeakingGrammarPercentage; 	
//			}
//			set
//			{			
//				strSpeakingGrammarPercentage   = value; 
//			} 		
//		}
//
//		public string SpeakingProsodyPercentage   
//		{  
//			get
//			{	 			
//				return strSpeakingProsodyPercentage; 	
//			}
//			set
//			{			
//				strSpeakingProsodyPercentage   = value; 
//			} 		
//		}

//		public string WritingEssayGrammarPercentage   
//		{  
//			get
//			{	 			
//				return strWritingEssayGrammarPercentage; 	
//			}
//			set
//			{			
//				strWritingEssayGrammarPercentage   = value; 
//			} 		
//		}
//
//		public string WritingEssayContentPercentage   
//		{  
//			get
//			{	 			
//				return strWritingEssayContentPercentage; 	
//			}
//			set
//			{			
//				strWritingEssayContentPercentage   = value; 
//			} 		
//		}
//
//		public string WritingEssayVocabularyPercentage   
//		{  
//			get
//			{	 			
//				return strWritingEssayVocabularyPercentage; 	
//			}
//			set
//			{			
//				strWritingEssayVocabularyPercentage   = value; 
//			} 		
//		}

		public string WritingEssayPercentage   
		{  
			get
			{	 			
				return strWritingEssayPercentage; 	
			}
			set
			{			
				strWritingEssayPercentage   = value; 
			} 		
		}

		public string TierInfo   
		{  
			get
			{	 			
				return strTierInfo; 	
			}
			set
			{			
				strTierInfo  = value; 
			} 		
		}



		//for candidate info update

		public string  FirstName
		{  
			get
			{
				return strFirstName; 
			}
			set
			{
				strFirstName= value; 			
			} 		
		}

		public string  MiddleName
		{  
			get
			{
				return strMiddleName; 
			}
			set
			{
				strMiddleName= value; 			
			} 		
		}

		public string  LastName
		{  
			get
			{
				return strLastName; 
			}
			set
			{
				strLastName= value; 			
			} 		
		}

		public void UpdateCandidateInfo()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(5);
				dbManager.AddParameters(0,"@NACRegID",NACRegID,ParameterDirection.Input);		
				dbManager.AddParameters(1,"@FirstName",CandidateName,ParameterDirection.Input);		
				dbManager.AddParameters(2,"@MiddleName",CandidateName,ParameterDirection.Input);	
				dbManager.AddParameters(3,"@LastName",CandidateName,ParameterDirection.Input);	
				dbManager.AddParameters(4,"@DOB",DOB,ParameterDirection.Input);					

				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"UpdateCandidateInfo");
				dbManager.CommitTransaction();
			}
			catch
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				throw;
			}	
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}		 
		}

       //for candidate info update end

		public void InsertScore()
		{
			try
			{
				conn = new DBConnection();
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);			 
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();
				dbManager.BeginTransaction();
				dbManager.CreateParameters(30);
				dbManager.AddParameters(0,"@NACRegID",NACRegID,ParameterDirection.Input);		
				//dbManager.AddParameters(1,"@CandidateName",CandidateName,ParameterDirection.Input);		
				//dbManager.AddParameters(2,"@DOB",DOB,ParameterDirection.Input);		
				//dbManager.AddParameters(3,"@TestLocation",TestLocation,ParameterDirection.Input);		
				//dbManager.AddParameters(4,"@TestDate",TestDate,ParameterDirection.Input);		
				dbManager.AddParameters(1,"@AQRScore",AQRScore,ParameterDirection.Input);		
				dbManager.AddParameters(2,"@AQRMaxScore",AQRMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(3,"@AQRPercentage",AQRPercentage,ParameterDirection.Input);		
				//dbManager.AddParameters(8,"@AQRPercentile",AQRPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(4,"@WritingScore",WritingScore,ParameterDirection.Input);		
				dbManager.AddParameters(5,"@WritingMaxScore",WritingMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(6,"@WritingPercentage",WritingPercentage,ParameterDirection.Input);		
				//dbManager.AddParameters(12,"@WritingPercentile",WritingPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(7,"@LAScore",LAScore,ParameterDirection.Input);		
				dbManager.AddParameters(8,"@LAMaxScore",LAMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(9,"@LAPercentage",LAPercentage,ParameterDirection.Input);		
				//dbManager.AddParameters(16,"@LAPercentile",LAPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(10,"@ListeningScore",ListeningScore,ParameterDirection.Input);		
				dbManager.AddParameters(11,"@ListeningMaxScore",ListeningMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(12,"@ListeningPercentage",ListeningPercentage,ParameterDirection.Input);		
				//dbManager.AddParameters(20,"@ListeningPercentile",ListeningPercentile,ParameterDirection.Input);						
				dbManager.AddParameters(13,"@KeyboardGrossSpeed",KeyboardGrossSpeed,ParameterDirection.Input);		
				dbManager.AddParameters(14,"@KeyboardAccuracy",KeyboardAccuracy,ParameterDirection.Input);		
				dbManager.AddParameters(15,"@KeyboardNetSpeed",KeyboardNetSpeed,ParameterDirection.Input);		
				//dbManager.AddParameters(24,"@KeyboardPercentile",KeyboardPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(16,"@SpeakingMaxScore",SpeakingMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(17,"@SpeakingVoiceClarity",SpeakingVoiceClarity,ParameterDirection.Input);		
				dbManager.AddParameters(18,"@SpeakingAccent",SpeakingAccent,ParameterDirection.Input);		
				dbManager.AddParameters(19,"@SpeakingFluency",SpeakingFluency,ParameterDirection.Input);		
				dbManager.AddParameters(20,"@SpeakingGrammar",SpeakingGrammar,ParameterDirection.Input);		
				dbManager.AddParameters(21,"@SpeakingProsody",SpeakingProsody,ParameterDirection.Input);		
				//dbManager.AddParameters(31,"@SpeakingPercentile",SpeakingPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(22,"@WritingEssayMaxScore",WritingEssayMaxScore,ParameterDirection.Input);		
				dbManager.AddParameters(23,"@WritingEssayGrammar",WritingEssayGrammar,ParameterDirection.Input);		
				dbManager.AddParameters(24,"@WritingEssayContent",WritingEssayContent,ParameterDirection.Input);		
				dbManager.AddParameters(25,"@WritingEssayVocabulary",WritingEssayVocabulary,ParameterDirection.Input);		
				dbManager.AddParameters(26,"@WritingEssaySpelling_Punctuation",WritingEssaySpelling_Punctuation,ParameterDirection.Input);		
				//dbManager.AddParameters(37,"@WritingEssayPercentile",WritingEssayPercentile,ParameterDirection.Input);		
				dbManager.AddParameters(27,"@SpeakingPercentage",SpeakingPercentage,ParameterDirection.Input);				

				
				dbManager.AddParameters(28,"@WritingEssayPercentage",WritingEssayPercentage,ParameterDirection.Input);	
	
				dbManager.AddParameters(29,"@TierInfo",TierInfo,ParameterDirection.Input);				
				

				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddNACScore");
				dbManager.CommitTransaction();
			}
			catch
			{
				dbManager.RollbackTransaction();
				dbManager.Close();
				throw;
			}	
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}		 
		}
		public int IsScoreExits(string strNACRegID)
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
				dbManager.AddParameters(0,"@NACRegID",strNACRegID,ParameterDirection.Input);						
				intCheck = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"IsScoreExits"));				 
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
		public DataSet GetScoreRegistrationID(string strNACRegID)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@NACRegID", strNACRegID);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetScoreRegistrationID");
			 
				
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
		public void AddTJVisit()
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
				dbManager.CreateParameters(3);		//Number of parameters to be passed in StoredProcedure
				dbManager.AddParameters(0,"@IpAddress",strIPAddress,ParameterDirection.Input);
				dbManager.AddParameters(1,"@RegistrationId",strNACRegID,ParameterDirection.Input);	
				dbManager.AddParameters(2,"@ClickDate",strfirstclickdate,ParameterDirection.Input);
				//Executing Command and storing Registrationid as Output Parameter in strRegistrationId
				dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure,"AddTJVisit");				 
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
		public DataSet GetTestScore(string strNACRegID)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@NACRegID", strNACRegID);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetTestScore");
			 
				
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


		public DataSet GetTestScoreV2(string strNACRegID)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@PinNo", strNACRegID);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetScoreDetailsV2");
			 
				
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

		public DataSet GetScoreCardRemarksV2(string strNACRegID)
		{
			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@RegistrationId", strNACRegID);
				return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetScoreCardRemarksV2");
			 
				
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
		
	}
}
