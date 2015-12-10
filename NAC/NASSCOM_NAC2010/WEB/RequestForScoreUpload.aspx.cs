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
using System.Text;
using BusinessLayer;
using System.Configuration;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for RequestForScoreUpload.
	/// </summary>
	public partial class RequestForScoreUpload : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnApprove.Attributes.Add("onclick","return ApproveStatus();");
			btnReject.Attributes.Add("onclick","return ApproveStatus();");
			//btnCloseStatus.Attributes.Add("onclick","return ApproveStatus();");
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				dgETSRequestStatus.DataSource = FetchETSStatusRequest();
				dgETSRequestStatus.DataBind();
 
			}
		}

		private DataSet FetchETSStatusRequest()
		{
			// ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
			ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
			return objScoreOverwrite.FetchETSStatusRequest();
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

		private void btnApprove_Click(object sender, System.EventArgs e)
		{
			 
			int intRowId = 0;
			int intStateId = 0;
			string strAdminComment = null;
			  
			foreach(DataGridItem dgItem in dgETSRequestStatus.Items)
			{ 
				 
				if(((System.Web.UI.WebControls.CheckBox)dgItem.FindControl("chkSelect")).Checked)
				{					 
					intRowId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblId")).Text); 
					intStateId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblStateId")).Text); 
					strAdminComment = Convert.ToString(((System.Web.UI.HtmlControls.HtmlInputHidden)dgItem.FindControl("hdAdminComment")).Value); 
					ApproveETSRequest(intRowId,strAdminComment,intStateId);
				}
				 
			}			 

			dgETSRequestStatus.DataSource = FetchETSStatusRequest();
			dgETSRequestStatus.DataBind();
		}


		public void ApproveETSRequest(int intRowId, string strAdminComment, int intStateId)
		{
			ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
			objScoreOverwrite.ApproveETSRequest(intRowId, strAdminComment,intStateId);
		}

		protected void btnReject_Click(object sender, System.EventArgs e)
		{
			int intRowId = 0;
			int intStateId = 0;
			string strAdminComment = null;

			foreach(DataGridItem dgItem in dgETSRequestStatus.Items)
			{ 
				 
				if(((System.Web.UI.WebControls.CheckBox)dgItem.FindControl("chkSelect")).Checked)
				{					 
					intRowId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblId")).Text); 
					intStateId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblStateId")).Text); 
					strAdminComment = Convert.ToString(((System.Web.UI.HtmlControls.HtmlInputHidden)dgItem.FindControl("hdAdminComment")).Value); 
				 
					RejectETSRequest(intRowId, strAdminComment,intStateId);
				 
				}
				 
			}
		 
			dgETSRequestStatus.DataSource = FetchETSStatusRequest();
			dgETSRequestStatus.DataBind();
		}


		public void RejectETSRequest(int intRowId, string strAdminComment, int intStateId)
		{
			ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
			objScoreOverwrite.RejectETSRequest(intRowId, strAdminComment,intStateId);
		}

		//		private void btnCloseStatus_Click(object sender, System.EventArgs e)
		//		{
		//			int intRowId = 0;
		//			int intStateId = 0;
		//			string strAdminComment = null;
		//
		//			foreach(DataGridItem dgItem in dgETSRequestStatus.Items)
		//			{ 
		//				 
		//				if(((System.Web.UI.WebControls.CheckBox)dgItem.FindControl("chkSelect")).Checked && ((System.Web.UI.WebControls.Label)dgItem.FindControl("lblIsActive")).Text != "N/A")
		//				{					 
		//					intRowId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblId")).Text); 
		//					intStateId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblStateId")).Text); 
		//					strAdminComment = Convert.ToString(((System.Web.UI.HtmlControls.HtmlInputHidden)dgItem.FindControl("hdAdminComment")).Value); 
		//				 
		//					CloseStatus(intRowId, strAdminComment,intStateId);
		//				 
		//				}
		//				 
		//			}
		//		 
		//			dgETSRequestStatus.DataSource = FetchETSStatusRequest();
		//			dgETSRequestStatus.DataBind();
		//		}

		public void CloseStatus(int intRowId, string strAdminComment, int intStateId)
		{
			ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
			objScoreOverwrite.CloseStatus(intRowId, strAdminComment,intStateId);
		}
	}
}
