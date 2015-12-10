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
	/// Summary description for CompanyProfile.
	/// </summary>
	public partial class CompanyProfile : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["CompanyId"]==null && Request.QueryString["Id"]==null)
			{
				Response.Redirect("./LoginPage.aspx",false);
			}
			else if(Request.QueryString["Id"]!=null)
			{
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				objBLCompanyLogin.CompanyId = Convert.ToInt32(Request.QueryString["Id"].ToString());
				//trBanner.Attributes.Add("style","Display:none");
				//trFooter.Attributes.Add("style","Display:none");
				lblNote.Visible=false;
				btnBack.Visible = false;
				btnClose.Visible=true;
				Populate(objBLCompanyLogin);
			}
			else
			{
				trLogin.Attributes.Add("style","Display:none");
				trPassword.Attributes.Add("style","Display:none");
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				objBLCompanyLogin.CompanyId = Convert.ToInt32(Session["CompanyId"].ToString());
				Populate(objBLCompanyLogin);
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

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("CompanyHomePage.aspx",false);
		}

		private void Populate(BLCompanyLogin objBLCompanyLogin)
		{
			DataSet dsCompanyDetail = new DataSet();
			dsCompanyDetail = objBLCompanyLogin.GetCompanyDetailById();
			objBLCompanyLogin.CompanyName = dsCompanyDetail.Tables[0].Rows[0]["CompanyName"].ToString();
			objBLCompanyLogin.CompanyAddress = dsCompanyDetail.Tables[0].Rows[0]["CompanyAddress"].ToString();
			objBLCompanyLogin.CompanyAddress = objBLCompanyLogin.CompanyAddress.Replace("\\r\\n","<br>");
			objBLCompanyLogin.OfficialPhone = dsCompanyDetail.Tables[0].Rows[0]["OfficialPhone"].ToString();
			objBLCompanyLogin.CompanySPOCName = dsCompanyDetail.Tables[0].Rows[0]["SPOCName"].ToString();
			objBLCompanyLogin.CompanySPOCPhone = dsCompanyDetail.Tables[0].Rows[0]["SPOCPhone"].ToString();
			objBLCompanyLogin.CompanySPOCEmail = dsCompanyDetail.Tables[0].Rows[0]["SPOCEmail"].ToString();
			objBLCompanyLogin.AgreementExpiryDate = Convert.ToString(dsCompanyDetail.Tables[0].Rows[0]["AgreementExpiryDate"]) != ""?Convert.ToDateTime(dsCompanyDetail.Tables[0].Rows[0]["AgreementExpiryDate"].ToString()):Convert.ToDateTime("01-Jan-1900");
			/*if(Convert.ToString(dsCompanyDetail.Tables[0].Rows[0]["AgreementExpiryDate"]) == "")
				objBLCompanyLogin.AgreementExpiryDate = Convert.ToDateTime("01-Jan-1900") ;
			else
 				objBLCompanyLogin.AgreementExpiryDate = Convert.ToDateTime(dsCompanyDetail.Tables[0].Rows[0]["AgreementExpiryDate"].ToString());
				*/
			lblCompanyName.Text = objBLCompanyLogin.CompanyName;
			lblCompanyAddress.Text = objBLCompanyLogin.CompanyAddress;
			lblOfficialPhone.Text = objBLCompanyLogin.OfficialPhone;
			lblSPOCName.Text = objBLCompanyLogin.CompanySPOCName;
			lblSPOCPhone.Text = objBLCompanyLogin.CompanySPOCPhone;
			lblSPOCEmail.Text = objBLCompanyLogin.CompanySPOCEmail;
			lblExpiryDate.Text = objBLCompanyLogin.AgreementExpiryDate.ToString("dd-MMM-yyyy");
			if(lblExpiryDate.Text == "01-Jan-1900")
			{
				lblExpiryDate.Text = "-NA-";
			}
			if(Request.QueryString["Id"]!=null)
			{
				lblLoginIdValue.Text = dsCompanyDetail.Tables[0].Rows[0]["LoginId"].ToString()!= ""?dsCompanyDetail.Tables[0].Rows[0]["LoginId"].ToString():"-NA-";
				lblPasswordValue.Text = dsCompanyDetail.Tables[0].Rows[0]["Password"].ToString()!=""?dsCompanyDetail.Tables[0].Rows[0]["Password"].ToString():"-NA-" ;
			}
		}

		protected void btnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language=javascript>window.close();</script>");
			Response.End();
		}


	}
}
