using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for ScoreCardRequest.
	/// </summary>
	public partial class ScoreCardRequest : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string strNACRegID = Session["UserID"].ToString();
			
			int intCandidateIdForNewScorecardFrom = Convert.ToInt32(ConfigurationSettings.AppSettings["CandidateIdForNewScoreCardFrom"].ToString());
			BLGenerateTestScore objBLTestScore = new BLGenerateTestScore();
			int candidateId = objBLTestScore.GetCandidateIdAgainstRegId(strNACRegID);

			if(candidateId >= intCandidateIdForNewScorecardFrom)
				Response.Redirect("TestScorePercentage.aspx");
					else
				Response.Redirect("TestScorePercentageV2.aspx");
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
	}
}
