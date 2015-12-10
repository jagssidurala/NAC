
    ///<remarks>
	///===================================================================
	/// Name: File Name				: TestRegistrationStatus.aspx
	/// Construction Date			: 09/05/11
	/// Author: Developer's Name	: Manoj Kumar Sijwali
	/// Description					: This page is used to view the registration states of tests.
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2011 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 
	///

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
	/// Summary description for TestRegistrationStatus.
	/// </summary>
	public partial class TestRegistrationStatus : System.Web.UI.Page
	{
		#region Class Variables
		#endregion

		#region PageLoad

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( Session["UserType"] == null)
			{
				Response.Redirect("login.aspx");
			}

			if(!IsPostBack)
			{
				BLRegistration objBLRegistration = new BLRegistration();
				BindDropDown(ref ddlTestNames, objBLRegistration.GetTestNames(1),"Name" , "Name");
				ListItem liSelect = new ListItem("Select" , "0");
				ddlTestNames.Items.Insert(0,liSelect);
			}
		}

		#endregion

		#region BindDropdown
		//Binding Combo Box with database value.
		private void BindDropDown(ref DropDownList ddlDropDownList, DataTable dtDataTable, string strTextField, string strValueField)
		{
			ddlDropDownList.DataSource = dtDataTable;
			ddlDropDownList.DataTextField = strTextField;
			ddlDropDownList.DataValueField = strValueField;
			ddlDropDownList.DataBind();

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

		#region ddlTestNames_SelectedIndexChanged
		protected void ddlTestNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( ddlTestNames.SelectedIndex != 0 )
			{
				BLRegistration objBLRegistration = new BLRegistration();
				DataSet ds = new DataSet();
				ds = objBLRegistration.GetTestRegistrationStatus(ddlTestNames.SelectedValue);
				
					if(ds.Tables.Count > 0)
					{
						if(ds.Tables[0].Rows.Count > 0)
						{

							dgRegistrationStatus.DataSource = ds.Tables[0];
							dgRegistrationStatus.DataBind();
							lblTotal.Text = "Total Capacity: " + ds.Tables[1].Rows[0]["TotalCapacity"].ToString() + " | Total Registered: " +  ds.Tables[1].Rows[0]["TotalRegisteredCount"].ToString();
							dgRegistrationStatus.Visible = true;
						}
						else
						{
							dgRegistrationStatus.Visible = false;
							lblTotal.Text = "";
						}
					}
					else
					{
						dgRegistrationStatus.Visible = false;
						lblTotal.Text = "";
					}
				
			}
			else
			{
				dgRegistrationStatus.Visible = false;
				lblTotal.Text = "";
			}
		}
		#endregion

		#region rblTestType_SelectedIndexChanged
		protected void rblTestType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			dgRegistrationStatus.Visible = false;
			lblTotal.Text = "";

			if(rblTestType.SelectedValue == "Ongoing Test")
			{
				BLRegistration objBLRegistration = new BLRegistration();
				BindDropDown(ref ddlTestNames, objBLRegistration.GetTestNames(1),"Name" , "Name");
				ListItem liSelect = new ListItem("Select" , "0");
				ddlTestNames.Items.Insert(0,liSelect);
			}
			else if(rblTestType.SelectedValue == "Previous Test")
			{
				BLRegistration objBLRegistration = new BLRegistration();
				BindDropDown(ref ddlTestNames, objBLRegistration.GetTestNames(0),"Name" , "Name");
				ListItem liSelect = new ListItem("Select" , "0");
				ddlTestNames.Items.Insert(0,liSelect);
			}
		}
		#endregion
	
	}
}
