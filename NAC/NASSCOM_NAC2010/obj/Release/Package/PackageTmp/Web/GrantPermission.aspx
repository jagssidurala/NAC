<%@ Page language="c#" Codebehind="GrantPermission.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.GrantPermission" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Grant Permission</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function AddPermission(chkValue)
			{
			  
				var strFieldNames = document.getElementById('hdnFieldNames').value;
				if (document.getElementById(chkValue).checked)
				{
					if (strFieldNames.indexOf(chkValue)== -1)
					{
						strFieldNames = strFieldNames + ','+chkValue;
					}
				}
				else
				{
					if (strFieldNames.indexOf(chkValue)>= 0)
					{
						var tmpValue = "";
						if (strFieldNames.indexOf(chkValue) == 0)
							tmpValue = chkValue+',';
						else
							tmpValue = ','+chkValue;
						strFieldNames = strFieldNames.replace(tmpValue,'');
					}
				}
				document.getElementById('hdnFieldNames').value = strFieldNames;
			}		
		</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<TBODY>
								<tr class="white_bg" vAlign="top" align="left">
									<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
								</tr>
								<tr class="blue_bg" vAlign="top" align="left">
									<td class="header1" vAlign="middle">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr vAlign="top">
												<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Grant Permission</td>
												<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
											</tr>
										</table>
									</td>
					</td>
				</tr>
				<tr class="white_bg" vAlign="top" align="center">
					<td align="center"><br>
						<table class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
							<tr>
								<td class="white_bg">
									<table id="Table4" cellSpacing="1" cellPadding="1" width="600" align="center" border="0">
										<tr class="main_black" align="left">
											<td class="lightblue_bg" colSpan="3" height="25"><strong>Grant Permission</strong></td>
										</tr>
										<TR>
											<TD width="43%" colSpan="3"></TD>
										</TR>
										<tr class="main_black">
											<td align="left" colSpan="2"><asp:label id="lblCandidateField" runat="server"></asp:label></td>
										</tr>
										<TR>
											<td width="40%">&nbsp;</td>
											<TD width="60%" align="left"><asp:label id="lblMessage" Text="Record updated" ForeColor="red" Visible="False" Font-Bold="True"
													Runat="server" CssClass="small_maroon"></asp:label></TD>
										</TR>
										<tr class="main_black" align="center">
											<td width="40%">&nbsp;</td>
											<td align="left" width="60%"><asp:button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
										</tr>
									</table>
									<INPUT id="hdnFieldNames" type="hidden" runat="server">
								</td>
							</tr>
						</table>
						<br>
					</td>
				</tr>
			</table>
			</TD>
			<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
			</TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR>
			</TBODY></TABLE></FORM>
	</body>
</HTML>
