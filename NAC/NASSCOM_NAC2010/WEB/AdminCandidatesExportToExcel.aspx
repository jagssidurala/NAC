<%@ Page language="c#" Codebehind="AdminCandidatesExportToExcel.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.AdminCandidatesExportToExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<HTML>
	<HEAD>
		<title>CandidateListToExcel</title>
	
		<style type="text/css">.ExlsTableFormHeaderFont {
	TEXT-ALIGN: center; BACKGROUND-COLOR: #e0e0e0; FONT-FAMILY: Verdana; COLOR: #990000; FONT-SIZE: 10pt; FONT-WEIGHT: bold
}
.ExlsTableInnerTable {
	BORDER-BOTTOM: #dadada 1pt solid; BORDER-LEFT: #dadada 1pt solid; BACKGROUND-COLOR: #ffffff; BORDER-COLLAPSE: collapse; FONT-FAMILY: Verdana; COLOR: #000000; BORDER-TOP: #dadada 1pt solid; BORDER-RIGHT: #dadada 1pt solid
}
.ExlsTableDataGridBody {
	BORDER-BOTTOM: white 1px solid; BORDER-LEFT: white 1px solid; BACKGROUND-COLOR: #f5f4f4; FONT-FAMILY: Verdana; COLOR: #990000; FONT-SIZE: 8pt; BORDER-TOP: white 1px solid; BORDER-RIGHT: white 1px solid
}
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="POSITION: absolute; TOP: 0px; LEFT: 0px" border="1" cellSpacing="0" cellPadding="0">
				<tr vAlign="middle" bgColor="#666666">
					<td vAlign="middle" align="center" rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>S.No.<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Test Date<br><br></STRONG></FONT></td>
                    <td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Test Time<br><br></STRONG></FONT></td>
                     <td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Test Centre<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Test City<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Test State<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#00CCFF"><STRONG><br><br>NAC Reg. ID<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>First Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Middle Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Last Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Date Of Birth<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Gender<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Residential Address<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>City<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Pincode<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>STD Code<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Phone Number(Landline)<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Phone Number(Cellphone)<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Email Id<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Mothers Full Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Fathers Full Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Annual Household Income<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>BelongTo<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Highest Educational Qualification<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Highest Educational Qualification Year<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>PG Specialization<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>College Name<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>College Address<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>College City<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Qualification Details<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Aggregate Percentage Scored<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Medium of Instruction Up to 10th<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Medium of Instruction in 12th<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Passing Year 12th<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Employment Status<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Current Location<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Language Skills<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Willing to work out of hometown<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Serial No.<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Pin No.<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Photo Id Document<br><br></STRONG></FONT></td>
					<td vAlign="middle" align="center"rowSpan="3"><FONT color="#ffffff"><STRONG><br><br>Photo Id Document No.<br><br></STRONG></FONT></td>

					<td vAlign="middle" rowspan="2" colSpan="1" align="center" bgColor="#CCCCFF"><FONT color="#000000"><STRONG>Analytical
								<br>
								Ability<br>(Range 0-16)</STRONG></FONT>
					</td>
					<td vAlign="middle" rowspan="2" colSpan="1" align="center" bgColor="#EBFFCC"><FONT color="#000000"><STRONG>Quantitative
								<br>
								Ability<br>(Range 0-16) </STRONG></FONT>
					</td>
					<td vAlign="middle" rowspan="1" colSpan="5" align="center" bgColor="#CCCCFF"><FONT color="#000000"><STRONG>English Writing</STRONG></FONT>
					</td>
					<td vAlign="middle" rowspan="1" colSpan="5" align="center"  bgColor="#EBFFCC"><FONT color="#000000"><STRONG>Speaking &amp; Listening
								</STRONG></FONT>
					</td>
					<td vAlign="middle" colSpan="2" align="center" bgColor="#CCCCFF"><FONT color="#000000"><STRONG>Keyboard 
								Skills </STRONG></FONT>
					</td>
				</tr>
				<tr vAlign="middle" bgColor="#666666">
					
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><STRONG><FONT color="#000000">Overall<br>(Range 0-20)</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><I><FONT color="#000000">Grammar<br>(Range 0-5)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><I><FONT color="#000000">Content<br>(Range 0-6)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><I><FONT color="#000000">Vocabulary<br>(Range 0-5)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><I><FONT color="#000000">Spelling & Punctuation<br>(Range 0-4)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#EBFFCC" align="center" ><STRONG><FONT color="#000000">Overall<br>(Range 20-80)</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#EBFFCC"  align="center" ><I><FONT color="#000000">Sentence Mastery<br>(Range 20-80)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#EBFFCC"  align="center" ><I><FONT color="#000000">Vocabulary<br>(Range 20-80)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#EBFFCC"  align="center" ><I><FONT color="#000000">Fluency<br>(Range 20-80)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#EBFFCC"  align="center" ><I><FONT color="#000000">Pronunciation<br>(Range 20-80)</FONT></I></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><STRONG><FONT color="#000000">Typing Speed (wpm)</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" bgColor="#CCCCFF" align="center" ><STRONG><FONT color="#000000">Typing Accuracy (%)</FONT></STRONG></TD>
					
				</tr>
				<tr vAlign="middle" bgColor="#666666">
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
					<TD vAlign="middle" rowspan="1" align="center" ><STRONG><FONT color="#ffffff">Score</FONT></STRONG></TD>
				</tr>

				<tr vAlign="top">
					<td vAlign="top" colSpan="56"><asp:datagrid id="dgCandidateList" runat="server" AutoGenerateColumns="False" CssClass="ExlsTableDataGridBody"
							AllowPaging="False" EnableViewState="False" ShowFooter="True" ShowHeader="False">
							<FooterStyle BorderWidth="0px" ForeColor="White" BackColor="#666666"></FooterStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="rowid" HeaderText="S.No" HeaderStyle-Height="15px"></asp:BoundColumn>
								<asp:BoundColumn DataField="TestDate" HeaderText="Test Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TestTime" HeaderText="Test Time"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Test Centre" HeaderText="Test Center"></asp:BoundColumn>
								<asp:BoundColumn DataField="Test City" HeaderText="Test City"></asp:BoundColumn>
								<asp:BoundColumn DataField="Test State" HeaderText="Test State"></asp:BoundColumn>
								<asp:BoundColumn DataField="Registration Id" HeaderText="Registration Id" HeaderStyle-Height="5px"></asp:BoundColumn>
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
								<asp:BoundColumn DataField="Email Id" HeaderText="Email Id"></asp:BoundColumn>
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
								
								<asp:BoundColumn DataField="UserId" HeaderText="Serial No."></asp:BoundColumn>
								<asp:BoundColumn DataField="PinNo" HeaderText="Pin No."></asp:BoundColumn>
								<asp:BoundColumn DataField="Photo-Id Document" HeaderText="Photo-Id Document"></asp:BoundColumn>
								<asp:BoundColumn DataField="Photo-Id Document Number" HeaderText="Photo-Id Document Number"></asp:BoundColumn>
								
								<asp:BoundColumn DataField="AnalyticalScore" HeaderText="Score"></asp:BoundColumn>
								<asp:BoundColumn DataField="QuantitativeScore" HeaderText="Score"></asp:BoundColumn>
								<asp:BoundColumn DataField="EWOverallScore" HeaderText="Score"></asp:BoundColumn>
								<asp:BoundColumn DataField="EWGrammarScore" HeaderText="Score"></asp:BoundColumn>
								<asp:BoundColumn DataField="EWContentScore" HeaderText="Score"></asp:BoundColumn>
								<asp:BoundColumn DataField="EWVocabularyScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="EWSpellingScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="SLOverallScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="SLSentenceScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="SLVocabularyScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="SLFluencyScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="SLPronunciationScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="KSTSpeedScore" HeaderText=""></asp:BoundColumn>
								<asp:BoundColumn DataField="KSTAccuracyScore" HeaderText=""></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
