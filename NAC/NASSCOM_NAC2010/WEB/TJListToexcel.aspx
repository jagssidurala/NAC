<%@ Page language="c#" Codebehind="TJListToexcel.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TJListtoexcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TJListtoexcel</title>
		<%
		    Response.Clear();
			Response.Buffer = true;
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment:filename=VisitorExport.xls");
			Response.Flush();
		%>
		<style type="text/css">.ExlsTableFormHeaderFont { FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #990000; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #e0e0e0; TEXT-ALIGN: center }
	.ExlsTableInnerTable { BORDER-RIGHT: #dadada 1pt solid; BORDER-TOP: #dadada 1pt solid; BORDER-LEFT: #dadada 1pt solid; COLOR: #000000; BORDER-BOTTOM: #dadada 1pt solid; FONT-FAMILY: Verdana; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: #ffffff }
	.ExlsTableDataGridBody { BORDER-RIGHT: white 1px solid; BORDER-TOP: white 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: white 1px solid; COLOR: #990000; BORDER-BOTTOM: white 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #f5f4f4 }
	</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE cellSpacing="0" cellPadding="0" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD >
					<form id="Form1" method="post" runat="server">
						<TABLE cellSpacing="0" cellPadding="0" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD colSpan="2" rowSpan="2">
									<TABLE border="1">
										<tr vAlign="top">
											<td vAlign="top">
												<asp:datagrid id="dgTJVisitorList" runat="server" ShowFooter="True" EnableViewState="False" AllowPaging="False"
													CssClass="ExlsTableDataGridBody" AutoGenerateColumns="False">
													<FooterStyle BorderWidth="0px" ForeColor="White" BackColor="#666666"></FooterStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#666666"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderText="S.No.">
															<HeaderStyle HorizontalAlign="Center" />
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<%# Container.ItemIndex+1 %>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="RegistrationId ASC" HeaderText="Registration ID">
															<ItemTemplate>
																<asp:Label ID="lblRegistration" Text='<%#DataBinder.Eval(Container.DataItem,"RegistrationId")%>' Runat="server">
																</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="FName" HeaderText="First Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="MName" HeaderText="Middle Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="LName" HeaderText="Last Name"></asp:BoundColumn>
														<asp:BoundColumn DataField="Address" HeaderText="Residential Address"></asp:BoundColumn>
														<asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
														<asp:BoundColumn DataField="State" HeaderText="State"></asp:BoundColumn>
														<asp:BoundColumn DataField="STDCode" HeaderText="STD Code"></asp:BoundColumn>
														<asp:BoundColumn DataField="LandlinephoneNo" HeaderText="Phone Number(Landline)"></asp:BoundColumn>
														<asp:BoundColumn DataField="MobilePhone" HeaderText="Phone Number(Cellphone)"></asp:BoundColumn>
														<asp:BoundColumn DataField="EmailId" HeaderText="Email ID"></asp:BoundColumn>
														<asp:BoundColumn DataFormatString="{0:MM/dd/yyyy}" DataField="FirstClickdate" HeaderText="FirstClickdate"></asp:BoundColumn>
														<asp:BoundColumn DataField="NoOfClicks" HeaderText="No. of Clicks"></asp:BoundColumn>
														
													</Columns>
												</asp:datagrid>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
