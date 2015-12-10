<%@ Page language="c#" Codebehind="ViewAllMembers.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.ViewAllMembers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewAllMembers</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script type="text/javascript">

	function new_window(url)
	{
		newwindow=window.open(url,'CompanyDetail','top=50,left=200,width=888,height=330,scrollbars=yes,maximize=1,resizable=1');
		newwindow.focus();
	}
	function NewWindow(url)
	{
		newwindow=window.open(url,'EditCompanyDetail','top=50,left=200,width=500,height=330,scrollbars=no');
		newwindow.focus();
	}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
							<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" style="WIDTH: 918px">&nbsp;&nbsp;<A class="link" href="AdminHome.aspx" style="WIDTH: 0%; HEIGHT: 14px">Home</A>
										<h1>&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center">
									<table align="center" width="80%">
											<tr>
												<td align="center"><FONT size="4"><STRONG>
															<asp:Label id="Label1" runat="server" CssClass="pageheader">All Approved/Rejected members</asp:Label></STRONG></FONT></td>
											</tr>
											<tr>
												<td>&nbsp;</td>
											</tr>
											<tr>
												<td align="left">
													<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Approved Members</asp:Label>
												</td>
											</tr>
											<tr>
												<td align="center">
													<asp:DataGrid id="dgApprovedMembers" runat="server" AutoGenerateColumns="False" CssClass="main_black"
														Width="100%">
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
															<asp:BoundColumn DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
															<asp:BoundColumn DataField="CompanyName" HeaderText="CompanyName"></asp:BoundColumn>
															<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
															<asp:BoundColumn DataField="CompanyId" Visible="False"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center">
																<ItemTemplate>
																	<button class="button" onclick="new_window('./CompanyProfile.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>')">
																		View Detail</button>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center">
																<ItemTemplate>
																	<button class="button" onclick="new_window('./AdminEditCompanyDetail.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>')">
																		Edit Detail</button>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
											<tr><td>&nbsp;</td></tr>
											<tr>
												<td align="left">
													<asp:Label id="Label3" runat="server" CssClass="label_black_bold">Rejected Members</asp:Label>
												</td>
											</tr>
											<tr>
												<td align="center">
													<asp:DataGrid id="dgRejectedMembers" runat="server" AutoGenerateColumns="False" CssClass="main_black"
														ForeColor="Black" Width="100%">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
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
															<asp:BoundColumn DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
															<asp:BoundColumn DataField="CompanyName" HeaderText="CompanyName"></asp:BoundColumn>
															<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
															<asp:BoundColumn DataField="RejectReason" HeaderText="Reject Reason"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center">
																<ItemTemplate>
																	<button class="button" onclick="new_window('./CompanyProfile.aspx?Id=<%#DataBinder.Eval(Container, "DataItem.CompanyId") %>')">
																		View Detail</button>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
											<tr><td>&nbsp;</td></tr>
											<tr>
												<td align="center">
													<asp:Button id="btnBack" runat="server" Text="Back"  CssClass="button" onclick="btnBack_Click"></asp:Button>
													
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
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
