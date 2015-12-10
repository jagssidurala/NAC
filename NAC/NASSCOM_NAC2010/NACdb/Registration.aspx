<%@ Page language="c#" Codebehind="Registration.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.Registration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registration</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<LINK rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css">
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
				//alert(document.getElementById("lblError").innerText);
				//alert(document.getElementById('lblError').textContent);
				//document.getElementById("lblError").innerText = '';
				//document.getElementById('lblError').textContent = '';
				
				var elem = document.getElementById('lblError');
			
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
				
				//Validate Company Address		
				strText = document.getElementById("txtCompanyAddress").value;
				if (Trim(strText) == "")
				{
					alert("Please enter company address");
					document.getElementById("txtCompanyAddress").focus();
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'yellow';
					return false;
				}
				
				else if(strText.length > 100)
				{
					alert("CompanyAddress exceeding maximum limit of 100 characters.");
					document.getElementById("txtCompanyAddress").focus();
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'yellow';
					return false;
				}
				
				else
				{
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'white';
				}
				
				//Validate Official Phone
				strText = document.getElementById("txtOfficialPhone").value;
				if (Trim(strText) == "")
				{
					alert("Please enter official phone number");
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if(strText.length < 7)
				{
					alert("Official Phone No. can't be less than 7 digits");
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsNumeric(strText))
				{
					alert("Please enter a valid official phone number");
					document.getElementById("txtOfficialPhone").value ='';
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Name
				strText = document.getElementById("txtSPOCName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter SPOC name");
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsAlphabet(strText))
				{
					alert("Please enter a valid SPOC name");
					document.getElementById("txtSPOCName").value ='';
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Phone
				strText = document.getElementById("txtSPOCPhone").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +"'s phone number");
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if(strText.length < 7)
				{
					alert("Please enter a valid "+ document.getElementById("txtSPOCName").value +"'s phone number. Can't be less than 7 digits");
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsNumeric(strText))
				{
					alert("Please enter a valid "+ document.getElementById("txtSPOCName").value +"'s phone number");
					document.getElementById("txtSPOCPhone").value='';
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Email
				strText = document.getElementById("txtSPOCEmail").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +"'s email ID");
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!(emailCheck(strText)) && Trim(strText)!="")
				{
					alert("Please enter valid email address");
					document.getElementById("txtSPOCEmail").value='';
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else if(Trim(strText).search("@gmail.com")>=0 || Trim(strText).search("@yahoo.co")>=0 || Trim(strText).search("@rediff.co")>=0 || Trim(strText).search("@zapak.co")>=0 || Trim(strText).search("@hotmail.co")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").value='';
						document.getElementById("txtSPOCEmail").focus();
						document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
						return false;
					}
					
				
				else
				{
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'white';
				}
				
				//Validate declaration
				if(document.getElementById("chkDeclaration").checked == false)
			    {
			        alert("Please accept the Declaration");
					document.getElementById("chkDeclaration").focus();
					document.getElementById("chkDeclaration").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("chkDeclaration").style.backgroundColor = 'white';
				}
				
				if (confirm("Are you sure you want to submit?") == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			 function checkBlankValue(eV)
			  {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (Trim(varValue) != "")
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
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
					document.getElementById(varControlId).value='';
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
					document.getElementById("txtSPOCEmail").value='';
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					if(varValue.search("@gmail.com")>=0 || varValue.search("@yahoo.co")>=0 || varValue.search("@rediff.co")>=0 || varValue.search("@zapak.co")>=0 || varValue.search("@hotmail.co")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").value='';
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
		        varControl = document.getElementById(varControlId);
		        if (!IsNumeric(varValue))
				{
					alert("Please enter numeric values");
					document.getElementById(varControlId).value = '';
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
				}		        
		    }
		    
		     function imposeMaxLength(Object, MaxLen, evt)
				{
					evt = (evt) ? evt : event;
					var charCode = (evt.charCode) ? evt.charCode :((evt.which) ? evt.which : evt.keyCode);
					if ((charCode == 8) || (charCode == 46)|| (charCode == 9)|| (charCode == 16))
					{
						return true;
					} 
					else 
					{
					//alert(key.keyCode);
					return (Object.value.length <= MaxLen);
					}
				}
		 
		 function isNumberKey(evt)
			{
				var charCode = (evt.which) ? evt.which : event.keyCode
				if (charCode > 31 && (charCode < 48 || charCode > 57))
					return false;

				return true;
			}
      
		 function isAlpha(code)
			{
			
				//var code = e.keyCode ? event.keyCode : e.which ? e.which : e.charCode;
				//alert(code);
				if ((code >= 65 && code <= 90)||(code >= 97 && code <= 122) ||(code >= 35 && code <= 40) || code==46 || code==8 || code==17 || code==127 || code==9 || code==16  || code==32 || code==46 )
				{return true;}
				else {return false;}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<table id="table1" border="0" cellSpacing="0" cellPadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellSpacing="0" cellPadding="0" width="888">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td rowSpan="9" width="4">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">
										<h1>&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><TABLE style="WIDTH: 914px; HEIGHT: 293px" id="Table1" border="0" cellSpacing="1" align="center">
											<TR>
												<TD colSpan="2" align="center"><STRONG><FONT size="4"><asp:label id="Label7" runat="server" CssClass="pageheader">Company Registration Form</asp:label></FONT></STRONG></TD>
											</TR>
											<tr>
												<td colSpan="2">&nbsp;</td>
											</tr>
											<TR>
												<TD><asp:label id="Label1" runat="server" CssClass="label_black_bold">Company Name</asp:label></TD>
												<TD><asp:textbox id="txtCompanyName" runat="server" CssClass="newUserTextbox" Width="180px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label2" runat="server" CssClass="label_black_bold">Company Address</asp:label></TD>
												<TD><asp:textbox id="txtCompanyAddress" runat="server" Width="180px" MaxLength="100" Font-Names="Tahoma"
														BorderStyle="Solid" BorderColor="#CCCCCC" Font-Size="11px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label3" runat="server" CssClass="label_black_bold">Official Phone No.</asp:label></TD>
												<TD><asp:textbox id="txtOfficialPhone" runat="server" CssClass="newUserTextbox" Width="180px" MaxLength="15"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label4" runat="server" CssClass="label_black_bold">Company SPOC for NAC</asp:label></TD>
												<TD><asp:textbox id="txtSPOCName" runat="server" CssClass="newUserTextbox" Width="180px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label5" runat="server" CssClass="label_black_bold">Company SPOC's phone number</asp:label></TD>
												<TD><asp:textbox id="txtSPOCPhone" runat="server" CssClass="newUserTextbox" Width="180px" MaxLength="15"></asp:textbox></TD>
											</TR>
											<TR>
												<TD><asp:label id="Label6" runat="server" CssClass="label_black_bold">Company SPOC's email ID</asp:label></TD>
												<TD><asp:textbox id="txtSPOCEmail" runat="server" CssClass="newUserTextbox" Width="180px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<tr>
												<td colSpan="2">&nbsp;</td>
											</tr>
											<TR>
												<TD colSpan="2"><asp:checkbox id="chkDeclaration" runat="server" CssClass="small_maroon" Font-Bold="True" Text="We confirm that the NAC candidate data, obtained through this website, will not be shared with any external stakeholder and be used by our organization purely for recruitment purposes"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD colSpan="2" align="center"><asp:button id="btnSubmit" runat="server" CssClass="button" Text="Submit" onclick="btnSubmit_Click"></asp:button>&nbsp;&nbsp;<asp:button id="btnCancel" tabIndex="1" runat="server" CssClass="button" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
											</TR>
											<tr>
												<td colSpan="2" align="center">&nbsp;
													<asp:label id="lblError" runat="server" CssClass="errorMessage"></asp:label></td>
											</tr>
											<TR>
												<td colSpan="2">
													<ul>
														<li>
															<font style="FONT-FAMILY: Verdana, Arial; COLOR: navy; FONT-SIZE: 11px">This is a 
																'one-time registration' formality to be fulfilled by each endorsing company to 
																access the NAC candidate database. </font>
														<li>
															<FONT style="FONT-FAMILY: Verdana, Arial; COLOR: navy; FONT-SIZE: 11px">Upon 
																submission of this form, the request will go to NASSCOM for final approval. </FONT>
														<li>
															<FONT style="FONT-FAMILY: Verdana, Arial; COLOR: navy; FONT-SIZE: 11px">NASSCOM 
																will approve the request only after having the 'NAC endorsement letter' in 
																place, duly signed by the company as well as NASSCOM SPOC. </FONT>
														<li>
															<FONT style="FONT-FAMILY: Verdana, Arial; COLOR: navy; FONT-SIZE: 11px">With 
																NASSCOM's approval, User ID/Password# (for database access) will be issued to 
																the authorized company SPOC through e-mail. </FONT>
														<li>
															<FONT style="FONT-FAMILY: Verdana, Arial; COLOR: navy; FONT-SIZE: 11px">Access to 
																NAC database will be available to the company SPOC for the duration defined in 
																the endorsement letter signed. In order to continue with the database access 
																after the defined period, the agreement will need to be renewed.</FONT>
														</li>
													</ul>
												</td>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../Web/Images/footer2014.gif"><A href="mailto:nac@nasscom.in"></A></DIV>
										</DIV>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
