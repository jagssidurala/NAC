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
using Common;
using System.Configuration;
using BusinessLayer;
using System.Text;

namespace NASSCOM_NAC.NACdb
{
	/// <summary>
	/// Summary description for SendEmail.
	/// </summary>
	public partial class SendEmail : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(Session["UserType"] == null || Session["UserID"] == null || Session["UserName"] == null)
			{
				Session.Abandon();
				Response.Redirect("../Web/Login.aspx",false);
			}
			else
			{
				lblError.Text ="";
				lblError.Visible = true;
				btnSendEmail.Attributes.Add("OnClick","javascript:return SelectCandidate();");
				//txtEmailBody.Attributes.Add("onkeyup","Count(this,1000);");
				txtareaEmailBody.Attributes.Add("onkeypress","return imposeMaxLength(this,1000,event);");
				if(!IsPostBack)
				{
					DataSet dsTotalMember = new DataSet();
					BLCompanyLogin objBLCompanyLogin = new BLCompanyLogin();
					objBLCompanyLogin.Status = 1;
					if(objBLCompanyLogin.Status != -1)
					{
						dsTotalMember = objBLCompanyLogin.GetMembersByStatus();
						if(dsTotalMember.Tables.Count>0)
						{
							if(dsTotalMember.Tables[0].Rows.Count>0)
							{
								dgMembers.DataSource = dsTotalMember;
								dgMembers.DataBind();
								hdTotalCandidateCount.Value = dsTotalMember.Tables[0].Rows.Count.ToString();
							}
							else
							{
								dgMembers.Visible = false;
								lblError.Visible = true;
								lblError.Text = "No Approved Members";
							}
						}
						else
						{
							dgMembers.Visible = false;
							lblError.Visible = true;
							lblError.Text = "Error occured, cannot retrieve data";
						}
					}
					txtareaEmailBody.Value="Dear member,\r\n\r\nWe have added scores for new NAC event(s).\r\nPlease log in to your account through the given link to access the same.\r\n\r\nhttp://www.nac.nasscom.in/nacdb/LoginPage.aspx\r\n\r\nThank you\r\nNAC Admin";
				}
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdminHome.aspx",false);
		}

		protected void btnSendEmail_Click(object sender, System.EventArgs e)
		{
			if(txtareaEmailBody.Value.Trim()!= "")
			{
				if(txtareaEmailBody.Value.Trim().Length > 1000)
				{
					lblError.Text = "Length of the Email text cannot be greater than 1000 characters.";
					lblError.Visible = true;
					return;
				}
				else
				{
					int countAll = 0;
					StringBuilder body = new StringBuilder();
					CLEmail objCommon = new CLEmail();
					body.Append("<span style=font-size:9.0pt;font-family:Arial>");
					body.Append(txtareaEmailBody.Value.Trim().Replace("\r\n","<br>"));
					body.Append("</span>");
					if(chkSelectAll.Checked)
					{
						foreach(DataGridItem dgItem in dgMembers.Items)
						{
							objCommon.SendMail(body.ToString(),"nacdb@mail.nasscom.in","NAC Updates",dgItem.Cells[4].Text.ToString(),Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
							countAll++;
						}
						if(countAll>0)
						{
							this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Emails sent');</script>");
						}
						foreach(DataGridItem dgItem in dgMembers.Items)
						{
							((CheckBox)dgItem.FindControl("chkSelect")).Checked = false;
						}
						chkSelectAll.Checked = false;
						hdSelectedCandidateCount.Value="0";
					}
					else
					{
						SaveCheckedValueTemporary();
						Hashtable htCheckedValue = new Hashtable();
						if(ViewState["CheckedValue"] != null)
						{
							htCheckedValue = (Hashtable) ViewState["CheckedValue"];
						}

						if (htCheckedValue.Count != 0)
						{
							int count = 0;
							IDictionaryEnumerator Enumerator;
							Enumerator = htCheckedValue.GetEnumerator();
							body = body.Replace("\r\n","<br>");
							while (Enumerator.MoveNext())
							{
								if(Convert.ToBoolean(Enumerator.Value))
								{					  
									objCommon.SendMail(body.ToString(),"nacdb@mail.nasscom.in","NAC Updates",Convert.ToString(Enumerator.Key.ToString()),Convert.ToString(ConfigurationSettings.AppSettings["MailServer"].ToString()));
									count++;
								}
							}
							if(count == 1)
							{
								this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Email sent');</script>");
							}
							else if(count > 1)
							{
								this.Page.RegisterClientScriptBlock("Message", "<script language=javascript>alert('Emails sent');</script>");
							}
							foreach(DataGridItem dgItem in dgMembers.Items)
							{
								((CheckBox)dgItem.FindControl("chkSelect")).Checked = false;
							}
							hdSelectedCandidateCount.Value="0";
						}
						else
						{
							lblError.Text = "Please select at least one member";
							lblError.Visible = true;
						}
					}
				}
			}
			else
			{
				lblError.Text = "Email text cannot be blank.";
				lblError.Visible = true;
			}
		}

		#region SaveCheckedValueTemporary()

		private void SaveCheckedValueTemporary()
		{
			Hashtable htCheckedValue = new Hashtable();
			

			if(ViewState["CheckedValue"] != null)
			{
				htCheckedValue = (Hashtable) ViewState["CheckedValue"];
			}

			if(chkSelectAll.Checked)
			{			   
				if(ViewState["CandidateList"] != null)
				{
					DataTable  dtCandidate = new DataTable();
					int intTotalRowCount = 0;
					int intIncrementLoop = 0;
					dtCandidate = (DataTable) ViewState["CandidateList"];
					intTotalRowCount = dtCandidate.Rows.Count;
					//hdSelectedCandidateCount.Value = intTotalRowCount.ToString();

					for(intIncrementLoop=0;intIncrementLoop <= intTotalRowCount - 1; intIncrementLoop++)
					{
						if(htCheckedValue.Contains(dtCandidate.Rows[intIncrementLoop]["RegistrationId"].ToString().Trim()))
						{
							htCheckedValue[dtCandidate.Rows[intIncrementLoop]["SPOCEmail"].ToString().Trim()] = (bool)(true);
						}
						else
						{
							htCheckedValue.Add(dtCandidate.Rows[intIncrementLoop]["SPOCEmail"].ToString().Trim(),((bool)(true)));
						}
					    
					}

				}
			}
			else
			{
				foreach(DataGridItem dgItem in dgMembers.Items)
				{ 
				 
					if(htCheckedValue.Contains(dgItem.Cells[4].Text.ToString().Trim()))
					{
						htCheckedValue[dgItem.Cells[4].Text.ToString().Trim()] = (bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked;
					}
					else
					{
						htCheckedValue.Add(dgItem.Cells[4].Text.ToString().Trim(),((bool)((CheckBox) dgItem.FindControl("chkSelect")).Checked));
					}
				}
			}
			ViewState["CheckedValue"] = htCheckedValue;
		}

		#endregion

		protected void lnkHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdminHome.aspx",false);
		}



	}
}
