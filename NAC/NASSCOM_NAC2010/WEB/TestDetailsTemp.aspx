<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="TestDetailsTemp.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.TestDetailsTemp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Test and ShiftTime Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		function FillHiddenField()
			{
				document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
				document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;			
			}	
			
			function ValidateTestData()
			{			
			
			     var strText;			  
				strText = document.getElementById("txtTestName").value;											
				if (Trim(strText) == "")
				{
					alert("Please enter Test Name");
					document.getElementById("txtTestName").focus();
					document.getElementById("txtTestName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtTestName").style.backgroundColor = 'white';
				}				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtTestName").focus();
					document.getElementById("txtTestName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtTestName").style.backgroundColor = 'white';
				}

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtTestName").focus();
					document.getElementById("txtTestName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtTestName").style.backgroundColor = 'white';
				}							
                strText = document.getElementById("ddlDay").value;   	                                
				if ((strText) == 0)
				{
					alert("Please select day");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlDay").style.backgroundColor = 'white';
				}
				
				
				strText = document.getElementById("ddlMonth").value;                      
				if ((strText) == 0)
				{
					alert("Please select month");
					document.getElementById("ddlMonth").focus();
					document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMonth").style.backgroundColor = 'white';
				}

				
				strText = document.getElementById("ddlYear").value;                       
				if ((strText) == 0)
				{
					alert("Please select year");
					document.getElementById("ddlYear").focus();
					document.getElementById("ddlYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlYear").style.backgroundColor = 'white';
				}        
				
				strText = document.getElementById("ddlTime").value;                       
				if ((strText) == 0)
				{
					alert("Please select time");
					document.getElementById("ddlTime").focus();
					document.getElementById("ddlTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTime").style.backgroundColor = 'white';
				}        
				
								
                strText = document.getElementById("ddlRegDay").value;   
	                                
				if ((strText) == 0)
				{
					alert("Please select day");
					document.getElementById("ddlRegDay").focus();
					document.getElementById("ddlRegDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlRegDay").style.backgroundColor = 'white';
				}
				
				
				strText = document.getElementById("ddlRegMonth").value;                      
				if ((strText) == 0)
				{
					alert("Please select month");
					document.getElementById("ddlRegMonth").focus();
					document.getElementById("ddlRegMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlRegMonth").style.backgroundColor = 'white';
				}

				
				strText = document.getElementById("ddlRegYear").value;                       
				if ((strText) == 0)
				{
					alert("Please select year");
					document.getElementById("ddlRegYear").focus();
					document.getElementById("ddlRegYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlRegYear").style.backgroundColor = 'white';
				}        
			}
			
			function ValidateShiftData()
			{			
			
			     var strText;			  
				strText = document.getElementById("txtShiftCapacity").value;											
				if (Trim(strText) == "")
				{
					alert("Please enter Shift Capacity");
					document.getElementById("txtShiftCapacity").focus();
					document.getElementById("txtShiftCapacity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtShiftCapacity").style.backgroundColor = 'white';
				}				
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric");
					document.getElementById("txtShiftCapacity").focus();
					document.getElementById("txtShiftCapacity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtShiftCapacity").style.backgroundColor = 'white';
				}

									
                strText = document.getElementById("ddlShiftDay").value;   	                                
				if ((strText) == 0)
				{
					alert("Please select day");
					document.getElementById("ddlShiftDay").focus();
					document.getElementById("ddlShiftDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlShiftDay").style.backgroundColor = 'white';
				}
				
				
				strText = document.getElementById("ddlShiftMonth").value;                      
				if ((strText) == 0)
				{
					alert("Please select month");
					document.getElementById("ddlShiftMonth").focus();
					document.getElementById("ddlShiftMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlShiftMonth").style.backgroundColor = 'white';
				}

				
				strText = document.getElementById("ddlShiftYear").value;                       
				if ((strText) == 0)
				{
					alert("Please select year");
					document.getElementById("ddlShiftYear").focus();
					document.getElementById("ddlShiftYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlShiftYear").style.backgroundColor = 'white';
				}        
				
				strText = document.getElementById("ddlSelShiftTime").value;                       
				if ((strText) == 0)
				{
					alert("Please select time");
					document.getElementById("ddlSelShiftTime").focus();
					document.getElementById("ddlSelShiftTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlSelShiftTime").style.backgroundColor = 'white';
				}        
				
								
              
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
						<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<TBODY>
								<TR class="white_bg" vAlign="top" align="left">
									<TD><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
								</TR>
								<TR class="blue_bg" vAlign="top" align="left">
									<TD class="header1" vAlign="middle">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR vAlign="top">
												<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Test &amp; Shift 
													Time&nbsp;Details</TD>
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
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Edit Details</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="5"></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" style="WIDTH: 188px">Test&nbsp;List:<FONT class="small_maroon">*</FONT></TD>
											<TD style="WIDTH: 219px"><asp:dropdownlist id="ddlTest" runat="server" Width="152px" AutoPostBack="True" CssClass="txtbox"></asp:dropdownlist></TD>
											<td align="right"><asp:button id="btnAddTest" runat="server" Width="96px" Text="Add Test"></asp:button></td>
											<td></td>
											<td></td>
										</TR>
										<TR class="main_black" align="left">
											<TD style="WIDTH: 188px; HEIGHT: 5px" align="right">Shift Time&nbsp;List:<FONT class="small_maroon">*</FONT></TD>
											<TD style="WIDTH: 219px; HEIGHT: 5px"><asp:dropdownlist id="ddlShiftTime" runat="server" Width="152px" AutoPostBack="True" CssClass="txtbox"></asp:dropdownlist></TD>
											<td style="HEIGHT: 5px" align="right"><asp:button id="btnAddShiftTime" runat="server" Text="Add Shift Time"></asp:button></td>
											<td style="HEIGHT: 5px"></td>
											<td style="HEIGHT: 5px"></td>
										</TR>
										<TR height="10">
											<TD colSpan="5" align="center">
												<asp:label id="lblMessage" runat="server" CssClass="errarea" Visible="False"></asp:label></TD>
										</TR>
										<TR class="main_black" align="left" height="10">
											<TD style="HEIGHT: 11px" align="center" colSpan="5"></TD>
										</TR>
										<TR class="main_black" id="dvTest1" align="left" runat="server">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Test&nbsp;Details</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="8"></TD>
										</TR>
										<TR class="main_black" id="dvTest2" align="left" runat="server">
											<TD style="WIDTH: 188px; HEIGHT: 16px" align="center">
												Name</TD>
											<TD style="HEIGHT: 16px" align="center" colSpan="2">Test Date &amp; Time</TD>
											<TD style="HEIGHT: 16px" align="center">Is Active</TD>
											<TD style="HEIGHT: 16px" align="center">Is Shift Time</TD>
										</TR>
										<TR class="main_black" id="dvTest3" align="left" runat="server">
											<TD align="center" style="WIDTH: 188px">
												<asp:textbox id="txtTestName" runat="server" Width="160px"></asp:textbox></TD>
											<TD colSpan="2" align="center"><asp:dropdownlist id="ddlDay" CssClass="txtarea" Runat="server" BackColor="White">
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
												</asp:dropdownlist><asp:dropdownlist id="ddlMonth" CssClass="txtarea" Runat="server" BackColor="White">
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
												</asp:dropdownlist><asp:dropdownlist id="ddlYear" Width="50px" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlTime" Width="60px" CssClass="txtarea" Runat="server" BackColor="White">
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
													<asp:ListItem Value="24">12 A.M</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><asp:checkbox id="chkIsActive" runat="server"></asp:checkbox></TD>
											<TD align="center">
												<asp:checkbox id="chkIsShiftTime" runat="server"></asp:checkbox></TD>
										</TR>
										<TR id="dvTest4" runat="server">
											<TD colSpan="5" height="8"></TD>
										</TR>
										<TR class="main_black" id="dvTest5" align="left" runat="server">
											<TD align="center">Registration End Date</TD>
											<TD style="HEIGHT: 20px" colSpan="2" align="center"></TD>
											<TD style="HEIGHT: 20px" align="center" colSpan="2"></TD>
										</TR>
										<TR class="main_black" id="dvTest6" align="left" runat="server">
											<TD align="left" colSpan="2">
												<asp:dropdownlist id="ddlRegDay" CssClass="txtarea" BackColor="White" Runat="server">
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
												<asp:dropdownlist id="ddlRegMonth" CssClass="txtarea" BackColor="White" Runat="server">
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
												<asp:dropdownlist id="ddlRegYear" CssClass="txtarea" Width="50px" BackColor="White" Runat="server">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD></TD>
											<TD colSpan="2"></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="8"></TD>
										</TR>
										<TR class="main_black" id="dvTime1" align="left" runat="server">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Shift Time&nbsp;Details</STRONG></TD>
										</TR>
										<TR id="dvTime2" runat="server">
											<TD colSpan="5" height="8"></TD>
										</TR>
										<TR class="main_black" id="dvTime3" align="left" runat="server">
											<TD style="WIDTH: 188px; HEIGHT: 16px" align="center">Shift Capacity</TD>
											<TD style="HEIGHT: 16px" align="center" colSpan="3">Test Date &amp; Time</TD>
											<TD style="HEIGHT: 16px" align="center">Is Active</TD>
										</TR>
										<TR class="main_black" id="dvTime4" align="left" runat="server">
											<TD align="center" style="WIDTH: 188px"><asp:textbox id="txtShiftCapacity" runat="server" Width="160px"></asp:textbox></TD>
											<TD colSpan="3" align="center">
												<asp:dropdownlist id="ddlShiftDay" CssClass="txtarea" Runat="server" BackColor="White">
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
												</asp:dropdownlist><asp:dropdownlist id="ddlShiftMonth" CssClass="txtarea" Runat="server" BackColor="White">
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
												</asp:dropdownlist><asp:dropdownlist id="ddlShiftYear" Width="50px" CssClass="txtarea" Runat="server" BackColor="White">
													<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
													<asp:ListItem Value="2007">2007</asp:ListItem>
													<asp:ListItem Value="2008">2008</asp:ListItem>
													<asp:ListItem Value="2009">2009</asp:ListItem>
												</asp:dropdownlist><asp:dropdownlist id="ddlSelShiftTime" Width="60px" CssClass="txtarea" Runat="server" BackColor="White">
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
													<asp:ListItem Value="24">12 A.M</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD align="center"><asp:checkbox id="chkIsShiftActive" runat="server"></asp:checkbox></TD>
										</TR>
										<TR runat="server" id="dvTime5">
											<TD colSpan="5" height="8" align="center"></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="8" align="center"><asp:button id="btnSubmitTestDetails" runat="server" Width="96px" Text="Submit"></asp:button></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="8" align="center"><asp:label id="lblSubmitMessage" runat="server" CssClass="errarea" Visible="False"></asp:label></TD>
										</TR>
										<TR runat="server" id="Tr1">
											<TD colSpan="5" height="8" align="center"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="5"><asp:datagrid id="dgCentre" runat="server" BackColor="White" CellPadding="3" BorderWidth="1px"
													BorderStyle="None" BorderColor="#CCCCCC" AllowPaging="True" PageSize="5" ShowFooter="True">
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
				</TR>
			</TABLE></TD>
			<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD></TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR></TBODY></TABLE></FORM>
	</body>
</HTML>
