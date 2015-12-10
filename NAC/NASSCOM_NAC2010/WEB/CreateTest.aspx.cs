
    ///<remarks>
	///===================================================================
	/// Name: File Name				: CreateTest.aspx
	/// Construction Date			: 06/05/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for creating final and diagnostic test including shift details by admin
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2011 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 
	///

#region Namespaces

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
using BusinessLayer;

#endregion

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for CreateTest.
	/// </summary>
	public partial class CreateTest : System.Web.UI.Page
	{
		#region Class Variables
		#endregion

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if( Session["UserType"] == null)
			{
				Response.Redirect("login.aspx");
			}

			txtCentreCapacity.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			chkIsShiftTime.Attributes.Add("onclick","ShowHideShift();");
			btnSubmit.Attributes.Add("onclick","return ValidateData();");
			ddlAddShift.Attributes.Add("onchange","ShowHideShiftDetails();");
			lblErrorCity.Visible=false;
			lblErrorCentre.Visible=false;
			lblErrorMsg.Visible = false;
			trCentreDetails.Style.Add("display","none");
			if(!Page.IsPostBack)
			{
                txtTestDateTime.Attributes.Add("readonly", "readonly");
                txtRegStartDateTime.Attributes.Add("readonly", "readonly");
                txtRegEndDateTime.Attributes.Add("readonly", "readonly");
                txtShiftTime1.Attributes.Add("readonly", "readonly");
                txtShiftTime2.Attributes.Add("readonly", "readonly");
                txtShiftTime3.Attributes.Add("readonly", "readonly");
                txtShiftTime4.Attributes.Add("readonly", "readonly");
                txtShiftTime5.Attributes.Add("readonly", "readonly");
                txtShiftTime6.Attributes.Add("readonly", "readonly");
                txtShiftTime7.Attributes.Add("readonly", "readonly");
                txtShiftTime8.Attributes.Add("readonly", "readonly");
                txtShiftTime9.Attributes.Add("readonly", "readonly");
                txtShiftTime10.Attributes.Add("readonly", "readonly");
                txtShiftTime11.Attributes.Add("readonly", "readonly");
                txtShiftTime12.Attributes.Add("readonly", "readonly");
                txtShiftTime13.Attributes.Add("readonly", "readonly");
                txtShiftTime14.Attributes.Add("readonly", "readonly");
                txtShiftTime15.Attributes.Add("readonly", "readonly");
                txtShiftTime16.Attributes.Add("readonly", "readonly");
                txtShiftTime17.Attributes.Add("readonly", "readonly");
                txtShiftTime18.Attributes.Add("readonly", "readonly");
                txtShiftTime19.Attributes.Add("readonly", "readonly");
                txtShiftTime20.Attributes.Add("readonly", "readonly");
                txtShiftTime21.Attributes.Add("readonly", "readonly");
                txtShiftTime22.Attributes.Add("readonly", "readonly");
                txtShiftTime23.Attributes.Add("readonly", "readonly");
                txtShiftTime24.Attributes.Add("readonly", "readonly");
                txtShiftTime25.Attributes.Add("readonly", "readonly");


				trShift1.Style.Add("display","none");
				trShift2.Style.Add("display","none");
				trShift3.Style.Add("display","none");
				trShift4.Style.Add("display","none");
				trShift5.Style.Add("display","none");
				trShift6.Style.Add("display","none");
				trShift7.Style.Add("display","none");
				trShift8.Style.Add("display","none");
				trShift9.Style.Add("display","none");
				trShift10.Style.Add("display","none");
				trShift11.Style.Add("display","none");
				trShift12.Style.Add("display","none");
				trShift13.Style.Add("display","none");
				trShift14.Style.Add("display","none");
				trShift15.Style.Add("display","none");
				trShift16.Style.Add("display","none");
				trShift17.Style.Add("display","none");
				trShift18.Style.Add("display","none");
				trShift19.Style.Add("display","none");
				trShift20.Style.Add("display","none");
				trShift21.Style.Add("display","none");
				trShift22.Style.Add("display","none");
				trShift23.Style.Add("display","none");
				trShift24.Style.Add("display","none");
				trShift25.Style.Add("display","none");

				trShiftDetails.Style.Add("display","none");

				FillTestCity();
				//Populating ddlTestCentre
				FillTestCentre();
				//Populating ddlTestState
				FillTestState();
				//if(Session["StateId"]!=null && Session["StateId"].ToString()!="")
				if(Request.QueryString["State"] != null)
				{
					//ddlTestState.SelectedValue = Session["StateId"].ToString();
					ddlTestState.SelectedValue = Request.QueryString["State"];
					ddlTestState_SelectedIndexChanged(sender,e);
					//if(Session["CityId"]!=null && Session["CityId"].ToString()!="")
					if(Request.QueryString["City"] != null)
					{
						//ddlTestCity.SelectedValue = Session["CityId"].ToString();
						ddlTestCity.SelectedValue = Request.QueryString["City"];
						ddlTestCity_SelectedIndexChanged(sender,e);					
					}
					if(Request.QueryString["Centre"] != null)
					{
						//ddlTestCity.SelectedValue = Session["CityId"].ToString();
						ddlTestCentre.SelectedValue = Request.QueryString["Centre"];
						//ddlTestCity_SelectedIndexChanged(sender,e);					
					}
				}

			}
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
		
		#region FillTestState()
		// To fill test state on page load
		private void FillTestState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(),"State","StateId");			 
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

		#region ValidateData()
		private bool ValidateData()
		{
			if(ddlTestState.SelectedIndex==0)
			{
				DisplayErrorMessage("Please select a state");
				return false;
			}

			if(ddlTestCity.SelectedIndex==0)
			{
				DisplayErrorMessage("Please select a city");
				return false;
			}

			if(ddlTestCentre.SelectedIndex==0)
			{
				DisplayErrorMessage("Please select a cantre");
				return false;
			}

			if(rbtnlstTestType.SelectedValue == "")
			{
				DisplayErrorMessage("Please select a test type");
				return false;
			}

			if(txtTestDateTime.Text=="")
			{
				DisplayErrorMessage("Please select test datetime");
				return false;
			}

			if(txtTestName.Text.Trim()=="")
			{
				DisplayErrorMessage("Please enter a test name");
				return false;
			}

			if(txtRegStartDateTime.Text=="")
			{
				DisplayErrorMessage("Please select registration start datetime");
				return false;
			}
			if(txtRegEndDateTime.Text=="")
			{
				DisplayErrorMessage("Please select registration end datetime");
				return false;
			}

			if(chkIsShiftTime.Checked==true)
			{
				if(ddlAddShift.SelectedIndex==0)
				{
					return false;
				}
				else
				{
					int shifts=0;
					int count = Convert.ToInt32(ddlAddShift.SelectedValue.ToString());
					int capacity = 0;
					for( shifts=1; shifts<=count; shifts++ )
					{
						string c = ((TextBox)FindControl("txtShiftTime"+shifts)).Text.Trim().ToString();
						if(((TextBox)FindControl("txtShiftTime"+shifts)).Text.Trim().ToString() == "")
						{
							DisplayErrorMessage("Please enter all shift datetime");
							return false;
						}
						capacity = Convert.ToInt32(((TextBox)FindControl("txtCapacity" + shifts)).Text) + capacity;
						for( int shiftCount=shifts+1; shiftCount<=count; shiftCount++ )
						{
							if( ((TextBox)FindControl("txtShiftTime"+shiftCount)).Text.Trim().ToString() == ((TextBox)FindControl("txtShiftTime"+shifts)).Text.Trim().ToString() )
							{
								DisplayErrorMessage("Two or more shifts cannot have same datetime");
								return false;
							}
						}
					}
					if( capacity > Convert.ToInt32(txtCentreCapacity.Text ))
					{
						DisplayErrorMessage("Total shift capacity is exceeding the centre capacity");
						return false;
					}
					
				}
			}
			return true;
		}
		#endregion

		#region DisplayErrorMessage()
		private void DisplayErrorMessage(string Message)
		{
			lblErrorMsg.Text = Message;
			lblErrorMsg.Visible = true;
		}
	#endregion

		#region ddlTestState_SelectedIndexChanged
		protected void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestState.SelectedIndex !=0 )
			{
				Session["StateId"] = ddlTestState.SelectedValue;
				BLRegistration objBLRegistration = new BLRegistration();	
				BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCity(Convert.ToInt32(ddlTestState.SelectedValue.ToString())),"City","CityId");	
				ddlTestCity.Items.Insert(0,new ListItem("Select","0"));

                if (ddlTestCentre.Items.Count > 1)
                {
                    FillTestCentre();
                }
			}
			else
			{
				Session["StateId"] = "";
				FillTestCity();
				FillTestCentre();
				ddlTestCity.SelectedIndex = 0;
				ddlTestCentre.SelectedIndex = 0;

			}
		}
		#endregion

		#region ddlTestCity_SelectedIndexChanged
		protected void ddlTestCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( ddlTestCity.SelectedIndex != 0 )
			{
				Session["CityId"] = ddlTestCity.SelectedValue;
				BLRegistration objBLRegistration = new BLRegistration();	
				BindDropDown(ref ddlTestCentre, objBLRegistration.FillAllTestCentre(Convert.ToInt32(ddlTestCity.SelectedValue.ToString())),"Centre","CentreId");	
				ddlTestCentre.Items.Insert(0,new ListItem("Select","0"));
				ddlTestCentre.SelectedIndex = 0;
			}
			else
			{
				Session["CityId"] = "";
				FillTestCentre();
				ddlTestCentre.SelectedIndex = 0;
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

		#region btnSaveEditCity_Click
		protected void btnSaveEditCity_Click(object sender, System.EventArgs e)
		{
			if(ddlTestState.SelectedIndex==0)
			{
				lblErrorCity.Visible=true;
				lblErrorCity.Text="Please select a state first";
			}
			else
			{
				Response.Redirect("./ManageTestCity.aspx");
			}
		}
		#endregion

		#region btnSaveEditCentre_Click
		protected void btnSaveEditCentre_Click(object sender, System.EventArgs e)
		{
			if(ddlTestCity.SelectedIndex==0)
			{
				lblErrorCentre.Visible=true;
				lblErrorCentre.Text="Please select a state and city first";
			}
			else
			{
				Response.Redirect("./ManageTestCentre.aspx");
			}
		}
		#endregion

		#region btnSubmit_Click
        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    int check;
                    BLTest objBLTest = new BLTest();
                    objBLTest.TestType = Convert.ToInt32(rbtnlstTestType.SelectedValue);
                    objBLTest.TestCentreId = Convert.ToInt32(ddlTestCentre.SelectedValue.ToString());
                    objBLTest.TestCityId = Convert.ToInt32(ddlTestCity.SelectedValue.ToString());
                    objBLTest.TestStateId = Convert.ToInt32(ddlTestState.SelectedValue.ToString());
                    objBLTest.TestCapacity = Convert.ToInt32(txtCentreCapacity.Text.Trim());
                    //objBLTest.TestDatedt = Convert.ToDateTime(ddlTestMonth.SelectedValue + "/" + ddlTestDay.SelectedValue + "/" + ddlTestYear.SelectedValue);//System.DateTime.Today;
                    //objBLTest.TestTimedt = objBLTest.TestDatedt.AddHours(Convert.ToDouble(ddlTestTime.SelectedValue.ToString()));//Convert.ToDateTime(ddlTestTime.SelectedValue);
                    try
                    {
                        objBLTest.TestDatedt = Convert.ToDateTime(txtTestDateTime.Text).Date;
                    }
                    catch(Exception ex)
                    {
                        lblErrorMsg.Text = "Please enter a valid a Test Date.";
                        lblErrorMsg.Visible = true;
                        return;
                    }
                    try
                    {
                        objBLTest.TestTimedt = Convert.ToDateTime(txtTestDateTime.Text);
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = "Please enter a valid a Test Date.";
                        lblErrorMsg.Visible = true;
                        return;
                    }

                    objBLTest.TestName = txtTestName.Text.ToString();
                    //objBLTest.RegStartDate = Convert.ToDateTime(ddlRegStartMonth.SelectedValue +"/"+ ddlRegStartDay.SelectedValue +"/"+ ddlRegStartYear.SelectedValue);
                    //objBLTest.RegStartDate = objBLTest.RegStartDate.AddHours(Convert.ToDouble(ddlRegStartTime.SelectedValue.ToString()));
                    try
                    {
                        objBLTest.RegStartDate = Convert.ToDateTime(txtRegStartDateTime.Text);
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = "Please enter a valid a Registration Start Date.";
                        lblErrorMsg.Visible = true;
                        return;
                    }
                    try
                    {
                        objBLTest.RegEndDate = Convert.ToDateTime(txtRegEndDateTime.Text);
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = "Please enter a valid a Registration End Date.";
                        lblErrorMsg.Visible = true;
                        return;
                    }
                    //objBLTest.RegEndDate = Convert.ToDateTime(ddlRegEndMonth.SelectedValue +"/"+ ddlRegEndDay.SelectedValue +"/"+ ddlRegEndYear.SelectedValue);
                    //objBLTest.RegEndDate = objBLTest.RegEndDate.AddHours(Convert.ToDouble(ddlRegEndTime.SelectedValue.ToString()));
                    string[,] arrShiftTime = new string[25, 2];
                    int count = 0;
                    if (chkIsShiftTime.Checked == true)
                    {
                        objBLTest.IsShiftTime = chkIsShiftTime.Checked;
                        count = Convert.ToInt32(ddlAddShift.SelectedValue.ToString());
                        for (int i = 1; i <= count; i++)
                        {
                            //arrShiftTime[i-1,0] = ((TextBox)FindControl("txtShift"+i)).Text;
                            //arrShiftTime[i-1,1] = ((DropDownList)FindControl("ddlShift"+i+"Time")).SelectedValue;
                            arrShiftTime[i - 1, 0] = ((TextBox)FindControl("txtCapacity" + i)).Text;
                            arrShiftTime[i - 1, 1] = ((TextBox)FindControl("txtShiftTime" + i)).Text;
                        }
                    }
                    check = objBLTest.CreateTest();
                    if (check > 0)
                    {
                        if (chkIsShiftTime.Checked == true)
                        {
                            BLTestDetails objBLTestDetails = new BLTestDetails();
                            objBLTestDetails.TestId = check;
                            for (int i = 1; i <= count; i++)
                            {
                                //objBLTestDetails.ShiftCapacity = Convert.ToInt32(arrShiftTime[i-1,0].ToString());
                                //objBLTestDetails.ShiftTestTime = objBLTestDetails.ShiftTestDate.AddHours(Convert.ToDouble(arrShiftTime[i-1,1].ToString()));
                                try
                                {

                                    objBLTestDetails.ShiftTestDate = Convert.ToDateTime(arrShiftTime[i - 1, 1]).Date;
                                    objBLTestDetails.ShiftTestTime = Convert.ToDateTime(arrShiftTime[i - 1, 1]);
                                }
                                catch (Exception ex)
                                {
                                    lblErrorMsg.Text = "Please enter a valid a shift date time.";
                                    lblErrorMsg.Visible = true;
                                    return;
                                }
                                objBLTestDetails.ShiftCapacity = Convert.ToInt32(arrShiftTime[i - 1, 0].ToString());
                                objBLTestDetails.IsShiftActive = "1";
                                objBLTestDetails.AddShiftTimeDetail();
                            }
                            lblErrorMsg.Text = "Test created successfully with shifts";
                            lblErrorMsg.Visible = true;
                        }
                        else
                        {
                            lblErrorMsg.Text = "Test created successfully";
                            lblErrorMsg.Visible = true;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "Test already exists";
                        lblErrorMsg.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                lblErrorMsg.Text = "Some error occured:" + ex.Message + ex.StackTrace;
                lblErrorMsg.Visible = true;
            }
        }
		#endregion

	}
}
