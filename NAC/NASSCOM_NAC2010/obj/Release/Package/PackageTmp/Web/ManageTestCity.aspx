<%@ Page language="c#" Codebehind="ManageTestCity.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.ManageTestCity" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Manage Test City</title>
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
		var radioButtons = document.getElementsByName("rbtnlstAddEditCity");
		for (var x = 1; x < radioButtons.length; x ++) 
		{		
			if (radioButtons[x].checked)
			{
				if(radioButtons[x].value==0)
				{
					if(document.getElementById('txtCityName').value == 0)
					{
						alert('Enter City Name');
						document.getElementById('txtCityName').focus();
						document.getElementById('txtCityName').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCityName').style.backgroundColor = 'white';
					}
					
					if(document.getElementById('txtCityCode').value == 0)
					{
						alert('Enter City Code');
						document.getElementById('txtCityCode').focus();
						document.getElementById('txtCityCode').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCityCode').style.backgroundColor = 'white';
						return true;
					}	
				}
				else
				{
					if(document.getElementById('ddlTestCity').value == 0)
					{
						alert('Select a City to edit');
						document.getElementById('ddlTestCity').focus();
						document.getElementById('ddlTestCity').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('ddlTestCity').style.backgroundColor = 'white';
					}
					if(document.getElementById('txtCityName').value == 0)
					{
						alert('City Name cannot be blank');
						document.getElementById('txtCityName').focus();
						document.getElementById('txtCityName').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCityName').style.backgroundColor = 'white';
					}
					
					if(document.getElementById('txtCityCode').value == 0)
					{
						alert('City Code cannot be blank');
						document.getElementById('txtCityCode').focus();
						document.getElementById('txtCityCode').style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById('txtCityCode').style.backgroundColor = 'white';
						return true;
					}						
				}
			}
		}
		
	}   
    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmManageTestCity" method="post" runat="server">
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
															<asp:label id="Label4" runat="server" CssClass="pageheader">Manage Test City </asp:label></FONT></STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="3"></TD>
											</TR>
											<TR>
												<TD align="left" width="20%"></TD>
												<TD width="70%" colSpan="2">
													<asp:RadioButtonList id="rbtnlstAddEditCity" runat="server" CssClass="main_black" AutoPostBack="True"
														RepeatDirection="Horizontal" onselectedindexchanged="rbtnlstAddEditCity_SelectedIndexChanged">
														<asp:ListItem Value="0" Selected="True">Add</asp:ListItem>
														<asp:ListItem Value="1">Edit</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<TR class="main_black" id="trEditCity" align="left" runat="server">
												<TD align="left" width="20%"><FONT class="small_maroon">
														<asp:Label id="lblCityToEdit" runat="server" CssClass="main_black">&nbsp;&nbsp;City to Edit&nbsp;:</asp:Label></FONT></TD>
												<TD width="70%" colSpan="2">
													<asp:DropDownList id="ddlTestCity" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCity_SelectedIndexChanged"></asp:DropDownList></TD>
											</TR>
											<TR class="main_black" id="trCityName" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:Label id="Label1" runat="server" CssClass="main_black">&nbsp;&nbsp;City Name&nbsp;:</asp:Label></TD>
												<TD colSpan="2">
													<asp:TextBox id="txtCityName" runat="server" CssClass="txtbox" MaxLength="30"></asp:TextBox>&nbsp;
												</TD>
											</TR>
											<TR class="main_black" id="trCityCode" align="left" runat="server">
												<TD style="WIDTH: 20%" align="left" width="20%">
													<asp:Label id="lblCityCode" runat="server" CssClass="main_black">&nbsp;&nbsp;City Code&nbsp;:</asp:Label></TD>
												<TD colSpan="2">
													<asp:TextBox id="txtCityCode" runat="server" CssClass="txtbox" MaxLength="2"></asp:TextBox></TD>
											</TR>
											<TR align="left">
												<TD class="main_black" style="WIDTH: 20%" align="left" width="20%"></TD>
												<TD>
													<asp:Label id="lblMessage" runat="server" CssClass="errarea"></asp:Label>&nbsp;</TD>
											</TR>
											<TR>
												<TD class="main_black" style="WIDTH: 20%" align="left" width="20%"></TD>
												<TD>
													<asp:Button id="btnSave" Text="Save" Runat="server" onclick="btnSave_Click"></asp:Button>
													<asp:Button id="btnCancel" Text="Cancel" Runat="server" onclick="btnCancel_Click"></asp:Button></TD>
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
