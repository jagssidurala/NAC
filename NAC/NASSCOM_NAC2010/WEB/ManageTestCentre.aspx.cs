
    ///<remarks>
	///===================================================================
	/// Name: File Name				: ManageTestCentre.aspx
	/// Construction Date			: 06/05/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used for adding new test centre or updating existing centre details
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
	/// Summary description for ManageTestCentre.
	/// </summary>
	public partial class ManageTestCentre : System.Web.UI.Page
	{
		#region Class Variables
		protected static int CityId;
		#endregion

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( Session["UserType"] == null)
			{
				Response.Redirect("login.aspx");
			}
			if(Session["CityId"] == null || Session["CityId"] == "")
			{
				
				Response.Redirect("../Web/login.aspx",true);
			}
			lblMessage.Visible=false;
			if(!IsPostBack)
			{
				trEditCentre.Style.Add("display","none");
				btnSave.Attributes.Add("onclick","return ValidateData();");
				FillTestCentre();
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

		#region rbtnlstAddEditCentre_SelectedIndexChanged
		protected void rbtnlstAddEditCentre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(rbtnlstAddEditCentre.SelectedValue=="0")
			{
				trEditCentre.Style.Add("display","none");
				trCentreName.Style.Add("display","");
				trCentreCapacity.Style.Add("display","");
				trCentreCode.Style.Add("display","");
				trCentreAddress.Style.Add("display","");
				txtCentreName.Text="";
				txtCentreCapacity.Text="";
				txtCentreCode.Text="";
				txtCentreAddress.Text="";
			}
			else
			{
				ddlTestCentre.SelectedIndex = 0;
				trEditCentre.Style.Add("display","");
				trCentreCode.Style.Add("display","none");
				trCentreName.Style.Add("display","none");
				trCentreCapacity.Style.Add("display","none");
				trCentreCode.Style.Add("display","none");
				trCentreAddress.Style.Add("display","none");
			}
		}
		#endregion

		#region ddlTestCentre_SelectedIndexChanged
		protected void ddlTestCentre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddlTestCentre.SelectedIndex!=0)
			{
				BLCentreDetails objBLCentreDetails = new BLCentreDetails();
				DataTable dtCentreDetails = new DataTable();
				objBLCentreDetails.CentreId = ddlTestCentre.SelectedValue;
				dtCentreDetails = objBLCentreDetails.GetCentreDetails_CentreId();
				txtCentreName.Text = ddlTestCentre.SelectedItem.Text;
				txtCentreCapacity.Text = dtCentreDetails.Rows[0]["Capacity"].ToString();
				txtCentreCode.Text = dtCentreDetails.Rows[0]["CentreCode"].ToString();
				txtCentreAddress.Text = dtCentreDetails.Rows[0]["CentreAddress"].ToString();
				trCentreName.Style.Add("display","");
				trCentreCapacity.Style.Add("display","");
				trCentreCode.Style.Add("display","");
				trCentreAddress.Style.Add("display","");
			}
			else
			{
				trCentreName.Style.Add("display","none");
				trCentreCapacity.Style.Add("display","none");
				trCentreCode.Style.Add("display","none");
				trCentreAddress.Style.Add("display","none");
			}
		}
		#endregion

		#region FillTestCentre()

		private void FillTestCentre()
		{	
			//CityId = Convert.ToInt32(Request.QueryString["City"].ToString());
			CityId = Convert.ToInt32(Session["CityId"].ToString());
			BLRegistration objBLRegistration = new BLRegistration();	
			BindDropDown(ref ddlTestCentre, objBLRegistration.FillAllTestCentre(CityId),"Centre","CentreId");	
			ddlTestCentre.Items.Insert(0,new ListItem("Select","0"));
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

		#region btnCancel_Click
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
		Response.Redirect("./CreateTest.aspx?State=" + Convert.ToString(Session["StateId"]) + "&City="+ CityId.ToString() );
		}
		#endregion

		#region btnSave_Click
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			BLCentreDetails objCentreDetails = new BLCentreDetails();
			objCentreDetails.CityId = CityId.ToString();
			if(txtCentreName.Text.Trim()!="" && txtCentreAddress.Text.Trim()!="" && txtCentreCapacity.Text.Trim()!="" && txtCentreCode.Text.Trim()!="")
			{
				objCentreDetails.Centre = txtCentreName.Text.Trim().ToString();
				objCentreDetails.CentreAddress = txtCentreAddress.Text.Trim().ToString();
				objCentreDetails.CentreCapacity = txtCentreCapacity.Text.Trim().ToString();
				objCentreDetails.CentreCode = txtCentreCode.Text.Trim().ToUpper().ToString();
			}
			else
			{
				lblMessage.Text="Please fill all fields";
				lblMessage.Visible=true;
				return; 
			}
			if(rbtnlstAddEditCentre.SelectedValue == "0")
			{
				objCentreDetails.CreateCentre();
			}
			else
			{
				objCentreDetails.CentreId = ddlTestCentre.SelectedValue;
				objCentreDetails.UpdateCentreDetail();

			}
			Response.Redirect("./CreateTest.aspx?State=" + Convert.ToString(Session["StateId"]) + "&City="+ CityId.ToString() + "&Centre="+ddlTestCentre.SelectedValue);
		}
		#endregion
	}
}
