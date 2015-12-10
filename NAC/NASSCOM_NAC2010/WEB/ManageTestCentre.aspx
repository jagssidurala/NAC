<%@ Page language="c#" Codebehind="ManageTestCentre.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.ManageTestCentre" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<HTML>
	<HEAD>
		<title>Manage Test Centre</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta http-equiv="pragma" content="no-cache">
		<meta http-equiv="cache-control" content="no-cache">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<SCRIPT language="javascript" src="js/datetimepicker_css.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
		function ValidateData()
		{
		var radioButtons = document.getElementsByName("rbtnlstAddEditCentre");
		for (var x = 1; x < radioButtons.length; x ++) 
		{		
			if (radioButtons[x].checked)
			{
				if(radioButtons[x].value==0)
				{
					if(document.getElementById('txtCentreName').value == 0)
					{
						alert('Enter Centre Name');
						document.getElementById('txtCentreName').focus();
						document.getElementById('txtCentreName').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreName').style.backgroundColor = 'white';
					}
					
					if(document.getElementById('txtCentreCapacity').value == 0)
					{
						alert('Enter Centre Capacity');
						document.getElementById('txtCentreCapacity').focus();
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'yellow';
						return false;
					}
					else if(!IsNumeric(document.getElementById('txtCentreCapacity').value))
					{
						alert('Enter Numeric value only');
						document.getElementById('txtCentreCapacity').value = "";
						document.getElementById('txtCentreCapacity').focus();
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'white';
					}	
					
					if(document.getElementById('txtCentreCode').value == 0)
					{
						alert('Enter Centre Code');
						document.getElementById('txtCentreCode').focus();
						document.getElementById('txtCentreCode').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreCode').style.backgroundColor = 'white';
					}	
					
					
					if(document.getElementById('txtCentreAddress').value == 0)
					{
						alert('Enter Centre Address');
						document.getElementById('txtCentreAddress').focus();
						document.getElementById('txtCentreAddress').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreAddress').style.backgroundColor = 'white';
						return true;
					}	
				}
				else
				{
					if(document.getElementById('ddlTestCentre').value == 0)
					{
						alert('Select a Centre to edit');
						document.getElementById('ddlTestCentre').focus();
						document.getElementById('ddlTestCentre').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('ddlTestCentre').style.backgroundColor = 'white';
					}
					if(document.getElementById('txtCentreName').value == 0)
					{
						alert('Enter Centre Name');
						document.getElementById('txtCentreName').focus();
						document.getElementById('txtCentreName').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreName').style.backgroundColor = 'white';
					}
					
					if(document.getElementById('txtCentreCapacity').value == 0)
					{
						alert('Enter Centre Capacity');
						document.getElementById('txtCentreCapacity').focus();
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'yellow';
						return false;
					}
					else if(!IsNumeric(document.getElementById('txtCentreCapacity').value))
					{
						alert('Enter Numeric value only');
						document.getElementById('txtCentreCapacity').value="";
						document.getElementById('txtCentreCapacity').focus();
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreCapacity').style.backgroundColor = 'white';
					}	
					
					if(document.getElementById('txtCentreCode').value == 0)
					{
						alert('Enter Centre Code');
						document.getElementById('txtCentreCode').focus();
						document.getElementById('txtCentreCode').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreCode').style.backgroundColor = 'white';
					}					
					
					if(document.getElementById('txtCentreAddress').value == 0)
					{
						alert('Enter Centre Address');
						document.getElementById('txtCentreAddress').focus();
						document.getElementById('txtCentreAddress').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCentreAddress').style.backgroundColor = 'white';
						return true;
					}		
				}
			}
		}
	}   
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">&nbsp;&nbsp;
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<TABLE id="Table4" cellSpacing="2" cellPadding="2" width="650" align="center" border="0">
											<TR>
												<TD align="center" colSpan="3"><STRONG><FONT size="4">
															<asp:label id="Label4" runat="server" CssClass="pageheader">Manage Test Centre </asp:label></FONT></STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="3"></TD>
											</TR>
											<TR>
												<TD align="left" width="20%"></TD>
												<TD width="70%" colSpan="2">
													<asp:radiobuttonlist id="rbtnlstAddEditCentre" runat="server" CssClass="main_black" RepeatDirection="Horizontal"
														AutoPostBack="True" onselectedindexchanged="rbtnlstAddEditCentre_SelectedIndexChanged">
														<asp:ListItem Value="0" Selected="True">Add</asp:ListItem>
														<asp:ListItem Value="1">Edit</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR id="trEditCentre" class="main_black" align="left" runat="server">
												<TD align="left" width="20%"><FONT class="small_maroon">
														<asp:label id="lblCentreToEdit" runat="server" CssClass="main_black">&nbsp;&nbsp;Centre to Edit&nbsp;:</asp:label></FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCentre_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR id="trCentreName" class="main_black" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:label id="Label1" runat="server" CssClass="main_black">&nbsp;&nbsp;Centre Name&nbsp;:</asp:label></TD>
												<TD colSpan="2">
													<asp:textbox id="txtCentreName" runat="server" CssClass="txtbox" MaxLength="30"></asp:textbox>
												</TD>
											</TR>
											<TR id="trCentreCapacity" class="main_black" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:label id="lblCentreCapacity" runat="server" CssClass="main_black">&nbsp;&nbsp;Centre Capacity&nbsp;:</asp:label></TD>
												<TD colSpan="2">
													<asp:textbox id="txtCentreCapacity" runat="server" CssClass="txtbox" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR id="trCentreCode" class="main_black" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:label id="lblCentreCode" runat="server" CssClass="main_black">&nbsp;&nbsp;Centre Code&nbsp;:</asp:label></TD>
												<TD colSpan="2">
													<asp:textbox id="txtCentreCode" runat="server" CssClass="txtbox" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR id="trCentreAddress" class="main_black" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:label id="Label2" runat="server" CssClass="main_black">&nbsp;&nbsp;Centre Address&nbsp;:</asp:label></TD>
												<TD colSpan="2">
													<asp:textbox id="txtCentreAddress" runat="server" CssClass="txtbox_MultiLine" MaxLength="500"
														Height="50px" TextMode="MultiLine" Rows="3"></asp:textbox></TD>
											</TR>
											<TR align="left">
												<TD class="main_black" style="WIDTH: 20%" align="left" width="20%"></TD>
												<TD>
													<asp:Label id="lblMessage" runat="server" CssClass="errarea"></asp:Label>&nbsp;</TD>
											</TR>
											<TR>
												<TD class="main_black" style="WIDTH: 20%" align="left" width="20%"></TD>
												<TD>
													<asp:button id="btnSave" Runat="server" Text="Save" onclick="btnSave_Click"></asp:button>&nbsp;
													<asp:button id="btnCancel" Runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
											</TR> <!--	<TR id="Tr1" runat="server">
												<TD style="WIDTH: 263px" align="left" width="263">&nbsp;</TD>
												<TD class="main_black" width="30%">Shift DateTime:<FONT class="small_maroon">*</FONT>
													<asp:TextBox id="Textbox4" runat="server" Width="120px" ReadOnly="true" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('Textbox4','MMddyyyy','arrow',true,'24')"
														src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
													<asp:TextBox id="Textbox3" runat="server" Width="50px" MaxLength="3"></asp:TextBox></TD>
											</TR> -->
											<TR class="main_black" align="left">
												<TD style="WIDTH: 20%">&nbsp;</TD>
												<TD width="70%"></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
                                          <tr><td valign="top" align="center">
                                        <uc1:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc1:nacyearlyfooter> 
									    </td></tr>
											<%--<DIV class="divLeft"><IMG src="../WEB/Images/footerDB.jpg"><A href="mailto:nac@nasscom.in"></A></DIV>--%>
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
