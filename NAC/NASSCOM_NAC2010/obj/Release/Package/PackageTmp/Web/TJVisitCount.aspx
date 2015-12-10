<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="TJVisitCount.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TJVisitCount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>TJ Visit Count</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		function Validatedata()
		    {
		      var strText = document.getElementById("ddlFromDay").value; 
		      if ((strText) == 0)
				{
					alert("Please select from day");
					document.getElementById("ddlFromDay").focus();
					document.getElementById("ddlFromDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlFromDay").style.backgroundColor = 'white';
				}

							
				strText = document.getElementById("ddlFromMonth").value;                      
				if ((strText) == 0)
				{
					alert("Please select from month");
					document.getElementById("ddlFromMonth").focus();
					document.getElementById("ddlFromMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlFromMonth").style.backgroundColor = 'white';
				}

				strText = document.getElementById("ddlFromYear").value;                       
				if ((strText) == 0)
				{
					alert("Please select from year");
					document.getElementById("ddlFromYear").focus();
					document.getElementById("ddlFromYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlFromYear").style.backgroundColor = 'white';
				}
					strText = document.getElementById("ddlFromDay").value + "-" + document.getElementById("ddlFromMonth").value + "-" + document.getElementById("ddlFromYear").value

				if (isValidDate(strText)!="")
				{
					alert("Please enter valid from date");
					document.getElementById("ddlToDay").focus();
					document.getElementById("ddlToDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToDay").style.backgroundColor = 'white';
				}
				var strText = document.getElementById("ddlToDay").value; 
		      if ((strText) == 0)
				{
					alert("Please select to day");
					document.getElementById("ddlToDay").focus();
					document.getElementById("ddlToDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToDay").style.backgroundColor = 'white';
				}

							
				strText = document.getElementById("ddlToMonth").value;                      
				if ((strText) == 0)
				{
					alert("Please select to month");
					document.getElementById("ddlToMonth").focus();
					document.getElementById("ddlToMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToMonth").style.backgroundColor = 'white';
				}

				strText = document.getElementById("ddlToYear").value;                       
				if ((strText) == 0)
				{
					alert("Please select to year");
					document.getElementById("ddlToYear").focus();
					document.getElementById("ddlToYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToYear").style.backgroundColor = 'white';
				}
					strText = document.getElementById("ddlToDay").value + "-" + document.getElementById("ddlToMonth").value + "-" + document.getElementById("ddlToYear").value

				if (isValidDate(strText)!="")
				{
					alert("Please enter valid to date");
					document.getElementById("ddlToDay").focus();
					document.getElementById("ddlToDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToDay").style.backgroundColor = 'white';
				}
				return true;
		    }
		    function CheckAllCandidate()
		{
		  
		   var chkVar = document.getElementById("chkAll").checked;
		   var varTotalCandidateCount = parseInt(document.getElementById("hdTotalCandidateCount").value);
		   if(chkVar)
		   {
		       var varForm = document.Form1;
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
		
		   var chkVar = document.getElementById("chkAll").checked; 
		   if(!chkVar)
		   {
		       var varForm = document.Form1;
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
		   
		   //document.getElementById("btnDeselectAll").click();
		
		}
		function CheckAll(checkAllBox)
		{
			var varForm = document.Form1;
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
			 
			var varForm = document.Form1;	 
			var IsCheckAll = true;
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
					if(e.checked == false && IsCheckAll)
					{
						IsCheckAll = false;	
						if(document.getElementById("hdHeaderCheckBox").value != "0")
						{
						   document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = false;
						   document.getElementById("chkAll").checked = false;
						}				 
						
					}				 		 
					
				}
			}
			
			if(IsCheckAll)
			{
				if(document.getElementById("hdHeaderCheckBox").value != "0")
				{
					document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = true;
				}	
			}
		}	
		function SelectCandidate()
	  {
	      var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);   
	       
	      if(varSelectedCandidateCount > 0)
	      {
	         return true;
	      }
	      else
	      {
	          alert("Please select Registration ID from list");
	          return false;
	      }
	       
	  }	
		</script>
	</HEAD>
	<body>
		<DIV align="center">
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
													<TD class="header1" vAlign="middle" align="left">&nbsp;&nbsp;<STRONG>Number of Visitors</STRONG></TD>
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
										<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="600" align="center" border="0">
											<TBODY>
												<TR class="main_black" align="left">
													<TD class="lightblue_bg" colSpan="3" height="25"><STRONG></STRONG></TD>
												</TR> <!-- Start Code here -->
												<TR vAlign="top" align="left">
													<TD vAlign="top" align="center" width="100%" colSpan="3" height="25"><asp:label id="lblErrorMsg" runat="server" CssClass="errorMsg"></asp:label></TD>
												</TR>
												<TR vAlign="top" align="right" height="10%">
													<TD>
														<TABLE id="Table2" height="100%" cellSpacing="5" cellPadding="0" width="100%" align="center"
															border="0">
															<TR class="main_black">
																<TD vAlign="top" align="left" height="25">From :</TD>
																<TD vAlign="top"><asp:dropdownlist id="ddlFromDay" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
																		<asp:ListItem Value="01">01</asp:ListItem>
																		<asp:ListItem Value="02">02</asp:ListItem>
																		<asp:ListItem Value="03">03</asp:ListItem>
																		<asp:ListItem Value="04">04</asp:ListItem>
																		<asp:ListItem Value="05">05</asp:ListItem>
																		<asp:ListItem Value="06">06</asp:ListItem>
																		<asp:ListItem Value="07">07</asp:ListItem>
																		<asp:ListItem Value="08">08</asp:ListItem>
																		<asp:ListItem Value="09">09</asp:ListItem>
																		<asp:ListItem Value="10">10</asp:ListItem>
																		<asp:ListItem Value="11">11</asp:ListItem>
																		<asp:ListItem Value="12">12</asp:ListItem>
																		<asp:ListItem Value="13">13</asp:ListItem>
																		<asp:ListItem Value="14">14</asp:ListItem>
																		<asp:ListItem Value="15">15</asp:ListItem>
																		<asp:ListItem Value="16">16</asp:ListItem>
																		<asp:ListItem Value="17">17</asp:ListItem>
																		<asp:ListItem Value="18">18</asp:ListItem>
																		<asp:ListItem Value="19">19</asp:ListItem>
																		<asp:ListItem Value="20">20</asp:ListItem>
																		<asp:ListItem Value="21">21</asp:ListItem>
																		<asp:ListItem Value="22">22</asp:ListItem>
																		<asp:ListItem Value="23">23</asp:ListItem>
																		<asp:ListItem Value="24">24</asp:ListItem>
																		<asp:ListItem Value="25">25</asp:ListItem>
																		<asp:ListItem Value="26">26</asp:ListItem>
																		<asp:ListItem Value="27">27</asp:ListItem>
																		<asp:ListItem Value="28">28</asp:ListItem>
																		<asp:ListItem Value="29">29</asp:ListItem>
																		<asp:ListItem Value="30">30</asp:ListItem>
																		<asp:ListItem Value="31">31</asp:ListItem>
																	</asp:dropdownlist><asp:dropdownlist id="ddlFromMonth" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
																		<asp:ListItem Value="01">Jan</asp:ListItem>
																		<asp:ListItem Value="02">Feb</asp:ListItem>
																		<asp:ListItem Value="03">Mar</asp:ListItem>
																		<asp:ListItem Value="04">Apr</asp:ListItem>
																		<asp:ListItem Value="05">May</asp:ListItem>
																		<asp:ListItem Value="06">June</asp:ListItem>
																		<asp:ListItem Value="07">July</asp:ListItem>
																		<asp:ListItem Value="08">Aug</asp:ListItem>
																		<asp:ListItem Value="09">Sept</asp:ListItem>
																		<asp:ListItem Value="10">Oct</asp:ListItem>
																		<asp:ListItem Value="11">Nov</asp:ListItem>
																		<asp:ListItem Value="12">Dec</asp:ListItem>
																	</asp:dropdownlist><asp:dropdownlist id="ddlFromYear" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
																		<asp:ListItem Value="2010">2010</asp:ListItem>
																		<asp:ListItem Value="2009">2009</asp:ListItem>
																		<asp:ListItem Value="2008">2008</asp:ListItem>
																		<asp:ListItem Value="2007">2007</asp:ListItem>
																		<asp:ListItem Value="2006">2006</asp:ListItem>
																		<asp:ListItem Value="2005">2005</asp:ListItem>
																		<asp:ListItem Value="2004">2004</asp:ListItem>
																		<asp:ListItem Value="2003">2003</asp:ListItem>
																		<asp:ListItem Value="2002">2002</asp:ListItem>
																		<asp:ListItem Value="2001">2001</asp:ListItem>
																		<asp:ListItem Value="2000">2000</asp:ListItem>
																		<asp:ListItem Value="1999">1999</asp:ListItem>
																		<asp:ListItem Value="1998">1998</asp:ListItem>
																	</asp:dropdownlist></TD>
																<TD vAlign="top" align="left" height="25">To :</TD>
																<TD vAlign="top"><asp:dropdownlist id="ddlToDay" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
																		<asp:ListItem Value="01">01</asp:ListItem>
																		<asp:ListItem Value="02">02</asp:ListItem>
																		<asp:ListItem Value="03">03</asp:ListItem>
																		<asp:ListItem Value="04">04</asp:ListItem>
																		<asp:ListItem Value="05">05</asp:ListItem>
																		<asp:ListItem Value="06">06</asp:ListItem>
																		<asp:ListItem Value="07">07</asp:ListItem>
																		<asp:ListItem Value="08">08</asp:ListItem>
																		<asp:ListItem Value="09">09</asp:ListItem>
																		<asp:ListItem Value="10">10</asp:ListItem>
																		<asp:ListItem Value="11">11</asp:ListItem>
																		<asp:ListItem Value="12">12</asp:ListItem>
																		<asp:ListItem Value="13">13</asp:ListItem>
																		<asp:ListItem Value="14">14</asp:ListItem>
																		<asp:ListItem Value="15">15</asp:ListItem>
																		<asp:ListItem Value="16">16</asp:ListItem>
																		<asp:ListItem Value="17">17</asp:ListItem>
																		<asp:ListItem Value="18">18</asp:ListItem>
																		<asp:ListItem Value="19">19</asp:ListItem>
																		<asp:ListItem Value="20">20</asp:ListItem>
																		<asp:ListItem Value="21">21</asp:ListItem>
																		<asp:ListItem Value="22">22</asp:ListItem>
																		<asp:ListItem Value="23">23</asp:ListItem>
																		<asp:ListItem Value="24">24</asp:ListItem>
																		<asp:ListItem Value="25">25</asp:ListItem>
																		<asp:ListItem Value="26">26</asp:ListItem>
																		<asp:ListItem Value="27">27</asp:ListItem>
																		<asp:ListItem Value="28">28</asp:ListItem>
																		<asp:ListItem Value="29">29</asp:ListItem>
																		<asp:ListItem Value="30">30</asp:ListItem>
																		<asp:ListItem Value="31">31</asp:ListItem>
																	</asp:dropdownlist><asp:dropdownlist id="ddlToMonth" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
																		<asp:ListItem Value="01">Jan</asp:ListItem>
																		<asp:ListItem Value="02">Feb</asp:ListItem>
																		<asp:ListItem Value="03">Mar</asp:ListItem>
																		<asp:ListItem Value="04">Apr</asp:ListItem>
																		<asp:ListItem Value="05">May</asp:ListItem>
																		<asp:ListItem Value="06">June</asp:ListItem>
																		<asp:ListItem Value="07">July</asp:ListItem>
																		<asp:ListItem Value="08">Aug</asp:ListItem>
																		<asp:ListItem Value="09">Sept</asp:ListItem>
																		<asp:ListItem Value="10">Oct</asp:ListItem>
																		<asp:ListItem Value="11">Nov</asp:ListItem>
																		<asp:ListItem Value="12">Dec</asp:ListItem>
																	</asp:dropdownlist><asp:dropdownlist id="ddlToYear" CssClass="txtarea" Runat="server">
																		<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
																		<asp:ListItem Value="2010">2010</asp:ListItem>
																		<asp:ListItem Value="2009">2009</asp:ListItem>
																		<asp:ListItem Value="2008">2008</asp:ListItem>
																		<asp:ListItem Value="2007">2007</asp:ListItem>
																		<asp:ListItem Value="2006">2006</asp:ListItem>
																		<asp:ListItem Value="2005">2005</asp:ListItem>
																		<asp:ListItem Value="2004">2004</asp:ListItem>
																		<asp:ListItem Value="2003">2003</asp:ListItem>
																		<asp:ListItem Value="2002">2002</asp:ListItem>
																		<asp:ListItem Value="2001">2001</asp:ListItem>
																		<asp:ListItem Value="2000">2000</asp:ListItem>
																		<asp:ListItem Value="1999">1999</asp:ListItem>
																		<asp:ListItem Value="1998">1998</asp:ListItem>
																	</asp:dropdownlist></TD>
																<TD vAlign="top"><asp:button id="btnSubmit" runat="server" Text="Search" onclick="btnSubmit_Click"></asp:button><asp:button id="btnshowall" runat="server" Text="Show All" onclick="btnshowall_Click"></asp:button></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR class="small_maroon">
													<td align="left">&nbsp;<asp:checkbox id="chkAll" onclick="CheckAllCandidate(); DeselectAll();" CssClass="chkbox" Runat="server"
															Text="Select All" Font-Bold="True"></asp:checkbox><input id="hdTotalCandidateCount" type="hidden" value="0" name="hdTotalCandidateCount"
															runat="server"><asp:button id="btnDeselectAll" Runat="server" Width="1px" Height="1px"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label id="lblTotalRecord" Runat="server"></asp:label></td>
												</TR>
												<TR>
													<TD vAlign="top" align="center">
														<asp:datagrid id="dgVisitorCount" runat="server" AllowPaging="True" GridLines="Vertical" CellPadding="3"
															BackColor="White" OnPageIndexChanged="dgVisitorCount_PageIndexChanged" BorderWidth="1px" BorderStyle="None"
															BorderColor="#999999" AutoGenerateColumns="False" CssClass="main_black" onselectedindexchanged="dgVisitorCount_SelectedIndexChanged">
															<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
															<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
															<ItemStyle HorizontalAlign="Center" ForeColor="Black" VerticalAlign="Middle" BackColor="#EEEEEE"></ItemStyle>
															<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
																BackColor="#000084"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn>
																	<HeaderTemplate>
																		<asp:CheckBox ID="chkHeader" CssClass="chkbox" onclick="CheckAll(this);" Runat="server"></asp:CheckBox>
																	</HeaderTemplate>
																	<ItemTemplate>
																		<asp:Checkbox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" Runat="server"></asp:Checkbox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="S.No.">
																	<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<ItemTemplate>
																		<%# Container.ItemIndex+1 %>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn SortExpression="RegistrationId ASC" HeaderText="Registration ID">
																	<ItemTemplate>
																		<asp:Label ID="lblRegistration" Text='<%#DataBinder.Eval(Container.DataItem,"RegistrationId")%>' Runat="server">
																		</asp:Label>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="FName" HeaderText="First Name"></asp:BoundColumn>
																<asp:BoundColumn DataField="MName" HeaderText="Middle Name"></asp:BoundColumn>
																<asp:BoundColumn DataField="LName" HeaderText="Last Name"></asp:BoundColumn>
																<asp:BoundColumn DataField="Address" HeaderText="Residential Address"></asp:BoundColumn>
																<asp:BoundColumn DataField="City" HeaderText="City"></asp:BoundColumn>
																<asp:BoundColumn DataField="State" HeaderText="State"></asp:BoundColumn>
																<asp:BoundColumn DataField="STDCode" HeaderText="STD Code"></asp:BoundColumn>
																<asp:BoundColumn DataField="LandlinephoneNo" HeaderText="Phone Number(Landline)"></asp:BoundColumn>
																<asp:BoundColumn DataField="MobilePhone" HeaderText="Phone Number(Cellphone)"></asp:BoundColumn>
																<asp:BoundColumn DataField="EmailId" HeaderText="Email ID"></asp:BoundColumn>
																<asp:BoundColumn DataField="FirstClickdate" HeaderText="FirstClickdate" DataFormatString="{0:dd-MMM-yyyy}"></asp:BoundColumn>
																<asp:BoundColumn DataField="NoOfClicks" HeaderText="No. of Clicks"></asp:BoundColumn>
															</Columns>
															<PagerStyle Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
												</TR> <!-- End Code here -->
												<TR>
													<TD align="right"><asp:button id="btnExport" runat="server" Text="Export To Excel" onclick="btnExport_Click"></asp:button><input id="hdHeaderCheckBox" type="hidden" value="0" name="hdHeaderCheckBox" runat="server"><input id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
															runat="server">
													</TD>
												</TR>
												<TR>
													<TD class="small_blue" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>Total number of hits 
															on TJ Link&nbsp;:&nbsp;
															<asp:label id="lblTotalHits" Runat="server"></asp:label></STRONG></TD>
												</TR>
											</TBODY>
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
		</DIV>
	</body>
</HTML>
