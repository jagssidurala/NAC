<%@ Page language="c#" Codebehind="EncryptDecrypt.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.EncryptDecrypt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Encrypt Decrypt Page</title>
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
				var strText;			      
				
				strText = document.getElementById("txtPassword").value;
				if (Trim(strText) == "")
				{
					var elem = document.getElementById('lblResult');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
					
					alert("Please enter an encrypted password");
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
									<td vAlign="top">
										<h1>&nbsp;&nbsp;&nbsp;
											<asp:LinkButton id="lnkHome" runat="server" CssClass="link" Width="5px" onclick="lnkHome_Click">Home</asp:LinkButton></h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center">
										<asp:TextBox id="txtPassword" runat="server" MaxLength="200" CssClass="newUserTextbox"></asp:TextBox>&nbsp;
										<asp:Button id="btnGetPassword" runat="server" Text="Get Password" CssClass="button" onclick="btnGetPassword_Click"></asp:Button>&nbsp;
										<asp:Button id="btnBack" runat="server" CssClass="button" Text="Back" onclick="btnBack_Click"></asp:Button>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top" align="center">&nbsp;</td>
								</tr>
								<TR>
									<TD style="HEIGHT: 20px" vAlign="top" align="center">
										<asp:Label id="lblResult" runat="server" CssClass="errormessage"></asp:Label></TD>
								</TR>
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
