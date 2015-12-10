<%@ Page language="c#" Codebehind="Andra_Pradesh_SingleEvent.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.Andra_Pradesh_SingleEvent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Single Event</title>
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="stylesheet/nasscomnew.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0">
		<div align="center">
			<table id="table1" cellSpacing="0" cellPadding="0" border="0">
				<TBODY>
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<TBODY>
									<tr>
										<td rowSpan="9">&nbsp;</td>
										<td vAlign="top"><IMG src="Images/BANNERline.jpg"></td>
										<td width="4" rowSpan="9">&nbsp;</td>
									</tr>
									<tr>
										<td vAlign="top" class="pageHeader" style="PADDING-TOP: 5px">
											NAC events at
												<asp:Label id="lblState" runat="server"></asp:Label>
										</td>
										<TD vAlign="top" align="right"><a style="FONT-WEIGHT: bold; TEXT-DECORATION: underline" Class="main_black" href="javascript:history.back();">Back</a></TD>
									</tr>
									<tr>
										<td vAlign="top" align="center">
											<div class="singleEvent" align="center">
												<table class="textBold" width="auto" style="MARGIN-LEFT:-100px; MARGIN-TOP:10px">
													<TBODY>
														<tr id="trEventName">
															<td class="singleEventHeader" >
																<asp:Label  id="lblEvent" runat="server"></asp:Label></td>
														</tr>
														<tr id="trComments" runat="server">
															<td align="left" colSpan="2"><asp:label id="lblComments" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td>&nbsp;
															</td>
														</tr>
														<tr id="trRegStartDate" runat="server">
															<td align="left" width="30%"><asp:label id="lblRegStartDateText" Runat="server">Registration Start Date:&nbsp;</asp:label></td>
															<td style="FONT-WEIGHT: normal"><asp:label id="lblRegStartDate" runat="server"></asp:label></td>
														</tr>
														<tr>
															<td>&nbsp;
															</td>
														</tr>
														<tr id="trRegEndDate" runat="server">
															<td align="left" width="30%"><asp:label id="lblRegEndDateText" runat="server">Registration End Date:&nbsp;</asp:label></td>
															<td style="FONT-WEIGHT: normal"><asp:label id="lblRegEndDate" runat="server"></asp:label></td>
														</tr>
														<tr>
														</tr>
														<tr>
															<td>&nbsp;
															</td>
														</tr>
														<TR id="trTestDate" runat="server">
															<td align="left" width="30%"><asp:label id="lblTestDateText" runat="server">Test Date:&nbsp;</asp:label></td>
															<td style="FONT-WEIGHT: normal"><asp:label id="lblTestDate" runat="server"></asp:label></td>
														</TR>
									</tr>
									<tr>
										<td>&nbsp;
										</td>
									</tr>
									<tr id="trResultDeclarationDate" runat="server">
										<td align="left" width="30%"><asp:label id="lblResultDeclarationDateText" runat="server">Result Declaration Date:&nbsp;</asp:label></td>
										<td style="FONT-WEIGHT: normal"><asp:label id="lblResultDeclarationDate" runat="server"></asp:label></td>
									</tr>
									<tr>
										<td colSpan="2">&nbsp;</td>
									</tr>
									<tr>
										<td style="MARGIN-RIGHT: 5px" borderColor="black" borderColorLight="gray" align="center"
											borderColorDark="black" colSpan="2" height="25">To register for this event <A href="PinLogin.aspx">
												CLICK HERE</A>
										</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
									</tr>
								</TBODY>
							</table>
		</div>
		</SPAN></TD></TR>
		<tr>
			<td valign="top" align="center">
				<div align="left">
					<ul class="textNormal">
						<li>
						Registration will be done on 'first-come-first-served' basis as each test 
						centre will have limited seats.
						<li>
						'Admission Card' must immediately be downloaded / printed out by the candidate 
						after successful submission of the 'online registration form'. If lost, 
						Admission Card can be downloaded again by logging in to the account through 
						'Already Registered' section.
						<li>
						One must remember to carry the ‘Admission Card' as well as an authentic 'Photo 
						ID proof’ to the test center on the day of the test.
						<li>
						Online registration form allows candidates to 'upload' their recent PP-size 
						photograph; however, if one does not have the soft copy of the photo, he/she 
						must paste the photograph on the Admission Card after downloading / printing 
						it.
						<li>
							Registration fee paid by the candidate, who is allowed to sit for the exam, is 
							non-refundable.</li>
					</ul>
				</div>
				<DIV class="landingFooter">
					<DIV class="divLeft"><IMG src="../web/Images/login_07.jpg"><A href="mailto:nac@nasscom.in"></A></DIV>
				</DIV>
			</td>
		</tr>
		</TBODY></TABLE></TD></TR></TBODY></TABLE></DIV>
	</body>
</HTML>
