using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using BusinessLayer;
using Common;

namespace NASSCOM_NAC.WebService
{
	/// <summary>
	/// Summary description for ScoreUploadV2.
	/// </summary>
	[WebService(Namespace="http://www.nac.nasscom.in/")]
	public class ScoreUploadV2 : System.Web.Services.WebService
	{
		public ScoreUploadV2()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

		[WebMethod]
		public ScoreUploadResponse UploadScores(ScoreUploadRequest Request)
		{
			BLWSScoreUpload objScoreUpload = new BLWSScoreUpload(); 
			try
			{
				objScoreUpload.UploadResponse.RegistrationId = Request.RegistrationId;
				
				#region ValidateRequest
				
				//Checking if Registration Id is blank.
				if ( (Request.RegistrationId.Trim()=="") || (Request.RegistrationId.Trim()== null) )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="101";
					objScoreUpload.UploadResponse.Response.Message="NOK-Registration Id is mandatory field.";
					return objScoreUpload.UploadResponse;
				}
				
				//Checking if Registration Id is invalid.
				if(objScoreUpload.ValidateRgistrationId(Request.RegistrationId) < 1)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="102";
					objScoreUpload.UploadResponse.Response.Message="NOK- Registration Id is invalid.";
					return objScoreUpload.UploadResponse;
				}
			
				//Checking if AnalyticalScore is blank.
				else if ((Request.Scores.AnalyticalScore.Trim()=="") || (Request.Scores.AnalyticalScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="103";
					objScoreUpload.UploadResponse.Response.Message="NOK-Analytical Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if QuantitativeScore is blank.
				else if ((Request.Scores.QuantitativeScore.Trim()=="") || (Request.Scores.QuantitativeScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="104";
					objScoreUpload.UploadResponse.Response.Message="NOK-Quantitative Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if EWOverallScore is blank.
				else if ((Request.Scores.EWOverallScore.Trim()=="") || (Request.Scores.EWOverallScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="105";
					objScoreUpload.UploadResponse.Response.Message="NOK-EW Overall Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if EWGrammarScore is blank.
				else if ((Request.Scores.EWGrammarScore.Trim()=="") || (Request.Scores.EWGrammarScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="106";
					objScoreUpload.UploadResponse.Response.Message="NOK-EW Grammar Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if EWContentScore is blank.
				else if ((Request.Scores.EWContentScore.Trim()=="") || (Request.Scores.EWContentScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="107";
					objScoreUpload.UploadResponse.Response.Message="NOK-EW Content Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if EWVocabularyScore is blank.
				else if ((Request.Scores.EWVocabularyScore.Trim()=="") || (Request.Scores.EWVocabularyScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="108";
					objScoreUpload.UploadResponse.Response.Message="NOK-EW Vocabulary Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}
				
				//Checking if EWSpellingScore is blank.
				else if ((Request.Scores.EWSpellingScore.Trim()=="") || (Request.Scores.EWSpellingScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="109";
					objScoreUpload.UploadResponse.Response.Message="NOK-EW Spelling Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if SLOverallScore is blank.
				else if ((Request.Scores.SLOverallScore.Trim()=="") || (Request.Scores.SLOverallScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="110";
					objScoreUpload.UploadResponse.Response.Message="NOK-SL SLOverallScore is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if SLSentenceScore is blank.
				else if ((Request.Scores.SLSentenceScore.Trim()=="") || (Request.Scores.SLSentenceScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="111";
					objScoreUpload.UploadResponse.Response.Message="NOK-SL Sentence Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if SLVocabularyScore is blank.
				else if ((Request.Scores.SLVocabularyScore.Trim()=="") || (Request.Scores.SLVocabularyScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="112";
					objScoreUpload.UploadResponse.Response.Message="NOK-SL Vocabulary Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if SLFluencyScore is blank.
				else if ((Request.Scores.SLFluencyScore.Trim()=="") || (Request.Scores.SLFluencyScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="113";
					objScoreUpload.UploadResponse.Response.Message="NOK-SL Fluency Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if SLPronunciationScore is blank.
				else if ((Request.Scores.SLPronunciationScore.Trim()=="") || (Request.Scores.SLPronunciationScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="114";
					objScoreUpload.UploadResponse.Response.Message="NOK-SL Pronunciation Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				//Checking if KSTSpeedScore is blank.
				else if ((Request.Scores.KSTSpeedScore.Trim()=="") || (Request.Scores.KSTSpeedScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="115";
					objScoreUpload.UploadResponse.Response.Message="NOK-KST Speed Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}
				
				//Checking if KSTAccuracyScore is blank.
				else if ((Request.Scores.KSTAccuracyScore.Trim()=="") || (Request.Scores.KSTAccuracyScore.Trim()== null)  )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="116";
					objScoreUpload.UploadResponse.Response.Message="NOK-KST Accuracy Score is mandatory field.";
					return objScoreUpload.UploadResponse;
				}

				
				// Validating if scores are numeric.
				int check = 0;
				try
				{	
					if(Request.Scores.AnalyticalScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.AnalyticalScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="117";
					objScoreUpload.UploadResponse.Response.Message="NOK-Analytical Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				
				try
				{
					if(Request.Scores.QuantitativeScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.QuantitativeScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="118";
					objScoreUpload.UploadResponse.Response.Message="NOK-Quantitative Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}

				try
				{
					if(Request.Scores.EWOverallScore.Trim().ToUpper()!="NA")
						check = Convert.ToInt32(Request.Scores.EWOverallScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="119";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWOverall Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}

				try
				{
					if(Request.Scores.EWGrammarScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.EWGrammarScore.Trim());
			
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="120";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWGrammar Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.EWContentScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.EWContentScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="121";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWContent Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.EWVocabularyScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.EWVocabularyScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="122";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWVocabulary Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.EWSpellingScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.EWSpellingScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="123";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWSpelling Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.SLOverallScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.SLOverallScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="124";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLOverall Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.SLSentenceScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.SLSentenceScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="125";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLSentence Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.SLVocabularyScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.SLVocabularyScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="126";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLVocabulary Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.SLFluencyScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.SLFluencyScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="127";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLFluency Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.SLPronunciationScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.SLPronunciationScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="128";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLPronunciation Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.KSTSpeedScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.KSTSpeedScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="129";
					objScoreUpload.UploadResponse.Response.Message="NOK-KSTSpeed Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}
				try
				{
					if(Request.Scores.KSTAccuracyScore.Trim().ToUpper()!="NA")
					check = Convert.ToInt32(Request.Scores.KSTAccuracyScore.Trim());
				}
				catch(Exception ex)
				{
					objScoreUpload.UploadResponse.Response.ResponseID="130";
					objScoreUpload.UploadResponse.Response.Message="NOK-KSTAccuracy Scores are not in correct format.";
					return objScoreUpload.UploadResponse;
				}

				

				//Checking Score Ranges
				if((Request.Scores.AnalyticalScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.AnalyticalScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.AnalyticalScore.Trim()) > 16)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="131";
					objScoreUpload.UploadResponse.Response.Message="NOK-Analytical Score is out of score range(0-16).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.QuantitativeScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.QuantitativeScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.QuantitativeScore.Trim()) > 16)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="132";
					objScoreUpload.UploadResponse.Response.Message="NOK-Quantitative Score is out of score range(0-16).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.EWOverallScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.EWOverallScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.EWOverallScore.Trim()) > 20)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="133";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWOverall Score is out of score range(0-20).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.EWGrammarScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.EWGrammarScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.EWGrammarScore.Trim()) > 5)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="134";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWGrammar Score is out of score range(0-5).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.EWContentScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.EWContentScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.EWContentScore.Trim()) > 6)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="135";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWContent Score is out of score range(0-6).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.EWVocabularyScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.EWVocabularyScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.EWVocabularyScore.Trim()) > 5)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="136";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWVocabulary Score is out of score range(0-5).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.EWSpellingScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.EWSpellingScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.EWSpellingScore.Trim()) > 4)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="137";
					objScoreUpload.UploadResponse.Response.Message="NOK-EWSpelling Score is out of score range(0-4).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.SLOverallScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.SLOverallScore.Trim()) < 20) || (Convert.ToInt32(Request.Scores.SLOverallScore.Trim()) > 80)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="138";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLOverall Score is out of score range(20-80).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.SLSentenceScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.SLSentenceScore.Trim()) < 20) || (Convert.ToInt32(Request.Scores.SLSentenceScore.Trim()) > 80)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="139";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLSentence Score is out of score range(20-80).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.SLVocabularyScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.SLVocabularyScore.Trim()) < 20) || (Convert.ToInt32(Request.Scores.SLVocabularyScore.Trim()) > 80)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="140";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLVocabulary Score is out of score range(20-80).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.SLFluencyScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.SLFluencyScore.Trim()) < 20) || (Convert.ToInt32(Request.Scores.SLFluencyScore.Trim()) > 80)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="141";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLFluency Score is out of score range(20-80).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.SLPronunciationScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.SLPronunciationScore.Trim()) < 20) || (Convert.ToInt32(Request.Scores.SLPronunciationScore.Trim()) > 80)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="142";
					objScoreUpload.UploadResponse.Response.Message="NOK-SLPronunciation Score is out of score range(20-80).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.KSTSpeedScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.KSTSpeedScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.KSTSpeedScore.Trim()) > 999)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="143";
					objScoreUpload.UploadResponse.Response.Message="NOK-KSTSpeed Score is out of score range(0-999).";
					return objScoreUpload.UploadResponse;
				}

				if((Request.Scores.KSTAccuracyScore.Trim().ToUpper()!="NA") && ((Convert.ToInt32(Request.Scores.KSTAccuracyScore.Trim()) < 0) || (Convert.ToInt32(Request.Scores.KSTAccuracyScore.Trim()) > 100)))
				{
					objScoreUpload.UploadResponse.Response.ResponseID="144";
					objScoreUpload.UploadResponse.Response.Message="NOK-KSTAccuracy Score is out of score range(0-100).";
					return objScoreUpload.UploadResponse;
				}


				//Checking if CDT_TinNo Length exceeds 20 characters
				if((Convert.ToInt32(Request.CDT_TinNo.Trim().Length) > 20) )
				{
					objScoreUpload.UploadResponse.Response.ResponseID="143";
					objScoreUpload.UploadResponse.Response.Message="NOK-CDT_TinNo length exceeds 20 characters.";
					return objScoreUpload.UploadResponse;
				}

				#endregion

				//Uploading Candidate Scores
				return objScoreUpload.UploadCandidateScores(Request);
					
			}
			catch(Exception ex)
			{
				objScoreUpload.UploadResponse.Response.ResponseID="999";
				objScoreUpload.UploadResponse.Response.Message="NOK-Some error occurred while processing your request. Please contact administrator.";
				return objScoreUpload.UploadResponse;
			}

		}

	}


}
