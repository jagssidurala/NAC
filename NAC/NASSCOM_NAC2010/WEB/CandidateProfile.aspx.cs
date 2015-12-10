///<remarks>
	///===================================================================
	/// Name: File Name				: CandidateProfile.aspx
	/// Construction Date			: 02/05/07
	/// Author: Developer's Name	: Amit Kumar
	/// Description					: This page is used for viewing Registration details
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2008 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 

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
using System.Threading;
using BusinessLayer;
using Common;

namespace NASSCOM_NAC
{
	/// <summary>
	/// Summary description for CandidateProfile.
	/// </summary>
	public partial class CandidateProfile : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblQualificationDetails;
		private string RegistrationId;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(Session["UserID"]==null)
			{
				Response.Redirect("../HomePage.aspx");
			}
			Response.ClearContent();
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Expires = -1;		
			
			btnPrint.Attributes.Add("OnClick","PrintReport();");
			//Common.CLCommonFunctions.CheckSession();

			if (!Page.IsPostBack)
			{
				RegistrationId = Session["UserID"].ToString();
				PreviewCandidateDetails();
			}

			if (Session["UserType"].ToString() == "1")
			{
				//				if(Convert.ToInt32(Session["StateId"]) == 9)
				//				{
				//					lblCentreText.Text = "Each city has only one center. Name of the center will be published on the Admission Card.";
				//					lblCentreText.ForeColor = System.Drawing.Color.Red;
				//					lblCentreText.Font.Size = 8;
				//					lblTestCentre.Visible = false;
				//					//lblTestCentre.Text = "KOHIMA";
				//				}
			
				//				if(Convert.ToInt32(Session["StateId"]) == 6)
				//				{
				//					lblCentreText.Text = "Test date and name of your allotted test center will be given on your Admission Card.";
				//					lblCentreText.ForeColor = System.Drawing.Color.Red;
				//					lblCentreText.Font.Size = 8;
				//					lblTestCentre.Visible = false;					 
				//				}
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

		private void PreviewCandidateDetails()
		{
			try
			{			
				BusinessLayer.BLRegistration oBLRegistration = new BusinessLayer.BLRegistration();
				DataSet dsRegistration = oBLRegistration.PreviewCandidateDetails(RegistrationId);
				lblFirstName.Text=dsRegistration.Tables[0].Rows[0][1].ToString().Trim();
				lblMiddleName.Text=dsRegistration.Tables[0].Rows[0][2].ToString().Trim();
				lblLastName.Text=dsRegistration.Tables[0].Rows[0][3].ToString().Trim();
				string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()));
				lblDOB.Text=strDOB;
				lblGender.Text=dsRegistration.Tables[0].Rows[0][5].ToString().Trim();
				lblResidentialAddress.Text=dsRegistration.Tables[0].Rows[0][6].ToString().Trim();
				lblCity.Text=dsRegistration.Tables[0].Rows[0][7].ToString().Trim();
				lblPin.Text=dsRegistration.Tables[0].Rows[0][8].ToString().Trim();
				lblPhoneNumber.Text=dsRegistration.Tables[0].Rows[0][9].ToString().Trim() + " - " + dsRegistration.Tables[0].Rows[0][10].ToString().Trim();
				lblCellPhone.Text=dsRegistration.Tables[0].Rows[0][11].ToString().Trim();
				
				string strCandidatePhoto = "";
				if (dsRegistration.Tables[0].Rows[0][12].ToString()=="")
					strCandidatePhoto ="images/DefaultPhoto.jpg";
				else
					strCandidatePhoto ="UploadedPhotograph/"+ dsRegistration.Tables[0].Rows[0][12].ToString().Trim();
				
				lblPhoto.Text ="<IMG height=\"100\" src=\""+strCandidatePhoto+"\" width=\"100\">"; 

				lblEmailId.Text=dsRegistration.Tables[0].Rows[0][13].ToString().Trim();
				lblMotherName.Text=dsRegistration.Tables[0].Rows[0][14].ToString().Trim();
				lblAnnualHouseholdIncome.Text=dsRegistration.Tables[0].Rows[0][15].ToString().Trim();
				lblHEQ.Text=dsRegistration.Tables[0].Rows[0][16].ToString().Trim();
				lblQualification.Text=dsRegistration.Tables[0].Rows[0][17].ToString().Trim();
				if (dsRegistration.Tables[0].Rows[0][36].ToString().Trim()!="")
				{
					lblQualification.Text = dsRegistration.Tables[0].Rows[0][36].ToString().Trim();
				}
				lblPercentageScored.Text=dsRegistration.Tables[0].Rows[0][18].ToString().Trim()+ " %";
				lblHEObtainedFrom.Text=dsRegistration.Tables[0].Rows[0][19].ToString().Trim();
				if (dsRegistration.Tables[0].Rows[0][16].ToString() == "UnderGraduate/Graduate")
				{
					lblCollege.Text = "College Name:";
					lblHighEduYear.Text="Year of Graduation";				
					trPGSpecialization.Visible=false;
				}
				else
				{
					lblCollege.Text = "Graduation done from (College name):";
					lblHighEduYear.Text="Year of Post Graduation";
					trPGSpecialization.Visible=true;
				}
				lblHEOFCity.Text=dsRegistration.Tables[0].Rows[0][20].ToString().Trim();
				lblEmploymentStatus.Text=dsRegistration.Tables[0].Rows[0][21].ToString().Trim();
				lblWTWOutOfHomeTown.Text=dsRegistration.Tables[0].Rows[0][22].ToString().Trim();
				lblTestCentre.Text=dsRegistration.Tables[0].Rows[0][30].ToString().Trim();
				lblTestCity.Text=dsRegistration.Tables[0].Rows[0][29].ToString().Trim();
				lblPhotoIDDocument.Text=dsRegistration.Tables[0].Rows[0][23].ToString().Trim();
				lblPhotoIdNo.Text=dsRegistration.Tables[0].Rows[0][24].ToString().Trim();
				lblMediumTenth.Text=dsRegistration.Tables[0].Rows[0][25].ToString().Trim();
				lblMediumTwelve.Text=dsRegistration.Tables[0].Rows[0][26].ToString().Trim();
				lblBelongTo.Text=dsRegistration.Tables[0].Rows[0][27].ToString().Trim();
				lblFatherName.Text=dsRegistration.Tables[0].Rows[0][31].ToString().Trim();
				lblCollegeAddress.Text = dsRegistration.Tables[0].Rows[0][34].ToString().Trim();
				lblPassword.Text = dsRegistration.Tables[0].Rows[0][35].ToString().Trim();
				//New fields added by deepak
				lblYearOfPassing12Th.Text=dsRegistration.Tables[0].Rows[0][37].ToString().Trim();
				if(dsRegistration.Tables[0].Rows[0][38].ToString().Trim()!="0")
				{
					lblGraduationYear.Text=dsRegistration.Tables[0].Rows[0][38].ToString().Trim();
				}
				else
				{
					lblGraduationYear.Text="";
				}
				
				lblPGSpecialization.Text=dsRegistration.Tables[0].Rows[0][39].ToString().Trim();
				lblCurrentLocation.Text=dsRegistration.Tables[0].Rows[0][40].ToString().Trim();				
				lblLanguageSkills.Text=dsRegistration.Tables[0].Rows[0][41].ToString().Trim();
				lblHavePassport.Text=dsRegistration.Tables[0].Rows[0][42].ToString().Trim();
				if(dsRegistration.Tables[0].Rows[0][42].ToString().Trim()=="Yes")
				{
					dvPassport.Attributes.Add("style","");					
					lblPassportNo.Text=dsRegistration.Tables[0].Rows[0][43].ToString().Trim();	
				}
				else
				{
					dvPassport.Attributes.Add("style","Display:none");					
					lblPassportNo.Text="";
				}
				
				
			}
			catch (Exception SysEx)
			{
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				ErrorLogger.ErrorRoutine(false,SysEx);
			}
		}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx"); 
        }
	}
}
