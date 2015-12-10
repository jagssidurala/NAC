<%@ Page language="c#" Codebehind="TestScore.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TestScore" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>TestScore</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<style type="text/css"> @media Print { #FirstPage { DISPLAY: block }
	#SecondPage { DISPLAY: block }
	#NoPrintTop { DISPLAY: none }
	#btnSaveTop { DISPLAY: none }
	#btnBackTop { DISPLAY: none }
	#NoPrintBottom { DISPLAY: none }
	#btnSaveBottom { DISPLAY: none }
	#btnBackBottom { DISPLAY: none }}
	#FirstPage { MARGIN: 0px }
	#SecondPage { MARGIN: 0px }
		</style>
		<script language="JavaScript" type="text/JavaScript">		
	
			function PrintReport()
			{
			  window.print();				 
			}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgcolor="#aca899">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" bgcolor="#aca899" width="100%" align="center" border="0">
				<tr valign="top">
					<td>
						<TABLE id="FirstPage" cellSpacing="0" cellPadding="35" border="1" bordercolor="#000000"
							bordercolorlight="#000000" bgcolor="#ffffff" width="800" height="600" align="center">
							<tr valign="top">
								<td align="center" valign="top">
									<INPUT id="NoPrintTop" onclick="PrintReport();" type="button" value="Print" name="NoPrint">
									<asp:Button id="btnSaveTop" runat="server" Text="Save" onclick="btnSave_Click"></asp:Button>
									<asp:Button id="btnBackTop" runat="server" Text="Back" onclick="btnBack_Click"></asp:Button><br>
									<DIV id="<%=strDivStyle%>"><IMG class="watermark_TS" id="imgWatermark" runat="server" height="600" width="600"></DIV>
									<div id="container1">
										<TABLE cellSpacing="0" cellPadding="2" border="1" bordercolor="#000000" width="100%" height="100%"
											align="center">
											<tr valign="top">
												<td valign="top">
													<TABLE cellSpacing="0" cellPadding="0" border="1" bordercolor="#000000" width="100%" height="100%"
														align="center">
														<tr valign="top">
															<td valign="top">
																<TABLE cellSpacing="0" cellPadding="5" border="0" width="100%">
																	<tr valign="top">
																		<TD vAlign="top" align="left" height="85"><IMG src="images/logo2.gif" height="85"></TD>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			<span class="H2_BA"><u>NASSCOM Assessment of Competence (NAC)</u></span>
																		</td>
																	</tr>
																	<tr valign="top" align="center">																	
																		<td align="center" valign="top">
																			<span class="main_BA_middle">Score Report</span><br>
																			<%if(stateName =="Hero Mindmine" || stateName =="Sona College" ){%>
																			<span class="main_BA">[<asp:Label ID="lblStateTemp" Runat="server"></asp:Label>]</span>
																			<%} else {%>
																			<span class="main_BA">[State&nbsp;of&nbsp;<asp:Label ID="lblState" Runat="server"></asp:Label>]</span>
																			<%}%>
																			<br>
																			<br>
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td>
																			<!-- [Basic Detail] Start Table to show the detail RegistrationID,Name,DOB,etc -->
																			<TABLE cellSpacing="0" cellPadding="0" width="70%" border="1" bordercolordark="#000000"
																				bordercolorlight="#808080">
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Registration ID</span>
																					</TD>
																					<TD width="70%">
																						<span class="main_middle_BA">&nbsp;<asp:label id="lblRegistrationId" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Name</span></TD>
																					<TD width="70%">
																						<span class="main_middle_BA">&nbsp;<asp:label id="lblName" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Date of Birth </span>
																					</TD>
																					<TD width="70%">
																						<span class="main_middle_BA">&nbsp;<asp:label id="lblDob" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Location</span>
																					</TD>
																					<TD width="70%">
																						<span class="main_middle_BA">&nbsp;<asp:label id="lblTestCentre" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Date</span></TD>
																					<TD width="70%">
																						<span class="main_middle_BA">&nbsp;<asp:label id="lblTestDate" runat="server"></asp:label></span></TD>
																				</TR>
																			</TABLE>
																			<!-- [Basic Detail] End Table -->
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
																				<TR vAlign="middle" align="left">
																					<TD width="100%"><span class="main_BA">Test Scores</span>
																					</TD>
																				</TR>
																			</TABLE>
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			<!-- [Test Score] Table Start -->
																			<TABLE cellSpacing="0" cellPadding="0" width="90%" border="1" bordercolorlight="#000000">
																				<!-- Speaking Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Speaking</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" bgcolor="#e6e6e6" align="left"><span class="main_middle_BA">&nbsp;Topic</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																							Score</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																							Score</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Voice Clarity</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblMaxSSVoiceClarity" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblSpeakingVoiceClarity" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center" rowspan="5"><span class="main_small_BA"><asp:Label ID="lblSpeakingPercentile" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Accent</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblMaxSSAccent" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblSpeakingAccent" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Fluency</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblMaxSSFluency" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblSpeakingFluency" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Grammar</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblMaxSSGrammar" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblSpeakingGrammar" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Prosody</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblMaxSProsody" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblSpeakingProsody" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Speaking Detail End -->
																				<!-- Writing (Essay) Detail Start -->
																				<TR vAlign="middle" align="left" id="WritingEssay1" runat="server">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Writing 
																							(Essay)</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center" id="WritingEssay2" runat="server">
																					<TD width="25%" bgcolor="#e6e6e6" align="left"><span class="main_middle_BA">&nbsp;Topic</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																							Score</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																							Score</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center" id="WritingEssay3" runat="server">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Grammar</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWEMaxSGrammar" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWritingEssayGrammar" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center" rowspan="4"><span class="main_small_BA"><asp:Label ID="lblWritingEssayPercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center" id="WritingEssay4" runat="server">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Content</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWEMaxSContent" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWritingEssayContent" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center" id="WritingEssay5" runat="server">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Vocabulary</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWEMaxSVocabulary" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWritingEssayVocabulary" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center" id="WritingEssay6" runat="server">
																					<TD width="25%" align="left"><span class="main_small_BA">&nbsp;Spelling &amp; 
																							Punctuation</span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWEMaxSSpellingPunctuation" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblWritingEssaySpellingPunctuation" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Writing (Essay) Detail End -->
																				<!-- Writing (Multiple Choice) Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA"> &nbsp;Writing&nbsp;<asp:Label ID="lblMultipleChoice" Runat="server">(Multiple Choice)</asp:Label></span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblWritingMultipleChoicePercentageScore" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblWritingMultipleChoicePercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Writing (Multiple Choice) Detail End -->
																				<!-- Listening Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Listening</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblListeningPercentageScore" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblListeningPercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Listening Detail End -->
																				<!-- Analytical and Quantitative Reasoning Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Analytical 
																							and Quantitative Reasoning</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblAQRPercentageScore" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblAQRPercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Analytical and Quantitative Reasoning Detail End -->
																				<!-- Learning Ability Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Learning 
																							Ability</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																					<TD width="50%" bgcolor="#e6e6e6" align="center" colspan="2"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblLearningAbilityPercentageScore" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="50%" align="center" colspan="2"><span class="main_small_BA"><asp:Label ID="lblLearningAbilityPercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Learning Ability Detail End -->
																				<!-- Keyboard Skills Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgcolor="#800000" colspan="4"><span class="main_middle_white_BA">&nbsp;Keyboard 
																							Skills</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Gross 
																							Speed</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Accuracy</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Net Speed</span>
																					</TD>
																					<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentile 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblKeyboardSkillsGrossSpeed" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblKeyboardSkillsAccuracy" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblKeyboardNetSpeed" Runat="server"></asp:Label></span>
																					</TD>
																					<TD width="25%" align="center"><span class="main_small_BA"><asp:Label ID="lblKeyboardSkillsPercentileScore" Runat="server"></asp:Label></span>
																					</TD>
																				</TR>
																				<!-- Keyboard Skills Detail End -->
																			</TABLE>
																			<!-- [Test Score] Table End -->
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			<img src="Images/blackbar_login.gif" width="670" height="1"><br>
																			<span class="main_small_UNB_BA_Bottom">NAC is a national assessment and 
																				certification program for aspiring candidates seeking job in Indian ITES – BPO 
																				Industry </span>
																		</td>
																	</tr>
																	<tr valign="top" align="center">
																		<td align="center" valign="top">
																			&nbsp;
																		</td>
																	</tr>
																</TABLE>
															</td>
														</tr>
													</TABLE>
												</td>
											</tr>
										</TABLE>
									</div>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<!-- Space between two pages -->
				<tr valign="top">
					<td>
						<p class="P"></p>
					</td>
				</tr>
				<!-- End space between two pages -->
				<!-- Second Page Start here -->
				<tr valign="top">
					<td align="center">
						<TABLE id="SecondPage" cellSpacing="0" cellPadding="35" border="1" bordercolor="#000000"
							bordercolorlight="#000000" bgcolor="#ffffff" width="800" height="600" align="center">
							<tr>
								<td align="center">
									<TABLE cellSpacing="0" cellPadding="2" border="1" bordercolor="#000000" width="100%" height="100%"
										align="center">
										<tr valign="top">
											<td valign="top">
												<TABLE cellSpacing="0" cellPadding="0" border="1" bordercolor="#000000" width="100%" height="100%"
													align="center">
													<tr valign="top">
														<td valign="top">
															<TABLE cellSpacing="0" cellPadding="5" border="0" width="100%">
																<tr valign="top" align="center">
																	<td align="left" valign="top">
																		<span class="main_small_UNB_BA">
																			<ul>
																				<li>
																					<strong><I>Writing</I></strong>
																				– It is a measure of the ability to both use and identify standard written 
																				English and the ability to organize and support ideas in English. Scoring of 
																				the written essay takes into account organization and language use, as well as 
																				success in completing a defined writing task.
																				<li>
																					<strong><I>Listening</I></strong>
																				– It is a measure of the comprehension of spoken English including the ability 
																				to identify main ideas, the ability to understand factual information and 
																				details, and the ability to connect information across longer speech samples. 
																				Speech samples simulate a variety of work and everyday situations and include 
																				both extended announcements and conversations.
																				<li>
																					<strong><I>Analytical and Quantitative Reasoning (A&amp;Q)</I></strong>
																				- It is a measure of the ability to (i) assimilate information presented in a 
																				structured way including quantitative information and (ii) draw logical 
																				inferences from the information, including identifying when information is 
																				insufficient to support an inference. Tasks in this section require the ability 
																				to comprehend sets of practical relationships presented in English as well as 
																				the ability to apply basic mathematical concepts.
																				<li>
																					<strong><I>Learning Ability</I></strong>
																				– It is a measure of ability to learn new technology. Task in this section 
																				requires the ability to understand a new concept and apply it in a hypothetical 
																				situation.
																				<li>
																					<strong><I>Keyboard Skills</I></strong>
																				– It measures the skills to use keyboard proficiently. Task in this section 
																				requires the ability to enter data accurately in a given span of time. Gross / 
																				Net Speed are mentioned in 'words per minute' and Accuracy is given in 
																				'percentage'.
																				<li>
																					<strong><I>Speaking</I></strong> – It is a measure of the ability to speak 
																					English in a professional context. Tasks in this section require comprehension 
																					of spoken English and written English. Scoring takes into account delivery and 
																					language use, as well as success at completing defined communicative tasks.
																				</li>
																			</ul>
																		</span>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="0" width="90%" border="0">
																			<TR class="white_bg" vAlign="middle" align="left">
																				<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																							ratings/scales (Speaking)</strong></span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="5" width="90%" border="1" bordercolorlight="#000000">
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Qualitative 
																							Rating</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating 
																							Description</strong></span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>5</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Excellent</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Requires 
																						no language training</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>4</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Good</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Requires 
																						minimum language training</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>3.5</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Above 
																							Average</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">May 
																						require focused language training. Is generally comfortable with the language</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>3</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Average</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">May 
																						require considerable language training. Is reasonably comfortable with the 
																						language</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>2</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Below 
																							Average</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Requires 
																						extensive language training. Is not very comfortable with the language</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>1</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Poor</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Requires 
																						intensive language training. Poor command of the language</span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="0" width="90%" border="0">
																			<TR class="white_bg" vAlign="middle" align="left" id="Essay1" runat="server">
																				<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																							ratings/scales (Writing Essay)</strong></span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="5" width="90%" border="1" bordercolorlight="#000000">
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay2" runat="server">
																				<TD width="10%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Qualitative 
																							Rating</strong></span>
																				</TD>
																				<TD width="53%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating 
																							Description</strong></span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay3" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>6</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Excellent:</strong>
																						Advanced level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">No 
																						language errors; completely accurate comprehension, interpretation &amp; 
																						completely relevant response</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay4" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>5</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Good:</strong>
																						Proficient level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Makes 
																						occasional language errors; largely accurate comprehension, interpretation 
																						&amp; largely relevant response</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay5" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>4</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Above 
																							Average:</strong> Vantage level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Makes a 
																						few language errors; generally accurate comprehension, interpretation &amp; 
																						generally relevant response</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay6" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>3</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Average:</strong>
																						Threshold level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Makes 
																						regular language errors; fairly accurate comprehension, interpretation &amp; 
																						reasonably relevant response</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay7" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>2</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Below 
																							Average:</strong> Learner level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Makes 
																						several language errors; largely inaccurate comprehension, interpretation &amp; 
																						largely irrelevant response</span>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay8" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong>1</strong></span>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong>Poor:</strong>
																						Beginner level language user</span>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA">Makes 
																						too many language; completely inaccurate 
																						comprehension,&nbsp;interpretation&nbsp;&amp;&nbsp;completely&nbsp;irrelevant&nbsp;response</span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<TABLE class="blue_bg" cellSpacing="0" cellPadding="0" width="90%" border="0">
																			<TR class="white_bg" vAlign="middle" align="left">
																				<TD width="100%">
																					<span lang="EN-US" style="FONT-SIZE:8pt; COLOR:gray; FONT-FAMILY:'Book Antiqua'; mso-bidi-font-family:'Arial Narrow'">
																						<strong><u>Important points</u> </strong>
																						<OL>
																							<li>
																							This is the official score card for NAC, NASSCOM Assessment of Competence.
																							<li>
																							Scores are provided in percentile manner and range from 0.1 to 100. Example - A 
																							percentile score of 50 on a skill indicates that 50% of the population has 
																							scored below or equal to the test taker taking the same test for that skill on 
																							the same day.
																							<li>
																							Where "NA" is present on a score report, a score could not be provided due to 
																							either of two possible reasons – (i) the test taker did not attempt that 
																							section of the test or (ii) there was considerable difficulty in discerning the 
																							test taker’s responses / there was insufficient data.
																							<li>
																							You may use this score sheet for applying to companies announced to be 
																							recruiting through NAC. However, NAC Test participation does not guarantee 
																							employment.
																							<li>
																							The employers may or may not assess your academic performance, details of past 
																							employment etc. for the purpose of final selection.
																							<li>
																							The content of current version of this assessment is designed and developed by 
																							MeritTrac Services Pvt. Ltd.
																							<li>
																								NAC is endorsed by leading ITES-BPO players.
																							</li>
																						</OL>
																					</span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<img src="Images/blackbar_login.gif" width="670" height="1"><br>
																		<span class="main_small_UNB_BA_Bottom">NAC is a national assessment and 
																			certification program for aspiring candidates seeking job in Indian ITES – BPO 
																			Industry </span>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		&nbsp;
																	</td>
																</tr>
															</TABLE>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									<INPUT id="NoPrintBottom" onclick="PrintReport();" type="button" value="Print" name="NoPrint">
									<asp:Button id="btnSaveBottom" runat="server" Text="Save" onclick="btnSave_Click"></asp:Button>
									<asp:Button id="btnBackBottom" runat="server" Text="Back" onclick="btnBack_Click"></asp:Button>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<!-- Second Page End here -->
			</TABLE>
		</form>
	</body>
</HTML>
