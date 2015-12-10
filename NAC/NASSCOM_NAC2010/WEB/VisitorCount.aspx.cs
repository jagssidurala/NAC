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
	/// Displays datewise count of No. of hits to the NAC HomePage in a DateGrid.
	/// </summary>
	public partial class VisitorCount : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// Populates the DataGrid with rows from last seven days with their respective count.
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

		#region btnSubmit_Click
		/// <summary>
		/// Populates the DataGrid with rows between a valid range of dates.
		/// If a valid range is not selected it Populates the Datagrid wiht rows from last seven days with their respective count.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			PopulateVisitCountGrid();
		}
		#endregion

		#region PopulateVisitCountGrid
		/// <summary>
		/// Populates the DataGrid with rows between a valid range of dates or default dates if range not specified.
		/// </summary>
		private void PopulateVisitCountGrid()
		{
			DateTime DateFrom, DateTo;
			DataSet dsNACVisitCountRange = new DataSet();
			int intIncrementCount = 0;
			int intHitCount = 0;
			int intTotalRowCount = 0;

			DateFrom = GetDateFrom();
			DateTo = GetDateTo();

			NACVisitCount objNACVisitCount = new NACVisitCount();
			DataTable DT = new DataTable();
			DataView DV = new DataView();

			dsNACVisitCountRange = objNACVisitCount.GetNACVisitCountRange(DateFrom, DateTo);
			DT = dsNACVisitCountRange.Tables[0];
			if(DT != null)
			{
				if(DT.Rows.Count > 0)
				{
					intTotalRowCount = Convert.ToInt32(DT.Rows.Count);

					for(intIncrementCount = 0; intIncrementCount <= intTotalRowCount - 1; intIncrementCount++)
					{
					    intHitCount = intHitCount + Convert.ToInt32(DT.Rows[intIncrementCount]["HitCount"]);
					}

					lblTotalNumberOfHits.Text = Convert.ToString(intHitCount);
					DV = DT.DefaultView;					 
					dgVisitorCount.DataSource = DV;
					dgVisitorCount.DataBind();
				}

			}

			lblTotalHits.Text = Convert.ToString(dsNACVisitCountRange.Tables[1].Rows[0]["TotalHitCount"]); 
			
			
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
				DateFrom = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}",DateTime.Now.Subtract(TimeSpan.FromDays(7.0))));
				//DateFrom = Convert.ToDateTime(Convert.ToString(DateFrom.Month) + "/" + Convert.ToString(DateFrom.Day-7) + "/" + Convert.ToString(DateFrom.Year));               
				SetDefaultDateFrom(DateFrom);
			}
			return DateFrom;
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
	}
}
