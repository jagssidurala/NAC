<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="Certificate.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Certificate" %>
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
		<form id="frmCertificate" runat="server">
			<asp:panel id="plScoreCardDetail" Runat="server">
<TABLE cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">
							<TABLE class="black_bg" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR class="white_bg" vAlign="top" align="left">
									<TD align="center">
										<TABLE class="blue_bg" height="960" cellSpacing="1" cellPadding="1" width="669" border="0">
											<TR>
												<TD class="white_bg" vAlign="top" align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TBODY>
															<TR>
																<TD vAlign="top" align="left">
																	<P><IMG height="26" src="http://localhost/NASSCOM_NAC/Web/images/NASSCOM%20Logo.jpg" width="175"></P>
																	<P>&nbsp;</P>
																</TD>
															</TR>
															<TR>
																<TD vAlign="top" align="center"><SPAN class="H2_BA"><u>NASSCOM 
                        Assessment of Competence (NAC)</u></SPAN>
																</TD>
															</TR>
															<TR>
																<TD class="main_blue_bold" vAlign="top" align="center">
																	<asp:label id="lblState" CssClass="main_BA" runat="server" Width="64px"></asp:label></TD>
															</TR>
															<TR>
																<TD align="left">&nbsp;</TD>
															</TR>
															<TR>
																<TD class="small_blue" vAlign="top" align="center">
																	<TABLE class="blue_bg" cellSpacing="1" cellPadding="1" width="80%" border="0">
																		<TR class="white_bg" vAlign="middle" align="left">
																			<TD width="30%"><STRONG>Registration ID: </STRONG>
																			</TD>
																			<TD width="70%">
																				<asp:label id="lblRegistrationId" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg" vAlign="middle" align="left">
																			<TD width="30%"><STRONG>Name:</STRONG></TD>
																			<TD width="70%">
																				<asp:label id="lblName" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg" vAlign="middle" align="left">
																			<TD width="30%"><STRONG>Date of Birth: </STRONG>
																			</TD>
																			<TD width="70%">
																				<asp:label id="lblDob" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg" vAlign="middle" align="left">
																			<TD width="30%"><STRONG>Test Location: </STRONG>
																			</TD>
																			<TD width="70%">
																				<asp:label id="lblTestCentre" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg" vAlign="middle" align="left">
																			<TD width="30%"><STRONG>Test Date:</STRONG></TD>
																			<TD width="70%">
																				<asp:label id="lblTestDate" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR>
																<TD class="main_black_bold" vAlign="top" align="center"><BR>
																	TEST SCORES
																</TD>
															</TR>
															<TR>
																<TD class="main_black_bold" vAlign="top" align="center"><IMG height="5" src="images/spacer.gif" width="1"></TD>
															</TR>
															<TR>
																<TD class="main_black_bold" vAlign="top" align="center">
																	<TABLE class="blue_bg" cellSpacing="1" cellPadding="4" width="80%" border="0">
																		<TR>
																			<TD class="header1" vAlign="middle" align="left" width="70%">Skill Set
																			</TD>
																			<TD class="header1" vAlign="middle" align="center" width="30%">Percentile Score
																			</TD>
																		</TR>
																		<TR class="white_bg">
																			<TD vAlign="middle" align="left" width="70%">English Speaking
																			</TD>
																			<TD vAlign="middle" align="center" width="30%">
																				<asp:label id="lblSpeaking" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg">
																			<TD vAlign="middle" align="left" width="70%">English Listening
																			</TD>
																			<TD vAlign="middle" align="center" width="30%">
																				<asp:label id="lblListening" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg">
																			<TD vAlign="middle" align="left" width="70%">English Writing
																			</TD>
																			<TD vAlign="middle" align="center" width="30%">
																				<asp:label id="lblWriting" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																		<TR class="white_bg">
																			<TD vAlign="middle" align="left" width="70%">Analytical &amp; Quantitative 
																				Reasoning</TD>
																			<TD vAlign="middle" align="center" width="30%">
																				<asp:label id="lblAnalytical" runat="server" Width="64px"></asp:label></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR>
																<TD></TD>
															</TR>
												</TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
											</TR>
										</TABLE>
										<TABLE cellSpacing="1" cellPadding="5" width="700" border="0">
											<TR>
											</TR>
											<TR>
												<BR>
											</TR>
											<TR>
												<TD class="main_blue_bold" vAlign="top" align="left">About NAC Test
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="left">
													<OL class="small_grey">
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
													</OL>
												</TD>
											</TR>
											<TR>
												<TD class="main_blue_bold" vAlign="top" align="left">Important Points
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="left">
													<OL class="small_grey" type="1">
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
													</OL>
												</TD>
											</TR>
										</TABLE>
										<INPUT id="NoPrint" onclick="PrintReport();" type="button" value="Print" name="NoPrint">
										<asp:Button id="btnSave" runat="server" Text="Save" onclick="btnSave_Click"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE></TD>
    <TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD></TR></TBODY></TABLE></asp:panel><asp:panel id="plNoScoreCard" Runat="server">
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
																	<DIV class="main_blue_bold" id="divViewPrintScoreCard"><STRONG>View/Print Your Score 
																			Card</STRONG></DIV>
																	<BR>
																	<DIV class="small_grey" id="divText">Scores shall be made available on the website 
																		one month after the NAC test date - kindly accordingly visit again.</DIV>
																	<BR>
																	<DIV class="main_blue_bold" id="divThankU"><STRONG>Thank You</STRONG></DIV>
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
			</asp:panel></form>
	</body>
</HTML>
