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

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for UpdateCandidate.
	/// </summary>
	public class UpdateCandidate : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnItemDone;
		protected System.Web.UI.WebControls.Panel pnlBrowseFile;
		protected System.Web.UI.WebControls.DropDownList ddWorksheet;
		protected System.Web.UI.WebControls.Panel pnlSelectSheet;
		protected System.Web.UI.WebControls.TextBox txtHidden;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.Label lblImported;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblRowNumber;
		protected System.Web.UI.HtmlControls.HtmlInputFile CandidateInfo;
		protected System.Web.UI.WebControls.Button btnUpdate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			lblError.Visible = false;
			lblImported.Visible = false;
			lblRowNumber.Visible = false;
			lblTotal.Visible = false;
			btnUpload.Attributes.Add("onclick","return validateWorksheet();");

			if(!Page.IsPostBack)
			{				
				
				pnlSelectSheet.Visible = false;
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnItemDone.Click += new System.EventHandler(this.btnItemDone_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Update_Click()

		private void btnUpdate_Click(object sender, System.EventArgs e)
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

				if (DtNACData.Columns.Count == 33)
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
						
							objScoreCard.NACRegID	=row[1].ToString().Trim(); 
							objScoreCard.FirstName	= row[2].ToString().Trim(); 
							objScoreCard.MiddleName	= row[3].ToString().Trim(); 	
							objScoreCard.LastName	= row[4].ToString().Trim(); 	
							objScoreCard.DOB	= Convert.ToDateTime(row[5].ToString().Trim()); 						
						
											 
							//Inserting Candidate score card to NASSCOM database
							objScoreCard.UpdateCandidateInfo();
								 
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

		#region ItemDone_Click()

		private void btnItemDone_Click(object sender, System.EventArgs e)
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
	}
}
