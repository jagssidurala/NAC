using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLayer;
using System.Threading;

namespace NASSCOM_NAC.Web
{
	/// <summary>
	/// Summary description for PinLogin.
	/// </summary>
	public partial class PinLogin : System.Web.UI.Page
	{
		public string strStatus = "";
		public string strStartDate = "";
		public string strEndDate = "";
		public string strStartTime = "";
		public string strEndTime = "";
		public string strDate = "";	
		
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

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if(Request.QueryString["NAC"] == "infotech")
				{
					Session["Centre"] = "Infotech Ent. Ltd.";
					Session["HomeURL"] = "http://localhost/NASSCOM_NAC/web/Andhra_Pradesh.aspx?State=Andhra Pradesh";
					Session["StateId"] = 8;
					Session["State"] = "Andhra Pradesh";
                    //FillPhotoIdDetail();
					//return;
				}
				if(Request.QueryString["NAC"] != "infotech")
				{
					if(Request.UrlReferrer != null)
					{
						if(Session["HomeURL"] == null)
						{
							Session["HomeURL"] = Request.UrlReferrer.ToString();
						}
					
                        //FillPhotoIdDetail();
					}
					else
					{
						Response.Redirect("../Default.aspx");
					}
				}
			}
			if(Session["StateId"]== null && Session["State"] == null)
			{
				Response.Redirect("../Default.aspx");
			}
			//			else
			//			{
			//				int intStateId = 0;				
			//				
			//				intStateId = Convert.ToInt32(Session["StateId"]);
			//				BLRegistration objBLRegistration = new BLRegistration();
			//				strStatus = objBLRegistration.CheckStateCentreIsActive(intStateId);
			//				if(strStatus != "")
			//				{					
			//					Session["RegistrationCloseDate"] = strStatus;
			//					DateTime dtTempTime = Convert.ToDateTime(Session["RegistrationCloseDate"]); 
			//					strDate =  dtTempTime.Day.ToString() + " " + MonthYear(dtTempTime.Month.ToString()) + " " + dtTempTime.Year.ToString();
			//					//Logic to check if registration start date is greater then current date , dispay a message for not to register
			//					
			//					StringBuilder sbAppend = new StringBuilder();
			//					sbAppend.Append("<script language='JavaScript'>");
			//					sbAppend.Append("function CentreCloseMessage()");
			//					sbAppend.Append("{");
			//					//added for Sona college Nac
			//					sbAppend.Append("if("+intStateId.ToString()+"==18)");
			//					sbAppend.Append("{");
			//					sbAppend.Append("alert('Sona NAC test stands cancelled!'); return false; ");
			//					sbAppend.Append("}");
			//					//Sona collge message end
			//					sbAppend.Append("if("+intStateId.ToString()+"==100)");
			//					sbAppend.Append("{");
			//					sbAppend.Append("alert('Registration for Gujarat NAC will start shortly. Thank you!'); return false; ");
			//					sbAppend.Append("}");
			//					sbAppend.Append("else");
			//					sbAppend.Append("{");
			//					sbAppend.Append("alert('Sorry! The last date for NAC registration was ");
			//					sbAppend.Append(strDate);
			//					sbAppend.Append("(6:00 pm).                                                                    ");
			//					sbAppend.Append("Keep watching the ");
			//					sbAppend.Append(Convert.ToString(Session["State"])); 
			//					sbAppend.Append(" NAC page for details on next round of NAC.'); return false; ");
			//					sbAppend.Append("}");
			//					sbAppend.Append("}");
			//					sbAppend.Append("</script>");
			//					Response.Write(sbAppend.ToString());
			//					
			//					btnSubmit.Attributes.Add("onclick","return CentreCloseMessage();");					 
			//				}
			/*
						else
						{
							int intStateId = 0;				
				
							intStateId = Convert.ToInt32(Session["StateId"]);
							BLRegistration objBLRegistration = new BLRegistration();
							DataSet ds = objBLRegistration.CheckStateCentreIsActive(intStateId);
							if(ds.Tables[0].Rows[0][0].ToString().Trim()!="")
							{
								Session["RegistrationStartDate"] = ds.Tables[0].Rows[0][1].ToString().Trim();
								Session["RegistrationCloseDate"] = ds.Tables[0].Rows[0][2].ToString().Trim();
	
								DateTime dtStartTime = Convert.ToDateTime(Session["RegistrationStartDate"]); 
								strStartDate =  dtStartTime.Day.ToString() + " " + MonthYear(dtStartTime.Month.ToString()) + " " + dtStartTime.Year.ToString();					
								strStartTime = dtStartTime.ToShortTimeString().ToString().ToLower();
								DateTime dtCloseTime = Convert.ToDateTime(Session["RegistrationCloseDate"]); 
								strEndDate =  dtCloseTime.Day.ToString() + " " + MonthYear(dtCloseTime.Month.ToString()) + " " + dtCloseTime.Year.ToString();
								//strEndDate = dtCloseTime.ToString();
								strEndTime = dtCloseTime.ToShortTimeString().ToString().ToLower();

								if(ds.Tables[0].Rows[0][0].ToString().Trim()=="End")
								{						
									StringBuilder sbAppend = new StringBuilder();
									sbAppend.Append("<script language='JavaScript'>");
									sbAppend.Append("function CentreCloseMessage()");
									sbAppend.Append("{");
									//added for Sona college Nac
									sbAppend.Append("if("+intStateId.ToString()+"==18)");
									sbAppend.Append("{");
									sbAppend.Append("alert('Sona NAC test stands cancelled!'); return false; ");
									sbAppend.Append("}");
									//Sona collge message end					
									sbAppend.Append("else");
									sbAppend.Append("{");
									//sbAppend.Append("alert('Sorry! The last date for NAC registration was ");
									sbAppend.Append("alert('Sorry! The last date for ");
									sbAppend.Append(Convert.ToString(Session["State"]));
									sbAppend.Append(" NAC registrations was ");
									sbAppend.Append(strEndDate);
									sbAppend.Append(" (");		
									sbAppend.Append(strEndTime);
									//sbAppend.Append("). ");
									sbAppend.Append(").'); return false; ");
									//sbAppend.Append("Keep watching the ");
									//sbAppend.Append(Convert.ToString(Session["State"])); 
									//sbAppend.Append(" NAC page for details on next round of NAC.'); return false; ");
									sbAppend.Append("}");
									sbAppend.Append("}");
									sbAppend.Append("</script>");
									Response.Write(sbAppend.ToString());
					
									btnSubmit.Attributes.Add("onclick","return CentreCloseMessage();");					 
								}
								else if(ds.Tables[0].Rows[0][0].ToString().Trim()=="Not Started")
								{						
									StringBuilder sbAppend = new StringBuilder();
									sbAppend.Append("<script language='JavaScript'>");
									sbAppend.Append("function CentreCloseMessage()");
									sbAppend.Append("{");
									//added for Sona college Nac
									sbAppend.Append("if("+intStateId.ToString()+"==18)");
									sbAppend.Append("{");
									sbAppend.Append("alert('Sona NAC test stands cancelled!'); return false; ");
									sbAppend.Append("}");
									//Sona collge message end					
									sbAppend.Append("else");
									sbAppend.Append("{");
									sbAppend.Append("alert('Registrations for ");					
									sbAppend.Append(Convert.ToString(Session["State"]));					
									sbAppend.Append(" NAC will start from ");
									sbAppend.Append(strStartDate);
									sbAppend.Append(" (");		
									sbAppend.Append(strStartTime);
									sbAppend.Append(") ");	
									sbAppend.Append(". Thank you!'); return false; ");
									sbAppend.Append("}");
									sbAppend.Append("}");
									sbAppend.Append("</script>");
									Response.Write(sbAppend.ToString());
					
									btnSubmit.Attributes.Add("onclick","return CentreCloseMessage();");					 
								}
								else if(ds.Tables[0].Rows[0][0].ToString().Trim()=="No Test")
								{						
									StringBuilder sbAppend = new StringBuilder();
									sbAppend.Append("<script language='JavaScript'>");
									sbAppend.Append("function CentreCloseMessage()");
									sbAppend.Append("{");
									//added for Sona college Nac
									sbAppend.Append("if("+intStateId.ToString()+"==18)");
									sbAppend.Append("{");
									sbAppend.Append("alert('Sona NAC test stands cancelled!'); return false; ");
									sbAppend.Append("}");
									//Sona collge message end					
									sbAppend.Append("else");
									sbAppend.Append("{");
									sbAppend.Append("alert('Currently, no round of NAC test is being organized in your state. Please visit after some time, thanks!'); return false; ");				
				
									sbAppend.Append("}");
									sbAppend.Append("}");
									sbAppend.Append("</script>");
									Response.Write(sbAppend.ToString());
					
									btnSubmit.Attributes.Add("onclick","return CentreCloseMessage();");					 
								}
				
								else
								{
									btnSubmit.Attributes.Add("onclick","return ValidatePIN();");
								}
							}
				 
						}*/
			
            //btnLogin.Attributes.Add("onclick","return ValidateLogin();");
			btnSubmit.Attributes.Add("onclick","return ValidatePIN();");
			DefaultButton(ref this.txtSerialNo,ref this.btnSubmit);
			DefaultButton(ref this.txtPIN,ref this.btnSubmit);
            
            //DefaultButton(ref this.txtPhotoIdNumber,ref this.btnLogin);
            //DefaultButton(ref this.txtPassword,ref this.btnLogin);
            //DefaultButtonDDL(ref this.ddlPhotoIdDocument,ref this.btnLogin);
		}
		#endregion

		#region DefaultButton()

		private void DefaultButton(ref TextBox objTextControl, ref Button objDefaultButton) 
		{
			StringBuilder sScript = new StringBuilder();							 
			sScript.Append("<SCRIPT language='javascript'> "); 
			sScript.Append("function fnTrapKD(btn){" ); 
			sScript.Append(" if (document.all){"); 
			sScript.Append(" if (event.keyCode == 13)") ;
			sScript.Append(" { "); 
			sScript.Append(" event.returnValue=false;"); 
			sScript.Append(" event.cancel = true;"); 
			sScript.Append(" btn.click();"); 
			sScript.Append(" } "); 
			sScript.Append(" } "); 
			sScript.Append("}"); 
			sScript.Append("</SCRIPT>");				 
			objTextControl.Attributes.Add("onkeydown", "fnTrapKD(document.all." + objDefaultButton.ClientID + ")"); 

			if(!Page.IsStartupScriptRegistered("ForceDefaultToScript"))
			{
				Page.RegisterStartupScript("ForceDefaultToScript", sScript.ToString());
			}
		}

		#endregion

		#region DefaultButtonDDL()

		private void DefaultButtonDDL(ref DropDownList objDDLControl, ref Button objDefaultButton) 
		{
			StringBuilder sScript = new StringBuilder();							 
			sScript.Append("<SCRIPT language='javascript'> "); 
			sScript.Append("function fnTrapKDDDL(btn){" ); 
			sScript.Append(" if (document.all){"); 
			sScript.Append(" if (event.keyCode == 13)") ;
			sScript.Append(" { "); 
			sScript.Append(" event.returnValue=false;"); 
			sScript.Append(" event.cancel = true;"); 
			sScript.Append(" btn.click();"); 
			sScript.Append(" } "); 
			sScript.Append(" } "); 
			sScript.Append("}"); 
			sScript.Append("</SCRIPT>");				 
			objDDLControl.Attributes.Add("onkeydown", "fnTrapKDDDL(document.all." + objDefaultButton.ClientID + ")"); 

			if(!Page.IsStartupScriptRegistered("ForceDefaultToScriptDDL"))
			{
				Page.RegisterStartupScript("ForceDefaultToScriptDDL", sScript.ToString());
			}
		}

		#endregion

		#region Month
		/// <summary>
		/// Name of the months.
		/// </summary>
		enum Month
		{
			January,
			February,
			March,
			April,
			May,
			June,
			July,
			August,
			September,
			October,
			November,
			December
		}
		#endregion

		#region MonthYear
		/// <summary>
		/// Computes name of the month based on respective value of month in a given date.
		/// </summary>
		/// <param name="strMonth">Value of month in given date</param>
		/// <returns>Name of the month</returns>
		private string MonthYear(string strMonth)
		{
			string strMonthName = null;			 

			switch (strMonth)
			{
				case "1": strMonthName = Month.January.ToString();
					break;
				case "2": strMonthName = Month.February.ToString();
					break;
				case "3": strMonthName = Month.March.ToString();
					break;
				case "4": strMonthName = Month.April.ToString();
					break;
				case "5": strMonthName = Month.May.ToString();
					break;
				case "6": strMonthName = Month.June.ToString();
					break;
				case "7": strMonthName = Month.July.ToString();
					break;
				case "8": strMonthName = Month.August.ToString();
					break;
				case "9": strMonthName = Month.September.ToString();
					break;
				case "10": strMonthName = Month.October.ToString();
					break;
				case "11": strMonthName = Month.November.ToString();
					break;
				case "12": strMonthName = Month.December.ToString();
					break;
			}
			return strMonthName;
		}
		#endregion

		#region btnSubmit_Click
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(Session["StateId"]== null)
			{
				Response.Redirect("../Default.aspx");
			}
			else
			{
				String strSerialNo = txtSerialNo.Text.ToString().Trim();
				String strPinNo = txtPIN.Text.ToString().Trim();	
				string centreName="";

				try
				{
					BusinessLayer.BLLogin oPin = new BusinessLayer.BLLogin();
					DataSet dsPIN = oPin.ValidatePin(strSerialNo,strPinNo);
				
					if (dsPIN.Tables[0].Rows.Count > 0)
					{
						bool status=Convert.ToBoolean(dsPIN.Tables[0].Rows[0]["Active"].ToString());
						if (status==false)		//Checking if Pin is inactive
						{
							BLRegistration objBLRegistration = new BLRegistration();
							DataSet dsCentreStatus= objBLRegistration.IsTestActive(strSerialNo,strPinNo);
									
							strStatus= dsCentreStatus.Tables[0].Rows[0][0].ToString();
							centreName=dsCentreStatus.Tables[0].Rows[0][1].ToString();
				
							if(strStatus != "")		//Checking if registration last date is closed
							{
								Session["RegistrationCloseDate"] = strStatus;
								DateTime dtTempTime = Convert.ToDateTime(Session["RegistrationCloseDate"]); 
								strDate =  dtTempTime.Day.ToString() + " " + MonthYear(dtTempTime.Month.ToString()) + " " + dtTempTime.Year.ToString();		
								strEndTime = dtTempTime.ToShortTimeString().ToString().ToLower();

								StringBuilder sbAppend = new StringBuilder();
								sbAppend.Append("<script language='JavaScript'>");
								sbAppend.Append("alert('Sorry! The last date for ");
								sbAppend.Append("\"");
								sbAppend.Append(centreName);
								sbAppend.Append("\"");
								sbAppend.Append(" NAC registrations was ");
								sbAppend.Append(strDate);
								sbAppend.Append(" (");		
								sbAppend.Append(strEndTime);					
								sbAppend.Append(").')");
								sbAppend.Append("</script>");					

								String strScript = sbAppend.ToString();
								Page.RegisterStartupScript("myScript", strScript);	
								lblMsg.Text = "Sorry! The last date for "+ centreName + " NAC registrations was " + strDate + "(" + strEndTime + ").";
							}
							else if(Convert.ToInt32(dsCentreStatus.Tables[1].Rows[0][0].ToString()) > 0)
							{
								HttpContext.Current.Session["SerialNo"] = Convert.ToString(dsPIN.Tables[0].Rows[0]["SerialNo"]);
								HttpContext.Current.Session["PIN"] = Convert.ToString(dsPIN.Tables[0].Rows[0]["PinNo"]);
 						
								Response.Redirect("Registration.aspx",false);
							}
								
							else
							{
								String strScript = "<script language='JavaScript'>alert('The center, you are trying to register for, is full.\\nPlease contact your College TPO to get ID for other center.')</script>";
								Page.RegisterStartupScript("myAlertScript", strScript);	
								lblMsg.Text = "The center, you are trying to register for, is full. Please contact your College TPO to get ID for other center.";
							}
						}
						else
						{
							HttpContext.Current.Session["SerialNo"] = null;
							HttpContext.Current.Session["PIN"] = null;
							lblMsg.Text = "Either UserID or Password has already been utilized";
						}
							
					}
					else
					{
						HttpContext.Current.Session["SerialNo"] = null;
						HttpContext.Current.Session["PIN"] = null;
						lblMsg.Text = "Invalid userid or password ";	
					}
				}
							
				catch (ThreadAbortException ex)
				{
					throw ex;
				}
				catch (Exception ex)
				{
					ErrorLogger.ErrorRoutine(false,ex);
				}

			}
			
			//Response.Redirect("registration.aspx");
		}
		#endregion

	}
}
