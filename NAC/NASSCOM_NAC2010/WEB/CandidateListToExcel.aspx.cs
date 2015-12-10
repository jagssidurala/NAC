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
	/// Summary description for CandidateListToExcel.
	/// </summary>
	public partial class CandidateListToExcel : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
           // Response.Clear();

			if(Request.QueryString["SearchType"] != null)
			{
				if(Request.QueryString["SearchType"] == "full")
				{
					BLSearch objBLSearch = new BLSearch();
					objBLSearch = (BLSearch)Session["SearchObject"];
					dgCandidateList.DataSource = objBLSearch.ExportAllCandidateListByAdmin();
					dgCandidateList.DataBind();
					  
				}
				else
				{
				   Response.Redirect("Login.aspx");
				}
			}
			else 
			{

				if(Session["ItemList"] != null)
				{
					BLImportExportXLS objBLImportExportXLS = new BLImportExportXLS();
					objBLImportExportXLS.CandidateRegistrationList = Convert.ToString(Session["ItemList"].ToString());
				
					dgCandidateList.DataSource = ((DataTable)(objBLImportExportXLS.ExportCandidateListByAdmin())).DefaultView;
					dgCandidateList.DataBind();

				}
				else
				{
				   Response.Redirect("Login.aspx");
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
	}
}
