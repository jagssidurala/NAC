<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="RegistrationSuccess.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.RegistrationSuccess" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NAC - Registration successfully completed</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
	</HEAD>
	<body>
		<FORM id="frmLogin" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr class="white_bg">
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr align="left" valign="top" class="blue_bg">
								<td valign="middle" class="header1">&nbsp;&nbsp;Registered successfully
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="center">
								<td align="center"><br>
									<table width="95%" cellspacing="1" cellpadding="0" class="lightblue_bg" border="0">
										<tr>
											<td class="white_bg">
												<table id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
													<TBODY>
														<tr class="main_black" align="left">
															<td height="25" class="lightblue_bg" colSpan="3"><strong>Registration successfully 
																	completed</strong></td>
														</tr>
														<TR>
															<TD width="100%" colSpan="3" height="20"></TD>
														</TR>
														<tr class="main_black" align="left">
															<td width="100%" colspan="3">&nbsp;You have successfully registered for NAC.</td>
														</tr>
														<tr class="main_black" align="left">
															<td width="100%" colspan="3" height="20"></td>
														</tr>
														<tr class="main_black" align="left">
															<td colSpan="3">&nbsp;Please visit again to download your NAC admit card, which 
																will be available from <span class="big_maroon">22 July 2007</span> onwards.</td>
														</tr>
														<tr class="main_black" align="left">
															<td width="100%" colspan="3" height="20"></td>
														</tr>
														<tr class="main_black" align="left">
															<td width="100%" colspan="3"><strong>&nbsp;Thank You!</strong></td>
														</tr>
														<TR>
															<TD width="100%" colSpan="3" height="20"></TD>
														</TR>
														<tr class="main_black" align="center">
															<td colSpan="3" rowSpan="1">
																<asp:Button id="btnPrintRegDetails" runat="server" Text="Print your registration details" onclick="btnPrintRegDetails_Click"></asp:Button>&nbsp;</td>
														</tr>
														<TR>
															<TD colSpan="3" height="20"></TD>
														</TR>
													</TBODY>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<TD background="images/tbg_right.gif" vAlign="top" align="center" width="7"><IMG height="1" src="images/spacer.gif" width="7"></TD>
				</tr>
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
