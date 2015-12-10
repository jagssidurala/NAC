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
using System.Text;
using BusinessLayer;
using System.Threading;
using System.Runtime;

namespace NASSCOM_NAC.Web
{
    /// <summary>
    /// Summary description for AlreadyRegistered.
    /// </summary>
   public partial class AlreadyRegistered : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
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

    protected void btnLogin_Click(object sender, System.EventArgs e)
    {
        String strPhotoId = ddlPhotoIdDocument.SelectedValue.ToString().Trim();
        String strDocumentNo = txtPhotoIdNumber.Text.ToString().Trim();
        String strPassword = txtPassword.Text.ToString().Trim();

        try
        {
            BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
            //DataSet ds = chkUser.ValidateUserCredential(strPhotoId,strDocumentNo,strPassword);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    HttpContext.Current.Session["UserID"] = ds.Tables[0].Rows[0]["UserName"].ToString();
            //    HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["FName"].ToString();
            //    HttpContext.Current.Session["UserType"] = Convert.ToInt32(ds.Tables[0].Rows[0]["UserType"].ToString());
            //    HttpContext.Current.Session["StateId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["TestState"].ToString());
            //    HttpContext.Current.Session["StateName"] = ds.Tables[0].Rows[0]["State"].ToString();
            //    HttpContext.Current.Session["RegistrationDate"] = ds.Tables[0].Rows[0]["DateOfRegistration"].ToString();
            //    HttpContext.Current.Session["TestName"] = ds.Tables[0].Rows[0]["TestName"].ToString();
            //    HttpContext.Current.Session["JobLogin"] = ds.Tables[0].Rows[0]["JobLogin"].ToString();
            //    HttpContext.Current.Session["JobLoginPassword"] = ds.Tables[0].Rows[0]["JobLoginPassword"].ToString();
            //    HttpContext.Current.Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();

            //    Response.Redirect("Welcome.aspx");
            //}
            //else
            //{
            //    HttpContext.Current.Session["UsreID"] = null;
            //    HttpContext.Current.Session["UserName"] = null;
            //    HttpContext.Current.Session["UserType"] = null;
            //    lblLoginMessage.Text = "Login credentials are not correct.";
            //}
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

    private void FillPhotoIdDetail()
    {
        BLRegistration objBLRegistration = new BLRegistration();
        BindDropDown(ref ddlPhotoIdDocument, objBLRegistration.FillPhotoIdDetail(), "PhotoIdDocument", "PhotoId");
    }
    private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
    {

        ddlDropDownList.DataSource = dtDataTable;
        ddlDropDownList.DataTextField = strTextField;
        ddlDropDownList.DataValueField = strValueField;
        ddlDropDownList.DataBind();

    }
   }
}
