<%@ Page language="c#" Codebehind="RegistrationPreview.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.RegistrationPreview" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<script type="text/javascript">
			function noBack(){window.history.forward()}
			noBack();
			window.onload=noBack;
			window.onpageshow=function(evt){if(evt.persisted)noBack()}
			window.onunload=function(){void(0)}
		</script>
		
		<script language="JavaScript" type="text/JavaScript">		 
			 
			function PrintReport()
			{
				print();
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
              <div class="outerbody" align="center">		
		
									 <uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Candidate Profile</h2>

                    


                    <table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">


							<tr class="white_bg" vAlign="top" align="left">
								<td align="center"><br>
									<table id="Table4" cellSpacing="0" cellPadding="3" width="100%" border="0">
										<tr class="main_black" vAlign="top" align="left">
											<td class="small_maroon" colSpan="3">This page shows the details you filled in the 
												registration form. If you want to change any of the details, please click EDIT. 
												If you want to proceed further and save the details, please click SAVE</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>PERSONAL DETAILS&nbsp;<asp:label id="lblExistMessage" ForeColor="Red" Font-Bold="True" Runat="server"></asp:label></strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td width="43%">First Name:</td>
											<td width="55%"><asp:label id="lblFirstName" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon" width="2%"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Middle Name:
											</td>
											<td><asp:label id="lblMiddleName" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Last Name:</td>
											<td><asp:label id="lblLastName" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Date of Birth:
											</td>
											<td><asp:label id="lblDOB" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Gender:</td>
											<td><asp:label id="lblGender" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Residential Address:
											</td>
											<td><asp:label id="lblResidentialAddress" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>City:</td>
											<td><asp:label id="lblCity" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Pincode:</td>
											<td><asp:label id="lblPin" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Phone Number (Landline):
											</td>
											<td><asp:label id="lblPhoneNumber" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Phone Number (Cellphone):
											</td>
											<td><asp:label id="lblCellPhone" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td style="HEIGHT: 20px">Photograph:
											</td>
											<td style="HEIGHT: 20px"><asp:label id="lblPhoto" runat="server" Width="48px"></asp:label></td>
											<td class="small_maroon" style="HEIGHT: 20px">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Email Id:
											</td>
											<td><asp:label id="lblEmailId" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Mother's Full Name:
											</td>
											<td><asp:label id="lblMotherName" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Father's Full Name:
											</td>
											<td><asp:label id="lblFatherName" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Annual Household Income:
											</td>
											<td><asp:label id="lblAnnualHouseholdIncome" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>You belong to:
											</td>
											<td><asp:label id="lblBelongTo" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Highest Educational Qualification:
											</td>
											<td><asp:label id="lblHEQ" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Qualification Details:
											</td>
											<td><asp:label id="lblQualification" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><asp:label id="lblCollege" runat="server">Label</asp:label></td>
											<td><asp:label id="lblHEObtainedFrom" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><asp:label id="lblHighEduYear" runat="server">Label</asp:label></td>
											<td><asp:label id="lblGraduationYear" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr id="dvPGSpecialization" class="main_black" vAlign="top" align="left" runat="server">
											<td>Specialization in PG:
											</td>
											<td><asp:label id="lblPGSpecialization" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>College Address:
											</td>
											<td><asp:label id="lblCollegeAddress" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>City:</td>
											<td><asp:label id="lblHEOFCity" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Aggregate Percentage Scored:</td>
											<td><asp:label id="lblPercentageScored" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Medium of Instruction upto 10th:</td>
											<td><asp:label id="lblMediumTenth" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Medium of Instruction in 12th:</td>
											<td><asp:label id="lblMediumTwelve" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Year of Passing 12th:</td>
											<td><asp:label id="lblYearOfPassing12Th" Runat="server" Text=""></asp:label></td>
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
											<td><asp:label id="lblEmploymentStatus" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Current Location:</td>
											<td><asp:label id="lblCurrentLocation" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Language Skills:</td>
											<td><asp:label id="lblLanguageSkills" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Willing to work out of hometown:</td>
											<td><asp:label id="lblWTWOutOfHomeTown" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Do You Have a Passport:</td>
											<td><asp:label id="lblHavePassport" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td id="dvPassport" runat="server">Passport No:</td>
											<td><asp:label id="lblPassportNo" Runat="server" Text=""></asp:label></td>
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
											<td><asp:label id="lblTestCity" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Test Centre:
											</td>
											<td><asp:label id="lblTestCentre" Runat="server" Text=""></asp:label><asp:label id="lblCentreText" Runat="server"></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>SECURITY </strong>
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Password:</td>
											<td><asp:label id="lblPassword" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Photo-ID document:</td>
											<td><asp:label id="lblPhotoIDDocument" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Photo Id Document Number:</td>
											<td><asp:label id="lblPhotoIdNo" Runat="server" Text=""></asp:label></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="small_maroon" align="center" colSpan="3"><asp:label id="lblMessage" runat="server" Width="528px">Once you click 'SAVE', you will not be allowed to make any changes in the registration form</asp:label></td>
										</tr>
										<tr class="main_black" vAlign="top" align="center">
											<td colSpan="3"><asp:button id="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click"></asp:button>&nbsp;
												<asp:button id="btnSubmit" runat="server" Text="Save" onclick="btnSubmit_Click"></asp:button>&nbsp;
												<asp:button id="btnPrint" runat="server" Text="Print"></asp:button></td>
										</tr>
									</table>
									<asp:literal id="ltReloadScript" runat="server"></asp:literal><br>
								</td>
							</tr>

                   
			                </table>
                            </div>
                            </div>

                            <div class="footer">  <img src="Images/footer2014.gif" /></div>
            </div>

           </form>
	</body>
</HTML>
