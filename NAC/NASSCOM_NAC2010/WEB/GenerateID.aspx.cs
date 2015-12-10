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
	#region Class GenerateID
	/// <summary>
	/// Summary description for GenerateRegistration.
	/// </summary>
	public partial class GenerateID : System.Web.UI.Page
	{

		#region WebControls


		#endregion
	
		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick","javascript:return Validatedata();");
			//Populating ddlTestCity on selection of ddlTestCenter through javascript.
			//ddlTestState.Attributes.Add("onchange","populate(); FillHiddenField();");
			//Populating ddlTestCentre on selection of ddlTestCity through javascript.
			//ddlTestCity.Attributes.Add("onchange"," populateCentre(); FillHiddenField();");
			//Populating hdState, hdCity and hdCentre fields on selection of ddlTestCentre.
			//ddlTestCentre.Attributes.Add("onchange","FillHiddenField();");
			if (Convert.ToInt64(HttpContext.Current.Session["UserType"]) != 2)
			{
				Response.Redirect("../default.aspx");
			}
			if(!Page.IsPostBack)
			{
				//Populating ddlTestState
				FillTestState();
				//Populating ddlTestCity
				FillTestCity();
				//Populating ddlTestCentre
				FillTestCentre();
				//Populating ddlTestName
				FillTestName();
			 
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

		}
		#endregion

		#region btnSubmit_Click()

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			BLRegistration objBLRegistration = new BLRegistration();				
            objBLRegistration.StateId = Convert.ToInt32(ddlTestState.SelectedValue);
            objBLRegistration.CityId = Convert.ToInt32(ddlTestCity.SelectedValue);
			objBLRegistration.CentreId = Convert.ToInt32(ddlTestCentre.SelectedValue);			
			objBLRegistration.TestId = Convert.ToInt32(ddlTestName.SelectedValue);			
			objBLRegistration.NumberOfRegistration = Convert.ToInt32(txtNumberofregistration.Text);
			//objBLRegistration.TestId = 
			objBLRegistration.AddRegistrationID();
			if (objBLRegistration.RegistrationMessage == 2)
			{
				lblMessage.Text = "This centre is currently not active...";
				//txtRegistrationStartFrom.Text = "";
			}
			else if (objBLRegistration.RegistrationMessage == 0)
			{
				lblMessage.Text = "The Start Registration ID is already exists.";
				//txtRegistrationStartFrom.Text = "";
			}
			else
			{
				lblMessage.Text = "Registration ID successfully generated";
			}
			//SetStateCityCentreDropDown();
		}


		#endregion

		#region FillTestCentre()
		//Populating ddlTestCentre Combo box.
		private void FillTestCentre()
		{
			try
			{
				//Creating instance of Datatable.
				DataTable dtTestCentre = new DataTable();
				//Adding "Center" as column in dtTestCenter DataTable.
				dtTestCentre.Columns.Add("Centre");
				//Adding "CenterId" as column in dtTestCenter DataTable.
				dtTestCentre.Columns.Add("CentreId"); 
				//Creating object of datarow.
				DataRow drNewRow;
				//Initializing srNewRow
				drNewRow = dtTestCentre.NewRow();
				//Inserting initial value in "Center" column
				drNewRow["Centre"] = "Select";
				//Inserting initial value in "CenterId" column
				drNewRow["CentreId"] = "0";
				//Adding dtNewRow in dtTestCenter(Datatable)
				dtTestCentre.Rows.Add(drNewRow);				
				//Passing ddlTestCentre drop down in BindDropDown to bind with dtTestCentre.
				BindDropDown(ref ddlTestCentre, dtTestCentre,"Centre","CentreId");
				ddlTestCentre.SelectedIndex=0;
			}
			catch(Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
			
		}

		#endregion

		#region FillTestCity()

		private void FillTestCity()
		{	
			//int intStateId;
			//intStateId = 1;
			//BLRegistration objBLRegistration = new BLRegistration();			 
			//BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId),"City","CityId");
			//return objBLRegistration.FillTestCity(intStateId);
			DataTable dtTestCity = new DataTable();
			dtTestCity.Columns.Add("City");
			dtTestCity.Columns.Add("CityId"); 
			DataRow drNewRow;
			drNewRow = dtTestCity.NewRow();
			drNewRow["City"] = "Select";
			drNewRow["CityId"] = "0";
			dtTestCity.Rows.Add(drNewRow);
			BindDropDown(ref ddlTestCity, dtTestCity,"City","CityId");
			ddlTestCity.SelectedIndex=0;
		}

		#endregion	
	 
		#region FillTestCitySecond()
		private void FillTestCitySecond(int intStateId)
		{	
			 
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId),"City","CityId");
			  
		}

		#endregion

		#region FillTestCentreSecond()

		private void FillTestCentreSecond(int intCityId)
		{	
			 
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecond(intCityId),"Centre","CentreId");
			  
		}

		#endregion

		#region FillTestNameSecond()
		private void FillTestNameSecond(int intCentreId)
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestName, objBLRegistration.FillTestNameSecond(intCentreId),"Name","TestId");
		}

		#endregion

		#region FillCity()

		private DataTable FillCity()
		{				 
			BLRegistration objBLRegistration = new BLRegistration();			 
			return objBLRegistration.FillCity();			 
		}

		#endregion

		#region FillCentre()

		private DataTable FillCentre()
		{			 
			 
			BLRegistration objBLRegistration = new BLRegistration();			 
			//BindDropDown(ref ddlTestCentre, objBLRegistration.FillCentre(),"Centre","CentreId");	
			return objBLRegistration.FillCentre();
		}

		#endregion

		#region FillTestState()

		private void FillTestState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(),"State","StateId");			 
		}

		#endregion

		#region FillState()

		private DataTable FillState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			return objBLRegistration.FillState();			 
		}

		#endregion	

		#region FillTestName()
		//Populating ddlTestEvent Combo box.
		private void FillTestName()
		{
			try
			{
				//Creating instance of Datatable.
				DataTable dtTestName = new DataTable();
				//Adding "Center" as column in dtTestCenter DataTable.
				dtTestName.Columns.Add("Name");
				//Adding "CenterId" as column in dtTestCenter DataTable.
				dtTestName.Columns.Add("TestId"); 
				//Creating object of datarow.
				DataRow drNewRow;
				//Initializing srNewRow
				drNewRow = dtTestName.NewRow();
				//Inserting initial value in "Center" column
				drNewRow["Name"] = "Select";
				//Inserting initial value in "CenterId" column
				drNewRow["TestId"] = "0";
				//Adding dtNewRow in dtTestCenter(Datatable)
				dtTestName.Rows.Add(drNewRow);				
				//Passing ddlTestCentre drop down in BindDropDown to bind with dtTestCentre.
				BindDropDown(ref ddlTestName, dtTestName,"Name","TestId");
				ddlTestName.SelectedIndex=0;
			}
			catch(Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
			
		}


		#endregion

		#region GenerateDynamicDropdown()

		private void GenerateDynamicDropdown()
		{
			   
			DataTable dtTestState = new DataTable();
			DataTable dtTestCity = new DataTable();
			  

			StringBuilder sbAppend = new StringBuilder();
			int intInnerIncrementLoop = 0;
			int intOuterIncrementLoop = 0;
			int intParentRowCount = 0;
			int intChildRowCount = 0;			  

			dtTestState = FillState();
			dtTestCity = FillCity();

			sbAppend.Append("<script language='javascript' type='text/javascript'> ");
			sbAppend.Append("function populate(){ ");
			sbAppend.Append("var store = new Array(); ");
			sbAppend.Append("store[0] = new Array('Select','0'); ");
 			
 
			if(dtTestState != null && dtTestCity != null)
			{
				intParentRowCount = dtTestState.Rows.Count;
				intChildRowCount = dtTestCity.Rows.Count;
 
				if(intParentRowCount > 0 && intChildRowCount > 0)
				{
					for(intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
					{
						sbAppend.Append("store[");
						sbAppend.Append(Convert.ToInt32(dtTestState.Rows[intOuterIncrementLoop]["StateId"].ToString().Trim())); 
						sbAppend.Append("] = new Array(");
					 
						for(intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
						{
							if(intInnerIncrementLoop == 0)
							{
								sbAppend.Append("'Select','0',");
								 
							}
							if(Convert.ToInt32(dtTestState.Rows[intOuterIncrementLoop]["StateId"].ToString().Trim()) == Convert.ToInt32(dtTestCity.Rows[intInnerIncrementLoop]["StateId"].ToString().Trim()))
							{

								sbAppend.Append("'");
								sbAppend.Append(dtTestCity.Rows[intInnerIncrementLoop]["City"].ToString().Trim());
								sbAppend.Append("'");
								sbAppend.Append(",");
								sbAppend.Append("'");
								sbAppend.Append(dtTestCity.Rows[intInnerIncrementLoop]["CityId"].ToString().Trim());
								sbAppend.Append("'"); 
								sbAppend.Append(",");
								 					 
							}

						}


						sbAppend.Remove(sbAppend.Length - 1,1);
						sbAppend.Append(");"); 
 			
					} 		 
 
					sbAppend.Append("var box = document.getElementById('ddlTestState'); ");
					sbAppend.Append("var number = box.options[box.selectedIndex].value; ");					 
					sbAppend.Append("if (!number) return;");
					sbAppend.Append("var list = store[number];");
					sbAppend.Append("var box2 = document.getElementById('ddlTestCity'); ");
					sbAppend.Append("var box3 = document.getElementById('ddlTestCentre'); ");
					sbAppend.Append("box2.options.length = 0; ");
					sbAppend.Append("box3.options.length = 0; ");
					sbAppend.Append("box3.options[0] = new Option(list[0],list[1]); ");
					sbAppend.Append("for(i=0;i<list.length;i+=2){ ");
					sbAppend.Append("box2.options[i/2] = new Option(list[i],list[i+1]); ");
					sbAppend.Append("} ");	
					 
				 
					sbAppend.Append("}</script> "); 
					Response.Write(sbAppend.ToString());
				}
			}


		}


		#endregion

		#region GenerateCityDropdown()

		private void GenerateCityDropdown()
		{
			   
			DataTable dtTestCentre = new DataTable();
			DataTable dtTestCity = new DataTable();
			  

			StringBuilder sbAppend = new StringBuilder();
			int intInnerIncrementLoop = 0;
			int intOuterIncrementLoop = 0;
			int intParentRowCount = 0;
			int intChildRowCount = 0;
			  
			  

			BLRegistration objBLRegistration = new BLRegistration();

			dtTestCentre = objBLRegistration.FillCentre();
			dtTestCity = FillCity();

			sbAppend.Append("<script language='javascript' type='text/javascript'> ");	
			sbAppend.Append("function populateCentre(){ ");
			sbAppend.Append("var store = new Array(); ");
			sbAppend.Append("store[0] = new Array('Select','0'); ");
 			
 
			if(dtTestCentre != null && dtTestCity != null)
			{
				intParentRowCount = dtTestCity.Rows.Count;
				intChildRowCount = dtTestCentre.Rows.Count;
 
				if(intParentRowCount > 0 && intChildRowCount > 0)
				{
					for(intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
					{
						sbAppend.Append("store[");
						sbAppend.Append(Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim())); 
						sbAppend.Append("] = new Array(");
					 
						for(intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
						{
							if(intInnerIncrementLoop == 0)
							{
								sbAppend.Append("'Select','0',");
								 
							}
							if(Convert.ToInt32(dtTestCentre.Rows[intInnerIncrementLoop]["CityId"].ToString().Trim()) == Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim()))
							{

								sbAppend.Append("'");
								sbAppend.Append(dtTestCentre.Rows[intInnerIncrementLoop]["Centre"].ToString().Trim());
								sbAppend.Append("'"); 		
								sbAppend.Append(",");
								sbAppend.Append("'");
								sbAppend.Append(dtTestCentre.Rows[intInnerIncrementLoop]["CentreId"].ToString().Trim());
								sbAppend.Append("'"); 
								sbAppend.Append(",");
								 					 
							}

						}


						sbAppend.Remove(sbAppend.Length - 1,1);
						sbAppend.Append(");"); 
 			
					} 		 
 
					sbAppend.Append("var box = document.getElementById('ddlTestCity'); ");
					sbAppend.Append("var number = box.options[box.selectedIndex].value; ");
					sbAppend.Append("if (!number) return;");
					sbAppend.Append("var list = store[number];");
					sbAppend.Append("var box2 = document.getElementById('ddlTestCentre'); ");
					sbAppend.Append("box2.options.length = 0; ");
					sbAppend.Append("for(i=0;i<list.length;i+=2){ ");
					sbAppend.Append("box2.options[i/2] = new Option(list[i],list[i+1]); ");
					sbAppend.Append("} ");	
					 
				 
					sbAppend.Append("}</script> "); 
					Response.Write(sbAppend.ToString());
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

		#region SetStateCityCentreDropDown()

		private void SetStateCityCentreDropDown()
		{		 
			GenerateDynamicDropdown();		 
			GenerateCityDropdown();			
			ddlTestState.SelectedValue = hdState.Value.ToString().Trim();
			FillTestCitySecond(Convert.ToInt32(hdState.Value.ToString().Trim()));
			ddlTestCity.SelectedValue = hdCity.Value.ToString().Trim();
			FillTestCentreSecond(Convert.ToInt32(hdCity.Value.ToString().Trim()));
			ddlTestCentre.SelectedValue = hdCentre.Value.ToString().Trim();
			
		}

		#endregion

		#region FillTestCity On ddlTestState_SelectedIndexChanged
		protected void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestState.SelectedValue != null || ddlTestState.SelectedValue != "0")
			{
				FillTestCitySecond(Convert.ToInt32(ddlTestState.SelectedValue.ToString()));
			}
			else
			{
				//Populating ddlTestCity
				FillTestCity();
			}
			//Populating ddlTestCentre
			FillTestCentre();
			//Populating ddlTestName
			FillTestName();
		}
				#endregion

		#region FillTestCentre On ddlTestCity_SelectedIndexChanged
		protected void ddlTestCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestCity.SelectedValue != null || ddlTestCity.SelectedValue != "0")
			{
				FillTestCentreSecond(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
			}
			else
			{
				//Populating ddlTestCentre
				FillTestCentre();
			}
			//Populating ddlTestEvent
			FillTestName();
		}
		#endregion

		#region FillTestName On ddlTestCentre_SelectedIndexChanged
		protected void ddlTestCentre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestCentre.SelectedValue != null || ddlTestCentre.SelectedValue != "0")
			{
				FillTestNameSecond(Convert.ToInt32(ddlTestCentre.SelectedValue.ToString()));
			}
			else
			{
				//Populating ddlTestName
				FillTestName();
			}
		}
		#endregion
	}

	#endregion
}