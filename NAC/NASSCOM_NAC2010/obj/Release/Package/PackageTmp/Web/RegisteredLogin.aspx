<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="RegisteredLogin.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.RegisteredLogin" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registered Login</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">


		    function ValidateLogin() {
		        var strCheck;
		        strCheck = document.getElementById("txtNacId").value;
		        if (Trim(strCheck) == "") {
		            alert("Please enter Nac Id");
		            document.getElementById("txtNacId").focus();
		            document.getElementById("txtNacId").style.backgroundColor = 'yellow';
		            return false;
		        }
		        strCheck = document.getElementById("ddlPhotoIdDocument").value;
		        if (strCheck == 0) {
		            alert("Please enter Photo-ID Document");
		            document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'yellow';
		            document.getElementById("ddlPhotoIdDocument").focus();
		            return false;
		        }
		        strCheck = document.getElementById("txtPhotoIdNumber").value;
		        if (Trim(strCheck) == "") {
		            alert("Please enter Document No");
		            document.getElementById("txtPhotoIdNumber").focus();
		            document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        strCheck = document.getElementById("txtPassword").value;
		        if (Trim(strCheck) == "") {
		            alert("Please enter Password");
		            document.getElementById("txtPassword").focus();
		            document.getElementById("txtPassword").style.backgroundColor = 'yellow';
		            return false;
		        }

		        return true;
		    }

		    function ValidatePIN() {
		        var strCheck;
		        strCheck = document.getElementById("txtSerialNo").value;
		        if (Trim(strCheck) == "") {
		            alert("Please enter the Serial No.");
		            document.getElementById("txtSerialNo").style.background = 'yellow';
		            document.getElementById("txtSerialNo").focus();
		            return false;
		        }
		        strCheck = document.getElementById("txtPIN").value;
		        if (Trim(strCheck) == "") {
		            alert("Please enter the PIN No.");
		            document.getElementById("txtPIN").style.background = 'yellow';
		            document.getElementById("txtPIN").focus();
		            return false;
		        }
		        return true;
		    }

		    function fillOnlyNumericValue(eV) {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        // varSubString = document.getElementById(varControlId).value;
		        // varSubString = varSubString.substring(0,varSubString.length - 1);



		        if (!IsNumeric(varValue)) {

		            alert("Please enter numeric data");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		        }
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
																<TBODY>
																	<tr>
																		<td class="yellow_bg main_black_bold" vAlign="middle" align="left" height="25">Already 
																			Registered
																		</td>
																	</tr>
																	<tr>
																		<td class="white_bg" vAlign="top" align="left" height="155">
																			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
																				<TBODY>
																					<tr>
																						<td class="main_black" vAlign="top" align="left" width="60%">NAC 
																							Registration&nbsp;ID</td>
																						<td class="main_black" vAlign="top" align="left"><asp:textbox id="txtNacId" 
                                                                                                MaxLength="100" CssClass="txtbox" Runat="server"></asp:textbox></td>
																					</tr>
																					<tr>
																						<td class="main_black" vAlign="top" align="left" width="60%">Photo-ID Document<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td class="main_black" vAlign="top" align="left" width="40%"><asp:dropdownlist id="ddlPhotoIdDocument" CssClass="txtarea" Runat="server"></asp:dropdownlist></td>
																					</tr>
																					<tr>
																						<td class="main_black" vAlign="top" align="left">Document No:<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td class="main_black" vAlign="top" align="left"><asp:textbox id="txtPhotoIdNumber" MaxLength="100" CssClass="txtbox" Runat="server"></asp:textbox></td>
																					</tr>
																					<tr>
																						<td class="main_black" vAlign="top" align="left">Password:<br>
																							<span class="tiny_blue">(as filled in the registration form)</span></td>
																						<td class="main_black" vAlign="top" align="left"><asp:textbox id="txtPassword" MaxLength="50" CssClass="txtbox" Runat="server" TextMode="Password"></asp:textbox></td>
																					</tr>
																					<tr>
																						<td class="main_black" vAlign="top" colspan="2" align="left">
																							<asp:label id="lblLoginMessage" runat="server" Font-Bold="True" Font-Size="XX-Small" ForeColor="Red"></asp:label>
																						</td>
																					</tr>
																					<tr>
																						<td class="main_black">&nbsp;</td>
																						<td class="main_black"><asp:button id="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click"></asp:button></td>
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
									<tr vAlign="top" align="center">
										<td class="white_bg main_black" align="right" style="HEIGHT: 14px">
											<a class="main_black" href="../HomePage.aspx"><strong>Go Back</strong>&nbsp;&nbsp;&nbsp;</a>
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
