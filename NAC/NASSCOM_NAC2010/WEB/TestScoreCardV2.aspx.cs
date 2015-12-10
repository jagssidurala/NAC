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
    public partial class TestScoreCardV2 : System.Web.UI.Page
    {
        public string RegistrationId;
        public DataRow dr;
        protected System.Web.UI.WebControls.Image Image1;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationId = Convert.ToString(Request.QueryString["req"]);

            if (!Page.IsPostBack)
            {
                if (RegistrationId != null && RegistrationId != "")
                {
                    GetTestScore();
                }
            }

        }

        private void GetTestScore()
        {
            try
            {
                //Response.Write(Session["UserID"].ToString());
                DataSet dsTestScore = new DataSet();            
               
                BusinessLayer.BLNACScoreCard objTestScore = new BLNACScoreCard();
                dsTestScore = objTestScore.GetTestScoreV2(RegistrationId);



                if (dsTestScore.Tables[0].Rows.Count > 0)
                {
                    //Score Card Logo and Header

                    if (Convert.ToString(dsTestScore.Tables[0].Rows[0]["RegistrationID"]).Trim().StartsWith("NC"))	//NAC-FINAL
                    {
                        imgLogo.ImageUrl = "Images/nac_logo.PNG";     
                        lbldignosticnote.Visible= false;
                     
                    }

                    else		//NAC-Diagnostic
                    {
                        imgLogo.ImageUrl = "Images/NAC-D_Logo.png";
                        lblDiagnostic.Text = "Diagnostic";
                        lbldignosticnote.Visible= true;
                        lbldignosticnote.Text= "NAC Diagnostic Score Report is not meant for employment purposes";
                    }

                    
                    //if (dsCandidteDetails.Tables[0].Rows[0]["RegistrationId"].ToString().StartsWith("ND"))
                    //    lblDiagnostic.Text = "DIAGNOSTIC ";

                    //Registration Detail
                    lblRegistrationId.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["RegistrationID"]).Trim();
                    lblName.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["FullName"]).Trim().ToUpper();
                    lblDOB.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["DOB"].ToString().Trim()));
                    lblTestLocation.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["City"]).Trim();
                    lblTestDate.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dsTestScore.Tables[0].Rows[0]["TestDate"].ToString().Trim()));

                    if (Convert.ToString(dsTestScore.Tables[0].Rows[0]["ImageFileName"]) != "")
                        imgCandidate.ImageUrl = "Controls/Thumbnail.ashx?p=" + Convert.ToString(dsTestScore.Tables[0].Rows[0]["ImageFileName"]);
                    else
                        imgCandidate.ImageUrl = "Controls/Thumbnail.ashx?p=defaultphoto.jpg";


                    //Analytical Ability Test Score
                    lblPg1AnalyticalRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 1);
                    //if(Convert.ToString(dsTestScore.Tables[0].Rows[0]["AnalyticalScore"]).Trim() != "")
                    lblPg1AnalyticalScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["AnalyticalScore"]);
                    //else
                    //lblPg1AnalyticalScore.Text="&nbsp;";

                    //Quantitative Test Score
                    lblPg1QuantitativeRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 2);
                    lblPg1QuantitativeScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["QuantitativeScore"]);

                    //English Writing Test Score

                    lblPg1EWOverallScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["EWOverallScore"]).Trim();
                    lblPg1EWOverallRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 3);
                    lblPg1EWGrammarScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["EWGrammarScore"]);
                    lblPg1EWGrammarRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 4);
                    lblPg1EWContentRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 5);
                    lblPg1EWContentScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["EWContentScore"]);
                    lblPg1EWVocabularyRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 6);
                    lblPg1EWVocabularyScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["EWVocabularyScore"]);
                    lblPg1EWSpellingRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 7);
                    lblPg1EWSpellingScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["EWSpellingScore"]).Trim();


                    //Speaking & Listening Test Score
                    lblPg1SLOverallRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 8);
                    lblPg1SLOverallScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SLOverallScore"]);
                    lblPg1SLSentenceRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 9);
                    lblPg1SLSentenceScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SLSentenceScore"]);
                    lblPg1SLVocabularyRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 10);
                    lblPg1SLVocabularyScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SLVocabularyScore"]);
                    lblPg1SLFluencyRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 11);
                    lblPg1SLFluencyScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SLFluencyScore"]);
                    lblPg1SLPronunciationRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 12);
                    lblPg1SLPronunciationScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["SLPronunciationScore"]);

                    //Keyboard Skills Test Score
                    //lblPg1KSTSpeedRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 13);
                   // lblPg1KSTSpeedScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KSTSpeedScore"]);
                    //lblPg1KSTAccuracyRange.Text = GetScoreRangeForExam(dsTestScore.Tables[1], 14);
                    lblPg1KSTAccuracyRange.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KSTSpeedScore"]);
                    lblPg1KSTAccuracyScore.Text = Convert.ToString(dsTestScore.Tables[0].Rows[0]["KSTAccuracyScore"]);


                }
                else
                {
                    Response.Redirect("TestScoreMessage.aspx", true);
                    return;
                }

                DataSet dsScoreCardRemarks = new DataSet();
                dsScoreCardRemarks = objTestScore.GetScoreCardRemarksV2(Convert.ToString(dsTestScore.Tables[0].Rows[0]["RegistrationID"]).Trim());

                if (dsScoreCardRemarks.Tables[0].Rows.Count > 0)
                {
                    //Analytical Ability Remarks
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 1);
                    lblPg2AnalyticalRange.Text = Convert.ToString(dr[1]);
                    lblPg2AnalyticalRemarks.Text = Convert.ToString(dr[2]);                    

                    //Quantitative Test Score

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 2);
                    lblPg2QuantitativeRange.Text = Convert.ToString(dr[1]);
                    lblPg2QuantitativeRemarks.Text = Convert.ToString(dr[2]);

                    //English Writing Test Score
                    lblPg2EWOverallScore.Text = "(" + lblPg1EWOverallScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 3);
                    lblPg2EWOverallRange.Text = Convert.ToString(dr[1]);
                    lblPg2EWOverallRemarks.Text = Convert.ToString(dr[2]);

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 4);
                    lblPg2EWGrammarRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2EWGrammarRemarks.Text = Convert.ToString(dr[2]);

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 5);
                    lblPg2EWContentRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2EWContentRemarks.Text = Convert.ToString(dr[2]);

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 6);
                    lblPg2EWVocabularyRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2EWVocabularyRemarks.Text = Convert.ToString(dr[2]);

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 7);
                    lblPg2EWSpellingRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2EWSpellingRemarks.Text = Convert.ToString(dr[2]);

                    //Speaking & Listening Test Score
                    lblPg2SLOverallScore.Text = "(" + lblPg1SLOverallScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 8);
                    lblPg2SLOverallRange.Text = Convert.ToString(dr[1]);
                    lblPg2SLOverallRemarks.Text = Convert.ToString(dr[2]);

                    lblPg2SLSentenceScore.Text = "(" + lblPg1SLSentenceScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 9);
                    lblPg2SLSentenceRange.Text = Convert.ToString(dr[1]);
                    lblPg2SLSentenceRemarks.Text = Convert.ToString(dr[2]);

                    lblPg2SLVocabularyScore.Text = "(" + lblPg1SLVocabularyScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 10);
                    lblPg2SLVocabularyRange.Text = Convert.ToString(dr[1]);
                    lblPg2SLVocabularyRemarks.Text = Convert.ToString(dr[2]);

                    lblPg2SLFluencyScore.Text = "(" + lblPg1SLFluencyScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 11);
                    lblPg2SLFluencyRange.Text = Convert.ToString(dr[1]);
                    lblPg2SLFluencyRemarks.Text = Convert.ToString(dr[2]);

                    lblPg2SLPronunciationScore.Text = "(" + lblPg1SLPronunciationScore.Text + ")";
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 12);
                    lblPg2SLPronunciationRange.Text = Convert.ToString(dr[1]);
                    lblPg2SLPronunciationRemarks.Text = Convert.ToString(dr[2]);

                    //Keyboard Skills Test Score
                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 13);

                    if (Convert.ToString(dr[1]).EndsWith("999"))
                        lblPg2KSTSpeedRange.Text = "(" + Convert.ToString(dr[1]).Substring(0, 2) + " and " + "above)";
                    else
                        lblPg2KSTSpeedRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2KSTSpeedRemarks.Text = Convert.ToString(dr[2]);

                    dr = GetScoreRemarks(dsScoreCardRemarks.Tables[0], 14);
                    lblPg2KSTAccuracyRange.Text = "(" + Convert.ToString(dr[1]) + ")";
                    lblPg2KSTAccuracyRemarks.Text = Convert.ToString(dr[2]);


                }
                else
                {
                    Response.Redirect("TestScoreMessage.aspx", true);
                }



            }
            catch (Exception SysEx)
            {

                ErrorLogger.ErrorRoutine(false, SysEx);
                //To Pass Execption in exception class for show exception
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);

            }
        }

        public string GetScoreRangeForExam(DataTable RangeTable, int ExamId)
        {
            DataRow[] dr = new DataRow[1];
            dr = RangeTable.Select("EXAMID='" + ExamId + "'", "EXAMID", DataViewRowState.CurrentRows);
            return Convert.ToString(dr[0]["ScoreRange"]);
            //	return Convert.ToString(dt.Rows[0]["ScoreRange"]);

        }

        public DataRow GetScoreRemarks(DataTable RangeTable, int ExamId)
        {
            DataRow[] dr = new DataRow[1];
            dr = RangeTable.Select("EXAMID='" + ExamId + "'", "EXAMID", DataViewRowState.CurrentRows);
            return dr[0];         

        }

    }
}