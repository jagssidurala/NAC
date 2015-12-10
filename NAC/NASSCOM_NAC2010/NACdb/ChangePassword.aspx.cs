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
	/// Summary description for ChangePassword.
	/// </summary>
	public partial class ChangePassword : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["CompanyId"] == null || Session["CompanyName"] == null)
			{
				Response.Redirect("./LoginPage.aspx",false);
			}
			else
			{
				btnSave.Attributes.Add("OnClick","javascript:return ValidateData();");
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
			Response.Redirect("CompanyHomePage.aspx",false);
		}

		#region Save
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtNewPassword.Text.Length != txtNewPassword.Text.Trim().Length)
			{
				lblError.Text = "Spaces are not allowed in start or end";
				lblError.Visible = true;
				return;
			}
			else if(txtNewPassword.Text.Length < 6)
			{
				lblError.Text = "Password must be at least of 6 characters";
				lblError.Visible = true;
				return;
			}

			if(txtCurrentPassword.Text.Trim() == "")
			{
				lblError.Text = "Please enter current password";
				lblError.Visible = true;
				return;
			}
			else if(txtNewPassword.Text.Trim() == "")
			{
				lblError.Text = "Please enter a new password";
				lblError.Visible = true;
				return;
			}
			else if(txtConfirmNewPassword.Text.Trim() == "")
			{
				lblError.Text = "Please enter new password to confirm";
				lblError.Visible = true;
				return;
			}
			else
			{
				if(txtNewPassword.Text == txtConfirmNewPassword.Text)
				{
					BLCompanyLogin objCompanyLogin = new BLCompanyLogin();
					DataSet ds = new DataSet();
					objCompanyLogin.CompanyId = Convert.ToInt32(Session["CompanyId"].ToString());
					objCompanyLogin.Password = objCompanyLogin.base64Encode(txtCurrentPassword.Text);
					objCompanyLogin.NewPassword = objCompanyLogin.base64Encode(txtNewPassword.Text);
					ds = objCompanyLogin.ChangeCompanyPassword();
					if(ds.Tables.Count>0)
					{
						if(ds.Tables[0].Rows.Count>0)
						{
							if(ds.Tables[0].Rows[0][0].ToString() == "1")
							{
								lblError.Text = "Password changed successfully";
								lblError.Visible = true;
								Session["IsUpdated"] = "True";
								return;
							}
							else if(ds.Tables[0].Rows[0][0].ToString() == "2")
							{
								lblError.Text = "Invalid current password";
								lblError.Visible = true;
								return;
							}
							else if(ds.Tables[0].Rows[0][0].ToString() == "3")
							{
								lblError.Text = "New password is same as current password";
								lblError.Visible = true;
								return;
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
				}
				else
				{
					lblError.Text = "New password & confirm new password do not match";
					lblError.Visible = true;
					return;
				}
			}
		}	
		#endregion
	}
}
