<%@ Page language="c#" Codebehind="ExportCLToExcelByETS.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.ExportCLToExcelByETS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CandidateListToExcel</title>
		<%
		    Response.Clear();
			Response.Buffer = true;
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment:filename=ReportToExcelAllExtNo.xls");
			Response.Flush();
		%>
		<style type="text/css">
		   
		    .ExlsTableFormHeaderFont { FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #990000; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #e0e0e0; TEXT-ALIGN: center }
		   
		    .ExlsTableInnerTable { BORDER-RIGHT: #dadada 1pt solid; BORDER-TOP: #dadada 1pt solid; BORDER-LEFT: #dadada 1pt solid; COLOR: #000000; BORDER-BOTTOM: #dadada 1pt solid; FONT-FAMILY: Verdana; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: #ffffff }
		   
		    .ExlsTableDataGridBody { BORDER-RIGHT: white 1px solid; BORDER-TOP: white 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: white 1px solid; COLOR: #990000; BORDER-BOTTOM: white 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #f5f4f4 }
		   
		    </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width="100%" border="0">
				<tr valign="top">
					<td width="100%" valign="top">
						<asp:DataGrid id="dgCandidateList" CssClass="ExlsTableDataGridBody" AutoGenerateColumns="False"
													AllowPaging="False" runat="server" EnableViewState="False" ShowFooter="True">
													<FooterStyle BorderWidth="0px" ForeColor="White" BackColor="#000084"></FooterStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084" Height="20px"></HeaderStyle>
													<Columns>
													  <asp:BoundColumn DataField="Candidate Id" HeaderText="Candidate ID" HeaderStyle-Height="5px"></asp:BoundColumn>
													  <asp:BoundColumn DataField="UserId" HeaderText="UserId" HeaderStyle-Height="5px"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Registration Id" HeaderText="Registration ID" HeaderStyle-Height="5px"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Password" HeaderText="Password"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Registration Date" HeaderText="Registration Date"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Registration Time" HeaderText="Registration Time"></asp:BoundColumn>
													  <asp:BoundColumn DataField="First Name" HeaderText="First Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Middle Name" HeaderText="Middle Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Last Name" HeaderText="Last Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Date Of Birth" HeaderText="Date Of Birth"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Gender" HeaderText="Gender"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Residential Address" HeaderText="Residential Address"></asp:BoundColumn>
													  <asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Pincode" HeaderText="Pincode"></asp:BoundColumn>
													  <asp:BoundColumn DataField="STD Code" HeaderText="STD Code"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Phone Number(Landline)" HeaderText="Phone Number(Landline)"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Phone Number(Cellphone)" HeaderText="Phone Number(Cellphone)"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Email Id" HeaderText="Email ID"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Mothers Full Name" HeaderText="Mothers Full Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Fathers Full Name" HeaderText="Fathers Full Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Annual Household Income" HeaderText="Annual Household Income"></asp:BoundColumn>
													  <asp:BoundColumn DataField="BelongTo" HeaderText="BelongTo"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Highest Educational Qualification" HeaderText="Highest Educational Qualification"></asp:BoundColumn>
													  <asp:BoundColumn DataField="College Name" HeaderText="College Name"></asp:BoundColumn>
													  <asp:BoundColumn DataField="College Address" HeaderText="College Address"></asp:BoundColumn>
													  <asp:BoundColumn DataField="College City" HeaderText="College City"></asp:BoundColumn>													 
													  <asp:BoundColumn DataField="Qualification Details" HeaderText="Qualification Details"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Aggregate Percentage Scored" HeaderText="Aggregate Percentage Scored"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Medium of Instruction Up to 10th" HeaderText="Medium of Instruction Up to 10th"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Medium of Instruction in 12th" HeaderText="Medium of Instruction in 12th"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Employment Status" HeaderText="Employment Status"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Willing to work out of hometown" HeaderText="Willing to work out of hometown"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Test City" HeaderText="Test City"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Test Centre" HeaderText="Test Centre"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Test State" HeaderText="Test State"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Photo-Id Document" HeaderText="Photo ID Document"></asp:BoundColumn>
													  <asp:BoundColumn DataField="Photo-Id Document Number" HeaderText="Photo ID Document Number"></asp:BoundColumn>
													</Columns>
												</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>	