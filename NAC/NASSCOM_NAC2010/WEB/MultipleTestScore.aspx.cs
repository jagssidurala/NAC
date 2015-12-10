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
	/// Summary description for MultipleTestScore.
	/// </summary>
	public partial class MultipleTestScore : System.Web.UI.Page
	{
//		protected System.Web.UI.HtmlControls.HtmlImage imgWatermark; 
		private string strItemList;
		protected System.Web.UI.HtmlControls.HtmlImage imgWatermark;
		private string strSortExp;
//		public string strDivStyle;
		public string stateName;
	
		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// Put user code to initialize the page here
			try
			{
//				string strUserAgent = Request.UserAgent.ToString().ToLower();			 
//
//				if(strUserAgent.IndexOf("msie 6.0") != -1)
//				{
//					strDivStyle = "ImgPosition5";
//
//					imgWatermark.Src = "Images/NAC_Stamp_bg6.gif";
//				}
//				else
//				{
//					strDivStyle = "ImgPosition6";
//					imgWatermark.Src = "Images/NAC_Stamp_bg.gif";
//				} 

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
				dtMultipleScoreCard = (DataTable) (oBLScoreCard.GenerateMultipleScoreCard_MTFormat(strItemList));

				if(dtMultipleScoreCard != null)
				{
					if(dtMultipleScoreCard.Rows.Count > 0)
					{				
						stateName=dtMultipleScoreCard.Rows[0]["state"].ToString().Trim();
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
				dtMultipleScoreCard = (DataTable) (objBLSearch.GenerateAllMultipleScoreCard_MTFormat());

				if(dtMultipleScoreCard != null)
				{
					if(dtMultipleScoreCard.Rows.Count > 0)
					{
						stateName=dtMultipleScoreCard.Rows[0]["state"].ToString().Trim();
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
