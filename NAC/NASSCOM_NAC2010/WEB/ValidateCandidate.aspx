<%@ Page language="c#" Codebehind="ValidateCandidate.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.ValidateCandidate" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
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
		<script language="JavaScript" type="text/JavaScript">
		</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center" class="white_bg">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td>
									<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr align="left" valign="top" class="blue_bg">
								<td valign="middle" class="header1">
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr valign="top">
											<td align="left" valign="middle" class="header1">
												&nbsp;&nbsp;Validate Candidate</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr vAlign="top" align="center">
								<td align="center" class="white_bg"><br>
									<table width="85%" class="lightblue_bg" border="0" cellspacing="1" cellpadding="0" ID="Table4">
										<tr>
											<td class="white_bg">
												<table width="100%" border="0" cellspacing="0" cellpadding="3" ID="Table4">
													<tr align="left" valign="top" class="main_black">
														<td colspan="3" height="25" class="lightblue_bg"><strong> Registration Id:
																<asp:Label id="Label1" runat="server">07002020</asp:Label></strong></td>
													</tr>
													<tr align="left" valign="top" class="main_black">
														<td>Photo Id Document:<FONT class="small_maroon">*</FONT></td>
														
														<td><select name="select9" class="txtarea" ID="Select9">
																<option selected>Select</option>
																<option>Driving License</option>
																<option>Passport</option>
																<option>PAN</option>
																<option>Voter ID</option>
																<option>College I-Card</option>
															</select>
														</td>
														<td class="small_maroon"></td>
													</tr>
													<TR>
														<TD></TD>
														<TD class="small_maroon"></TD>
														<TD></TD>
													</TR>
													<tr align="left" valign="top" class="main_black">
														<td>Photo Id Number:<FONT class="small_maroon">*</FONT></td>
														
														<td><INPUT class="txtbox" id="Text4" type="text" size="35" name="textfield2"></td>
														<td class="small_maroon">&nbsp;</td>
													</tr>
													<TR>
														<TD></TD>
														<TD class="small_maroon"></TD>
														<TD></TD>
													</TR>
													<TR align="left" valign="top" class="main_black">
														<TD colspan="3"><INPUT type="radio">Sent password via email&nbsp; <INPUT type="radio">&nbsp;Display 
															password on screen</TD>
													</TR>
													<tr align="center" valign="top" class="main_black">
														<td colspan="3"><input type="submit" name="Submit" value="Submit" ID="Submit1"></td>
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
					<TD vAlign="bottom" class="white_bg" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
