<%@ Page language="c#" Codebehind="Home.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.Home" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Home Page</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">
										<h1>&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><table>
											<tr>
												<td align="center" colSpan="2"><STRONG><FONT size="4"><asp:label id="Label1" runat="server" CssClass="pageHeader">Home Page</asp:label></FONT></STRONG></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;</td>
											</tr>
											<tr>
												<td><asp:label id="Label2" runat="server" CssClass="label_black_bold">For Already Registered</asp:label></td>
												<td><asp:linkbutton id="lnkbtnAlreadyReg" runat="server" CssClass="link" onclick="lnkbtnAlreadyReg_Click">Already Registered</asp:linkbutton></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;</td>
											</tr>
											<tr>
												<td><asp:label id="Label3" runat="server" CssClass="label_black_bold">To Register</asp:label></td>
												<td><asp:linkbutton id="lnkbtnLogin" runat="server" CssClass="link" onclick="lnkbtnLogin_Click">Sign Up</asp:linkbutton></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
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
