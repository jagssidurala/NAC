<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="ChandigarhDefault.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.ChandigarhDefault" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<TITLE>PUNJAB NAC - ROUND 3</TITLE>
		<META content="text/html; charset=utf-8" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="stylesheet/nasscom.css">
		<META name="GENERATOR" content="MSHTML 6.00.2900.3086">
		<META name="CODE_LANGUAGE" content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<SCRIPT language="JavaScript" type="text/JavaScript">
			function ValidateLoginInfo()
			{
				var strCheck;
				strCheck = document.frmLogin.txtUserName.value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter user name");
					document.frmLogin.txtUserName.focus();
					return false;
				}
				strCheck = document.frmLogin.txtPassword.value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Password");
					document.frmLogin.txtPassword.focus();
					return false;
				}
			}
		</SCRIPT>
	</HEAD>
	<BODY>
		<div style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 110px; HEIGHT: 65px" id="div1"
			runat="server"><A href="PinLogin.aspx"><IMG border="0" src="Images/click-btn.gif" width="125" height="65"></A>
		</div>
		<div style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 170px; HEIGHT: 65px" id="Div2"
			runat="server"><A href="RegisteredLogin.aspx"><IMG border="0" src="Images/click-btn-2.gif" width="125" height="65"></A>
		</div>
		<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="756" align="center"
			height="100%">
			<FORM id="frmLogin" method="post" name="frmLogin" action="dddefault.aspx">
				<TBODY>
					<TR class="white_bg">
						<TD vAlign="top" background="images/tbg_left.gif" width="7" align="center"><IMG src="images/spacer.gif" width="7" height="1"></TD>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" class="black_bg" border="0" cellSpacing="0" cellPadding="0" width="741"
								align="center">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<TABLE id="tblHeader" border="0" cellSpacing="0" cellPadding="0" width="100%">
												<TBODY>
													<TR vAlign="top" align="left">
														<td>
															<table id="tblHeader1" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<tr vAlign="top" align="left">
																	<td background="images/header_bg.gif" width="39%"><IMG src="images/NAC_Logo.png" height="85"></td>
																	<td vAlign="top" background="images/header_bg.gif" align="right">&nbsp;<IMG id="imgStateLogo" src="images/Logo - DoHE.gif" height="85" runat="server">
																		<IMG id="Img1" src="images/Logo - Punjab Infotech.JPG" height="85" runat="server">
																	</td>
																</tr>
																<!-- <tr vAlign="top" align="left">
																	<td background="images/header_bg.gif" width="39%"><IMG src="images/logo1.gif" height="85"></td>
																	<td background="images/header_bg.gif" align="right">&nbsp;
																	</td>
																</tr> --></table>
														</td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<table border="0" cellSpacing="0" cellPadding="0" width="100%">
												<tr vAlign="top">
													<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;<asp:label id="lblState" runat="server"></asp:label>&nbsp;NAC 
														- ROUND 3</td>
													<td class="header1" vAlign="middle" align="right"><A class="header1" href="../default.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
												</tr>
											</table>
										</TD>
									</TR>
									<TR class="white_bg" vAlign="top" align="center">
										<TD align="center"><BR>
											<TABLE border="0" cellSpacing="0" cellPadding="0" width="98%">
												<TBODY>
													<TR>
														<TD vAlign="top" width="70%" align="left">
															<TABLE class="lightblue_bg" border="0" cellSpacing="1" cellPadding="3" width="100%" bgcolor="#ebf5ff">
																<TBODY>
																	<TR>
																		<TD class="grey_bg main_black" height="30" vAlign="middle" align="left"><strong>Government 
																				of Punjab launches NAC - Round 3</strong></TD>
																	</TR>
																	<TR>
																		<TD class="while_bg main_black" vAlign="top" align="left">
																			<p align="justify"><B>Department of Higher Education and Punjab Infotech</B>, in 
																				association with <B>NASSCOM</B>, is proud to launch <B><font color="#800000">NASSCOM 
																						Assessment of Competence (NAC)</font></B> at Punjab. An 
																				assessment-cum-certification program for candidates who aspire to be a part of 
																				the ITES-BPO industry.
																				<br>
																				<br>
																				NASSCOM, with active participation of BPO industry players, has designed NAC, 
																				which is aimed at creating a robust and continuous pipeline of talent by 
																				transforming the "trainable" workforce into an "employable" workforce. As 
																				working with the BPO industry involves working primarily for global clients, 
																				that too in a global environment, the preferred language (medium of 
																				instruction) is English.
																				<br>
																				<br>
																			</p>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><span class="main_white_bold">Eligibility 
																								criteria</span></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg"><br>
																							<UL>
																								<LI style="PADDING-BOTTOM: 0px">
																									All final year students (general / non-technical streams)
																								</LI>
																							</UL>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" bgColor="#800000"
																				align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><SPAN class="main_white_bold">The NAC 
																								test process</SPAN></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD bgColor="#ffff99"><br>
																							<UL>
																								<LI style="PADDING-BOTTOM: 5px">
																									User ID / Password (for online registration on NAC website to be collected by 
																									the students
																									<br>
																									[<STRONG>Start date</STRONG>:<FONT color="#cc3300"> 28&nbsp;Jan 2012</FONT> <STRONG>
																										Close Date</STRONG>: <FONT color="#cc3300">09 Feb 2012)</FONT>]
																									<br>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px">
																									Registration on NAC website by the students
																									<br>
																									[<strong>Start date</strong>:<font color="#cc3300"> 28&nbsp;Jan 2012</font> <strong>
																										Close Date</strong>: <font color="#cc3300">09&nbsp;Feb 2012 (06:00pm)</font>]
																									<br>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px">
																									<strong>Admission Card / Hall Ticket should be downloaded by the candidates <u>immediately</u>
																										after submitting the online registration form</strong>
																									<br>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px; COLOR: #cc3300">
																									<strong>NAC Test Date: <font color="#cc3300">13-16 Feb 2012</font></strong>
																									<br>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px">
																									<strong>NAC Score Card should be downloaded by the candidates <u>immediately</u> after 
																										finishing the test</strong>(Score Card can also be downloaded by the 
																									students from the NAC website through 'Already Registered' section after the 
																									test)
																								</LI>
																							</UL>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><span class="main_white_bold">User 
																								ID/Password are available at the following colleges</span>
																						</TD>
																					</TR>
																					<TR class="main_black" vAlign="middle" align="left">
																						<TD class="white_bg">
																							<table style="FONT-SIZE: 12px" border="0" cellpadding="0" cellspacing="0">
																								<tr>
																									<td valign="middle" width="300" style="PADDING-BOTTOM:5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Mohindera C, Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Patiala
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Bikram C, Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Patiala
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. (W) Amritsar</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																								Amritsar
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Tarn Taran</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																								Tarn Taran
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Gurdaspur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Gurdaspur
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Roopnagar
																										</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Roopnagar
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Ranbir College, Sangrur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Sangrur</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G. Ripudaman C. Nabha, Distt Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Nabha
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Malerkotla, Distt Sangrur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Malerkotla
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Hoshiarpur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Hoshiarpur
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. (Boys) Ludhiana</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Ludhiana
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. ( Women) Ludhiana</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Ludhiana
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Bathinda</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Bhatinda
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Naya Nangal</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Naya Nangal
																									</td>
																								</tr>
																							</table>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><span class="main_white_bold">Punjab 
																								NAC test will take place at the following colleges</span>
																						</TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg">
																							<table style="FONT-SIZE: 12px" border="0" cellpadding="0" cellspacing="0">
																								<tr>
																									<td valign="middle" width="300" style="PADDING-BOTTOM:5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Mohindera C, Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Patiala
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Bikram C, Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Patiala
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. (W) Amritsar</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																								Amritsar
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Tarn Taran</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																								Tarn Taran
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Gurdaspur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Gurdaspur
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G.C. Roopnagar
																										</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Roopnagar
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT:25px">
																											G. Ranbir College. Sangrur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Sangrur</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G. Ripudaman C. Nabha, Distt Patiala</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Nabha
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Malerkotla, Distt Sangrur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Malerkotla
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Hoshiarpur</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Hoshiarpur
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. (Boys) Ludhiana</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Ludhiana
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. ( Women) Ludhiana</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Ludhiana
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Bathinda</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Bathinda
																									</td>
																								</tr>
																								<tr>
																									<td valign="top" width="300" style="PADDING-BOTTOM: 5px">
																										<LI style="PADDING-LEFT: 25px">
																											G.C. Naya Nangal</LI>
																									</td>
																									<td valign="top" style="PADDING-LEFT:5px">
																										Naya Nangal
																									</td>
																								</tr>
																							</table>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><SPAN class="main_white_bold">Please 
																								note</SPAN></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg"><br>
																							<UL>
																								<LI style="PADDING-BOTTOM: 5px; COLOR: #cc3300">
																									<strong>The name &amp; address of the test center will be mentioned on your NAC 
																										Admission Card.</strong>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px; COLOR: #cc3300">
																									<strong>On the basis of first-come-first-served, you may get any of the test dates 
																										between 13-16 February 2012, which will be mentioned on your NAC Admission 
																										Card.</strong>
																									<br>
																								<LI style="PADDING-BOTTOM: 5px">
																									Dept. of Higher Education / Punjab Infotech reserves the right to disapprove 
																									any candidature that is found unsuitable/ineligible.
																									<br>
																								<LI style="PADDING-BOTTOM: 5px">
																									There is a section in the online registration form where candidates can 
																									'upload' their recent PP-size photograph; however, if anyone does not have the 
																									soft copy of the photograph, he/she will be required to <u>paste</u> the 
																									photograph after printing/downloading the 'NAC Admission Card'.
																									<br>
																								</LI>
																							</UL>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" border="0" cellSpacing="1" cellPadding="3" width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" height="25" vAlign="middle"><span class="main_white_bold">For any 
																								queries</span></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD style="PADDING-LEFT: 20px; PADDING-TOP: 5px" class="white_bg">For all general 
																							queries, please contact your College Coordinator
																							<br>
																							<br>
																							For any registration-related technical issues, you can send an email to <A href="mailto:nac@nasscom.in">
																								nac@nasscom.in</A>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE style="FONT-SIZE: 12px" class="lightblue_bg" border="0" cellSpacing="0" cellPadding="3"
																				width="95%" align="center">
																				<TBODY>
																					<tr>
																						<td><strong>To know about NAC in detail, visit <a href="http://www.nac.nasscom.in" target="_self">
																									www.nac.nasscom.in</a> </strong>
																						</td>
																					</tr>
																				</TBODY>
																			</TABLE>
																		</TD>
																	</TR>
																</TBODY>
															</TABLE>
															<br>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
											<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
									</TR>
								</TBODY>
							</TABLE>
							<br>
						</TD>
					</TR>
				</TBODY>
		</TABLE>
		</TD></TD><td background="images/tbg_right.gif" width="7" align="center" vAlign="top"><IMG src="images/spacer.gif" width="7" height="1"></td>
		</TR><TR>
			<TD background="images/tbg_left.gif" width="7" align="center" vAlign="top"><IMG src="images/spacer.gif" width="7" height="1"></TD>
			<TD vAlign="bottom" align="center"></TD>
			<TD background="images/tbg_right.gif" width="7" align="center" vAlign="top"></TD>
		</TR>
		</TBODY></FORM></TABLE>
	</BODY>
</HTML>
