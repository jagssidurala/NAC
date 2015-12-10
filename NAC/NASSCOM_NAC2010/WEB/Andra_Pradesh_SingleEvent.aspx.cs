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
using System.Configuration;
using System.Web.Security;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Andra_Pradesh_SingleEvent.
	/// </summary>
	public class Andra_Pradesh_SingleEvent : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblComments;
		protected System.Web.UI.WebControls.Label lblRegStartDateText;
		protected System.Web.UI.WebControls.Label lblRegStartDate;
		protected System.Web.UI.WebControls.Label lblRegEndDateText;
		protected System.Web.UI.WebControls.Label lblRegEndDate;
		protected System.Web.UI.WebControls.Label lblTestDateText;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Label lblResultDeclarationDateText;
		protected System.Web.UI.WebControls.Label lblResultDeclarationDate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trComments;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRegStartDate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRegEndDate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trTestDate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trResultDeclarationDate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trEventName;
		protected System.Web.UI.WebControls.Label lblEvent;
		protected System.Web.UI.WebControls.Label lblState;
		static string prevPage = String.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			if(!IsPostBack)
//			{
//				prevPage = Request.UrlReferrer.ToString();
//			}
			int TestId = 0;
			if(Session["TestId"]!=null && Session["StateId"]!=null)
			{
				TestId = Convert.ToInt32(Session["TestId"].ToString());
				lblState.Text = Session["State"].ToString();
			}
			else
			{
				Response.Redirect("../homepage.aspx");
			}
			BLRegistration objBLRegistration = new BLRegistration();
			objBLRegistration.TestId = TestId;
			DataSet ds = objBLRegistration.GetEventbyTestId();
			if(ds.Tables[0].Rows.Count!=0)
			{
				if(ds.Tables[0].Rows[0]["Comments"].ToString() == String.Empty)
				{
					trComments.Style.Add("Display","None");
				}
				else
				{
					lblComments.Text=ds.Tables[0].Rows[0]["Comments"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegistrationStartDate"].ToString() == String.Empty)
				{
					trRegStartDate.Style.Add("Display","None");
				}
				else
				{
					lblRegStartDate.Text=Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationStartDate"].ToString()).ToLongDateString();
				}
				if(ds.Tables[0].Rows[0]["RegistrationEndDate"].ToString() == String.Empty)
				{
					trRegEndDate.Style.Add("Display","None");
				}
				else
				{
					lblRegEndDate.Text=Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationEndDate"].ToString()).ToLongDateString();
				}
				if(ds.Tables[0].Rows[0]["TestDate"].ToString() == String.Empty)
				{
					trTestDate.Style.Add("Display","None");
				}
				else
				{
					lblTestDate.Text=Convert.ToDateTime(ds.Tables[0].Rows[0]["TestDate"].ToString()).ToLongDateString();
				}
				if(ds.Tables[0].Rows[0]["ResultDate"].ToString() == String.Empty)
				{
					trResultDeclarationDate.Style.Add("Display","None");
				}
				else
				{
					lblResultDeclarationDate.Text=Convert.ToDateTime(ds.Tables[0].Rows[0]["ResultDate"].ToString()).ToLongDateString();
				}
				if(ds.Tables[0].Rows[0]["Name"].ToString() == String.Empty)
				{
					trEventName.Style.Add("Display","None");
				}
				else
				{
					lblEvent.Text = ds.Tables[0].Rows[0]["Name"].ToString();
				}
			}
			else
			{
				Response.Redirect(prevPage);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
