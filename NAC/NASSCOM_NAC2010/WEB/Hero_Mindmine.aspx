<%@ Page language="c#" Codebehind="Hero_Mindmine.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Hero_Mindmine" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
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
			<div id="div1" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 110px; HEIGHT: 65px"
				runat="server"><A href="PinLogin.aspx"><IMG height="65" src="Images/click-btn.gif" width="125" border="0"></A>
			</div>
			&nbsp;
			<div id="Div3" style="RIGHT: 0px; WIDTH: 125px; POSITION: fixed; TOP: 170px; HEIGHT: 65px"
				runat="server"><A href="RegisteredLogin.aspx"><IMG height="65" src="Images/click-btn-2.gif" width="125" border="0"></A>
			</div>
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
																	<td align="right" background="images/header_bg.gif">&nbsp;<IMG id="imgStateLogo" height="48" src="images/HMM.gif" runat="server">
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
																			<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify"><span style="COLOR: #cc0000"><strong>Hero 
																						Mindmine holds the first round of NAC at 15 locations</strong></span><br>
																				<br>
																				Hero Mindmine and NASSCOM jointly introduce <span style="COLOR: #993300"><u>NASSCOM 
																						Assessment of Competence (NAC)</u></span>
																			- an assessment-cum-certification program for candidates who aspire to be a 
																			part of the BPO industry.
																			<p style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify"><strong>Part of the 
																					USD 4.2bn Hero Group, Hero Mindmine Institute Limited (HMIL) is respected as 
																					India's Largest Training, Human Capacity Building and HR Consulting 
																					Organization with over 176 centers across India.</strong>
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
																					administration is taking place at 15 centers of Hero Mindmine on <span style="COLOR: #cc0000">
																						15-18 November 2008.</span></strong>
																			</p>
																			<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
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
																									Pursuing final year under-graduation <span style="COLOR: #993300">(all streams)</span>
																								<LI>
																									Graduates <span style="COLOR: #993300">(all streams)</span>
																								<li>
																									Post graduates <span style="COLOR: #993300">(all streams)</span>
																								<li>
																									Engineering students <span style="COLOR: #993300">(pre-final / final semester)</span>
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
																							<ul>
																								<li>
																									Registration Fee to be submitted to any of the HMIL centers [<strong>Last Date:</strong><span style="COLOR: #cc0000">11 
																										Nov 08</span>] - <span style="FONT-SIZE: 11px; COLOR: #006699">please refer to 
																										the 'Registration Process' section below</span>
																								<li>
																									HMIL to issue the <u>User ID &amp; Password</u>
																								to candidate (for online registration) on receipt of reg. fee
																								<li>
																									Registration on NAC website by candidates with the help of User ID &amp; 
																									Password [<strong>Start date:</strong><span style="COLOR: #cc0000">25 Oct 08 </span>
																									<strong>Close Date:</strong><span style="COLOR: #cc0000">11 Nov 08 (06:00pm)</span>]
																								<li>
																									<strong>Admission Card / Hall Ticket to be downloaded by the candidates immediately 
																										after submitting the online registration form</strong> <span style="COLOR: #cc0000">
																										<li>
																											<span style="COLOR: #cc0000"><strong>NAC Test [<span style="COLOR: black">Date:</span> 15, 
																													16, 17, 18 November '08]</strong></span></span>
																								<li>
																									NAC score card to be downloaded by candidates from NAC website <span style="COLOR: #cc0000">
																										[11 Dec 08 onwards]</span>
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
																									Process / NAC Test Centers</strong></font>
																						</TD>
																					</TR>
																					<tr style="FONT-SIZE: 12px; FONT-FAMILY: verdana" align="justify">
																						<td bgColor="#ffff99"><BR>
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;Registration process will be followed at all the 
																								following Hero Mindmine test centers:</strong>
																							<br>
																							<br>
																							
																							<table style="FONT-SIZE: 11px" border="0" cellpadding="5" cellspacing="1" width="95%" bgcolor="gray"  align="center">
																								
																								<tr bgcolor="white">
																									<td><strong>S No</strong></td>
																									<td><strong>City</strong></td>
																									<td><strong>Address</strong></td>
																									<td><strong>Nodel person</strong></td>
																								</tr>
																								<tr bgcolor="white">
																									<td>1</td>
																									<td><strong>Lucknow</strong></td>
																									<td>C-2005 , Near Erum Girls Degree College, Indira Nagar</td>
																									<td>Aparna Mishra - 9335777559</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>2</td>
																									<td><strong>Kanpur</strong></td>
																									<td>86/300 G.T Road, Opp. Anwar Ganj Station</td>
																									<td>Piyush - 9793779977</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>3</td>
																									<td><strong>Delhi</strong></td>
																									<td>M-3, II Floor, South Extn. - II</td>
																									<td>Garima - 9891577687</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>4</td>
																									<td><strong>Jaipur</strong></td>
																									<td>2nd Floor, B-23, Adarsh Nagar, Raja Park, Govind Marg</td>
																									<td>Deepika - (0141) 4020040</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>5</td>
																									<td><strong>Jaipur</strong></td>
																									<td>C-13, Subhash Nagar Shopping Center, Near Hari Ram School</td>
																									<td>Atul Sanghi - 9351411559</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>6</td>
																									<td><strong>Amritsar</strong></td>
																									<td>Opp. Khalsa College (Women), No. 22, Phatak Road</td>
																									<td>Sarita Gupta - 9876648483</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>7</td>
																									<td><strong>Delhi</strong></td>
																									<td>H-6B, IInd Floor, Main road, Kalkaji</td>
																									<td>Deepak - 9212745491</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>8</td>
																									<td><strong>Delhi</strong></td>
																									<td>B-1/628, Main Najafgarh Road, Janakpuri</td>
																									<td>Shalini - 9310757105</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>9</td>
																									<td><strong>Delhi</strong></td>
																									<td>2520, IInd Floor, Hudson Line, Kingsway Camp</td>
																									<td>Deepa - 9971138484</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>10</td>
																									<td><strong>NOIDA</strong></td>
																									<td>B-4, Sector - 59</td>
																									<td>Alka - 9718554709</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>11</td>
																									<td><strong>Ludhiana</strong></td>
																									<td>SCF-17/2nd Floor, Sarabha Nagar</td>
																									<td>Parneet - 9872877020</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>12</td>
																									<td><strong>Dehradun</strong></td>
																									<td>122, Premier Shopping Complex, 1st Floor, Kaulagarh Road</td>
																									<td>Amit - 9412054919</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>13</td>
																									<td><strong>Jammu</strong></td>
																									<td>5C/C, Gandhi Nagar</td>
																									<td>Roopesh - 9419183356</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>14</td>
																									<td><strong>Chandigarh</strong></td>
																									<td>SCO-60-61, 4th Floor, Sector 34-A</td>
																									<td>Niru - 9216110635</td>
																								</tr>
																								<tr bgcolor="white">
																									<td>15</td>
																									<td><strong>Gurgaon</strong></td>
																									<td>20/4, Palm Court, MG Road</td>
																									<td>Alka - 9810657497</td>
																								</tr>																								
																							</table>
																							
																							<br>
																							<br>
																							
																						
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;Step1:</strong> Submission of proof of 'highest 
																							education qualification'<br>
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;Step2:</strong> Registration fee of <span style="COLOR: #cc0000">
																								<strong>Rs.750/-</span></strong> through Demand Draft/Cash/ CC/Cheque. 
																							DD/Cheque to be made 
																							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;in 
																							favor of <span style="FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #000000">'Hero 
																								Mindmine Institute Limited'</span> - payable at par / New Delhi
																							<br>
																							<br>
																							<span style="FONT-SIZE: 11px; COLOR: #006699">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(candidate 
																								will be issued a receipt by HMIL against the acceptance of the payment)</span><br><br>
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
																							<ul>
																								<li>
																									The <u>test date</u> for each candidate will be issued by the system <u>automatically</u>, 
																								which is dependent on consumption of all the seats on each test day.
																								<li>
																								HMIL will accept applications on 'first-cum-first-served' basis. HMIL also 
																								reserves the right to reject any application that is found incomplete / 
																								unsuitable or received late.
																								<li>
																									Candidates must download their 'NAC Admission Card' <u>immediately</u>
																								after submitting the 'online registration form'.
																								<li>
																									<span style="COLOR: #cc0000"><u>DO NOT FORGET</u></span>
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
																						<TD class="white_bg">
																							<br>
																							<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For any queries, contact the following 
																								personnel at Hero Mindmine:</strong>
																							<ol>
																								<li>
																									Mr. Vikas Kaul - 9871130373 / <A href="mailto:vikas.kaul@heromindmine.com">vikas.kaul@heromindmine.com</A>
																								<li>
																									Mr. Rajiv Mohan - 9711331176 / <A href="mailto:rajiv.mohan@heromindmine.com">rajiv.mohan@heromindmine.com</A>
																								</li>
																							</ol>
																							<br>
																						</TD>
																					</TR>
																				</TBODY>
																			</TABLE>
																			<br>
																			<TABLE class="grey_bg" cellSpacing="1" cellPadding="3" width="95%" align="center" border="0">
																				<TBODY>
																					<TR class="main_black" vAlign="top" align="left">
																						<td class="lightblue_bg" vAlign="middle" height="25"><strong>To know about NAC in 
																								detail, visit <a style="FONT-WEIGHT: bold; COLOR: #0000ff; TEXT-DECORATION: none" href="http://www.nac.nasscom.in"
																									target="_self"><u>www.nac.nasscom.in</u></a> </strong>
																						</td>
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
