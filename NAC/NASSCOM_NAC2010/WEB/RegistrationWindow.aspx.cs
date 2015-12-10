using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Common;
using System.Data;
using System.Text;
using BusinessLayer;
using System.Collections;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
    public partial class RegistrationWindow : System.Web.UI.Page
    {
        #region Class Variables
        public string strSortExp;
        private int intCurrentPage;
        DataTable dtTestState = new DataTable();
        DataTable dtTestCity = new DataTable();
        DataTable dtTestCentre = new DataTable();
        private static int intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtRegEndDateTime.Attributes.Add("readonly", "readonly");      
                FillYear();
                FillMonth();
                FillDay();              
                FillState();

                ddlTestCentre.Items.Insert(0, new ListItem("--Select--", "-1"));
                ddlTestCity.Items.Insert(0, new ListItem("--Select--", "-1"));           
 
            }

            fieldsetDetail.Visible = false;
            lblMessage.Text = string.Empty;
            lblUpdateMessage.Text = string.Empty;

        }

        #region Fill DropDown Data

        private void FillYear()
        {
            CLCommonFunctions objCLCommonFunctions = new CLCommonFunctions();
            DataTable dtYear = new DataTable();
            dtYear = objCLCommonFunctions.ReturnYearList(CLCommonFunctions.StartTestDateDropdown);

            ddlTestYearFrom.DataSource = dtYear;
            ddlTestYearFrom.DataTextField = "Year";
            ddlTestYearFrom.DataValueField = "value";
            ddlTestYearFrom.DataBind();

            ddlTestYearTo.DataSource = dtYear;
            ddlTestYearTo.DataTextField = "Year";
            ddlTestYearTo.DataValueField = "value";
            ddlTestYearTo.DataBind();
        }

        private void FillMonth()
        {
            CLCommonFunctions objCLCommonFunctions = new CLCommonFunctions();
            DataTable dtMonth = new DataTable();
            dtMonth = objCLCommonFunctions.ReturnMonthList();

            ddlTestMonthFrom.DataSource = dtMonth;
            ddlTestMonthFrom.DataTextField = "Month";
            ddlTestMonthFrom.DataValueField = "value";
            ddlTestMonthFrom.DataBind();

            ddlTestMonthTo.DataSource = dtMonth;
            ddlTestMonthTo.DataTextField = "Month";
            ddlTestMonthTo.DataValueField = "value";
            ddlTestMonthTo.DataBind();
        }

        private void FillDay()
        {
            CLCommonFunctions objCLCommonFunctions = new CLCommonFunctions();
            DataTable dtDay = new DataTable();
            dtDay = objCLCommonFunctions.ReturnDayList();

            ddlTestDayFrom.DataSource = dtDay;
            ddlTestDayFrom.DataTextField = "Day";
            ddlTestDayFrom.DataValueField = "value";
            ddlTestDayFrom.DataBind();

            ddlTestDayTo.DataSource = dtDay;
            ddlTestDayTo.DataTextField = "Day";
            ddlTestDayTo.DataValueField = "value";
            ddlTestDayTo.DataBind();
        }     

        private void FillState()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            dtTestState = objBLRegistration.FillState();

         
            if (dtTestState.Rows.Count > 0)
            {
                ddlTestState.DataSource = dtTestState;
                ddlTestState.DataTextField = "State";
                ddlTestState.DataValueField = "StateId";
                ddlTestState.DataBind();             
                ddlTestState.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
        }
                   
        private void FillCity()
        {
            BLRegistration objBLRegistration = new BLRegistration();           	 
            dtTestCity= objBLRegistration.FillCity();          
        }
        
        private void FillCentre()
        {
            BLRegistration objBLRegistration = new BLRegistration();
            dtTestCentre= objBLRegistration.FillCentre();
        }

        #endregion

        #region DropDown Event
        protected void ddlTestState_SelectedIndexChanged(object sender, EventArgs e)
        {           
            FillCity();
            
            DataView dv = dtTestCity.DefaultView;
            dv.RowFilter = "stateid=" + ddlTestState.SelectedValue;
            ddlTestCity.DataSource = dv;
            ddlTestCity.Items.Clear();
            ddlTestCentre.Items.Clear();
            if (dv.Count > 0)
            {               
                ddlTestCity.DataTextField = "City";
                ddlTestCity.DataValueField = "CityId";
                ddlTestCity.DataBind();
               
            }
            ddlTestCity.Items.Insert(0, new ListItem("--Select--", "-1"));
            ddlTestCentre.Items.Insert(0, new ListItem("--Select--", "-1"));
               
        }

        protected void ddlTestCity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            FillCentre();
            DataView dv = dtTestCentre.DefaultView;
            dv.RowFilter = "cityId=" + ddlTestCity.SelectedValue;
            ddlTestCentre.DataSource = dv;
            ddlTestCentre.Items.Clear();
            if (dv.Count > 0)
            { 
                ddlTestCentre.DataTextField = "Centre";
                ddlTestCentre.DataValueField = "CentreId";
                ddlTestCentre.DataBind();
               
            }

            ddlTestCentre.Items.Insert(0, new ListItem("--Select--", "-1"));
        }

        #endregion

        #region search button Event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
          

            GetTestDetails();
           
        }

        private void GetTestDetails()
        {

            BLRegistrationWindow objRegistration = new BLRegistrationWindow();
            
            DateTime dateFrom = Convert.ToDateTime(ddlTestYearFrom.SelectedValue.ToString().Trim() + "/" + (ddlTestMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlTestDayFrom.SelectedValue.ToString().Trim());
            DateTime dateTo = Convert.ToDateTime(ddlTestYearTo.SelectedValue.ToString().Trim() + "/" + (ddlTestMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlTestDayTo.SelectedValue.ToString().Trim());
            
            objRegistration.TestDateFrom = dateFrom;
            objRegistration.TestDateTo = dateTo;
            objRegistration.TestState = Convert.ToInt32(ddlTestState.SelectedValue);
            objRegistration.TestCity = Convert.ToInt32(ddlTestCity.SelectedValue);
            objRegistration.TestCentre = Convert.ToInt32(ddlTestCentre.SelectedValue);

            DataSet dsDetails= objRegistration.GetDetails();

            if (dsDetails.Tables[0].Rows.Count > 0)
            {
                fieldsetDetail.Visible = true;
                BindDetails(dsDetails);
            }
            else
            {
                lblMessage.Text = "No Record found";
            }

        }

        #endregion

        private void BindDetails(DataSet dsDetails)
        {

            lblTestDate.Text = dsDetails.Tables[0].Rows[0]["TestDate"].ToString();
            lblState.Text = dsDetails.Tables[0].Rows[0]["state"].ToString();
            lblCity.Text = dsDetails.Tables[0].Rows[0]["City"].ToString();
            lblCentre.Text = dsDetails.Tables[0].Rows[0]["Centre"].ToString();
            lblStartDate.Text = dsDetails.Tables[0].Rows[0]["RegistrationStartDate"].ToString();
            lblEndDate.Text = dsDetails.Tables[0].Rows[0]["RegistrationendDate"].ToString();

            hdnTestId.Value = dsDetails.Tables[0].Rows[0]["TestId"].ToString();
            

        }

        #region Reset button Event
        protected void btnReset_Click(object sender, EventArgs e)
        {
           
            ddlTestDayFrom.SelectedIndex = 0;
            ddlTestMonthFrom.SelectedIndex = 0;
            ddlTestYearFrom.SelectedIndex = 0;
            ddlTestDayTo.SelectedIndex = 0;
            ddlTestMonthTo.SelectedIndex = 0;
            ddlTestYearTo.SelectedIndex = 0;
            ddlTestState.SelectedIndex = 0;
          //  FillTestCity();
            ddlTestCity.SelectedIndex = 0;
            ddlTestCentre.SelectedIndex = 0;     
            
          
         
            pnlMessage.Enabled = true;
            lblMessage.Enabled = true;
            pnlMessage.Visible = true;
            pnlSearch.Visible = false;
         
            Response.Redirect("RegistrationWindow.aspx", true);
        }
        #endregion
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx", false);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BLRegistrationWindow objRegistration = new BLRegistrationWindow();
           
            string dt = (Convert.ToDateTime(txtRegEndDateTime.Text)).ToString("MM/dd/yyyy HH:mm");

            int status = objRegistration.UpdateRegistrationDate(hdnTestId.Value, Convert.ToDateTime(dt));

           if (status > 0)
           {
               GetTestDetails();
               lblUpdateMessage.Text = "Update done successfully";
           }
           else
           {
               lblUpdateMessage.Text = "Sorry ! some error has occured, Please try again or contact to Administrator";
           }

        }

              

    }
}