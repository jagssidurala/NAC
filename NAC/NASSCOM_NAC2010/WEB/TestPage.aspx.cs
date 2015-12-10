using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using BusinessLayer;
using Common;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for TestPage.
	/// </summary>
	public partial class TestPage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			btnSubmit.Attributes.Add("Onclick","return SetbodyText();");
			lblMessage.Visible = false;
			if(!Page.IsPostBack)
			{		
				
				FillStates();
				FillDetail(Convert.ToInt32(cmbUserType.SelectedValue),Convert.ToInt32(cmbStates.SelectedValue),Convert.ToString(cmbTestName.SelectedValue));
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			BLTest objBLTest = new BLTest();			
			objBLTest.SetWelcomeBodyText(Convert.ToInt32(cmbUserType.SelectedValue), Convert.ToString(Server.HtmlEncode(txtBody.Value.ToString().Trim())),Convert.ToInt32(cmbStates.SelectedValue),Convert.ToString(cmbTestName.SelectedValue));
			FillDetail(Convert.ToInt32(cmbUserType.SelectedValue),Convert.ToInt32(cmbStates.SelectedValue),Convert.ToString(cmbTestName.SelectedValue));
			lblMessage.Visible=true;
			lblMessage.Text="Changes saved successfully";
		}
	
		private void FillStates()
		{		 	
			//Passing Test City combo to bind with FillTestCitySecond(DataTable) 
			BLTest objBLTest = new BLTest();

			DataTable dt= new DataTable(); 
			dt= objBLTest.FillStates();
			cmbStates.DataSource=dt;
			cmbStates.DataTextField="State";
			cmbStates.DataValueField="StateId";
			cmbStates.DataBind();

		}

		private void FillDetail(int UserType,int StateId, string TestName)
		{
				
			BLTest objBLTest = new BLTest();
			string strWelcometext;
			strWelcometext= objBLTest.GetWelcomeBodyText(UserType,StateId,TestName);
			if(strWelcometext!="")
			{	
								
				divBody.InnerHtml = "<P>" + Server.HtmlDecode(strWelcometext) + "</P>";				 				
			}
			else
			{			
				strWelcometext= objBLTest.GetWelcomeBodyText(1,0,"NACTest1");								
				divBody.InnerHtml = "<P>" + Server.HtmlDecode(strWelcometext) + "</P>";
			}
			
		}

//		private void cmbStates_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			FillDetail(Convert.ToInt32(cmbUserType.SelectedValue),Convert.ToInt32(cmbStates.SelectedValue),Convert.ToString(cmbTestName.SelectedValue));		
//		}

		protected void cmbTestName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDetail(Convert.ToInt32(cmbUserType.SelectedValue),Convert.ToInt32(cmbStates.SelectedValue),Convert.ToString(cmbTestName.SelectedValue));
		}

	}
}
