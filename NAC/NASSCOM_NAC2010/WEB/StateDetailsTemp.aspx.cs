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

namespace NASSCOM_NAC.Web
{
	///<remarks>
	///===================================================================
	/// Name: File Name				: StateDetailsTemp.aspx
	/// Construction Date			: 01/08/08
	/// Author: Developer's Name	: Nitish Bhatia
	/// Description					: This page is used for creating new states
	/// Last Revision Date			: 
	/// Last Revision By			:  
	/// Last Revision Change		: 
	/// ====================================================================
	/// Copyright (C) 2007-2008 NASSCOM  All Rights Reserved.
	/// ====================================================================
	///</remarks> 
	public class StateDetailsTemp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlTestState;
		protected MagicAjax.UI.Controls.AjaxPanel AjaxPanel;
		protected System.Web.UI.WebControls.Button btnModifyState;
		protected System.Web.UI.WebControls.Button btnAddModifyCenterDetails;
		protected System.Web.UI.WebControls.TextBox txtStateCode;
		protected System.Web.UI.WebControls.CheckBox chkETSAccess;
		protected System.Web.UI.HtmlControls.HtmlTable tblState;
		protected System.Web.UI.HtmlControls.HtmlInputFile filUpload;
		protected System.Web.UI.WebControls.Button btnAddState;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Image imgState;
		protected System.Web.UI.WebControls.TextBox txtStateName;		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateData();");
			if(!Page.IsPostBack)
			{
				tblState.Visible=false;
				btnSubmit.Visible=false; 
				FillState();
				lblMessage.Visible=false; 
				
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
			this.ddlTestState.SelectedIndexChanged += new System.EventHandler(this.ddlTestState_SelectedIndexChanged);
			this.btnAddModifyCenterDetails.Click += new System.EventHandler(this.btnAddModifyCenterDetails_Click);
			this.btnAddState.Click += new System.EventHandler(this.btnAddState_Click);
			this.btnModifyState.Click += new System.EventHandler(this.btnModifyState_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region FillState()

		private void FillState()
		{	
			BLRegistration objBLRegistration = new BLRegistration();			 
			BindDropDown(ref ddlTestState, objBLRegistration.FillTestState(),"State","StateId");			 
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

		#region btnAddState_Click()
		private void btnAddState_Click(object sender, System.EventArgs e)
		{
			tblState.Visible=true;		
			ViewState["Mode"]="insert";
			txtStateName.Text="";
			txtStateCode.Text="";			
			chkETSAccess.Checked=false;
			btnSubmit.Visible=true; 
			lblMessage.Visible=false; 

		}
		#endregion

		#region btnModifyState_Click()
		private void btnModifyState_Click(object sender, System.EventArgs e)
		{
			if(ddlTestState.SelectedItem.Value.ToString()!="0")
			{
				tblState.Visible=true;
				ViewState["Mode"]="update";
				DataTable dtDataTable;
				BLCentreDetails objBLCentreDetails = new BLCentreDetails();
			
				btnSubmit.Visible=true; 


				objBLCentreDetails.StateId=ddlTestState.SelectedItem.Value.ToString().Trim ();
				dtDataTable=objBLCentreDetails.GetStateDetails();

				txtStateName.Text=dtDataTable.Rows[0][1].ToString().Trim();
				txtStateCode.Text=dtDataTable.Rows[0][2].ToString().Trim();
				imgState.ImageUrl ="Images/"+dtDataTable.Rows[0][3].ToString().Trim();
				//filUpload.Value =dtDataTable.Rows[0][3].ToString().Trim();
				string strETS =Convert.ToString(dtDataTable.Rows[0][4]);
				if (strETS=="True")
				{
					chkETSAccess.Checked=true; 
				}
				else
				{
					chkETSAccess.Checked=false;
				}
				lblMessage.Visible=false; 
			}			
			else
			{
				lblMessage.Visible=true;
				lblMessage.Text="Select state for modification"; 
			}
		}
		#endregion	

		#region GetLogoFileExtension()
		//Returns file extention as string.
		private string GetLogoFileExtension()
		{
			string strExtension = "";
			//Initializing fn string variable with extention of current file.
			string fn = System.IO.Path.GetFileName(filUpload.PostedFile.FileName);

			if (filUpload.PostedFile == null || System.IO.Path.GetFileName(filUpload.PostedFile.FileName)=="")
			{				 
				return strExtension;
			}
			else
			{
				return strExtension = fn;// + System.IO.Path.GetExtension(filUpload.PostedFile.FileName);		 
			}
		}
		

		#endregion

		#region btnSubmit_Click()
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string baseLocation =  Server.MapPath(".")+ "\\UploadedPhotograph\\";
			BLCentreDetails objBLCentreDetails = new BLCentreDetails();
		
			objBLCentreDetails.StateId=ddlTestState.SelectedItem.Value.ToString().Trim ();
			objBLCentreDetails.State = txtStateName.Text.ToString().Trim();
			objBLCentreDetails.StateCode = txtStateCode.Text.ToString().Trim();
			objBLCentreDetails.UploadLogo = GetLogoFileExtension();
			if(chkETSAccess.Checked)
			{
				objBLCentreDetails.ETSAccess = "1";				
			}
			else
			{
				objBLCentreDetails.ETSAccess = "0";
			}
			objBLCentreDetails.Flag = ViewState["Mode"].ToString();
			objBLCentreDetails.UpdateStateDetail();

			ViewState["Mode"]="";
			FillState();

			//Finally blanking the state
			txtStateName.Text="";
			txtStateCode.Text="";	
			lblMessage.Visible=true;
			lblMessage.Text="Records added successfully."; 
		}

#endregion

		#region btnAddModifyCenterDetails_Click()
		private void btnAddModifyCenterDetails_Click(object sender, System.EventArgs e)
		{
			string strStateId=ddlTestState.SelectedItem.Value.ToString().Trim ();
			if(strStateId!="0")
				Response.Redirect("CenterDetailsTemp.aspx?StateId="+strStateId);
		}
		#endregion

		private void ddlTestState_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
		
	}
}
