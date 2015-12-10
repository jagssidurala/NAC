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
using System.Text.RegularExpressions;
using BusinessLayer;
using Common;
using System.Text;
using System.Configuration;


namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for ForgotPassword.
	/// </summary>
	public partial class ForgotPassword : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
			lblErrorMsg.Visible = false;
			rbtnSendEmail.Checked=true;
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(ValidateData())
			{
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				DataSet dsLoginDetail = new DataSet();
				string userId = "";
				string password = "";
				string emailID = "";
				string spocName = "";
				string spocEmail = "";
				objBLCompanyLogin.CompanyName = txtCompanyName.Text.Trim();
				objBLCompanyLogin.CompanySPOCName = txtSPOCName.Text.Trim();
				objBLCompanyLogin.CompanySPOCEmail = txtCompanySPOCEmail.Text.Trim();
				dsLoginDetail = objBLCompanyLogin.GetCompanyLoginDetail();
				if(dsLoginDetail.Tables.Count > 0)
				{
					if(dsLoginDetail.Tables[0].Rows.Count > 0)
					{
						userId = dsLoginDetail.Tables[0].Rows[0]["loginid"].ToString();
						password = dsLoginDetail.Tables[0].Rows[0]["password"].ToString();
						password = objBLCompanyLogin.base64Decode(password);
						emailID = dsLoginDetail.Tables[0].Rows[0]["spocemail"].ToString();
						spocName = dsLoginDetail.Tables[0].Rows[0]["spocname"].ToString();
						spocEmail = dsLoginDetail.Tables[0].Rows[0]["spocemail"].ToString();
					}
					else
					{
						lblErrorMsg.Text = "Invalid details/please try again";
						lblErrorMsg.Visible = true;
						return;		
					}
				}
				else
				{
					lblErrorMsg.Text = "Some error occured, please try again later";
					lblErrorMsg.Visible = true;
					return;
				}
				if(rbtnDisplay.Checked == true)
				{
					this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Login ID:"+ userId +"\\r\\nPassword: " + password + "');</script>");
					txtCompanyName.Text = "";
					txtSPOCName.Text = "";
					txtCompanySPOCEmail.Text = "";
					rbtnDisplay.Checked = false;
					rbtnSendEmail.Checked = false;
				}
				else if(rbtnSendEmail.Checked == true)
				{
					SendMail(spocName,userId,password,spocEmail);
				}
				else
				{
					lblErrorMsg.Text = "Some error occured, please try again later";
					lblErrorMsg.Visible = true;
					txtCompanyName.Text = "";
					txtSPOCName.Text = "";
					txtCompanySPOCEmail.Text = "";
					rbtnDisplay.Checked = false;
					rbtnSendEmail.Checked = false;
					return;
				}
			}
			
		}

		private void SendMail(string spocName, string userID, string password, string spocEmail)
		{
			CLEmail objCLEmail = new CLEmail();
				
			StringBuilder EmailBody = new StringBuilder();
			EmailBody.Append("<HTML><BODY>");
			EmailBody.Append("<TABLE cellSpacing=0 width=100% bgcolor=#FFFFFF border=0>");
			EmailBody.Append("<TR>");
			EmailBody.Append("<TD colspan=2 align=left width=100% valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Hi " + spocName + "</span><br><br>");
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");
				
			EmailBody.Append("<TR>");
			EmailBody.Append("<TD colspan=2 align=left width=100% valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>As per your request, we are sending you your log-in details for accessing NAC Company Login application.</span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");

			EmailBody.Append("<TR>");
			EmailBody.Append("<TD align=left valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt; font-family:Arial;><b>Login ID: </b></span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("<TD align=left valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt; font-family:Arial;><b>" + userID + "</b></span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");
				
			EmailBody.Append("<TR>");
			EmailBody.Append("<TD align=left width=5% valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt; font-family:Arial;><b>Password: </b></span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("<TD align=left width=95% valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt; font-family:Arial;><b>" + password + "</b></span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");
			
			EmailBody.Append("<TR>");
			EmailBody.Append("<TD colspan=2 align=left width=100% valign=top>");
			EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Please <a href='http://www.nac.nasscom.in/nacdb/LoginPage.aspx'>click here</a> to log in to your account.</span><br><br>");						
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");

			EmailBody.Append("</table>");
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");
			EmailBody.Append("<TR>");
			EmailBody.Append("<TD colspan=2 align=left valign=top><br>");
			EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Regards</span><br>");
			EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>NAC Admin</span><br>");
			EmailBody.Append("</TD>");
			EmailBody.Append("</TR>");
			EmailBody.Append("</TABLE>");						 
			EmailBody.Append("</BODY></HTML>");
			
			objCLEmail.SendMail(Convert.ToString(EmailBody),"nacdb@mail.nasscom.in","NAC Login Details",spocEmail,Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
			this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('An email has been sent to your registered email-ID');</script>");
			txtCompanyName.Text = "";
			txtSPOCName.Text = "";
			txtCompanySPOCEmail.Text = "";
			rbtnDisplay.Checked = false;
			//rbtnSendEmail.Checked = false;
		}
		
		private bool ValidateData()
		{
			if(txtCompanyName.Text.Trim()=="")
			{
				lblErrorMsg.Text = "Please enter company name";
				lblErrorMsg.Visible = true;
				return false;
			}
			
			if(txtSPOCName.Text.Trim()=="")
			{
				lblErrorMsg.Text = "Please enter SPOC's name";
				lblErrorMsg.Visible = true;
				return false;
			}
			else if(!IsAlphabet(txtSPOCName.Text.Trim()))
			{
				lblErrorMsg.Text = "Please enter alphabets only";
				lblErrorMsg.Visible = true;
				return false;
			}

			if(txtCompanySPOCEmail.Text.Trim()=="")
			{
				lblErrorMsg.Text = "Please enter SPOC's email ID";
				lblErrorMsg.Visible = true;
				return false;
			}
			else if(!ValidEmail(txtCompanySPOCEmail.Text.Trim()))
			{
				lblErrorMsg.Text = "Please enter valid email ID";
				lblErrorMsg.Visible = true;
				return false;
			}

			if(rbtnDisplay.Checked == false && rbtnSendEmail.Checked == false)
			{
				lblErrorMsg.Text = "Please select 'Send login details to email' to get login details";
				lblErrorMsg.Visible = true;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool ValidEmail(string strInput)
		{
			if (!Regex.Match(strInput, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success)
			{		
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool IsAlphabet(string strInput)
		{
			string check="abcdefghijklmnopqrstuvwxyz ";
			strInput=strInput.ToLower();
			bool status=true;
			int count,counter;
			for (count=0; count<strInput.Length; count++)
			{
				for(counter=0; counter<check.Length; counter++)
				{
					if(strInput[count]==check[counter])
					{
						break;
					}
				}
				if(counter==check.Length)
				{
					status = false;
					break;
				}
			}
			return status;
		}

		protected void lnkHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../HomePage.aspx",true);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
            Response.Redirect("../HomePage.aspx", true);
		}

	}
}
