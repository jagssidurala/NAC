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
using System.Configuration;
using DataAccessLayer;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Validate.
	/// </summary>
	public partial class Validate : System.Web.UI.Page
	{
		string strRegistrationID;
		private string SMTPServerIP;
		private string To;
		protected System.Web.UI.WebControls.TextBox txtEmailID;
		protected System.Web.UI.WebControls.TextBox txtSecondEmailID;
	 

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateData()");
			//Checking that request is coming from ForgotPassword or not and this is having valid session or not.
			if (Session["TempUser"].ToString()=="" || Session["TempUser"].ToString() == null || Session["TempUser"].ToString() == "0")
			{
				//Redirecting to ForgotPassword.aspx.
				Response.Redirect("ForgotPassword.aspx");
			}
			else
			{
				if (Request.QueryString.Count.ToString() == "0")
				{
					//Redirecting to ForgotPassword.aspx.
					Response.Redirect("ForgotPassword.aspx");
				}
				else
				{
					//Initializing strRegistration with QueryString data.
					strRegistrationID = Request.QueryString["ResistrationID"].ToString();
					//Displaying Registration/UserID in lblUserID Label.
					lblUserID.Text = strRegistrationID.ToString();
					if(!Page.IsPostBack)
					{
					 
						//Populating ddlPhotoIdDocument combo box.
						FillPhotoIdDetail();
					}
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
		
		#region BindDropDown()
		//Binding Combobox with database field
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{

			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

		}

		#endregion
		
		#region FillPhotoIdDetail()
		//Populating Photo ID Combobox
		private void FillPhotoIdDetail()
		{
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(),"PhotoIdDocument","PhotoId");
		}

		#endregion

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Creating instrance of BLLogin to fetch password.
				BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
				//Creating instance of CLEmail to send password information to user.
				Common.CLEmail oMail = new Common.CLEmail();
				string EmailBody;		//Variable to generate Email body for sending Password details
				int valPhotoID;			//Variable to keep PhotoID information.
				string strPhotoNumber;	//variable to keep Photo Document Number.
				string strFrom = Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"].ToString());
				string strSubjectHeader = Convert.ToString(ConfigurationSettings.AppSettings["SubjectHeader"].ToString());
				valPhotoID = Convert.ToInt32(ddlPhotoIdDocument.SelectedValue.ToString());
				strPhotoNumber = txtPhotoNumber.Text.Trim();
				//Creating dataset to keep password information
				DataSet ds = chkUser.ValidateUserForPassword(strRegistrationID.Trim(),valPhotoID,strPhotoNumber.Trim());
			 
				if (ds.Tables[0].Rows.Count > 0)
				{
				 
				
					if (optSent.Checked==true)
					{
						if(Convert.ToString(ds.Tables[0].Rows[0]["EmailId"])=="")
						{
							Response.Write("<script>alert('You do not have an Email ID registered with NASSCOM')</script>");
							return;
						}
						string strPassword= ds.Tables[0].Rows[0]["Password"].ToString().Trim();
						string strDocumentNo=ds.Tables[0].Rows[0]["DocumentNo"].ToString().Trim();
						string Name = ds.Tables[0].Rows[0]["FName"].ToString().Trim();
						if (!ds.Tables[0].Rows[0]["MName"].ToString().Equals(""))
							Name += " "+ ds.Tables[0].Rows[0]["MName"].ToString().Trim();
						if (!ds.Tables[0].Rows[0]["LName"].ToString().Equals(""))
							Name += " "+ ds.Tables[0].Rows[0]["LName"].ToString().Trim();
						string strDocumentType=ds.Tables[0].Rows[0]["PhotoIdDocument"].ToString().Trim();
						//EmailBody = "<html><head><title>Password</title></head><body>";
						EmailBody = "<HTML><BODY>";
						/*EmailBody += "<table  width=100% border=0 cellpadding=0 cellspacing=0 >";
						EmailBody += "<tr><td colspan=2><FONT SIZE=2 face=verdana>Dear  " +  Name +"</td></tr>";
						EmailBody += "<tr><td colspan=2>&nbsp;</td></tr>";
						EmailBody += "<tr><td colspan=2><FONT SIZE=2 face=verdana>As per your request, we are sending you your log-in details for accessing NAC application.</FONT></td></tr>";
						EmailBody += "<tr><td colspan=2>&nbsp;</td></tr>";
						EmailBody += "<tr><td colspan=2><FONT SIZE=2 face=verdana>Please find below the same:</FONT></td></tr>";
						EmailBody += "<tr><td colspan=2>&nbsp;</td></tr>";
						EmailBody += "<tr><td colspan=2>&nbsp;</td></tr>";
						EmailBody += "<tr><td width=\"30%\" align=\"left\"><strong>Photo-Id document:</strong></td><td align=\"left\" width=\"70%\">"+ strDocumentType+"</td></tr>";
						EmailBody += "<tr><td width=\"30%\" align=\"left\"><strong>Document No:</strong></td><td align=\"left\" width=\"70%\">"+ strDocumentNo+"<strong>(Case sensitive)</strong></td></tr>";
						EmailBody += "<tr><td width=\"30%\" align=\"left\"><strong>Password Details:</strong></td><td align=\"left\" width=\"70%\">"+ strPassword+"<strong>(Case sensitive)</strong></td></tr>";
						EmailBody += "</table>";
						EmailBody += "<BR><BR><FONT SIZE=2 face=verdana>Regards,</FONT><BR>";
						EmailBody += "<FONT SIZE=2 face=verdana>NAC Team</FONT><BR>";
						
						EmailBody += "<FONT SIZE=2 face=verdana>www.nac.nasscom.in</FONT><BR><BR><BR>";
						EmailBody += "<FONT SIZE=2 color=#ff3300 face=verdana >This is a system-generated mail – please do not reply.</FONT>";
						*/

						EmailBody = "<TABLE cellSpacing=0 cellPadding=3 width=100% bgcolor=#FFFFFF border=0>";
						EmailBody += "<TR>";
						EmailBody += "<TD align=left width=100% valign=top colspan=3>";
						EmailBody += "<span style=font-size:9.0pt;font-family:Arial>Dear&nbsp;" + Name + "</span><br/><br/>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "<TR>";
						EmailBody += "<TD align=left width=100% valign=top colspan=3>";
						EmailBody += "<span style=font-size:9.0pt;font-family:Arial>As per your request, we are sending you your log-in details for accessing NAC application.</span><br/><br/>";						
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "<TR valign=top>";
						EmailBody += "<TD align=left width=100% valign=top colspan=3>";
						EmailBody += "<table cellpadding=0 width=100% cellspacing=0 border=0>";
						EmailBody += "<TR valign=top>";
						EmailBody += "<TD align=left width=18% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>Photo-ID&nbsp;Document</span></strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=1% valign=top colspan=3>";
						EmailBody += "<strong>&nbsp;:&nbsp;</strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=91% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>" + strDocumentType + "</span></strong>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "<TR valign=top>";
						EmailBody += "<TD align=left width=18% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>Document&nbsp;No.</span></strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=1% valign=top colspan=3>";
						EmailBody += "<strong>&nbsp;:&nbsp;</strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=91% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>" + strDocumentNo + "</strong>&nbsp;</span>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "<TR valign=top>";
						EmailBody += "<TD align=left width=18% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>Password</span></strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=1% valign=top colspan=3>";
						EmailBody += "<strong>&nbsp;:&nbsp;</strong>";
						EmailBody += "</TD>";
						EmailBody += "<TD align=left width=91% valign=bottom colspan=3>";
						EmailBody += "<strong><span style=font-size:9.0pt;font-family:Arial>" + strPassword + "</strong>&nbsp;(Case sensitive)</span>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "</table>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "<TR>";
						EmailBody += "<TD align=left valign=top colspan=3><br/>";
						EmailBody += "<span style=font-size:9.0pt;font-family:Arial>Regards</span><br/>";
						EmailBody += "<span style=font-size:9.0pt;font-family:Arial>NAC Team</span><br/>";
						EmailBody += "<span style=font-size:9.0pt;font-family:Arial><a href=http://www.nac.nasscom.in>www.nac.nasscom.in</a></span><br/><br/>";
						EmailBody += "<span style=font-size:8.0pt;font-family:Arial;color:#666699>Disclaimer: This is a system-generated mail - please do not reply</span>";
						EmailBody += "</TD>";
						EmailBody += "</TR>";
						EmailBody += "</TABLE>";						 
						EmailBody += "</BODY></HTML>";
						SMTPServerIP = Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString());
						To = ds.Tables[0].Rows[0]["EmailId"].ToString();						 
						if(hdMailSend.Value == "0")
						{
							oMail.SendMail(EmailBody,strFrom,strSubjectHeader,To,SMTPServerIP);
							hdMailSend.Value = "1";
							lblPassword.Text = "Your password has been sent to your e-mail ID";
						}
						else
						{
							lblPassword.Text = "Your password has been sent to your e-mail ID";
						}
						
					}
					else
					{
						//Displaying password information on lblPassword label.
						lblPassword.Text = "Your password is: " + ds.Tables[0].Rows[0]["Password"].ToString();
					}
				}
				else
				{
					//Display "Please enter valid data" if system is not having data regarding user input.
					lblPassword.Text = "Please enter valid data";
				}
			}
			catch(Exception SysEx)
			{
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
		}
	}
}