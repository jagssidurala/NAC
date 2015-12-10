<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationWindowExtension.aspx.cs" Inherits="NASSCOM_NAC.Web.RegistrationWindowExtension" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Window Extension</title>
    	<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
        <SCRIPT language="javascript" src="js/datetimepicker_css.js"></SCRIPT>
        <script language="javascript" type="text/javascript"></Script>
        <script>

            function ValidateData() {
                var strText;
                //Validate Search Text
                strText = document.getElementById("ddlEventName").value;
                if (strText == "0") {
                    alert("Please select event code/name to be searched.");
                    document.getElementById("ddlEventName").focus();
                    document.getElementById("ddlEventName").style.backgroundColor = 'yellow';
                    return false;
                }
                else {
                    document.getElementById("ddlEventName").style.backgroundColor = 'white';

                }
                strText = document.getElementById("txtNewRegistrationEndDate").value;

                if (strText == "") {
                    alert("Please enter new registration end date.");
                    document.getElementById("txtNewRegistrationEndDate").focus();
                    document.getElementById("txtNewRegistrationEndDate").style.backgroundColor = 'yellow';
                    return false;
                }
                else {
                    document.getElementById("txtNewRegistrationEndDate").style.backgroundColor = 'white';

                }
                return true;
            }	   
		    	 
 
		</script>
</head>
<body MS_POSITIONING="GridLayout">
    	<form id="frmHome" method="post" runat="server">
			<INPUT id="hdnSearchCriteria" type="hidden" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td style="WIDTH: 918px" vAlign="top">&nbsp;&nbsp;<A class="link" style="WIDTH: 0%; HEIGHT: 14px" href="Welcome.aspx">Home</A>
										<h1>&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td vAlign="top">
										<h1>&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<table width="100%">
											<tr>
												<td class="pageheader" align="center"><FONT size="4"><STRONG>Registration Window 
                                                    Extension</STRONG></FONT>
												</td>
											</tr>
											<TR>
												<TD vAlign="middle" align="center">
                                                    &nbsp;</TD>
											</TR>
											<tr>
												<td align="center" colSpan="1" rowSpan="1">
															<table cellSpacing="1" cellPadding="5" width="100%" border="1">
																<tr>
																	<td vAlign="top" align="left" height="147">
																		<table cellSpacing="0" cellPadding="4" width="100%" border="0">
																			<tr>
																				<td class="main_black" vAlign="top" align="left" width="46%">
                                                                                    <asp:Label ID="lblEventName" runat="server" Height="17px" Text="Event Name:"></asp:Label>
                                                                                </td>
																				<td vAlign="top" align="left" width="54%" class="main_black">
                                                                                    <asp:dropdownlist id="ddlEventName" runat="server" CssClass="txtbox" 
                                                                                        Height="17px" Width="150px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="ddlEventName_SelectedIndexChanged">
																					
																				</asp:dropdownlist>
                                                                                </td>
																			</tr>
																			<tr>
																				<td class="main_black" vAlign="top" align="left" width="46%">
                                                                                    <asp:Label ID="lblTestCentre" runat="server" Text="Test Centre:"></asp:Label>
                                                                                </td>
																				<td vAlign="top" align="left" width="54%" class="main_black">
                                                                                    <asp:textbox id="txtTestCentre" runat="server" 
                                                                                        CssClass="txtbox" MaxLength="100" Width="134px" Height="17px" 
                                                                                        ReadOnly="True"></asp:textbox>
                                                                                </td>
																			</tr>
																			<tr>
																				<td class="main_black" vAlign="top" align="left">
                                                                                    <asp:Label ID="lblTestDate" runat="server" Height="17px" Text="Test Date:"></asp:Label>
                                                                                </td>
																				<td vAlign="top" align="left" class="main_black">
                                                                                    <asp:textbox id="txtTestDate" runat="server" 
                                                                                        CssClass="txtbox" MaxLength="100" Width="134px" Height="17px" 
                                                                                        ReadOnly="True"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="main_black" vAlign="top" align="left">
                                                                                    <asp:Label ID="lblRegistrationEndDate" runat="server" Height="17px" 
                                                                                        Text="Existing Registration End Date:"></asp:Label>
                                                                                </td>
																				<td vAlign="top" align="left" class="main_black">
                                                                                    <asp:textbox id="txtRegistrationEndDate" 
                                                                                        runat="server" CssClass="txtbox" MaxLength="100" Height="17px" 
                                                                                        Width="134px" ReadOnly="True"></asp:textbox></td>
																			</tr>
																			<tr>
																				<td class="main_black" vAlign="top" align="left"><asp:Label 
                                                                                        ID="lblNewRegistrationEndDate" runat="server" Height="17px" 
                                                                                        Text="New Registration End Date:"></asp:Label>
                                                                                </td>
																				<td vAlign="top" align="left" class="main_black">
                                                                                    <asp:TextBox id="txtNewRegistrationEndDate" 
                                                                                        runat="server" MaxLength="100" ReadOnly="True"></asp:TextBox><IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtNewRegistrationEndDate','MMddyyyy','arrow',true,'24')"
														                            src="images/cal.gif">&nbsp;</td>
																			</tr>
																			<tr>
																				<td class="main_black">&nbsp;</td>
																				<td class="main_black">
                                                                                    <asp:button id="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" 
                                                                                        ></asp:button></td>
																			</tr>
																			<tr>
																				<td class="main_black" colSpan="2">
																					<asp:label id="lblMsg" runat="server" ForeColor="Red" Font-Size="XX-Small" Font-Bold="True"></asp:label></td>
																			</tr>
																			</table>
																	</td>
																</tr>
															</table>
														</td>
											</table>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../WEB/Images/footerDB.jpg"><A href="mailto:nac@mail.nasscom.in"></A></DIV>
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
</html>
