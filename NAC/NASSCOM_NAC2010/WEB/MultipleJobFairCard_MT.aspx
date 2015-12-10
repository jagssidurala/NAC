<%@ Page language="c#" Codebehind="MultipleJobFairCard_MT.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.MultipuleJobFairCard_MT" %>
<%@ Register TagPrefix="uc1" TagName="nac_JobCard" Src="Controls/nac_JobFairCard.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_JobCardDate" Src="Controls/nac_JobfairCardDateDetails.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>Certificate</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">
						
			function PrintReport()
				{
					print();
				}
			</script>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="1">
				<asp:panel id="rpScoreCard" Runat="server">
					<TBODY>
						<TR>
							<TD vAlign="top" align="center" width="7"></TD>
							<TD vAlign="top" align="right">
								<DIV id="NoPrint"><INPUT id="iPrint" onclick="PrintReport();" type="button" value="Print" name="iPrint" runat="server"><INPUT id="goBack" onclick="javascript:history.go(-1);" type="button" value="Back" name="goBack"
										runat="server"></DIV>
								<BR>
								<asp:repeater id="rptMultJobCard" Runat="server">
									<ItemTemplate>
										<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
											<tr>
												<td class="white_bg" vAlign="top" align="left">
													<table cellSpacing="0" cellPadding="1" width="100%" border="0">
														<TR class=" main_black" vAlign="top">
															<TD class="grey_bg">
																<CENTER>
																	<H4>
																		<%# DataBinder.Eval(Container.DataItem, "State") %>
																		NAC<BR>
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
																			<TABLE class="main_black" cellSpacing="0" cellPadding="5" width="100%" border="1">
																				<!--<TR class="main_black" vAlign="top" align="left">
																					<TD class="grey_bg"><STRONG>GROUP</STRONG></TD>
																					<TD class="grey_bg"><STRONG>
																							<%# DataBinder.Eval(Container.DataItem, "GroupName") %>
																						</STRONG>
																					</TD>
																				</TR>-->
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="20%">Registration ID:
																					</td>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="20%">Name:</td>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "FullName") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="20%">Gender:
																					</td>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "Gender") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="20%">City:
																					</td>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "City") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="white_bg">Highest Education:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "Qualification") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="white_bg">Medium of Instruction (upto 10th):</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "MediumSchool") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="white_bg">Medium of Instruction (upto 12th):</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "Medium12th") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="white_bg">Employment Status:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "EmploymentStatus") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="white_bg">Willing to relocate:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "Relocate") %>
																					</td>
																				</tr>
																			</TABLE>
																			<BR>
																			<TABLE class="main_black" cellSpacing="0" cellPadding="5" width="100%" border="1">
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD class="grey_bg" colSpan="2"><STRONG>NAC SCORES(in Percentile)</STRONG><STRONG></STRONG></TD>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Analytical &amp; Quantitative:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "AQRPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Listening:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "ListeningPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Writing (Multiple Choice):</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "WritingPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Writing (Essay):</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "WritingEssayPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Speaking:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "SpeakingPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Learning Ability:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "LAPercentile") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<TD width="20%" class="white_bg">Keyboard Skills:</TD>
																					<td width="40%">
																						<%# DataBinder.Eval(Container.DataItem, "KeyboardPercentile") %>
																					</td>
																				</tr>
																			</TABLE>
																		</TD>
																		<TD vAlign="top" align="left" width="94%">
																			<TABLE class="white_bg" cellSpacing="0" cellPadding="5" width="100%" border="0">
																				<tr>
																					<td>
																						<table cellpadding="0" border="0" width="100%" cellspacing="0">
																							<tr valign="top">
																								<td>
																									<uc1:nac_JobCardDate id="nac_JobCardDate" RegId='	<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>' runat="server">
																									</uc1:nac_JobCardDate>
																								</td>
																							</tr>
																						</table>
																					</td>
																				</tr>
																			</TABLE>
																		</TD>
																	</TR>
																	<!----here ends sub repeater code---->
																</TABLE>
															</TD>
														</TR>
														<tr>
															<td>
																<table cellpadding="0" border="0" width="100%" cellspacing="0">
																	<tr>
																		<td>
																			<uc1:nac_JobCard id="nac_jobcard" RegId='	<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>' runat="server">
																			</uc1:nac_JobCard>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
												</td>
											</tr>
											<tr>
												<td class="P"><p></p>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:repeater>
				</asp:panel></TD></TR></TBODY></table>
			</TD></TBODY></TABLE></TD></TR>
			<asp:Panel ID="pnlMessage" Runat="server">
				<TR class="white_bg">
					<TD width="7" background="images/tbg_left.gif" vAlign="top" align="center"></TD>
					<TD vAlign="bottom" align="center">
						<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
					<TD width="7" background="images/tbg_right.gif" vAlign="top" align="center"></TD>
				</TR>
				<TR>
					<TD width="7" background="images/tbg_left.gif" vAlign="top" align="right"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="centre">
						<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR vAlign="middle">
								<TD align="center">&nbsp;</TD>
							</TR>
							<TR vAlign="middle">
								<TD align="center">
									<DIV id="NoPrint" align="center">
										<asp:Label id="lblMessage" Runat="server" Font-Bold="True" ForeColor="Red" Text="There is no job fair card details found"></asp:Label><BR>
										<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Back" name="Button1">
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD width="7" background="images/tbg_right.gif" vAlign="top" align="center" height="100%"><IMG height="1" src="images/spacer.gif" width="7">
					</TD>
				</TR>
				<TR class="white_bg">
					<TD width="7" background="images/tbg_left.gif" vAlign="top" align="center"></TD>
					<TD vAlign="bottom" align="center">
						<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD width="7" background="images/tbg_right.gif" vAlign="top" align="center"></TD>
				</TR>
			</asp:Panel></TBODY></TABLE></form>
	</body>
</HTML>
