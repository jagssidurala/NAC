<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page language="c#" Codebehind="SaveAdmitCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.SaveAdmitCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Save Admit Card</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function Validatedata()
			{
				var strText;
				//validating Test ID
				strText = document.getElementById("ddlTestState").value;
				if(strText == 0)
				{
					alert("Please select Test State");
					document.getElementById("ddlTestState").focus();
					document.getElementById("ddlTestState").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestState").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlTestCity").value;
				if(strText == 0)
				{
					alert("Please select Test City");
					document.getElementById("ddlTestCity").focus();
					document.getElementById("ddlTestCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCity").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlTestCentre").value;
				if(strText == 0)
				{
					alert("Please select Test Centre");
					document.getElementById("ddlTestCentre").focus();
					document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCentre").style.backgroundColor = 'white';
				}		
				
				return true;
					
			}
			
		function FillHiddenField()
			{
				document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
				document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
				document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;			
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
									<td>
										<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
								</tr>
								<tr align="left" valign="top" class="blue_bg">
									<td class="header1" vAlign="middle">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr vAlign="top">
												<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Save Admit Card</td>
												<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
											</tr>
										</table>
									</td>
					</td>
				</tr>
				<tr class="white_bg" vAlign="top" align="center">
					<td align="center"><br>
						<table width="30%" cellspacing="1" cellpadding="0" class="lightblue_bg" border="0">
							<tr>
								<td class="white_bg">
									<table id="Table4" cellSpacing="1" cellPadding="1" width="600" align="center" border="0">
										<tr class="main_black" align="left">
											<td height="25" class="lightblue_bg" colSpan="3"><strong>Save Admit Card</strong></td>
										</tr>
										<TR>
											<TD width="43%" colspan="3"></TD>
										</TR>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test State:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test City:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test Centre:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox"></asp:dropdownlist></TD>
										</tr>
										<TR>
											<td>&nbsp;</td>
											<TD width="100%" colspan="2">
												<asp:Label id="lblMessage" CssClass="errarea" runat="server"></asp:Label></TD>
										</TR>
										<tr class="main_black" align="center">
											<td><asp:Button id="btnGenerateAdmitCard" runat="server" Text="Generate Admit Card" Width="152px" onclick="btnGenerateAdmitCard_Click"></asp:Button></td>
											<td align="left" colSpan="2"><asp:Button id="btnValidate" runat="server" Text="Validate" Width="124px" onclick="btnValidate_Click"></asp:Button>
											</td>
										</tr>
									</table>
									<INPUT id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server"><INPUT id="hdCity" type="hidden" value="0" name="hdCity" runat="server"><INPUT id="hdState" type="hidden" value="0" name="hdState" runat="server">
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
			</TBODY></TABLE>
		</FORM>
	</body>
</HTML>
