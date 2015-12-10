<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="Welcome.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Welcome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Welcome Page</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</HEAD>
	<script language="javascript">

function CloseWindow()

{
alert('The window will now exit for security reasons.');
window.focus();
window.open('','_self','');
window.close();

}
	</script>
	<META Http-Equiv="Cache-Control" Content="no-cache">
	<META Http-Equiv="Pragma" Content="no-cache">
	<META Http-Equiv="Expires" Content="0">
	<LINK rel="stylesheet" type="text/css" href="stylesheet/nasscom.css">
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
	<meta name="CODE_LANGUAGE" content="C#">
	<meta name="vs_defaultClientScript" content="JavaScript">
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<script language="JavaScript" type="text/JavaScript">
	</script>
	<FORM id="Form1" method="post" runat="server">
		<table id="Table1" border="0" cellSpacing="0" cellPadding="0" width="756" align="center"
			height="100%">
			<tr vAlign="top">
				<td vAlign="top" background="images/tbg_left.gif" width="7" align="center"><IMG src="images/spacer.gif" width="7" height="1"></td>
				<td vAlign="top" align="center">
					<table id="Table2" class="black_bg" border="0" cellSpacing="0" cellPadding="0" width="100%"
						align="center">
						<tr class="white_bg" vAlign="top" align="left">
							<td colSpan="2"><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
						</tr>
						<tr class="blue_bg" vAlign="top" align="left">
							<td class="header1" vAlign="middle">&nbsp;&nbsp;Welcome User&nbsp;</td>
							<TD align="right">
								<div id="divLnkCandidate" runat="server"><A class="header1" href="../HomePage.aspx">Home</A>&nbsp;&nbsp;&nbsp;
								</div>
								<div id="divLnkAdmin" runat="server"><A class="header1" href="Login.aspx">Home</A>&nbsp;&nbsp;&nbsp;
								</div>
								<div id="divLnkETS" runat="server"><A class="header1" href="Login.aspx">Home</A>&nbsp;&nbsp;&nbsp;
								</div>
							</TD>
						<tr class="white_bg" vAlign="top" align="left">
							<td width="200" align="left">
								<div id="divCandidate" runat="server">
									<table border="0" cellSpacing="2" cellPadding="5" width="100%">
										<TR>
											<TD height="40" align="left"></TD>
										</TR>
										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="ViewYoursProfile" href="CandidateProfile.aspx?login=true" src="ViewYourProfile"
													alt="View Your Profile">View/Print Your Profile</A></td>
										</tr>
										<tr class="main_black">
											<%if(intStateId ==100 && DateOfRegistration>Convert.ToDateTime("01-31-2008")){%>
											<td align="left"><A id="PrintAdmitCard" href="MessageState.aspx" src="AdmitCard.aspx" alt="Print Admit Card">View/Print 
													Your Admit Card</A>
											</td>
											<%} else {%>
											<td align="left"><A id=PrintAdmitCard href='AdmitCard.aspx?login=true&amp;RegistrationId=<%=Session["UsreID"]%>'  src="AdmitCard.aspx" alt="Print Admit Card">View/Print 
													Your Admit Card</A>
											</td>
											<%}%>
										</tr>
										<tr class="main_black" align="center">
											<%if(DateOfRegistration>Convert.ToDateTime("10-10-2010")){%>
											<td align="left">
												<A id="ViewScoreCard" href="TestScorePercentageV2.aspx" src="Link1" alt="View Score Card">
													View/Print Your Score Card</A> 
												<!--<A id="ViewScoreCard" target="_self" href="http://174.133.14.66/ReportServer/Pages/ReportViewer.aspx?%2fNACScoreCardV2%2fScoreCard&rs%3aCommand=Render&RegistrationId=NGGJGA121000021&rs:Format=PDF"  src="Link1" alt="View Score Card">View/Print 
													Your Score Card</A>	-->
												<!--		<A id="ViewScoreCard" target="_self" href="ScoreCardPDFV2.aspx"  alt="View Score Card">View/Print 
													Your Score Card</A>	-->
											</td>
											<%} else if(DateOfRegistration>Convert.ToDateTime("11-06-2008")){%>
											<td align="left"><A id="ViewScoreCard" href="TestScorePercentage.aspx" src="Link1" alt="View Score Card">View/Print 
													Your Score Card</A>
											</td>
											<%} else if(DateOfRegistration>Convert.ToDateTime("10-01-2007")){%>
											<td align="left"><A id="ViewScoreCard" href="TestScore.aspx" src="Link1" alt="View Score Card">View/Print 
													Your Score Card</A>
											</td>
											<%} else {%>
											<td align="left"><A id="ViewScoreCard" href="Certificate.aspx" src="Link1" alt="View Score Card">View/Print 
													Your Score Card</A></td>
											<%}%>
										</tr>
										<tr style="DISPLAY: none" class="main_black" align="center">
											<%if(DateOfRegistration>Convert.ToDateTime("10-01-2007")){%>
											<td noWrap align="left"><A id="JobFairCard_MT" href="JobFairCard_MT.aspx?login=true" src="JobFairCard" alt="View Your Profile">View/Print 
													Your Job Fair Card</A></td>
											<%} else {%>
											<td noWrap align="left"><A id="JobFairCard" href="JobFairCard.aspx?login=true" src="JobFairCard" alt="View Your Profile">View/Print 
													Your Job Fair Card</A></td>
											<%}%>
										</tr>
										<tr class="main_black" align="center">
											<td noWrap align="left">
												<!-- <A id="Logout" runat="server" href="PinLogin.aspx" src="Logout" alt="Logout">Logout</A> -->
												<asp:LinkButton id="lbtnLogout" runat="server" onclick="lbtnLogout_Click">Logout</asp:LinkButton>
												<!--	<asp:HyperLink id="hlLogout" runat="server" >Logout</asp:HyperLink></td> --></td>
										</tr>
									</table>
								</div>
								<div id="divAdmin" runat="server">
									<table border="0" cellSpacing="2" cellPadding="5" width="100%">
										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="Candidatelist" href="AdminCandidateSearch.aspx" alt="View Candidate details">View 
													Candidate details</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="Candidatelistsearch" href="Candidatelistsearch.aspx" alt="View Candidate details for ETS">View 
													Candidate details (MeritTrac)</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="UploadScore" href="UploadScore.aspx" alt="Upload Score">Upload 
													Score(ETS)</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="UploadScoreCard" href="UploadScoreCard.aspx" alt="Upload Score">Upload 
													Score(MeritTrac)</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="GrantPermission" href="GrantPermission.aspx" src="Link1" alt="Grant Permission">Grant 
													Permission </A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<TD align="left">
												<A id="RegistrationStatus" href="TestRegistrationStatus.aspx" src="Link5" alt="Test Registration Status">
													Test Registration Status</A></TD>
										</tr>
										<tr class="main_black" align="center">
											<TD align="left"><A id="CreateTest" href="CreateTest.aspx" alt="Create Test" src="Link5">Create 
													Test</A></TD>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="GenarateId" href="GenerateID.aspx" src="Link5" alt="Generate Id">Generate 
													Id </A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="GenaratePin" href="GeneratePinno.aspx" src="GenPin" alt="Generate PinNo">Generate&nbsp;user 
													ID/password&nbsp; </A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="HtmlEditor" href="TestPage.aspx" src="HtmlEditor" alt="Html Editor ">Welcome&nbsp;Page 
													Management&nbsp; </A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="VisitorCount" href="VisitorCount.aspx" src="Link6" alt="Visitor Tracker">Visitor 
													Tracker </A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="DeActivateCentre" href="DeactivateCentre.aspx" src="Link6" alt="Visitor Tracker">Set 
													Registration Permissions</A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<%if(Convert.ToInt32(intRequestStatus) == 0){%>
											<td align="left"><A id="PendingListForApproval" href="ScoreUploadRequest.aspx" src="Link7" alt="Score upload request">Score&nbsp;upload&nbsp;request</A>
											</td>
											<%}else {%>
											<td align="left"><A id="PendingListForApprovalP" href="ScoreUploadRequest.aspx" src="Link7" alt="Score upload request">Score&nbsp;upload&nbsp;request</A>&nbsp;<font color="red">(Pending)</font>
											</td>
											<%}%>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="uploadJobFairCard" href="UploadJobfaircard.aspx" src="Link7" alt=" upload job fair request">Upload&nbsp;Job 
													&nbsp;Fair&nbsp;Card&nbsp;request</A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="TJVisitorCount" href="TJVisitCount.aspx" src="Link7" alt=" TJ Visitor Count">TJ&nbsp;Visitor 
													&nbsp;Count</A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="AdminHome" href="../nacdb/AdminHome.aspx" alt="Admin Home" src="Link9">Endorsing&nbsp;Company&nbsp;Admin&nbsp;section</A>
											</td>
										</tr>
                                        <tr class="main_black" align="center">
											<td noWrap align="left"><A id="A1" href="AutomateRegistered_Count.aspx" src="Shift-wise Registered count" alt="Shift-wise Registered count">Shift-wise Registered count</A></td>
										</tr>

                                        <tr class="main_black" align="center">
											<td noWrap align="left"><A id="A2" href="RegistrationWindow.aspx" src="Extend Registration Window" alt="Extend Registration Window">Extend Registration Window</A></td>
										</tr>


										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="Logout" href="Login.aspx" src="Logout" alt="Logout">Logout</A></td>
										</tr>
									</table>
								</div>
								<div id="divETS" runat="server">
									<table border="0" cellSpacing="2" cellPadding="5" width="100%">
										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="ETSCandidatelist" href="SearchCandidateByETS.aspx" alt="View Candidate details">View 
													Candidate details</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="ETSUploadScore" href="UploadScore.aspx" alt="Upload Score">Upload 
													Score</A></td>
										</tr>
										<tr class="main_black" align="center">
											<td align="left"><A id="PendingListForApprovaETS" href="Score_Upload_Request.aspx" src="Link7" alt="Score upload request">Score&nbsp;upload&nbsp;request</A>
											</td>
										</tr>
										<tr class="main_black" align="center">
											<td noWrap align="left"><A id="ETSLogout" href="Login.aspx" src="Logout" alt="Logout">Logout</A></td>
										</tr>
									</table>
								</div>
							</td>
							<td align="center"><br>
								<table id="Table4" border="0" cellSpacing="1" cellPadding="7" width="100%" align="center">
									<tr align="left">
										<td>
											<P class="main_black"><b>Welcome</b>
												<%if(Convert.ToInt32(Session["UserType"]) != 3){%>
												<asp:label id="lblWelcomeText" runat="server"></asp:label>
												<%}%>
											</P>
											<P><asp:label id="lblBodyText" runat="server"></asp:label></P>
											<p>&nbsp;</p>
											<div id="divFlash" runat="server">
												<table>
													<tr class="main_black_Font" align="left">
														<td>
															<P style="TEXT-JUSTIFY: newspaper; TEXT-ALIGN: justify">
																<asp:linkbutton class="main_black_Font" id="lnkClickHere" runat="server" Font-Underline="True" ForeColor="#365F91"
																	Font-Bold="True" Visible="False">CLICK HERE</asp:linkbutton>
																<span style="COLOR: #365f91" class="main_black_Font"><EM style="FONT-SIZE: 8pt"></EM>
																</span>
															</P>
														</td>
													</tr>
												</table>
											</div>
											<%if(Convert.ToInt32(Session["StateId"]) >100){%>
											<div id="divLogin" runat="server">
												<table id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
													<tr class="main_black" align="left">
														<td>
															<p>NASSCOM, in association with Times Group, in order to enhance the chances of 
																your employment, has got your bio-data created on "TimesJobs.Com", one of 
																India's major e-employment portals. You may now view your bio-data on the 
																website (<a style="COLOR: #0000ff; TEXT-DECORATION: underline" href="http://www.timesjobs.com"
																	target="_self">www.timesjobs.com</a>) and apply to various jobs published 
																on the website by over 25,000 employers across the country.</p>
															<p>In order to login to <a style="COLOR: #0000ff; TEXT-DECORATION: underline" href="http://www.timesjobs.com"
																	target="_self">www.timesjobs.com</a>, following user ID/password will be 
																required, which is as follows:</p>
															<p><asp:label id="Label1" runat="server" Width="75px">
																	<strong>User ID -</strong></asp:label>&nbsp;&nbsp;
																<asp:label id="lblUserId" runat="server"></asp:label><br>
																<asp:label id="Label2" runat="server" Width="75px">
																	<strong>Password -</strong></asp:label>&nbsp;&nbsp;
																<asp:label id="lblPassword" runat="server"></asp:label></p>
															<p>Please use the following e-mail ID while you contact any of the 
																employers/companies for job:</p>
															<p><asp:label id="Label3" runat="server" Width="75px">
																	<strong>E-mail ID -</strong></asp:label>&nbsp;&nbsp;
																<asp:label id="lblEmailId" runat="server"></asp:label><br>
																<asp:label id="Label5" runat="server" Width="75px">
																	<strong>Password -</strong></asp:label>&nbsp;&nbsp;
																<asp:label id="lblPassword1" runat="server"></asp:label></p>
															<p>For any queries, please write to <A href="mailto:nac@nasscom.in">nac@nasscom.in</A></p>
															<p>Thanks!</p>
														</td>
													</tr>
												</table>
											</div>
											<%}%>
											<P>&nbsp;</P>
										</td>
									</tr>
								</table>
								<br>
							</td>
						</tr>
					</table>
				</td>
				<td vAlign="top" background="images/tbg_right.gif" width="7" align="center"><IMG src="images/spacer.gif" width="7" height="1"></td>
			</tr>
			<TR>
				<TD vAlign="top" background="images/tbg_left.gif" width="7" align="center"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" background="images/tbg_right.gif" width="7" align="center"></TD>
			</TR>
		</table>
	</FORM>
</HTML>
