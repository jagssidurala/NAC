<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetStateWiseDetailsReportToExcel.aspx.cs" Inherits="NASSCOM_NAC.Web.GetStateWiseDetailsReportToExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .ExlsTableFormHeaderFont {
            TEXT-ALIGN: center;
            BACKGROUND-COLOR: #e0e0e0;
            FONT-FAMILY: Verdana;
            COLOR: #990000;
            FONT-SIZE: 10pt;
            FONT-WEIGHT: bold;
        }

        .ExlsTableInnerTable {
            BORDER-BOTTOM: #dadada 1pt solid;
            BORDER-LEFT: #dadada 1pt solid;
            BACKGROUND-COLOR: #ffffff;
            BORDER-COLLAPSE: collapse;
            FONT-FAMILY: Verdana;
            COLOR: #990000;
            BORDER-TOP: #dadada 1pt solid;
            BORDER-RIGHT: #dadada 1pt solid;
        }

        .ExlsTableDataGridBody {
            BORDER-BOTTOM: white 1px solid;
            BORDER-LEFT: white 1px solid;
            BACKGROUND-COLOR: #f5f4f4;
            FONT-FAMILY: Verdana;
            COLOR: #990000;
            FONT-SIZE: 8pt;
            BORDER-TOP: white 1px solid;
            BORDER-RIGHT: white 1px solid;
        }
    </style>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table style="POSITION: absolute; TOP: 0px; LEFT: 0px" border="1" cellspacing="0" cellpadding="0">
            <tr valign="middle" bgcolor="#666666">
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>RowNumber<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Candidate Id<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>UserId<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>RegistrationId<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Password<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Registration Date<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#00CCFF"><STRONG><br><br>Registration Time<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>First Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Middle Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Last Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Date Of Birth<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Gender<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Residential Address<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>City<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Pincode<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>STD Code<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Phone Number(Landline)<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Phone Number(Cellphone)<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Email Id<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Mothers Full Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Fathers Full Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Annual Household Income<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>BelongTo<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Highest Educational Qualification<br><br></STRONG></font></td>


                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>College Name<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>College Address<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>College City<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Qualification Details<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Aggregate Percentage Scored<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Medium of Instruction Up to 10th<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Medium of Instruction in 12th<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Employment Status<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Willing to work out of hometown<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Test City<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Test Centre<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Test State<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Photo Id Document<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Photo Id Document No.<br><br></STRONG></font></td>


                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Highest Educational Qualification Year<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>PG Specialization<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Current Location<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Language Skills<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Have Passport<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>Passport No<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>TestDate<br><br></STRONG></font></td>
                <td valign="middle" align="center" rowspan="3"><font color="#ffffff"><STRONG><br><br>TestTime<br><br></STRONG></font></td>
                <%--<td valign="middle" rowspan="2" colspan="1" align="center" bgcolor="#CCCCFF"><font color="#000000"><STRONG>Analytical
								<br>
								Ability<br>(Range 0-16)</STRONG></font>
                </td>
                <td valign="middle" rowspan="2" colspan="1" align="center" bgcolor="#EBFFCC"><font color="#000000"><STRONG>Quantitative
								<br>
								Ability<br>(Range 0-16) </STRONG></font>
                </td>
                <td valign="middle" rowspan="1" colspan="5" align="center" bgcolor="#CCCCFF"><font color="#000000"><STRONG>English Writing</STRONG></font>
                </td>
                <td valign="middle" rowspan="1" colspan="5" align="center" bgcolor="#EBFFCC"><font color="#000000"><STRONG>Speaking &amp; Listening
								</STRONG></font>
                </td>
                <td valign="middle" colspan="2" align="center" bgcolor="#CCCCFF"><font color="#000000"><STRONG>Keyboard 
								Skills </STRONG></font>
                </td>--%>
            </tr>
            <tr valign="middle" bgcolor="#666666">

              <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><strong><font color="#000000">AnalyticalScore<br>(Range 0-16)</font></strong></td>
                 <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><strong><font color="#000000">QuantitativeScore<br>(Range 0-16)</font></strong></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><i><font color="#000000">Grammar<br>(Range 0-5)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><i><font color="#000000">Content<br>(Range 0-6)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><i><font color="#000000">Vocabulary<br>(Range 0-5)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><i><font color="#000000">Spelling & Punctuation<br>(Range 0-4)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#EBFFCC" align="center"><strong><font color="#000000">Overall<br>(Range 20-80)</font></strong></td>
                <td valign="middle" rowspan="1" bgcolor="#EBFFCC" align="center"><i><font color="#000000">Sentence Mastery<br>(Range 20-80)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#EBFFCC" align="center"><i><font color="#000000">Vocabulary<br>(Range 20-80)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#EBFFCC" align="center"><i><font color="#000000">Fluency<br>(Range 20-80)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#EBFFCC" align="center"><i><font color="#000000">Pronunciation<br>(Range 20-80)</font></i></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><strong><font color="#000000">Typing Speed (wpm)</font></strong></td>
                <td valign="middle" rowspan="1" bgcolor="#CCCCFF" align="center"><strong><font color="#000000">Typing Accuracy (%)</font></strong></td>

            </tr>
            <tr valign="middle" bgcolor="#666666">
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
               <%-- <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>
                <td valign="middle" rowspan="1" align="center"><strong><font color="#ffffff">Score</font></strong></td>--%>
            </tr>
            <tr>
                <td valign="top" colspan="80">
                    <asp:DataGrid ID="dgCandidateList" runat="server" AutoGenerateColumns="False" CssClass="ExlsTableDataGridBody"
                        AllowPaging="False" EnableViewState="False" ShowFooter="True" ShowHeader="False">
                        <FooterStyle BorderWidth="0px" ForeColor="White" BackColor="#666666"></FooterStyle>
                        <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="RowNumber" HeaderText="S.No" HeaderStyle-Height="15px"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Candidate Id" HeaderText="Candidate Id"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UserId" HeaderText="UserId"></asp:BoundColumn>
                            <asp:BoundColumn DataField="RegistrationId" HeaderText="RegistrationId"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Password" HeaderText="Password"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Registration Date" HeaderText="Registration Date"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Registration Time" HeaderText="Registration Time" HeaderStyle-Height="5px"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FirstName" HeaderText="FirstName"></asp:BoundColumn>
                            <asp:BoundColumn DataField="MiddleName" HeaderText="MiddleName"></asp:BoundColumn>
                            <asp:BoundColumn DataField="LastName" HeaderText="LastName"></asp:BoundColumn>
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
                            <asp:BoundColumn DataField="College Name" HeaderText="College Name"></asp:BoundColumn>
                            <asp:BoundColumn DataField="College Address" HeaderText="College Address"></asp:BoundColumn>
                            <asp:BoundColumn DataField="College City" HeaderText="College City"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Qualification Details" HeaderText="Qualification Details"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Aggregate Percentage Scored" HeaderText="Aggregate Percentage Scored"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Medium of Instruction Up to 10th" HeaderText="Medium of Instruction Up to 10th"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Medium of Instruction in 12th" HeaderText="Medium of Instruction in 12th"></asp:BoundColumn>
                            <%--<asp:BoundColumn DataField="Passing Year 12th" HeaderText="Passing Year 12th"></asp:BoundColumn>--%>
                            <asp:BoundColumn DataField="Employment Status" HeaderText="Employment Status"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Willing to work out of hometown" HeaderText="Willing to work out of hometown"></asp:BoundColumn>


                            <asp:BoundColumn DataField="Test City" HeaderText="Test City"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Test Centre" HeaderText="Test Centre"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Test State" HeaderText="Test State"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Photo-Id Document" HeaderText="Photo-Id Document"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Photo-Id Document Number" HeaderText="Photo-Id Document Number"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Highest Educational Qualification Year" HeaderText="Highest Educational Qualification Year"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PG Specialization" HeaderText="PG Specialization"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Current Location" HeaderText="Current Location"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Language Skills" HeaderText="Language Skills"></asp:BoundColumn>

                            <asp:BoundColumn DataField="Have Passport" HeaderText="Have Passport"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Passport no" HeaderText="Passport no"></asp:BoundColumn>
                            <asp:BoundColumn DataField="TestDate" HeaderText="TestDate"></asp:BoundColumn>
                            <asp:BoundColumn DataField="TestTime" HeaderText="TestTime"></asp:BoundColumn>

                            <asp:BoundColumn DataField="AnalyticalScore" HeaderText="Score"></asp:BoundColumn>
                            <asp:BoundColumn DataField="QuantitativeScore" HeaderText="Score"></asp:BoundColumn>
                            <%--<asp:BoundColumn DataField="EWOverallScore" HeaderText="Score"></asp:BoundColumn>--%>
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
                    </asp:DataGrid></td>
            </tr>
        </table>
    </form>
</body>
</html>
