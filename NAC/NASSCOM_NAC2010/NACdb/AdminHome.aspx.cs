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
	/// Summary description for AdminHome.
	/// </summary>
	public partial class AdminHome : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lnkLogOut.Attributes.Add("onclick","CloseWindow();");

			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null)
			{
				Session.Abandon();
				Response.Redirect("../Web/Login.aspx",false);
			}
			else
			{
				if(!IsPostBack)
				{
					BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
					DataSet ds = new DataSet();
					objBLCompanyLogin.Status = 0;
					ds = objBLCompanyLogin.GetMembersByStatus();
					if(ds.Tables.Count > 0)
					{
						if(ds.Tables[0].Rows.Count >= 0)
						{
							lnkApproveDenyRequest.Text = lnkApproveDenyRequest.Text + " (" + ds.Tables[0].Rows.Count.ToString() + ")";
						}
					}
				}
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

		protected void lnkSendEmail_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("SendEmail.aspx",false);
		}

		protected void lnkApproveDenyRequest_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ApproveDenyRequest.aspx",false);
		}

		protected void lnkViewAll_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ViewAllMembers.aspx",false);
		}

		protected void lnkLogOut_Click(object sender, System.EventArgs e)
		{
			Session["UserID"] = null;
			Session["UserName"] = null;
			Session["UserType"] = null;
			Session.Abandon();
			//Response.Redirect("../Web/Login.aspx",false);
			Response.Write("<script language=javascript>self.close();</script>");
			string nextpage = "../Web/Login.aspx";
			Response.Write("<script language=javascript>");
			Response.Write("{");
			Response.Write(" var Backlen=history.length;");
			Response.Write(" history.go(-Backlen);");
			Response.Write(" window.location.href='" + nextpage + "'; ");
			Response.Write("}");
			Response.Write("</script>");  

			Response.Cache.SetExpires(DateTime.Parse(DateTime.  Now.ToString()));
			Response.Cache.SetCacheability(HttpCacheability.Private);
			Response.Cache.SetNoStore();
			Response.AppendHeader("Pragma", "no-cache");
		}

		protected void lnkbtnEncryptDecrypt_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EncryptDecrypt.aspx",false);
		}
	}
}
