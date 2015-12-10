<%@ Page language="c#" Codebehind="TestRegistrationStatus.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TestRegistrationStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Registration Status</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta http-equiv="pragma" content="no-cache">
		<meta http-equiv="cache-control" content="no-cache">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<script language="JavaScript">
		function noBack()
		{
			window.history.forward(0)
		}
		noBack();
		window.onload=noBack;
		window.onpageshow=function(evt){if(evt.persisted)noBack()}
		window.onunload=function(){void(0)}
		</script>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
				var elem = document.getElementById('lblErrorMsg');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
				
				var strText;			      
				//Validate Company Name		
				strText = document.getElementById("txtCompanyName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter company name");
					document.getElementById("txtCompanyName").focus();
					document.getElementById("txtCompanyName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanyName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Name
				strText = document.getElementById("txtSPOCName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter Company SPOC name");
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Email
				strText = document.getElementById("txtCompanySPOCEmail").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +" email ID");
					document.getElementById("txtCompanySPOCEmail").focus();
					document.getElementById("txtCompanySPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanySPOCEmail").style.backgroundColor = 'white';
				}
				
				//Confirmation				
				if (confirm("Are you sure you want to submit?") == true)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			  function fillOnlyAlphabetValue(eV)
			  {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!IsAlphabet(varValue))
				{
					alert("Please enter alphabets only");
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
		    
		    function ValidateEmailAddress(eV)
		    {
				var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!(emailCheck(varValue)) && Trim(varValue)!="")
				{
					alert("Please enter valid email address");
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					if(varValue.search("gmail")>=0 || varValue.search("yahoo")>=0 || varValue.search("rediff")>=0 || varValue.search("zapak")>=0 || varValue.search("hotmail")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").focus();
						document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
						return false;
					}
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'white';
				}		        
		        
		    }
		    
		    function fillOnlyNumericValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        if (!IsNumeric(varValue))
				{
					alert("Please enter numeric values");
					//document.getElementById(varControlId).value = "";
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
				}		        
		    }
		    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">&nbsp;&nbsp;<A class="link" style="WIDTH: 0%; HEIGHT: 14px" href="Welcome.aspx">Home</A>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><table>
											<tr>
												<td align="center" colSpan="2"><STRONG><FONT size="4"><asp:label id="Label3" runat="server" CssClass="pageheader">Test Registration Status</asp:label></FONT></STRONG></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;</td>
											</tr>
											<TR>
												<TD align="left" colSpan="2">
													<asp:RadioButtonList id="rblTestType" runat="server" CssClass="main_black" Width="220px" AutoPostBack="True"
														RepeatDirection="Horizontal" onselectedindexchanged="rblTestType_SelectedIndexChanged">
														<asp:ListItem Value="Ongoing Test" Selected="True">Ongoing Test</asp:ListItem>
														<asp:ListItem Value="Previous Test">Previous Test</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<tr>
												<td style="PADDING-TOP:20px"><asp:label id="Label1" runat="server" CssClass="label_black_bold">Test Name</asp:label></td>
												<td style="PADDING-TOP:20px">
													<asp:DropDownList id="ddlTestNames" runat="server" CssClass="main_black" AutoPostBack="True" onselectedindexchanged="ddlTestNames_SelectedIndexChanged"></asp:DropDownList></td>
											</tr>
											<TR>
												<TD align="left" colSpan="2"></TD>
											</TR>
											<TR>
												<TD align="right" colSpan="2"><asp:label id="lblErrorMsg" runat="server" CssClass="errormessage" Font-Bold="True"></asp:label>
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="2"></SPAN></td>
											</tr>
										</table>
										<TABLE id="Table2" cellSpacing="2" cellPadding="2" border="0">
											<TR>
												<TD>
													<asp:datagrid id="dgRegistrationStatus" runat="server" CellPadding="3" CssClass="main_black" AutoGenerateColumns="False">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
															BorderColor="Black" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="S.No.">
																<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<%# Container.ItemIndex+1 %>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="TestId" Visible="false"></asp:BoundColumn>
															<asp:BoundColumn DataField="EventType" HeaderText="Type"></asp:BoundColumn>
															<asp:BoundColumn DataField="State" HeaderText="State" Visible="False"></asp:BoundColumn>
															<asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
															<asp:BoundColumn DataField="Centre" HeaderText="Centre"></asp:BoundColumn>
															<asp:BoundColumn DataField="RegistrationStartDate" HeaderText="Reg. Start Date" DataFormatString="{0: dd-MM-yyyy hh:mm tt}"></asp:BoundColumn>
															<asp:BoundColumn DataField="RegistrationEndDate" HeaderText="Reg. End Date" DataFormatString="{0: dd-MM-yyyy hh:mm tt}"></asp:BoundColumn>
															<asp:BoundColumn DataField="IsShiftTime" HeaderText="Shift"></asp:BoundColumn>
															<asp:BoundColumn DataField="Capacity" HeaderText="Capacity"></asp:BoundColumn>
															<asp:BoundColumn DataField="RegisteredCount" HeaderText="Registered"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:Label id="lblTotal" runat="server" CssClass="label_black_bold"></asp:Label></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../WEB/Images/footerDB.jpg"><A href="mailto:nac@nasscom.in"></A></DIV>
										</DIV>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
