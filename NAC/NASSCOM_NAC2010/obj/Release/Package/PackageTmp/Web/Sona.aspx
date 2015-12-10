<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="Sona.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Sona" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<TITLE>NAC</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<META content="MSHTML 6.00.2900.3086" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY>
		<FORM id="frmLogin" name="frmLogin" method="post" runat="server">
			<!--<div id="div1" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 110px; HEIGHT: 65px"
				runat="server"><A href="PinLogin.aspx"><IMG height="65" src="Images/click-btn.gif" width="125" border="0"></A>
			</div>
			&nbsp;
			<div id="Div3" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 170px; HEIGHT: 65px"
				runat="server"><A href="PinLogin.aspx"><IMG height="65" src="Images/click-btn-2.gif" width="125" border="0"></A>
			</div>-->
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TBODY>
					<TR class="white_bg">
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<TABLE id="tblHeader" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<TR vAlign="top" align="left">
														<td>
															<table id="tblHeader1" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr vAlign="middle" align="left">
																	<td width="39%" background="images/header_bg.gif"><IMG height="85" src="images/logo1.gif"></td>
																	<td align="right" background="images/header_bg.gif">&nbsp;<IMG id="imgStateLogo" height="48" src="images/Sona.gif" runat="server">
																	</td>
																</tr>
															</table>
														</td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr vAlign="top">
													<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;<asp:label id="lblState" runat="server"></asp:label>&nbsp;NAC</td>
													<td class="header1" vAlign="middle" align="right"><A class="header1" href="../default.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
												</tr>
											</table>
										</TD>
									</TR>
									<TR class="white_bg" vAlign="top" align="center">
										<TD align="center"><BR>
											<TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
												<TBODY>
													<TR>
														<TD vAlign="top" align="left" width="70%">
															<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="3" width="100%" border="0">
																<TBODY>
																	<TR>
																		<TD class="lightblue_bg" vAlign="top" align="left">
																			<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify"><span style="COLOR: #cc0000"><strong>Sona 
																						College of Technology <u>CANCELS</u> NAC test</strong></span><br>
																				<br>
																				For certain inevitable circumstances, the Sona NAC test stands <u>cancelled</u> 
																				as on date.
																				<br>
																				Any further information in this regard shall be published on this page as and 
																				when available.
																				<br>
																				<br>
																				<!--<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify"><span style="COLOR: #cc0000"><strong>Sona 
																						College of Technology holds first round of NAC</strong></span><br>
																				<br>
																				<strong>Sona College of Technology, Salem (TN)</strong> and <strong>NASSCOM</strong>
																				jointly introduce <span style="COLOR: #993300"><u>NASSCOM Assessment of Competence 
																						(NAC)</u></span>
																			- an assessment-cum-certification program for candidates who aspire to be a 
																			part of the BPO industry.
																			<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify">Sona College, a 
																				unit of Sona Group of Institutions, is a pioneer in the field of technical 
																				education in Tamilnadu, caters to the need for quality technical education. The 
																				institution is approved by the 'AICTE' and affiliated to 'Anna University'.
																			</p>
																			<P style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify">NASSCOM, with 
																				active participation of BPO industry players, designed NAC, which is aimed at 
																				creating a robust and continuous pipeline of talent by transforming the 
																				"trainable" workforce into an "employable" workforce. As working with the BPO 
																				industry involves working primarily for global clients, that too in a global 
																				environment, the preferred language (medium of instruction) is English.
																			</P>
																			<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify"><strong>NAC is to 
																					become a national-level certification program and its first round of 
																					administration is taking place at Sona College on <span style="COLOR: #cc0000">18-19 
																						December 2008.</span></strong>
																			</p>-->
																				<!--<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" vAlign="middle"><font style="FONT-SIZE: 13px; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none"><strong>Eligibility 
																									criteria</strong></font>
																						</TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg" height="30">
																							<ul>
																								<li>
																									Final-year undergraduates <span style="COLOR: #993300">(all streams)</span>
																								</li>
																							</ul>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<table class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" vAlign="middle"><font style="FONT-SIZE: 13px; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none"><strong>The 
																									NAC exam process</strong></font>
																						</TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD bgColor="#ffff99"><br>
																							<ul style="LINE-HEIGHT: 18px">
																								<li>
																									Registration Fee to be submitted to Sona College [<strong>Last Date:</strong><span style="COLOR: #cc0000">12 
																										Dec 08</span>] - <span style="FONT-SIZE: 11px; COLOR: #006699">please refer to 
																										the 'Registration Process' section below</span>
																								<li>
																									<strong>Sona College to issue the <u>User ID &amp; Password</u> to candidate (for 
																										online registration) on receipt of reg. fee</strong>
																								<li>
																									Registration on NAC website by candidates with the help of User ID &amp; 
																									Password [<strong>Start date:</strong><span style="COLOR: #cc0000">28 Nov 08 </span>
																									<strong>Close Date:</strong><span style="COLOR: #cc0000">12 Dec 08 (06:00pm)</span>]
																								<li>
																									<strong>Admission Card / Hall Ticket to be downloaded by the candidates immediately 
																										after submitting the online registration form</strong> <span style="COLOR: #cc0000">
																										<li>
																											<span style="COLOR: #cc0000"><strong>NAC Test [<span style="COLOR: black">Date:</span> 18-19 
																													December 08]</strong></span></span>
																								<li>
																									NAC score card to be downloaded by candidates from the NAC website <span style="COLOR: #cc0000">
																										[12 Jan 09 onwards]</span>
																								</li>
																							</ul>
																						</TD>
																					</TR>
																				</TBODY>
																			</table>
																			<br>
																			<TABLE width="95%" align="center">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left" bgColor="#800000" height="30">
																						<TD class="blue_bg" vAlign="middle"><font style="FONT-SIZE: 13px; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none"><strong>Registration 
																									Process</strong></font>
																						</TD>
																					</TR>
																					<tr style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify">
																						<td bgColor="#ffff99"><BR>
																							<i><span style="FONT-WEIGHT: bold; COLOR: #336699">&nbsp;&nbsp;&nbsp;&nbsp;Step1:</span>
																								&nbsp;&nbsp;Submission of proof of 'highest education qualification'</i><br>
																							<br>
																							<i><span style="FONT-WEIGHT: bold; COLOR: #336699">&nbsp;&nbsp;&nbsp;&nbsp;Step2:</span>
																								&nbsp;&nbsp;Registration fee of <span style="COLOR: #cc0000"><strong>Rs.660/-</span></STRONG> 
																								through <u>Demand Draft</u> to be made in favor of <strong>'Sona College of 
																									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Technology'
																								</strong>- payable at <strong>Salem</strong></i>
																							<br>
																							<span style="FONT-SIZE: 11px; COLOR: #006699; FONT-STYLE: italic">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Candidates 
																								will be issued a <u>receipt</u> by Sona College on acceptance of the registration fee)</span><br>
																							<br>
																							<i><span style="FONT-WEIGHT: bold; COLOR: #336699">&nbsp;&nbsp;&nbsp;&nbsp;Step3:</span>
																								&nbsp;&nbsp;Issuance of User ID/Password by the College to the candidate</i><br>
																							<br>
																							&nbsp;&nbsp;&nbsp;&nbsp;------------------------------------------------------------------------------------------------------------------------------<br>
																							<br>
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;<u>Fee can be submitted at the following address:</u></strong>
																							<br>
																							<br>
																							<span style="COLOR: #cc0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NASSCOM 
																								Nodal Centre</span><br>
																							<span style="COLOR: #cc0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sona 
																								College of Technology</span><br>
																							<span style="COLOR: #cc0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Salem 
																								- 636005 (Tamilnadu)</span><br>
																							<span style="COLOR: #cc0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Phone: 
																								0427 - 4099820, 4099821</span><br>
																							<br>
																							<i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Website: <a href="http://www.sonatech.ac.in/nasscom/index.html">
																									http://www.sonatech.ac.in/nasscom/index.html</a></i><br>
																							<i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email: <A href="mailto:sonachece@sonatech.ac.in">
																									sonachece@sonatech.ac.in</A></i><br><br>
																						</td>
																					</tr>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" vAlign="middle" height="25"><span class="main_white_bold">Please 
																								note</span></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg" height="30">
																							<ul style="LINE-HEIGHT: 18px">
																								<li>
																									The <u>test date</u> for each candidate will be issued by the system <u>automatically</u>, 
																								which is dependent on consumption of all the seats on each test day.
																								<li>
																								Sona College will accept applications on 'first-cum-first-served' basis. The 
																								College also reserves the right to reject any application that is found 
																								incomplete / unsuitable or received late.
																								<li>
																									Candidates must download their 'NAC Admission Card' <u>immediately</u>
																								after submitting the 'online registration form'.
																								<li>
																									Candidates should <span style="COLOR: #cc0000"><u>NOT FORGET</u></span>
																								to carry the 'NAC Admission Card' as well as an authentic 'Photo-ID document' 
																								to the test center on the day of the test.
																								<li>
																									There is a section in the online registration form where candidates can 
																									'upload' their recent PP-size photograph; however, if one <u>does not</u>
																								have the soft copy of the photo, he/she will be required to paste the 
																								photograph on the Admission Card after downloading/printing it.
																								<li>
																									Registration fee paid by the candidate, who is allowed to sit for the exam, is 
																									non-refundable.
																								</li>
																							</ul>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="blue_bg" vAlign="middle" height="25"><span class="main_white_bold"><span class="mainwhitebold1">For 
																									queries</span></span></TD>
																					</TR>
																					<TR class="main_black" vAlign="top" align="left">
																						<TD class="white_bg"><br>
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For any queries, contact the following 
																								personnel at Sona College:</strong>
																							<ol>
																								<li>
																									Dr. S. P. Shantharajah (0427-4099821)<br>
																									Professor<br>
																									Dept. of Computer Applications<br>
																									Sona College of Technology<br><br>
																								<li>
																									Mr. P. Arunkumar (0427-4099820)<br>
																									Lecturer<br>
																									Dept. of Computer Applications<br>
																									Sona College of Technology<br>
																									<br>
																									E-mail ID: <A href="mailto:sonachece@sonatech.ac.in">sonachece@sonatech.ac.in</A>
																								</li>
																							</ol>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>-->
																				<br>
																				<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="100%" align="center" border="0">
																					<TBODY>
																						<TR class="main_black" vAlign="top" align="left">
																							<td class="lightblue_bg" vAlign="middle" height="25"><strong>To know about NAC in 
																									detail, visit <a style="FONT-WEIGHT: bold; COLOR: #0000ff; TEXT-DECORATION: none" href="http://www.nac.nasscom.in"
																										target="_self"><u>www.nac.nasscom.in</u></a> </strong>
																							</td>
																						</TR>
																					</TBODY>
																				</TABLE>
																			</p>
																		</TD>
																	</TR>
																</TBODY>
															</TABLE>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
						<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
						<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
