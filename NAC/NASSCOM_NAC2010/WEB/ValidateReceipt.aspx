<%@ Page language="c#" Codebehind="ValidateReceipt.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.ValidateReceipt" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Validate Receipt</title>
		<meta name="vs_snapToGrid" content="True">
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function ValidateReceipt()
			{
				var strCheck;
				strCheck = document.frmValidateReceipt.txtUserName.value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter user name");
					document.frmValidateReceipt.txtUserName.focus();
					return false;
				}
				strCheck = document.frmValidateReceipt.txtPassword.value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Password");
					document.frmValidateReceipt.txtPassword.focus();
					return false;
				}
			}
		</script>
	</HEAD>
	<body>
		<FORM id="frmValidateReceipt" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr class="white_bg">
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr align="left" valign="top" class="blue_bg">
								<td valign="middle" class="header1">&nbsp;Receipt Verification
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="center">
								<td align="center"><br>
									<table width="30%" cellspacing="1" cellpadding="0" class="lightblue_bg" border="0">
										<tr>
											<td class="white_bg" height="10">
												<table id="Table4" cellSpacing="1" cellPadding="1" width="362" align="center" border="0">
													<tr class="main_black" align="left">
														<td height="25" class="lightblue_bg" colSpan="3"><strong>&nbsp;Please enter the receipt 
																details</strong></td>
													</tr>
													<TR>
														<TD width="100%" colspan="3" height="20"></TD>
													</TR>
													<TR>
														<TD width="100%" colspan="3"></TD>
													</TR>
													<tr class="main_black" align="left">
														<td width="43%">Serial Number:<FONT class="small_maroon">*</FONT></td>
														
														<td width="55%">
															<asp:TextBox id="txtSerialNo" CssClass="txtbox" runat="server" Width="100px"></asp:TextBox>
														</td>
														<td class="small_maroon" width="2%"></td>
													</tr>
													<TR>
														<TD width="100%" colspan="3"></TD>
													</TR>
													<tr class="main_black" align="left">
														<td>PIN Number:<FONT class="small_maroon">*</FONT></td>
														</td>
														
														<td>
															<asp:TextBox id="txtPinNo" CssClass="txtbox" runat="server" Width="100px"></asp:TextBox>
														</td>
														<td class="small_maroon"></td>
													</tr>
													<TR>
														<TD width="100%" colspan="3" height="10"></TD>
													</TR>
													<tr class="main_black" align="center">
														<td colSpan="3" rowSpan="1">
															<asp:Button id="btnSubmit" runat="server" Text="Submit"></asp:Button>
														</td>
													</tr>
													<TR>
														<TD colSpan="3" height="10"></TD>
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
