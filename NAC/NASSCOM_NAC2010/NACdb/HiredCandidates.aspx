<%@ Page language="c#" Codebehind="HiredCandidates.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.HiredCandidates" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Hired Candidates</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script>

	function new_window(url)
	{
		newwindow=window.open(url,'Feedback','top=50,left=200,width=380,height=70,scrollbars=no');
		newwindow.focus();
	}
	
	function new_window_profile(url)
	{
		newwindow=window.open(url,'Feedback','top=50,left=200,width=888,height=330,scrollbars=no');
		newwindow.focus();
	}
	
	 function confirmExit() 
	 {
		return confirm("Are you sure you want remove the selected candidate from hired list?");
     }
     

     	function ValidateDate()
		{
			var varForm = document.frmHiredCandidates;
			
			var varSelectedCandidateCount = 0;    
		 	 
			for(i=0;i<varForm.length;i++)
			{
					e = varForm.elements[i];
					if(e.type == 'checkbox' && e.name.indexOf("chkExit") != -1)
					{
							 if(e.checked)
						     {
						        varSelectedCandidateCount = varSelectedCandidateCount + 1;
						     }
					}
			}
			
			
			if (varSelectedCandidateCount <= 0)
			{
	          alert("Please select candidate from candidate list");
			  return false;
			}
			
	        //Validate declaration
			if(document.getElementById("chkDeclaration").checked == false)
		    {
		        alert("Please accept the Declaration");
				document.getElementById("chkDeclaration").focus();
				document.getElementById("chkDeclaration").style.backgroundColor = 'yellow';
				return false;
			}
			
			 return confirm("Are you sure you want remove the candidate from hired list?");
			
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHiredCandidates" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td style="WIDTH: 918px" vAlign="top">&nbsp;&nbsp;<A class="link" style="WIDTH: 0%; HEIGHT: 14px" href="CompanyHomePage.aspx">Home</A>
										<INPUT id="hdnCheckboxCount" type="hidden" value="0">
										<h1>&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td vAlign="top">
										<h1>&nbsp;&nbsp;&nbsp;</h1>
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<table width="100%">
											<tr>
												<td class="pageheader" align="center"><FONT size="4"><STRONG>Hired Candidates</STRONG></FONT>
												</td>
											</tr>
											<tr>
												<td>&nbsp;</td>
											</tr>
											<TR>
												<TD align="center">
													<TABLE id="Table2" cellSpacing="0" cellPadding="4" border="0">
														<TR>
															<TD>
																<asp:datagrid id="dgHiredCandidates" runat="server" AutoGenerateColumns="False" CssClass="main_black">
																	<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
																		BorderColor="Black" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
																	<Columns>
																		<asp:TemplateColumn HeaderText="Select" ItemStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:CheckBox Runat="server" ID="chkExit"></asp:CheckBox>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="S.No.">
																			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<%# Container.ItemIndex+1 %>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn HeaderText="RegId" ItemStyle-HorizontalAlign="Center">
																			<ItemTemplate>
																				<asp:Label Runat="server" ID="lblRegistrationId" Text='<%#DataBinder.Eval(Container, "DataItem.RegistrationId")%>'>
																				</asp:Label>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:BoundColumn DataField="Name" HeaderText="Name"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Date Of Birth" HeaderText="Date Of Birth" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
																		<asp:BoundColumn DataField="TestDate" HeaderText="Test Date" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
																		<asp:BoundColumn DataField="TestCity" HeaderText="Test City"></asp:BoundColumn>
																		<asp:BoundColumn DataField="HiredOn" HeaderText="Hired On" DataFormatString="{0: dd-MMMM-yyyy}"></asp:BoundColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
														<TR>
															<TD>
																<asp:checkbox id="chkDeclaration" runat="server" CssClass="small_maroon" Text="We confirm that the above NAC candidate has taken <u>exit</u> from our organization."
																	Font-Bold="True"></asp:checkbox></TD>
														</TR>
														<TR>
															<TD><asp:button id="btnExit" runat="server" Text="Mark Candidate Exit " onclick="btnExit_Click"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<tr>
												<td align="center" colSpan="1" rowSpan="1"><asp:label id="lblStatus" runat="server" CssClass="errormessage">No Candidates hired</asp:label></td>
											<TR>
												<TD align="center"></TD>
											</TR>
											<tr>
												<td align="center"><br>
													<asp:button id="btnBack" runat="server" CssClass="button" Text="Back" onclick="btnBack_Click"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
											<DIV class="divLeft"><IMG src="../Web/Images/footer2014.gif"><A href="mailto:nac@nasscom.in"></A></DIV>
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
