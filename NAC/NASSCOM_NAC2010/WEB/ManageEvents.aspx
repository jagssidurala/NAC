<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page language="c#" Codebehind="ManageEvents.aspx.cs" AutoEventWireup="false" Inherits="WEB.ManageEvents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Manage Registration Permissions</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
	</HEAD>
	<body>
		<FORM id="formManageEvents" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="center">
						<ajax:ajaxpanel id="AjaxPanel" runat="server" Height="100%">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR vAlign="top">
													<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Manage Events</TD>
													<TD class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
					</TD>
				</TR>
				<TR class="white_bg" vAlign="top" align="center">
					<TD align="center"><BR>
						<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
							<TR>
								<TD class="white_bg">
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="650" align="center" border="0">
										<TR>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:radiobuttonlist id="rbtnlstStateEvent" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
													<asp:ListItem Value="0">States</asp:ListItem>
													<asp:ListItem Value="1">Events</asp:ListItem>
												</asp:radiobuttonlist></TD>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD>&nbsp;
												<asp:label id="lblState_Event" runat="server"></asp:label></TD>
											<TD><asp:dropdownlist id="ddlStates" runat="server" AutoPostBack="True"></asp:dropdownlist><asp:dropdownlist id="ddlEvents" runat="server">
													<asp:ListItem Value="0">Select</asp:ListItem>
													<asp:ListItem Value="1">Retail Event I</asp:ListItem>
													<asp:ListItem Value="2">Retail Event II</asp:ListItem>
													<asp:ListItem Value="3">Retail Event III</asp:ListItem>
													<asp:ListItem Value="4">Retail Event IV</asp:ListItem>
													<asp:ListItem Value="5">Retail Event V</asp:ListItem>
													<asp:ListItem Value="6">Retail Event VI</asp:ListItem>
													<asp:ListItem Value="7">Retail Event VII</asp:ListItem>
													<asp:ListItem Value="8">Retail Event VIII</asp:ListItem>
													<asp:ListItem Value="9">Retail Event IX</asp:ListItem>
													<asp:ListItem Value="10">Retail Event X</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD>&nbsp;
												<asp:label id="lblStateEvents" runat="server">Events</asp:label></TD>
											<TD><asp:dropdownlist id="ddlStateEvents" runat="server" AutoPostBack="True">
													<asp:ListItem Value="0">Select</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD width="25%">&nbsp;
												<asp:label id="lblRegStartDate" runat="server">Registration Start date</asp:label></TD>
											<TD><asp:dropdownlist id="ddlStartDay" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlStartMonth" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlStartYear" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD width="25%"></TD>
											<TD></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD>&nbsp;
												<asp:label id="lblRegEndDate" runat="server">Registration End date</asp:label></TD>
											<TD colSpan="2"><asp:dropdownlist id="ddlEndDay" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlEndMonth" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlEndYear" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD colSpan="2"></TD>
										</TR>
										<TR class="main_black" align="center">
											<TD align="left">&nbsp;
												<asp:label id="lblTestDate" runat="server">Test Date</asp:label></TD>
											<TD align="left" width="80%" colSpan="2"><asp:dropdownlist id="ddlTestDay" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlTestMonth" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlTestYear" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD align="left"></TD>
											<TD align="left" width="80%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="main_black"><asp:label id="lblResultDeclarationDate" runat="server">Result Declaration Date</asp:label></TD>
											<TD align="left" colSpan="2"><asp:dropdownlist id="ddlResultDay" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlResultMonth" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlResultYear" Runat="server" BackColor="White" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
													<asp:ListItem Value="2010">2010</asp:ListItem>
													<asp:ListItem Value="2011">2011</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="main_black"></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="main_black">&nbsp;
												<asp:label id="Label1" runat="server">Comments</asp:label></TD>
											<TD align="left" colSpan="2"><asp:textbox id="txtcomments" runat="server" Height="72px" Width="192px" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 148px"></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
										<TR>
											<TD align="center"></TD>
											<TD align="left" colSpan="3"><asp:button id="btnSave" runat="server" Text="Submit"></asp:button></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"><asp:label id="lblMessage" runat="server" CssClass="errarea"></asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 148px"></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
									</TABLE>
									<INPUT id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server"><INPUT id="hdCity" type="hidden" value="0" name="hdCity" runat="server"><INPUT id="hdState" type="hidden" value="0" name="hdState" runat="server">
									<INPUT id="hdtestid" type="hidden" value="0" name="hdtestid" runat="server">
								</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
				</TR>
			</TABLE>
			</ajax:ajaxpanel></TD>
			<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
			</TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR>
			</TBODY></TABLE></FORM>
	</body>
</HTML>
