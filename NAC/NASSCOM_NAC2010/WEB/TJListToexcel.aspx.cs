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

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for TJListtoexcel.
	/// </summary>
	public partial class TJListtoexcel : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
				 //Put user code to initialize the page here
		if(Request.QueryString["SearchType"] != null)
			{
				if(Request.QueryString["SearchType"] == "full")
				{
					BLImportExportXLS objBLImportExportXLS = new BLImportExportXLS();
					objBLImportExportXLS.CandidateRegistrationList = Convert.ToString(Session["ItemList"].ToString());
					dgTJVisitorList.DataSource = ((DataTable)(objBLImportExportXLS.ExportTJVisitorToExcel())).DefaultView;
					dgTJVisitorList.DataBind();
					  
				}
				else
				{
				   Response.Redirect("Login.aspx");
				}
			}
			else 
			{

//				if(Session["ItemList"] != null)
//				{
//					NACVisitCount objNACVisitCount = new NACVisitCount();
//					//objBLImportExportXLS.CandidateRegistrationList = Convert.ToString(Session["ItemList"].ToString());
//					dgCandidateList.DataSource = ((DataTable)(objBLImportExportXLS.ExportCandidateListByAdmin())).DefaultView;
//					dgCandidateList.DataBind();
//
//				}
//				else
//				{
//				   Response.Redirect("Login.aspx");
//				}
//			
//			
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
