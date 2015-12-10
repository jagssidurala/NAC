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

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Edit_Registration.
	/// </summary>
	public partial class Edit_Registration : System.Web.UI.Page
	{
		//private int intStateId = 0;
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
		public int CandidateId;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{	 
			 
			//Adding Attribute to populate ddlTestCity Combo on runtime
			ddlTestCity.Attributes.Add("onchange","populate();");
			//Adding attribute to hide Specify Others text box, populate Qualification Details and changing college name.
			ddlQualification.Attributes.Add("onchange","populateQualification();ChangeCollegeLabel();");
			//Adding Attribute to validate user input while submition of page
			btnSave.Attributes.Add("OnClick", "javascript:return ValidateData()");
			//Adding Attribute to Initialize hdTestCentre(Hidden field) on runtime.
			ddlTestCentre.Attributes.Add("onchange","fillHiddenCentre();");
			ddlTestCentre.Attributes.Add("onblur","CheckCapacity();");		
			//Adding Attribute to check visibility of txtOtherQualification on certain condition
			ddlQualificationDetails.Attributes.Add("onchange","fillHiddenQualification();");
			
			txtPinCode.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			txtSTDCode.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			txtPhoneNumber.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			txtCellPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			txtPercentageScored.Attributes.Add("onblur","fillOnlyNumericValue(this);");
			txtFirstName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtMiddleName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtLastName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtCity.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtMothersName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtFathersName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);");
			txtEmailID.Attributes.Add("onblur","ValidateEmailAddress(this);");
		ddlPassport.Attributes.Add("onchange","HidePassport();");	
			//Populating ddlQualificationDetails(Qualification Details) ComboBox on behalf of selected Highest Educational Qualification
			GenerateDDLQualification();
			
			if(!Page.IsPostBack)
            {
                int thisYear = Convert.ToInt32(System.DateTime.Now.Year) + 1;
                ddlYear.Items.Add(new ListItem("Year", "0"));
                ddlGraduationYear.Items.Add(new ListItem("Year", "0"));
                ddlPassingYear12th.Items.Add(new ListItem("Year", "0"));
                for (int i = thisYear; i >= 1949; i--)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlGraduationYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlPassingYear12th.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }

                //ListItem lsitem = new ListItem("Year", "0");
                //ddlYear.Items.Insert(0, lsitem);
                //ddlGraduationYear.Items.Insert(0, lsitem);
                //ddlPassingYear12th.Items.Insert(0, lsitem);
            

				divLblTestCity.Attributes.Add("style","Display:none");
				divLblTestCentre.Attributes.Add("style","Display:none");
				//Populating ddlQualification(Highest Educational Qualification) ComboBox
				FillQualificationType();
				//Populating ddlQualificationDetails(Qualification Details) ComboBox
				FillQualification();
				//Populating ddlTestCity(Test City) ComboBox
			//	FillCity(intStateId);
				//Populating ddlTestCentre(Test Center) Combobox
				FillTestCentre();
				//FillTestState();
				//Populating ddlPhotoIdDocument(Photo ID) Document Combobox
				FillPhotoIdDetail();
				//Populating ddlHouseholdIncome(Income Range) Combobox
				FillIncomeRange();
				//Populating Candidate details
				getCandidateDetail();

				
			}
			//Populating ddlTestCentre(Test Centre) on behalf of selected Test City
			GenerateDynamicDropdown(Convert.ToInt32(Session["StateId"]));

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
			BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCity(intStateId),"City","CityId");
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
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillCentre(),"Centre","CentreId");
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

		#region FillTestCentreSecondAdmin()

		//Populating Test Center Combobox
		private void FillTestCentreSecondAdmin(int intCityId)
		{
			//Initializing intCityId parameter with selected Test City value
			//intCityId = Convert.ToInt16(ddlTestCity.SelectedValue.ToString().Trim());
			BLRegistration objBLRegistration = new BLRegistration();
			//Passing Test Center combo to bind with FillTestCentre(DataTable)  
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecondAdmin(intCityId),"Centre","CentreId");
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
			//string strRegistrationId = Session["UserID"].ToString();
			string strRegistrationId = Request.QueryString["CandidateID"].ToString(); 
			//Storing State ID
			
			try
			{	
				BusinessLayer.BLRegistration oBLRegistration = new BusinessLayer.BLRegistration();
				DataSet dsRegistration = oBLRegistration.PreviewCandidateDetailsforAdmin(strRegistrationId);
				Session["StateId"]=Convert.ToInt32(dsRegistration.Tables[0].Rows[0][37]);
				
				txtFirstName.Text= dsRegistration.Tables[0].Rows[0][1].ToString().Trim();
				txtMiddleName.Text=dsRegistration.Tables[0].Rows[0][2].ToString().Trim();
				txtLastName.Text= dsRegistration.Tables[0].Rows[0][3].ToString().Trim();

				string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()));
				
				if(Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Day.ToString().Trim().Length == 1)
				{
					ddlDay.SelectedValue = "0" + Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Day.ToString().Trim();
				}
				else
				{
					ddlDay.SelectedValue = Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Day.ToString().Trim();
				}
				if(Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Month.ToString().Trim().Length == 1)
				{
					ddlMonth.SelectedValue = "0" + Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Month.ToString().Trim();
				}
				else
				{
					ddlMonth.SelectedValue = Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Month.ToString().Trim();
				}
				if(Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Year.ToString().Trim().Length == 1)
				{
					ddlYear.SelectedValue = "0" + Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Year.ToString().Trim();
				}
				else
				{
					ddlYear.SelectedValue = Convert.ToDateTime(dsRegistration.Tables[0].Rows[0][4].ToString().Trim()).Year.ToString().Trim();
				}

				rblGender.SelectedValue = Convert.ToString(rblGender.Items.FindByText(dsRegistration.Tables[0].Rows[0][5].ToString().Trim()).Value);			
				
				txtResidentialAddress.Text=dsRegistration.Tables[0].Rows[0][6].ToString().Trim().Replace("<BR>","\r");
				txtCity.Text=dsRegistration.Tables[0].Rows[0][7].ToString().Trim();
				txtPinCode.Text=dsRegistration.Tables[0].Rows[0][8].ToString().Trim();
				txtSTDCode.Text =dsRegistration.Tables[0].Rows[0][9].ToString().Trim();
				txtPhoneNumber.Text=dsRegistration.Tables[0].Rows[0][10].ToString().Trim();
				txtCellPhone.Text=dsRegistration.Tables[0].Rows[0][11].ToString().Trim();

				if(dsRegistration.Tables[0].Rows[0][12].ToString().Trim() != "")
				{
					imgUploadPhotograph.ImageUrl ="UploadedPhotograph/"+ dsRegistration.Tables[0].Rows[0][12].ToString().Trim();
				}
				else
				{
					imgUploadPhotograph.ImageUrl ="Images/defaultphoto.jpg";
				}

				//filUpload.Value = oBLRegistration.PhotoGraphLocalePath.ToString().Trim();
				txtEmailID.Text=dsRegistration.Tables[0].Rows[0][13].ToString().Trim();
				txtMothersName.Text=dsRegistration.Tables[0].Rows[0][14].ToString().Trim();
				txtFathersName.Text =dsRegistration.Tables[0].Rows[0][31].ToString().Trim();
				ddlHouseholdIncome.SelectedValue = Convert.ToString(ddlHouseholdIncome.Items.FindByText(dsRegistration.Tables[0].Rows[0][15].ToString().Trim()).Value);
				txtCollegeAddress.Text = dsRegistration.Tables[0].Rows[0][34].ToString().Trim().Replace("<BR>","\r");
				
				ddlQualification.SelectedValue =dsRegistration.Tables[0].Rows[0][32].ToString();
				if (ddlQualification.SelectedItem.Text.ToString().Trim().ToLower()=="undergraduate/graduate")
				{					 
					divHighestEducationObtainedFrom.InnerText = "College Name:*";	
					divHighestEducationYear.InnerText="Year of Graduation:";
					//dvPGSpecialization.Visible=false;
					dvPGSpecialization.Attributes.Add("style","Display:none");
				}
				else
				{
					divHighestEducationObtainedFrom.InnerText = "Graduation done from (College Name):*";
					divHighestEducationYear.InnerText="Year of Post Graduation:";
					//dvPGSpecialization.Visible=true;
					dvPGSpecialization.Attributes.Add("style","");
				
				}
				
				tempParam = Convert.ToInt32( dsRegistration.Tables[0].Rows[0][32].ToString());
				BindDropDown(ref ddlQualificationDetails, oBLRegistration.FillQualificationDetails(tempParam),"Qualification","QualificationId");
				
				ddlQualificationDetails.SelectedValue = dsRegistration.Tables[0].Rows[0][33].ToString();
				hdQualificationDetails.Value = dsRegistration.Tables[0].Rows[0][33].ToString();
				
				if((dsRegistration.Tables[0].Rows[0][17].ToString().Trim().ToLower() == "others"))
				{
					txtOtherQualification.Style.Add("display","");
					txtOtherQualification.Value = dsRegistration.Tables[0].Rows[0][36].ToString().Trim();
				}
				else
				{
					txtOtherQualification.Style.Add("display","none");
				}
				
				txtPercentageScored.Text=dsRegistration.Tables[0].Rows[0][18].ToString(); 
				txtHighestEducationObtainedFrom.Text =dsRegistration.Tables[0].Rows[0][19].ToString();
				txtHighestEducationCity.Text = dsRegistration.Tables[0].Rows[0][20].ToString();

				rblEmploymentStatus.SelectedValue = dsRegistration.Tables[0].Rows[0][21].ToString().Trim();

				rblWillingToWorkOutOfHomeTown.SelectedValue = dsRegistration.Tables[0].Rows[0][22].ToString().Trim();
				
				FillCity(Convert.ToInt32(Session["StateId"]));
				
				tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(dsRegistration.Tables[0].Rows[0][29].ToString().Trim()).Value);
				ddlTestCity.SelectedValue = Convert.ToString(tempParam);
				
				FillTestCentreSecondAdmin(tempParam);

				ddlTestCentre.SelectedValue = ddlTestCentre.Items.FindByText(dsRegistration.Tables[0].Rows[0][30].ToString().Trim()).Value;
				
				hdTestCentre.Value = ddlTestCentre.Items.FindByText(dsRegistration.Tables[0].Rows[0][30].ToString().Trim()).Value;
				hdTestCentreName.Value = dsRegistration.Tables[0].Rows[0][30].ToString().Trim();
				
				ddlPhotoIdDocument.SelectedValue = Convert.ToString(ddlPhotoIdDocument.Items.FindByText(dsRegistration.Tables[0].Rows[0][23].ToString().Trim()).Value);
				txtPhotoIdNumber.Text = dsRegistration.Tables[0].Rows[0][24].ToString().Trim();
				ddlMediumOfInstruction.SelectedValue=dsRegistration.Tables[0].Rows[0][25].ToString().Trim();
				ddlMediumOfInstructionIn12Th.SelectedValue=dsRegistration.Tables[0].Rows[0][26].ToString().Trim();

				rblYouBelongTo.SelectedValue =dsRegistration.Tables[0].Rows[0][27].ToString().Trim();				
				txtPassword.Text = dsRegistration.Tables[0].Rows[0][35].ToString().Trim();
				txtConfirmPassword.Text = dsRegistration.Tables[0].Rows[0][35].ToString().Trim();

				// New fielda added by deepak
				if(dsRegistration.Tables[0].Rows[0][38].ToString().Trim()!="")
				{
					ddlPassingYear12th.SelectedValue=dsRegistration.Tables[0].Rows[0][38].ToString().Trim();
				}
				else
				{
					ddlPassingYear12th.SelectedValue="0";
				}
				if(dsRegistration.Tables[0].Rows[0][39].ToString().Trim()!="")
				{
					ddlGraduationYear.SelectedValue=dsRegistration.Tables[0].Rows[0][39].ToString().Trim();				
				}
				else
				{
					ddlGraduationYear.SelectedValue="0";
				}
				txtPGSpecialization.Text=dsRegistration.Tables[0].Rows[0][40].ToString().Trim();
				txtCurrentLocation.Text=dsRegistration.Tables[0].Rows[0][41].ToString().Trim();
				txtLanguageSkills.Text=dsRegistration.Tables[0].Rows[0][42].ToString().Trim();
				if(dsRegistration.Tables[0].Rows[0][43].ToString().Trim()!="")
				{
					ddlPassport.SelectedValue=dsRegistration.Tables[0].Rows[0][43].ToString().Trim();
				}
				else
				{
					ddlPassport.SelectedValue="No";
				}
				if (dsRegistration.Tables[0].Rows[0][43].ToString().Trim()=="Yes")
				{					
					dvPassport1.Attributes.Add("style","");
					txtPassport.Text=dsRegistration.Tables[0].Rows[0][44].ToString().Trim();
				}
				else
				{					
					dvPassport1.Attributes.Add("style","Display:none");
					txtPassport.Text="";
				}
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
		
		#region UpdateCandidate
		//Updating Candidate details 
		protected void btnSave_Click(object sender, System.EventArgs e)
		{		
			string strRegistrationId=Request.QueryString["CandidateID"].ToString();
			try
			{
				BLRegistration objBLRegistration = new BLRegistration();		
				objBLRegistration.RegistrationId=strRegistrationId; 
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
				if(filUpload.PostedFile.FileName != "")
				{
					objBLRegistration.UploadPhotograph = GetImageFileExtension();
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

				//New Fields Added by deepak
				objBLRegistration.YearOfPassing12Th=Convert.ToInt32(ddlPassingYear12th.SelectedItem.ToString().Trim());
				objBLRegistration.YearOfGraduation=Convert.ToInt32(ddlGraduationYear.SelectedValue.ToString().Trim());
		
				objBLRegistration.PGSpecialization = txtPGSpecialization.Text.ToString().Trim();
				objBLRegistration.CurrentLocation = txtCurrentLocation.Text.ToString().Trim();
				objBLRegistration.LanguageSkills = txtLanguageSkills.Text.ToString().Trim();

				if(ddlPassport.SelectedValue == "Yes")
				{
					objBLRegistration.HavePassport = true;
					objBLRegistration.HavePassportName="Yes";					
					objBLRegistration.PassportNo = txtPassport.Text.ToString().Trim();				

				}
				else
				{
					objBLRegistration.HavePassport = false;
					objBLRegistration.HavePassportName = "No";
					objBLRegistration.PassportNo= System.DBNull.Value.ToString();
				}				
				//New Fields Added by deepak end
				objBLRegistration.TestCity = ddlTestCity.SelectedItem.ToString().Trim();			
				
				objBLRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString().Trim();
				objBLRegistration.TestCentreName = hdTestCentreName.Value.ToString().Trim();
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
				
				if(filUpload.PostedFile.FileName != "")
				{
					objBLRegistration.UploadPhotograph = UploadPhotograph(strRegistrationId);
				}

				objBLRegistration.UpdateCandidateDetail(strRegistrationId);
			}
			catch(Exception SysEx)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}
			
			Response.Redirect("AdminCandidateSearch.aspx");	
		}

		#endregion
		
		#region GetImageFileExtension()
		//Returning file extention as string.
		private string GetImageFileExtension()
		{
			string strExtension = "";
			//Initializing fn string variable with current file name.
			string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);
			//Validating that file has been posted through control or it is blank.
			if (filUpload.PostedFile == null || System.IO.Path.GetFileName(filUpload.PostedFile.FileName)=="")
			{				 
				return strExtension;
			}
			else
			{
				return strExtension = fn;// + System.IO.Path.GetExtension(filUpload.PostedFile.FileName);		 
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
					//Initializing fn string variable with file name, which to be Uploaded.
					string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);
					string strExtension;		//Declaring variable to keep file extention which to be Uploaded.
					strExtension = System.IO.Path.GetExtension(filUpload.PostedFile.FileName);
					string file = baseLocation + fn;
					strFileName = strRegistrationId + fn;
					//Uploading file.
					filUpload.PostedFile.SaveAs(baseLocation + strRegistrationId + fn);
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

			        
					sbAppend.Append("if (CentreIdAndFlag[row,col] == 1){ alert('Now centre capacity is full, so please select any other centre.'); document.getElementById('ddlTestCentre').focus(); return false; } else { return true;}");
					
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
