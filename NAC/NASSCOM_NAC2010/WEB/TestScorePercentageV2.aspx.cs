using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;
using BusinessLayer;
using Common;



namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for TestScorePercentageV2.
	/// </summary>
	public partial class TestScorePercentageV2 : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay1;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay2;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay3;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay4;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay5;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay6;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay7;
		protected System.Web.UI.HtmlControls.HtmlTableRow Essay8;
		protected System.Web.UI.WebControls.Label lblAnalyticalRangeCar;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblAnalyticalRemarksOverall;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Label7;
		protected System.Web.UI.WebControls.Label lblPg2AnalyticalRangeCard;
		public string strDivStyle;
		public DataRow dr;
        public  string strNACRegID;

		protected void Page_Load(object sender, System.EventArgs e)
		{

            strNACRegID = Session["UserID"].ToString();
            String strRegistrationId = (String)Session["RegistrationId"];           
            if (Session["UserID"] == null || Convert.ToString(Session["UserID"]) == "")
                Response.Redirect("../Default.aspx");

			if (!Page.IsPostBack)
			{				
                try 
                {
                    lblRegistrationId.Text = strNACRegID;                        
                    BusinessLayer.BLNACScoreCard oBLNACScoreCard = new BLNACScoreCard();
                    if (oBLNACScoreCard.IsScoreExits(strRegistrationId) > 0)
                        RedirectToPDFScoreCard();
                    else
                        Response.Redirect("TestScoreMessage.aspx");
                }

                catch (System.Threading.ThreadAbortException lException)
                {
                    //do nothing
                }

                catch (Exception SysEx)
                {
                    ErrorLogger.ErrorRoutine(false, SysEx);
                    //To Pass Execption in exception class for show exception
                    ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
                }              
 
		
			}
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


        public void RedirectToPDFScoreCard()
        {
            string url = Convert.ToString(ConfigurationSettings.AppSettings["ScoreCardURL"]) + "?req=" + strNACRegID;
            string fileName = " - ";
            //string wkhtmlDir = "D:\\NASSCOM\\NAC_TECH\\Nasscom_NAC_Tech\\WEB\\TempWorkAreaPdf";
            string wkhtmlDir = Server.MapPath("~/Web/TempWorkAreaPdf");
            //string wkhtml = "D:\\NASSCOM\\NAC_TECH\\Nasscom_NAC_Tech\\bin\\wkhtmltopdf.exe";
            string wkhtml = Server.MapPath("~/bin/wkhtmltopdf.exe");
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = wkhtml;
            p.StartInfo.WorkingDirectory = wkhtmlDir;

            string switches = "";
            switches += "--print-media-type ";
            switches += "--images ";
            switches += "--quiet ";
            switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
            switches += "--disable-smart-shrinking ";
            switches += "--dpi 112 ";
            switches += "--page-width 220 --page-height 310";
            p.StartInfo.Arguments = switches + " " + url + " " + fileName;
            p.Start();

            //read output
            byte[] buffer = new byte[32768];
            byte[] file;
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);

                    if (read <= 0)
                    {
                        break;
                    }
                    ms.Write(buffer, 0, read);
                }
                file = ms.ToArray();
            }

            // wait or exit
            p.WaitForExit(60000);

            // read the exit code, close process
            int returnCode = p.ExitCode;
            p.Close();

            //return returnCode == 0 ? file : null;

            if (file != null)
            {
                Response.ClearContent();
                Response.ClearHeaders();
                //Response.ContentType = "Application/pdf";
                HttpContext.Current.Response.ContentType = "application/pdf";


                Response.BinaryWrite(file);
                Response.End();
            }
        }        
      	



	}
}