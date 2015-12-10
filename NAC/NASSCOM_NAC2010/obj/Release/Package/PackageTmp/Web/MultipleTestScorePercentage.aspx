<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="MultipleTestScorePercentage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.MultipleTestScorePercentage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
  <HEAD>
		<title>Multiple Certificates Percentage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet" media="print">
		
		<script language="JavaScript" type="text/JavaScript">		
	
			function PrintReport()
			{
			  window.print();				 
			}
		
		</script>
</HEAD>
	<BODY>
		<form id="form1" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<asp:panel id="rpScoreCard" Runat="server">
  <TBODY>
  <TR>
    <TD vAlign=top align=center width=7 background=images/tbg_left.gif><IMG 
      height=1 src="images/spacer.gif" width=7></TD>
    <TD vAlign=top align=right>
      <DIV id=NoPrint><INPUT id=iPrint onclick=PrintReport(); type=button value=Print name=iPrint runat="server"> 
<INPUT id=goBack onclick=javascript:history.go(-1); type=button value=Back name=goBack runat="server"></DIV>
<asp:repeater id=rptScoreCard Runat="server">


									<ItemTemplate>
									
										<TABLE cellSpacing="0" cellPadding="0" bgcolor="#aca899" width="100%" align="center" border="0">
											<tr valign="top">
												<td>
												
													<TABLE id="FirstPage" cellSpacing="0" cellPadding="35" border="1" bordercolor="#000000"
														bordercolorlight="#000000" width="800" height="600" align="center" 
														style="background-repeat:no-repeat; background-position:center; background-color:#ffffff; background-image:url(Images/NAC_Stamp_bg.gif)">
														<tr valign="top">
															<td align="left" valign="top">
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
																									<strong><span class="main_BA">Score Report </span></strong>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<strong><span class="main_BA">State&nbsp;of&nbsp;
																											<%# DataBinder.Eval(Container.DataItem, "State") %>
																										</span></strong>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center">
																									<!-- [Basic Detail] Start Table to show the detail RegistrationID,Name,DOB,etc -->
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="70%" border="1"
																										bordercolorlight="#000000">
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Registration ID</span>
																											</TD>
																											<TD width="70%">
																												<span class="main_middle_BA">&nbsp;
																													<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Name</span></TD>
																											<TD width="70%">
																												<span class="main_middle_BA">&nbsp;
																													<%# DataBinder.Eval(Container.DataItem, "FullName") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Date of Birth </span>
																											</TD>
																											<TD width="70%">
																												<span class="main_middle_BA">&nbsp;
																													<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DOB"))) %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Location</span>
																											</TD>
																											<TD width="70%">
																												<span class="main_middle_BA">&nbsp;
																													<%# DataBinder.Eval(Container.DataItem, "Centre") %>
																													,
																													<%# DataBinder.Eval(Container.DataItem, "City") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="30%" bgcolor="#e6e6e6"><span class="main_middle_BA">&nbsp;Test Date</span></TD>
																											<TD width="70%">
																												<span class="main_middle_BA">&nbsp;
																													<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TestDate"))) %>
																												</span>
																											</TD>
																										</TR>
																									</TABLE>
																									<!-- [Basic Detail] End Table -->
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="90%" border="0">
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%"><span class="main_BA">Test Scores</span>
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<!-- [Test Score] Table Start -->
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="100%" border="1"
																										bordercolorlight="#000000">
																										<!-- Speaking Detail Start -->
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%" bgcolor="#800000" style="COLOR: white" colspan="4"><strong>&nbsp;Speaking</strong>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Topic</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																													Score</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																													Score</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																													Score</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Voice 
																													Clarity</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingVoiceClarity") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center" rowspan="5"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingPercentage") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Accent</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingAccent") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Fluency</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingFluency") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Grammar</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingGrammar") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Prosody</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "SpeakingProsody") %>
																												</span>
																											</TD>
																										</TR>
																										<!-- Speaking Detail End -->
																										<!-- Writing (Essay) Detail Start -->
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%" bgcolor="#800000" style="COLOR: white" colspan="4"><strong>&nbsp;Writing 
																													(Essay)</strong>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Topic</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																													Score</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																													Score</span>
																											</TD>
																											<TD width="25%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																													Score</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Grammar</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayGrammar") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center" rowspan="4"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayPercentage") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Content</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayContent") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Vocabulary</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayVocabulary") %>
																												</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">Spelling 
																													&amp; Punctuation</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssayMaxScore") %>
																												</span>
																											</TD>
																											<TD width="25%" bgcolor="transparent" align="center"><span class="main_small_BA">
																													<%# DataBinder.Eval(Container.DataItem, "WritingEssaySpelling_Punctuation") %>
																												</span>
																											</TD>
																										</TR>
																										<!-- Writing (Essay) Detail End -->
																										<!-- Writing (Multiple Choice) Detail Start -->
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%" bgcolor="#800000" colspan="4" style="COLOR: white"><strong>&nbsp;Writing&nbsp; 
																													(Multiple Choice)</strong>
																											</TD>
																										</TR>
																										<tr>
																											<td colspan="4">
																												<table cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolorlight="#000000">
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																																Score</span>
																														</TD>
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																																Score</span>
																														</TD>
																														<TD width="34%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																																Score</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "WritingMaxScore") %>
																															</span>
																														</TD>
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "WritingScore") %>
																															</span>
																														</TD>
																														<TD width="34%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "WritingPercentage") %>
																															</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" bgcolor="transparent" align="center">
																														<TD width="100%" colspan="3">&nbsp;</TD>
																													</TR>
																												</table>
																											</td>
																										</tr>
																										<!-- Writing (Multiple Choice) Detail End -->
																										<!-- Listening Detail Start -->
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%" bgcolor="#800000" colspan="4" style="COLOR: white"><strong>&nbsp;Listening</strong>
																											</TD>
																										</TR>
																										<tr>
																											<td colspan="4">
																												<table cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolorlight="#000000">
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																																Score</span>
																														</TD>
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																																Score</span>
																														</TD>
																														<TD width="34%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																																Score</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "ListeningMaxScore") %>
																															</span>
																														</TD>
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "ListeningScore") %>
																															</span>
																														</TD>
																														<TD width="34%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "ListeningPercentage") %>
																															</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" bgcolor="transparent" align="center">
																														<TD width="100%" colspan="3">&nbsp;</TD>
																													</TR>
																												</table>
																											</td>
																										</tr>
																										<!-- Listening Detail End -->
																										<!-- Analytical and Quantitative Reasoning Detail Start -->
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%" bgcolor="#800000" colspan="4" style="COLOR: white"><strong>&nbsp;Analytical 
																													and Quantitative Reasoning</strong>
																											</TD>
																										</TR>
																										<tr>
																											<td colspan="4">
																												<table cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolorlight="#000000">
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																																Score</span>
																														</TD>
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																																Score</span>
																														</TD>
																														<TD width="34%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																																Score</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "AQRMaxScore") %>
																															</span>
																														</TD>
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "AQRScore") %>
																															</span>
																														</TD>
																														<TD width="34%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "AQRPercentage") %>
																															</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" bgcolor="transparent" align="center">
																														<TD width="100%" colspan="3">&nbsp;</TD>
																													</TR>
																												</table>
																											</td>
																										</tr>
																										<!-- Analytical and Quantitative Reasoning Detail End -->
																										<!-- Learning Ability Detail Start -->
																										<TR vAlign="middle" align="left" class="white_transparent">
																											<TD width="100%" bgcolor="#800000" colspan="4" style="COLOR: white"><strong>&nbsp;Learning 
																													Ability</strong>
																											</TD>
																										</TR>
																										<tr>
																											<td colspan="4">
																												<table cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolorlight="#000000">
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Maximum 
																																Score</span>
																														</TD>
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Your 
																																Score</span>
																														</TD>
																														<TD width="34%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Percentage 
																																Score</span>
																														</TD>
																													</TR>
																													<TR vAlign="middle" align="center">
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "LAMaxScore") %>
																															</span>
																														</TD>
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "LAScore") %>
																															</span>
																														</TD>
																														<TD width="34%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "LAPercentage") %>
																															</span>
																														</TD>
																													</TR>
																												</table>
																											</td>
																										</tr>
																										<!-- Keyboard Skills Detail Start -->
																										<TR vAlign="middle" align="left" class="white_transparent">
																											<TD width="100%" bgcolor="#800000" colspan="4" style="COLOR: white"><strong>&nbsp;Keyboard 
																													Skills</strong>
																											</TD>
																										</TR>
																										<tr>
																											<td colspan="4">
																												<table cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolorlight="#000000">
																													<TR class="white_transparent" vAlign="middle" align="center">
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Gross 
																																Speed (WPM)</span>
																														</TD>
																														<TD width="33%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Accuracy</span>
																														</TD>
																														<TD width="34%" bgcolor="#e6e6e6" align="center"><span class="main_middle_BA">Net Speed 
																																(WPM)</span>
																														</TD>
																													</TR>
																													<TR class="white_transparent" vAlign="middle" align="center">
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "KeyboardGrossSpeed") %>
																															</span>
																														</TD>
																														<TD width="33%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "KeyboardAccuracy") %>
																															</span>
																														</TD>
																														<TD width="34%" bgcolor="transparent" align="center"><span class="main_small_BA">
																																<%# DataBinder.Eval(Container.DataItem, "KeyboardNetSpeed") %>
																															</span>
																														</TD>
																													</TR>
																												</table>
																											</td>
																										</tr>
																										<!-- Keyboard Skills Detail End -->
																									</TABLE>
																									<!-- [Test Score] Table End -->
																								</td>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<img src="Images/blackbar_login.gif" width="660" height="1"><br>
																									<span lang="EN-US" style="FONT-SIZE:10pt;COLOR:gray;FONT-FAMILY:'Times New Roman';LETTER-SPACING:-0.1pt;mso-fareast-font-family:'Times New Roman';mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
																										NAC is a national assessment and certification program for aspiring candidates 
																										seeking job in Indian ITES - BPO Industry</span>
																								</td>
																							</tr>
																						</TABLE>
																					</td>
																				</tr>
																			</TABLE>
																		</td>
																	</tr>
																</TABLE>
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
											<!--End space between two pages -->
											<!-- Second Page Start here -->
											<!-- 
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
																											- It s a measure of the ability to both use and identify standard written 
																											English and the ability to organize and support ideas in English. Scoring of 
																											the written essay takes into account organization and language use, as well as 
																											success in completing a defined writing task
																											<li>
																												<strong><I>Listening</I></strong>
																											- It is a measure of the comprehension of spoken English including the ability 
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
																											- It is a measure of ability to learn new technology. Task in this section 
																											requires the ability to understand a new concept and apply it in a hypothetical 
																											situation.
																											<li>
																												<strong><I>Keyboard Skills</I></strong>
																											- It measure the skills to use keyboard proficiently. Task in this section 
																											requires the ability to enter data accurately in a given span of time.
																											<li>
																												<strong><I>Speaking</I></strong> - It is a measure of the ability to speak 
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
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="90%" border="0">
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																														ratings/scales (Speaking)</strong></span>
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="5" width="90%" border="1"
																										bordercolorlight="#000000">
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Qualitative 
																														Rating</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating 
																														Description</strong></span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>5</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Excellent</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Requires 
																													no language training</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>4</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Good</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Requires 
																													minimum language training</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>3.5</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Above 
																														Average</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">May 
																													require focused language training. Is generally comfortable with the language</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>3</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Average</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">May 
																													require considerable language training. Is reasonably comfortable with the 
																													language</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>2</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Below 
																														Average</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Requires 
																													extensive language training. Is not very comfortable with the language</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>1</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Poor</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Requires 
																													intensive language training. Poor command of the language</span>
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="90%" border="0">
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%"><span class="main_small_UNB_BA"><strong>Qualitative description of 
																														ratings/scales (Writing Essay)</strong></span>
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="5" width="90%" border="1"
																										bordercolorlight="#000000">
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Qualitative 
																														Rating</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="#f3f3f3" align="center"><span class="main_small_UNB_BA"><strong>Rating 
																														Description</strong></span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>6</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Excellent:</strong>
																													Advanced level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">No 
																													language errors; completely accurate comprehension, interpretation &amp; 
																													completely relevant response</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>5</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Good:</strong>
																													Proficient level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Makes 
																													occasional language errors; largely accurate comprehension, interpretation 
																													&amp; largely relevant response</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>4</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Above 
																														Average:</strong> Vantage level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Makes 
																													a few language errors; generally accurate comprehension, interpretation &amp; 
																													generally relevant response</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>3</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Average:</strong>
																													Threshold level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Makes 
																													regular language errors; fairly accurate comprehension, interpretation &amp; 
																													reasonably relevant response</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>2</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Below 
																														Average:</strong> Learner level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Makes 
																													several language errors; largely inaccurate comprehension, interpretation &amp; 
																													largely irrelevant response</span>
																											</TD>
																										</TR>
																										<TR class="white_transparent" vAlign="middle" align="center">
																											<TD width="10%" bgcolor="transparent" align="center"><span class="main_small_UNB_BA"><strong>1</strong></span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA"><strong>Poor:</strong>
																													Beginner level language user</span>
																											</TD>
																											<TD width="45%" bgcolor="transparent" align="left"><span class="main_small_UNB_BA">Makes 
																													too many language; completely inaccurate comprehension, interpretation &amp; 
																													completely irrelevant response</span>
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</tr>
																							<tr valign="top" align="center">
																								<td align="center" valign="top">
																									<TABLE class="white_transparent" cellSpacing="0" cellPadding="0" width="90%" border="0">
																										<TR class="white_transparent" vAlign="middle" align="left">
																											<TD width="100%">
																												<span lang="EN-US" style="FONT-SIZE:8pt; COLOR:gray; FONT-FAMILY:'Book Antiqua'; mso-bidi-font-family:'Arial Narrow'">
																													<strong><u>Important points</u> </strong>
																													<OL>
																														<li>
																														This is the official score card for NAC, NASSCOM Assessment of Competence.
																														<li>
																														Where "NA" is present on a score report, a score could not be provided due to 
																														either of two possible reasons - (i) the test taker did not attempt that 
																														section of the test or (ii) there was considerable difficulty in discerning the 
																														test taker's responses / there was insufficient data.
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
																									<img src="Images/blackbar_login.gif" width="660" height="1"><br>
																									<span lang="EN-US" style="FONT-SIZE:10pt;COLOR:gray;FONT-FAMILY:'Times New Roman';LETTER-SPACING:-0.1pt;mso-fareast-font-family:'Times New Roman';mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
																										NAC is a national assessment and certification program for aspiring candidates 
																										seeking job in Indian ITES - BPO Industry</span>
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
															</td>
														</tr>
													</TABLE>
												</td>
											</tr>
											 -->
											<!-- Second Page End here -->
										</TABLE>
									</ItemTemplate>
								</asp:repeater></TD>
    <TD vAlign=top align=center width=7 background=images/tbg_right.gif><IMG 
      height=1 src="images/spacer.gif" width=7></TD></TR>
				</asp:panel><asp:panel id="pnlMessage" Runat="server">
  <TR class=white_transparent>
    <TD vAlign=top align=center width=7 background=images/tbg_left.gif></TD>
    <TD vAlign=bottom align=center>
<uc1:nac_header id=Nac_header1 runat="server"></uc1:nac_header></TD>
    <TD vAlign=top align=center width=7 background=images/tbg_right.gif></TD></TR>
  <TR>
    <TD vAlign=top align=right width=7 background=images/tbg_left.gif><IMG 
      height=1 src="images/spacer.gif" width=7></TD>
    <TD vAlign=top align=centre>
      <TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TR vAlign=middle>
          <TD align=center>&nbsp;</TD></TR>
        <TR vAlign=middle>
          <TD align=center>
            <DIV id=NoPrint align=center>
<asp:Label id=lblMessage Runat="server" ForeColor="Red" Font-Bold="True" Text="There is no score card details found"></asp:Label><BR><INPUT id=Button1 onclick=history.go(-1) type=button value=Back name=Button1> 
            </DIV></TD></TR></TABLE></TD>
    <TD vAlign=top align=center width=7 background=images/tbg_right.gif 
    height="100%"><IMG height=1 src="images/spacer.gif" width=7> </TD></TR>
  <TR class=white_transparent>
    <TD vAlign=top align=center width=7 background=images/tbg_left.gif></TD>
    <TD vAlign=bottom align=center>
<uc1:nac_footer id=Nac_footer1 runat="server"></uc1:nac_footer></TD>
    <TD vAlign=top align=center width=7 
  background=images/tbg_right.gif></TD></TR>
				</asp:panel></TBODY></table>
		</form>
	</BODY>
</HTML>
