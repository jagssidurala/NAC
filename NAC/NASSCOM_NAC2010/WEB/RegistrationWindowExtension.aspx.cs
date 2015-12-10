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

namespace NASSCOM_NAC.Web
{
    public partial class RegistrationWindowExtension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("OnClick", "javascript:return ValidateData();");
            if (Convert.ToInt64(HttpContext.Current.Session["UserType"]) != 2)
            {
                Session.Abandon();
                Response.Redirect("../Web/Login.aspx");
            }
            if (!IsPostBack)
            {
                lblMsg.Visible = false;
                FillTestEvent();

            }
        }

        private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
        {
            ddlDropDownList.DataSource = dtDataTable;
            ddlDropDownList.DataTextField = strTextField;
            ddlDropDownList.DataValueField = strValueField;
            ddlDropDownList.DataBind();
        }

        private void FillTestEvent()
        {           
           
            BLDatesExtensionByAdmin objBLRegistrationExtension = new BLDatesExtensionByAdmin();
            BindDropDown(ref ddlEventName, objBLRegistrationExtension.FillTestEvent(), "name", "TestId");
        }

        public string ChangeTimeFormat(string strTime)
        {
            if (strTime == "12:00 PM")
            {
                return "12:00 Noon";
            }
            else
            {
                return strTime;
            }

        }

        protected void ddlEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (Convert.ToInt32(ddlEventName.SelectedValue.ToString()) != 0)
            {
                BLDatesExtensionByAdmin objBLRegistrationExtension = new BLDatesExtensionByAdmin();
                objBLRegistrationExtension.TestId = Convert.ToInt32(ddlEventName.SelectedValue.ToString());
                DataSet dsTestDetails = objBLRegistrationExtension.FillTestDetails();
                string strTestDate = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsTestDetails.Tables[0].Rows[0]["TestDate"].ToString().Trim()));
                txtTestDate.Text = strTestDate;
                txtTestCentre.Text = dsTestDetails.Tables[0].Rows[0]["Centre"].ToString();
                string strRegistrationEndDate = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsTestDetails.Tables[0].Rows[0]["RegistrationEndDate"].ToString())) + ' ' + ChangeTimeFormat(String.Format("{0:hh:mm tt}", Convert.ToDateTime(dsTestDetails.Tables[0].Rows[0]["RegistrationEndDate"].ToString())));
                txtRegistrationEndDate.Text = strRegistrationEndDate;
            }
            else { Reset(); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatecontrol())
                {
                    BLDatesExtensionByAdmin objBLRegistrationExtension = new BLDatesExtensionByAdmin();
                    objBLRegistrationExtension.TestId = Convert.ToInt32(ddlEventName.SelectedValue.ToString());
                    objBLRegistrationExtension.NewRegistrationEndDate = Convert.ToDateTime(txtNewRegistrationEndDate.Text);
                    Session["RegEndDate"] = Convert.ToDateTime(txtNewRegistrationEndDate.Text);
                    string strSystemIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0).ToString();
                    objBLRegistrationExtension.SystemIP = strSystemIP;
                    objBLRegistrationExtension.UpdateRegistrationEndDate();
                    Confirmationmail();
                    lblMsg.Visible = true;
                    lblMsg.Text = "Registration End Date updated successfully";
                }
            }
            catch (Exception Ex)
            {
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(Ex);
            }
        }

        protected void Confirmationmail()
        {
            StringBuilder body = new StringBuilder();
            CLEmail objCommon = new CLEmail();
            string strName = ddlEventName.SelectedItem.ToString();
            body.Append("The Registration window for Test Name " + strName + " is extended till " + Session["RegEndDate"]);
            objCommon.SendMail(body.ToString(), "nacdb@mail.nasscom.in", "Registration Window Extention", Convert.ToString(ConfigurationSettings.AppSettings["MailTo"].ToString()), Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));

        }

        protected void Reset()
        {
            ddlEventName.SelectedIndex = 0;
            txtTestDate.Text = "";
            txtTestCentre.Text = "";
            txtRegistrationEndDate.Text = "";
            txtNewRegistrationEndDate.Text = "";

        }

        private bool validatecontrol()
        {
            if (ddlEventName.SelectedIndex == 0)
            {
                ddlEventName.BackColor = System.Drawing.Color.Yellow;
                lblMsg.Visible = true;
                lblMsg.Text = "Please select event name";
                return false;
            }
            if (txtNewRegistrationEndDate.Text == "")
            {
                txtNewRegistrationEndDate.BackColor = System.Drawing.Color.Yellow;
                lblMsg.Visible = true;
                lblMsg.Text = "Please enter new registration end date";
                return false;
            }
            return true;
        }

    }
}