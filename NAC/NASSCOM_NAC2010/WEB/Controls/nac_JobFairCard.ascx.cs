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

namespace NASSCOM_NAC.Web.Controls
{
	

	/// <summary>
	///		Summary description for nac_JobFairCard.
	/// </summary>
	public partial class nac_JobFairCard : System.Web.UI.UserControl
	{
private string strId;


		public string RegId
		{
			get{return strId;}
			set{strId = value;}
		}


		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			DataRow drNewRow;
			//string strRegistrationId = Session["UserID"].ToString();
			nac_JobFairCard objcard=new nac_JobFairCard();

			string strRegistrationId=RegId.ToString();
			DataSet dsJobFairCardCompanyDetails = new DataSet();

			BusinessLayer.BLJobFairCard oBLJobFairCard = new BusinessLayer.BLJobFairCard();
			dsJobFairCardCompanyDetails = oBLJobFairCard.GenerateMultipuleJobFairCardCompanyDetails(RegId.ToString().Trim());
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("SNo");
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("Attended");
			dsJobFairCardCompanyDetails.Tables[0].Columns.Add("Signature");

			int SNo=1;			 

			for(int k=0;k < dsJobFairCardCompanyDetails.Tables[0].Rows.Count;k++)
			{
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["SNo"]=SNo;
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["Attended"]=" ";
				dsJobFairCardCompanyDetails.Tables[0].Rows[k]["Signature"]="";
				SNo=SNo+1;			
			}

			for(int iCounter=dsJobFairCardCompanyDetails.Tables[0].Rows.Count; iCounter<10; iCounter++)
			{			
				//Initializing srNewRow
				drNewRow = dsJobFairCardCompanyDetails.Tables[0].NewRow();
				//Inserting initial value in "Center" column
				drNewRow["SNo"] = iCounter + 1;
				//Inserting initial value in "CenterId" column
				drNewRow["Attended"] = "";
				drNewRow["Signature"] = "";
				drNewRow["Company Name"] = "";
				drNewRow["FirstDate"] = DateTime.Now;
				drNewRow["SecondDate"] = DateTime.Now;		
				//Adding dtNewRow in dtTestCenter(Datatable)
				dsJobFairCardCompanyDetails.Tables[0].Rows.Add(drNewRow);							

			}			
			rptCompanyDetail.DataSource=dsJobFairCardCompanyDetails;
			rptCompanyDetail.DataBind();

			
		
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
