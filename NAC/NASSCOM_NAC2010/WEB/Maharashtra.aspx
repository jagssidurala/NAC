<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="Maharashtra.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Maharashtra" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>Madhya Pradesh NAC</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<META content="MSHTML 6.00.2900.3086" name="GENERATOR">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY>
		<FORM id="frmLogin" name="frmLogin" method="post" runat="server">
			<div id="div1" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 110px; HEIGHT: 65px"
				runat="server"><A href="PinLogin.aspx"><IMG height="65" src="Images/click-btn.gif" width="125" border="0"></A>
			</div>
			<div id="Div2" runat="server" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 170px; HEIGHT: 65px">
				<A href="RegisteredLogin.aspx"><IMG src="Images/click-btn-2.gif" width="125" height="65" border="0"></A>
			</div>
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TBODY>
					<TR class="white_bg">
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<TABLE id="tblHeader" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<TR vAlign="top" align="left">
														<td>
															<table id="tblHeader1" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr vAlign="top" align="left">
																	<td width="39%" background="images/header_bg.gif"><IMG height="85" src="images/logo1.gif"></td>
																	<td align="right" background="images/header_bg.gif">&nbsp; 
																		<!-- <IMG id="imgStateLogo" height="85" src="images/" runat="server"> -->
																	</td>
																</tr>
															</table>
														</td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr vAlign="top">
													<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;<asp:label id="lblState" runat="server"></asp:label>&nbsp;NAC</td>
													<td class="header1" vAlign="middle" align="right"><A class="header1" href="../default.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
												</tr>
											</table>
										</TD>
									</TR>
									<TR class="white_bg" vAlign="top" align="center">
										<TD align="center"><BR>
											<TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
												<TBODY>
													<TR>
														<TD vAlign="top" align="left" width="70%">
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
						<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
						<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
