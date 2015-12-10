using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for NewTestScore.
	/// </summary>
	public class NewTestScore : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSaveTop;
		protected System.Web.UI.WebControls.Button btnBackTop;
		protected System.Web.UI.WebControls.Label lblStateTemp;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblRegistrationId;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblDob;
		protected System.Web.UI.WebControls.Label lblTestCentre;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Label lblMaxSSVoiceClarity;
		protected System.Web.UI.WebControls.Label lblSpeakingVoiceClarity;
		protected System.Web.UI.WebControls.Label lblMaxSSAccent;
		protected System.Web.UI.WebControls.Label lblSpeakingAccent;
		protected System.Web.UI.WebControls.Label lblMaxSSFluency;
		protected System.Web.UI.WebControls.Label lblSpeakingFluency;
		protected System.Web.UI.WebControls.Label lblMaxSSGrammar;
		protected System.Web.UI.WebControls.Label lblSpeakingGrammar;
		protected System.Web.UI.WebControls.Label lblMaxSProsody;
		protected System.Web.UI.WebControls.Label lblSpeakingProsody;
		protected System.Web.UI.WebControls.Label lblWEMaxSGrammar;
		protected System.Web.UI.WebControls.Label lblWritingEssayGrammar;
		protected System.Web.UI.WebControls.Label lblWEMaxSContent;
		protected System.Web.UI.WebControls.Label lblWritingEssayContent;
		protected System.Web.UI.WebControls.Label lblWEMaxSVocabulary;
		protected System.Web.UI.WebControls.Label lblWritingEssayVocabulary;
		protected System.Web.UI.WebControls.Label lblWEMaxSSpellingPunctuation;
		protected System.Web.UI.WebControls.Label lblWritingEssaySpellingPunctuation;
		protected System.Web.UI.WebControls.Label lblMultipleChoice;
		protected System.Web.UI.WebControls.Label lblWritingMultipleChoicePercentageScore;
		protected System.Web.UI.WebControls.Label lblWritingMultipleChoicePercentileScore;
		protected System.Web.UI.WebControls.Label lblListeningPercentageScore;
		protected System.Web.UI.WebControls.Label lblListeningPercentileScore;
		protected System.Web.UI.WebControls.Label lblAQRPercentageScore;
		protected System.Web.UI.WebControls.Label lblAQRPercentileScore;
		protected System.Web.UI.WebControls.Label lblLearningAbilityPercentageScore;
		protected System.Web.UI.WebControls.Label lblLearningAbilityPercentileScore;
		protected System.Web.UI.WebControls.Label lblKeyboardSkillsGrossSpeed;
		protected System.Web.UI.WebControls.Label lblKeyboardSkillsAccuracy;
		protected System.Web.UI.WebControls.Label lblKeyboardNetSpeed;
		protected System.Web.UI.WebControls.Label lblKeyboardSkillsPercentileScore;
		protected System.Web.UI.WebControls.Button btnSaveBottom;
		protected System.Web.UI.WebControls.Button btnBackBottom;
		protected System.Web.UI.HtmlControls.HtmlImage imgWatermark;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay1;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay2;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay3;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay4;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay5;
		protected System.Web.UI.HtmlControls.HtmlTableRow WritingEssay6;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay1;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay2;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay3;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay4;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay5;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay6;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay7;
		protected System.Web.UI.WebControls.Label lblSpeakingPercentage;
		protected System.Web.UI.WebControls.Label lblWritingEssayPercentageScore;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay8;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
