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
using System.IO;
using System.Text;
using Common;

namespace NASSCOM_NAC
{
	/// <summary>
	/// Summary description for EditRegistration.
	/// </summary>
	public partial class EditRegistration : System.Web.UI.Page
	{
		private int intStateId = 0;
		private int intPasswordCheck = 0;
		private string SerialNo = null;
		private string PinNo = null;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFirstName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMiddleName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvLastName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revLastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvDayDOB;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvMonthDOB;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvYearDOB;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvGender;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvResidentialAddress;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExpValidatorRA;
		protected System.Web.UI.WebControls.RegularExpressionValidator revCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPinCode;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPinCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvSTDCode;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPhoneNumber;
		protected System.Web.UI.WebControls.RegularExpressionValidator revSTDCode;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPhoneNumber;
		protected System.Web.UI.WebControls.RegularExpressionValidator revCellPhone;
		protected System.Web.UI.WebControls.RegularExpressionValidator revEmailID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvMothersName;
		protected System.Web.UI.WebControls.RegularExpressionValidator revMothersName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHouseholdIncome;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvYouBelongTo;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHighestEducationQualification;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPercentageScored;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPercentageSocred;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHighestEducationObtainedFrom;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHighestEducationCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEmploymentStatus;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvWillingToWorkOutOfHomeTown;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvTestCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvTestCentre;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvConfirmPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPhotoIdDocument;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPhotoIdNumber;
		protected System.Web.UI.WebControls.DropDownList ddlPGYear;
		protected System.Web.UI.WebControls.RadioButtonList rblPassport;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvGraduationYear;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvPGYear;
		protected System.Web.UI.WebControls.Label Label1;
		protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["PIN"] == null || Session["StateId"] == null)
			{
				Response.Redirect("PinLogin.aspx");				 
			}

			//Declaring stateid variable to populate Test City
			intStateId = Convert.ToInt32(Session["StateId"].ToString());
			//Declaring SerialNo and PinNo variable to populate Test City	
			SerialNo = Convert.ToString(Session["SerialNo"]);
			PinNo = Convert.ToString(Session["PIN"]);
			//Common.CLCommonFunctions.CheckSession();
			//Adding Attribute to populate ddlTestCity Combo on runtime
			//ddlTestCity.Attributes.Add("onchange","populate();");
			//Adding attribute to hide Specify Others text box, populate Qualification Details and changing college name.
			//ddlQualification.Attributes.Add("onchange","populateQualification();ChangeCollegeLabel();");
			ddlQualification.Attributes.Add("onchange","populateQualification();hideTextBox();ChangeCollegeLabel();");
			ddlPassport.Attributes.Add("onchange","HidePassport();");
			//Adding Attribute to validate user input while submition of page
			btnSave.Attributes.Add("OnClick", "javascript:return ValidateData()");
			//Adding Attribute to Initialize hdTestCentre(Hidden field) on runtime.
			//ddlTestCentre.Attributes.Add("onchange","fillHiddenCentre();");
			//ddlTestCentre.Attributes.Add("onblur","CheckCapacity();");		
			//Adding Attribute to check visibility of txtOtherQualification on certain condition
			ddlQualificationDetails.Attributes.Add("onchange","fillHiddenQualification();");
			
			txtFirstName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtMiddleName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtLastName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtCity.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			//Adding attribute to accept only numeric data in txtPinCode.
			txtPinCode.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			//Adding attribute to accept only numeric data in txtSTDCode.
			txtSTDCode.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			//Adding attribute to accept only numeric data in txtPhoneNumber.
			txtPhoneNumber.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			//Adding attribute to accept only numeric data in txtCellPhone.
			txtCellPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);ValidateMobile(this);");
			txtEmailID.Attributes.Add("onblur","ValidateEmailAddress(this);");
			txtMothersName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtFathersName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtPassport.Attributes.Add("onblur","fillOnlyAlphanumericValue(this);");
			txtHighestEducationObtainedFrom.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtPGSpecialization.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtHighestEducationCity.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtOtherQualification.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtPercentageScored.Attributes.Add("onblur","fillOnlyPercentageValue(this);");
			txtCurrentLocation.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtLanguageSkills.Attributes.Add("onblur", "fillonlyAlphaComma(this);");

			txtConfirmPassword.Attributes.Add("onblur","CheckConfirmPassword(this);");
			//Populating ddlQualificationDetails(Qualification Details) ComboBox on behalf of selected Highest Educational Qualification
			GenerateDDLQualification();
			//Populating ddlTestCentre(Test Centre) on behalf of selected Test City
			//GenerateDynamicDropdown(intStateId);
			if(!Page.IsPostBack)
			{
                //Modified by Sonali
                CLCommonFunctions objCLCommonFunctions = new CLCommonFunctions();
                DataTable objdt = new DataTable();

                objdt = objCLCommonFunctions.ReturnYearList(CLCommonFunctions.StartDOBDropdown);
                ddlYear.DataSource = objdt;
                ddlYear.DataTextField = "Year";
                ddlYear.DataValueField = "value";
                ddlYear.DataBind();

                objdt = objCLCommonFunctions.ReturnYearList(CLCommonFunctions.StartGraduationDropdown);
                ddlGraduationYear.DataSource = objdt;
                ddlGraduationYear.DataTextField = "Year";
                ddlGraduationYear.DataValueField = "value";
                ddlGraduationYear.DataBind();

                objdt = objCLCommonFunctions.ReturnYearList(CLCommonFunctions.Start12Dropdown);
                ddlPassingYear12th.DataSource = objdt;
                ddlPassingYear12th.DataTextField = "Year";
                ddlPassingYear12th.DataValueField = "value";
                ddlPassingYear12th.DataBind();
            
				
				lblMessage.Visible=false;
				divLblTestCity.Attributes.Add("style","Display:none");
				divLblTestCentre.Attributes.Add("style","Display:none");
				//Populating ddlQualification(Highest Educational Qualification) ComboBox
				FillQualificationType();
				//Populating ddlQualificationDetails(Qualification Details) ComboBox
				FillQualification();
				//Populating ddlTestCity(Test City) ComboBox.
				FillTestCity(SerialNo,PinNo);
				//Populating ddlTestCentre(Test Center) Combobox.
				FillTestCentre(SerialNo,PinNo);		
				//FillTestState();
				//Populating ddlPhotoIdDocument(Photo ID) Document Combobox
				FillPhotoIdDetail();
				//Populating ddlHouseholdIncome(Income Range) Combobox
				FillIncomeRange();
				//Populating Candidate details
				getCandidateDetail();

				
			}

			//Pre populate if centre and city is already allocated
			if(Session["SerialNo"] != null && Session["PIN"] != null && Session["State"] != null && Convert.ToInt32(Session["StateId"]) != 9 && Convert.ToInt32(Session["StateId"]) != 6)
			{
				BLTest objBLTest = new BLTest();
				DataSet dsPreAllocatedCentre = new DataSet();
				dsPreAllocatedCentre = (DataSet) objBLTest.PreAllocatedCentre(Convert.ToInt32(Session["SerialNo"]),Convert.ToString(Session["PIN"]), Convert.ToString(Session["State"]));
					 
				if(dsPreAllocatedCentre.Tables[0] != null)
				{
					if(dsPreAllocatedCentre.Tables[0].Rows.Count > 0)
					{
						ddlTestCity.SelectedValue = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CityId"]);
						lblTestCity.Text = ddlTestCity.SelectedItem.ToString();					    
						FillAllTestCentre(Convert.ToInt32(dsPreAllocatedCentre.Tables[0].Rows[0]["CityId"]));
						ddlTestCentre.SelectedValue = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CentreId"]); 
						hdTestCentre.Value = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CentreId"]); 
						hdTestCentreName.Value = ddlTestCentre.SelectedItem.ToString().Trim();
						lblTestCentre.Text = ddlTestCentre.SelectedItem.ToString();
						divDropTestCity.Attributes.Add("style","Display:none");
						divDropTestCentre.Attributes.Add("style","Display:none");
						divLblTestCity.Attributes.Remove("style");
						divLblTestCentre.Attributes.Remove("style");
						ddlTestCity.Enabled = false;
						ddlTestCentre.Enabled = false;
					}
				}
					 

			}

			//This is for Nagaland State
			//			if(Convert.ToInt32(Session["StateId"]) == 9)
			//			{
			//				 
			//				
			//				//ddlTestCentre.SelectedValue = "20"; 
			//				//hdTestCentre.Value = ddlTestCentre.SelectedValue; 
			//				//hdTestCentreName.Value = ddlTestCentre.SelectedItem.ToString();
			//				lblTestCentre.Text = "Each city has only one center. Name of the center will be published on the Admission Card.";
			//				lblTestCentre.ForeColor = System.Drawing.Color.Red;
			//				lblTestCentre.Font.Size = 8;
			//				//divDropTestCity.Attributes.Add("style","Display:none");
			//				divDropTestCentre.Attributes.Add("style","Display:none");
			//				//divLblTestCity.Attributes.Remove("style");
			//				divLblTestCentre.Attributes.Remove("style");
			//				ddlTestCity.Enabled = true;
			//				ddlTestCentre.Enabled = false;			
			//			}

			//This is for Gujarat State
			if(Convert.ToInt32(Session["StateId"]) == 100) //|| Convert.ToInt32(Session["StateId"]) == 6)
			{
				 
				
				//ddlTestCentre.SelectedValue = "20"; 
				//hdTestCentre.Value = ddlTestCentre.SelectedValue; 
				//hdTestCentreName.Value = ddlTestCentre.SelectedItem.ToString();
				lblTestCentre.Text = "Test date and name of your allotted test center will be given on your Admission Card.";
				lblTestCentre.ForeColor = System.Drawing.Color.Red;
				lblTestCentre.Font.Size = 8;
				//divDropTestCity.Attributes.Add("style","Display:none");
				divDropTestCentre.Attributes.Add("style","Display:none");
				//divLblTestCity.Attributes.Remove("style");
				divLblTestCentre.Attributes.Remove("style");
				ddlTestCity.Enabled = true;
				ddlTestCentre.Enabled = false;			
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

		#region FillTestCity()
		//Populating Test City Combobox
		private DataTable FillTestCity(int intStateId)
		{		 
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Test City combo to bind with FillTestCitySecond(DataTable) 
			//	BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId),"City","CityId");
			return objBLRegistration.FillTestCity(intStateId);
		}
		
		//Created By Manoj to Fill test city based on SerialNo and PinNo. Date: 15 Sept 2010
		private void FillTestCity(string SerialNo, string PinNo)
		{		 
			BLRegistration objBLRegistration = new BLRegistration();	
			//Passing Test City combo to bind with FillTestCitySecond(DataTable).
			BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(SerialNo,PinNo),"City","CityId");
		}
		#endregion

		#region FillAllTestCentre()

		public void FillAllTestCentre(int intCity)
		{
			 
			//Passing Test Center combo to bind with FillAllTestCentre(DataTable).
			DataTable dtTestCentre = new DataTable();
			BLRegistration objBLRegistration = new BLRegistration();			 
			dtTestCentre = (DataTable) objBLRegistration.FillAllTestCentre(intCity);
			BindDropDown(ref ddlTestCentre, dtTestCentre,"Centre","CentreId");
		}

		#endregion

		#region FillCity()
		//Populating Test City Combobox
		private void FillCity(int intStateId)
		{	
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Test City combo to bind with FillTestCitySecond(DataTable) 
			BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId),"City","CityId");
			//return objBLRegistration.FillTestCity(intStateId);
		}

		#endregion

		#region FillTestCentre()
		//Populating Test Center Combobox
		private void FillTestCentre()
		{
			//Initializing intCityId parameter with selected Test City value
			//intCityId = Convert.ToInt16(ddlTestCity.SelectedValue.ToString().Trim());
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Test Center combo to bind with FillTestCentre(DataTable)  
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentre(),"Centre","CentreId");
		}

		private void FillTestCentre(string SerialNo, string PinNo)
		{
			BLRegistration objBLRegistration = new BLRegistration();	
			//Passing Test City combo to bind with FillTestCitySecond(DataTable).
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCitySecond(SerialNo,PinNo),"Centre","CentreId");
		}

		#endregion

		#region FillTestCentreSecond()
		//Populating Test Center Combobox
		private void FillTestCentreSecond(int intCityId)
		{
			//Initializing intCityId parameter with selected Test City value
			//intCityId = Convert.ToInt16(ddlTestCity.SelectedValue.ToString().Trim());
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Test Center combo to bind with FillTestCentre(DataTable)  
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecond(intCityId),"Centre","CentreId");
		}

		#endregion

		#region FillTestState()
		//		private void FillTestState()
		//		{
		//			BLRegistration objBLRegistration = new BLRegistration();			 
		//			BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(),"State","StateId");
		//		}
		#endregion

		#region FillPhotoIdDetail()
		//Populating Photo ID Document Combobox
		private void FillPhotoIdDetail()
		{
			BLRegistration objBLRegistration = new BLRegistration();	
			//Passing Photo Id Document combo to bind with FillPhotoIdDetail(DataTable)
			BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(),"PhotoIdDocument","PhotoId");
		}

		#endregion

		#region FillIncomeRange()
		//Populating Income Range Combobox
		private void FillIncomeRange()
		{
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Household Income combo to bind with FillIncomeRange(DataTable)
			BindDropDown(ref ddlHouseholdIncome, objBLRegistration.FillIncomeRange(),"IncomeRange","IncomeRangeId");
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
		
		#region BindDropdown
		//Binding Combo Box with database value.
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{
			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

		}

		#endregion

		#region getCandidateDetail()
		//Populating Candidate Details
		private void getCandidateDetail()
		{
			int tempParam;
			string strRegistrationId = Session["UserID"].ToString();
			
			try
			{	
				BusinessLayer.BLRegistration oBLRegistration = new BusinessLayer.BLRegistration();
				//DataSet dsRegistration = oBLRegistration.PreviewCandidateDetails(strRegistrationId);
				oBLRegistration = (BLRegistration) Session["objBLRegistration"];
				txtFirstName.Text= oBLRegistration.FirstName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][1].ToString().Trim();
				txtMiddleName.Text= oBLRegistration.MiddleName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][2].ToString().Trim();
				txtLastName.Text= oBLRegistration.LastName.ToString().Trim();//dsRegistration.Tables[0].Rows[0][3].ToString().Trim();
				if(Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Day.ToString().Trim().Length == 1)
				{
					ddlDay.SelectedValue = "0" + Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Day.ToString().Trim();
				}
				else
				{
					ddlDay.SelectedValue = Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Day.ToString().Trim();
				}
				if(Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Month.ToString().Trim().Length == 1)
				{
					ddlMonth.SelectedValue = "0" + Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Month.ToString().Trim();
				}
				else
				{
					ddlMonth.SelectedValue = Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Month.ToString().Trim();
				}
				if(Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Year.ToString().Trim().Length == 1)
				{
					ddlYear.SelectedValue = "0" + Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Year.ToString().Trim();
				}
				else
				{
					ddlYear.SelectedValue = Convert.ToDateTime(oBLRegistration.DOB.ToString().Trim()).Year.ToString().Trim();
				}
				rblGender.SelectedValue = oBLRegistration.Gender.ToString().Substring(0,1);//txtResidentialAddress.Text.ToString().Trim();
				txtResidentialAddress.Text=oBLRegistration.ResidentialAddress.ToString().Trim().Replace("<BR>","\r\n");//dsRegistration.Tables[0].Rows[0][6].ToString().Trim().Replace("<BR>","\r");
				txtCity.Text=oBLRegistration.City.ToString().Trim();//dsRegistration.Tables[0].Rows[0][7].ToString().Trim();
				txtPinCode.Text=oBLRegistration.PinCode.ToString().Trim();//dsRegistration.Tables[0].Rows[0][8].ToString().Trim();
				txtSTDCode.Text = oBLRegistration.STDCode.ToString().Trim();//dsRegistration.Tables[0].Rows[0][9].ToString().Trim();
				txtPhoneNumber.Text= oBLRegistration.LandLine.ToString().Trim();//dsRegistration.Tables[0].Rows[0][10].ToString().Trim();
				txtCellPhone.Text= oBLRegistration.CellPhone.ToString().Trim();//dsRegistration.Tables[0].Rows[0][11].ToString().Trim();

				if(oBLRegistration.UploadPhotograph.ToString().Trim() != "")
				{
					imgUploadPhotograph.ImageUrl ="UploadedPhotograph/"+ oBLRegistration.UploadPhotograph.ToString().Trim();
				}
				else
				{
					imgUploadPhotograph.ImageUrl ="Images/defaultphoto.jpg";
				}

				//filUpload.Value = oBLRegistration.PhotoGraphLocalePath.ToString().Trim();
				txtEmailID.Text=oBLRegistration.EmailId.ToString().Trim();//dsRegistration.Tables[0].Rows[0][13].ToString().Trim();
				txtMothersName.Text=oBLRegistration.MothersFullname.ToString().Trim();//dsRegistration.Tables[0].Rows[0][14].ToString().Trim();
				txtFathersName.Text =oBLRegistration.FathersFullname.ToString().Trim();//dsRegistration.Tables[0].Rows[0][31].ToString().Trim();
				ddlHouseholdIncome.SelectedValue = oBLRegistration.AnnualHouseHoldIncome.ToString().Trim();//Convert.ToString(ddlHouseholdIncome.Items.FindByText(oBLRegistration.AnnualHouseHoldIncome.ToString().Trim()).Value);
				txtCollegeAddress.Text = oBLRegistration.CollegeAddress.ToString().Trim().Replace("<BR>","\r\n");//dsRegistration.Tables[0].Rows[0][34].ToString().Trim().Replace("<BR>","\r");
				ddlQualification.SelectedValue = oBLRegistration.HighestEducationalQualification.ToString().Trim();//dsRegistration.Tables[0].Rows[0][32].ToString();
				
				//New Fields added by deepak
				if (ddlQualification.SelectedItem.Text.ToString().Trim().ToLower()=="undergraduate/graduate")
				{					 
					divHighestEducationObtainedFrom.InnerText = "College Name:*";
					divHighestEducationYear.InnerText = "Year of Graduation:";
					//					dvGraduationYear.Visible=true;
					//					dvPGYear.Visible=false;
					//dvPGSpecialization.Visible=false;
					//dvPGSpecialization.Style.Add("display", "none"); 
					dvPGSpecialization.Attributes.Add("style","Display:none");
					//Response.Write("<script language=javascript>document.getElementById('dvPGSpecialization').style.display = '';</script>");
					if(oBLRegistration.YearOfGraduation.ToString().Trim()!= "Year")
					{						
						ddlGraduationYear.SelectedValue=oBLRegistration.YearOfGraduation.ToString().Trim();
					}
				}
				else
				{
					divHighestEducationObtainedFrom.InnerText = "College Name:*";
					divHighestEducationYear.InnerText = "Year of Post Graduation:";
					//					dvGraduationYear.Visible=false;
					//					dvPGYear.Visible=true;
					//dvPGSpecialization.Visible=true;					
					//dvPGSpecialization.Style.Add("display", ""); 
					dvPGSpecialization.Attributes.Add("style","Display:");
					if(oBLRegistration.PGSpecialization.ToString().Trim() != "")
					{											
						txtPGSpecialization.Text= oBLRegistration.PGSpecialization.ToString().Trim();
					}	 
				}				
								
				ddlPassingYear12th.SelectedValue=oBLRegistration.YearOfPassing12Th.ToString().Trim();
				txtCurrentLocation.Text = oBLRegistration.CurrentLocation.ToString().Trim();
				txtLanguageSkills.Text= oBLRegistration.LanguageSkills.ToString().Trim();

				if(Convert.ToBoolean(oBLRegistration.HavePassport.ToString().Trim()))
				{
					ddlPassport.SelectedValue = "Yes";
					//txtPassport.Visible=true;
					dvPassport1.Attributes.Add("style","");
					txtPassport.Text=oBLRegistration.PassportNo.ToString().Trim();
				}
				else
				{	
					//txtPassport.Visible=false;
					dvPassport1.Attributes.Add("style","Display:none");
					ddlPassport.SelectedValue = "No";
				}			
				
				//New Fields added by deepak End
				
				tempParam = Convert.ToInt32(oBLRegistration.HighestEducationalQualification.ToString());
				BindDropDown(ref ddlQualificationDetails, oBLRegistration.FillQualificationDetails(tempParam),"Qualification","QualificationId");
				
				ddlQualificationDetails.SelectedValue = oBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
				hdQualificationDetails.Value = oBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
				
				if((oBLRegistration.QualificationDetailName.ToString().Trim().ToLower() == "others"))
				{
					txtOtherQualification.Style.Add("display","");
					txtOtherQualification.Value = oBLRegistration.OtherQualification.ToString().Trim();//dsRegistration.Tables[0].Rows[0][36].ToString().Trim();
				}
				else
				{
					txtOtherQualification.Style.Add("display","none");
				}
				//Added by Shweta
				if(ddlQualificationDetails.SelectedItem.Text== "Others")
				{
					txtOtherQualification.Style.Add("display","");
					txtOtherQualification.Value = oBLRegistration.OtherQualification.ToString();
				}
				else
				{
					txtOtherQualification.Style.Add("display","none");
				}
				//Added by Shweta end
				txtPercentageScored.Text=oBLRegistration.AggregatePercentageScored.ToString().Trim();//dsRegistration.Tables[0].Rows[0][18].ToString(); 
				txtHighestEducationObtainedFrom.Text = oBLRegistration.University.ToString().Trim();//dsRegistration.Tables[0].Rows[0][19].ToString();
				txtHighestEducationCity.Text = oBLRegistration.EducationCity.ToString().Trim();//dsRegistration.Tables[0].Rows[0][20].ToString();
				if(Convert.ToBoolean(oBLRegistration.EmploymentStatus.ToString().Trim()))
				{
					rblEmploymentStatus.SelectedValue = "Employed";
				}
				else
				{
					rblEmploymentStatus.SelectedValue = "Unemployed";
				}
				//rblEmploymentStatus.SelectedValue = oBLRegistration.EmploymentStatus.ToString().Trim();//dsRegistration.Tables[0].Rows[0][21].ToString().Trim();
				if(Convert.ToBoolean(oBLRegistration.WillingToWorkOutOfHomeTown.ToString().Trim()))
				{
					rblWillingToWorkOutOfHomeTown.SelectedValue = "Yes";
				}
				else
				{
					rblWillingToWorkOutOfHomeTown.SelectedValue = "No";
				}
				//rblWillingToWorkOutOfHomeTown.SelectedValue = oBLRegistration.WillingToWorkOutOfHomeTown.ToString().Trim();//dsRegistration.Tables[0].Rows[0][22].ToString();
				//FillTestCity();
				tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(oBLRegistration.TestCity.ToString().Trim()).Value);
				ddlTestCity.SelectedValue = Convert.ToString(tempParam);
				FillTestCentreSecond(tempParam);

				ddlTestCentre.SelectedValue = oBLRegistration.TestCentre.ToString().Trim();
				hdTestCentre.Value = oBLRegistration.TestCentre.ToString().Trim();
				hdTestCentreName.Value = oBLRegistration.TestCentreName.ToString().Trim();
				ddlPhotoIdDocument.SelectedValue = oBLRegistration.PhotoIdDocument.ToString().Trim();//Convert.ToInt32(ddlPhotoIdDocument.Items.FindByText(oBLRegistration.PhotoIdDocument.ToString().Trim()).Value);
				txtPhotoIdNumber.Text = oBLRegistration.PhotoIdNumber.ToString().Trim();
				ddlMediumOfInstruction.SelectedValue=oBLRegistration.MediumOfInstructionUpTo10Th.ToString().Trim();
				ddlMediumOfInstructionIn12Th.SelectedValue=oBLRegistration.MediumOfInstructionUpTo12Th.ToString().Trim();//dsRegistration.Tables[0].Rows[0][26].ToString().Trim();
				if(Convert.ToBoolean(oBLRegistration.YouBelongTo.ToString().Trim()))
				{
					rblYouBelongTo.SelectedValue = "Village";
				}
				else
				{
					rblYouBelongTo.SelectedValue = "City";
				}

				//rblYouBelongTo.SelectedValue = oBLRegistration.YouBelongTo.ToString().Trim();//dsRegistration.Tables[0].Rows[0][27].ToString().Trim();
				txtPassword.Text = oBLRegistration.Password.ToString().Trim();//dsRegistration.Tables[0].Rows[0][35].ToString().Trim();
				txtConfirmPassword.Text = oBLRegistration.ConfirmPassword.ToString().Trim();//dsRegistration.Tables[0].Rows[0][35].ToString().Trim();
			}
			catch (Exception SysEx)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
		}
		
		#endregion

		#region ValidateControls()

		private bool ValidateControls()
		{
			
			//Added by Shweta
			lblMessage.Text="";
			BLRegistration objRegistration= new BLRegistration();
			DataTable dtQualification = new DataTable();
			dtQualification = objRegistration.FillQualification();
			DataRow[] dr = dtQualification.Select("QualificationTypeId="+ddlQualification.SelectedValue);
			int intChildRowCount = dtQualification.Rows.Count;
			objRegistration.QualificationDetail = Convert.ToInt32(hdQualificationDetails.Value.ToString());	
			if(Convert.ToInt32(Session["StateId"]) == 100) //|| Convert.ToInt32(Session["StateId"]) == 6)
			{
				BLTest objBLTest = new BLTest();
				objRegistration.TestCentre = objBLTest.GetTestCentreID(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
				objRegistration.TestCentreName = objBLTest.GetTestCentreName(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
				
			}
			else
			{
				objRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString().Trim();//ddlTestCentre.SelectedItem.ToString().Trim();
				objRegistration.TestCentreName = ddlTestCentre.SelectedItem.Text.ToString().Trim();
			}
			
			//Passing Qualification Details Document combo to bind with dtQualification(DataTable).
			//BindDropDown(ref ddlQualificationDetails, dtQualification,"Qualification","QualificationId");
			objRegistration.HighestEducationalQualification =Convert.ToInt32(ddlQualification.SelectedValue.ToString().Trim());
			int tempParam = Convert.ToInt32(objRegistration.HighestEducationalQualification.ToString());
			BindDropDown(ref ddlQualificationDetails, objRegistration.FillQualificationDetails(tempParam),"Qualification","QualificationId");
			if(tempParam != 0)
			{

				for(int i=0; i<= ddlQualificationDetails.Items.Count-1; i++)
				{
					if(ddlQualificationDetails.Items[i].Value.ToString() == objRegistration.QualificationDetail.ToString().Trim())
					{ddlQualificationDetails.SelectedValue = objRegistration.QualificationDetail.ToString().Trim();}
				}
				//					ddlQualificationDetails.SelectedValue = objRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
			}
			
			hdQualificationDetails.Value = objRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
			if(ddlQualificationDetails.SelectedItem.Text== "Others")
			{
				txtOtherQualification.Style.Add("display","");
				objRegistration.OtherQualification = txtOtherQualification.Value.ToString().Trim();
				txtOtherQualification.Value = objRegistration.OtherQualification.ToString();
			}
			else
			{
				txtOtherQualification.Style.Add("display","none");
			}
			if(ddlTestCity.SelectedValue.ToString().Trim() != "0")
			{
				objRegistration.TestCity = ddlTestCity.SelectedItem.ToString().Trim();
				tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(objRegistration.TestCity.ToString().Trim()).Value);
				ddlTestCity.SelectedValue = Convert.ToString(tempParam);
				FillTestCentreSecond(tempParam);
				//ddlTestCentre.SelectedValue = objRegistration.TestCentre.ToString().Trim();
				if(tempParam != 0)
				{
					for(int i=0; i<= ddlTestCentre.Items.Count-1; i++)
					{
						if(ddlTestCentre.Items[i].Value.ToString() == objRegistration.TestCentre.ToString().Trim())
						{ddlTestCentre.SelectedValue = objRegistration.TestCentre.ToString().Trim();}
					}
				}
				hdTestCentre.Value = objRegistration.TestCentre.ToString().Trim();
				hdTestCentreName.Value = objRegistration.TestCentreName.ToString().Trim();
				//ddlTestCentre.SelectedValue = objRegistration.TestCentreName.ToString().Trim();
			}
			
			
			if(txtFirstName.Text.ToString().Trim()== "")
			{
				txtFirstName.BackColor= System.Drawing.Color.Yellow;
				return false;
			}
			else
			{
				txtFirstName.BackColor= System.Drawing.Color.White;
				
			}
			if(txtLastName.Text.ToString().Trim()== "")
			{
				txtLastName.BackColor= System.Drawing.Color.Yellow;
				return false;
			}
			else
			{
				txtLastName.BackColor= System.Drawing.Color.White;
				
			}
	
			if(ddlDay.SelectedValue.ToString().Trim() == "0")
			{
				ddlDay.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlDay.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlMonth.SelectedValue.ToString().Trim() == "0")
			{
				ddlMonth.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlMonth.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlYear.SelectedValue.ToString().Trim() == "0")
			{
				ddlYear.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlYear.BackColor= System.Drawing.Color.White;
				
			}
			if(rblGender.SelectedValue.ToString().Trim()== "")
			{
				lblMessage.Text="";
				lblMessage.Visible=true;
				lblMessage.Text="** Please select Gender";
				return false;
			}
			if(txtResidentialAddress.Text.ToString().Trim()== "")
			{
				txtResidentialAddress.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtResidentialAddress.BackColor= System.Drawing.Color.White;
				
			}
			if(txtCity.Text.ToString().Trim()== "")
			{
				txtCity.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtCity.BackColor= System.Drawing.Color.White;
				
			}
			if(txtPinCode.Text.ToString().Trim()== "")
			{
				txtPinCode.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtPinCode.BackColor= System.Drawing.Color.White;
				
			}
			if(txtSTDCode.Text.ToString().Trim()== "")
			{
				txtSTDCode.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtSTDCode.BackColor= System.Drawing.Color.White;
				
			}
			if(txtPhoneNumber.Text.ToString().Trim()== "")
			{
				txtPhoneNumber.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtPhoneNumber.BackColor= System.Drawing.Color.White;
				
			}
			if(txtMothersName.Text.ToString().Trim()== "")
			{
				txtMothersName.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtMothersName.BackColor= System.Drawing.Color.White;
				
			}
			if(txtFathersName.Text.ToString().Trim()== "")
			{
				txtFathersName.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtFathersName.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlHouseholdIncome.SelectedValue.ToString().Trim() == "0")
			{
				ddlHouseholdIncome.BackColor= System.Drawing.Color.Yellow;
				return false;
			
			}
			else
			{
				ddlHouseholdIncome.BackColor= System.Drawing.Color.White;
				
			}
			if(rblYouBelongTo.SelectedValue.ToString().Trim()== "")
			{
				lblMessage.Text="";
				lblMessage.Visible=true;
				lblMessage.Text="** Please select You Belong To ";
				return false;
			}
			if(ddlQualification .SelectedValue.ToString().Trim() == "0")
			{
				ddlQualification.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlQualification.BackColor= System.Drawing.Color.White;
				
			}
			if(txtHighestEducationObtainedFrom.Text.ToString().Trim()== "")
			{
				txtHighestEducationObtainedFrom.BackColor= System.Drawing.Color.Yellow;		
				return false;

			}
			else
			{
				txtHighestEducationObtainedFrom.BackColor= System.Drawing.Color.White;
				
			}
			if(txtCollegeAddress.Text.ToString().Trim()== "")
			{
				txtCollegeAddress.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtCollegeAddress.BackColor= System.Drawing.Color.White;
				
			}
			if(txtHighestEducationCity.Text.ToString().Trim()== "")
			{
				txtHighestEducationCity.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtHighestEducationCity.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlQualificationDetails .SelectedValue.ToString().Trim() == "0")
			{
				ddlQualificationDetails.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlQualificationDetails.BackColor= System.Drawing.Color.White;
				
			}

			if(hdQualificationDetails.Value.ToString().Trim() == "0")
			{
				ddlQualificationDetails.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlQualificationDetails.BackColor= System.Drawing.Color.White;
				
			}

			if(txtPercentageScored.Text.ToString().Trim()== "")
			{
				txtPercentageScored.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtPercentageScored.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlMediumOfInstruction.SelectedValue.ToString().Trim() == "0")
			{
				ddlMediumOfInstruction.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlMediumOfInstruction.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim() == "0")
			{
				ddlMediumOfInstructionIn12Th.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlMediumOfInstructionIn12Th.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlPassingYear12th.SelectedValue.ToString().Trim() == "0")
			{
				ddlPassingYear12th.BackColor=System.Drawing.Color.Yellow;
				return false;
			}
			else
			{
				ddlPassingYear12th.BackColor= System.Drawing.Color.White;
				
			}
			if(rblEmploymentStatus.SelectedValue.ToString().Trim()== "")
			{
				lblMessage.Text="";
				lblMessage.Visible=true;
				lblMessage.Text="** Please select Employment Status ";
				return false;
			}
			if(txtCurrentLocation.Text.ToString().Trim()=="")
			{
				txtCurrentLocation.BackColor=System.Drawing.Color.Yellow;	
				return false;
			}
			else
			{
				txtCurrentLocation.BackColor= System.Drawing.Color.White;
				
			}
			if(txtLanguageSkills.Text.ToString().Trim()=="")
			{
				txtLanguageSkills.BackColor=System.Drawing.Color.Yellow;	
				return false;
			}
			else
			{
				txtLanguageSkills.BackColor= System.Drawing.Color.White;
				
			}
			if(rblWillingToWorkOutOfHomeTown.SelectedValue.ToString().Trim()== "")
			{
				lblMessage.Text="";
				lblMessage.Visible=true;
				lblMessage.Text="** Please select Willing To Work Out Of Home Town ";
				return false;
			}
			if(ddlPassport.SelectedValue.ToString().Trim() == "0")
			{
				ddlPassport.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlPassport.BackColor= System.Drawing.Color.White;
				
			}
			if(ddlPassport.SelectedValue.ToString().Trim()=="Yes")
			{
				if(txtPassport.Text.ToString().Trim()=="")
				{
					txtPassport.BackColor=System.Drawing.Color.Yellow;	
					return false;
				}
			}
			else
			{
				txtPassport.BackColor=System.Drawing.Color.White;

			}
			if(ddlTestCity.SelectedValue.ToString().Trim() == "0")
			{
				ddlTestCity.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlTestCity.BackColor=System.Drawing.Color.White;

			}
			
			if(	hdTestCentre.Value.ToString().Trim() == "0")
			{
				ddlTestCentre.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlTestCentre.BackColor=System.Drawing.Color.White;

			}
			if(	ddlTestCentre.SelectedValue.ToString().Trim() == "0")
			{
				ddlTestCentre.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlTestCentre.BackColor=System.Drawing.Color.White;

			}
			if(txtPassword.Text.ToString().Trim()== "")
			{
				txtPassword.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtPassword.BackColor=System.Drawing.Color.White;
				hdpassword.Value = txtPassword.Text;
				txtPassword.Attributes.Add("value", hdpassword.Value);

			}
			if(txtConfirmPassword.Text.ToString().Trim()== "")
			{
				
				txtConfirmPassword.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtConfirmPassword.BackColor=System.Drawing.Color.White;
				hdconfpassword.Value = txtConfirmPassword.Text;
				txtConfirmPassword.Attributes.Add("value", hdconfpassword.Value);

			}
			if(ddlPhotoIdDocument.SelectedValue.ToString().Trim() == "0")
			{
				ddlPhotoIdDocument.BackColor= System.Drawing.Color.Yellow;				
				return false;
			}
			else
			{
				ddlPhotoIdDocument.BackColor=System.Drawing.Color.White;

			}
			if(txtPhotoIdNumber.Text.ToString().Trim()== "")
			{
				txtPhotoIdNumber.BackColor= System.Drawing.Color.Yellow;		
				return false;
			}
			else
			{
				txtPhotoIdNumber.BackColor=System.Drawing.Color.White;

			}

            if (chkAuthorization.Checked == false)
            {
                chkAuthorization.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPhotoIdNumber.BackColor = System.Drawing.Color.White;

            }
            //aku
            if (filUpload.PostedFile  == null)
            {
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please upload your photograph";
                return false;
            }

            if (filUpload.PostedFile != null)
            {
                if (filUpload.PostedFile.ContentLength > 1048576)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your image size is more than 1MB";
                    return false;
                }
                else
                {
                    if ((filUpload.PostedFile.ContentLength == 0) && (filUpload.PostedFile.FileName  !=""))
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Your image size is less than 1KB";
                        return false;
                    }
                }
            }   
			//Added by Shweta
			//			BLRegistration objRegistration= new BLRegistration();
			//			intPasswordCheck= objRegistration.IsPWDExits(ddlPhotoIdDocument.SelectedValue.ToString().Trim(), txtPhotoIdNumber.Text.ToString().Trim(),txtPassword.Text.ToString().Trim());
			//			
			//			if(intPasswordCheck== 1)
			//			{
			//				lblMessage.Visible = true;
			//				lblMessage.Text = "This passowrd already in use.";
			//				txtPassword.BackColor= System.Drawing.Color.Yellow;
			//				txtConfirmPassword.BackColor= System.Drawing.Color.Yellow;	
			//				return false;
			//			}
			if(hdImagepath.Value=="true")
			{
				string jScript;
				jScript = "<Script Language=Javascript>alert('Please select again Photo to Upload')</Script>";
				Page.RegisterStartupScript("keyClientBlock", jScript);
				hdImagepath.Value="";
				return false;
			}
			//Added by Shweta end
			return true;
		}
 

		#endregion
		
		#region UpdateCandidate
		//Updating Candidate details 
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if(ValidateControls())
			{
				string strRegistrationId = Session["UserID"].ToString();
				try
				{
					BLRegistration objBLRegistration = new BLRegistration();
					objBLRegistration = (BLRegistration) Session["objBLRegistration"];
					objBLRegistration.FirstName = txtFirstName.Text.ToString().Trim();
					objBLRegistration.MiddleName = txtMiddleName.Text.ToString().Trim();
					objBLRegistration.LastName = txtLastName.Text.ToString().Trim();
					objBLRegistration.DOB = Convert.ToDateTime(ddlDay.SelectedItem.ToString() + "/" + ddlMonth.SelectedItem.ToString() + "/" + ddlYear.SelectedItem.ToString());
					objBLRegistration.Gender = rblGender.SelectedValue.ToString().Trim();
					if(rblGender.SelectedValue.ToString().Trim() == "M")
					{
				 
						objBLRegistration.GenderName = "Male";
					}
					else
					{
						objBLRegistration.GenderName = "Female";
					} 
					objBLRegistration.ResidentialAddress = txtResidentialAddress.Text.ToString().Trim().Replace("\r\n","<BR>");
					objBLRegistration.City = txtCity.Text.ToString().Trim();
					objBLRegistration.PinCode = txtPinCode.Text.ToString().Trim();
					objBLRegistration.STDCode = txtSTDCode.Text.ToString().Trim();
					objBLRegistration.LandLine = txtPhoneNumber.Text.ToString().Trim();
					objBLRegistration.CellPhone = txtCellPhone.Text.ToString().Trim();
					if(Convert.ToString(filUpload.PostedFile.FileName) != "")
					{
						objBLRegistration.UploadPhotograph = GetImageFileExtension();
					}

					else if(hdImage.Value != "-1")
					{
						BusinessLayer.BLRegistration oBLRegistration2 = new BusinessLayer.BLRegistration();
						//DataSet dsRegistration = oBLRegistration.PreviewCandidateDetails(strRegistrationId);
						oBLRegistration2 = (BLRegistration) Session["objBLRegistration"];
						objBLRegistration.UploadPhotograph = oBLRegistration2.UploadPhotograph;
					}

					else
					{
					objBLRegistration.UploadPhotograph = "";
					}
				
					objBLRegistration.EmailId = txtEmailID.Text.ToString().Trim();
					objBLRegistration.MothersFullname = txtMothersName.Text.ToString().Trim();
					objBLRegistration.FathersFullname = txtFathersName.Text.ToString().Trim();
					objBLRegistration.AnnualHouseHoldIncome =Convert.ToInt32(ddlHouseholdIncome.SelectedValue.ToString().Trim());
					objBLRegistration.AHHIName = ddlHouseholdIncome.SelectedItem.ToString().Trim();
					if(rblYouBelongTo.SelectedValue.ToString().Trim() == "Village")
					{
						objBLRegistration.YouBelongTo = true;
						objBLRegistration.YBTName = "Village";
					}
					else
					{
						objBLRegistration.YouBelongTo = false;
						objBLRegistration.YBTName = "City";
					} 
					objBLRegistration.HighestEducationalQualification =Convert.ToInt32(ddlQualification.SelectedValue.ToString().Trim());
					objBLRegistration.HEQName = ddlQualification.SelectedItem.ToString().Trim();
					//objBLRegistration.QualificationDetail = ddlQualificationDetails.SelectedValue.ToString().Trim();	
					objBLRegistration.QualificationDetail =Convert.ToInt32(hdQualificationDetails.Value);	
					objBLRegistration.QualificationDetailName = ddlQualificationDetails.SelectedItem.ToString().Trim();	

					objBLRegistration.University = txtHighestEducationObtainedFrom.Text.ToString().Trim();
					objBLRegistration.CollegeAddress = txtCollegeAddress.Text.ToString().Trim().Replace("\r\n","<BR>");
					objBLRegistration.EducationCity = txtHighestEducationCity.Text.ToString().Trim();
					objBLRegistration.AggregatePercentageScored = Convert.ToInt32(txtPercentageScored.Text.ToString().Trim());
					objBLRegistration.HighestEducationObtainedFrom = txtHighestEducationObtainedFrom.Text.ToString().Trim();
					objBLRegistration.HighestEducationObtainedCity = txtHighestEducationCity.Text.ToString().Trim();
					objBLRegistration.MediumOfInstructionUpTo10Th = ddlMediumOfInstruction.SelectedValue.ToString().Trim();
					objBLRegistration.MediumOfInstructionUpTo12Th = ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim();
					
					//New Fields Added by deepak
					objBLRegistration.YearOfPassing12Th=Convert.ToInt32(ddlPassingYear12th.SelectedItem.ToString().Trim());
					objBLRegistration.YearOfGraduation=Convert.ToInt32(ddlGraduationYear.SelectedValue.ToString().Trim());
					
					objBLRegistration.PGSpecialization = txtPGSpecialization.Text.ToString().Trim();
					objBLRegistration.CurrentLocation = txtCurrentLocation.Text.ToString().Trim();
					objBLRegistration.LanguageSkills = txtLanguageSkills.Text.ToString().Trim();

					if(ddlPassport.SelectedValue.ToString().Trim() == "Yes")
					{
						objBLRegistration.HavePassport = true;
						objBLRegistration.HavePassportName="Yes";					
						objBLRegistration.PassportNo = txtPassport.Text.ToString().Trim();				

					}
					else
					{
						objBLRegistration.HavePassport = false;
						objBLRegistration.HavePassportName = "No";
					}				
					//New Fields Added by deepak end

					if(rblEmploymentStatus.SelectedValue.ToString().Trim() == "Employed")
					{
						objBLRegistration.EmploymentStatus = true;
						objBLRegistration.EmploymentStatusName = "Employed";
					}
					else
					{
						objBLRegistration.EmploymentStatus = false;
						objBLRegistration.EmploymentStatusName = "Unemployed";
					}			
					if(rblWillingToWorkOutOfHomeTown.SelectedValue.ToString().Trim() == "Yes")
					{
						objBLRegistration.WillingToWorkOutOfHomeTown = true;
						objBLRegistration.WillingToWOUHTName = "Yes";
					}
					else
					{
						objBLRegistration.WillingToWorkOutOfHomeTown = false;
						objBLRegistration.WillingToWOUHTName = "No";
					}
					objBLRegistration.TestCity = ddlTestCity.SelectedItem.ToString().Trim();
					//objBLRegistration.TestCentre = hdTestCentre.Value.ToString().Trim();
					if(Convert.ToInt32(Session["StateId"]) == 100) //|| Convert.ToInt32(Session["StateId"]) == 6)
					{
						BLTest objBLTest = new BLTest();
						objBLRegistration.TestCentre = objBLTest.GetTestCentreID(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
						objBLRegistration.TestCentreName = objBLTest.GetTestCentreName(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
				
					} 
					else
					{
						objBLRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString().Trim();//ddlTestCentre.SelectedItem.ToString().Trim();
						objBLRegistration.TestCentreName = ddlTestCentre.SelectedItem.Text.Trim();
					}
					//objBLRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString().Trim();
					//objBLRegistration.TestCentreName = hdTestCentreName.Value.ToString().Trim();
					objBLRegistration.Password = txtPassword.Text.ToString().Trim();
					objBLRegistration.ConfirmPassword = txtConfirmPassword.Text.ToString().Trim();
					objBLRegistration.PhotoIdDocument = ddlPhotoIdDocument.SelectedValue.ToString().Trim();
					objBLRegistration.PhotoIdDocumentName = ddlPhotoIdDocument.SelectedItem.ToString().Trim();
					objBLRegistration.PhotoIdNumber = txtPhotoIdNumber.Text.ToString().Trim();
					if (txtOtherQualification.Value.ToString().Trim() == "Specify other")
					{
						txtOtherQualification.Value = "";
						objBLRegistration.OtherQualification = txtOtherQualification.Value;
					}
					else
					{
						objBLRegistration.QualificationDetailName = hdQualificationDetailsName.Value.ToString().ToLower().Trim();
						objBLRegistration.OtherQualification = txtOtherQualification.Value;
					}
				
				
					if((filUpload.PostedFile != null) && (filUpload.PostedFile.FileName != ""))
					{
						objBLRegistration.UploadPhotograph = UploadPhotograph(strRegistrationId);
					}
					intPasswordCheck= objBLRegistration.IsPWDExits(ddlPhotoIdDocument.SelectedValue.ToString().Trim(), txtPhotoIdNumber.Text.ToString().Trim(),txtPassword.Text.ToString().Trim());
			
					if(intPasswordCheck== 1)
					{
						string jScript;
						jScript = "<Script Language=Javascript>alert('This Password already exits.')</Script>";
						Page.RegisterStartupScript("keyClientBlock", jScript);
						txtPassword.BackColor= System.Drawing.Color.Yellow;
						txtConfirmPassword.BackColor= System.Drawing.Color.Yellow;
						txtPassword.Text="";
						txtConfirmPassword.Text="";
						hdpassword.Value="";
						hdconfpassword.Value="";
						txtConfirmPassword.Attributes.Add("value", hdconfpassword.Value);
						txtPassword.Attributes.Add("value", hdpassword.Value);
						if(ddlQualificationDetails.SelectedItem.Text== "Others")
						{
							txtOtherQualification.Style.Add("display","");
							txtOtherQualification.Value = objBLRegistration.OtherQualification.ToString();
						}
						else
						{
							txtOtherQualification.Style.Add("display","none");
						}
						return;
					}
					Session["objBLRegistration"] = objBLRegistration;

					//Response.Redirect("RegistrationPreview.aspx?RegistrationId="+strRegistrationId);
				}
				catch(Exception SysEx)
				{
					//Calling ErrorRoutine of ErrorLogger to write error text in text file.
					ErrorLogger.ErrorRoutine(false,SysEx);
					//To Pass Execption in exception class for show exception
					ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				}
				Response.Redirect("RegistrationPreview.aspx?RegistrationId="+strRegistrationId);
			}
		}

		#endregion
		
		#region GetImageFileExtension()
		//Returning file extention as string.
		private string GetImageFileExtension()
		{
			string strExtension = "";
			//Initializing fn string variable with current file name.
			//string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);
			//Validating that file has been posted through control or it is blank.
			if (filUpload.PostedFile == null || System.IO.Path.GetFileName(filUpload.PostedFile.FileName)=="")
			{				 
				return strExtension;
			}
			else
			{
				hdImagepath.Value = "true";
				return strExtension = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);// + System.IO.Path.GetExtension(filUpload.PostedFile.FileName);		 
			}
		}

		#endregion

		#region Uploaded Photograph
		//Returning file name after uploading it on UploadedPhotograph.
		private string UploadPhotograph(string strRegistrationId)
		{
			//Response.Cache.SetCacheability(HttpCacheability.NoCache);
			//Initializing baseLocation string with path of folder where file to be uploaded.
			string baseLocation =  Server.MapPath(".")+ "\\UploadedPhotograph\\";
			string strFileName = "";
			//Validating that file has been posted or not.
			if (filUpload.PostedFile == null)// || System.IO.Path.GetFileName(filUpload.PostedFile.FileName)=="")
			{				 
				return strFileName;
			}
			else
			{
				try
				{
					//Initializing fn string with current file name.
					string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);

					ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
					imgCompress.GetImage = new System.Drawing.Bitmap(filUpload.PostedFile.InputStream);
					imgCompress.Height = 110;
					imgCompress.Width = 95;
					//Compressing and uploading file in UploadedPhotograph root folder.
					imgCompress.Save(strRegistrationId +  fn, @baseLocation);
					strFileName = strRegistrationId + fn; 
				}
				catch(Exception ex)
				{
					//Calling ErrorRoutine of ErrorLogger to write error text in text file.
					ErrorLogger.ErrorRoutine(false,ex);
				}
				return strFileName ; 
			}
		}


		#endregion

		#region FillQualificationType()
		//Populating heighest education qualification
		private void FillQualificationType()
		{
			//Creating Instance of BLRegistration
			BLRegistration objBLRegistration = new BLRegistration();
			//Adding "Select" text on the top of Heighest Qualification
			ddlQualification.Items.Add("Select");
			//Passing Heighest Qualification combo to bind with FillQualificationTypeSecond(DataTable)
			BindDropDown(ref ddlQualification, objBLRegistration.FillQualificationTypeSecond(),"QualificationType","QualificationTypeId");
		}

		#endregion
		
		#region GenerateDynamicDropdown()
		//Creating script to populate Test Center on behalf of selected Test City
		private void GenerateDynamicDropdown(int intStateId)
		{  
			DataTable dtTestCentre = new DataTable();
			DataTable dtTestCity = new DataTable();
			StringBuilder sbAppend = new StringBuilder();
			int intInnerIncrementLoop = 0;
			int intOuterIncrementLoop = 0;
			int intParentRowCount = 0;
			int intChildRowCount = 0;
			BLRegistration objBLRegistration = new BLRegistration();
			dtTestCentre = objBLRegistration.FillTestCentre();
			dtTestCity = FillTestCity(intStateId);
			sbAppend.Append("<script language='javascript' type='text/javascript'> ");	
			sbAppend.Append("function populate(){ ");
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
				 
					sbAppend.Append("}");
					sbAppend.Append(" ");
					sbAppend.Append("function CheckCapacity()");
					sbAppend.Append("{");
					sbAppend.Append("var boxTestCentre = document.getElementById('ddlTestCentre');");
					sbAppend.Append("var col = boxTestCentre.options[boxTestCentre.selectedIndex].value;  ");
					sbAppend.Append("var boxTestCity = document.getElementById('ddlTestCity');");
					sbAppend.Append("var row = boxTestCity.options[boxTestCity.selectedIndex].value;  ");

					sbAppend.Append("var CentreIdAndFlag = new Array( ");
					sbAppend.Append(intParentRowCount);
					sbAppend.Append("); ");

					if(intParentRowCount > 0 && intChildRowCount > 0)
					{
						for(intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
						{

							sbAppend.Append("CentreIdAndFlag[");
							sbAppend.Append(Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim())); 
							sbAppend.Append("] = new Array(");
							sbAppend.Append(intChildRowCount);
							sbAppend.Append(");");

							for(intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
							{
								sbAppend.Append("CentreIdAndFlag[");
								sbAppend.Append(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim());						
								sbAppend.Append(",");
								sbAppend.Append(dtTestCentre.Rows[intInnerIncrementLoop]["CentreId"].ToString().Trim());						
								sbAppend.Append("]  ");	
								sbAppend.Append("=  ");
								sbAppend.Append("'");
								sbAppend.Append(dtTestCentre.Rows[intInnerIncrementLoop]["Flag"].ToString().Trim());
								sbAppend.Append("';");
							}
						}
					}	

			        
					sbAppend.Append("if (CentreIdAndFlag[row,col] == 1){ alert('All seats at this center are full. Please choose any other center.'); document.getElementById('ddlTestCentre').focus(); return false; } else { return true;}");
					
					sbAppend.Append("}");
					sbAppend.Append("</script> ");
					Response.Write(sbAppend.ToString());
				}
			}
		}

		#endregion

		#region FillQualification()
		//Populating qualification details
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
			//Passing Qualification Details Document combo to bind with dtQualification(DataTable) 
			BindDropDown(ref ddlQualificationDetails, dtQualification,"Qualification","QualificationId");
		}
		#endregion

		#region Remove Image
		private void btnRemoveImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				BLRegistration objBLRegistration = new BLRegistration();
				objBLRegistration = (BLRegistration) Session["objBLRegistration"];
				objBLRegistration.UploadPhotograph = "";
				Session["objBLRegistration"] = objBLRegistration;
				//Creating object of BLRegistration for calling RemovePhotograph() function.
				//BLRegistration objRemovePhotograph = new BLRegistration();
				//Removing photo name of candidate.
				//objRemovePhotograph.RemovePhotograph(Session["UserID"].ToString());
			}
			catch (Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
			getCandidateDetail();
		}
		#endregion



	}
}