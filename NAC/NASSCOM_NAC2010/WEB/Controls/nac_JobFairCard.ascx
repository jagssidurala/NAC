<%@ Control Language="c#" AutoEventWireup="True" Codebehind="nac_JobFairCard.ascx.cs" Inherits="NASSCOM_NAC.Web.Controls.nac_JobFairCard" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE class="blue_bg" cellSpacing="0" cellPadding="5" width="100%" border="1">
	<TBODY>
		<TR class="white_bg" vAlign="top" align="left">
			<TD align="center">
<BR>
				<table cellSpacing="0" cellPadding="0" width="100%" border="1">
					<asp:repeater id="rptCompanyDetail" Runat="server">
						<HeaderTemplate>
							<TR class="grey_bg" vAlign="top" align="left">
								<TD class="main_black" width="8%"><STRONG>S.No </STRONG>
								<TD class="main_black" width="32%"><STRONG>Name of the company</STRONG>
								<TD class="main_black" width="14%"><STRONG>Attended(Y/N)</STRONG></TD>
								<TD class="main_black" width="46%"><STRONG>Signature of company personnel</STRONG></TD>
							</TR>
						</HeaderTemplate>
						<ItemTemplate>
							<tr class="main_black" vAlign="top" align="left">
								<TD width="8%"><%# DataBinder.Eval(Container.DataItem, "SNo") %>&nbsp;</TD>
								<TD width="32%"><%# DataBinder.Eval(Container.DataItem, "Company Name") %>&nbsp;</TD>
								<TD width="14%"><%# DataBinder.Eval(Container.DataItem, "Attended") %>&nbsp;</TD>
								<TD width="46%"><%# DataBinder.Eval(Container.DataItem, "Signature") %>&nbsp;</TD>
							</tr>
						</ItemTemplate>
					</asp:repeater>
				</table>
 </TD>
		</TR>
	</TBODY>
</TABLE>
</TR></TBODY></TABLE>
			
