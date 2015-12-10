<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Login" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Login</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function ValidateUser(txtUserNameCI,txtPasswordCI)
			{
			
				var strCheck;
				strCheck = document.getElementById(txtUserNameCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter User name");
					document.getElementById(txtUserNameCI).style.backgroundColor = 'yellow';
					document.getElementById(txtUserNameCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtUserNameCI).style.backgroundColor = 'white';
				}
				strCheck = document.getElementById(txtPasswordCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter Password");
					document.getElementById(txtPasswordCI).style.backgroundColor = 'yellow';
					document.getElementById(txtPasswordCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtPasswordCI).style.backgroundColor = 'white';
				}
				return true;
			}		
		</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="center">
						<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<TR class="white_bg" vAlign="top" align="left">
								<TD>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
							</TR>
							<TR class="blue_bg" vAlign="top" align="left">
								<TD class="header1" vAlign="middle">&nbsp;&nbsp;Login
								</TD>
							</TR>
							<TR class="white_bg" vAlign="top" align="center">
								<TD align="center"><BR>
									<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
										<TR>
											<TD class="white_bg">
												<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="362" align="center" border="0">
													<TR class="main_black" align="left">
														<TD class="lightblue_bg" colSpan="3" height="25"><STRONG>Login</STRONG></TD>
													</TR>
													<TR>
														<TD width="43%" colSpan="3"></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD width="43%">User Name:<FONT class="small_maroon">*</FONT></TD>
														<TD width="55%">
															<asp:TextBox id="txtUserName" runat="server" MaxLength="20" Width="120px" TextMode="SingleLine"></asp:TextBox></TD>
														<TD class="small_maroon" width="2%"></TD>
													</TR>
													<TR>
														<TD width="100%" colSpan="3"></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD>Password:<FONT class="small_maroon">*</FONT></TD>
														<TD>
															<asp:TextBox id="txtPassword" runat="server" MaxLength="20" Width="120px" TextMode="Password"></asp:TextBox></TD>
														<TD class="small_maroon"></TD>
													</TR>
													<TR>
														<TD width="100%" colSpan="3"></TD>
													</TR>
													<TR class="main_black" align="center">
														<TD>&nbsp;</TD>
														<TD align="left" colSpan="2">
															<asp:Button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:Button>&nbsp;<INPUT type="reset" value="Reset"></TD>
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
					<TD vAlign="bottom" align="center">
						<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif">
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
