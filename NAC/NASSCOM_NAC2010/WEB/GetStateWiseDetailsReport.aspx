<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetStateWiseDetailsReport.aspx.cs" Inherits="NASSCOM_NAC.Web.GetStateWiseDetailsReport" %>

<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get State Wise Details Report</title>
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

            //var DayFrom = document.getElementById('ddlTestState');
            //if (DayFrom.value <= 0) {
            //    alert("Please select  test state ");
            //    DayFrom.focus();
            //    return false;
            //}
            var DayFrom = document.getElementById('ddlTestDayFrom');
            if (DayFrom.value <= 0) {
                alert("Please select test start Day ");
                DayFrom.focus();
                return false;
            }

            var MonthFrom = document.getElementById('ddlTestMonthFrom');
            if (MonthFrom.value <= 0) {
                alert("Please select test start Month ");
                MonthFrom.focus();
                return false;
            }

            var YearFrom = document.getElementById('ddlTestYearFrom');
            if (YearFrom.value <= 0) {
                alert("Please select test start  Year");
                YearFrom.focus();
                return false;
            }

            var DayTo = document.getElementById('ddlTestDayTo');
            if (DayTo.value <= 0) {
                alert("Please select To end Day ");
                DayTo.focus();
                return false;
            }

            var MonthTo = document.getElementById('ddlTestMonthTo');
            if (MonthTo.value <= 0) {
                alert("Please select To end Month ");
                MonthTo.focus();
                return false;
            }

            var YearTo = document.getElementById('ddlTestYearTo');
            if (YearTo.value <= 0) {
                alert("Please select To end Year");
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
    </script>
</head>
<body>
    <form id="frmRegistrationWindow" method="post" runat="server">
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
                            <tr>
                                <td>
                                    <table id="table2" border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td>
                                                <table id="table8" border="0" cellspacing="1" cellpadding="1" width="100%" align="center" height="100%">
                                                    <tr class="main_black_small" valign="top" align="left">
                                                        <td valign="top" width="20%">
                                                            <fieldset align="left">
                                                                <legend class="main_black_bold">Select Details </legend>
                                                                <table id="table9" cellspacing="1" cellpadding="1" width="100%" height="49">
                                                                    <tr class="main_black_small" valign="top" align="left">
                                                                        <td width="163" align="left">Select Test State:</td>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlTestState" CssClass="txtarea" AutoPostBack="True" runat="server" ValidationGroup="GetTestDetails">
                                                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                          <%--  <asp:RequiredFieldValidator ID="rfvTestState" runat="server" ControlToValidate="ddlTestState"
                                                                                InitialValue="0" ErrorMessage="Select Test State." Enabled="True" ToolTip="Select Test City"
                                                                                CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                                Display="dynamic"></asp:RequiredFieldValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="110" align="left">Select Test Start  Date</td>
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
                                                                        <td width="110" align="left">Select Test End Date </td>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlTestDayTo" CssClass="txtarea" runat="server"></asp:DropDownList>

                                                                            <asp:DropDownList ID="ddlTestMonthTo" CssClass="txtarea" runat="server">
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
                                                                            <asp:DropDownList ID="ddlTestYearTo" CssClass="txtarea" runat="server"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTestDayFrom"
                                                                                InitialValue="0" ErrorMessage="Select Test Day." Enabled="True" ToolTip="Select Test Day"
                                                                                CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                                Display="dynamic"></asp:RequiredFieldValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTestMonthFrom"
                                                                                InitialValue="0" ErrorMessage="Select Test Month." Enabled="True" ToolTip="Select Test Month"
                                                                                CssClass="errorcontent Tab1" ValidationGroup="GetTestDetails" SetFocusOnError="true"
                                                                                Display="dynamic"></asp:RequiredFieldValidator>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTestYearFrom"
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
                                                            <asp:Button ID="btnGetTestDetails" runat="server" CssClass="button" Text="Get statewise candidates count" OnClick="btnSearch_Click" ValidationGroup="GetTestDetails" OnClientClick="javascript:return CheckManadatory();" CommandArgument="Submit"></asp:Button>&nbsp;
										                     <asp:Button ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click" EnableViewState="False" Text="Reset"></asp:Button>&nbsp;
										                    <asp:Button ID="btnBack" runat="server" CssClass="button" EnableViewState="False" OnClick="btnBack_Click" Text="Back"></asp:Button>&nbsp;
                                                             <asp:Button ID="btnExportToExcel" runat="server" CssClass="button" Text="Export To Excel" Visible="false" OnClick="btnExportToExcel_Click"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <b>
                                                                <asp:Label ID="lblMsgNoRecords" CssClass="small_maroon" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="5">
                                                            <b>
                                                                <asp:Label ID="lblTotalRecords" CssClass="small_maroon" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="WIDTH: 918px">
                                                            <asp:Panel ID="pnlSearch" runat="server">
                                                                <asp:DataGrid ID="dgSearch" runat="server" CssClass="main_black_small" Width="100%" Height="100%"
                                                                    GridLines="Vertical" CellPadding="3" BackColor="White" OnItemCreated="dgSearch_ItemCreated"
                                                                    OnItemCommand="dgSearch_ItemCommand" OnItemDataBound="dgSearch_ItemDataBound" OnPageIndexChanged="dgSearch_PageIndexChanged"
                                                                    BorderWidth="1px" BorderStyle="None" BorderColor="#999999" AutoGenerateColumns="False" OnSortCommand="dgSearch_SortCommand"
                                                                    ShowFooter="True" AllowSorting="True">
                                                                    <FooterStyle ForeColor="Blue" BackColor="White"></FooterStyle>
                                                                    <AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
                                                                    <ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
                                                                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
                                                                    <Columns>
                                                                        <asp:TemplateColumn>
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="chkHeader" CssClass="chkbox" onclick="CheckAll(this);" runat="server"></asp:CheckBox>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" runat="server"></asp:CheckBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn SortExpression="RegistrationId ASC" HeaderText="Registration Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRegistration" Text='<%#DataBinder.Eval(Container.DataItem,"RegistrationId")%>' runat="server">
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:BoundColumn DataField="FirstName" SortExpression="Name ASC" HeaderText="FirstName"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="MiddleName" SortExpression="Name ASC" HeaderText="MiddleName"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="LastName" SortExpression="Qualification ASC" HeaderText="LastName"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="City" SortExpression="City ASC" HeaderText="City"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Email Id" SortExpression="Email ASC" HeaderText="Email Id"></asp:BoundColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                                <input id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
                                                                    runat="server">
                                                            </asp:Panel>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                           <%-- <asp:Button ID="btnExportToExcel" runat="server" CssClass="button" Text="Export To Excel" Visible="false" OnClick="btnExportToExcel_Click"></asp:Button>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="landingFooter">
                                                                <uc1:nacyearlyfooter ID="nacyearlyfooter" runat="server"></uc1:nacyearlyfooter>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
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
