<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="VisitorCount.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.VisitorCount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Generate Registration ID</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<ajax:AjaxPanel id="AjaxPanel" runat="server" Height="100%">
<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
					border="0">
					<TR>
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR vAlign="top">
													<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;<STRONG>Number of Visitors</STRONG></TD>
													<TD class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></TD>
												</TR>
											</TABLE>
										</TD>
						</TD>
					</TR>
					<TR class="white_bg" vAlign="top" align="center">
						<TD align="center"><BR>
							<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
								<TR>
									<TD class="white_bg">
										<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="600" align="center" border="0">
											<TR class="main_black" align="left">
												<TD class="lightblue_bg" colSpan="3" height="25"><STRONG></STRONG></TD>
											</TR> <!-- Start Code here -->
											<TR vAlign="top" align="left">
												<TD vAlign="top" align="center" width="100%" colSpan="3" height="25"></TD>
											</TR>
											<TR vAlign="top" align="right" height="10%">
												<TD>
													<TABLE id="Table2" height="100%" cellSpacing="5" cellPadding="0" width="100%" align="center"
														border="0">
														<TR class="main_black">
															<TD vAlign="top" align="right" width="10%" height="25">From :</TD>
															<TD vAlign="top" width="35%">
																<asp:dropdownlist id="ddlFromDay" Runat="server" CssClass="txtarea">
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
																</asp:dropdownlist>
																<asp:dropdownlist id="ddlFromMonth" Runat="server" CssClass="txtarea">
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
																</asp:dropdownlist>
																<asp:dropdownlist id="ddlFromYear" Runat="server" CssClass="txtarea">
																	<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
																	<asp:ListItem Value="2010">2010</asp:ListItem>
																	<asp:ListItem Value="2009">2009</asp:ListItem>
																	<asp:ListItem Value="2008">2008</asp:ListItem>
																	<asp:ListItem Value="2007">2007</asp:ListItem>
																	<asp:ListItem Value="2006">2006</asp:ListItem>
																	<asp:ListItem Value="2005">2005</asp:ListItem>
																	<asp:ListItem Value="2004">2004</asp:ListItem>
																	<asp:ListItem Value="2003">2003</asp:ListItem>
																	<asp:ListItem Value="2002">2002</asp:ListItem>
																	<asp:ListItem Value="2001">2001</asp:ListItem>
																	<asp:ListItem Value="2000">2000</asp:ListItem>
																	<asp:ListItem Value="1999">1999</asp:ListItem>
																	<asp:ListItem Value="1998">1998</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD vAlign="top" align="right" width="10%" height="25">To :</TD>
															<TD vAlign="top" width="35%">
																<asp:dropdownlist id="ddlToDay" Runat="server" CssClass="txtarea">
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
																</asp:dropdownlist>
																<asp:dropdownlist id="ddlToMonth" Runat="server" CssClass="txtarea">
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
																</asp:dropdownlist>
																<asp:dropdownlist id="ddlToYear" Runat="server" CssClass="txtarea">
																	<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
																	<asp:ListItem Value="2010">2010</asp:ListItem>
																	<asp:ListItem Value="2009">2009</asp:ListItem>
																	<asp:ListItem Value="2008">2008</asp:ListItem>
																	<asp:ListItem Value="2007">2007</asp:ListItem>
																	<asp:ListItem Value="2006">2006</asp:ListItem>
																	<asp:ListItem Value="2005">2005</asp:ListItem>
																	<asp:ListItem Value="2004">2004</asp:ListItem>
																	<asp:ListItem Value="2003">2003</asp:ListItem>
																	<asp:ListItem Value="2002">2002</asp:ListItem>
																	<asp:ListItem Value="2001">2001</asp:ListItem>
																	<asp:ListItem Value="2000">2000</asp:ListItem>
																	<asp:ListItem Value="1999">1999</asp:ListItem>
																	<asp:ListItem Value="1998">1998</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD vAlign="top" width="10%">
																<asp:button id="btnSubmit" runat="server" Height="22" Text="Submit" onclick="btnSubmit_Click"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" width="20%" colSpan="3">
													<asp:datagrid id="dgVisitorCount" runat="server" AutoGenerateColumns="False" Width="50%">
														<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
															BackColor="#000084"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataFormatString="{0:MM/dd/yyyy}" DataField="DATE" HeaderText="Date"></asp:BoundColumn>
															<asp:BoundColumn DataField="HitCount" HeaderText="No. of hits"></asp:BoundColumn>
														</Columns>
													</asp:datagrid>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-----
													<DIV class="main_black">Total No. of 
														hits:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<B>
															<asp:Label id="lblTotalNumberOfHits" Runat="server" CssClass="small_blue"></asp:Label></B></DIV>
												</TD>
											</TR> <!-- End Code here -->
											<TR>
												<TD class="small_blue" width="43%" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>Total 
														number of hits on this portal&nbsp;:&nbsp;
														<asp:Label id="lblTotalHits" Runat="server"></asp:Label></STRONG></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<BR>
						</TD>
					</TR>
				</TABLE></TD>
    <TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD></TR>
  <TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center">
						<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR></TBODY></TABLE></ajax:AjaxPanel></FORM>
	</body>
</HTML>
