using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using BusinessLayer;
using Common;
namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for TestScorePercentage.
	/// </summary>
	public partial class TestScorePercentage : System.Web.UI.Page
	{

		public string strDivStyle;
		//protected System.Web.UI.WebControls.Label lblStateTemp;
		public string stateName;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["UserID"]==null)
			{
				Response.Redirect("../Homepage.aspx");
			}
			string strUserAgent = Request.UserAgent.ToString().ToLower();			 

			if(strUserAgent.IndexOf("msie 6.0") != -1)
			{
				strDivStyle = "ImgPosition5";

				imgWatermark.Src = "Images/NAC_Stamp_bg6.gif";
			}
			else
			{
				strDivStyle = "ImgPosition6";
				imgWatermark.Src = "Images/NAC_Stamp_bg.gif";
			}
			
			lblState.Text = Convert.ToString(HttpContext.Current.Session["StateName"]);
			lblStateTemp.Text = Convert.ToString(HttpContext.Current.Session["StateName"]);
			stateName = Convert.ToString(HttpContext.Current.Session["StateName"]);

			if(Convert.ToString(HttpContext.Current.Session["StateName"])=="Rajasthan")
			{
				WritingEssay1.Visible=false;
				WritingEssay2.Visible=false;
				WritingEssay3.Visible=false;
				WritingEssay4.Visible=false;
				WritingEssay5.Visible=false;
				WritingEssay6.Visible=false;
				lblMultipleChoice.Visible=false; 
				Essay1.Visible=false;
				Essay2.Visible=false;
				Essay3.Visible=false;
				Essay4.Visible=false;
				Essay5.Visible=false;
				Essay6.Visible=false;
				Essay7.Visible=false;
				Essay8.Visible=false;
				
  
			}


			if (!Page.IsPostBack)
			{				
				GetTestScore();
			}
		}

		private void GetTestScore()
		{
			try
			{
				DataSet dsTestScore = new DataSet();
				string strNACRegID = Session["UserID"].ToString();
				BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
				dsTestScore = objTestScore.GetTestScore(strNACRegID);

				

				if (dsTestScore.Tables[0].Rows.Count > 0)
				{

					//Registration Detail
					lblRegistrationId.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["NACRegID"]).Trim();
					lblName.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["CandidateName"]).Trim();
					lblDob.Text = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["DOB"].ToString().Trim()));
					lblTestCentre.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["TestLocation"]).Trim();
					lblTestDate.Text = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim()));
					DateTime Testdate= Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim());
					DateTime test= new DateTime(2009,5,15);
					int retval=Testdate.CompareTo(test);

					if(Testdate>=test)
					{
					   //scores.Visible=false;
					}
// 

					//Speaking Test Score
					lblMaxSSVoiceClarity.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
					lblMaxSSAccent.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
					lblMaxSSFluency.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
					lblMaxSSGrammar.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
					lblMaxSProsody.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingMaxScore"]).Trim();
				
					lblSpeakingVoiceClarity.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingVoiceClarity"]).Trim();
					lblSpeakingAccent.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingAccent"]).Trim();
					lblSpeakingFluency.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingFluency"]).Trim();
					lblSpeakingGrammar.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingGrammar"]).Trim();
					lblSpeakingProsody.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingProsody"]).Trim();
					//lblSpeakingPercentile.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingPercentile"]).Trim();
					lblSpeakingPercentage.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["SpeakingPercentage"]).Trim());

					//Writing (Essay) 
					lblWEMaxSGrammar.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
					lblWEMaxSContent.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
					lblWEMaxSVocabulary.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();
					lblWEMaxSSpellingPunctuation.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayMaxScore"]).Trim();

					lblWritingEssayGrammar.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayGrammar"]).Trim();
					lblWritingEssayContent.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayContent"]).Trim();
					lblWritingEssayVocabulary.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayVocabulary"]).Trim();
					lblWritingEssaySpellingPunctuation.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssaySpelling_Punctuation"]).Trim();
					//lblWritingEssayPercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayPercentile"]).Trim();
					lblWritingEssayPercentage.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingEssayPercentage"]).Trim());

					//Writing (Multiple Choice)
					lblWritingMultipleChoiceYourScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingScore"]).Trim();
					lblWritingMultipleChoiceMaxScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingMaxScore"]).Trim();
					lblWritingMultipleChoicePercentage.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentage"]).Trim());
					//lblWritingMultipleChoicePercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["WritingPercentile"]).Trim();

					//Listening
					lblListeningYourScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningScore"]).Trim();
					lblListeningMaxScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningMaxScore"]).Trim();
					lblListeningPercentageScore.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentage"]).Trim());
					//lblListeningPercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["ListeningPercentile"]).Trim();				

					//Analytical and Quantitative Reasoning
					lblAQRYourScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRScore"]).Trim();
					lblAQRMaxScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRMaxScore"]).Trim();
					lblAQRPercentageScore.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentage"]).Trim());
					//lblAQRPercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AQRPercentile"]).Trim();				

					//Learning Ability			
					lblLearningAbilityYourScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAScore"]).Trim();
					lblLearningAbilityMaxScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAMaxScore"]).Trim();
					lblLearningAbilityPercentageScore.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentage"]).Trim());
					//lblLearningAbilityPercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["LAPercentile"]).Trim();

					//Keyboard Skills
					lblKeyboardSkillsGrossSpeed.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardGrossSpeed"]).Trim();
					lblKeyboardSkillsAccuracy.Text = PercentageAppend(Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardAccuracy"]).Trim());
					lblKeyboardNetSpeed.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardNetSpeed"]).Trim();
					//lblKeyboardSkillsPercentileScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KeyboardPercentile"]).Trim();							
							
				}
				else
				{
					Response.Redirect("TestScoreMessage.aspx");
				}
				
			}
			catch (Exception SysEx)
			{
					
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
					
			}
		
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void btnBack_Click(object sender, System.EventArgs e)
		{			 
			Response.Redirect("Welcome.aspx");			 
		}		 

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string RegistrationId = Convert.ToString(Session["UserID"]);
			if(RegistrationId!= null)
			{
				BusinessLayer.BLGenerateTestScore objBLGenerateTestScore = new BLGenerateTestScore();
				bool typeflag; 
				typeflag=objBLGenerateTestScore.GenerateScoreCardPDFPercentage(RegistrationId);				 
				SaveAsPDF(RegistrationId);
			}
		}

		private void SaveAsPDF(string RegistrationId)
		{
			bool bFileExist = false;
			int intTimeout = 0;	
			string strFileName = null;
			strFileName = "ScoreCard_" + RegistrationId + ".pdf";
			string FilePath = MapPath("")+ "\\TempWorkAreaPdf\\" + strFileName;
			
				
			while ( bFileExist == false )
			{
				if (File.Exists(FilePath))
				{
					bFileExist = true;
				}					 
				Thread.Sleep(1000);					
				intTimeout++;
				if ( intTimeout == 10 )
					break;
			}

			if (bFileExist == true)
			{
				try
				{
					Response.Clear();
					Response.ClearHeaders();
					Response.ContentType="application/pdf";					  
					Response.AddHeader("content-disposition", "attachment; filename="+ strFileName);				 
					Response.WriteFile(FilePath);	
					Response.Flush();
					Response.Close();
					ClearTempFiles(FilePath);
				}
				catch(Exception ex)
				{
					Response.ClearContent();
					throw(ex);
				}
					
					 
                    
			}	 
		}

		/// <summary>
		/// This method will be used to clear up all the temporary file created in the process.
		/// from TempWorkArea and TempworkAreaPdf folder.
		/// </summary>
		private void ClearTempFiles(string FilePath)
		{
			 
			// TempWorkAreaPdf is a folder where HTML and PDf file will be created
			
			if (File.Exists(FilePath))
			{
				try
				{
					File.Delete(FilePath);
					FilePath = FilePath.Replace(".pdf", ".html");
					File.Delete(FilePath);					 
				}
				catch (Exception ex)
				{
					throw (ex);
               
				}				 
        
			}


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

		protected void btnSaveTop_Click(object sender, System.EventArgs e)
		{
			btnSave_Click(sender, e);
		}

	}
}
