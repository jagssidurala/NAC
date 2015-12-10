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
    public partial class UpdateTestCapacityandShiftCapcity : System.Web.UI.Page
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
            lblrpttestdetailsMsg.Visible = false;
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

        #region BindDropDown
        private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
        {
            ddlDropDownList.DataSource = dtDataTable;
            ddlDropDownList.DataTextField = strTextField;
            ddlDropDownList.DataValueField = strValueField;
            ddlDropDownList.DataBind();
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

        #region btnGetTestDetaisl
        protected void btnGetTestDetails_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BindTestDetails();
            }
        }
        #endregion

        #region FillTestState
        private void FillTestState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(), "State", "StateId");
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
            dsReport = (DataSet)objBLUpdationOfTestCapcityAndShiftCapacity.GetTestAndShiftCapacity(dtTestDate, intTestState, intTestCity, intTestCentre);
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
                        rptTestDetailsNonShift.Visible = false;
                        rpttestdetails.Visible = true;
                        rpttestdetails.DataSource = dtReport;
                        rpttestdetails.DataBind();
                    }
                    else
                    {
                        rpttestdetails.Visible = false;
                        rptTestDetailsNonShift.Visible = true;
                        rptTestDetailsNonShift.DataSource = dtReport;
                        rptTestDetailsNonShift.DataBind();
                    }
                }
            }
            else
            {
                lblMsgNoRecords.Visible = true;
                lblMsgNoRecords.Text = "No Tests are conducted on this date";
                rpttestdetails.Visible = false;
                rptTestDetailsNonShift.Visible = false;
            }

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

        #region rptTestDetailsNonShift_ItemCommand
        protected void rptTestDetailsNonShift_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                Label lblUpdateMsg = (Label)e.Item.FindControl("lblUpdateMsg");
                string lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblUpdateMsg").UniqueID);
                lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblUpdateMsg").ClientID);
                if (e.CommandName == "Update")
                {
                    TextBox txtNewCapacity = (TextBox)e.Item.FindControl("txtNewCapacity");
                    HiddenField hdnTestId = (HiddenField)e.Item.FindControl("hdnTestId"); 
                    HiddenField hdnTestDate = (HiddenField)e.Item.FindControl("hdnTestDate");
                    HiddenField hdnRegisteredCount = (HiddenField)e.Item.FindControl("hdnRegisteredCount");
                    if (!string.IsNullOrEmpty(hdnTestId.Value) && !string.IsNullOrEmpty(txtNewCapacity.Text))
                    {
                         DateTime dtcmprTestDate;
                         if (DateTime.TryParse(hdnTestDate.Value, out dtcmprTestDate))
                         {
                             int intNewTestCapacity;
                             if (int.TryParse(txtNewCapacity.Text, out intNewTestCapacity))
                             {

                                 int intTestId = Convert.ToInt32(hdnTestId.Value);
                                 intNewTestCapacity = Convert.ToInt32(txtNewCapacity.Text);
                                 int intRegisteredCount = Convert.ToInt32(hdnRegisteredCount.Value);
                                 if (intNewTestCapacity > intRegisteredCount)
                                 {
                                     UpdateTestCapacityDetails(0, intTestId, intNewTestCapacity, 0);
                                     BindTestDetails();
                                     lblUpdateMsg.Visible = true;
                                     //  lblUpdateMsg.Text = "Test Capacty Updated Successfully.";
                                     ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test Capacty Updated Successfully." + "')", true);
                                 }
                                 else
                                 {
                                     ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Test capacty must be Greater than registered count " + "')", true);
                                 }
                             }
                             else
                             {
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblNonShiftText('" + lblRptSucceesmessageUnqueId + "','" + "Capacity must be only numbers " + "')", true);
                             }
                         }
                         else
                         {
                             ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Test is already conducted and Capacity cannot be changed." + "')", true);
                         }

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtNewCapacity.Text))
                        {
                            lblrpttestdetailsMsg.Visible = true;
                            lblrpttestdetailsMsg.Text = "Enter Test capacity";

                        }
                    }
                }
            }
            
        }
        #endregion
        
        #region UpdateTestCapacityDetaisl
        public void UpdateTestCapacityDetails(int intShiftId, int intTestId, int TestCount, int ShiftCount)
        {
            BLUpdationOfTestCapcityAndShiftCapacity objBLUpdationOfTestCapcityAndShiftCapacity = new BLUpdationOfTestCapcityAndShiftCapacity();
            objBLUpdationOfTestCapcityAndShiftCapacity.UpdateTestCapcityAndShiftCapacity(intShiftId, intTestId, TestCount, ShiftCount);
           // BindTestDetails();
        }
        #endregion

        #region rpttestdetails_ItemCommand
        protected void rpttestdetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                Label lblRptSucceesmessage = (Label)e.Item.FindControl("lblRptSucceesmessage");
                string lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").UniqueID);
                lblRptSucceesmessageUnqueId = (e.Item.FindControl("lblRptSucceesmessage").ClientID);
                lblRptSucceesmessage.Visible = true;
                if (e.CommandName == "Update")
                {
                    if (Page.IsValid)
                    {
                        TextBox txtNewCapacity = (TextBox)e.Item.FindControl("txtNewCapacity");
                        HiddenField hdnShiftId = (HiddenField)e.Item.FindControl("hdnShiftId");
                        HiddenField hdnTestId = (HiddenField)e.Item.FindControl("hdnTestId");
                        HiddenField hdnTestDate = (HiddenField)e.Item.FindControl("hdnTestDate");
                        HiddenField hdnRegisteredCount = (HiddenField)e.Item.FindControl("hdnRegisteredCount");
                        TextBox txtNewShiftCapacity = (TextBox)e.Item.FindControl("txtNewShiftCapacity");
                        if (!string.IsNullOrEmpty(txtNewShiftCapacity.Text) && !string.IsNullOrEmpty(hdnShiftId.Value) && !string.IsNullOrEmpty(hdnTestId.Value) && !string.IsNullOrEmpty(txtNewCapacity.Text))
                        {
                            DateTime dtcmprTestDate;
                            if (DateTime.TryParse(hdnTestDate.Value, out dtcmprTestDate))
                            {

                                if (dtcmprTestDate > DateTime.Now)
                                {
                                    int intShiftId = Convert.ToInt32(hdnShiftId.Value);
                                    int intTestId = Convert.ToInt32(hdnTestId.Value);
                                    int intNewShiftCapacity;
                                    int intNewTestCapacity;
                                    int intRegisteredCount = Convert.ToInt32(hdnRegisteredCount.Value);
                                    if (int.TryParse(txtNewShiftCapacity.Text, out intNewShiftCapacity))
                                    {
                                        if (int.TryParse(txtNewCapacity.Text, out intNewTestCapacity))
                                        {
                                            if (intNewTestCapacity > intRegisteredCount)
                                            {

                                                if (intNewTestCapacity > intNewShiftCapacity)
                                                {
                                                    UpdateTestCapacityDetails(intShiftId, intTestId, intNewTestCapacity, intNewShiftCapacity);
                                                    BindTestDetails();
                                                    lblRptSucceesmessage.Text = "Shift Capacity updated successfully";
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Shift Capacity updated successfully" + "')", true);

                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Test Capacity must be greater then the Shift Capacity" + "')", true);

                                                }
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Test Capacity must be greater then the registered count" + "')", true);

                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Capacity must be only numbers" + "')", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Capacity must be only numbers" + "')", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Test is already conducted and Capacity cannot be changed." + "')", true);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(txtNewShiftCapacity.Text) || (string.IsNullOrEmpty(txtNewCapacity.Text)))
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "changelblText('" + lblRptSucceesmessageUnqueId + "','" + "Enter Test capacity and shift capacity" + "')", true);

                                }
                            }
                        }
                    }
                }
            }


        }
        #endregion

        #region rpttestdetails_ItemDataBound
        protected void rpttestdetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ((RequiredFieldValidator)e.Item.FindControl("rfvtxtNewShiftCapacity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewShiftCapacity")).UniqueID;
                    ((Button)e.Item.FindControl("btnSubmitNewCapcity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewShiftCapacity")).UniqueID;

                    ((RequiredFieldValidator)e.Item.FindControl("rfvtxtNewCapacity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewShiftCapacity")).UniqueID;
                    ((RegularExpressionValidator)e.Item.FindControl("revtxtNewCapacity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewShiftCapacity")).UniqueID;
                    ((RegularExpressionValidator)e.Item.FindControl("revtxtNewShiftCapacity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewShiftCapacity")).UniqueID;

                    //((Button)e.Item.FindControl("btnSubmitNewCapcity")).ValidationGroup = ((TextBox)e.Item.FindControl("txtNewCapacity")).UniqueID;


                }

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
            //  FillTestCity();
            ddlTestCity.SelectedIndex = 0;
            ddlTestCentre.SelectedIndex = 0;

            Response.Redirect("UpdateTestCapacityandShiftCapcity.aspx", true);
        }
        #endregion

        #region btnBack_Click
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx", false);

        }
        #endregion

    }
}