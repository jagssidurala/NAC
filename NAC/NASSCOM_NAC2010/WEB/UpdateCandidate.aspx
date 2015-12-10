<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="UpdateCandidate.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.UpdateCandidate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Update Candidate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="javascript">
			
		function validateWorksheet()
		{
		   var strText;
		   strText = document.getElementById("ddWorksheet").value;  
		   
		   if (Trim(strText) == "")
				{
					alert("Please select worksheet");
					document.getElementById("ddWorksheet").focus();
					document.getElementById("ddWorksheet").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddWorksheet").style.backgroundColor = 'white';
				}
		}
		</script>
	</HEAD>
	<body>
		<FORM id="frm" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr class="white_bg">
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td class="white_bg" vAlign="top" align="center">
						<table class="black_bg" id="Table2" style="WIDTH: 741px" cellSpacing="0" cellPadding="0"
							width="741" align="center" border="0">
							<tr class="white_bg" vAlign="top" align="left" height="100%">
								<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Update Candidate</td>
											<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="left">
								<td vAlign="middle">&nbsp;&nbsp;
								</td>
							</tr>
							<tr class="white_bg" vAlign="middle" align="center">
								<td align="center"><br>
									<table cellSpacing="0" cellPadding="0" width="80%" border="0">
										<tr>
											<td>
												<table id="Table4" cellSpacing="2" cellPadding="1" width="662" align="center" border="0">
													<tr class="main_black" align="left">
														<td class="lightblue_bg" colSpan="3" height="25"></td>
													</tr>
													<TR>
														<TD colSpan="3" height="25">&nbsp;</TD>
													</TR>
													<asp:panel id="pnlBrowseFile" runat="server">
														<TR class="main_black" id="trUpComment1">
															<TD style="WIDTH: 321px"></TD>
															<TD width="30%"></TD>
															<TD class="small_maroon" align="left" width="20%"></TD>
														</TR>
														<TR class="main_black" id="trUpComment2" align="left">
															<TD style="WIDTH: 321px" align="right" width="321">Browse&nbsp;Excel&nbsp;file&nbsp;and&nbsp;Click&nbsp;Submit&nbsp;</TD>
															<TD width="30%"><INPUT class="txtbox" id="CandidateInfo" type="file" name="file" runat="server"></TD>
															<TD class="small_maroon" align="left" width="20%"></TD>
														</TR>
														<TR id="trUpComment3">
															<TD style="WIDTH: 321px" align="left" width="321"></TD>
															<TD width="100%" colSpan="2">
																<asp:Button id="btnItemDone" runat="server" Text="Submit"></asp:Button></TD>
														</TR>
													</asp:panel><asp:panel id="pnlSelectSheet" runat="server">
														<TR class="main_black" align="center">
															<TD style="WIDTH: 321px" align="right" width="321">Select Worksheet and Click 
																Upload&nbsp;</TD>
															<TD align="left" width="30%">
																<asp:DropDownList id="ddWorksheet" runat="server" CssClass="txtbox"></asp:DropDownList>
																<asp:Button id="btnUpdate" runat="server" Text="Update"></asp:Button></TD>
															<TD align="left" width="20%">&nbsp;
															</TD>
														</TR>
													</asp:panel>
													<TR>
														<TD colSpan="3"></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:textbox id="txtHidden" runat="server" CssClass="txtbox" Visible="False"></asp:textbox><asp:label id="lblInfo" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 12px" align="center" colSpan="3"><asp:label id="lblTotal" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:label id="lblImported" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:label id="lblError" runat="server" CssClass="main_red_bold"></asp:label></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD align="center" colSpan="3"><asp:label id="lblRowNumber" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<!-- Start Overwrite statement -->
													<TR id="trComment1" style="DISPLAY: none">
														<TD align="center" colSpan="3"></TD>
													</TR>
													<!-- End Overwrite statement -->
													<TR>
														<TD align="center" colSpan="3"></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD align="center" colSpan="3"><A href="Welcome.aspx">Go Back</A></TD>
													</TR>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
