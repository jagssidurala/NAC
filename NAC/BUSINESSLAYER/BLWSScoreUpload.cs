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
	/// Summary description for BLWSScoreUpload.
	/// </summary>
	public class BLWSScoreUpload
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private ScoreUploadRequest req = new ScoreUploadRequest();
		private ScoreUploadResponse res = new ScoreUploadResponse();
		private DataAccessLayer.DBConnection conn;
		private string strConn;	
			

		public ScoreUploadRequest UploadRequest
		{  
			get{return req;}
			set{req = value;}
		}		
		public ScoreUploadResponse UploadResponse
		{  
			get{return res;}
			set{res = value;}
		}

		public BLWSScoreUpload()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int ValidateRgistrationId(string RegistrationId)
		{
			try
			{
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);			
				dbManager.AddParameters(0, "@RegistrationId", RegistrationId,ParameterDirection.Input);
				int count= (Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"ValidateRegistrationId")));				 
				dbManager.CommitTransaction();
				return count;
			}
			catch(Exception ex)
			{
				dbManager.RollbackTransaction();
				throw ex;
			}
			finally
			{
				
				dbManager.Close();
			}	
		}
				
		

		#region AuthenticateCandidateDetails
		public  ScoreUploadResponse UploadCandidateScores(ScoreUploadRequest Req)
		{
			try
			{	
				int i32NoOfRows = 0;
				res.RegistrationId=Req.RegistrationId;
				conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(17);			
				dbManager.AddParameters(0, "@RegistrationId", Req.RegistrationId.ToUpper(),ParameterDirection.Input);
				dbManager.AddParameters(1, "@AnalyticalScore", Req.Scores.AnalyticalScore,ParameterDirection.Input);
				dbManager.AddParameters(2, "@QuantitativeScore", Req.Scores.QuantitativeScore,ParameterDirection.Input);
				dbManager.AddParameters(3, "@EWOverallScore", Req.Scores.EWOverallScore,ParameterDirection.Input);
				dbManager.AddParameters(4, "@EWGrammarScore", Req.Scores.EWGrammarScore,ParameterDirection.Input);
				dbManager.AddParameters(5, "@EWContentScore", Req.Scores.EWContentScore,ParameterDirection.Input);
				dbManager.AddParameters(6, "@EWVocabularyScore", Req.Scores.EWVocabularyScore,ParameterDirection.Input);
				dbManager.AddParameters(7, "@EWSpellingScore", Req.Scores.EWSpellingScore,ParameterDirection.Input);
				dbManager.AddParameters(8, "@SLOverallScore", Req.Scores.SLOverallScore,ParameterDirection.Input);
				dbManager.AddParameters(9, "@SLSentenceScore", Req.Scores.SLSentenceScore,ParameterDirection.Input);
				dbManager.AddParameters(10, "@SLVocabularyScore", Req.Scores.SLVocabularyScore,ParameterDirection.Input);
				dbManager.AddParameters(11, "@SLFluencyScore", Req.Scores.SLFluencyScore,ParameterDirection.Input);
				dbManager.AddParameters(12, "@SLPronunciationScore", Req.Scores.SLPronunciationScore,ParameterDirection.Input);
				dbManager.AddParameters(13, "@KSTSpeedScore", Req.Scores.KSTSpeedScore,ParameterDirection.Input);
				dbManager.AddParameters(14, "@KSTAccuracyScore", Req.Scores.KSTAccuracyScore,ParameterDirection.Input);
				dbManager.AddParameters(15, "@CDT_TinNo", Req.CDT_TinNo,ParameterDirection.Input);
				dbManager.AddParameters(16, "@NoOfRows", i32NoOfRows,ParameterDirection.Output);
				int count = (Convert.ToInt32(dbManager.ExecuteNonQuery_SP(System.Data.CommandType.StoredProcedure,"UploadScoreV2","@NoOfRows")));				 
				dbManager.CommitTransaction();
				if (count > 0)
				{
					res.Response.ResponseID="1";
					res.Response.Message="OK";
				}
				else
				{
					res.Response.ResponseID="0";
					res.Response.Message="NOK-Scores not uploaded. Please contact the administrator";
				}
				return res;
			}
				
			catch(Exception ex)
			{
				dbManager.RollbackTransaction();
				throw ex;
			}
			finally
			{
				
				dbManager.Close();
			}
		}
		#endregion


	}


	public class ScoreUploadRequest
	{
		private string strRegistrationID;
		private string strCDT_TinNo;
		private Score objscore;
			
		public string RegistrationId
		{  
			get{return strRegistrationID;}
			set{strRegistrationID = value;}
		}	

		public string CDT_TinNo
		{  
			get{return strCDT_TinNo;}
			set{strCDT_TinNo = value;}
		}	

		public Score Scores
		{  
			get{return objscore;}
			set{objscore = value;}
			
		}		
		
	}

	public class Score
	{
		//private string strAnalyticalScoreRange;
		private string strAnalyticalScore;
		//private string strQuantitativeScoreRange;
		private string strQuantitativeScore;
		//private string strEWOverallScoreRange;
		private string strEWOverallScore;
		//private string strEWGrammarScoreRange;
		private string strEWGrammarScore;
		//private string strEWContentScoreRange;
		private string strEWContentScore;
		//private string strEWVocabularyScoreRange;
		private string strEWVocabularyScore;
		//private string strEWSpellingScoreRange;
		private string strEWSpellingScore;
		private string strSLOverallScore;
		private string strSLSentenceScore;
		//private string strSLVocabularyScoreRange;
		private string strSLVocabularyScore;
		//private string strSLFluencyScoreRange;
		private string strSLFluencyScore;
		//private string strSLPronunciationScoreRange;
		private string strSLPronunciationScore;
		//private string strKSTSpeedScoreRange;
		private string strKSTSpeedScore;
		//private string strKSTAccuracyScoreRange;
		private string strKSTAccuracyScore;	
			
		
//		public string AnalyticalScoreRange
//		{  
//			get{return strAnalyticalScoreRange;}
//			set{strAnalyticalScoreRange = value;}
//		}		
		public string AnalyticalScore
		{  
			get{return strAnalyticalScore;}
			set{strAnalyticalScore = value;}
		}
//		public string QuantitativeScoreRange
//		{  
//			get{return strQuantitativeScoreRange;}
//			set{strQuantitativeScoreRange = value;}
//		}
		public string QuantitativeScore
		{  
			get{return strQuantitativeScore;}
			set{strQuantitativeScore = value;}
		}

		public string EWOverallScore
		{  
			get{return strEWOverallScore;}
			set{strEWOverallScore = value;}
		}
		//		public string EWGrammarScoreRange
//		{  
//			get{return strEWGrammarScoreRange;}
//			set{strEWGrammarScoreRange = value;}
//		}
		public string EWGrammarScore
		{  
			get{return strEWGrammarScore;}
			set{strEWGrammarScore = value;}
		}
//		public string EWContentScoreRange
//		{  
//			get{return strEWContentScoreRange;}
//			set{strEWContentScoreRange = value;}
//		}
		public string EWContentScore
		{  
			get{return strEWContentScore;}
			set{strEWContentScore = value;}
		}
//		public string EWVocabularyScoreRange
//		{  
//			get{return strEWVocabularyScoreRange;}
//			set{strEWVocabularyScoreRange = value;}
//		}
		public string EWVocabularyScore
		{  
			get{return strEWVocabularyScore;}
			set{strEWVocabularyScore = value;}
		}
//		public string EWSpellingScoreRange
//		{  
//			get{return strEWSpellingScoreRange;}
//			set{strEWSpellingScoreRange = value;}
//		}
		public string EWSpellingScore
		{  
			get{return strEWSpellingScore;}
			set{strEWSpellingScore = value;}
		}
		public string SLOverallScore
		{  
			get{return strSLOverallScore;}
			set{strSLOverallScore = value;}
		}
		public string SLSentenceScore
		{  
			get{return strSLSentenceScore;}
			set{strSLSentenceScore = value;}
		}
//		public string SLVocabularyScoreRange
//		{  
//			get{return strSLVocabularyScoreRange;}
//			set{strSLVocabularyScoreRange = value;}
//		}
		public string SLVocabularyScore
		{  
			get{return strSLVocabularyScore;}
			set{strSLVocabularyScore = value;}
		}
//		public string SLFluencyScoreRange
//		{  
//			get{return strSLFluencyScoreRange;}
//			set{strSLFluencyScoreRange = value;}
//		}
		public string SLFluencyScore
		{  
			get{return strSLFluencyScore;}
			set{strSLFluencyScore = value;}
		}
//		public string SLPronunciationScoreRange
//		{  
//			get{return strSLPronunciationScoreRange;}
//			set{strSLPronunciationScoreRange = value;}
//		}
		public string SLPronunciationScore
		{  
			get{return strSLPronunciationScore;}
			set{strSLPronunciationScore = value;}
		}
//		public string KSTSpeedScoreRange
//		{  
//			get{return strKSTSpeedScoreRange;}
//			set{strKSTSpeedScoreRange = value;}
//		}
		public string KSTSpeedScore
		{  
			get{return strKSTSpeedScore;}
			set{strKSTSpeedScore = value;}
		}
//		public string KSTAccuracyScoreRange
//		{  
//			get{return strKSTAccuracyScoreRange;}
//			set{strKSTAccuracyScoreRange = value;}
//		}
		public string KSTAccuracyScore
		{  
			get{return strKSTAccuracyScore;}
			set{strKSTAccuracyScore = value;}
		}
		
						
	}

	public class ScoreUploadResponse
	{
		private string strRegistrationId ;
		private ScoreResponseMessage rmResponse=new ScoreResponseMessage();
		
		public string RegistrationId
		{  
			get{return strRegistrationId;}
			set{strRegistrationId = value;}
		}		
		
		public ScoreResponseMessage Response
		{
			get{return rmResponse;}
			set{rmResponse=value;}
		}


		
	}

	public class ScoreResponseMessage
	{
		private string strResponseId;
		private string strResponseMessage;
			
		
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
