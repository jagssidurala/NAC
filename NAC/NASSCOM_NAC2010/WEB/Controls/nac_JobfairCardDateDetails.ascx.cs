
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

namespace NASSCOM_NAC.Web.Controls
{
	

	/// <summary>
	///		Summary description for nac_JobfairCardDateDetails.
	/// </summary>
	public partial class nac_JobfairCardDateDetails : System.Web.UI.UserControl
	{

		private string strId;


		public string RegId
		{
			get{return strId;}
			set{strId = value;}
		}

		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			string strRegistrationId=RegId.ToString();


			//int StateId=Convert.ToInt32(Session["StateId"].ToString());
			DataSet dsJobFairCardDateDetails = new DataSet();

			BusinessLayer.BLJobFairCard oBLJobFairCard = new BusinessLayer.BLJobFairCard();
			dsJobFairCardDateDetails = oBLJobFairCard.GenerateJobFairCardStateDateDetails(strRegistrationId);

			if (dsJobFairCardDateDetails.Tables[0].Rows.Count > 0)
			{
				if((Convert.ToInt32(dsJobFairCardDateDetails.Tables[0].Rows[0]["StateID"])>=9  && Convert.ToInt32(dsJobFairCardDateDetails.Tables[0].Rows[0]["StateID"])<=16)||Convert.ToInt32(dsJobFairCardDateDetails.Tables[0].Rows[0]["StateID"])==3||Convert.ToInt32(dsJobFairCardDateDetails.Tables[0].Rows[0]["StateID"])==1)
				{
					TblInterview.Visible=false;
					TblInterview2.Visible=true;																		
						
					lblInterviewDate.Text = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsJobFairCardDateDetails.Tables[0].Rows[0]["FRISTINTERVIEWDATE"].ToString()));
					if(dsJobFairCardDateDetails.Tables[0].Rows[0]["InterviewTime"]!=System.DBNull.Value)
					{
						lblInterviewTime.Text = String.Format("{0:HH:mm tt}",Convert.ToDateTime(dsJobFairCardDateDetails.Tables[0].Rows[0]["InterviewTime"].ToString()));
					}
					else
					{
						lblInterviewTime.Text="";
					}					
					lblVenue.Text = dsJobFairCardDateDetails.Tables[0].Rows[0]["Venue"].ToString();
						
				}
				else
				{
					TblInterview.Visible=true;
					TblInterview2.Visible=false;													
						
					lblDate1.Text=  String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsJobFairCardDateDetails.Tables[0].Rows[0]["FristInterviewDate"].ToString()));						
						
						
				}
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
