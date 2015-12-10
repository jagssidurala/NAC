<%@ Page language="c#" Codebehind="GenerateJobAdmitCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.GenerateJobAdmitCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>Job Fair Admit Card</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">
			function PrintReport()
			{
				print();
			}
			</script>
	</HEAD>
	<body bgProperties="fixed">
		<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
			<tr>
				<td vAlign="top" align="right">
					<div id="NoPrint"><INPUT id="iPrint" onclick="PrintReport();" type="button" value="Print" runat="server"
							NAME="iPrint"><INPUT id="goBack" runat="server" onclick="javascript:history.go(-1);" type="button" value="Back"
							NAME="goBack"></div>
					<asp:repeater id="rptAdmitCard" Runat="server">
						<ItemTemplate>
							<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
								<tr>
									<td width="7" align="center" valign="top" background="images/tbg_left.gif"><img src="images/spacer.gif" width="7" height="1"></td>
									<td align="center" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="1" class="black_bg">
											<tr align="left" valign="top" class="white_bg">
												<td align="center" class="grey_bg main_black"><h1><br>
														NAC
														<asp:Label id="lblState" Runat="server"></asp:Label><br>
														<u>Job Interview Admit Sheet</u></h1>
													Please carry this sheet to all company interviews for admission, attendance and 
													company signature
													<br>
													<u>DO NOT hand it over to any company</u><br>
													After attending all the assigned interviews, you are free to attend other 
													company interview
													<br>
													depending on time availability/company permission
													<br>
													<br>
												</td>
											</tr>
											<tr align="left" valign="top" class="white_bg">
												<td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="6">
														<tr>
															<td width="76%" align="left" valign="top"><table width="100%" border="1" cellpadding="5" cellspacing="0" class="blue_bg">
																	<tr align="left" valign="top" class="main_black">
																		<td class="lightblue_bg"><strong>GROUP</strong></td>
																		<td class="lightblue_bg"><strong>TIER 1 </strong>
																		</td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td width="52%" class="white_bg">Reg. ID:</td>
																		<td width="48%" class="white_bg"><%# DataBinder.Eval(Container.DataItem, "RegistrationId") %></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Name:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "FullName") %></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Gender:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "Gender") %></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">City:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "City") %></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Highest Education:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "Qualification")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Medium of Instruction (upto 10th):</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "MediumSchool")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Medium of Instruction (upto 12th):</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "Medium12th")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Employment Status:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "EmploymentStatus")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Willing to relocate:</td>
																		<td class="white_bg"><%# DataBinder.Eval(Container.DataItem, "Relocate")%></td>
																	</tr>
																</table>
																<br>
																<table width="100%" border="1" cellpadding="5" cellspacing="0" class="blue_bg">
																	<tr align="left" valign="top" class="main_black">
																		<td colspan="2" class="lightblue_bg"><strong>SCORE</strong><strong></strong></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td width="52%" class="white_bg">Analytical &amp; Quantitative:</td>
																		<td width="48%" class="white_bg">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Analytical")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Listening:</td>
																		<td class="white_bg">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Listening")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Writing:</td>
																		<td class="white_bg">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Writing")%></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td class="white_bg">Speaking:</td>
																		<td class="white_bg">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Speaking")%></td>
																	</tr>
																</table>
															</td>
															<td width="24%" align="left" valign="top"><table width="100%" border="1" cellpadding="5" cellspacing="0" class="blue_bg">
																	<tr align="left" valign="top" class="main_black">
																		<td colspan="2" class="lightblue_bg"><strong>INTERVIEW DATE </strong><strong></strong>
																		</td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td width="22%" align="center" class="white_bg"><input type="checkbox" name="checkbox" value="checkbox"></td>
																		<td width="78%" class="white_bg">
																			<asp:Label id="lblDate1" Runat="server">date1</asp:Label></td>
																	</tr>
																	<tr align="left" valign="top" class="main_black">
																		<td align="center" class="white_bg"><input type="checkbox" name="checkbox2" value="checkbox"></td>
																		<td class="white_bg">
																			<asp:Label id="lblDate2" Runat="server">date2</asp:Label></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr align="left" valign="top" class="white_bg">
												<td align="center"><br>
													<table width="100%" border="1" cellpadding="5" cellspacing="0" class="blue_bg">
														<tr align="left" valign="top" class="main_black">
															<td colspan="2" valign="middle" class="lightblue_bg"><strong>Name of the Company</strong><strong></strong></td>
															<td align="center" valign="middle" class="lightblue_bg"><strong>Attended<br>
																	(yes / no)</strong></td>
															<td align="center" valign="middle" class="lightblue_bg"><strong>Authorised Company 
																	Signature</strong></td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td width="4%" class="white_bg">1.</td>
															<td width="46%" class="white_bg">&nbsp;</td>
															<td width="14%" class="white_bg">&nbsp;</td>
															<td width="36%" class="white_bg">&nbsp;</td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td class="white_bg">2.</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td class="white_bg">3.</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td class="white_bg">4.</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td class="white_bg">5.</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
														</tr>
														<tr align="left" valign="top" class="main_black">
															<td class="white_bg">6.</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
															<td class="white_bg">&nbsp;</td>
														</tr>
													</table>
													<br>
													<br>
												</td>
											</tr>
										</table>
									</td>
									<td width="7" align="center" valign="top" background="images/tbg_right.gif"><img src="images/spacer.gif" width="7" height="1"></td>
								</tr>
							</table>
						</ItemTemplate>
					</asp:repeater>
				</td>
			</tr>
		</table>
	</body>
</HTML>
