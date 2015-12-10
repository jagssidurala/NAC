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
	/// Summary description for RejectReason.
	/// </summary>
	public partial class RejectReason : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null || Request.QueryString["Email"] == null || Request.QueryString["Id"] == null)
			{
				Response.Redirect("../Web/Login.aspx",false);
			}

//			if(Request.QueryString["Email"] == null || Request.QueryString["Id"] == null)
//			{
//				Response.Redirect("../Web/Login.aspx",false);
//			}
			
			btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
			txtRejectReason.Attributes.Add("onkeyup","Count(this,500);");
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
			if(txtRejectReason.Text.Trim()!="")
			{
				//Session["PendingStatus"] = "1";
				CLEmail objCLEmail = new CLEmail();
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				objBLCompanyLogin.CompanyId = Convert.ToInt32(Request.QueryString["Id"].ToString());
				objBLCompanyLogin.CompanySPOCEmail = Request.QueryString["Email"].ToString();
				objBLCompanyLogin.Status = 2;
				objBLCompanyLogin.RejectReason = txtRejectReason.Text;
				objBLCompanyLogin.RejectReason = objBLCompanyLogin.RejectReason.Replace("\r\n"," ");
				
				DataSet dsCompanyStatusDetail = new DataSet();
				dsCompanyStatusDetail = objBLCompanyLogin.GetCompanyDetailById();
				
				if(dsCompanyStatusDetail.Tables[0].Rows[0]["Status"].ToString().ToUpper().Trim() == "APPROVED")
				{
					lblError.Text="Cannot reject the company. The request has already been approved.";
					lblError.Visible=true;
					return;
				}

				else if(dsCompanyStatusDetail.Tables[0].Rows[0]["Status"].ToString().ToUpper().Trim() == "REJECTED")
				{
					lblError.Text="Cannot reject the company. The request has already been rejected.";
					lblError.Visible=true;
					return;
				}
				else if((dsCompanyStatusDetail.Tables[0].Rows[0]["CompanyId"].ToString().Trim() != Request.QueryString["Id"].ToString()) || (dsCompanyStatusDetail.Tables[0].Rows[0]["SPOCEmail"].ToString().ToUpper().Trim() != Request.QueryString["Email"].ToString().ToUpper()))
				{
					lblError.Text="Cannot reject the company. There is a mismatch in company id and the email.";
					lblError.Visible=true;
					return;
				}
				else
				{
					objBLCompanyLogin.UpdateCompanyStatus();
				    objBLCompanyLogin.RejectReason = txtRejectReason.Text.Replace("\r\n","<br>");
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
					EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>We would like to inform that your request for 'NAC database access' has been declined on following grounds:</span><br><br>");						
					EmailBody.Append("</TD>");
					EmailBody.Append("</TR>");

					EmailBody.Append("<TR>");
					EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
					EmailBody.Append("<span style=font-size:9.0pt; font-family:Arial;><b>\"" + objBLCompanyLogin.RejectReason + "\"</b></span><br><br>");						
					EmailBody.Append("</TD>");
					EmailBody.Append("</TR>");
				
					EmailBody.Append("<TR>");
					EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
					EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>If you have any queries, please write to us @ nacdb@mail.nasscom.in.</span><br><br>");						
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

					objCLEmail.SendMail(EmailBody.ToString(),"nacdb@mail.nasscom.in","Request Rejected",objBLCompanyLogin.CompanySPOCEmail.ToString(),Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
					this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Rejection email has been sent. Thank You');window.close();</script>");
				}
			}
			else
			{
				lblError.Text="Please enter a reject reason";
				lblError.Visible=true;
			}
		}
	}
}
