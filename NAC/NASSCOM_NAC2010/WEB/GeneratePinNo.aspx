<%@ Page language="c#" Codebehind="GeneratePinNo.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.GeneratePinNo" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Generate Registration Pin No</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function ValidateUser(txtNoOfPinNoCI)
			{
				var strCheck;
				strCheck = document.getElementById(txtNoOfPinNoCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter No Of IDs to be generated");
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'yellow';
					document.getElementById(txtNoOfPinNoCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'white';
				}
				
				if (strCheck > 5000)
				{
					alert("Value should be less or equal to 5000");
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'yellow';
					document.getElementById(txtNoOfPinNoCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'white';
				}
				
				return true;
			}		
			
			function Validatedata(txtNoOfPinNoCI)
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
				
				strText = document.getElementById("ddlTestName").value;
				if(strText == 0)
				{
					alert("Please select Test Event");
					document.getElementById("ddlTestName").focus();
					document.getElementById("ddlTestName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestName").style.backgroundColor = 'white';
				}	
				
				var strCheck;
				strCheck = document.getElementById(txtNoOfPinNoCI).value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter No Of IDs to be generated");
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'yellow';
					document.getElementById(txtNoOfPinNoCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'white';
				}
				
				if (strCheck > 5000)
				{
					alert("Value should be less or equal to 5000");
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'yellow';
					document.getElementById(txtNoOfPinNoCI).focus();
					return false;
				}
				else
				{
					document.getElementById(txtNoOfPinNoCI).style.backgroundColor = 'white';
				}
				
				return true;
				
					
			}
			
			function FillHiddenField()
			{
				document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
				document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
				document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;		
				document.getElementById("hdTest").value = document.getElementById("ddlTest").value;			
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
												<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Generate Registration 
													Pin No</td>
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
									<table id="Table4" cellSpacing="1" cellPadding="1" width="500" align="center" border="0">
										<tr class="main_black" align="left">
											<td class="lightblue_bg" colSpan="3" height="25"><strong>Generate Registration Pin No</strong></td>
										</tr>
										<TR>
											<TD width="43%" colSpan="3"></TD>
										</TR>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test State:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestState_SelectedIndexChanged"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test City:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCity_SelectedIndexChanged"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test Centre:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCentre_SelectedIndexChanged"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<TD align="right" width="30%">Test:<FONT class="small_maroon">*</FONT></TD>
											<TD width="70%" colSpan="2">
												<asp:dropdownlist id="ddlTestName" runat="server" CssClass="txtbox"></asp:dropdownlist></TD>
										</tr>
										<tr class="main_black" align="left">
											<td align="right" width="40%">No Of Registration Pin:<FONT class="small_maroon">*</FONT></td>
											<td width="10%"><asp:textbox id="txtNoOfPinNo" runat="server" TextMode="SingleLine" Width="60px" MaxLength="20"></asp:textbox></td>
											<td class="small_maroon" width="50%"></td>
										</tr>
										<TR>
											<td>&nbsp;</td>
											<TD width="100%" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="errarea"></asp:label></TD>
										</TR>
										<tr class="main_black" align="center">
											<td>&nbsp;</td>
											<td align="left" colSpan="2"><asp:button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
										</tr>
									</table>
									<INPUT id="hdTest" type="hidden" value="0" name="hdTest" runat="server"><INPUT id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server"><INPUT id="hdCity" type="hidden" value="0" name="hdCity" runat="server"><INPUT id="hdState" type="hidden" value="0" name="hdState" runat="server">
								</td>
							</tr>
							<tr>
								<td class="white_bg">
									<table id="dgRegistration" cellSpacing="1" cellPadding="1" width="500" align="center" border="0"
										runat="server">
										<tr class="main_black" align="left">
											<td class="lightblue_bg" colSpan="3" height="25"><strong>Registration Pin History</strong></td>
										</tr>
										<TR>
											<TD align="center" width="100%"><asp:datagrid id="dgRegistrationPin" runat="server" AutoGenerateColumns="False" BorderColor="#CCCCCC"
													BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" DataKeyField="RecordId">
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="RecordId"></asp:BoundColumn>
														<asp:BoundColumn DataField="RegPinStartId" HeaderText="Start No."></asp:BoundColumn>
														<asp:BoundColumn DataField="RegPinEndId" HeaderText="End No."></asp:BoundColumn>
														<asp:BoundColumn DataField="RegistrationDate" HeaderText="Registration Date"></asp:BoundColumn>
														<asp:BoundColumn DataField="Test" HeaderText="Test Name"></asp:BoundColumn>
														<asp:ButtonColumn Text="Export" HeaderText="Export To Excel" CommandName="ExportToExcel"></asp:ButtonColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</table>
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
