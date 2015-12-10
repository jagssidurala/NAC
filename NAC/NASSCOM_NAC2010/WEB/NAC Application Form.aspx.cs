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
	/// Summary description for NAC_Application_Form.
	/// </summary>
	public partial class NAC_Application_Form : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
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

		}
		#endregion
	 

		protected void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			Response.Clear();
			Response.ClearHeaders();
			Response.ContentType="application/pdf";		 
			string FilePath = MapPath("NAC_Application_Form.pdf");		 
			Response.AddHeader("content-disposition", "attachment; filename=" + "NAC_Application_Form" + ".pdf");				 
			Response.WriteFile(FilePath);
			Response.End(); 
		}

		protected void btnSaveTop_Click(object sender, System.EventArgs e)
		{
			Response.Clear();
			Response.ClearHeaders();
			Response.ContentType="application/pdf";		 
			string FilePath = MapPath("NAC_Application_Form.pdf");		 
			Response.AddHeader("content-disposition", "attachment; filename=" + "NAC_Application_Form" + ".pdf");				 
			Response.WriteFile(FilePath);
			Response.End(); 
		}
	}
}
