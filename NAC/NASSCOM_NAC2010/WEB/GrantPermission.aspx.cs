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
	/// Summary description for GrantPermission.
	/// </summary>
	public partial class GrantPermission : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Common.CLCommonFunctions.CheckSession();

			if (!Page.IsPostBack)
			{
				ReadField();
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


		#region Private Method
		private void ReadField()
		{
			string baseDir =  AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;      
			string strFilename = baseDir.Replace("bin","") + "/" + "Web/CandidateField.xml";

			DataSet dsCandidateField = new DataSet("Candidate");
			dsCandidateField.ReadXml(strFilename);
			 
			FieldPermission objFieldPermission = new FieldPermission();
			DataSet dsFieldName = objFieldPermission.getFieldName();

			int iCounter = 0;
			string strFieldName = "";
			string strSelectedField = dsFieldName.Tables[0].Rows[0][1].ToString();
			hdnFieldNames.Value = strSelectedField;

			string strFieldTable = "<table cellSpacing=\"1\" cellPadding=\"1\" width=\"100%\" align=\"center\" border=\"1\">";
			strFieldTable += "<tr class=\"main_black\">";
			for (int i=0;i<dsCandidateField.Tables[0].Rows.Count;i++)
			{
				strFieldName = dsCandidateField.Tables[0].Rows[i][0].ToString();

				strFieldTable += "<td>";
				if (strSelectedField.IndexOf(strFieldName)>=0)
					strFieldTable += "<INPUT type=\"checkbox\" checked name=\""+strFieldName+"\" value=\""+strFieldName+"\" onClick=\"AddPermission('"+strFieldName+"');\">&nbsp;";
				else
					strFieldTable += "<INPUT type=\"checkbox\" name=\""+strFieldName+"\" value=\""+strFieldName+"\" onClick=\"AddPermission('"+strFieldName+"');\">&nbsp;";

				strFieldTable += dsCandidateField.Tables[0].Rows[i][1].ToString();
				strFieldTable += "<td>";

				iCounter++;
				
				if (iCounter == 4)
				{
					strFieldTable += "</tr>";
					strFieldTable += "<tr class=\"main_black\">";
					iCounter = 0;
				}

			}
			strFieldTable += "</tr>";



			strFieldTable +="</table>";

			lblCandidateField.Text = strFieldTable;

		}
		

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string strFieldNames = hdnFieldNames.Value;
			FieldPermission objFieldPermission = new FieldPermission();
			 
			int iUpdatedRecord = objFieldPermission.UpdateField(strFieldNames);

			if (iUpdatedRecord > 0)
			{
				lblMessage.Visible = true;
				ReadField();
			}
		}
		#endregion
	}
}
