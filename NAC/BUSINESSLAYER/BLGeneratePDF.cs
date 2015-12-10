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
	/// Summary description for BLGeneratePDF.
	/// </summary>
	public  class BLGeneratePDF : System.Web.UI.Page
	{
		private string strName;
		private string strDOB;
		private string strGender;
		private string strQualification;
		private string strState;
		private string strCity;
		private string strCentre;
		private string strTestDate;
		string strLocation;
		private string RegistrationId;


		public BLGeneratePDF()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ChangeTimeFormat(string strTime)
		{
			if(strTime == "12:00 PM")
			{
				return "12:00 Noon";
			}
			else
			{
				return strTime;
			}
		}


		public bool GeneratePDF(string strRegistrationId)
		{
			bool flag=true;		 
			int intVarYPixCor = 0;
			int xCordinate, yCordanate;
			 
			 
			//To Get Data Set			 
			BusinessLayer.BLAdmitCard oBLAdmitCard = new BLAdmitCard();
			DataSet dsAdmitCard = oBLAdmitCard.GenerateAdmitCard(strRegistrationId);

			//To store values in variables
			RegistrationId = dsAdmitCard.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();	
			strName=dsAdmitCard.Tables[0].Rows[0]["FullName"].ToString().Trim().ToUpper();						
			strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0]["DOB"].ToString()));
			strGender=dsAdmitCard.Tables[0].Rows[0]["Gender"].ToString().Trim();

			if (dsAdmitCard.Tables[0].Rows[0]["Qualification"].ToString().Trim() == "Others")
			{
				//Displaying qualification details on lblQualification if Qualification Details is "Others"
				strQualification = dsAdmitCard.Tables[0].Rows[0]["OtherQualification"].ToString().Trim();
			}
			else
			{
				//Displaying qualification details on lblQualification if Qualification Details is not "Others"
				strQualification = dsAdmitCard.Tables[0].Rows[0]["Qualification"].ToString().Trim();
			}

			

			if(dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim()=="Hero Mindmine")
			{
				strState=dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim();
			}			
			else if(dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim()=="Sona College")
			{
				strState=dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim()+ ' ' + "of Technology";
			}
			else if(dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim()=="Vel-Tech Tech. Univ.")
			{
				strState=dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim();
			}
			else if(dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim()=="Infotech Enterprises Ltd.")
			{
				strState=dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
			}
			else
			{
				strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0]["State"].ToString().Trim();
			}

			strCity = dsAdmitCard.Tables[0].Rows[0]["City"].ToString().Trim();
			strCentre = dsAdmitCard.Tables[0].Rows[0]["Centre"].ToString().Trim();
			strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0]["TestDate"].ToString())) + ' ' + ChangeTimeFormat(String.Format("{0:hh:mm tt}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0]["TestTime"].ToString())));
			//Displaying test center of user on lblTestLocation Label.
			strLocation = dsAdmitCard.Tables[0].Rows[0]["CentreAddress"].ToString().Trim();           
			
			string strURL;	//Image url			

			if (dsAdmitCard.Tables[0].Rows[0]["ImageFileName"].ToString()=="")
			{
				//Displaying default photo is image is not in database.
				strURL = "images\\" + "defaultphoto.jpg";
			}
			else
			{
				//Displaying image of user if image name is existing in database.			
 
				if(System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath("") + "\\" + "UploadedPhotograph\\" + dsAdmitCard.Tables[0].Rows[0]["ImageFileName"].ToString().Trim()))
				{
					strURL = "UploadedPhotograph\\" + dsAdmitCard.Tables[0].Rows[0]["ImageFileName"].ToString().Trim();
				}
				else
				{
					strURL = "images\\" + "defaultphoto.jpg";
				}
			}

		
			sharpPDF.pdfDocument  ObjDocument = new sharpPDF.pdfDocument("NAC_Admit_Card","NASSCOM");
			sharpPDF.pdfPage ObjAdmitCard = ObjDocument.addPage();
			ObjDocument.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
			ObjDocument.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");			
			 
			// ObjDocument.getFontReference("verdana");

			//ObjDocument.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
		
			//ObjAdmitCard.addImage(ObjDocument.getImageReference("ex"),60,200,500,500);

			//Report Header section nass_logo.gif
			if(RegistrationId.StartsWith("NC"))				//For NAC-Final
			{
				ObjDocument.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\Nac_logo_PDF.png","logo");
				ObjAdmitCard.addImage(ObjDocument.getImageReference("logo"),60,700,80,150);		      
				ObjAdmitCard.addText("NASSCOM Assessment of Competence ", 220, 730, ObjDocument.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			}
			else				//For NAC-Diagnostic
			{
				ObjDocument.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\Nac-D_logo_PDF.png","logo");
				ObjAdmitCard.addImage(ObjDocument.getImageReference("logo"),60,700,80,150);		      
				ObjAdmitCard.addText("NASSCOM Assessment of Competence-", 220, 740, ObjDocument.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);	
				ObjAdmitCard.addText("Diagnostic", 340, 710, ObjDocument.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);	
			}
			//ObjAdmitCard.addImage(ObjDocument.getImageReference("logo"),81,700,80,150);		      

			ObjAdmitCard.addText("Admission Card ", 245, 665, ObjDocument.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			
			ObjAdmitCard.addText( strState , 246, 635,ObjDocument.getFontReference("verdanab"),11,sharpPDF.pdfColor.DarkBlue);
			int i32Length;
			i32Length=strState.Length;
			int lastCordinate=245+i32Length;
			string strStateText="____";

			if(i32Length > 20)
			{
				i32Length = i32Length + 3;
			}
			else if (i32Length > 16)
			{
				i32Length = i32Length + 2;
			}
			else if(i32Length > 13)
			{
				i32Length = i32Length + 1;
			}
			else
			{
				i32Length = i32Length + 0;
			}

			for (int i=0; i<=i32Length - 1; i++)
			{
				strStateText += "_";
			}

			//ObjAdmitCard.drawLine(235, 635,lastCordinate,635);
			ObjAdmitCard.addText( strStateText , 245, 635,ObjDocument.getFontReference(sharpPDF.Enumerators.predefinedFont.csTimesBold),10,sharpPDF.pdfColor.DarkBlue);
		
			//Details section		 

			/*ObjAdmitCard.addText( "Registration ID:" , 129, 580,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( RegistrationId , 243, 580,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjDocument.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\" + strURL,"CandidateImage");
			ObjAdmitCard.addImage(ObjDocument.getImageReference("CandidateImage"),410,450,98,88);
			ObjAdmitCard.addText( "Name:" , 129, 565,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strName.Substring(0,46) , 243, 565,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strName.Substring(46) , 243, 555,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( "Date of Birth:" , 129, 550,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strDOB , 243, 550,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( "Gender:" , 129, 535,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strGender , 243, 535,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( "Highest Education:" , 129, 520,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strQualification , 243, 520,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( "Test Centre:" , 129, 505,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addParagraph( strCentre , 243, 515,ObjDocument.getFontReference("verdana"),9,12,150,50,sharpPDF.pdfColor.DarkBlue);
			*/
			
			ObjAdmitCard.addText( "Registration ID:" , 129, 580,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( RegistrationId , 243, 580,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			ObjDocument.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\" + strURL,"CandidateImage");
			ObjAdmitCard.addImage(ObjDocument.getImageReference("CandidateImage"),410,450,98,88);
			
			yCordanate=565;

			ObjAdmitCard.addText( "Name:" , 129, yCordanate,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			if(strName.Length<46)
			{
				ObjAdmitCard.addText( strName , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);	
			}
			else
			{
				ObjAdmitCard.addText( strName.Substring(0,46) , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
				yCordanate = yCordanate-15;
				ObjAdmitCard.addText( strName.Substring(46) , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			}
			
			yCordanate = yCordanate-15;
			ObjAdmitCard.addText( "Date of Birth:" , 129, yCordanate,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strDOB , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			yCordanate = yCordanate-15;
			ObjAdmitCard.addText( "Gender:" , 129, yCordanate,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strGender , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			yCordanate = yCordanate-15;
			ObjAdmitCard.addText( "Highest Education:" , 129, yCordanate ,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			if(strQualification.Length<30)
			{
				ObjAdmitCard.addText( strQualification , 243, yCordanate ,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			}
			else
			{
				ObjAdmitCard.addText( strQualification.Substring(0,30) , 243, yCordanate ,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
				yCordanate = yCordanate-15;
				ObjAdmitCard.addText( strQualification.Substring(30) , 243, yCordanate ,ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			}
			yCordanate = yCordanate-15;
			ObjAdmitCard.addText( "Test Centre:" , 129, yCordanate,ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			yCordanate = yCordanate+10;
			ObjAdmitCard.addParagraph( strCentre , 243, yCordanate,ObjDocument.getFontReference("verdana"),9,12,150,50,sharpPDF.pdfColor.DarkBlue);
			
			yCordanate = strCentre.Length>25? yCordanate-25:yCordanate-10;

			if(strLocation == "" || strLocation == null)
			{
				intVarYPixCor = 60;
			}
			else if ((strLocation.Length > 60) && (strLocation.Length > 120))
			{
				intVarYPixCor = 0;
				
			//	ObjAdmitCard.addParagraph(strLocation , 243, yCordanate,ObjDocument.getFontReference("verdana"),10,12,153,100,sharpPDF.pdfColor.DarkBlue);
			}
			else if((strLocation.Length > 60) && (strLocation.Length < 90))
			{
				intVarYPixCor = 15;				 
			//	ObjAdmitCard.addParagraph(strLocation , 243, yCordanate,ObjDocument.getFontReference("verdana"),10,12,153,100,sharpPDF.pdfColor.DarkBlue); 
			}
			else if((strLocation.Length > 30) && (strLocation.Length < 60))
			{
				intVarYPixCor = 30;			 
			//	ObjAdmitCard.addParagraph(strLocation , 243, yCordanate,ObjDocument.getFontReference("verdana"),10,12,153,100,sharpPDF.pdfColor.DarkBlue);
			} 
			else
			{
				intVarYPixCor = 60;				 
			//	ObjAdmitCard.addParagraph(strLocation , 243, yCordanate,ObjDocument.getFontReference("verdana"),10,12,153,100,sharpPDF.pdfColor.DarkBlue);
			} 
			ObjAdmitCard.addParagraph(strLocation , 243, yCordanate,ObjDocument.getFontReference("verdana"),10,12,153,100,sharpPDF.pdfColor.DarkBlue);

			yCordanate = yCordanate -90;
			
			ObjAdmitCard.addText( "Test City:" , 129, (yCordanate + intVarYPixCor),ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strCity , 243, (yCordanate + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.DarkBlue);
			yCordanate = yCordanate - 65;
			ObjAdmitCard.addText( "Candidate's Signature" , 375,(yCordanate + intVarYPixCor),ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			yCordanate = yCordanate + 40 ;
			ObjAdmitCard.addText( "Test Date:" , 129, (yCordanate + intVarYPixCor),ObjDocument.getFontReference("verdanab"),9,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( strTestDate , 243, (yCordanate + intVarYPixCor),ObjDocument.getFontReference("verdana"),10,sharpPDF.pdfColor.DarkBlue);

			//Report Footer seaction

			ObjAdmitCard.addText( "Important Points" , 70, (272 + intVarYPixCor),ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			ObjAdmitCard.addText( " 1.  Do take a printout of your Admission Card (A4 size / portrait)." , 90, (239 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 2.  Paste your recent color passport-size photo in the given space (in case you have not uploaded" , 90, (226 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    it already) and sign the Admission Card in the given space." , 97, (213 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 3.  It is mandatory to carry to the test centre your NAC Admission Card and the Photo" , 90, (200 + intVarYPixCor),ObjDocument.getFontReference("verdanab"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    Document, details of which were filled by you in the online registration form.   " , 97, (187 + intVarYPixCor),ObjDocument.getFontReference("verdanab"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    Failing this, you will not be allowed to sit for the test." , 97, (174 + intVarYPixCor),ObjDocument.getFontReference("verdanab"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 4.  Your photograph on the Admission Card must match the one on the photo-ID document." , 90, (159 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			//ObjAdmitCard.addText( "    document." , 97, (146 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 5.  In case of loss of the Admission Card, the candidate must visit the website" , 90, (146 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    (www.nac.nasscom.in) and log in to his/her account to print it again. " , 97, (133 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 6.  Candidates are requested to report at the test centre at least 30 minutes before the test" , 90, (120 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    timing." , 97, (107 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 7.  Do not write/mark on any sheet, which is given to you at the test center, without invigilator's" , 90, (94 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( "    permission." , 97, (81 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 8.  Candidates should carry their own stationery. Test center shall not be providing the same." , 90, (68 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			//ObjAdmitCard.addText( "    providing the same. " , 97, (55 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			ObjAdmitCard.addText( " 9.  For any queries, please get in touch with the nodal person/agency for NAC in your college/state. " , 90, (54 + intVarYPixCor),ObjDocument.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
            //ekta
            ObjAdmitCard.addText(" 10. Please take a note of your NAC Registration ID. You will need it for future references", 90, (40 + intVarYPixCor), ObjDocument.getFontReference("verdana"), 9, sharpPDF.pdfColor.Gray);

			ObjAdmitCard.addText( " To view your profile - please visit www.nac.nasscom.in " , 70, (10 + intVarYPixCor),ObjDocument.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
 
			//Bottom Line
			ObjAdmitCard.drawLine(55,20,560,20,sharpPDF.pdfColor.LightGray);
			//ObjAdmitCard.drawLine(100,800,590,800);

			//Top Line
			ObjAdmitCard.drawLine(55,790,560,790,sharpPDF.pdfColor.LightGray);						
			
			//Left Line
			ObjAdmitCard.drawLine(55,790,55,20,sharpPDF.pdfColor.LightGray);

			//Right Line
			ObjAdmitCard.drawLine(560,790 ,560,20,sharpPDF.pdfColor.LightGray);

			//Above "Admission Card' Line
			ObjAdmitCard.drawLine(70,700 ,540,700,sharpPDF.pdfColor.LightGray);

			ObjAdmitCard.drawLine(70,(295 + intVarYPixCor),540,(295+ intVarYPixCor),sharpPDF.pdfColor.Gray);

			//Pragraph third underline1
			ObjAdmitCard.drawLine(110,(197 + intVarYPixCor),528,(197 + intVarYPixCor),sharpPDF.pdfColor.Gray,1);
			//Pragraph third underline2
			ObjAdmitCard.drawLine(110,(184 + intVarYPixCor),496,(184 + intVarYPixCor),sharpPDF.pdfColor.Gray,1);
			//Pragraph third underline3
			ObjAdmitCard.drawLine(110,(170 + intVarYPixCor),317,(170 + intVarYPixCor),sharpPDF.pdfColor.Gray,1);

			ObjDocument.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "AdmitCard_" + strRegistrationId + ".pdf");
			ObjAdmitCard = null;
			ObjDocument = null; 
			return flag;
		}

	}
}
