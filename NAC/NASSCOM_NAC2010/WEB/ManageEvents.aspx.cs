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

namespace WEB
{
	/// <summary>
	/// Summary description for ManageEvents.
	/// </summary>
	public class ManageEvents : System.Web.UI.Page
	{
		protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdCentre;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdCity;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlStates;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.RadioButtonList rbtnlstStateEvent;
		protected System.Web.UI.WebControls.DropDownList ddlEvents;
		protected System.Web.UI.WebControls.DropDownList ddlStateEvents;
		protected System.Web.UI.WebControls.Label lblState_Event;
		protected System.Web.UI.WebControls.Label lblStateEvents;
		protected System.Web.UI.WebControls.Label lblRegStartDate;
		protected System.Web.UI.WebControls.Label lblRegEndDate;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Label lblResultDeclarationDate;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdState;
		protected System.Web.UI.WebControls.TextBox txtcomments;
		protected System.Web.UI.WebControls.DropDownList ddlEndDay;
		protected System.Web.UI.WebControls.DropDownList ddlEndMonth;
		protected System.Web.UI.WebControls.DropDownList ddlEndYear;
		protected System.Web.UI.WebControls.DropDownList ddlTestDay;
		protected System.Web.UI.WebControls.DropDownList ddlTestMonth;
		protected System.Web.UI.WebControls.DropDownList ddlTestYear;
		protected System.Web.UI.WebControls.DropDownList ddlResultDay;
		protected System.Web.UI.WebControls.DropDownList ddlResultMonth;
		protected System.Web.UI.WebControls.DropDownList ddlResultYear;
		protected System.Web.UI.WebControls.DropDownList ddlStartDay;
		protected System.Web.UI.WebControls.DropDownList ddlStartMonth;
		protected System.Web.UI.WebControls.DropDownList ddlStartYear;
	    protected System.Web.UI.HtmlControls.HtmlInputHidden hdtestid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{			
				FillTestState();
				rbtnlstStateEvent.SelectedIndex=0;
				ddlStates.Visible=true;
				ddlEvents.Visible=false;
				lblState_Event.Text="States";
				ddlStateEvents.Visible=true;
				lblStateEvents.Visible=true;
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
			this.rbtnlstStateEvent.SelectedIndexChanged += new System.EventHandler(this.rbtnlstStateEvent_SelectedIndexChanged);
			this.ddlStates.SelectedIndexChanged += new System.EventHandler(this.ddlStates_SelectedIndexChanged);
			this.ddlStateEvents.SelectedIndexChanged += new System.EventHandler(this.ddlStateEvents_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region FillTestState()

		private void FillTestState()
		{
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlStates, objBLRegistration.FillTestState(),"State","StateId");
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

		private void rbtnlstStateEvent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rbtnlstStateEvent.SelectedValue=="0")
			{
				ddlStates.Visible=true;
				ddlEvents.Visible=false;
				lblState_Event.Text="States";
				ddlStateEvents.Visible=true;
				lblStateEvents.Visible=true;
			}
			else
			{
				ddlStates.Visible=false;
				ddlEvents.Visible=true;
				ddlStateEvents.Visible=false;
				lblStateEvents.Visible=false;
				lblState_Event.Text="Events";
			}
		}

		private void ddlStates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intStateId=Convert.ToInt32(ddlStates.SelectedItem.Value);
			
			if(intStateId!=0)
			{	
				BLCentreDetails objBLRegistration = new BLCentreDetails();
				objBLRegistration.StateId = intStateId.ToString();
				BindDropDown(ref ddlStateEvents, objBLRegistration.GetCentreAddress(),"Address","TestId");
				ddlStateEvents.Items.Insert(0,"Select");
				ddlStateEvents.SelectedIndex=0;

			}
			else
			{
				ddlStateEvents.Items.Clear();
				ddlStateEvents.Dispose();
				ddlStateEvents.Items.Insert(0,"Select");
				ddlStateEvents.SelectedIndex=0;
				Reset();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(ddlStates.SelectedIndex==0)
			{
				string jScript;
				jScript = "<Script Language=Javascript>alert('Please select a State')</Script>";
				Page.RegisterStartupScript("keyClientBlock", jScript);
				return;
			}
			int intCheck = 0;
			BLCentreDetails objBLRegistration = new BLCentreDetails();
			objBLRegistration.RegisterationStartDate = Convert.ToDateTime(ddlStartYear.SelectedValue.ToString() + "-" + ddlStartMonth.SelectedValue.ToString() + "-" + ddlStartDay.SelectedValue.ToString());
			objBLRegistration.RegisterationEndDate = Convert.ToDateTime(ddlEndYear.SelectedValue.ToString() + "-" + ddlEndMonth.SelectedValue.ToString() + "-" + ddlEndDay.SelectedValue.ToString());
			objBLRegistration.TestDate = Convert.ToDateTime(ddlTestYear.SelectedValue.ToString() + "-" + ddlTestMonth.SelectedValue.ToString() + "-" + ddlTestDay.SelectedValue.ToString());
			objBLRegistration.ResultDeclarationDate= Convert.ToDateTime(ddlResultYear.SelectedValue.ToString() + "-" + ddlResultMonth.SelectedValue.ToString() + "-" + ddlResultDay.SelectedValue.ToString());
			objBLRegistration.EventComments = txtcomments.Text;
			objBLRegistration.TestId = hdtestid.Value;
			intCheck = objBLRegistration.InsertEvents();
		}

		private void ddlStateEvents_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet dsEvents = new DataSet();
			BLCentreDetails objBLRegistration = new BLCentreDetails();
			if(ddlStateEvents.SelectedIndex!=0)
			{
				hdtestid.Value = ddlStateEvents.SelectedValue;
				dsEvents = objBLRegistration.GetEventDetails(Convert.ToInt32(hdtestid.Value));
				if(dsEvents.Tables.Count>0)
				{
					if(dsEvents.Tables[0].Rows.Count>0)
					{
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Day.ToString().Trim().Length == 1)
						{
							ddlStartDay.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Day.ToString();
						}
						else
						{
							ddlStartDay.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Day.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Month.ToString().Trim().Length == 1)
						{
							ddlStartMonth.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Month.ToString().Trim();
						}
						else
						{
							ddlStartMonth.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Month.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Year.ToString().Length == 1)
						{
							ddlStartYear.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0].ToString().Trim()).Year.ToString().Trim();
						}
						else
						{
							ddlStartYear.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][0]).Year.ToString();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Day.ToString().Trim().Length == 1)
						{
							ddlEndDay.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Day.ToString().Trim();
						}
						else
						{
							ddlEndDay.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Day.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Month.ToString().Trim().Length == 1)
						{
							ddlEndMonth.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Month.ToString().Trim();
						}
						else
						{
							ddlEndMonth.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Month.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Year.ToString().Trim().Length == 1)
						{
							ddlEndYear.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Year.ToString().Trim();
						}
						else
						{
							ddlEndYear.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][1].ToString().Trim()).Year.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Day.ToString().Trim().Length == 1)
						{
							ddlTestDay.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Day.ToString().Trim();
						}
						else
						{
							ddlTestDay.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Day.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Month.ToString().Trim().Length == 1)
						{
							ddlTestMonth.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Month.ToString().Trim();
						}
						else
						{
							ddlTestMonth.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Month.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Year.ToString().Trim().Length == 1)
						{
							ddlTestYear.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Year.ToString().Trim();
						}
						else
						{
							ddlTestYear.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][2].ToString().Trim()).Year.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Day.ToString().Trim().Length == 1)
						{
							ddlResultDay.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Day.ToString().Trim();
						}
						else
						{
							ddlResultDay.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Day.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Month.ToString().Trim().Length == 1)
						{
							ddlResultMonth.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Month.ToString().Trim();
						}
						else
						{
							ddlResultMonth.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Month.ToString().Trim();
						}
						if(Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Year.ToString().Trim().Length == 1)
						{
							ddlResultYear.SelectedValue = "0" + Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Year.ToString().Trim();
						}
						else
						{
							ddlResultYear.SelectedValue = Convert.ToDateTime(dsEvents.Tables[0].Rows[0][3].ToString().Trim()).Year.ToString().Trim();
						}
						txtcomments.Text = dsEvents.Tables[0].Rows[0][4].ToString().Trim();
					}
					else
					{
						Reset();
					}
				}
				else
				{
					Reset();
				}
			}
			else
			{
				Reset();
			}
		}
			
		private void Reset()
		{
			ddlStartDay.SelectedValue = "0";
			ddlStartMonth.SelectedValue = "0";
			ddlStartYear.SelectedValue = "0";
			ddlEndDay.SelectedValue = "0";
			ddlEndMonth.SelectedValue = "0";
			ddlEndYear.SelectedValue = "0";
			ddlTestDay.SelectedValue = "0";
			ddlTestMonth.SelectedValue = "0";
			ddlTestYear.SelectedValue = "0";
			ddlResultDay.SelectedValue = "0";
			ddlResultMonth.SelectedValue = "0";
			ddlResultYear.SelectedValue = "0";
			txtcomments.Text="";
		}
	}
}
