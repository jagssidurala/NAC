using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml; 
using BusinessLayer;

namespace NASSCOM_NAC.WebService
{
	/// <summary>
	/// Summary description for NACCandidateDetails.
	/// </summary>
	public class NACCandidateDetails : System.Web.Services.WebService
	{
		public NACCandidateDetails()
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

		[WebMethod]
		public XmlDocument GetCandidateDetails(string CandidateRequestXML)
		{			
			XmlDocument xmlCandidateRequest=new XmlDocument();		
			try
			{
				//xmlCandidateRequest=CandidateRequestXML;
				xmlCandidateRequest.LoadXml(CandidateRequestXML);
				string fname= xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/FirstName").InnerText.ToString();
				string lname=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/LastName").InnerText.ToString();
				string regId=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/RegistrationId").InnerText.ToString();
				string DOB=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/DOB").InnerText.ToString();
				BLWSCandidateDetail objCandidateDtails = new BLWSCandidateDetail();

				if(fname!="")
				{
					objCandidateDtails.FirstName=fname.Trim();				
				}
				else
				{				
					//add error message in errorXML
					return GetErrorXML(xmlCandidateRequest,"ErrNAC4","Web Service validation failure (First Name is mandatory field)");
				}
				if(lname!="")
				{
					objCandidateDtails.LastName=lname.Trim();				
				}
				else
				{				
					//add error message in errorXML
					return GetErrorXML(xmlCandidateRequest,"ErrNAC5","Web Service validation failure (Last Name is mandatory field)");
				}
				if(regId!="")
				{
					objCandidateDtails.RegistrationId=regId.Trim();				
				}
				else
				{				
					//add error message in errorXML
					return GetErrorXML(xmlCandidateRequest,"ErrNAC3","Web Service validation failure (NAC Registration ID is mandatory field)");
				}
				if(DOB!="")
				{
					objCandidateDtails.Dob=Convert.ToDateTime(DOB);				
				}
				else
				{				
					//add error message in errorXML
					return GetErrorXML(xmlCandidateRequest,"ErrNAC6","Web Service validation failure (Date of Birth is mandatory field)");
				}
			
				if(objCandidateDtails.ValidateCandidateDetails() ==0)
				{
					return GetErrorXML(xmlCandidateRequest,"ErrNAC2","Registration ID does not match with other details. Please visit www.nac.nasscom.in to get correct details");
				}

				DataSet dsUserDetail = new DataSet();
				dsUserDetail = objCandidateDtails.getCandidateDetails();			
				XmlDocument XmlResponse= new XmlDocument();			
			
			
				if(dsUserDetail.Tables[0].Rows.Count>0)
				{
					if(Convert.ToString(dsUserDetail.Tables[0].Rows[0]["ScorecardType"])=="Ver2")
					{					
						XmlResponse.Load(Server.MapPath("Scores_Ver2.xml"));				 
					
						//Request Data Scores/NACOldScoresResponse
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/RegistrationId").InnerText=Convert.ToString(dsUserDetail.Tables[0].Rows[0]["RegId"]).Trim();
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/FirstName").InnerText=fname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/LastName").InnerText=lname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/DOB").InnerText=Convert.ToString(dsUserDetail.Tables[0].Rows[0]["DOB"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse").Attributes["ScoreFormat"].Value="Ver2";
						XmlResponse.SelectSingleNode("Scores/TestType").InnerText="NAC";
						XmlResponse.SelectSingleNode("Scores/Status").InnerText="Ver2";
						
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestDate").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["TestDate"]).Trim();
						
						//Analytical
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/Analytical/ScoreRange ").InnerText= "0-16";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/Analytical/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["AnalyticalScore"]).Trim();

						//Quantitative
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/Quantitative/ScoreRange ").InnerText= "0-16";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/Quantitative/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["QuantitativeScore"]).Trim();

						//EnglishWriting
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/ScoreRange ").InnerText= "0-20";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["EWOverallScore"]);
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Grammar/ScoreRange ").InnerText= "0-5";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Grammar/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["EWGrammarScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Content/ScoreRange ").InnerText= "0-6";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Content/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["EWContentScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Vocabulary/ScoreRange ").InnerText= "0-5";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/Vocabulary/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["EWVocabularyScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/SpellingPunctuation/ScoreRange ").InnerText= "0-4";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/EnglishWriting/SpellingPunctuation/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["EWSpellingScore"]).Trim();

						//Speaking & Listening
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/ScoreRange ").InnerText= "20-80";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["SLOverallScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Sentence/ScoreRange ").InnerText= "20-80";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Sentence/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["SLSentenceScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Vocabulary/ScoreRange ").InnerText= "20-80";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Vocabulary/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["SLVocabularyScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Fluency/ScoreRange ").InnerText= "20-80";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Fluency/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["SLFluencyScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Pronunciation/ScoreRange ").InnerText= "20-80";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/SpeakingListening/Pronunciation/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["SLPronunciationScore"]).Trim();

						//KeyBoard Skills
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/KeyboardSkills/TypingSpeed/ScoreRange ").InnerText= "-";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/KeyboardSkills/TypingSpeed/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["KSTSpeedScore"]).Trim();
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/KeyboardSkills/TypingAccuracy/ScoreRange ").InnerText= "-";
						XmlResponse.SelectSingleNode("Scores/NACV2ScoresResponse/TestResults/KeyboardSkills/TypingAccuracy/ScoresObtained").InnerText= Convert.ToString(dsUserDetail.Tables[0].Rows[0]["KSTAccuracyScore"]).Trim();
					}
					
					else if(Convert.ToString(dsUserDetail.Tables[0].Rows[0]["ScorecardType"])=="Old")
					{					
						XmlResponse.Load(Server.MapPath("Scores_Ver2.xml"));				 
					
						//Request Data Scores/NACOldScoresResponse
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/RegistrationId").InnerText=dsUserDetail.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/FirstName").InnerText=fname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/LastName").InnerText=lname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/DOB").InnerText=dsUserDetail.Tables[0].Rows[0]["dob"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse").Attributes["ScoreFormat"].Value="Old";
						XmlResponse.SelectSingleNode("Scores/TestType").InnerText="NAC";
						XmlResponse.SelectSingleNode("Scores/Status").InnerText="Old";
						//XmlResponse.SelectSingleNode("NACScores/ScoresRequest/RegistrationId").InnerText=dsUserDetail.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();
						//XmlResponse.SelectSingleNode("NACScores/ScoresRequest/FirstName").InnerText=fname;
						//XmlResponse.SelectSingleNode("NACScores/ScoresRequest/LastName").InnerText=lname;
						//XmlResponse.SelectSingleNode("NACScores/ScoresRequest/DOB").InnerText=dsUserDetail.Tables[0].Rows[0]["dob"].ToString().Trim();
						//XmlResponse.SelectSingleNode("NACScores/ScoresResponse").Attributes["ScoreFormat"].Value="Old";
					
						//Score result
						
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse/TestDate").InnerText= dsUserDetail.Tables[0].Rows[0]["TestDate"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse/TestList/EnglishSpeaking/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Speaking"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse/TestList/EnglishListening/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Listening"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse/TestList/EnglishWriting/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Writing"].ToString().Trim();					
						XmlResponse.SelectSingleNode("Scores/NACOldScoresResponse/TestList/AnalyticalQuantitativeReasoning/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Analytical"].ToString().Trim();

//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestDate").InnerText= dsUserDetail.Tables[0].Rows[0]["TestDate"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestList/EnglishSpeaking/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Speaking"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestList/EnglishListening/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Listening"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestList/EnglishWriting/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Writing"].ToString().Trim();					
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestList/AnalyticalQuantitativeReasoning/Percentile").InnerText = dsUserDetail.Tables[0].Rows[0]["Analytical"].ToString().Trim();
					}
					else
					{
						XmlResponse.Load(Server.MapPath("Scores_Ver2.xml"));				 
					
						//Request Data

						XmlResponse.SelectSingleNode("Scores/ScoresRequest/RegistrationId").InnerText=dsUserDetail.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/FirstName").InnerText=fname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/LastName").InnerText=lname;
						XmlResponse.SelectSingleNode("Scores/ScoresRequest/DOB").InnerText=dsUserDetail.Tables[0].Rows[0]["dob"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse").Attributes["ScoreFormat"].Value="New";
						XmlResponse.SelectSingleNode("Scores/TestType").InnerText="NAC";
						XmlResponse.SelectSingleNode("Scores/Status").InnerText="New";

//						XmlResponse.SelectSingleNode("NACScores/ScoresRequest/RegistrationId").InnerText=dsUserDetail.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresRequest/FirstName").InnerText=fname;
//						XmlResponse.SelectSingleNode("NACScores/ScoresRequest/LastName").InnerText=lname;
//						XmlResponse.SelectSingleNode("NACScores/ScoresRequest/DOB").InnerText=dsUserDetail.Tables[0].Rows[0]["dob"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse").Attributes["ScoreFormat"].Value="New";
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestDate").InnerText= dsUserDetail.Tables[0].Rows[0]["TestDate"].ToString().Trim();

						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestDate").InnerText= dsUserDetail.Tables[0].Rows[0]["TestDate"].ToString().Trim();
						//Speaking
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["SpeakingPercentile"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/VoiceClarity/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingVoiceClarity"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/VoiceClarity/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Accent/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingAccent"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Accent/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Fluency/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingFluency"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Fluency/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Grammar/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingGrammar"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Grammar/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Prosody/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingProsody"].ToString().Trim();		
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Speaking/Prosody/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
					
						//Writing Essay
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayPercentile"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Grammar/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayGrammar"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Grammar/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();												
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Content/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayContent"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Content/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Vocabulary/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayVocabulary"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/Vocabulary/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/SpellingPunctuation/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssaySpelling_Punctuation"].ToString().Trim();											
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingEssay/SpellingPunctuation/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();

						//Writing Multiple Choice
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingMultipleChoice/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingPercentile"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/WritingMultipleChoice/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingPercentage"].ToString().Trim();
					
						//Listening
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Listening/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["ListeningPercentile"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/Listening/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["ListeningPercentage"].ToString().Trim();
					
						//Analytical Reasoning
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/AnalyticalReasoning/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["AQRPercentile"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/AnalyticalReasoning/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["AQRPercentage"].ToString().Trim();

						//Learning Ability
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/LearningAbility/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["LAPercentile"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/LearningAbility/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["LAPercentage"].ToString().Trim();
	
						//Keyboard skills
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/KeyboardSkills/GrossSpeed").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardGrossSpeed"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/KeyboardSkills/Accuracy").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardAccuracy"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/KeyboardSkills/NetSpeed").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardNetSpeed"].ToString().Trim();
						XmlResponse.SelectSingleNode("Scores/NACNewScoresResponse/TestResults/KeyboardSkills/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardPercentile"].ToString().Trim();
                    

//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["SpeakingPercentile"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/VoiceClarity/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingVoiceClarity"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/VoiceClarity/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Accent/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingAccent"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Accent/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Fluency/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingFluency"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Fluency/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Grammar/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingGrammar"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Grammar/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Prosody/ScoresObtained").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingProsody"].ToString().Trim();		
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Speaking/Prosody/MaxScores").InnerText = dsUserDetail.Tables[0].Rows[0]["SpeakingMaxScore"].ToString().Trim();
//					
//						//Writing Essay
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayPercentile"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Grammar/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayGrammar"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Grammar/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();												
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Content/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayContent"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Content/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Vocabulary/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayVocabulary"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/Vocabulary/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/SpellingPunctuation/ScoresObtained").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssaySpelling_Punctuation"].ToString().Trim();											
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingEssay/SpellingPunctuation/MaxScores").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingEssayMaxScore"].ToString().Trim();
//
//						//Writing Multiple Choice
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingMultipleChoice/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingPercentile"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/WritingMultipleChoice/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["WritingPercentage"].ToString().Trim();
//					
//						//Listening
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Listening/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["ListeningPercentile"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/Listening/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["ListeningPercentage"].ToString().Trim();
//					
//						//Analytical Reasoning
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/AnalyticalReasoning/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["AQRPercentile"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/AnalyticalReasoning/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["AQRPercentage"].ToString().Trim();
//
//						//Learning Ability
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/LearningAbility/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["LAPercentile"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/LearningAbility/Percentage").InnerText= dsUserDetail.Tables[0].Rows[0]["LAPercentage"].ToString().Trim();
//	
//						//Keyboard skills
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/KeyboardSkills/GrossSpeed").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardGrossSpeed"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/KeyboardSkills/Accuracy").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardAccuracy"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/KeyboardSkills/NetSpeed").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardNetSpeed"].ToString().Trim();
//						XmlResponse.SelectSingleNode("NACScores/ScoresResponse/TestResults/KeyboardSkills/Percentile").InnerText= dsUserDetail.Tables[0].Rows[0]["KeyboardPercentile"].ToString().Trim();
//                    
					}
				}
				else
				{
					return GetErrorXML(xmlCandidateRequest,"ErrNAC1","NAC scores not available for this Registration ID");					
				}
				return XmlResponse; //XmlResponse.OuterXml.ToString();
			}
			catch(Exception ex)
			{
				return GetGeneralErrorXML("ErrNACSys1","Exception occurred while fetching data from NAC website.");
			}	
		}

		/// <summary>
		/// For creating error xml
		/// </summary>
		/// <param name="xmlCandidateRequest"></param>
		/// <param name="ErrorId"></param>
		/// <param name="ErrorMessage"></param>
		/// <returns></returns>

		private  XmlDocument GetErrorXML(XmlDocument xmlCandidateRequest, string ErrorId, string ErrorMessage)
		{
			XmlDocument XmlResponse= new XmlDocument();	
			XmlResponse.Load(Server.MapPath("Scores_Ver2.xml"));	
			XmlResponse.SelectSingleNode("Scores/ScoresRequest/RegistrationId").InnerText=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/RegistrationId").InnerText.ToString();
			XmlResponse.SelectSingleNode("Scores/ScoresRequest/FirstName").InnerText=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/FirstName").InnerText.ToString();
			XmlResponse.SelectSingleNode("Scores/ScoresRequest/LastName").InnerText=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/LastName").InnerText.ToString();
			XmlResponse.SelectSingleNode("Scores/ScoresRequest/DOB").InnerText=xmlCandidateRequest.SelectSingleNode("NACScores/ScoresRequest/DOB").InnerText.ToString();
			XmlResponse.SelectSingleNode("Scores/TestType").InnerText="NAC";
			XmlResponse.SelectSingleNode("Scores/Status").InnerText="Error";
			XmlResponse.SelectSingleNode("Scores/ErrorMessage/ErrorId").InnerText=ErrorId;
			XmlResponse.SelectSingleNode("Scores/ErrorMessage/ErrorMessage").InnerText=ErrorMessage;
//			string ErrorXML=string.Empty;
//			XmlDocument errorXML=new XmlDocument(); 
//			if(ErrorId!=string.Empty &&ErrorMessage!=string.Empty) 
//			{
//				ErrorXML="<ErrorMessage><ErrorId>"+ErrorId+"</ErrorId><ErrorMessage>"+ErrorMessage+"</ErrorMessage></ErrorMessage>";
//			}
//			errorXML.LoadXml(ErrorXML); 
//			XmlNode newError = xmlCandidateRequest.ImportNode(errorXML.DocumentElement, true);
//			xmlCandidateRequest.DocumentElement.AppendChild(newError);
//
//			return xmlCandidateRequest.OuterXml.ToString() ;
			return XmlResponse; //XmlResponse.OuterXml.ToString();
		}


		/// <summary>
		/// For creating error xml
		/// </summary>	
		/// <param name="ErrorId"></param>
		/// <param name="ErrorMessage"></param>
		/// <returns></returns>

		private  XmlDocument GetGeneralErrorXML(string ErrorId, string ErrorMessage)
		{
			XmlDocument XmlResponse= new XmlDocument();	
			XmlResponse.Load(Server.MapPath("Scores_Ver2.xml"));	
			XmlResponse.SelectSingleNode("Scores/TestType").InnerText="NAC";
			XmlResponse.SelectSingleNode("Scores/Status").InnerText="Error";
			XmlResponse.SelectSingleNode("Scores/ErrorMessage/ErrorId").InnerText=ErrorId;
			XmlResponse.SelectSingleNode("Scores/ErrorMessage/ErrorMessage").InnerText=ErrorMessage;
			return XmlResponse; //XmlResponse.OuterXml.ToString();

//			string ErrorXML=string.Empty;
//			XmlDocument errorXML=new XmlDocument(); 
//			if(ErrorId!=string.Empty &&ErrorMessage!=string.Empty) 
//			{
//				ErrorXML="<NACScores><ErrorMessage><ErrorId>"+ErrorId+"</ErrorId><ErrorMessage>"+ErrorMessage+"</ErrorMessage></ErrorMessage></NACScores>";
//			}
//			errorXML.LoadXml(ErrorXML);
//			return errorXML.OuterXml.ToString();
		}
	}
}
