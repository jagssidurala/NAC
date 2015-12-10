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
using DataAccessLayer;
using BusinessLayer;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for ForgotPassword.
	/// </summary>
	public partial class ForgotPassword : System.Web.UI.Page
	{
		BusinessLayer.BLLogin chkUser = new BusinessLayer.BLLogin();
		string strFirstName;
		string strLastName;
		string strMotherName;
		string strDOB;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//Adding attribute to validate user input while submition of page
			btnSubmit.Attributes.Add("OnClick", "javascript:return ValidateForgotLogin()");
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dtDOB;
				strFirstName = txtFirstName.Text.Trim();		//Initializing first name.
				strLastName = txtLastName.Text.Trim();			//Initializing last name.
				strMotherName = txtMotherName.Text.Trim();		//Initializing mother name.
				//Initializing strDOB for valid date.
                if (!(cmbDay.SelectedItem.ToString().Trim() == "Day") && !(cmbMonth.SelectedItem.ToString().Trim() == "Month") && !(cmbYear.SelectedItem.ToString().Trim() == "Year"))
                    strDOB = cmbDay.SelectedItem.ToString().Trim() + "/" + cmbMonth.SelectedItem.ToString().Trim() + "/" + cmbYear.SelectedItem.ToString().Trim();
                else
                    strDOB = string.Empty;
				//Converting string variable in Date data type.
                if (strDOB.Length > 0)
                {
                    dtDOB = System.Convert.ToDateTime(strDOB);
                }
                else
                {
                    dtDOB = System.Convert.ToDateTime("01/01/1901");
                }
				//Fetching registration id from database.
				DataSet ds = chkUser.FetchForgotPassword(strFirstName,strLastName,strMotherName,dtDOB);
				//Checking table is blank or not.
				if (ds.Tables[0].Rows.Count > 0)
				{
					//Initializing session for fetching password details.
					HttpContext.Current.Session["TempUser"] = Session.SessionID.ToString();
					//Redirecting in validate.aspx to fetch password.
					Response.Redirect("Validate.aspx?ResistrationID=" + ds.Tables[0].Rows[0]["RegistrationId"]);
				}
				else
				{
					//Display "No Result" text in lblResult if system is not getting data from database regarding user input.
                    lblResult.Text = "Please enter valid data";
				}
			}
			catch (Exception SysEx)
			{
				ErrorLogger.ErrorRoutine(false,SysEx);
				//To Pass Execption in exception class for show exception
				ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
			}		
		}
	}
}
