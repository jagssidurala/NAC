using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;
using BusinessLayer;
using System.Text;

namespace NASSCOM_NAC
{
    public partial class HomePageV2 : System.Web.UI.Page
    {
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

        private string MonthYear(string strMonth)
        {
            string strMonthName = null;

            switch (strMonth)
            {
                case "1": strMonthName = Month.January.ToString();
                    break;
                case "2": strMonthName = Month.February.ToString();
                    break;
                case "3": strMonthName = Month.March.ToString();
                    break;
                case "4": strMonthName = Month.April.ToString();
                    break;
                case "5": strMonthName = Month.May.ToString();
                    break;
                case "6": strMonthName = Month.June.ToString();
                    break;
                case "7": strMonthName = Month.July.ToString();
                    break;
                case "8": strMonthName = Month.August.ToString();
                    break;
                case "9": strMonthName = Month.September.ToString();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblCompanyLoginError.Visible = false;
                lblCandidateLoginError.Visible = false;
                FillPhotoIdDetail();
            }
            txtUserID.Attributes.Add("autocomplete", "off");
            btnLogin.Attributes.Add("onclick", "return ValidateLogin();");
            btnCompanyLogin.Attributes.Add("onclick", "return ValidateCompanyLogin();");
            btnNewUserLogin.Attributes.Add("onclick", "return ValidateNewUserLogin();");
            //DefaultButton(ref this.txtPhotoIdNumber, ref this.btnLogin);
            //DefaultButton(ref this.txtPassword, ref this.btnLogin);
            //DefaultButtonDDL(ref this.ddlPhotoIdDocument, ref this.btnLogin);

            System.Web.UI.HtmlControls.HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl();
            li = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Nac_headermenu1.FindControl("home");
            li.Attributes.Add("class", "active");
        }


        #region Login

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String strPhotoId = ddlPhotoIdDocument.SelectedIndex.ToString().Trim();
            String strDocumentNo = txtPhotoIdNumber.Text.ToString().Trim();
            String strPassword = txtPassword.Text.ToString().Trim();
            String strNACRegID = txtNacRegId.Text.ToString().Trim();

            try
            {
                BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
                DataSet ds = chkUser.ValidateUserCredential(strPhotoId, strDocumentNo, strPassword, strNACRegID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    HttpContext.Current.Session["UserID"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["FName"].ToString();
                    HttpContext.Current.Session["UserType"] = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());
                    HttpContext.Current.Session["StateId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["TestState"].ToString());
                    HttpContext.Current.Session["StateName"] = ds.Tables[0].Rows[0]["State"].ToString();
                    HttpContext.Current.Session["RegistrationDate"] = ds.Tables[0].Rows[0]["DateOfRegistration"].ToString();
                    HttpContext.Current.Session["TestName"] = ds.Tables[0].Rows[0]["TestName"].ToString();
                    HttpContext.Current.Session["JobLogin"] = ds.Tables[0].Rows[0]["JobLogin"].ToString();
                    HttpContext.Current.Session["JobLoginPassword"] = ds.Tables[0].Rows[0]["JobLoginPassword"].ToString();
                    HttpContext.Current.Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                    HttpContext.Current.Session["RegistrationId"] = ds.Tables[0].Rows[0]["RegistrationId"].ToString();

                    Response.Redirect("Web/Welcome.aspx", false);
                }
                else
                {
                    HttpContext.Current.Session["UserID"] = null;
                    HttpContext.Current.Session["UserName"] = null;
                    HttpContext.Current.Session["UserType"] = null;
                    tblCandidateErrorMessage.Visible = true;
                    lblCandidateLoginError.Visible = true;
                    lblCandidateLoginError.Text = "Wrong credentials entered.Please check";
                }
            }
            catch (ThreadAbortException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorRoutine(false, ex);
            }

        }

        protected void btnCompanyLogin_Click(object sender, EventArgs e)
        {
            string LoginID = txtUserName.Text.ToString();
            string Password = txtPwrd.Text.ToString();
            try
            {
                BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
                DataSet ds = new DataSet();
                objBLCompanyLogin.LoginId = LoginID;
                objBLCompanyLogin.Password = objBLCompanyLogin.base64Encode(Password);
                ds = objBLCompanyLogin.ValidateCompanyLogin();

                if (ValidateCompanyLoginControls(ds))
                {
                    Session["CompanyId"] = ds.Tables[0].Rows[0]["CompanyId"].ToString();
                    Session["CompanyName"] = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    Session["IsUpdated"] = ds.Tables[0].Rows[0]["IsUpdated"].ToString();
                    Response.Redirect("NACdb/CompanyHomePage.aspx", false);
                }
            }
            catch (ThreadAbortException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorRoutine(false, ex);
            }


        }

        protected void btnNewUserLogin_Click(object sender, System.EventArgs e)
        {
            String strSerialNo = txtUserID.Text.ToString().Trim();
            String strPinNo = txtUserPassword.Text.ToString().Trim();
            string centreName = "";
            string strStatus = "";
            string strDate = "";
            string strEndTime = "";

            try
            {
                BusinessLayer.BLLogin oPin = new BusinessLayer.BLLogin();
                DataSet dsPIN = oPin.ValidatePin(strSerialNo, strPinNo);

                if (dsPIN.Tables[0].Rows.Count > 0)
                {
                    bool status = Convert.ToBoolean(dsPIN.Tables[0].Rows[0]["Active"].ToString());
                    if (status == false)		//Checking if Pin is inactive
                    {
                        BLRegistration objBLRegistration = new BLRegistration();
                        DataSet dsCentreStatus = objBLRegistration.IsTestActive(strSerialNo, strPinNo);

                        strStatus = dsCentreStatus.Tables[0].Rows[0][0].ToString();
                        centreName = dsCentreStatus.Tables[0].Rows[0][1].ToString();

                        if (strStatus != "")		//Checking if registration last date is closed
                        {
                            Session["RegistrationCloseDate"] = strStatus;
                            DateTime dtTempTime = Convert.ToDateTime(Session["RegistrationCloseDate"]);
                            strDate = dtTempTime.Day.ToString() + " " + MonthYear(dtTempTime.Month.ToString()) + " " + dtTempTime.Year.ToString();
                            strEndTime = dtTempTime.ToShortTimeString().ToString().ToLower();
                            tblCandidateErrorMessage.Visible = true;
                            lblCandidateLoginError.Visible = true;
                            lblCandidateLoginError.Text = "Sorry! The last date for " + centreName + " NAC registrations was " + strDate + "(" + strEndTime + ").";
                        }
                        else if (Convert.ToInt32(dsCentreStatus.Tables[1].Rows[0][0].ToString()) > 0)
                        {
                            HttpContext.Current.Session["SerialNo"] = Convert.ToString(dsPIN.Tables[0].Rows[0]["SerialNo"]);
                            HttpContext.Current.Session["PIN"] = Convert.ToString(dsPIN.Tables[0].Rows[0]["PinNo"]);

                            Response.Redirect("Web/Registration.aspx", false);
                        }

                        else
                        {
                            tblCandidateErrorMessage.Visible = true;
                            lblCandidateLoginError.Visible = true;
                            lblCandidateLoginError.Text = "The center, you are trying to register for, is full. Please contact your College TPO to get ID for other center.";
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session["SerialNo"] = null;
                        HttpContext.Current.Session["PIN"] = null;
                        tblCandidateErrorMessage.Visible = true;
                        lblCandidateLoginError.Visible = true;
                        lblCandidateLoginError.Text = "Either UserID or Password has already been utilized";
                    }

                }
                else
                {
                    HttpContext.Current.Session["SerialNo"] = null;
                    HttpContext.Current.Session["PIN"] = null;
                    tblCandidateErrorMessage.Visible = true;
                    lblCandidateLoginError.Visible = true;
                    lblCandidateLoginError.Text = "Invalid userid or password ";

                }
            }

            catch (ThreadAbortException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ErrorLogger.ErrorRoutine(false, ex);
            }

        }

        #endregion Login

        protected void rdList_selectedindexchanged(object sender, EventArgs e)
        {
            ResetControls();

            if (rblUserType.SelectedValue == "NewUser")
            {
                tblNewUser.Visible = true;
                tblRegisteredLogin.Visible = false;            
            }

            else if (rblUserType.SelectedValue == "AlreadyRegistered")
            {
                tblNewUser.Visible = false;
                tblRegisteredLogin.Visible = true;      
            }
        }

        private void ResetControls()
        {
            txtNacRegId.Text = "";
            txtPhotoIdNumber.Text = "";
            txtPassword.Text = "";
            ddlPhotoIdDocument.SelectedIndex = 0;
            txtUserID.Text = "";
            txtUserPassword.Text = "";
            lblCandidateLoginError.Visible = false;
        }

        #region FillPhotoIdDetail
        private void FillPhotoIdDetail()
        {

            BLRegistration objBLRegistration = new BLRegistration();
            BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(), "PhotoIdDocument", "PhotoId");
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

        #region DefaultButton()

        private void DefaultButton(ref TextBox objTextControl, ref Button objDefaultButton)
        {
            StringBuilder sScript = new StringBuilder();
            sScript.Append("<SCRIPT language='javascript'> ");
            sScript.Append("function fnTrapKD(btn){");
            sScript.Append(" if (document.forms[0].all){");
            sScript.Append(" if (event.keyCode == 13)");
            sScript.Append(" { ");
            sScript.Append(" event.returnValue=false;");
            sScript.Append(" event.cancel = true;");
            sScript.Append(" btn.click();");
            sScript.Append(" } ");
            sScript.Append(" } ");
            sScript.Append("}");
            sScript.Append("</SCRIPT>");
            objTextControl.Attributes.Add("onkeydown", "fnTrapKD(document.all." + objDefaultButton.ClientID + ")");

            if (ClientScript.IsStartupScriptRegistered("ForceDefaultToScript"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ForceDefaultToScript", sScript.ToString());
            }

        }

        #endregion

        #region DefaultButtonDDL()

        private void DefaultButtonDDL(ref DropDownList objDDLControl, ref Button objDefaultButton)
        {
            StringBuilder sScript = new StringBuilder();
            sScript.Append("<SCRIPT language='javascript'> ");
            sScript.Append("function fnTrapKDDDL(btn){");
            sScript.Append(" if (document.forms[0].all){");
            sScript.Append(" if (event.keyCode == 13)");
            sScript.Append(" { ");
            sScript.Append(" event.returnValue=false;");
            sScript.Append(" event.cancel = true;");
            sScript.Append(" btn.click();");
            sScript.Append(" } ");
            sScript.Append(" } ");
            sScript.Append("}");
            sScript.Append("</SCRIPT>");
            objDDLControl.Attributes.Add("onkeydown", "fnTrapKDDDL(document.all." + objDefaultButton.ClientID + ")");


            if (ClientScript.IsStartupScriptRegistered("ForceDefaultToScriptDDL"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ForceDefaultToScriptDDL", sScript.ToString());
            }

        }

        #endregion

        private bool ValidateCompanyLoginControls(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[0]["AgreementExpiryDate"]) <= System.DateTime.Today.Date)
                    {
                        tblCompanyLogin.Visible = true;
                        lblCompanyLoginError.Visible = true;
                        lblCompanyLoginError.Text = "Agreement date has been expired.";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    tblCompanyLogin.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "ValidateUserCreditional", "<script>alert('Invalid userid or password')</script>");
                    lblCompanyLoginError.Visible = true;
                    lblCompanyLoginError.Text = "Invalid user ID or password.";
                    return false;
                }
            }
            else
            {
                tblCompanyLogin.Visible = true;
                lblCompanyLoginError.Visible = true;
                lblCompanyLoginError.Text = "Invalid user ID or password.";
                return false;
            }

        }
    }
}