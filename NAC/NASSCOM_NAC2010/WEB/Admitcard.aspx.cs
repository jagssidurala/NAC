///<remarks>
///===================================================================
/// Name: File Name				: AdmitCard.aspx
/// Construction Date			: 01/05/07
/// Author: Developer's Name	: Badal Kumar
/// Description					: This page is used for viewing and printing Admit Card 
/// Last Revision Date			: 08-October-2007
/// Last Revision By			: Badal Kumar
/// Last Revision Change		: 1. Adding email functionality at the time of successful registration.
///								  2. Save admit card as a PDF
/// ====================================================================
/// Copyright (C) 2007-2008 NASSCOM  All Rights Reserved.
/// ====================================================================
///</remarks> 

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using BusinessLayer;
using Common;

namespace NASSCOM_NAC.Web
{
    /// <summary>
    /// Summary description for Admitcard.
    /// </summary>
    public partial class Admitcard : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button btnPrint;
        private string RegistrationId;
        protected System.Web.UI.HtmlControls.HtmlImage imgWatermark;
        public string strDivStyle;


        protected void Page_Load(object sender, System.EventArgs e)
        {
            //			// Put user code to initialize the page here			 
            //			string strUserAgent = Request.UserAgent.ToString().ToLower();			 
            //
            //			if(strUserAgent.IndexOf("msie 6.0") != -1)
            //			{
            //				strDivStyle = "ImgPosition3";
            //
            //				imgWatermark.Src = "Images/NAC_Stamp_bg6.gif";
            //			}
            //			else
            //			{
            //				strDivStyle = "ImgPosition2";
            //				imgWatermark.Src = "Images/NAC_Stamp_bg.gif";
            //			}

            if (Session["UserID"] == null)
            {
                Response.Redirect("../Default.aspx");
            }


            if (!Page.IsPostBack)
            {
                try
                {
                    RegistrationId = Session["UserID"].ToString();

                    GetAdmitCardData();
                    try
                    {
                        if (Request.QueryString["Login"].Equals("false"))
                        {
                            DataTable dtUserDetail = new DataTable();
                            string strFileName = null;
                            strFileName = CreatePDF("AdmitCard_" + RegistrationId + ".pdf", RegistrationId);
                            dtUserDetail = GetUserDetailToSendAMail(RegistrationId);
                            if (dtUserDetail != null && Session["MailSent"] == null)
                            {
                                if (dtUserDetail.Rows.Count > 0)
                                {
                                    if (Convert.ToString(dtUserDetail.Rows[0]["EmailId"]) != null && Convert.ToString(dtUserDetail.Rows[0]["EmailId"]) != "")
                                    {
                                        //Sned mail for NAC Exam
                                        if (lblRegistrationID.Text.StartsWith("NC"))
                                        {
                                            SendMailWithPDF(strFileName, Convert.ToString(dtUserDetail.Rows[0]["EmailId"]), Convert.ToString(dtUserDetail.Rows[0]["FullName"]).ToUpper(), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdDocument"]), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdNo"]), Convert.ToString(dtUserDetail.Rows[0]["Password"]), lblRegistrationID.Text);
                                            Session["MailSent"] = true;
                                        }

                                        //Send mail for NAC Diagnostic Exam
                                        else if (lblRegistrationID.Text.StartsWith("NG"))
                                        {
                                            SendMailWithPDF_Diagnostic(strFileName, Convert.ToString(dtUserDetail.Rows[0]["EmailId"]), Convert.ToString(dtUserDetail.Rows[0]["FullName"]).ToUpper(), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdDocument"]), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdNo"]), Convert.ToString(dtUserDetail.Rows[0]["Password"]), lblRegistrationID.Text);
                                            Session["MailSent"] = true;
                                        }
                                    }

                                }

                            }

                        }
                    }
                    catch (Exception Ex)
                    {
                        //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                        ErrorLogger.ErrorRoutine(false, Ex);
                    }

                }
                catch (Exception Ex)
                {
                    //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                    ErrorLogger.ErrorRoutine(false, Ex);
                    //To Pass Execption in exception class for show exception
                    ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(Ex);
                }
            }
        }

        public string ChangeTimeFormat(string strTime)
        {
            if (strTime == "12:00 PM")
            {
                return "12:00 Noon";
            }
            else
            {
                return strTime;
            }
        }



        private DataTable GetUserDetailToSendAMail(string RegistrationId)
        {
            BusinessLayer.BLAdmitCard objBLAdmitCard = new BLAdmitCard();
            return ((DataTable)objBLAdmitCard.GetUserDetailToSendAMail(RegistrationId));
        }

        #region CreatePDF()

        private string CreatePDF(string strPDFName, string strUserId)
        {
            bool typeflag;
            BusinessLayer.BLGeneratePDF objGeneratePDF = new BLGeneratePDF();
            typeflag = objGeneratePDF.GeneratePDF(strUserId);
            return MapPath("") + "\\TempWorkAreaPdf\\" + strPDFName;
        }

        #endregion

        #region SendMailWithPDF()

        private void SendMailWithPDF(string strFileName, string strEmailId, string strCandidateName, string strPhotoIDDocument, string strPhotoIDDocumentNumber, string strPassword, string strRegistrationID)
        {
            bool bFileExist = false;
            string EmailBody = null;

            int intTimeout = 0;

            while (bFileExist == false)
            {
                if (File.Exists(strFileName))
                {
                    bFileExist = true;
                }
                else
                {
                    Thread.Sleep(1000);
                    intTimeout++;
                }
                if (intTimeout == 10)
                    break;
            }

            if (bFileExist == true)
            {
                try
                {
                    CLEmail objCLEmail = new CLEmail();
                    //Start Email Body


                    EmailBody = "<html><body>";
                    EmailBody += "<table cellpadding=5 cellspacing=0 border=0 bgcolor=#ffffff width=100%>";

                    EmailBody += "<tr valign=top>";
                    EmailBody += "<td colspan=3 align=left><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Dear&nbsp;" + strCandidateName.Trim() + "</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Congratulations on your successful registration for NAC (NASSCOM Assessment of Competence).</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please find below your log-in details that you would require to view/print your profile on NAC website:</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><p><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Registration ID</span></strong></p></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strRegistrationID.Trim() + "</span></strong></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><p><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document</span></strong></p></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocument.Trim() + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document No.</span></strong></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocumentNumber.Trim() + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Password</span></strong></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPassword.Trim() + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>These details will also be required by you later to access your NAC score card after the test.</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Also, do find attached your <b>NAC Admission Card</b> – DO NOT forget to carry it to the test center on the day of the test along with the photo-ID document.</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please take a note of your NAC Registration ID. You will need it for future references</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>We wish you all the best!</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Regards<br>NAC Team<br><a href=www.nac.nasscom.in>www.nac.nasscom.in</a></span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:8.0pt;FONT-FAMILY:Arial; FONT-COLOR: #666699;>Disclaimer: This is a system-generated mail - please do not reply</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "</table>";
                    EmailBody += "</body></html>";


                    //End Email Body					
                    objCLEmail.SendMailWithAttachment(EmailBody, Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"]), "NAC Test", strEmailId, Convert.ToString(ConfigurationSettings.AppSettings["MailServer"]), strFileName);
                    ClearTempFiles(strFileName);
                }
                catch (Exception ex)
                {
                    Response.ClearContent();
                    throw (ex);
                }



            }

        }


        #endregion

        #region SendMailWithPDF_Diagnostic()

        private void SendMailWithPDF_Diagnostic(string strFileName, string strEmailId, string strCandidateName, string strPhotoIDDocument, string strPhotoIDDocumentNumber, string strPassword, string strRegistrationID)
        {
            bool bFileExist = false;
            string EmailBody = null;

            int intTimeout = 0;

            while (bFileExist == false)
            {
                if (File.Exists(strFileName))
                {
                    bFileExist = true;
                }
                else
                {
                    Thread.Sleep(1000);
                    intTimeout++;
                }
                if (intTimeout == 10)
                    break;
            }

            if (bFileExist == true)
            {
                try
                {
                    CLEmail objCLEmail = new CLEmail();
                    //Start Email Body


                    EmailBody = "<HTML><BODY>";
                    EmailBody += "<table cellpadding=5 cellspacing=0 border=0 bgcolor=#ffffff width=100%>";

                    EmailBody += "<tr valign=top>";
                    EmailBody += "<td colspan=3 align=left><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Dear&nbsp;" + strCandidateName + "</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Congratulations on your successful registration for NAC (NASSCOM Assessment of Competence)-Diagnostic.</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please find below your log-in details that you would require to view/print your profile on NAC website:</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><p><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Registration ID</span></strong></p></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strRegistrationID.Trim() + "</span></strong></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><p><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document</span></strong></p></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocument + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document No.</span></strong></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocumentNumber + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Password</span></strong></td>";
                    EmailBody += "<td width=1%>:</td>";
                    EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPassword + "</span></strong></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>These details will also be required by you later to access your NAC Diagnostic score card after the test.</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Also, do find attached your <b>NAC Diagnostic Admission Card</b> – DO NOT forget to carry it to the test center on the day of the test along with the photo-ID document.</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please take a note of your NAC Registration ID. You will need it for future references</span></p></td>";
                    EmailBody += "</tr>";
                    //NAC Release 5.0
                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>We wish you all the best!</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Regards<br>NAC Team<br><a href=www.nac.nasscom.in>www.nac.nasscom.in</a></span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "<tr>";
                    EmailBody += "<td colspan=3><p><span style=FONT-SIZE:8.0pt;FONT-FAMILY:Arial; FONT-COLOR: #666699;>Disclaimer: This is a system-generated mail - please do not reply</span></p></td>";
                    EmailBody += "</tr>";

                    EmailBody += "</table>";
                    EmailBody += "</BODY></HTML>";


                    //End Email Body					
                    objCLEmail.SendMailWithAttachment(EmailBody, Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"]), "NAC Diagnostic Test", strEmailId, Convert.ToString(ConfigurationSettings.AppSettings["MailServer"]), strFileName);
                    ClearTempFiles(strFileName);
                }
                catch (Exception ex)
                {
                    Response.ClearContent();
                    throw (ex);
                }



            }

        }


        #endregion

        private void GetAdmitCardData()
        {
            try
            {
                //Creating instance of BLAdmitCard to display admit card information on page.
                BusinessLayer.BLAdmitCard oBLAdmitCard = new BLAdmitCard();
                //Initializing dataset with admitcard details.
                DataSet dsAdmitCard = oBLAdmitCard.GenerateAdmitCard(RegistrationId);
                //Displaying Registration id on lblRegistrationID Label.
                lblRegistrationID.Text = dsAdmitCard.Tables[0].Rows[0][0].ToString();

                //Displaying NAC/NAC-D Logo based on Registration ID
                if (dsAdmitCard.Tables[0].Rows[0][0].ToString().StartsWith("NC"))
                {
                    imgLogo.ImageUrl = "Images/nac_logo.PNG";
                    lblLogoHeader.Text = "NASSCOM Assessment of Competence";
                }
                else
                {
                    imgLogo.ImageUrl = "Images/nac-D_logo.PNG";
                    lblLogoHeader.Text = "NASSCOM Assessment of Competence- <br> Diagnostic";

                }

                //Displaying user nanme on lblName Label.
                lblName.Text = dsAdmitCard.Tables[0].Rows[0][1].ToString().ToUpper();
                //Converting variable with date in formated string.
                string strDOB = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][2].ToString()));
                //Displaying user date of birth on lblDOB Label.
                lblDOB.Text = strDOB;
                //Displaying gender information on lblGender Label.
                lblGender.Text = dsAdmitCard.Tables[0].Rows[0][3].ToString().Trim();
                //Checking that qualification details is Others or not.
                if (dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim() == "Others")
                {
                    //Displaying qualification details on lblQualification if Qualification Details is "Others"
                    lblQualification.Text = dsAdmitCard.Tables[0].Rows[0][11].ToString().Trim();
                }
                else
                {
                    //Displaying qualification details on lblQualification if Qualification Details is not "Others"
                    lblQualification.Text = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
                }

                //Displaying state of user on lblState Label.
                if (dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim() == "Hero Mindmine")
                {
                    lblState.Text = dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
                }

                else if (dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim() == "Sona College")
                {
                    lblState.Text = dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim() + ' ' + "of Technology";
                }
                else if (dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim() == "Vel-Tech Tech. Univ.")
                {
                    lblState.Text = dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
                }
                else if (dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim() == "Infotech Enterprises Ltd.")
                {
                    lblState.Text = dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
                }
                else
                {
                    lblState.Text = "State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
                }

                //Displaying city of user on lblCity Label.
                lblCity.Text = dsAdmitCard.Tables[0].Rows[0][5].ToString().Trim();
                //Displaying test center of user on lblTestLocation Label.
                lblTestLocation.Text = dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
                //Converting variable with date in formated string.
                string strTestDate = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][8].ToString())) + ' ' + ChangeTimeFormat(String.Format("{0:hh:mm tt}", Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][9].ToString())));
                //Checking that user has uploaded his/her photo or not.
                if (dsAdmitCard.Tables[0].Rows[0][10].ToString() == "")
                {
                    //Displaying default photo is image is not in database.
                    imgUploadPhotograph.ImageUrl = "images/" + "defaultphoto.jpg";
                }
                else
                {
                    //Displaying image of user if image name is existing in database.
                    imgUploadPhotograph.ImageUrl = "UploadedPhotograph/" + dsAdmitCard.Tables[0].Rows[0][10].ToString().Trim();
                }
                if (dsAdmitCard.Tables[0].Rows[0][13].ToString() == "")
                {
                    //Displaying default photo is image is not in database.
                    lblCentreAddress.Text = "";
                }
                else
                {
                    //Displaying image of user if image name is existing in database.
                    lblCentreAddress.Text = dsAdmitCard.Tables[0].Rows[0][13].ToString().Trim();
                }
                lblTestDate.Text = strTestDate;

            }
            catch (Exception SysEx)
            {
                //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                ErrorLogger.ErrorRoutine(false, SysEx);
                //To Pass Execption in exception class for show exception
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
            }
            finally
            {

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

        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            if (Request.QueryString["login"] == ("true"))
                Response.Redirect("Welcome.aspx");
            else
                Response.Redirect("../Default.aspx");

        }

        public void btnSave_Click(object sender, System.EventArgs e)
        {

            if (Session["UserID"] != null)
            {
                BusinessLayer.BLGeneratePDF objGeneratePDF = new BLGeneratePDF();
                bool typeflag;
                typeflag = objGeneratePDF.GeneratePDF(Convert.ToString(Session["UserID"]));
                SaveAsPDF();
            }

        }

        private void SaveAsPDF()
        {
            bool bFileExist = false;
            int intTimeout = 0;
            RegistrationId = Session["UserID"].ToString();
            string FileName = "AdmitCard_" + RegistrationId + ".pdf";
            string FilePath = MapPath("") + "\\TempWorkAreaPdf\\" + "AdmitCard_" + RegistrationId + ".pdf";


            while (bFileExist == false)
            {
                if (File.Exists(FilePath))
                {
                    bFileExist = true;
                }
                Thread.Sleep(1000);
                intTimeout++;
                if (intTimeout == 10)
                    break;
            }

            if (bFileExist == true)
            {
                try
                {
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment; filename=" + FileName);
                    Response.WriteFile(FilePath);
                    Response.Flush();
                    Response.Close();
                    ClearTempFiles(FilePath);
                }
                catch (Exception ex)
                {
                    Response.ClearContent();
                    throw (ex);
                }



            }

        }



        /// <summary>
        /// This method will be used to clear up all the temporary file created in the process.
        /// </summary>
        private void ClearTempFiles(string FilePath)
        {

            if (File.Exists(FilePath))
            {
                try
                {
                    File.Delete(FilePath);
                }
                catch (Exception ex)
                {
                    throw (ex);

                }

            }


        }



    }
}
