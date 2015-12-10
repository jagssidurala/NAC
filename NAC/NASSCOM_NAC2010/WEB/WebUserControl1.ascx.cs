namespace NASSCOM_NAC.Web
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for WebUserControl1.
	/// </summary>
	public class WebUserControl1 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.HtmlControls.HtmlTextArea selDesc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
//		protected void Button1_Click(object sender, EventArgs e)
//		{
//			Literal1.Text =  selDesc.Value.Replace("'","''")  ;
//		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
		Literal1.Text =  selDesc.Value.Replace("'","''")  ;
		}
	}
}
