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
	/// Summary description for MultipuleJobFairCard.
	/// </summary>
	public partial class MultipuleJobFairCard_MT : System.Web.UI.Page
	{
		private string strItemList;
		private string strSortExp;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			try
			{
				if(Request.QueryString["SearchType"] != null)
				{
					if(Request.QueryString["SearchType"] == "full"  && Session["SortExp"] != null)
					{

						BLSearch objBLSearch = new BLSearch();
						objBLSearch = (BLSearch)Session["SearchObject"];
						strSortExp = Session["SortExp"].ToString();
						CreateAllMultipleJobFairCard(objBLSearch,strSortExp);
						 				
					  
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
						CreateMultipleJobFairCard(strItemList,strSortExp);
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

		#region CreateMultipleJobFairCard()

		private void CreateMultipleJobFairCard(string strItemList, string strSortExp)
		{
			try
			{
				BusinessLayer.BLScoreCard oBLScoreCard = new BLScoreCard();
				DataView dvJobFairCard = new DataView();
				dvJobFairCard = oBLScoreCard.GenerateMultipleScoreCardforJobCard_MT(strItemList).DefaultView; 
				dvJobFairCard.Sort = strSortExp;				

				if(dvJobFairCard.Count > 0)
				{
					rptMultJobCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptMultJobCard.DataSource = dvJobFairCard;
					rptMultJobCard.DataBind();
				}
				else
				{					
					rptMultJobCard.Visible = false;
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

		#region CreateAllMultipleJobFairCard()

		private void CreateAllMultipleJobFairCard(BLSearch objBLSearch, string strSortExp)
		{
			try
			{				
				DataView dvJobFairCard = new DataView();
				dvJobFairCard = objBLSearch.GenerateAllMultipleJobAdmitCard_MT().Tables[0].DefaultView; 
				dvJobFairCard.Sort = strSortExp;				

				if(dvJobFairCard.Count > 0)
				{
					rptMultJobCard.Visible = true;
					iPrint.Visible = true;
					goBack.Visible = true;
					pnlMessage.Visible = false;
					rptMultJobCard.DataSource = dvJobFairCard;
					rptMultJobCard.DataBind();
				}
				else
				{					
					rptMultJobCard.Visible = false;
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
