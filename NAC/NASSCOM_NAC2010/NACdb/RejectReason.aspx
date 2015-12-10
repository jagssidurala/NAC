<%@ Page language="c#" Codebehind="RejectReason.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.RejectReason" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<HTML>
  <HEAD>
		<title>RejectReason</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../WEB/Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="../WEB/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
				var elem = document.getElementById('lblError');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
					
				var strText;			      
				strText = document.getElementById("txtRejectReason").value;
				if (Trim(strText) == "")
				{
					alert("Please enter reject reason");
					document.getElementById("txtRejectReason").focus();
					document.getElementById("txtRejectReason").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtRejectReason").style.backgroundColor = 'white';
					return true;
				}
			}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
						<asp:Label ID="lblReason" CssClass="label_black_bold" Runat="server">Reason for rejection:</asp:Label>
					</td>
					<td>
					<asp:textbox id="txtRejectReason" runat="server" MaxLength="100" Width="180px" TextMode="MultiLine" Font-Size="11px" BorderColor="#CCCCCC" BorderStyle="Solid" Font-Names="Tahoma"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">&nbsp;
						<asp:Label id="lblError" runat="server" CssClass="errormessage"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2" align="right">
						<asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="button" onclick="btnCancel_Click"></asp:Button>&nbsp;
						<asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="button" onclick="btnSubmit_Click"></asp:Button>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
