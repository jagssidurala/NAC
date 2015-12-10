<%@ Page language="c#" Codebehind="GenerateAdmitCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.GenerateAdmitCard" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Generate Admit Card</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="756" border="0" align="center" cellpadding="0" cellspacing="0" ID="Table1">
				<tr>
					<td width="7" align="center" valign="top" background="images/tbg_left.gif"><img src="images/spacer.gif" width="7" height="1"></td>
					<td align="center" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="1" class="black_bg" ID="Table2">
							<tr align="left" valign="top" class="white_bg">
								<td>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header>
								</td>
							</tr>
							<tr align="left" valign="top" class="blue_bg">
								<td valign="middle" class="header1">&nbsp;&nbsp;REGISTRATION FORM
								</td>
							</tr>
							<tr align="left" valign="top" class="white_bg">
								<td align="center"><br>
									<table width="85%" border="0" cellspacing="0" cellpadding="3" ID="Table4">
										<tr align="left" valign="top" class="main_black">
											<td colspan="3" class="lightblue_bg"><strong>Thanks for submitting your profile. You 
													can now take print out of your Admit Card</strong></td>
										</tr>
										<tr align="left" valign="top" class="main_black">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr align="center" valign="top" class="main_black">
											<td colspan="3">
												<asp:Button id="Button1" runat="server" Text="Print Admit Card" onclick="Button1_Click"></asp:Button>&nbsp;</td>
										</tr>
									</table>
									<br>
								</td>
							</tr>
							<tr align="left" valign="top" class="white_bg">
								<td>&nbsp;
									<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer>
								</td>
							</tr>
						</table>
					</td>
					<td width="7" align="center" valign="top" background="images/tbg_right.gif"><img src="images/spacer.gif" width="7" height="1"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
