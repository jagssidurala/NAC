<%@ Page language="c#" Codebehind="LoginPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.LoginPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Login Page</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
			var elem = document.getElementById('lblErrorMsg');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
					
				
				
				var strText;			      
				
				strText = document.getElementById("txtLogin").value;
				if (Trim(strText) == "")
				{
					alert("Please enter login ID");
					document.getElementById("txtLogin").focus();
					document.getElementById("txtLogin").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtLogin").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtPassword").value;
				if (Trim(strText) == "")
				{
					alert("Please enter a password");
					document.getElementById("txtPassword").focus();
					document.getElementById("txtPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPassword").style.backgroundColor = 'white';
				}
			}
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
									<td vAlign="top">&nbsp;&nbsp;<asp:LinkButton id="lnkHome" runat="server" CssClass="link" Width="5px" onclick="lnkHome_Click">Home</asp:LinkButton>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><table>
											<tr>
												<td colspan="2" align="center"><STRONG><FONT size="4">
															<asp:Label id="Label3" runat="server" CssClass="pageheader">Login Page</asp:Label></FONT></STRONG></td>
											</tr>
											<tr>
												<td colspan="2" align="center">&nbsp;</td>
											</tr>
											<tr>
												<td>
													<asp:Label id="Label1" runat="server" CssClass="label_black_bold">Login ID</asp:Label></td>
												<td>
													<asp:TextBox id="txtLogin" runat="server" Width="180px" MaxLength="10" CssClass="newUserTextbox"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td>
													<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Password</asp:Label></td>
												<td>
													<asp:TextBox id="txtPassword" runat="server" TextMode="Password" Width="180px" MaxLength="12"
														CssClass="newUserTextbox"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td colspan="2" align="right">
													<asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="button" onclick="btnSubmit_Click"></asp:Button></td>
											</tr>
											<TR>
												<TD align="right" colSpan="2">
													<asp:LinkButton id="lnkBtnForgotPassword" runat="server" CssClass="label_black_bold" Font-Underline="True" onclick="lnkBtnForgotPassword_Click">Forgot Password</asp:LinkButton></TD>
											</TR>
											<tr>
												<td colspan="2" align="center"></SPAN>
													<asp:Label id="lblErrorMsg" runat="server" Font-Bold="True" CssClass="errormessage"></asp:Label>
												</td>
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
