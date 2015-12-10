<%@ Page language="c#" Codebehind="CompanyHire.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.CompanyHire" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CompanyProfile</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript">
			function ValidateData()
			{
				//Validate Registration Id
				strText = document.getElementById("txtRegistrationId").value;
				if (Trim(strText) == "")
				{
					alert("Please enter registration id");
					document.getElementById("txtRegistrationId").focus();
					document.getElementById("txtRegistrationId").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtRegistrationId").style.backgroundColor = 'white';
				}
			}	
			
			function checkDeclaration()
			{
				//Validate declaration
				if(document.getElementById("chkDeclaration").checked == false)
			    {
			        alert("Please accept the Declaration");
					document.getElementById("chkDeclaration").focus();
					document.getElementById("chkDeclaration").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("chkDeclaration").style.backgroundColor = 'white';
				}
				
				if (confirm("Are you sure you want to submit?") == true)
				{
					return true;
				}
				else
				{
					return false;
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
								<tr id="trBanner" runat="server">
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td vAlign="middle" width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td style="WIDTH: 918px" vAlign="top">&nbsp;&nbsp;
										<h1><A class="link" style="WIDTH: 0%; HEIGHT: 14px" href="CompanyHomePage.aspx">Home</A></h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><TABLE id="Table2" cellSpacing="1" cellPadding="1" width="450" border="0">
											<TR>
												<TD align="left" width="450" colSpan="2"></TD>
											</TR>
											<TR>
												<TD align="center" width="450" colSpan="2"><asp:label id="lblPageHeader" runat="server" CssClass="pageheader">Candidate Hire/Exit</asp:label></TD>
											</TR>
											<TR>
												<TD align="center" width="450" colSpan="2">&nbsp;</TD>
											</TR>
											<TR>
												<TD align="left" width="200"><asp:label id="lblEnterRegId" runat="server" CssClass="label_black_bold">Enter Registration Id</asp:label></TD>
												<TD width="250"><asp:textbox id="txtRegistrationId" runat="server" CssClass="newUserTextbox" MaxLength="15" Width="180px"></asp:textbox>&nbsp;
													<asp:button id="btnSearch" runat="server" CssClass="button" Text="Search" onclick="btnSearch_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD width="200">&nbsp;</TD>
												<TD></TD>
											</TR>
											<TR>
												<td colSpan="2"><asp:panel id="pnlDetails" Runat="server">
														<TABLE id="Table3" cellSpacing="1" cellPadding="3" width="450" border="0">
															<TR>
																<TD width="200">
																	<asp:Label id="Label9" runat="server" CssClass="label_black_bold"> Registration Id</asp:Label></TD>
																<TD width="250">
																	<asp:Label id="lblRegistrationId" runat="server" CssClass="label_black"></asp:Label></TD>
															</TR>
															<TR>
																<TD width="200">
																	<asp:Label id="Label14" runat="server" CssClass="label_black_bold">Name</asp:Label></TD>
																<TD width="250">
																	<asp:Label id="lblName" runat="server" CssClass="label_black"></asp:Label></TD>
															</TR>
															<TR>
																<TD width="200">
																	<asp:Label id="Label15" runat="server" CssClass="label_black_bold">Date of Birth</asp:Label></TD>
																<TD width="250">
																	<asp:Label id="lblDOB" runat="server" CssClass="label_black"></asp:Label></TD>
															</TR>
															<TR>
																<TD width="200">
																	<asp:Label id="Label16" runat="server" CssClass="label_black_bold">Test Date</asp:Label></TD>
																<TD width="250">
																	<asp:Label id="lblTestDate" runat="server" CssClass="label_black"></asp:Label></TD>
															</TR>
															<TR>
																<TD width="200">
																	<asp:Label id="Label17" runat="server" CssClass="label_black_bold">Test Location</asp:Label></TD>
																<TD width="250">
																	<asp:Label id="lblTestLocation" runat="server" CssClass="label_black"></asp:Label></TD>
															</TR>
															<TR>
																<TD width="450" colSpan="2">
																	<asp:checkbox id="chkDeclaration" runat="server" CssClass="small_maroon" Font-Bold="True"></asp:checkbox></TD>
															</TR>
															<TR>
																<TD width="450" colSpan="2">
																	<asp:button id="btnHire" runat="server" CssClass="button" Text="Hire Candidate" onclick="btnHire_Click"></asp:button>
																	<asp:button id="btnExit" runat="server" CssClass="button" Text="Exit Candidate" onclick="btnExit_Click"></asp:button></TD>
															</TR>
														</TABLE>
													</asp:panel></td>
											</TR>
											<TR>
												<TD align="center" width="450" colSpan="2"><asp:label id="lblError" runat="server" CssClass="errorMessage"></asp:label></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr id="trFooter" runat="server">
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
