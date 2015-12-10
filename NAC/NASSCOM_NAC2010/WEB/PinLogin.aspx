<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="PinLogin.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.PinLogin" %>
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
		
			function ValidateLogin()
			{
				var strCheck;
				strCheck = document.getElementById("ddlPhotoIdDocument").value;
				if (strCheck == 0)
				{
					alert("Please enter Photo-ID Document");
					document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'yellow';
					document.getElementById("ddlPhotoIdDocument").focus();
					return false;
				}
	            strCheck = document.getElementById("txtPhotoIdNumber").value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Document No");
					document.getElementById("txtPhotoIdNumber").focus();
					document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
					return false;
				}
	            strCheck = document.getElementById("txtPassword").value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Password");
					document.getElementById("txtPassword").focus();
					document.getElementById("txtPassword").style.backgroundColor = 'yellow';
					return false;
				}
				return true;
			}
				
			function ValidatePIN()
			{
				var strCheck;
				strCheck = document.getElementById("txtSerialNo").value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter the User ID");
					document.getElementById("txtSerialNo").style.background = 'yellow';
					document.getElementById("txtSerialNo").focus();
					return false;
				}
	            strCheck = document.getElementById("txtPIN").value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter the Password");
					document.getElementById("txtPIN").style.background = 'yellow';
					document.getElementById("txtPIN").focus();
					return false;
				}
				return true;
			}
		</script>
	</HEAD>
	<body>
		<FORM id="frmPinLogin" method="post" runat="server">
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
													<td class="header1" vAlign="middle" align="right"></td>
												</tr>
											</table>
										</td>
									</tr>
									<tr vAlign="top" align="center">
										<td class="white_bg" align="center"><br>
											<table cellSpacing="0" cellPadding="10" width="50%" border="0">
												<TBODY>
													<tr>
														<td vAlign="top" align="left" width="50%">
															<table class="blue_bg" cellSpacing="1" cellPadding="5" width="100%" border="0">
																<tr>
																	<td class="yellow_bg main_black_bold" vAlign="middle" align="left" height="25">New 
																		User</td>
																</tr>
																<tr>
																	<td class="white_bg" vAlign="top" align="left" height="147">
																		<table cellSpacing="0" cellPadding="4" width="100%" border="0">
																			<tr>
																				<td class="main_black" vAlign="top" align="left" width="46%">User ID:</td>
																				<td vAlign="top" align="left" width="54%"><asp:textbox id="txtSerialNo" runat="server" MaxLength="10" CssClass="txtbox"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="main_black" vAlign="top" align="left">Password:</td>
																				<td vAlign="top" align="left"><asp:textbox id="txtPIN" runat="server" MaxLength="16" CssClass="txtbox"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="main_black">&nbsp;</td>
																				<td class="main_black"><asp:button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
																			</tr>
																			<tr>
																				<td class="main_black" colSpan="2">
																					<asp:label id="lblMsg" runat="server" Font-Bold="True" Font-Size="XX-Small" ForeColor="Red"></asp:label></td>
																			</tr>
																			<tr>
																				<td class="small_maroon" colSpan="2">As shown in the User ID/Password document 
																					provided to you.
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>												
													</tr>
												</TBODY>
											</table>
										</td>
									</tr>
                                    	<tr vAlign="top" align="center">
										<td class="white_bg main_black" align="Centre" style="HEIGHT: 14px">
											<a class="main_black" href="../Web/RegisteredLogin.aspx" 
                                                style="font-size: xx-small; color: #0000FF; text-decoration: underline"><strong>Already Registered</strong></a></td>
									</tr>
									<tr vAlign="top" align="center">
										<td class="white_bg main_black" align="right" style="HEIGHT: 14px">
											<a class="main_black" href="../default.aspx"><strong>Go Back</strong>&nbsp;&nbsp;&nbsp;</a>
										</td>
									</tr>
									<tr vAlign="top" align="center">
										<td class="white_bg main_black" align="left">
											<span class="small_maroon"><strong>NEW USERS, please note:</strong></span><br>
											<ol>
												<li>
													<span class="small_black">UserId &amp; Password must be used <u>ONLY ONCE</u> while 
														registering for the first time. After successful registration, the UserId &amp; 
														Password will become non-usable/obsolete.</span>
												<li>
													<span class="small_black">If the UserId &amp; Password document is lost, you are 
														requested to contact the centre where the document was issued to you. No 
														issuance of the UserId &amp; Password shall be made in case of any further 
														misplacement/loss of the UserId &amp; Password&nbsp; document.</span></li>
											</ol>
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
			</TD></TR></TABLE></FORM>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
