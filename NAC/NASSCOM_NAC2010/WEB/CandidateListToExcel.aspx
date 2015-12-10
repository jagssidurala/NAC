<%@ Page language="c#" Codebehind="CandidateListToExcel.aspx.cs" EnableViewState="false" AutoEventWireup="True" Inherits="NASSCOM_NAC.CandidateListToExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CandidateListToExcel</title>
		<%
		    Response.Clear();
			Response.Buffer = true;
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment:filename=ReportToExcelAllExtNo.xls");
			Response.Flush();
		%>
		<style type="text/css">.ExlsTableFormHeaderFont { FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #990000; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #e0e0e0; TEXT-ALIGN: center }
	.ExlsTableInnerTable { BORDER-RIGHT: #dadada 1pt solid; BORDER-TOP: #dadada 1pt solid; BORDER-LEFT: #dadada 1pt solid; COLOR: #000000; BORDER-BOTTOM: #dadada 1pt solid; FONT-FAMILY: Verdana; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: #ffffff }
	.ExlsTableDataGridBody { BORDER-RIGHT: white 1px solid; BORDER-TOP: white 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: white 1px solid; COLOR: #990000; BORDER-BOTTOM: white 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #f5f4f4 }
	</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE cellSpacing="0" cellPadding="0" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD>
					<form id="Form1" method="post" runat="server">
						<TABLE  cellSpacing="0" cellPadding="0" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" border="1">
										<tr bgcolor=#666666>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>S.No.</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>CandidateId</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>UserId</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>Registration ID</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>Password</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>Registration Date</STRONG></FONT></td>
											<td rowspan="2" valign="middle"><FONT color="#ffffff"><STRONG>Registration Time</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>First Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Middle Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Last Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Date Of Birth</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Gender</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Residential Address</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>City</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Pincode</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>STD Code</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Phone Number(Landline)</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Phone Number(Cellphone)</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Email</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Mothers Full Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Fathers Full Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Annual Household Income</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>BelongTo</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Highest Educational Qualification</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Highest Educational Qualification Year</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>PG Specialization</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>College Name</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>College Address</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>College City</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Qualification Details</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Aggregate Percentage Scored</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Medium of Instruction Up to 10th</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Medium of Instruction in 12th</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Passing Year 12th</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Employment Status</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Current Location</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Language Skills</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Willing to work out of hometown</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Passport no</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Test Date</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Test Time</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Test City</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Test Centre</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Test State</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Photo ID Document</STRONG></FONT></td>
											<td rowspan="2"><FONT color="#ffffff"><STRONG>Photo ID Document Number</STRONG></FONT></td>
											<td align="center" colspan="2"><FONT color="#ffffff"><STRONG> Analytical &amp; Quantitative<br>
														Reasoning (Max Score - 30) </STRONG></FONT>
											</td>
											<td align="center" colspan="2"><FONT color="#ffffff"><STRONG> Writing-Multiple Choice<br>
														(Max Score - 30) </STRONG></FONT>
											</td>
											<td align="center" colspan="2"><FONT color="#ffffff"><STRONG> Learning Ability<br>
														(Max Score - 10) </STRONG></FONT>
											</td>
											<td align="center" colspan="2"><FONT color="#ffffff"><STRONG> Listening<br>
														(Max Score - 25) </STRONG></FONT>
											</td>
											<td align="center" colspan="3" valign="middle"><FONT color="#ffffff"><STRONG>Keyboard Skills </STRONG></FONT>
											</td>
											<td align="center" colspan="6"><FONT color="#ffffff"><STRONG> Speaking<br>
														(Max Score on each parameter - 5)</STRONG></FONT>
											</td>
											<td align="center" colspan="5"><FONT color="#ffffff"><STRONG> Writing-Essay<br>
														(Max Score on each parameter- 6)</STRONG></FONT>
											</td>
										</tr>
										<tr bgcolor=#666666>
											<TD><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Gross Speed (WPM)</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Accuracy (%)</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Net Speed (WPM)</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Voice Clarity</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Accent</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Fluency</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Grammar</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Prosody</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Grammar</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Content</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Vocabulary</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">Spelling &amp; Punctuation</FONT></STRONG></TD>
											<TD><STRONG><FONT color="#ffffff">%age</FONT></STRONG></TD>
										</tr>
										<tr vAlign="top">
											<td vAlign="top" colSpan="68"><asp:datagrid id="dgCandidateList" runat="server" ShowHeader="False" ShowFooter="True" EnableViewState="False"
													AllowPaging="False" CssClass="ExlsTableDataGridBody" AutoGenerateColumns="False">
													<FooterStyle BorderWidth="0px" ForeColor="White" BackColor=#666666></FooterStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="S.No.">
															<HeaderStyle HorizontalAlign="Center" />
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<%# Container.ItemIndex+1 %>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Candidate ID" HeaderText="Candidate ID" HeaderStyle-Height="15px"></asp:BoundColumn>
														<asp:BoundColumn DataField="UserId" HeaderText="UserId"></asp:BoundColumn>
														<asp:BoundColumn DataField="Registration ID" HeaderText="Registration ID" HeaderStyle-Height="5px"></asp:BoundColumn>
														<asp:BoundColumn DataField="Password" HeaderText="Password"></asp:BoundColumn>
														<asp:BoundColumn DataFormatString="{0: dd-MMMM-yyyy}" DataField="Registration Date" HeaderText="Registration Date"></asp:BoundColumn>
														<asp:BoundColumn DataField="Registration Time" DataFormatString="{0: HH:mm}" HeaderText="Registration Time"></asp:BoundColumn>
														<asp:BoundColumn DataField="First Name" HeaderText="First Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Middle Name" HeaderText="Middle Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Last Name" HeaderText="Last Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Date Of Birth" DataFormatString="{0: dd-MMMM-yyyy}" HeaderText="Date Of Birth"></asp:BoundColumn>
														<asp:BoundColumn DataField="Gender" HeaderText="Gender"></asp:BoundColumn>
														<asp:BoundColumn DataField="Residential Address" HeaderText="Residential Address"></asp:BoundColumn>
														<asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
														<asp:BoundColumn DataField="Pincode" HeaderText="Pincode"></asp:BoundColumn>
														<asp:BoundColumn DataField="STD Code" HeaderText="STD Code"></asp:BoundColumn>
														<asp:BoundColumn DataField="Phone Number(Landline)" HeaderText="Phone Number(Landline)"></asp:BoundColumn>
														<asp:BoundColumn DataField="Phone Number(Cellphone)" HeaderText="Phone Number(Cellphone)"></asp:BoundColumn>
														<asp:BoundColumn DataField="Email Id" HeaderText="Email"></asp:BoundColumn>
														<asp:BoundColumn DataField="Mothers Full Name" HeaderText="Mothers Full Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Fathers Full Name" HeaderText="Fathers Full Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Annual Household Income" HeaderText="Annual Household Income"></asp:BoundColumn>
														<asp:BoundColumn DataField="BelongTo" HeaderText="BelongTo"></asp:BoundColumn>
														<asp:BoundColumn DataField="Highest Educational Qualification" HeaderText="Highest Educational Qualification"></asp:BoundColumn>
														<asp:BoundColumn DataField="Highest Educational Qualification Year" HeaderText="Highest Educational Qualification Year"></asp:BoundColumn>
														<asp:BoundColumn DataField="PG Specialization" HeaderText="PG Specialization"></asp:BoundColumn>
														<asp:BoundColumn DataField="College Name" HeaderText="College Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="College Address" HeaderText="College Address"></asp:BoundColumn>
														<asp:BoundColumn DataField="College City" HeaderText="College City"></asp:BoundColumn>
														<asp:BoundColumn DataField="Qualification Details" HeaderText="Qualification Details"></asp:BoundColumn>
														<asp:BoundColumn DataField="Aggregate Percentage Scored" HeaderText="Aggregate Percentage Scored"></asp:BoundColumn>
														<asp:BoundColumn DataField="Medium of Instruction Up to 10th" HeaderText="Medium of Instruction Up to 10th"></asp:BoundColumn>
														<asp:BoundColumn DataField="Medium of Instruction in 12th" HeaderText="Medium of Instruction in 12th"></asp:BoundColumn>
														<asp:BoundColumn DataField="Passing Year 12th" HeaderText="Passing Year 12th"></asp:BoundColumn>
														<asp:BoundColumn DataField="Employment Status" HeaderText="Employment Status"></asp:BoundColumn>
														<asp:BoundColumn DataField="Current Location" HeaderText="Current Location"></asp:BoundColumn>
														<asp:BoundColumn DataField="Language Skills" HeaderText="Language Skills"></asp:BoundColumn>
														<asp:BoundColumn DataField="Willing to work out of hometown" HeaderText="Willing to work out of hometown"></asp:BoundColumn>
														<asp:BoundColumn DataField="Passport no" HeaderText="Passport no"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestDate" HeaderText="Test Date"></asp:BoundColumn>
														<asp:BoundColumn DataField="TestTime" HeaderText="Test Time"></asp:BoundColumn>
														<asp:BoundColumn DataField="Test City" HeaderText="Test City"></asp:BoundColumn>
														<asp:BoundColumn DataField="Test Centre" HeaderText="Test Centre"></asp:BoundColumn>
														<asp:BoundColumn DataField="Test State" HeaderText="Test State"></asp:BoundColumn>
														<asp:BoundColumn DataField="Photo-Id Document" HeaderText="Photo ID Document"></asp:BoundColumn>
														<asp:BoundColumn DataField="Photo-Id Document Number" HeaderText="Photo ID Document Number"></asp:BoundColumn>
														<asp:BoundColumn DataField="AQRScore" HeaderText="Score"></asp:BoundColumn>
														<asp:BoundColumn DataField="AQRPercentage" HeaderText="%age"></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingScore" HeaderText="Score"></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingPercentage" HeaderText="%age"></asp:BoundColumn>
														<asp:BoundColumn DataField="LAScore" HeaderText="Score"></asp:BoundColumn>
														<asp:BoundColumn DataField="LAPercentage" HeaderText="%age"></asp:BoundColumn>
														<asp:BoundColumn DataField="ListeningScore" HeaderText="Score"></asp:BoundColumn>
														<asp:BoundColumn DataField="ListeningPercentage" HeaderText="%age"></asp:BoundColumn>
														<asp:BoundColumn DataField="KeyboardGrossSpeed" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="KeyboardAccuracy" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="KeyboardNetSpeed" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingVoiceClarity" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingAccent" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingFluency" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingGrammar" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingProsody" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="SpeakingPercentage" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingEssayGrammar" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingEssayContent" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingEssayVocabulary" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingEssaySpelling_Punctuation" HeaderText=""></asp:BoundColumn>
														<asp:BoundColumn DataField="WritingEssayPercentage" HeaderText=""></asp:BoundColumn>
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
