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
using System.Configuration;
using BusinessLayer;

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for Approve.
	/// </summary>
	public partial class Approve : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			/*if(Request.QueryString["Email"] == null || Request.QueryString["Id"] == null)
			{
				Response.Redirect("../Web/Login.aspx",false);
			}*/

			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null || Request.QueryString["Email"] == null || Request.QueryString["Id"] == null)
			{
				Response.Redirect("../Web/Login.aspx",false);
			}

			Session["Approve_Email"] = Convert.ToString(Request.QueryString["Email"]);
			Session["Approve_Id"] = Convert.ToString(Request.QueryString["Id"]);

			btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
			string cRefreshParentKey = "RefreshParentKey";
			string strScript = "<script>window.opener.document.forms(0).submit();</script>";
			lblError.Visible=false;
			if (!this.Page.IsClientScriptBlockRegistered(cRefreshParentKey))
			{
				this.Page.RegisterClientScriptBlock(cRefreshParentKey, strScript);
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language=javascript>window.close();</script>");
			Response.End();
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
			int CompanyId = Convert.ToInt32(Request.QueryString["Id"].ToString());
			string emailTo = Request.QueryString["Email"].ToString();
			

			DataSet dsUpdateStatus = new DataSet();
			DataSet dsGenerateLoginDetail = new DataSet();
			string loginId="";
			string password="";
			if(ddlDay.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry day";
				lblError.Visible = true;
				return;
			}
			else if(ddlDay.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry month";
				lblError.Visible = true;
				return;
			}
			else if(ddlDay.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry year";
				lblError.Visible = true;
				return;
			}
			else
			{ 
				DateTime today;
				today = DateTime.Today;
				if(Convert.ToDateTime(ddlMonth.SelectedValue+"/"+ddlDay.SelectedValue+"/"+ddlYear.SelectedValue) <= today)
				{
					lblError.Text = "Past or current date for Agreement expiry is not allowed";
					lblError.Visible = true;
					return;	
				}
				else
				{
					//Session["PendingStatus"] = "1";
					objBLCompanyLogin.CompanyId = CompanyId;
					objBLCompanyLogin.Status = 1;
					objBLCompanyLogin.AgreementExpiryDate = Convert.ToDateTime(ddlMonth.SelectedValue +"/"+ ddlDay.SelectedValue +"/"+ ddlYear.SelectedValue);
					
					
					DataSet dsCompanyStatusDetail = new DataSet();
					dsCompanyStatusDetail = objBLCompanyLogin.GetCompanyDetailById();
				
					if(dsCompanyStatusDetail.Tables[0].Rows[0]["Status"].ToString().ToUpper().Trim() == "APPROVED")
					{
						lblError.Text="Cannot approve the company. The request has already been approved.";
						lblError.Visible=true;
						return;
					}

					else if(dsCompanyStatusDetail.Tables[0].Rows[0]["Status"].ToString().ToUpper().Trim() == "REJECTED")
					{
						lblError.Text="Cannot approve the company. The request has already been rejected.";
						lblError.Visible=true;
						return;
					}

					else if((dsCompanyStatusDetail.Tables[0].Rows[0]["CompanyId"].ToString().Trim() != CompanyId.ToString()) || (dsCompanyStatusDetail.Tables[0].Rows[0]["SPOCEmail"].ToString().ToUpper().Trim() != emailTo.Trim().ToUpper()))
					{
						lblError.Text="Cannot approve the company. There is a mismatch in company id and the email.";
						lblError.Visible=true;
						return;
					}
					else
					{
					
						dsUpdateStatus = objBLCompanyLogin.UpdateCompanyStatus();
						if(dsUpdateStatus.Tables.Count>0)
						{
							if(dsUpdateStatus.Tables[0].Rows.Count>0)
							{
								if(dsUpdateStatus.Tables[0].Rows[0][0].ToString()=="1")
								{
									dsGenerateLoginDetail = objBLCompanyLogin.GenerateLoginDetail();		
								}
								else
								{
									lblError.Text = "Some error occured, please try again later";
									lblError.Visible = true;
									return;
								}
							}
							else
							{
								lblError.Text = "Some error occured, please try again later";
								lblError.Visible = true;
								return;
							}
						}
						else
						{
							lblError.Text = "Some error occured, please try again later";
							lblError.Visible = true;
							return;
						}

						if(dsGenerateLoginDetail.Tables.Count>0)
						{
							if(dsGenerateLoginDetail.Tables[0].Rows.Count>0)
							{
								if(dsGenerateLoginDetail.Tables[0].Rows[0][0].ToString() == "0")
								{
									return;
								}
								else if(dsGenerateLoginDetail.Tables[0].Rows[0][0].ToString() == "1")
								{
									loginId = dsGenerateLoginDetail.Tables[1].Rows[0]["LoginId"].ToString();
									password = dsGenerateLoginDetail.Tables[1].Rows[0]["Password"].ToString();
									objBLCompanyLogin.Password = password;
									objBLCompanyLogin.NewPassword = objBLCompanyLogin.base64Encode(password);
									objBLCompanyLogin.CompanyId = Convert.ToInt32(dsGenerateLoginDetail.Tables[1].Rows[0]["CompanyId"].ToString());
									objBLCompanyLogin.ChangeCompanyPassword();
								}
							}
							if(loginId!="" && password != "")
							{
								CLEmail objCLEmail = new CLEmail();
					
								StringBuilder EmailBody = new StringBuilder();
								EmailBody.Append("<HTML><BODY>");
								EmailBody.Append("<TABLE cellSpacing=0 cellPadding=3 width=100% bgcolor=#FFFFFF border=0>");
								EmailBody.Append("<TR>");
								EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
								EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Hi</span><br><br>");
								EmailBody.Append("</TD>");
								EmailBody.Append("</TR>");
				
								EmailBody.Append("<TR>");
								EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
								EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Thank you for your interest in the NAC initiative.</span><br><br>");						
								EmailBody.Append("</TD>");
								EmailBody.Append("</TR>");

								EmailBody.Append("<TR>");
								EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
								EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>As one of the endorsing companies, you are now eligible to access the NAC database. Please use the following log-in details for the same.</span><br><br>");						
								EmailBody.Append("</TD>");
								EmailBody.Append("</TR>");

								EmailBody.Append("<TR valign=top>");
								EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
								EmailBody.Append("<table cellpadding=0 width=100% cellspacing=0 border=0>");

								EmailBody.Append("<TR valign=top>");
								EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>User Id:</span></strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
								EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + loginId + "</span></strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("</TR>");

								EmailBody.Append("<TR valign=top>");
								EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Password:</span></strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
								EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + password + "</strong></span>");
								EmailBody.Append("</TD>");
								EmailBody.Append("</TR>");

								EmailBody.Append("<TR valign=top>");
								EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>URL for database access:</span></strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
								EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
								EmailBody.Append("</TD>");
								EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
								EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + "http://www.nac.nasscom.in/nacdb/LoginPage.aspx" + "</strong></span>");
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
					
								objCLEmail.SendMail(EmailBody.ToString(),"nacdb@mail.nasscom.in","Request Approved",emailTo,Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
								this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Approval email has been sent. Thank You');window.close();</script>");
							}
						}
					}
				}
			}
		}
	}
}
