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
	/// Summary description for LoginPage.
	/// </summary>
	public partial class LoginPage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblErrorMsg.Visible = false;
			btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
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
			if(txtLogin.Text.Trim()!="" || txtPassword.Text.Trim()!="")
			{
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				DataSet ds = new DataSet();
				objBLCompanyLogin.LoginId = txtLogin.Text.ToString();
				objBLCompanyLogin.Password = objBLCompanyLogin.base64Encode(txtPassword.Text.ToString());
				ds = objBLCompanyLogin.ValidateCompanyLogin();
				if(ds.Tables.Count>0)
				{
					if(ds.Tables[0].Rows.Count>0)
					{
						if(Convert.ToDateTime(ds.Tables[0].Rows[0]["AgreementExpiryDate"]) <= System.DateTime.Today.Date)
						{
							lblErrorMsg.Visible=true;
							lblErrorMsg.Text = "Agreement date has been expired.";
						}
						else
						{
							Session["CompanyId"] = ds.Tables[0].Rows[0]["CompanyId"].ToString();
							Session["CompanyName"] = ds.Tables[0].Rows[0]["CompanyName"].ToString();
							Session["IsUpdated"] = ds.Tables[0].Rows[0]["IsUpdated"].ToString();
							Response.Redirect("CompanyHomePage.aspx",false);
						}
					}
					else
					{
						lblErrorMsg.Visible=true;
						lblErrorMsg.Text = "Invalid user ID or password";
					}
				}
				else
				{
					lblErrorMsg.Visible=true;
					lblErrorMsg.Text = "Invalid user ID or password";
				}
			}
			else
			{
				lblErrorMsg.Visible=true;
				lblErrorMsg.Text = "Please enter user ID and Password";
			}
		}

		protected void lnkHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Home.aspx",false);
		}

		protected void lnkBtnForgotPassword_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ForgotPassword.aspx",false);
		}


	}
}
