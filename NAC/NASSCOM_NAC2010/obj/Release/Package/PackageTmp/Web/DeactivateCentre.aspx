<%@ Page language="c#" Codebehind="DeactivateCentre.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.CentreManage" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Manage Registration Permissions</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
			function Validatedata()
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
				
				return true;
					
			}
		
		function ValidateDateTime()
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
				 
		  
				strText = document.getElementById("ddlDay").value;
				if(strText == 0)
				{
					alert("Please select test centre closing day");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlDay").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlMonth").value;
				if(strText == 0)
				{
					alert("Please select test centre closing month");
					document.getElementById("ddlMonth").focus();
					document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMonth").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlYear").value;
				if(strText == 0)
				{
					alert("Please select test centre closing year");
					document.getElementById("ddlYear").focus();
					document.getElementById("ddlYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlYear").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlTime").value;
				if(strText == 0)
				{
					alert("Please select test centre closing time");
					document.getElementById("ddlTime").focus();
					document.getElementById("ddlTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTime").style.backgroundColor = 'white';
				}
		}
		
		function ValidateDateTimeStart()
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
				 
		  
				strText = document.getElementById("ddlStartDay").value;
				if(strText == 0)
				{
					alert("Please select test centre starting day");
					document.getElementById("ddlStartDay").focus();
					document.getElementById("ddlStartDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlStartDay").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlStartMonth").value;
				if(strText == 0)
				{
					alert("Please select test centre starting month");
					document.getElementById("ddlStartMonth").focus();
					document.getElementById("ddlStartMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlStartMonth").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlStartYear").value;
				if(strText == 0)
				{
					alert("Please select test centre starting year");
					document.getElementById("ddlStartYear").focus();
					document.getElementById("ddlStartYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlStartYear").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlStartTime").value;
				if(strText == 0)
				{
					alert("Please select test centre starting time");
					document.getElementById("ddlStartTime").focus();
					document.getElementById("ddlStartTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlStartTime").style.backgroundColor = 'white';
				}
		}
		
		function ValidateAOrDStateForETS()
		{
			   var strText;				 
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
		}
			
		function FillHiddenField()
			{
				document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
				document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
				document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;			
			}
		 
		</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="center">
						<ajax:AjaxPanel id="AjaxPanel" runat="server" Height="100%">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR vAlign="top">
													<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Set Registration 
														Permissions</TD>
													<TD class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></TD>
												</TR>
											</TABLE>
										</TD>
					</TD>
				</TR>
				<TR class="white_bg" vAlign="top" align="center">
					<TD align="center"><BR>
						<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
							<TR>
								<TD class="white_bg">
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="650" align="center" border="0">
										<TR class="main_black" align="left">
											<TD class="lightblue_bg" colSpan="3" height="25"><STRONG>Set Registration Permissions</STRONG></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3"></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%">Test State:<FONT class="small_maroon">*</FONT></TD>
											<TD colSpan="2">
												<asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestState_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%">Test City:<FONT class="small_maroon">*</FONT></TD>
											<TD colSpan="2">
												<asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCity_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%">Test Centre:<FONT class="small_maroon">*</FONT></TD>
											<TD colSpan="2">
												<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCentre_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%"><FONT class="small_maroon"></FONT></TD>
											<TD width="40%">
												<asp:CheckBox id="chkDeactivateCentre" runat="server" Text="Deactivate Centre"></asp:CheckBox></TD>
											<TD width="30%">
												<asp:Button id="btnDeactivate" runat="server" Text="GO" onclick="btnDeactivate_Click"></asp:Button></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%"></TD>
											<TD width="40%">
												<asp:CheckBox id="chkActivateCentre" runat="server" Text="Activate Centre"></asp:CheckBox></TD>
											<TD width="30%">
												<asp:Button id="btnActivate" runat="server" Text="GO" onclick="btnActivate_Click"></asp:Button></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%"></TD>
											<TD width="40%">
												<asp:CheckBox id="chkDeactivateStateForETS" runat="server" Text="Deactivate State For ETS"></asp:CheckBox></TD>
											<TD width="30%">
												<asp:Button id="btnDeactivateStateForETS" runat="server" Text="GO" onclick="btnDeactivateStateForETS_Click"></asp:Button></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%"></TD>
											<TD width="40%">
												<asp:CheckBox id="chkActivateStateForETS" runat="server" Text="Activate State For ETS"></asp:CheckBox></TD>
											<TD width="30%">
												<asp:Button id="btnActivateStateForETS" runat="server" Text="GO" onclick="btnActivateStateForETS_Click"></asp:Button></TD>
										</TR>
										<TR>
											<TD colSpan="3"></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD align="right" width="30%">Registration Closing datetime:
											</TD>
											<TD width="42%">
												<asp:dropdownlist id="ddlDay" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlMonth" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlYear" CssClass="txtarea" Runat="server" BackColor="White" Width="50px">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlTime" CssClass="txtarea" Runat="server" BackColor="White" Width="60px">
													<asp:ListItem Value="0" Selected="True">Time</asp:ListItem>
													<asp:ListItem Value="01">1 A.M</asp:ListItem>
													<asp:ListItem Value="02">2 A.M</asp:ListItem>
													<asp:ListItem Value="03">3 A.M</asp:ListItem>
													<asp:ListItem Value="04">4 A.M</asp:ListItem>
													<asp:ListItem Value="05">5 A.M</asp:ListItem>
													<asp:ListItem Value="06">6 A.M</asp:ListItem>
													<asp:ListItem Value="07">7 A.M</asp:ListItem>
													<asp:ListItem Value="08">8 A.M</asp:ListItem>
													<asp:ListItem Value="09">9 A.M</asp:ListItem>
													<asp:ListItem Value="10">10 A.M</asp:ListItem>
													<asp:ListItem Value="11">11 A.M</asp:ListItem>
													<asp:ListItem Value="12">12 P.M</asp:ListItem>
													<asp:ListItem Value="13">1 P.M</asp:ListItem>
													<asp:ListItem Value="14">2 P.M</asp:ListItem>
													<asp:ListItem Value="15">3 P.M</asp:ListItem>
													<asp:ListItem Value="16">4 P.M</asp:ListItem>
													<asp:ListItem Value="17">5 P.M</asp:ListItem>
													<asp:ListItem Value="18">6 P.M</asp:ListItem>
													<asp:ListItem Value="19">7 P.M</asp:ListItem>
													<asp:ListItem Value="20">8 P.M</asp:ListItem>
													<asp:ListItem Value="21">9 P.M</asp:ListItem>
													<asp:ListItem Value="22">10 P.M</asp:ListItem>
													<asp:ListItem Value="23">11 P.M</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD width="30%">
												<asp:Button id="btnSubmit" runat="server" Text="GO" onclick="btnSubmit_Click"></asp:Button></TD>
										</TR>
										<TR>
											<TD colSpan="3" width="100%"></TD>
										</TR>
										<TR class="main_black" width="100%">
											<TD align="right" width="30%">Registration Start datetime:
											</TD>
											<TD width="42%">
												<asp:dropdownlist id="ddlStartDay" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
													<asp:ListItem Value="01">01</asp:ListItem>
													<asp:ListItem Value="02">02</asp:ListItem>
													<asp:ListItem Value="03">03</asp:ListItem>
													<asp:ListItem Value="04">04</asp:ListItem>
													<asp:ListItem Value="05">05</asp:ListItem>
													<asp:ListItem Value="06">06</asp:ListItem>
													<asp:ListItem Value="07">07</asp:ListItem>
													<asp:ListItem Value="08">08</asp:ListItem>
													<asp:ListItem Value="09">09</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12</asp:ListItem>
													<asp:ListItem Value="13">13</asp:ListItem>
													<asp:ListItem Value="14">14</asp:ListItem>
													<asp:ListItem Value="15">15</asp:ListItem>
													<asp:ListItem Value="16">16</asp:ListItem>
													<asp:ListItem Value="17">17</asp:ListItem>
													<asp:ListItem Value="18">18</asp:ListItem>
													<asp:ListItem Value="19">19</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="21">21</asp:ListItem>
													<asp:ListItem Value="22">22</asp:ListItem>
													<asp:ListItem Value="23">23</asp:ListItem>
													<asp:ListItem Value="24">24</asp:ListItem>
													<asp:ListItem Value="25">25</asp:ListItem>
													<asp:ListItem Value="26">26</asp:ListItem>
													<asp:ListItem Value="27">27</asp:ListItem>
													<asp:ListItem Value="28">28</asp:ListItem>
													<asp:ListItem Value="29">29</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
													<asp:ListItem Value="31">31</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlStartMonth" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
													<asp:ListItem Value="01">January</asp:ListItem>
													<asp:ListItem Value="02">February</asp:ListItem>
													<asp:ListItem Value="03">March</asp:ListItem>
													<asp:ListItem Value="04">April</asp:ListItem>
													<asp:ListItem Value="05">May</asp:ListItem>
													<asp:ListItem Value="06">June</asp:ListItem>
													<asp:ListItem Value="07">July</asp:ListItem>
													<asp:ListItem Value="08">August</asp:ListItem>
													<asp:ListItem Value="09">September</asp:ListItem>
													<asp:ListItem Value="10">October</asp:ListItem>
													<asp:ListItem Value="11">November</asp:ListItem>
													<asp:ListItem Value="12">December</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlStartYear" CssClass="txtarea" Runat="server" BackColor="White" Width="50px">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlStartTime" CssClass="txtarea" Runat="server" BackColor="White" Width="60px">
													<asp:ListItem Value="0" Selected="True">Time</asp:ListItem>
													<asp:ListItem Value="01">1 A.M</asp:ListItem>
													<asp:ListItem Value="02">2 A.M</asp:ListItem>
													<asp:ListItem Value="03">3 A.M</asp:ListItem>
													<asp:ListItem Value="04">4 A.M</asp:ListItem>
													<asp:ListItem Value="05">5 A.M</asp:ListItem>
													<asp:ListItem Value="06">6 A.M</asp:ListItem>
													<asp:ListItem Value="07">7 A.M</asp:ListItem>
													<asp:ListItem Value="08">8 A.M</asp:ListItem>
													<asp:ListItem Value="09">9 A.M</asp:ListItem>
													<asp:ListItem Value="10">10 A.M</asp:ListItem>
													<asp:ListItem Value="11">11 A.M</asp:ListItem>
													<asp:ListItem Value="12">12 P.M</asp:ListItem>
													<asp:ListItem Value="13">1 P.M</asp:ListItem>
													<asp:ListItem Value="14">2 P.M</asp:ListItem>
													<asp:ListItem Value="15">3 P.M</asp:ListItem>
													<asp:ListItem Value="16">4 P.M</asp:ListItem>
													<asp:ListItem Value="17">5 P.M</asp:ListItem>
													<asp:ListItem Value="18">6 P.M</asp:ListItem>
													<asp:ListItem Value="19">7 P.M</asp:ListItem>
													<asp:ListItem Value="20">8 P.M</asp:ListItem>
													<asp:ListItem Value="21">9 P.M</asp:ListItem>
													<asp:ListItem Value="22">10 P.M</asp:ListItem>
													<asp:ListItem Value="23">11 P.M</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD width="30%">
												<asp:Button id="btnSubmitStart" runat="server" Text="GO" onclick="btnSubmitStart_Click"></asp:Button></TD>
										</TR>
										<TR>
											<TD width="30%">&nbsp;</TD>
											<TD width="70%" colSpan="2">
												<asp:Label id="lblMessage" runat="server" CssClass="errarea"></asp:Label></TD>
										</TR>
										<TR class="main_black" align="center">
											<TD width="30%">&nbsp;</TD>
											<TD align="left" width="70%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<asp:datagrid id="dgCentreStatus" runat="server" CssClass="main_black" BackColor="White" Width="100%"
													GridLines="Vertical" CellPadding="3" OnItemCreated="dgCentreStatus_ItemCreated" OnItemCommand="dgCentreStatus_ItemCommand"
													OnItemDataBound="dgCentreStatus_ItemDataBound" OnPageIndexChanged="dgCentreStatus_PageIndexChanged"
													BorderWidth="1px" BorderStyle="None" BorderColor="#999999" AutoGenerateColumns="False" OnSortCommand="dgCentreStatus_SortCommand"
													ShowFooter="True" AllowSorting="False" Height="100%">
													<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
													<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
													<FooterStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderStyle-Width="500px" ItemStyle-HorizontalAlign="Left" DataField="Centre" HeaderText="Centre"></asp:BoundColumn>
														<asp:BoundColumn HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left" DataField="IsActive"
															HeaderText="Centre Status"></asp:BoundColumn>
														<asp:BoundColumn HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Left" DataField="ETSAccess"
															HeaderText="Access For ETS"></asp:BoundColumn>
													</Columns>
												</asp:datagrid>
											</TD>
										</TR>
										<TR>
											<TD colSpan="3" align="center"><asp:Label ID="lblCentreStatusMessage" CssClass="errarea" Runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD align="left" colSpan="2"></TD>
										</TR>
									</TABLE>
									<INPUT id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server"><INPUT id="hdCity" type="hidden" value="0" name="hdCity" runat="server"><INPUT id="hdState" type="hidden" value="0" name="hdState" runat="server">
								</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
				</TR>
			</TABLE>
			</ajax:AjaxPanel></TD>
			<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
			</TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
				<TD vAlign="bottom" align="center">
					<uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR>
			</TBODY></TABLE>
		</FORM>
	</body>
</HTML>
