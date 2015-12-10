<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Page language="c#" Codebehind="APInstruction.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.APInstruction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sample Form</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                text-decoration: none;
            }
            .style2
            {
                height: 21px;
            }
        </style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">


        <!--
			<table id="Table1" cellSpacing="0" cellPadding="0" width="756" align="center" border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">&nbsp;&nbsp;INSTRUCTIONS FOR FILLING UP THE 
									REGISTRATION FORM
								</td>
							</tr>-->
            			 <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">INSTRUCTIONS FOR FILLING UP THE 
									REGISTRATION FORM</h2>
                            <table id="Table3" cellSpacing="0" cellPadding="0" width="756" align="center" border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td align="left"><br>
									<table id="Table4" cellSpacing="0" cellPadding="3" width="85%" border="0">
										<TR>
											<TD class="small_maroon" colSpan="2">
											</TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>PERSONAL DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>First Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your first name (takes up to 30 characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Middle Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your middle name, if any (takes up to 30 characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Last Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your last name / surname (takes up to 30 characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Date of Birth</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the day, month and year of your birth</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Gender</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the gender</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Residential Address</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your permanent residential address</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>City</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your residence city</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Pincode</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put pincode of your residence city (takes up to 6 numeric characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Phone Number (Landline)</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your landline contact number (STD code in first field - up to 6 numeric 
												characters and Telephone Number in the second field - up to 10 numeric 
												characters).</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Phone Number (Cellphone)</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your cellphone number, if any (takes up to 15 numeric characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Upload Photograph</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Upload photograph from your computer, which will reflect on your NAC Admission Card. It must not be more than 1MB and must be in .jpg, .gif or .jpeg format only.</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Email ID</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Use only valid email ID (e.g. abc@yahoo.com). This may be used later for 
												communication purposes.</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Mother's Full Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your mother’s full name (DO NOT put titles like Ms. / Mrs. / Smt.)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Father's Full Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your father's full name (DO NOT put titles like Mr. / Sh.)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Annual Household Income</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select your annual household income from the dropdown</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>You belong to</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the correct option</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Highest Educational Qualification</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="style2">Select your highest educational qualification from the dropdown list</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Your College Name</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put your college name (takes up to 50 characters)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Your College Address</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put complete address of your college with pincode</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>College City</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put the city where your college is located</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Qualification Details</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select your qualification from the dropdown. If the list does not have your 
												qualification listed, please select others and put your qualification detail in 
												'specify others' box</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Aggregate Percentage Scored</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put the aggregate percentage that you scored in your highest qualification (DO 
												NOT put '%' sign in the box)</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Medium of Instruction upto 10<SUP>th</SUP></strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the language of medium of instruction that you had up to standard 10th</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Medium of Instruction upto 12<SUP>th</SUP></strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the language of medium of instruction that you had up to standard 12<SUP>th</SUP>
											</td>
										</tr>

                                        <tr class="main_black" vAlign="top" align="left">
											<td><strong>Year of passing 12<SUP>th</SUP> </strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the appropriate year
											</td>
										</tr>


										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>PROFESSIONAL DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Employment Status</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select the appropriate option</td>
										</tr>

                                        <tr class="main_black" vAlign="top" align="left">
											<td><strong>Current Location</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put the name of city where you presently stay</td>
										</tr>


                                        <tr class="main_black" vAlign="top" align="left">
											<td><strong>Language Skills</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Mention languages that you are proficient with, e.g. English, Hindi, Malayalam, etc.</td>
										</tr>



										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Willing to work out of hometown</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>If you are willing to work out of your current residential placeshift to a different city for work – please select YES; otherwise select NO</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>NAC TEST DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Test City</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Test city has already been allocated to you (as shown in the Registration Form) 
												- hence NO changes can be made to that.
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Test Centre</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Test centre has already been allocated to you (as shown in the Registration 
												Form) - hence NO changes can be made to that.<br>
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>SECURITY </strong>
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Password</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Password should be 6-12 characters and must contain only alphabets and numeric. ALWAYS REMEMBER this password as you would require this 
												for future references as well.</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Confirm Password</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Confirm the password that you filled in the previous box</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Select a photo-ID document</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select one of the photo-idID document that you have with you. You will be required to bring this to the test centre at the time of the test examination for verification purpose.</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td><strong>Photo-Id Document Number</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Put the unique number printed on the photo-id document that you selected.</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td align="left">
												<span class="main_black"><b>In case you face any technical problem/error while filling 
														up the form, please write to us by </b></span><A href="ContactUs.aspx" 
                                                    class="style1">
													<strong>CLICKING HERE</strong></A>.
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="center">
											<td colSpan="3"><asp:button id="btnClose" runat="server" Text="Close"></asp:button>&nbsp;</td>
										</tr>




									</table>

                                     </div>
            </div> 
                       

   
           

               <div class="footer">  <img src="Images/footer2014.gif" /></div>
            </div>
								</td>
							</tr>


							<!--<tr class="white_bg" vAlign="top" align="left">
								<td><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
			</table>-->
		</form>
	</body>
</HTML>
