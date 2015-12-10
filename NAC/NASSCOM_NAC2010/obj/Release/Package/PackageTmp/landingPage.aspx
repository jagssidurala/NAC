<%@ Page language="c#" Codebehind="landingPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.landingPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>landingPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK media="screen" href="Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script>

	function new_window(url)
	{
		newwindow=window.open(url,'Feedback','top=50,left=200,width=500,height=400,scrollbars=no');
		newwindow.focus();
	}
	
	function NoEventAlert()
	{
		alert('Currently there is no NAC event in your state. Please visit after some time.');
	}
		</script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0">
		<FORM id="frmAdmitCard" method="post" runat="server">
			<div align="center">
				<div class="container">
					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td colSpan="2"><IMG alt="" src="Web/Images/BANNER.jpg"></td>
						</tr>
						<tr>
							<td vAlign="top" width="704">
								<br>
								<div align="left" class="textBold" style="MARGIN-LEFT: 10px; FONT-SIZE: 13px; TEXT-DECORATION: underline">About 
											NAC</div>
											<div class="textBold" style="MARGIN-LEFT: 10px; MARGIN-TOP: 10px">
											An assessment/certification program for those who aim to join the Indian BPO 
										industry</div>
								<div style="MARGIN-LEFT: 10px; MARGIN-TOP: 10px; MARGIN-BOTTOM: 30px" class="textNormal">
								NASSCOM, with the support from 
										the Indian BPO industry partners, has devised an assessment-cum-certification 
										program - the <font color="#990000">NASSCOM Assessment of Competence (NAC)</font>. 
										The initiative will prove to be the first-level recruitment filter for 
										companies and will help the test takers reach the companies in a more 
										quantitative as well as qualitative manner through their NAC scores. This will 
										be done by continuously assessing candidates on key skills required by the BPO 
										companies, thus making it easier for companies to screen the candidates and 
										this will also provide candidates with their training-need analysis.
								</div>
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td width="234">
											<div class="boxDiv2">
												<div class="textBold" style="FONT-SIZE: 13px">The 
													Approach</div>
												<div class="line"><IMG src="Web/Images/naclone.jpg"></div>
												<div class="fontNormal" style="HEIGHT: 55px">
													Phase-I Approach
													<br>
													Phase-II Approach
												</div></div>
												<div align="right"><A style="FONT-SIZE: 11px; COLOR: #990000; FONT-FAMILY: Arial" href="web/TheApproach.aspx"
														target="_blank">Read more...</A></div>
											
										</td>
										<td width="236">
											<div class="boxDiv2">
												<div class="textBold" style="FONT-SIZE: 13px">NAC 
													Benefits
												</div>
												<div class="line"><IMG src="Web/Images/naclone.jpg"></div>
												<div class="fontNormal" style="HEIGHT: 55px">	
													For Job Aspirants<br>
													For Industry / Companies<br>
													For State Governments<br>
													For Educational Institutions
												</div>
												</div>
												<div align="right"><A style="FONT-SIZE: 11px; COLOR: #990000; FONT-FAMILY: Arial" href="web/NACBenefits.aspx"
														target="_blank">Read more...</A></div>
											
										</td>
										<td width="234">
											<div class="boxDiv2">
												<div class="textBold" style="FONT-SIZE: 13px">FAQs 
													on NAC
												</div>
												<div class="line"><IMG src="Web/Images/naclone.jpg"></div>
												<div class="fontNormal" style="HEIGHT: 55px">
													Where does Indian BPO industry stand today?<br>
													What role do BPO companies play in NAC?<br>
													What is the eligibility criterion for NAC?
												</div>
											</div>
											<div align="right"><A style="FONT-SIZE: 11px; COLOR: #990000; FONT-FAMILY: Arial" href="web/Faq.aspx"
													target="_blank">Read more...</A></div>
										</td>
									</tr>
									<tr>
										<td vAlign="top">&nbsp;</td>
									</tr><tr>
										<td vAlign="top">&nbsp;</td>
									</tr>
									<tr>
										<td vAlign="top">
											<p align="center"><A href="web/AlreadyRegistered.aspx"><IMG src="Web/Images/nacScoreAdmit.jpg" border="0"></A></p>
										</td>
										<td vAlign="top">
											<p align="center"><a href="http://nac.nasscom.in/Web/NAC Sample Papers.zip" target="_self"><IMG src="Web/Images/samplePapers.jpg" border="0"></a></p>
										</td>
										<td vAlign="top">
											<p align="center"><A href="web/SkillCompetency.aspx" target="_blank"><IMG src="Web/Images/skilltesting.jpg" border="0"></A></p>
										</td>
									</tr>
								</table>
							</td>
							<td vAlign="top">
								<table cellSpacing="0" cellPadding="0" width="240" border="0">
									<tr>
										<td class="loginBoxBack" style="BACKGROUND-IMAGE: url(Web/Images/RegisterForNAC.jpg)">
											<div class="loginBoxDivHome">
												<div><asp:dropdownlist id="ddlState" runat="server"></asp:dropdownlist>&nbsp;<asp:imagebutton id="btnGo" ImageUrl="Web/Images/gobtn.gif" Runat="server" onclick="btnGo_Click"></asp:imagebutton></div>
											</div>
										</td>
									</tr>
									<tr>
										<td class="nacEvents">
											<div class="boxDivLanding">
												<marquee scrollDelay="300" direction="up" behavior="scroll" height="100">
													<div class="textNormal">No 'live' event as on date.</div>
												</marquee>
											</div>
										</td>
									</tr>
									<tr style="MARGIN-TOP: 100px">
										<td style="MARGIN-TOP: 100px">
											<p align="center" style="MARGIN-TOP: 5px"><A href="landingPage.aspx"><IMG onclick="new_window('Web/SendFeedbackMail.aspx?type=nac');" src="Web/Images/WriteToUsLanding.jpg"
														border="0"></A></p>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td colSpan="2">
								<div style="MARGIN-TOP: 5px" align="center"><IMG src="Web/Images/login_07.jpg"></div>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</FORM>
	</body>
</HTML>
