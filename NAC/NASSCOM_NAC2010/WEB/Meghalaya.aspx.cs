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
 
using DataAccessLayer;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Meghalaya.
	/// </summary>
	public partial class Meghalaya : System.Web.UI.Page
	{
		DataSet dsStateDetail;
		private string strStateName;
		private string strStateLogo;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["State"] != null && Session["StateId"] != null)
			{
				if (Request.QueryString["State"] != null)
				{
					lblState.Text = Request.QueryString["State"].ToString();
					strStateName = Request.QueryString["State"].ToString();
				}
				else
				{
					lblState.Text = Convert.ToString(Session["State"]);
					strStateName = Convert.ToString(Session["State"]);
				}	
				//lblState.Text = strStateName;
				Session["State"]= strStateName;
				BLLogin objBLLogin = new BLLogin();
				dsStateDetail = new DataSet();
				dsStateDetail = objBLLogin.GetStateDetail(strStateName);
				if(dsStateDetail.Tables[0].Rows.Count > 0)
				{
					//store state id in session
					Session["StateId"] = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["StateId"]);
					strStateLogo = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["Logo"]);
					Session["StateLogo"] = strStateLogo;
//					if(Convert.ToInt32(Session["StateId"]) == 14)
//					{
//					  Response.Redirect("PinLogin.aspx");
//					}
					
					//imgStateLogo.Src = "images/"+ strStateLogo;
				}
				//imgStateLogo.Src = "images/"+ Convert.ToString(Session["StateLogo"]);
			}
			else
			{
				if (Request.QueryString["State"] != null)
				{
					strStateName = Request.QueryString["State"].ToString();
				}
				else
				{
					Response.Redirect("../default.aspx");
				}
				lblState.Text = strStateName;
				Session["State"]= strStateName;
				BLLogin objBLLogin = new BLLogin();
				dsStateDetail = new DataSet();
				dsStateDetail = objBLLogin.GetStateDetail(strStateName);
				if(dsStateDetail.Tables[0].Rows.Count > 0)
				{
					//store state id in session
					Session["StateId"] = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["StateId"]);
					strStateLogo = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["Logo"]);
					Session["StateLogo"] = strStateLogo;
//					if(Request.QueryString["State"].ToString().Trim() == "Meghalaya")
//					{
//					  Response.Redirect("PinLogin.aspx");
//					}
					
					//imgStateLogo.Src = "images/"+ strStateLogo;
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
	}
}
