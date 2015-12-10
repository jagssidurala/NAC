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
	/// Summary description for GenerateJobAdmitCard.
	/// </summary>
	public partial class GenerateJobAdmitCard : System.Web.UI.Page
	{
		private string strItemList;
		 
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			try
			{
				if(Request.QueryString["SearchType"] != null)
				{
					if(Request.QueryString["SearchType"] == "full"  && Session["UserType"] != null)
					{

						BLSearch objBLSearch = new BLSearch();
						objBLSearch = (BLSearch)Session["SearchObject"];					 
						CreateAllJobAdmitCard(objBLSearch);
						 				
					  
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
						strItemList = strItemList.TrimEnd(','); 
						CreateJobAdmitCard(strItemList);
					}
					else
					{
						Response.Redirect("Login.aspx");
					}
				}
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}
		private void CreateJobAdmitCard(string RegistrationId)
		{
			try
			{
				BusinessLayer.BLJobAdmitCard oBLJobAdmitCard = new BusinessLayer.BLJobAdmitCard();
				DataSet dsJobAdmitCard = oBLJobAdmitCard.GenerateMultipleJobAdmitCard(RegistrationId);
				
				rptAdmitCard.DataSource = dsJobAdmitCard;
				rptAdmitCard.DataBind();

				
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			
		}

		private void CreateAllJobAdmitCard(BLSearch objBLSearch)
		{
			try
			{
				
				DataSet dsJobAdmitCard = objBLSearch.GenerateAllMultipleJobAdmitCard();
				
				rptAdmitCard.DataSource = dsJobAdmitCard;
				rptAdmitCard.DataBind();

				
			}
			catch(Exception ex)
			{
				throw(ex);
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
	}
}
