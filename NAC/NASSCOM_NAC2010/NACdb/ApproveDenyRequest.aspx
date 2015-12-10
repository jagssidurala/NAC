<%@ Page language="c#" Codebehind="ApproveDenyRequest.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.ApproveDenyRequest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Approve/Deny Pending Request</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="../Web/Stylesheet/nasscomNew.css" type="text/css">
		<script>

	function new_window(url)
	{
		newwindow=window.open(url,'Feedback','top=50,left=200,width=380,height=70,scrollbars=no');
		newwindow.focus();
	}
	
	function new_window_profile(url)
	{
		newwindow=window.open(url,'Feedback','top=50,left=200,width=888,height=330,scrollbars=no');
		newwindow.focus();
	}
	
	 function confirmApprove() 
	 {
		return confirm("Are you sure you want to approve?");
     }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<table border="0" id="table1" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td rowspan="9">
										&nbsp;</td>
									<td valign="top">
										<img src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td rowspan="9" width="4">
										&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" style="WIDTH: 918px">&nbsp;&nbsp;<A class="link" href="AdminHome.aspx" style="WIDTH: 0%; HEIGHT: 14px">Home</A>
										<h1>&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td valign="top">
										<h1>
											&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td valign="top" align="center">
										<table width="100%">
											<tr>
												<td class="pageheader" align="center"><FONT size="4"><STRONG>Pending Requests</STRONG></FONT>
												</td>
											</tr>
											<tr>
												<td>&nbsp;</td>
											</tr>
											<tr>
												<td align="center" colSpan="1" rowSpan="1">
													<asp:datagrid CssClass="main_black" id="dgPendingRequest" runat="server" AutoGenerateColumns="False">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
															BorderColor="Black" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="S.No.">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<%# Container.ItemIndex+1 %>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="CompanyId" Visible="false"></asp:BoundColumn>
															<asp:BoundColumn DataField="SPOCEmail" Visible="false"></asp:BoundColumn>
															<asp:BoundColumn DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
															<asp:BoundColumn DataField="CompanyName" HeaderText="CompanyName"></asp:BoundColumn>
															<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="">
																<ItemTemplate>
																	<button class="button" onclick="new_window('./Approve.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>&Email=<%#DataBinder.Eval(Container, "DataItem.SPOCEmail") %>')">
																		Approve</button>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="">
																<ItemTemplate>
																	<button class="button" onclick="new_window('./RejectReason.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>&Email=<%#DataBinder.Eval(Container, "DataItem.SPOCEmail") %>')">
																		Reject</button>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center">
																<ItemTemplate>
																	<button class="button" onclick="new_window_profile('./CompanyProfile.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>')">
																		View Detail</button>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid>
													<asp:Label id="lblStatus" runat="server" CssClass="errormessage">No Pending Requests</asp:Label></td>
											<tr>
												<td align="center"><br>
													<asp:button id="btnBack" CssClass="button" runat="server" Text="Back" onclick="btnBack_Click"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top" style="HEIGHT: 20px">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../Web/Images/footer2014.gif"><A href="mailto:nac@nasscom.in"></A></DIV>
										</DIV>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
