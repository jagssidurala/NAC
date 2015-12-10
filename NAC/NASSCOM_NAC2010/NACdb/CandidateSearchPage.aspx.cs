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
using System.Configuration;
using System.Threading;
using Common;
using BusinessLayer;

namespace NASSCOM_NAC.NACdb
{
    /// <summary>
    /// Summary description for CandidateSearchPage.
    /// </summary>
    public partial class CandidateSearchPage : System.Web.UI.Page
    {
        public string strSortExp;
        private int intCurrentPage;
        private static int intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["CompanyId"] == null || Session["CompanyName"] == null)
            {

                Response.Redirect("./LoginPage.aspx", false);
            }
            Session["CheckedValue"] = ViewState["CheckedValue"];
            //ddlTestCentre.Attributes.Add("style", "Display:none");
            lblMessage.Visible = false;
            lblMessage.Text = "No Record Found!";
            btnSearch.Attributes.Add("OnClick", "javascript:return ValidateData();");
            btnExportToExcel.Attributes.Add("OnClick", "javascript:return SelectCandidate();");
            btnScoreCard.Attributes.Add("OnClick", "javascript:return SelectCandidate();");
            btnReset.Attributes.Add("OnClick", "javascript:return ConfirmMessage('Are you sure you want to reset');");
            txtGraduationPercentageMin.Attributes.Add("onblur", "fillOnlyPercentageValue(this);");
            txtKSTAccuracyMin.Attributes.Add("onblur", "fillOnlyPercentageValue(this);");
            //Populating ddlTestCity and ddlTestCentre besad on state id.
            GenerateDynamicDropdown();
            //Populating ddlTestCentre on selection of ddlTestCity.
            GenerateCityDropdown();
            ddlQualification.Attributes.Add("onchange", "populateQualification(); fillHiddenQualification();");
            ddlGraduationStream.Attributes.Add("onchange", "fillHiddenQualification();");
            //Populating ddlGraduationStream(Qualification Details) ComboBox on behalf of selected Highest Educational Qualification.
            GenerateDDLQualification();
            if (!Page.IsPostBack)
            {
                Session["intCurrentPage"] = 1;
                ddlTestState.Attributes.Add("onchange", "populate(); FillHiddenField();");
                ddlTestCity.Attributes.Add("onchange", " populateCentre(); FillHiddenField();");
                //Populating hdState, hdCity and hdCentre fields on selection of ddlTestCentre.
                ddlTestCentre.Attributes.Add("onchange", "FillHiddenField();");
                btnScoreCard.Visible = false;
                btnExportToExcel.Visible = false;
                pnlSearch.Visible = true;
                pnlMessage.Visible = false;
                lblTotalRecord.Visible = false;
                chkAll.Visible = false;

                //Populating ddlTestCity and ddlTestCentre besad on state id.
                //GenerateDynamicDropdown();					
                //Populating ddlTestCentre on selection of ddlTestCity.
                //GenerateCityDropdown();
                //Populating ddlTestCity
                FillTestCity();
                //Populating ddlTestCentre
                FillTestCentre();
                //Populating ddlTestState
                //FillTestState();										
                FillTestStateV2();
                //Populating ddlTechnologyDomain(Domain Papers Details) ComboBox.
                //Populating ddlQualification(Highest Educational Qualification) ComboBox.
                FillQualificationType();
                //Populating ddlGraduationStream(Qualification Details) ComboBox.
                FillQualification();

                lblSortExp.Text = "RegistrationId ASC";
            }
        }

        #region FillGraduationStream()

        private void FillGraduationStream()
        {
            DataTable dtTestCity = new DataTable();
            dtTestCity.Columns.Add("City");
            dtTestCity.Columns.Add("CityId");
            DataRow drNewRow;
            drNewRow = dtTestCity.NewRow();
            drNewRow["City"] = "Select";
            drNewRow["CityId"] = "0";
            dtTestCity.Rows.Add(drNewRow);
            BindDropDown(ref ddlTestCity, dtTestCity, "City", "CityId");
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
            this.dgSearch.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgSearch_PageIndexChanged);
            this.dgSearch.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgSearch_ItemDataBound);

        }
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
                BindDropDown(ref ddlTestCentre, dtTestCentre, "Centre", "CentreId");
            }
            catch (Exception ex)
            {
                //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                //ErrorLogger.ErrorRoutine(false,ex);
            }
        }

        #endregion

        #region btnScoreCard_Click()

        protected void btnScoreCard_Click(object sender, System.EventArgs e)
        {
            Hidden1.Value = hdSelectedCandidateCount.Value;
            if (chkAll.Checked)
            {
                Session["SortExp"] = lblSortExp.Text;
                Response.Redirect("../Web/MultipleScoreCardV2.aspx?SearchType=fullCompany", false);
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
                    if (ViewState["CheckedValue"] != null)
                    {
                        //Initializing htCheckedValue with (Hashtable) ViewState["CheckedValue"].
                        htCheckedValue = (Hashtable)ViewState["CheckedValue"];
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
                            if (Convert.ToBoolean(Enumerator.Value))
                            {
                                sbItemList.Append("'");
                                sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));
                                sbItemList.Append("',");
                                if (IsSelected == false)
                                {
                                    IsSelected = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                    //ErrorLogger.ErrorRoutine(false,ex);
                }

                if (IsSelected)
                {
                    try
                    {
                        sbItemList.Remove(sbItemList.Length - 1, 1);
                        Session["ItemList"] = sbItemList.ToString();
                        Session["SortExp"] = lblSortExp.Text;
                    }
                    catch (Exception ex)
                    {
                        //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                        //ErrorLogger.ErrorRoutine(false,ex);
                    }
                    Response.Redirect("../Web/MultipleScoreCardV2.aspx", false);
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
                    catch (Exception ex)
                    {
                        //Calling ErrorRoutine of ErrorLogger to write error text in text file.
                        //ErrorLogger.ErrorRoutine(false,ex);
                    }
                }
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
            BindDropDown(ref ddlTestCity, dtTestCity, "City", "CityId");
        }

        #endregion

        #region FillTestCitySecond()

        private void FillTestCitySecond(int intStateId)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCitySecond(intStateId, 1), "City", "CityId");
        }

        private void FillGraduationStream(int intQualificationId)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlGraduationStream, objBLRegistration.FillQualificationDetails(intQualificationId), "Qualification", "QualificationId");
        }


        #endregion

        #region FillTestCentreSecond()

        private void FillTestCentreSecond(int intCityId)
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestCentre, objBLRegistration.FillTestCentreSecondAdmin(intCityId), "Centre", "CentreId");
        }

        #endregion

        #region FillCity()

        private DataTable FillCity()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            //objBLRegistration.TestType = "FINAL"; 
            //return objBLRegistration.GetTestCityV2();			 
            return objBLRegistration.FillCity();

        }

        #endregion

        #region FillTestCityV2()

        private DataTable FillTestCityV2()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            objBLRegistration.TestType = "FINAL";
            return objBLRegistration.GetTestCityV2();
        }

        #endregion

        #region FillCentre()

        private DataTable FillCentre()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            return objBLRegistration.FillCentre();
        }

        #endregion

        #region FillTestState()

        private void FillTestState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestState, objBLRegistration.FillAllTestState(), "State", "StateId");
        }
        #endregion

        #region FillTestStateV2()

        private void FillTestStateV2()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            objBLRegistration.TestType = "FINAL";
            BindDropDown(ref ddlTestState, objBLRegistration.FillTestStateV2(), "State", "StateId");
        }


        #endregion

        #region FillState()

        private DataTable FillState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            objBLRegistration.TestType = "FINAL";
            return objBLRegistration.FillTestStateV2();
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
            BindDropDown(ref ddlGraduationStream, dtQualification, "Qualification", "QualificationId");
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
            chkAll.Checked = false;
            dgSearch.CurrentPageIndex = 0;
            dgSearch.SelectedIndex = 0;
            ViewState["SelectedPage"] = null;
            ViewState["CheckedValue"] = null;
            Hashtable htCheckedValue = new Hashtable();
            ViewState["CheckedValue"] = htCheckedValue;
            strSortExp = lblSortExp.Text.ToString().Trim();
            SetStateCityCentreDropDown();
            SetQualificationStreamDropDown();
            SetSearchParameter(strSortExp, 1);
        }

        #endregion

        #region SetSearchParameter()

        private void SetSearchParameter(string SortExp, int intCurrentPage)
        {
            BLCandidateSearchByCompany objBLCandidateSearchByCompany = new BLCandidateSearchByCompany();

            if (txtRegId.Text.Trim() == "")
            {
                objBLCandidateSearchByCompany.RegistrationID = "";
            }
            else if (txtRegId.Text.Trim().Length < 16)
            {
                lblMessage.Text = "Please enter a valid Registration ID";
                lblMessage.Visible = true;
            }
            else
            {
                objBLCandidateSearchByCompany.RegistrationID = txtRegId.Text.Trim();
            }

            if (ddlTestDayFrom.SelectedIndex != 0 && ddlTestMonthFrom.SelectedIndex != 0 && ddlTestYearFrom.SelectedIndex != 0)
            {
                objBLCandidateSearchByCompany.TestDateFrom = Convert.ToDateTime(ddlTestDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestYearFrom.SelectedValue.ToString().Trim());
            }
            else
            {
                objBLCandidateSearchByCompany.TestDateFrom = Convert.ToDateTime("01/01/1900");
            }

            if (ddlTestDayTo.SelectedIndex != 0 && ddlTestMonthTo.SelectedIndex != 0 && ddlTestYearTo.SelectedIndex != 0)
            {
                objBLCandidateSearchByCompany.TestDateTo = Convert.ToDateTime(ddlTestDayTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlTestYearTo.SelectedValue.ToString().Trim());
            }
            else
            {
                objBLCandidateSearchByCompany.TestDateTo = Convert.ToDateTime("01/01/1900");
            }

            if (ddlDOBdayFrom.SelectedIndex != 0 && ddlDOBmonthFrom.SelectedIndex != 0 && ddlDOByearFrom.SelectedIndex != 0)
            {
                objBLCandidateSearchByCompany.DOBFrom = Convert.ToDateTime(ddlDOBdayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlDOBmonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlDOByearFrom.SelectedValue.ToString().Trim());
            }
            else
            {
                objBLCandidateSearchByCompany.DOBFrom = Convert.ToDateTime("01/01/1900");
            }

            if (ddlDOBdayTo.SelectedIndex != 0 && ddlDOBmonthTo.SelectedIndex != 0 && ddlDOByearTo.SelectedIndex != 0)
            {
                objBLCandidateSearchByCompany.DOBTo = Convert.ToDateTime(ddlDOBdayTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlDOBmonthTo.SelectedValue.ToString().Trim()) + "/" + ddlDOByearTo.SelectedValue.ToString().Trim());
            }
            else
            {
                objBLCandidateSearchByCompany.DOBTo = Convert.ToDateTime("01/01/1900");
            }

            if (Convert.ToInt32(ddlTestState.SelectedValue.ToString().Trim()) == 0)
            {
                objBLCandidateSearchByCompany.TestState = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.TestState = Convert.ToInt32(ddlTestState.SelectedValue.ToString().Trim());
            }

            if (Convert.ToInt32(ddlTestCity.SelectedValue.ToString().Trim()) == 0)
            {
                objBLCandidateSearchByCompany.TestCity = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.TestCity = Convert.ToInt32(ddlTestCity.SelectedValue.ToString().Trim());
            }



            if (Convert.ToInt32(ddlTestCentre .SelectedValue.ToString().Trim()) == 0)
            {
                objBLCandidateSearchByCompany.TestCentre = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.TestCentre = Convert.ToInt32(ddlTestCentre.SelectedValue.ToString().Trim());
            }



            if (ddlGender.SelectedValue.ToString().Trim() == "Select")
            {
                objBLCandidateSearchByCompany.Gender = "";
            }
            else
            {
                objBLCandidateSearchByCompany.Gender = ddlGender.SelectedValue.ToString().Trim();
            }

            if (ddlYearOfPassing12.SelectedValue.ToString().Trim() == "0")
            {
                objBLCandidateSearchByCompany.YearOfPassing12 = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.YearOfPassing12 = Convert.ToInt32(ddlYearOfPassing12.SelectedValue.ToString().Trim());
            }

            /*
            //10th Percentage
            if(txt10thPercentageMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.Percentage10Min = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.Percentage10Min = Convert.ToInt16(txt10thPercentageMin.Text.ToString().Trim());
            }

            if(txt10thPercentageMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.Percentage10Max = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.Percentage10Max = Convert.ToInt16(txt10thPercentageMax.Text.ToString().Trim());
            }
			
            //12th Percentage
            if(txt12thPercentageMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.Percentage12Min = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.Percentage12Min = Convert.ToInt16(txt12thPercentageMin.Text.ToString().Trim());
            }

            if(txt12thPercentageMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.Percentage12Max = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.Percentage12Max = Convert.ToInt16(txt12thPercentageMax.Text.ToString().Trim());
            }
*/

            //Graduation Percentage
            if (txtGraduationPercentageMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.PercentageGraduationMin = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.PercentageGraduationMin = Convert.ToInt16(txtGraduationPercentageMin.Text.ToString().Trim());
            }

            if (txtGraduationPercentageMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.PercentageGraduationMax = -1;
            }
            else
            {
                objBLCandidateSearchByCompany.PercentageGraduationMax = Convert.ToInt16(txtGraduationPercentageMax.Text.ToString().Trim());
            }

            if (ddlQualification.SelectedValue.ToString().Trim() == "0")
            {
                objBLCandidateSearchByCompany.QualificationDetails = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.QualificationDetails = Convert.ToInt16(ddlQualification.SelectedValue.ToString().Trim());
            }

            if (ddlGraduationStream.SelectedValue.ToString().Trim() == "0")
            {
                objBLCandidateSearchByCompany.GraduationStream = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.GraduationStream = Convert.ToInt16(ddlGraduationStream.SelectedValue.ToString().Trim());
            }

            if (ddlYearOfGraduation.SelectedValue.ToString().Trim() == "0")
            {
                objBLCandidateSearchByCompany.YearOfGraduation = 0;
            }
            else
            {
                objBLCandidateSearchByCompany.YearOfGraduation = Convert.ToInt16(ddlYearOfGraduation.SelectedValue.ToString().Trim());
            }

            if (txtAnalyticalMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.AnalyticalMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.AnalyticalMin = txtAnalyticalMin.Text.ToString().Trim();
            }

            if (txtAnalyticalMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.AnalyticalMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.AnalyticalMax = txtAnalyticalMax.Text.ToString().Trim();
            }

            if (txtQuantitativeMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.QuantitativeMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.QuantitativeMin = txtQuantitativeMin.Text.ToString().Trim();
            }

            if (txtQuantitativeMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.QuantitativeMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.QuantitativeMax = txtQuantitativeMax.Text.ToString().Trim();
            }

            if (txtEWOverallMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWOverallMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWOverallMin = txtEWOverallMin.Text.ToString().Trim();
            }

            if (txtEWOverallMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWOverallMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWOverallMax = txtEWOverallMax.Text.ToString().Trim();
            }

            if (txtEWGrammarMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWGrammarMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWGrammarMin = txtEWGrammarMin.Text.ToString().Trim();
            }

            if (txtEWGrammarMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWGrammarMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWGrammarMax = txtEWGrammarMax.Text.ToString().Trim();
            }

            if (txtEWContentMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWContentMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWContentMin = txtEWContentMin.Text.ToString().Trim();
            }

            if (txtEWContentMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWContentMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWContentMax = txtEWContentMax.Text.ToString().Trim();
            }

            if (txtEWVocabularyMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWVocabularyMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWVocabularyMin = txtEWVocabularyMin.Text.ToString().Trim();
            }

            if (txtEWVocabularyMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWVocabularyMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWVocabularyMax = txtEWVocabularyMax.Text.ToString().Trim();
            }

            if (txtEWSpellingMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWSpellingMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWSpellingMin = txtEWSpellingMin.Text.ToString().Trim();
            }

            if (txtEWSpellingMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.EWSpellingMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.EWSpellingMax = txtEWSpellingMax.Text.ToString().Trim();
            }

            if (txtSLOverallMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLOverallMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLOverallMin = txtSLOverallMin.Text.ToString().Trim();
            }

            if (txtSLOverallMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLOverallMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLOverallMax = txtSLOverallMax.Text.ToString().Trim();
            }

            if (txtSLSentenceMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLSentenceMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLSentenceMin = txtSLSentenceMin.Text.ToString().Trim();
            }

            if (txtSLSentenceMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLSentenceMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLSentenceMax = txtSLSentenceMax.Text.ToString().Trim();
            }

            if (txtSLVocabularyMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLVocabularyMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLVocabularyMin = txtSLVocabularyMin.Text.ToString().Trim();
            }

            if (txtSLVocabularyMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLVocabularyMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLVocabularyMax = txtSLVocabularyMax.Text.ToString().Trim();
            }

            if (txtSLFluencyMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLFluencyMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLFluencyMin = txtSLFluencyMin.Text.ToString().Trim();
            }

            if (txtSLFluencyMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLFluencyMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLFluencyMax = txtSLFluencyMax.Text.ToString().Trim();
            }

            if (txtSLPronunciationMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLPronunciationMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLPronunciationMin = txtSLPronunciationMin.Text.ToString().Trim();
            }

            if (txtSLPronunciationMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.SLPronunciationMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.SLPronunciationMax = txtSLPronunciationMax.Text.ToString().Trim();
            }

            if (txtKSTSpeedMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.KSTSpeedMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.KSTSpeedMin = txtKSTSpeedMin.Text.ToString().Trim();
            }

            if (txtKSTSpeedMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.KSTSpeedMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.KSTSpeedMax = txtKSTSpeedMax.Text.ToString().Trim();
            }

            if (txtKSTAccuracyMin.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.KSTAccuracyMin = "";
            }
            else
            {
                objBLCandidateSearchByCompany.KSTAccuracyMin = txtKSTAccuracyMin.Text.ToString().Trim();
            }

            if (txtKSTAccuracyMax.Text.ToString().Trim() == "")
            {
                objBLCandidateSearchByCompany.KSTAccuracyMax = "";
            }
            else
            {
                objBLCandidateSearchByCompany.KSTAccuracyMax = txtKSTAccuracyMax.Text.ToString().Trim();
            }



            objBLCandidateSearchByCompany.CurrentPage = intCurrentPage;
            objBLCandidateSearchByCompany.PageSize = intPageSize;
            objBLCandidateSearchByCompany.SortBy = SortExp;
            Session["SearchObject"] = objBLCandidateSearchByCompany;
            GetCandidateList(objBLCandidateSearchByCompany);
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
            GenerateDynamicDropdown();
            GenerateCityDropdown();
            BLRegistration objBLRegistration = new BLRegistration();
            ddlTestState.SelectedValue = hdState.Value.ToString().Trim();
            FillTestCitySecond(Convert.ToInt32(hdState.Value.ToString().Trim()));
            ddlTestCity.SelectedValue = hdCity.Value.ToString().Trim();
            FillTestCentreSecond(Convert.ToInt32(hdCity.Value.ToString().Trim()));
            ddlTestCentre.SelectedValue = hdCentre.Value.ToString().Trim();
        }

        #endregion


        #region SetQualificationStreamDropDown()

        private void SetQualificationStreamDropDown()
        {
            GenerateDDLQualification();
            ddlQualification.SelectedValue = hdQualification.Value.ToString().Trim();
            FillGraduationStream(Convert.ToInt32(hdQualification.Value.ToString().Trim()));
            ddlGraduationStream.SelectedValue = hdGraduationStream.Value.ToString().Trim();
            //FillTestCitySecond(Convert.ToInt32(hdState.Value.ToString().Trim()));
            //ddlTestCity.SelectedValue = hdCity.Value.ToString().Trim();

        }

        #endregion

        #region PopulateCandidateList()

        public void PopulateCandidateList(string strSortExp)
        {
            DataTable dtCandidate = new DataTable();
            DataView dtView = new DataView();

            dtCandidate = (DataTable)ViewState["CandidateList"];
            dtView = dtCandidate.DefaultView;
            dtView.Sort = strSortExp;

            int intPageSize = 0;
            bool blAllowPagination = false;

            intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());

            dgSearch.CurrentPageIndex = 0;
            dgSearch.SelectedIndex = 0;
            dgSearch.AllowPaging = blAllowPagination;
            dgSearch.PageSize = intPageSize;
            dgSearch.DataSource = dtView;
            dgSearch.DataBind();

            if (dtCandidate.Rows.Count > 0)
            {

                btnScoreCard.Visible = true;
                btnExportToExcel.Visible = true;
                chkAll.Visible = true;
                pnlSearch.Visible = true;
                pnlMessage.Visible = false;
                lblTotalRecord.Visible = true;
                lblTotalRecord.Text = "Total Record:" + Convert.ToString(ViewState["TotalRecord"]);

            }
            else
            {
                btnScoreCard.Visible = false;
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

        private void GetCandidateList(BLCandidateSearchByCompany objBLCandidateSearchByCompany)
        {
            DataTable dtCandidate = new DataTable();
            DataSet dsSearchCandidate = new DataSet();
            dsSearchCandidate = (DataSet)objBLCandidateSearchByCompany.SearchCandidate();
            dtCandidate = ((DataTable)dsSearchCandidate.Tables[0]);
            ViewState["TotalRecord"] = Convert.ToInt32(dsSearchCandidate.Tables[1].Rows[0][0]);
            ViewState["SelectAll"] = Convert.ToString(dsSearchCandidate.Tables[2].Rows[0][0]);
            ViewState["CandidateList"] = dtCandidate;
            if (dtCandidate.Rows.Count > 0)
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

            if (dtTestState != null && dtTestCity != null)
            {
                intParentRowCount = dtTestState.Rows.Count;
                intChildRowCount = dtTestCity.Rows.Count;

                if (intParentRowCount > 0 && intChildRowCount > 0)
                {
                    for (intOuterIncrementLoop = 0; intOuterIncrementLoop <= intParentRowCount - 1; intOuterIncrementLoop++)
                    {
                        sbAppend.Append("store[");
                        sbAppend.Append(Convert.ToInt32(dtTestState.Rows[intOuterIncrementLoop]["StateId"].ToString().Trim()));
                        sbAppend.Append("] = new Array(");

                        for (intInnerIncrementLoop = 0; intInnerIncrementLoop <= intChildRowCount - 1; intInnerIncrementLoop++)
                        {
                            if (intInnerIncrementLoop == 0)
                            {
                                sbAppend.Append("'Select','0',");

                            }
                            if (Convert.ToInt32(dtTestState.Rows[intOuterIncrementLoop]["StateId"].ToString().Trim()) == Convert.ToInt32(dtTestCity.Rows[intInnerIncrementLoop]["StateId"].ToString().Trim()))
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
                        sbAppend.Remove(sbAppend.Length - 1, 1);
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
                    sbAppend.Append("}</script> ");
                    Response.Write(sbAppend.ToString());
                }
            }
        }

        #endregion

        #region btnExportToExcel_Click()

        protected void btnExportToExcel_Click(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
            {
                Session["CompanyLoginExport"] = "full";
                Response.Redirect("CandidatesExportToExcelByCompany.aspx?SearchType=full", false);
            }
            else
            {
                Session["CompanyLoginExport"] = "selected";
                bool IsSelected = false;
                StringBuilder sbItemList = new StringBuilder();

                SaveCheckedValueTemporary();

                Hashtable htCheckedValue = new Hashtable();
                if (ViewState["CheckedValue"] != null)
                {
                    htCheckedValue = (Hashtable)ViewState["CheckedValue"];
                }

                if (htCheckedValue.Count != 0)
                {
                    IDictionaryEnumerator Enumerator;
                    Enumerator = htCheckedValue.GetEnumerator();
                    while (Enumerator.MoveNext())
                    {
                        if (Convert.ToBoolean(Enumerator.Value))
                        {
                            sbItemList.Append("'");
                            sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));
                            sbItemList.Append("'");
                            sbItemList.Append(",");
                            if (IsSelected == false)
                            {
                                IsSelected = true;
                            }
                        }
                    }
                }

                if (IsSelected)
                {
                    sbItemList.Remove(sbItemList.Length - 1, 1);
                    Session["ItemList"] = sbItemList.ToString();
                    Response.Redirect("CandidatesExportToExcelByCompany.aspx", false);
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
            if (lblSortExp.Text.ToString().Trim() == strSortExp)
            {
                if (strSortExp.IndexOf("ASC") > 0)
                {
                    strSortExp = strSortExp.Replace("ASC", "DESC");
                }
                else if (strSortExp.IndexOf("DESC") > 0)
                {
                    strSortExp = strSortExp.Replace("DESC", "ASC");
                }
            }


            lblSortExp.Text = strSortExp;
            SetStateCityCentreDropDown();
            SaveCheckedValueTemporary();
            //Response.Write(Session["intCurrentPage"].ToString());
            SetSearchParameter(strSortExp, Convert.ToInt32(Session["intCurrentPage"]));
            PopulateCandidateList(strSortExp);

            //PopulateCandidateList(strSortExp);
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
            SetSearchParameter(strSortExp, intCurrentPage);
            //Response.Write(intCurrentPage.ToString());
            Session["intCurrentPage"] = intCurrentPage;
        }

        #endregion



        #region SaveCheckedValueTemporary()

        private void SaveCheckedValueTemporary()
        {
            Hashtable htCheckedValue = new Hashtable();

            //if(ViewState["CheckedValue"] != null)
            if (Session["CheckedValue"] != null)
            {
                //htCheckedValue = (Hashtable) ViewState["CheckedValue"];
                htCheckedValue = (Hashtable)Session["CheckedValue"];
            }

            if (chkAll.Checked)
            {
                if (ViewState["CandidateList"] != null)
                {
                    DataTable dtCandidate = new DataTable();
                    int intTotalRowCount = 0;
                    int intIncrementLoop = 0;
                    dtCandidate = (DataTable)ViewState["CandidateList"];
                    intTotalRowCount = dtCandidate.Rows.Count;
                    hdSelectedCandidateCount.Value = intTotalRowCount.ToString();

                    for (intIncrementLoop = 0; intIncrementLoop <= intTotalRowCount - 1; intIncrementLoop++)
                    {
                        if (htCheckedValue.Contains(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()))
                        {
                            htCheckedValue[dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()] = (bool)(true);
                        }
                        else
                        {
                            htCheckedValue.Add(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim(), ((bool)(true)));
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridItem dgItem in dgSearch.Items)
                {
                    if (htCheckedValue.Contains(((Label)dgItem.FindControl("lblRegistration")).Text.ToString().Trim()))
                    {
                        htCheckedValue[((Label)dgItem.FindControl("lblRegistration")).Text.ToString().Trim()] = (bool)((CheckBox)dgItem.FindControl("chkSelect")).Checked;
                    }
                    else
                    {
                        htCheckedValue.Add(((Label)dgItem.FindControl("lblRegistration")).Text.ToString().Trim(), ((bool)((CheckBox)dgItem.FindControl("chkSelect")).Checked));
                    }
                }
            }
            ViewState["CheckedValue"] = htCheckedValue;
            Session["CheckedValue"] = htCheckedValue;

            int SelectedCandidateCount = 0;
            foreach (DictionaryEntry de in htCheckedValue)
                if (de.Value.ToString() == "True")
                    SelectedCandidateCount = SelectedCandidateCount + 1;
            hdSelectedCandidateCount.Value = SelectedCandidateCount.ToString();



        }

        #endregion

        #region dgSearch_ItemDataBound()

        public void dgSearch_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            Hashtable htCheckedValue = new Hashtable();

            if (ViewState["CheckedValue"] != null)
            {
                htCheckedValue = (Hashtable)ViewState["CheckedValue"];
            }

            if (e.Item.ItemType == ListItemType.Header)
            {
                hdHeaderCheckBox.Value = ((CheckBox)e.Item.FindControl("chkHeader")).ClientID.ToString().Trim();
            }

            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                if (htCheckedValue.Contains(((Label)e.Item.FindControl("lblRegistration")).Text.ToString().Trim()))
                {
                    ((CheckBox)e.Item.FindControl("chkSelect")).Checked = (bool)htCheckedValue[((Label)e.Item.FindControl("lblRegistration")).Text.ToString().Trim()];
                }
            }

            if (chkAll.Checked == true)
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    ((CheckBox)e.Item.FindControl("chkHeader")).Checked = true;
                }
                else if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
                {
                    ((CheckBox)(e.Item.FindControl("chkSelect"))).Checked = true;
                }
            }
        }

        #endregion

        #region DeselectAll_Click()

        protected void btnDeselectAll_Click(object sender, System.EventArgs e)
        {
            if (chkAll.Checked)
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

        #endregion

        #region CreatePDF()

        public string CreatePDF(string strPDFName, string strUserId)
        {
            bool typeflag;
            BusinessLayer.BLGeneratePDF objGeneratePDF = new BLGeneratePDF();
            typeflag = objGeneratePDF.GeneratePDF(strUserId);
            return MapPath("") + "\\TempWorkAreaPdf\\" + strPDFName;
        }

        #endregion

        #region ClearTempFiles
        /// <summary>
        /// This method will be used to clear up all the temporary file created in the process.
        /// from TempWorkArea and TempworkAreaPdf folder.
        /// </summary>
        private void ClearTempFiles(string FilePath)
        {

            // TempWorkAreaPdf is a folder where HTML and PDf file will be created
            if (File.Exists(FilePath))
            {
                try
                {
                    File.Delete(FilePath);
                    FilePath = FilePath.Replace(".pdf", ".html");
                    File.Delete(FilePath);
                }
                catch (Exception ex)
                {
                    throw (ex);

                }
            }
        }

        #endregion

        #region dgSearch_ItemCreated()

        public void dgSearch_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
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

                if (dblNumberOfLink > intNumberOfLink)
                {
                    intNumberOfLink = intNumberOfLink + 1;
                }
                if (ViewState["SelectedPage"] == null)
                {
                    ViewState["SelectedPage"] = 1;
                }

                for (intIncrementLoop = 0; intIncrementLoop <= intNumberOfLink - 1; intIncrementLoop++)
                {
                    if (Convert.ToInt32(ViewState["SelectedPage"]) == intIncrementLoop + 1)
                    {
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

        #endregion

        #region dgSearch_ItemCommand()

        public void dgSearch_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "FetchRecord")
            {
                ViewState["SelectedPage"] = e.CommandArgument.ToString();
                SetStateCityCentreDropDown();
                SaveCheckedValueTemporary();
                SetSearchParameter(lblSortExp.Text.ToString(), Convert.ToInt32(e.CommandArgument));
                Session["intCurrentPage"] = Convert.ToInt32(e.CommandArgument);
            }
        }

        #endregion

        #region Reset
        protected void btnReset_Click(object sender, System.EventArgs e)
        {
            txtRegId.Text = "";
            ddlTestDayFrom.SelectedIndex = 0;
            ddlTestMonthFrom.SelectedIndex = 0;
            ddlTestYearFrom.SelectedIndex = 0;
            ddlTestDayTo.SelectedIndex = 0;
            ddlTestMonthTo.SelectedIndex = 0;
            ddlTestYearTo.SelectedIndex = 0;
            ddlTestState.SelectedIndex = 0;
            FillTestCity();
            ddlTestCity.SelectedIndex = 0;
            ddlDOBdayFrom.SelectedIndex = 0;
            ddlDOBmonthFrom.SelectedIndex = 0;
            ddlDOByearFrom.SelectedIndex = 0;
            ddlDOBdayTo.SelectedIndex = 0;
            ddlDOBmonthTo.SelectedIndex = 0;
            ddlDOByearTo.SelectedIndex = 0;
            FillQualification();
            ddlQualification.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlYearOfPassing12.SelectedIndex = 0;
            //txt10thPercentageMin.Text = "";
            //txt10thPercentageMax.Text = "";
            //txt12thPercentageMin.Text = "";
            //txt12thPercentageMax.Text = "";
            txtGraduationPercentageMin.Text = "";
            txtGraduationPercentageMax.Text = "";
            ddlGraduationStream.SelectedIndex = 0;
            ddlYearOfGraduation.SelectedIndex = 0;
            txtAnalyticalMin.Text = "";
            txtAnalyticalMax.Text = "";
            txtQuantitativeMin.Text = "";
            txtQuantitativeMax.Text = "";
            txtEWOverallMin.Text = "";
            txtEWOverallMax.Text = "";
            txtEWGrammarMin.Text = "";
            txtEWGrammarMax.Text = "";
            txtEWContentMin.Text = "";
            txtEWContentMax.Text = "";
            txtEWVocabularyMin.Text = "";
            txtEWVocabularyMax.Text = "";
            txtEWSpellingMin.Text = "";
            txtEWSpellingMax.Text = "";
            txtSLOverallMin.Text = "";
            txtSLOverallMax.Text = "";
            txtSLSentenceMin.Text = "";
            txtSLSentenceMax.Text = "";
            txtSLVocabularyMin.Text = "";
            txtSLVocabularyMax.Text = "";
            txtSLFluencyMin.Text = "";
            txtSLFluencyMax.Text = "";
            txtSLPronunciationMin.Text = "";
            txtSLPronunciationMax.Text = "";
            txtKSTSpeedMin.Text = "";
            txtKSTSpeedMax.Text = "";
            txtKSTAccuracyMin.Text = "";
            txtKSTAccuracyMax.Text = "";

            btnScoreCard.Visible = false;
            btnExportToExcel.Visible = false;
            chkAll.Visible = false;
            pnlMessage.Enabled = true;
            lblMessage.Enabled = true;
            pnlMessage.Visible = true;
            pnlSearch.Visible = false;
            lblTotalRecord.Visible = false;
            Response.Redirect("CandidateSearchPage.aspx", true);
        }
        #endregion

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
                    sbAppend.Append("var box2 = document.getElementById('ddlGraduationStream'); ");
                    sbAppend.Append("box2.options.length = 0; ");
                    sbAppend.Append("for(i=0;i<list.length;i+=2){ ");
                    sbAppend.Append("box2.options[i/2] = new Option(list[i],list[i+1]); ");
                    sbAppend.Append("} ");
                    sbAppend.Append("}</script> ");
                    Response.Write(sbAppend.ToString());
                }
            }

        }


        protected void btnBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("CompanyHomePage.aspx", false);
        }












    }
}
