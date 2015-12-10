///<remarks>
	///===================================================================
	/// Name: File Name				: HiredCandidates.aspx
	/// Construction Date			: 28/03/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for viewing and exiting hired candidates by Company
	/// Last Revision Date			: 
	/// Last Revision By			: 
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2011-2012 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 
	///
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
using Common;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for HiredCandidates.
	/// </summary>
	public partial class HiredCandidates : System.Web.UI.Page
	{
	
		#region PageLoad 

		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblStatus.Text = "";
			btnExit.Attributes.Add("onclick","return ValidateDate();");
			if(Session["CompanyId"] == null || Session["CompanyName"] == null)
			{
				Session.Abandon();
				Response.Redirect("./LoginPage.aspx",false);
			}
			
			if(!IsPostBack)
			{
				BindDataGrid();
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

		#region btnBack_Click

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CompanyHomePage.aspx",false);
		}


		#endregion

		#region btnExit_Click 

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			
			int chkBoxCount = 0;		//to count number of registration ids selected.
			string registrationIDstring = null ;		//to store comma seperated string of selected registration ids.
			int output = 0;
			DataSet ds = new DataSet();
			foreach(DataGridItem dgItem in dgHiredCandidates.Items)
			{
				CheckBox chkboxExit = (CheckBox)dgItem.FindControl("chkExit");
				if(((CheckBox)dgItem.FindControl("chkExit")).Checked)
				{
					registrationIDstring = registrationIDstring + ((Label)dgItem.FindControl("lblRegistrationId")).Text.ToString().Trim() + "," ;
					chkBoxCount++;
				}
			}
			
			if (chkBoxCount > 0)
			{
				registrationIDstring = registrationIDstring.Remove(registrationIDstring.LastIndexOf(","),1);
				BLHireExitCandidate objBLHireExitCandidate = new BLHireExitCandidate();
				objBLHireExitCandidate.RegistrationIdList = registrationIDstring;
				objBLHireExitCandidate.CompanyId = Convert.ToString(Session["CompanyId"]);
				//ds = objBLHireExitCandidate.ExitMultipleCandidates();
				try
				{
					output = objBLHireExitCandidate.ExitCandidate();
					}
				catch(SqlException se)
				{
					Session["ErrorMessage"] = "Server reports an error";
					Response.Redirect("../Web/ErrorPage.aspx",false);
				}
				catch(Exception ex)
				{
					Session["ErrorMessage"] = "An error occured while trying to submit";
					Response.Redirect("../Web/ErrorPage.aspx",false);
				}

				if (output > 0)
				{
					BindDataGrid();
					string jScript;
					jScript = "<Script Language=Javascript>alert('Candidate(s) successfully marked as Exit')</Script>";
					Page.RegisterStartupScript("keyClientBlock", jScript);
				}
				else
				{
					lblStatus.Text="Some error errored while processing your request. Please contact server administrator";
					lblStatus.Visible = true;
				}
			}

			else
			{
				lblStatus.Text="No candidate selected.";
				lblStatus.Visible = true;
			}
		}
			

		#endregion

		#region BindDataGrid 

		private void BindDataGrid()
		{
			BLHireExitCandidate objBLHireExitCandidate = new BLHireExitCandidate();
			DataSet ds = new DataSet();
			objBLHireExitCandidate.CompanyId = Convert.ToString(Session["CompanyId"]);
			ds = objBLHireExitCandidate.GetHiredCandidateDetailsByCompany();
			if(ds.Tables.Count > 0)
			{
				if(ds.Tables[0].Rows.Count > 0)
				{
					dgHiredCandidates.DataSource = ds;
					dgHiredCandidates.DataBind();

					lblStatus.Visible = false;
					btnExit.Visible=true;
					chkDeclaration.Visible=true;
					chkDeclaration.Checked=false;
				}
				else
				{
					dgHiredCandidates.Visible = false;
					btnExit.Visible=false;
					lblStatus.Text="No candidates hired.";
					lblStatus.Visible = true;
					chkDeclaration.Visible = false;
					chkDeclaration.Checked = false;
				}
			}
		}


		#endregion

	}
}
