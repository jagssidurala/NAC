<%@ Page Language="C#"  CodeBehind="RegistrationWindow.aspx.cs" AutoEventWireup="True"  EnableEventValidation="false" Inherits="NASSCOM_NAC.Web.RegistrationWindow" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

   <HEAD>
		<title>Registration Window Extend Page</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
        <SCRIPT language="javascript" src="js/datetimepicker_css.js"></SCRIPT>
<script language="javascript" type="text/javascript">

    function CheckManadatory() {

        var DayFrom = document.getElementById('ddlTestDayFrom');
        if (DayFrom.value <= 0) {
            alert("Please select From Day ");
            DayFrom.focus();
            return false;
        }

        var MonthFrom = document.getElementById('ddlTestMonthFrom');
        if (MonthFrom.value <= 0) {
            alert("Please select From Month ");
            MonthFrom.focus();
            return false;
        }

        var YearFrom = document.getElementById('ddlTestYearFrom');
        if (YearFrom.value <= 0) {
            alert("Please select From Year");
            YearFrom.focus();
            return false;
        }
      
        var DayTo = document.getElementById('ddlTestDayTo');
        if (DayTo.value <= 0) {
            alert("Please select To Day ");
            DayTo.focus();
            return false ;
        }

        var MonthTo = document.getElementById('ddlTestMonthTo');
        if (MonthTo.value <= 0) {
            alert("Please select To Month ");
            MonthTo.focus();
            return false;
        }

        var YearTo = document.getElementById('ddlTestYearTo');
        if (YearTo.value <= 0) {
            alert("Please select To Year");
            YearTo.focus();
            return false;
        }
      

        var state = document.getElementById('ddlTestState').value;
        if (state < 0) {
            alert("Please select State");
            return false;
        }

        var City = document.getElementById('ddlTestCity').value;
        if (City < 0) {
            alert("Please select City");
            return false;
        }

        var Centre = document.getElementById('ddlTestCentre').value;
        if (Centre < 0) {
            alert("Please select Centre");
            return false;
        }
    }

    function validUpdate() {

        var endDate = document.getElementById('txtRegEndDateTime').value;
        if (endDate == "") {
            alert("Please select valid date to update");
            return false;
        }
    }
</script>
	</HEAD>
<BODY MS_POSITIONING="GridLayout">
		<FORM id="frmRegistrationWindow" method="post" runat="server">
			<INPUT id="hdCentre" value="0" type="hidden" name="hdCentre" runat="server"> <input id="hdCity" value="0" type="hidden" name="hdCity" runat="server">
			<INPUT id="hdState" value="0" type="hidden" name="hdState" runat="server">
			<DIV align="center">
				<table id="table1" border="0" cellSpacing="0" cellPadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellSpacing="0" cellPadding="0" width="888">
								<tr>
									<td style="WIDTH: 918px" vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
								</tr>
								<tr>
									<td style="WIDTH: 918px" vAlign="top">&nbsp;&nbsp;<A style="WIDTH: 0%; HEIGHT: 14px" class="link" href="Welcome.aspx">Home</A>
										<h1>&nbsp;</h1>
									</td>
								</tr>

                                <tr>
									<td style="WIDTH: 919px; HEIGHT: 18px" vAlign="top" align="center">
										<table id="table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td vAlign="top">
													
													<table id="table8" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center"
														height="100%">
														<tr class="main_black_small" vAlign="top" align="left">
															<td vAlign="top" width="20%">
																<fieldset align="left"><legend class="main_black_bold">Test Locations</legend>
																	<table id="table9" border="0" cellSpacing="1" cellPadding="1" width="100%" height="49">
                                                                    <tr class="main_black_small" vAlign="top" align="left">
																			
																			<td>From:<!-- Start From Date --></td>
																			<td><asp:dropdownlist id="ddlTestDayFrom" CssClass="txtarea" Runat="server">
																					
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestMonthFrom" CssClass="txtarea" Runat="server">
																					
																				</asp:dropdownlist>
                                                                                
                                                                                <asp:dropdownlist id="ddlTestYearFrom" CssClass="txtarea" Runat="server">																					
																				</asp:dropdownlist>

																				<!-- END From Date --></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td>To:</td>
																			<td><asp:dropdownlist id="ddlTestDayTo" CssClass="txtarea" Runat="server">
																					
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestMonthTo" CssClass="txtarea" Runat="server">
																					
																				</asp:dropdownlist>
                                                                                <asp:dropdownlist id="ddlTestYearTo" CssClass="txtarea" Runat="server">																					
																				</asp:dropdownlist>
																				<!-- End To Date --></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td width="90" align="left">Test State:</td>
																			<td align="left"><asp:dropdownlist id="ddlTestState" runat="server"  AutoPostBack="true"
                                                                                    CssClass="txtbox" onselectedindexchanged="ddlTestState_SelectedIndexChanged">
																					
																				</asp:dropdownlist></td>
																		</tr>
																	<tr class="main_black_small" vAlign="top" align="left">
																			<td width="90" align="left">Test City:</td>
																			<td align="left"><asp:dropdownlist id="ddlTestCity" runat="server"  AutoPostBack="true"
                                                                                    CssClass="txtbox" onselectedindexchanged="ddlTestCity_SelectedIndexChanged">
                                                                         
																				</asp:dropdownlist></td>
																		</tr>
                                                                        	<tr class="main_black_small" vAlign="top" align="left">
																			<td width="90" align="left">Test Centre:</td>
																			<td align="left"><asp:dropdownlist id="ddlTestCentre" AutoPostBack="true" runat="server" CssClass="txtbox"> 
                                                                            	
                                                                                <%--<asp:ListItem Value="01">01</asp:ListItem>--%>
																				</asp:dropdownlist></td>
                                                                             
																		</tr>
																	</table>
																</fieldset>
															</td>
														</tr>
                                                        <TR class="main_black_small" vAlign="top" align="left">
									<TD style="WIDTH: 918px" vAlign="top" width="918" align="center">
                                    <asp:button id="btnSearch" runat="server" CssClass="button" EnableViewState="False" Text="Search"
									OnClientClick="javascript:return CheckManadatory();" CommandArgument="Submit" onclick="btnSearch_Click"></asp:button>&nbsp;
										<asp:button id="btnReset" runat="server" CssClass="button" EnableViewState="False" Text="Reset" onclick="btnReset_Click"></asp:button>&nbsp;
										<asp:button id="btnBack" runat="server" CssClass="button" EnableViewState="False" Text="Back" onclick="btnBack_Click"></asp:button>&nbsp;
									</TD>
								</TR>

                               

                                <tr class="main_black_small" align="center">
									<td style="WIDTH: 918px"><asp:panel id="pnlSearch" Runat="server">
											
											<INPUT id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
												runat="server">
										</asp:panel><INPUT id="Hidden1" value="0" type="hidden" name="hdSelectedCandidateCount" runat="server"></td>
								</tr>
								<tr class="small_maroon" align="center">
									<td style="WIDTH: 918px" align="center"><asp:panel id="pnlMessage" Runat="server" HorizontalAlign="Center">
											<asp:Label id="lblMessage" CssClass="small_maroon" Runat="server" Visible="True" 
												Font-Bold="True" ForeColor="red"></asp:Label>
										</asp:panel></td>
								</tr>
		</table>
</DIV>


<fieldset runat="server" id="fieldsetDetail" align="left">
<legend class="main_black_bold">Details</legend>

<table>
<tr align="left">
    <td style="width:200px">Test Date :</td>
    <td><asp:Label ID="lblTestDate" runat="server" Text=""></asp:Label></td>
</tr>
<tr  align="left">
    <td style="width:200px">State :</td>
    <td><asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
</tr>
<tr  align="left">
    <td style="width:200px">City :</td>
    <td><asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>
</tr>
<tr  align="left">
    <td style="width:200px">Centre :</td>
    <td><asp:Label ID="lblCentre" runat="server" Text=""></asp:Label></td>
</tr>
<tr  align="left">
    <td style="width:200px">Registration Start Date :</td>
    <td><asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></td>
</tr>

<tr align="left">
    <td style="width:200px">Registration End Date :</td>
    <td><asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label></td>
</tr>

</table>
<hr />
<table>
<tr align="left">
    <td style="width:250px; font-weight:bold; color:Blue">Update Registration End Date :</td>
   <td>
	<asp:TextBox id="txtRegEndDateTime" runat="server" Width="120px" MaxLength="25"> </asp:TextBox>
  <%--  <asp:Label ID="lblupdateEndDate" runat="server"></asp:Label>--%>
    &nbsp;
    <IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtRegEndDateTime','MMddyyyy','arrow',true,'24')"	src="images/cal.gif"/>
	</td>
    <td><asp:button id="btnUpdate" runat="server" CssClass="button" EnableViewState="False" Text="Update" OnClientClick="javascript:return validUpdate();" onclick="btnUpdate_Click"></asp:button></td>
</tr>

<tr>
<td align="center" colspan="3"><asp:Label id="lblUpdateMessage" CssClass="small_maroon" Runat="server" Visible="True"
												Font-Bold="True" ForeColor="red"></asp:Label></td>
</tr>
</table>
<asp:HiddenField ID="hdnTestId" runat="server" />
</fieldset>
    </form>
</body>
</html>
