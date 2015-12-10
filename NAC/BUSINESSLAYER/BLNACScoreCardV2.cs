using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; 
using System.Web; 
using ExceptionHandling;
using Common;
using System.IO;
using DataAccessLayer;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLNACScoreCardV2.
	/// </summary>
	public class BLNACScoreCardV2
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);

		public BLNACScoreCardV2()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private DataAccessLayer.DBConnection conn;
		private string strConn;			
		private string strNACRegID;
		private string strCandidateName;
		private string strFirstName;
		private string strMiddleName;
		private string strLastName;
		private DateTime  dtDOB;
		private string strTestLocation;
		private DateTime   dtTestDate;
		private string intPg1AnalyticalRange;
		private string intPg1AnalyticalScore;
		private string intPg1QuantitativeRange;
		private string intPg1QuantitativeScore;
		private string intPg1EWOverallRange;
		private string intPg1EWOverallScore;
		private string intPg1EWGrammarRange;
		private string intPg1EWGrammarScore;
		private string intPg1EWContentRange;
		private string intPg1EWContentScore;
		private string intPg1EWVocabularyRange;
		
		private string strAQRPercentage;
		private string  strAQRPercentile;
		private string intWritingScore;
		private string intWritingMaxScore;
		private string strWritingPercentage;
		private string strWritingPercentile;
		private string intLAScore;
		private string intLAMaxScore;
		private string strLAPercentage;
		private string strLAPercentile;
		private string intListeningScore;
		private string intListeningMaxScore;
		private string strListeningPercentage;
		private string strListeningPercentile;
		private string intKeyboardGrossSpeed;
		private string intKeyboardAccuracy;
		private string intKeyboardNetSpeed;
		private string strKeyboardPercentile;

		private string intSpeakingMaxScore;
		private string intSpeakingVoiceClarity;		
		private string intSpeakingAccent;
		private string intSpeakingFluency;
		private string intSpeakingGrammar;
		private string intSpeakingProsody;
		private string strSpeakingPercentile;

		private string strSpeakingPercentage;
		//		private string strSpeakingVoiceClarityPercentage;		
		//		private string strSpeakingAccentPercentage;
		//		private string strSpeakingFluencyPercentage;
		//		private string strSpeakingGrammarPercentage;
		//		private string strSpeakingProsodyPercentage;

		private string intWritingEssayMaxScore;		
		private string intWritingEssayGrammar;
		private string intWritingEssayContent;
		private string intWritingEssayVocabulary;
		private string intWritingEssaySpelling_Punctuation;
		private string strWritingEssayPercentile;

		private string strWritingEssayPercentage;
		private string strIPAddress;
		private DateTime strfirstclickdate;
	}
}
