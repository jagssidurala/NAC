using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Threading;
using System.Web.UI.HtmlControls;



namespace NASSCOM_NAC.Web
{
    public partial class RegisteredLogin : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    if (Session["HomeURL"] == null)
                    {
                        Session["HomeURL"] = Request.UrlReferrer.ToString();
                    }

                    FillPhotoIdDetail();
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }
            }

            btnLogin.Attributes.Add("onclick", "return ValidateLogin();");
            DefaultButton(ref this.txtPhotoIdNumber, ref this.btnLogin);
            DefaultButton(ref this.txtPassword, ref this.btnLogin);
            DefaultButtonDDL(ref this.ddlPhotoIdDocument, ref this.btnLogin);

        }


        #region btnLogin_Click
        protected void btnLogin_Click(object sender, System.EventArgs e)
        {

            String strPhotoId = ddlPhotoIdDocument.SelectedValue.ToString().Trim();
            String strDocumentNo = txtPhotoIdNumber.Text.ToString().Trim();
            String strPassword = txtPassword.Text.ToString().Trim();
            String strNACRegID = txtNacId.Text.ToString().Trim();

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

                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    HttpContext.Current.Session["UsreID"] = null;
                    HttpContext.Current.Session["UserName"] = null;
                    HttpContext.Current.Session["UserType"] = null;
                    lblLoginMessage.Text = "Login credentials are not correct.";
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

        #endregion

        #region DefaultButton()

        private void DefaultButton(ref TextBox objTextControl, ref Button objDefaultButton)
        {
            StringBuilder sScript = new StringBuilder();
            sScript.Append("<SCRIPT language='javascript'> ");
            sScript.Append("function fnTrapKD(btn){");
            sScript.Append(" if (document.all){");
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

            if (!Page.IsStartupScriptRegistered("ForceDefaultToScript"))
            {
                Page.RegisterStartupScript("ForceDefaultToScript", sScript.ToString());
            }
        }

        #endregion

        #region DefaultButtonDDL()

        private void DefaultButtonDDL(ref DropDownList objDDLControl, ref Button objDefaultButton)
        {
            StringBuilder sScript = new StringBuilder();
            sScript.Append("<SCRIPT language='javascript'> ");
            sScript.Append("function fnTrapKDDDL(btn){");
            sScript.Append(" if (document.all){");
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

            if (!Page.IsStartupScriptRegistered("ForceDefaultToScriptDDL"))
            {
                Page.RegisterStartupScript("ForceDefaultToScriptDDL", sScript.ToString());
            }
        }

        #endregion

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

    }
}