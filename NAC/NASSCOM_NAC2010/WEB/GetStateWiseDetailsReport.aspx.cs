using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLayer;
using System.Data;
using System.Configuration;


namespace NASSCOM_NAC.Web
{
    public partial class GetStateWiseDetailsReport : System.Web.UI.Page
    {
        #region StaticVariables
        private static int intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());
        #endregion

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
                    ddlTestYearTo.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsYear = new ListItem("Year", "0");
                ddlTestYearFrom.Items.Insert(0, lsYear);
                ddlTestYearTo.Items.Insert(0, lsYear);

                //Day
                for (int i = 1; i <= 31; i++)
                {
                    ddlTestDayFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlTestDayTo.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                FillTestState();
                ddlTestState.Items.RemoveAt(0);
                ListItem lsDay = new ListItem("Day", "0");
                ddlTestDayFrom.Items.Insert(0, lsDay);
                ddlTestDayTo.Items.Insert(0, lsDay);
            }          

           
        }
        #endregion

        #region FillTestState
        private void FillTestState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlTestState, objBLRegistration.FillAllTestState(), "State", "StateId");
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

        #region btnSearch_Click
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                GetStateWiseDetailReport();
            }
        }
        #endregion

        #region GetStateWiseDetailReport
        public void GetStateWiseDetailReport()
        {
            try
            {
                BLGetStateWiseDetails objBLGetStateWiseDetails = new BLGetStateWiseDetails();
                DataTable dtCandidateDetails = new DataTable();
                DateTime dtTestDateFrom;
                dtTestDateFrom = Convert.ToDateTime(ddlTestDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestYearFrom.SelectedValue.ToString().Trim());
                Session["dtTestDateFrom"] = dtTestDateFrom;
                DateTime dtTestDateTo;
                dtTestDateTo = Convert.ToDateTime(ddlTestDayTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlTestYearTo.SelectedValue.ToString().Trim());
                Session["dtTestDateTo"] = dtTestDateTo;
                int intTestState = Convert.ToInt32(ddlTestState.SelectedValue.ToString());
                Session["intTestState"] = intTestState.ToString();
                if (dtTestDateTo > dtTestDateFrom)
                {
                    DataSet dsBLGetStateWiseDetails = objBLGetStateWiseDetails.GetStateWiseCandidateDetails(dtTestDateFrom.ToString(), dtTestDateTo.ToString(), intTestState);
                    dtCandidateDetails = ((DataTable)dsBLGetStateWiseDetails.Tables[0]);
                    if (dtCandidateDetails.Rows.Count > 0)
                    {
                        lblMsgNoRecords.Visible = false;
                        btnExportToExcel.Visible = true;
                        lblTotalRecords.Visible = true;
                        dgSearch.Visible = true;
                        ViewState["TotalRecord"] = Convert.ToInt32(dsBLGetStateWiseDetails.Tables[1].Rows[0][0]);
                        lblTotalRecords.Text = "Total Records Count:" + Convert.ToString(ViewState["TotalRecord"]);
                        dgSearch.Visible = false;
                        //dgSearch.DataSource = dtCandidateDetails;
                        // dgSearch.DataBind();
                    }
                    else
                    {
                        btnExportToExcel.Visible = false;
                        lblMsgNoRecords.Visible = true;
                        lblMsgNoRecords.Text = "No Record Found!";
                        lblTotalRecords.Visible = false;
                        dgSearch.Visible = false;
                    }
                }
                else
                {
                    lblMsgNoRecords.Visible = true;
                    btnExportToExcel.Visible = false;
                    lblTotalRecords.Visible = false;
                    dgSearch.Visible = false;
                    lblMsgNoRecords.Text = "Test Start date  must be greater than test End date ";
                }
            }
            catch (Exception SysEx)
            {
                ErrorLogger.ErrorRoutine(false, SysEx);
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);

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
        }
        #endregion

        #region dgSearch_ItemDataBound()
        public void dgSearch_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
        }
        #endregion

        #region dgSearch_PageIndexChanged()
        public void dgSearch_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
        }
        #endregion

        #region dgSearch_SortCommand()
        public void dgSearch_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
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

        #region btnExportToExcel_Click
        protected void btnExportToExcel_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("GetStateWiseDetailsReportToExcel.aspx?SearchType=full", false);
            }
        }
        #endregion

        #region btnReset_Click
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlTestDayFrom.SelectedIndex = 0;
            ddlTestMonthFrom.SelectedIndex = 0;
            ddlTestYearFrom.SelectedIndex = 0;
            ddlTestState.SelectedIndex = 0;
            //  FillTestCity();

            Response.Redirect("GetStateWiseDetailsReport.aspx", true);
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