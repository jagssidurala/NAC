<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" Codebehind="MultipleRegistration.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.MultipleRegistration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Candidate Profiles</title>
	</HEAD>
	<BODY>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="756" align="center" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
						<td vAlign="top" align="center">
							<table class="black_bg" id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<tr class="white_bg" vAlign="top" align="left">
									<td align="right"><INPUT id="NoPrint" onclick="javascript:history.go(-1);" type="button" value="Back">
									</td>
								</tr>
							</table>
							<table class="black_bg" id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TBODY>
									<tr class="white_bg" vAlign="top" align="left">
										<td align="center">
											<asp:repeater id="rptCandidateList" runat="server">
												<ItemTemplate>
													<table width="100%" cellpadding="0" cellspacing="0">
														<tr class="blue_bg">
															<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Candidate Profile
															</td>
														</tr>
														<tr>
															<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;
															</td>
														</tr>
													</table>
													<table id="Table4" cellSpacing="0" cellPadding="3" width="85%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td class="lightblue_bg" colSpan="3"><strong>PERSONAL DETAILS</strong></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td width="43%">First Name:</td>
															<td width="55%"><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
															<td class="small_maroon" width="2%"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Middle Name:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "MiddleName") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Last Name:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Date of Birth:
															</td>
															<td><%# String.Format("{0:dd-MMM-yyyy}",Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateofBirth"))) %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Gender:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "Gender") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trResidentialAddress" runat="server" class="main_black" vAlign="top" align="left">
															<td>Residential Address:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "Address") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>City:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "City") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Pincode:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "Pincode") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trPhoneNumber" runat="server" class="main_black" vAlign="top" align="left">
															<td>Phone Number (Landline):
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "STDCode") %>
																-
																<%# DataBinder.Eval(Container.DataItem, "LandlinePhoneNo") %>
															</td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trCellphone" runat="server" class="main_black" vAlign="top" align="left">
															<td>Phone Number (Cellphone):
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "MobilePhone") %></td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Photograph:
															</td>
															<td>
																<asp:image id="imgUploadPhotograph" Runat="server" ImageUrl='<%# ValidateImage(Convert.ToString(DataBinder.Eval(Container.DataItem, "ImageFileName"))) %>' Width="120px">
																</asp:image>&nbsp;</td>
														</tr>
														<tr id="trEmailId" runat="server" class="main_black" vAlign="top" align="left">
															<td>Email ID:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "EmailId") %></td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr id="trMotherName" runat="server" class="main_black" vAlign="top" align="left">
															<td>Mother's Full Name:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "MotherName") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trFatherName" runat="server" class="main_black" vAlign="top" align="left">
															<td>Father's Full Name:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "FatherName") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trHouseHoldIncome" runat="server" class="main_black" vAlign="top" align="left">
															<td>Annual Household Income:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "IncomeRange") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>You belong to:
															</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "BelongTo") %>
															</td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Highest Educational Qualification:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "QualificationType") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Qualification Details:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "Qualification") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>College Name:</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "University") %>
															</td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Year of Passing:</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "HighEduYear") %>
															</td>
															<td class="small_maroon"></td>
														</tr>
														<!--<tr class="main_black" vAlign="top" align="left">															
															<td>Specialization in PG:</td>
															<td>
																<%# DataBinder.Eval(Container.DataItem, "PGSpecialization") %>
															</td>															
															<td class="small_maroon"></td>
														</tr>-->
														<tr class="main_black" vAlign="top" align="left">
															<td>College Address:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "CollegeAddress") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>City:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "EducationCity") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Aggregate Percentage Scored:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "MarksObtained") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Medium of Instruction upto 10th:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "MediumSchool") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Medium of Instruction in 12th:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "Medium12th") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Year of Passing 12th:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "PassingYear12Th") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td class="lightblue_bg" colSpan="3"><strong>PROFESSIONAL DETAILS</strong></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Employment Status:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "EmploymentStatus") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Current Location:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "CurrentLocation") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Language Skills:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "LanguageSkills") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Willing to work out of hometown:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "OutsideHome") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Passport No:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "passportNo") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td class="lightblue_bg" colSpan="3"><strong>NAC TEST DETAILS</strong></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Test City:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "TestCity") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Test Centre:
															</td>
															<td><%# DataBinder.Eval(Container.DataItem, "TestCentre") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr id="trSecurity" runat="server" class="main_black" vAlign="top" align="left">
															<td class="lightblue_bg" colSpan="3"><strong> SECURITY </strong>
															</td>
														</tr>
														<tr id="Password" runat="server" class="main_black" vAlign="top" align="left">
															<td>Password:</td>
															<td>
																<asp:label id="lblPassword" Runat="Server" Text='<%# DataBinder.Eval(Container.DataItem, "Password") %>'>
																</asp:label></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trPhotoIdDocument" runat="server" class="main_black" vAlign="top" align="left">
															<td>Photo-ID document:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "PhotoIdDocument") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr id="trPhotoIdNumber" runat="server" class="main_black" vAlign="top" align="left">
															<td>Photo ID Document Number:</td>
															<td><%# DataBinder.Eval(Container.DataItem, "PhotoIdNo") %></td>
															<td class="small_maroon"></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>&nbsp;</td>
															<td>&nbsp;</td>
															<td class="small_maroon">&nbsp;</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<!--<td class="small_maroon" colspan="3" align="center">
																<asp:Label id="lblMessage" runat="server" Width="528px">Once you click 'SAVE', you will not be allowed to make any changes in the registration form</asp:Label></td>-->
														</tr>
														<tr class="main_black" vAlign="top" align="center">
															<!--	<td colSpan="3">
																<asp:button id="btnEdit" runat="server" Text="Edit"></asp:button>&nbsp;
																<asp:button id="btnSubmit" runat="server" Text="Save"></asp:button>&nbsp;
																<asp:button id="btnPrint" runat="server" Text="Print"></asp:button>
															</td> -->
														</tr>
													</table>
												</ItemTemplate>
											</asp:repeater>
											<asp:Literal id="ltReloadScript" runat="server"></asp:Literal>
											<br>
										</td>
									</tr>
									<!--<tr class="white_bg" vAlign="top" align="left">
										<td>&nbsp;
											<uc1:nac_footer id="Nac_footer2" runat="server"></uc1:nac_footer></td>
									</tr>--></TBODY>
							</table>
						</td>
						<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					</tr>
				</TBODY>
			</table>
			</TD></TD> 
			<!--<tr class="white_bg" vAlign="top" align="left">
				<td><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></td>
			</tr>--> 
			</TBODY></TABLE></TD>
			<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
			</TR></TBODY></TABLE></form>
	</BODY>
</HTML>
