<%@ Page language="c#" Codebehind="IndiaMap.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.IndiaMap" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>NAC Registration</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

        <LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr>
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;NAC Registration</td>
											<td class="header1" vAlign="middle" align="right"><A class="header1" href="../default.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="center">
								<td align="center"><br>
									<table class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
										<tr>
											<td class="white_bg">
												<div class="main_black_bold"><b>NASSCOM Assessment of Competence</b>
												</div>
												<br>
												<table width="100%" border="0">
													<tbody>
														<tr vAlign="top">
															<td class="main_black" colSpan="2">
																<i><p align="left">Click on your state to register for NAC&nbsp;</p></i>
															</td>
														</tr>
														<tr vAlign="top">
															<td align="center" colSpan="2"></td>
														</tr>
													</tbody>
												</table>
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<table cellSpacing="0" cellPadding="0" align="center" bgColor="#ffffff" border="0">
													<tbody>
														<tr>
															<td><IMG height="580" alt="" src="Images/india-map_blank.jpg" width="541" useMap="#Map" border="0"><map name="Map">
																	<area shape="POLY" coords="70,331,76,290,45,326,8,279,33,277,3,253,19,245,55,234,82,251,110,280,95,321"
																		href="GujratDefault.aspx?State=Gujarat">
																	<area shape="POLY" coords="34,193,45,218,111,276,122,242,151,261,178,201,148,185,119,142"
																		href="Rajasthan.aspx?State=Rajasthan">
																	<!--<area shape="POLY" coords="490,210,485,210,475,212,460,225,455,240,465,240,475,240" href="Nagaland.aspx?State=Nagaland"> -->
																	<area shape="POLY" coords="158,121,166,125,170,131,161,144,151,149,142,149,135,147,129,147,120,144,115,136,126,128,133,124,131,116,140,106,149,103,156,113"
																		href="ChandigarhDefault.aspx?State=Punjab">
																	<area shape="POLY" coords="158,168,159,169,163,179,170,185,179,171,170,163,163,165,158,167"
																		href="Delhi.aspx?State=Delhi">
																	<area shape="POLY" coords="142,575,167,555,179,535,194,526,192,510,195,499,200,489,204,485,205,477,205,473,206,469,198,467,189,476,181,479,172,483,169,482,167,482,158,479,150,482,151,489,147,499,130,502,132,522,142,532,140,554"
																		href="TamilNadu.aspx?State=TamilNadu">
																	<area shape="POLY" coords="183,241,184,263,195,235,269,262,218,310,189,313,166,315,158,304,140,316,108,296,114,277,124,242,145,261,161,257,165,238,157,227,182,208,201,217"
																		href="Madhya_Pradesh.aspx?State=Madhya Pradesh">
																	<!-- <area shape="POLY" coords="101,476,101,491,111,511,116,527,119,542,129,561,140,573,141,558,143,545,142,539,143,532,135,522,133,508,129,497,113,485,104,476"
																		href="Kerala.aspx?State=Kerala"> -->
																	<area shape="POLY" coords="132,506,135,496,146,498,150,483,165,479,170,472,163,458,155,464,144,456,135,450,136,430,146,434,150,420,162,371,128,391,125,391,119,391,120,398,117,395,106,398,99,408,92,415,91,433,94,451,104,479"
																		href="Karnataka.aspx?State=Karnataka">
																	<area shape="POLY" coords="138,169,149,190,163,188,170,186,159,170,174,162,172,142,177,142,174,132,146,151,126,147,125,147"
																		href="Haryana.aspx?State=Haryana">
																	<area shape="POLY" coords="185,254,201,237,272,269,289,241,284,208,227,179,191,169,180,141,177,177,167,186,177,210,197,219,196,216"
																		href="Uttar_Pradesh.aspx?State=Uttar Pradesh">
																	<area shape="POLY" coords="89,426,103,396,117,395,125,389,159,373,168,351,178,339,192,356,205,349,212,368,225,352,214,339,223,318,196,308,164,316,161,305,140,318,118,305,106,300,102,313,86,334,74,334,71,354,76,399,79,417"
																		href="Maharashtra.aspx?State=Maharashtra">
																	<area shape="POLY" coords="285,205,295,238,275,262,331,258,354,239,355,224,321,221,290,201"
																		href="Bihar.aspx?State=Bihar">
																	
																	<!--<area shape="POLY" coords="420,290,410,280,440,260,440,260,435,290" href="Tripura.aspx?State=Tripura">
																	<area shape="POLY" coords="370,210,350,210,360,190,380,190" href="Sikkim.aspx?State=Sikkim">
																	<area shape="POLY" coords="415,235,425,230,443,243,435,254,437,263,454,255,457,235,468,212,476,217,501,197,496,184,465,192,458,204,448,206,442,207,437,207,433,211,418,215,408,212,397,206,383,212,398,216,391,220,392,235,398,234"
																		href="Assam.aspx?State=Assam">
																	<area shape="POLY" coords="451,255,446,261,452,270,469,267,478,252,474,241,464,239,451,248"
																		href="Manipur.aspx?State=Manipur">
																	<area shape="POLY" coords="472,188,495,184,495,195,486,206,489,214,504,202,520,203,520,191,527,184,523,176,506,179,503,154,493,160,485,166,468,160,464,169,464,175,451,176,446,184,430,188,432,200,414,209,424,214,435,206,452,203"
																		href="Arunachal_Pradesh.aspx?State=Arunachal Pradesh">
																	<area shape="POLY" coords="400,255,440,250,440,230,390,230" href="Meghalaya.aspx?State=Meghalaya">
																	<area shape="POLY" coords="435,290,435,280,440,260,440,260,460,290,445,305" href="Mizoram.aspx?State=Mizoram">
																	-->
																	<area shape="POLY" coords="168,478,188,475,198,463,206,450,202,434,216,423,239,414,254,401,281,379,296,367,277,365,259,375,250,375,226,385,213,373,201,352,179,345,166,354,157,376,153,401,151,412,141,429,135,444,134,430,139,450"
																		href="Andhra_Pradesh.aspx?State=Andhra Pradesh">
																	<!--<area shape="POLY" coords="379,306,373,272,364,261,366,253,372,242,364,235,368,219,383,233,390,226,392,216,381,217,372,198,367,209,358,210,356,231,357,238,355,241,350,264,324,278,320,285,336,293,337,304,351,317,353,309,367,311"
																		href="West_Bangal.aspx?State=West Bengal">
																	 <area shape="RECT" coords="330,25,456,65" href="Hero_Mindmine.aspx?State=Hero Mindmine"> 
																	<area shape="POLY" coords="243,383,247,371,258,379,264,363,279,367,296,365,310,351,337,338,334,329,337,318,351,317,347,307,336,304,324,295,318,305,312,302,288,293,272,304,263,321,251,327,254,347,238,340,245,364,234,374,229,385"
																		href="Orissa.aspx?State=Orissa">-->
																	<!-- <area shape="RECT" coords="300,80,490,130" href="VelTech.aspx?State=VelTech"> -->
																</map>
															</td>
														</tr>
													</tbody>
												</table>
											</td>
										</tr>
									</table>
									<br>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
