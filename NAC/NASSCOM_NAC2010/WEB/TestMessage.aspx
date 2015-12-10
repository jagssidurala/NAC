<%@ Page language="c#" Codebehind="TestMessage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TestMessage" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NAC:Test Message</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr align="left" valign="top" class="blue_bg">
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">
												&nbsp;&nbsp;&nbsp;<asp:Label id="lblState" runat="server"></asp:Label>&nbsp;NAC</td>
											<td class="header1" vAlign="middle" align="right"><A class="header1" href="../default.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="center">
								<td align="center"><br>
									<table width="90%" cellspacing="1" cellpadding="0" class="lightblue_bg" border="0">
										<tr>
											<td class="white_bg">
												<div class="main_black">
													Thank you for your interest in <strong>NASSCOM Assessment of Competence (NAC).</strong>
												</div>
												<br>
												<table width="100%" border="0" ID="Table1">
													<tbody>
														<tr valign="top">
															<td class="main_grey_bold" colspan="2"><p align="left">Schedule for NAC administration in 
																	your state will shortly be published.<br>
																	Please keep watching this space for details.</p>
															</td>
														</tr>
														<tr valign="top">
															<td colspan="2">
															</td>
														</tr>
														<tr valign="top">
															<td colspan="2" align="left">
																<a class="main_blue" href="#" onclick="javascript:history.go(-1);"><u>Go Back</u></a>
															</td>
														</tr>
													</tbody>
												</table>
											</td>
										</tr>
									</table>
									<br>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
