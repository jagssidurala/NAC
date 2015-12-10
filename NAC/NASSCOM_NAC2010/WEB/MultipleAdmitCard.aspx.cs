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
	/// Summary description for MultipleAdmitCard.
	/// </summary>
	public partial class MultipleAdmitCard : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.Label lblRegistrationID;
		protected System.Web.UI.WebControls.Label lblName;
		protected System.Web.UI.WebControls.Label lblDOB;
		protected System.Web.UI.WebControls.Label lblGender1;
		protected System.Web.UI.WebControls.Label lblQualification;
		protected System.Web.UI.WebControls.Label lblTestLocation;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.Label lblTestDate;
		protected System.Web.UI.WebControls.Image imgUploadPhotograph;
		private string strItemList;
		private int iTotalAdmitCard;
		public string stateName;
		public string otherQualification;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(Request.QueryString["SearchType"] != null)
			{
				if(Request.QueryString["SearchType"] == "full")
				{

					BLSearch objBLSearch = new BLSearch();
					objBLSearch = (BLSearch)Session["SearchObject"];
					CreateAllMultipleAdmitCard(objBLSearch);					
					  
				}

				else if(Request.QueryString["SearchType"] == "fullAdmin")
				{

					BLCandidateSearchByAdmin objBLSearch = new BLCandidateSearchByAdmin();
					objBLSearch = (BLCandidateSearchByAdmin)Session["SearchObject"];
					CreateAllMultipleAdmitCardAdminV2(objBLSearch);					
					  
				}

				else
				{
					Response.Redirect("Login.aspx");
				}
			}
			else 
			{
				if(Session["ItemList"] != null)
				{
					strItemList = Session["ItemList"].ToString();
					strItemList = strItemList.ToString();
					//strItem = strItemList.Split(',');
					strItemList = strItemList.TrimEnd(','); 
					CreateMultipleAdmitCard(strItemList);
				}
				else
				{
					Response.Redirect("Login.aspx");
				}
			}
		}

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

		private void CreateMultipleAdmitCard(string RegistrationId)
		{	

			
			//string strGender;
			string strQualification;
			string strState;
			string strCity;
			string strCentre;
			string strName;

			
			BusinessLayer.BLAdmitCard oBLAdmitCard = new BLAdmitCard();
			DataSet dsAdmitCard = oBLAdmitCard.GenerateMultipleAdmitCard(RegistrationId);
			//lblRegistrationID.Text=dsAdmitCard.Tables[0].Rows[0][0].ToString();
			strName=dsAdmitCard.Tables[0].Rows[0][1].ToString();
				
			string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][2].ToString()));
			//lblGender1.Text=dsAdmitCard.Tables[0].Rows[0][3].ToString().Trim();
			strQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			otherQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
			stateName=dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
//			if(dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim()=="Hero Mindmine")
//			{
//				strState=dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
//			}
//			else
//			{
//				strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
//			}
//
//			if(dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim()=="Sona College")
//			{
//				strState=dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim()+ ' ' + "of Technology";
//			}
//			else
//			{
//				strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
//			}
			
			strCity = dsAdmitCard.Tables[0].Rows[0][5].ToString().Trim();
			strCentre = dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
			string strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][8].ToString())) + ' ' + String.Format("{0:HH:MM}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][9].ToString()));
			
			iTotalAdmitCard = dsAdmitCard.Tables[0].Rows.Count;

			rptAdmitCard.DataSource = dsAdmitCard;
			rptAdmitCard.DataBind();
		}

		public string ChangeTimeFormat(string strTime)
		{
			if(strTime == "12:00 PM")
			{
				return "12:00 Noon";
				}
			else
			{
			    return strTime;
			}
		}


		private void CreateAllMultipleAdmitCard(BLSearch objBLSearch)
		{
			//string strGender;
			string strQualification;
			string strState;
			string strCity;
			string strCentre;
			string strName;

		 
			DataSet dsAdmitCard = objBLSearch.GenerateAllMultipleAdmitCard();
			//lblRegistrationID.Text=dsAdmitCard.Tables[0].Rows[0][0].ToString();
			strName=dsAdmitCard.Tables[0].Rows[0][1].ToString();
				
			string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][2].ToString()));
			//lblGender1.Text=dsAdmitCard.Tables[0].Rows[0][3].ToString().Trim();
			strQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			otherQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();			
			stateName=dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
			strCity = dsAdmitCard.Tables[0].Rows[0][5].ToString().Trim();
			strCentre = dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
			string strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][8].ToString())) + ' ' + String.Format("{0:HH:MM}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][9].ToString()));
			
			iTotalAdmitCard = dsAdmitCard.Tables[0].Rows.Count;

			rptAdmitCard.DataSource = dsAdmitCard;
			rptAdmitCard.DataBind();
		}

		private void CreateAllMultipleAdmitCardAdminV2(BLCandidateSearchByAdmin objBLSearch)
		{
			//string strGender;
			string strQualification;
			string strState;
			string strCity;
			string strCentre;
			string strName;

		 
			DataSet dsAdmitCard = objBLSearch.GenerateAllMultipleAdmitCardAdminV2();
			//lblRegistrationID.Text=dsAdmitCard.Tables[0].Rows[0][0].ToString();
			strName=dsAdmitCard.Tables[0].Rows[0][1].ToString();
				
			string strDOB = String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][2].ToString()));
			//lblGender1.Text=dsAdmitCard.Tables[0].Rows[0][3].ToString().Trim();
			strQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			otherQualification = dsAdmitCard.Tables[0].Rows[0][4].ToString().Trim();
			strState="State of" + ' ' + dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();			
			stateName=dsAdmitCard.Tables[0].Rows[0][7].ToString().Trim();
			strCity = dsAdmitCard.Tables[0].Rows[0][5].ToString().Trim();
			strCentre = dsAdmitCard.Tables[0].Rows[0][6].ToString().Trim();
			string strTestDate=String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][8].ToString())) + ' ' + String.Format("{0:HH:MM}",Convert.ToDateTime(dsAdmitCard.Tables[0].Rows[0][9].ToString()));
			
			iTotalAdmitCard = dsAdmitCard.Tables[0].Rows.Count;

			rptAdmitCard.DataSource = dsAdmitCard;
			rptAdmitCard.DataBind();
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
			this.rptAdmitCard.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptAdmitCard_ItemDataBound);

		}
		#endregion

		private void rptAdmitCard_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			string strSpacer = "<tr><td class=\"white_bg\" height=\"50px\" align=\"center\"></td></tr><tr><td class=\"ContentPrint\" height=\"50px\" align=\"center\">&nbsp;</td></tr>";
			
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
			{
				if ((iTotalAdmitCard > 1 )&&(e.Item.ItemIndex < (iTotalAdmitCard-1)))
				{
					((Label)e.Item.FindControl("lblBlanSpacer")).Text= strSpacer;
				}
			}

		}
	}
}
