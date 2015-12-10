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
using BusinessLayer;


namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for MultipleCertificate.
	/// </summary>
	public partial class MultipleCertificate : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblRegistrationId;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblDob;
		protected System.Web.UI.WebControls.Label lblTestCentre;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Label lblSpeaking;
		protected System.Web.UI.WebControls.Label lblListening;
		protected System.Web.UI.WebControls.Label lblWriting;
		protected System.Web.UI.WebControls.Label lblAnalytical;
		private string strItemList;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		private string strSortExp;

		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
					else
					{
						Response.Redirect("Login.aspx");
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
						Response.Redirect("Login.aspx");
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
				BusinessLayer.BLScoreCard oBLScoreCard = new BLScoreCard();
				DataView dvScoreCard = new DataView();
				DataTable dtMultipleScoreCard = new DataTable();
				dtMultipleScoreCard = (DataTable) (oBLScoreCard.GenerateMultipleScoreCard(strItemList));

				if(dtMultipleScoreCard != null)
				{
					if(dtMultipleScoreCard.Rows.Count > 0)
					{
						   int intIncrementLoop = 0;	
						DataColumn dcSpeaking = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcListening = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcWriting = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcAnalytical = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						dtMultipleScoreCard.Columns.Add("dcSpeaking");
						dtMultipleScoreCard.Columns.Add("dcListening");
						dtMultipleScoreCard.Columns.Add("dcWriting");
						dtMultipleScoreCard.Columns.Add("dcAnalytical");

						for(intIncrementLoop = 0; intIncrementLoop <= dtMultipleScoreCard.Rows.Count -1; intIncrementLoop++)
						{
							if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]) == "0")
							{
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = "Did not appear";
								
							}
							else
							{
								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = "N/A";									 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = "N/A";		
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = "N/A";									 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = "N/A";										 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]);
								}						


							}

						}

						dvScoreCard = dtMultipleScoreCard.DefaultView; 
						dvScoreCard.Sort = strSortExp;						 
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
				DataTable dtMultipleScoreCard = new DataTable();
				dtMultipleScoreCard = (DataTable) (objBLSearch.GenerateAllMultipleScoreCard());

				if(dtMultipleScoreCard != null)
				{
					if(dtMultipleScoreCard.Rows.Count > 0)
					{
						int intIncrementLoop = 0;						   

						DataColumn dcSpeaking = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcListening = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcWriting = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						DataColumn dcAnalytical = new DataColumn(dtMultipleScoreCard.Columns["Speaking"].ColumnName,System.Type.GetType("System.String"));
						dtMultipleScoreCard.Columns.Add("dcSpeaking");
						dtMultipleScoreCard.Columns.Add("dcListening");
						dtMultipleScoreCard.Columns.Add("dcWriting");
						dtMultipleScoreCard.Columns.Add("dcAnalytical");
//						dtMultipleScoreCard.Columns["Speaking"].DataType = System.Type.GetType("System.String");
//						dtMultipleScoreCard.Columns["Listening"].DataType = System.Type.GetType("System.String");
//						dtMultipleScoreCard.Columns["Writing"].DataType = System.Type.GetType("System.String");
//						dtMultipleScoreCard.Columns["Analytical"].DataType = System.Type.GetType("System.String");

						for(intIncrementLoop = 0; intIncrementLoop <= dtMultipleScoreCard.Rows.Count -1; intIncrementLoop++)
						{
							if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]) == "0" && Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]) == "0")
							{
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = "Did not appear";
								dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = "Did not appear";
								
							}
							else
							{
								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = "N/A";									 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcSpeaking"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Speaking"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = "N/A";		
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcListening"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Listening"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = "N/A";									 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcWriting"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Writing"]);
								}

								if(Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]) == "0")
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = "N/A";										 
								}
								else
								{
									dtMultipleScoreCard.Rows[intIncrementLoop]["dcAnalytical"] = Convert.ToString(dtMultipleScoreCard.Rows[intIncrementLoop]["Analytical"]);
								}


							}

						}

						dvScoreCard = dtMultipleScoreCard.DefaultView; 
						dvScoreCard.Sort = strSortExp;						 
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
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
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

		
		 
	}
}
