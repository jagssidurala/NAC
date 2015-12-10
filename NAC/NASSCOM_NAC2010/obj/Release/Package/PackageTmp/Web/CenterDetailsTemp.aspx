<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="CenterDetailsTemp.aspx.cs" AutoEventWireup="false" Inherits="NASSCOM_NAC.Web.CenterDetailsTemp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Center Details</title>
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
		    
		    		     
			function ValidateCityData()
			{			
			
			     var strText;
			      
				  //Validate State Name		
				strText = document.getElementById("txtCityName").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter City Name");
					document.getElementById("txtCityName").focus();
					document.getElementById("txtCityName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCityName").style.backgroundColor = 'white';
				}
				
				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtCityName").focus();
					document.getElementById("txtCityName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCityName").style.backgroundColor = 'white';
				}

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCityName").focus();
					document.getElementById("txtCityName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCityName").style.backgroundColor = 'white';
				}


					//Validate State Code
					
				strText = document.getElementById("txtCityCode").value;			       					  

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCityCode").focus();
					document.getElementById("txtCityCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCityCode").style.backgroundColor = 'white';
				}
				
				

					//
			}
			
			
			function ValidateCentreData()
			{			
			
			     var strText;
			      
				  //Validate Center Name		
				strText = document.getElementById("txtCenterName").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter Centre Name");
					document.getElementById("txtCenterName").focus();
					document.getElementById("txtCenterName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterName").style.backgroundColor = 'white';
				}
				
				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtCenterName").focus();
					document.getElementById("txtCenterName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterName").style.backgroundColor = 'white';
				}

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCenterName").focus();
					document.getElementById("txtCenterName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterName").style.backgroundColor = 'white';
				}


					//Validate Centre Capacity
					
				strText = document.getElementById("txtCenterCapacity").value;			       					  

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCenterCapacity").focus();
					document.getElementById("txtCenterCapacity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterCapacity").style.backgroundColor = 'white';
				}
				
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric");
					document.getElementById("txtCenterCapacity").focus();
					document.getElementById("txtCenterCapacity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterCapacity").style.backgroundColor = 'white';
				}
				
				
				//Validate State Code
					
				strText = document.getElementById("txtCenterCode").value;			       					  

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCenterCode").focus();
					document.getElementById("txtCenterCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterCode").style.backgroundColor = 'white';
				}
				
				
				
				  //Validate Center Addresss		
				strText = document.getElementById("txtCenterAddress").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter Centre Address");
					document.getElementById("txtCenterAddress").focus();
					document.getElementById("txtCenterAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterAddress").style.backgroundColor = 'white';
				}
				
				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtCenterAddress").focus();
					document.getElementById("txtCenterAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterAddress").style.backgroundColor = 'white';
				}

				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCenterAddress").focus();
					document.getElementById("txtCenterAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCenterAddress").style.backgroundColor = 'white';
				}
			}
			
			function FillHiddenField()
			{
				document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
				document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;			
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
												<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Center Details</TD>
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
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Edit Details</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="5"></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD align="right">City List:<FONT class="small_maroon">*</FONT></TD>
											<TD><asp:dropdownlist id="ddlTestcity" runat="server" Width="152px" AutoPostBack="True" CssClass="txtbox"></asp:dropdownlist></TD>
											<td align="right"><asp:button id="btnAddCity" runat="server" Width="96px" Text="Add City"></asp:button></td>
											<td><asp:button id="btnModifyCity" runat="server" Width="96px" Text="Modify City"></asp:button></td>
											<td></td>
										</TR>
										<TR class="main_black" align="left">
											<TD style="HEIGHT: 5px" align="right">Center List:<FONT class="small_maroon">*</FONT></TD>
											<TD style="HEIGHT: 5px"><asp:dropdownlist id="ddlCenter" runat="server" Width="152px" AutoPostBack="True" CssClass="txtbox"></asp:dropdownlist></TD>
											<td style="HEIGHT: 5px" align="right"><asp:button id="btnAddCenter" runat="server" Text="Add Center"></asp:button></td>
											<td style="HEIGHT: 5px"><asp:button id="btnModifyCenter" runat="server" Width="120px" Text="Modify Test Center"></asp:button></td>
											<td style="HEIGHT: 5px"><asp:button id="btnAddTestDetails" runat="server" Text="Add Test"></asp:button></td>
										</TR>
										<TR height="10">
											<TD colSpan="5" align="center">
												<asp:label id="lblMessage" runat="server" CssClass="errarea" Visible="False"></asp:label></TD>
										</TR>
										<TR class="main_black" align="left">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>State Corresponding Details</STRONG></TD>
										</TR>
										<tr>
											<td colSpan="5" height="8"></td>
										</tr>
										<TR class="main_black" align="left">
											<TD align="center">State Name</TD>
											<TD align="center">State Code</TD>
											<td align="center">Logo</td>
											<td align="center">ETS Access</td>
											<td align="center"></td>
										</TR>
										<TR class="main_black" align="left">
											<TD style="HEIGHT: 14px" align="center"><asp:textbox id="txtStateName" runat="server" Width="160px"></asp:textbox></TD>
											<TD style="HEIGHT: 14px" align="center"><asp:textbox id="txtStateCode" runat="server" Width="160px"></asp:textbox></TD>
											<td style="HEIGHT: 14px" align="center"><asp:image id="imgState" runat="server"></asp:image></td>
											<td style="HEIGHT: 14px" align="center"><asp:checkbox id="chkETSAccess" runat="server"></asp:checkbox></td>
											<td style="HEIGHT: 14px" align="center"></td>
										</TR>
										<TR class="main_black" align="left" height="10">
											<TD align="center" colSpan="5"></TD>
										</TR>
										<TR class="main_black" id="dvCity1" align="left" runat="server">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>City Corresponding Details</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="5" height="8"></TD>
										</TR>
										<TR class="main_black" id="dvCity2" align="left" runat="server">
											<TD align="center">City</TD>
											<TD align="center">City Code</TD>
											<td align="center"></td>
											<td align="center"></td>
											<td align="center"></td>
										</TR>
										<TR class="main_black" id="dvCity3" align="left" runat="server">
											<TD align="center"><asp:textbox id="txtCityName" runat="server" Width="160px"></asp:textbox></TD>
											<TD align="center"><asp:textbox id="txtCityCode" runat="server" Width="160px"></asp:textbox></TD>
											<td align="center"></td>
											<td align="center"></td>
											<td align="center"></td>
										</TR>
										<TR height="10">
											<TD colSpan="5"></TD>
										</TR>
										<TR class="main_black" id="dvCentre1" align="left" runat="server">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Center Corresponding Details</STRONG></TD>
										</TR>
										<TR height="10">
											<TD colSpan="5"></TD>
										</TR>
										<TR class="main_black" id="dvCentre2" align="left" runat="server">
											<TD align="center">Center Name</TD>
											<TD align="center">Center Capacity</TD>
											<td align="center">Center Code</td>
											<td align="center">Center Address</td>
											<td align="center"></td>
										</TR>
										<TR class="main_black" id="dvCentre3" align="left" runat="server">
											<TD align="center"><asp:textbox id="txtCenterName" runat="server" Width="160px"></asp:textbox></TD>
											<TD align="center"><asp:textbox id="txtCenterCapacity" runat="server" Width="160px"></asp:textbox></TD>
											<td align="center"><asp:textbox id="txtCenterCode" runat="server" Width="160px"></asp:textbox></td>
											<td align="center"><asp:textbox id="txtCenterAddress" runat="server" Width="160px"></asp:textbox></td>
											<td align="center"></td>
										</TR>
										<tr>
											<td colSpan="5" height="8"><INPUT id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server">
												<INPUT id="hdCity" type="hidden" value="0" name="hdCity" runat="server"></td>
										<TR>
											<TD align="center" colSpan="5"><asp:button id="btnSubmit" runat="server" Text="Submit"></asp:button></TD>
										</TR>
										<TR height="10">
											<TD colSpan="5" align="center">
												<asp:label id="lblSubmitMessage" runat="server" CssClass="errarea" Visible="False"></asp:label></TD>
										</TR>
										<TR class="main_black" id="Tr1" align="left" runat="server">
											<TD class="lightblue_bg" colSpan="5" height="25"><STRONG>Centers Details</STRONG></TD>
										</TR>
										<TR height="10">
											<TD colSpan="5"></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="5">
												<asp:label id="lblGrid" runat="server" Visible="False">No center exist for this state.</asp:label>
												<asp:datagrid id="dgCentre" runat="server" CellPadding="3" BackColor="White" BorderWidth="1px"
													BorderStyle="None" BorderColor="#CCCCCC" AllowPaging="True" PageSize="5" ShowFooter="True">
													<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
													<ItemStyle ForeColor="#000066"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
													<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
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
