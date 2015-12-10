<%@ Page language="c#" Codebehind="Approve.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.Approve" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Approve</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../WEB/Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="../WEB/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
			
				var currentDate = new Date();
				var expiryDate = new Date();
				var strText;
				
				if(document.getElementById("ddlDay").value == "0")
				{
					alert("Please enter day");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				if(document.getElementById("ddlMonth").value == "0")
				{
					alert("Please enter Month");
					document.getElementById("ddlMonth").focus();
					document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
					return false;
				}
				if(document.getElementById("ddlYear").value == "0")
				{
					alert("Please enter year");
					document.getElementById("ddlYear").focus();
					document.getElementById("ddlYear").style.backgroundColor = 'yellow';
					return false;
				}
							      
				if(document.getElementById("ddlDay").value != "0" && document.getElementById("ddlMonth").value != "0" && document.getElementById("ddlYear").value != "0")
				{
					strText = document.getElementById("ddlDay").value + "-" + document.getElementById("ddlMonth").value + "-" + document.getElementById("ddlYear").value;
					expiryDate = expiryDate.setFullYear(document.getElementById("ddlYear").value,document.getElementById("ddlMonth").value - 1, document.getElementById("ddlDay").value);
					if (isValidDate(strText)!="")
					{
						alert("Please enter valid date");
						document.getElementById("ddlDay").focus();
						document.getElementById("ddlDay").style.backgroundColor = 'yellow';
						return false;
					}
					else if(currentDate >= expiryDate)
					{
						alert("Past or current date for Agreement expiry is not allowed");
						document.getElementById("ddlDay").focus();
						document.getElementById("ddlDay").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("ddlDay").style.backgroundColor = 'white';
						return true;
					}
				}
			}
		</script>
	</HEAD>
	<BODY>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
						<asp:Label ID="lblAgreementExpiryDate" CssClass="label_black_bold" Runat="server">Agreement Expiry Date:</asp:Label>
					</td>
					<td>
						<asp:DropDownList id="ddlDay" runat="server">
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
						</asp:DropDownList>
						<asp:DropDownList id="ddlMonth" runat="server">
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
						</asp:DropDownList>
						<asp:DropDownList id="ddlYear" runat="server">
							<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
							<asp:ListItem Value="2015">2015</asp:ListItem>
							<asp:ListItem Value="2014">2014</asp:ListItem>
							<asp:ListItem Value="2013">2013</asp:ListItem>
							<asp:ListItem Value="2012">2012</asp:ListItem>
							<asp:ListItem Value="2011">2011</asp:ListItem>
							<asp:ListItem Value="2010">2010</asp:ListItem>
							<asp:ListItem Value="2009">2009</asp:ListItem>
							<asp:ListItem Value="2008">2008</asp:ListItem>
							<asp:ListItem Value="2007">2007</asp:ListItem>
							<asp:ListItem Value="2006">2006</asp:ListItem>
							<asp:ListItem Value="2005">2005</asp:ListItem>
							<asp:ListItem Value="2004">2004</asp:ListItem>
							<asp:ListItem Value="2003">2003</asp:ListItem>
							<asp:ListItem Value="2002">2002</asp:ListItem>
							<asp:ListItem Value="2001">2001</asp:ListItem>
							<asp:ListItem Value="2000">2000</asp:ListItem>
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
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center">&nbsp;
						<asp:Label id="lblError" runat="server" CssClass="errormessage"></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2" align="right">
						<asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="button" onclick="btnCancel_Click"></asp:Button>&nbsp;
						<asp:Button id="btnSubmit" runat="server" Text="Submit" CssClass="button" onclick="btnSubmit_Click"></asp:Button>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
