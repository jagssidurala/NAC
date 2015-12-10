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
	public class CenterDetailsTemp : System.Web.UI.Page
	{
	
		protected System.Web.UI.WebControls.DropDownList ddlcenter;
		protected System.Web.UI.WebControls.DropDownList ddlCenter;
		protected System.Web.UI.WebControls.Button btnAddCity;
		protected System.Web.UI.WebControls.Button btnAddCenter;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCity1;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCity2;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCity3;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCentre1;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCentre2;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvCentre3;


		protected System.Web.UI.HtmlControls.HtmlInputHidden hdCentre;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdCity;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdState;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtCityName;
		protected System.Web.UI.WebControls.TextBox txtCityCode;
		protected System.Web.UI.WebControls.TextBox txtCenterName;
		protected System.Web.UI.WebControls.TextBox txtCenterCapacity;
		protected System.Web.UI.WebControls.TextBox txtCenterCode;
		protected System.Web.UI.WebControls.TextBox txtCenterAddress;
		protected System.Web.UI.WebControls.TextBox txtStateName;
		protected System.Web.UI.WebControls.TextBox txtStateCode;
		protected System.Web.UI.WebControls.CheckBox chkETSAccess;
		protected System.Web.UI.WebControls.Image imgState;
		protected System.Web.UI.WebControls.DataGrid dgCentre;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr1;
		protected System.Web.UI.WebControls.Button btnAddTestDetails;
		protected System.Web.UI.WebControls.Button btnModifyCity;
		protected System.Web.UI.WebControls.Button btnModifyCenter;
		protected System.Web.UI.WebControls.DropDownList ddlTestcity;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblSubmitMessage;
		protected System.Web.UI.WebControls.Label lblGrid;
		public string str;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			str =Request.QueryString["StateId"].ToString();		

			if(!Page.IsPostBack)
			{
				dvCity1.Visible=false;
				dvCity2.Visible=false;
				dvCity3.Visible=false;
				FillStateDetails();
				FillCityAgainstState();			 
				FillCentreGrid();

				dvCity1.Visible=false;
				dvCity2.Visible=false;
				dvCity3.Visible=false;
				dvCentre1.Visible=false;
				dvCentre2.Visible=false;
				dvCentre3.Visible=false;
			}
			
			
		}

		#region FillStateDetails()
		private void FillStateDetails()
		{
			DataTable dtDataTable;
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			objBLCentreDetails.StateId = str.ToString().Trim();
			dtDataTable=objBLCentreDetails.GetStateDetails();

			txtStateName.Text=dtDataTable.Rows[0][1].ToString().Trim();
			txtStateCode.Text=dtDataTable.Rows[0][2].ToString().Trim();
			imgState.ImageUrl ="Images/"+dtDataTable.Rows[0][3].ToString().Trim();
			string strETS =Convert.ToString(dtDataTable.Rows[0][4]);
			if (strETS=="True")
			{
				chkETSAccess.Checked=true; 
			}
			else
			{
				chkETSAccess.Checked=false;
			}

		
		 }
		#endregion

		#region FillCentreGrid()
		private void FillCentreGrid()
		{
			DataTable dtDataTable;
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			objBLCentreDetails.StateId = str.ToString().Trim();
			dtDataTable=objBLCentreDetails.GetCentreDetails();
			if(dtDataTable.Rows.Count==0)
			{
				lblGrid.Visible=true;
				dgCentre.Visible=false; 
			}
			else
			{
				
				lblGrid.Visible=false;
				dgCentre.Visible=true;
				dgCentre.DataSource=dtDataTable;
				dgCentre.DataBind(); 
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
			this.ddlTestcity.SelectedIndexChanged += new System.EventHandler(this.ddlTestcity_SelectedIndexChanged);
			this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
			this.btnModifyCity.Click += new System.EventHandler(this.btnModifyCity_Click);
			this.btnAddCenter.Click += new System.EventHandler(this.btnAddCenter_Click);
			this.btnModifyCenter.Click += new System.EventHandler(this.btnModifyCenter_Click);
			this.btnAddTestDetails.Click += new System.EventHandler(this.btnAddTestDetails_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region FillCityAgainstState()

		private void FillCityAgainstState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();
			objBLRegistration.StateId = Convert.ToInt32(str.ToString().Trim());			
			BindDropDown(ref ddlTestcity, objBLRegistration.FillCityAgainstState(),"City","CityId");		
			if(ddlTestcity.Items.Count==0)
			{
				btnModifyCity.Enabled=false; 
				btnAddCenter.Enabled=false;
				btnModifyCenter.Enabled=false; 
				btnAddTestDetails.Enabled=false;  
				 
			}
			else
			{
				btnModifyCity.Enabled=true; 
				btnAddCenter.Enabled=true;


			}
			//Filling center on basis of city
			FillCenterAgainstCity(); 
		}

		#endregion

		#region FillCenterAgainstCity()

		private void FillCenterAgainstCity()
		{	
			BLRegistration objBLRegistration = new BLRegistration();
			if(ddlTestcity.Items.Count>0)
			{
				btnAddCenter.Enabled=true; 
				objBLRegistration.CityId = Convert.ToInt32(ddlTestcity.SelectedItem.Value.ToString().Trim());			
				BindDropDown(ref ddlCenter, objBLRegistration.FillCenterAgainstCity(),"Centre","CentreId");			 

				if(ddlCenter.Items.Count==0)
				{					
					btnModifyCenter.Enabled=false; 
					btnAddTestDetails.Enabled=false;  
				}
				else
				{
					btnModifyCenter.Enabled=true; 
					btnAddTestDetails.Enabled=true;  
				}
			}
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

		#region btnAddCity_Click()
		private void btnAddCity_Click(object sender, System.EventArgs e)
		{
			dvCity1.Visible=true;
			dvCity2.Visible=true;
			dvCity3.Visible=true;
			dvCentre1.Visible=false;
			dvCentre2.Visible=false;
			dvCentre3.Visible=false;
			txtCenterName.Text="";
			txtCenterCapacity.Text="";
			txtCenterCode.Text="";
			txtCenterAddress.Text="";
			ViewState["Mode"]="insert";
			ViewState["Module"]="City";
			btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateCityData();");
			lblMessage.Visible=false; 
			lblSubmitMessage.Visible=false;

		}
		#endregion

		#region ddlTestcity_SelectedIndexChanged

		private void ddlTestcity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillCenterAgainstCity(); 		
		}
		#endregion

		# region btnSubmit_Click
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();					

			if(ViewState["Module"].ToString() =="City")
			{
				if(ViewState["Mode"].ToString() =="insert")
				{
					//Inserting  City Details
					objBLCentreDetails.CityCode=txtCityCode.Text.ToString().Trim ();
					objBLCentreDetails.CityName=txtCityName.Text.ToString().Trim ();		
					objBLCentreDetails.StateId=str;	
					objBLCentreDetails.CityId="0";	
					objBLCentreDetails.Flag = ViewState["Mode"].ToString();
					objBLCentreDetails.UpdateCityDetail();
					
				}
				else
				{
					//Inserting  City Details
					objBLCentreDetails.CityCode=txtCityCode.Text.ToString().Trim ();
					objBLCentreDetails.CityName=txtCityName.Text.ToString().Trim ();		
					objBLCentreDetails.StateId=str;	
					objBLCentreDetails.CityId=ddlTestcity.SelectedItem.Value.ToString();	
					objBLCentreDetails.Flag = ViewState["Mode"].ToString();
					objBLCentreDetails.UpdateCityDetail();					

				}
				//Populating states again
				FillCityAgainstState();	
			}
			else
			{
				if(ViewState["Mode"].ToString()=="insert")
				{
					//Inserting  Centre Details
					objBLCentreDetails.Centre=txtCenterName.Text.ToString().Trim ();
					objBLCentreDetails.CentreCapacity=txtCenterCapacity.Text.ToString().Trim ();		
					objBLCentreDetails.CentreCode=txtCenterCode.Text.ToString().Trim ();		
					objBLCentreDetails.CityId = ddlTestcity.SelectedItem.Value.ToString().Trim();							
					objBLCentreDetails.Flag = ViewState["Mode"].ToString();
					objBLCentreDetails.CentreAddress=txtCenterAddress.Text.ToString().Trim ();		 
					objBLCentreDetails.CentreId="0";				
					objBLCentreDetails.UpdateCentreDetail();
					
				}
				else
				{
					objBLCentreDetails.Centre=txtCenterName.Text.ToString().Trim ();
					objBLCentreDetails.CentreCapacity=txtCenterCapacity.Text.ToString().Trim ();		
					objBLCentreDetails.CentreCode=txtCenterCode.Text.ToString().Trim ();		
					objBLCentreDetails.CityId = ddlTestcity.SelectedItem.Value.ToString().Trim();							
					objBLCentreDetails.Flag = ViewState["Mode"].ToString();
					objBLCentreDetails.CentreAddress=txtCenterAddress.Text.ToString().Trim ();		 
					objBLCentreDetails.CentreId=ddlCenter.SelectedItem.Value.ToString();				
					objBLCentreDetails.UpdateCentreDetail();
				}
				//Populating states again
				FillCenterAgainstCity();	
				FillCentreGrid();
			}
			lblSubmitMessage.Visible=true;
			lblSubmitMessage.Text="Records added successfully";
			lblMessage.Visible=false; 
 

			ViewState["Mode"]="";
		
		}
		#endregion

		#region btnAddCenter_Click
		private void btnAddCenter_Click(object sender, System.EventArgs e)
		{			
			dvCity1.Visible=false;
			dvCity2.Visible=false;
			dvCity3.Visible=false;
			dvCentre1.Visible=true;
			dvCentre2.Visible=true;
			dvCentre3.Visible=true;

			txtCityCode.Text="";
			txtCityName.Text="";
			ViewState["Module"]="Centre";
			ViewState["Mode"]="insert";
			btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateCentreData();");
			lblMessage.Visible=false; 
			lblSubmitMessage.Visible=false;		
		}
		#endregion

		#region btnAddTestDetails_Click
		private void btnAddTestDetails_Click(object sender, System.EventArgs e)
		{
			if(ddlCenter.Items.Count>0 && ddlCenter.SelectedItem.Value.ToString()!="0")
			Response.Redirect("TestDetailsTemp.aspx?CentreId="+ddlCenter.SelectedItem.Value.ToString().Trim());
		}
		# endregion

		#region btnModifyCity_Click
		private void btnModifyCity_Click(object sender, System.EventArgs e)
		{
			
			if(ddlTestcity.SelectedItem.Value.ToString()!="0")
			{
				dvCity1.Visible=true;
				dvCity2.Visible=true;
				dvCity3.Visible=true;
				dvCentre1.Visible=false;
				dvCentre2.Visible=false;
				dvCentre3.Visible=false;
				
				ViewState["Module"]="City";
				ViewState["Mode"]="update";
				DataTable dtDataTable;
				BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			
				btnSubmit.Visible=true; 


				objBLCentreDetails.CityId=ddlTestcity.SelectedItem.Value.ToString().Trim ();
				dtDataTable=objBLCentreDetails.GetCityDetails_CityId();

				txtCityName.Text=dtDataTable.Rows[0][1].ToString().Trim();
				txtCityCode.Text=dtDataTable.Rows[0][2].ToString().Trim();
				btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateCityData();");				
				lblMessage.Visible=false; 
			}
			else
			{
				lblMessage.Visible=true;
				lblMessage.Text="City not selected"; 
			}
			lblSubmitMessage.Visible=false; 


		}
		#endregion

		#region btnModifyCenter_Click
		private void btnModifyCenter_Click(object sender, System.EventArgs e)
		{
			if(ddlCenter.SelectedItem.Value.ToString()!="0")
			{
				dvCity1.Visible=false;
				dvCity2.Visible=false;
				dvCity3.Visible=false;
				dvCentre1.Visible=true;
				dvCentre2.Visible=true;
				dvCentre3.Visible=true;

				ViewState["Mode"]="update";
				ViewState["Module"]="Centre";
				DataTable dtDataTable;
				BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			
				btnSubmit.Visible=true; 


				objBLCentreDetails.CentreId=ddlCenter.SelectedItem.Value.ToString().Trim ();
				dtDataTable=objBLCentreDetails.GetCentreDetails_CentreId();

				txtCenterName.Text=dtDataTable.Rows[0]["Centre"].ToString().Trim();
				txtCenterCapacity.Text=dtDataTable.Rows[0]["Capacity"].ToString().Trim();
				txtCenterCode.Text=dtDataTable.Rows[0]["CentreCode"].ToString().Trim();
				txtCenterAddress.Text=dtDataTable.Rows[0]["CentreAddress"].ToString().Trim();
				btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateCentreData();");	
				lblMessage.Visible=false; 
			}
			else
			{
				lblMessage.Visible=true;		
				lblMessage.Text="Centre not selected.";
			}
			lblSubmitMessage.Visible=false;		
		
		}
#endregion

	

		
	}
}
