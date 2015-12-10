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
	/// Summary description for ViewAllMembers.
	/// </summary>
	public partial class ViewAllMembers : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null)
			{
				Session.Abandon();
				Response.Redirect("../Web/Login.aspx",true);
			}

			BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
			DataSet dsApprovedMembers = new DataSet();
			DataSet dsRejectedMembers = new DataSet();

			objBLCompanyLogin.Status = 1;
			dsApprovedMembers = objBLCompanyLogin.GetMembersByStatus();
			dgApprovedMembers.DataSource = dsApprovedMembers;
			dgApprovedMembers.DataBind();
			
			objBLCompanyLogin.Status = 2;
			dsRejectedMembers = objBLCompanyLogin.GetMembersByStatus();
			dgRejectedMembers.DataSource = dsRejectedMembers;
			dgRejectedMembers.DataBind();
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
		Response.Redirect("AdminHome.aspx",true);
		}
	}
}
