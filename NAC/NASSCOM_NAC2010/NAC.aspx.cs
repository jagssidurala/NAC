using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLayer;

namespace NASSCOM_NAC
{
	/// <summary>
	/// Summary description for NAC.
	/// </summary>
	public class NAC : System.Web.UI.Page
	{
		private string strStateName;
		public string strStatus = "";
		public string strStartDate = "";
		public string strEndDate = "";
		public string strStartTime = "";
		protected System.Web.UI.WebControls.DropDownList ddlState;
		protected System.Web.UI.WebControls.ImageButton btnGo;
		public string strEndTime = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			if(!Page.IsPostBack)
			{			
				FillTestState();		
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
			this.btnGo.Click += new System.Web.UI.ImageClickEventHandler(this.btnGo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{
			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();
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
				case "1": strMonthName = Month.January.ToString();
					break;
				case "2": strMonthName = Month.February.ToString();
					break;
				case "3": strMonthName = Month.March.ToString();
					break;
				case "4": strMonthName = Month.April.ToString();
					break;
				case "5": strMonthName = Month.May.ToString();
					break;
				case "6": strMonthName = Month.June.ToString();
					break;
				case "7": strMonthName = Month.July.ToString();
					break;
				case "8": strMonthName = Month.August.ToString();
					break;
				case "9": strMonthName = Month.September.ToString();
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

		private void btnGo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int stateId = Convert.ToInt32(ddlState.SelectedValue.ToString());
			if(stateId==0)
			{
				string jScript;
				jScript = "<Script Language=Javascript>alert('Please select a state.');</Script>";
				Page.RegisterStartupScript("keyClientBlock", jScript);
				return;
			}
			BLRegistration objBLRegistration = new BLRegistration();
			objBLRegistration.StateId = stateId;
			DataSet ds = objBLRegistration.CheckStateCentreIsActive();
			//string testStatus = ds.Tables[0].Rows[0][0].ToString().Trim();
			//if(testStatus=="End" || testStatus=="Not Started" || testStatus=="No Test" || testStatus == "")
			if(ds.Tables[0].Rows.Count <= 0)
			{
				string jScript;
				//jScript = "<Script Language=Javascript>alert('Currently there is no NAC event in your state. Please visit after some time.');</Script>";
				jScript = "<Script Language=Javascript>NoEventAlert();</Script>";
				Page.RegisterStartupScript("keyClientBlock", jScript);
				return;
			}
			else
			{
				strStateName = ddlState.SelectedItem.Text.ToString();
				Session["StateId"]= stateId;
				Session["State"]= strStateName;
				if(ds.Tables[0].Rows.Count == 1)
				{
					Session["TestId"]=ds.Tables[0].Rows[0]["TestId"];
//					switch(strStateName)
//					{
//						case "Gujarat":
//							Response.Redirect("web/Gujrat_SingleEvent.aspx?State=Gujarat");
//							break;				
//						case "West Bengal":			
//							Response.Redirect("web/West_Bangal_SingleEvent.aspx?State=West Bengal");
//							break;
//						case "Rajasthan":			
//							Response.Redirect("web/Rajasthan_SingleEvent.aspx?State=Rajasthan");
//							break;
//						case "Chandigarh":			
//							Response.Redirect("web/Chandigarh_SingleEvent.aspx?State=Chandigarh");
//							break;
						//case "Andhra Pradesh":
							Response.Redirect("web/Andra_Pradesh_SingleEvent.aspx");
//							break;
//						case "Nagaland":
//							Response.Redirect("web/Nagaland_SingleEvent.aspx?State=Nagaland");
//							break;
//						case "Mizoram":
//							Response.Redirect("web/Mizoram_SingleEvent.aspx?State=Mizoram");
//							break;
//						case "Manipur":
//							Response.Redirect("web/Manipur_SingleEvent.aspx?State=Manipur");
//							break;
//						case "Sikkim":
//							Response.Redirect("web/Sikkim_SingleEvent.aspx?State=Sikkim");
//							break;
//						case "Tripura":
//							Response.Redirect("web/Tripura_SingleEvent.aspx?State=Tripura");
//							break;
//						case "Meghalaya":
//							Response.Redirect("web/Meghalaya_SingleEvent.aspx?State=Meghalaya");
//							break;
//						case "Arunachal Pradesh":
//							Response.Redirect("web/Arunachal_Pradesh_SingleEvent.aspx?State=Arunachal Pradesh");
//							break;
//						case "Assam":
//							Response.Redirect("web/Assam_SingleEvent.aspx?State=Assam");
//							break;
//							//					case "Hero Mindmine":
//							//						Response.Redirect("web/Hero_Mindmine.aspx?State=Hero Mindmine");
//							//						break;
//							//					case "Sona College":
//							//						Response.Redirect("web/Sona.aspx?State=Sona College");
//							//						break;
//						case "Orissa":
//							Response.Redirect("web/Orissa_SingleEvent.aspx?State=Orissa");
//							break;
//							//					case "Vel-Tech Tech. Univ.":
//							//						Response.Redirect("web/VelTech.aspx?State=Vel-Tech Tech. Univ.");
//							//						break;
//					}
				}
				else
				{
//					switch(strStateName)
//					{
//						case "Gujarat":
//							Response.Redirect("web/Gujrat_MultipleEvents.aspx?State=Gujarat");
//							break;				
//						case "West Bengal":			
//							Response.Redirect("web/West_Bangal_MultipleEvents.aspx?State=West Bengal");
//							break;
//						case "Rajasthan":			
//							Response.Redirect("web/Rajasthan_MultipleEvents.aspx?State=Rajasthan");
//							break;
//						case "Chandigarh":			
//							Response.Redirect("web/Chandigarh_MultipleEvents.aspx?State=Chandigarh");
//							break;
//						case "Andhra Pradesh":
							Response.Redirect("web/Andra_Pradesh_MultipleEvents.aspx");
//							break;
//						case "Nagaland":
//							Response.Redirect("web/Nagaland_MultipleEvents.aspx?State=Nagaland");
//							break;
//						case "Mizoram":
//							Response.Redirect("web/Mizoram_MultipleEvents.aspx?State=Mizoram");
//							break;
//						case "Manipur":
//							Response.Redirect("web/Manipur_MultipleEvents.aspx?State=Manipur");
//							break;
//						case "Sikkim":
//							Response.Redirect("web/Sikkim_MultipleEvents.aspx?State=Sikkim");
//							break;
//						case "Tripura":
//							Response.Redirect("web/Tripura_MultipleEvents.aspx?State=Tripura");
//							break;
//						case "Meghalaya":
//							Response.Redirect("web/Meghalaya_MultipleEvents.aspx?State=Meghalaya");
//							break;
//						case "Arunachal Pradesh":
//							Response.Redirect("web/Arunachal_Pradesh_MultipleEvents.aspx?State=Arunachal Pradesh");
//							break;
//						case "Assam":
//							Response.Redirect("web/Assam_MultipleEvents.aspx?State=Assam");
//							break;
//							//					case "Hero Mindmine":
//							//						Response.Redirect("web/Hero_Mindmine.aspx?State=Hero Mindmine");
//							//						break;
//							//					case "Sona College":
//							//						Response.Redirect("web/Sona.aspx?State=Sona College");
//							//						break;
//						case "Orissa":
//							Response.Redirect("web/Orissa_MultipleEvents.aspx?State=Orissa");
//							break;
//							//					case "Vel-Tech Tech. Univ.":
//							//						Response.Redirect("web/VelTech.aspx?State=Vel-Tech Tech. Univ.");
//							//						break;
//					}
				}
			}
		}
	}
}