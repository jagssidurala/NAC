<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutomateRegistered_Count.aspx.cs" Inherits="NASSCOM_NAC.NACdb.AutomateRegistered_Count" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <title>Registered Count</title>
    	<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<script language="javascript" type="text/javascript">

		    function ValidateData()
             {
		        var varTestDateFrom;
		        var varTestDateTo;

		        if (document.getElementById("ddlTestDayFrom").value != "0" && document.getElementById("ddlTestMonthFrom").value != "0" && document.getElementById("ddlTestYearFrom").value != "0") {
		            varTestDateFrom = document.getElementById("ddlTestDayFrom").value + "-" + document.getElementById("ddlTestMonthFrom").value + "-" + document.getElementById("ddlTestYearFrom").value;

		            if (isValidDate(varTestDateFrom) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlTestDayFrom").focus();
		                document.getElementById("ddlTestDayFrom").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {

		                document.getElementById("ddlTestDayFrom").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            varTestDateFrom = "";

		        }

		        if (document.getElementById("ddlTestDayTo").value != "0" && document.getElementById("ddlTestMonthTo").value != "0" && document.getElementById("ddlTestYearTo").value != "0") {
		            varTestDateTo = document.getElementById("ddlTestDayTo").value + "-" + document.getElementById("ddlTestMonthTo").value + "-" + document.getElementById("ddlTestYearTo").value;

		            if (isValidDate(varTestDateTo) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlTestDayTo").focus();
		                document.getElementById("ddlTestDayTo").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("ddlTestDayTo").style.backgroundColor = 'white';
		            }
		        }
		        
		      
		        if ((document.getElementById("ddlTestDayTo").value != "0" && document.getElementById("ddlTestMonthTo").value != "0" && document.getElementById("ddlTestYearTo").value != "0") &&
			(document.getElementById("ddlTestDayFrom").value != "0" && document.getElementById("ddlTestMonthFrom").value != "0" && document.getElementById("ddlTestYearFrom").value != "0")) {
		            var varTestDateFrom = document.getElementById("ddlTestYearFrom").value + "" + document.getElementById("ddlTestMonthFrom").value + "" + document.getElementById("ddlTestDayFrom").value;
		            var varTestDateTo = document.getElementById("ddlTestYearTo").value + "" + document.getElementById("ddlTestMonthTo").value + "" + document.getElementById("ddlTestDayTo").value;

		            if (varTestDateFrom > varTestDateTo) {
		                alert("Test Date(From) cannot be greater than Test date(To) ");
		                document.getElementById("ddlTestYearFrom").focus();
		                return false;
		            }
		        }	
		    }


       </script>
</head>

<body>
    <form id="frmHome" method="post" runat="server">
			<div align="center">
    
<table id="tblReport" border="0" cellspacing="0" cellpadding="0">
<tr>
	<td>
                        <table id="Table_01" cellspacing="0" cellpadding="0" width="888" border="0">
								<tr>
									<td rowspan="8">&nbsp;</td>
									<td valign="top" colspan="2"><img src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td rowspan="8">&nbsp;</td>
									<td rowspan="8">&nbsp;</td>
                                    <td><br /></td>
								</tr>
                            
<tr>
 	<td colspan="1">TestDateFrom:</td>
        <td colspan="1"><asp:dropdownlist id="ddlTestDayFrom" CssClass="txtarea" Runat="server"></asp:dropdownlist>
<asp:dropdownlist id="ddlTestMonthFrom" CssClass="txtarea" Runat="server">
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
<asp:dropdownlist id="ddlTestYearFrom" CssClass="txtarea" Runat="server"></asp:dropdownlist></td>
     </tr>
     <tr> 
     <td colspan="1">TestDateTo:</td>
   <td colspan="1"><asp:dropdownlist id="ddlTestDayTo" CssClass="txtarea" Runat="server"></asp:dropdownlist>
   <asp:dropdownlist id="ddlTestMonthTo" CssClass="txtarea" Runat="server"><asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
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
																					<asp:ListItem Value="12">December</asp:ListItem></asp:dropdownlist>
<asp:dropdownlist id="ddlTestYearTo" CssClass="txtarea" Runat="server"></asp:dropdownlist></td>
</tr>
     <tr>
    <td colspan="1"><asp:button id="btnSubmit" runat="server" CssClass="button" Text="GetTestEvent" onclick="btnSubmit_Click"></asp:button></td>
      <td colspan="1">
        <asp:DropDownList ID="ddlTestName"  Width:30 runat="server">
        </asp:DropDownList>
        </td>
        </tr>
        <tr align="center">
       <td colspan="2"><asp:button ID="btnSubmit1" runat="server" text="GetReport" 
               onclick="btnSubmit1_Click" /></td>
               <td><br /></td>
      </tr>

      </table>
      </td>
      </tr>
      <tr>
      <td> <asp:GridView ID="GrReport" runat="server">
    </asp:GridView></td>
      </tr>
      <tr>
									<td valign="top" align="center">
                                 <uc1:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc1:nacyearlyfooter> 
									</td>
								</tr>
  		</table>

    </div> 
    </form>
  
        </body>
</html>

