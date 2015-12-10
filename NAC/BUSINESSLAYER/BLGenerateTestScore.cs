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
using System.IO;
using System.Drawing.Design;
using System.Drawing.Imaging;

using sharpPDF.PDFControls;
using System.Threading;
using System.Configuration;

using System.Collections.Specialized;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLGenerateTestScore.
	/// </summary>
	public class BLGenerateTestScore : System.Web.UI.Page
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		private CandidateAuthenticationRequest req = new CandidateAuthenticationRequest();
		private CandidateAuthenticationResponse res = new CandidateAuthenticationResponse();
		private DataAccessLayer.DBConnection conn;
		private string strConn;	

		string  strState;
		string	RegistrationId;
		string	Name;
		string	Dob;
		string	TestCentre;
		string	TestDate;

		string	MaxSSVoiceClarity;
		string	MaxSSAccent;
		string	MaxSSFluency;
		string	MaxSSGrammar;
		string	MaxSProsody;
		string	SpeakingVoiceClarity;
		string	SpeakingAccent;
		string	SpeakingFluency;
		string	SpeakingGrammar;
		string	SpeakingProsody;
		string	SpeakingPercentile;
		string  SpeakingPercentage;

		//		string  SpeakingVCPercentage;
		//		string  SpeakingAPercentage;
		//		string  SpeakingFPercentage;
		//		string  SpeakingGPercentage;
		//		string  SpeakingPPercentage;

		string	WEMaxSGrammar;
		string	WEMaxSContent;
		string	WEMaxSVocabulary;
		string	WEMaxSSpellingPunctuation;
		string	WritingEssayGrammar;
		string	WritingEssayContent;
		string	WritingEssayVocabulary;
		string	WritingEssaySpellingPunctuation;
		string	WritingEssayPercentileScore;
		string	WritingEssayPercentage;	

		//		string	WritingEssayGPercentage;
		//		string	WritingEssayCPercentage;
		//		string	WritingEssayVPercentage;
		//		string	WritingEssaySPPercentage;		

		string	WritingMultipleChoiceMaxScore;
		string	WritingMultipleChoiceYourScore;
		string	WritingMultipleChoicePercentageScore;
		string	WritingMultipleChoicePercentileScore;

		string	ListeningMaxScore;
		string	ListeningYourScore;
		string	ListeningPercentageScore;
		string	ListeningPercentileScore;

		string	AQRMaxScore;
		string	AQRYourScore;
		string	AQRPercentageScore;
		string	AQRPercentileScore;

		string	LearningAbilityMaxScore;
		string	LearningAbilityYourScore;
		string	LearningAbilityPercentageScore;
		string	LearningAbilityPercentileScore;

		string	KeyboardSkillsGrossSpeed;
		string	KeyboardSkillsAccuracy;
		string	KeyboardNetSpeed;
		string	KeyboardSkillsPercentileScore;

		public BLGenerateTestScore()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string PercentageAppend(string score)
		{
			string strScorePercent;			
								
			
			if(score=="NA") 
			{
				return score;
			}
			else
			{	
				strScorePercent=Convert.ToString(score+"%");
				return strScorePercent; 	
			}
		}
		
		public int GetCandidateIdAgainstRegId(string registrationId)
		{
			
			conn = new DBConnection();						
				//Fetching connection string from Config file through GetConnectionString()
				strConn = conn.GetConnectionString();
				dbManager = new DBManager(DataProvider.SqlServer);
				dbManager.ConnectionString = strConn.ToString();
				dbManager.Open();				 
				dbManager.CreateParameters(1);			
				dbManager.AddParameters(0, "@RegistrationId", registrationId);
				return Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure,"GetCandidateIdAgainstRegId"));
				
		}

		public bool GenerateScoreCardPDF(string strPINNo)
		{
			bool flag=true;
			
			sharpPDF.Fonts.pdfFontDefinition objMertic = new sharpPDF.Fonts.pdfFontDefinition();
			sharpPDF.pdfColor clGray = new sharpPDF.pdfColor(128,128,128);
			sharpPDF.pdfColor clAAAAAA = new sharpPDF.pdfColor(170,170,170);
			objMertic.familyName = "Antiqua, Arial, Helvetica, sans-serif";
			objMertic.fontWeight = "bold";
			objMertic.fontHeight = 11;	
			BusinessLayer.BLNACScoreCard oBLScoreCard = new BLNACScoreCard();			 
			DataSet dsTestScore = oBLScoreCard.GetTestScore(strPINNo);
			strState = HttpContext.Current.Session["StateName"].ToString() + "]";
	
			//To store values in variables
			if(dsTestScore.Tables[0].Rows.Count > 0)
			{
				
				//Registration Detail
				RegistrationId = Convert.ToString(dsTestScore.Tables[0].Rows[0]["NACRegID"]).Trim();
				Name = Convert.ToString(dsTestScore.Tables[0].Rows[0]["CandidateName"]).Trim();
				Dob = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["DOB"].ToString().Trim()));
				TestCentre = Convert.ToString(dsTestScore.Tables[0].Rows[0]["TestLocation"]).Trim();
				TestDate = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim()));

 

				//Speaking Test Score
				MaxSSVoiceClarity = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSAccent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSFluency = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSProsody = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				
				SpeakingVoiceClarity = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingVoiceClarity"]).Trim();
				SpeakingAccent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingAccent"]).Trim();
				SpeakingFluency = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingFluency"]).Trim();
				SpeakingGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingGrammar"]).Trim();
				SpeakingProsody = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingProsody"]).Trim();
				SpeakingPercentile = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingPercentile"]).Trim();

				//Writing (Essay) 
				WEMaxSGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSContent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSVocabulary = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSSpellingPunctuation = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();

				WritingEssayGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayGrammar"]).Trim();
				WritingEssayContent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayContent"]).Trim();
				WritingEssayVocabulary = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayVocabulary"]).Trim();
				WritingEssaySpellingPunctuation = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssaySpelling_Punctuation"]).Trim();

				WritingEssayPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayPercentile"]).Trim();

				//Writing (Multiple Choice)
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingScore"]).Trim();
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingMaxScore"]).Trim();
				WritingMultipleChoicePercentageScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentage"]).Trim();
				WritingMultipleChoicePercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentile"]).Trim();

				//Listening
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningScore"]).Trim();
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningMaxScore"]).Trim();
				ListeningPercentageScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentage"]).Trim();
				ListeningPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentile"]).Trim();

				

				//Analytical and Quantitative Reasoning
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRScore"]).Trim();
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRMaxScore"]).Trim();
				AQRPercentageScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentage"]).Trim();
				AQRPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentile"]).Trim();				

				//Learning Ability			
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAScore"]).Trim();
				//Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAMaxScore"]).Trim();
				LearningAbilityPercentageScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentage"]).Trim();
				LearningAbilityPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentile"]).Trim();

				//Keyboard Skills
				KeyboardSkillsGrossSpeed = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardGrossSpeed"]).Trim();
				KeyboardSkillsAccuracy = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardAccuracy"]).Trim();
				KeyboardNetSpeed = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardNetSpeed"]).Trim();
				KeyboardSkillsPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardPercentile"]).Trim();			
				
					
			}
			//for Rajasthan
			if(Convert.ToString(HttpContext.Current.Session["StateName"])=="Rajasthan")
			{

				sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_Score_Card","NASSCOM");
				sharpPDF.pdfPage myPage = myDoc.addPage();
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");
			
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAB.TTF","AntiquaBold");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUABI.TTF","AntiquaBoldItalic");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAI.TTF","AntiquaItalic");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\BKANT.TTF","Antiqua");
			 
				// myDoc.getFontReference("Antiqua");

				myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
		
				myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);

				//Report Header section nass_logo.gif

				myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NASSCOM logo.jpg","logo");
				myPage.addImage(myDoc.getImageReference("logo"),45,742,26,175);		      

				myPage.addText("NASSCOM Assessment of Competence (NAC)", 144, 705, myDoc.getFontReference("AntiquaBold"),15,sharpPDF.pdfColor.Black);
				myPage.drawLine(144,703,467,703,sharpPDF.pdfColor.Black);

				//Score Report
				myPage.addText("Score Report", 269, 690, myDoc.getFontReference("AntiquaBold"),11,sharpPDF.pdfColor.Black);			

				//state
				myPage.addText("[State of", 258, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(strState, 298, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			
				//table Gray color
				myPage.drawLine(150,623,250,623,sharpPDF.pdfColor.LightGray,75);
			
				//Table horizontal lines
				myPage.drawLine(150,660,475,660,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,645,475,645,sharpPDF.pdfColor.Black);
				myPage.drawLine(150,630,475,630,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,615,475,615,sharpPDF.pdfColor.Black);
				myPage.drawLine(150,600,475,600,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,585,475,585,sharpPDF.pdfColor.Black);

				//table vertical lines
				myPage.drawLine(150,660,150,585,sharpPDF.pdfColor.Black);
				myPage.drawLine(250,660,250,585,sharpPDF.pdfColor.Black);
				myPage.drawLine(475,660,475,585,sharpPDF.pdfColor.Black);

				//table text
				myPage.addText("Registration ID", 155, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Name", 155, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Date of Birth", 155, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Test Location", 155, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Test Date", 155, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

				myPage.addText(RegistrationId, 255, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(Name, 255, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(Dob, 255, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(TestCentre, 255, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(TestDate, 255, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

				//Test Score
				myPage.addText("Test Scores", 80, 555, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			
				// second table maroon fill
				myPage.drawLine(75,540,540,540,sharpPDF.pdfColor.DarkRed,20);
				//myPage.drawLine(75,430,540,430,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,335+95,540,335+95,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,285+95,540,285+95,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,235+95,540,235+95,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,185+95,540,185+95,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,135+95,540,135+95,sharpPDF.pdfColor.DarkRed,20);

				//second table Grey fill
				myPage.drawLine(75,522,540,522,sharpPDF.pdfColor.LightGray,15);
				//myPage.drawLine(75,412,540,412,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,317+95,540,317+95,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,267+95,540,267+95,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,217+95,540,217+95,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,167+95,540,167+95,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,117+95,540,117+95,sharpPDF.pdfColor.LightGray,15);

				//Second Table Horizontal
				myPage.drawLine (75,550,540,550,sharpPDF.pdfColor.Black);
				myPage.addText("Speaking", 80, 536, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,530,540,530,sharpPDF.pdfColor.Black);
				myPage.addText("Topic", 85, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Maximum Score", 223, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Your Score", 340, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 440, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

				myPage.drawLine (75,515,540,515,sharpPDF.pdfColor.Black);
				myPage.addText("Voice Clearity", 85, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSVoiceClarity, 255, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingVoiceClarity, 355, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
					

				myPage.drawLine (75,500,410,500,sharpPDF.pdfColor.Black);
				myPage.addText("Accent", 85, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSAccent, 255, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingAccent, 355, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,485,410,485,sharpPDF.pdfColor.Black);
				myPage.addText("Fluency", 85, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSFluency, 255, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingFluency, 355, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingPercentile, 465, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

				myPage.drawLine (75,470,410,470,sharpPDF.pdfColor.Black);
				myPage.addText("Grammer", 85, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSGrammar, 255, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingGrammar, 355, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,455,410,455,sharpPDF.pdfColor.Black);
				myPage.addText("Prosody", 85, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSProsody, 255, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingProsody, 355, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,440,540,440,sharpPDF.pdfColor.Black);
				//				myPage.addText("Writing (Essay)", 80, 426, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				//
				//				myPage.drawLine (75,420,540,420,sharpPDF.pdfColor.Black);
				//				myPage.addText("Topic", 85, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText("Maximum Score", 223, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText("Your Score", 340, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText("Percentile Score", 440, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//
				//				myPage.drawLine (75,405,540,405,sharpPDF.pdfColor.Black);
				//				myPage.addText("Grammer", 85, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WEMaxSGrammar, 255, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WritingEssayGrammar, 355, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				
				//
				//				myPage.drawLine (75,390,410,390,sharpPDF.pdfColor.Black);
				//				myPage.addText("Content", 85, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WEMaxSContent, 255, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WritingEssayContent, 355, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WritingEssayPercentileScore, 465, 370, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//
				//				myPage.drawLine (75,375,410,375,sharpPDF.pdfColor.Black);
				//				myPage.addText("Vocabulary", 85, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WEMaxSVocabulary, 255, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WritingEssayVocabulary, 355, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				
				//				myPage.drawLine (75,360,410,360,sharpPDF.pdfColor.Black);
				//				myPage.addText("Spelling & Punctuation", 85, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WEMaxSSpellingPunctuation, 255, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				//				myPage.addText(WritingEssaySpellingPunctuation, 355, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				


				//				myPage.drawLine (75,345,540,345,sharpPDF.pdfColor.Black);
				myPage.addText("Writing", 80, 426, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,325+95,540,325+95,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 314+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 314+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,310+95,540,310+95,sharpPDF.pdfColor.Black);
				myPage.addText(WritingMultipleChoicePercentageScore, 190, 299+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingMultipleChoicePercentileScore, 425, 299+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);


				myPage.drawLine (75,295+95,540,295+95,sharpPDF.pdfColor.Black);
				myPage.addText("Listening", 80, 281+95, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,275+95,540,275+95,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 264+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 264+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,260+95,540,260+95,sharpPDF.pdfColor.Black);
				myPage.addText(ListeningPercentageScore, 190, 249+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(ListeningPercentileScore, 425, 249+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,245+95,540,245+95,sharpPDF.pdfColor.Black);
				myPage.addText("Analytical and Quantitative Reasoning", 80, 231+95, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,225+95,540,225+95,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 214+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 214+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,210+95,540,210+95,sharpPDF.pdfColor.Black);
				myPage.addText(AQRPercentageScore, 190, 199+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(AQRPercentileScore, 425, 199+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,195+95,540,195+95,sharpPDF.pdfColor.Black);
				myPage.addText("Learning Ability", 80, 181+95, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,175+95,540,175+95,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 164+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 164+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,160+95,540,160+95,sharpPDF.pdfColor.Black);
				myPage.addText(LearningAbilityPercentageScore, 190, 149+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(LearningAbilityPercentileScore, 425, 149+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,145+95,540,145+95,sharpPDF.pdfColor.Black);
				myPage.addText("Keyboard Skills", 80, 131+95, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,125+95,540,125+95,sharpPDF.pdfColor.Black);
				myPage.addText("Gross Speed", 120, 114+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Accuracy", 240, 114+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Net Speed", 340, 114+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 440, 114+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,110+95,540,110+95,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsGrossSpeed, 135, 99+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsAccuracy, 255, 99+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardNetSpeed, 355, 99+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsPercentileScore, 455, 99+95, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
		
				myPage.drawLine (75,95+95,540,95+95,sharpPDF.pdfColor.Black);

				// second table vertical lines
				myPage.drawLine (75,95+95,75,550,sharpPDF.pdfColor.Black);
				myPage.drawLine (540,95+95,540,550,sharpPDF.pdfColor.Black);

				myPage.drawLine (210,95+95,210,125+95,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,95+95,310,125+95,sharpPDF.pdfColor.Black);
				myPage.drawLine (410,95+95,410,125+95,sharpPDF.pdfColor.Black);

				myPage.drawLine (310,145+95,310,175+95,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,195+95,310,225+95,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,245+95,310,275+95,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,295+95,310,325+95,sharpPDF.pdfColor.Black);

				//				myPage.drawLine (210,345,210,420,sharpPDF.pdfColor.Black);
				//				myPage.drawLine (310,345,310,420,sharpPDF.pdfColor.Black);
				//				myPage.drawLine (410,345,410,420,sharpPDF.pdfColor.Black);

				myPage.drawLine (210,440,210,530,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,440,310,530,sharpPDF.pdfColor.Black);
				myPage.drawLine (410,440,410,530,sharpPDF.pdfColor.Black);


				//Outer Most Border
				myPage.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
				myPage.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
				myPage.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
				myPage.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

			
				//Inner Border
				myPage.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
				myPage.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
				myPage.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
				myPage.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

				//Outer Border
				myPage.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
				myPage.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
				myPage.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
				myPage.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

				//fotter

				myPage.drawLine (50,57,565,57,clGray);
				myPage.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
		
				// Second page
				sharpPDF.pdfPage myPage2 = myDoc.addPage();

				//Outer Most Border
				myPage2.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
				myPage2.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
				myPage2.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

				//Inner Border
				myPage2.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
				myPage2.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
				myPage2.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

				//Outer Border
				myPage2.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
				myPage2.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
				myPage2.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

				//fotter

				myPage2.drawLine (50,57,565,57,clGray);
				myPage2.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
			
				//Matter

				myPage2.addText("•    Writing ", 53, 750, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the ability to both use and identify standard written English and the ability to organize and support ideas in English. ", 93, 750, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Scoring of the written essay takes into account organization and language use, as well as success in completing a defined writing task.", 65, 740, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•    Listening  ", 53, 720, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the comprehension of spoken English including the ability to identify main ideas, the ability to understand factual", 98, 720, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("information and details, and the ability to connect information across longer speech samples. Speech samples  simulate  a  variety  of work and ", 65, 710, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("and everyday situations and include both extended announcements and conversations.", 65, 700, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Analytical and Quantitative Reasoning (A&Q) ", 53, 680, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("- It is a measure of the ability to (i) assimilate information presented in a structured way including ", 218, 680, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("quantitative information and (ii) draw logical inferences from the information, including identifying when information is insufficient to support ", 65, 670, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("an inference. Tasks in this section require the ability to comprehend sets of practical relationships presented in English as well as the ability ", 65, 660, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("to apply basic mathematical concepts.", 65, 650, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Learning Ability ", 53,630, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of ability to learn new technology. Task in this section requires the ability to understand a new concept and ", 120, 630, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("apply it in a hypothetical situation.", 65, 620, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Keyboard Skills ", 53,600, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It measures the skills to use keyboard proficiently. Task in this section requires the ability to enter data accurately in a given ", 116, 600, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("span of time. Gross / Net Speed are mentioned in 'words per minute' and Accuracy is given in 'percentage'.", 65, 590, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Speaking ", 53,570, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the ability to speak English in a professional context. Tasks in this section require comprehension of spoken Eng- ", 94, 570, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("lish and written English. Scoring takes into account delivery and language use, as well as success at completing defined communicative tasks.", 65, 560, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("Qualitative description of ratings/scales (Speaking)", 57, 540, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			
				myPage2.drawLine (57,530,563,530,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating ", 65, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Qualitative Rating", 105, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating Description", 305, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,518,563,518,sharpPDF.pdfColor.Black);
				myPage2.addText("5 ", 75, 504, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Excellent", 104, 506, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires no language training", 304, 506, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,494,563,494,sharpPDF.pdfColor.Black);
				myPage2.addText("4 ", 75, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Good", 105, 480, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires minimum language training", 305, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,470,563,470,sharpPDF.pdfColor.Black);
				myPage2.addText("3.5 ", 72, 456, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Above Average", 105, 456, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("May require focused language training. Is generally comfortable with", 305, 461, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("the language", 305, 451, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,446,563,446,sharpPDF.pdfColor.Black);
				myPage2.addText("3 ", 75, 432, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Average", 105, 432, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("May require considerable language training. Is reasonably comfortable ", 305, 437, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("with the language", 305, 428, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,422,563,422,sharpPDF.pdfColor.Black);
				myPage2.addText("2 ", 75, 408, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Below Average", 105, 408, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires extensive language training. Is not very comfortable with the", 305, 413, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("language", 305, 404, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,398,563,398,sharpPDF.pdfColor.Black);
				myPage2.addText("1 ", 75, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Poor", 105, 384, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires intensive language training. Poor command of the language", 305, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,374,563,374,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,374,57,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (563,374,563,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (97,374,97,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (297,374,297,530,sharpPDF.pdfColor.Black);

				//				myPage2.addText("Qualitative description of ratings/scales (Writing Essay)", 57, 360, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//			
				//				myPage2.drawLine (57,350,563,350,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Rating ", 65, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Qualitative Rating", 105, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Rating Description", 305, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//
				//				myPage2.drawLine (57,338,563,338,sharpPDF.pdfColor.Black);
				//				myPage2.addText("6 ", 75, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Excellent:", 105, 324, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Advanced level language user", 145, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("No language errors; completely accurate comprehension, interpretation ", 305, 329, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("& completely relevant response", 305, 320, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//				myPage2.drawLine (57,314,563,314,sharpPDF.pdfColor.Black);
				//				myPage2.addText("5 ", 75, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Good:", 105, 300, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Proficient level language user", 130, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Makes occasional language errors; largely accurate comprehension, ", 305, 305, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("interpretation & largely relevant response", 305, 296, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//
				//				myPage2.drawLine (57,290,563,290,sharpPDF.pdfColor.Black);
				//				myPage2.addText("4 ", 75, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Above Average:", 105, 276, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Vantage level language user", 165, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Makes a few language errors; generally accurate comprehension, ", 305, 281, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("interpretation & generally relevant response", 305, 272, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//
				//				myPage2.drawLine (57,266,563,266,sharpPDF.pdfColor.Black);
				//				myPage2.addText("3 ", 75, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Average:", 105, 252, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Threshold level language user", 140, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Makes regular language errors; fairly accurate comprehension, ", 305, 257, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("interpretation & reasonably relevant response", 305, 248, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//
				//				myPage2.drawLine (57,242,563,242,sharpPDF.pdfColor.Black);
				//				myPage2.addText("2 ", 75, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Below Average:", 105, 228, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Learner level language user", 165, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Makes several language errors; largely inaccurate comprehension, ", 305, 233, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("interpretation & largely irrelevant response", 305, 224, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//
				//				myPage2.drawLine (57,218,563,218,sharpPDF.pdfColor.Black);
				//				myPage2.addText("1 ", 75, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Poor: ", 105, 204, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Beginner level language user", 130, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("Makes too many language; completely inaccurate comprehension, ", 305, 209, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//				myPage2.addText("interpretation & completely irrelevant response", 305, 200, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				//
				//

				//				myPage2.drawLine (57,194,563,194,sharpPDF.pdfColor.Black);			


				//				myPage2.drawLine (57,194,57,350,sharpPDF.pdfColor.Black);
				//				myPage2.drawLine (563,194,563,350,sharpPDF.pdfColor.Black);
				//				myPage2.drawLine (97,194,97,350,sharpPDF.pdfColor.Black);
				//				myPage2.drawLine (297,194,297,350,sharpPDF.pdfColor.Black);

				myPage2.addText("Important points", 57, 180+170, myDoc.getFontReference("AntiquaBold"),8,clGray);
				myPage2.drawLine (57,178+170,120,178+170,clGray);
				myPage2.addText("1. This is the official score card for NAC, NASSCOM Assessment of Competence", 72, 160+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("2. Scores are provided in percentile manner and range from 0.1 to 100. Example - A percentile score of 50 on a skill indicates that 50% of the ", 72, 150+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("population has scored below or equal to the test taker taking the same test for that skill on the same day. ", 82, 140+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("3. Where “NA” is present on a score report, a score could not be provided due to either of two possible reasons – (i) the test taker did not  ", 72, 130+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("attempt that section of the test or (ii) there was considerable difficulty in discerning the test taker’s responses / there was insufficient data.", 82, 120+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("4. You may use this score sheet for applying to companies announced to be recruiting through NAC. However, NAC Test participation does ", 72, 110+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("not guarantee employment.", 82, 100+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("5. The employers may or may not assess your academic performance, details of past employment etc. for the purpose of final selection.", 72, 90+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("6. The content of current version of this assessment is designed and developed by MeritTrac Services Pvt. Ltd.", 72, 80+170, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("7. NAC is endorsed by leading ITES-BPO players.", 72, 70+170, myDoc.getFontReference("Antiqua"),8,clGray);


				//create PDF
				myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "ScoreCard_" + strPINNo + ".pdf"); 
				myPage = null;
				myDoc = null; 
				return flag;							
			}

				// fro all other states
			else
			{
				sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_Score_Card","NASSCOM");
				sharpPDF.pdfPage myPage = myDoc.addPage();
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");
			
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAB.TTF","AntiquaBold");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUABI.TTF","AntiquaBoldItalic");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAI.TTF","AntiquaItalic");
				myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\BKANT.TTF","Antiqua");
			 
				// myDoc.getFontReference("Antiqua");

				myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
		
				myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);

				//Report Header section nass_logo.gif

				myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NASSCOM logo.jpg","logo");
				myPage.addImage(myDoc.getImageReference("logo"),45,742,30,165);		      

				myPage.addText("NASSCOM Assessment of Competence (NAC)", 144, 705, myDoc.getFontReference("AntiquaBold"),15,sharpPDF.pdfColor.Black);
				myPage.drawLine(144,703,467,703,sharpPDF.pdfColor.Black);

				//Score Report
				myPage.addText("Score Report", 269, 690, myDoc.getFontReference("AntiquaBold"),11,sharpPDF.pdfColor.Black);			

				//state
				myPage.addText("[State of", 258, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(strState, 298, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			
				//table Gray color
				myPage.drawLine(150,623,250,623,sharpPDF.pdfColor.LightGray,75);
			
				//Table horizontal lines
				myPage.drawLine(150,660,475,660,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,645,475,645,sharpPDF.pdfColor.Black);
				myPage.drawLine(150,630,475,630,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,615,475,615,sharpPDF.pdfColor.Black);
				myPage.drawLine(150,600,475,600,sharpPDF.pdfColor.Black);			
				myPage.drawLine(150,585,475,585,sharpPDF.pdfColor.Black);

				//table vertical lines
				myPage.drawLine(150,660,150,585,sharpPDF.pdfColor.Black);
				myPage.drawLine(250,660,250,585,sharpPDF.pdfColor.Black);
				myPage.drawLine(475,660,475,585,sharpPDF.pdfColor.Black);

				//table text
				myPage.addText("Registration ID", 155, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Name", 155, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Date of Birth", 155, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Test Location", 155, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText("Test Date", 155, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

				myPage.addText(RegistrationId, 255, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(Name, 255, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(Dob, 255, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(TestCentre, 255, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(TestDate, 255, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

				//Test Score
				myPage.addText("Test Scores", 80, 555, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			
				// second table maroon fill
				myPage.drawLine(75,540,540,540,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,430,540,430,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,335,540,335,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,285,540,285,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,235,540,235,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,185,540,185,sharpPDF.pdfColor.DarkRed,20);
				myPage.drawLine(75,135,540,135,sharpPDF.pdfColor.DarkRed,20);

				//second table Grey fill
				myPage.drawLine(75,522,540,522,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,412,540,412,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,317,540,317,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,267,540,267,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,217,540,217,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,167,540,167,sharpPDF.pdfColor.LightGray,15);
				myPage.drawLine(75,117,540,117,sharpPDF.pdfColor.LightGray,15);

				//Second Table Horizontal
				myPage.drawLine (75,550,540,550,sharpPDF.pdfColor.Black);
				myPage.addText("Speaking", 80, 536, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,530,540,530,sharpPDF.pdfColor.Black);
				myPage.addText("Topic", 85, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Maximum Score", 223, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Your Score", 340, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 440, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

				myPage.drawLine (75,515,540,515,sharpPDF.pdfColor.Black);
				myPage.addText("Voice Clearity", 85, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSVoiceClarity, 255, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingVoiceClarity, 355, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
					

				myPage.drawLine (75,500,410,500,sharpPDF.pdfColor.Black);
				myPage.addText("Accent", 85, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSAccent, 255, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingAccent, 355, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,485,410,485,sharpPDF.pdfColor.Black);
				myPage.addText("Fluency", 85, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSFluency, 255, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingFluency, 355, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingPercentile, 465, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

				myPage.drawLine (75,470,410,470,sharpPDF.pdfColor.Black);
				myPage.addText("Grammer", 85, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSSGrammar, 255, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingGrammar, 355, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,455,410,455,sharpPDF.pdfColor.Black);
				myPage.addText("Prosody", 85, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(MaxSProsody, 255, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(SpeakingProsody, 355, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,440,540,440,sharpPDF.pdfColor.Black);
				myPage.addText("Writing (Essay)", 80, 426, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);

				myPage.drawLine (75,420,540,420,sharpPDF.pdfColor.Black);
				myPage.addText("Topic", 85, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Maximum Score", 223, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Your Score", 340, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 440, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,405,540,405,sharpPDF.pdfColor.Black);
				myPage.addText("Grammer", 85, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WEMaxSGrammar, 255, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingEssayGrammar, 355, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				

				myPage.drawLine (75,390,410,390,sharpPDF.pdfColor.Black);
				myPage.addText("Content", 85, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WEMaxSContent, 255, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingEssayContent, 355, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingEssayPercentileScore, 465, 370, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,375,410,375,sharpPDF.pdfColor.Black);
				myPage.addText("Vocabulary", 85, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WEMaxSVocabulary, 255, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingEssayVocabulary, 355, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
				myPage.drawLine (75,360,410,360,sharpPDF.pdfColor.Black);
				myPage.addText("Spelling & Punctuation", 85, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WEMaxSSpellingPunctuation, 255, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingEssaySpellingPunctuation, 355, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				


				myPage.drawLine (75,345,540,345,sharpPDF.pdfColor.Black);
				myPage.addText("Writing (Multiple Choice)", 80, 331, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,325,540,325,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 314, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 314, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,310,540,310,sharpPDF.pdfColor.Black);
				myPage.addText(WritingMultipleChoicePercentageScore, 190, 299, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(WritingMultipleChoicePercentileScore, 425, 299, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);


				myPage.drawLine (75,295,540,295,sharpPDF.pdfColor.Black);
				myPage.addText("Listening", 80, 281, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,275,540,275,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 264, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 264, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,260,540,260,sharpPDF.pdfColor.Black);
				myPage.addText(ListeningPercentageScore, 190, 249, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(ListeningPercentileScore, 425, 249, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,245,540,245,sharpPDF.pdfColor.Black);
				myPage.addText("Analytical and Quantitative Reasoning", 80, 231, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,225,540,225,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 214, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 214, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,210,540,210,sharpPDF.pdfColor.Black);
				myPage.addText(AQRPercentageScore, 190, 199, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(AQRPercentileScore, 425, 199, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,195,540,195,sharpPDF.pdfColor.Black);
				myPage.addText("Learning Ability", 80, 181, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,175,540,175,sharpPDF.pdfColor.Black);
				myPage.addText("Percentage Score", 160, 164, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 395, 164, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.drawLine (75,160,540,160,sharpPDF.pdfColor.Black);
				myPage.addText(LearningAbilityPercentageScore, 190, 149, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(LearningAbilityPercentileScore, 425, 149, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,145,540,145,sharpPDF.pdfColor.Black);
				myPage.addText("Keyboard Skills", 80, 131, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
				myPage.drawLine (75,125,540,125,sharpPDF.pdfColor.Black);
				myPage.addText("Gross Speed", 120, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Accuracy", 240, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Net Speed", 340, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText("Percentile Score", 440, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

				myPage.drawLine (75,110,540,110,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsGrossSpeed, 135, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsAccuracy, 255, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardNetSpeed, 355, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				myPage.addText(KeyboardSkillsPercentileScore, 455, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
		
				myPage.drawLine (75,95,540,95,sharpPDF.pdfColor.Black);

				// second table vertical lines
				myPage.drawLine (75,95,75,550,sharpPDF.pdfColor.Black);
				myPage.drawLine (540,95,540,550,sharpPDF.pdfColor.Black);

				myPage.drawLine (210,95,210,125,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,95,310,125,sharpPDF.pdfColor.Black);
				myPage.drawLine (410,95,410,125,sharpPDF.pdfColor.Black);

				myPage.drawLine (310,145,310,175,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,195,310,225,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,245,310,275,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,295,310,325,sharpPDF.pdfColor.Black);

				myPage.drawLine (210,345,210,420,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,345,310,420,sharpPDF.pdfColor.Black);
				myPage.drawLine (410,345,410,420,sharpPDF.pdfColor.Black);

				myPage.drawLine (210,440,210,530,sharpPDF.pdfColor.Black);
				myPage.drawLine (310,440,310,530,sharpPDF.pdfColor.Black);
				myPage.drawLine (410,440,410,530,sharpPDF.pdfColor.Black);


				//Outer Most Border
				myPage.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
				myPage.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
				myPage.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
				myPage.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

			
				//Inner Border
				myPage.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
				myPage.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
				myPage.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
				myPage.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

				//Outer Border
				myPage.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
				myPage.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
				myPage.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
				myPage.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

				//fotter

				myPage.drawLine (50,57,565,57,clGray);
				myPage.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
		
				// Second page
				sharpPDF.pdfPage myPage2 = myDoc.addPage();

				//Outer Most Border
				myPage2.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
				myPage2.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
				myPage2.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

				//Inner Border
				myPage2.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
				myPage2.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
				myPage2.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

				//Outer Border
				myPage2.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
				myPage2.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
				myPage2.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
				myPage2.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

				//fotter

				myPage2.drawLine (50,57,565,57,clGray);
				myPage2.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
			
				//Matter

				myPage2.addText("•    Writing ", 53, 750, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the ability to both use and identify standard written English and the ability to organize and support ideas in English. ", 93, 750, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Scoring of the written essay takes into account organization and language use, as well as success in completing a defined writing task.", 65, 740, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•    Listening  ", 53, 720, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the comprehension of spoken English including the ability to identify main ideas, the ability to understand factual", 98, 720, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("information and details, and the ability to connect information across longer speech samples. Speech samples  simulate  a  variety  of work and ", 65, 710, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("and everyday situations and include both extended announcements and conversations.", 65, 700, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Analytical and Quantitative Reasoning (A&Q) ", 53, 680, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("- It is a measure of the ability to (i) assimilate information presented in a structured way including ", 218, 680, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("quantitative information and (ii) draw logical inferences from the information, including identifying when information is insufficient to support ", 65, 670, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("an inference. Tasks in this section require the ability to comprehend sets of practical relationships presented in English as well as the ability ", 65, 660, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("to apply basic mathematical concepts.", 65, 650, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Learning Ability ", 53,630, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of ability to learn new technology. Task in this section requires the ability to understand a new concept and ", 120, 630, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("apply it in a hypothetical situation.", 65, 620, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Keyboard Skills ", 53,600, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It measures the skills to use keyboard proficiently. Task in this section requires the ability to enter data accurately in a given ", 116, 600, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("span of time. Gross / Net Speed are mentioned in 'words per minute' and Accuracy is given in 'percentage'.", 65, 590, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("•	   Speaking ", 53,570, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("– It is a measure of the ability to speak English in a professional context. Tasks in this section require comprehension of spoken Eng- ", 94, 570, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("lish and written English. Scoring takes into account delivery and language use, as well as success at completing defined communicative tasks.", 65, 560, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.addText("Qualitative description of ratings/scales (Speaking)", 57, 540, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			
				myPage2.drawLine (57,530,563,530,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating ", 65, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Qualitative Rating", 105, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating Description", 305, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,518,563,518,sharpPDF.pdfColor.Black);
				myPage2.addText("5 ", 75, 504, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Excellent", 104, 506, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires no language training", 304, 506, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,494,563,494,sharpPDF.pdfColor.Black);
				myPage2.addText("4 ", 75, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Good", 105, 480, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires minimum language training", 305, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,470,563,470,sharpPDF.pdfColor.Black);
				myPage2.addText("3.5 ", 72, 456, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Above Average", 105, 456, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("May require focused language training. Is generally comfortable with", 305, 461, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("the language", 305, 451, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,446,563,446,sharpPDF.pdfColor.Black);
				myPage2.addText("3 ", 75, 432, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Average", 105, 432, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("May require considerable language training. Is reasonably comfortable ", 305, 437, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("with the language", 305, 428, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,422,563,422,sharpPDF.pdfColor.Black);
				myPage2.addText("2 ", 75, 408, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Below Average", 105, 408, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires extensive language training. Is not very comfortable with the", 305, 413, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("language", 305, 404, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,398,563,398,sharpPDF.pdfColor.Black);
				myPage2.addText("1 ", 75, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Poor", 105, 384, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Requires intensive language training. Poor command of the language", 305, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,374,563,374,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,374,57,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (563,374,563,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (97,374,97,530,sharpPDF.pdfColor.Black);
				myPage2.drawLine (297,374,297,530,sharpPDF.pdfColor.Black);

				myPage2.addText("Qualitative description of ratings/scales (Writing Essay)", 57, 360, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			
				myPage2.drawLine (57,350,563,350,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating ", 65, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Qualitative Rating", 105, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Rating Description", 305, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,338,563,338,sharpPDF.pdfColor.Black);
				myPage2.addText("6 ", 75, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Excellent:", 105, 324, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Advanced level language user", 145, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("No language errors; completely accurate comprehension, interpretation ", 305, 329, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("& completely relevant response", 305, 320, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

				myPage2.drawLine (57,314,563,314,sharpPDF.pdfColor.Black);
				myPage2.addText("5 ", 75, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Good:", 105, 300, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Proficient level language user", 130, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Makes occasional language errors; largely accurate comprehension, ", 305, 305, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("interpretation & largely relevant response", 305, 296, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


				myPage2.drawLine (57,290,563,290,sharpPDF.pdfColor.Black);
				myPage2.addText("4 ", 75, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Above Average:", 105, 276, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Vantage level language user", 165, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Makes a few language errors; generally accurate comprehension, ", 305, 281, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("interpretation & generally relevant response", 305, 272, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


				myPage2.drawLine (57,266,563,266,sharpPDF.pdfColor.Black);
				myPage2.addText("3 ", 75, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Average:", 105, 252, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Threshold level language user", 140, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Makes regular language errors; fairly accurate comprehension, ", 305, 257, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("interpretation & reasonably relevant response", 305, 248, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


				myPage2.drawLine (57,242,563,242,sharpPDF.pdfColor.Black);
				myPage2.addText("2 ", 75, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Below Average:", 105, 228, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Learner level language user", 165, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Makes several language errors; largely inaccurate comprehension, ", 305, 233, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("interpretation & largely irrelevant response", 305, 224, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


				myPage2.drawLine (57,218,563,218,sharpPDF.pdfColor.Black);
				myPage2.addText("1 ", 75, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Poor: ", 105, 204, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Beginner level language user", 130, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("Makes too many language; completely inaccurate comprehension, ", 305, 209, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
				myPage2.addText("interpretation & completely irrelevant response", 305, 200, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);



				myPage2.drawLine (57,194,563,194,sharpPDF.pdfColor.Black);			


				myPage2.drawLine (57,194,57,350,sharpPDF.pdfColor.Black);
				myPage2.drawLine (563,194,563,350,sharpPDF.pdfColor.Black);
				myPage2.drawLine (97,194,97,350,sharpPDF.pdfColor.Black);
				myPage2.drawLine (297,194,297,350,sharpPDF.pdfColor.Black);

				myPage2.addText("Important points", 57, 180, myDoc.getFontReference("AntiquaBold"),8,clGray);
				myPage2.drawLine (57,178,120,178,clGray);
				myPage2.addText("1. This is the official score card for NAC, NASSCOM Assessment of Competence", 72, 160, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("2. Scores are provided in percentile manner and range from 0.1 to 100. Example - A percentile score of 50 on a skill indicates that 50% of the ", 72, 150, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("population has scored below or equal to the test taker taking the same test for that skill on the same day. ", 82, 140, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("3. Where “NA” is present on a score report, a score could not be provided due to either of two possible reasons – (i) the test taker did not  ", 72, 130, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("attempt that section of the test or (ii) there was considerable difficulty in discerning the test taker’s responses / there was insufficient data.", 82, 120, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("4. You may use this score sheet for applying to companies announced to be recruiting through NAC. However, NAC Test participation does ", 72, 110, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("not guarantee employment.", 82, 100, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("5. The employers may or may not assess your academic performance, details of past employment etc. for the purpose of final selection.", 72, 90, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("6. The content of current version of this assessment is designed and developed by MeritTrac Services Pvt. Ltd.", 72, 80, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("7. NAC is endorsed by leading ITES-BPO players.", 72, 70, myDoc.getFontReference("Antiqua"),8,clGray);

				//create PDF
				myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "ScoreCard_" + strPINNo + ".pdf"); 
				myPage = null;
				myDoc = null; 
				return flag;	
			}

			
		}


		public bool GenerateScoreCardPDFPercentage(string strPINNo)
		{
			bool flag=true;
			
			sharpPDF.Fonts.pdfFontDefinition objMertic = new sharpPDF.Fonts.pdfFontDefinition();
			sharpPDF.pdfColor clGray = new sharpPDF.pdfColor(128,128,128);
			sharpPDF.pdfColor clAAAAAA = new sharpPDF.pdfColor(170,170,170);
			objMertic.familyName = "Antiqua, Arial, Helvetica, sans-serif";
			objMertic.fontWeight = "bold";
			objMertic.fontHeight = 11;	
			BusinessLayer.BLNACScoreCard oBLScoreCard = new BLNACScoreCard();			 
			DataSet dsTestScore = oBLScoreCard.GetTestScore(strPINNo);
			strState = HttpContext.Current.Session["StateName"].ToString() + "]";
	
			//To store values in variables
			if(dsTestScore.Tables[0].Rows.Count > 0)
			{
				
				//Registration Detail
				RegistrationId = Convert.ToString(dsTestScore.Tables[0].Rows[0]["NACRegID"]).Trim();
				Name = Convert.ToString(dsTestScore.Tables[0].Rows[0]["CandidateName"]).Trim();
				Dob = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["DOB"].ToString().Trim()));
				TestCentre = Convert.ToString(dsTestScore.Tables[0].Rows[0]["TestLocation"]).Trim();
				TestDate = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim()));

 

				//Speaking Test Score
				MaxSSVoiceClarity = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSAccent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSFluency = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSSGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				MaxSProsody = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				
				SpeakingVoiceClarity = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingVoiceClarity"]).Trim();
				SpeakingAccent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingAccent"]).Trim();
				SpeakingFluency = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingFluency"]).Trim();
				SpeakingGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingGrammar"]).Trim();
				SpeakingProsody = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingProsody"]).Trim();

				SpeakingPercentage = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingPercentage"]).Trim());

				//Writing (Essay) 
				WEMaxSGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSContent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSVocabulary = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
				WEMaxSSpellingPunctuation = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();

				WritingEssayGrammar = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayGrammar"]).Trim();
				WritingEssayContent = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayContent"]).Trim();
				WritingEssayVocabulary = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayVocabulary"]).Trim();
				WritingEssaySpellingPunctuation = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssaySpelling_Punctuation"]).Trim();

				WritingEssayPercentage = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayPercentage"]).Trim());

				//Writing (Multiple Choice)
				WritingMultipleChoiceYourScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingScore"]).Trim();
				WritingMultipleChoiceMaxScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingMaxScore"]).Trim();
				WritingMultipleChoicePercentageScore = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentage"]).Trim());
				//WritingMultipleChoicePercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentile"]).Trim();

				//Listening
				ListeningYourScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningScore"]).Trim();
				ListeningMaxScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningMaxScore"]).Trim();
				ListeningPercentageScore = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentage"]).Trim());
				//ListeningPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentile"]).Trim();

				

				//Analytical and Quantitative Reasoning
				AQRYourScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRScore"]).Trim();
				AQRMaxScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRMaxScore"]).Trim();
				AQRPercentageScore = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentage"]).Trim());
				//AQRPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentile"]).Trim();				

				//Learning Ability			
				LearningAbilityYourScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAScore"]).Trim();
				LearningAbilityMaxScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAMaxScore"]).Trim();
				LearningAbilityPercentageScore = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentage"]).Trim());
				//LearningAbilityPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentile"]).Trim();

				//Keyboard Skills
				KeyboardSkillsGrossSpeed = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardGrossSpeed"]).Trim();
				KeyboardSkillsAccuracy = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardAccuracy"]).Trim());
				KeyboardNetSpeed = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardNetSpeed"]).Trim();
				//KeyboardSkillsPercentileScore = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardPercentile"]).Trim();			
				
					
			}
			
			sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_Score_Card","NASSCOM");
			sharpPDF.pdfPage myPage = myDoc.addPage();
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");
			
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAB.TTF","AntiquaBold");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUABI.TTF","AntiquaBoldItalic");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\ANTQUAI.TTF","AntiquaItalic");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\BKANT.TTF","Antiqua");
			 
			// myDoc.getFontReference("Antiqua");

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
		
			myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);

			//Report Header section nass_logo.gif

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NASSCOM Logo.jpg","logo");
			myPage.addImage(myDoc.getImageReference("logo"),45,742,16,116);		      

			myPage.addText("NASSCOM Assessment of Competence (NAC)", 144, 705, myDoc.getFontReference("AntiquaBold"),15,sharpPDF.pdfColor.Black);
			myPage.drawLine(144,703,467,703,sharpPDF.pdfColor.Black);

			//Score Report
			myPage.addText("Score Report", 269, 690, myDoc.getFontReference("AntiquaBold"),11,sharpPDF.pdfColor.Black);			

			//state

			if(HttpContext.Current.Session["StateName"].ToString()=="Hero Mindmine" || HttpContext.Current.Session["StateName"].ToString()=="Sona College" ||  HttpContext.Current.Session["StateName"].ToString()=="Infotech Enterprises Ltd.") 
			{
				myPage.addText("[", 258, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(strState, 262, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			}
			else
			{
				myPage.addText("[State of", 258, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
				myPage.addText(strState, 298, 675, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			}
			
			//table Gray color
			myPage.drawLine(150,623,250,623,sharpPDF.pdfColor.LightGray,75);
			
			//Table horizontal lines
			myPage.drawLine(150,660,475,660,sharpPDF.pdfColor.Black);			
			myPage.drawLine(150,645,475,645,sharpPDF.pdfColor.Black);
			myPage.drawLine(150,630,475,630,sharpPDF.pdfColor.Black);			
			myPage.drawLine(150,615,475,615,sharpPDF.pdfColor.Black);
			myPage.drawLine(150,600,475,600,sharpPDF.pdfColor.Black);			
			myPage.drawLine(150,585,475,585,sharpPDF.pdfColor.Black);

			//table vertical lines
			myPage.drawLine(150,660,150,585,sharpPDF.pdfColor.Black);
			myPage.drawLine(250,660,250,585,sharpPDF.pdfColor.Black);
			myPage.drawLine(475,660,475,585,sharpPDF.pdfColor.Black);

			//table text
			myPage.addText("Registration ID", 155, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText("Name", 155, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText("Date of Birth", 155, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText("Test Location", 155, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText("Test Date", 155, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

			myPage.addText(RegistrationId, 255, 649, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText(Name, 255, 634, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText(Dob, 255, 619, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText(TestCentre, 255, 604, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			myPage.addText(TestDate, 255, 589, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);

			//Test Score
			myPage.addText("Test Scores", 80, 555, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.Black);
			
			// second table maroon fill
			myPage.drawLine(75,540,540,540,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,430,540,430,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,335,540,335,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,285,540,285,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,235,540,235,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,185,540,185,sharpPDF.pdfColor.DarkRed,20);
			myPage.drawLine(75,135,540,135,sharpPDF.pdfColor.DarkRed,20);

			//second table Grey fill
			myPage.drawLine(75,522,540,522,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,412,540,412,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,317,540,317,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,267,540,267,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,217,540,217,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,167,540,167,sharpPDF.pdfColor.LightGray,15);
			myPage.drawLine(75,117,540,117,sharpPDF.pdfColor.LightGray,15);

			//Second Table Horizontal
			myPage.drawLine (75,550,540,550,sharpPDF.pdfColor.Black);
			myPage.addText("Speaking", 80, 536, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,530,540,530,sharpPDF.pdfColor.Black);
			myPage.addText("Topic", 85, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 223, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 340, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 440, 519, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

			myPage.drawLine (75,515,540,515,sharpPDF.pdfColor.Black);
			myPage.addText("Voice Clearity", 85, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(MaxSSVoiceClarity, 255, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingVoiceClarity, 355, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(SpeakingPercentile, 465, 504, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);		

			myPage.drawLine (75,500,410,500,sharpPDF.pdfColor.Black);
			myPage.addText("Accent", 85, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(MaxSSAccent, 255, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingAccent, 355, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(SpeakingPercentile, 465, 489, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);		
				
			myPage.drawLine (75,485,410,485,sharpPDF.pdfColor.Black);
			myPage.addText("Fluency", 85, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(MaxSSFluency, 255, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingFluency, 355, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingPercentage, 465, 474, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);	

			myPage.drawLine (75,470,410,470,sharpPDF.pdfColor.Black);
			myPage.addText("Grammer", 85, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(MaxSSGrammar, 255, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingGrammar, 355, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(SpeakingPercentile, 465, 459, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);		
				
			myPage.drawLine (75,455,410,455,sharpPDF.pdfColor.Black);
			myPage.addText("Prosody", 85, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(MaxSProsody, 255, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(SpeakingProsody, 355, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(SpeakingPercentile, 465, 444, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);		
				
			myPage.drawLine (75,440,540,440,sharpPDF.pdfColor.Black);
			myPage.addText("Writing (Essay)", 80, 426, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);

			myPage.drawLine (75,420,540,420,sharpPDF.pdfColor.Black);
			myPage.addText("Topic", 85, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 223, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 340, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 440, 409, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,405,540,405,sharpPDF.pdfColor.Black);
			myPage.addText("Grammer", 85, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WEMaxSGrammar, 255, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingEssayGrammar, 355, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(WritingEssayPercentileScore, 465, 394, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,390,410,390,sharpPDF.pdfColor.Black);
			myPage.addText("Content", 85, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WEMaxSContent, 255, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingEssayContent, 355, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(WritingEssayPercentileScore, 465, 379, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,375,410,375,sharpPDF.pdfColor.Black);
			myPage.addText("Vocabulary", 85, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WEMaxSVocabulary, 255, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingEssayVocabulary, 355, 364, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingEssayPercentage, 465, 371, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				
			myPage.drawLine (75,360,410,360,sharpPDF.pdfColor.Black);
			myPage.addText("Spelling & Punctuation", 85, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WEMaxSSpellingPunctuation, 255, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingEssaySpellingPunctuation, 355, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(WritingEssayPercentileScore, 465, 349, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
				


			myPage.drawLine (75,345,540,345,sharpPDF.pdfColor.Black);
			myPage.addText("Writing (Multiple Choice)", 80, 331, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,325,540,325,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 150, 314, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 280, 314, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 410, 314, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.drawLine (75,310,540,310,sharpPDF.pdfColor.Black);
			myPage.addText(WritingMultipleChoiceMaxScore, 180, 299, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingMultipleChoiceYourScore, 310, 299, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(WritingMultipleChoicePercentageScore, 430, 299, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);


			myPage.drawLine (75,295,540,295,sharpPDF.pdfColor.Black);
			myPage.addText("Listening", 80, 281, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,275,540,275,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 150, 264, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 280, 264, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 410, 264, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.drawLine (75,260,540,260,sharpPDF.pdfColor.Black);
			myPage.addText(ListeningMaxScore, 180, 249, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(ListeningYourScore, 310, 249, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(ListeningPercentageScore, 430, 249, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,245,540,245,sharpPDF.pdfColor.Black);
			myPage.addText("Analytical and Quantitative Reasoning", 80, 231, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,225,540,225,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 150, 214, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 280, 214, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 410, 214, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.drawLine (75,210,540,210,sharpPDF.pdfColor.Black);
			myPage.addText(AQRMaxScore, 180, 199, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(AQRYourScore, 310, 199, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(AQRPercentageScore, 430, 199, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,195,540,195,sharpPDF.pdfColor.Black);
			myPage.addText("Learning Ability", 80, 181, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,175,540,175,sharpPDF.pdfColor.Black);
			myPage.addText("Maximum Score", 150, 164, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Your Score", 280, 164, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Percentage Score", 410, 164, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.drawLine (75,160,540,160,sharpPDF.pdfColor.Black);
			myPage.addText(LearningAbilityMaxScore, 180, 149, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(LearningAbilityYourScore, 310, 149, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(LearningAbilityPercentageScore, 430, 149, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,145,540,145,sharpPDF.pdfColor.Black);
			myPage.addText("Keyboard Skills", 80, 131, myDoc.getFontReference("AntiquaBold"),10,sharpPDF.pdfColor.White);
			myPage.drawLine (75,125,540,125,sharpPDF.pdfColor.Black);
			myPage.addText("Gross Speed (WPM)", 150, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Accuracy", 280, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText("Net Speed (WPM)", 410, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText("Percentile Score", 440, 114, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);

			myPage.drawLine (75,110,540,110,sharpPDF.pdfColor.Black);
			myPage.addText(KeyboardSkillsGrossSpeed, 180, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(KeyboardSkillsAccuracy, 310, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			myPage.addText(KeyboardNetSpeed, 430, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
			//myPage.addText(KeyboardSkillsPercentileScore, 455, 99, myDoc.getFontReference("Antiqua"),9,sharpPDF.pdfColor.Black);
		
			myPage.drawLine (75,95,540,95,sharpPDF.pdfColor.Black);

			// second table vertical lines
			myPage.drawLine (75,95,75,550,sharpPDF.pdfColor.Black);
			myPage.drawLine (540,95,540,550,sharpPDF.pdfColor.Black);

			myPage.drawLine (245,95,245,125,sharpPDF.pdfColor.Black);
			myPage.drawLine (370,95,370,125,sharpPDF.pdfColor.Black);
			//myPage.drawLine (410,95,410,125,sharpPDF.pdfColor.Black);

			myPage.drawLine (245,145,245,175,sharpPDF.pdfColor.Black);
			myPage.drawLine (370,145,370,175,sharpPDF.pdfColor.Black);

			myPage.drawLine (245,195,245,225,sharpPDF.pdfColor.Black);
			myPage.drawLine (370,195,370,225,sharpPDF.pdfColor.Black);

			myPage.drawLine (245,245,245,275,sharpPDF.pdfColor.Black);
			myPage.drawLine (370,245,370,275,sharpPDF.pdfColor.Black);

			myPage.drawLine (245,295,245,325,sharpPDF.pdfColor.Black);
			myPage.drawLine (370,295,370,325,sharpPDF.pdfColor.Black);

			myPage.drawLine (210,345,210,420,sharpPDF.pdfColor.Black);
			myPage.drawLine (310,345,310,420,sharpPDF.pdfColor.Black);
			myPage.drawLine (410,345,410,420,sharpPDF.pdfColor.Black);

			myPage.drawLine (210,440,210,530,sharpPDF.pdfColor.Black);
			myPage.drawLine (310,440,310,530,sharpPDF.pdfColor.Black);
			myPage.drawLine (410,440,410,530,sharpPDF.pdfColor.Black);


			//Outer Most Border
			myPage.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
			myPage.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
			myPage.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
			myPage.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

			
			//Inner Border
			myPage.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
			myPage.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
			myPage.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
			myPage.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

			//Outer Border
			myPage.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
			myPage.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
			myPage.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
			myPage.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

			//fotter

			myPage.drawLine (50,57,565,57,clGray);
			myPage.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
		
			// Second page
			sharpPDF.pdfPage myPage2 = myDoc.addPage();

			//Outer Most Border
			myPage2.drawLine (15,790,593,790,sharpPDF.pdfColor.Black);
			myPage2.drawLine (15,15,593,15,sharpPDF.pdfColor.Black);				
			myPage2.drawLine (15,790,15,15,sharpPDF.pdfColor.Black);
			myPage2.drawLine (593,15,593,790,sharpPDF.pdfColor.Black);

			//Inner Border
			myPage2.drawLine (40,775,575,775,sharpPDF.pdfColor.Black);
			myPage2.drawLine (40,40,575,40,sharpPDF.pdfColor.Black);				
			myPage2.drawLine (40,775,40,40,sharpPDF.pdfColor.Black);
			myPage2.drawLine (575,40,575,775,sharpPDF.pdfColor.Black);

			//Outer Border
			myPage2.drawLine (37,778,578,778,sharpPDF.pdfColor.Black);
			myPage2.drawLine (37,37,578,37,sharpPDF.pdfColor.Black);				
			myPage2.drawLine (37,778,37,37,sharpPDF.pdfColor.Black);
			myPage2.drawLine (578,37,578,778,sharpPDF.pdfColor.Black);

			//fotter

			myPage2.drawLine (50,57,565,57,clGray);
			myPage2.addText("NAC is a national assessment and certification program for aspiring candidates seeking job in Indian ITES – BPO Industry", 60, 45, myDoc.getFontReference("Antiqua"),9,clAAAAAA);
			
			//Matter

			myPage2.addText("•    Writing ", 53, 750, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("– It is a measure of the ability to both use and identify standard written English and the ability to organize and support ideas in English. ", 93, 750, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Scoring of the written essay takes into account organization and language use, as well as success in completing a defined writing task.", 65, 740, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("•    Listening  ", 53, 720, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("– It is a measure of the comprehension of spoken English including the ability to identify main ideas, the ability to understand factual", 98, 720, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("information and details, and the ability to connect information across longer speech samples. Speech samples  simulate  a  variety  of work and ", 65, 710, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("and everyday situations and include both extended announcements and conversations.", 65, 700, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("•	   Analytical and Quantitative Reasoning (A&Q) ", 53, 680, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("- It is a measure of the ability to (i) assimilate information presented in a structured way including ", 218, 680, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("quantitative information and (ii) draw logical inferences from the information, including identifying when information is insufficient to support ", 65, 670, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("an inference. Tasks in this section require the ability to comprehend sets of practical relationships presented in English as well as the ability ", 65, 660, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("to apply basic mathematical concepts.", 65, 650, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("•	   Learning Ability ", 53,630, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("– It is a measure of ability to learn new technology. Task in this section requires the ability to understand a new concept and ", 120, 630, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("apply it in a hypothetical situation.", 65, 620, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("•	   Keyboard Skills ", 53,600, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("– It measures the skills to use keyboard proficiently. Task in this section requires the ability to enter data accurately in a given ", 116, 600, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("span of time. Gross / Net Speed are mentioned in 'words per minute' and Accuracy is given in 'percentage'.", 65, 590, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("•	   Speaking ", 53,570, myDoc.getFontReference("AntiquaItalic"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("– It is a measure of the ability to speak English in a professional context. Tasks in this section require comprehension of spoken Eng- ", 94, 570, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("lish and written English. Scoring takes into account delivery and language use, as well as success at completing defined communicative tasks.", 65, 560, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.addText("Qualitative description of ratings/scales (Speaking)", 57, 540, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			
			myPage2.drawLine (57,530,563,530,sharpPDF.pdfColor.Black);
			myPage2.addText("Rating ", 65, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Qualitative Rating", 105, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Rating Description", 305, 522, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,518,563,518,sharpPDF.pdfColor.Black);
			myPage2.addText("5 ", 75, 504, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Excellent", 104, 506, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Requires no language training", 304, 506, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,494,563,494,sharpPDF.pdfColor.Black);
			myPage2.addText("4 ", 75, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Good", 105, 480, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Requires minimum language training", 305, 480, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,470,563,470,sharpPDF.pdfColor.Black);
			myPage2.addText("3.5 ", 72, 456, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Above Average", 105, 456, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("May require focused language training. Is generally comfortable with", 305, 461, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("the language", 305, 451, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,446,563,446,sharpPDF.pdfColor.Black);
			myPage2.addText("3 ", 75, 432, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Average", 105, 432, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("May require considerable language training. Is reasonably comfortable ", 305, 437, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("with the language", 305, 428, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,422,563,422,sharpPDF.pdfColor.Black);
			myPage2.addText("2 ", 75, 408, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Below Average", 105, 408, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Requires extensive language training. Is not very comfortable with the", 305, 413, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("language", 305, 404, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,398,563,398,sharpPDF.pdfColor.Black);
			myPage2.addText("1 ", 75, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Poor", 105, 384, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Requires intensive language training. Poor command of the language", 305, 384, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,374,563,374,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,374,57,530,sharpPDF.pdfColor.Black);
			myPage2.drawLine (563,374,563,530,sharpPDF.pdfColor.Black);
			myPage2.drawLine (97,374,97,530,sharpPDF.pdfColor.Black);
			myPage2.drawLine (297,374,297,530,sharpPDF.pdfColor.Black);

			myPage2.addText("Qualitative description of ratings/scales (Writing Essay)", 57, 360, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			
			myPage2.drawLine (57,350,563,350,sharpPDF.pdfColor.Black);
			myPage2.addText("Rating ", 65, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Qualitative Rating", 105, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Rating Description", 305, 342, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,338,563,338,sharpPDF.pdfColor.Black);
			myPage2.addText("6 ", 75, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Excellent:", 105, 324, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Advanced level language user", 145, 324, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("No language errors; completely accurate comprehension, interpretation ", 305, 329, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("& completely relevant response", 305, 320, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);

			myPage2.drawLine (57,314,563,314,sharpPDF.pdfColor.Black);
			myPage2.addText("5 ", 75, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Good:", 105, 300, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Proficient level language user", 130, 300, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Makes occasional language errors; largely accurate comprehension, ", 305, 305, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("interpretation & largely relevant response", 305, 296, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


			myPage2.drawLine (57,290,563,290,sharpPDF.pdfColor.Black);
			myPage2.addText("4 ", 75, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Above Average:", 105, 276, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Vantage level language user", 165, 276, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Makes a few language errors; generally accurate comprehension, ", 305, 281, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("interpretation & generally relevant response", 305, 272, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


			myPage2.drawLine (57,266,563,266,sharpPDF.pdfColor.Black);
			myPage2.addText("3 ", 75, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Average:", 105, 252, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Threshold level language user", 140, 252, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Makes regular language errors; fairly accurate comprehension, ", 305, 257, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("interpretation & reasonably relevant response", 305, 248, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


			myPage2.drawLine (57,242,563,242,sharpPDF.pdfColor.Black);
			myPage2.addText("2 ", 75, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Below Average:", 105, 228, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Learner level language user", 165, 228, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Makes several language errors; largely inaccurate comprehension, ", 305, 233, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("interpretation & largely irrelevant response", 305, 224, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);


			myPage2.drawLine (57,218,563,218,sharpPDF.pdfColor.Black);
			myPage2.addText("1 ", 75, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Poor: ", 105, 204, myDoc.getFontReference("AntiquaBold"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Beginner level language user", 130, 204, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("Makes too many language; completely inaccurate comprehension, ", 305, 209, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);
			myPage2.addText("interpretation & completely irrelevant response", 305, 200, myDoc.getFontReference("Antiqua"),8,sharpPDF.pdfColor.Black);



			myPage2.drawLine (57,194,563,194,sharpPDF.pdfColor.Black);			


			myPage2.drawLine (57,194,57,350,sharpPDF.pdfColor.Black);
			myPage2.drawLine (563,194,563,350,sharpPDF.pdfColor.Black);
			myPage2.drawLine (97,194,97,350,sharpPDF.pdfColor.Black);
			myPage2.drawLine (297,194,297,350,sharpPDF.pdfColor.Black);

			myPage2.addText("Important points", 57, 180, myDoc.getFontReference("AntiquaBold"),8,clGray);
			myPage2.drawLine (57,178,120,178,clGray);
			myPage2.addText("1. This is the official score card for NAC, NASSCOM Assessment of Competence", 72, 160, myDoc.getFontReference("Antiqua"),8,clGray);
			DateTime Testdate1= Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim());
			DateTime test= new DateTime(2009,5,15);
			int retval=Testdate1.CompareTo(test);

			if(Testdate1>=test)
			{
				myPage2.addText("2. Where 'NA' is present on a score report, a score could not be provided due to either of two possible reasons – (i) the test taker did not  ", 72, 150, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("attempt that section of the test or (ii) there was considerable difficulty in discerning the test taker’s responses / there was insufficient data.", 82, 140, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("3. You may use this score sheet for applying to companies announced to be recruiting through NAC. However, NAC Test participation does ", 72, 130, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("not guarantee employment.", 82, 120, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("4. The employers may or may not assess your academic performance, details of past employment etc. for the purpose of final selection.", 72, 110, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("5. The content of current version of this assessment is designed and developed by MeritTrac Services Pvt. Ltd.", 72, 100, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("6. NAC is endorsed by leading ITES-BPO players.", 72, 90, myDoc.getFontReference("Antiqua"),8,clGray);
			}
			else
			{
				myPage2.addText("2. Scores are provided in percentile manner and range from 0.1 to 100. Example - A percentile score of 50 on a skill indicates that 50% of the ", 72, 150, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("population has scored below or equal to the test taker taking the same test for that skill on the same day. ", 82, 140, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("3. Where 'NA' is present on a score report, a score could not be provided due to either of two possible reasons – (i) the test taker did not  ", 72, 130, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("attempt that section of the test or (ii) there was considerable difficulty in discerning the test taker’s responses / there was insufficient data.", 82, 120, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("4. You may use this score sheet for applying to companies announced to be recruiting through NAC. However, NAC Test participation does ", 72, 110, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("not guarantee employment.", 82, 100, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("5. The employers may or may not assess your academic performance, details of past employment etc. for the purpose of final selection.", 72, 90, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("6. The content of current version of this assessment is designed and developed by MeritTrac Services Pvt. Ltd.", 72, 80, myDoc.getFontReference("Antiqua"),8,clGray);
				myPage2.addText("7. NAC is endorsed by leading ITES-BPO players.", 72, 70, myDoc.getFontReference("Antiqua"),8,clGray);
				
			}
				
				
			//create PDF
			myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "ScoreCard_" + strPINNo + ".pdf"); 
			myPage = null;
			myDoc = null; 
			return flag;		

			
		}
	}
}
