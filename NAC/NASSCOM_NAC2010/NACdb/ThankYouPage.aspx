<%@ Page language="c#" Codebehind="ThankYouPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.ThankYou" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Thank You Page</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script language=javascript>

		function CloseWindow()

		{
		alert('The window will now exit for security reasons.');
		window.focus();
		window.open('','_self','');
		window.close();

		}
</script>
		<script language="JavaScript">
		function noBack()
		{
			window.history.forward()
		}
		noBack();
		window.onload=noBack;
		window.onpageshow=function(evt){if(evt.persisted)noBack()}
		window.onunload=function(){void(0)}
		</script>
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
									<td style="HEIGHT: 18px" vAlign="top" align="center"><div align="center" style="COLOR: maroon; FONT-SIZE: medium">
											<br>
											<asp:Label id="Label1" runat="server" CssClass="label_black_bold">Your request has successfully been submitted. After necessary approval, you shall receive your log-in details within 3 working days.<br><br>If you have any queries, please write to us @ nacdb@mail.nasscom.in<br><br>Thank you</asp:Label>
											<br>
											<br>
											<asp:Button id="btnClose" runat="server" Text="Close" CssClass="button" onclick="btnClose_Click"></asp:Button>
										</div>
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
