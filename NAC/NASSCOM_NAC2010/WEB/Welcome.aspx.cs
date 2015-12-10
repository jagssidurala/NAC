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
using Common;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Welcome.
	/// </summary>
	public partial class Welcome : System.Web.UI.Page
	{
		public int intStateId = 0;
		public DateTime DateOfRegistration;
		public int intUserType = 0;
		public int intRequestStatus = 0;
		public int intTestId = 0;
		public string strTestName="NACTest1";
		//		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		//		protected System.Web.UI.WebControls.LinkButton Linkbutton1;
		private int intScoreCheck = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			lbtnLogout.Attributes.Add("onclick","CloseWindow();");
			//Checking that session is live or not.
			//Common.CLCommonFunctions.CheckSession();	
			
			DateOfRegistration=Convert.ToDateTime(Session["RegistrationDate"]); 

			if(!Page.IsPostBack)
			{
				divFlash.Visible=false;
				//Validating session.
				BLTest objBLTest = new BLTest();
				if( Session["UserType"] != null)
				{
					//Checking NAC user for user type.
					if(Session["UserType"].ToString() == "1" && Session["StateId"] != null)
					{
						divFlash.Visible=true;
						//Displaying user name in lblWelcomeText label.
						lblWelcomeText.Text = " " + Session["UserName"].ToString();
						intUserType = Convert.ToInt32(Session["UserType"]);
						intStateId = Convert.ToInt32(Session["StateId"]);
						strTestName = Convert.ToString(Session["TestName"]);
						divCandidate.Visible = true;
						divETS.Visible = false;
						divAdmin.Visible = false;
						divLnkCandidate.Visible = true;
						divLnkAdmin.Visible = false;
						divLnkETS.Visible = false;				  
						//lblBodyText.Text = Server.HtmlDecode(Convert.ToString(objBLTest.GetWelcomeBodyText(intUserType,intStateId,strTestName).ToString()));
						if(Session["JobLogin"]!= null && Session["JobLogin"].ToString()!= "")
						{
							divLogin.Visible= true;
							lblUserId.Text= " " + Session["JobLogin"].ToString(); 
							lblPassword.Text = " " + Session["JobLoginPassword"].ToString();
							lblEmailId.Text = " " + Session["Email"].ToString(); 
							lblPassword1.Text = " " + Session["JobLoginPassword"].ToString();
						}
					}
					else if(Session["UserType"].ToString() == "2")
					{
						//Displaying user name in lblWelcomeText label.
						lblWelcomeText.Text = " " + Session["UserName"].ToString();
						divCandidate.Visible = false;
						divETS.Visible = false;
						divAdmin.Visible = true;
						divLnkCandidate.Visible = false;
						divLnkAdmin.Visible = true;
						divLnkETS.Visible = false;
						intRequestStatus = objBLTest.GetRequestStatus();
						lblBodyText.Text = Server.HtmlDecode(Convert.ToString(objBLTest.GetWelcomeBodyText(intUserType,intStateId,strTestName).ToString()));
						divLogin.Visible= false;	
						
						
						   
					}
					else if(Session["UserType"].ToString() == "3")
					{
						//Displaying user name in lblWelcomeText label.
						lblWelcomeText.Text = " " + Session["UserName"].ToString();
						divCandidate.Visible = false;
						divETS.Visible = true;
						divAdmin.Visible = false;
						divLnkCandidate.Visible = false;
						divLnkAdmin.Visible = false;
						divLnkETS.Visible = true;
						lblBodyText.Text = Server.HtmlDecode(Convert.ToString(objBLTest.GetWelcomeBodyText(intUserType,intStateId,strTestName).ToString()));
						divLogin.Visible= false;
						
						
					}
				}
				else
				{
					divCandidate.Visible = false;
					divETS.Visible = false;
					divAdmin.Visible = false;
					divLnkCandidate.Visible = false;
					divLnkAdmin.Visible = false;
					divLnkETS.Visible = false;
					//If user is not valid then control to be redirected on DDDefault.aspx.
					//Response.Redirect(Request.UrlReferrer.ToString());
					Response.Redirect("Login.aspx");
					divLogin.Visible= false;
					
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
		//Added By Shweta
		private void lnkScoreCard_Click(object sender, System.EventArgs e)
		{
		   
		}

		private void lnkClickHere_Click(object sender, System.EventArgs e)
		{
			DateTime DateOfRegistration1;
			DateOfRegistration1=Convert.ToDateTime(Session["RegistrationDate"]);
			DataSet dsTestScore = new DataSet();
			if(Session["UserID"].ToString()!="")
			{
				string strNACRegID = Session["UserID"].ToString();
				BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
				dsTestScore = objTestScore.GetScoreRegistrationID(strNACRegID);
				
				if (dsTestScore.Tables[0].Rows.Count > 0)
				{
	               
					string strNACRegID1 = Convert.ToString(dsTestScore.Tables[0].Rows[0]["RegistrationID"]).Trim();
					if(strNACRegID1.Trim().StartsWith("NG"))  //For NAC Diagonostic candidates
					{
						string jScript;
						jScript = "<Script Language=Javascript>alert('This service is not available for those taking NAC/NAC-Tech Diagnostic as Diagnostic Test is not conceptualized to be used for employment purposes.')</Script>";
						Page.RegisterStartupScript("keyClientBlock", jScript);
						//Response.Write(jScript);
						//Response.Redirect("Welcome.aspx");
					}
					else
					{
						objTestScore.IPAddress = Request.UserHostAddress.ToString();
						objTestScore.NACRegID = strNACRegID1;
						objTestScore.firstclickdate = System.DateTime.Now;
						objTestScore.AddTJVisit();
						//Response.Redirect("http://www.timesjobs.com/candidate/post_resume_stage1.html?source=CMD_10500&from=nac");
						intScoreCheck= objTestScore.IsScoreExits(strNACRegID1);
					
						if(intScoreCheck== 1)
						{
							Response.Redirect("http://www.timesjobs.com/candidate/post_resume_stage1.html?source=CMD_10500&from=nac");
						}
						else
						{
							string jScript;
							jScript = "<Script Language=Javascript>alert('Your Scores have not yet been published on the website.Please try after you have received your scores.Thank you.')</Script>";
							Page.RegisterStartupScript("keyClientBlock", jScript);
						}
					}
				}
			
				else
				{
					string jScript;
					jScript = "<Script Language=Javascript>alert('Your Scores have not yet been published on the website.Please try after you have received your scores.Thank you.')</Script>";
					Page.RegisterStartupScript("keyClientBlock", jScript);
				}
			}
		}

		protected void lbtnLogout_Click(object sender, System.EventArgs e)
		{
			//Session["UserType"] = null;
			//Session.Abandon();
			//Response.Redirect("../Default.aspx");

			/*Session.Clear();//clear session
			Session.Abandon();//Abandon sessionResponse.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Redirect("../Default.aspx");*/
			Session.Abandon();
			Response.Write("<script language=javascript>self.close();</script>");
			string nextpage = "../Default.aspx";
			Response.Write("<script language=javascript>");
			Response.Write("{");
			Response.Write(" var Backlen=history.length;");
			Response.Write(" history.go(-Backlen);");
			Response.Write(" window.location.href='" + nextpage + "'; ");
			Response.Write("}");
			Response.Write("</script>");  

			Response.Cache.SetExpires(DateTime.Parse(DateTime.  Now.ToString()));
			Response.Cache.SetCacheability(HttpCacheability.Private);
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");


			//Response.Redirect("../Default.aspx");
 
			

		}

		
		//Added By Shweta End
	}
}
