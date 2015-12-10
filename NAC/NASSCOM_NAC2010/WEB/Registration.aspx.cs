
///<remarks>
///===================================================================
/// Name: File Name				: Registration.aspx
/// Construction Date			: 01/05/07
/// Author: Developer's Name	: Badal Kumar
/// Description					: This page is used for registrating new candidate
/// Last Revision Date			: 
/// Last Revision By			:  
/// Last Revision Change		: 
/// ====================================================================
/// Copyright (C) 2007-2008 NASSCOM  All Rights Reserved.
/// ====================================================================
///</remarks> 

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
using System.IO;
using System.Text;
using BusinessLayer;
using Common;


namespace NASSCOM_NAC.Web
{
    /// <summary>
    /// Summary description for Registration Form.
    /// </summary>
    public partial class Registration : System.Web.UI.Page
    {

        #region WebControls

        private int intCheck = 0;
        private int intPasswordCheck = 0;
        public int intStateId = 0;
        private string SerialNo = null;
        private string PinNo = null;
        protected System.Web.UI.WebControls.TextBox txtUnderGraduationObtainedFrom;
        protected System.Web.UI.WebControls.TextBox txtUnderGraduateCityName;
        protected System.Web.UI.WebControls.RadioButtonList rblPassport;
        protected System.Web.UI.WebControls.DropDownList ddlPGYear;
        protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel;
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

            Session["StateId"] = "1";
            if (Session["PIN"] == null || Session["StateId"] == null)
            {
                Response.Redirect("PinLogin.aspx");
            }

            DataSet dsStateDetail = new DataSet();

            BLRegistration objBlRegistration = new BLRegistration();
            dsStateDetail = objBlRegistration.GetStateDetail(Convert.ToString(Session["PIN"]));

            if (dsStateDetail.Tables[0].Rows.Count > 0)
            {
                //store state details in session
                Session["StateId"] = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["StateId"]);
                Session["State"] = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["State"]);
                Session["StateLogo"] = Convert.ToString(dsStateDetail.Tables[0].Rows[0]["Logo"]);
                //imgStateLogo.Src = "images/"+ strStateLogo;
            }


            //Declaring stateid variable to populate Test City
            intStateId = Convert.ToInt32(Session["StateId"].ToString());
            lblStateName.Text = "For " + Convert.ToString(Session["State"]);
            //checking for Infotech Enterprises Ltd 
            if (Session["Centre"] == "Infotech Ent. Ltd.")
            {
                lblStateName.Text = "For " + Convert.ToString(Session["Centre"]);
                tdInstructions.Visible = false;
            }

            txtFirstName.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtMiddleName.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtLastName.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtCity.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            //Adding attribute to accept only numeric data in txtPinCode.
            txtPinCode.Attributes.Add("onblur", "fillOnlyNumericValue(this);");
            //Adding attribute to accept only numeric data in txtSTDCode.
            txtSTDCode.Attributes.Add("onblur", "fillOnlyNumericValue(this);");
            //Adding attribute to accept only numeric data in txtPhoneNumber.
            txtPhoneNumber.Attributes.Add("onblur", "fillOnlyNumericValue(this);");
            //Adding attribute to accept only numeric data in txtCellPhone.
            txtCellPhone.Attributes.Add("onblur", "fillOnlyNumericValue(this);ValidateMobile(this);");
            txtEmailID.Attributes.Add("onblur", "ValidateEmailAddress(this);");
            txtMothersName.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtFathersName.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtPassport.Attributes.Add("onblur", "fillOnlyAlphanumericValue(this);");
            txtHighestEducationObtainedFrom.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtPGSpecialization.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtHighestEducationCity.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtOtherQualification.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtPercentageScored.Attributes.Add("onblur", "fillOnlyPercentageValue(this);");
            txtCurrentLocation.Attributes.Add("onblur", "fillOnlyAlphabetValue(this);");
            txtLanguageSkills.Attributes.Add("onblur", "fillonlyAlphaComma(this);");
            txtConfirmPassword.Attributes.Add("onblur", "CheckPassword(this);CheckConfirmPassword(this);");

            //Declaring SerialNo and PinNo variable to populate Test City	
            SerialNo = Convert.ToString(Session["SerialNo"]);
            PinNo = Convert.ToString(Session["PIN"]);

            //Adding Attribute to populate ddlTestCity Combo on runtime.
            //ddlTestCity.Attributes.Add("onchange","populate();");
            //Adding attribute to hide Specify Others text box, populate Qualification Details and changing college name.
            ddlQualification.Attributes.Add("onchange", "populateQualification();hideTextBox();ChangeCollegeLabel();");
            //Adding attribute to validate user input while submition of page.
            Save.Attributes.Add("OnClick", "javascript:return ValidateData();");
            //Save.Attributes.Add("OnClick", "javascript:return populateQualification();");
            //Adding Attribute to Initialize hdTestCentre(Hidden field) on runtime.    
            //ddlTestCentre.Attributes.Add("onchange","fillHiddenCentre();");
            //ddlTestCentre.Attributes.Add("onblur","CheckCapacity();");				
            //Adding Attribute to fill data in hdQualificationDetails hidden field.
            ddlQualificationDetails.Attributes.Add("onchange", "fillHiddenQualification();");
            //Adding attribute to accept only numeric data in txtPercentageScored.
            //txtPercentageScored.Attributes.Add("onblur","fillOnlyNumericValue(this);");

            ddlPassport.Attributes.Add("onchange", "HidePassport();");
            //Populating ddlTestCentre(Test Centre) on behalf of selected Test City.
            //GenerateDynamicDropdown(intStateId);
            //Populating ddlQualificationDetails(Qualification Details) ComboBox on behalf of selected Highest Educational Qualification.
            GenerateDDLQualification();

            if (!Page.IsPostBack)
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
                
                lblExistMessage.Visible = false;
                lblMessage.Visible = false;
                divLblTestCity.Attributes.Add("style", "Display:none");
                divLblTestCentre.Attributes.Add("style", "Display:none");
                //Populating ddlTestCity(Test City) ComboBox.
                FillTestCity(SerialNo, PinNo);
                //Populating ddlTestCentre(Test Center) Combobox.
                FillTestCentre(SerialNo, PinNo);
                //Populating ddlPhotoIdDocument(Photo ID) Document Combobox.
                FillPhotoIdDetail();
                //Populating ddlHouseholdIncome(Income Range) Combobox.
                FillIncomeRange();
                //Populating ddlQualification(Highest Educational Qualification) ComboBox.
                FillQualificationType();
                //Populating ddlQualificationDetails(Qualification Details) ComboBox.
                FillQualification();

            }

            //Pre populate if centre and city is already allocated
            if (Session["SerialNo"] != null && Session["PIN"] != null && Session["State"] != null && Convert.ToInt32(Session["StateId"]) != 9 && Convert.ToInt32(Session["StateId"]) != 6)
            {
                BLTest objBLTest = new BLTest();
                DataSet dsPreAllocatedCentre = new DataSet();
                dsPreAllocatedCentre = (DataSet)objBLTest.PreAllocatedCentre(Convert.ToInt32(Session["SerialNo"]), Convert.ToString(Session["PIN"]), Convert.ToString(Session["State"]));

                if (dsPreAllocatedCentre.Tables[0] != null)
                {
                    if (dsPreAllocatedCentre.Tables[0].Rows.Count > 0)
                    {
                        ddlTestCity.SelectedValue = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CityId"]);
                        lblTestCity.Text = ddlTestCity.SelectedItem.ToString();
                        FillAllTestCentre(Convert.ToInt32(dsPreAllocatedCentre.Tables[0].Rows[0]["CityId"]));
                        ddlTestCentre.SelectedValue = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CentreId"]);
                        hdTestCentre.Value = Convert.ToString(dsPreAllocatedCentre.Tables[0].Rows[0]["CentreId"]);
                        hdTestCentreName.Value = ddlTestCentre.SelectedItem.ToString().Trim();
                        lblTestCentre.Text = ddlTestCentre.SelectedItem.ToString();
                        divDropTestCity.Attributes.Add("style", "Display:none");
                        divDropTestCentre.Attributes.Add("style", "Display:none");
                        divLblTestCity.Attributes.Remove("style");
                        divLblTestCentre.Attributes.Remove("style");
                        ddlTestCity.Enabled = false;
                        ddlTestCentre.Enabled = false;
                    }
                }
            }


            if (Convert.ToInt32(Session["StateId"]) == 100)
            {

                lblTestCentre.Text = "Test date and name of your allotted test center will be given on your Admission Card.";
                lblTestCentre.ForeColor = System.Drawing.Color.Red;
                lblTestCentre.Font.Size = 8;
                //divDropTestCity.Attributes.Add("style","Display:none");
                divDropTestCentre.Attributes.Add("style", "Display:none");
                //divLblTestCity.Attributes.Remove("style");
                divLblTestCentre.Attributes.Remove("style");
                ddlTestCity.Enabled = true;
                ddlTestCentre.Enabled = false;
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

        #region FillTestCity()

        private void FillTestCity(int intStateId)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Test City combo to bind with FillTestCitySecond(DataTable).
            BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId), "City", "CityId");
        }

        //Created By Manoj to Fill test city based on SerialNo and PinNo. Date: 15 Sept 2010
        private void FillTestCity(string SerialNo, string PinNo)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Test City combo to bind with FillTestCitySecond(DataTable).
            BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(SerialNo, PinNo), "City", "CityId");
        }

        #endregion

        #region FillCity()
        //Populating Test City Combobox
        private DataTable FillCity(int intStateId)
        {
            //Passing Test City combo to bind with FillTestCitySecond(DataTable) 
            BLRegistration objBLRegistration = new BLRegistration();
            return objBLRegistration.FillTestCity(intStateId);
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


            if (dtQualificationType != null && dtQualification != null)
            {
                intParentRowCount = dtQualificationType.Rows.Count;
                intChildRowCount = dtQualification.Rows.Count;

                if (intParentRowCount > 0 && intChildRowCount > 0)
                {
                    for (intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
                    {
                        sbAppend.Append("store[");
                        sbAppend.Append(Convert.ToInt32(dtQualificationType.Rows[intOuterIncrementLoop]["QualificationTypeId"].ToString().Trim()));
                        sbAppend.Append("] = new Array(");

                        for (intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
                        {
                            if (intInnerIncrementLoop == 0)
                            {
                                sbAppend.Append("'Select','0',");

                            }

                            if (Convert.ToInt32(dtQualificationType.Rows[intOuterIncrementLoop]["QualificationTypeId"].ToString().Trim()) == Convert.ToInt32(dtQualification.Rows[intInnerIncrementLoop]["QualificationTypeId"].ToString().Trim()))
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
                        sbAppend.Remove(sbAppend.Length - 1, 1);
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

        #region FillQualificationType()
        //Populating heighest education qualification.
        private void FillQualificationType()
        {
            //Creating Instance of BLRegistration.
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Heighest Qualification combo to bind with FillQualificationTypeSecond(DataTable).
            BindDropDown(ref ddlQualification, objBLRegistration.FillQualificationTypeSecond(), "QualificationType", "QualificationTypeId");
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
            BindDropDown(ref ddlQualificationDetails, dtQualification, "Qualification", "QualificationId");
        }


        #endregion

        #region FillTestCentre()
        //Populating Test Center Combobox.
        private void FillTestCentre()
        {

            DataTable dtTestCentre = new DataTable();
            dtTestCentre.Columns.Add("Centre");
            dtTestCentre.Columns.Add("CentreId");
            DataRow drNewRow;
            drNewRow = dtTestCentre.NewRow();
            drNewRow["Centre"] = "Select";
            drNewRow["CentreId"] = "0";
            dtTestCentre.Rows.Add(drNewRow);
            //Passing Test Center combo to bind with FillTestCentre(DataTable).
            BindDropDown(ref ddlTestCentre, dtTestCentre, "Centre", "CentreId");
        }

        private void FillTestCentre(string SerialNo, string PinNo)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Test City combo to bind with FillTestCitySecond(DataTable).
            BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCitySecond(SerialNo, PinNo), "Centre", "CentreId");
        }

        #endregion

        #region FillAllTestCentre()

        public void FillAllTestCentre(int intCity)
        {

            //Passing Test Center combo to bind with FillAllTestCentre(DataTable).
            DataTable dtTestCentre = new DataTable();
            BLRegistration objBLRegistration = new BLRegistration();
            dtTestCentre = (DataTable)objBLRegistration.FillAllTestCentre(intCity);
            BindDropDown(ref ddlTestCentre, dtTestCentre, "Centre", "CentreId");
        }

        #endregion

        #region FillTestState()

        private void FillTestState()
        {
            //BLRegistration objBLRegistration = new BLRegistration();			 
            //BindDropDown(ref ddlTestCity, objBLRegistration.FillTestState(),"State","StateId");
        }


        #endregion

        #region FillPhotoIdDetail()
        //Populating Photo ID Document Combobox
        private void FillPhotoIdDetail()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Photo Id Document combo to bind with FillPhotoIdDetail(DataTable)
            BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(), "PhotoIdDocument", "PhotoId");
        }


        #endregion

        #region FillIncomeRange()
        //Populating Income Range Combobox.
        private void FillIncomeRange()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Household Income combo to bind with FillIncomeRange(DataTable).
            BindDropDown(ref ddlHouseholdIncome, objBLRegistration.FillIncomeRange(), "IncomeRange", "IncomeRangeId");
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

        #region Save_Click()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Save_Click(object sender, System.EventArgs e)
        {
            if (ValidateControls())
            {
                string strRegistrationPIN = Convert.ToString(Session["PIN"].ToString().Trim());
                string baseLocation = Server.MapPath(".") + "\\UploadedPhotograph\\";
                BLRegistration objBLRegistration = new BLRegistration();
                objBLRegistration.PinNo = Convert.ToString(Session["PIN"].ToString().Trim());
                objBLRegistration.SerialNumber = Convert.ToInt32(Session["SerialNo"].ToString().Trim());
                objBLRegistration.FirstName = txtFirstName.Text.ToString().Trim();
                objBLRegistration.MiddleName = txtMiddleName.Text.ToString().Trim();
                objBLRegistration.LastName = txtLastName.Text.ToString().Trim();
                objBLRegistration.DOB = Convert.ToDateTime(ddlDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlMonth.SelectedValue.ToString().Trim()) + "/" + ddlYear.SelectedValue.ToString().Trim());
                objBLRegistration.Gender = rblGender.SelectedValue.ToString().Trim();
                objBLRegistration.GenderName = rblGender.SelectedItem.ToString().Trim();
                objBLRegistration.ResidentialAddress = txtResidentialAddress.Text.ToString().Trim().Replace("\r\n", "<BR>");
                objBLRegistration.City = txtCity.Text.ToString().Trim();
                objBLRegistration.PinCode = txtPinCode.Text.ToString().Trim();
                objBLRegistration.STDCode = txtSTDCode.Text.ToString().Trim();
                objBLRegistration.LandLine = txtPhoneNumber.Text.ToString().Trim();
                objBLRegistration.CellPhone = txtCellPhone.Text.ToString().Trim();
                objBLRegistration.UploadPhotograph = GetImageFileExtension();
                //			if(GetImageFileExtension() != "")
                //			{
                //				objBLRegistration.PhotoGraphLocalePath = filUpload.Value.ToString().Trim();
                //			}
                //			else
                //			{
                //			    objBLRegistration.PhotoGraphLocalePath = "";
                //			}
                objBLRegistration.EmailId = txtEmailID.Text.ToString().Trim();
                objBLRegistration.MothersFullname = txtMothersName.Text.ToString().Trim();
                objBLRegistration.FathersFullname = txtFathersName.Text.ToString().Trim();
                objBLRegistration.AnnualHouseHoldIncome = Convert.ToInt32(ddlHouseholdIncome.SelectedValue.ToString().Trim());
                objBLRegistration.AHHIName = ddlHouseholdIncome.SelectedItem.ToString().Trim();
                if (rblYouBelongTo.SelectedValue.ToString().Trim() == "Village")
                {
                    objBLRegistration.YouBelongTo = true;
                    objBLRegistration.YBTName = "Village";
                }
                else
                {
                    objBLRegistration.YouBelongTo = false;
                    objBLRegistration.YBTName = "City";
                }

                objBLRegistration.HighestEducationalQualification = Convert.ToInt32(ddlQualification.SelectedValue.ToString().Trim());
                objBLRegistration.University = txtHighestEducationObtainedFrom.Text.ToString().Trim();
                objBLRegistration.CollegeAddress = txtCollegeAddress.Text.ToString().Trim().Replace("\r\n", "<BR>");
                objBLRegistration.EducationCity = txtHighestEducationCity.Text.ToString().Trim();
                objBLRegistration.QualificationDetailName = hdQualificationDetailsName.Value.ToString().Trim().ToLower();
                //			if(hdQualificationDetailsName.Value.ToString().Trim().ToLower() == "others")
                //			{
                //			   objBLRegistration.QualificationDetail = Convert.ToInt32(txtOtherQualification.Value.ToString());//hdQualificationDetails.Value.ToString().Trim();			
                //			}
                //			else
                //			{
                objBLRegistration.QualificationDetail = Convert.ToInt32(hdQualificationDetails.Value.ToString());
                //			}

                objBLRegistration.OtherQualification = txtOtherQualification.Value.ToString().Trim();
                objBLRegistration.AggregatePercentageScored = Convert.ToInt32(txtPercentageScored.Text.ToString().Trim());
                objBLRegistration.MediumOfInstructionUpTo10Th = ddlMediumOfInstruction.SelectedValue.ToString().Trim();
                objBLRegistration.MediumOfInstructionUpTo12Th = ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim();


                if (rblEmploymentStatus.SelectedValue.ToString().Trim() == "Employed")
                {
                    objBLRegistration.EmploymentStatus = true;
                    objBLRegistration.EmploymentStatusName = "Employed";
                }
                else
                {
                    objBLRegistration.EmploymentStatus = false;
                    objBLRegistration.EmploymentStatusName = "Unemployed";
                }

                if (rblWillingToWorkOutOfHomeTown.SelectedValue.ToString().Trim() == "Yes")
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
                if (Convert.ToInt32(Session["StateId"]) == 100) //|| Convert.ToInt32(Session["StateId"]) == 6)
                {
                    BLTest objBLTest = new BLTest();
                    objBLRegistration.TestCentre = objBLTest.GetTestCentreID(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
                    objBLRegistration.TestCentreName = objBLTest.GetTestCentreName(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));

                }
                else
                {
                    objBLRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString();//ddlTestCentre.SelectedItem.ToString().Trim();
                    objBLRegistration.TestCentreName = ddlTestCentre.SelectedItem.Text.ToString().Trim();
                }

                objBLRegistration.Password = txtPassword.Text.ToString().Trim();
                objBLRegistration.ConfirmPassword = txtConfirmPassword.Text.ToString().Trim();
                objBLRegistration.PhotoIdDocument = ddlPhotoIdDocument.SelectedValue.ToString().Trim();
                objBLRegistration.PhotoIdDocumentName = ddlPhotoIdDocument.SelectedItem.ToString().Trim();
                objBLRegistration.PhotoIdNumber = txtPhotoIdNumber.Text.ToString().Trim();
                objBLRegistration.HEQName = ddlQualification.SelectedItem.ToString().Trim();

                //New Fields Added by deepak
                objBLRegistration.YearOfPassing12Th = Convert.ToInt32(ddlPassingYear12th.SelectedItem.ToString().Trim());
                objBLRegistration.YearOfGraduation = Convert.ToInt32(ddlGraduationYear.SelectedValue.ToString().Trim());

                objBLRegistration.PGSpecialization = txtPGSpecialization.Text.ToString().Trim();
                objBLRegistration.CurrentLocation = txtCurrentLocation.Text.ToString().Trim();
                objBLRegistration.LanguageSkills = txtLanguageSkills.Text.ToString().Trim();

                if (ddlPassport.SelectedValue.ToString().Trim() == "Yes")
                {
                    objBLRegistration.HavePassport = true;
                    objBLRegistration.HavePassportName = "Yes";
                    objBLRegistration.PassportNo = txtPassport.Text.ToString().Trim();

                }
                else
                {
                    objBLRegistration.HavePassport = false;
                    objBLRegistration.HavePassportName = "No";
                    objBLRegistration.PassportNo = System.DBNull.Value.ToString();
                }
                //New Fields Added by deepak end

                intCheck = objBLRegistration.IsPinNumberInUse();
                //Added by Shweta
                //CheckSamePassword();
                intPasswordCheck = objBLRegistration.IsPWDExits(ddlPhotoIdDocument.SelectedValue.ToString().Trim(), txtPhotoIdNumber.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());
                if (intPasswordCheck == 1)
                {
                    string jScript;
                    //jScript = "<Script Language=Javascript>alert('This Password already exits.')</Script>";
                    //jScript = "<Script Language=Javascript>alert('This Password already exits. Please change the password.')</Script>";
                    jScript = "<Script Language=Javascript>SamePasswordAlert();</Script>";
                    Page.RegisterStartupScript("keyClientBlock", jScript);
                    txtPassword.BackColor = System.Drawing.Color.Yellow;
                    txtConfirmPassword.BackColor = System.Drawing.Color.Yellow;
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    hdpassword.Value = "";
                    hdconfpassword.Value = "";
                    txtConfirmPassword.Attributes.Add("value", hdconfpassword.Value);
                    txtPassword.Attributes.Add("value", hdpassword.Value);
                    DataTable dtQualification = new DataTable();
                    dtQualification = objBLRegistration.FillQualification();
                    DataRow[] dr = dtQualification.Select("QualificationTypeId=" + ddlQualification.SelectedValue);
                    int intChildRowCount = dtQualification.Rows.Count;
                    //Passing Qualification Details Document combo to bind with dtQualification(DataTable).
                    int tempParam = Convert.ToInt32(objBLRegistration.HighestEducationalQualification.ToString());
                    BindDropDown(ref ddlQualificationDetails, objBLRegistration.FillQualificationDetails(tempParam), "Qualification", "QualificationId");
                    ddlQualificationDetails.SelectedValue = objBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
                    hdQualificationDetails.Value = objBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();				
                    tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(objBLRegistration.TestCity.ToString().Trim()).Value);
                    ddlTestCity.SelectedValue = Convert.ToString(tempParam);
                    FillTestCentreSecond(tempParam);
                    ddlTestCentre.SelectedValue = objBLRegistration.TestCentre.ToString().Trim();
                    hdTestCentre.Value = objBLRegistration.TestCentre.ToString().Trim();
                    hdTestCentreName.Value = objBLRegistration.TestCentreName.ToString().Trim();
                    if (ddlQualificationDetails.SelectedItem.Text == "Others")
                    {
                        txtOtherQualification.Style.Add("display", "");
                        txtOtherQualification.Value = objBLRegistration.OtherQualification.ToString();
                    }
                    else
                    {
                        txtOtherQualification.Style.Add("display", "none");
                    }

                    return;
                }
                //Added by Shweta end

                if (intCheck == 0)
                {
                    if (strRegistrationPIN != "")
                    {
                        objBLRegistration.UploadPhotograph = UploadPhotograph(strRegistrationPIN);
                    }
                    Session["UserID"] = strRegistrationPIN;
                    Session["UserName"] = txtFirstName.Text.ToString().Trim();
                    Session["UserType"] = "1";
                    Session["objBLRegistration"] = objBLRegistration;
                    Response.Redirect("RegistrationPreview.aspx?Login=false&RegistrationId=" + strRegistrationPIN);

                }
                else
                {
                    lblExistMessage.Visible = true;
                    lblExistMessage.Text = "This pin number already in use.";
                }

            }
        }

        #endregion

        //		private void CheckSamePassword()
        //		{
        //			BLRegistration objBLRegistration = new BLRegistration();
        //			intPasswordCheck= objBLRegistration.IsPWDExits(ddlPhotoIdDocument.SelectedValue.ToString().Trim(), txtPhotoIdNumber.Text.ToString().Trim(),txtPassword.Text.ToString().Trim());
        //			if(intPasswordCheck == 1)
        //			{
        //				string jScript;
        //				//jScript = "<Script Language=Javascript>alert('This Password already exits.')</Script>";
        //				//jScript = "<Script Language=Javascript>alert('This Password already exits. Please change the password.')</Script>";
        //				jScript = "<Script Language=Javascript>SamePasswordAlert();</Script>";
        //				Page.RegisterStartupScript("keyClientBlock", jScript);
        //				txtPassword.BackColor= System.Drawing.Color.Yellow;
        //				txtConfirmPassword.BackColor= System.Drawing.Color.Yellow;	
        //				txtPassword.Text="";
        //				txtConfirmPassword.Text="";
        //				hdpassword.Value="";
        //				hdconfpassword.Value="";
        //				txtConfirmPassword.Attributes.Add("value", hdconfpassword.Value);
        //				txtPassword.Attributes.Add("value", hdpassword.Value);	
        //				DataTable dtQualification = new DataTable();
        //				dtQualification = objBLRegistration.FillQualification();
        //				DataRow[] dr = dtQualification.Select("QualificationTypeId="+ddlQualification.SelectedValue);
        //				int intChildRowCount = dtQualification.Rows.Count;
        //				//Passing Qualification Details Document combo to bind with dtQualification(DataTable).
        //				int tempParam = Convert.ToInt32(objBLRegistration.HighestEducationalQualification.ToString());
        //				BindDropDown(ref ddlQualificationDetails, objBLRegistration.FillQualificationDetails(tempParam),"Qualification","QualificationId");
        //				ddlQualificationDetails.SelectedValue = objBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
        //				hdQualificationDetails.Value = objBLRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();				
        //				tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(objBLRegistration.TestCity.ToString().Trim()).Value);
        //				ddlTestCity.SelectedValue = Convert.ToString(tempParam);
        //				FillTestCentreSecond(tempParam);
        //				ddlTestCentre.SelectedValue = objBLRegistration.TestCentre.ToString().Trim();
        //				hdTestCentre.Value = objBLRegistration.TestCentre.ToString().Trim();
        //				hdTestCentreName.Value = objBLRegistration.TestCentreName.ToString().Trim();
        //				if(ddlQualificationDetails.SelectedItem.Text== "Others")
        //				{
        //					txtOtherQualification.Style.Add("display","");
        //					txtOtherQualification.Value = objBLRegistration.OtherQualification.ToString();
        //				}
        //				else
        //				{
        //					txtOtherQualification.Style.Add("display","none");
        //				}
        //					
        //				return;
        //			}
        //		}


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

        #region Uploaded Photograph
        //Uploading candidate photo in UploadedPhotograph root folder.
        private string UploadPhotograph(string strRegistrationId)
        {
            //Initializing baseLocation string with current path.
            string baseLocation = Server.MapPath(".") + "\\UploadedPhotograph\\";
            //string baseLocationCompress =  Server.MapPath(".")+ "\\UploadedPhotograph\\Compress\\";
            string strFileName = "";
            //Validating that file is posted or not.
            if (filUpload.PostedFile == null || System.IO.Path.GetFileName(filUpload.PostedFile.FileName) == "")
            //if (hdImagepath.Value=="" || hdImagepath.Value == null)
            {
                return strFileName;
            }
            else
            {
                //Initializing fn string with current file name.
                string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);

                ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
                imgCompress.GetImage = new System.Drawing.Bitmap(filUpload.PostedFile.InputStream);
                imgCompress.Height = 110;
                imgCompress.Width = 95;
                //Compressing and uploading file in UploadedPhotograph root folder.
                imgCompress.Save(strRegistrationId + fn, @baseLocation);
                return strFileName = strRegistrationId + fn;

            }
        }


        #endregion

        #region GetImageFileExtension()
        //Returns file extention as string.
        private string GetImageFileExtension()
        {
            string strExtension = "";
            //Initializing fn string variable with extention of current file.			
            string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);

            if (filUpload.PostedFile == null || System.IO.Path.GetFileName(filUpload.PostedFile.FileName) == "")
            {
                return strExtension;
            }
            else
            {
                hdImagepath.Value = "true";
                return strExtension = fn;// + System.IO.Path.GetExtension(filUpload.PostedFile.FileName);

            }

            //			string strExtension = "";
            //			Initializing fn string variable with extention of current file.
            //			
            //			if(Page.Session["UploadedFile"] != null) 
            //			{
            //				filUpload.EnableViewState= true;//Page.Session["UploadedFile"].ToString();
            //				return strExtension = Page.Session["UploadedFile"].ToString();		
            //			}
            //			else
            //			{ 
            //				string fn = hdImagepath.Value;
            //				if (fn=="")
            //				{				 
            //					Page.Session["UploadedFile"]=fn;
            //					filUpload.EnableViewState = true;
            //					return strExtension;
            //				}
            //				else
            //				{
            //					Page.Session["UploadedFile"]=fn;
            //					filUpload.EnableViewState = true;
            //					return strExtension = fn;// + System.IO.Path.GetExtension(filUpload.PostedFile.FileName);		 
            //				}
            //				
            //			}		

        }


        #endregion

        #region GenerateDynamicDropdown()
        //Populating Test Center on click event of Test City through JavaScript.
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
            dtTestCity = FillCity(intStateId);

            sbAppend.Append("<script language='javascript' type='text/javascript'> ");
            sbAppend.Append("function populate(){ ");
            sbAppend.Append("var store = new Array(); ");
            sbAppend.Append("store[0] = new Array('Select','0'); ");


            if (dtTestCentre != null && dtTestCity != null)
            {
                intParentRowCount = dtTestCity.Rows.Count;
                intChildRowCount = dtTestCentre.Rows.Count;

                if (intParentRowCount > 0 && intChildRowCount > 0)
                {
                    for (intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
                    {
                        sbAppend.Append("store[");
                        sbAppend.Append(Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim()));
                        sbAppend.Append("] = new Array(");

                        for (intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
                        {
                            if (intInnerIncrementLoop == 0)
                            {
                                sbAppend.Append("'Select','0',");

                            }
                            if (Convert.ToInt32(dtTestCentre.Rows[intInnerIncrementLoop]["CityId"].ToString().Trim()) == Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim()))
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


                        sbAppend.Remove(sbAppend.Length - 1, 1);
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

                    if (intParentRowCount > 0 && intChildRowCount > 0)
                    {
                        for (intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
                        {

                            sbAppend.Append("CentreIdAndFlag[");
                            sbAppend.Append(Convert.ToInt32(dtTestCity.Rows[intOuterIncrementLoop]["CityId"].ToString().Trim()));
                            sbAppend.Append("] = new Array(");
                            sbAppend.Append(intChildRowCount);
                            sbAppend.Append(");");

                            for (intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
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

        #region rblWillingToWorkOutOfHomeTown_SelectedIndexChanged()
        protected void rblWillingToWorkOutOfHomeTown_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region ValidateControls()

        private bool ValidateControls()
        {
            //Added by Shweta
            lblMessage.Text = "";
            BLRegistration objRegistration = new BLRegistration();
            DataTable dtQualification = new DataTable();
            dtQualification = objRegistration.FillQualification();
            DataRow[] dr = dtQualification.Select("QualificationTypeId=" + ddlQualification.SelectedValue);
            int intChildRowCount = dtQualification.Rows.Count;
            objRegistration.QualificationDetail = Convert.ToInt32(hdQualificationDetails.Value.ToString());
            if (Convert.ToInt32(Session["StateId"]) == 100) //|| Convert.ToInt32(Session["StateId"]) == 6)
            {
                BLTest objBLTest = new BLTest();
                objRegistration.TestCentre = objBLTest.GetTestCentreID(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));
                objRegistration.TestCentreName = objBLTest.GetTestCentreName(Convert.ToInt32(ddlTestCity.SelectedValue.ToString()));

            }
            else
            {
                objRegistration.TestCentre = ddlTestCentre.SelectedValue.ToString().Trim();
                objRegistration.TestCentreName = ddlTestCentre.SelectedItem.Text.ToString().Trim();
            }

            //Passing Qualification Details Document combo to bind with dtQualification(DataTable).
            //BindDropDown(ref ddlQualificationDetails, dtQualification,"Qualification","QualificationId");
            objRegistration.HighestEducationalQualification = Convert.ToInt32(ddlQualification.SelectedValue.ToString().Trim());
            int tempParam = Convert.ToInt32(objRegistration.HighestEducationalQualification.ToString());
            BindDropDown(ref ddlQualificationDetails, objRegistration.FillQualificationDetails(tempParam), "Qualification", "QualificationId");
            if (tempParam != 0)
            {
                for (int i = 0; i <= ddlQualificationDetails.Items.Count - 1; i++)
                {
                    if (ddlQualificationDetails.Items[i].Value.ToString() == objRegistration.QualificationDetail.ToString().Trim())
                    { ddlQualificationDetails.SelectedValue = objRegistration.QualificationDetail.ToString().Trim(); }
                }
                //					ddlQualificationDetails.SelectedValue = objRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();

            }
            hdQualificationDetails.Value = objRegistration.QualificationDetail.ToString().Trim();//dsRegistration.Tables[0].Rows[0][33].ToString();
            if (ddlQualificationDetails.SelectedItem.Text == "Others")
            {
                txtOtherQualification.Style.Add("display", "");
                objRegistration.OtherQualification = txtOtherQualification.Value.ToString().Trim();
                txtOtherQualification.Value = objRegistration.OtherQualification.ToString();
            }
            else
            {
                txtOtherQualification.Style.Add("display", "none");
            }
            if (ddlTestCity.SelectedValue.ToString().Trim() != "0")
            {
                objRegistration.TestCity = ddlTestCity.SelectedItem.ToString().Trim();
                tempParam = Convert.ToInt32(ddlTestCity.Items.FindByText(objRegistration.TestCity.ToString().Trim()).Value);
                ddlTestCity.SelectedValue = Convert.ToString(tempParam);
                FillTestCentreSecond(tempParam);
                //ddlTestCentre.SelectedValue = objRegistration.TestCentre.ToString().Trim();
                for (int i = 0; i <= ddlTestCentre.Items.Count - 1; i++)
                {
                    if (ddlTestCentre.Items[i].Value.ToString() == objRegistration.TestCentre.ToString().Trim())
                    { ddlTestCentre.SelectedValue = objRegistration.TestCentre.ToString().Trim(); }
                }
                hdTestCentre.Value = objRegistration.TestCentre.ToString().Trim();
                hdTestCentreName.Value = objRegistration.TestCentreName.ToString().Trim();
                //ddlTestCentre.SelectedValue = objRegistration.TestCentreName.ToString().Trim();
            }


            if (txtFirstName.Text.ToString().Trim() == "")
            {
                txtFirstName.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtFirstName.BackColor = System.Drawing.Color.White;

            }
            if (txtLastName.Text.ToString().Trim() == "")
            {
                txtLastName.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtLastName.BackColor = System.Drawing.Color.White;

            }

            if (ddlDay.SelectedValue.ToString().Trim() == "0")
            {
                ddlDay.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlDay.BackColor = System.Drawing.Color.White;

            }
            if (ddlMonth.SelectedValue.ToString().Trim() == "0")
            {
                ddlMonth.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlMonth.BackColor = System.Drawing.Color.White;

            }
            if (ddlYear.SelectedValue.ToString().Trim() == "0")
            {
                ddlYear.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlYear.BackColor = System.Drawing.Color.White;

            }
            if (rblGender.SelectedValue.ToString().Trim() == "")
            {
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please select Gender";
                return false;
            }
            if (txtResidentialAddress.Text.ToString().Trim() == "")
            {
                txtResidentialAddress.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtResidentialAddress.BackColor = System.Drawing.Color.White;

            }
            if (txtCity.Text.ToString().Trim() == "")
            {
                txtCity.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtCity.BackColor = System.Drawing.Color.White;

            }
            if (txtPinCode.Text.ToString().Trim() == "")
            {
                txtPinCode.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPinCode.BackColor = System.Drawing.Color.White;

            }
            if (txtSTDCode.Text.ToString().Trim() == "")
            {
                txtSTDCode.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtSTDCode.BackColor = System.Drawing.Color.White;

            }
            if (txtPhoneNumber.Text.ToString().Trim() == "")
            {
                txtPhoneNumber.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPhoneNumber.BackColor = System.Drawing.Color.White;

            }

            if (txtEmailID.Text.ToString().Trim() == "")
            {
                txtEmailID.BackColor = System.Drawing.Color.Yellow;
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please enter email ID";
                return false;
            }

            else
            {
                txtEmailID.BackColor = System.Drawing.Color.White;
            }

            if (filUpload.PostedFile == null)
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
                    lblMessage.Text = "Your image size is more than 1 MB";
                    return false;
                }
                else
                {
                    if (filUpload.PostedFile.ContentLength == 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Your image size is less than 1KB";
                        return false;
                    }
                }
            }


            if (txtMothersName.Text.ToString().Trim() == "")
            {
                txtMothersName.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtMothersName.BackColor = System.Drawing.Color.White;

            }
            if (txtFathersName.Text.ToString().Trim() == "")
            {
                txtFathersName.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtFathersName.BackColor = System.Drawing.Color.White;

            }
            if (ddlHouseholdIncome.SelectedValue.ToString().Trim() == "0")
            {
                ddlHouseholdIncome.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlHouseholdIncome.BackColor = System.Drawing.Color.White;

            }
            if (rblYouBelongTo.SelectedValue.ToString().Trim() == "")
            {
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please select You Belong To ";
                return false;
            }
            if (ddlQualification.SelectedValue.ToString().Trim() == "0")
            {
                ddlQualification.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlQualification.BackColor = System.Drawing.Color.White;

            }
            if (txtHighestEducationObtainedFrom.Text.ToString().Trim() == "")
            {
                txtHighestEducationObtainedFrom.BackColor = System.Drawing.Color.Yellow;
                return false;

            }
            else
            {
                txtHighestEducationObtainedFrom.BackColor = System.Drawing.Color.White;

            }
            if (txtCollegeAddress.Text.ToString().Trim() == "")
            {
                txtCollegeAddress.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtCollegeAddress.BackColor = System.Drawing.Color.White;

            }
            if (txtHighestEducationCity.Text.ToString().Trim() == "")
            {
                txtHighestEducationCity.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtHighestEducationCity.BackColor = System.Drawing.Color.White;

            }
            if (ddlQualificationDetails.SelectedValue.ToString().Trim() == "0")
            {
                ddlQualificationDetails.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlQualificationDetails.BackColor = System.Drawing.Color.White;

            }

            if (hdQualificationDetails.Value.ToString().Trim() == "0")
            {
                ddlQualificationDetails.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlQualificationDetails.BackColor = System.Drawing.Color.White;

            }

            if (txtPercentageScored.Text.ToString().Trim() == "")
            {
                txtPercentageScored.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPercentageScored.BackColor = System.Drawing.Color.White;

            }
            if (ddlMediumOfInstruction.SelectedValue.ToString().Trim() == "0")
            {
                ddlMediumOfInstruction.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlMediumOfInstruction.BackColor = System.Drawing.Color.White;

            }
            if (ddlMediumOfInstructionIn12Th.SelectedValue.ToString().Trim() == "0")
            {
                ddlMediumOfInstructionIn12Th.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlMediumOfInstructionIn12Th.BackColor = System.Drawing.Color.White;

            }
            if (ddlPassingYear12th.SelectedValue.ToString().Trim() == "0")
            {
                ddlPassingYear12th.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlPassingYear12th.BackColor = System.Drawing.Color.White;

            }
            if (rblEmploymentStatus.SelectedValue.ToString().Trim() == "")
            {
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please select Employment Status ";
                return false;
            }
            if (txtCurrentLocation.Text.ToString().Trim() == "")
            {
                txtCurrentLocation.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtCurrentLocation.BackColor = System.Drawing.Color.White;

            }
            if (txtLanguageSkills.Text.ToString().Trim() == "")
            {
                txtLanguageSkills.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtLanguageSkills.BackColor = System.Drawing.Color.White;

            }
            if (rblWillingToWorkOutOfHomeTown.SelectedValue.ToString().Trim() == "")
            {
                lblMessage.Text = "";
                lblMessage.Visible = true;
                lblMessage.Text = "** Please select Willing To Work Out Of Home Town ";
                return false;
            }
            if (ddlPassport.SelectedValue.ToString().Trim() == "0")
            {
                ddlPassport.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlPassport.BackColor = System.Drawing.Color.White;

            }
            if (ddlPassport.SelectedValue.ToString().Trim() == "Yes")
            {
                if (txtPassport.Text.ToString().Trim() == "")
                {
                    txtPassport.BackColor = System.Drawing.Color.Yellow;
                    return false;
                }
            }
            else
            {
                txtPassport.BackColor = System.Drawing.Color.White;

            }
            if (ddlTestCity.SelectedValue.ToString().Trim() == "0")
            {
                ddlTestCity.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlTestCity.BackColor = System.Drawing.Color.White;

            }

            if (hdTestCentre.Value.ToString().Trim() == "0")
            {
                ddlTestCentre.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlTestCentre.BackColor = System.Drawing.Color.White;

            }
            if (ddlTestCentre.SelectedValue.ToString().Trim() == "0")
            {
                ddlTestCentre.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlTestCentre.BackColor = System.Drawing.Color.White;

            }

            if (txtPassword.Text.ToString().Trim() == "")
            {
                txtPassword.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPassword.BackColor = System.Drawing.Color.White;
                hdpassword.Value = txtPassword.Text;
                txtPassword.Attributes.Add("value", hdpassword.Value);

            }
            if (txtConfirmPassword.Text.ToString().Trim() == "")
            {

                txtConfirmPassword.BackColor = System.Drawing.Color.Yellow;
                // txtPassword.Text = hdpassword.Value;
                return false;
            }
            else
            {
                txtConfirmPassword.BackColor = System.Drawing.Color.White;
                hdconfpassword.Value = txtConfirmPassword.Text;
                txtConfirmPassword.Attributes.Add("value", hdconfpassword.Value);

            }
            if (ddlPhotoIdDocument.SelectedValue.ToString().Trim() == "0")
            {
                ddlPhotoIdDocument.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                ddlPhotoIdDocument.BackColor = System.Drawing.Color.White;

            }
            if (txtPhotoIdNumber.Text.ToString().Trim() == "")
            {
                txtPhotoIdNumber.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
            {
                txtPhotoIdNumber.BackColor = System.Drawing.Color.White;

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

            if (hdImagepath.Value == "true")
            {
                string jScript;
                jScript = "<Script Language=Javascript>alert('Please select again Photo to Upload')</Script>";
                Page.RegisterStartupScript("keyClientBlock", jScript);
                hdImagepath.Value = "";
                return false;
            }

            return true;
        }
        //Added by Shweta end

        #endregion

        //Added by Shweta
        private void FillTestCentreSecond(int intCityId)
        {
            //Initializing intCityId parameter with selected Test City value
            //intCityId = Convert.ToInt16(ddlTestCity.SelectedValue.ToString().Trim());
            BLRegistration objBLRegistration = new BLRegistration();
            //Passing Test Center combo to bind with FillTestCentre(DataTable)  
            BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecond(intCityId), "Centre", "CentreId");
        }

        //Added by Shweta end


    }
}