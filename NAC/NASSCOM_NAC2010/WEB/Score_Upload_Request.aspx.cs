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
	/// Summary description for Score_Upload_Request.
	/// </summary>
	public partial class Score_Upload_Request : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{		
 			if(!Page.IsPostBack)
 			{
 				dgETSRequestStatus.DataSource = FetchETSStatusRequest();
 				dgETSRequestStatus.DataBind();
				 
 			}
		}

		private DataSet FetchETSStatusRequest()
		{			 
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

		protected void btnRequestForReupload_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem dgItem in dgETSRequestStatus.Items)
			{ 
				 
				if(((System.Web.UI.WebControls.CheckBox)dgItem.FindControl("chkSelect")).Checked)
				{
					ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
					objScoreOverwrite.RowId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblId")).Text); 
 					objScoreOverwrite.StateId = Convert.ToInt32(((System.Web.UI.WebControls.Label)dgItem.FindControl("lblStateId")).Text); 
					objScoreOverwrite.UserId = Convert.ToInt32(Session["UserID"]);
					objScoreOverwrite.UserName = Convert.ToString(Session["UserName"]);
					objScoreOverwrite.ETSComment = Convert.ToString(((System.Web.UI.HtmlControls.HtmlInputHidden)dgItem.FindControl("hdETSComment")).Value); 
					objScoreOverwrite.RequestForScoreOverwrite();					
				}
				 
			}			 

			dgETSRequestStatus.DataSource = FetchETSStatusRequest();
			dgETSRequestStatus.DataBind();
		}

		protected void dgETSRequestStatus_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			int intPermitted = 0;
			if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				intPermitted = Convert.ToInt32(((System.Web.UI.WebControls.Label)e.Item.FindControl("lblIsPermitted")).Text);

				switch(intPermitted)
				{
					case 1 : 
						((System.Web.UI.WebControls.CheckBox)e.Item.FindControl("chkSelect")).Attributes.Remove("onclick");
						((System.Web.UI.WebControls.CheckBox)e.Item.FindControl("chkSelect")).Attributes.Add("onclick","javascript:alert('Request is pending'); return false;");
						((System.Web.UI.WebControls.CheckBox)e.Item.FindControl("chkSelect")).Enabled = false;
						break;					
					case 2 :						
						((System.Web.UI.WebControls.CheckBox)e.Item.FindControl("chkSelect")).Attributes.Remove("onclick");					
						((System.Web.UI.WebControls.CheckBox)e.Item.FindControl("chkSelect")).Enabled = false;
						break;
					case 0 :
					case 4 :			 
					case 3 :						
						((System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtETSComment")).Attributes.Add("onblur","ValidateData(this);");						
						break;
				}				

			}
		}

		 
	}
}
