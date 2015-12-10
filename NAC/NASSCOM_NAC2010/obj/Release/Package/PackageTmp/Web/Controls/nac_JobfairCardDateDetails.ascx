<%@ Control Language="c#" AutoEventWireup="True" Codebehind="nac_JobfairCardDateDetails.ascx.cs" Inherits="NASSCOM_NAC.Web.Controls.nac_JobfairCardDateDetails" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE class="white_bg" cellSpacing="0" cellPadding="5" width="100%" border="0">
	<TBODY>
		<TR class="white_bg" vAlign="top" align="left">
			<TD align="center">
				<TABLE class="blue_bg" id="TblInterview" cellSpacing="0" cellPadding="5" width="100%" border="1"
					runat="server">
					<TR class="main_black" vAlign="top" align="left">
						<TD class="grey_bg" colSpan="2"><STRONG>INTERVIEW DATE </STRONG><STRONG></STRONG>
						</TD>
					</TR>
					<TR class="main_black" vAlign="top" align="left">
						<TD class="white_bg" align="center" width="22%"><INPUT type="checkbox" value="checkbox" name="checkbox"></TD>
						<TD class="white_bg" width="78%">
							<asp:Label id="lblDate1" Runat="server">date1</asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE class="blue_bg" id="TblInterview2" cellSpacing="0" cellPadding="5" width="100%"
					border="1" runat="server">
					<TR class="main_black" vAlign="top" align="left">
						<TD class="grey_bg" colSpan="2"><STRONG>INTERVIEW&nbsp;SCHEDULE </STRONG><STRONG></STRONG>
						</TD>
					</TR>
					<TR class="main_black" vAlign="top" align="left">
						<TD class="white_bg" align="left" width="22%">Date:</TD>
						<TD class="white_bg" width="78%">
							<asp:Label id="lblInterviewDate" runat="server"></asp:Label></TD>
					</TR>
					<TR class="main_black" vAlign="top" align="left">
						<TD class="white_bg" align="left" width="22%">Time:</TD>
						<TD class="white_bg" width="78%">
							<asp:Label id="lblInterviewTime" runat="server"></asp:Label></TD>
					</TR>
					<TR class="main_black" vAlign="top" align="left">
						<TD class="white_bg" align="left" width="22%">Venue:</TD>
						<TD class="white_bg" width="78%">
							<asp:Label id="lblVenue" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TBODY>
</TABLE>
