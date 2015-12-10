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

namespace NASSCOM_NAC
{
	/// <summary>
	/// Summary description for SearchCandidateByETS.
	/// </summary>
	public partial class SearchCandidateByETS : System.Web.UI.Page
	{		
		 
		public string strSortExp;
		private int intCurrentPage;
		private static int intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());

		#region WebControls
        

		#endregion	

		#region Enum

		enum Month
		{
			January,
			February,
			March,
			April,
			May,
			June,
			July,
			August,
			September,
			October,
			November,
			December
		}

		#endregion

		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Populating ddlTestCity on selection of ddlTestCenter through javascript.
				ddlTestState.Attributes.Add("onchange","populate(); FillHiddenField();");
				//Populating ddlTestCentre on selection of ddlTestCity through javascript.
				ddlTestCity.Attributes.Add("onchange"," populateCentre(); FillHiddenField();");
				//Populating hdState, hdCity and hdCentre fields on selection of ddlTestCentre.
				ddlTestCentre.Attributes.Add("onchange","FillHiddenField();");
				//Adding attribute to hide Specify Others text box, populate Qualification Details and changing college name.
				ddlqualification.Attributes.Add("onchange","populateQualification(); hideTextBox(); ChangeCollegeLabel(); fillHiddenQualification();");
				//Adding attribute to validate user input on click event of btnSearch through javascript.
				btnSearch.Attributes.Add("OnClick", "javascript:return ValidateData();");
				
				//Adding Attribute to fill data in hdQualificationDetails hidden field.
				ddlQualificationDetails.Attributes.Add("onchange","fillHiddenQualification();"); 

				 btnScoreCard.Attributes.Add("OnClick","javascript:return NoJobFairOrScoreCard();");
				btnViewJobCard.Attributes.Add("OnClick","javascript:return NoJobFairOrScoreCard();");

				//btnScoreCard.Attributes.Add("OnClick","javascript:return SelectCandidate();");
				btnCandidateDetails.Attributes.Add("OnClick","javascript:return SelectCandidate();");
				btnAdmitCard.Attributes.Add("OnClick","javascript:return SelectCandidate();");
				btnExportToExcel.Attributes.Add("OnClick","javascript:return SelectCandidate();");
			//	btnViewJobCard.Attributes.Add("OnClick","javascript:return SelectCandidate();");

				 
				 
				if(!Page.IsPostBack)
				{
					// Put user code to initialize the page here

					
					btnCandidateDetails.Visible = false;
					btnViewJobCard.Visible = false;
					btnScoreCard.Visible = false;
					btnAdmitCard.Visible = false;
					btnExportToExcel.Visible = false;
					pnlSearch.Visible = true;
					pnlMessage.Visible = false;
				 
					lblTotalRecord.Visible = false;
					chkAll.Visible = false;

					//Populating ddlTestCity and ddlTestCentre besad on state id.
					GenerateDynamicDropdown();
					//Populating ddlQualificationDetails(Qualification Details) ComboBox on behalf of selected Highest Educational Qualification.
					GenerateDDLQualification();
					//Populating ddlTestCentre on selection of ddlTestCity.
					GenerateCityDropdown();
					//Populating ddlTestCity
					FillTestCity();
					//Populating ddlTestCentre
					FillTestCentre();
					//Populating ddlTestState
					FillTestStateForETS();
					//Populating ddlqualification
					FillQualificationType();
					//Populating ddlQualificationDetails(Qualification Details) ComboBox.
					FillQualification(); 
					 
					lblSortExp.Text = "RegistrationId ASC";
					 
				}
			}
			catch(Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
			
		}

		#endregion

		#region GenerateDDLQualification()
		//Creating script to populate Qualification details on behalf of selected Heighest Qualification
		private void GenerateDDLQualification()
		{
		      
			DataTable dtQualificationType = new DataTable();
			DataTable dtQualification = new DataTable();		  

			StringBuilder sbAppend = new StringBuilder();

			int intInnerIncrementLoop = 0;
			int intOuterIncrementLoop = 0;
			int intParentRowCount = 0;
			int intChildRowCount = 0;			  

			BLRegistration objBLRegistration = new BLRegistration();

			dtQualificationType = objBLRegistration.FillQualificationType();
			dtQualification = objBLRegistration.FillQualification();

			sbAppend.Append("<script language='javascript' type='text/javascript'> ");	
			sbAppend.Append("function populateQualification(){ "); 
			sbAppend.Append("document.getElementById('txtOtherQualification').style.visibility = 'hidden'; ");
			sbAppend.Append("var store = new Array(); ");
			sbAppend.Append("store[0] = new Array('Select','0'); ");
 			
 
			if(dtQualificationType != null && dtQualification != null)
			{
				intParentRowCount = dtQualificationType.Rows.Count;
				intChildRowCount = dtQualification.Rows.Count;
 
				if(intParentRowCount > 0 && intChildRowCount > 0)
				{
					for(intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
					{
						sbAppend.Append("store[");
						sbAppend.Append(Convert.ToInt32(dtQualificationType.Rows[intOuterIncrementLoop]["QualificationTypeId"].ToString().Trim())); 
						sbAppend.Append("] = new Array(");
					 
						for(intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
						{
							if(intInnerIncrementLoop == 0)
							{
								sbAppend.Append("'Select','0',");
								 
							}

							if(Convert.ToInt32(dtQualificationType.Rows[intOuterIncrementLoop]["QualificationTypeId"].ToString().Trim()) == Convert.ToInt32(dtQualification.Rows[intInnerIncrementLoop]["QualificationTypeId"].ToString().Trim()))
							{

								sbAppend.Append("'");
								sbAppend.Append(dtQualification.Rows[intInnerIncrementLoop]["Qualification"].ToString().Trim());
								sbAppend.Append("'"); 		
								sbAppend.Append(",");
								sbAppend.Append("'");
								sbAppend.Append(dtQualification.Rows[intInnerIncrementLoop]["QualificationId"].ToString().Trim());
								sbAppend.Append("'"); 
								sbAppend.Append(",");								 								 
							}
						}
						sbAppend.Remove(sbAppend.Length - 1,1); 
						sbAppend.Append(");"); 
							
					} 		 
 
					sbAppend.Append("var box = document.getElementById('ddlQualification'); ");
					sbAppend.Append("var number = box.options[box.selectedIndex].value; ");
					sbAppend.Append("if (!number) return;");
					sbAppend.Append("var list = store[number];");
					sbAppend.Append("var box2 = document.getElementById('ddlQualificationDetails'); ");
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

		#region FillQualification()
		//Populating qualification details.
		private void FillQualification()
		{
			DataTable dtQualification = new DataTable();
			dtQualification.Columns.Add("Qualification");
			dtQualification.Columns.Add("QualificationId"); 
			DataRow drNewRow;
			drNewRow = dtQualification.NewRow();
			drNewRow["Qualification"] = "Select";
			drNewRow["QualificationId"] = "0";
			dtQualification.Rows.Add(drNewRow); 
			//Passing Qualification Details Document combo to bind with dtQualification(DataTable).
			BindDropDown(ref ddlQualificationDetails, dtQualification,"Qualification","QualificationId");
		}


		#endregion

		#region FillQualificationType()
		//Populating ddlqualification Combo box.
		private void FillQualificationType()
		{
			try
			{
				BLRegistration objBLRegistration = new BLRegistration();
				//Passing Qualification Details Document combo in BindDropDown to bind with object returned by FillQualificationTypeSecond() function.
				BindDropDown(ref ddlqualification, objBLRegistration.FillQualificationTypeSecond(),"QualificationType","QualificationTypeId");
			}
			catch(Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
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
			this.dgSearch.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgSearch_ItemCreated);
			this.dgSearch.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSearch_ItemCommand);
			this.dgSearch.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgSearch_PageIndexChanged);
			this.dgSearch.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgSearch_SortCommand);
			this.dgSearch.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgSearch_ItemDataBound);

		}
		#endregion

		#region btnScoreCard_Click()

		protected void btnScoreCard_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				Session["SortExp"] = lblSortExp.Text;
				Response.Redirect("MultipleCertificate.aspx?SearchType=full");
			}
			else
			{
				bool IsSelected = false; 
				//Declaring and nitializing sbItemList as StringBuilder to keep the value of salected check boxes.
				StringBuilder sbItemList = new StringBuilder();
				try
				{
				
					//Calling SaveCheckedValueTemporary() to store values of checked check box in viewstate (ViewState["CheckedValue"]).
					SaveCheckedValueTemporary();
					//Creating instance of hashtable.
					Hashtable htCheckedValue = new Hashtable();
					//Checking that CheckedValue in ViewState is existing or not.
					if(ViewState["CheckedValue"] != null)
					{
						//Initializing htCheckedValue with (Hashtable) ViewState["CheckedValue"].
						htCheckedValue = (Hashtable) ViewState["CheckedValue"];
					}
					//Checking that values in htCheckedValue hashtable is existing or not.
					if (htCheckedValue.Count != 0)
					{
						//Creating instance of IDictionaryEnumerator to generate sbItemList.
						IDictionaryEnumerator Enumerator;
						//Initializing Enumerator with htCheckedValue.
						Enumerator = htCheckedValue.GetEnumerator();
						while (Enumerator.MoveNext())
						{
							if(Convert.ToBoolean(Enumerator.Value))
							{
								sbItemList.Append("'");
								sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));				 
								sbItemList.Append("'");
								sbItemList.Append(",");
								if(IsSelected == false)
								{
									IsSelected = true;
								}
						 
							}
					 
						}
					}
				}
				catch(Exception ex)
				{
					//Calling ErrorRoutine of ErrorLogger to write error text in text file.
					ErrorLogger.ErrorRoutine(false,ex);
				}
				

				if(IsSelected)
				{
					//				try
					//				{
					//					sbItemList.Remove(sbItemList.Length - 1,1);
					//					Session["ItemList"] = sbItemList.ToString();			 
					//					Session["SortExp"] = lblSortExp.Text;
					//				}
					//				catch(Exception ex)
					//				{
					//					//Calling ErrorRoutine of ErrorLogger to write error text in text file.
					//					ErrorLogger.ErrorRoutine(false,ex);
					//				}
					//				 
					//				Response.Redirect("MultipleCertificate.aspx");
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);	
					//Response.Write("<script language='javascript'>alert('No data found!')</script>");	
				}
				else
				{
					try
					{
						strSortExp = lblSortExp.Text;
						Session["SortExp"] = lblSortExp.Text;
						SetStateCityCentreDropDown();
						PopulateCandidateList(strSortExp);					 
					
					}
					catch(Exception ex)
					{
						//Calling ErrorRoutine of ErrorLogger to write error text in text file.
						ErrorLogger.ErrorRoutine(false,ex);
					}
				
				}
			}
		}

		#endregion

		#region btnCandidateDetails_Click()

		protected void btnCandidateDetails_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				Response.Redirect("MultipleRegistration.aspx?SearchType=full");
			}
			else
			{
				bool IsSelected = false; 
				string strItemList = "";	
            
				SaveCheckedValueTemporary();

				Hashtable htCheckedValue = new Hashtable();
				if(ViewState["CheckedValue"] != null)
				{
					htCheckedValue = (Hashtable) ViewState["CheckedValue"];
				}

				if (htCheckedValue.Count != 0)
				{
					IDictionaryEnumerator Enumerator;
					Enumerator = htCheckedValue.GetEnumerator();
					while (Enumerator.MoveNext())
					{
						if(Convert.ToBoolean(Enumerator.Value))
						{					  
							strItemList = strItemList + Convert.ToString(Enumerator.Key.ToString()) + ","; 
							if(IsSelected == false)
							{
								IsSelected = true;
							}
						}
					 
					}
				}			

				if(IsSelected)
				{
					Session["ItemList"] = strItemList.ToString().TrimEnd(',');
					Response.Redirect("MultipleRegistration.aspx");
				}
				else
				{
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);				 
				}
			}
		}

		#endregion

		#region btnAdmitCard_Click()

		protected void btnAdmitCard_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				Response.Redirect("MultipleAdmitCard.aspx?SearchType=full");
			}
			else
			{
				bool IsSelected = false; 
				string strItemList = "";	
			 
				SaveCheckedValueTemporary();

				Hashtable htCheckedValue = new Hashtable();
				if(ViewState["CheckedValue"] != null)
				{
					htCheckedValue = (Hashtable) ViewState["CheckedValue"];
				}

				if (htCheckedValue.Count != 0)
				{
					IDictionaryEnumerator Enumerator;
					Enumerator = htCheckedValue.GetEnumerator();
					while (Enumerator.MoveNext())
					{
						if(Convert.ToBoolean(Enumerator.Value))
						{					  
							strItemList = strItemList + Convert.ToString(Enumerator.Key.ToString()) + ","; 
							if(IsSelected == false)
							{
								IsSelected = true;
							}
						}
					 
					}
				}

				if(IsSelected)
				{
					Session["ItemList"] = strItemList;
					Response.Redirect("MultipleAdmitCard.aspx");
				}
				else
				{
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);
				}
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

		#region FillTestStateForETS()

		private void FillTestStateForETS()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestState, objBLRegistration.FillTestStateForETS(),"State","StateId");			 
		}

		#endregion

		#region FillTestState()

		private void FillTestState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestState, objBLRegistration.FillAllTestState(),"State","StateId");			 
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

		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{

			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

		}

		#endregion

		#region btnSearch_Click()

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			dgSearch.CurrentPageIndex = 0;
			dgSearch.SelectedIndex = 0;
			hdSelectedCandidateCount.Value = "0";
			hdTotalCandidateCount.Value = "0";
			ViewState["SelectedPage"] = null;
			ViewState["CheckedValue"] = null;
			Hashtable htCheckedValue = new Hashtable();
			ViewState["CheckedValue"] = htCheckedValue; 
			strSortExp = lblSortExp.Text.ToString().Trim();
			SetStateCityCentreDropDown();
			SetSearchParameter(strSortExp,1);
		}

		#endregion

		#region SetSearchParameter()

		private void SetSearchParameter(string SortExp,int intCurrentPage)
		{
	
			BLSearch objBLSearch = new BLSearch();
			objBLSearch.FirstName = txtName.Text.ToString().Trim();
			objBLSearch.LastName = txtLastName.Text.ToString().Trim();

			if(ddlGender.SelectedValue.ToString().Trim() == "Select")
			{
				objBLSearch.Gender = "";
			} 	
			else
			{
				objBLSearch.Gender = ddlGender.SelectedValue.ToString().Trim();
			}
			
			if(ddlqualification.SelectedValue.ToString().Trim() == "0")
			{
				objBLSearch.Qualification = "";
			}
			else
			{ 
				objBLSearch.Qualification = ddlqualification.SelectedValue.ToString().Trim();
			}

			if(Convert.ToInt32(ddlTestState.SelectedValue.ToString().Trim()) == 0)
			{
				objBLSearch.TestState = 0;
			}
			else
			{ 
				objBLSearch.TestState = Convert.ToInt32(ddlTestState.SelectedValue.ToString().Trim());
			}

			if(Convert.ToInt32(ddlTestCity.SelectedValue.ToString().Trim()) == 0)
			{
				objBLSearch.TestCity = 0;
			}
			else
			{ 
				objBLSearch.TestCity = Convert.ToInt32(ddlTestCity.SelectedValue.ToString().Trim());
			}

			if(Convert.ToInt32(ddlTestCentre.SelectedValue.ToString().Trim()) == 0)
			{
				objBLSearch.TestCentre = 0;
			}
			else
			{ 
				objBLSearch.TestCentre = Convert.ToInt32(ddlTestCentre.SelectedValue.ToString().Trim());
			}

			if(ddlEmploymentStatus.SelectedValue.ToString().Trim() == "Select")
			{
				objBLSearch.EmploymentStatus = "";
			}
			else
			{ 
				objBLSearch.EmploymentStatus = ddlEmploymentStatus.SelectedValue.ToString().Trim();
			}

			if(ddlRelocate.SelectedValue.ToString().Trim() == "Select")
			{
				objBLSearch.WillingToRelocate = "";
			} 	
			else
			{
				objBLSearch.WillingToRelocate = ddlRelocate.SelectedValue.ToString().Trim();
			}

			 
			if(txtSerialNoFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.SerialNoFrom = 0;
			}
			else
			{ 
				objBLSearch.SerialNoFrom = Convert.ToInt32(txtSerialNoFrom.Text.ToString().Trim());
			}

			if(txtSerialNoTo.Text.ToString().Trim() == "")
			{
				objBLSearch.SerialNoTo = 0;
			}
			else
			{ 
				objBLSearch.SerialNoTo = Convert.ToInt32(txtSerialNoTo.Text.ToString().Trim());
			}
			 
			 
			if(txtRegistrationIDFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.RegistrationIDFrom = "";
			}
			else
			{ 
				objBLSearch.RegistrationIDFrom = txtRegistrationIDFrom.Text.ToString().Trim();
			}

			if(txtRegistrationIDTo.Text.ToString().Trim() == "")
			{
				objBLSearch.RegistrationIDTo = "";
			}
			else
			{ 
				objBLSearch.RegistrationIDTo = txtRegistrationIDTo.Text.ToString().Trim();
			}

			 
			if(rblYouBelongTo.SelectedValue.ToString().Trim() == "0")
			{
				objBLSearch.YouBelongTo = "";
			} 	
			else
			{
				objBLSearch.YouBelongTo = rblYouBelongTo.SelectedValue.ToString().Trim();
			}
			
			if(ddlMediumOfInstruction.SelectedValue.ToString().Trim() == "0")
			{
				objBLSearch.MediumOfInstruction = "";
			} 	
			else
			{
				objBLSearch.MediumOfInstruction = ddlMediumOfInstruction.SelectedValue.ToString().Trim();
			}
			
			if(ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim() == "0")
			{
				objBLSearch.MediumOfInstructionIn12Th = "";
			} 	
			else
			{
				objBLSearch.MediumOfInstructionIn12Th = ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim();
			}
			
			if(txtSpeakingFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.SpeakingFrom = 0;
			}
			else
			{ 
				objBLSearch.SpeakingFrom = Convert.ToInt32(txtSpeakingFrom.Text.ToString().Trim());
			}

			 
			if(txtSpeakingTo.Text.ToString().Trim() == "")
			{
				objBLSearch.SpeakingTo = 0;
			}
			else
			{ 
				objBLSearch.SpeakingTo = Convert.ToInt32(txtSpeakingTo.Text.ToString().Trim());
			}

			if(txtListeningFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.ListeningFrom = 0;
			}
			else
			{ 
				objBLSearch.ListeningFrom = Convert.ToInt32(txtListeningFrom.Text.ToString().Trim());
			}

			if(txtListeningTo.Text.ToString().Trim() == "")
			{
				objBLSearch.ListeningTo = 0;
			}
			else
			{ 
				objBLSearch.ListeningTo = Convert.ToInt32(txtListeningTo.Text.ToString().Trim());
			}

			if(txtWaitingFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.WaitingFrom = 0;
			}
			else
			{ 
				objBLSearch.WaitingFrom = Convert.ToInt32(txtWaitingFrom.Text.ToString().Trim());
			}
			 
			if(txtWaitingTo.Text.ToString().Trim() == "")
			{
				objBLSearch.WaitingTo = 0;
			}
			else
			{ 
				objBLSearch.WaitingTo = Convert.ToInt32(txtWaitingTo.Text.ToString().Trim());
			}
			
			if(txtAnalyticalFrom.Text.ToString().Trim() == "")
			{
				objBLSearch.AnalyticalFrom = 0;
			}
			else
			{ 
				objBLSearch.AnalyticalFrom = Convert.ToInt32(txtAnalyticalFrom.Text.ToString().Trim());
			}

			if(txtAnalyticalTo.Text.ToString().Trim() == "")
			{
				objBLSearch.AnalyticalTo = 0;
			}
			else
			{ 
				objBLSearch.AnalyticalTo = Convert.ToInt32(txtAnalyticalTo.Text.ToString().Trim());
			}
	
			if(hdQualificationDetails.Value == "0")
			{
				objBLSearch.QualificationDetails = 0;
			}
			else
			{
				objBLSearch.QualificationDetails = Convert.ToInt32(hdQualificationDetails.Value.ToString().Trim());
			}

			if(txtOtherQualification.Value.ToString().Trim() == "CONTAINS WORD LIKE")
			{
				objBLSearch.OtherQualification = "";
			}
			else
			{ 
				objBLSearch.OtherQualification = txtOtherQualification.Value.ToString().Trim();
			}	
	
			objBLSearch.ResidentialCity = Convert.ToString(txtResidenceCity.Text.Trim().ToString());

			if(ddlFromDay.SelectedIndex != 0 && ddlFromMonth.SelectedIndex != 0 && ddlFromYear.SelectedIndex != 0)
				
			{
				objBLSearch.DOBFrom = Convert.ToDateTime(ddlFromDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlFromMonth.SelectedValue.ToString().Trim()) + "/" + ddlFromYear.SelectedValue.ToString().Trim());				
			}
			else
			{
				objBLSearch.DOBFrom = Convert.ToDateTime("01/01/1900");               
			}

			if(ddlToDay.SelectedIndex != 0 && ddlToMonth.SelectedIndex != 0 && ddlToYear.SelectedIndex != 0)
			{
				objBLSearch.DOBTo = Convert.ToDateTime(ddlToDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlToMonth.SelectedValue.ToString().Trim()) + "/" + ddlToYear.SelectedValue.ToString().Trim());
			}
			else
			{
				objBLSearch.DOBTo = System.DateTime.Now;
			}

		 
		    
		  
			objBLSearch.University = txtHighestEducationObtainedFrom.Text.ToString().Trim();
			objBLSearch.CollegeAddress = txtCollegeAddress.Text.ToString().Trim();
			objBLSearch.EducationCity = txtHighestEducationCity.Text.ToString().Trim();
			objBLSearch.CurrentPage = intCurrentPage;
			objBLSearch.PageSize = intPageSize;
			objBLSearch.UserType = 3;
			Session["SearchObject"] = objBLSearch;
			GetCandidateList(objBLSearch);
			PopulateCandidateList(SortExp);
		}

		#endregion

		#region MonthYear()

		private string MonthYear(string strMonth)
		{
			string strMonthName = null;			 

			switch (strMonth)
			{
				case "01": strMonthName = Month.January.ToString();
					break;
				case "02": strMonthName = Month.February.ToString();
					break;
				case "03": strMonthName = Month.March.ToString();
					break;
				case "04": strMonthName = Month.April.ToString();
					break;
				case "05": strMonthName = Month.May.ToString();
					break;
				case "06": strMonthName = Month.June.ToString();
					break;
				case "07": strMonthName = Month.July.ToString();
					break;
				case "08": strMonthName = Month.August.ToString();
					break;
				case "09": strMonthName = Month.September.ToString();
					break;
				case "10": strMonthName = Month.October.ToString();
					break;
				case "11": strMonthName = Month.November.ToString();
					break;
				case "12": strMonthName = Month.December.ToString();
					break;
			}
			return strMonthName;
		}


		#endregion

		#region SetStateCityCentreDropDown()

		private void SetStateCityCentreDropDown()
		{
			int intQualificationTypeID = 0;
			GenerateDynamicDropdown();			
			GenerateDDLQualification();
			GenerateCityDropdown();
			BLRegistration objBLRegistration = new BLRegistration();		
			intQualificationTypeID = Convert.ToInt32(ddlqualification.SelectedValue.ToString().Trim());			 
			BindDropDown(ref ddlQualificationDetails, ((DataTable)(objBLRegistration.FillQualificationDetails(intQualificationTypeID))),"Qualification","QualificationId");
			ddlQualificationDetails.SelectedValue = hdQualificationDetails.Value.ToString().Trim();
			ddlTestState.SelectedValue = hdState.Value.ToString().Trim();
			FillTestCitySecond(Convert.ToInt32(hdState.Value.ToString().Trim()));
			ddlTestCity.SelectedValue = hdCity.Value.ToString().Trim();
			FillTestCentreSecond(Convert.ToInt32(hdCity.Value.ToString().Trim()));
			ddlTestCentre.SelectedValue = hdCentre.Value.ToString().Trim();
			 
		}

		#endregion

		#region PopulateCandidateList()

		public void PopulateCandidateList(string strSortExp)
		{
			DataTable dtCandidate = new DataTable();	
			DataView dtView = new DataView();
		
			dtCandidate = (DataTable) ViewState["CandidateList"];
			dtView = dtCandidate.DefaultView;
			dtView.Sort = strSortExp;

			int intPageSize = 0;
			//bool blAllowPagination = false;

			//blAllowPagination = Convert.ToBoolean(ConfigurationSettings.AppSettings["AllowPaging"].ToString());
			intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());
			
		//	dgSearch.AllowPaging = blAllowPagination;
		//	dgSearch.PageSize = intPageSize;

//			if(blAllowPagination)
//			{
//				
//				if(dtCandidate.Rows.Count > intPageSize)
//				{
//					dgSearch.AllowPaging = true;
//				}
//				else
//				{
//					dgSearch.AllowPaging = false;
//				}
//			}
			

			
			dgSearch.DataSource = dtView;
			dgSearch.DataBind();
	 
			if(dtCandidate.Rows.Count > 0)
			{				
				btnCandidateDetails.Visible = true;
				btnViewJobCard.Visible = true;
				btnScoreCard.Visible = true;
				btnAdmitCard.Visible = true;
				btnExportToExcel.Visible = true;	
				chkAll.Visible = true;
				pnlSearch.Visible = true;
				 
				pnlMessage.Visible = false;
				lblTotalRecord.Visible = true;
				lblTotalRecord.Text = "Total Record:" + Convert.ToString(ViewState["TotalRecord"]);
			}
			else
			{
				btnCandidateDetails.Visible = false;
				btnScoreCard.Visible = false;
				btnAdmitCard.Visible = false;
				btnViewJobCard.Visible = false;
				btnExportToExcel.Visible = false;
				chkAll.Visible = false;
				pnlMessage.Enabled = true;
				lblMessage.Enabled = true;
				pnlMessage.Visible = true;
				pnlSearch.Visible = false;
				 
				lblMessage.Visible = true;
				lblMessage.Text = "No Record Found!";
				lblTotalRecord.Visible = false;
				
                
			}
		}

		#endregion

		#region GetCandidateList()

		private void GetCandidateList(BLSearch objBLSearch)
		{
			DataTable  dtCandidate = new DataTable();
			DataSet dsSearchCandidate = new DataSet();
			dsSearchCandidate = (DataSet) objBLSearch.SearchCandidateForETS();
			dtCandidate = ((DataTable) dsSearchCandidate.Tables[0]);
			ViewState["TotalRecord"] =  Convert.ToInt32(dsSearchCandidate.Tables[1].Rows[0][0]);
			ViewState["SelectAll"] = Convert.ToString(dsSearchCandidate.Tables[2].Rows[0][0]);
			ViewState["CandidateList"] = dtCandidate;
			if(dtCandidate.Rows.Count > 0)
			{
				hdTotalCandidateCount.Value = Convert.ToString(dtCandidate.Rows.Count.ToString());
			}
			else
			{
				hdTotalCandidateCount.Value = "0";
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

		#region btnExportToExcel_Click()

		protected void btnExportToExcel_Click(object sender, System.EventArgs e)
		{
			

			if(chkAll.Checked)
			{
				 
				Response.Redirect("ExportCLToExcelByETS.aspx?SearchType=full");
			}
			else
			{
				bool IsSelected = false; 
				StringBuilder sbItemList = new StringBuilder();

				SaveCheckedValueTemporary();

				Hashtable htCheckedValue = new Hashtable();
				if(ViewState["CheckedValue"] != null)
				{
					htCheckedValue = (Hashtable) ViewState["CheckedValue"];
				}

				if (htCheckedValue.Count != 0)
				{
					IDictionaryEnumerator Enumerator;
					Enumerator = htCheckedValue.GetEnumerator();
					while (Enumerator.MoveNext())
					{
						if(Convert.ToBoolean(Enumerator.Value))
						{
							sbItemList.Append("'");
							sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));				 
							sbItemList.Append("'");
							sbItemList.Append(",");
							if(IsSelected == false)
							{
								IsSelected = true;
							}
						 
						}
					 
					}
				}			 

				if(IsSelected)
				{
					sbItemList.Remove(sbItemList.Length - 1,1);
					Session["ItemList"] = sbItemList.ToString();
					Response.Redirect("ExportCLToExcelByETS.aspx");
				}
				else
				{
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);
				}
			}
		}


		#endregion

		#region dgSearch_SortCommand()

		public void dgSearch_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			 
			strSortExp = e.SortExpression.ToString().Trim();

			if(lblSortExp.Text.ToString().Trim() == strSortExp)
			{
				if(strSortExp.IndexOf("ASC") > 0)
				{
					strSortExp = strSortExp.Replace("ASC", "DESC");
				}
				else if(strSortExp.IndexOf("DESC") > 0)
				{
					strSortExp = strSortExp.Replace("DESC", "ASC");
				}	
			}			 

			lblSortExp.Text = strSortExp;
			SetStateCityCentreDropDown();
			SaveCheckedValueTemporary();
			//intCurrentPage = dgSearch.CurrentPageIndex + 1;
			//SetSearchParameter(strSortExp,intCurrentPage);
			PopulateCandidateList(strSortExp);
			 
		}

		#endregion

		#region dgSearch_PageIndexChanged()

		public void dgSearch_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgSearch.CurrentPageIndex = e.NewPageIndex;
			strSortExp = lblSortExp.Text;
			SetStateCityCentreDropDown();
			SaveCheckedValueTemporary();
			intCurrentPage = e.NewPageIndex + 1;
			SetSearchParameter(strSortExp,intCurrentPage);
			//PopulateCandidateList(strSortExp);


		}


		
		
		#endregion

		#region SaveCheckedValueTemporary()

		private void SaveCheckedValueTemporary()
		{
			Hashtable htCheckedValue = new Hashtable();
			

			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			//ViewState["CandidateList"]
			if(chkAll.Checked)
			{			   
				if(ViewState["CandidateList"] != null)
				{
					DataTable  dtCandidate = new DataTable();
					int intTotalRowCount = 0;
					int intIncrementLoop = 0;
					dtCandidate = (DataTable) ViewState["CandidateList"];
					intTotalRowCount = dtCandidate.Rows.Count;
					hdSelectedCandidateCount.Value = intTotalRowCount.ToString();

					for(intIncrementLoop=0;intIncrementLoop <= intTotalRowCount - 1; intIncrementLoop++)
					{
						if(htCheckedValue.Contains(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()))
						{
							htCheckedValue[dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()] = (bool)(true);
						}
						else
						{
							htCheckedValue.Add(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim(),((bool)(true)));
						}
					    
					}

				}
			}
			else
			{
				foreach(DataGridItem dgItem in dgSearch.Items)
				{ 
				 
					if(htCheckedValue.Contains(((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim()))
					{
						htCheckedValue[((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim()] = (bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked;
					}
					else
					{
						htCheckedValue.Add(((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim(),((bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked));
					}
				 
				}
			}

			

			ViewState["CheckedValue"] = htCheckedValue;
            
		}

		#endregion

		#region dgSearch_ItemDataBound()


		public void dgSearch_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Hashtable htCheckedValue = new Hashtable();			 

			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			if(e.Item.ItemType == ListItemType.Header)
			{
				hdHeaderCheckBox.Value = ((CheckBox) e.Item.FindControl("chkHeader")).ClientID.ToString().Trim();
			}

			if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{				 				
				if(htCheckedValue.Contains(((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()))
				{
					((CheckBox) e.Item.FindControl("chkSelect")).Checked = (bool) htCheckedValue[((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()];
				}						 
				 
			}

		}

		#endregion

		public void dgSearch_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Footer)
			{
				int intNumberOfLink = 0;
				int intIncrementLoop = 0; 
				double dblNumberOfLink = 0.0;
				int intTotalRecord = 0;

				intTotalRecord = Convert.ToInt32(ViewState["TotalRecord"]);
				 
				e.Item.Cells.Clear();
				System.Web.UI.WebControls.TableCell tc = new TableCell();				 
				tc.ColumnSpan = 6;
				e.Item.Cells.Add(tc);				 
				dblNumberOfLink = Convert.ToDouble(intTotalRecord) / Convert.ToDouble(intPageSize);
				intNumberOfLink = Convert.ToInt32(intTotalRecord / intPageSize);

				if(dblNumberOfLink > intNumberOfLink)
				{
					intNumberOfLink =intNumberOfLink + 1;
				}
				if(ViewState["SelectedPage"] == null)
				{
					ViewState["SelectedPage"] = 1;
				}

				for(intIncrementLoop = 0; intIncrementLoop <= intNumberOfLink - 1; intIncrementLoop++)
				{
					if(Convert.ToInt32(ViewState["SelectedPage"]) == intIncrementLoop + 1)
					{
						//lnkNumber.Style.Add("TEXT-DECORATION","none");
						System.Web.UI.LiteralControl lc = new LiteralControl();
						System.Web.UI.LiteralControl lc1 = new LiteralControl();
						lc.Text = " ";
						lc1.Text = (intIncrementLoop + 1).ToString();
						lc1.Visible = true;						 
						tc.Controls.Add(lc1); 
						tc.Controls.Add(lc);
					}
					else
					{
						System.Web.UI.WebControls.LinkButton lnkNumber = new LinkButton();
						System.Web.UI.LiteralControl lc = new LiteralControl();
						lc.Text = " ";
						lnkNumber.ID = intIncrementLoop.ToString();
						lnkNumber.Text = (intIncrementLoop + 1).ToString();					
						lnkNumber.ForeColor = System.Drawing.Color.Blue;
						lnkNumber.CommandArgument = (intIncrementLoop + 1).ToString();
						lnkNumber.CommandName = "FetchRecord";
						tc.Controls.Add(lnkNumber); 
						tc.Controls.Add(lc);
					}
					

				}


			}           
           

		}

		public void dgSearch_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.ToString() == "FetchRecord")
			{
			 
				ViewState["SelectedPage"] = e.CommandArgument.ToString();
				//((LinkButton)dgSearch.FindControl(e.CommandArgument.ToString())).Style.Add("TEXT-DECORATION:","none");
				SetStateCityCentreDropDown();
				SaveCheckedValueTemporary();
				SetSearchParameter(lblSortExp.Text.ToString(), Convert.ToInt32(e.CommandArgument));
				
			}
		}	

		#region btnViewJobCard_Click()
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnViewJobCard_Click(object sender, System.EventArgs e)
		{
			
			if(chkAll.Checked)
			{
				Response.Redirect("GenerateJobAdmitCard.aspx?SearchType=full");
			}
			else
			{ 
				bool IsSelected = false; 
				string strItemList = "";	
           
				SaveCheckedValueTemporary();

				Hashtable htCheckedValue = new Hashtable();
				if(ViewState["CheckedValue"] != null)
				{
					htCheckedValue = (Hashtable) ViewState["CheckedValue"];
				}

				if (htCheckedValue.Count != 0)
				{
					IDictionaryEnumerator Enumerator;
					Enumerator = htCheckedValue.GetEnumerator();
					while (Enumerator.MoveNext())
					{
						if(Convert.ToBoolean(Enumerator.Value))
						{					  
							strItemList = strItemList + Convert.ToString(Enumerator.Key.ToString()) + ","; 
							if(IsSelected == false)
							{
								IsSelected = true;
							}
						}
					 
					}
				}			

				if(IsSelected)
				{
					//Session["ItemList"] = strItemList.ToString().TrimEnd(',');
					//Response.Redirect("GenerateJobAdmitCard.aspx");
				 
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);	
					//RegisterClientScriptBlock("Post","<script language='javascript'>alert('No data found!')</script>");
			 
				 
				}
				else
				{
					lblSortExp.Text = strSortExp;
					SetStateCityCentreDropDown();
					PopulateCandidateList(strSortExp);				 
				}
			}
		}


		#endregion

		#region btnDeActive_Click()

		private void btnDeActive_Click(object sender, System.EventArgs e)
		{
			bool IsSelected = false; 
			StringBuilder sbItemList = new StringBuilder();

			SaveCheckedValueTemporary();

			Hashtable htCheckedValue = new Hashtable();
			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			if (htCheckedValue.Count != 0)
			{
				IDictionaryEnumerator Enumerator;
				Enumerator = htCheckedValue.GetEnumerator();
				while (Enumerator.MoveNext())
				{
					if(Convert.ToBoolean(Enumerator.Value))
					{
						//sbItemList.Append("'");
						sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));				 
						//sbItemList.Append("'");
						sbItemList.Append(",");
						if(IsSelected == false)
						{
							IsSelected = true;
						}
						 
					}
					 
				}
			}			 

			if(IsSelected)
			{
				sbItemList.Remove(sbItemList.Length - 1,1);
				Session["ItemList"] = sbItemList.ToString();
				DeactivateCandidate(sbItemList.ToString());
			}
			else
			{
				lblSortExp.Text = strSortExp;
				SetStateCityCentreDropDown();
				PopulateCandidateList(strSortExp);
			}
		}

		#endregion

		#region DeactivateCandidate()

		private void DeactivateCandidate(string strItemList)
		{
			int intTotalNumberOfDeactivate = 0;			 
			BLDeactiveCandidate objBLDeactiveCandidate = new BLDeactiveCandidate();
			objBLDeactiveCandidate.CandidateRegistrationList = strItemList;
			intTotalNumberOfDeactivate = objBLDeactiveCandidate.DeactivateCandidates(strItemList);
			strSortExp = lblSortExp.Text.ToString().Trim();
			intCurrentPage = dgSearch.CurrentPageIndex + 1;
			SetSearchParameter(strSortExp,intCurrentPage);			 
		 
		}

		#endregion

		protected void btnDeselectAll_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				ViewState["CheckedValue"] = null;
				Hashtable htCheckedValue = new Hashtable();
				ViewState["CheckedValue"] = htCheckedValue; 
			}
			else
			{
				ViewState["CheckedValue"] = null;
				Hashtable htCheckedValue = new Hashtable();
				ViewState["CheckedValue"] = htCheckedValue; 
			}
			
		}
		 
		

	}
}
