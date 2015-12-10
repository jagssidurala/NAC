<%@ Page language="c#" Codebehind="CompanyProfile.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.CompanyProfile" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
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
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
         <link href="../Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			   <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headermenu1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Company Profile </h2>

									<TABLE  width="100%" align="center">
											<TR>
												<TD align="center" colspan="2" width="50%"><STRONG><FONT size="4">
															<asp:Label id="Label8" runat="server" CssClass="pageheader"></asp:Label></FONT></STRONG></TD>
											</TR>
											<TR>
												<TD colspan="2">&nbsp;</TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label1" runat="server" CssClass="label_black_bold">Company Name</asp:Label></TD>
												<TD>
													<asp:Label id="lblCompanyName" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Company Address</asp:Label></TD>
												<TD>
													<asp:Label id="lblCompanyAddress" runat="server" CssClass="label_black" Width="100%"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label3" runat="server" CssClass="label_black_bold">Official Phone Number</asp:Label></TD>
												<TD>
													<asp:Label id="lblOfficialPhone" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label4" runat="server" CssClass="label_black_bold">Company SPOC for NAC</asp:Label></TD>
												<TD>
													<asp:Label id="lblSPOCName" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label5" runat="server" CssClass="label_black_bold">Company SPOC's Phone Number</asp:Label></TD>
												<TD>
													<asp:Label id="lblSPOCPhone" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label6" runat="server" CssClass="label_black_bold">Company SPOC's emailID</asp:Label></TD>
												<TD>
													<asp:Label id="lblSPOCEmail" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label7" runat="server" CssClass="label_black_bold">Agreement Expiry Date</asp:Label></TD>
												<TD>
													<asp:Label id="lblExpiryDate" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR id="trLogin" runat="server">
												<TD width="50%">
													<asp:Label id="lblLoginId" runat="server" CssClass="label_black_bold">Login ID</asp:Label></TD>
												<TD>
													<asp:Label id="lblLoginIdValue" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<TR id="trPassword" runat="server">
												<TD width="50%">
													<asp:Label id="lblPassword" runat="server" CssClass="label_black_bold">Password (Encrypted)</asp:Label></TD>
												<TD>
													<asp:Label id="lblPasswordValue" runat="server" CssClass="label_black"></asp:Label></TD>
											</TR>
											<tr>
												<td colspan="2">&nbsp;</td>
											</tr>
											<TR>
												<TD colspan="2" style="HEIGHT: 8px; COLOR: maroon; FONT-SIZE: medium" vAlign="top" align="center">
													<asp:Label CssClass="label_black_bold" id="lblNote" runat="server">
														Should there be a change in the company 
																profile details, an email should be sent to NASSCOM @ <A style="COLOR: maroon" href="mailto:nacdb@mail.nasscom.in">
															nacdb@mail.nasscom.in</A></asp:Label></EM></FONT></TD>
											</TR>
											<TR>
												<TD align="center" colspan="2">
													<asp:Button id="btnBack" runat="server" Text="Back" CssClass="btn2" 
                                                        onclick="btnBack_Click"></asp:Button>
													<asp:Button id="btnClose" runat="server" CssClass="btn2" Text="Close" 
                                                        Visible="False" onclick="btnClose_Click"></asp:Button></TD>
											</TR>
										</TABLE>
									
               </div>
                        </div>           

               <div class="footer">  <img src="../Web/Images/footer2014.gif" />
               
               </div>

            </div>

                               


		</form>
	</body>
</HTML>
