<%@ Page language="c#" Codebehind="CompanyHomePage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.CompanyHomePage" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CompanyHomePage</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
        <LINK href="../Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<script language="javascript">

		function CloseWindow()

		{
		alert('The window will now exit for security reasons.');
		window.focus();
		window.open('','_self','');
		window.close();

		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			 <div class="outerbody" align="center">		
		
									 <uc2:nac_headerlogo id="Nac_headermenu1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Welcome <asp:Label id="lblCompanyName" runat="server" ></asp:Label> </h2>

										<table width="100%">
											<!--<tr>
												<td colspan="2" align="left"><STRONG><FONT size="2" class="label_black_bold">
															<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Welcome </asp:Label></FONT></STRONG>
													<asp:Label id="lblCompanyName1" runat="server" CssClass="label_black_bold"></asp:Label>
												</td>
											</tr>-->
											<tr>
												<td colspan="2" align="center"><STRONG><FONT size="4">
															<asp:Label id="Label1" runat="server" CssClass="pageheader">My Home Page</asp:Label></FONT></STRONG></td>
											</tr>
											<tr>
												<td colspan="2" align="center">&nbsp;</td>
											</tr>
											<tr>
												<td>
													<asp:LinkButton id="lnkCompanyProfile" runat="server" CssClass="link" Width="127px" onclick="lnkCompanyProfile_Click">My Company Profile</asp:LinkButton></td>
											</tr>
											<tr>
												<td style="HEIGHT: 21px">
													<asp:LinkButton id="lnkChangePassword" runat="server" CssClass="link" Width="141px" onclick="lnkChangePassword_Click">Change/Edit Password</asp:LinkButton></td>
											</tr>
											<tr>
												<td colspan="2" align="left">
													<asp:LinkButton id="lnkCandidateSearch" runat="server" CssClass="link" Width="169px" onclick="lnkCandidateSearch_Click">NAC Candidate Search</asp:LinkButton></td>
											</tr>
											<TR>
												<TD align="left" colSpan="2">
													<asp:LinkButton id="lnkHireExit" runat="server" CssClass="link" Width="169px" Visible="false" onclick="lnkHireExit_Click">Hire Candidate</asp:LinkButton></TD>
											</TR>
											<TR>
												<TD align="left" colSpan="2">
													<asp:LinkButton id="lnkViewHiredCandidates" runat="server" CssClass="link" Visible="false" Width="169px" onclick="lnkViewHiredCandidates_Click">View Hired Candidates</asp:LinkButton></TD>
											</TR>
											<tr>
												<td colspan="2" align="left">
													<asp:LinkButton id="lnkLogOut" runat="server" CssClass="link" Width="51px" onclick="lnkLogOut_Click">Log Out</asp:LinkButton></td>
											</tr>
										</table>

									</div>
                            </div>

                            <div class="footer">  <img src="../Web/Images/footer2014.gif" /></div>
            </div>
		</form>
	</body>
</HTML>
