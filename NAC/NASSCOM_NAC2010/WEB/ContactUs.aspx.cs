using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using Common;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;


namespace NASSCOM_NAC.Web
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillFeedbackType();
                lblMessage.Visible = false;

            }

            System.Web.UI.HtmlControls.HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl();
            li = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Nac_headermenu1.FindControl("contact");
            li.Attributes.Add("class", "active");

            txtEmailID.Attributes.Add("onblur", "ValidateEmailAddress(this);");
            txtMobileNumber.Attributes.Add("onblur", "fillOnlyNumericValue(this);ValidateMobile(this);");
            txtCode.Attributes.Add("onblur", "fillOnlyNumericValue(this);");
            txtLandline.Attributes.Add("onblur", "fillOnlyNumericValue(this);");
            btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateControls();");
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

        #region FillFeedbackType
        private void FillFeedbackType()
        {
            BLContactUs objBLContactUs = new BLContactUs();
            BindDropDown(ref ddlfeedbackType, objBLContactUs.FillFeedbackType(), "FeedbackType", "FeedbackTypeID");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                if (ValidateControls())
                {
                    BLContactUs objBLContactUs = new BLContactUs();
                    objBLContactUs.EmailID = txtEmailID.Text.ToString().Trim();
                    objBLContactUs.FeedbackMessage = txtMessage.Value.ToString().Trim();
                    objBLContactUs.FeedbackSubject = txtSubject.Text.ToString().Trim();
                    objBLContactUs.LandlinePhoneNo = txtLandline.Text.ToString().Trim();
                    objBLContactUs.MobilePhone = txtMobileNumber.Text.ToString().Trim();
                    objBLContactUs.STDCode = txtCode.Text.ToString().Trim();
                    objBLContactUs.QueryType = ddlfeedbackType.SelectedIndex;
                    flag = objBLContactUs.InsertFeedbackDetails();
                    if (flag == 1)
                    {

                        
                       
                        if (ddlfeedbackType.SelectedIndex == 3)
                        {
                            String strScript = "<script language='JavaScript'>alert('Your comment has been recorded');window.location = '../HomePage.aspx'</script>";
                            Page.RegisterClientScriptBlock("myAlertScript", strScript);
                        }


                        else
                        {
                            String strScript = "<script language='JavaScript'>alert('Your " + ddlfeedbackType.SelectedItem + " has been recorded');window.location = '../HomePage.aspx'</script>";
                            Page.RegisterClientScriptBlock("myAlertScript", strScript);


                        }

                        //Sending mail to client 
                        SendMailtoClient();
                        //Sending mail to user
                        SendMailToUser();
                       


                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorRoutine(false, ex);
            }

        }






        private void SendMailToUser()
        {
            string emailID = txtEmailID.Text.ToString().Trim();
            string querytype = ddlfeedbackType.SelectedItem.Text.ToString().Trim();

            if (ddlfeedbackType.SelectedIndex == 3)
            {
                querytype = "Comment";
            }
            try
            {
                CLEmail objCLEmail = new CLEmail();
                StringBuilder EmailBody = new StringBuilder();
                EmailBody.Append("<HTML><BODY>");
                EmailBody.Append("<TABLE cellSpacing=0 cellPadding=3 width=100% bgcolor=#FFFFFF border=0>");
                EmailBody.Append("<TR>");
                EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
                EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Hello</span><br><br>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");

                EmailBody.Append("<TR>");
                EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
                EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Your " +querytype +" has been recorded. We will get back to you</span><br><br>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");

                EmailBody.Append("<TR>");
                EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
                EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial><u>Disclaimer</u>:</span><br><br>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");

                EmailBody.Append("<TR>");
                EmailBody.Append("<TD align=left valign=top colspan=3><br>");
                EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Regards,</span><br>");
                EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>NASSCOM Admin</span><br>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");
                EmailBody.Append("</TABLE>");
                EmailBody.Append("</BODY></HTML>");
                objCLEmail.SendMail(Convert.ToString(EmailBody), Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"]), querytype , emailID, Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
            }

            catch
            { }
        }

        private void SendMailtoClient()
        {
            string emailID = txtEmailID.Text.ToString().Trim();
            string subject = txtSubject.Text.ToString().Trim();
            string message = txtMessage.Value.ToString().Trim();
            string mobileNumber = txtMobileNumber.Text.ToString().Trim();
            string STDCode = txtCode.Text.ToString().Trim();
            string LandlinePhoneNo = txtLandline.Text.ToString().Trim();
            string querytype = ddlfeedbackType.SelectedItem.Text.ToString().Trim();
            if (ddlfeedbackType.SelectedIndex == 3)
            {
                querytype = "Comment";
            }
            CLEmail objCLEmail = new CLEmail();
            StringBuilder EmailBody = new StringBuilder();
            EmailBody.Append("<HTML><BODY>");
            EmailBody.Append("<TABLE cellSpacing=0 cellPadding=3 width=100% bgcolor=#FFFFFF border=0>");
            EmailBody.Append("<TR>");
            EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
            EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Hello</span><br><br>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR>");
            EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
            EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>You have received one " +querytype +".</span><br><br>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR>");
            EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
            EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial><u>Details</u>:</span><br><br>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR valign=top>");
            EmailBody.Append("<TD align=left width=100% valign=top colspan=3>");
            EmailBody.Append("<table cellpadding=0 width=100% cellspacing=0 border=0>");

            EmailBody.Append("<TR valign=top>");
            EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial> " + querytype + " Type:</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
            EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + querytype + "</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR valign=top>");
            EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial> " + querytype + " Subject:</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
            EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + subject + "</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR valign=top>");
            EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial> " + querytype + " Message:</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
            EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + message + "</strong></span>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            EmailBody.Append("<TR valign=top>");
            EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Email ID:</span></strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
            EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
            EmailBody.Append("</TD>");
            EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
            EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + emailID + "</strong></span>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");

            if (mobileNumber != "")
            {
                EmailBody.Append("<TR valign=top>");
                EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
                EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Mobile Number:</span></strong>");
                EmailBody.Append("</TD>");
                EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
                EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
                EmailBody.Append("</TD>");
                EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
                EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + mobileNumber + "</strong></span>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");
            }

            if (STDCode != "" && LandlinePhoneNo != "")
            {
                EmailBody.Append("<TR valign=top>");
                EmailBody.Append("<TD align=left width=25% valign=bottom colspan=3>");
                EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>Landline Number:</span></strong>");
                EmailBody.Append("</TD>");
                EmailBody.Append("<TD align=left width=1% valign=top colspan=3>");
                EmailBody.Append("<strong>&nbsp;:&nbsp;</strong>");
                EmailBody.Append("</TD>");
                EmailBody.Append("<TD align=left width=74% valign=bottom colspan=3>");
                EmailBody.Append("<strong><span style=font-size:9.0pt;font-family:Arial>" + STDCode + "-" + LandlinePhoneNo + "</strong></span>");
                EmailBody.Append("</TD>");
                EmailBody.Append("</TR>");
            }

            EmailBody.Append("</table>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");
            EmailBody.Append("<TR>");
            EmailBody.Append("<TD align=left valign=top colspan=3><br>");
            EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>Regards,</span><br>");
            EmailBody.Append("<span style=font-size:9.0pt;font-family:Arial>NASSSCOM Admin</span><br>");
            EmailBody.Append("</TD>");
            EmailBody.Append("</TR>");
            EmailBody.Append("</TABLE>");
            EmailBody.Append("</BODY></HTML>");
            objCLEmail.SendMail(Convert.ToString(EmailBody), Convert.ToString(ConfigurationSettings.AppSettings["MailFrom"]), querytype, Convert.ToString(ConfigurationSettings.AppSettings["MailTo"]), Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
        }

        private bool ValidateControls()
        {
            if (txtSubject.Text.Trim() == "")
            {
                lblMessage.Text = "Please enter Subject";
                lblMessage.Visible = true;
                return false;
            }

            if (txtSubject.Text.Length > 50)
            {
                lblMessage.Text = "Subject cant be more than 50 characters";
                lblMessage.Visible = true;
                return false;
            }

            if (txtMessage.Value.ToString().Trim() == "")
            {
                lblMessage.Text = "Please enter Message";
                lblMessage.Visible = true;
                return false;
            }

            if (txtMessage.Value.Length > 400)
            {
                lblMessage.Text = "Message cant be more than 400 characters";
                lblMessage.Visible = true;
                return false;
            }

            if (txtEmailID.Text.Trim() == "")
            {
                lblMessage.Text = "Please enter Email ID";
                lblMessage.Visible = true;
                return false;
            }
            else if (!ValidEmail(txtEmailID.Text.Trim()))
            {
                lblMessage.Text = "Please enter valid email ID";
                lblMessage.Visible = true;
                return false;
            }

            if (txtMobileNumber.Text.Trim() != "")
            {

                if (!IsNumeric(txtMobileNumber.Text.Trim()))
                {
                    lblMessage.Text = "Please enter numbers only";
                    lblMessage.Visible = true;
                    return false;
                }

                if (txtMobileNumber.Text.Trim().Length != 10)
                {
                    lblMessage.Text = "Please enter a 10 digit mobile number";
                    lblMessage.Visible = true;
                    return false;
                }
            }
            if (txtCode.Text.Trim() != "")
            {

                if (!IsNumeric(txtCode.Text.Trim()))
                {
                    lblMessage.Text = "Please enter numbers only";
                    lblMessage.Visible = true;
                    return false;
                }


                if (txtCode.Text.Trim().Length < 3)
                {
                    lblMessage.Text = "STD Code can't be less than 3 digits";
                    lblMessage.Visible = true;
                    return false;
                }
            }

            if (txtLandline.Text.Trim() != "")
            {
                if (!IsNumeric(txtLandline.Text.Trim()))
                {
                    lblMessage.Text = "Please enter numbers only";
                    lblMessage.Visible = true;
                    return false;
                }

                if (txtLandline.Text.Trim().Length < 7)
                {
                    lblMessage.Text = "Landline No. can't be less than 7 digits";
                    lblMessage.Visible = true;
                    return false;
                }
            }
         
            return true;
        }

        private bool IsNumeric(string strInput)
        {
            string check = "0123456789";
            bool status = true;
            int count, counter;
            for (count = 0; count < strInput.Length; count++)
            {
                for (counter = 0; counter < check.Length; counter++)
                {
                    if (strInput[count] == check[counter])
                    {
                        break;
                    }
                }
                if (counter == check.Length)
                {
                    status = false;
                    break;
                }
            }
            return status;
        }

        public bool ValidEmail(string strInput)
        {
            if (!Regex.Match(strInput, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}