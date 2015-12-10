<%@ Page language="c#" Codebehind="Admitcard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Admitcard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>Admit Card</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">		
	
		 	function PrintReport()
		 	{
			 	print();
			}
		
			</script>
			<script type="text/javascript">
			function noBack(){window.history.forward()}
			noBack();
			window.onload=noBack;
			window.onpageshow=function(evt){if(evt.persisted)noBack()}
			window.onunload=function(){void(0)}
			</script>
	</HEAD>
	<body>
		<FORM id="frmAdmitCard" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<tr>
					<td vAlign="middle" align="center" width="600" height="600">
						<div id="container">
							<TABLE cellSpacing="1" cellPadding="1" align="center" border="1"> <!--Start of Admit Card Table-->
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<div align="right"><asp:button id="btnBack" runat="server" Text="Exit" CssClass="btEdit" onclick="btnBack_Click"></asp:button></div>
											<TABLE cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
												<TBODY>
													<TR>
														<TD vAlign="top" align="left">
															<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TBODY>
																	<TR>
																		<TD width="192" height="95px" align="left">
																			<!-- <IMG alt="#" src="Images/logo2.gif"> --->
																			<asp:Image id="imgLogo"  height="95px" runat="server"></asp:Image></TD>
														</TD>
														<TD align="center">
															<TABLE id="Table2" align="center" border="0" cellSpacing="0" cellPadding="0" width="100%">
																<TR>
																	<TD width="100%" height="95px" align="center" valign="middle">
																		<asp:Label ID="lblLogoHeader" Runat="server" Font-Name="Verdana" Font-Size="14pt" ForeColor="#00008b"
																			Font-Bold="True"></asp:Label>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<tr>
														<td width="100%" colSpan="2" align="center"><IMG align="absMiddle" src="images/RedRuler.JPG">
														</td>
													</tr>
												</TBODY>
											</TABLE>
										</TD>
									<TR>
										<TD height="10"></TD>
									</TR>
									<!--	<TR>
										<TD vAlign="top" align="center">
											<H1>NAC - NASSCOM Assessment of Competence
											</H1>
										</TD>
									</TR> -->
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">
											<H2>Admission Card</H2>
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="main_blue_bold" vAlign="top" align="center"><U><asp:label id="lblState" runat="server" Font-Bold="true"></asp:label></U></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="left">&nbsp;</TD>
									</TR>
									<TR>
										<TD class="small_blue" vAlign="top" align="center">
											<TABLE cellSpacing="1" cellPadding="3" width="80%" border="0">
												<TBODY>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Registration ID: </STRONG>
														</TD>
														<TD width="60%"><asp:label id="lblRegistrationID" runat="server"></asp:label></SPAN></TD>
														<TD width="70%" rowSpan="7"><asp:image id="imgUploadPhotograph" Runat="server" ImageUrl="Images/defaultphoto.jpg" Width="120px"></asp:image></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Name:</STRONG></TD>
														<TD width="60%"><asp:label id="lblName" runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Date of Birth: </STRONG>
														</TD>
														<TD width="60%"><asp:label id="lblDOB" runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Gender: </STRONG>
														</TD>
														<TD width="60%"><asp:label id="lblGender" runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD noWrap width="40%"><STRONG>Highest Education: </STRONG>
														</TD>
														<TD width="60%"><asp:label id="lblQualification" runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="top" align="left">
														<TD vAlign="top" width="40%" height="15"><STRONG>Test Centre: </STRONG>
														</TD>
														<TD width="60%" height="15"><asp:label id="lblTestLocation" runat="server"></asp:label><br>
															<asp:label id="lblCentreAddress" Runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Test City: </STRONG>
														</TD>
														<TD width="60%"><asp:label id="lblCity" runat="server"></asp:label></TD>
													</TR>
													<TR vAlign="middle" align="left">
														<TD width="40%"><STRONG>Test Date:</STRONG></TD>
														<TD width="60%"><asp:label id="lblTestDate" runat="server"></asp:label></TD>
													</TR>
												</TBODY></TABLE>
											<BR>
											<TABLE cellSpacing="1" cellPadding="3" width="80%" border="0">
												<TBODY>
													<TR vAlign="middle" align="left">
														<TD width="60%"></TD>
														<TD class="main_blue_bold" align="right" width="40%">Candidate's Signature</TD>
													</TR>
												</TBODY></TABLE>
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="blue_bg" vAlign="top" align="left"><IMG height="1" alt="#" src="Images/spacer.gif" width="1"></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="left">&nbsp;</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="main_blue_bold" vAlign="top" align="left">Important Points
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">&nbsp;
										</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="left">
											<OL class="small_grey" type="1">
												<LI>
												Do take a printout of your Admission Card (A4 size / portrait).
												<LI>
												Paste your recent color passport-size photo in the given space (in case you 
												have not uploaded it already) and sign the Admission Card in the given space.
												<LI>
													<U><STRONG>It is mandatory to carry to the test centre your NAC Admission Card and the 
															Photo-ID Document, details of which were filled by you in the online 
															registration form. Failing this, you will not be allowed to sit for the test. </STRONG>
													</U>
												<LI>
												Your photograph on the Admission Card must match the one on the photo-ID 
												document.
												<LI>
												In case of loss of the Admission Card, the candidate must visit the website 
												(www.nac.nasscom.in) and log in to his/her account to print it again.
												<LI>
												Candidates are requested to report at the test centre at least 30 minutes 
												before the test timing.
												<LI>
												Do not write/mark on any sheet, which is given to you at the test center, 
												without invigilator's permission.
												<LI>
												Candidates should carry their own stationery. Test center shall not be 
												providing the same.
												<LI>
													For any queries, please get in touch with the nodal person/agency for NAC in 
													your college/state.
												<LI>
                                                    Please take a note of your NAC Registration ID. You will need it for future references
                                                </LI>
											</OL>
											<br>
											<div class="main_blue_bold" align="left">To view your profile - please visit <A href="../Default.aspx" target="_blank">
													www.nac.nasscom.in</A></div>
										</TD>
									</TR>
								</TBODY></TABLE>
					</td>
				</tr>
			</table>
			<INPUT id="NoPrint" onclick="PrintReport();" type="button" value="Print" name="NoPrint">
			<asp:Button id="btnSave" runat="server" Text="Save" onclick="btnSave_Click"></asp:Button></DIV></TD></TR></TBODY></TABLE>
		</FORM>
	</body>
</HTML>
