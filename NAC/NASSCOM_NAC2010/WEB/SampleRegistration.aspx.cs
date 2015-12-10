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
using System.IO;
using System.Text;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for SampleRegistration.
	/// </summary>
	public partial class SampleRegistration : System.Web.UI.Page
	{
	
		#region WebControls

		#endregion	

		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{ 		
				
			
			if(Session["PIN"] == null || Session["StateId"] == null)
			{
				Response.Redirect("PinLogin.aspx");				 
			}

			

			if(!Page.IsPostBack)
			{
			}

			btnClose.Attributes.Add("onclick","javascript: window.self.close();");
		}


		#endregion

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
