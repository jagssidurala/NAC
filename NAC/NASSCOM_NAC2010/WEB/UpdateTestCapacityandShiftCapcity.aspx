<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTestCapacityandShiftCapcity.aspx.cs" Inherits="NASSCOM_NAC.Web.UpdateTestCapacityandShiftCapcity" %>

<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Test and Shift Capacity</title>
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" />
    <link rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css" />
    <script language="javascript" src="../Web/js/common.js"></script>
    <script language="javascript" src="js/datetimepicker_css.js"></script>
    <script language="javascript" type="text/javascript">
        function CheckManadatory() {

            var DayFrom = document.getElementById('ddlTestState');
            if (DayFrom.value <= 0) {
                alert("Please select  test state ");
                DayFrom.focus();
                return false;
            }

            var DayFrom = document.getElementById('ddlTestCity');
            if (DayFrom.value <= 0) {
                alert("Please select  test city ");
                DayFrom.focus();
                return false;
            }

            var DayFrom = document.getElementById('ddlTestCentre');
            if (DayFrom.value <= 0) {
                alert("Please select  test centre ");
                DayFrom.focus();
                return false;
            }

            var DayFrom = document.getElementById('ddlTestDayFrom');
            if (DayFrom.value <= 0) {
                alert("Please select  Day ");
                DayFrom.focus();
                return false;
            }

            var MonthFrom = document.getElementById('ddlTestMonthFrom');
            if (MonthFrom.value <= 0) {
                alert("Please select  Month ");
                MonthFrom.focus();
                return false;
            }

            var YearFrom = document.getElementById('ddlTestYearFrom');
            if (YearFrom.value <= 0) {
                alert("Please select  Year");
                YearFrom.focus();
                return false;
            }

            var DayTo = document.getElementById('ddlTestDayTo');
            if (DayTo.value <= 0) {
                alert("Please select To Day ");
                DayTo.focus();
                return false;
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
        function changelblText(Id, text) {
            alert(text);
            Id = String(Id).split('$').join('_');
            document.getElementById(Id).innerHTML = text;
            document.getElementById(Id).className = "small_maroon";
        }
        function changelblNonShiftText(Id, text) {
            alert(text);
            Id = String(Id).split('$').join('_');
            document.getElementById(Id).innerHTML = text;
            document.getElementById(Id).className = "small_maroon";
        }

    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="frmRegistrationWindow" method="post" runat="server">
        <input id="hdCentre" value="0" type="hidden" name="hdCentre" runat="server" />
        <input id="hdCity" value="0" type="hidden" name="hdCity" runat="server" />
        <input id="hdState" value="0" type="hidden" name="hdState" runat="server" />
        <div align="center">
            <table id="table1" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <table id="Table_01" border="0" cellspacing="0" cellpadding="0" width="888">
                            <tr>
                                <td>
                                    <img src="../Web/Images/BANNER.jpg" width="942" height="124" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a style="WIDTH: 0%; HEIGHT: 14px" class="link" href="Welcome.aspx">Home</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <td>
                                <table id="table2" border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td>
                                            <table id="table8" border="0" cellspacing="1" cellpadding="1" width="100%" align="center" height="100%">
                                                <tr class="main_black_small" valign="top" align="left">
                                                    <td valign="top" width="20%">
                                                        <fieldset align="left">
                                                            <legend class="main_black_bold">Test Details </legend>
                                                            <table id="table9" cellspacing="1" cellpadding="1" width="100%" height="49">
                                                                <tr class="main_black_small" valign="top" align="left">
                                                                    <td width="110" align="left">Select Test State:</td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTestState" CssClass="txtarea" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlTestState_SelectedIndexChanged" ValidationGroup="GetTestDetails">
                                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvTestState" runat="server" ControlToValidate="ddlTestState"
                                                                            InitialValue="0" ErrorMessage="Select test state." Enabled="True" ToolTip="Select test city"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr class="main_black_small" valign="top" align="left">
                                                                    <td width="110" align="left">Select Test City:</td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTestCity" CssClass="txtarea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTestCity_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvTestCity" runat="server" ControlToValidate="ddlTestCity"
                                                                            InitialValue="0" ErrorMessage="Select test city." Enabled="True" ToolTip="Select test state"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="110" align="left">Select Test Centre:</td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTestCentre" CssClass="txtarea" runat="server">
                                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvTestCentre" runat="server" ControlToValidate="ddlTestCentre"
                                                                            InitialValue="0" ErrorMessage="Select test centre." Enabled="True" ToolTip="Select test centre"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="110" align="left">Select Test Date:</td>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTestDayFrom" CssClass="txtarea" runat="server"></asp:DropDownList>

                                                                        <asp:DropDownList ID="ddlTestMonthFrom" CssClass="txtarea" runat="server">
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
                                                                        <asp:DropDownList ID="ddlTestYearFrom" CssClass="txtarea" runat="server"></asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvTestDay" runat="server" ControlToValidate="ddlTestDayFrom"
                                                                            InitialValue="0" ErrorMessage="Select Test Day." Enabled="True" ToolTip="Select Test Day"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:RequiredFieldValidator ID="rfvTestMonth" runat="server" ControlToValidate="ddlTestMonthFrom"
                                                                            InitialValue="0" ErrorMessage="Select Test Month." Enabled="True" ToolTip="Select Test Month"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator>
                                                                        <asp:RequiredFieldValidator ID="rfvTestYearFrom" runat="server" ControlToValidate="ddlTestYearFrom"
                                                                            InitialValue="0" ErrorMessage="Select Test year." Enabled="True" ToolTip="Select Test Year"
                                                                            CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                            Display="dynamic"></asp:RequiredFieldValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                                                        <td >
                                                                            <asp:Button ID="btnGetTestDetails" runat="server" CssClass="button" Text="GetTestDetails" OnClick="btnGetTestDetails_Click" ValidationGroup="GetTestDetails" OnClientClick="javascript:return CheckManadatory();" CommandArgument="Submit"></asp:Button>
                                                                        </td>
                                                                    </tr>--%>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 918px" align="center">
                                                        <asp:Button ID="btnGetTestDetails" runat="server" CssClass="button" Text="GetTestDetails" OnClick="btnGetTestDetails_Click" ValidationGroup="GetTestDetails" OnClientClick="javascript:return CheckManadatory();" CommandArgument="Submit"></asp:Button>&nbsp;
										<asp:Button ID="btnReset" runat="server" CssClass="button" EnableViewState="False" Text="Reset" OnClick="btnReset_Click"></asp:Button>&nbsp;
										<asp:Button ID="btnBack" runat="server" CssClass="button" EnableViewState="False" Text="Back" OnClick="btnBack_Click"></asp:Button>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="5">
                                                        <b>
                                                            <asp:Label ID="lblMsgNoRecords" CssClass="small_maroon" runat="server"></asp:Label></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                            <tr>
                                <td>
                                    <asp:Repeater ID="rptTestDetailsNonShift" runat="server" OnItemCommand="rptTestDetailsNonShift_ItemCommand">
                                        <HeaderTemplate>
                                            <fieldset>
                                                <legend class="main_black_bold"><b>Test Capcity Details </b></legend>
                                                <table>
                                        </HeaderTemplate>
                                        <ItemTemplate>

                                            <table>
                                                <tr class="main_black_small">
                                                    <asp:HiddenField ID="hdnTestId" runat="server" Value='<%#Eval("TestId")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnTestDate" runat="server" Value='<%#Eval("TestDate")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnRegisteredCount" runat="server" Value='<%#Eval("RegisteredCount")%>'></asp:HiddenField>
                                                    <td>Test Date :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTestDate" runat="server" Text='<%#Eval("TestTime","{0:dd MMM yyyy hh:mm tt}")%>'></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr class="main_black_small">
                                                    <td>Test Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcapcity" runat="server" Text='<%#Eval("Capacity")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>New Test Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewCapacity" runat="server" Style="width: 120px" ValidationGroup="regrptTestDetailsNonShift"></asp:TextBox>

                                                    </td>
                                                    <td>
                                                        <asp:RegularExpressionValidator ID="revtxtNewCapacity" ControlToValidate="txtNewCapacity" runat="server" ErrorMessage="Enter only numbers" ValidationExpression="\d+" ValidationGroup="regrptTestDetailsNonShift" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvtxtNewCapacity" runat="server" ControlToValidate="txtNewCapacity"
                                                            ErrorMessage="Entre test capacity." Enabled="True" ToolTip="Entre test capacity."
                                                            CssClass="errorcontent Tab1" ValidationGroup="regrptTestDetailsNonShift" SetFocusOnError="true" Display="dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>
                                                        <br />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnSubmitNewCapcity" runat="server" Text="Update" CommandName="Update" class="button" ValidationGroup="regrptTestDetailsNonShift"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                    </td>
                                                    <td align="center" colspan="5">

                                                        <asp:Label ID="lblUpdateMsg" runat="server" CssClass="small_maroon" Visible="true"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </fieldset>
                                                </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Repeater ID="rpttestdetails" runat="server" OnItemCommand="rpttestdetails_ItemCommand" OnItemDataBound="rpttestdetails_ItemDataBound">
                                        <HeaderTemplate>
                                            <fieldset>
                                                <legend class="main_black_bold">Shift Capacity Details </legend>
                                                <table>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>

                                            <table>
                                                <tr class="main_black_small">
                                                    <asp:HiddenField ID="hdnShiftId" runat="server" Value='<%#Eval("ShiftID")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnTestId" runat="server" Value='<%#Eval("TestId")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnTestDate" runat="server" Value='<%#Eval("TestDate")%>'></asp:HiddenField>
                                                    <asp:HiddenField ID="hdnRegisteredCount" runat="server" Value='<%#Eval("RegisteredCount")%>'></asp:HiddenField>
                                                    <td>Test Date :
                                                    </td>
                                                    <td class="main_black_small">
                                                        <asp:Label ID="lblTestDate" runat="server" Text='<%#Eval("TestTime")%>'></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr class="main_black_small">
                                                    <td>Test Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcapcity" runat="server" Text='<%#Eval("TestCapacity")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>Shift Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblShiftCapacity" runat="server" Text='<%#Eval("ShiftCapacity")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>New Test Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewCapacity" runat="server" Style="width: 120px" MaxLength="10"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RegularExpressionValidator ID="revtxtNewCapacity" ControlToValidate="txtNewCapacity" runat="server" ErrorMessage="Enter only numbers" ValidationExpression="\d+" ValidationGroup="regrpttestdetails" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvtxtNewCapacity" runat="server" ControlToValidate="txtNewCapacity"
                                                            ErrorMessage="Entre test capacity." Enabled="True" ToolTip="Entre test capacity."
                                                            CssClass="errorcontent Tab1" ValidationGroup="regrpttestdetails" SetFocusOnError="true" Display="dynamic"></asp:RequiredFieldValidator>
                                                    </td>

                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>New Shift Capacity :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewShiftCapacity" runat="server" Style="width: 120px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RegularExpressionValidator ID="revtxtNewShiftCapacity" ControlToValidate="txtNewShiftCapacity" runat="server" ErrorMessage="Enter only numbers" ValidationExpression="\d+" ValidationGroup="regrpttestdetails" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="rfvtxtNewShiftCapacity" runat="server" ControlToValidate="txtNewShiftCapacity"
                                                            ErrorMessage="Entre shift capacity." Enabled="True" ToolTip="Entre shift capacity."
                                                            CssClass="errorcontent Tab1" ValidationGroup="regrpttestdetails" SetFocusOnError="true" Display="dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>
                                                        <br />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnSubmitNewCapcity" runat="server" Text="Update" CommandName="Update" class="button" ValidationGroup="regrpttestdetails"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr class="main_black_small">
                                                    <td>
                                                        <br />
                                                    </td>
                                                    <td align="center" colspan="5"></b><asp:Label ID="lblRptSucceesmessage" CssClass="small_maroon" runat="server" Visible="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                </tr>
                                            </table>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </fieldset>
                                                </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5"><b>
                                    <asp:Label ID="lblrpttestdetailsMsg" CssClass="small_maroon" runat="server" Visible="false"></asp:Label></b></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>
                            <asp:Label ID="lblTotal" runat="server" Text="Total" Visible="false"></asp:Label></b>
                    </td>
                    <td>
                        <b>
                            <asp:TextBox ID="txtTotal" runat="server" Visible="false"></asp:TextBox></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
