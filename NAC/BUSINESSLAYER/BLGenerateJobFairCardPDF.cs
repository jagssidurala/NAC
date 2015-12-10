using System; 
using System.Collections;
using System.Text;
using System.Data; 
using DataAccessLayer;
using DataBaseAccessLayer;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using Common;
using System.Data.SqlClient;
using ExceptionHandling;
using System.IO;
using System.Drawing.Design;
using System.Drawing.Imaging;

using sharpPDF.PDFControls;
using System.Threading;
using System.Configuration;

using System.Collections.Specialized;
namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLGenerateJobFairCardPDF.
	/// </summary>
	public class BLGenerateJobFairCardPDF: System.Web.UI.Page
	{
		private string strRegistrationId;
		private string strName ;
		private string strStateName;
		private string strGender; 
		private string strCity; 
		private string strQualification;
		private string strMediumSchool;
		private string strMedium12th;
		private string strEmployeeStatus;
		private string strRelocate; 
		private string strAnalytical; 
		private string strListening;																																	 
		private string strWriting;
		private string strWritingEssay;
		private string strSpeaking;
		private string strGroupTier;
		private string strLearning;
		private string strKeyboard;
		//private string strDate;
		private string strTime;
		private string strVenue;

		public BLGenerateJobFairCardPDF()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public bool GenerateJobFairCardPDF(string strPINNo)
		{
			bool flag=true;
			sharpPDF.Fonts.pdfFontDefinition objMertic = new sharpPDF.Fonts.pdfFontDefinition();
			objMertic.familyName = "Verdana, Arial, Helvetica, sans-serif";
			objMertic.fontWeight = "bold";
			objMertic.fontHeight = 11;	
			string strInterviewFirstInterviewDate = "15 Dec 2007";
			//string strInterviewSecondInterviewDate = "16 Dec 2007";
			BusinessLayer.BLJobAdmitCard oBLJobAdmitCard = new BusinessLayer.BLJobAdmitCard();
			//dsJobFairCard = oBLJobAdmitCard.GenerateJobAdmitCard(strPinNo);

			DataSet dsJobFairCard = oBLJobAdmitCard.GenerateJobAdmitCard(strPINNo);
			DataSet dsJobFairCardCompanyDetails=GenerateJobFairCardCompanyDetails();		
            

			if (dsJobFairCard.Tables[0].Rows.Count > 0)
			{
				strRegistrationId = dsJobFairCard.Tables[0].Rows[0]["RegistrationId"].ToString();
				strName = dsJobFairCard.Tables[0].Rows[0]["FullName"].ToString();
				strGender = dsJobFairCard.Tables[0].Rows[0]["Gender"].ToString();	
				strStateName = dsJobFairCard.Tables[0].Rows[0]["State"].ToString() + " " + "NAC";
				strCity = dsJobFairCard.Tables[0].Rows[0]["City"].ToString();
				strQualification = dsJobFairCard.Tables[0].Rows[0]["Qualification"].ToString();
				strMediumSchool = dsJobFairCard.Tables[0].Rows[0]["MediumSchool"].ToString();
				strMedium12th = dsJobFairCard.Tables[0].Rows[0]["Medium12th"].ToString();
				strEmployeeStatus = dsJobFairCard.Tables[0].Rows[0]["EmploymentStatus"].ToString();
				strRelocate = dsJobFairCard.Tables[0].Rows[0]["Relocate"].ToString();
				strAnalytical = dsJobFairCard.Tables[0].Rows[0]["Analytical"].ToString();
				strListening = dsJobFairCard.Tables[0].Rows[0]["Listening"].ToString();
				strWriting = dsJobFairCard.Tables[0].Rows[0]["Writing"].ToString();
				strSpeaking = dsJobFairCard.Tables[0].Rows[0]["Speaking"].ToString();
				strInterviewFirstInterviewDate = dsJobFairCard.Tables[0].Rows[0]["FristInterviewDate"].ToString();
				strGroupTier = dsJobFairCard.Tables[0].Rows[0]["GroupName"].ToString();				
				strTime = dsJobFairCard.Tables[0].Rows[0]["InterviewTime"].ToString();
				strVenue = dsJobFairCard.Tables[0].Rows[0]["Venue"].ToString();
					

			}
			sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_JobFair_Card","NASSCOM");
			sharpPDF.pdfPage myPage = myDoc.addPage();
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");					

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
			myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);    

			//myPage.drawLine(70,697,555,697,sharpPDF.pdfColor.LightGray,125);
			
			myPage.drawLine(70,760,70,30,sharpPDF.pdfColor.Gray,1);			
			myPage.drawLine(555,760,555,30,sharpPDF.pdfColor.Gray,1);
			myPage.drawLine(70,760,555,760,sharpPDF.pdfColor.Gray,1);
			myPage.drawLine(70,30,555,30,sharpPDF.pdfColor.Gray,1);

			
			 
			myPage.addText(strStateName, 240, 740, myDoc.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			myPage.addText("Job Fair Admission Card", 230, 723, myDoc.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			
			myPage.drawLine(230,721,430,721,sharpPDF.pdfColor.DarkBlue,1);
			
			myPage.addText("1. Please carry this sheet to all company interviews for admission, attendance and company", 85, 700, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    signature. DO NOT hand it over to any company", 85, 689, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("2. After attending all the assigned interviews, you are free to attend other company interview", 85, 678, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    depending on time availability/company permission. For this, you must proceed to the NAC ",85, 667, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    Waiting Area for the respective companies after you are done with your assigned interview.",85, 656, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("3. PLEASE HAND OVER THIS SHEET AT THE GATE BEFORE YOU LEAVE THE COLLEGE PREMISES.", 85, 645, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);

			
			if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Gujarat")

			{
				myPage.drawLine(70,625,555,625,sharpPDF.pdfColor.Gray,1);
				myPage.addText( "INTERVIEW SCHEDULE" , 400, 606,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText( "Date :" , 400, 590,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText(String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(strInterviewFirstInterviewDate)), 435, 590,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText( "Time :" , 400, 575,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				if(dsJobFairCard.Tables[0].Rows[0]["InterviewTime"]!=System.DBNull.Value)
				{
					myPage.addText( String.Format("{0:HH:mm tt}",Convert.ToDateTime(strTime)), 435, 575,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				}		
				
				myPage.addText( "Venue :" , 400, 560,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				if(strVenue.Length >25)
				{
					if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Gujarat")
					{
						myPage.addText( strVenue.Substring(0,22), 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(22,13), 435, 545,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(35,strVenue.Length-35), 435, 530,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
					}					
				}
				else
				{
					myPage.addText( strVenue, 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

				}
			}
			else
			{
				myPage.drawLine(70,635,555,635,sharpPDF.pdfColor.Gray,1);
				myPage.addText( "GROUP" , 94, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( strGroupTier , 255, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( "INTERVIEW DATE" , 410, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText(String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(strInterviewFirstInterviewDate)), 420, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			}
			
			
		

			
		

			myPage.addText( "Reg. ID:" , 94, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strRegistrationId , 255, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
		
			myPage.addText( "Name:" , 94, 591,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strName , 255, 591,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			
			
			myPage.addText( "Gender:" , 94, 576,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
		
			myPage.addText( strGender , 255, 576,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "City:" , 94, 561,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strCity , 255, 561,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Highest Education:" , 94, 546,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strQualification , 255, 546,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Medium of Instrucation (upto 10th):" , 94, 531,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strMediumSchool , 255, 531,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Medium of Instrucation (upto 12th):" , 94, 516,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strMedium12th , 255, 516,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Employement Status:" , 94, 501,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strEmployeeStatus , 255, 501,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "Willing to relocate:" , 94, 486,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strRelocate , 255, 486,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "NAC SCORES (in Percentile)" , 94, 464,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "Analytical & Quantitative:" , 94, 444,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strAnalytical , 255, 444,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Listening:" , 94, 429,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strListening , 255, 429,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "Writing:" , 94, 414,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strWriting , 255, 414,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Speaking:" , 94, 399,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strSpeaking , 255, 399,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			 
		 
			myPage.drawLine(70,385,555,385,sharpPDF.pdfColor.Gray,1);

			//Vertical line after S.No.
			myPage.drawLine(120,385,120,30,sharpPDF.pdfColor.LightGray,1);
			//Vertical line after Name of the company
			myPage.drawLine(261,385,261,30,sharpPDF.pdfColor.LightGray,1);
			//Vertical line after Attended(Yes/No)
			myPage.drawLine(396,385,396,30,sharpPDF.pdfColor.LightGray,1);
			 

			myPage.addText( "S.No." , 88, 365,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Name of the company" , 124, 365,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Attended (Y/N)" , 265, 365,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Signature of Company personnel" , 400, 365,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.drawLine(70,355,555,355,sharpPDF.pdfColor.Gray,1);

			int iCounter=0;			
			foreach (DataRow dr in dsJobFairCardCompanyDetails.Tables[0].Rows)
			{
				iCounter=iCounter+1;
				myPage.addText( iCounter.ToString()+"."  , 94, 370-(30*iCounter),myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( dr["Company Name"].ToString()   , 124, 370-(30*iCounter),myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				
				//Dynamic horizontal line
				myPage.drawLine(70,360-(30*iCounter),555,360-(30*iCounter),sharpPDF.pdfColor.LightGray,1);				
			}			
			
			
			myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "JobFairCard_" + strPINNo + ".pdf");
			
			myPage = null;
			myDoc = null; 
			return flag;


			
		}

		public bool GenerateJobFairCardPDF_MT(string strPINNo)
		{
			bool flag=true;
			sharpPDF.Fonts.pdfFontDefinition objMertic = new sharpPDF.Fonts.pdfFontDefinition();
			objMertic.familyName = "Verdana, Arial, Helvetica, sans-serif";
			objMertic.fontWeight = "bold";
			objMertic.fontHeight = 11;	
			string strInterviewFirstInterviewDate = "15 Dec 2007";
			//string strInterviewSecondInterviewDate = "16 Dec 2007";
			BusinessLayer.BLJobAdmitCard oBLJobAdmitCard = new BusinessLayer.BLJobAdmitCard();
			//dsJobFairCard = oBLJobAdmitCard.GenerateJobAdmitCard(strPinNo);

			DataSet dsJobFairCard = oBLJobAdmitCard.GenerateJobAdmitCard_MT(strPINNo);
			DataSet dsJobFairCardCompanyDetails=GenerateJobFairCardCompanyDetails();
	
			//			//To store values in variables  A32CY79BF4
			
			
            

			if (dsJobFairCard.Tables[0].Rows.Count > 0)
			{
				strRegistrationId = dsJobFairCard.Tables[0].Rows[0]["RegistrationId"].ToString();
				strName = dsJobFairCard.Tables[0].Rows[0]["FullName"].ToString();
				strGender = dsJobFairCard.Tables[0].Rows[0]["Gender"].ToString();	
				strStateName = dsJobFairCard.Tables[0].Rows[0]["State"].ToString() + " " + "NAC";
				strCity = dsJobFairCard.Tables[0].Rows[0]["City"].ToString();
				strQualification = dsJobFairCard.Tables[0].Rows[0]["Qualification"].ToString();
				strMediumSchool = dsJobFairCard.Tables[0].Rows[0]["MediumSchool"].ToString();
				strMedium12th = dsJobFairCard.Tables[0].Rows[0]["Medium12th"].ToString();
				strEmployeeStatus = dsJobFairCard.Tables[0].Rows[0]["EmploymentStatus"].ToString();
				strRelocate = dsJobFairCard.Tables[0].Rows[0]["Relocate"].ToString();
				strAnalytical = dsJobFairCard.Tables[0].Rows[0]["AQRPercentile"].ToString();
				strListening = dsJobFairCard.Tables[0].Rows[0]["ListeningPercentile"].ToString();
				strWriting = dsJobFairCard.Tables[0].Rows[0]["WritingPercentile"].ToString();
				strWritingEssay = dsJobFairCard.Tables[0].Rows[0]["WritingEssayPercentile"].ToString();				
				strSpeaking = dsJobFairCard.Tables[0].Rows[0]["SpeakingPercentile"].ToString();				
				strLearning = dsJobFairCard.Tables[0].Rows[0]["LAPercentile"].ToString();	
				strKeyboard = dsJobFairCard.Tables[0].Rows[0]["KeyboardPercentile"].ToString();
				strInterviewFirstInterviewDate = dsJobFairCard.Tables[0].Rows[0]["FristInterviewDate"].ToString();				
				strGroupTier = dsJobFairCard.Tables[0].Rows[0]["GroupName"].ToString();	
				strTime = dsJobFairCard.Tables[0].Rows[0]["InterviewTime"].ToString();
				strVenue = dsJobFairCard.Tables[0].Rows[0]["Venue"].ToString();
					

			}
			sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_JobFair_Card","NASSCOM");
			sharpPDF.pdfPage myPage = myDoc.addPage();
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");					

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
			myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);    

			//myPage.drawLine(70,697,555,697,sharpPDF.pdfColor.LightGray,125);
			
			myPage.drawLine(70,760,70,30,sharpPDF.pdfColor.Gray,1);			
			myPage.drawLine(555,760,555,30,sharpPDF.pdfColor.Gray,1);
			myPage.drawLine(70,760,555,760,sharpPDF.pdfColor.Gray,1);
			myPage.drawLine(70,30,555,30,sharpPDF.pdfColor.Gray,1);

			
			 
			myPage.addText(strStateName, 240, 740, myDoc.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			myPage.addText("Job Fair Admission Card", 230, 723, myDoc.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			
			myPage.drawLine(230,721,430,721,sharpPDF.pdfColor.DarkBlue,1);
			
			myPage.addText("1. Please carry this sheet to all company interviews for admission, attendance and company", 85, 700, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    signature. DO NOT hand it over to any company", 85, 689, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			//myPage.drawLine(245,687,415,687,sharpPDF.pdfColor.LightGray,1);
			myPage.addText("2. After attending all the assigned interviews, you are free to attend other company interview", 85, 678, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    depending on time availability/company permission. For this, you must proceed to the NAC ",85, 667, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("    Waiting Area for the respective companies after you are done with your assigned interview.",85, 656, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			myPage.addText("3. PLEASE HAND OVER THIS SHEET AT THE GATE BEFORE YOU LEAVE THE COLLEGE PREMISES.", 85, 645, myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);

			//myPage.drawLine(78,622,390,622,sharpPDF.pdfColor.LightGray,15);

			//myPage.drawLine(405,622,520,622,sharpPDF.pdfColor.LightGray,15);
			if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Mizoram" ||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Manipur"||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Assam" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Nagaland" ||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Meghalaya" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Sikkim" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Tripura" ||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Arunachal Pradesh"||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="West Bengal")

			{
				myPage.drawLine(70,625,555,625,sharpPDF.pdfColor.Gray,1);
//				myPage.addText( "GROUP" , 94, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
//				myPage.addText( strGroupTier , 255, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( "INTERVIEW SCHEDULE" , 400, 606,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText( "Date :" , 400, 590,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText(String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(strInterviewFirstInterviewDate)), 435, 590,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText( "Time :" , 400, 575,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				if(dsJobFairCard.Tables[0].Rows[0]["InterviewTime"]!=System.DBNull.Value)
				{
					myPage.addText( String.Format("{0:HH:mm tt}",Convert.ToDateTime(strTime)), 435, 575,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				}		
				
				myPage.addText( "Venue :" , 400, 560,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				if(strVenue.Length >25)
				{
					if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Mizoram" ||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Manipur")
					{
						myPage.addText( strVenue.Substring(0,22), 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(22,16), 435, 545,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(39,strVenue.Length-39), 435, 530,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
					}
					else if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Assam" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Nagaland" ||Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Meghalaya" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Sikkim" || Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Arunachal Pradesh")
					{
						myPage.addText( strVenue.Substring(0,18), 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(18,20), 435, 545,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(39,strVenue.Length-39), 435, 530,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
					}
					else if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="Tripura")
					{
						myPage.addText( strVenue.Substring(0,21), 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(21,17), 435, 545,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(38,strVenue.Length-38), 435, 530,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
					}
					else if(Convert.ToString(dsJobFairCard.Tables[0].Rows[0]["State"])=="West Bengal")
					{
						myPage.addText( strVenue.Substring(0,22), 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(22,22), 435, 545,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(44,28), 435, 530,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
						myPage.addText( strVenue.Substring(72,strVenue.Length-72), 435, 515,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
					}
				}
				else
				{
					myPage.addText( strVenue, 435, 560,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

				}
			}
			else
			{
				myPage.drawLine(70,635,555,635,sharpPDF.pdfColor.Gray,1);
				myPage.addText( "GROUP" , 94, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( strGroupTier , 255, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( "INTERVIEW DATE" , 410, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);

				myPage.addText(String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(strInterviewFirstInterviewDate)), 420, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			}

			
			//myPage.drawLine(70,635,555,635,sharpPDF.pdfColor.Gray,1);

			

//			myPage.addText( "GROUP" , 94, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
//			myPage.addText( strGroupTier , 255, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
//			myPage.addText( "INTERVIEW DATE" , 410, 620,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
//
//			myPage.addText(String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(strInterviewFirstInterviewDate)), 420, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			//myPage.drawRectangle(412,610,417,605,sharpPDF.pdfColor.DarkBlue,sharpPDF.pdfColor.White,1); 
			//myPage.addText( strInterviewSecondInterviewDate , 420, 591,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			//myPage.drawRectangle(412,595,417,590,sharpPDF.pdfColor.DarkBlue,sharpPDF.pdfColor.White,1); 

			myPage.addText( "Reg. ID:" , 94, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strRegistrationId , 255, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
		
			myPage.addText( "Name:" , 94, 591,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strName , 255, 591,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			
			
			myPage.addText( "Gender:" , 94, 576,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
		
			myPage.addText( strGender , 255, 576,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "City:" , 94, 561,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strCity , 255, 561,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Highest Education:" , 94, 546,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strQualification , 255, 546,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Medium of Instrucation (upto 10th):" , 94, 531,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strMediumSchool , 255, 531,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Medium of Instrucation (upto 12th):" , 94, 516,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strMedium12th , 255, 516,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Employement Status:" , 94, 501,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strEmployeeStatus , 255, 501,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "Willing to relocate:" , 94, 486,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strRelocate , 255, 486,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "NAC SCORES (in Percentile)" , 94, 469,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "Analytical & Quantitative:" , 94, 455,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strAnalytical , 255, 455,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Listening:" , 94, 441,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strListening , 255, 441,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "Writing(Multiple Choice):" , 94, 427,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strWriting , 255, 427,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "Writing(Essay):" , 94, 413,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strWritingEssay , 255, 413,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.addText( "Speaking:" , 94, 399,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strSpeaking , 255, 399,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText( "Learning Ability:" , 94, 384,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText(strLearning , 255, 384,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Keyboard Skills:" , 94, 369,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strKeyboard , 255, 369,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
		 
			myPage.drawLine(70,385-30,555,385-30,sharpPDF.pdfColor.Gray,1);

			//Vertical line after S.No.
			myPage.drawLine(120,385-30,120,30,sharpPDF.pdfColor.LightGray,1);
			//Vertical line after Name of the company
			myPage.drawLine(261,385-30,261,30,sharpPDF.pdfColor.LightGray,1);
			//Vertical line after Attended(Yes/No)
			myPage.drawLine(396,385-30,396,30,sharpPDF.pdfColor.LightGray,1);
			 

			myPage.addText( "S.No." , 88, 365-30,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Name of the company" , 124, 365-30,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Attended (Y/N)" , 265, 365-30,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "Signature of Company personnel" , 400, 365-30,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			
			myPage.drawLine(70,355-30,555,355-30,sharpPDF.pdfColor.Gray,1);

			int iCounter=0;			
			foreach (DataRow dr in dsJobFairCardCompanyDetails.Tables[0].Rows)
			{
				iCounter=iCounter+1;
				myPage.addText( iCounter.ToString()+"."  , 94, 340-(30*iCounter),myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				myPage.addText( dr["Company Name"].ToString()   , 124, 340-(30*iCounter),myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
				
				//Dynamic horizontal line
				myPage.drawLine(70,330-(30*iCounter),555,330-(30*iCounter),sharpPDF.pdfColor.LightGray,1);				
			}			
			
			
			myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "JobFairCard_" + strPINNo + ".pdf");
			
			myPage = null;
			myDoc = null; 
			return flag;


			
		}

		#region GenerateJobFairCardCompanyDetails

		private DataSet GenerateJobFairCardCompanyDetails()
		{
			string strRegistrationId = Session["UserID"].ToString();
			DataRow drNewRow;
		
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

			return dsJobFairCardCompanyDetails;
			
		
		}
		#endregion
	}
}
