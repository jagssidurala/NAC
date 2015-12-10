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
	/// Summary description for BLGenerateScoreCardPDF.
	/// </summary>
	public class BLGenerateScoreCardPDF : System.Web.UI.Page
	{
		string strRegistartionId;
		string strName;
		string strDOB;
		string strState;
		string strTestCentre;
		//string strTestDate;
		string strSpeaking;
		string strListening;
		string strWriting;
		string strAnalytical;
		string strTestDate;
		 
		public BLGenerateScoreCardPDF()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool GenerateScoreCardPDF(string strPINNo)
		{
			bool flag=true;
			bool blCheck = false;
			sharpPDF.Fonts.pdfFontDefinition objMertic = new sharpPDF.Fonts.pdfFontDefinition();
			objMertic.familyName = "Verdana, Arial, Helvetica, sans-serif";
			objMertic.fontWeight = "bold";
			objMertic.fontHeight = 11;	
			BusinessLayer.BLScoreCard oBLScoreCard = new BLScoreCard();
			DataSet dsScoreCard = oBLScoreCard.GenerateScoreCard(strPINNo);
	
			//			//To store values in variables
			if(dsScoreCard.Tables[0].Rows.Count > 0)
			{
				strRegistartionId=dsScoreCard.Tables[0].Rows[0]["RegistrationId"].ToString().Trim();
				strName=dsScoreCard.Tables[0].Rows[0][1].ToString().Trim();				
				strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsScoreCard.Tables[0].Rows[0][2].ToString()));				
				strState="State of" + ' ' + dsScoreCard.Tables[0].Rows[0][4].ToString().Trim();
				strTestCentre = dsScoreCard.Tables[0].Rows[0][3].ToString().Trim();
				strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsScoreCard.Tables[0].Rows[0][5].ToString()));				
				if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][6]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][7]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][8]) == 0 && Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][9]) == 0)
				{
					blCheck = true;
					strSpeaking = "Did not appear";
					strListening = "Did not appear";
					strWriting = "Did not appear";
					strAnalytical = "Did not appear";
				}
				else
				{
					if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][6]) == 0)
					{
					   strSpeaking = "N/A";
					}
					else
					{
					   strSpeaking=dsScoreCard.Tables[0].Rows[0][6].ToString().Trim();
					}

					if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][7]) == 0)
					{
						strListening = "N/A";
					}
					else
					{
						strListening=dsScoreCard.Tables[0].Rows[0][7].ToString().Trim();
					}

					if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][8]) == 0)
					{
						strWriting = "N/A";
					}
					else
					{
						strWriting=dsScoreCard.Tables[0].Rows[0][8].ToString().Trim();
					}

					if(Convert.ToInt32(dsScoreCard.Tables[0].Rows[0][9]) == 0)
					{
						strAnalytical = "N/A";
					}
					else
					{
						strAnalytical=dsScoreCard.Tables[0].Rows[0][9].ToString().Trim();
					}
					
					
					
					
				}
				
				
			}		
			sharpPDF.pdfDocument  myDoc = new sharpPDF.pdfDocument("NAC_Score_Card","NASSCOM");
			sharpPDF.pdfPage myPage = myDoc.addPage();
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdanab.ttf","verdanab");
			myDoc.addTrueTypeFont(System.Web.HttpContext.Current.Server.MapPath("") + "\\Stylesheet\\verdana.ttf","verdana");			
			 
			// myDoc.getFontReference("verdana");

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NAC_Stamp_bg.gif","ex");
		
			myPage.addImage(myDoc.getImageReference("ex"),60,200,500,500);

			//Report Header section nass_logo.gif

			myDoc.addImageReference(System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\NASSCOM logo.jpg","logo");
			myPage.addImage(myDoc.getImageReference("logo"),45,742,30,165);		      

			myPage.addText("NAC - NASSCOM Assessment of Competence", 125, 705, myDoc.getFontReference("verdanab"),15,sharpPDF.pdfColor.DarkBlue);
			
			myPage.addText(strState, 275, 690, myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);

			//Details section	
			

			// here  
			myPage.drawLine(92,679,533,679,sharpPDF.pdfColor.LightBlue );
			//
			myPage.drawLine(92,679,92,600,sharpPDF.pdfColor.LightBlue);
			myPage.drawLine(533,600,533,679,sharpPDF.pdfColor.LightBlue);
			//myPage.drawLine(72,620,513,620);
			myPage.drawLine(250,679,250,600,sharpPDF.pdfColor.LightBlue);

			myPage.addText( "Registration ID:" , 94, 669,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strRegistartionId , 255, 669,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.drawLine(92,664,533,664,sharpPDF.pdfColor.LightBlue);

		
			myPage.addText( "Name:" , 94, 653,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strName , 255, 653,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.drawLine(92,648,533,648,sharpPDF.pdfColor.LightBlue);
			myPage.addText( "Date of Birth:" , 94, 638,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strDOB , 255, 638,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.drawLine(92,632,533,632,sharpPDF.pdfColor.LightBlue);
			
			myPage.addText( "Test Location:" , 94, 622,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
		
			myPage.addText( strTestCentre , 255, 622,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.drawLine(92,616,533,616,sharpPDF.pdfColor.LightBlue);
			
			myPage.addText( "Test Date:" , 94, 606,myDoc.getFontReference("verdanab"),8,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( strTestDate , 255, 606,myDoc.getFontReference("verdana"),8,sharpPDF.pdfColor.DarkBlue);

			myPage.drawLine(92,600,533,600,sharpPDF.pdfColor.LightBlue);

			myPage.addText( "TEST SCORES" , 288, 580,myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);

			
			myPage.drawLine(415,492,415,574,sharpPDF.pdfColor.LightBlue);
		
			
			myPage.drawLine(92,492,92,574,sharpPDF.pdfColor.LightBlue);
		
			myPage.drawLine(533,574,533,492,sharpPDF.pdfColor.LightBlue );
			//above skill set

			myPage.drawLine(92,574,533,574,sharpPDF.pdfColor.LightBlue,1);
		
			///line cloured here
			myPage.drawLine(92,564,533,564,sharpPDF.pdfColor.DarkBlue,20);
		

			myPage.addText( "Skill Set" , 94, 562,myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.White );
			
			myPage.addText( "Percentile Score" , 434, 562,myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.White);
			myPage.drawLine(92,555,533,555,sharpPDF.pdfColor.LightBlue);

			if(blCheck)
			{
				//myPage.drawLine(380,553,380,553);
				myPage.addText( "English Speaking" , 94, 544,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black );
				myPage.addText(  strSpeaking , 445, 544,myDoc.getFontReference("verdanab"),7,sharpPDF.pdfColor.Black);
				myPage.drawLine(92,539,533,539,sharpPDF.pdfColor.LightBlue);
				myPage.addText( "English Listening " , 94, 528,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				myPage.addText(  strListening , 445, 528,myDoc.getFontReference("verdanab"),7,sharpPDF.pdfColor.Black);
				myPage.drawLine(92,523,533,523,sharpPDF.pdfColor.LightBlue);
				myPage.addText( "English Writing" , 94, 512,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				myPage.addText(  strWriting , 445, 512,myDoc.getFontReference("verdanab"),7,sharpPDF.pdfColor.Black);
				myPage.drawLine(92,507,533,507,sharpPDF.pdfColor.LightBlue);
				myPage.addText( "Analytical & Quantitative Reasoning" , 94, 497,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				myPage.addText(  strAnalytical , 445, 497,myDoc.getFontReference("verdanab"),7,sharpPDF.pdfColor.Black);
				myPage.drawLine(92,492,533,492,sharpPDF.pdfColor.LightBlue);
			}
			else
			{
				//myPage.drawLine(380,553,380,553);
				myPage.addText( "English Speaking" , 94, 544,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black );
				int lenSpeaking=strSpeaking.Length;
			
				if (lenSpeaking==1)
				{
					myPage.addText(  strSpeaking , 460, 544,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
				}
				else
				{
					myPage.addText(  strSpeaking , 456, 544,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			
				}
				myPage.drawLine(92,539,533,539,sharpPDF.pdfColor.LightBlue);

				myPage.addText( "English Listening " , 94, 528,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				int lenListening=strListening.Length;
				if (lenListening==1)
				{
					myPage.addText(  strListening , 460, 528,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
				}
				else
				{
					myPage.addText(  strListening , 456, 528,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			
				}
			
			
				myPage.drawLine(92,523,533,523,sharpPDF.pdfColor.LightBlue);

				myPage.addText( "English Writing" , 94, 512,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				int lenWriting=strWriting.Length;
				if (lenWriting==1)
				{
					myPage.addText(  strWriting , 460, 512,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
				}
				else
				{
					myPage.addText(  strWriting , 456, 512,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			
				}
			
				myPage.drawLine(92,507,533,507,sharpPDF.pdfColor.LightBlue);

				myPage.addText( "Analytical & Quantitative Reasoning" , 94, 497,myDoc.getFontReference("verdanab"),9,sharpPDF.pdfColor.Black);
				int lenAnalytical=strAnalytical.Length;
				if (lenAnalytical==1)
				{
					myPage.addText(  strAnalytical , 460, 497,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
				}
				else
				{
					myPage.addText(  strAnalytical , 456, 497,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Black);
			
				}

			
				myPage.drawLine(92,492,533,492,sharpPDF.pdfColor.LightBlue);
			}
			

			myPage.addText( " About NAC Test" , 50, 444,myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			//detail section
			myPage.addText( "1.  Speaking is a measure of ability to speak in a professional context. Tasks in this section require comprehension " , 60, 419,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     of spoken English and written English.Scoring takes into account delivery and language use, as well as success" , 60, 407,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     at completing defined communicative tasks.  " , 60, 395,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);  

			//2nd point
			myPage.addText( "2.  Listening is a measure of the comprehension of spoken English including the ability to identify main ideas, the" , 60, 383,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     ability to understand factual information and details and the ability to connect information across longer speech" , 60, 371,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     samples. Speech samples simulate a variety of work and everyday situations and include both extended" , 60, 359,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     announcement and conversations ." , 60, 347,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
   
			//3rd point
			myPage.addText( "3.  Writing is a measure of the ability to both use and identify standard written English and to organize and support" , 60, 335,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     ideas in English . Scoring of the written essay takes into account organization and language, use as well as" , 60, 323,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     success in completing a defined writing task. " , 60, 311,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			
				
			//4th point			
			myPage.addText( "4.  Analytical and Quantitative Reasoning (A&Q) is a measure of the ability to (i) assimilate information presented in" , 60, 299,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     a structured way including quantitative information and (ii) draw logical inferences from the information," , 60, 287,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     including identifying when information is insufficient to support an inference. Tasks in this section require the" , 60, 275,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     ability to comprehend sets of practical relationships presented in English as well as the ability to apply basic" , 60, 263,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);	
			myPage.addText( "     mathematical concepts." , 60, 251,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			
			//Report Footer seaction 230

			myPage.addText( "Important Points" , 50, 214,myDoc.getFontReference("verdanab"),10,sharpPDF.pdfColor.DarkBlue);
			myPage.addText( "1.  This is the official score card for NAC-NASSCOM Assessment of Competence." , 60, 184,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "2.  Scores are provided in percentile manner and range from 0 to 99. Example - A percentile score of 50 on a skill" , 60, 172,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     indicates that the test taker scored over 50 percent of the population taking the same test for that skill on the" , 60, 160,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     same day." , 60, 148,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			myPage.addText( "3.  Where 'NA' is present on a score report, a score could not be provided due to either of two possible reasons -" , 60, 136,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     (i) the test taker did not attempt that section of the test or (ii) there was considerable difficulty in discerning the" , 60, 124,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     test taker's responses (only in the speaking section)." , 60, 112,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			myPage.addText( "4.  You may use this score sheet for applying to companies announced to be recruiting through NAC. However, NAC" , 60, 100,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     Test participation does not guarantee employment." , 60, 88,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			myPage.addText( "5.  The employers may or may not assess your academic performance, details of past employment etc. for the" , 60, 76,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     purpose of final selection." , 60, 64,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			myPage.addText( "6.  The content of current version of the assessment is designed and developed by Educational Testing Services" , 60, 52,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "     (ETS)." , 60, 40,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			myPage.addText( "7.  NAC is endorsed by leading ITES-BPO players." , 60, 28,myDoc.getFontReference("verdana"),9,sharpPDF.pdfColor.Gray);
			
			myPage.drawLine(25,788,25,4,sharpPDF.pdfColor.LightBlue);
			myPage.drawLine(590,788,590,4,sharpPDF.pdfColor.LightBlue);
			myPage.drawLine (25,788,590,788,sharpPDF.pdfColor.LightBlue);
			myPage.drawLine(25,4,590,4,sharpPDF.pdfColor.LightBlue);
		
			myDoc.createPDF(System.Web.HttpContext.Current.Server.MapPath("") + "\\TempWorkAreaPdf\\" + "ScoreCard_" + strPINNo + ".pdf"); 
			myPage = null;
			myDoc = null; 
			return flag;


			
		}
	}
}
