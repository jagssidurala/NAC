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
using BusinessLayer;

namespace NASSCOM_NAC
{
	/// <summary>
	/// Summary description for _default.
	/// </summary>
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Response.Redirect("web/pindefault.aspx");

			
//			Response.Write("Browser:" + Request.Browser.Browser.ToString()+ "<br/>");
//			Response.Write("ActiveXControls:" + Request.Browser.ActiveXControls.ToString()+ "<br/>");
//			Response.Write("JavaScript:" + Request.Browser.JavaScript.ToString()+ "<br/>");			
//			Response.Write("Platform:" + Request.Browser.Platform.ToString()+ "<br/>");
//			Response.Write("VBScript:" + Request.Browser.VBScript.ToString()+ "<br/>");
//			Response.Write("Version:" + Request.Browser.Version.ToString()+ "<br/>");
//			Response.Write("Version:" + Request.Browser.Cookies.ToString()+ "<br/>");
		
		 
			

			if(!Page.IsPostBack)
			{
				//Set NAC visitor count
				NACVisitCount objNACVisitCount = new NACVisitCount();            
				objNACVisitCount.IpAddress = Request.UserHostAddress.ToString();
				objNACVisitCount.SessionId = Session.SessionID.ToString();
				 
				objNACVisitCount.SetNACVisitCount();
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
	}
}
