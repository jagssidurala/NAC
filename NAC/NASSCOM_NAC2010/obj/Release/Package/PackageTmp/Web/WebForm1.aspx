<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NASSCOM_NAC.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
  <HEAD>
		<title>TestScorePercentage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
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

		    function PrintReport() {
		        window.print();
		    }
		
		</script>
</HEAD>
	<body bgColor="#aca899" MS_POSITIONING="GridLayout">
		<form id="Form1" style="FONT-SIZE: 8px; FONT-FAMILY: 'Book Antiqua'" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#aca899" border="0">
				<tr vAlign="top">
					<td>
						<TABLE id="FirstPage" borderColor="#000000" height="600" cellSpacing="0" cellPadding="35"
							width="800" align="center" bgColor="#ffffff" borderColorLight="#000000" border="1">
							<tr vAlign="top">
								<td vAlign="top" align="center"><INPUT id="NoPrintTop" onclick="PrintReport();" type="button" value="Print" name="NoPrint" class=button>&nbsp;
									<asp:button id="btnSaveTop" runat="server" Text="Save" CssClass="button" onclick="btnSaveTop_Click"></asp:button>&nbsp;<asp:button id="btnBackTop" runat="server" Text="Back" CssClass="button"></asp:button><br>
									<DIV id="<%=strDivStyle%>"><IMG class="watermark_TS" id="imgWatermark" height="600" width="600" runat="server"></DIV>
									<div id="container1">
										<TABLE borderColor="#000000" height="100%" cellSpacing="0" cellPadding="1" width="100%"
											align="center" border="1">
											<tr vAlign="top">
												<td vAlign="top">
													<TABLE borderColor="#000000" height="100%" cellSpacing="0" cellPadding="0" width="100%"
														align="center" border="1">
														<tr vAlign="top">
															<td vAlign="top">
																<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
																	<tr vAlign="top">
																		<TD vAlign="top" align="left"><IMG height="26" src="images/NASSCOM Logo.jpg" width=175></TD>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center"><span class="H2_BA"><u>NASSCOM Assessment of Competence 
																					(NAC)</u></span>
																		</td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center"><span class="main_BA_middle">Score Report</span><br>
																			<%if(stateName =="Hero Mindmine" || stateName =="Sona College" || stateName =="Infotech Enterprises Ltd." ){%>
																			<span class="main_BA">[<asp:label id="lblStateTemp" Runat="server"></asp:label>]</span>
																			<%} else {%>
																			<span class="main_BA">[State&nbsp;of&nbsp;<asp:label id="lblState" Runat="server"></asp:label>]</span>
																			<%}%>
																			<br>
																			<br>
																		</td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td>
																			<!-- [Basic Detail] Start Table to show the detail RegistrationID,Name,DOB,etc -->
																			<TABLE cellSpacing="0" borderColorDark="#000000" cellPadding="0" width="70%" borderColorLight="#808080"
																				border="1">
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Registration ID</span>
																					</TD>
																					<TD width="70%"><span class="main_middle_BA">&nbsp;<asp:label id="lblRegistrationId" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Name</span></TD>
																					<TD width="70%"><span class="main_middle_BA">&nbsp;<asp:label id="lblName" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Date of Birth </span>
																					</TD>
																					<TD width="70%"><span class="main_middle_BA">&nbsp;<asp:label id="lblDob" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Location</span>
																					</TD>
																					<TD width="70%"><span class="main_middle_BA">&nbsp;<asp:label id="lblTestCentre" runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="left">
																					<TD width="30%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Date</span></TD>
																					<TD width="70%"><span class="main_middle_BA">&nbsp;<asp:label id="lblTestDate" runat="server"></asp:label></span></TD>
																				</TR>
																			</TABLE>
																			<!-- [Basic Detail] End Table --></td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center">&nbsp;
																		</td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center">
																			<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
																				<TR vAlign="middle" align="left">
																					<TD width="100%"><span class="main_BA">Test Scores</span>
																					</TD>
																				</TR>
																			</TABLE>
																		</td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center">
																			<!-- [Test Score] Table Start -->
																			<TABLE cellSpacing="0" cellPadding="0" width="90%" borderColorLight="#000000" border="1">
																				<!-- Speaking Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Speaking</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Topic</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																							Score</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																							Score</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Voice Clarity</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblMaxSSVoiceClarity" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblSpeakingVoiceClarity" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%" rowSpan="5"><span class="main_small_BA"><asp:label id="lblSpeakingPercentage" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Accent</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblMaxSSAccent" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblSpeakingAccent" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Fluency</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblMaxSSFluency" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblSpeakingFluency" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Grammar</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblMaxSSGrammar" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblSpeakingGrammar" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR vAlign="middle" align="center">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Prosody</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblMaxSProsody" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblSpeakingProsody" Runat="server"></asp:label></span></TD>
																				</TR>
																				<!-- Speaking Detail End -->
																				<!-- Writing (Essay) Detail Start -->
																				<TR id="WritingEssay1" vAlign="middle" align="left" runat="server">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Writing 
																							(Essay)</span>
																					</TD>
																				</TR>
																				<TR id="WritingEssay2" vAlign="middle" align="center" runat="server">
																					<TD align="left" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">&nbsp;Topic</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																							Score</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																							Score</span>
																					</TD>
																					<TD align="center" width="25%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																							Score</span>
																					</TD>
																				</TR>
																				<TR id="WritingEssay3" vAlign="middle" align="center" runat="server">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Grammar</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWEMaxSGrammar" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWritingEssayGrammar" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%" rowSpan="4"><span class="main_small_BA"><asp:label id="lblWritingEssayPercentage" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR id="WritingEssay4" vAlign="middle" align="center" runat="server">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Content</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWEMaxSContent" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWritingEssayContent" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR id="WritingEssay5" vAlign="middle" align="center" runat="server">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Vocabulary</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWEMaxSVocabulary" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWritingEssayVocabulary" Runat="server"></asp:label></span></TD>
																				</TR>
																				<TR id="WritingEssay6" vAlign="middle" align="center" runat="server">
																					<TD align="left" width="25%"><span class="main_small_BA">&nbsp;Spelling &amp; 
																							Punctuation</span>
																					</TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWEMaxSSpellingPunctuation" Runat="server"></asp:label></span></TD>
																					<TD align="center" width="25%"><span class="main_small_BA"><asp:label id="lblWritingEssaySpellingPunctuation" Runat="server"></asp:label></span></TD>
																				</TR>
																				<!-- Writing (Essay) Detail End -->
																				<!-- Writing (Multiple Choice) Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Writing&nbsp;<asp:label id="lblMultipleChoice" Runat="server">(Multiple Choice)</asp:label></span>
																					</TD>
																				</TR>
																				<tr>
																					<td colSpan="4">
																						<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#000000" border="1">
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																										Score</span>
																								</TD>
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																										Score</span>
																								</TD>
																								<TD align="center" width="34%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																										Score</span>
																								</TD>
																							</TR>
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblWritingMultipleChoiceMaxScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblWritingMultipleChoiceYourScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="34%"><span class="main_small_BA"><asp:label id="lblWritingMultipleChoicePercentage" Runat="server"></asp:label></span></TD>
																							</TR>
																						</table>
																					</td>
																				</tr>
																				<!-- Writing (Multiple Choice) Detail End -->
																				<!-- Listening Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Listening</span>
																					</TD>
																				</TR>
																				<tr>
																					<td colSpan="4">
																						<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#000000" border="1">
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																										Score</span>
																								</TD>
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																										Score</span>
																								</TD>
																								<TD align="center" width="34%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																										Score</span>
																								</TD>
																							</TR>
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblListeningMaxScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblListeningYourScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="34%"><span class="main_small_BA"><asp:label id="lblListeningPercentageScore" Runat="server"></asp:label></span></TD>
																							</TR>
																						</table>
																					</td>
																				</tr>
																				<!-- Listening Detail End -->
																				<!-- Analytical and Quantitative Reasoning Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Analytical 
																							and Quantitative Reasoning</span>
																					</TD>
																				</TR>
																				<tr>
																					<td colSpan="4">
																						<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#000000" border="1">
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																										Score</span>
																								</TD>
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																										Score</span>
																								</TD>
																								<TD align="center" width="34%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																										Score</span>
																								</TD>
																							</TR>
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblAQRMaxScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblAQRYourScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="34%"><span class="main_small_BA"><asp:label id="lblAQRPercentageScore" Runat="server"></asp:label></span></TD>
																							</TR>
																						</table>
																					</td>
																				</tr>
																				<!-- Analytical and Quantitative Reasoning Detail End -->
																				<!-- Learning Ability Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Learning 
																							Ability</span>
																					</TD>
																				</TR>
																				<tr>
																					<td colSpan="4">
																						<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#000000" border="1">
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Maximum 
																										Score</span>
																								</TD>
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Your 
																										Score</span>
																								</TD>
																								<TD align="center" width="34%" bgColor="#e6e6e6"><span class="main_middle_BA">Percentage 
																										Score</span>
																								</TD>
																							</TR>
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblLearningAbilityMaxScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblLearningAbilityYourScore" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="34%"><span class="main_small_BA"><asp:label id="lblLearningAbilityPercentageScore" Runat="server"></asp:label></span></TD>
																							</TR>
																						</table>
																					</td>
																				</tr>
																				<!-- Learning Ability Detail End -->
																				<!-- Keyboard Skills Detail Start -->
																				<TR vAlign="middle" align="left">
																					<TD width="100%" bgColor="#800000" colSpan="4"><span class="main_middle_white_BA">&nbsp;Keyboard 
																							Skills</span>
																					</TD>
																				</TR>
																				<tr>
																					<td colSpan="4">
																						<table cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#000000" border="1">
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Gross 
																										Speed (WPM)</span>
																								</TD>
																								<TD align="center" width="33%" bgColor="#e6e6e6"><span class="main_middle_BA">Accuracy </span>
																								</TD>
																								<TD align="center" width="34%" bgColor="#e6e6e6"><span class="main_middle_BA">Net Speed 
																										(WPM)</span>
																								</TD>
																							</TR>
																							<TR vAlign="middle" align="center">
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblKeyboardSkillsGrossSpeed" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="33%"><span class="main_small_BA"><asp:label id="lblKeyboardSkillsAccuracy" Runat="server"></asp:label></span></TD>
																								<TD align="center" width="34%"><span class="main_small_BA"><asp:label id="lblKeyboardNetSpeed" Runat="server"></asp:label></span></TD>
																							</TR>
																						</table>
																					</td>
																				</tr>
																				<!-- Keyboard Skills Detail End --></TABLE>
																			<!-- [Test Score] Table End --></td>
																	</tr>
																	<tr vAlign="top" align="center">
																		<td vAlign="top" align="center"><IMG height="1" src="Images/blackbar_login.gif" width="670"><br>
																			<span class="main_small_UNB_BA_Bottom">NAC is a national assessment and 
																				certification program for aspiring candidates seeking job in Indian ITES – BPO 
																				Industry </span>
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
				<tr vAlign="top">
					<td>
						<p class="P"></p>
					</td>
				</tr>
				<!-- End space between two pages -->
				<!-- Second Page Start here -->
				<tr vAlign="top">
					<td align="center">
						<TABLE id="SecondPage" borderColor="#000000" height="600" cellSpacing="0" cellPadding="35"
							width="800" align="center" bgColor="#ffffff" borderColorLight="#000000" border="1">
							<tr>
								<td align="center">
									<TABLE borderColor="#000000" height="100%" cellSpacing="0" cellPadding="1" width="100%"
										align="center" border="1">
										<tr vAlign="top">
											<td vAlign="top">
												<TABLE borderColor="#000000" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													align="center" border="1">
													<tr vAlign="top">
														<td vAlign="top">
															<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
																<tr vAlign="top" align="center">
																	<td vAlign="top" align="left"><span class="main_small_UNB_BA">
																			<ul>
																				<li>
																					<strong><I><font size="2">Writing</font></I></strong><font size="2"> – It is a 
																						measure of the ability to both use and identify standard written English and 
																						the ability to organize and support ideas in English. Scoring of the written 
																						essay takes into account organization and language use, as well as success in 
																						completing a defined writing task. </font>
																				<li>
																					<strong><I><font size="2">Listening</font></I></strong><font size="2"> – It is a 
																						measure of the comprehension of spoken English including the ability to 
																						identify main ideas, the ability to understand factual information and details, 
																						and the ability to connect information across longer speech samples. Speech 
																						samples simulate a variety of work and everyday situations and include both 
																						extended announcements and conversations. </font>
																				<li>
																					<strong><I><font size="2">Analytical and Quantitative Reasoning (A&amp;Q)</font></I></strong><font size="2">
																						- It is a measure of the ability to (i) assimilate information presented in a 
																						structured way including quantitative information and (ii) draw logical 
																						inferences from the information, including identifying when information is 
																						insufficient to support an inference. Tasks in this section require the ability 
																						to comprehend sets of practical relationships presented in English as well as 
																						the ability to apply basic mathematical concepts. </font>
																				<li>
																					<strong><I><font size="2">Learning Ability</font></I></strong><font size="2"> – It 
																						is a measure of ability to learn new technology. Task in this section requires 
																						the ability to understand a new concept and apply it in a hypothetical 
																						situation. </font>
																				<li>
																					<strong><I><font size="2">Keyboard Skills</font></I></strong><font size="2"> – It 
																						measures the skills to use keyboard proficiently. Task in this section requires 
																						the ability to enter data accurately in a given span of time. Gross / Net Speed 
																						are mentioned in 'words per minute' and Accuracy is given in 'percentage'. </font>
																				<li>
																					<strong><I><font size="2">Speaking</font></I></strong><font size="2"> – It is a 
																						measure of the ability to speak English in a professional context. Tasks in 
																						this section require comprehension of spoken English and written English. 
																						Scoring takes into account delivery and language use, as well as success at 
																						completing defined communicative tasks. </font>
																				</li>
																			</ul>
																		</span>
																	</td>
																</tr>
																<TR class="white_bg" vAlign="middle" align="left">
																	<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																				ratings/scales (Speaking)</strong></span>
																	</TD>
																</TR>
																<tr vAlign="top" align="center">
																	<td vAlign="top" align="center">
																		<TABLE class="blue_bg" height="50" cellSpacing="0" cellPadding="5" width="90%" borderColorLight="#000000"
																			border="1">
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Rating</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="center" width="37%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Qualitative 
																								Rating</font></strong></span><font size="1"> </font>
																				</TD>
																				<TD align="center" width="53%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Rating 
																								Description</font></strong></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">5</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1"><STRONG>Excellent</STRONG></font></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">Requires 
																							no language training</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">4</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Good</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">Requires 
																							minimum language training</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">3.5</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Above 
																								Average</font></strong></span><font size="1"> </font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">May 
																							require focused language training. Is generally comfortable with the language</font></span><font size="1">
																					</font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">3</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Average</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">May 
																							require considerable language training. Is reasonably comfortable with the 
																							language</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">2</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Below 
																								Average</font></strong></span><font size="1"> </font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">Requires 
																							extensive language training. Is not very comfortable with the language</font></span><font size="1">
																					</font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">1</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Poor</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">Requires 
																							intensive language training. Poor command of the language</font></span><font size="1">
																					</font>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<TR class="white_bg" id="Essay1" vAlign="middle" align="left" runat="server">
																	<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																				ratings/scales (Writing Essay)</strong></span>
																	</TD>
																</TR>
																<tr vAlign="top" align="center">
																	<td vAlign="top" align="center">
																		<TABLE class="blue_bg" height="200" cellSpacing="0" cellPadding="5" width="90%" borderColorLight="#000000"
																			border="1">
																			<TR class="white_bg" id="Essay2" vAlign="middle" align="center" runat="server">
																				<TD align="center" width="10%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Rating</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="center" width="37%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Qualitative 
																								Rating</font></strong></span><font size="1"> </font>
																				</TD>
																				<TD align="center" width="53%" bgColor="#f3f3f3"><span class="main_small_UNB_BA"><strong><font size="1">Rating 
																								Description</font></strong></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" id="Essay3" vAlign="middle" align="center" runat="server">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">6</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Excellent:</font></strong><font size="1">
																							Advanced level language user</font></span><font size="1"> </font>
																				</TD>
																				<TD align="left" width="53%" bgColor="#ffffff"><span class="main_small_UNB_BA"><font size="1">No 
																							language errors; completely accurate comprehension, interpretation &amp; 
																							completely relevant response</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" id="Essay4" vAlign="middle" align="center" runat="server">
																				<TD align="center" width="10%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">5</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD align="left" width="37%" bgColor="#ffffff"><span class="main_small_UNB_BA"><strong><font size="1">Good:</font></strong><font size="1">
																							Proficient level language user</font></span><font size="1"> </font>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><font size="1">Makes 
																							occasional language errors; largely accurate comprehension, interpretation 
																							&amp; largely relevant response</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay5" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong><font size="1">4</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong><font size="1">Above 
																								Average:</font></strong><font size="1"> Vantage level language user</font></span><font size="1">
																					</font>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><font size="1">Makes 
																							a few language errors; generally accurate comprehension, interpretation &amp; 
																							generally relevant response</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay6" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong><font size="1">3</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong><font size="1">Average:</font></strong><font size="1">
																							Threshold level language user</font></span><font size="1"> </font>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><font size="1">Makes 
																							regular language errors; fairly accurate comprehension, interpretation &amp; 
																							reasonably relevant response</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay7" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong><font size="1">2</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong><font size="1">Below 
																								Average:</font></strong><font size="1"> Learner level language user</font></span><font size="1">
																					</font>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><font size="1">Makes 
																							several language errors; largely inaccurate comprehension, interpretation &amp; 
																							largely irrelevant response</font></span><font size="1"> </font>
																				</TD>
																			</TR>
																			<TR class="white_bg" vAlign="middle" align="center" id="Essay8" runat="server">
																				<TD width="10%" bgcolor="#ffffff" align="center"><span class="main_small_UNB_BA"><strong><font size="1">1</font></strong></span><font size="1">
																					</font>
																				</TD>
																				<TD width="37%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><strong><font size="1">Poor:</font></strong><font size="1">
																							Beginner level language user</font></span><font size="1"> </font>
																				</TD>
																				<TD width="53%" bgcolor="#ffffff" align="left"><span class="main_small_UNB_BA"><font size="1">Makes 
																							too many language; completely inaccurate 
																							comprehension,&nbsp;interpretation&nbsp;&amp;&nbsp;completely&nbsp;irrelevant&nbsp;response</font></span><font size="1">
																					</font>
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
																						<strong><u>Important points<BR>
																							</u></strong>1. This is the official score card for NAC, NASSCOM Assessment 
																						of Competence.
																						<BR>
																						2. Where "NA" is present on a score report, a score could not be provided due 
																						to either of two possible reasons – (i) the test taker did not attempt that 
																						section of the test or (ii) there was considerable difficulty in discerning the 
																						test taker’s responses / there was insufficient data.<BR>
																						3. You may use this score sheet for applying to companies announced to be 
																						recruiting through NAC. However, NAC Test participation does not guarantee 
																						employment.<BR>
																						4. The employers may or may not assess your academic performance, details of 
																						past employment etc. for the purpose of final selection.<BR>
																						5. The content of current version of this assessment is designed and developed 
																						by MeritTrac Services Pvt. Ltd.<BR>
																						6. NAC is endorsed by leading ITES-BPO players. </span>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr valign="top" align="center">
																	<td align="center" valign="top">
																		<img src="Images/blackbar_login.gif" width="670" height="1"><br>
																		<span class="main_small_UNB_BA_Bottom" style="FONT-SIZE: 8pt; FONT-FAMILY: 'Book Antiqua'">
																			NAC is a national assessment and certification program for aspiring candidates 
																			seeking job in Indian ITES – BPO Industry </span>
																	</td>
																</tr>
															</TABLE>
														</td>
													</tr>
												</TABLE>
											</td>
										</tr>
									</TABLE>
									
							</tr>
						</TABLE>
					</td>
				</tr>
				<!-- Second Page End here --></TABLE>
		</form>
	</body>
</HTML>
