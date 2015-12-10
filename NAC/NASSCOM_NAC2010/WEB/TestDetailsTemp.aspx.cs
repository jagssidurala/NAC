using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for CenterDetailsTemp.
	/// </summary>
	public class TestDetailsTemp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlTestCity;
		protected System.Web.UI.WebControls.DropDownList ddlcenter;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCity3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdState;
		protected System.Web.UI.WebControls.DataGrid dgCentre;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.DropDownList ddlDay;
		protected System.Web.UI.WebControls.DropDownList ddlTime;
		protected System.Web.UI.WebControls.CheckBox chkIsActive;
		protected System.Web.UI.WebControls.Button btnSubmitTestDetails;
		protected System.Web.UI.WebControls.Button btnAddTest;
		protected System.Web.UI.WebControls.Button btnAddShiftTime;
		protected System.Web.UI.WebControls.DropDownList ddlTest;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest1;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest2;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest3;
		protected System.Web.UI.HtmlControls.HtmlTableRow dv1;
		protected System.Web.UI.HtmlControls.HtmlTableRow dv2;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest5;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest6;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTest4;
		protected System.Web.UI.WebControls.TextBox txtShiftCapacity;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTime1;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTime2;
		protected System.Web.UI.WebControls.DropDownList ddlShiftDay;
		protected System.Web.UI.WebControls.DropDownList ddlShiftMonth;
		protected System.Web.UI.WebControls.DropDownList ddlShiftYear;
		protected System.Web.UI.WebControls.CheckBox chkIsShiftActive;
		protected System.Web.UI.WebControls.DropDownList ddlSelShiftTime;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTime4;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTime3;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvTime5;
		protected System.Web.UI.WebControls.DropDownList ddlShiftTime;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblSubmitMessage;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr1;
		protected System.Web.UI.WebControls.TextBox txtTestName;
		protected System.Web.UI.WebControls.CheckBox chkIsShiftTime;
		protected System.Web.UI.WebControls.DropDownList ddlRegYear;
		protected System.Web.UI.WebControls.DropDownList ddlRegMonth;
		protected System.Web.UI.WebControls.DropDownList ddlRegDay;
		public string str;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			str =Request.QueryString["CentreId"].ToString();
			if(!Page.IsPostBack)
			{				
				dvTime1.Visible=false;
				dvTime2.Visible=false;
				dvTime3.Visible=false;
				dvTime4.Visible=false;
				dvTime5.Visible=false;			
				dvTest1.Visible=false;
				dvTest2.Visible=false;
				dvTest3.Visible=false;
				dvTest4.Visible=false;
				dvTest5.Visible=false;
				dvTest6.Visible=false;
				btnSubmitTestDetails.Visible=false; 
				FillTestAgainstCentre();
				FillShiftTimeAgainstTest();
			}
			
		}

		#region FillTestAgainstCentre()

		private void FillTestAgainstCentre()
		{	
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			objBLCentreDetails.CentreId = str.ToString().Trim();			
			BindDropDown(ref ddlTest, objBLCentreDetails.FillTestAgainstCentre(),"Name","TestId");
			
		}

		#endregion

		#region FillShiftTimeAgainstTest()

		private void FillShiftTimeAgainstTest()
		{	
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			if(ddlTest.Items.Count>0)
			{
				objBLCentreDetails.TestId = ddlTest.SelectedItem.Value.ToString();   		
				BindDropDown(ref ddlShiftTime, objBLCentreDetails.FillShiftTimeAgainstTest(),"ShiftTime","ShiftId");
			}
			
		}

		#endregion

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
			this.ddlTest.SelectedIndexChanged += new System.EventHandler(this.ddlTest_SelectedIndexChanged);
			this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
			this.btnAddShiftTime.Click += new System.EventHandler(this.btnAddShiftTime_Click);
			this.btnSubmitTestDetails.Click += new System.EventHandler(this.btnSubmitTestDetails_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region BindDropDown()
		/// <summary>
		/// Bind a DropDown with data table.
		/// </summary>
		/// <param name="ddlDropDownList" Type="Input"></param> 
		/// <param name="dtDataTable"></param> 
		/// <param name="strTextField"></param> 
		/// <param name="strValueField"></param>     
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{
			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();
		}

		#endregion

		#region btnSubmitTestDetails_Click()
		private void btnSubmitTestDetails_Click(object sender, System.EventArgs e)
		{
			BLTestDetails objBLTestDetails;
			if (ViewState["Mode"].ToString()=="ShiftTime")
			{
				objBLTestDetails = new BLTestDetails();
				objBLTestDetails.ShiftCapacity=Convert.ToInt32(txtShiftCapacity.Text.ToString().Trim());
				objBLTestDetails.TestId = Convert.ToInt32(ddlTest.SelectedItem.Value.ToString());   		
				objBLTestDetails.ShiftTestTime = Convert.ToDateTime(ddlShiftYear.SelectedValue.ToString() + "-" + ddlShiftMonth.SelectedValue.ToString() + "-" + ddlShiftDay.SelectedValue.ToString() + " " + ddlSelShiftTime.SelectedValue.ToString() + ":00:00.000");
				objBLTestDetails.ShiftTestDate = Convert.ToDateTime(ddlShiftYear.SelectedValue.ToString() + "-" + ddlShiftMonth.SelectedValue.ToString() + "-" + ddlShiftDay.SelectedValue.ToString());
				if(chkIsShiftActive.Checked)
				{
					objBLTestDetails.IsShiftActive = "1";				
				}
				else
				{
					objBLTestDetails.IsShiftActive = "0";
				}
				objBLTestDetails.AddShiftTimeDetail(); 
                FillShiftTimeAgainstTest();
			}
			else
			{
				objBLTestDetails = new BLTestDetails();				
				objBLTestDetails.TestName = txtTestName.Text.ToString().Trim();		
		
				if(chkIsActive.Checked)
				{
					objBLTestDetails.IsActive = "1";				
				}
				else
				{
					objBLTestDetails.IsActive = "0";
				}

				if(chkIsShiftTime.Checked)
				{
					objBLTestDetails.IsShiftTime = "1";				
				}
				else
				{
					objBLTestDetails.IsShiftTime = "0";
				}

				objBLTestDetails.TestTime = Convert.ToDateTime(ddlYear.SelectedValue.ToString() + "-" + ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString() + " " + ddlTime.SelectedValue.ToString() + ":00:00.000");
				objBLTestDetails.TestDate = Convert.ToDateTime(ddlYear.SelectedValue.ToString() + "-" + ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString());
				objBLTestDetails.RegistrationDate = Convert.ToDateTime(ddlRegYear.SelectedValue.ToString() + "-" + ddlRegMonth.SelectedValue.ToString() + "-" + ddlRegDay.SelectedValue.ToString());
				objBLTestDetails.TestCentre = str;
				objBLTestDetails.AddTestDetail();
				FillTestAgainstCentre();
			}

			lblSubmitMessage.Text="Records added successfully";
		
		}

		#endregion

		#region btnAddTest_Click()
		private void btnAddTest_Click(object sender, System.EventArgs e)
		{
			ViewState["Mode"]="TestDetail";

			dvTime1.Visible=false;
			dvTime2.Visible=false;
			dvTime3.Visible=false;
			dvTime4.Visible=false;
			dvTime5.Visible=false;			
			dvTest1.Visible=true;
			dvTest2.Visible=true;
			dvTest3.Visible=true;
			dvTest4.Visible=true;
			dvTest5.Visible=true;
			dvTest6.Visible=true;
			ddlDay.SelectedIndex=0;  
			ddlMonth.SelectedIndex=0;  
			ddlYear.SelectedIndex=0;  
			ddlTime.SelectedIndex=0;  
			ddlRegDay.SelectedIndex=0;  
			ddlRegMonth.SelectedIndex=0;  
			ddlRegYear.SelectedIndex=0;  
			txtTestName.Text="";
			chkIsActive.Checked=false;
			chkIsShiftTime.Checked=false;		
			btnSubmitTestDetails.Visible=true; 
			btnSubmitTestDetails.Attributes.Add("OnClick", "javascript:return ValidateTestData();");

		}
			#endregion

		#region btnAddShiftTime_Click()
		private void btnAddShiftTime_Click(object sender, System.EventArgs e)
		{
			ViewState["Mode"]="ShiftTime";
			dvTest1.Visible=false;
			dvTest2.Visible=false;
			dvTest3.Visible=false;
			dvTest4.Visible=false;
			dvTest5.Visible=false;
			dvTest6.Visible=false;			
			dvTime1.Visible=true;
			dvTime2.Visible=true;
			dvTime3.Visible=true;
			dvTime4.Visible=true;
			dvTime5.Visible=true;
			
			txtShiftCapacity.Text=""; 
			ddlShiftDay.SelectedIndex=0;  
			ddlShiftMonth.SelectedIndex=0;  
			ddlShiftYear.SelectedIndex=0;  
			ddlSelShiftTime.SelectedIndex=0;  
			chkIsShiftActive.Checked=false;  
			btnSubmitTestDetails.Visible=true; 
			btnSubmitTestDetails.Attributes.Add("OnClick", "javascript:return ValidateShiftData();");

		}

			#endregion

		#region ddlTest_SelectedIndexChanged()
		private void ddlTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTest.SelectedIndex>0)
			{
				FillShiftTimeAgainstTest();
			}
		
		}

		#endregion

		
		

	

		
	}
}
