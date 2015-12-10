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

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for ThankYou.
	/// </summary>
	public partial class ThankYou : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnClose.Attributes.Add("onclick","CloseWindow();");
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

		protected void btnClose_Click(object sender, System.EventArgs e)
		{
			Session.Abandon();
			Response.Write("<script language=javascript>window.close();</script>");
			Response.Redirect("Home.aspx",true);
		}
	}
}
