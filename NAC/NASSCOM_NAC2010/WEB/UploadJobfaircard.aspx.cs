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
	/// Summary description for UploadJobfaircard.
	/// </summary>
	public class UploadJobfaircard : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputFile JobFairCardFile;
		protected System.Web.UI.WebControls.DropDownList ddWorksheet;
		protected System.Web.UI.WebControls.DropDownList ddlState;
		protected System.Web.UI.WebControls.Button btnItemDone;
		protected System.Web.UI.WebControls.Panel pnlBrowseFile;
		
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.Panel pnlSelectSheet;
		protected System.Web.UI.WebControls.TextBox txtHidden;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.WebControls.Label lblImported;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblRowNumber;
		protected System.Web.UI.WebControls.DropDownList ddlDayFrom;
		protected System.Web.UI.WebControls.DropDownList ddlMonthFrom;
		protected System.Web.UI.WebControls.DropDownList ddlYearFrom;
		protected System.Web.UI.WebControls.DropDownList ddlDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlMonthTo;
		protected System.Web.UI.WebControls.DropDownList ddlYearTo;
		protected System.Web.UI.WebControls.DropDownList ddInterviewDay;
		protected System.Web.UI.WebControls.DropDownList ddInterviewMonth;
		protected System.Web.UI.WebControls.DropDownList ddInterviewYear;
		protected System.Web.UI.HtmlControls.HtmlInputFile ScoreCardFile;
		#region Enum

		enum Month
		{
			January,
			February,
			March,
			April,
			May,
			June,
			July,
			August,
			September,
			October,
			November,
			December
		}

		#endregion
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
				FillTestState();
				btnItemDone.Attributes.Add("onclick","return validate('JobFairCardFile');");
				JobFairCardFile.Attributes.Add("onreadystatechange","return ValidateDropDown();");
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
			this.btnItemDone.Click += new System.EventHandler(this.btnItemDone_Click);
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

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

		#region FillTestState()

		private void FillTestState()
		{
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlState, objBLRegistration.FillTestState(),"State","StateId");
		}


		#endregion

		#region Upload Excel File

		private string UploadFile()
		{
			try
			{
				string FileName = "";
				// If file field isn’t empty
				if(JobFairCardFile.PostedFile != null)
				{
					HttpPostedFile oFile = JobFairCardFile.PostedFile;
					int nFileLen = JobFairCardFile.PostedFile.ContentLength;

					// Check file size (mustn’t be 0)
					if (nFileLen == 0)
					{
						return "";
					}

					// Check file extension (must be Xls)
					string Extension = Path.GetExtension(JobFairCardFile.Value).ToLower();
					
					if(Extension == ".xls")
					{
						// Read file into a data stream
						byte[] oData = new Byte[nFileLen];
						oFile.InputStream.Read(oData,0,nFileLen);

						//Forming File Name
						FileName = Path.GetFileNameWithoutExtension(JobFairCardFile.Value) + "_" + DateTime.Now.ToShortDateString().Replace("/","_") + "_" + DateTime.Now.ToShortTimeString().Replace(":","_").Replace(" ","_") + Extension;
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

		#region MonthYear()

		private string MonthYear(string strMonth)
		{
			string strMonthName = null;			 

			switch (strMonth)
			{
				case "01": strMonthName = Month.January.ToString();
					break;
				case "02": strMonthName = Month.February.ToString();
					break;
				case "03": strMonthName = Month.March.ToString();
					break;
				case "04": strMonthName = Month.April.ToString();
					break;
				case "05": strMonthName = Month.May.ToString();
					break;
				case "06": strMonthName = Month.June.ToString();
					break;
				case "07": strMonthName = Month.July.ToString();
					break;
				case "08": strMonthName = Month.August.ToString();
					break;
				case "09": strMonthName = Month.September.ToString();
					break;
				case "10": strMonthName = Month.October.ToString();
					break;
				case "11": strMonthName = Month.November.ToString();
					break;
				case "12": strMonthName = Month.December.ToString();
					break;
			}
			return strMonthName;
		}


		#endregion


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

		private void btnUpload_Click(object sender, System.EventArgs e)
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
				//Initializing BLScoreCard to insert socres of candidates in database.
				
				for(int i=1;i < DtNACData.Columns.Count;i=i+2)
				{
					BLJobFairCard objJobCard = new BLJobFairCard();
					objJobCard.CompanyName 	=  Convert.ToString(DtNACData.Columns[i]).Trim();

					
					objJobCard.FirstJobFairDate=Convert.ToDateTime(Convert.ToDateTime(ddlDayFrom.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlMonthFrom.SelectedValue.ToString().Trim()) + "/" + ddlYearFrom.SelectedValue.ToString().Trim()));
					objJobCard.SecondJobFairDate=Convert.ToDateTime(Convert.ToDateTime(ddlDateTo.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlMonthTo.SelectedValue.ToString().Trim()) + "/" + ddlYearTo.SelectedValue.ToString().Trim()));
					objJobCard.StateId=Convert.ToInt32(ddlState.SelectedValue);

					//Inserting Job Fair card to NASSCOM database
					objJobCard.InsertJobFairCompanydetail();
					objJobCard = null;
					for(int j=0;j < DtNACData.Rows.Count;j++)
					{
						try
						{
							if(Convert.ToString(DtNACData.Rows[j][i]).Trim()!="")
							{
						
								BLJobFairCard objJobCardReg = new BLJobFairCard();
								objJobCardReg.CompanyName 	=  Convert.ToString(DtNACData.Columns[i]).Trim();
								objJobCardReg.RegistrationId=  Convert.ToString(DtNACData.Rows[j][i]).Trim();
								objJobCardReg.StateId=Convert.ToInt32(ddlState.SelectedValue);
								objJobCardReg.Interviewdate=Convert.ToDateTime(Convert.ToDateTime(ddInterviewDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddInterviewMonth.SelectedValue.ToString().Trim()) + "/" + ddInterviewYear.SelectedValue.ToString().Trim()));

								objJobCardReg.Interviewtime=Convert.ToDateTime(DtNACData.Rows[j][i+1].ToString().Trim());

								objJobCardReg.InsertJobFairCardDetail();
								objJobCardReg = null;	
							}
						}
						catch
						{
							continue;
						}
						
					}
								 
						
				}
				lblInfo.Text = "Candidates JobFair Card Imported Successfully!";
			
			}
			catch(Exception ex)
			{
				  
				lblInfo.Text = "Problem in Importing Data from Excel File." + ex;
				//Calling ErrorRoutine of ErrorLogger to write error text in text file.
				ErrorLogger.ErrorRoutine(false,ex);
			}

		}
	}
}
