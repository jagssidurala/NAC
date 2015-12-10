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
	/// Summary description for BLGenerateTestScoreV2.
	/// </summary>
	public class BLGenerateTestScoreV2
	{
		string RegistrationId;
		string Name;
		string Dob;
		string TestDate;
		string Pg1AnalyticalRange;
		string Pg1AnalyticalScore;
		string Pg1QuantitativeRange;
		string Pg1QuantitativeScore;
		string Pg1EWOverallRange;
		string Pg1EWOverallScore;
		string Pg1EWGrammarRange;
		string Pg1EWGrammarScore;
		string Pg1EWContentRange;
		string Pg1EWContentScore;
		string Pg1EWVocabularyRange;
		string Pg1EWVocabularyScore;
		string Pg1EWSpellingRange;
		string Pg1EWSpellingScore;
		string Pg1SLOverallRange;
		string Pg1SLOverallScore;
		string Pg1SLSentenceRange;
		string Pg1SLSentenceScore;
		string Pg1SLVocabularyRange;
		string Pg1SLVocabularyScore;
		string Pg1SLFluencyRange;
		string Pg1SLFluencyScore;
		string Pg1SLPronunciationRange;
		string Pg1SLPronunciationScore;
		string Pg1KSTSpeedRange;
		string Pg1KSTSpeedScore;
		string Pg1KSTAccuracyRange;
		string Pg1KSTAccuracyScore;
		string Pg2AnalyticalRangeCard;
		string Pg2QuantitativeRange;
		string Pg2EWGrammarRange;
		string Pg2EWContentRange;
		string Pg2EWVocabularyRange;
		string Pg2EWSpellingRange;
		string Pg2AnalyticalRemarks;
		string Pg2QuantitativeRemarks;
		string Pg2EWOverallRemarks;
		string Pg2EWGrammarRemarks;
		string Pg2EWContentRemarks;
		string Pg2EWVocabularyRemarks;
		string Pg2SLPronunciationScore;
		string Pg2SLOverallRemarks;
		string Pg2KSTAccuracyRemarks;
		string Pg2AnalyticalRange;
		string Pg2EWOverallScore;
		string Pg2EWOverallRange;
		string Pg2EWSpellingRemarks;
		string Pg2KSTSpeedRange;
		string Pg2KSTSpeedRemarks;
		string Pg2KSTAccuracyRange;
		string Pg2SLOverallScore;
		string Pg2SLOverallRange;
		string Pg2SLSentenceScore;
		string Pg2SLSentenceRange;
		string Pg2SLSentenceRemarks;
		string Pg2SLVocabularyScore;
		string Pg2SLVocabularyRange;
		string Pg2SLVocabularyRemarks;
		string Pg2SLFluencyScore;
		string Pg2SLFluencyRange;
		string Pg2SLFluencyRemarks;
		string Pg2SLPronunciationRange;
		string Pg2SLPronunciationRemarks;
		string TestLocation;

		public BLGenerateTestScoreV2()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
	}
}
