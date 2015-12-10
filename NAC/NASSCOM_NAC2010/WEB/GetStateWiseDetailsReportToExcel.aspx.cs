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
    public partial class GetStateWiseDetailsReportToExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserType"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                if (Request.QueryString["SearchType"] != null)
                {
                    if (Request.QueryString["SearchType"] == "full")
                    {
                        BLGetStateWiseDetails objBLGetStateWiseDetails = new BLGetStateWiseDetails();
                        DataTable dtCandidateDetails = new DataTable();
                        DataSet dsCandidateDetails = new DataSet();
                        string dtTestDateFrom = string.Empty;
                        string dtTestDateTo = string.Empty;
                        int intTestState = 0;
                        if (Session["dtTestDateFrom"] != null)
                        {
                            dtTestDateFrom = Session["dtTestDateFrom"].ToString();
                        }

                        if (Session["dtTestDateTo"] != null)
                        {
                            dtTestDateTo = Session["dtTestDateTo"].ToString();
                        }
                        if (Session["intTestState"] != null)
                        {
                            intTestState = Convert.ToInt32(Session["intTestState"].ToString());
                        }
                        dsCandidateDetails = objBLGetStateWiseDetails.GetStateWiseCandidateDetails(dtTestDateFrom, dtTestDateTo, intTestState);
                        dtCandidateDetails = dsCandidateDetails.Tables[0];
                        dgCandidateList.DataSource = dtCandidateDetails;
                        dgCandidateList.DataBind();

                      //  Response.Clear();
                       
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("content-disposition", "attachment;filename=StateWiseDetailsReport.xls");
                        System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter htmlTextWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
                        this.RenderControl(htmlTextWriter);
                        Response.Write(stringWriter.ToString());
                        Response.OutputStream.Write(new byte[] { 0xef, 0xbb, 0xbf }, 0, 3); 
                        Response.Flush();
                        HttpContext.Current.Response.Clear();
                       
                    }
                }
            }
            catch (Exception SysEx)
            {
                ErrorLogger.ErrorRoutine(false, SysEx);
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
            }

        }
    }
}