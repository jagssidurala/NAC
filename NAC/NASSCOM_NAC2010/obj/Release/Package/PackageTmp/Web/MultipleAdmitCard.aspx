<%@ Page language="c#" Codebehind="MultipleAdmitCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.MultipleAdmitCard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD id="Head1">
		<title>Admit Card</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">
			function PrintReport()
			{
				print();
			}
			</script>
			<style type="text/css">
				BODY { MARGIN: 0px }
				</style>
	</HEAD>
	<body bgproperties="fixed">
		<form id="form1" runat="server">
			<div>
				<table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
					<tr>
						<td width="620" height="600" align="right" valign="middle">
							<INPUT id="NoPrint" type="button" value="Print" onclick="PrintReport();"><INPUT id="NoPrint" onclick="javascript:history.go(-1);" type="button" value="Back">&nbsp;<br>
							<asp:repeater id="rptAdmitCard" Runat="server">
								<ItemTemplate>
									<table class="black_bg" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="white_bg" height="12" align="center">
											</td>
										</tr>
										<tr>
											<td class="white_bg" height="50px" align="center">&nbsp;</td>
										</tr>
										<tr class="white_bg" vAlign="top" align="left">
											<td align="right">
												<!-- Table2 Start -->
												<table class="blue_bg" align="left" cellSpacing="0" cellPadding="0" width="100%" border="1">
													<tr>
														<td class="white_bg" vAlign="top" align="left">
															<!-- Table3 Start -->
															<table align="left" cellSpacing="0" width="620" cellPadding="0" width="0" border="0">
																<tr>
																	<td vAlign="middle" align="left" width="620px" height="600px" style="background-repeat:no-repeat;background-position:1px;"
																		background="images/NAC_water1.jpg">
																		<!-- Table4 Start -->
																		<table cellSpacing="0" cellPadding="7" width="100%" border="0">
																			<tr>
																				<td vAlign="top" align="left"><IMG src="images/logo2.gif"></td>
																			</tr>
																			<tr>
																				<td vAlign="top" align="left">&nbsp;</td>
																			</tr>
																			<tr>
																				<td vAlign="top" align="center">
																					<h1>NAC - NASSCOM Assessment of Competence
																					</h1>
																				</td>
																			</tr>
																			<tr>
																				<td vAlign="top" align="center"><h2>Admission Card</h2>
																				</td>
																			</tr>
																			<tr>
																				<%if(stateName =="Hero Mindmine" || stateName =="Sona College" ){%>
																				<td class="main_blue_bold" vAlign="top" align="center"><u>
																						<%# DataBinder.Eval(Container.DataItem, "State") %>
																					</u>
																				</td>																				
																				<%} else {%>
																				<td class="main_blue_bold" vAlign="top" align="center"><u>
																						<%# "State of " + DataBinder.Eval(Container.DataItem, "State") %>
																					</u>
																				</td>
																				<%}%>
																			</tr>
																			<tr>
																				<td vAlign="top" align="left">&nbsp;</td>
																			</tr>
																			<tr>
																				<td class="small_blue" vAlign="top" align="center">
																					<table cellSpacing="1" cellPadding="3" width="80%" border="0">
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Registration ID: </strong>
																							</td>
																							<td width="60%">
																								<%# DataBinder.Eval(Container.DataItem, "RegistrationId") %>
																							</td>
																							<TD width="60%" rowSpan="8">
																								<asp:image id="imgUploadPhotograph" Runat="server" ImageUrl='<%# ValidateImage(Convert.ToString(DataBinder.Eval(Container.DataItem, "ImageFileName"))) %>' Width="120px">
																								</asp:image></TD>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Name:</strong></td>
																							<td width="60%">
																								<%# DataBinder.Eval(Container.DataItem, "FullName") %>
																							</td>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Date of Birth: </strong>
																							</td>
																							<td width="60%"><%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DOB"))) %>
																							</td>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Gender: </strong>
																							</td>
																							<td width="60%">
																								<asp:Label Id="lblGender1" Runat="server"></asp:Label>
																								<%# DataBinder.Eval(Container.DataItem, "Gender") %>
																							</td>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td noWrap width="40%"><strong>Highest Education<br>
																									Qualification: </strong>
																							</td>
																				<%if(otherQualification =="Others"){%>
																					<td width="60%">
																						<%# DataBinder.Eval(Container.DataItem, "OtherQualification") %>
																					</td>																				
																				<%} else {%>
																					<td width="60%">
																						<%# DataBinder.Eval(Container.DataItem, "Qualification") %>
																					</td>
																				<%}%>
																							<!--<td width="60%">
																								<%# DataBinder.Eval(Container.DataItem, "Qualification") %>
																							</td>-->
																						</tr>
																						<tr vAlign="top" align="left">
																							<td width="40%" valign="top"><strong>Test Centre: </strong>
																							</td>
																							<td width="60%">
																								<%# DataBinder.Eval(Container.DataItem, "Centre") %>
																								<br />
																								<%# DataBinder.Eval(Container.DataItem, "CentreAddress") %>
																							</td>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Test City: </strong>
																							</td>
																							<td width="60%">
																								<%# DataBinder.Eval(Container.DataItem, "City") %>
																							</td>
																						</tr>
																						<tr vAlign="middle" align="left">
																							<td width="40%"><strong>Test Date:</strong></td>
																							<td width="60%">
																								<%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TestDate"))) %>
																								<%# ChangeTimeFormat(String.Format("{0:hh:mm tt}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "TestTime")))) %>
																							</td>
																						</tr>
																					</table>
																					<br>
																					<table cellSpacing="1" cellPadding="3" width="80%" border="0">
																						<tr vAlign="middle" align="left">
																							<td width="60%"></td>
																							<td class="main_blue_bold" align="right" width="40%">Candidate's Signature</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																			<TR>
																				<TD vAlign="top" align="left" height="20"></TD>
																			</TR>
																			<tr>
																				<td vAlign="top" align="left">&nbsp;</td>
																			</tr>
																			<tr>
																				<td class="main_blue_bold" vAlign="top" align="left">Important Points
																				</td>
																			</tr>
																			<tr>
																				<td vAlign="top" align="left">
																					<ol class="small_grey" type="1">
																						<li>
																						Do take a printout of your NAC Admit Card (A4 size / portrait).
																						<LI>
																						Paste your recent color passport-size photo in the given space (in case you 
																						have not uploaded it already) and sign the admission card in the given space.
																						<LI>
																							<u><strong>It is mandatory to carry to the test centre your NAC Admission Card and the 
																									Photo-ID Document, which you mentioned about, in your registration form. 
																									Failing this, you will not be allowed to sit for the test.</strong></u>
																						<LI>
																						Your photograph on the admission card must match the one on the photo-ID 
																						document.
																						<LI>
																						In case of loss of the Admission Card, the candidate must visit the website 
																						(www.nac.nasscom.in) and print the Admission Card again.
																						<LI>
																						Candidates are requested to report at the test centre at least 30 minutes 
																						before the test timing.
																						<LI>
																						Do not use pen to write/mark on any sheet, that is given to you at the test center, without invigilator's permission.
																						<LI>
																						Candidates should carry their own pencils (HB lead) with eraser and sharpener. 
																						Test centers shall not be providing the same.
																						<LI>
																							For any queries, please get in touch with the nodal agency for NAC in your 
																							state.
																						</LI>
																					</ol>
																					<br />
																					<div align="left" class="main_blue_bold">To view your profile - please visit <a href="#">
																							www.nac.nasscom.in</a></div>
																				</td>
																			</tr>
																		</table>
																		<!-- Table4 End -->
																	</td>
																</tr>
															</table>
															<!-- Table3 End -->
														</td>
													</tr>
												</table>
												<!-- Table2 End -->
											</td>
										</tr>
										<asp:label id="lblBlanSpacer" runat="server"></asp:label>
										<!--
										<tr>
											<td class="white_bg" height="50px" align="center">
											
											</td>
										</tr>
										<tr>
											<td class="ContentPrint" height="50px" align="center">&nbsp;</td>
										</tr>
										-->
									</table>
								</ItemTemplate>
							</asp:repeater>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
