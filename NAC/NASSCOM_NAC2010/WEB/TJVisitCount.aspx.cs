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
using System.IO;
using System.Text;
using System.Configuration;
using System.Threading;
using Common;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Displays datewise count of No. of hits to the NAC WelcomePage in a DateGrid.
	/// </summary>
	public partial class TJVisitCount : System.Web.UI.Page
	{
		public string strSortExp;
		private int intCurrentPage;
		private static int intPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"].ToString());
		static DataSet dsNACVisitCountRange = new DataSet();
		protected void Page_Load(object sender, System.EventArgs e)
		{

			dgVisitorCount.Columns[1].Visible=false;
			dgVisitorCount.Columns[6].Visible=false;
			dgVisitorCount.Columns[9].Visible=false;
			dgVisitorCount.Columns[10].Visible=false;
			dgVisitorCount.Columns[11].Visible=false;
			dgVisitorCount.Columns[12].Visible=false;

			
            btnSubmit.Attributes.Add("OnClick", "javascript:return Validatedata();");
			btnExport.Attributes.Add("OnClick","javascript:return SelectCandidate();");
			if(!Page.IsPostBack)
			{
				
				PopulateVisitCountGrid();
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

		}
		#endregion
		
		#region GetDateFrom
		/// <summary>
		/// Computes the 'From' part of the date from selected values in respectove combo boxes.
		/// </summary>
		/// <returns>'From' date in dd/mm/yy format</returns>
		private DateTime GetDateFrom()
		{
			DateTime DateFrom;

			if(ddlFromDay.SelectedIndex != 0 && ddlFromMonth.SelectedIndex != 0 && ddlFromYear.SelectedIndex != 0)
			{
				DateFrom = Convert.ToDateTime(ddlFromDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlFromMonth.SelectedValue.ToString().Trim()) + "/" + ddlFromYear.SelectedValue.ToString().Trim());				
			}
			else
			{
				DateFrom = System.DateTime.Now;			
				//DateFrom = Convert.ToDateTime(Convert.ToString(DateFrom.Month) + "/" + Convert.ToString(DateFrom.Day-7) + "/" + Convert.ToString(DateFrom.Year));               
				SetDefaultDateFrom(DateFrom);
			}
			return DateFrom;
		}
		#endregion
		#region PopulateVisitCountGrid
		/// <summary>
		/// Populates the DataGrid with rows between a valid range of dates or default dates if range not specified.
		/// </summary>
		private void PopulateVisitCountGrid()
		{
			DateTime DateFrom, DateTo;
			//DataSet dsNACVisitCountRange = new DataSet();


			DateFrom = GetDateFrom();
			DateTo = GetDateTo();
			SaveCheckedValueTemporary();
			NACVisitCount objNACVisitCount = new NACVisitCount();
			DataTable DT = new DataTable();
			DataView DV = new DataView();

			dsNACVisitCountRange = objNACVisitCount.GetTJVisitDetailWithoutdate();
			if(dsNACVisitCountRange != null)
			{
				if(dsNACVisitCountRange.Tables[0].Rows.Count > 0)
				{
					hdTotalCandidateCount.Value = Convert.ToString(dsNACVisitCountRange.Tables[0].Rows.Count.ToString());
					dgVisitorCount.DataSource = dsNACVisitCountRange;
					dgVisitorCount.DataBind();
				}
				else
				{
					hdTotalCandidateCount.Value = "0";
				}

			}

			lblTotalHits.Text = dsNACVisitCountRange.Tables[1].Rows[0][0].ToString();
			ddlFromDay.SelectedIndex=0;
			ddlFromMonth.SelectedIndex=0;
			ddlFromYear.SelectedIndex=0;
			ddlToDay.SelectedIndex=0;
			ddlToMonth.SelectedIndex = 0;
			ddlToYear.SelectedIndex = 0;
			
		}
		#endregion
		

		#region DeselectAll_Click()

		private void btnDeselectAll_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				ViewState["CheckedValue"] = null;
				Hashtable htCheckedValue = new Hashtable();
				ViewState["CheckedValue"] = htCheckedValue; 
			}
			else
			{
				ViewState["CheckedValue"] = null;
				Hashtable htCheckedValue = new Hashtable();
				ViewState["CheckedValue"] = htCheckedValue; 
			}
			
		}


		#endregion
		
		#region SaveCheckedValueTemporary()

		private void SaveCheckedValueTemporary()
		{
			Hashtable htCheckedValue = new Hashtable();
			

			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			if(chkAll.Checked)
			{			   
				if(ViewState["CandidateList"] != null)
				{
					DataTable  dtCandidate = new DataTable();
					int intTotalRowCount = 0;
					int intIncrementLoop = 0;
					dtCandidate = (DataTable) ViewState["CandidateList"];
					intTotalRowCount = dtCandidate.Rows.Count;
					hdSelectedCandidateCount.Value = intTotalRowCount.ToString();

					for(intIncrementLoop=0;intIncrementLoop <= intTotalRowCount - 1; intIncrementLoop++)
					{
						if(htCheckedValue.Contains(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()))
						{
							htCheckedValue[dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()] = (bool)(true);
						}
						else
						{
							htCheckedValue.Add(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim(),((bool)(true)));
						}
					    
					}

				}
			}
			else
			{
				foreach(DataGridItem dgItem in dgVisitorCount.Items)
				{ 
				 
					if(htCheckedValue.Contains(((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim()))
					{
						htCheckedValue[((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim()] = (bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked;
					}
					else
					{
						htCheckedValue.Add(((Label) dgItem.FindControl("lblRegistration")).Text.ToString().Trim(),((bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked));
					}
				 
				}
			}

			

			ViewState["CheckedValue"] = htCheckedValue;
            
		}

		#endregion
		#region dgSearch_ItemDataBound()

		public void dgVisitorCount_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Hashtable htCheckedValue = new Hashtable();			 

			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			if(e.Item.ItemType == ListItemType.Header)
			{
				hdHeaderCheckBox.Value = ((CheckBox) e.Item.FindControl("chkHeader")).ClientID.ToString().Trim();
			}

			if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{				 				
				if(htCheckedValue.Contains(((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()))
				{
					((CheckBox) e.Item.FindControl("chkSelect")).Checked = (bool) htCheckedValue[((Label) e.Item.FindControl("lblRegistration")).Text.ToString().Trim()];
				}						 
				 
			}

		}

		#endregion
		#region PopulateVisitCountGrid1
		/// <summary>
		/// Populates the DataGrid with rows between a valid range of dates or default dates if range not specified.
		/// </summary>
		private void PopulateVisitCountGrid1()
		{
			DateTime DateFrom, DateTo;
			//DataSet dsNACVisitCountRange = new DataSet();


			DateFrom = GetDateFrom();
			DateTo = GetDateTo();

			NACVisitCount objNACVisitCount = new NACVisitCount();
			DataTable DT = new DataTable();
			DataView DV = new DataView();

			dsNACVisitCountRange = objNACVisitCount.GetTJVisitDetail(DateFrom, DateTo);
			if(dsNACVisitCountRange != null)
			{
				if(dsNACVisitCountRange.Tables[0].Rows.Count > 0)
				{

					dgVisitorCount.DataSource = dsNACVisitCountRange;
					dgVisitorCount.DataBind();
					dgVisitorCount.Visible = true;
				
				}
				else
				{
					lblErrorMsg.Text = "No Records Are Available To View...";			        
					dgVisitorCount.Visible = false;
				    
					
				}

			}

				lblTotalHits.Text = dsNACVisitCountRange.Tables[1].Rows[0][0].ToString();
			
			
		}

		#endregion
		#region SetDefaultDateFrom
		/// <summary>
		/// Sets the respective combo boxes with 'From' part of the date range .
		/// </summary>
		/// <param name="DateFrom">From date in dd/mm/yy format</param>
		private void SetDefaultDateFrom(DateTime DateFrom)
		{
			ddlFromDay.SelectedValue = (DateFrom.Day < 10)?("0" + DateFrom.Day.ToString()):(DateFrom.Day.ToString());
			ddlFromMonth.SelectedValue = (DateFrom.Month < 10)?("0"+ DateFrom.Month.ToString()):(DateFrom.Month.ToString());
			ddlFromYear.SelectedValue = DateFrom.Year.ToString();
		}
		#endregion

		
		#region GetDateTo
		/// <summary>
		/// Computes the 'To' part of the date from selected values in respectove combo boxes.
		/// </summary>
		/// <returns>'To' date in dd/mm/yy format</returns>
		private DateTime GetDateTo()
		{
			DateTime DateTo;

			if(ddlToDay.SelectedIndex != 0 && ddlToMonth.SelectedIndex != 0 && ddlToYear.SelectedIndex != 0)
			{
				DateTo = Convert.ToDateTime(ddlToDay.SelectedValue.ToString().Trim() + "/" + MonthYear(ddlToMonth.SelectedValue.ToString().Trim()) + "/" + ddlToYear.SelectedValue.ToString().Trim());				
			}
			else
			{
				DateTo = System.DateTime.Now;
				SetDefaultDateTo(DateTo);
			}
			return DateTo;
		}
		#endregion
		#region SetDefaultDateTo
		/// <summary>
		/// Sets the respective combo boxes with 'From' part of the date range .
		/// </summary>
		/// <param name="DateTo">'To' part of the date in dd/mm/yy format</param>
		private void SetDefaultDateTo(DateTime DateTo)
		{
			ddlToDay.SelectedValue = (DateTo.Day < 10)?("0" + DateTo.Day.ToString()):(DateTo.Day.ToString());
			ddlToMonth.SelectedValue = (DateTo.Month < 10)?("0"+ DateTo.Month.ToString()):(DateTo.Month.ToString());
			ddlToYear.SelectedValue = DateTo.Year.ToString();
		}
		#endregion

		#region Month
		/// <summary>
		/// Name of the months.
		/// </summary>
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
		#region MonthYear
		/// <summary>
		/// Computes name of the month based on respective value of month in a given date.
		/// </summary>
		/// <param name="strMonth">Value of month in given date</param>
		/// <returns>Name of the month</returns>
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
		 PopulateVisitCountGrid1();
		}
		#region dgVisitorCount_PageIndexChanged()

		public void dgVisitorCount_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgVisitorCount.CurrentPageIndex = e.NewPageIndex;
			//strSortExp = lblSortExp.Text;
			PopulateVisitCountGrid();
			intCurrentPage = e.NewPageIndex + 1;
			//SetSearchParameter(strSortExp,intCurrentPage);
			//PopulateVisitCountGrid();

		}

		
		#endregion
		protected void btnshowall_Click(object sender, System.EventArgs e)
		{
			lblErrorMsg.Text ="";
		  PopulateVisitCountGrid();
			dgVisitorCount.Visible=true;
		  ddlFromDay.SelectedIndex=0;
          ddlFromMonth.SelectedIndex=0;
		  ddlFromYear.SelectedIndex=0;
		  ddlToDay.SelectedIndex=0;
		  ddlToMonth.SelectedIndex = 0;
 	      ddlToYear.SelectedIndex = 0;
		}

		protected void btnExport_Click(object sender, System.EventArgs e)
		{
			if(chkAll.Checked)
			{
				
				if(dsNACVisitCountRange.Tables.Count!=0)
				{
					if(dsNACVisitCountRange.Tables[0].Rows.Count!=0)
					{
						dgVisitorCount.AllowPaging=false;
						dgVisitorCount.DataSource=dsNACVisitCountRange;
						dgVisitorCount.DataBind();
						dgVisitorCount.AllowPaging=false;
					}
					else
					{
						lblErrorMsg.Text="No data to Export";
						lblErrorMsg.Visible=true;
						return;
					}
					
					dgVisitorCount.Columns[0].Visible=false;
					dgVisitorCount.Columns[1].Visible=true;
					dgVisitorCount.Columns[6].Visible=true;
					dgVisitorCount.Columns[9].Visible=true;
					dgVisitorCount.Columns[10].Visible=true;
					dgVisitorCount.Columns[11].Visible=true;
					dgVisitorCount.Columns[12].Visible=true;
					
					Response.Clear();
					Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
					Response.Charset = "";
					Response.Cache.SetCacheability(HttpCacheability.NoCache);
					Response.ContentType = "application/vnd.xls";
					this.EnableViewState = false;
					System.IO.StringWriter stringWrite = new System.IO.StringWriter();
					System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
					dgVisitorCount.RenderControl(htmlWrite);
					Response.Write(stringWrite.ToString());
					Response.End();
				}
			}
			else
			{
				bool IsSelected = false; 
				StringBuilder sbItemList = new StringBuilder();
				SaveCheckedValueTemporary();
				Hashtable htCheckedValue = new Hashtable();
				if(ViewState["CheckedValue"] != null)
				{
					htCheckedValue = (Hashtable) ViewState["CheckedValue"];
				}
				if (htCheckedValue.Count != 0)
				{
					IDictionaryEnumerator Enumerator;
					Enumerator = htCheckedValue.GetEnumerator();
					while (Enumerator.MoveNext())
					{
						if(Convert.ToBoolean(Enumerator.Value))
						{
							sbItemList.Append("'");
							sbItemList.Append(Convert.ToString(Enumerator.Key.ToString()));				 
							sbItemList.Append("'");
							sbItemList.Append(",");
							if(IsSelected == false)
							{
								IsSelected = true;
							}
						 
						}
					 
					}
				}
				if(IsSelected)
				{
					sbItemList.Remove(sbItemList.Length - 1,1);
					Session["ItemList"] = sbItemList.ToString();
					Response.Redirect("TJListToexcel.aspx?SearchType=full");
				}
				else
				{
//					lblSortExp.Text = strSortExp;
//					SetStateCityCentreDropDown();
//					PopulateCandidateList(strSortExp);
				}
			}
		}

		protected void dgVisitorCount_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
