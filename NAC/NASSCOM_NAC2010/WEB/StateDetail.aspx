<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="StateDetail.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.StateDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>State Detail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TR class="white_bg" vAlign="top" align="left">
									<TD><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
								</TR>
								<TR class="blue_bg" vAlign="top" align="left">
									<TD class="header1" vAlign="middle">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR vAlign="top">
												<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;State Details</TD>
												<TD class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR class="white_bg" vAlign="top" align="center">
									<TD align="center"><BR>
										<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
											<TR>
												<TD class="white_bg">
													<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="650" align="center" border="0">
														<TR class="main_black" align="left">
															<TD class="lightblue_bg" colSpan="3" height="25"><STRONG>State Details</STRONG></TD>
														</TR>
														<TR>
															<TD width="30%" colSpan="3"></TD>
														</TR>
														<TR class="main_black" align="left">
															<TD align="right" width="20%">State List:<FONT class="small_maroon">*</FONT></TD>
															<TD colSpan="2"><asp:dropdownlist id="ddlTestState" runat="server" AutoPostBack="True" CssClass="txtbox" Width="184px"></asp:dropdownlist>
																<asp:button id="Button7" runat="server" Text="Add New"></asp:button>
																<asp:button id="Button3" runat="server" Width="100px" Text="Edit Details"></asp:button></TD>
														</TR>
														<TR class="main_black" align="left">
															<TD align="right" width="30%"></TD>
															<TD colSpan="2"></TD>
														</TR>
														<TR class="main_black">
															<TD align="center" width="30%" colSpan="3"></TD>
														</TR>
														<TR class="main_black" align="left">
															<TD style="HEIGHT: 18px" align="right" width="30%"><FONT class="small_maroon"></FONT></TD>
															<TD style="HEIGHT: 18px" width="40%"></TD>
															<TD style="HEIGHT: 18px" width="30%"></TD>
														</TR>
														<TR class="main_black" align="left">
															<TD align="right" width="30%"></TD>
															<TD width="40%"></TD>
															<TD width="30%"></TD>
														</TR>
														<TR>
															<TD colSpan="3"></TD>
														</TR>
														<tr>
															<td align="center" colSpan="3">
																<table width="650">
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%" style="HEIGHT: 26px">State Name:</TD>
																		<TD width="70%" colspan="2" style="HEIGHT: 26px"><asp:textbox id="TextBox1" runat="server" Width="160px"></asp:textbox></TD>
																	</TR>
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%">State Code:</TD>
																		<TD width="70%" colspan="2"><asp:textbox id="Textbox2" runat="server" Width="160px"></asp:textbox></TD>
																	</TR>
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%">State Logo:</TD>
																		<TD width="70%" colspan="2"><asp:textbox id="Textbox3" runat="server" Width="160px"></asp:textbox><asp:button id="Button4" runat="server" Text="Browse"></asp:button></TD>
																	</TR>
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%">ETS Access:</TD>
																		<TD width="70%" colspan="2"><asp:checkbox id="CheckBox1" runat="server"></asp:checkbox></TD>
																	</TR>
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%">Admit card Availablity:</TD>
																		<TD width="70%" colspan="2"><asp:checkbox id="Checkbox2" runat="server"></asp:checkbox>
																			<asp:dropdownlist id="ddlDay" CssClass="txtarea" Runat="server" BackColor="White">
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
																			</asp:dropdownlist><asp:dropdownlist id="ddlMonth" CssClass="txtarea" Runat="server" BackColor="White">
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
																			</asp:dropdownlist><asp:dropdownlist id="ddlYear" CssClass="txtarea" Runat="server" BackColor="White">
																				<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
																				<asp:ListItem Value="1990">1990</asp:ListItem>
																				<asp:ListItem Value="1989">1989</asp:ListItem>
																				<asp:ListItem Value="1988">1988</asp:ListItem>
																				<asp:ListItem Value="1987">1987</asp:ListItem>
																				<asp:ListItem Value="1986">1986</asp:ListItem>
																				<asp:ListItem Value="1985">1985</asp:ListItem>
																				<asp:ListItem Value="1984">1984</asp:ListItem>
																				<asp:ListItem Value="1983">1983</asp:ListItem>
																				<asp:ListItem Value="1982">1982</asp:ListItem>
																				<asp:ListItem Value="1981">1981</asp:ListItem>
																				<asp:ListItem Value="1980">1980</asp:ListItem>
																				<asp:ListItem Value="1979">1979</asp:ListItem>
																				<asp:ListItem Value="1978">1978</asp:ListItem>
																				<asp:ListItem Value="1977">1977</asp:ListItem>
																				<asp:ListItem Value="1976">1976</asp:ListItem>
																				<asp:ListItem Value="1975">1975</asp:ListItem>
																				<asp:ListItem Value="1974">1974</asp:ListItem>
																				<asp:ListItem Value="1973">1973</asp:ListItem>
																				<asp:ListItem Value="1972">1972</asp:ListItem>
																				<asp:ListItem Value="1971">1971</asp:ListItem>
																				<asp:ListItem Value="1970">1970</asp:ListItem>
																				<asp:ListItem Value="1969">1969</asp:ListItem>
																				<asp:ListItem Value="1968">1968</asp:ListItem>
																				<asp:ListItem Value="1967">1967</asp:ListItem>
																				<asp:ListItem Value="1966">1966</asp:ListItem>
																				<asp:ListItem Value="1965">1965</asp:ListItem>
																				<asp:ListItem Value="1964">1964</asp:ListItem>
																				<asp:ListItem Value="1963">1963</asp:ListItem>
																				<asp:ListItem Value="1962">1962</asp:ListItem>
																				<asp:ListItem Value="1961">1961</asp:ListItem>
																				<asp:ListItem Value="1960">1960</asp:ListItem>
																				<asp:ListItem Value="1959">1959</asp:ListItem>
																				<asp:ListItem Value="1958">1958</asp:ListItem>
																				<asp:ListItem Value="1957">1957</asp:ListItem>
																				<asp:ListItem Value="1956">1956</asp:ListItem>
																				<asp:ListItem Value="1955">1955</asp:ListItem>
																				<asp:ListItem Value="1954">1954</asp:ListItem>
																				<asp:ListItem Value="1953">1953</asp:ListItem>
																				<asp:ListItem Value="1952">1952</asp:ListItem>
																				<asp:ListItem Value="1951">1951</asp:ListItem>
																				<asp:ListItem Value="1950">1950</asp:ListItem>
																				<asp:ListItem Value="1949">1949</asp:ListItem>
																			</asp:dropdownlist>
																		</TD>
																	</TR>
																	<TR class="main_black" width="100%">
																		<TD align="right" width="30%">Customise Mailformat:</TD>
																		<TD width="70%" colspan="2">
																			<asp:checkbox id="Checkbox3" runat="server"></asp:checkbox></TD>
																	</TR>
																</table>
																<asp:button id="Button5" runat="server" Text="Submit"></asp:button>&nbsp;
																<asp:button id="Button1" runat="server" Text="Cancel"></asp:button></td>
														</tr>
														<TR>
															<TD width="20%">&nbsp;</TD>
															<TD width="80%" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="errarea"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
						<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
						<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
					</TR>
				</TBODY>
			</TABLE>
		</FORM>
	</body>
</HTML>
