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
    public partial class AutomateRegistered_Count : System.Web.UI.Page
    {
        BLAutomateRegistered_Count objBLAutomateRegistered_Count = new BLAutomateRegistered_Count();
        DateTime TestDateFrom;
        DateTime TestDateTo;
        string TestName;
        int Flag = 0;
        int Flag1 = 0;
        int Flag2 = 0;
        #region Page_Load()

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateData();");


            if (Page.IsPostBack != true)
            {
                //Year
                int thisYear = Convert.ToInt32(System.DateTime.Now.Year)+1;
                for (int i = thisYear; i >= 1949; i--)
                {
                    ddlTestYearFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlTestYearTo.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsYear = new ListItem("Year", "0");
                ddlTestYearFrom.Items.Insert(0, lsYear);
                ddlTestYearTo.Items.Insert(0, lsYear);

                //Day

                ddlTestDayTo.Items.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    ddlTestDayFrom.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlTestDayTo.Items.Add(new ListItem(i.ToString(), i.ToString()));

                }
                ListItem lsDay = new ListItem("Day", "0");
                ddlTestDayFrom.Items.Insert(0, lsDay);
                ddlTestDayTo.Items.Insert(0, lsDay);

                //Month
                //manual in aspx

                ///FillTestName();
                ///
            }
           
        }
        #endregion

        //#region FillTestName()
        ////Populating ddlTestEvent Combo box.
        //private void FillTestName()
        //{
        //    try
        //    {
        //        //Creating instance of Datatable.
        //        DataTable dtTestName = new DataTable();
        //        //Adding "Center" as column in dtTestCenter DataTable.
        //        dtTestName.Columns.Add("Name");
        //        //Adding "CenterId" as column in dtTestCenter DataTable.
        //        dtTestName.Columns.Add("TestId");
        //        //Creating object of datarow.
        //        DataRow drNewRow;
        //        //Initializing srNewRow
        //        drNewRow = dtTestName.NewRow();
        //        //Inserting initial value in "Center" column
        //        drNewRow["Name"] = "Select";
        //        //Inserting initial value in "CenterId" column
        //        drNewRow["TestId"] = "0";
        //        //Adding dtNewRow in dtTestCenter(Datatable)
        //        dtTestName.Rows.Add(drNewRow);
        //        //Passing ddlTestCentre drop down in BindDropDown to bind with dtTestCentre.
        //        BindDropDown(ref ddlTestName, dtTestName, "Name", "TestId");
        //        ddlTestName.SelectedIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Calling ErrorRoutine of ErrorLogger to write error text in text file.
        //        ErrorLogger.ErrorRoutine(false, ex);
        //    }

        //}


        //#endregion


        #region BindDropDown()
        private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField)
        {
            ddlDropDownList.DataSource = dtDataTable;
            ddlDropDownList.DataTextField = strTextField;
            //ddlDropDownList.DataValueField = strValueField;
            ddlDropDownList.DataBind();
        }
        #endregion


        #region FillTestNameForDates()
        private void FillTestNameForDates(DateTime TestDateFrom, DateTime TestDateTo)
        {
            BindDropDown(ref ddlTestName, objBLAutomateRegistered_Count.FillTestNameForDates(TestDateFrom,TestDateTo), "Name");
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

       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
     

            if (ddlTestDayFrom.SelectedIndex != 0 && ddlTestMonthFrom.SelectedIndex != 0 && ddlTestYearFrom.SelectedIndex != 0)
            {
                TestDateFrom = Convert.ToDateTime(ddlTestDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestYearFrom.SelectedValue.ToString().Trim());
            }
            if (ddlTestDayTo.SelectedIndex != 0 && ddlTestMonthTo.SelectedIndex != 0 && ddlTestYearTo.SelectedIndex != 0)
            {
                TestDateTo = Convert.ToDateTime(ddlTestDayTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlTestYearTo.SelectedValue.ToString().Trim());
            }
            FillTestNameForDates(TestDateFrom, TestDateTo);
            TestName = ddlTestName.SelectedValue.ToString();	
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (ddlTestDayFrom.SelectedIndex != 0 && ddlTestMonthFrom.SelectedIndex != 0 && ddlTestYearFrom.SelectedIndex != 0)
            {
                Flag = 1;
            }
            else
            {
                this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Please select Test From Date!');</script>");
            }
            if (ddlTestDayTo.SelectedIndex != 0 && ddlTestMonthTo.SelectedIndex != 0 && ddlTestYearTo.SelectedIndex != 0)
            {
                Flag1 = 1;
            }
            else
            {
                this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Please select Test To Date!');</script>");
            }
            if (ddlTestName.SelectedValue.ToString() != "")
            {
                Flag2 = 1;
            }
            else
            {
                this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Please select Test Name!');</script>");
            }

            if ((Flag == 1) && (Flag1 == 1) && (Flag2 == 1))
            {
                TestDateFrom = Convert.ToDateTime(ddlTestDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestYearFrom.SelectedValue.ToString().Trim());
                TestDateTo = Convert.ToDateTime(ddlTestDayTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlTestMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlTestYearTo.SelectedValue.ToString().Trim());
                //TestName = Convert.ToInt32(ddlTestName.SelectedValue);
                DataTable dtReport = new DataTable(); 
                DataSet dsReport = new DataSet();
                dsReport = (DataSet)objBLAutomateRegistered_Count.GetData4Grid(ddlTestName.SelectedValue.ToString(), TestDateFrom, TestDateTo);
                dtReport = ((DataTable)dsReport.Tables[0]);
                //dtTestShifts = ((DataTable)dsReport.Tables[1]);
                //DataView dtView = new DataView(dtReport);
                //GrReport.DataSource = dtView.ToTable("DataTableName", true, "CenterName");


             GrReport.DataSource = dtReport;
                GrReport.DataBind();

            }
        }


    }
}