using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Andra_Pradesh_MultipleEvents.
	/// </summary>
	public class Andra_Pradesh_MultipleEvents : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblComments;
		protected System.Web.UI.WebControls.Label lblRegStartDate;
		protected System.Web.UI.WebControls.Label lblRegEndDate;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Repeater rptrLinks;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblResultDeclarationDate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			BLRegistration objBLRegistration = new BLRegistration();
			if(Session["StateId"]!=null)
			{
				int stateId = Convert.ToInt32(Session["StateId"].ToString());
				lblState.Text = Session["State"].ToString();
				objBLRegistration.StateId = stateId;
				DataSet ds = new DataSet();
				ds = objBLRegistration.CheckStateCentreIsActive();
				rptrLinks.DataSource = ds;
				rptrLinks.DataBind();
				Page.DataBind();
			}
			else
			{
				Response.Redirect("../homepage.aspx");
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
			this.rptrLinks.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rptrLinks_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rptrLinks_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			if(e.CommandName.ToLower().Equals("deletecomment")) 
			{
				LinkButton lnk; 
				lnk = (LinkButton)rptrLinks.Items[e.Item.ItemIndex].FindControl("lnkbtnEvent");
				Session["TestId"] = lnk.CommandArgument;
				Response.Redirect("../Web/Andra_Pradesh_SingleEvent.aspx");
			}
			else
			{
				Response.Redirect("../NAC.aspx");
			}
		}
	}
}
