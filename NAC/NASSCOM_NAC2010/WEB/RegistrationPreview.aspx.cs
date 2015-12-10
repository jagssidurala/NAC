///<remarks>
	///===================================================================
	/// Name: File Name				: RegistrationPReview.aspx
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
	/// Summary description for RegistrationPreview.
	/// </summary>
	public partial class RegistrationPreview : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblQualificationDetails;
		protected System.Web.UI.WebControls.Label lblPGYear;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvGraduationYear;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvPGYear;
		private string RegistrationId;
		protected void Page_Load(object sender, System.EventArgs e)
		{
//			Response.ClearContent();
//			Response.Cache.SetCacheability(HttpCacheability.NoCache);
//			Response.Expires = -1;
			
			btnSubmit.Attributes.Add("OnClick","javascript: if(!window.confirm('Are you sure you want to save the details?')){return false;};");
			btnPrint.Attributes.Add("OnClick","PrintReport();");

			//Common.CLCommonFunctions.CheckSession();
			//This code only for Nagaland.
//			if(Convert.ToInt32(Session["StateId"]) == 9)
//			{
//			   lblCentreText.Text = "Each city has only one center. Name of the center will be published on the Admission Card.";
//			   lblCentreText.ForeColor = System.Drawing.Color.Red;
//			   lblCentreText.Font.Size = 8;
//			   lblTestCentre.Visible = false;			 
//			}

			//This code only for Rajasthan.
			if(Convert.ToInt32(Session["StateId"]) == 100 )//|| Convert.ToInt32(Session["StateId"]) == 6)
			{
				lblCentreText.Text = "Test date and name of your allotted test center will be given on your Admission Card.";
				lblCentreText.ForeColor = System.Drawing.Color.Red;
				lblCentreText.Font.Size = 8;
				lblTestCentre.Visible = false;				 
			}	
				
			if (!Page.IsPostBack)
			{
				RegistrationId = Session["UserID"].ToString();
				lblExistMessage.Visible = false;			
				dvPGSpecialization.Visible=false;
				if (Request.QueryString["login"]==("true"))  
				{
					btnEdit.Visible=false;
					btnSubmit.Visible = false;
					btnPrint.Visible = true;
					lblMessage.Visible=false;
				}
				else
				{
					btnEdit.Visible = true;
					btnSubmit.Visible = true;
					btnPrint.Visible = false;
					lblMessage.Visible=true;
				}
				lblPhoto.Text = "";
				if(Session["objBLRegistration"] != null)
				{
					
					PreviewCandidateDetails();
				}
				else
				{
				   Response.Redirect("PinLogin.aspx");
				}
				
			}

			// Form the script that is to be registered at client side.
            /*
            String scriptString = "<script language=JavaScript> function ReloadPage() {";
            scriptString += "window.location.href=window.location.href";
            scriptString += "}";
            scriptString += "</script>";

            if(!this.IsClientScriptBlockRegistered("ReloadScript"))
                this.RegisterClientScriptBlock("ReloadScript", scriptString);
            */

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

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EditRegistration.aspx?RegistrationId="+RegistrationId);
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(Session["objBLRegistration"] != null && Session["UserID"] != null)
			{
				String strSerialNo = Convert.ToString(Session["SerialNo"]);
				String strPinNo = Convert.ToString(Session["PIN"]);	
				string centreName="", strStatus="";
				///
				BLRegistration objBLRegistration = new BLRegistration();
				DataSet dsCentreStatus= objBLRegistration.IsTestActive(strSerialNo,strPinNo);
									
				strStatus= dsCentreStatus.Tables[0].Rows[0][0].ToString();
				centreName=dsCentreStatus.Tables[0].Rows[0][1].ToString();
				
				if(Convert.ToInt32(dsCentreStatus.Tables[1].Rows[0][0].ToString()) <= 0)
				{
					String strScript = "<script language='JavaScript'>alert('The center, you are trying to register for, is full.\\nPlease contact your College TPO to get ID for other center.')</script>";
					Page.RegisterStartupScript("myAlertScript", strScript);	
				}
								
				else
				{
					int intCheck = 0;
					string strRegistrationId = null;

					strRegistrationId = Session["UserID"].ToString().Trim();

					objBLRegistration = new BLRegistration();
					//				objBLRegistration = (BLRegistration) Session["objBLRegistration"];
					//				objBLRegistration.UpdateCandidateDetail(strRegistrationId);
					objBLRegistration = (BLRegistration) Session["objBLRegistration"];
					objBLRegistration.PinNo = strRegistrationId;
					intCheck = objBLRegistration.SetCandidateDetail();

					if(intCheck == 1)
					{
						if(Convert.ToInt32(Session["StateId"]) == 100)
						{
							Response.Redirect("GujaratMessage.aspx");
						}
							//					else 
							//					if(Convert.ToInt32(Session["StateId"]) == 6)
							//					{
							//						Response.Redirect("RajasthanMessage.aspx");
							//					}
						else
						{
							Session["MailSent"] = null;
							Response.Redirect("AdmitCard.aspx?Login=false");
						}
					
					}
					else
					{
						lblExistMessage.Visible = true;
						lblExistMessage.Text = "This pin number already in use.";
					}			 
				
				}
			}			
		}
		
		private void PreviewCandidateDetails()
		{
			try
			{			
				BusinessLayer.BLRegistration oBLRegistration = new BusinessLayer.BLRegistration();
				oBLRegistration = (BLRegistration) Session["objBLRegistration"];

				//Change Added by Badal - 07-June-2007 at 4:40PM
				//DataSet dsRegistration = oBLRegistration.PreviewCandidateDetails(RegistrationId);
				lblFirstName.Text= oBLRegistration.FirstName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][1].ToString().Trim();
				lblMiddleName.Text=oBLRegistration.MiddleName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][2].ToString().Trim();
				lblLastName.Text=oBLRegistration.LastName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][3].ToString().Trim();
				string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(oBLRegistration.DOB)); //dsRegistration.Tables[0].Rows[0][4].ToString().Trim()
				lblDOB.Text=strDOB;
				lblGender.Text=oBLRegistration.GenderName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][5].ToString().Trim();
				lblResidentialAddress.Text=oBLRegistration.ResidentialAddress.ToString().Trim();//dsRegistration.Tables[0].Rows[0][6].ToString().Trim();
				lblCity.Text=oBLRegistration.City.ToString().Trim();//dsRegistration.Tables[0].Rows[0][7].ToString().Trim();
				lblPin.Text=oBLRegistration.PinCode.ToString().Trim();//dsRegistration.Tables[0].Rows[0][8].ToString().Trim();
				lblPhoneNumber.Text=oBLRegistration.LandLine.ToString().Trim();//dsRegistration.Tables[0].Rows[0][9].ToString().Trim() + " - " + dsRegistration.Tables[0].Rows[0][10].ToString().Trim();
				lblCellPhone.Text=oBLRegistration.CellPhone.ToString().Trim();//dsRegistration.Tables[0].Rows[0][11].ToString().Trim();
				
				string strCandidatePhoto = "";
				if (oBLRegistration.UploadPhotograph.ToString().Trim() == "")//dsRegistration.Tables[0].Rows[0][12].ToString()==""
					strCandidatePhoto ="images/DefaultPhoto.jpg";
				else
					
					strCandidatePhoto ="UploadedPhotograph/"+ oBLRegistration.UploadPhotograph.ToString().Trim();//dsRegistration.Tables[0].Rows[0][12].ToString().Trim();
				
				lblPhoto.Text ="<IMG height=\"100\" src=\""+strCandidatePhoto+"\" width=\"100\">"; 

				lblEmailId.Text=oBLRegistration.EmailId.ToString().Trim();//dsRegistration.Tables[0].Rows[0][13].ToString().Trim();
				lblMotherName.Text=oBLRegistration.MothersFullname.ToString().Trim();//dsRegistration.Tables[0].Rows[0][14].ToString().Trim();
				lblAnnualHouseholdIncome.Text=oBLRegistration.AHHIName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][15].ToString().Trim();
				lblHEQ.Text=oBLRegistration.HEQName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][16].ToString().Trim();
				lblQualification.Text=oBLRegistration.QualificationDetailName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][17].ToString().Trim();
				if (oBLRegistration.OtherQualification.ToString().Trim() != "")//dsRegistration.Tables[0].Rows[0][36].ToString().Trim()!=""
				{
					lblQualification.Text = oBLRegistration.OtherQualification.ToString().Trim();//dsRegistration.Tables[0].Rows[0][36].ToString().Trim();
				}
				lblPercentageScored.Text=oBLRegistration.AggregatePercentageScored.ToString().Trim();//dsRegistration.Tables[0].Rows[0][18].ToString().Trim()+ " %";
				lblHEObtainedFrom.Text=oBLRegistration.University.ToString().Trim();//dsRegistration.Tables[0].Rows[0][19].ToString().Trim();
				if(oBLRegistration.YearOfGraduation.ToString().Trim()!="0")
				{
					lblGraduationYear.Text=oBLRegistration.YearOfGraduation.ToString().Trim();
				}
				else
				{
					lblGraduationYear.Text="";
				}
				//New Fields added by deepak
				if (oBLRegistration.HEQName.ToString().Trim() == "UnderGraduate/Graduate")//dsRegistration.Tables[0].Rows[0][16].ToString()
				{
					lblCollege.Text = "College Name:";
					lblHighEduYear.Text="Year of Graduation:";
				}
				else
				{
					lblCollege.Text = "Graduation done from (College name):";
					lblHighEduYear.Text="Year of Post Graduation:";
					if(oBLRegistration.PGSpecialization.ToString().Trim() != "")
					{
						dvPGSpecialization.Visible=true;					
						lblPGSpecialization.Text= oBLRegistration.PGSpecialization.ToString().Trim();
					}	
				}

                lblYearOfPassing12Th.Text = oBLRegistration.YearOfPassing12Th.ToString().Trim();
				lblCurrentLocation.Text = oBLRegistration.CurrentLocation.ToString().Trim();
				lblLanguageSkills.Text= oBLRegistration.LanguageSkills.ToString().Trim();

				lblHavePassport.Text= oBLRegistration.HavePassportName.ToString().Trim();
				if(oBLRegistration.HavePassportName.ToString().Trim()=="Yes")
				{
					dvPassport.Attributes.Add("style","");	
					lblPassportNo.Text= oBLRegistration.PassportNo.ToString().Trim();							
					
				}
				else
				{
					dvPassport.Attributes.Add("style","Display:none");					
					lblPassportNo.Text="";
				}
				//New Fields added by deepak End

				lblHEOFCity.Text=oBLRegistration.EducationCity.ToString().Trim();//dsRegistration.Tables[0].Rows[0][20].ToString().Trim();
				lblEmploymentStatus.Text=oBLRegistration.EmploymentStatusName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][21].ToString().Trim();
				lblWTWOutOfHomeTown.Text=oBLRegistration.WillingToWOUHTName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][22].ToString().Trim();
				lblTestCentre.Text=oBLRegistration.TestCentreName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][30].ToString().Trim();
				lblTestCity.Text=oBLRegistration.TestCity.ToString().Trim();//dsRegistration.Tables[0].Rows[0][29].ToString().Trim();
				lblPhotoIDDocument.Text=oBLRegistration.PhotoIdDocumentName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][23].ToString().Trim();
				lblPhotoIdNo.Text=oBLRegistration.PhotoIdNumber.ToString().Trim();//dsRegistration.Tables[0].Rows[0][24].ToString().Trim();
				lblMediumTenth.Text=oBLRegistration.MediumOfInstructionUpTo10Th.ToString().Trim();//dsRegistration.Tables[0].Rows[0][25].ToString().Trim();				
				lblMediumTwelve.Text=oBLRegistration.MediumOfInstructionUpTo12Th.ToString().Trim();//dsRegistration.Tables[0].Rows[0][26].ToString().Trim();
				lblBelongTo.Text=oBLRegistration.YBTName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][27].ToString().Trim();
				lblFatherName.Text=oBLRegistration.FathersFullname.ToString().Trim();//dsRegistration.Tables[0].Rows[0][31].ToString().Trim();
				lblCollegeAddress.Text =oBLRegistration.CollegeAddress.ToString().Trim();// dsRegistration.Tables[0].Rows[0][34].ToString().Trim();
				lblPassword.Text = oBLRegistration.Password.ToString().Trim();//dsRegistration.Tables[0].Rows[0][35].ToString().Trim();
			}
			catch (Exception SysEx)
			{
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				ErrorLogger.ErrorRoutine(false,SysEx);
			}
		}
	}
}
