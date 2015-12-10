<%@ Page language="c#" Codebehind="AdminHome.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.AdminHome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Admin Home</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<link rel="stylesheet" href="../Web/Stylesheet/nasscomNew.css" type="text/css">
		
	</HEAD>
	
	<script language=javascript>

		function CloseWindow()

		{
		alert('The window will now exit for security reasons.');
		window.focus();
		window.open('','_self','');
		window.close();

		}
</script>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<table border="0" id="table1" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellpadding="0" cellspacing="0" width="888">
								<tr>
									<td rowspan="9">
										&nbsp;</td>
									<td valign="top">
										<img src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td rowspan="9" width="4">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<h1>
											&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td valign="top" style="HEIGHT: 18px" align="center">
										<table width="90%">
											<tr>
												<td colspan="2" align="left">
													<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Welcome Administrator</asp:Label>
												</td>
											</tr>
											<tr>
												<td colspan="2" align="center" style="HEIGHT: 19px"><STRONG><FONT size="4" class="header_text">
															<asp:Label id="Label1" runat="server" CssClass="pageheader">Admin Home Page</asp:Label></FONT></STRONG></td>
											</tr>
											<tr>
												<td colspan="2" align="center">&nbsp;</td>
											</tr>
											<tr>
												<td>
													<asp:LinkButton id="lnkSendEmail" runat="server" CssClass="link" Width="143px" onclick="lnkSendEmail_Click">Send email to members</asp:LinkButton></td>
											</tr>
											<tr>
												<td style="HEIGHT: 21px">
													<asp:LinkButton id="lnkApproveDenyRequest" runat="server" CssClass="link" Width="250px" onclick="lnkApproveDenyRequest_Click">Approve/Deny Pending Requests</asp:LinkButton></td>
											</tr>
											<tr>
												<td colspan="2" align="left">
													<asp:LinkButton id="lnkViewAll" runat="server" CssClass="link" Width="107px" onclick="lnkViewAll_Click">View All members</asp:LinkButton></td>
											</tr>
											<TR>
												<TD align="left" colSpan="2">
													<asp:LinkButton id="lnkbtnEncryptDecrypt" runat="server" CssClass="link" Width="111px" onclick="lnkbtnEncryptDecrypt_Click">Decrypt Password</asp:LinkButton></TD>
											</TR>
											<tr>
												<td colspan="2" align="left">
													<asp:LinkButton id="lnkLogOut" runat="server" CssClass="link" Width="50px" onclick="lnkLogOut_Click">Log Out</asp:LinkButton></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top" style="HEIGHT: 20px">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../Web/Images/footer2014.gif"><A href="mailto:nac@nasscom.in"></A></DIV>
										</DIV>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
