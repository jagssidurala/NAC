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
	/// Summary description for CentreManage.
	/// </summary>
	public partial class CentreManage : System.Web.UI.Page
	{
	
		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnDeactivate.Attributes.Add("OnClick","javascript:return Validatedata();");
			btnActivate.Attributes.Add("OnClick","javascript:return Validatedata();");
			btnSubmit.Attributes.Add("OnClick","javascript:return ValidateDateTime();");
			btnSubmitStart.Attributes.Add("OnClick","javascript:return ValidateDateTimeStart();");

			btnDeactivateStateForETS.Attributes.Add("OnClick","javascript:return ValidateAOrDStateForETS();");

			btnActivateStateForETS.Attributes.Add("OnClick","javascript:return ValidateAOrDStateForETS();");
			//Populating ddlTestCity on selection of ddlTestCenter through javascript.
			ddlTestState.Attributes.Add("onchange","populate(); FillHiddenField();");
			//Populating ddlTestCentre on selection of ddlTestCity through javascript.
			ddlTestCity.Attributes.Add("onchange","populateCentre(); FillHiddenField(); ");
			//Populating hdState, hdCity and hdCentre fields on selection of ddlTestCentre.
			ddlTestCentre.Attributes.Add("onchange","FillHiddenField();");

			 
			if(!Page.IsPostBack)
			{
				//Populating ddlTestCity and ddlTestCentre besad on state id.
				GenerateDynamicDropdown();				 
				//Populating ddlTestCentre on selection of ddlTestCity.
				GenerateCityDropdown();
				//Populating ddlTestCity
				FillTestCity();
				//Populating ddlTestCentre
				FillTestCentre();
				//Populating ddlTestState
				FillTestState();	
				PopulateCentreStatus();
			 
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
			objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());			
			objBLRegistration.RegistrationClosingDate = Convert.ToDateTime(ddlYear.SelectedValue.ToString() + "-" + ddlMonth.SelectedValue.ToString() + "-" + ddlDay.SelectedValue.ToString() + " " + ddlTime.SelectedValue.ToString() + ":00:00.000");
			objBLRegistration.SetRegistrationClosingTime();
			if (objBLRegistration.RegistrationMessage == 2)
			{
				lblMessage.Text = "Registration closing time is successfully set";
				//txtRegistrationStartFrom.Text = "";
			} 
			 
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}


		#endregion

		#region btnSubmitStart_Click()

		protected void btnSubmitStart_Click(object sender, System.EventArgs e)
		{
			BLRegistration objBLRegistration = new BLRegistration();				
			objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());			
			objBLRegistration.RegistrationStartDate = Convert.ToDateTime(ddlStartYear.SelectedValue.ToString() + "-" + ddlStartMonth.SelectedValue.ToString() + "-" + ddlStartDay.SelectedValue.ToString() + " " + ddlStartTime.SelectedValue.ToString() + ":00:00.000");
			objBLRegistration.SetRegistrationStartTime();
			if (objBLRegistration.RegistrationMessage == 2)
			{
				lblMessage.Text = "Registration starting time is successfully set";
				//txtRegistrationStartFrom.Text = "";
			} 
			 
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
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
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecondAdmin(intCityId),"Centre","CentreId");
			  
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

		#region btnDeactivate_Click()

		protected void btnDeactivate_Click(object sender, System.EventArgs e)
		{
			if(chkDeactivateCentre.Checked)
			{
				BLRegistration objBLRegistration = new BLRegistration();				
				objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());
				objBLRegistration.CityId = Convert.ToInt32(hdCity.Value.ToString().Trim());
				objBLRegistration.CentreId = Convert.ToInt32(hdCentre.Value.ToString().Trim());				
				objBLRegistration.DeActivateCentre();
				if (objBLRegistration.RegistrationMessage == 2)
				{
					lblMessage.Text = "This centre is already de-active...";
					//txtRegistrationStartFrom.Text = "";
				}			 
				else
				{
					lblMessage.Text = "Centre De-Activated successfully";
				}
				
			}
			else
			{
			       lblMessage.Text = "First check the Deactivate Centre";
			}

			PopulateCentreStatus();
			SetStateCityCentreDropDown();
			
		}

		#endregion

		#region btnActivate_Click()

		protected void btnActivate_Click(object sender, System.EventArgs e)
		{
			if(chkActivateCentre.Checked)
			{
				BLRegistration objBLRegistration = new BLRegistration();				
				objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());
				objBLRegistration.CityId = Convert.ToInt32(hdCity.Value.ToString().Trim());
				objBLRegistration.CentreId = Convert.ToInt32(hdCentre.Value.ToString().Trim());				
				objBLRegistration.ActivateCentre();
				if (objBLRegistration.RegistrationMessage == 2)
				{
					lblMessage.Text = "This centre is already active...";
					//txtRegistrationStartFrom.Text = "";
				}			 
				else
				{
					lblMessage.Text = "Centre Activated successfully";
				}
				
			}
			else
			{ 
			     lblMessage.Text = "First check the Activate Centre";
			}

			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}


		#endregion
		
		#region btnDeactivateStateForETS_Click()

		protected void btnDeactivateStateForETS_Click(object sender, System.EventArgs e)
		{
			if(chkDeactivateStateForETS.Checked)
			{
				BLRegistration objBLRegistration = new BLRegistration();				
				objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());							
				objBLRegistration.DeActivateStateForETS();
				if (objBLRegistration.RegistrationMessage == 2)
				{
					lblMessage.Text = "This State is already de-active for ETS...";
					//txtRegistrationStartFrom.Text = "";
				}			 
				else
				{
					lblMessage.Text = "State De-Activated for ETS successfully";
				}
				
			}
			else
			{
				lblMessage.Text = "First check the Deactivate State For ETS";
			}

			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

		
		#endregion

		#region btnActivateStateForETS_Click()

		protected void btnActivateStateForETS_Click(object sender, System.EventArgs e)
		{
			if(chkActivateStateForETS.Checked)
			{
				BLRegistration objBLRegistration = new BLRegistration();				
				objBLRegistration.StateId = Convert.ToInt32(hdState.Value.ToString().Trim());						
				objBLRegistration.ActivateStateForETS();
				if (objBLRegistration.RegistrationMessage == 2)
				{
					lblMessage.Text = "This State is already active for ETS...";
					//txtRegistrationStartFrom.Text = "";
				}			 
				else
				{
					lblMessage.Text = "State Activated successfully for ETS";
				}
				
			}
			else
			{ 
				lblMessage.Text = "First check the Activate State For ETS";
			}

			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

		
		#endregion

		#region dgCentreStatus_SortCommand()

		public void dgCentreStatus_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			 
//			strSortExp = e.SortExpression.ToString().Trim();
//
//			if(lblSortExp.Text.ToString().Trim() == strSortExp)
//			{
//				if(strSortExp.IndexOf("ASC") > 0)
//				{
//					strSortExp = strSortExp.Replace("ASC", "DESC");
//				}
//				else if(strSortExp.IndexOf("DESC") > 0)
//				{
//					strSortExp = strSortExp.Replace("DESC", "ASC");
//				}	
//			}			 
//
//			lblSortExp.Text = strSortExp;
//			SetStateCityCentreDropDown();
//			SaveCheckedValueTemporary();
//			//intCurrentPage = dgSearch.CurrentPageIndex + 1;
//			//SetSearchParameter(strSortExp,intCurrentPage);
//			PopulateCandidateList(strSortExp);
			 
		}

		#endregion

		#region dgCentreStatus_PageIndexChanged()

		public void dgCentreStatus_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
//			dgSearch.CurrentPageIndex = e.NewPageIndex;		 
//			intCurrentPage = e.NewPageIndex + 1;
//			SetSearchParameter(strSortExp,intCurrentPage);
//			//PopulateCandidateList(strSortExp);

		}

		
		#endregion
						  
		#region dgCentreStatus_ItemDataBound()

		public void dgCentreStatus_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
//			Hashtable htCheckedValue = new Hashtable();			 
//
//			if(ViewState["CheckedValue"] != null)
//			{
//				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
//			}
//
//			if(e.Item.ItemType == ListItemType.Header)
//			{
//				hdHeaderCheckBox.Value = ((CheckBox) e.Item.FindControl("chkHeader")).ClientID.ToString().Trim();
//			}
//
//			if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
//			{				 				
//				if(htCheckedValue.Contains(((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()))
//				{
//					((CheckBox) e.Item.FindControl("chkSelect")).Checked = (bool) htCheckedValue[((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()];
//				}						 
//				 
//			}

		}

		#endregion

		#region dgCentreStatus_ItemCreated()


		public void dgCentreStatus_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
 			if(e.Item.ItemType == ListItemType.Footer)
 			{
 				DateTime dtRegistrationClosingDateTime;
 				
 				e.Item.Cells.Clear();
 				System.Web.UI.WebControls.TableCell tc = new TableCell();				 
 				tc.ColumnSpan = 3;
 				e.Item.Cells.Add(tc);	
				System.Web.UI.LiteralControl lc = new LiteralControl();
				if(ViewState["RegistrationClosingDateTime"] != null)
				{
					dtRegistrationClosingDateTime = Convert.ToDateTime(ViewState["RegistrationClosingDateTime"]);
					lc.Text = "Registration end date/time: " + String.Format("{0: dd-MMMM-yyyy hh:mm tt}", dtRegistrationClosingDateTime);
				}
				else
				{
				    lc.Text = "No any registration end date/time";
				}
				
				tc.Controls.Add(lc);

 			}           

		}


		#endregion

		#region dgCentreStatus_ItemCommand()

		public void dgCentreStatus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.ToString() == "FetchRecord")
			{
			 
//				ViewState["SelectedPage"] = e.CommandArgument.ToString();
//				//((LinkButton)dgSearch.FindControl(e.CommandArgument.ToString())).Style.Add("TEXT-DECORATION:","none");
//				SetStateCityCentreDropDown();
//				SaveCheckedValueTemporary();
//				SetSearchParameter(lblSortExp.Text.ToString(), Convert.ToInt32(e.CommandArgument));
				
			}
		}


		#endregion

		#region btnRefreshGrid_Click()

		public void btnRefreshGrid_Click(object sender, System.EventArgs e)
		{
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

		#endregion

		#region PopulateCentreStatus()

		public void PopulateCentreStatus()
		{
			if(Convert.ToInt32(hdState.Value) != 0)
			{
				DataTable dtCentreStatus = new DataTable();

				BLRegistrationPermissions objBLRegistrationPermissions = new BLRegistrationPermissions();
				objBLRegistrationPermissions.StateID = Convert.ToInt32(hdState.Value);
				objBLRegistrationPermissions.CityID = Convert.ToInt32(hdCity.Value);
				objBLRegistrationPermissions.CentreID = Convert.ToInt32(hdCentre.Value);
				objBLRegistrationPermissions.CurrentPage = 0;
				objBLRegistrationPermissions.PageSize = 0;
				dtCentreStatus = objBLRegistrationPermissions.RegistrationPermissionDetail().Tables[0];
				if(dtCentreStatus.Rows.Count > 0)
				{
					dgCentreStatus.Visible = true;
					lblCentreStatusMessage.Visible = false;
					if(dtCentreStatus.Rows[0]["RegistrationEndDate"] != null && Convert.ToString(dtCentreStatus.Rows[0]["RegistrationEndDate"]) != "" && (!System.DBNull.Value.Equals(dtCentreStatus.Rows[0]["RegistrationEndDate"])))
					{
						ViewState["RegistrationClosingDateTime"] = Convert.ToDateTime(dtCentreStatus.Rows[0]["RegistrationEndDate"]);
					}
					else
					{
					ViewState["RegistrationClosingDateTime"] = null;
					}
					
					dgCentreStatus.DataSource = dtCentreStatus.DefaultView;
					dgCentreStatus.DataBind();
					
				}
				else
				{
					ViewState["RegistrationClosingDateTime"] = null;
					lblCentreStatusMessage.Visible = true;
				    lblCentreStatusMessage.Text = "There is no any corresponding record.";
					dgCentreStatus.Visible = false;
				}
				
			}
			else
			{
				 lblCentreStatusMessage.Visible = false;
			     dgCentreStatus.Visible = false;
			}
			
		}
		

		#endregion 

		protected void ddlTestCentre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

		protected void ddlTestCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

		protected void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateCentreStatus();
			SetStateCityCentreDropDown();
		}

	

//		public void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			PopulateCentreStatus();
//			SetStateCityCentreDropDown();
//		}

	 
		

 	}
}
