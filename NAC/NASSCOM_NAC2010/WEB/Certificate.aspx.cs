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
	/// Summary description for Certificate.
	/// </summary>
	public partial class Certificate : System.Web.UI.Page
	{
		public string RegistrationId;
		 
		protected void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				RegistrationId = Session["UserID"].ToString();
				if (!Page.IsPostBack)
				{					
					plScoreCardDetail.Visible = true;
					plNoScoreCard.Visible = false;
					GetScoreCardData();
				}
			}
			catch (Exception Ex)
			{
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(Ex);
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

//		private void getScoreCard()
//		{
//			String strRegistrationId = (String)Session["RegistrationId"];
//			if (strRegistrationId == null)
//				strRegistrationId = "0000000000";
//
//			lblState.Text = "Gujarat";
//			lblRegistrationId.Text = strRegistrationId;
//			lblName.Text = "Test Candidate";
//            lblDob.Text = "30 Oct, 1980";
//			lblTestCentre.Text = "Ahemdabad";
//			lblTestDate.Text = "30 Apr, 2007";
//
//			lblSpeaking.Text = "91";
//			lblWriting.Text = "81";
//			lblListening.Text = "84";
//			lblAnalystical.Text = "84";
//		}

		private void GetScoreCardData()
		{
			DataSet dsScoreCard = new DataSet();
			 
			
			
			try
			{		
				
				BusinessLayer.BLScoreCard oBLScoreCard = new BLScoreCard();
				dsScoreCard = oBLScoreCard.GenerateScoreCard(RegistrationId);

				if(dsScoreCard.Tables[0].Rows.Count > 0)
				{
					lblRegistrationId.Text=dsScoreCard.Tables[0].Rows[0][0].ToString().Trim();
					lblName.Text=dsScoreCard.Tables[0].Rows[0][1].ToString().Trim();				
					string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsScoreCard.Tables[0].Rows[0][2].ToString()));
					lblDob.Text=strDOB;
					lblState.Text="State of" + ' ' + dsScoreCard.Tables[0].Rows[0][4].ToString().Trim();
					lblTestCentre.Text = dsScoreCard.Tables[0].Rows[0][3].ToString().Trim();
					string strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsScoreCard.Tables[0].Rows[0][5].ToString()));
					lblTestDate.Text = strTestDate;

					if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][6]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][7]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][8]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][9]) == 0)
					{						 

//						lblSpeaking.Style.Add("font-weight","normal");
//						lblListening.Style.Add("font-weight","normal");
//						lblWriting.Style.Add("font-weight","normal");
//						lblAnalytical.Style.Add("font-weight","normal");

						lblSpeaking.Style.Add("FONT-SIZE","9px");
						lblListening.Style.Add("FONT-SIZE","9px");
						lblWriting.Style.Add("FONT-SIZE","9px");
						lblAnalytical.Style.Add("FONT-SIZE","9px");
 

						lblSpeaking.Text = "Did not appear";
						lblListening.Text = "Did not appear";
						lblWriting.Text = "Did not appear";
						lblAnalytical.Text = "Did not appear";
					}
					else
					{
						if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][6]) == 0)
						{
							lblSpeaking.Style.Add("FONT-SIZE","9px");
							lblSpeaking.Text = "N/A";
						}
						else
						{
							lblSpeaking.Text=dsScoreCard.Tables[0].Rows[0][6].ToString().Trim();
						}

						if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][7]) == 0)
						{
							lblListening.Style.Add("FONT-SIZE","9px");
							lblListening.Text = "N/A";
						}
						else
						{
							lblListening.Text=dsScoreCard.Tables[0].Rows[0][7].ToString().Trim();
						}

						if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][8]) == 0)
						{
							lblWriting.Style.Add("FONT-SIZE","9px");
							lblWriting.Text = "N/A";
						}
						else
						{
							lblWriting.Text=dsScoreCard.Tables[0].Rows[0][8].ToString().Trim();
						}

						if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][9]) == 0)
						{
							lblAnalytical.Style.Add("FONT-SIZE","9px");
							lblAnalytical.Text = "N/A";
						}
						else
						{
							lblAnalytical.Text=dsScoreCard.Tables[0].Rows[0][9].ToString().Trim();
						}
					}
					Response.Redirect("TestScoreMessage.aspx");
					//plScoreCardDetail.Visible = true;
					//plNoScoreCard.Visible = false;
				}
				else
				{
					plScoreCardDetail.Visible = false;
					plNoScoreCard.Visible = true;
				}

				

			}
			catch (Exception SysEx)
			{
				
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
				
			}
			finally
			{

			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			//if(Session["UserID"] != null)
			if(RegistrationId!= null)
			{
				BusinessLayer.BLGenerateScoreCardPDF objBLGenerateScoreCardPDF = new BLGenerateScoreCardPDF();
				bool typeflag; 
				typeflag=objBLGenerateScoreCardPDF.GenerateScoreCardPDF(RegistrationId);				 
				SaveAsPDF();
			}
		}
		private void SaveAsPDF()
		{
			bool bFileExist = false;
			int intTimeout = 0;	
			string strFileName = null;
			strFileName = "ScoreCard_" + RegistrationId + ".pdf";
			string FilePath = MapPath("")+ "\\TempWorkAreaPdf\\" + strFileName;
			
				
			while ( bFileExist == false )
			{
				if (File.Exists(FilePath))
				{
					bFileExist = true;
				}					 
				Thread.Sleep(1000);					
				intTimeout++;
				if ( intTimeout == 10 )
					break;
			}

			if (bFileExist == true)
			{
				try
				{
					Response.Clear();
					Response.ClearHeaders();
					Response.ContentType="application/pdf";					  
					Response.AddHeader("content-disposition", "attachment; filename="+ strFileName);				 
					Response.WriteFile(FilePath);	
					Response.Flush();
					Response.Close();
					ClearTempFiles(FilePath);
				}
				catch(Exception ex)
				{
					Response.ClearContent();
					throw(ex);
				}
					
					 
                    
			}	 
		}

		/// <summary>
		/// This method will be used to clear up all the temporary file created in the process.
		/// from TempWorkArea and TempworkAreaPdf folder.
		/// </summary>
		private void ClearTempFiles(string FilePath)
		{
			 
			// TempWorkAreaPdf is a folder where HTML and PDf file will be created
			
			if (File.Exists(FilePath))
			{
				try
				{
					File.Delete(FilePath);
					FilePath = FilePath.Replace(".pdf", ".html");
					File.Delete(FilePath);					 
				}
				catch (Exception ex)
				{
					throw (ex);
               
				}				 
        
			}


		}
	
	
	}
}
