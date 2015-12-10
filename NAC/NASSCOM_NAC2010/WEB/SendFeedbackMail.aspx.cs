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
	/// Summary description for SendFeedbackMail.
	/// </summary>
	public partial class SendFeedbackMail : System.Web.UI.Page
	{
		static string prevPage = String.Empty;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Request.QueryString["type"]=="nac")
			{
				ddlType.SelectedValue="1";
				ddlType.Enabled=false;
			}
			btnSave.Attributes.Add("onclick","javascript:return ValidateData();");
	        txtComments.Attributes.Add("onkeyup","Count(this,1000);");
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			CLEmail objCLEmail = new CLEmail();
			string strComments = txtComments.Text.ToString().Trim().Replace(Environment.NewLine, "<br>" );
			if(ddlType.SelectedValue == "1")
			{
				objCLEmail.SendMail(strComments, txtEmail.Text.Trim(),"NAC Support","nac@nasscom.in", Convert.ToString(ConfigurationSettings.AppSettings["MailServer"]));
			}
			else if(ddlType.SelectedValue == "2")
			{
				objCLEmail.SendMail(strComments, txtEmail.Text.Trim(),"NAC-Tech Support","nactech@nasscom.in", Convert.ToString(ConfigurationSettings.AppSettings["MailServer"]));
			}
			Response.Write("<script language=javascript>alert('Thank you! We shall revert to you shortly.'); window.close();</script>");
			Response.End();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language=javascript>window.close();</script>");
			Response.End();
		}
	}
}
