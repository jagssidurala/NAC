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

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for Registrationtest.
	/// </summary>
	public class Registrationtest : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblStateName;
		protected System.Web.UI.WebControls.Label lblExistMessage;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtMiddleName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.DropDownList ddlDay;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.RadioButtonList rblGender;
		protected System.Web.UI.WebControls.TextBox txtResidentialAddress;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtPinCode;
		protected System.Web.UI.WebControls.TextBox txtSTDCode;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.TextBox txtEmailID;
		protected System.Web.UI.WebControls.TextBox txtMothersName;
		protected System.Web.UI.WebControls.TextBox txtFathersName;
		protected System.Web.UI.WebControls.DropDownList ddlHouseholdIncome;
		protected System.Web.UI.WebControls.RadioButtonList rblYouBelongTo;
		protected System.Web.UI.WebControls.DropDownList ddlQualification;
		protected System.Web.UI.WebControls.TextBox txtHighestEducationObtainedFrom;
		protected System.Web.UI.WebControls.DropDownList ddlGraduationYear;
		protected System.Web.UI.WebControls.TextBox txtPGSpecialization;
		protected System.Web.UI.WebControls.TextBox txtCollegeAddress;
		protected System.Web.UI.WebControls.TextBox txtHighestEducationCity;
		protected System.Web.UI.WebControls.DropDownList ddlQualificationDetails;
		protected System.Web.UI.WebControls.TextBox txtPercentageScored;
		protected System.Web.UI.WebControls.DropDownList ddlMediumOfInstruction;
		protected System.Web.UI.WebControls.DropDownList ddlMediumOfInstructionIn12Th;
		protected System.Web.UI.WebControls.DropDownList ddlPassingYear12th;
		protected System.Web.UI.WebControls.RadioButtonList rblEmploymentStatus;
		protected System.Web.UI.WebControls.TextBox txtCurrentLocation;
		protected System.Web.UI.WebControls.TextBox txtLanguageSkills;
		protected System.Web.UI.WebControls.RadioButtonList rblWillingToWorkOutOfHomeTown;
		protected System.Web.UI.WebControls.DropDownList ddlPassport;
		protected System.Web.UI.WebControls.TextBox txtPassport;
		protected System.Web.UI.WebControls.DropDownList ddlTestCity;
		protected System.Web.UI.WebControls.Label lblTestCity;
		protected System.Web.UI.WebControls.DropDownList ddlTestCentre;
		protected System.Web.UI.WebControls.Label lblTestCentre;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtConfirmPassword;
		protected System.Web.UI.WebControls.DropDownList ddlPhotoIdDocument;
		protected System.Web.UI.WebControls.TextBox txtPhotoIdNumber;
		protected System.Web.UI.WebControls.CheckBox chkAuthorization;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button Save;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdTestCentreName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdTestCentre;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdconfpassword;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdpassword;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdImagepath;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdQualificationDetailsName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdQualificationDetails;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdInstructions;
		protected System.Web.UI.HtmlControls.HtmlInputFile filUpload;
		protected System.Web.UI.HtmlControls.HtmlTableCell divHighestEducationObtainedFrom;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOtherQualification;
		protected System.Web.UI.HtmlControls.HtmlTableRow dvPassport1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trTestCity;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divDropTestCity;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divLblTestCity;
		protected System.Web.UI.HtmlControls.HtmlTableRow trTestCentre;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divDropTestCentre;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divLblTestCentre;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
