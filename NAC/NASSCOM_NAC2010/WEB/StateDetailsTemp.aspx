<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="StateDetailsTemp.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.StateDetailsTemp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>State Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		    
			history.forward(1);  
		    
		    function fillOnlyAlphabetValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       // varSubString = document.getElementById(varControlId).value;
		       // varSubString = varSubString.substring(0,varSubString.length - 1);
		        
				 
		        
		        if (!IsAlphabet(varValue))
				    {
				       
					  alert("Please enter alphabet");
					  document.getElementById(varControlId).value = "";
					  document.getElementById(varControlId).focus();
					  document.getElementById(varControlId).style.backgroundColor = 'yellow';
					  return false;
					}	
				else
					{
						document.getElementById(varControlId).style.backgroundColor = 'white';
						 return true;
					}
		    }
		    
		    
		     function CheckFileExtension()
		     {			       	 
				var ext = document.getElementById("filUpload").value;
				
				var extFour;
				var bFileFormat = false;
								
				//document.getElementById("btnFileUpload").value = document.getElementById("filUpload").value;
				ext = ext.substring(ext.length-3,ext.length);
				ext = ext.toLowerCase();
				extFour = ext.substring(ext.length-4,ext.length);
				extFour = extFour.toLowerCase();
				if((ext == 'jpg') ||(ext == 'gif'))
				{
					bFileFormat = true;
				}   
				
				if(bFileFormat == false)
				 {
					alert('You selected a .' + ext + ' file; please select a .jpg or .gif file instead!');
					document.getElementById("filUpload").value = "";
					return false;
				 }				  
				else
					return true; 
		     }
		    
		  
		    
		    function fillOnlyNumericValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       // varSubString = document.getElementById(varControlId).value;
		       // varSubString = varSubString.substring(0,varSubString.length - 1);
		        
				 
		        
		        if (!IsNumeric(varValue))
				    {
				       
					  alert("Please enter numeric data");
					  document.getElementById(varControlId).value = "";
					  document.getElementById(varControlId).focus();
					  document.getElementById(varControlId).style.backgroundColor = 'yellow';
					  return false;
					}
				else
					{
						document.getElementById(varControlId).style.backgroundColor = 'white';
					}		        
		    }
		    
		    		     
			function ValidateData()
			{			
			
			     var strText;
			      
				  //Validate State Name		
				strText = document.getElementById("txtStateName").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter State Name");
					document.getElementById("txtStateName").focus();
					document.getElementById("txtStateName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtStateName").style.backgroundColor = 'white';
				}
				
				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtStateName").focus();
					document.getElementById("txtStateName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtStateName").style.backgroundColor = 'white';
				}

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtStateName").focus();
					document.getElementById("txtStateName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtStateName").style.backgroundColor = 'white';
				}


					//Validate State Code
					
				strText = document.getElementById("txtStateCode").value;			       					  

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtStateCode").focus();
					document.getElementById("txtStateCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtStateCode").style.backgroundColor = 'white';
				}
				
				//Validate Upload Photograph
					
			/*	strText = document.getElementById("filUpload").value;

				if (Trim(strText) != "")
				{
					var varFlag = CheckFileExtension();
					if (varFlag == false)
					{
						document.getElementById("filUpload").focus();
						return false;
					}
				}*/

					//
			}
			
		</script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TR>
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
					<TD vAlign="top" align="center">
						<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
							border="0">
							<TBODY>
								<TR class="white_bg" vAlign="top" align="left">
									<TD><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></TD>
								</TR>
								<TR class="blue_bg" vAlign="top" align="left">
									<TD class="header1" vAlign="middle">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR vAlign="top">
												<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;State Details</TD>
												<TD class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></TD>
											</TR>
										</TABLE>
									</TD>
					</TD>
				</TR>
				<TR class="white_bg" vAlign="top" align="center">
					<TD align="center"><BR>
						<TABLE class="lightblue_bg" cellSpacing="1" cellPadding="0" width="30%" border="0">
							<TR>
								<TD class="white_bg">
									<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="650" align="center" border="0">
										<TR class="main_black" align="left">
											<TD class="lightblue_bg" colSpan="3" height="25"><STRONG>State Details</STRONG></TD>
										</TR>
										<TR>
											<TD width="30%" colSpan="3"></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="20%">State List:<FONT class="small_maroon">*</FONT></TD>
											<TD><asp:dropdownlist id="ddlTestState" runat="server" Width="184px" AutoPostBack="True" CssClass="txtbox"></asp:dropdownlist></TD>
											<td><asp:button id="btnAddModifyCenterDetails" runat="server" Width="171px" Text="Modify/Add Center Details"></asp:button></td>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%" height="5">&nbsp;</TD>
											<TD colSpan="2" height="5">&nbsp;</TD>
										</TR>
										<TR class="main_black">
											<TD align="center" width="30%" colSpan="3"><asp:button id="btnAddState" runat="server" Text="Add New"></asp:button><asp:button id="btnModifyState" runat="server" Width="78px" Text="Modify"></asp:button>
											</TD>
										</TR>
										<TR class="main_black" align="left">
											<TD style="HEIGHT: 18px" align="right" width="30%"><FONT class="small_maroon"></FONT></TD>
											<TD style="HEIGHT: 18px" width="40%"></TD>
											<TD style="HEIGHT: 18px" width="30%"></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right" width="30%"></TD>
											<TD width="40%"></TD>
											<TD width="30%"></TD>
										</TR>
										<TR>
											<TD colSpan="3"></TD>
										</TR>
										<tr>
											<td align="center" colSpan="3">
												<table id="tblState" width="650" runat="server">
													<TR class="main_black" width="100%">
														<TD align="right" width="30%">State Name:</TD>
														<TD width="40%"><asp:textbox id="txtStateName" name="txtStateName" runat="server" Width="160px"></asp:textbox></TD>
														<td width="30%"></td>
													</TR>
													<TR class="main_black" width="100%">
														<TD align="right" width="30%">State Code:</TD>
														<TD width="40%"><asp:textbox id="txtStateCode" runat="server" Width="160px"></asp:textbox></TD>
														<td width="30%"></td>
													</TR>
													<TR class="main_black" width="100%">
														<TD align="right" width="30%">State Logo:</TD>
														<td colSpan="2"><INPUT class="btn2" id="filUpload" type="file" size="30" name="filUpload" runat="server">
														</td>
													</TR>
													<TR class="main_black" width="100%">
														<TD align="right" width="30%"></TD>
														<td colSpan="2">
															<asp:image id="imgState" runat="server"></asp:image>
														</td>
													</TR>
													<TR class="main_black" width="100%">
														<TD align="right" width="30%">ETS Access:</TD>
														<TD width="40%"><asp:checkbox id="chkETSAccess" runat="server"></asp:checkbox></TD>
														<td width="30%"></td>
													</TR>
												</table>
												<asp:button id="btnSubmit" runat="server" Text="Submit"></asp:button></td>
										</tr>
										<TR>
											<TD width="20%">&nbsp;</TD>
											<TD width="80%" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="errarea" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<BR>
					</TD>
				</TR>
			</TABLE>
			</TD>
			<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
			</TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR>
			</TBODY></TABLE></FORM>
	</body>
</HTML>
