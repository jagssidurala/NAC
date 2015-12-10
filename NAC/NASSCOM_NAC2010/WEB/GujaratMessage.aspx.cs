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
	/// Summary description for GujaratMessage.
	/// </summary>
	public class GujaratMessage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblCandidateName;
		protected System.Web.UI.WebControls.Label lblPhotoIDDocument;
		protected System.Web.UI.WebControls.Label lblPhotoIDDocumentNumber;
		protected System.Web.UI.WebControls.Label lblPassword;
		public string RegistrationId;	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				try
				{
					// Put user code to initialize the page here
					lblCandidateName.Text = Session["UserName"].ToString();
					RegistrationId = Session["UserID"].ToString();
					
					DataTable dtUserDetail = new DataTable();
					dtUserDetail = GetUserDetailToSendAMail(RegistrationId);

					lblPhotoIDDocument.Text = Convert.ToString(dtUserDetail.Rows[0]["PhotoIdDocument"]);
					lblPhotoIDDocumentNumber.Text = Convert.ToString(dtUserDetail.Rows[0]["PhotoIdNo"]);
					lblPassword.Text = Convert.ToString(dtUserDetail.Rows[0]["Password"]);

					if(dtUserDetail != null && Session["MailSent"] == null)
					{
						if(dtUserDetail.Rows.Count > 0)
						{
							if(Convert.ToString(dtUserDetail.Rows[0]["EmailId"]) != null && Convert.ToString(dtUserDetail.Rows[0]["EmailId"]) != "")
							{
								SendMailWithPDF(Convert.ToString(dtUserDetail.Rows[0]["EmailId"]), Convert.ToString(dtUserDetail.Rows[0]["FullName"]), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdDocument"]), Convert.ToString(dtUserDetail.Rows[0]["PhotoIdNo"]), Convert.ToString(dtUserDetail.Rows[0]["Password"]));	
								Session["MailSent"] = true;
							}
									 								
						}
							   
					}
 							
					
				}
				catch (Exception Ex)
				{
					//Calling ErrorRoutine of ErrorLogger to write error text in text file.
					ErrorLogger.ErrorRoutine(false,Ex);
				}
			}
		}

		private DataTable GetUserDetailToSendAMail(string RegistrationId)
		{
			BusinessLayer.BLAdmitCard objBLAdmitCard = new BLAdmitCard();
			return ((DataTable) objBLAdmitCard.GetUserDetailToSendAMail(RegistrationId));
		}

		#region SendMailWithPDF()

		private void SendMailWithPDF(string strEmailId, string strCandidateName, string strPhotoIDDocument, string strPhotoIDDocumentNumber, string strPassword)
		{
			 
			string EmailBody = null;

			try
			{
				CLEmail objCLEmail = new CLEmail();
				//Start Email Body
				EmailBody = "<HTML><BODY>";
				EmailBody += "<table cellpadding=5 cellspacing=0 border=0 bgcolor=#ffffff width=100%>";
				EmailBody += "<tr valign=top>";
				EmailBody += "<td colspan=3 align=left><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Dear&nbsp;" + strCandidateName  + "</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Congratulations on your successful registration for NAC (NASSCOM Assessment of Competence).</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please find below your log-in details that you would require to view/print your profile on NAC website:</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td align=left width=20%><p><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document</span></strong></td>";
				EmailBody += "<td width=1%>:</td>";
				EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocument + "</span></strong></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Photo-ID Document No.</span></strong></td>";
				EmailBody += "<td width=1%>:";
				EmailBody += "</td>";
				EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>" + strPhotoIDDocumentNumber + "</span></strong></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td align=left width=20%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Password</span></strong></td>";
				EmailBody += "<td width=1%>:</td>";
				EmailBody += "<td align=left width=79%><strong><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>"+ strPassword +"</span></strong></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>These details will also be required by you later to access your NAC Admission Card / Score Card.</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Please note, your NAC Admission Card will be available on NAC website from <font color=#6633ff>12-Feb-08</font> onwards - do visit the website accordingly. </span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>DO NOT forget to carry it to the test center on the day of the test along with the photo-ID document.</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>We wish you all the best!</span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3></p><span style=FONT-SIZE:9.0pt;FONT-FAMILY:Arial>Regards<br>NAC Team<br><a href=www.nac.nasscom.in>www.nac.nasscom.in</a><br/></span></p></td>";
				EmailBody += "</tr>";
				EmailBody += "<tr>";
				EmailBody += "<td colspan=3><p><span style=FONT-SIZE:8.0pt;FONT-FAMILY:Arial; FONT-COLOR: #666699;>Disclaimer: This is a system-generated mail - please do not reply</span></p></td>";
				EmailBody += "</tr>";					
				EmailBody += "</table>";					 
				EmailBody += "</BODY></HTML>";
				//End Email Body					
				objCLEmail.SendMail(EmailBody,Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"]),"NAC Test",strEmailId,Convert.ToString(ConfigurationSettings.AppSettings["MailServer"]));
					 
			}
			catch(Exception ex)
			{
				Response.ClearContent();
				throw(ex);
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
