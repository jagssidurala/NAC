
    ///<remarks>
	///===================================================================
	/// Name: File Name				: AdminCandidatesExportToExcel.aspx
	/// Construction Date			: 05/05/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for exporting candidate details to excel
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2011 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 

#region Namespaces

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
using BusinessLayer;

#endregion

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for AdminCandidatesExportToExcel.
	/// </summary>
	public partial class AdminCandidatesExportToExcel : System.Web.UI.Page
	{
		#region Class Variables
		#endregion
	
		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( Session["UserType"] == null)
			{
				Response.Redirect("login.aspx");
			}
			
			if(Request.QueryString["SearchType"] != null)
			{
				if(Request.QueryString["SearchType"] == "full")
				{
					BLCandidateSearchByAdmin objBLSearch = new BLCandidateSearchByAdmin();
					objBLSearch = (BLCandidateSearchByAdmin)Session["SearchObject"];
					DataTable dtResult = new DataTable();
					dtResult = objBLSearch.ExportAllCandidateListByAdmin();
					
					dgCandidateList.DataSource = dtResult;
					dgCandidateList.DataBind();

					Response.Clear(); 
					Response.Buffer = true; 
					Response.ContentType = "application/vnd.ms-excel";
					Response.AddHeader("content-disposition", "attachment;filename=CompanyExportToExcel.xls");
					System.IO.StringWriter stringWriter = new System.IO.StringWriter(); 
					System.Web.UI.HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
					this.RenderControl(htmlTextWriter);
					Response.Write(stringWriter.ToString());
					Response.Flush();

				}
				else
				{
					Response.Redirect("Login.aspx",false);
				}
			}
			else 
			{
				if(Session["ItemList"] != null)
				{
					BLImportExportXLS objBLImportExportXLS = new BLImportExportXLS();
					objBLImportExportXLS.CandidateRegistrationList = Convert.ToString(Session["ItemList"].ToString());
					dgCandidateList.DataSource = ((DataTable)(objBLImportExportXLS.ExportCandidateListByAdminV2())).DefaultView;
					dgCandidateList.DataBind();

					Response.Clear(); 
					Response.Buffer = true; 
					Response.ContentType = "application/vnd.ms-excel";
					Response.AddHeader("content-disposition", "attachment;filename=CompanyExportToExcel.xls");
					System.IO.StringWriter stringWriter = new System.IO.StringWriter(); 
					System.Web.UI.HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
					this.RenderControl(htmlTextWriter);
					Response.Write(stringWriter.ToString());
					Response.Flush();
				}
				else
				{
					Response.Redirect("Login.aspx",false);
				}
			}
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