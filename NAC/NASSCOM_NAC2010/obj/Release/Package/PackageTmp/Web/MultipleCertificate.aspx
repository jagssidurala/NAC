<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="MultipleCertificate.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.MultipleCertificate" %>
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
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
				<asp:panel id="rpScoreCard" Runat="server">
					<TBODY>
						<tr>
							<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
							<td vAlign="top" align="right">
								<div id="NoPrint"><INPUT id="iPrint" onclick="PrintReport();" type="button" value="Print" runat="server"><INPUT id="goBack" onclick="javascript:history.go(-1);" type="button" value="Back" runat="server"></div>
								&nbsp;<br>
								<asp:repeater id="rptScoreCard" Runat="server">
									<ItemTemplate>
										<table class="black_bg" cellSpacing="1" cellPadding="0" width="100%" border="0">
											<tr class="white_bg" vAlign="top" align="left">
												<td align="center">
													<table class="blue_bg" height="960" cellSpacing="1" cellPadding="1" width="669" border="0">
														<tr>
															<td class="white_bg" vAlign="top" align="center"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<tr>
																		<td vAlign="top" align="left"><IMG src="images/nass_logo_trans.gif"></td>
																	</tr>
																	<tr>
																		<td vAlign="top" align="center">
																			<span class="Header2">NASSCOM Assessment of Competence (NAC)</span>
																		</td>
																	</tr>
																	<tr>
																		<td class="main_blue_bold" vAlign="top" align="center">
																			<asp:label id="lblState" runat="server" Width="64px"></asp:label></td>
																	</tr>
																	<tr>
																		<td align="left">&nbsp;</td>
																	</tr>
																	<tr>
																		<td class="small_blue" vAlign="top" align="center">
																			<table class="blue_bg" cellSpacing="1" cellPadding="1" width="80%" border="0">
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="30%"><strong>Registration ID: </strong>
																					</td>
																					<td width="70%">
																						<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="30%"><strong>Name:</strong></td>
																					<td width="70%">
																						<%# DataBinder.Eval(Container.DataItem, "FullName") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="30%"><strong>Date of Birth: </strong>
																					</td>
																					<td width="70%">
																						<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DOB"))) %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="30%"><strong>Test Location: </strong>
																					</td>
																					<td width="70%">
																						<%# DataBinder.Eval(Container.DataItem, "Centre") %>
																						,
																						<%# DataBinder.Eval(Container.DataItem, "City") %>
																					</td>
																				</tr>
																				<tr class="white_bg" vAlign="middle" align="left">
																					<td width="30%"><strong>Test Date:</strong></td>
																					<td width="70%">
																						<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TestDate"))) %>
																					</td>
																				</tr>
																			</table>
																		</td>
																	</tr>
																	<tr>
																		<td class="main_black_bold" vAlign="top" align="center"><br>
																			TEST SCORES
																		</td>
																	</tr>
																	<tr>
																		<td class="main_black_bold" vAlign="top" align="center"><IMG height="5" src="images/spacer.gif" width="1"></td>
																	</tr>
																	<tr>
																		<td class="main_black_bold" vAlign="top" align="center">
																			<table class="blue_bg" cellSpacing="1" cellPadding="4" width="80%" border="0">
																				<tr>
																					<td class="header1" vAlign="middle" align="left" width="70%">Skill Set
																					</td>
																					<td class="header1" vAlign="middle" align="center" width="30%">Percentile Score
																					</td>
																				</tr>
																				<tr class="white_bg">
																					<td vAlign="middle" align="left" width="70%">English Speaking
																					</td>
																					<td vAlign="middle" align="center" width="30%">
																						<asp:label id="lblSpeaking" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dcSpeaking") %>' Width="64px">
																						</asp:label></td>
																				</tr>
																				<tr class="white_bg">
																					<td vAlign="middle" align="left" width="70%">English Listening
																					</td>
																					<td vAlign="middle" align="center" width="30%">
																						<asp:label id="lblListening" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dcListening") %>' Width="64px">
																						</asp:label></td>
																				</tr>
																				<tr class="white_bg">
																					<td vAlign="middle" align="left" width="70%">English Writing
																					</td>
																					<td vAlign="middle" align="center" width="30%">
																						<asp:label id="lblWriting" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dcWriting") %>' Width="64px">
																						</asp:label></td>
																				</tr>
																				<tr class="white_bg">
																					<td vAlign="middle" align="left" width="70%">Analytical &amp; Quantitative 
																						Reasoning</td>
																					<td vAlign="middle" align="center" width="30%">
																						<asp:label id="lblAnalytical" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dcAnalytical") %>' Width="64px">
																						</asp:label></td>
																				</tr>
																			</table>
																		</td>
																	</tr>
																	<tr>
																		<td></td>
																	</tr>
															</td>
														</tr>
													</table>
													<table cellSpacing="1" cellPadding="5" width="700" border="0">
														<tr>
															<td class="main_blue_bold" vAlign="top" align="left">About NAC Test
															</td>
														</tr>
														<tr>
															<td vAlign="top" align="left">
																<ul class="small_grey">
																	<LI>
																	Speaking is a measure of ability to speak in a professional context. Tasks in 
																	this section require comprehension of spoken English and written English. 
																	Scoring takes into account delivery and language use, as well as success at 
																	completing defined communicative tasks.
																	<LI>
																	Listening is a measure of the comprehension of spoken English including the 
																	ability to identify main ideas, the ability to understand factual information 
																	and details, and the ability to connect information across longer speech 
																	samples. Speech samples simulate a variety of work and everyday situations and 
																	include both extended announcement and conversations.
																	<LI>
																	Writing is a measure of the ability to both use and identify standard written 
																	English and to organize and support ideas in English. Scoring of the written 
																	essay takes into account organization and language use, as well as success in 
																	completing a defined writing task.
																	<LI>
																		Analytical and Quantitative Reasoning (A&amp;Q) is a measure of the ability to 
																		(i) assimilate information presented in a structured way including quantitative 
																		information and (ii) draw logical inferences from the information, including 
																		identifying when information is insufficient to support an inference. Tasks in 
																		this section require the ability to comprehend sets of practical relationships 
																		presented in English as well as the ability to apply basic mathematical 
																		concepts.
																	</LI>
																</ul>
															</td>
														</tr>
														<tr>
															<td class="main_blue_bold" vAlign="top" align="left">Important Points
															</td>
														</tr>
														<tr>
															<td vAlign="top" align="left">
																<ol class="small_grey" type="1">
																	<LI>
																	This is the official score card for NAC-NASSCOM Assessment of Competence.
																	<LI>
																	Scores are provided in percentile manner and range from 0 to 99. Example - A 
																	percentile score of 50 on a skill indicates that the test taker scored over 50 
																	percent of the population taking the same test for that skill on the same day.
																	<LI>
																	Where "NA" is present on a score report, a score could not be provided due to 
																	either of two possible reasons - (i) the test taker did not attempt that 
																	section of the test or (ii) there was considerable difficulty in discerning the 
																	test taker's responses (only in the speaking section).
																	<LI>
																	You may use this score sheet for applying to companies announced to be 
																	recruiting through NAC. However, NAC Test participation does not guarantee 
																	employment.
																	<LI>
																	The employers may or may not assess your academic performance, details of past 
																	employment etc. for the purpose of final selection.
																	<LI>
																	The content of current version of the assessment is designed and developed by 
																	Educational Testing Services (ETS).
																	<LI>
																		NAC is endorsed by leading ITES-BPO players.
																	</LI>
																</ol>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
							</td>
						</tr>
			</table>
			</ItemTemplate> </asp:repeater></TD>
			<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
			</TR></asp:panel><asp:panel id="pnlMessage" Runat="server">
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center">
						<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="centre">
						<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR vAlign="middle">
								<TD align="center">&nbsp;</TD>
							</TR>
							<TR vAlign="middle">
								<TD align="center">
									<DIV id="NoPrint" align="center">
										<asp:Label id="lblMessage" Runat="server" Text="There is no score card details found" ForeColor="Red"
											Font-Bold="True"></asp:Label><BR>
										<INPUT id="Button1" onclick="history.go(-1)" type="button" value="Back" name="Button1">
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif" height="100%"><IMG height="1" src="images/spacer.gif" width="7">
					</TD>
				</TR>
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center">
						<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</asp:panel></TBODY></TABLE></form>
	</body>
</HTML>
