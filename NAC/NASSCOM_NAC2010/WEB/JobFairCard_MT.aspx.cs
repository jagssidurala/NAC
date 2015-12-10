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
	/// Summary description for JobFairCard.
	/// </summary>
	public partial class JobFairCard_MT : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image imgUploadPhotograph;
		protected System.Web.UI.WebControls.Label lblGender1;
		protected System.Web.UI.WebControls.Label lblBlanSpacer;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//Common.CLCommonFunctions.CheckSession();
			if (!Page.IsPostBack)
			{
				//plNoJobFairCard.Visible = false;
				//plJobFairCard.Visible = true;
				GetJobFairCard();
				GenerateJobFairCardCompanyDetails();
				

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

		#region Private Methods

		private void GenerateJobFairCardCompanyDetails()
		{
			string strRegistrationId = Session["UserID"].ToString();
			
			DataRow drNewRow;

			//strRegistrationId="15121";
			DataSet dsJobFairCardCompanyDetails = new DataSet();
			BusinessLayer.BLJobFairCard oBLJobFairCard = new BusinessLayer.BLJobFairCard();
			dsJobFairCardCompanyDetails = oBLJobFairCard.GenerateJobFairCardCompanyDetails(strRegistrationId);
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("SNo");
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("Attended");
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("Signature");
			int SNo=1;
			for(int k=0;k < dsJobFairCardCompanyDetails.Tables[0].Rows.Count;k++)
			{
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["SNo"]=SNo;
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["Attended"]=" ";
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["Signature"]="";
				SNo=SNo+1;
			}				

			if(dsJobFairCardCompanyDetails.Tables[0].Rows.Count>0)
			{
				for(int iCounter=dsJobFairCardCompanyDetails.Tables[0].Rows.Count; iCounter<10; iCounter++)
				{			
					//Initializing srNewRow
					drNewRow = dsJobFairCardCompanyDetails.Tables[0].NewRow();
					//Inserting initial value in "Center" column
					drNewRow["SNo"] = iCounter + 1;
					//Inserting initial value in "CenterId" column
					drNewRow["Attended"] = "";
					drNewRow["Signature"] = "";
					drNewRow["Company Name"] = "";
					drNewRow["FirstDate"] = DateTime.Now;
					drNewRow["SecondDate"] = DateTime.Now;		
					//Adding dtNewRow in dtTestCenter(Datatable)
					dsJobFairCardCompanyDetails.Tables[0].Rows.Add(drNewRow);							

				}
			
				rptCompanyDetail.DataSource=dsJobFairCardCompanyDetails;
				rptCompanyDetail.DataBind();

				plNoJobFairCard.Visible = false;
				plJobFairCard.Visible = true;				
				
			}	
			else
			{
				plNoJobFairCard.Visible = true;
				plJobFairCard.Visible = false;
			}
			
			
		}
		
		private void GetJobFairCard()
		{
			string strPinNo = Session["UserID"].ToString();
			DataSet dsJobAdmitCard = new DataSet();

			try
			{

				BusinessLayer.BLJobAdmitCard oBLJobAdmitCard = new BusinessLayer.BLJobAdmitCard();
				dsJobAdmitCard = oBLJobAdmitCard.GenerateJobAdmitCard_MT(strPinNo);
				if (dsJobAdmitCard.Tables[0].Rows.Count > 0)
				{
					if(Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Mizoram" ||Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Manipur"||Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Assam" || Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Nagaland" ||Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Meghalaya" || Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Sikkim" || Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Tripura" ||Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="Arunachal Pradesh"||Convert.ToString(dsJobAdmitCard.Tables[0].Rows[0]["State"])=="West Bengal")
					{
						TblInterview.Visible=false;
						TblInterview2.Visible=true;
						TrGroup.Visible=false;

						lblRegistrationId.Text = dsJobAdmitCard.Tables[0].Rows[0]["RegistrationId"].ToString();
						lblName.Text = dsJobAdmitCard.Tables[0].Rows[0]["FullName"].ToString();
						lblGender.Text = dsJobAdmitCard.Tables[0].Rows[0]["Gender"].ToString();	
						lblCity.Text = dsJobAdmitCard.Tables[0].Rows[0]["City"].ToString();
						lblState.Text = dsJobAdmitCard.Tables[0].Rows[0]["State"].ToString();
						lblHeighestEducation.Text = dsJobAdmitCard.Tables[0].Rows[0]["Qualification"].ToString();
						lblMedium10.Text = dsJobAdmitCard.Tables[0].Rows[0]["MediumSchool"].ToString();
						lblMedium12.Text = dsJobAdmitCard.Tables[0].Rows[0]["Medium12th"].ToString();
						lblEmploymentStatus.Text = dsJobAdmitCard.Tables[0].Rows[0]["EmploymentStatus"].ToString();
						lblRelocation.Text = dsJobAdmitCard.Tables[0].Rows[0]["Relocate"].ToString();
						lblAnalytical.Text = dsJobAdmitCard.Tables[0].Rows[0]["AQRPercentile"].ToString();
						lblListening.Text = dsJobAdmitCard.Tables[0].Rows[0]["ListeningPercentile"].ToString();
						lblWriting.Text = dsJobAdmitCard.Tables[0].Rows[0]["WritingPercentile"].ToString();
						lblWritingEssay.Text = dsJobAdmitCard.Tables[0].Rows[0]["WritingEssayPercentile"].ToString();
						lblSpeaking.Text = dsJobAdmitCard.Tables[0].Rows[0]["SpeakingPercentile"].ToString();
						lblLearningAbility.Text = dsJobAdmitCard.Tables[0].Rows[0]["LAPercentile"].ToString();
						lblKeyboardSkills.Text = dsJobAdmitCard.Tables[0].Rows[0]["KeyboardPercentile"].ToString();
						lblDate1.Text=  String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsJobAdmitCard.Tables[0].Rows[0]["FristInterviewDate"].ToString()));
						//lblTier.Text = dsJobAdmitCard.Tables[0].Rows[0]["GroupName"].ToString();
						lblInterviewDate.Text = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsJobAdmitCard.Tables[0].Rows[0]["FRISTINTERVIEWDATE"].ToString()));
						if(dsJobAdmitCard.Tables[0].Rows[0]["InterviewTime"]!=System.DBNull.Value)
						{
							lblInterviewTime.Text = String.Format("{0:HH:mm tt}",Convert.ToDateTime(dsJobAdmitCard.Tables[0].Rows[0]["InterviewTime"].ToString()));
						}
						else
						{
							lblInterviewTime.Text="";
						}


						lblVenue.Text = dsJobAdmitCard.Tables[0].Rows[0]["Venue"].ToString();
						plNoJobFairCard.Visible = false;
						plJobFairCard.Visible = true;
					}
					else
					{		
						TblInterview.Visible=true;
						TblInterview2.Visible=false;
						TrGroup.Visible=true;

						lblRegistrationId.Text = dsJobAdmitCard.Tables[0].Rows[0]["RegistrationId"].ToString();
						lblName.Text = dsJobAdmitCard.Tables[0].Rows[0]["FullName"].ToString();
						lblGender.Text = dsJobAdmitCard.Tables[0].Rows[0]["Gender"].ToString();	
						lblCity.Text = dsJobAdmitCard.Tables[0].Rows[0]["City"].ToString();
						lblState.Text = dsJobAdmitCard.Tables[0].Rows[0]["State"].ToString();
						lblHeighestEducation.Text = dsJobAdmitCard.Tables[0].Rows[0]["Qualification"].ToString();
						lblMedium10.Text = dsJobAdmitCard.Tables[0].Rows[0]["MediumSchool"].ToString();
						lblMedium12.Text = dsJobAdmitCard.Tables[0].Rows[0]["Medium12th"].ToString();
						lblEmploymentStatus.Text = dsJobAdmitCard.Tables[0].Rows[0]["EmploymentStatus"].ToString();
						lblRelocation.Text = dsJobAdmitCard.Tables[0].Rows[0]["Relocate"].ToString();
						lblAnalytical.Text = dsJobAdmitCard.Tables[0].Rows[0]["AQRPercentile"].ToString();
						lblListening.Text = dsJobAdmitCard.Tables[0].Rows[0]["ListeningPercentile"].ToString();
						lblWriting.Text = dsJobAdmitCard.Tables[0].Rows[0]["WritingPercentile"].ToString();
						lblSpeaking.Text = dsJobAdmitCard.Tables[0].Rows[0]["SpeakingPercentile"].ToString();
						lblLearningAbility.Text = dsJobAdmitCard.Tables[0].Rows[0]["LAPercentile"].ToString();
						lblKeyboardSkills.Text = dsJobAdmitCard.Tables[0].Rows[0]["KeyboardPercentile"].ToString();
						lblDate1.Text=  String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsJobAdmitCard.Tables[0].Rows[0]["FristInterviewDate"].ToString()));
						lblTier.Text = dsJobAdmitCard.Tables[0].Rows[0]["GroupName"].ToString();
//						lblInterviewDate.Text = dsJobAdmitCard.Tables[0].Rows[0]["FRISTINTERVIEWDATE"].ToString();
//						lblInterviewTime.Text = dsJobAdmitCard.Tables[0].Rows[0]["InterviewTime"].ToString();
//						lblVenue.Text = dsJobAdmitCard.Tables[0].Rows[0]["Venue"].ToString();
						plNoJobFairCard.Visible = false;
						plJobFairCard.Visible = true;
					}
				}
				else
				{
					plNoJobFairCard.Visible = true;
					plJobFairCard.Visible = false;
				}
					

				
			}
			catch (Exception ex)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(ex);
			}

		}
		#endregion
		 
		private void SaveAsJobFairCardPDF(string strPinNo)
		{
			bool bFileExist = false;
			int intTimeout = 0;	
			string strFileName = null;
			strFileName = "JobFairCard_" + strPinNo + ".pdf";
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

	 
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if(Session["UserID"] != null)
			{
				string strPinNo = Session["UserID"].ToString();
				BusinessLayer.BLGenerateJobFairCardPDF objGenerateJobFairCardPDF = new BusinessLayer.BLGenerateJobFairCardPDF();
				objGenerateJobFairCardPDF.GenerateJobFairCardPDF_MT(strPinNo);			 
				SaveAsJobFairCardPDF(strPinNo);
			}
		}	

	}
}
