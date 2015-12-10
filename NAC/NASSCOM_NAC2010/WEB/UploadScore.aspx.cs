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
	#region UploadScore
	/// <summary>
	/// Summary description for UploadScore.
	/// </summary>
	public partial class UploadScore : System.Web.UI.Page
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
				FillTestState();
				btnItemDone.Attributes.Add("onclick","return validate('ScoreCardFile');");
				ScoreCardFile.Attributes.Add("onreadystatechange","return ValidateDropDown();");
				pnlSelectSheet.Visible = false;
			}

		}


		#endregion

		#region FillTestState()

		private void FillTestState()
		{
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlState, objBLRegistration.FillTestState(),"State","StateId");
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

					if (DtNACData.Columns.Count == 16)
					{
						foreach(DataRow row in DtNACData.Rows)
						{
							 
							try
							{
								//Initializing BLScoreCard to insert socres of candidates in database.
							    BLScoreCard objScoreCard = new BLScoreCard();		        
								objScoreCard.RegistrationId		=  Convert.ToString(row[0]).Trim();
								tempSNO = Convert.ToString(row[0]).Trim();
								objScoreCard.TestCentreCode		=  Convert.ToString(row[1]).Trim();
								//objScoreCard.Name				=  row[3].ToString().Trim();
								objScoreCard.AdminDOB			=  Convert.ToDateTime(row[2].ToString().Trim());
								//objScoreCard.DOB				= Convert.ToDateTime(row[4].ToString().Trim());
								//objScoreCard.Gender				=  Convert.ToInt32(row[5].ToString().Trim());
								//objScoreCard.Residency			=  Convert.ToInt32(row[6].ToString().Trim());
								//objScoreCard.Education			=  Convert.ToInt32(row[7].ToString().Trim());
								//objScoreCard.Employeement		=  Convert.ToInt32(row[8].ToString().Trim());
								
								//objScoreCard.MediumInstructions = Convert.ToInt32 (row[9].ToString().Trim());
								objScoreCard.FormCode			=  row[10].ToString().Trim();

							 
								if(System.DBNull.Value.Equals(row[11]))
								{
									objScoreCard.Analytical	= 0;
								}
								else
								{
								    objScoreCard.Analytical	= Convert.ToInt32(row[11].ToString().Trim());
								}
								
								 
								if(System.DBNull.Value.Equals(row[12]))
								{
									objScoreCard.Listening	= 0;
								}
								else
								{
									objScoreCard.Listening	= Convert.ToInt32(row[12].ToString().Trim());
								}
								
								if(System.DBNull.Value.Equals(row[13]))
								{
									objScoreCard.Writing	= 0;
								}
								else
								{
									objScoreCard.Writing	= Convert.ToInt32(row[13].ToString().Trim());
								}

								if(System.DBNull.Value.Equals(row[14]))
								{
									objScoreCard.Speaking	= 0;
								}
								else
								{
									objScoreCard.Speaking	= Convert.ToInt32(row[14].ToString().Trim());
								}								 
								
								objScoreCard.Group				=  Convert.ToString(row[15]).Trim();								
								objScoreCard.StateId			= Convert.ToInt32(ddlState.SelectedValue.ToString().Trim());
								 
								
								//Inserting Candidate score card to NASSCOM database
								objScoreCard.InsertScore();
								 
								objScoreCard = null;								 
								CounterImported++;
							}
							catch
							{
								SNO_Lost += tempSNO +  ";";
								CounterLost++;								
								continue;
							}
							CounterTotal++;
						}
						//Displaying "Candidates Score Imported Successfully!", if data has been successfully inserted.
						lblInfo.Text = "Candidates Score Imported Successfully!";						 
						//Update upload status in database.
						if(Convert.ToInt32(Session["UserType"]) == 3)
						{							
							ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
							objScoreOverwrite.StateId = Convert.ToInt32(ddlState.SelectedValue.ToString().Trim());
							objScoreOverwrite.StateName = Convert.ToString(ddlState.SelectedItem.ToString().Trim());
							objScoreOverwrite.UserId = Convert.ToInt32(Session["UserID"]);
							objScoreOverwrite.UserName = Convert.ToString(Session["UserName"]);
							objScoreOverwrite.UserType = Convert.ToInt32(Session["UserType"]);
							objScoreOverwrite.ChnageUploadStatusByETS();
						}
						else
						{
							ScoreOverwrite objScoreOverwrite = new ScoreOverwrite();
							objScoreOverwrite.StateId = Convert.ToInt32(ddlState.SelectedValue.ToString().Trim());
							objScoreOverwrite.StateName = Convert.ToString(ddlState.SelectedItem.ToString().Trim());
							objScoreOverwrite.UserId = Convert.ToInt32(Session["UserID"]);
							objScoreOverwrite.UserName = Convert.ToString(Session["UserName"]);	
							objScoreOverwrite.UserType = Convert.ToInt32(Session["UserType"]);
							objScoreOverwrite.ChnageUploadStatusByAdmin();
						}
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

		#region ValidateScoreForState()

		private bool ValidateScoreForState(int intStateId)
		{
		     BLScoreCard objBLScoreCard = new BLScoreCard();
			 return objBLScoreCard.ValidateScoreForState(intStateId);
		}

		#endregion

		#region CheckForApproval(intStateId,intUserId)

		private int CheckForApproval(int intStateId, int intUserId)
		{
			BLScoreCard objBLScoreCard = new BLScoreCard();
			return objBLScoreCard.CheckForApproval(intStateId, intUserId);
		}

		#endregion
		
		#region GetResonOfRejection(intStateId)

			private string GetResonOfRejection(int intStateId)
			{
				BLScoreCard objBLScoreCard = new BLScoreCard();
				return objBLScoreCard.GetResonOfRejection(intStateId);
			}

		#endregion

		#region ddlState_SelectedIndexChanged()

		protected void ddlState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  
			int intStateId = Convert.ToInt32(ddlState.SelectedValue.ToString().Trim());
			int intUserId = Convert.ToInt32(Session["UserId"]);
			int intUserType = Convert.ToInt32(Session["UserType"]);
			int intApprovalStage = 3;

			if(ValidateScoreForState(intStateId))
			{
				if(Convert.ToInt32(Session["UserType"]) == 3)
				{
					intApprovalStage = CheckForApproval(intStateId,intUserId);
					if(intApprovalStage == 0)
					{
						btnItemDone.Attributes.Remove("onclick");				 
						btnItemDone.Attributes.Add("onclick","return validateETSScoreCardForState('ScoreCardFile');");	
					}
					else if(intApprovalStage == 1)
					{
						btnItemDone.Attributes.Remove("onclick");				 
						btnItemDone.Attributes.Add("onclick","return validatePendingForApproval('ScoreCardFile');");						
					}
					else if(intApprovalStage == 2)
					{
						btnItemDone.Attributes.Remove("onclick");				 
						btnItemDone.Attributes.Add("onclick","return validate('ScoreCardFile');");						
					}
					else if (intApprovalStage == 3)
					{
						strReasonOfRejection = GetResonOfRejection(intStateId);
						btnItemDone.Attributes.Remove("onclick");				 
						btnItemDone.Attributes.Add("onclick","return validateRequestRejected('ScoreCardFile');");
						
					}
					else if (intApprovalStage == 4)
					{
						btnItemDone.Attributes.Remove("onclick");				 
						btnItemDone.Attributes.Add("onclick","return validateAgainNeedRequest('ScoreCardFile');");	
					}
					else
					{
						btnItemDone.Attributes.Remove("onclick");
						btnItemDone.Attributes.Add("onclick","return validate('ScoreCardFile');");
					}
								
				}
				else
				{
					btnItemDone.Attributes.Remove("onclick");				 
					btnItemDone.Attributes.Add("onclick","return validateScoreCardForState('ScoreCardFile');");				
				}
				
			}
			else
			{
				btnItemDone.Attributes.Remove("onclick");
				btnItemDone.Attributes.Add("onclick","return validate('ScoreCardFile');");
			}
		}


		#endregion

		#region btnSubmit_ServerClick()
		
		private void btnSubmit_ServerClick(object sender, System.EventArgs e)
		{
			
			 

		}


		#endregion

	}

	#endregion
}


#endregion
