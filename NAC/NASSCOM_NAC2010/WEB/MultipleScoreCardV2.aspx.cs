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
	/// Summary description for MultipleScoreCardV2.
	/// </summary>
	public partial class MultipleScoreCardV2 : System.Web.UI.Page
	{
		public string strDivStyle;
		private string strItemList;
		private string strSortExp;

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string strUserAgent = Request.UserAgent.ToString().ToLower();			 

//			if(strUserAgent.IndexOf("msie 6.0") != -1)
//			{
//				strDivStyle = "ImgPosition5";
//
//				//imgWatermark.Src = "Images/NAC_Stamp_bg6.gif";
//			}
//			else
//			{
//				strDivStyle = "ImgPosition6";
//				//imgWatermark.Src = "Images/NAC_Stamp_bg.gif";
//			}



			try
			{
				if(Request.QueryString["SearchType"] != null)
				{
					if(Request.QueryString["SearchType"] == "full"  && Session["SortExp"] != null)
					{

						BLSearch objBLSearch = new BLSearch();
						objBLSearch = (BLSearch)Session["SearchObject"];
						strSortExp = Session["SortExp"].ToString();
						CreateAllMultipleScoreCard(objBLSearch,strSortExp);
					}
					else if(Request.QueryString["SearchType"] == "fullCompany" && Session["SortExp"] != null)
					{
						BLCandidateSearchByCompany objBLSearch = new BLCandidateSearchByCompany();
						objBLSearch = (BLCandidateSearchByCompany)Session["SearchObject"];
						strSortExp = Session["SortExp"].ToString();
						CreateAllMultipleScoreCardForCompany(objBLSearch,strSortExp);
					}

					else if(Request.QueryString["SearchType"] == "fullAdmin" && Session["SortExp"] != null)
					{
						BLCandidateSearchByAdmin objBLSearch = new BLCandidateSearchByAdmin();
						objBLSearch = (BLCandidateSearchByAdmin)Session["SearchObject"];
						strSortExp = Session["SortExp"].ToString();
						CreateAllMultipleScoreCardForAdmin(objBLSearch,strSortExp);
					}

					else
					{
						Response.Redirect("../NacDb/LoginPage.aspx");
					}
				}
				else 
				{
					if(Session["ItemList"] != null && Session["SortExp"] != null)
					{				
						strItemList = Session["ItemList"].ToString(); 
						strSortExp = Session["SortExp"].ToString();
						CreateMultipleScoreCard(strItemList,strSortExp);
					}
					else
					{
						Response.Redirect("../NacDb/LoginPage.aspx");
					}
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}



		}

#endregion

		#region CreateMultipleScoreCard()

		private void CreateMultipleScoreCard(string strItemList, string strSortExp)
		{
			try
			{
				BusinessLayer.BLSearch oBLSearch = new BLSearch();
				DataView dvScoreCard = new DataView();
				DataTable dtScores = new DataTable();
				dtScores = oBLSearch.GenerateMultipleScoreCardV2(strItemList);
				dtScores.Columns.Add("AnalyticalRange",typeof(string));
				dtScores.Columns.Add("AnalyticalRemarks",typeof(string));
				dtScores.Columns.Add("QuantitativeRange",typeof(string));
				dtScores.Columns.Add("QuantitativeRemarks",typeof(string));
				dtScores.Columns.Add("EWOverallRange",typeof(string));
				dtScores.Columns.Add("EWOverallRemarks",typeof(string));
				dtScores.Columns.Add("EWGrammarRange",typeof(string));
				dtScores.Columns.Add("EWGrammarRemarks",typeof(string));
				dtScores.Columns.Add("EWContentRange",typeof(string));
				dtScores.Columns.Add("EWContentRemarks",typeof(string));
				dtScores.Columns.Add("EWVocabularyRange",typeof(string));
				dtScores.Columns.Add("EWVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("EWSpellingRange",typeof(string));
				dtScores.Columns.Add("EWSpellingRemarks",typeof(string));
				dtScores.Columns.Add("SLOverallRange",typeof(string));
				dtScores.Columns.Add("SLOverallRemarks",typeof(string));
				dtScores.Columns.Add("SLSentenceRange",typeof(string));
				dtScores.Columns.Add("SLSentenceRemarks",typeof(string));
				dtScores.Columns.Add("SLVocabularyRange",typeof(string));
				dtScores.Columns.Add("SLVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("SLFluencyRange",typeof(string));
				dtScores.Columns.Add("SLFluencyRemarks",typeof(string));
				dtScores.Columns.Add("SLPronunciationRange",typeof(string));
				dtScores.Columns.Add("SLPronunciationRemarks",typeof(string));
				dtScores.Columns.Add("KSTSpeedRange",typeof(string));
				dtScores.Columns.Add("KSTSpeedRemarks",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRange",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRemarks",typeof(string));
				dtScores.Columns.Add("imgLogo",typeof(string));
				dtScores.Columns.Add("imgLogoHeaderText",typeof(string));
				dtScores.Columns.Add("txtNAC_DFooterNoteVisible",typeof(string));

				foreach(DataRow dr in dtScores.Rows)
				{
					BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
					DataTable dtScoreCardRemarks = new DataTable();
					dtScoreCardRemarks = objTestScore.GetScoreCardRemarksV2(Convert.ToString(dr["RegistrationID"]).Trim()).Tables[0];
					
					if(Convert.ToString(dr["RegistrationID"]).Trim().StartsWith("NC"))	//NAC-FINAL
					{
						dr["imgLogo"]="Images/nac_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence";
						dr["txtNAC_DFooterNoteVisible"]="";

					}

					else		//NAC-Diagnostic
					{
						dr["imgLogo"]="Images/nac-D_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence- <br> Diagnostic";
						dr["txtNAC_DFooterNoteVisible"]="- NAC Diagnostic Score Report is not meant for employment purposes";
						
					}

					dr["AnalyticalRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["ScoreRange"]);
					dr["AnalyticalRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["Remarks"]);
					dr["QuantitativeRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["ScoreRange"]);
					dr["QuantitativeRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["Remarks"]);
					dr["EWOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["ScoreRange"]);
					dr["EWOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["Remarks"]);
					dr["EWGrammarRange"]= Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["ScoreRange"]);
					dr["EWGrammarRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["Remarks"]);
					dr["EWContentRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["ScoreRange"]);
					dr["EWContentRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["Remarks"]);
					dr["EWVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["ScoreRange"]);
					dr["EWVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["Remarks"]);
					dr["EWSpellingRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["ScoreRange"]);
					dr["EWSpellingRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["Remarks"]);
					dr["SLOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["ScoreRange"]);
					dr["SLOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["Remarks"]);
					dr["SLSentenceRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["ScoreRange"]);
					dr["SLSentenceRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["Remarks"]);
					dr["SLVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["ScoreRange"]);
					dr["SLVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["Remarks"]);
					dr["SLFluencyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["ScoreRange"]);
					dr["SLFluencyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["Remarks"]);
					dr["SLPronunciationRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["ScoreRange"]);
					dr["SLPronunciationRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["Remarks"]);
					dr["KSTSpeedRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["ScoreRange"]);
					if(Convert.ToString(dr["KSTSpeedRange"]).EndsWith("999"))
						dr["KSTSpeedRange"]=Convert.ToString(dr["KSTSpeedRange"]).Substring(0,2) + " and " + "above" ;
					dr["KSTSpeedRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["Remarks"]);
					dr["KSTAccuracyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["ScoreRange"]);
					dr["KSTAccuracyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["Remarks"]);

			
				}
				dvScoreCard = dtScores.DefaultView; 
				//dvScoreCard.Sort = strSortExp;
				
				

				if(dvScoreCard.Count > 0)
				{
					rptScoreCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptScoreCard.DataSource = dvScoreCard;
					rptScoreCard.DataBind();
				}
				else
				{					
					rptScoreCard.Visible = false;
					iPrint.Visible = false;
					goBack.Visible = false;
					pnlMessage.Visible = true;
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}

		#endregion

		#region CreateAllMultipleScoreCard()

		private void CreateAllMultipleScoreCard(BLSearch objBLSearch, string strSortExp)
		{
			try
			{
				 
				DataView dvScoreCard = new DataView();
			//	dvScoreCard = objBLSearch.GenerateAllPercentMultipleScoreCard().DefaultView; 
				//dvScoreCard.Sort = strSortExp;	

				if(dvScoreCard.Count > 0)
				{
					rptScoreCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptScoreCard.DataSource = dvScoreCard;
					rptScoreCard.DataBind();
				}
				else
				{					
					rptScoreCard.Visible = false;
					iPrint.Visible = false;
					goBack.Visible = false;
					pnlMessage.Visible = true;
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}
		
		
		#endregion

		#region CreateAllMultipleScoreCardForCompany()

		private void CreateAllMultipleScoreCardForCompany(BLCandidateSearchByCompany objBLSearch, string strSortExp)
		{
			try
			{
				DataView dvScoreCard = new DataView();

				DataTable dtScores = new DataTable();
				dtScores = objBLSearch.GenerateAllPercentMultipleScoreCard(); 

				dtScores.Columns.Add("AnalyticalRange",typeof(string));
				dtScores.Columns.Add("AnalyticalRemarks",typeof(string));
				dtScores.Columns.Add("QuantitativeRange",typeof(string));
				dtScores.Columns.Add("QuantitativeRemarks",typeof(string));
				dtScores.Columns.Add("EWOverallRange",typeof(string));
				dtScores.Columns.Add("EWOverallRemarks",typeof(string));
				dtScores.Columns.Add("EWGrammarRange",typeof(string));
				dtScores.Columns.Add("EWGrammarRemarks",typeof(string));
				dtScores.Columns.Add("EWContentRange",typeof(string));
				dtScores.Columns.Add("EWContentRemarks",typeof(string));
				dtScores.Columns.Add("EWVocabularyRange",typeof(string));
				dtScores.Columns.Add("EWVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("EWSpellingRange",typeof(string));
				dtScores.Columns.Add("EWSpellingRemarks",typeof(string));
				dtScores.Columns.Add("SLOverallRange",typeof(string));
				dtScores.Columns.Add("SLOverallRemarks",typeof(string));
				dtScores.Columns.Add("SLSentenceRange",typeof(string));
				dtScores.Columns.Add("SLSentenceRemarks",typeof(string));
				dtScores.Columns.Add("SLVocabularyRange",typeof(string));
				dtScores.Columns.Add("SLVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("SLFluencyRange",typeof(string));
				dtScores.Columns.Add("SLFluencyRemarks",typeof(string));
				dtScores.Columns.Add("SLPronunciationRange",typeof(string));
				dtScores.Columns.Add("SLPronunciationRemarks",typeof(string));
				dtScores.Columns.Add("KSTSpeedRange",typeof(string));
				dtScores.Columns.Add("KSTSpeedRemarks",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRange",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRemarks",typeof(string));
				dtScores.Columns.Add("imgLogo",typeof(string));
				dtScores.Columns.Add("imgLogoHeaderText",typeof(string));
				dtScores.Columns.Add("txtNAC_DFooterNoteVisible",typeof(string));

				foreach(DataRow dr in dtScores.Rows)
				{
					BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
					DataTable dtScoreCardRemarks = new DataTable();
					dtScoreCardRemarks = objTestScore.GetScoreCardRemarksV2(Convert.ToString(dr["RegistrationID"]).Trim()).Tables[0];
					
					if(Convert.ToString(dr["RegistrationID"]).Trim().StartsWith("NC"))	//NAC-FINAL
					{
						dr["imgLogo"]="Images/nac_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence";
						dr["txtNAC_DFooterNoteVisible"]="";
					}

					else		//NAC-Diagnostic
					{
						dr["imgLogo"]="Images/nac-D_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence- <br> Diagnostic";
						dr["txtNAC_DFooterNoteVisible"]="- NAC Diagnostic Score Report is not meant for employment purposes";
						
					}

					dr["AnalyticalRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["ScoreRange"]);
					dr["AnalyticalRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["Remarks"]);
					dr["QuantitativeRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["ScoreRange"]);
					dr["QuantitativeRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["Remarks"]);
					dr["EWOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["ScoreRange"]);
					dr["EWOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["Remarks"]);
					dr["EWGrammarRange"]= Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["ScoreRange"]);
					dr["EWGrammarRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["Remarks"]);
					dr["EWContentRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["ScoreRange"]);
					dr["EWContentRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["Remarks"]);
					dr["EWVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["ScoreRange"]);
					dr["EWVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["Remarks"]);
					dr["EWSpellingRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["ScoreRange"]);
					dr["EWSpellingRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["Remarks"]);
					dr["SLOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["ScoreRange"]);
					dr["SLOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["Remarks"]);
					dr["SLSentenceRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["ScoreRange"]);
					dr["SLSentenceRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["Remarks"]);
					dr["SLVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["ScoreRange"]);
					dr["SLVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["Remarks"]);
					dr["SLFluencyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["ScoreRange"]);
					dr["SLFluencyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["Remarks"]);
					dr["SLPronunciationRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["ScoreRange"]);
					dr["SLPronunciationRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["Remarks"]);
					dr["KSTSpeedRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["ScoreRange"]);
					if(Convert.ToString(dr["KSTSpeedRange"]).EndsWith("999"))
						dr["KSTSpeedRange"]=Convert.ToString(dr["KSTSpeedRange"]).Substring(0,2) + " and " + "above" ;
					dr["KSTSpeedRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["Remarks"]);
					dr["KSTAccuracyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["ScoreRange"]);
					dr["KSTAccuracyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["Remarks"]);

			
				}
				dvScoreCard = dtScores.DefaultView; 

				//dvScoreCard.Sort = strSortExp;	

				if(dvScoreCard.Count > 0)
				{
					rptScoreCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptScoreCard.DataSource = dvScoreCard;
					rptScoreCard.DataBind();
				}
				else
				{					
					rptScoreCard.Visible = false;
					iPrint.Visible = false;
					goBack.Visible = false;
					pnlMessage.Visible = true;
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}
		
		
		#endregion

		#region CreateAllMultipleScoreCardForAdmin()

		private void CreateAllMultipleScoreCardForAdmin(BLCandidateSearchByAdmin objBLSearch, string strSortExp)
		{
			try
			{
				DataView dvScoreCard = new DataView();

				DataTable dtScores = new DataTable();
				dtScores = objBLSearch.GenerateAllPercentMultipleScoreCard(); 

				dtScores.Columns.Add("AnalyticalRange",typeof(string));
				dtScores.Columns.Add("AnalyticalRemarks",typeof(string));
				dtScores.Columns.Add("QuantitativeRange",typeof(string));
				dtScores.Columns.Add("QuantitativeRemarks",typeof(string));
				dtScores.Columns.Add("EWOverallRange",typeof(string));
				dtScores.Columns.Add("EWOverallRemarks",typeof(string));
				dtScores.Columns.Add("EWGrammarRange",typeof(string));
				dtScores.Columns.Add("EWGrammarRemarks",typeof(string));
				dtScores.Columns.Add("EWContentRange",typeof(string));
				dtScores.Columns.Add("EWContentRemarks",typeof(string));
				dtScores.Columns.Add("EWVocabularyRange",typeof(string));
				dtScores.Columns.Add("EWVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("EWSpellingRange",typeof(string));
				dtScores.Columns.Add("EWSpellingRemarks",typeof(string));
				dtScores.Columns.Add("SLOverallRange",typeof(string));
				dtScores.Columns.Add("SLOverallRemarks",typeof(string));
				dtScores.Columns.Add("SLSentenceRange",typeof(string));
				dtScores.Columns.Add("SLSentenceRemarks",typeof(string));
				dtScores.Columns.Add("SLVocabularyRange",typeof(string));
				dtScores.Columns.Add("SLVocabularyRemarks",typeof(string));
				dtScores.Columns.Add("SLFluencyRange",typeof(string));
				dtScores.Columns.Add("SLFluencyRemarks",typeof(string));
				dtScores.Columns.Add("SLPronunciationRange",typeof(string));
				dtScores.Columns.Add("SLPronunciationRemarks",typeof(string));
				dtScores.Columns.Add("KSTSpeedRange",typeof(string));
				dtScores.Columns.Add("KSTSpeedRemarks",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRange",typeof(string));
				dtScores.Columns.Add("KSTAccuracyRemarks",typeof(string));
				dtScores.Columns.Add("imgLogo",typeof(string));
				dtScores.Columns.Add("imgLogoHeaderText",typeof(string));
				dtScores.Columns.Add("txtNAC_DFooterNoteVisible",typeof(string));

				foreach(DataRow dr in dtScores.Rows)
				{
					BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
					DataTable dtScoreCardRemarks = new DataTable();
					dtScoreCardRemarks = objTestScore.GetScoreCardRemarksV2(Convert.ToString(dr["RegistrationID"]).Trim()).Tables[0];
					
					if(Convert.ToString(dr["RegistrationID"]).Trim().StartsWith("NC"))	//NAC-FINAL
					{
						dr["imgLogo"]="Images/nac_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence";
						dr["txtNAC_DFooterNoteVisible"]="";
					}

					else		//NAC-Diagnostic
					{
						dr["imgLogo"]="Images/nac-D_logo.PNG";
						dr["imgLogoHeaderText"]="NASSCOM Assessment of Competence- <br> Diagnostic";
						dr["txtNAC_DFooterNoteVisible"]="- NAC Diagnostic Score Report is not meant for employment purposes";
						
					}

					dr["AnalyticalRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["ScoreRange"]);
					dr["AnalyticalRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,1)["Remarks"]);
					dr["QuantitativeRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["ScoreRange"]);
					dr["QuantitativeRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,2)["Remarks"]);
					dr["EWOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["ScoreRange"]);
					dr["EWOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,3)["Remarks"]);
					dr["EWGrammarRange"]= Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["ScoreRange"]);
					dr["EWGrammarRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,4)["Remarks"]);
					dr["EWContentRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["ScoreRange"]);
					dr["EWContentRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,5)["Remarks"]);
					dr["EWVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["ScoreRange"]);
					dr["EWVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,6)["Remarks"]);
					dr["EWSpellingRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["ScoreRange"]);
					dr["EWSpellingRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,7)["Remarks"]);
					dr["SLOverallRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["ScoreRange"]);
					dr["SLOverallRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,8)["Remarks"]);
					dr["SLSentenceRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["ScoreRange"]);
					dr["SLSentenceRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,9)["Remarks"]);
					dr["SLVocabularyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["ScoreRange"]);
					dr["SLVocabularyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,10)["Remarks"]);
					dr["SLFluencyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["ScoreRange"]);
					dr["SLFluencyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,11)["Remarks"]);
					dr["SLPronunciationRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["ScoreRange"]);
					dr["SLPronunciationRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,12)["Remarks"]);
					dr["KSTSpeedRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["ScoreRange"]);
					if(Convert.ToString(dr["KSTSpeedRange"]).EndsWith("999"))
						dr["KSTSpeedRange"]=Convert.ToString(dr["KSTSpeedRange"]).Substring(0,2) + " and " + "above" ;
					dr["KSTSpeedRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,13)["Remarks"]);
					dr["KSTAccuracyRange"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["ScoreRange"]);
					dr["KSTAccuracyRemarks"]=Convert.ToString(GetScoreRemarks(dtScoreCardRemarks,14)["Remarks"]);

			
				}
				dvScoreCard = dtScores.DefaultView; 

				//dvScoreCard.Sort = strSortExp;	

				if(dvScoreCard.Count > 0)
				{
					rptScoreCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptScoreCard.DataSource = dvScoreCard;
					rptScoreCard.DataBind();
				}
				else
				{					
					rptScoreCard.Visible = false;
					iPrint.Visible = false;
					goBack.Visible = false;
					pnlMessage.Visible = true;
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}
		
		
		#endregion




		public DataRow GetScoreRemarks(DataTable RangeTable, int ExamId)
		{
			DataRow []dr = new DataRow[1];
			dr=RangeTable.Select("EXAMID='" + ExamId + "'","EXAMID",DataViewRowState.CurrentRows );
			if (dr.Length<1)
			{	DataTable dt = new DataTable();
				object[] remarksNA = new object[3];
				dt.Columns.Add("EXAMID" ,typeof(string));
				dt.Columns.Add("ScoreRange" ,typeof(string));
				dt.Columns.Add("Remarks" ,typeof(string));
				
				remarksNA[0]=Convert.ToString(ExamId);
				remarksNA[1]="NA";
				remarksNA[2]="NA";
				dt.Rows.Add(remarksNA);
				return dt.Rows[0];
			}
			return dr[0];
			//	return Convert.ToString(dt.Rows[0]["ScoreRange"]);

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
	}
}