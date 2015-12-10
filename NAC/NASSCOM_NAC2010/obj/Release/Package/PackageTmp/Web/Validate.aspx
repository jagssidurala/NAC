<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="Validate.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Validate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Forgot Password</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="JS/Common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		function ValidateData()
		{
			if (document.frmValidatePassword.ddlPhotoIdDocument.value==0)
			{
				alert("Please select a valid photo id");
				document.frmValidatePassword.ddlPhotoIdDocument.focus();
				return false;
			}			
			if (Trim(document.frmValidatePassword.txtPhotoNumber.value)=="")
			{
				alert("Please enter photo number");
				document.frmValidatePassword.txtPhotoNumber.focus();
				return false;
			}			
		}
		
		function SendPwdByEmail(ev)
		{
		    document.getElementById("lblPassword").innerHTML="";
		   // document.getElementById("trFirst").style.display = "";
		   // document.getElementById("trSecond").style.display = "";
		     
		}
		
		function DisplayPwdOnScreen(ev)
		{
		   document.getElementById("lblPassword").innerHTML="";
		  // document.getElementById("trFirst").style.display = "none";
		  // document.getElementById("trSecond").style.display = "none";
		}		
		 
		</script>
	</HEAD>
	<body>
		<FORM id="frmValidatePassword" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td class="white_bg" vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Forgot Password</td>
											<td class="header1" id="HomeLink" vAlign="middle" align="right" runat="server"><A class="header1" href="../Default.aspx">Home&nbsp;&nbsp;&nbsp;</A>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr vAlign="top" align="center">
								<td class="white_bg" align="center"><br>
									<table class="lightblue_bg" id="Table4" cellSpacing="1" cellPadding="0" width="85%" border="0">
										<tr>
											<td class="white_bg">
												<table id="Table4" cellSpacing="0" cellPadding="3" width="100%" border="0">
													<tr class="main_black" vAlign="top" align="left">
														<td class="lightblue_bg" colSpan="3"><strong>Registration ID:
																<asp:label id="lblUserID" runat="server">07002020</asp:label></strong></td>
													</tr>
													<tr class="main_black" vAlign="top" align="left">
														<td>Photo ID Document:<FONT class="small_maroon">*</FONT></td>
														<td><asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" CssClass="txtarea">
																<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																<asp:ListItem Value="Driving License">Driving License</asp:ListItem>
																<asp:ListItem Value="Passport">Passport</asp:ListItem>
																<asp:ListItem Value="PAN">PAN</asp:ListItem>
																<asp:ListItem Value="Voter ID">Voter ID</asp:ListItem>
																<asp:ListItem Value="College I-Card">College I-Card</asp:ListItem>
															</asp:dropdownlist></td>
														<td class="small_maroon"></td>
													</tr>
													<TR>
														<TD></TD>
														<TD class="small_maroon"></TD>
														<TD></TD>
													</TR>
													<tr class="main_black" vAlign="top" align="left">
														<td>Photo ID Number:<FONT class="small_maroon">*</FONT></td>
														<td><asp:textbox id="txtPhotoNumber" runat="server" CssClass="txtbox" Width="200px"></asp:textbox></td>
														<td class="small_maroon"></td>
													</tr>
													<TR>
														<TD></TD>
														<TD></TD>
														<TD class="small_maroon"></TD>
													</TR>													
													<TR class="main_black" vAlign="top" align="left">
														<TD colSpan="3"><INPUT id="optSent" onclick="SendPwdByEmail(this);" type="radio" CHECKED value="Radio1"
																name="RadioGroup" runat="server">Send password via email&nbsp; <INPUT id="optDisplay" onclick="DisplayPwdOnScreen(this);" type="radio" value="Radio2"
																name="RadioGroup" runat="server">&nbsp;Display password on screen</TD>
													</TR>
													<tr class="main_black" vAlign="top" align="center">
														<td colSpan="3"><asp:button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
													</tr>
													<tr class="main_black" vAlign="top" align="center">
														<td colSpan="3"><asp:label id="lblPassword" Runat="server" CssClass="errarea" Text=""></asp:label><input id="hdMailSend" type="hidden" value="0" runat="server" NAME="hdMailSend"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD class="white_bg" vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
