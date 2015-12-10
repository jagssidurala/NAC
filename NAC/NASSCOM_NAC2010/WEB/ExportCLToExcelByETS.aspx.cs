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
	/// Summary description for ExportCLToExcelByETS.
	/// </summary>
	public partial class ExportCLToExcelByETS : System.Web.UI.Page
	{
	
		#region Page_Load()

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Clear();
			 
			try
			{
				if(Request.QueryString["SearchType"] != null)
				{
					if(Request.QueryString["SearchType"] == "full")
					{
						BLSearch objBLSearch = new BLSearch();
						objBLSearch = (BLSearch)Session["SearchObject"];
						GetAllCandidateList(objBLSearch);			 
					  
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
						GetMultipleCandidateList();
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


		#endregion

		#region GetMultipleCandidateList()

		private void GetMultipleCandidateList()
		{
			
				string strTemplate = null;
				char[] splitter  = {','};
				int intIncrementLoop = 0;
				string[] strTemplateColumn;

				FieldPermission objFieldPermission = new FieldPermission();
				strTemplate = objFieldPermission.GetFieldPermission();

				if(strTemplate != null || strTemplate != "")
				{
					strTemplateColumn = strTemplate.Split(splitter);
					BLImportExportXLS objBLImportExportXLS = new BLImportExportXLS();
				 
					objBLImportExportXLS.CandidateRegistrationList = Convert.ToString(Session["ItemList"].ToString());
 		       
					dgCandidateList.AutoGenerateColumns = false;
					dgCandidateList.DataSource = ((DataTable)(objBLImportExportXLS.ExportCandidateListByETS())).DefaultView;
					dgCandidateList.DataBind(); 


					for(intIncrementLoop = 0; intIncrementLoop <= dgCandidateList.Columns.Count - 1; intIncrementLoop++)
					{
						dgCandidateList.Columns[intIncrementLoop].Visible = false;
					}

					for(intIncrementLoop = 0; intIncrementLoop <= strTemplateColumn.Length - 1; intIncrementLoop++)
					{
						switch(Convert.ToString(strTemplateColumn[intIncrementLoop]))
						{
							case "SerialNo":
								dgCandidateList.Columns[1].Visible = true;
								break;
							case "RegistrationId":
								dgCandidateList.Columns[2].Visible = true;
								break;							
							case "PinNo":
								dgCandidateList.Columns[3].Visible = true;
								break;
							case "FName":
								dgCandidateList.Columns[6].Visible = true;
								break;
							case "MName":
								dgCandidateList.Columns[7].Visible = true;
								break;					
							case "LName":
								dgCandidateList.Columns[8].Visible = true;
								break;
							case "DOB":
								dgCandidateList.Columns[9].Visible = true;							
								break;	
							case "Gender":
								dgCandidateList.Columns[10].Visible = true;
								break;
							case "ResidentialAddress":
								dgCandidateList.Columns[11].Visible = true;
								break;
							case "HomeCity":
								dgCandidateList.Columns[12].Visible = true;
								break;
							case "Pincode":
								dgCandidateList.Columns[13].Visible = true;
								break;
							case "STDCode":
								dgCandidateList.Columns[14].Visible = true;
								break;
							case "LandlinePhoneNo":
								dgCandidateList.Columns[15].Visible = true;
								break;		
							case "MobilePhone":
								dgCandidateList.Columns[16].Visible = true;
								break;					
							case "EmailId":
								dgCandidateList.Columns[17].Visible = true;
								break;
							case "MotherName":
								dgCandidateList.Columns[18].Visible = true;
								break;
							case "FatherName":
								dgCandidateList.Columns[19].Visible = true;
								break;
							case "IncomeRange":
								dgCandidateList.Columns[20].Visible = true;
								break;
							case "BelongTo":
								dgCandidateList.Columns[21].Visible = true;
								break;
							case "QualificationType":
								dgCandidateList.Columns[22].Visible = true;
								break;
							case "University":
								dgCandidateList.Columns[23].Visible = true;
								break;							 
							case "CollegeAddress":
								dgCandidateList.Columns[24].Visible = true;
								break;
							case "EducationCity":
								dgCandidateList.Columns[25].Visible = true;
								break;	
							case "OtherQualification":
								dgCandidateList.Columns[26].Visible = true;
								break;
							case "MarksObtained":
								dgCandidateList.Columns[27].Visible = true;
								break;
							case "MediumSchool":
								dgCandidateList.Columns[28].Visible = true;
								break;
							case "Medium12th":
								dgCandidateList.Columns[29].Visible = true;
								break;
							case "EmploymentStatus":
								dgCandidateList.Columns[30].Visible = true;
								break;					
							case "OutsideHome":
								dgCandidateList.Columns[31].Visible = true;
								break;
							case "TestCity":
								dgCandidateList.Columns[32].Visible = true;
								break;
							case "TestCentre":
								dgCandidateList.Columns[33].Visible = true;
								break;
							case "TestState":
								dgCandidateList.Columns[34].Visible = true;
								break;
							case "PhotoId":
								dgCandidateList.Columns[35].Visible = true;
								break;
							case "PhotoIdNo":
								dgCandidateList.Columns[36].Visible = true;
								break;
						}
					}
				}
				
			 
		}


		#endregion

		#region GetAllCandidateList()

		private void GetAllCandidateList(BLSearch objBLSearch)
		{
			string strTemplate = null;
			char[] splitter  = {','};
			int intIncrementLoop = 0;
			string[] strTemplateColumn;

			FieldPermission objFieldPermission = new FieldPermission();
			strTemplate = objFieldPermission.GetFieldPermission();

			if(strTemplate != null || strTemplate != "")
			{
				strTemplateColumn = strTemplate.Split(splitter);
				dgCandidateList.AutoGenerateColumns = false;
				dgCandidateList.DataSource = ((DataTable)(objBLSearch.ExportAllCandidateListByETS())).DefaultView;
				dgCandidateList.DataBind(); 


				for(intIncrementLoop = 0; intIncrementLoop <= dgCandidateList.Columns.Count - 1; intIncrementLoop++)
				{
					dgCandidateList.Columns[intIncrementLoop].Visible = false;
				}

				for(intIncrementLoop = 0; intIncrementLoop <= strTemplateColumn.Length - 1; intIncrementLoop++)
				{
					switch(Convert.ToString(strTemplateColumn[intIncrementLoop]))
					{
						case "SerialNo":
							dgCandidateList.Columns[1].Visible = true;
							break;
						case "RegistrationId":
							dgCandidateList.Columns[2].Visible = true;
							break;							
						case "PinNo":
							dgCandidateList.Columns[3].Visible = true;
							break;
						case "FName":
							dgCandidateList.Columns[6].Visible = true;
							break;
						case "MName":
							dgCandidateList.Columns[7].Visible = true;
							break;					
						case "LName":
							dgCandidateList.Columns[8].Visible = true;
							break;
						case "DOB":
							dgCandidateList.Columns[9].Visible = true;							
							break;	
						case "Gender":
							dgCandidateList.Columns[10].Visible = true;
							break;
						case "ResidentialAddress":
							dgCandidateList.Columns[11].Visible = true;
							break;
						case "HomeCity":
							dgCandidateList.Columns[12].Visible = true;
							break;
						case "Pincode":
							dgCandidateList.Columns[13].Visible = true;
							break;
						case "STDCode":
							dgCandidateList.Columns[14].Visible = true;
							break;
						case "LandlinePhoneNo":
							dgCandidateList.Columns[15].Visible = true;
							break;		
						case "MobilePhone":
							dgCandidateList.Columns[16].Visible = true;
							break;					
						case "EmailId":
							dgCandidateList.Columns[17].Visible = true;
							break;
						case "MotherName":
							dgCandidateList.Columns[18].Visible = true;
							break;
						case "FatherName":
							dgCandidateList.Columns[19].Visible = true;
							break;
						case "IncomeRange":
							dgCandidateList.Columns[20].Visible = true;
							break;
						case "BelongTo":
							dgCandidateList.Columns[21].Visible = true;
							break;
						case "QualificationType":
							dgCandidateList.Columns[22].Visible = true;
							break;
						case "University":
							dgCandidateList.Columns[23].Visible = true;
							break;							 
						case "CollegeAddress":
							dgCandidateList.Columns[24].Visible = true;
							break;
						case "EducationCity":
							dgCandidateList.Columns[25].Visible = true;
							break;	
						case "OtherQualification":
							dgCandidateList.Columns[26].Visible = true;
							break;
						case "MarksObtained":
							dgCandidateList.Columns[27].Visible = true;
							break;
						case "MediumSchool":
							dgCandidateList.Columns[28].Visible = true;
							break;
						case "Medium12th":
							dgCandidateList.Columns[29].Visible = true;
							break;
						case "EmploymentStatus":
							dgCandidateList.Columns[30].Visible = true;
							break;					
						case "OutsideHome":
							dgCandidateList.Columns[31].Visible = true;
							break;
						case "TestCity":
							dgCandidateList.Columns[32].Visible = true;
							break;
						case "TestCentre":
							dgCandidateList.Columns[33].Visible = true;
							break;
						case "TestState":
							dgCandidateList.Columns[34].Visible = true;
							break;
						case "PhotoId":
							dgCandidateList.Columns[35].Visible = true;
							break;
						case "PhotoIdNo":
							dgCandidateList.Columns[36].Visible = true;
							break;					

					}
				}
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
	}
}
