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
	/// Summary description for GenerateAdmitCard.
	/// </summary>
	public partial class GenerateAdmitCard : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Button1.Attributes.Add("onclick", "window.open('AdmitCard.aspx', null,'height=620,width=740,status= no, resizable= no, scrollbars=no,toolbar=no,location=no,menubar=no ');");
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("AdmitCard.aspx"); 
		}
	}
}
