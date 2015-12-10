<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>

<%@ Page language="c#" Codebehind="ForgotPassword.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.ForgotPassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Forgot Password</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
        <LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
         <link href="../Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta http-equiv="pragma" content="no-cache">
		<meta http-equiv="cache-control" content="no-cache">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<script language="JavaScript">
		function noBack()
		{
			window.history.forward(0)
		}
		noBack();
		window.onload=noBack;
		window.onpageshow=function(evt){if(evt.persisted)noBack()}
		window.onunload=function(){void(0)}
		</script>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
				var elem = document.getElementById('lblErrorMsg');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
				
				var strText;			      
				//Validate Company Name		
				strText = document.getElementById("txtCompanyName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter company name");
					document.getElementById("txtCompanyName").focus();
					document.getElementById("txtCompanyName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanyName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Name
				strText = document.getElementById("txtSPOCName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter Company SPOC name");
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Email
				strText = document.getElementById("txtCompanySPOCEmail").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +" email ID");
					document.getElementById("txtCompanySPOCEmail").focus();
					document.getElementById("txtCompanySPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanySPOCEmail").style.backgroundColor = 'white';
				}
				
				//Confirmation				
				if (confirm("Are you sure you want to submit?") == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			  function fillOnlyAlphabetValue(eV)
			  {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!IsAlphabet(varValue))
				{
					alert("Please enter alphabets only");
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}	
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
				}
			}
		    
		    function ValidateEmailAddress(eV)
		    {
				var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!(emailCheck(varValue)) && Trim(varValue)!="")
				{
					alert("Please enter valid email address");
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					if(varValue.search("gmail")>=0 || varValue.search("yahoo")>=0 || varValue.search("rediff")>=0 || varValue.search("zapak")>=0 || varValue.search("hotmail")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").focus();
						document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
						return false;
					}
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'white';
				}		        
		        
		    }
		    
		    function fillOnlyNumericValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        if (!IsNumeric(varValue))
				{
					alert("Please enter numeric values");
					//document.getElementById(varControlId).value = "";
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
				}		        
		    }
		    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
		   <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headermenu1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                   <!-- <h2 align="left">&nbsp;</h2>-->
                                <table id="Table2" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td vAlign="top">&nbsp;&nbsp;<asp:linkbutton id="lnkHome" runat="server" 
                                            Width="5px" CssClass="link" onclick="lnkHome_Click" Visible="False">Home</asp:linkbutton>
									</td>
								</tr>
								<tr>
									<td  vAlign="top" align="center"><table cellpadding ="5">
											<tr>
												<td align="center" colSpan="2"><STRONG><FONT size="4"><asp:label id="Label3" runat="server" CssClass="pageheader">Forgot Password</asp:label></FONT></STRONG></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;</td>
											</tr>
											<tr>
												<td><asp:label id="Label1" runat="server" CssClass="label_black_bold">Company Name</asp:label></td>
												<td><asp:textbox id="txtCompanyName" runat="server" Width="265px" CssClass="newUserTextbox" MaxLength="50"></asp:textbox></td>
											</tr>
											<tr>
												<td><asp:label id="Label2" runat="server" CssClass="label_black_bold">Company SPOC Name</asp:label></td>
												<td><asp:textbox id="txtSPOCName" runat="server" Width="265px" CssClass="newUserTextbox" MaxLength="30"></asp:textbox></td>
											</tr>
											<tr>
												<TD align="left"><asp:label id="Label4" runat="server" CssClass="label_black_bold">Company SPOC Email</asp:label></TD>
												<td align="left"><asp:textbox id="txtCompanySPOCEmail" runat="server" Width="265px" CssClass="newUserTextbox"
														MaxLength="30"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="left" colSpan="2"><asp:radiobutton id="rbtnDisplay" runat="server" CssClass="label_black_bold" GroupName="group" Text="Display login details on screen"
														Visible="False"></asp:radiobutton><asp:radiobutton id="rbtnSendEmail" 
                                                        runat="server" CssClass="label_black_bold" GroupName="group"
														Text="Send login details to registered email-ID" Checked="True" Visible="False"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD align="right" colSpan="2" ><FONT class="small_maroon">Login details will be sent to the registered email-ID</FONT></TD>
											</TR>
											<TR>
												<TD align="right" colSpan="2"><asp:button id="btnSubmit" runat="server" CssClass="button" Text="Submit" onclick="btnSubmit_Click"></asp:button>&nbsp;
													<asp:button id="btnBack" runat="server" CssClass="button" Text="Back" onclick="btnBack_Click"></asp:button></TD>
											</TR>
											<tr>
												<td align="center" colSpan="2"></SPAN><asp:label id="lblErrorMsg" runat="server" CssClass="errormessage" Font-Bold="True"></asp:label></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								
							</table>
				 </div>
                        </div>           

               <div class="footer">  <img src="../Web/Images/footer2014.gif" />
               
               </div>

            </div>		
			
		</form>
	</body>
</HTML>
