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
using Common;
using System.Text;
using BusinessLayer;
using System.Configuration;


namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for GeneratePinNo.
	/// </summary>
	public partial class GeneratePinNo : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			/*
			//Common.CLCommonFunctions.CheckSession();
			//added by ankit
			ddlTestState.Attributes.Add("onchange","populate(); FillHiddenField();");
			//Populating ddlTestCentre on selection of ddlTestCity through javascript.
			ddlTestCity.Attributes.Add("onchange"," populateCentre(); FillHiddenField();");
			//Populate test
			ddlTestCentre.Attributes.Add("onchange"," populateTest(); FillHiddenField();");
			ddlTest.Attributes.Add("onchange","FillHiddenField();");
			//added by ankit end
			*/
			if (Convert.ToInt64(HttpContext.Current.Session["UserType"]) != 2)
			{
				Response.Redirect("../default.aspx");
			}
			btnSubmit.Attributes.Add("onclick","return Validatedata('"+txtNoOfPinNo.ClientID+"');");

			if(!Page.IsPostBack)
			{		
				/*
				//Added by ankit
				//Populating ddlTestCity and ddlTestCentre besad on state id.
				GenerateDynamicDropdown();			 
				//Populating ddlTestCentre on selection of ddlTestCity.
				GenerateCityDropdown();
				//Populating ddlTest on selection of ddlTestCentre.
				GenerateTestDropdown();
				//Populating ddlTestCity
				FillTestCity();
				//Populating ddlTestCentre
				FillTestCentre();
				//Populating ddlTestState
				FillTestState();
				//populating Tests
				FillTest();
				//added by ankit end
				*/
				FillRegistrationPinRecord();
				

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
			this.dgRegistrationPin.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRegistrationPin_ItemCommand);

		}
		#endregion

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			
				String strNoOfPinNo = txtNoOfPinNo.Text.Trim();
				Int32 i32NoOfPinNo = Convert.ToInt32(strNoOfPinNo);
				Int32 i32Counter = 0;
				String tmpPinNo = "";
				string argPinNo = "";
				int StartId=0,EndId=0;
				DataSet tempDS=new DataSet(); 
			
				ArrayList arNewPinNo = new ArrayList(i32NoOfPinNo);
				ArrayList arUsedId = new ArrayList();
			
				BusinessLayer.BLRegistration objRegistration = new BusinessLayer.BLRegistration();
				arUsedId = objRegistration.FetchPinNo();

				while (i32Counter < i32NoOfPinNo)
				{
					String strPinNo = PasswordGenerator.Generate(10,10);
					if ((!arUsedId.Contains(strPinNo))&&(!arNewPinNo.Contains(strPinNo)))
					{
						tmpPinNo = tmpPinNo + "--" + strPinNo;
						arNewPinNo.Add(strPinNo);
						i32Counter++;
					}
				}
				int valChkLoop = 0;
				int valLoopLimit = Convert.ToInt32(ConfigurationSettings.AppSettings["PinNoLimit"].ToString());
				for(int i = 0; i <= arNewPinNo.Count - 1; i++)
				{
					valChkLoop = valChkLoop + 1;
					if (argPinNo == "")
					{
						argPinNo = arNewPinNo[i].ToString();
					}
					else
					{
						argPinNo = argPinNo +","+ arNewPinNo[i].ToString();
					}
					if (valChkLoop == valLoopLimit)
					{
						valChkLoop = 0;
						objRegistration.PinNo = argPinNo + ",";
						objRegistration.TestId=Convert.ToInt32(ddlTestName.SelectedValue);
						tempDS=objRegistration.AddPinNo();
						if (StartId ==0)					
						{
							StartId=Convert.ToInt32(tempDS.Tables[0].Rows[0][0]);  
						}
						EndId=Convert.ToInt32(tempDS.Tables[0].Rows[0][1]); 
						argPinNo = "";
					}
				
				}
				if(argPinNo!="")
				{
					objRegistration.PinNo = argPinNo + ",";
					objRegistration.TestId=Convert.ToInt32(ddlTestName.SelectedValue);
					tempDS=objRegistration.AddPinNo();
					if (StartId ==0)					
					{
						StartId=Convert.ToInt32(tempDS.Tables[0].Rows[0][0]);  
					}
					EndId=Convert.ToInt32(tempDS.Tables[0].Rows[0][1]); 
				}			
				objRegistration.AddPinNoRecord(StartId,EndId);
				argPinNo = "";
				lblMessage.Text = "Registration ID successfully generated...";			
			
				FillRegistrationPinRecord();
			string jScript;
			jScript = "<Script Language=Javascript>alert('Userid/Passwords generated successfully');window.location.href='../Web/GeneratePinNo.aspx';</Script>";
			Page.RegisterStartupScript("keyClientBlock", jScript);
			//Response.Redirect("GeneratePinNo.aspx"); 
		}

	


		#region FillRegistrationPinRecord()

		private void FillRegistrationPinRecord()
		{
			try
			{
				BusinessLayer.BLRegistration oBLRegistration = new BLRegistration();
				DataView dvRegistration = new DataView();
				dvRegistration = oBLRegistration.FillRegistrationPinRecord().DefaultView; 
				

				if(dvRegistration.Count > 0)
				{
					dgRegistration.Visible=true;
					dgRegistrationPin.DataSource = dvRegistration;
					dgRegistrationPin.DataBind();
				}
				else
				{					
					dgRegistration.Visible=false;				
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}
		#endregion

		private void dgRegistrationPin_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "ExportToExcel")
			{
				Response.Redirect("RegistrationPinListToExcel.aspx?RecordId="+Convert.ToString(e.Item.Cells[0].Text));				
			}
		}

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

		#region FillState()

		private DataTable FillState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			return objBLRegistration.FillState();			 
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

		#region GenerateTestDropdown()

		private void GenerateTestDropdown()
		{
			   
			DataTable dtTestCentre = new DataTable();
			DataTable dtTest = new DataTable();
			  

			StringBuilder sbAppend = new StringBuilder();
			int intInnerIncrementLoop = 0;
			int intOuterIncrementLoop = 0;
			int intParentRowCount = 0;
			int intChildRowCount = 0;
			  
			  

			BLRegistration objBLRegistration = new BLRegistration();

			dtTestCentre = objBLRegistration.FillCentre();
			dtTest = objBLRegistration.FillTestEvent();

			sbAppend.Append("<script language='javascript' type='text/javascript'> ");	
			sbAppend.Append("function populateTest(){ ");
			sbAppend.Append("var store = new Array(); ");
			sbAppend.Append("store[0] = new Array('Select','0'); ");
 			
 			if(dtTest != null && dtTestCentre != null)
			{
				intParentRowCount = dtTestCentre.Rows.Count;
				intChildRowCount = dtTest.Rows.Count;
 
				if(intParentRowCount > 0 && intChildRowCount > 0)
				{
					for(intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
					{
						sbAppend.Append("store[");
						sbAppend.Append(Convert.ToInt32(dtTestCentre.Rows[intOuterIncrementLoop]["CentreId"].ToString().Trim())); 
						sbAppend.Append("] = new Array(");
					 
						for(intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
						{
							if(intInnerIncrementLoop == 0)
							{
								sbAppend.Append("'Select','0',");
								 
							}
							if(Convert.ToInt32(dtTest.Rows[intInnerIncrementLoop]["TestCentre"].ToString().Trim()) == Convert.ToInt32(dtTestCentre.Rows[intOuterIncrementLoop]["CentreId"].ToString().Trim()))
							{

								sbAppend.Append("'");
								sbAppend.Append(dtTest.Rows[intInnerIncrementLoop]["Name"].ToString().Trim());
								sbAppend.Append("'"); 		
								sbAppend.Append(",");
								sbAppend.Append("'");
								sbAppend.Append(dtTest.Rows[intInnerIncrementLoop]["TestId"].ToString().Trim());
								sbAppend.Append("'"); 
								sbAppend.Append(",");
								 					 
							}

						}


						sbAppend.Remove(sbAppend.Length - 1,1);
						sbAppend.Append(");"); 
 			
					} 		 
 
					sbAppend.Append("var box = document.getElementById('ddlTestCentre'); ");
					sbAppend.Append("var number = box.options[box.selectedIndex].value; ");
					sbAppend.Append("if (!number) return;");
					sbAppend.Append("var list = store[number];");
					sbAppend.Append("var box2 = document.getElementById('ddlTest'); ");
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

		#region FillTest()
		//Populating ddlTest Combo box.
		private void FillTest()
		{
			try
			{
				//Creating instance of Datatable.
				DataTable dtTest = new DataTable();
				//Adding "Center" as column in dtTestCenter DataTable.
				dtTest.Columns.Add("Name");
				//Adding "CenterId" as column in dtTestCenter DataTable.
				dtTest.Columns.Add("TestId"); 
				//Creating object of datarow.
				DataRow drNewRow;
				//Initializing srNewRow
				drNewRow = dtTest.NewRow();
				//Inserting initial value in "Center" column
				drNewRow["Name"] = "Select";
				//Inserting initial value in "CenterId" column
				drNewRow["TestId"] = "0";
				//Adding dtNewRow in dtTestCenter(Datatable)
				dtTest.Rows.Add(drNewRow);				
				//Passing ddlTestCentre drop down in BindDropDown to bind with dtTestCentre.
				BindDropDown(ref ddlTestName, dtTest,"Name","TestId");
			}
			catch(Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
			
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
}