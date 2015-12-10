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
using System.Threading;
using BusinessLayer;


namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSubmit.Attributes.Add("onclick","return ValidateUser('"+txtUserName.ClientID+"','"+txtPassword.ClientID+"');");
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
			String strUserName = txtUserName.Text.ToString().Trim();
			String strPassword = txtPassword.Text.ToString().Trim();

			try
			{
				BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
				DataSet ds = chkUser.ValidateAdminCredential(strUserName,strPassword);
				if (ds.Tables[0].Rows.Count > 0)
				{
					HttpContext.Current.Session["UserID"] = ds.Tables[0].Rows[0]["UserId"].ToString();
					HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
					HttpContext.Current.Session["UserType"] = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());
					Response.Redirect("Welcome.aspx");
				}
				else
				{
					HttpContext.Current.Session["UsreID"] = null;
					HttpContext.Current.Session["UserName"] = null;
					HttpContext.Current.Session["UserType"] = null;
					RegisterStartupScript("ValidateUserCreditional","<script>alert('Invalid userid or password')</script>");
				}
			}
			catch (ThreadAbortException ex)
			{		
				throw ex;
			}
			catch (Exception ex)
			{
				ErrorLogger.ErrorRoutine(false,ex);
			}
								
		}
	}
}
