///<remarks>
	///===================================================================
	/// Name: File Name				: CompanyHire.aspx
	/// Construction Date			: 28/03/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for hiring candidates by Company
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
using BusinessLayer;
using Common;
using System.Configuration;
using ExceptionHandling;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for CompanyHire.
	/// </summary>
	public partial class CompanyHire : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblCompanyAddress;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblOfficialPhone;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblSPOCName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblSPOCPhone;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label lblSPOCEmail;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblExpiryDate;
		protected System.Web.UI.WebControls.Label lblLoginId;
		protected System.Web.UI.WebControls.Label lblLoginIdValue;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.Label lblPasswordValue;
		protected System.Web.UI.WebControls.Label lblNote;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.HtmlControls.HtmlTableRow trLogin;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPassword;
	
		#region PageLoad 
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblError.Text = "";
			
			if(Session["CompanyId"] == null || Session["CompanyName"] == null)
			{
				Response.Redirect("./LoginPage.aspx",false);
			}

			if(!Page.IsPostBack)
			{
				btnSearch.Attributes.Add("OnClick","return ValidateData();");
				btnHire.Attributes.Add("OnClick","return checkDeclaration();");
				btnExit.Attributes.Add("OnClick","return checkDeclaration();");
				pnlDetails.Visible=false;
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

		#region Search 
			
		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			if(txtRegistrationId.Text.Trim()!="")
			{
				BLHireExitCandidate objBLHireExitCandidate = new BLHireExitCandidate();
				DataSet dsCandidateDetails = new DataSet();
				
				objBLHireExitCandidate.RegistrationId = txtRegistrationId.Text.Trim();
				dsCandidateDetails = (DataSet) objBLHireExitCandidate.GetCandidateDetails();

				if(dsCandidateDetails.Tables[0].Rows.Count != 0)
				{
					// If candidate is not hired currently
					if(Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["HireStatus"]) == "0" || Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["HireStatus"]) == "")
						ShowHiringDetailsForCandidate(ref dsCandidateDetails);
					
						// If candidate is hired by currently logged-in company
					else if(Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["CompanyId"]) == Convert.ToString(Session["CompanyId"]))
						ShowExitDetailsForCandidate(ref dsCandidateDetails);
					
						// If candidate is currently hired by another company
					else   
					{
						ClearControls();
						pnlDetails.Visible = false;
						lblError.Text = "This candidate has already been hired by another organization.";
					}
				}

			
				else	// If registration id is incorrect
				{
					ClearControls();
					pnlDetails.Visible = false;
					lblError.Text = "Invalid Registration Id !";
				}

			}
		}
	
	#endregion

	#region ShowExitDetailsForCandidate
	
		private void ShowExitDetailsForCandidate(ref DataSet  dsCandidateDetails)
		{
			ClearControls();
			pnlDetails.Visible = true;
			lblRegistrationId.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["RegistrationId"]);
			lblName.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Name"]);
			lblDOB.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Date Of Birth"]);
			lblName.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Name"]);
			lblTestDate.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["TestDate"]);
			lblTestLocation.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["TestCity"]);
			chkDeclaration.Text = "We confirm that the above NAC candidate has taken <u>exit</u> from our organization.";
			btnExit.Visible = true;
		}

	#endregion

	#region ShowHiringDetailsForCandidate
		private void ShowHiringDetailsForCandidate(ref DataSet dsCandidateDetails)
		{
			ClearControls();
			pnlDetails.Visible = true;
			lblRegistrationId.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["RegistrationId"]);
			lblName.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Name"]);
			lblDOB.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Date Of Birth"]);
			lblName.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["Name"]);
			lblTestDate.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["TestDate"]);
			lblTestLocation.Text = Convert.ToString(dsCandidateDetails.Tables[0].Rows[0]["TestCity"]);
			chkDeclaration.Text = "We confirm that the above NAC candidate has been <u>hired</u> by our organization.";
			btnHire.Visible = true;
		}

		#endregion
		
	#region ClearControls 
		private void ClearControls()
		{
			lblRegistrationId.Text = "";
			lblName.Text = "";
			lblDOB.Text = "";
			lblName.Text = "";
			lblTestDate.Text = "";
			lblTestLocation.Text = "";
			chkDeclaration.Text = "";
			btnHire.Visible = false;
			btnExit.Visible = false;
			chkDeclaration.Checked=false;


		}
		#endregion

	#region Hire_Candidate 
		
		protected void btnHire_Click(object sender, System.EventArgs e)
		{
			BLHireExitCandidate objBLHireExitCandidate = new BLHireExitCandidate();
			objBLHireExitCandidate.RegistrationIdList = lblRegistrationId.Text;
			objBLHireExitCandidate.CompanyId = Convert.ToString(Session["CompanyId"]);
			int output = 0;
			try
			{
				output = objBLHireExitCandidate.HireCandidate();
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
			
			if(output == 1)
			{
				lblError.Text = "The candidate has been successfully marked as 'Hired'";
				btnHire.Visible = false;
			}
			else
			{
				lblError.Text = "Some error occured while processing your request. Please contact adminitrator.";
			}
		}
		
		#endregion

	#region Exit_Candidate
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			BLHireExitCandidate objBLHireExitCandidate = new BLHireExitCandidate();
			objBLHireExitCandidate.RegistrationIdList = lblRegistrationId.Text;
			objBLHireExitCandidate.CompanyId = Convert.ToString(Session["CompanyId"]);
			int output = 0;
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
			
			if(output == 1)
			{
				lblError.Text = "The candidate has been successfully marked as 'Exit'";
				btnExit.Visible = false;
			}
			else
			{
				lblError.Text = "Some error occured while processing your request. Please contact adminitrator.";
			}
		}

		#endregion
	}
}

			