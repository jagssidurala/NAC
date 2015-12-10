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

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for EncryptDecrypt.
	/// </summary>
	public partial class EncryptDecrypt : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null)
			{
				Session.Abandon();
				Response.Redirect("../Web/Login.aspx",false);
			}
			lblResult.Visible = true;
			btnGetPassword.Attributes.Add("OnClick","javascript:return ValidateData();");
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

		protected void btnGetPassword_Click(object sender, System.EventArgs e)
		{
			BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
			try
			{
				objBLCompanyLogin.Password = txtPassword.Text;
				if(objBLCompanyLogin.IsCompanyPasswordValid())
				{
					lblResult.Text = "Your decrypted password is: " + objBLCompanyLogin.base64Decode(txtPassword.Text);
					lblResult.Visible = true;
				}
				else
				{
					lblResult.Text = "Please enter a valid encrypted password";
					lblResult.Visible = true;
				}

			}
			catch
			{
				lblResult.Text = "Please enter a valid encrypted password";
				lblResult.Visible = true;
			}
		}

		protected void lnkHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdminHome.aspx",false);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdminHome.aspx",false);
		}
	}
}
