<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="RequestForScoreUpload.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.RequestForScoreUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RequestForScoreUpload</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="javascript" type="text/javascript">
		
		    
		   
		   function ChangeHeaderCheck(ev)
		   {
		       var ControlId = ev.id;			             
		       var TextControlId = ControlId.replace('chkSelect','txtAdminComment');
		       var divControlId = ControlId.replace('chkSelect','divAdminComment');
		       var hdControlValue = ControlId.replace('chkSelect','hdAdminComment');
		       var lblStatus = ControlId.replace('chkSelect','lblStatus');
		       var lblIsActive = ControlId.replace('chkSelect','lblIsActive');
		       
		        
		     /*   if(document.getElementById(lblStatus).innerText == "N/A" && document.getElementById(lblIsActive).innerText == "Closed")
				{
				   
					alert("Not allowed to change in closed Approval/Rejected status.");	
					document.getElementById(ControlId).checked = false;
					return false;
									 
				} */
		       
		          
			  /*	if(document.getElementById(lblIsActive).innerText == "Open")
				{*/
					if(document.getElementById(ControlId).checked)
					{
					document.getElementById(TextControlId).style.display = "";
					document.getElementById(divControlId).style.display = "none";
					}
					else
					{
					document.getElementById(divControlId).style.display = "";
					document.getElementById(TextControlId).style.display = "none";
					document.getElementById(hdControlValue).value = document.getElementById(TextControlId).value;
					document.getElementById(divControlId).innerText = document.getElementById(hdControlValue).value;
					}
			/*	}
				else
				{
					alert("You are unable to change the status");
					document.getElementById(ControlId).checked = false;
				}*/
		        
		       
		           
		       
		       
		        
		   }
		   
		   function SetValueInHiddenField(ev)
		   {
		       var ControlId = ev.id;
		                
		       var TextControlId = ControlId.replace('txtAdminComment','hdAdminComment');
		       
		          
		       document.getElementById(TextControlId).value = document.getElementById(ControlId).value;
		      
		   }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
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
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Request&nbsp;For 
												Approval</td>
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
													<TR>
														<TD align="center" colSpan="3"></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 12px" align="center" colSpan="3"><asp:datagrid id="dgETSRequestStatus" runat="server" AllowPaging="False" PageSize="10" AllowSorting="False"
																ShowFooter="True" AutoGenerateColumns="False" BorderColor="#999999" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical"
																Height="100%" Width="100%" CssClass="main_black" ForeColor="White">
																<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
																<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
																<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
																<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn>
																		<ItemTemplate>
																			<asp:Checkbox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" Runat="server"></asp:Checkbox>
																			<asp:Label ID="lblId" Runat="server" Visible="False" Text='<%#DataBinder.Eval(Container.DataItem,"Id")%>'>
																			</asp:Label>
																			<asp:Label ID="lblStateId" Runat="server" Visible="False" Text='<%#DataBinder.Eval(Container.DataItem,"StateId")%>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField="StateName" ItemStyle-Font-Size="10px" HeaderStyle-Font-Size="11px" HeaderText="State"></asp:BoundColumn>
																	<asp:BoundColumn DataField="RequestDate" DataFormatString="{0: dd-MM-yy}" ItemStyle-Font-Size="10px"
																		HeaderStyle-Font-Size="11px" SortExpression="RequestDate ASC" HeaderText="Request&#160;Date"></asp:BoundColumn>
																	<asp:BoundColumn DataField="ETSComment" ItemStyle-Font-Size="10px" HeaderStyle-Font-Size="11px" HeaderText="Reason&#160;for&#160;request"></asp:BoundColumn>
																	<asp:TemplateColumn ItemStyle-Font-Size="10px" HeaderStyle-Font-Size="11px">
																		<HeaderTemplate>
																			Admin&#160;approval/rejection
																		</HeaderTemplate>
																		<ItemTemplate>
																			<asp:Label ID="lblApprovOrRejectDate" Font-Size="10px" Runat="server" Text='<%#String.Format("{0: dd-MM-yy}", DataBinder.Eval(Container.DataItem,"ApprovalDate"))%>'>
																			</asp:Label>
																			<br />
																			<asp:Label ID="lblStatus" ForeColor="Red" Font-Size="9px" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Satus of Request")%>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn ItemStyle-Font-Size="10px" HeaderStyle-Font-Size="11px">
																		<HeaderTemplate>
																			Admin&#160;Comment
																		</HeaderTemplate>
																		<ItemTemplate>
																			<div id="divAdminComment" runat="server">
																				<%#DataBinder.Eval(Container.DataItem,"AdminComment")%>
																			</div>
																			<asp:TextBox TextMode="MultiLine" onblur="SetValueInHiddenField(this);" style="display:none; WIDTH: 200px; HEIGHT: 150px" id="txtAdminComment" Text='<%#DataBinder.Eval(Container.DataItem,"AdminComment")%>' runat="server">
																			</asp:TextBox>
																			<input type="hidden" id="hdAdminComment" runat="server" value='<%#DataBinder.Eval(Container.DataItem,"AdminComment")%>' NAME="hdAdminComment"/>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn ItemStyle-Font-Size="10px" HeaderStyle-Font-Size="11px">
																		<HeaderTemplate>
																			Last&#160;score&#160;upload
																		</HeaderTemplate>
																		<ItemTemplate>
																			<asp:Label ID="lblLastUploadOn" Font-Size="10px" Runat="server" Text='<%#String.Format("{0: dd-MM-yy}", DataBinder.Eval(Container.DataItem,"UploadDate"))%>'>
																			</asp:Label>
																			&nbsp;<br />
																			<asp:Label ID="lblUploadedBy" Font-Size="10px" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UploadedBy")%>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
																<PagerStyle NextPageText="Next" PrevPageText="Previous" HorizontalAlign="Right" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:button id="btnApprove" Text="Approve" Runat="server"></asp:button>&nbsp;
															<asp:button id="btnReject" Text="Reject" Runat="server" onclick="btnReject_Click"></asp:button>&nbsp;&nbsp;&nbsp;
														</TD>
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
		</form>
	</body>
</HTML>
