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
	/// Summary description for MultipleRegistration.
	/// </summary>
	public partial class MultipleRegistration : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFirstName;
		protected System.Web.UI.WebControls.Label lblMiddleName;
		protected System.Web.UI.WebControls.Label lblSurname;
		protected System.Web.UI.WebControls.Label lblDOB;
		protected System.Web.UI.WebControls.Label lblGender;
		protected System.Web.UI.WebControls.Label lblResidentialAddress;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.Label lblPin;
		protected System.Web.UI.WebControls.Label lblPhoneNumber;
		protected System.Web.UI.WebControls.Label lblCellPhone;
		protected System.Web.UI.WebControls.Image imgUploadPhotograph;
		protected System.Web.UI.WebControls.Label lblEmailId;
		protected System.Web.UI.WebControls.Label lblMothersName;
		protected System.Web.UI.WebControls.Label lblAnnualHouseholdIncome;
		protected System.Web.UI.WebControls.Label lblHEQ;
		protected System.Web.UI.WebControls.Label lblQualification;
		protected System.Web.UI.WebControls.Label lblAggregatePercentageScored;
		protected System.Web.UI.WebControls.Label lblHEObtainedFrom;
		protected System.Web.UI.WebControls.Label lblHEOFCity;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblWTWOutOfHomeTown;
		protected System.Web.UI.WebControls.Label lblTestCity;
		protected System.Web.UI.WebControls.Label lblTestCentre;
		protected System.Web.UI.WebControls.Label lblPhotoIDDocument;
		protected System.Web.UI.WebControls.Label lblSecretQuestion;
		protected System.Web.UI.WebControls.Label lblAnswer;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.Label Label40;
		protected System.Web.UI.WebControls.Label Label41;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.Label Label48;
		protected System.Web.UI.WebControls.Label Label49;
		protected System.Web.UI.WebControls.Label Label50;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.Label Label51;
		private string strItemList;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(Request.QueryString["SearchType"] != null)
			{
				if(Request.QueryString["SearchType"] == "fullAdmin"  && Session["UserType"] != null)
				{
					BLCandidateSearchByAdmin objBLCandidateSearchByAdmin = new BLCandidateSearchByAdmin();
					objBLCandidateSearchByAdmin = (BLCandidateSearchByAdmin)Session["SearchObject"];					 
					CreateAllCandidateDetailsByAdmin(objBLCandidateSearchByAdmin);
					
						 				
					  
				}
				else if(Request.QueryString["SearchType"] == "full"  && Session["UserType"] != null)
				{

					BLSearch objBLSearch = new BLSearch();
					objBLSearch = (BLSearch)Session["SearchObject"];					 
					CreateAllCandidateDetails(objBLSearch);
						 				
					  
				}
				else
				{
					Response.Redirect("Login.aspx");
				}
			}
			else 
			{
				if(Session["ItemList"] != null && Session["UserType"] != null)
				{
					strItemList = Session["ItemList"].ToString();
					strItemList = strItemList.ToString();
					//strItem = strItemList.Split(',');
					strItemList = strItemList.TrimEnd(','); 
					CreateMultipleCandidateDetails(strItemList);
				}
				else
				{
					Response.Redirect("Login.aspx");
				}
			}
		}


		#region CreateMultipleCandidateDetails()		
		private void CreateMultipleCandidateDetails(string RegistrationId)
		{ 
			//string strRegistrationId;
			BusinessLayer.BLRegistration oBLCandidate = new BLRegistration();
			string UserName=Session["UserName"].ToString();
			DataSet dsCandidate = oBLCandidate.GenerateMultipleCandidateDetails(RegistrationId);
			//strRegistrationId=dsCandidate.Tables[0].Rows[0][0].ToString();
			rptCandidateList.DataSource = dsCandidate;
			rptCandidateList.DataBind();
		}

		#endregion

		#region CreateAllCandidateDetails()		
		private void CreateAllCandidateDetails(BLSearch objBLSearch)
		{ 
			string UserName;

			UserName = Session["UserName"].ToString();
			
			DataSet dsCandidate = objBLSearch.GenerateAllCandidateDetails();

			rptCandidateList.DataSource = dsCandidate;
			rptCandidateList.DataBind();
		}

		#endregion

		#region CreateAllCandidateDetailsByAdmin()		
		private void CreateAllCandidateDetailsByAdmin(BLCandidateSearchByAdmin objBLCandidateSearchByAdmin)
		{ 
			string UserName;

			UserName = Session["UserName"].ToString();
			
			DataSet dsCandidate = objBLCandidateSearchByAdmin.GenerateAllCandidateDetailsAdminV2();

			rptCandidateList.DataSource = dsCandidate;
			rptCandidateList.DataBind();
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
			this.rptCandidateList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptCandidateList_ItemDataBound_1);

		}
		#endregion
		public string ValidateImage(string strImagePath)
		{
			if(strImagePath == "")
			{
				return "Images/" + "defaultphoto.jpg";
			}
			else
			{
				return "UploadedPhotograph/"+ strImagePath;
			}			
		 
		}
		private void rptCandidateList_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}

		private void rptCandidateList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{

		}

		private void rptCandidateList_ItemDataBound_1(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			if(e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
			{
				if(Session["UserType"].ToString() != "2")
				{
				    ((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("password"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trResidentialAddress"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trPhoneNumber"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trCellphone"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trEmailId"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trMotherName"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trFatherName"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trHouseHoldIncome"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trPhotoIdDocument"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trPhotoIdNumber"))).Visible = false;
					((System.Web.UI.HtmlControls.HtmlTableRow)(e.Item.FindControl("trSecurity"))).Visible = false;
				}
			}
		}
	}
}
