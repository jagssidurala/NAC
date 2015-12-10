<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="ForgotPassword.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.ForgotPassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Forgot Password</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
        <LINK href="stylesheet/styleV2.css" type="text/css" rel="stylesheet">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			//Validating User Input
			function ValidateForgotLogin()
			{
				var strCheck;
				//Validating First Name
				strCheck = document.getElementById("txtFirstName").value;
				
				if (Trim(strCheck) == "")
				{
					alert("Please enter First name");
					document.getElementById("txtFirstName").focus();
					return false;
				}
				//Validating Last Name
	        strCheck = document.getElementById("txtLastName").value;
	
				if (Trim(strCheck) == "")
				{
					alert("Please enter Last name");
					document.getElementById("txtLastName").focus();
					return false;
				}
	//Validating Mother Name

	            strCheck = document.getElementById("txtMotherName").value;
				if (Trim(strCheck) == "")
				{
					alert("Please enter User name");
					document.getElementById("txtMotherName").focus();
					return false;
				}
	//Validating Day of month


	strCheck = document.getElementById("cmbDay").value;
				if (strCheck == 0)
				{
					alert("Please select valid day");
						document.getElementById("cmbDay").focus();
					return false;
				}
	//Validating Month

	strCheck = document.getElementById("cmbMonth").value;
				if (strCheck == 0)
				{
					alert("Please select valid month");
						document.getElementById("cmbMonth").focus();
					return false;
				}
				//validating Year
	strCheck = document.getElementById("cmbYear").value;
				if (strCheck == 0)
				{
					alert("Please select valid year");
					document.getElementById("cmbYear").focus();
					return false;
				}
				//Validating Date
	strCheck  = document.getElementById("cmbDay").value +"-" +  document.getElementById("cmbMonth").value + "-" +  document.getElementById("cmbYear").value
				if (isValidDate(strCheck)!="")
				{
					alert("Please enter valid date");
					document.getElementById("cmbDay").focus();
					return false;
				}
			}
		</script>
	   
	    <style type="text/css">
            #Table4
            {
                width: 427px;
            }
            .style1
            {
                height: 24px;
            }
            .style2
            {
                font-size: 11px;
                color: #a11d21;
                font-family: Arial;
                text-decoration: none;
                height: 24px;
            }
        </style>
	   
	</HEAD>
	<body class="popupbg">
		<form id="frmForgetPassword" method="post" runat="server">
			
            <table cellpadding ="0" cellspacing = "0" border = "0" width="425px">
                <tr>
                    <td>
			            <table id="Table1"  cellspacing="0" cellpadding="0" align="left" width="100%"
				border="0">				
					<tr class="blue_bg" vAlign="top" align="left">
						<td class="header1" vAlign="middle">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr vAlign="top">
									<td class="header1" vAlign="middle" align="left" height="20px">&nbsp;&nbsp;Forgot 
                                        Reg. ID/Password</td>
								</tr>
							</table>
						</td>
					</tr>
               </table>
                        
                    </td>
				</tr>	
                <tr>
                    <td>
                        <table class="black_bg" id="Table2" cellSpacing="0" width="100%" cellPadding="0" 
                             border="0">
					<tr vAlign="top" align="center">
						<td class="white_bg" align="center">
							<table class="lightblue_bg" id="Table4" cellSpacing="1" cellPadding="0" border="0">
								<tr>
									<td class="white_bg">
										<table id="Table4" cellSpacing="0" cellPadding="3" border="0">
											    
												<tr class="main_black" vAlign="top" align="left">
													<td class="lightblue_bg" colSpan="3" height="25"><strong>Please enter the following:</strong></td>
												</tr>
                                                <tr class="main_black" vAlign="top" align="left">
													<td  colSpan="3" height="15px">&nbsp;</td>
												</tr>
												<tr class="main_black" vAlign="top" align="left">
													<td class="style1" >&nbsp;&nbsp;First Name:<FONT class="small_maroon">*</FONT></td>
													<td>
														<asp:TextBox id="txtFirstName" runat="server" CssClass="txtbox" Width="200px"></asp:TextBox></td>
													<td class="small_maroon" width="2%"></td>
												</tr>
												<TR>
													<TD class="style1" ></TD>
													<TD class="small_maroon" width="2%"></TD>
													<TD ></TD>
												</TR>
												<tr class="main_black" vAlign="top" align="left">
													<td class="style1" >&nbsp;&nbsp;Last Name:<FONT class="small_maroon">*</FONT></td>
													<td>
														<asp:TextBox id="txtLastName" runat="server" CssClass="txtbox" Width="200px"></asp:TextBox></td>
													<td class="small_maroon" width="2%"></td>
												</tr>
												<TR>
													<TD class="style1"></TD>
													<TD></TD>
													<TD class="small_maroon" width="2%"></TD>
												</TR>
												<tr class="main_black" vAlign="top" align="left">
													<td nowrap class="style1">&nbsp;&nbsp;Mother's name:<FONT class="small_maroon">*</FONT></td>
													<td>
														<asp:TextBox id="txtMotherName" runat="server" CssClass="txtbox" Width="200px"></asp:TextBox></td>
													<td class="small_maroon"></td>
												</tr>
												<TR>
													<TD class="style1"></TD>
													<TD class="style2"></TD>
													<TD class="style1"></TD>
												</TR>
												<tr class="main_black" vAlign="top" align="left">
													<td class="style1">&nbsp;&nbsp;Date of Birth:<FONT class="small_maroon">*</FONT></td>
													<td nowrap><asp:dropdownlist id="cmbDay" CssClass="txtarea" Runat="server">
															<asp:ListItem Value="0">Day</asp:ListItem>
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
														</asp:dropdownlist><asp:dropdownlist id="cmbMonth" CssClass="txtarea" Runat="server">
															<asp:ListItem Value="0">Month</asp:ListItem>
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
														</asp:dropdownlist><asp:dropdownlist id="cmbYear" CssClass="txtarea" Runat="server">
															<asp:ListItem Value="0">Year</asp:ListItem>
															<asp:ListItem Value="2010">2010</asp:ListItem>
															<asp:ListItem Value="1999">1999</asp:ListItem>
															<asp:ListItem Value="1998">1998</asp:ListItem>
															<asp:ListItem Value="1997">1997</asp:ListItem>
															<asp:ListItem Value="1996">1996</asp:ListItem>
															<asp:ListItem Value="1995">1995</asp:ListItem>
															<asp:ListItem Value="1994">1994</asp:ListItem>
															<asp:ListItem Value="1993">1993</asp:ListItem>
															<asp:ListItem Value="1992">1992</asp:ListItem>
															<asp:ListItem Value="1991">1991</asp:ListItem>
															<asp:ListItem Value="1990">1990</asp:ListItem>
															<asp:ListItem Value="1989">1989</asp:ListItem>
															<asp:ListItem Value="1988">1988</asp:ListItem>
															<asp:ListItem Value="1987">1987</asp:ListItem>
															<asp:ListItem Value="1986">1986</asp:ListItem>
															<asp:ListItem Value="1985">1985</asp:ListItem>
															<asp:ListItem Value="1984">1984</asp:ListItem>
															<asp:ListItem Value="1983">1983</asp:ListItem>
															<asp:ListItem Value="1982">1982</asp:ListItem>
															<asp:ListItem Value="1981">1981</asp:ListItem>
															<asp:ListItem Value="1980">1980</asp:ListItem>
															<asp:ListItem Value="1979">1979</asp:ListItem>
															<asp:ListItem Value="1978">1978</asp:ListItem>
															<asp:ListItem Value="1977">1977</asp:ListItem>
															<asp:ListItem Value="1976">1976</asp:ListItem>
															<asp:ListItem Value="1975">1975</asp:ListItem>
															<asp:ListItem Value="1974">1974</asp:ListItem>
															<asp:ListItem Value="1973">1973</asp:ListItem>
															<asp:ListItem Value="1972">1972</asp:ListItem>
															<asp:ListItem Value="1971">1971</asp:ListItem>
															<asp:ListItem Value="1970">1970</asp:ListItem>
															<asp:ListItem Value="1969">1969</asp:ListItem>
															<asp:ListItem Value="1968">1968</asp:ListItem>
															<asp:ListItem Value="1967">1967</asp:ListItem>
															<asp:ListItem Value="1966">1966</asp:ListItem>
															<asp:ListItem Value="1965">1965</asp:ListItem>
															<asp:ListItem Value="1964">1964</asp:ListItem>
															<asp:ListItem Value="1963">1963</asp:ListItem>
															<asp:ListItem Value="1962">1962</asp:ListItem>
															<asp:ListItem Value="1961">1961</asp:ListItem>
															<asp:ListItem Value="1960">1960</asp:ListItem>
																	
														</asp:dropdownlist></td>
													<td class="small_maroon"></td>
												</tr>
								</tr>
								<TR>
									<TD class="style1"></TD>
									<TD class="small_maroon"></TD>
									<TD></TD>
								</TR>
								<tr class="main_black" vAlign="top" align="center">
									<td colSpan="3">
										<asp:Button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"></asp:Button></td>
								</tr>
								<TR class="main_black">
									<TD colSpan="3" align="center">
										<asp:Label id="lblResult" runat="server" CssClass="errarea"></asp:Label></TD>
								</TR>
							</table>
						</td>
					</tr>
			</table>
                    </td>
                </tr>
			</table>
			
			</form>
	</body>
</HTML>
