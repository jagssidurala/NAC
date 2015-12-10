<%@ Page language="c#" Codebehind="SendEmail.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.SendEmail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SendEmail</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
		
	function SelectCandidate()
	{
	    var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);   
	    
	    if(varSelectedCandidateCount > 0)
	    {
	        return true;
	    }
	    else
	    {
	        alert("Please select atleast one company from the list.");
	        return false;
	    }
	}
	  
	function CheckAllCandidate()
	{
		var chkVar = document.getElementById("chkSelectAll").checked;
		var varTotalCandidateCount = parseInt(document.getElementById("hdTotalCandidateCount").value);
		if(chkVar)
		{
		    var varForm = document.frmSendEmail;
		    document.getElementById("hdSelectedCandidateCount").value = varTotalCandidateCount;
		    for(i=0;i<varForm.length;i++)
			{
				e = varForm.elements[i];
				if(e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1))
				{
					e.checked = true;
						
				}
			}
		}
	}
	
	function DeselectAll()
	{
		var chkVar = document.getElementById("chkSelectAll").checked; 
		if(!chkVar)
		{
		    var varForm = document.frmSendEmail;
		    document.getElementById("hdSelectedCandidateCount").value = 0;
		    for(i=0;i<varForm.length;i++)
			{
				e = varForm.elements[i];
				if(e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1))
				{
					e.checked = false;
				}
			}
		}	
	}
	
	function CheckAll(checkAllBox)
	{
		var varForm = document.frmSendEmail;
		var chkVar = checkAllBox.checked;  
		var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);    
		
		for(i=0;i<varForm.length;i++)
		{
				e = varForm.elements[i];
				if(e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1)
				{
					if(chkVar)
					{
						if(!e.checked)
						    {
						    varSelectedCandidateCount = varSelectedCandidateCount + 1;
						    }
						e.checked = true;
					}
					else
					{
							if(e.checked)
						    {
						    varSelectedCandidateCount = varSelectedCandidateCount - 1;
						    }
						e.checked = false;
					}
				}
		}
		document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount;
	}
	
		function ChangeHeaderCheck(checkAll)
		{
			var varForm = document.frmSendEmail;	 
			var chkVar = checkAll.checked;
			var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);    
			
			if(chkVar)
			{
			    document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount + 1;
			}
			else
			{
			    document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount - 1;
			}
						
			for(i=0;i<varForm.length;i++)
			{
				e = varForm.elements[i];
				if(e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1)
				{
					if(e.checked == false)
					{
						document.getElementById("chkSelectAll").checked = false;
						return;
					}
					else
					{
						document.getElementById("chkSelectAll").checked = true;
					}
				}
			}
		}		
		
		 function imposeMaxLength(Object, MaxLen, evt)
		 {
			evt = (evt) ? evt : event;
			var charCode = (evt.charCode) ? evt.charCode :((evt.which) ? evt.which : evt.keyCode);
			if ((charCode == 8) || (charCode == 46))
			{
				return true;
			} 
			else 
			{
			//alert(key.keyCode);
			return (Object.value.length <= MaxLen);
			}
		 }
		    
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmSendEmail" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="9">&nbsp;</td>
									<td vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
									<td width="4" rowSpan="9">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">
										<h1>&nbsp;&nbsp;
											<asp:LinkButton id="lnkHome" runat="server" CssClass="link" Width="5px" onclick="lnkHome_Click">Home</asp:LinkButton></h1>
									</td>
								</tr>
								<tr>
									<td style="HEIGHT: 18px" vAlign="top" align="center"><table>
											<tr>
												<td align="center" colSpan="2"><FONT size="4"><STRONG>
															<asp:Label id="lblHeading" runat="server" CssClass="pageheader">Send Email to members</asp:Label></STRONG></FONT></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">&nbsp;</td>
											</tr>
											<tr>
												<td vAlign="top">
													<asp:Label id="Label13" runat="server" CssClass="label_black_bold">Email Text:</asp:Label></td>
												<td><asp:textbox id="txtEmailBody" runat="server" Height="200px" Width="465px" TextMode="MultiLine"
														Font-Size="11px" BorderColor="#CCCCCC" BorderStyle="Solid" Font-Names="Tahoma" Visible="False"></asp:textbox><TEXTAREA style="Z-INDEX: 0; BORDER-BOTTOM: 1px solid; BORDER-LEFT: 1px solid; PADDING-BOTTOM: 2px; PADDING-LEFT: 3px; WIDTH: 465px; PADDING-RIGHT: 3px; FONT-FAMILY: Tahoma; HEIGHT: 200px; COLOR: black; FONT-SIZE: 11px; BORDER-TOP: 1px solid; BORDER-RIGHT: 1px solid; PADDING-TOP: 2px"
														id="txtareaEmailBody" runat="server">													</TEXTAREA></td>
											</tr>
											<tr>
												<td colSpan="2">&nbsp;</td>
											</tr>
											<TR>
												<td></td>
												<td>&nbsp;<asp:checkbox id="chkSelectAll" onclick="CheckAllCandidate(); DeselectAll();" runat="server" Text="Select All"
														CssClass="label_black_bold"></asp:checkbox><input id="hdTotalCandidateCount" type="hidden" value="0" name="hdTotalCandidateCount"
														runat="server"><asp:button id="btnDeselectAll" Height="1px" Width="1px" Runat="server" Visible="False"></asp:button>
												</td>
											</TR>
											<tr>
												<td>
													<asp:Label id="Label14" runat="server" CssClass="label_black_bold">To:</asp:Label>
												</td>
												<td><asp:datagrid id="dgMembers" runat="server" Width="100%" AutoGenerateColumns="False">
														<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BorderWidth="1px" ForeColor="Black" BorderStyle="Solid"
															BorderColor="Black" VerticalAlign="Middle" BackColor="LightGray"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderStyle-HorizontalAlign="left">
																<ItemTemplate>
																	<asp:Checkbox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" Runat="server"></asp:Checkbox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="CompanyId"></asp:BoundColumn>
															<asp:BoundColumn HeaderText="Company Name" DataField="CompanyName"></asp:BoundColumn>
															<asp:BoundColumn HeaderText="SPOC Name" DataField="SPOCName"></asp:BoundColumn>
															<asp:BoundColumn HeaderText="SPOC Email" DataField="SPOCEmail"></asp:BoundColumn>
														</Columns>
													</asp:datagrid></td>
											</tr>
											<tr>
												<td align="right" colSpan="2"><asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button" onclick="btnCancel_Click"></asp:button>&nbsp;
													<asp:button id="btnSendEmail" runat="server" Text="Send Email" CssClass="button" onclick="btnSendEmail_Click"></asp:button></td>
											</tr>
											<tr>
												<td align="center" colSpan="2">
													<asp:Label id="lblError" runat="server" CssClass="errormessage"></asp:Label></td>
											</tr>
											<tr>
												<td colSpan="2"><INPUT id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
														runat="server">
												</td>
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
