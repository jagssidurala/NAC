<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="RajasthanMessage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.RajasthanMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Rajasthan Test Message</title>
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
													Dear&nbsp;<asp:Label ID="lblCandidateName" Runat="server"></asp:Label>
												</div>
												<br>
												<table width="100%" border="0" ID="Table1">
													<tbody>
														<tr valign="top">
															<td class="main_black" colspan="2"><p align="left">
																<p>
																	Congratulations on your successful registration for NAC (NASSCOM Assessment of 
																	Competence).
																</p>
																<p>Please find below your log-in details that you would require to view your 
																	profile on NAC website:</p>
																<table cellpadding="0" cellspacing="0" border="0">
																	<tr>
																		<td class="main_black" align="left" width="25%"><strong>Photo-ID Document</strong></td>
																		<td class="main_black" align="left" width="1%"><strong>:</strong></td>
																		<td class="main_black" align="left" width="74%"><asp:Label ID="lblPhotoIDDocument" Runat="server"></asp:Label></td>
																	</tr>
																	<tr>
																		<td class="main_black" align="left" width="25%"><strong>Photo-ID Document No</strong></td>
																		<td class="main_black" align="left" width="1%"><strong>:</strong></td>
																		<td class="main_black" align="left" width="74%"><asp:Label ID="lblPhotoIDDocumentNumber" Runat="server"></asp:Label></td>
																	</tr>
																	<tr>
																		<td class="main_black" align="left" width="25%"><strong>Password</strong></td>
																		<td class="main_black" align="left" width="1%"><strong>:</strong></td>
																		<td class="main_black" align="left" width="74%"><asp:Label ID="lblPassword" Runat="server"></asp:Label></td>
																	</tr>
																</table>
																<p><span style="FONT-SIZE: 11px; COLOR: maroon">An e-mail has been sent to your 
																		e-mailID, please check</span></p>
																<p>These details will also be required by you later to access your NAC Admission 
																	Card / Score Card.</p>
																<p><span style="COLOR: maroon"><strong>Please note -</strong> Your Admission Card will 
																		be made available on the website from <font color="#000000" style="TEXT-DECORATION: none; COLOR: maroon">
																			<strong>15-Sep-08</strong></font> onwards. Please visit the website 
																		accordingly to download your Admission Card.</span></p>
																<p>DO NOT forget to carry it to the test center on the day of the test along with 
																	the photo-ID document.</p>
																<p>We wish you all the best!<br>
																	<strong>NAC Team </strong>
																</p>
															</td>
														</tr>
														<tr valign="top">
															<td colspan="2">
															</td>
														</tr>
														<tr valign="top">
															<td colspan="2" align="left">
																&nbsp;
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
