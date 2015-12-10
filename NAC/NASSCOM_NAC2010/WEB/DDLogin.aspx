<%@ Page language="c#" Codebehind="DDLogin.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.DDLogin" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Login</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateNewUser(txtFirstNameCI,txtLastNameCI,txtDdNoCI)
			{
				var strCheck;
				strCheck = document.getElementById(txtFirstNameCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter First name");
					document.getElementById(txtFirstNameCI).style.backgroundColor = 'yellow';
					document.getElementById(txtFirstNameCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtFirstNameCI).style.backgroundColor = 'white';
				}
				strCheck = document.getElementById(txtLastNameCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Last name");
					document.getElementById(txtLastNameCI).style.backgroundColor = 'yellow';
					document.getElementById(txtLastNameCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtLastNameCI).style.backgroundColor = 'white';
				}
				strCheck = document.getElementById(txtDdNoCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Demand name");
					document.getElementById(txtDdNoCI).style.backgroundColor = 'yellow';
					document.getElementById(txtDdNoCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtDdNoCI).style.backgroundColor = 'white';
				}
				
				return true;
			}

			function ValidateLogin(ddlPhotoIdDocumentCI,txtPhotoIdNumberCI,txtPasswordCI)
			{
				var strCheck;
				strCheck = document.getElementById(ddlPhotoIdDocumentCI).value;
				
				if (strCheck == 0)
				{
					alert("Please select Photo-ID document");
					document.getElementById(ddlPhotoIdDocumentCI).style.background = 'yellow';
					document.getElementById(ddlPhotoIdDocumentCI).focus();
					return false;
				}
				else
				{
					document.getElementById(ddlPhotoIdDocumentCI).style.background = 'white';
				}
				strCheck = document.getElementById(txtPhotoIdNumberCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Photo-ID document No");
					document.getElementById(txtPhotoIdNumberCI).style.background = 'yellow';
					document.getElementById(txtPhotoIdNumberCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtPhotoIdNumberCI).style.backgroundColor = 'white';
				}
				strCheck = document.getElementById(txtPasswordCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Password");
					document.getElementById(txtPasswordCI).style.backgroundColor = 'yellow';
					document.getElementById(txtPasswordCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtPasswordCI).style.backgroundColor = 'white';
				}
				
				return true;
			}

		</script>
	</HEAD>
	<body>
		<FORM id="frmForgetPassword" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TBODY>
					<tr>
						<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
						<td class="white_bg" vAlign="top" align="center">
							<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<tr class="white_bg" vAlign="top" align="left">
										<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
									</tr>
									<tr class="blue_bg" vAlign="top" align="left">
										<td class="header1" vAlign="middle">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr vAlign="top">
													<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Login</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr vAlign="top" align="center">
										<td class="white_bg" align="center"><br>
											<table width="100%" border="0" cellspacing="0" cellpadding="10">
												<TBODY>
													<tr>
														<td width="50%" align="left" valign="top">
															<table width="100%" border="0" cellpadding="5" cellspacing="1" class="blue_bg">
																<tr>
																	<td height="25" align="left" valign="middle" class="yellow_bg main_black_bold">New 
																		User</td>
																</tr>
																<tr>
																	<td height="146" align="left" valign="top" class="white_bg">
																		<table width="100%" border="0" cellspacing="0" cellpadding="3">
																			<tr>
																				<td width="46%" align="left" valign="top" class="main_black">First Name:</td>
																				<td width="54%" align="left" valign="top">
																					<asp:TextBox id="txtFirstName" CssClass="txtbox" runat="server" MaxLength="30"></asp:TextBox></td>
																			</tr>
																			<tr>
																				<td align="left" valign="top" class="main_black">Middle Name:</td>
																				<td align="left" valign="top"><asp:TextBox id="txtMiddleName" CssClass="txtbox" runat="server" MaxLength="30"></asp:TextBox></td>
																			</tr>
																			<tr>
																				<td align="left" valign="top" class="main_black">Last Name:</td>
																				<td align="left" valign="top"><asp:TextBox id="txtLastName" CssClass="txtbox" runat="server" MaxLength="30"></asp:TextBox></td>
																			</tr>
																			<tr>
																				<td align="left" valign="top" class="main_black">Demand Draft No:</td>
																				<td align="left" valign="top" class="main_black"><asp:TextBox id="txtDdNo" CssClass="txtbox" runat="server" MaxLength="20"></asp:TextBox></td>
																			</tr>
																			<tr>
																				<td class="main_black">&nbsp;</td>
																				<td class="main_black"><asp:button id="btnSubmit" runat="server" Text="Submit"></asp:button></td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>
														<td width="50%" align="left" valign="top"><table width="100%" border="0" cellpadding="5" cellspacing="1" class="blue_bg">
																<TBODY>
																	<tr>
																		<td height="25" align="left" valign="middle" class="yellow_bg main_black_bold">Already 
																			Registered
																		</td>
																	</tr>
																	<tr>
																		<td height="130" align="left" valign="top" class="white_bg"><table width="100%" border="0" cellspacing="0" cellpadding="2">
																				<TBODY>
																					<tr>
																						<td width="60%" align="left" valign="top" class="main_black">Photo-ID Document<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td width="40%" align="left" valign="top" class="main_black">
																							<asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" CssClass="txtarea"></asp:dropdownlist>
																						</td>
																					</tr>
																					<tr>
																						<td align="left" valign="top" class="main_black">Document No:<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td align="left" valign="top" class="main_black"><asp:textbox id="txtPhotoIdNumber" MaxLength="15" Runat="server" CssClass="txtbox"></asp:textbox></td>
																					</tr>
																					<tr>
																						<td align="left" valign="top" class="main_black">Password:<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td align="left" valign="top" class="main_black"><asp:textbox id="txtPassword" Runat="server" CssClass="txtbox" TextMode="Password" MaxLength="8"></asp:textbox></td>
																					</tr>
																					<tr>
																						<td class="main_black">&nbsp;</td>
																						<td class="main_black"><asp:button id="btnLogin" runat="server" Text="Login"></asp:button></td>
																					</tr>
																					<tr>
																						<td class="main_black">&nbsp;</td>
																						<td class="main_black"><A class="tiny_blue" href="ForgotPassword.aspx"><b>Forgot Password</b></A></td>
																					</tr>
																				</TBODY>
																			</table>
																		</td>
																	</tr>
																</TBODY>
															</table>
														</td>
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
								</TBODY>
							</table>
						</td>
						<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					</tr>
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
						<TD class="white_bg" vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
						<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
					</TR>
				</TBODY>
			</table>
			</TD></TR></TABLE>
		</FORM>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
