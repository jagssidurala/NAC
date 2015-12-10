<%@ Page language="c#" Codebehind="NAC Application Form.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.NAC_Application_Form" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NAC Application Form</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css"> BODY { MARGIN: 0px } </style>
		<script language="JavaScript" type="text/JavaScript">
		function PrintReport()
		{
			print();
		}
		
		 
			
		</script>
		<link href="Stylesheet/nasscom_form.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" border="0" width="100%">
				<tr valign="top">
					<td align="center" valign="top">
						<INPUT id="NoPrintTop" onclick="PrintReport();" type="button" value="PRINT" name="button">&nbsp;<asp:Button id="btnSaveTop" Text="SAVE" Runat="server" onclick="btnSaveTop_Click"></asp:Button>&nbsp;<INPUT id="btnCancelTop" runat="server" onclick="javascript:window.self.close();" type="button"
							value="CANCEL" name="goBack">
					</td>
				</tr>
			</table>
			<table width="750" height="95%" border="0" align="center" cellpadding="0" cellspacing="0"
				bgcolor="#ffffff" id="print">
				<tr valign="top">
					<td height="85" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="15%" height="85" align="left" valign="middle"><img src="images/GIL_logo.gif" width="118" height="85" vspace="5" border="0"></td>
								<td width="85%" align="right" valign="middle"><img src="images/nass_logo.gif" width="178" height="27" vspace="5" border="0"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="5" bgcolor="#706b6b"></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td height="100" align="left" valign="middle">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="12" height="100"><img src="images/Curve_Left.gif" width="12" height="100"></td>
								<td width="738" align="center" valign="middle"><img src="images/Form-Img.gif" width="738" height="100" border="0"></td>
								<td width="12" height="100" align="right" valign="top"><img src="images/Curve_Right.gif" width="12" height="100"></td>
							</tr>
						</table>
						<!--  <table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="16" height="120"><img src="images/Curve_Left.gif" width="16" height="120"></td>
								<td width="718" height="120" align="center" valign="middle" bgcolor="#c0c0c0"><img src="images/Form-Img.gif" width="505" height="120" border="0"></td>
								<td width="16" height="120"><img src="images/Curve_Right.gif" width="16" height="120"></td>
							</tr>
						</table> -->
					</td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="20" colspan="2" align="left" valign="middle"><p class="blue">* Please fill 
										the complete form in BLOCK letters only.</p>
								</td>
							</tr>
							<tr>
								<td height="5" colspan="2"></td>
							</tr>
							<tr>
								<td width="22%" height="30" align="left" valign="middle" class="main_black_bold">Name 
									of the candidate:
								</td>
								<td width="78%" align="left" valign="bottom" class="main_black">__________________________________________________________________________</td>
							</tr>
							<tr valign="top">
								<td colspan="2" height="30" align="left" valign="middle" class="main_black_bold">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="35%" height="30" align="left" valign="middle" class="main_black_bold">Date 
												of birth (DD-MM-YYYY):
											</td>
											<td width="65%" align="left" height="30" valign="bottom" class="main_black">_________________________________________________________________</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="5" colspan="2"></td>
							</tr>
							<tr>
								<td width="22%" height="30" align="left" valign="top" class="main_black_bold">Residential 
									Address:
								</td>
								<td width="78%" align="left" valign="bottom" class="main_black">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="100%" height="30" align="left" valign="middle" class="main_black">__________________________________________________________________________</td>
										</tr>
										<tr>
											<td width="100%" height="30" align="left" valign="middle" class="main_black">__________________________________________________________________________</td>
										</tr>
										<tr>
											<td width="100%" height="30" align="left" valign="middle" class="main_black">_________________________________Pin 
												Code:_________________________________</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black_bold"><strong>Phone 
										Number: </strong>
								</td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black">___________________ 
									(STD Code) __________________________ 
									(Landline)&nbsp;________________________(Mobile)</td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black"><b>Highest 
										Education Qualification</b> (if you are in UG final year, please write 
									'pursuing final year')<strong class="main_black"> </strong>
								</td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black">______________________________________________________________________________________________</td>
							</tr>
							<tr>
								<td height="5" colspan="2"></td>
							</tr>
							<tr>
								<td colspan="2" align="left" valign="middle" class="main_black"><strong>* </strong>You 
									need to be <u>at least UG final-year student</u> to be eligible to take NAC 
									test. Please attach a photocopy of your last &nbsp;&nbsp;&nbsp;year's college 
									mark sheet / certificate with this form (self attested) if you are currently in 
									UG final year.
								</td>
							</tr>
							<tr>
								<td height="20" colspan="2"></td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black_bold"><u>Demand 
										Draft Details:</u></td>
							</tr>
							<tr>
								<td height="30" colspan="2" align="left" valign="middle" class="main_black">Rs. 
									:_________________________________&nbsp;&nbsp; DD 
									Number:_____________________________________<br>
									<br>
									<br>
									Date of DD:_____________________Drawn on (Bank 
									Name):___________________________________________</td>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td height="30" class="main_black_bold"><u>Signature of the candidate:</u></td>
							</tr>
							<tr>
								<td height="30" class="main_black">I confirm that I am eligible to take NAC test 
									and agree to pay GIL a sum of Rs. 450/- towards the NAC test registration fee.</td>
							</tr>
							<tr>
								<td height="30"></td>
							</tr>
							<tr>
								<td height="30" align="left" valign="middle" class="main_black">Signature:____________________________________________ 
									Date:______________________________________
								</td>
							</tr>
							<tr>
								<td height="20" class="main_black_bold"><u>Instructions:</u><strong> </strong>
								</td>
							</tr>
							<tr>
								<td align="left" valign="middle" class="main_black">&nbsp; Fill this form and send 
									it (by hand/post) along with a Demand Draft of Rs. 450/- in favor of 'Gujarat 
									Informatics Limited'<br>
									&nbsp; and a self-attested proof of 'highest education qualification' to:</td>
							</tr>
							<tr>
								<td align="left" valign="middle" class="main_black_bold">&nbsp; Gujarat Informatics 
									Limited
									<br>
									&nbsp; NAC Cell
									<br>
									&nbsp; Block No. 1, 8th Floor<br>
									&nbsp;&nbsp;Udyog Bhavan, Sector -11
									<br>
									&nbsp; Gandhinagar 382 017, Gujarat<br>
									&nbsp; Phone: 079- 23256023 / 23256014 / 23259224</td>
							</tr>
							<tr>
								<td height="20"></td>
							</tr>
							<tr>
								<td align="left" valign="middle" class="main_black"><b>Disclaimer:</b> Due to 
									limited seats, GIL will accept the applications on 'first-cum-first-served' 
									basis. GIL also reserves the right to reject any application that is found 
									incomplete / unsuitable or is received late</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="20"></td>
				</tr>
				<tr>
					<td height="2" bgcolor="#c0c0c0"></td>
				</tr>
				<tr>
					<td height="2" bgcolor="#000000"></td>
				</tr>
				<tr>
					<td height="25" align="left" valign="middle" class="main_black">Application form 
						available at <a href="http://www.gujaratinformatics.com/" class="small_blue">www.gujaratinformatics.com</a>
						/ <a href="http://www.nac.nasscom.in" class="small_blue">www.nac.nasscom.in</a><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td height="20" align="center" valign="middle" class="main_black">NASSCOM 
						Assessment of Competence (NAC)</td>
				</tr>
				<tr>
					<td height="21" style="HEIGHT: 21px"></td>
				</tr>
				<tr>
					<td height="20" align="center" valign="middle"><input id="NoPrint" onclick="PrintReport();" type="button" name="button" value="PRINT">&nbsp;<input id="btnSave" runat="server" type="button" value="SAVE" onserverclick="btnSave_ServerClick">&nbsp;<INPUT id="btnEdit" runat="server" onclick="javascript:window.self.close();" type="button"
							value="CANCEL" NAME="goBack"></td>
				</tr>
				<tr>
					<td height="20"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
