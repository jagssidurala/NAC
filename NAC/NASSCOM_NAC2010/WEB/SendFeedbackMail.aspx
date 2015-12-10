<%@ Page language="c#" Codebehind="SendFeedbackMail.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.SendFeedbackMail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SendFeedbackMail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="Stylesheet/nasscomNew.css" type="text/css" media="screen">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">

		function ValidateData() 
			{ 
				var strText;
			    
			    //Validate Type dropdown			    
			    strText = document.getElementById("ddlType").value;
			    if(strText == 0)
			    {
					alert("Please select a program name.");
					document.getElementById("ddlType").focus();
					document.getElementById("ddlType").style.backgroundColor = 'yellow';
					return false;
			    }
			    else
			    {
					document.getElementById("ddlType").style.backgroundColor = 'white';
			    }  
			      
				//Validate Email
				strText = document.getElementById("txtEmail").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter your Email ID.");
					document.getElementById("txtEmail").focus();
					document.getElementById("txtEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else if(!emailCheck(strText))
				{
					alert("Please enter valid Email ID.");
					document.getElementById("txtEmail").focus();
					document.getElementById("txtEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtEmail").style.backgroundColor = 'white';
				}
				
				//Validate comments
				strText = document.getElementById("txtComments").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter your Comments/feedback.");
					document.getElementById("txtComments").focus();
					document.getElementById("txtComments").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtComments").style.backgroundColor = 'white';
				}
				return true;
			} 
		</script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ShowHideType();">
		<form runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td style="WIDTH: 886px">
							<table id="Table_01" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD style="WIDTH: 64px"></TD>
									<TD vAlign="top" align="left"></TD>
									<TD width="1" style="WIDTH: 1px">&nbsp;</TD>
								</TR>
								<tr>
									<td rowSpan="9" style="WIDTH: 64px">&nbsp;</td>
									<td vAlign="top" align="left"><img id="imgBanner" src="Images/BannerLine.jpg" width="55%" alt="">
									</td>
									<td width="1" rowSpan="9" style="WIDTH: 1px">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top"></td>
								</tr>
								<tr>
									<td vAlign="top">
										<table align="left" width="50%">
											<TBODY>
												<tr>
													<td colspan="2">&nbsp;</td>
												</tr>
												<tr>
													<td colSpan="2" class="pageHeader">Please fill the desired details</td>
												</tr>
												<TR>
													<TD colSpan="2"></TD>
												<tr>
													<td class="textNormal">Program Name:
													</td>
													<td><asp:dropdownlist id="ddlType" runat="server">
															<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
															<asp:ListItem Value="1">NAC</asp:ListItem>
															<asp:ListItem Value="2">NAC-Tech</asp:ListItem>
														</asp:dropdownlist></td>
												</tr>
												<tr>
													<td class="textNormal">Your Email:
													</td>
													<td><asp:textbox id="txtEmail" runat="server" MaxLength="50" Width="344px"></asp:textbox></td>
												</tr>
												<tr>
													<td class="textNormal" valign="top">
													Comments/Query:
													<td><asp:textbox id="txtComments" runat="server" Width="344px" Height="144px" TextMode="MultiLine"></asp:textbox></td>
												</tr>
												<tr>
													<td colSpan="2"></td>
												</tr>
												<tr>
													<td align="center" colSpan="2">
														<asp:button id="btnCancel" runat="server" CssClass="button" Text="Cancel" onclick="btnCancel_Click"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnSave" runat="server" Text="Submit" CssClass="button" onclick="btnSave_Click"></asp:button></td>
												</tr>
								</tr>
								</TBODY>
							</table>
						</td>
					</tr>
					<tr>
						<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
					</tr>
					<tr>
						<td vAlign="top" align="center">
							<DIV class="landingFooter">
								<DIV class="divLeft">&nbsp;</DIV>
								<!--<DIV class="divRight"><IMG src="Images/login_07.jpg"></DIV>-->
							</DIV>
						</td>
					</tr>
				</table>
				</td></tr></table></div>
		</form>
	</body>
</HTML>
