using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Reflection; 
using System.Text;
using BusinessLayer;
using ExceptionHandling;



#region NASSCOM_NAC.Web

namespace NASSCOM_NAC.Web
{
	#region UploadScoreCard
	/// <summary>
	/// Summary description for UploadScore.
	/// </summary>
	public partial class UploadScoreCard : System.Web.UI.Page
	{

		#region WebControls


		public string strReasonOfRejection = null;
	 

		#endregion	

		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//Adding attribute to validate Excel file through JavaScript.			
           
			lblError.Visible = false;
			lblImported.Visible = false;
			lblRowNumber.Visible = false;
			lblTotal.Visible = false;
			btnUpload.Attributes.Add("onclick","return validateWorksheet();");
			//			btnSubmit.Attributes.Add("onclick","return validateComment();");

			if(!Page.IsPostBack)
			{
				
				btnItemDone.Attributes.Add("onclick","return validate('ScoreCardFile');");				
				pnlSelectSheet.Visible = false;
			}

		}


		#endregion		

		#region BindDropDown()
		/// <summary>
		/// Bind a DropDown with data table.
		/// </summary>
		/// <param name="ddlDropDownList" Type="Input"></param>
		/// <param name="dtDataTable"></param>
		/// <param name="strTextField"></param> 
		/// <param name="strValueField"></param>     
		private void BindDropDown(ref DropDownList ddlDropDownList, System.Data.DataTable dtDataTable, string strTextField, string strValueField)
		{

			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

		}

		#endregion

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

		#region Upload_Click()

		/// <summary>
		/// Handles the Click event of the Upload control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Upload_Click(object sender, System.EventArgs e)
		{
			 

			try
			{
				//Declaring local variable to keep connectionstring.
				String strconn = null;
				//Declaring connection object.
				OleDbConnection objConn = null;
				//Initializing strconn with connectionstring.
				strconn =  "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+ txtHidden.Text +"; Extended Properties=Excel 8.0;";
				//Initializing connection object.
				objConn = new OleDbConnection(strconn);
				//Opening connection.
				objConn.Open();
				//Initializing sql string to keep query for command object.
				string sql = "SELECT * FROM [" + ddWorksheet.SelectedItem.Value +"]";
				//Initializing command object.
				OleDbCommand objcmd = new OleDbCommand(sql,objConn);
				//Initaializing OleDBDataAdaptor.
				OleDbDataAdapter objAdapter = new OleDbDataAdapter(objcmd);
				//Declaring and initializing DataTable.
				System.Data.DataTable DtNACData = new System.Data.DataTable();   
				//Puting selected data in Dataset.
				objAdapter.Fill(DtNACData);		
				//Closing connection.
				objConn.Close();

				string SNO_Lost="";
				int CounterTotal = 0;
				int CounterImported = 0;
				int CounterLost = 0;
				string tempSNO = "";

				if (DtNACData.Columns.Count == 24)
				{
					foreach(DataRow row in DtNACData.Rows)
					{

						//To bypass top headers rows
						if (row==DtNACData.Rows[0])
							continue;
						
						if (row==DtNACData.Rows[1])
							continue;
							 
						try
						{
							

							//Initializing BLScoreCard to insert socres of candidates in database.
							BLNACScoreCard  objScoreCard = new BLNACScoreCard();		        	
						
							objScoreCard.NACRegID	=row[0].ToString().Trim(); 
							//objScoreCard.CandidateName	= row[2].ToString().Trim(); 	
							//objScoreCard.DOB	= Convert.ToDateTime(row[3].ToString().Trim()); 	
							//objScoreCard.TestLocation	= row[4].ToString().Trim(); 		
							//objScoreCard.TestDate	= Convert.ToDateTime(row[5].ToString().Trim()); 		


							if(System.DBNull.Value.Equals(row[1])|| row[1].ToString().Trim()=="NA")
							{ 			
								objScoreCard.AQRScore	= "NA"; 	
							}
							else
							{ 
								objScoreCard.AQRScore	= row[1].ToString().Trim(); 	
							}			
			
							objScoreCard.AQRMaxScore	= txtAQRMaxScore.Text; 

							if(System.DBNull.Value.Equals(row[2])|| row[2].ToString().Trim()=="NA")
							{ 							
								objScoreCard.AQRPercentage	= "NA"; 							
							}
							else
							{
								objScoreCard.AQRPercentage	= row[2].ToString().Trim();						
							}

//							if(System.DBNull.Value.Equals(row[8])|| row[8].ToString().Trim()=="NA")
//							{ 					
//								objScoreCard.AQRPercentile	= "NA"; 		
//							}
//							else
//							{ 							
//								objScoreCard.AQRPercentile	=  PercentageConverter(Convert.ToDouble(row[8])); 
//							}

							if(System.DBNull.Value.Equals(row[3])|| row[3].ToString().Trim()=="NA")
							{ 						
								objScoreCard.WritingScore	= "NA"; 	
							}
							else
							{ 					
								objScoreCard.WritingScore	= row[3].ToString().Trim(); 	
							}
							objScoreCard.WritingMaxScore	= txtWritingMaxScore.Text; 


							if(System.DBNull.Value.Equals(row[4])|| row[4].ToString().Trim()=="NA")
							{ 			
								objScoreCard.WritingPercentage	= "NA"; 				
							}
							else
							{ 					
								objScoreCard.WritingPercentage	=  row[4].ToString().Trim();
							}

//							if(System.DBNull.Value.Equals(row[11])|| row[11].ToString().Trim()=="NA")
//							{ 					
//								objScoreCard.WritingPercentile	= "NA"; 			
//							}
//							else
//							{ 				
//								objScoreCard.WritingPercentile	=  PercentageConverter(Convert.ToDouble(row[11])); 
//							}

							if(System.DBNull.Value.Equals(row[5])|| row[5].ToString().Trim()=="NA")
							{ 						
								objScoreCard.LAScore	= "NA"; 					
							}
							else
							{ 				
								objScoreCard.LAScore	= row[5].ToString().Trim(); 	
							}

							objScoreCard.LAMaxScore	= txtLearningMaxScore.Text; 
					


							if(System.DBNull.Value.Equals(row[6])|| row[6].ToString().Trim()=="NA")
							{ 					
								objScoreCard.LAPercentage	= "NA"; 	
							}
							else
							{ 						
								objScoreCard.LAPercentage	=  row[6].ToString().Trim();
							}

//							if(System.DBNull.Value.Equals(row[14])|| row[14].ToString().Trim()=="NA")
//							{ 						
//								objScoreCard.LAPercentile	= "NA"; 			
//							}
//							else
//							{ 						
//								objScoreCard.LAPercentile	=  PercentageConverter(Convert.ToDouble(row[14])); 
//							}

							if(System.DBNull.Value.Equals(row[7])|| row[7].ToString().Trim()=="NA")
							{ 						
								objScoreCard.ListeningScore	= "NA"; 		
							}
							else
							{ 					
								objScoreCard.ListeningScore	= row[7].ToString().Trim(); 
							}

							objScoreCard.ListeningMaxScore	= txtListeningMaxScore.Text;  		


							if(System.DBNull.Value.Equals(row[8])|| row[8].ToString().Trim()=="NA")
							{ 					
								objScoreCard.ListeningPercentage	= "NA"; 		
							}
							else
							{ 						
								objScoreCard.ListeningPercentage	=  row[8].ToString().Trim();
							}

//							if(System.DBNull.Value.Equals(row[17])|| row[17].ToString().Trim()=="NA")
//							{ 					
//								objScoreCard.ListeningPercentile	= "NA"; 			
//							}
//							else
//							{ 					
//								objScoreCard.ListeningPercentile	=  PercentageConverter(Convert.ToDouble(row[17])); 
//							}

							if(System.DBNull.Value.Equals(row[9])|| row[9].ToString().Trim()=="NA")
							{ 						
								objScoreCard.KeyboardGrossSpeed	= "NA"; 				
							}
							else

							{ 					
								objScoreCard.KeyboardGrossSpeed	= row[9].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[10])|| row[10].ToString().Trim()=="NA")
							{ 					
								objScoreCard.KeyboardAccuracy	= "NA"; 				
							}
							else
							{ 				
								objScoreCard.KeyboardAccuracy	= row[10].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[11])|| row[11].ToString().Trim()=="NA")
							{ 					
								objScoreCard.KeyboardNetSpeed	= "NA"; 		
							}
							else
							{ 				
								objScoreCard.KeyboardNetSpeed	= row[11].ToString().Trim(); 	
							}

//							if(System.DBNull.Value.Equals(row[21])|| row[21].ToString().Trim()=="NA")
//							{ 		
//								objScoreCard.KeyboardPercentile	= "NA"; 	
//							}
//							else
//							{ 					
//								objScoreCard.KeyboardPercentile	= PercentageConverter(Convert.ToDouble(row[21])); 
//							}

							if(System.DBNull.Value.Equals(row[12])|| row[12].ToString().Trim()=="NA")
							{ 					
								objScoreCard.SpeakingVoiceClarity	= "NA"; 		
							}
							else
							{ 					
								objScoreCard.SpeakingVoiceClarity	= row[12].ToString().Trim(); 
							}
							objScoreCard.SpeakingMaxScore	=txtSpeakingMaxScore.Text; 


							if(System.DBNull.Value.Equals(row[13])|| row[13].ToString().Trim()=="NA")
							{ 	
								objScoreCard.SpeakingAccent	= "NA"; 			
							}
							else
							{ 					
								objScoreCard.SpeakingAccent	= row[13].ToString().Trim(); 
							}

							if(System.DBNull.Value.Equals(row[14])|| row[14].ToString().Trim()=="NA")
							{ 					
								objScoreCard.SpeakingFluency	= "NA"; 	
							}
							else
							{ 					
								objScoreCard.SpeakingFluency	= row[14].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[15])|| row[15].ToString().Trim()=="NA")
							{ 		
								objScoreCard.SpeakingGrammar	= "NA"; 
							}
							else
							{ 			
								objScoreCard.SpeakingGrammar	= row[15].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[16])|| row[16].ToString().Trim()=="NA")
							{ 			
								objScoreCard.SpeakingProsody	= "NA"; 	
							}
							else
							{ 					
								objScoreCard.SpeakingProsody	= row[16].ToString().Trim(); 
							}

							if(System.DBNull.Value.Equals(row[17])|| row[17].ToString().Trim()=="NA")
							{
								objScoreCard.SpeakingPercentage	= "NA"; 						
							}
							else
							{
								objScoreCard.SpeakingPercentage	=  row[17].ToString().Trim(); 
							}

//							if(System.DBNull.Value.Equals(row[27])|| row[27].ToString().Trim()=="NA")
//							{
//								objScoreCard.SpeakingPercentile	= "NA"; 						
//							}
//							else
//							{
//								objScoreCard.SpeakingPercentile	=  PercentageConverter(Convert.ToDouble(row[27])); 
//							}

							if(System.DBNull.Value.Equals(row[18])|| row[18].ToString().Trim()=="NA")
							{
								objScoreCard.WritingEssayGrammar	= "NA";
							}
							else
							{
								objScoreCard.WritingEssayGrammar	= row[18].ToString().Trim(); 						
							}

							objScoreCard.WritingEssayMaxScore	= txtWritingEssayMaxScore.Text; 


							if(System.DBNull.Value.Equals(row[19])|| row[19].ToString().Trim()=="NA")
							{ 				
								objScoreCard.WritingEssayContent	= "NA"; 		
							}
							else
							{ 				
								objScoreCard.WritingEssayContent	= row[19].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[20])|| row[20].ToString().Trim()=="NA")
							{ 					
								objScoreCard.WritingEssayVocabulary	= "NA"; 	
							}
							else
							{ 				
								objScoreCard.WritingEssayVocabulary	= row[20].ToString().Trim(); 	
							}

							if(System.DBNull.Value.Equals(row[21])|| row[21].ToString().Trim()=="NA")
							{ 		
								objScoreCard.WritingEssaySpelling_Punctuation	= "NA"; 
							}
							else
							{ 			
								objScoreCard.WritingEssaySpelling_Punctuation	= row[21].ToString().Trim(); 
							}

							if(System.DBNull.Value.Equals(row[22])|| row[22].ToString().Trim()=="NA")
							{ 						
								objScoreCard.WritingEssayPercentage	= "NA";	
							}
							else
							{ 					
								objScoreCard.WritingEssayPercentage	=  row[22].ToString().Trim();
							}

//							if(System.DBNull.Value.Equals(row[32])|| row[32].ToString().Trim()=="NA")
//							{ 						
//								objScoreCard.WritingEssayPercentile	= "NA";	
//							}
//							else
//							{ 					
//								objScoreCard.WritingEssayPercentile	=  PercentageConverter(Convert.ToDouble(row[32])); 
//							}

							if(System.DBNull.Value.Equals(row[23])|| row[23].ToString().Trim()=="NA")
							{ 						
								objScoreCard.TierInfo = "NA";	
							}
							else
							{ 					
								objScoreCard.TierInfo=  row[23].ToString().Trim(); 	 
							}
												 
							//Inserting Candidate score card to NASSCOM database
							objScoreCard.InsertScore();
								 
							objScoreCard = null;								 
							CounterImported++;
						}
						catch(Exception ex)
						{
							SNO_Lost += tempSNO +  ";";
							CounterLost++;								
							continue;
						}
						CounterTotal++;
					}
					//Displaying "Candidates Score Imported Successfully!", if data has been successfully inserted.
					lblInfo.Text = "Candidates Score Imported Successfully!";						 					
					lblTotal.Visible = true;
					lblImported.Visible = true;
					lblError.Visible = true;
					lblTotal.Text = "Read: " + CounterTotal;
					lblImported.Text = "Imported: " + CounterImported;
					lblError.Text = "Error: " + CounterLost;				
					if(SNO_Lost.Length != 0)
					{
						lblRowNumber.Visible = true;
						lblRowNumber.Text = "Errorneous Records RegistrationID: " + SNO_Lost;
					}
					pnlSelectSheet.Visible = false;
					pnlBrowseFile.Visible = false;
				}
				else
				{
					lblInfo.Text = "Excel Sheet is not well formatted";
				}
			}
			catch(Exception ex)
			{
				  
				lblInfo.Text = "Problem in Importing Data from Excel File." + ex;
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}
		
		}


		#endregion		

		#region Upload Excel File

		private string UploadFile()
		{
			try
			{
				string FileName = "";
				// If file field isn’t empty
				if(ScoreCardFile.PostedFile != null)
				{
					HttpPostedFile oFile = ScoreCardFile.PostedFile;
					int nFileLen = ScoreCardFile.PostedFile.ContentLength;

					// Check file size (mustn’t be 0)
					if (nFileLen == 0)
					{
						return "";
					}

					// Check file extension (must be Xls)
					string Extension = Path.GetExtension(ScoreCardFile.Value).ToLower();
					
					if(Extension == ".xls")
					{
						// Read file into a data stream
						byte[] oData = new Byte[nFileLen];
						oFile.InputStream.Read(oData,0,nFileLen);

						//Forming File Name
						FileName = Path.GetFileNameWithoutExtension(ScoreCardFile.Value) + "_" + DateTime.Now.ToShortDateString().Replace("/","_") + "_" + DateTime.Now.ToShortTimeString().Replace(":","_").Replace(" ","_") + Extension;
						string Destination = Server.MapPath("UploadFiles/" + FileName);

						// Save the stream to disk
						FileStream oFileStream = new FileStream(Destination,FileMode.Create);
						oFileStream.Write(oData,0,oData.Length);
						oFileStream.Close();
					}
					else
					{
						return FileName;
					}	
				}
				return Server.MapPath("UploadFiles/" + FileName);
			}
			catch(Exception oException)
			{
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,oException);
				ELExceptionHandler.ProcessErrorWithPageThrow(oException);
				return "";
			}
		}


		#endregion

		#region ItemDone_Click()

		protected void ItemDone_Click(object sender, System.EventArgs e)
		{

			try
			{
				
				 
				String strconn = null;
				OleDbConnection objConn = null;				
 
				System.Data.DataTable DtNACData =null;

				//hidden.Value = NACFile.Value;
				txtHidden.Text = UploadFile();
				
				//Initializing connection string.
				strconn =  "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+ txtHidden.Text +"; Extended Properties=Excel 8.0;";
			 
				objConn = new OleDbConnection(strconn);
				//Opening connection.
				objConn.Open();
				 
				//Initializing DtNACData(DataTable) with current structure of table, which is existing in connection.
				DtNACData = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
				if(DtNACData==null)
				{
					lblInfo.Text = "Unable to open Excel File";
					return ;
				}

 
				ListItem Item;
				Item = new ListItem("Select","");
				ddWorksheet.Items.Add(Item);

				foreach(DataRow row in DtNACData.Rows)
				{
					//Inserting values of DtNACData (DataTable) in Item (ListItem).
					Item = new ListItem(row["TABLE_NAME"].ToString().Replace("$",""),row["TABLE_NAME"].ToString());
					ddWorksheet.Items.Add(Item);
 
				}
 
				//Binding ddWorksheet (DropDownList) with Item.
				ddWorksheet.DataBind();
				//Closing connection.
				objConn.Close();
				pnlSelectSheet.Visible = true;
				pnlBrowseFile.Visible = false;
				
				DtNACData.Dispose();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				lblInfo.Text = "Problem in opening Excel file.";
			}	
		}


		#endregion

		#region btnSubmit_ServerClick()
		
		private void btnSubmit_ServerClick(object sender, System.EventArgs e)
		{
			
			 

		}


		#endregion

		
		private string PercentageConverter(double dblScore )
		{
			string strScorePercent;			
			strScorePercent=Convert.ToString(Math.Round(dblScore*100,2));
			return strScorePercent;			
//
//			if(dblScore==1) //If candidate score full marks then return 100%
//			{
//				return strScorePercent;
//			}
//			else
//			{
//				return strScorePercent; 	
//			}
		}

	}

	#endregion
}


#endregion
