<%@ Page language="c#" Codebehind="MultipleScoreCardV2.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.MultipleScoreCardV2" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>TestScorePercentage</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="Stylesheet/nasscom.css">
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
	<body bgColor="#aca899" MS_POSITIONING="GridLayout">
		<form style="FONT-FAMILY: 'Book Antiqua'; FONT-SIZE: 8px" id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<asp:panel id="rpScoreCard" Runat="server">
  <TBODY>
  <TR>
    <TD vAlign=top background=images/tbg_left.gif width=7 align=center><IMG 
      src="images/spacer.gif" width=7 height=1></TD>
    <TD vAlign=top align=right>
      <DIV id=NoPrint><INPUT id=iPrint onclick=PrintReport(); value=Print type=button name=iPrint runat="server"> 
<INPUT id=goBack onclick=javascript:history.go(-1); value=Back type=button name=goBack runat="server"></DIV>&nbsp;<BR>
<asp:repeater id=rptScoreCard Runat="server">
									<ItemTemplate>
										<TABLE id="tblScoreCard" border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#aca899"
											align="center" runat="server">
											<tr vAlign="top">
												<td align="center">
													<TABLE id="FirstPage" border="1" cellSpacing="0" borderColor="#000000" borderColorLight="#000000"
														cellPadding="35" width="800" bgColor="#ffffff" align="center">
														<tr vAlign="top">
															<td vAlign="top" align="center">
																<div id="container1">
																	<TABLE border="0" cellSpacing="0" borderColor="#000000" cellPadding="1" width="100%" align="center"
																		height="100%">
																		<tr vAlign="top">
																			<td vAlign="top" >
																				<TABLE border="0" cellSpacing="0" borderColor="#000000" cellPadding="0" width="100%" align="center"
																					height="100%">
																					<tr vAlign="top">
																						<td vAlign="top">
																							<TABLE border="0" cellSpacing="0" cellPadding="5" width="100%">
																								<TR>
																									<TD vAlign="top" align="center" width="100%">
																										<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
																												<TR>
																													<TD width="192" align="left"><asp:image id="imgLogo" runat="server" ImageUrl=<%# DataBinder.Eval(Container.DataItem, "imgLogo") %>></asp:image>
																														<!--<IMG align="left" style="Z-INDEX: 0" src="images/nac.JPG" width="192" height="95"> --></TD>
																													<TD align="center">
																														<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
																															<TR>
																																<TD width="100%" align="center"><asp:label id="lblLogoHeader" Font-Bold="True" Font-Size="14pt" Runat="server" Font-Names="Times New Roman"><%# DataBinder.Eval(Container.DataItem, "imgLogoHeaderText") %></asp:label></TD>
																															</TR>
																															<TR>
																																<TD width="100%">&nbsp;</TD>
																															</TR>
																															<TR>
																																<TD width="100%" align="center"><FONT size="4" face="Times New Roman"><STRONG>SCORE CARD</STRONG></FONT></TD>
																															</TR>
																														</TABLE>
																													</TD>
																												</TR>
																												<tr>
																													<td width="100%" colSpan="2" align="center"><IMG align="absMiddle" src="images/RedRuler.JPG">
																													</td>
																												</tr>
																										</TABLE>
																									</TD>
																								</TR>
																								<tr vAlign="top" align="center">
																									<td style="PADDING-TOP: 20px">
																										<!-- [Basic Detail] Start Table to show the detail RegistrationID,Name,DOB,etc -->
																										<TABLE border="0" cellSpacing="0" borderColorLight="#808080" borderColorDark="#000000"
																											cellPadding="0" width="70%">
																											<TR>
																												<TD style=" PADDING-BOTTOM: 3px; PADDING-LEFT: 5px; PADDING-TOP: 3px" width="100%" colSpan="2"
																													align="left"><font size="2" face="Times New Roman"><strong>CANDIDATE DETAILS</strong>
																													</font>
																												</TD>
																											</TR>
																											<tr>
																												<td height="15">&nbsp;
																												</td>
																											</tr>
																										</TABLE>
																										<TABLE border="1" cellSpacing="0" style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid"
																				borderColorLight="#808080" borderColorDark="#000000" cellPadding="0" width="70%">
																										<TR style="PADDING-BOTTOM: 2pt; HEIGHT: 0.2in; PADDING-TOP: 2pt" vAlign="middle" align="left">
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						bgColor="#e6e6e6" width="30%"><span class="main_middle_BA_TimesNew">&nbsp;Registration 
																							ID</span>
																					</TD>
																												<TD width="70%" style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none"> <SPAN class="main_middle_BA_TimesNew">
																														&nbsp;<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>
																													</SPAN>
																												</TD>
																											</TR>
																											<TR style="PADDING-BOTTOM: 2pt; HEIGHT: 0.2in; PADDING-TOP: 2pt" vAlign="middle" align="left">
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none"
																						bgColor="#e6e6e6" width="30%"><span class="main_middle_BA_TimesNew">&nbsp;Name</span></TD>
																					<TD width="70%" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: solid"><SPAN class="main_middle_BA_TimesNew">&nbsp;<%# DataBinder.Eval(Container.DataItem, "FullName") %></SPAN></TD>
																											</TR>
																											<TR style="PADDING-BOTTOM: 2pt; HEIGHT: 0.2in" vAlign="middle" align="left">
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						bgColor="#e6e6e6" width="30%"><span class="main_middle_BA_TimesNew">&nbsp;Date of 
																							Birth </span>
																					</TD>
																					<TD width="70%" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: solid"><SPAN class="main_middle_BA_TimesNew">&nbsp;<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DOB"))) %></SPAN></TD>
																											</TR>
																											<TR style="PADDING-BOTTOM: 2pt; HEIGHT: 0.2in; PADDING-TOP: 2pt" vAlign="middle" align="left">
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						bgColor="#e6e6e6" width="30%"><span class="main_middle_BA_TimesNew">&nbsp;Test 
																							Location</span>
																					</TD>
																					<TD width="70%" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: solid"><SPAN class="main_middle_BA_TimesNew">&nbsp;<%# DataBinder.Eval(Container.DataItem, "City") %></TD>
																											</TR>
																											<TR style="PADDING-BOTTOM: 2pt; HEIGHT: 0.2in; PADDING-TOP: 2pt" vAlign="middle" align="left">
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						bgColor="#e6e6e6" width="30%"><span class="main_middle_BA_TimesNew">&nbsp;Test Date</span></TD>
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: solid"
																						width="70%"><SPAN class="main_middle_BA_TimesNew">&nbsp;<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TestDate"))) %></SPAN></TD>
																											</TR>
																										</TABLE>
																										<!-- [Basic Detail] End Table --></td>
																								</tr>
																								<tr vAlign="top" align="center">
																		<td style="PADDING-TOP: 12px" vAlign="bottom" align="center"><IMG style="Z-INDEX: 0" align="absMiddle" src="images/RedRuler.JPG">&nbsp;
																		</td>
																	</tr>
																								<tr vAlign="top" align="center">
																		<td vAlign="top" align="center">
																			<TABLE border="0" cellSpacing="0" cellPadding="0" width="90%">
																				<TR vAlign="middle" align="left">
																					<TD width="100%" align="center"><span class="main_middle_BA_TimesNew">Test Scores</span>
																					</TD>
																				</TR>
																			</TABLE>
																		</td>
																	</tr>
																								<TR>
																									<TD vAlign="top" align="center">
																										<TABLE id="Table3" border="1" cellSpacing="0" borderColor="#000000" cellPadding="0" width="90%">
																				<TR style="TEXT-ALIGN: center; PADDING-BOTTOM: 3px; BACKGROUND-COLOR: #696969; COLOR: white; VERTICAL-ALIGN: baseline; PADDING-TOP: 3px">
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						height="0.15in" width="40%"><FONT size="2" face="Times New Roman"><STRONG>Skill</STRONG></FONT></TD>
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: solid"
																						height="0.15in" width="30%"><FONT size="2" face="Times New Roman"><STRONG>Score Range</STRONG></FONT></TD>
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: solid"
																						height="0.15in" width="30%"><FONT size="2" face="Times New Roman"><STRONG>Your Score</STRONG></FONT></TD>
																				</TR>
																											<TR style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; HEIGHT: 0.15in; COLOR: black; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt"
																					height="0.15in">
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none; FONT-WEIGHT: bold"
																						width="40%" align="left"><span class="main_middle_BA_TimesNew">Analytical Ability</span></TD>
																												<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: solid; HEIGHT: 0.15in; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-16
																												</SPAN></TD>
																												<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; HEIGHT: 0.15in; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "Analytical")%>
																												</SPAN></TD>
																											</TR>
																											<tr style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; HEIGHT: 0.15in; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<td height="0.15in" colSpan="3" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none">&nbsp;
																					</td>
																				</tr>
																											<TR style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; HEIGHT: 0.15in; COLOR: black; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none; FONT-WEIGHT: bold"
																						width="40%" align="left"><span class="main_middle_BA_TimesNew">Quantitative Ability</span></TD>
																					<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-16
																												</SPAN></TD>
																												<TD style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "Quantitative")%>
																												</SPAN></TD>
																											</TR>
																											<tr style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; HEIGHT: 0.15in; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<td height="0.15in" colSpan="3" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none">&nbsp;
																					</td>
																				</tr>
																											<TR style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; HEIGHT: 0.15in; COLOR: black; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none; FONT-WEIGHT: bold"
																						width="40%" align="left"><span class="main_middle_BA_TimesNew">English Writing</span></TD>
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-20
																												</SPAN>
																												</TD>
																												<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "EWOverall")%>
																												</SPAN></TD>
																											</TR>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Grammar</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-5
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "EWGrammar")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Content</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																														<SPAN class="main_middle_BA_TimesNew">
																													0-6
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "EWContent")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Vocabulary</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-5
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "EWVocabulary")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="BORDER-BOTTOM-STYLE: none; PADDING-BOTTOM: 2pt; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none; PADDING-TOP: 2pt"
																					height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Spelling 
																							&amp; Punctuation</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													0-4
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "EWSpelling")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; HEIGHT: 0.15in; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<td height="0.15in" colSpan="3" style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none">&nbsp;
																					</td>
																				</tr>
																											<TR style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; HEIGHT: 0.15in; COLOR: black; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none; FONT-WEIGHT: bold"
																						width="40%" align="left"><span class="main_middle_BA_TimesNew">Speaking &amp; 
																							Listening</span></TD>
																					<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													20-80
																												</SPAN>
																												</TD>
																												<TD style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "SLOverall")%>
																												</SPAN>
																												</TD>
																											</TR>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Sentence 
																							Mastery</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													20-80
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "SLSentence")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="BORDER-BOTTOM-STYLE: none; PADDING-BOTTOM: 2pt; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none; PADDING-TOP: 2pt"
																					height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Vocabulary</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													20-80
																												</SPAN>
																												</td>
																													<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "SLVocabulary")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style=" PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: solid; PADDING-BOTTOM: 2pt; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Fluency</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													20-80
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: solid; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "SLFluency")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 2pt" height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: none; PADDING-BOTTOM: 2pt; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Pronunciation</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew">
																													20-80
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_subNode_Score" width="30%" align="left">
																													<SPAN class="main_middle_BA_TimesNew" style="FONT-WEIGHT: normal">
																													<%# DataBinder.Eval(Container.DataItem, "SLPronunciation")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; HEIGHT: 0.15in; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<td height="0.15in" colSpan="3" style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none">&nbsp;
																					</td>
																				</tr>
																											<TR style="BORDER-BOTTOM-STYLE: none; TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; COLOR: black; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<TD style="BORDER-BOTTOM-STYLE: none; PADDING-LEFT: 4px; PADDING-RIGHT: 1px; BORDER-LEFT-STYLE: none; FONT-WEIGHT: bold"
																						width="40%" align="left"><span class="main_middle_BA_TimesNew">Keyboard Skills</span></TD>
																					<TD style="BORDER-BOTTOM-STYLE: none;BORDER-RIGHT-STYLE: solid;BORDER-LEFT-STYLE: none"
																						width="30%">&nbsp;</TD>
																					<TD style="BORDER-BOTTOM-STYLE: none;BORDER-RIGHT-STYLE: none;BORDER-LEFT-STYLE: none"
																						width="30%">&nbsp;</TD>
																				</TR>
																											<tr style="BORDER-BOTTOM-STYLE: none; PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; BORDER-TOP-STYLE: none; PADDING-TOP: 2pt"
																					height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Typing 
																							Speed (Words Per Minute)</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%" align="center">
																													<SPAN class="main_middle_BA_TimesNew">
																													-
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%" align="center">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "KSTSpeed")%>
																												</SPAN></td>
																											</tr>
																											<tr style="PADDING-BOTTOM: 2pt; BACKGROUND-COLOR: #f5f5f5; BORDER-TOP-STYLE: none; PADDING-TOP: 2pt"
																					height="0.15in">
																					<td style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: solid; PADDING-LEFT: 15px; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none"
																						width="40%" align="left">&nbsp;<span class="main_middle_BA_TimesNew">-&nbsp;&nbsp;&nbsp;Typing 
																							Accuracy (%age)</span>
																					</td>
																					<td style="BORDER-BOTTOM-STYLE: none;BORDER-RIGHT-STYLE: solid;BORDER-TOP-STYLE: none;BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%" align="center">
																													<SPAN class="main_middle_BA_TimesNew">
																													-
																												</SPAN>
																												</td>
																												<td style="BORDER-BOTTOM-STYLE: none;BORDER-RIGHT-STYLE: none;BORDER-TOP-STYLE: none;BORDER-LEFT-STYLE: none"
																						class="ScoreTable_MainNode_Score" width="30%" align="center">
																													<SPAN class="main_middle_BA_TimesNew">
																													<%# DataBinder.Eval(Container.DataItem, "KSTAccuracy")%>
																												</SPAN>
																												</td>
																											</tr>
																											<tr style="TEXT-ALIGN: center; PADDING-BOTTOM: 2pt; HEIGHT: 0.15in; VERTICAL-ALIGN: baseline; PADDING-TOP: 2pt">
																					<td height="0.15in" colSpan="3" style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: solid; BORDER-LEFT-STYLE: none">&nbsp;
																					</td>
																				</tr>
																											<tr style="PADDING-BOTTOM: 2pt; PADDING-TOP: 1pt">
																					<td style="BORDER-BOTTOM-STYLE: none;BORDER-RIGHT-STYLE: none;BORDER-LEFT-STYLE: none"
																						width="100%" colSpan="3" align="left">
																							<table border="0" cellpadding="0" cellspacing="0" width="100%">
																							<tr>
																								<td width="40"><span style="PADDING-LEFT: 5px; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 9pt; FONT-WEIGHT: bold"
																										class="main_middle_BA_TimesNew">Note: </span>
																								</td>
																								<td><span style="FONT-STYLE: italic; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew">- NAC Score Report is valid for a year from the 
																										date of issue</span>
																								</td>
																							</tr>
																							<tr>
																								<td><span style="PADDING-LEFT: 5px; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: bold"
																										class="main_middle_BA_TimesNew">&nbsp; </span>
																								</td>
																								<td><span style="FONT-STYLE: italic; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew">- 'NA' is equivalent to 'no attempt'</span>
																								</td>
																							</tr>
																							<tr>
																								<td><span style="PADDING-LEFT: 5px; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew">&nbsp; </span>
																								</td>
																								<td><span style="FONT-STYLE: italic; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew">- In the Speaking &amp; Listening Test, score 
																										of '20' is equivalent to '0' </span>
																								</td>
																							</tr>
																							<tr runat="server" id="trNAC_DNote" >
																								<td><span style="PADDING-LEFT: 5px; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew">&nbsp; </span>
																								</td>
																								<td><span style="FONT-STYLE: italic; FONT-FAMILY: 'Times New Roman'; FONT-SIZE: 8pt; FONT-WEIGHT: normal"
																										class="main_middle_BA_TimesNew"><%# DataBinder.Eval(Container.DataItem, "txtNAC_DFooterNoteVisible") %></span>
																								</td>
																								
																								
																							</tr>
																							
																						</table>
																						
																					</td>
																				</tr>
																										</TABLE>
																									</TD>
																								</TR>
																								<tr vAlign="top" align="center">
																		<td vAlign="top" align="left">
																			<!--<IMG src="Images/blackbar_login.gif" width="670" height="1"><br> -->
																			<span class="main_small_UNB_BA_Bottom_TimesNew">NASSCOM Assessment of Competence 
																				(NAC) is the official skills &amp; competency program for the entry-level 
																				employment opportunities in<br> the ITES-BPO sector </span>
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
													<TABLE id="SecondPage" border="1" cellSpacing="0" borderColor="#000000" borderColorLight="#000000"
														cellPadding="35" width="800" bgColor="#ffffff" align="center">
														<tr>
															<td align="center">
																<TABLE border="0" cellSpacing="0" borderColor="#000000" cellPadding="1" width="100%" align="center"
																	height="100%">
																	<tr vAlign="top">
																		<td vAlign="top">
																			<TABLE border="0" cellSpacing="0" borderColor="#000000" cellPadding="0" width="100%" align="center"
																				height="100%">
																				<tr vAlign="top">
																					<td style="PADDING-BOTTOM: 10px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px"
																						vAlign="top">
																						<TABLE border="1" style="BORDER-BOTTOM: #000000 0px solid; BORDER-LEFT: #000000 0px solid; BORDER-TOP: #000000 0px solid; BORDER-RIGHT: #000000 0px solid"
																bordercolor="#000000" cellSpacing="0" cellPadding="0" width="100%">
																							<TR bgColor="#808080">
																								<TD style="BORDER-BOTTOM-STYLE: none; PADDING-BOTTOM: 2pt; FONT-FAMILY: Times New Roman; FONT-SIZE: 10pt; FONT-WEIGHT: bold; PADDING-TOP: 2pt"
																		height="0.025in" width="100%" colSpan="2" align="center"><FONT color="#ffffff" face="Times new Roman">Skill 
																			Definition &amp; Candidate Score Analysis</FONT></TD>
																</TR>	
																							<TR>
																								<TD style="BORDER-BOTTOM-STYLE: none;PADDING-BOTTOM: 5px;BORDER-RIGHT-STYLE: none;PADDING-LEFT: 5px;FONT-FAMILY: Times New Roman;COLOR: #000000;FONT-SIZE: 12px;FONT-WEIGHT: bold;PADDING-TOP: 5px;font-color: #000000"
																		bgColor="#f5f5f5" vAlign="top" width="200" align="left">Analytical<br>
																		Ability
																	</TD>
																									<TD align="left" style="BORDER-BOTTOM-STYLE: none">
																		<TABLE border="0" cellSpacing="0" width="100%">
																			<TR>
																				<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">The 
																						objective is to test candidate's approach towards problem solving. The key 
																						performance indicators are understanding and accuracy while analyzing and 
																						organizing the given data to solve a given question / problem / puzzle etc. </span>
																				</TD>
																			</TR>
																										<TR>
																				<td width="100%">
																					<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
																						<TR>
																							<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="33">
																															
																																<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "AnalyticalRange")%>
																												</SPAN>
																														</TD>
																													<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-TOP: 5px" vAlign="top" align="left">
																															
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "AnalyticalRemarks")%>
																												</SPAN>
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																							<TR>
																	<TD style="BORDER-BOTTOM-STYLE: none;PADDING-BOTTOM: 5px;BORDER-RIGHT-STYLE: none;PADDING-LEFT: 5px;FONT-FAMILY: Times New Roman;COLOR: #000000;FONT-SIZE: 12px;FONT-WEIGHT: bold;PADDING-TOP: 5px;font-color: #000000"
																		bgColor="#f5f5f5" vAlign="top" width="200" align="left">Quantitative<br>
																		Ability
																	</TD>
																	<TD align="left" style="BORDER-BOTTOM-STYLE: none">
																		<TABLE border="0" cellSpacing="0" width="100%">
																			<TR>
																				<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">The 
																						objective is to test candidate's ability to apply logic and calculations while 
																						tackling day to day arithmetic, involving simple to complicated 
																						problems/situations. The key performance indicators are understanding and 
																						accuracy while exercising calculations for arriving at 
																						answer/solution/conclusion for a given problem/puzzle. </span>
																				</TD>
																			</TR>
																										<TR>
																				<td width="100%">
																					<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
																						<TR>
																							<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="33">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "QuantitativeRange")%>
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px" >
																													<%# DataBinder.Eval(Container.DataItem, "QuantitativeRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																							<TR style="BORDER-BOTTOM-STYLE: none">
																	<TD style="BORDER-BOTTOM-STYLE: none;PADDING-BOTTOM: 5px;BORDER-RIGHT-STYLE: none;PADDING-LEFT: 5px;FONT-FAMILY: Times New Roman;COLOR: #000000;FONT-SIZE: 12px;FONT-WEIGHT: bold;PADDING-TOP: 5px;font-color: #000000"
																		bgColor="#f5f5f5" vAlign="top" width="200" align="left">English<BR>Writing
																	</TD>
																	<TD align="left" style="BORDER-BOTTOM-STYLE: none">
																		<TABLE border="0" cellSpacing="0" width="100%">
																			<TR>
																				<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																											<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Overall (<%# DataBinder.Eval(Container.DataItem, "EWOverall")%>)</span>&nbsp;
																												
																											</TD>
																										</TR>
																										<TR>
																				<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">The 
																						objective is to test a candidate's ability to use correct grammar, appropriate 
																						vocabulary, spellings and punctuation in written communication. </span>
																				</TD>
																			</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="38"
																														<Font face="Times New Roman" size="12px" style="FONT-WEIGHT: bold; font-color: #000000">	<SPAN  style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "EWOverallRange")%>
																												</SPAN></Font>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 0px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "EWOverallRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0" >
																													<TR>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="50">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													Grammar
																													</SPAN>
																														</TD>
																														
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="30">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "EWGrammarRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "EWGrammarRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="50">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													Content
																												</SPAN>
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="30">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "EWContentRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD  style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "EWContentRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="50">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													Vocabulary
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="30">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "EWVocabularyRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="top" align="left">
																																<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "EWVocabularyRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																													
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="135">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													Spelling and Punctuation
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="30">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "EWSpellingRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "EWSpellingRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																							<TR>
																								<TD style="BORDER-BOTTOM-STYLE: none;PADDING-BOTTOM: 5px;BORDER-RIGHT-STYLE: none;PADDING-LEFT: 5px;FONT-FAMILY: Times New Roman;COLOR: #000000;FONT-SIZE: 12px;FONT-WEIGHT: bold;PADDING-TOP: 5px;font-color: #000000"
																		bgColor="#f5f5f5" vAlign="top" width="200" align="left">Keyboard Skills
																	</TD>
																								<TD align="left" style="BORDER-BOTTOM-STYLE: none">
																									<TABLE border="0" cellSpacing="0" width="100%">
																										<TR>
																				<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">The 
																						objective is to test a candidate's replication ability while typing/keying-in 
																						the given content. The key performance indicators are speed and accuracy while 
																						typing. These are assessed through data entry activities involving alphanumeric 
																						text and passages. </span>
																				</TD>
																			</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="top" width="80"><span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; Font-COLOR: #000000">Typing 
																									Speed
																												</SPAN>
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="top" width="80">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "KSTSpeedRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 2px; PADDING-TOP: 0px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "KSTSpeedRemarks")%>
																												</SPAN>
																															
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 3px; PADDING-TOP: 0px" vAlign="bottom" width="93"><span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; Font-COLOR: #000000">Typing 
																									Accuracy</span>
																							</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="bottom" width="45">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													(<%# DataBinder.Eval(Container.DataItem, "KSTAccuracyRange")%>)
																												</SPAN>
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 3px; PADDING-LEFT: 0px; PADDING-TOP: 0px" vAlign="bottom" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "KSTAccuracyRemarks")%>
																												</SPAN>
																												
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																							<TR style="BORDER-BOTTOM-STYLE: none">
																								<TD style="BORDER-BOTTOM-STYLE: none;PADDING-BOTTOM: 5px;BORDER-RIGHT-STYLE: none;PADDING-LEFT: 5px;FONT-FAMILY: Times New Roman;COLOR: #000000;FONT-SIZE: 12px;FONT-WEIGHT: bold;PADDING-TOP: 5px;font-color: #000000"
																		bgColor="#f5f5f5" vAlign="top" width="200" align="left">Speaking &amp; 
																		Listening
																	</TD>
																								<TD align="left" style="BORDER-BOTTOM-STYLE: none">
																									<TABLE border="0" cellSpacing="0" width="100%">
																										<TR>
																											<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																											<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Overall (<%# DataBinder.Eval(Container.DataItem, "SLOverall")%>)</span>&nbsp;
																											&nbsp;
																												
																											
																											</TD>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">The 
																						Overall Score of the test represents the ability to understand spoken English 
																						and speak it intelligibly at a native-like conversational pace on everyday 
																						topics. Scores are based on a weighted combination of four diagnostic sub 
																						scores. Scores are reported in the range from 20 to 80. </span>
																				</TD>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="35">
																																<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "SLOverallRange")%>
																												</SPAN>
																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "SLOverallRemarks")%>
																												</SPAN>
																												
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																															<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Sentence Mastery (<%# DataBinder.Eval(Container.DataItem, "SLSentence")%>)</span>&nbsp;
																											&nbsp;
																												</TD>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">Sentence 
																						Mastery reflects the ability to understand, recall and produce English phrases 
																						and clauses in complete sentences. Performance depends on accurate syntactic 
																						processing and appropriate usage of words, phrases and clauses in meaningful 
																						sentence structures. </span>
																				</TD>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="35">
																																<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "SLSentenceRange")%>
																												</SPAN>
																																
																															
																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "SLSentenceRemarks")%>
																												</SPAN>
																												
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																												<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Vocabulary (<%# DataBinder.Eval(Container.DataItem, "SLVocabulary")%>)</span>&nbsp;
																											&nbsp;
																												
																											</TD>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">Vocabulary 
																						reflects the ability to understand common everyday words spoken in sentence 
																						context and to produce such words as needed. Performance depends on familiarity 
																						with the form and meaning of everyday words and their use in connected speech. </span>
																				</TD>
																										</TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="35">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "SLVocabularyRange")%>
																												</SPAN>
																												
																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "SLVocabularyRemarks")%>
																												</SPAN>
																												
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																												<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Fluency (<%# DataBinder.Eval(Container.DataItem, "SLFluency")%>)</span>&nbsp;
																											&nbsp;
																												
																											</TD>
																										</TR>
																										<TR>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">Fluency 
																						reflects the rhythm, phrasing and timing evident in constructing, reading and 
																						repeating sentences. </span>
																				</TD>
																										</TR>
																										<TR>
																										<TR>
																											<td width="100%">
																												<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																													<TR>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="35">
																															<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "SLFluencyRange")%>
																												</SPAN>

																														</TD>
																														<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px" vAlign="top" align="left">
																															<SPAN style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "SLFluencyRemarks")%>
																												</SPAN>
																												
																														</TD>
																													</TR>
																												</TABLE>
																											</td>
																										</TR>
																										<TR>
																										<TD style="PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-TOP: 5px">
																											<span style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																											Pronunciation (<%# DataBinder.Eval(Container.DataItem, "SLPronunciation")%>)</span>&nbsp;
																											</TD>
																							</TR>
																							<TR>
																								<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 2px"><span style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">Pronunciation 
																						reflects the ability to produce consonants, vowels and stress in a native-like 
																						manner in sentence context. Performance depends on knowledge of the 
																						phonological structure of everyday words. </span>
																				</TD>
																							</TR>
																							<TR>
																								<td width="100%">
																									<TABLE WIDTH="100%" BORDER="0" CELLSPACING="0" CELLPADDING="0">
																										<TR>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 3px; PADDING-TOP: 5px" vAlign="top" width="35">
																												<SPAN style="FONT-FAMILY: Times New Roman; COLOR: #000000; FONT-SIZE: 12px; FONT-WEIGHT: bold; font-color: #000000">
																													<%# DataBinder.Eval(Container.DataItem, "SLPronunciationRange")%>
																												</SPAN>
																												
																											</TD>
																											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-TOP: 5px" vAlign="top" align="left">
																												<SPAN  style="FONT-FAMILY: Times New Roman; FONT-SIZE: 12px">
																													<%# DataBinder.Eval(Container.DataItem, "SLPronunciationRemarks")%>
																												</SPAN>
																												
																											</TD>
																										</TR>
																									</TABLE>
																								</td>
																							</TR>
																						</TABLE>
																					</td>
																				</tr>
																				<TR>
																	<TD colspan="2" width="100%" align="left" style="FONT-VARIANT: normal; FONT-STYLE: italic; PADDING-LEFT: 5px; FONT-FAMILY: 'Times New Roman'; COLOR: black; FONT-SIZE: 7pt">* 
																		Percentile Scores shall be provided over a period of time once a reasonable 
																		volume of test takers is generated</TD>
																</TR>
																				<TR>
																					<TD width="150"></TD>
																					<TD></TD>
																				</TR>
																			</TABLE>
																			<TABLE border="0" cellSpacing="0" cellPadding="5" width="100%">
																<tr vAlign="top" align="center">
																	<td vAlign="top" align="left">
																		<!--<IMG align="center" src="Images/blackbar_login.gif" width="670" height="1"><br>-->
																		<span class="main_small_UNB_BA_Bottom_TimesNew">NASSCOM Assessment of Competence 
																			(NAC) is the official skills &amp; competency program for the entry-level 
																			employment opportunities in <BR>the ITES-BPO sector </span>
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
										<DIV align="center" style="PAGE-BREAK-AFTER: always"> 
							</TD>
						</TR>
				<!-- Second Page End here -->
				
				</table>
			</ItemTemplate> </asp:repeater></TD>
    <TD vAlign=top background=images/tbg_right.gif width=7 align=center><IMG 
      src="images/spacer.gif" width=7 height=1></TD></TR></asp:panel><asp:panel id="pnlMessage" Runat="server">
  <TR class=white_bg>
    <TD vAlign=top background=images/tbg_left.gif width=7 align=center></TD>
    <TD vAlign=bottom align=center></TD>
    <TD vAlign=top background=images/tbg_right.gif width=7 align=center></TD></TR>
  <TR>
    <TD vAlign=top background=images/tbg_left.gif width=7 align=right><IMG 
      src="images/spacer.gif" width=7 height=1></TD>
    <TD vAlign=top align=centre>
      <TABLE border=0 cellSpacing=0 cellPadding=0 width="100%" height="100%">
        <TR vAlign=middle>
          <TD align=center>&nbsp;</TD></TR>
        <TR vAlign=middle>
          <TD align=center>
            <DIV id=NoPrint align=center>
<asp:Label id=lblMessage Runat="server" Text="There is no score card details found" ForeColor="Red" Font-Bold="True"></asp:Label><BR><INPUT id=Button1 onclick=history.go(-1) value=Back type=button name=Button1> 
            </DIV></TD></TR></TABLE></TD>
    <TD height="100%" vAlign=top background=images/tbg_right.gif width=7 
    align=center><IMG src="images/spacer.gif" width=7 height=1> </TD></TR>
  <TR class=white_bg>
    <TD vAlign=top background=images/tbg_left.gif width=7 align=center></TD>
    <TD vAlign=bottom align=center>
<uc1:nac_footer id=Nac_footer1 runat="server"></uc1:nac_footer></TD>
    <TD vAlign=top background=images/tbg_right.gif width=7 
  align=center></TD></TR>
			</asp:panel></TBODY></table></form>
	</body>
</HTML>
