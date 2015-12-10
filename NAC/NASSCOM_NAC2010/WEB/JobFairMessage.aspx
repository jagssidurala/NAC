<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="JobFairMessage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.JobFairMessage" %>
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
			<TABLE id="Table5" height="600" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7">
					</TD>
					<TD vAlign="top" align="center">
						<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<TR class="white_bg" vAlign="top" align="left">
								<TD>
									<UC1:NAC_HEADER id="Nac_header1" runat="server"></UC1:NAC_HEADER></TD>
							</TR>
							<TR class="blue_bg" vAlign="top" align="left">
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR vAlign="top">
											<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;
											</TD>
											<TD class="header1" vAlign="middle" align="right"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR class="white_bg" vAlign="top" align="center">
								<TD align="center"><BR>
									<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="90%" border="0">
										<TR>
											<TD class="white_bg">
												<TABLE id="Table1" width="100%" border="0">
													<TR vAlign="top">
														<TD class="main_grey_bold" colSpan="2">
															<P align="left">
																<DIV class="main_blue_bold" id="divViewPrintScoreCard">View/Print Your Job Fair 
																	Card</DIV>
																<BR>
																<DIV class="small_grey" id="divText">A job fair shall be conducted exclusively for 
																	NAC participants. Information about the same shall be published only after the 
																	scores are made available.
																</DIV>
																<BR>
																<DIV id="divThankU">Thank You</DIV>
															<P></P>
														</TD>
													</TR>
													<TR vAlign="top">
														<TD colSpan="2"></TD>
													</TR>
													<TR vAlign="top">
														<TD align="left" colSpan="2"><U><A class="main_blue" onclick="javascript:history.go(-1);" href="#"><U>Go 
																		Back</U></A> </U>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<BR>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center">
						<UC1:NAC_FOOTER id="Nac_footer2" runat="server"></UC1:NAC_FOOTER></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
