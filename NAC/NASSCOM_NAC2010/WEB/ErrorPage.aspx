<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Page language="c#" Codebehind="ErrorPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.ErrorPage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>System Error</title>
		
		 <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
		 <link href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet" />	
		
	    
	</head>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0">

		<div class="outerbody" align="center">			
		
									 <uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                    <div class="inner-content">
                        <h2 align="left"><strong><IMG src="Images/icon_err.gif"></strong>Error occured</h2>
			                
									<table id="Table2" cellSpacing="0" cellPadding="0" border="0" width="100%">
										
										<tr vAlign="top" align="center">
											<td align="center"><br>
												<table cellspacing="1" cellpadding="0" border="0" style="width: 100%">
													<tr>
														<td>
															<table id="Table4" cellspacing="1" cellpadding="1"  align="center" border="0" 
                                                                width="100%">
																<TBODY>
													</tr>
													<tr align="left">
														<td class="small_maroon">
															<strong>
																<asp:Literal id="ltlErrorMessage" runat="server"></asp:Literal></strong></td>
													</tr>
													<TR>
														<TD height="20"></TD>
													</TR>
													<TR>
														<TD class="main_black">If problem persists, please report Administrator</TD>
													</TR>
													<TR>
														<TD height="20"></TD>
													</TR>
													<tr align="center">
														<td>
															<INPUT id="NoPrint" onclick="javascript:history.go(-1);" type="button" value="Back" class="btn2">
															&nbsp;</td>
													</tr>
													
												</table>
											</td>
										</tr>
									 </td>
									<td width="1"><IMG height="1" alt="" src="Images/spacer.gif" width="1"></td>
								</tr>
										
									</table>
								
                                      

				    </div>
                   
                </div>
           
			<div class="footer">  <img src="Images/footer2014.gif" /></div>
             </div> 

	</body>
</HTML>
