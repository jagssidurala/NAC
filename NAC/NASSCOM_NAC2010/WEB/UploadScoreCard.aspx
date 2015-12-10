<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="UploadScoreCard.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.UploadScoreCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload Score</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="javascript">
		
		function validateWorksheet()
		{
		   var strText;
		   strText = document.getElementById("ddWorksheet").value;  
		   
		   if (Trim(strText) == "")
				{
					alert("Please select worksheet");
					document.getElementById("ddWorksheet").focus();
					document.getElementById("ddWorksheet").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddWorksheet").style.backgroundColor = 'white';
				}
				
				
						//AQR Max Score 
				strText = document.getElementById("txtAQRMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtAQRMaxScore").focus();
					document.getElementById("txtAQRMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtAQRMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtAQRMaxScore").focus();
					document.getElementById("txtAQRMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtAQRMaxScore").style.backgroundColor = 'white';
				}
				
				
						//Writing Max Score 
				strText = document.getElementById("txtWritingMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtWritingMaxScore").focus();
					document.getElementById("txtWritingMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWritingMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtWritingMaxScore").focus();
					document.getElementById("txtWritingMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWritingMaxScore").style.backgroundColor = 'white';
				}
				
				
						//Learning Max Score 
				strText = document.getElementById("txtLearningMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtLearningMaxScore").focus();
					document.getElementById("txtLearningMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtLearningMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtLearningMaxScore").focus();
					document.getElementById("txtLearningMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtLearningMaxScore").style.backgroundColor = 'white';
				}
				
						//Listening Max Score 
				strText = document.getElementById("txtListeningMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtListeningMaxScore").focus();
					document.getElementById("txtListeningMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtListeningMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtListeningMaxScore").focus();
					document.getElementById("txtListeningMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtListeningMaxScore").style.backgroundColor = 'white';
				}
				
				
						//Speaking Max Score 
				strText = document.getElementById("txtSpeakingMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtSpeakingMaxScore").focus();
					document.getElementById("txtSpeakingMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSpeakingMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtSpeakingMaxScore").focus();
					document.getElementById("txtSpeakingMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSpeakingMaxScore").style.backgroundColor = 'white';
				}
				
				
						//Writing Essay Max Score 
				strText = document.getElementById("txtWritingEssayMaxScore").value;
					
				if (Trim(strText) == "")
				{
					alert("Please enter max score");
					document.getElementById("txtWritingEssayMaxScore").focus();
					document.getElementById("txtWritingEssayMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWritingEssayMaxScore").style.backgroundColor = 'white';
				}				
							
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtWritingEssayMaxScore").focus();
					document.getElementById("txtWritingEssayMaxScore").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWritingEssayMaxScore").style.backgroundColor = 'white';
				}
		}
			
			
			
				//Validating excel file, which is submited by user.
		function validate(obj)
		{			
			var filename =document.getElementById(obj).value;
			if (filename.length <=0)
			{
				alert("Browse Excel File");
				return false;
			}
			else
			var ext = filename.split(".")
			if (ext[ext.length-1].toUpperCase() != "XLS")
			{
				alert("Only .xls files are allowed");				
				return false;
			}
			return true;	
		}
					
		function ValidateConfirm()
		{			
			if(window.confirm('Scores for this state are already uploaded. Do you want to replace the old data with new one?'))
				{
					return true;
				    
				}
				else
				{
					return false;
				}
		}			
			
		</script>
	</HEAD>
	<body>
		<FORM id="frm" method="post" runat="server">
			<table id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr class="white_bg">
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td class="white_bg" vAlign="top" align="center">
						<table class="black_bg" id="Table2" style="WIDTH: 741px" cellSpacing="0" cellPadding="0"
							width="741" align="center" border="0">
							<tr class="white_bg" vAlign="top" align="left" height="100%">
								<td><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Upload Score</td>
											<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="left">
								<td vAlign="middle">&nbsp;&nbsp;
								</td>
							</tr>
							<tr class="white_bg" vAlign="middle" align="center">
								<td align="center"><br>
									<table cellSpacing="0" cellPadding="0" width="80%" border="0">
										<tr>
											<td>
												<table id="Table4" cellSpacing="2" cellPadding="1" width="662" align="center" border="0">
													<tr class="main_black" align="left">
														<td class="lightblue_bg" colSpan="3" height="25"></td>
													</tr>
													<TR>
														<TD colSpan="3" height="25">&nbsp;</TD>
													</TR>
													<asp:panel id="pnlBrowseFile" runat="server">
														<TR class="main_black" id="trUpComment2" align="left">
															<TD align="right" width="50%">Browse&nbsp;Score&nbsp;Card&nbsp;Excel&nbsp;file&nbsp;and&nbsp;Click&nbsp;Submit&nbsp;</TD>
															<TD width="30%"><INPUT class="txtbox" id="ScoreCardFile" type="file" name="file" runat="server"></TD>
															<TD class="small_maroon" align="left" width="20%"></TD>
														</TR>
														<TR id="trUpComment3">
															<TD align="left" width="20%"></TD>
															<TD width="100%" colSpan="2">
																<asp:Button id="btnItemDone" runat="server" Text="Submit" onclick="ItemDone_Click"></asp:Button></TD>
														</TR>
													</asp:panel><asp:panel id="pnlSelectSheet" runat="server">
														<TR class="main_black" align="center">
															<TD align="right" width="50%">Select Worksheet and Click Upload&nbsp;</TD>
															<TD align="left" width="30%">
																<asp:DropDownList id="ddWorksheet" runat="server" CssClass="txtbox"></asp:DropDownList>
																<asp:Button id="btnUpload" runat="server" Text="Upload" onclick="Upload_Click"></asp:Button></TD>
															<TD align="left" width="20%">&nbsp;
															</TD>
														</TR>
														<TR class="main_black" align="center">
															<TD align="center" width="50%" colSpan="3">&nbsp;</TD>
														</TR>
														<TR class="main_black" align="center">
															<TD class="lightblue_bg" align="left" width="50%" colSpan="3"><STRONG>Enter Max Marks</STRONG></TD>
														</TR>
														<TR class="main_black" align="center">
															<TD align="right" width="50%" colSpan="3">&nbsp;</TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Analytical &amp; Quantitative Reasoning Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtAQRMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">30</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Writing Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtWritingMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">30</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Learning Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtLearningMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">10</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Listening Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtListeningMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">25</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Speaking Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtSpeakingMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">5</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
														<TR class="main_black" vAlign="top" align="left">
															<TD width="43%">Writing Essay Max Score:<FONT class="small_maroon">*</FONT></TD>
															<TD width="55%">
																<asp:textbox id="txtWritingEssayMaxScore" CssClass="txtbox" Runat="server" MaxLength="3" BackColor="White">6</asp:textbox></TD>
															<TD class="small_maroon" width="2%"></TD>
														</TR>
													</asp:panel>
													<TR>
														<TD colSpan="3"></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:textbox id="txtHidden" runat="server" CssClass="txtbox" Visible="False"></asp:textbox><asp:label id="lblInfo" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 12px" align="center" colSpan="3"><asp:label id="lblTotal" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:label id="lblImported" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:label id="lblError" runat="server" CssClass="main_red_bold"></asp:label></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD align="center" colSpan="3"><asp:label id="lblRowNumber" runat="server" CssClass="main_blue_bold"></asp:label></TD>
													</TR>
													<!-- Start Overwrite statement -->
													<TR id="trComment1" style="DISPLAY: none">
														<TD align="center" colSpan="3"></TD>
													</TR>
													<!-- End Overwrite statement -->
													<TR>
														<TD align="center" colSpan="3"></TD>
													</TR>
													<TR class="main_black" align="left">
														<TD align="center" colSpan="3"><A href="Welcome.aspx">Go Back</A></TD>
													</TR>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</table>
		</FORM>
	</body>
</HTML>
