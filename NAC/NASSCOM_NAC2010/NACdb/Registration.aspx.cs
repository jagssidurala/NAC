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
	/// Summary description for Registration.
	/// </summary>
	public partial class Registration : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lblError.Visible = false;
			if(!IsPostBack)
			{
				btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
				txtCompanyAddress.Attributes.Add("onkeydown","return imposeMaxLength(this,99,event);");
				txtCompanyName.Attributes.Add("onblur","checkBlankValue(this);");
				txtCompanyAddress.Attributes.Add("onblur","checkBlankValue(this);");
				txtSPOCName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);checkBlankValue(this);");
				txtSPOCName.Attributes.Add("onkeydown","return isAlpha(event.keyCode)");
				txtSPOCEmail.Attributes.Add("onblur","ValidateEmailAddress(this);");
				txtOfficialPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);");
				txtOfficialPhone.Attributes.Add("onkeypress","return isNumberKey(event)");
				txtSPOCPhone.Attributes.Add("onkeypress","return isNumberKey(event)");
				txtSPOCPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);");
				//txtSPOCPhone.Attributes.Add("onblur","validateSPOCNumberOnBlur();");
				
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(ValidateData())
			{
				DataSet dsStatus = new DataSet();
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				objBLCompanyLogin.CompanyName = txtCompanyName.Text.Trim();
				objBLCompanyLogin.CompanyAddress = txtCompanyAddress.Text.Trim();
				objBLCompanyLogin.CompanyAddress = objBLCompanyLogin.CompanyAddress.Replace("\r\n","\\r\\n");
				objBLCompanyLogin.CompanySPOCName = txtSPOCName .Text.Trim();
				objBLCompanyLogin.CompanySPOCPhone =  txtSPOCPhone.Text.Trim();
				objBLCompanyLogin.CompanySPOCEmail = txtSPOCEmail.Text.Trim();
				objBLCompanyLogin.OfficialPhone = txtOfficialPhone.Text.Trim();
				try
				{
					dsStatus = objBLCompanyLogin.AddMember();
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
				if(dsStatus.Tables.Count>0)
				{
					if(dsStatus.Tables[0].Rows.Count>0)
					{
						if(dsStatus.Tables[0].Rows[0][0].ToString() == "1")
						{
							lblError.Visible = true;
							lblError.Text = "A company with the name or email id you specified, already exists";
						}
						else if(dsStatus.Tables[0].Rows[0][0].ToString() == "0")
						{
							objBLCompanyLogin.CompanyAddress = objBLCompanyLogin.CompanyAddress.Replace("\\r\\n"," ");
							CLEmail objCLEmail = new CLEmail();
							StringBuilder EmailBody=new StringBuilder();
							EmailBody.Append("<HTML><BODY>");
							EmailBody.Append("<TABLE cellSpacing=0 cellPadding=3 width=100% bgcolor=#FFFFFF border=0>");
							EmailBody.Append("<TR>");
							EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
							EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Hello</span><br><br>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");
				
							EmailBody.Append("<TR>");
							EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
							EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>You have received one new request for company access to the NAC database.</span><br><br>");						
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR>");
							EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
							EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial><u>Details</u>:</span><br><br>");						
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
							EmailBody.Append("<table cellpadding=0 width=100% cellspacing=0 border=0>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Company Name:</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.CompanyName + "</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");
				
							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Company Address:</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.CompanyAddress + "</strong></span>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Official phone no.(landline):</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.OfficialPhone + "</strong></span>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Company SPOC for NAC:</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.CompanySPOCName + "</strong></span>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Company SPOC's phone number:</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.CompanySPOCPhone + "</strong></span>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("<TR valign=top>");
							EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Company SPOC's e-mail ID:</span></strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
							EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
							EmailBody.Append("</TD>");
							EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
							EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + objBLCompanyLogin.CompanySPOCEmail + "</strong></span>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");

							EmailBody.Append("</table>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");
							EmailBody.Append("<TR>");
							EmailBody.Append("<TD align=left valign=top colspan=3><br>");
							EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Regards</span><br>");
							EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>NAC Admin</span><br>");
							EmailBody.Append("</TD>");
							EmailBody.Append("</TR>");
							EmailBody.Append("</TABLE>");						 
							EmailBody.Append("</BODY></HTML>");
							objCLEmail.SendMail(Convert.ToString(EmailBody),"nacdb@mail.nasscom.in","Request received","nacdb@mail.nasscom.in",Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
							Response.Redirect("ThankYouPage.aspx",false);
						}
						else
						{
							Session["ErrorMessage"] = "An internal error occured";
							Response.Redirect("../Web/ErrorPage.aspx",false);
						}	
					}
				}
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Home.aspx",false);
		}

		private bool ValidateData()
		{
			if(txtCompanyName.Text.Trim()=="")
			{
				lblError.Text = "Please enter company name";
				lblError.Visible = true;
				return false;
			}
			if(txtCompanyAddress.Text.Trim()=="")
			{
				lblError.Text = "Please enter company address";
				lblError.Visible = true;
				return false;
			}

			if(txtOfficialPhone.Text.Trim()=="")
			{
				lblError.Text = "Please enter official phone number";
				lblError.Visible = true;
				return false;
			}
			else if(!IsNumeric(txtOfficialPhone.Text.Trim()))
			{
				lblError.Text = "Please enter numbers only";
				lblError.Visible = true;
				return false;
			}
			if(txtOfficialPhone.Text.Trim().Length < 7)
			{
				lblError.Text = "Official Phone No. can't be less than 7 digits";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCName.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's name";
				lblError.Visible = true;
				return false;
			}
			else if(!IsAlphabet(txtSPOCName.Text.Trim()))
			{
				lblError.Text = "Please enter alphabets only";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCPhone.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's phone number";
				lblError.Visible = true;
				return false;
			}
			else if(!IsNumeric(txtSPOCPhone.Text.Trim()))
			{
				lblError.Text = "Please enter numbers only";
				lblError.Visible = true;
				return false;
			}
			if(txtSPOCPhone.Text.Trim().Length < 7)
			{
				lblError.Text = "Please enter a valid SPOC's phone number. Can't be less than 7 digits";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCEmail.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's email ID";
				lblError.Visible = true;
				return false;
			}
			else if(!ValidEmail(txtSPOCEmail.Text.Trim()))
			{
				lblError.Text = "Please enter valid email ID";
				lblError.Visible = true;
				return false;
			}
			else if(txtSPOCEmail.Text.Trim().ToLower().IndexOf("@gmail.co")>0 || txtSPOCEmail.Text.Trim().ToLower().IndexOf("@yahoo.co")>0 ||
				txtSPOCEmail.Text.Trim().ToLower().IndexOf("@rediff.co")>0 || txtSPOCEmail.Text.Trim().ToLower().IndexOf("@zapak.co")>0 ||
				txtSPOCEmail.Text.Trim().ToLower().IndexOf("@hotmail.co")>0)
			{
				lblError.Text = "Please enter official email ID";
				lblError.Visible = true;
				return false;
			}

			if(chkDeclaration.Checked == false)
			{
				lblError.Text = "Please accept the declaration";
				lblError.Visible = true;
				return false;
			}
			return true;
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
					status=false;
					break;
				}
			}
			return status;
		}

		private bool IsNumeric(string strInput)
		{
			string check="0123456789";
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
					status=false;
					break;
				}
			}
			return status;
		}

		public bool ValidEmail(string strInput)
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

	}
}
