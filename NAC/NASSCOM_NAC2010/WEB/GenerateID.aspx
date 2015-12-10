<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="GenerateID.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.GenerateID" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Generate Registration ID</TITLE>
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
				
				
				//validating Number of Registration
				strText = document.getElementById("txtNumberofregistration").value;
				if(Trim(strText)=="")
				{
					alert("Please enter number of RegistrationId to generate");
					document.getElementById("txtNumberofregistration").focus();
					document.getElementById("txtNumberofregistration").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtNumberofregistration").style.backgroundColor = 'white';
				}	
				
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtNumberofregistration").focus();
					document.getElementById("txtNumberofregistration").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtNumberofregistration").style.backgroundColor = 'white';
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
												<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Generate Registration 
													ID</td>
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
										<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="600" align="center">
											<TR class="main_black" align="left">
												<TD class="lightblue_bg" height="25" colSpan="3"><STRONG>Generate Registration ID</STRONG></TD>
											</TR>
											<TR>
												<TD width="43%" colSpan="3"></TD>
											</TR>
											<TR class="main_black" align="left">
												<TD width="30%" align="right">Test State:<FONT class="small_maroon">*</FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestState_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR class="main_black" align="left">
												<TD width="30%" align="right">Test City:<FONT class="small_maroon">*</FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCity_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR class="main_black" align="left">
												<TD width="30%" align="right">Test Centre:<FONT class="small_maroon">*</FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCentre_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR class="main_black" align="left">
												<TD width="30%" align="right">Test Name:<FONT class="small_maroon">*</FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:dropdownlist id="ddlTestName" runat="server" CssClass="txtbox"></asp:dropdownlist></TD>
											</TR>
											<TR class="main_black" align="left">
												<TD width="30%" align="right">Number of Ids:<FONT class="small_maroon">*</FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:TextBox id="txtNumberofregistration" runat="server" CssClass="txtbox" MaxLength="20" Width="144px"
														TextMode="SingleLine"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD></TD>
												<TD width="100%" colSpan="2"></TD>
											</TR>
											<TR>
												<TD>&nbsp;</TD>
												<TD width="100%" colSpan="2">
													<asp:Label id="lblMessage" runat="server" CssClass="errarea"></asp:Label></TD>
											</TR>
											<TR class="main_black" align="center">
												<TD>&nbsp;</TD>
												<TD colSpan="2" align="left">
													<asp:Button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:Button></TD>
											</TR>
										</TABLE>
									
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
