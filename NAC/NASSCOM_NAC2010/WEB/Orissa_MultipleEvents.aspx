<%@ Page language="c#" Codebehind="Orissa_MultipleEvents.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.Orissa_MultipleEvents" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>Orissa_MultipleEvents</title>
   <LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="stylesheet/nasscomnew.css" type="text/css" rel="stylesheet">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
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
										<img src="Images/BANNER.jpg" width="957"></td>
									<td rowspan="9" width="4">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<h1>
											&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td valign="top">
									</td>
								</tr>
								<tr>
									<td valign="top" style="HEIGHT: 20px" align="center">&nbsp;
										<asp:Repeater id="rptrLinks" runat="server">
											<ItemTemplate>
												<table width="100%" border="1" bordercolor="#FF9933" cellpadding="5" cellspacing="0" id="tblLinks">
													<tr>
														<td colspan="2" id="Td1" align="left" valign="top" bgcolor="#FFCC33" class="big_red">
														<a href="Orissa_SingleEvent.aspx?code=<%# DataBinder.Eval(Container.DataItem, 'TestId') %>">
														
														<%# DataBinder.Eval(Container.DataItem, "Name") %>
															
															</a>
														</td>
													</tr>
												</table>
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
	</body>
</HTML>
