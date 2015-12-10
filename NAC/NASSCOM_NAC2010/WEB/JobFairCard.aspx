<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="JobFairCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.JobFairCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>Job Fair Admit Card</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">
			function PrintReport()
			{
				print();
			}
			</script>
	</HEAD>
	<body bgProperties="fixed">
		<form id="frmJobFairCard" runat="server">
			<asp:panel id="plJobFairCard" Runat="server">
<TABLE cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
					<TR>
						<TD vAlign="top" align="right">
							<DIV id="NoPrint">
								<asp:Button id="btnSave" Runat="server" Text="Save" onclick="btnSave_Click"></asp:Button><INPUT id="iPrint" onclick="PrintReport();" type="button" value="Print" name="iPrint" runat="server"><INPUT id="goBack" onclick="javascript:history.go(-1);" type="button" value="Back" name="goBack"
									runat="server"></DIV>
							<TABLE cellSpacing="0" cellPadding="0" width="90%" align="right" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
										<TD vAlign="top" align="center"><!-- Put start panel here -->
											<TABLE class="black_bg" cellSpacing="0" cellPadding="0" width="100%" border="1">
												<TBODY>
													<TR class="white_bg" vAlign="top" align="left">
														<TD class="grey_bg">
															<CENTER>
																<H4>
																	<asp:Label id="lblState" Runat="server"></asp:Label>&nbsp;NAC<BR>
																	<U>Job Fair Admission Card</U></H4>
															</CENTER>
															<UL>
																<LI>
																Please carry this sheet to all company interviews for admission, attendance and 
																company signature. DO NOT hand it over to any company
																<LI>
																After attending all the assigned interviews, you are free to attend other 
																company interview depending on time availability/company permission. For this, 
																you must proceed to the NAC Waiting Area for the respective companies after you 
																are done with your assigned interview.&nbsp;
																<LI>
																	PLEASE HAND OVER THIS SHEET AT THE GATE BEFORE YOU LEAVE THE COLLEGE PREMISES.
																</LI>
															</UL>
														</TD>
													</TR>
													<TR class="white_bg" vAlign="top" align="left">
														<TD align="center">
															<TABLE cellSpacing="0" cellPadding="6" width="100%" border="0">
																<TR>
																	<TD vAlign="top" align="left" width="76%">
																		<TABLE class="grey_bg" cellSpacing="0" cellPadding="5" width="100%" border="1">
																			<TR class="main_black" id="grpTier" vAlign="top" align="left" runat="server">
																				<TD class="grey_bg"><STRONG>GROUP</STRONG></TD>
																				<TD class="grey_bg"><STRONG>
																						<asp:Label id="lblTier" runat="server"></asp:Label></STRONG></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" width="52%">Reg. ID:</TD>
																				<TD class="white_bg" width="48%">
																					<asp:Label id="lblRegistrationId" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Name:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblName" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Gender:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblGender" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">City:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblCity" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Highest Education:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblHeighestEducation" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Medium of Instruction (upto 10th):</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblMedium10" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Medium of Instruction (upto 12th):</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblMedium12" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Employment Status:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblEmploymentStatus" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Willing to relocate:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblRelocation" runat="server"></asp:Label></TD>
																			</TR>
																		</TABLE>
																		<BR>
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="5" width="100%" border="1">
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="grey_bg" colSpan="2"><STRONG>NAC SCORES (in Percentile)</STRONG><STRONG></STRONG></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" width="52%">Analytical &amp; Quantitative:</TD>
																				<TD class="white_bg" width="48%">
																					<asp:Label id="lblAnalytical" runat="server"></asp:Label>&nbsp;</TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Listening:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblListening" runat="server"></asp:Label>&nbsp;</TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Writing:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblWriting" runat="server"></asp:Label>&nbsp;</TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg">Speaking:</TD>
																				<TD class="white_bg">
																					<asp:Label id="lblSpeaking" runat="server"></asp:Label>&nbsp;</TD>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD vAlign="top" align="left" width="24%">
																		<TABLE class="blue_bg" id="TblInterview" cellSpacing="0" cellPadding="5" width="100%" border="1"
																			runat="server">
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="grey_bg" colSpan="2"><STRONG>INTERVIEW DATE </STRONG><STRONG></STRONG>
																				</TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" align="center" width="22%"><INPUT type="checkbox" value="checkbox" name="checkbox"></TD>
																				<TD class="white_bg" width="78%">
																					<asp:Label id="lblDate1" Runat="server">date1</asp:Label></TD>
																			</TR>
																		</TABLE>
																		<TABLE class="blue_bg" id="TblInterview2" cellSpacing="0" cellPadding="5" width="100%"
																			border="1" runat="server">
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="grey_bg" colSpan="2"><STRONG>INTERVIEW&nbsp;SCHEDULE </STRONG><STRONG></STRONG>
																				</TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" align="left" width="22%">Date:</TD>
																				<TD class="white_bg" width="78%">
																					<asp:Label id="lblInterviewDate" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" align="left" width="22%">Time:</TD>
																				<TD class="white_bg" width="78%">
																					<asp:Label id="lblInterviewTime" runat="server"></asp:Label></TD>
																			</TR>
																			<TR class="main_black" vAlign="top" align="left">
																				<TD class="white_bg" align="left" width="22%">Venue:</TD>
																				<TD class="white_bg" width="78%">
																					<asp:Label id="lblVenue" runat="server"></asp:Label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR class="white_bg" vAlign="top" align="left">
														<TD align="center"><BR> <!--Here Starts
											
											<!--Changed code-->
															<asp:repeater id="rptCompanyDetail" Runat="server">
																<HeaderTemplate>
																	<table cellSpacing="0" cellPadding="0" width="100%" border="1">
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="white_bg" width="8%" align="left"><STRONG>&nbsp;&nbsp;S.No. </STRONG>
																			<TD class="white_bg" width="32%" align="left"><STRONG>&nbsp;&nbsp;Name of the company </STRONG>
																			<TD class="white_bg" width="14%" align="left"><STRONG>&nbsp;&nbsp;Attended(Y/N)</STRONG></TD>
																			<TD class="white_bg" width="49%" align="left"><STRONG>&nbsp;&nbsp;Signature of company 
																					personnel </STRONG>
																		</TR>
																	</table>
																</HeaderTemplate>
																<ItemTemplate>
																	<table class="black_bg" cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<tr class="white_bg" vAlign="top" align="left">
																			<td align="right">
																				<!-- Table2 Start -->
																				<TABLE class="blue_bg" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																					<TR>
																						<TD class="white_bg" vAlign="top" align="left"><!-- Table3 Start -->
																							<TABLE cellSpacing="0" width="100%" border="1">
																								<tr class="main_black" vAlign="top" align="left">
																									<TD width="8%">&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "SNo") %></TD>
																									<TD width="32%">&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Company Name") %></TD>
																									<td width="14%">&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Attended") %>&nbsp;</td>
																									<td width="49%">&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "Signature") %>&nbsp;</td>
																						</TD>
																			</td>
																	</table> <!-- Table4 End --></TD>
													</TR>
											</TABLE> <!-- Table3 End --></TD>
									</TR>
							</TABLE> <!-- Table2 End -->
							</ItemTemplate> </asp:repeater></TD>
					</TR>
				</TABLE></TD>
          <TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
		</asp:panel><asp:panel id="plNoJobFairCard" Runat="server">
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
															<TD class="main_grey_bold" align="left" colSpan="2">
																<P align="left">
																	<DIV class="main_blue_bold" id="divViewPrintScoreCard"><STRONG>View/Print Your Job Fair 
																			Card</STRONG></DIV>
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
			</asp:panel>
		</form>
	</body>
</HTML>
