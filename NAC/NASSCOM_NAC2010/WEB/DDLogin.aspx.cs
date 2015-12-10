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
	/// Summary description for DDLogin.
	/// </summary>
	public class DDLogin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtMiddleName;
		protected System.Web.UI.WebControls.TextBox txtDdNo;
		protected System.Web.UI.WebControls.Button btnLogin;
		protected System.Web.UI.WebControls.DropDownList ddlPhotoIdDocument;
		protected System.Web.UI.WebControls.TextBox txtPhotoIdNumber;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				FillPhotoIdDetail();
			}
			btnSubmit.Attributes.Add("onclick","return ValidateNewUser('"+txtFirstName.ClientID+"','"+txtLastName.ClientID+"','"+txtDdNo.ClientID+"');");
			btnLogin.Attributes.Add("onclick","return ValidateLogin('"+ddlPhotoIdDocument.ClientID+"','"+txtPhotoIdNumber.ClientID+"','"+txtPassword.ClientID+"');");
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("registration.aspx");
		}
		private void FillPhotoIdDetail()
		{
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(),"PhotoIdDocument","PhotoId");
		}
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{

			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

		}
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
	
			String strPhotoId = ddlPhotoIdDocument.SelectedValue.ToString().Trim();
			String strDocumentNo = txtPhotoIdNumber.Text.ToString().Trim();
			string strPassword = txtPassword.Text.ToString();

			try
			{
				BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
				DataSet ds = chkUser.ValidateUserCredential(strPhotoId,strDocumentNo,strPassword);
				if (ds.Tables[0].Rows.Count > 0)
				{
					HttpContext.Current.Session["UserID"] = ds.Tables[0].Rows[0]["UserName"].ToString();
					HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["FName"].ToString();
					HttpContext.Current.Session["UserType"] = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());
					Response.Redirect("Welcome.aspx");
				}
				else
				{
					HttpContext.Current.Session["UsreID"] = null;
					HttpContext.Current.Session["UserName"] = null;
					HttpContext.Current.Session["UserType"] = null;
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
