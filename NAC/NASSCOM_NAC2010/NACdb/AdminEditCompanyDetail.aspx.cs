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
using System.Text.RegularExpressions;

using BusinessLayer;


namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for AdminEditCompanyDetail.
	/// </summary>
	public partial class AdminEditCompanyDetail : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["CompanyId"]==null && Request.QueryString["Id"]==null)
			{
				Response.Redirect("./LoginPage.aspx",false);
			}
			else if(Request.QueryString["Id"] != null)
			{
				if(!IsPostBack)
				{
					btnSubmit.Attributes.Add("OnClick","javascript:return ValidateData();");
					txtCompanyAddress.Attributes.Add("onkeydown","return imposeMaxLength(this,99,event);");
					txtCompanyName.Attributes.Add("onblur","checkBlankValue(this);");
					txtCompanyAddress.Attributes.Add("onblur","checkBlankValue(this);");
					txtSPOCName.Attributes.Add("onblur","fillOnlyAlphabetValue(this);checkBlankValue(this);");
					txtSPOCName.Attributes.Add("onkeydown","return isAlpha(event.keyCode)");
					txtSPOCEmail.Attributes.Add("onblur","ValidateEmailAddress(this);");
					txtOfficialPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);");
					txtOfficialPhone.Attributes.Add("onkeypress","return isNumberKey(event)");
					txtSPOCPhone.Attributes.Add("onkeypress","return isNumberKey(event)");
					txtSPOCPhone.Attributes.Add("onblur","fillOnlyNumericValue(this);");
					BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
					objBLCompanyLogin.CompanyId = Convert.ToInt32(Request.QueryString["Id"].ToString());
					Populate(objBLCompanyLogin);
				}
				string cRefreshParentKey = "RefreshParentKey";
				string strScript = "<script>window.opener.document.forms(0).submit();</script>";
				if (!this.Page.IsClientScriptBlockRegistered(cRefreshParentKey))
				{
					this.Page.RegisterClientScriptBlock(cRefreshParentKey, strScript);
				}
			}
			else
			{
				Response.Redirect("./LoginPage.aspx",false);
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

		private void Populate(BLCompanyLogin objBLCompanyLogin)
		{
			DataSet dsCompanyDetail = new DataSet();
			DateTime AgreementExpiryDate;
			dsCompanyDetail = objBLCompanyLogin.GetCompanyDetailById();
			txtCompanyName.Text = dsCompanyDetail.Tables[0].Rows[0]["CompanyName"].ToString();
			txtCompanyAddress.Text = dsCompanyDetail.Tables[0].Rows[0]["CompanyAddress"].ToString();
			txtCompanyAddress.Text = txtCompanyAddress.Text.ToString().Replace("\\r\\n","\r\n");
			txtOfficialPhone.Text = dsCompanyDetail.Tables[0].Rows[0]["OfficialPhone"].ToString().Trim();
			txtSPOCName.Text = dsCompanyDetail.Tables[0].Rows[0]["SPOCName"].ToString();
			txtSPOCPhone.Text = dsCompanyDetail.Tables[0].Rows[0]["SPOCPhone"].ToString().Trim();
			txtSPOCEmail.Text = dsCompanyDetail.Tables[0].Rows[0]["SPOCEmail"].ToString();
			AgreementExpiryDate = Convert.ToDateTime(dsCompanyDetail.Tables[0].Rows[0]["AgreementExpiryDate"].ToString());
			ddlDay.SelectedValue = AgreementExpiryDate.Day.ToString();
			ddlMonth.SelectedValue = AgreementExpiryDate.Month.ToString();
			ddlYear.SelectedValue = AgreementExpiryDate.Year.ToString();
			lblLoginIdValue.Text = dsCompanyDetail.Tables[0].Rows[0]["Loginid"].ToString();
			txtPassword.Text = dsCompanyDetail.Tables[0].Rows[0]["Password"].ToString();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language=javascript>window.close();</script>");
			Response.End();
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(ValidateData())
			{
				DataSet dsStatus = new DataSet();
				DataSet dsCompanyDetail = new DataSet();
				BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
				objBLCompanyLogin.CompanyName = txtCompanyName.Text.Trim();
				objBLCompanyLogin.CompanyAddress = txtCompanyAddress.Text.Trim();
				objBLCompanyLogin.CompanyAddress = objBLCompanyLogin.CompanyAddress.Replace("\r\n","\\r\\n");
				objBLCompanyLogin.OfficialPhone = txtOfficialPhone.Text.Trim();
				objBLCompanyLogin.CompanySPOCName = txtSPOCName .Text.Trim();
				objBLCompanyLogin.CompanySPOCPhone =  txtSPOCPhone.Text.Trim();
				objBLCompanyLogin.CompanySPOCEmail = txtSPOCEmail.Text.Trim();
				objBLCompanyLogin.AgreementExpiryDate = Convert.ToDateTime(ddlMonth.SelectedValue +"/"+ ddlDay.SelectedValue +"/"+ ddlYear.SelectedValue);
				objBLCompanyLogin.CompanyId = Convert.ToInt32(Request.QueryString["Id"].ToString());
				dsStatus = objBLCompanyLogin.UpdateCompanyDetail();
				
				dsCompanyDetail = objBLCompanyLogin.GetCompanyDetailById();
				if(dsCompanyDetail.Tables.Count > 0)
				{
					if(dsCompanyDetail.Tables[0].Rows.Count > 0)
					{
						DataSet dsChangePassword = new DataSet();
						objBLCompanyLogin.Password = dsCompanyDetail.Tables[0].Rows[0]["Password"].ToString();
						objBLCompanyLogin.NewPassword = objBLCompanyLogin.base64Encode(txtPassword.Text);
						if(objBLCompanyLogin.Password != txtPassword.Text)
						{
							dsChangePassword = objBLCompanyLogin.ChangeCompanyPassword();
						}
					}
				}

				if(dsStatus.Tables.Count > 0)
				{
					if(dsStatus.Tables[0].Rows.Count>0)
					{
						if(dsStatus.Tables[0].Rows[0][0].ToString() == "0")
						{
							this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Details have been updated. Thank You');window.close();</script>");
						}
						else if(dsStatus.Tables[0].Rows[0][0].ToString() == "1")
						{
							lblError.Text = "A company with the name or Email Id you specified, already exists";
							lblError.Visible = true;
							return;
						}
						else
						{
							lblError.Text = "Error occured";
							lblError.Visible = true;
							return;
						}
					}
					else
					{
						lblError.Text = "Error occured";
						lblError.Visible = true;
						return;
					}
				}
				else
				{
					lblError.Text = "Error occured";
					lblError.Visible = true;
					return;
				}
			}
		}

		private bool ValidateData()
		{
			if(txtCompanyName.Text.Trim()=="")
			{
				lblError.Text = "Please enter company name";
				lblError.Visible = true;
				return false;
			}
			if(txtCompanyAddress.Text.Trim()=="")
			{
				lblError.Text = "Please enter company address";
				lblError.Visible = true;
				return false;
			}

			if(txtCompanyAddress.Text.Trim().Length > 100)
			{
				lblError.Text = "CompanyAddress exceeding maximum limit of 100 characters.";
				lblError.Visible = true;
				return false;
			}

			if(txtOfficialPhone.Text.Trim()=="")
			{
				lblError.Text = "Please enter official phone number";
				lblError.Visible = true;
				return false;
			}
			else if(!IsNumeric(txtOfficialPhone.Text.Trim()))
			{
				lblError.Text = "Please enter numbers only";
				lblError.Visible = true;
				return false;
			}
			if(txtOfficialPhone.Text.Trim().Length < 7)
			{
				lblError.Text = "Official Phone No. can't be less than 7 digits";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCName.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's name";
				lblError.Visible = true;
				return false;
			}
			else if(!IsAlphabet(txtSPOCName.Text.Trim()))
			{
				lblError.Text = "Please enter alphabets only";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCPhone.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's phone number";
				lblError.Visible = true;
				return false;
			}
			else if(!IsNumeric(txtSPOCPhone.Text.Trim()))
			{
				lblError.Text = "Please enter numbers only";
				lblError.Visible = true;
				return false;
			}
			if(txtSPOCPhone.Text.Trim().Length < 7)
			{
				lblError.Text = "Please enter a valid SPOC's phone number. Can't be less than 7 digits";
				lblError.Visible = true;
				return false;
			}

			if(txtSPOCEmail.Text.Trim()=="")
			{
				lblError.Text = "Please enter SPOC's email ID";
				lblError.Visible = true;
				return false;
			}
			else if(!ValidEmail(txtSPOCEmail.Text.Trim()))
			{
				lblError.Text = "Please enter valid email ID";
				lblError.Visible = true;
				return false;
			}
			else if(txtSPOCEmail.Text.Trim().ToLower().IndexOf("@gmail.co")>0 || txtSPOCEmail.Text.Trim().ToLower().IndexOf("@yahoo.co")>0 ||
				txtSPOCEmail.Text.Trim().ToLower().IndexOf("@rediff.co")>0 || txtSPOCEmail.Text.Trim().ToLower().IndexOf("@zapak.co")>0 ||
				txtSPOCEmail.Text.Trim().ToLower().IndexOf("@hotmail.co")>0)
			{
				lblError.Text = "Please enter official email ID";
				lblError.Visible = true;
				return false;
			}
			
			if(ddlDay.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry day";
				lblError.Visible = true;
				return false;
			}
			else if(ddlMonth.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry month";
				lblError.Visible = true;
				return false;
			}
			else if(ddlYear.SelectedIndex == 0)
			{
				lblError.Text = "Please select agreement expiry year";
				lblError.Visible = true;
				return false;
			}
			else
			{
				DateTime today;
				today = DateTime.Today;
				if(Convert.ToDateTime(ddlMonth.SelectedValue+"/"+ddlDay.SelectedValue+"/"+ddlYear.SelectedValue) <= today)
				{
					lblError.Text = "Past or current date for Agreement expiry is not allowed";
					lblError.Visible = true;
					return false;	
				}
			}

			if(txtPassword.Text.Length != txtPassword.Text.Trim().Length)
			{
				lblError.Text = "Spaces are not allowed in start or end";
				lblError.Visible = true;
				return false;
			}
			else if(txtPassword.Text.Length < 6)
			{
				lblError.Text = "Password must be at least of 6 characters";
				lblError.Visible = true;
				return false;
			}

			return true;
		}

		
		private bool IsAlphabet(string strInput)
		{
			string check="abcdefghijklmnopqrstuvwxyz ";
			strInput=strInput.ToLower();
			bool status=true;
			int count,counter;
			for (count=0; count<strInput.Length; count++)
			{
				for(counter=0; counter<check.Length; counter++)
				{
					if(strInput[count]==check[counter])
					{
						break;
					}
				}
				if(counter==check.Length)
				{
					status=false;
					break;
				}
			}
			return status;
		}

		private bool IsNumeric(string strInput)
		{
			string check="0123456789";
			bool status=true;
			int count,counter;
			for (count=0; count<strInput.Length; count++)
			{
				for(counter=0; counter<check.Length; counter++)
				{
					if(strInput[count]==check[counter])
					{
						break;
					}
				}
				if(counter==check.Length)
				{
					status=false;
					break;
				}
			}
			return status;
		}

		public bool ValidEmail(string strInput)
		{
			if (!Regex.Match(strInput, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").Success)
			{		
				return false;
			}
			else
			{
				return true;
			}
		}


	}
}
