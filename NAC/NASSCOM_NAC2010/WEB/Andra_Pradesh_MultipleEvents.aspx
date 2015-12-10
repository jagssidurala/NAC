<%@ Page language="c#" Codebehind="Andra_Pradesh_MultipleEvents.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.Andra_Pradesh_MultipleEvents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Multiple Events</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="stylesheet/nasscomnew.css" type="text/css" rel="stylesheet">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<FORM id="frm" method="post" runat="server">
			<div align="center">
				<table border="0" id="table1" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellpadding="0" cellspacing="0" width="888">
								<TBODY>
									<tr>
										<td rowspan="9">
											&nbsp;</td>
										<td valign="top">
											<img src="Images/BANNERline.jpg"></td>
										<td rowspan="9" width="4">
											&nbsp;</td>
									</tr>
									<tr>
										<td vAlign="top" class="pageHeader" style="PADDING-TOP: 5px">
											NAC events at
											<asp:Label id="lblState" runat="server"></asp:Label>
										</td>
										<TD vAlign="top" align="right"><a style="FONT-WEIGHT: bold; TEXT-DECORATION: underline" Class="main_black" href="../NAC.aspx">Home</a></TD>
									</tr>
									<tr>
										<td valign="top">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td valign="top">
											&nbsp;
										</td>
									</tr>
									<tr>
										<td valign="top" style="HEIGHT: 20px" align="center">
											<asp:Repeater id="rptrLinks" runat="server">
												<ItemTemplate>
													<div>
														<div class="divEvent">
															<div class="left">
															<asp:Label id="Label1" runat="server" >Event <%#(((RepeaterItem)Container).ItemIndex+1).ToString() %>: </asp:Label>
															<asp:LinkButton style="text-decoration:none" ID="lnkbtnEvent" Runat="server" CommandName="DeleteComment" Font-Bold="True" Font-Name="Verdana" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "TestId") %>><%# DataBinder.Eval(Container.DataItem, "Name") %><br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Test Date:&nbsp;<%# DataBinder.Eval(Container.DataItem,"testdate","{0:dd MMM yyyy}") %></asp:LinkButton>
															</div>
															
															<div class="right">
															<div class="register"> 														
															<asp:LinkButton    id="btnRegister" runat="server" Text="Click here to register" CommandName="DeleteComment" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "TestId") %>>
															</asp:LinkButton>
															</div>
															</div>
															</div>
														<div>
															
														</div>
													</div>
													<br>
													<br>
												</ItemTemplate>
											</asp:Repeater></td>
									</tr>
									<tr>
										<td valign="top" align="center">
											<DIV class="landingFooter">
												<DIV class="divLeft"><A href="mailto:nac@nasscom.in"></A> &nbsp;</DIV>
											</DIV>
										</td>
									</tr>
								</TBODY>
							</table>
							<DIV class="divLeft"><IMG src="../web/Images/login_07.jpg"><A href="mailto:nac@nasscom.in"></A></DIV>
						</td>
					</tr>
				</table>
			</div>
		</FORM>
	</body>
</HTML>
