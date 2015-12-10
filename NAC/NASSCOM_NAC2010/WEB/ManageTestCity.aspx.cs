
    ///<remarks>
	///===================================================================
	/// Name: File Name				: ManageTestCity.aspx
	/// Construction Date			: 06/05/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for adding new city or updating existing city details
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2011 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 

#region Namespaces

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

#endregion

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for ManageTestCity.
	/// </summary>
	public partial class ManageTestCity : System.Web.UI.Page
	{
		#region Class Variables

		protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel;
		protected static int StateId;

		#endregion

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( Session["UserType"] == null)
			{
				Response.Redirect("login.aspx");
			}
			if(Session["StateId"] == null || Session["StateId"] == "")
			{
				Response.Redirect("../Web/login.aspx",true);
			}
			lblMessage.Visible=false;
			if(!IsPostBack)
			{
				FillTestCity();
				trEditCity.Style.Add("display","none");
				rbtnlstAddEditCity.SelectedValue="0";
				btnSave.Attributes.Add("onclick","return ValidateData();");
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

		#region FillTestCity()

		private void FillTestCity()
		{	
			//StateId = Convert.ToInt32(Request.QueryString["State"].ToString());
			StateId = Convert.ToInt32(Session["StateId"].ToString());
			BLRegistration objBLRegistration = new BLRegistration();	
			BindDropDown(ref ddlTestCity, objBLRegistration.FillTestCity(StateId),"City","CityId");	
			ddlTestCity.Items.Insert(0,new ListItem("Select","0"));
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

		#region rbtnlstAddEditCity_SelectedIndexChanged
		protected void rbtnlstAddEditCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rbtnlstAddEditCity.SelectedValue=="0")
			{
				trEditCity.Style.Add("display","none");
				trCityCode.Style.Add("display","");
				trCityName.Style.Add("display","");
				txtCityName.Text="";
				txtCityCode.Text="";
			}
			else
			{
				ddlTestCity.SelectedIndex = 0;
				trEditCity.Style.Add("display","");
				trCityCode.Style.Add("display","none");
				trCityName.Style.Add("display","none");
			}
		}
		#endregion

		#region ddlTestCity_SelectedIndexChanged
		protected void ddlTestCity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestCity.SelectedIndex!=0)
			{
				BLCentreDetails objBLCentreDetails = new BLCentreDetails();
				DataTable dtCentreDetails = new DataTable();
				
				objBLCentreDetails.CityId = ddlTestCity.SelectedValue;
				dtCentreDetails = objBLCentreDetails.GetCityDetails_CityId();

				trCityName.Style.Add("display","");
				trCityCode.Style.Add("display","");
				txtCityCode.Text = dtCentreDetails.Rows[0]["CityCode"].ToString().Trim();
				txtCityName.Text = ddlTestCity.SelectedItem.Text;
			}
			else
			{
				trCityName.Style.Add("display","none");
				trCityCode.Style.Add("display","none");
				txtCityName.Text = "";
			}
		}
		#endregion

		#region btnSave_Click
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			objBLCentreDetails.StateId = StateId.ToString();
			if(txtCityName.Text.Trim()!="" && txtCityCode.Text.Trim()!="")
			{
				objBLCentreDetails.CityName = txtCityName.Text.Trim().ToString();				
				objBLCentreDetails.CityCode = txtCityCode.Text.Trim().ToUpper().ToString();
			}
			else
			{
				lblMessage.Text="Please fill all the fields";
				lblMessage.Visible=true;
				return;
			}
			if(rbtnlstAddEditCity.SelectedValue=="0")		//AddCity
			{
				//objBLCentreDetails.UpdateCityDetail();
				objBLCentreDetails.CreateCity();
			}
			else if(rbtnlstAddEditCity.SelectedValue=="1")	//EditCity
			{
				if(ddlTestCity.SelectedIndex!=0)
				{
					objBLCentreDetails.CityId = ddlTestCity.SelectedValue;
					objBLCentreDetails.UpdateCityDetail();
					//Session["CityId"] = ddlTestCity.SelectedValue;
					Response.Redirect("./CreateTest.aspx?State=" + StateId.ToString() + "&City=" + ddlTestCity.SelectedValue);
				}
				else
				{
					lblMessage.Text="Please select a city to edit";
					lblMessage.Visible=true;
					return;
				}
			}
			
			Response.Redirect("./CreateTest.aspx?City=" + ddlTestCity.SelectedValue);
		}
		#endregion

		#region btnDelete_Click
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(rbtnlstAddEditCity.SelectedValue=="1")
			{
				if(ddlTestCity.SelectedIndex!=0)
				{
					int result;
					BLCentreDetails objBLCentreDetails = new BLCentreDetails();
					objBLCentreDetails.CityId = ddlTestCity.SelectedValue;
					result = objBLCentreDetails.DeleteCity();
					if(result == 0)
					{
						lblMessage.Text = "City not deleted";
						lblMessage.Visible = true;
						string jScript;
						jScript = "<Script Language=Javascript>alert('City not deleted')</Script>";
						Page.RegisterStartupScript("keyClientBlock", jScript);
					}
					else
					{
						//Response.Redirect("./CreateTest.aspx");
						string jScript;
						jScript = "<Script Language=Javascript>alert('Please select again Photo to Upload');window.open('./CreateTest.aspx')</Script>";
						Page.RegisterStartupScript("keyClientBlock", jScript);
					}
				}
				else
				{
					lblMessage.Text = "Select a city to edit or delete";
					lblMessage.Visible = true;
					string jScript;
					jScript = "<Script Language=Javascript>alert('Select a city to edit or delete')</Script>";
					Page.RegisterStartupScript("keyClientBlock", jScript);
				}
			}
			else
			{
				lblMessage.Text = "Please select edit first";
				lblMessage.Visible = true;
				string jScript;
				jScript = "<Script Language=Javascript>alert('Please select edit first')</Script>";
				Page.RegisterStartupScript("keyClientBlock", jScript);
			}
		}
		#endregion

		#region btnCancel_Click
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("./CreateTest.aspx");
			Response.Redirect("./CreateTest.aspx?State=" + StateId.ToString());
		}	
		#endregion
	}
}
