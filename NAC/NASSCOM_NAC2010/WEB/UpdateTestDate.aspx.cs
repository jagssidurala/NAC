using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLayer;
using System.Data;

namespace NASSCOM_NAC.Web
{
    public partial class UpdateTestDate : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (Page.IsPostBack != true)
            {
                //Year
                int thisYear = Convert.ToInt32(System.DateTime.Now.Year) + 1;
                for (int i = thisYear; i >= 1949; i--)
                {
                    ddlTestYearFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsYear = new ListItem("Year", "0");
                ddlTestYearFrom.Items.Insert(0, lsYear);

                //Day
                for (int i = 1; i <= 31; i++)
                {
                    ddlTestDayFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsDay = new ListItem("Day", "0");
                ddlTestDayFrom.Items.Insert(0, lsDay);

                FillTestState();
            }
            lblMsgNoRecords.Visible = false;
        }
        #endregion

        #region ddlTestState_SelectedIndexChanged
        protected void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlTestState.SelectedIndex != 0)
            {
                Session["StateId"] = ddlTestState.SelectedValue;
                BLRegistration objBLRegistration = new BLRegistration();
                BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCity(Convert.ToInt32(ddlTestState.SelectedValue.ToString())), "City", "CityId");
                ddlTestCity.Items.Insert(0, new ListItem("Select", "0"));

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
            if (ddlTestCity.SelectedIndex != 0)
            {
                Session["CityId"] = ddlTestCity.SelectedValue;
                BLRegistration objBLRegistration = new BLRegistration();
                BindDropDown(ref ddlTestCentre, objBLRegistration.FillAllTestCentre(Convert.ToInt32(ddlTestCity.SelectedValue.ToString())), "Centre", "CentreId");
                ddlTestCentre.Items.Insert(0, new ListItem("Select", "0"));
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

        #region btnGetTestDetaisl
        protected void btnGetTestDetails_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BindTestDetails();
            }
        }
        #endregion

        #region Reset button Event
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlTestDayFrom.SelectedIndex = 0;
            ddlTestMonthFrom.SelectedIndex = 0;
            ddlTestYearFrom.SelectedIndex = 0;
            ddlTestState.SelectedIndex = 0;
            ddlTestCity.SelectedIndex = 0;
            ddlTestCentre.SelectedIndex = 0;
            Response.Redirect("UpdateTestDate.aspx", true);
        }
        #endregion

        #region btnBack_Click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx", false);
        }
        #endregion

        #region BindDropDown
        private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
        {
            ddlDropDownList.DataSource = dtDataTable;
            ddlDropDownList.DataTextField = strTextField;
            ddlDropDownList.DataValueField = strValueField;
            ddlDropDownList.DataBind();
        }
        #endregion

        #region FillTestState
        private void FillTestState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(), "State", "StateId");
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
                ErrorLogger.ErrorRoutine(false, ex);
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

        #region BindTestDetails
        public void BindTestDetails()
        {
            BLUpdationOfTestCapcityAndShiftCapacity objBLUpdationOfTestCapcityAndShiftCapacity = new BLUpdationOfTestCapcityAndShiftCapacity();
            int intTestState = Convert.ToInt32(ddlTestState.SelectedValue);
            int intTestCity = Convert.ToInt32(ddlTestCity.SelectedValue);
            int intTestCentre = Convert.ToInt32(ddlTestCentre.SelectedValue);
            DateTime dtTestDate;
            dtTestDate = Convert.ToDateTime(ddlTestDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestYearFrom.SelectedValue.ToString().Trim());
            DataTable dtReport = new DataTable();
            DataSet dsReport = new DataSet();
            dsReport = (DataSet)objBLUpdationOfTestCapcityAndShiftCapacity.UspGetTestDateDetails(dtTestDate, intTestState, intTestCity, intTestCentre);
            if (dsReport != null && (!(dsReport.Tables.Count == 0)))
            {
                dtReport = ((DataTable)dsReport.Tables[0]);
                if (dtReport != null && (dtReport.Rows.Count > 0))
                {
                    int intIsshiftCount = 0;

                    foreach (DataRow drReport in dtReport.Rows)
                    {
                        if (Convert.ToInt32(drReport["IsShiftTime"]) == 0)
                        {
                            intIsshiftCount = 0;

                        }
                        else
                        {
                            intIsshiftCount = 1;
                        }

                    }
                    if (intIsshiftCount == 1)
                    {
                        rptrNonShiftDetails.Visible = false;
                        rptTestDetailshift.Visible = true;
                        rptTestDetailshift.DataSource = dtReport;
                        rptTestDetailshift.DataBind();
                    }
                    else
                    {
                        rptTestDetailshift.Visible = false;
                        rptrNonShiftDetails.Visible = true;
                        rptrNonShiftDetails.DataSource = dtReport;
                        rptrNonShiftDetails.DataBind();
                    }
                }
            }
            else
            {
                lblMsgNoRecords.Visible = true;
               lblMsgNoRecords.Text = "No Records found";
                rptrNonShiftDetails.Visible = false;
                rptTestDetailshift.Visible = false;
            }

        }
        #endregion

        #region rptTestDetailshift_ItemCommand
        protected void rptTestDetailshift_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                string lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").UniqueID);
                lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").ClientID);
                HiddenField hdnTestId = (HiddenField)e.Item.FindControl("hdnTestId");
                HiddenField hdnIsShiftTime = (HiddenField)e.Item.FindControl("hdnIsShiftTime");
                HiddenField hdnShiftID = (HiddenField)e.Item.FindControl("hdnShiftID");
                DropDownList ddlRptTestDay = (DropDownList)e.Item.FindControl("ddlRptTestDay");
                DropDownList ddlRptTestMonthFrom = (DropDownList)e.Item.FindControl("ddlRptTestMonthFrom");
                DropDownList ddlRptTestYear = (DropDownList)e.Item.FindControl("ddlRptTestYear");
                int intTestId = Convert.ToInt32(hdnTestId.Value);
                int intIsShiftTime = Convert.ToInt32(hdnIsShiftTime.Value);
                int intShiftID = Convert.ToInt32(hdnShiftID.Value);
                DateTime dtTestDate;
                HiddenField hdnTestDate = (HiddenField)e.Item.FindControl("hdnTestDate");
                DateTime dtcmprTestDate;
                if (DateTime.TryParse(hdnTestDate.Value, out dtcmprTestDate))
                {
                    if (dtcmprTestDate > DateTime.Now)
                    {
                        if (Convert.ToInt32(ddlRptTestDay.SelectedValue) != 0 && Convert.ToInt32(ddlRptTestMonthFrom.SelectedValue) != 0 && Convert.ToInt32(ddlRptTestYear.SelectedValue) != 0)
                        {
                            dtTestDate = Convert.ToDateTime(ddlRptTestDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlRptTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlRptTestYear.SelectedValue.ToString().Trim());
                            if (dtTestDate > DateTime.Now)
                            {
                                UpdateTestDateDetails(intShiftID, intTestId, intIsShiftTime, dtTestDate, dtTestDate);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test date updated successfully." + "')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test date must be greater than current date." + "')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Select correct test date." + "')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test is already conducted and date cannot be changed." + "')", true);
                    }
                }
            }
        }
        #endregion

        #region rptrNonShiftDetails_ItemCommand
        protected void rptrNonShiftDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.Item.ItemIndex > -1)
            {
                string lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").UniqueID);
                lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").ClientID);
                HiddenField hdnTestId = (HiddenField)e.Item.FindControl("hdnTestId");
                HiddenField hdnIsShiftTime = (HiddenField)e.Item.FindControl("hdnIsShiftTime");
                DropDownList ddlRptTestDay = (DropDownList)e.Item.FindControl("ddlRptTestDay");
                DropDownList ddlRptTestMonthFrom = (DropDownList)e.Item.FindControl("ddlRptTestMonthFrom");
                DropDownList ddlRptTestYear = (DropDownList)e.Item.FindControl("ddlRptTestYear");
                int intTestId = Convert.ToInt32(hdnTestId.Value);
                int intIsShiftTime = Convert.ToInt32(hdnIsShiftTime.Value);
                DateTime dtTestDate;
                HiddenField hdnTestDate = (HiddenField)e.Item.FindControl("hdnTestDate");
                DateTime dtcmprTestDate;
                if (DateTime.TryParse(hdnTestDate.Value, out dtcmprTestDate))
                {
                    if (dtcmprTestDate > DateTime.Now)
                    {
                        if (Convert.ToInt32(ddlRptTestDay.SelectedValue) != 0 && Convert.ToInt32(ddlRptTestMonthFrom.SelectedValue) != 0 && Convert.ToInt32(ddlRptTestYear.SelectedValue) != 0)
                        {
                            dtTestDate = Convert.ToDateTime(ddlRptTestDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlRptTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlRptTestYear.SelectedValue.ToString().Trim());
                            if (dtTestDate > DateTime.Now)
                            {
                                UpdateTestDateDetails(0, intTestId, intIsShiftTime, dtTestDate, dtTestDate);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test date updated successfully." + "')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test date must be greater than current date." + "')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Selcect correct test date." + "')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test is already conducted and date cannot be changed." + "')", true);
                    }
                }
            }
        }
        #endregion

        #region UpdateTestDateDetais
        public void UpdateTestDateDetails( int shiftId,int intTestId,int IsShiftTime,DateTime TestDate,DateTime TestTime)
        {
            BLUpdationOfTestCapcityAndShiftCapacity objBLUpdationOfTestCapcityAndShiftCapacity = new BLUpdationOfTestCapcityAndShiftCapacity();
            objBLUpdationOfTestCapcityAndShiftCapacity.UpdateTestDateAndTestTime(shiftId, intTestId, IsShiftTime, TestDate, TestTime);
        }
        #endregion

        #region rptrNonShiftDetails_ItemDataBound
        protected void rptrNonShiftDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemIndex > -1)
            {

                DropDownList ddldays = (DropDownList)e.Item.FindControl("ddlRptTestDay");
                DropDownList ddlRptTestYear = (DropDownList)e.Item.FindControl("ddlRptTestYear");


                int thisYear = Convert.ToInt32(System.DateTime.Now.Year) + 1;
                for (int i = thisYear; i >= 1949; i--)
                {
                    ddlRptTestYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsYear = new ListItem("Year", "0");
                ddlRptTestYear.Items.Insert(0, lsYear);

                for (int i = 1; i <= 31; i++)
                {
                    ddldays.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ListItem lsDay = new ListItem("Day", "0");
                ddldays.Items.Insert(0, lsDay);

                string binddropdown = (string)((DataRowView)e.Item.DataItem)["TestDate"].ToString() ;
                ddldays.SelectedValue = binddropdown;
            }
        }
        #endregion

        #region rptrNonShiftDetails_ItemDataBound
        protected void rptTestDetailshift_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {

                DropDownList ddldays = (DropDownList)e.Item.FindControl("ddlRptTestDay");
                DropDownList ddlRptTestYear = (DropDownList)e.Item.FindControl("ddlRptTestYear");


                int thisYear = Convert.ToInt32(System.DateTime.Now.Year) + 1;
                for (int i = thisYear; i >= 1949; i--)
                {
                    ddlRptTestYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsYear = new ListItem("Year", "0");
                ddlRptTestYear.Items.Insert(0, lsYear);

                for (int i = 1; i <= 31; i++)
                {
                    ddldays.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                ListItem lsDay = new ListItem("Day", "0");
                ddldays.Items.Insert(0, lsDay);

                string binddropdown = (string)((DataRowView)e.Item.DataItem)["TestDate"].ToString();
                ddldays.SelectedValue = binddropdown;
            }
        }
        #endregion
    }
}