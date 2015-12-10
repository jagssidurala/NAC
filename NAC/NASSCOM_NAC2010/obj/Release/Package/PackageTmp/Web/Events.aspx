<%@ Register TagPrefix="uc2" TagName="nac_headermenu1" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="NASSCOM_NAC.Web.Events" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NAC - Events</title>
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
</head>
<body>
   <form id="Form1" method="post" runat="server">
		
			 <div class="outerbody">			
		
									 <uc2:nac_headermenu1 id="Nac_headermenu2" runat="server"></uc2:nac_headermenu1>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2>Events</h2>
                         
													 <tr>
									
									<td class="divMatter" vAlign="top">
										<div class="border">
											<table border="0" id="table2" cellspacing="0" cellpadding="0" width="900">
												<tr>
													<td>&nbsp;</td>
											</tr>
											<tr>
											<td align="left" valign="top" >
													<div class="msg_txt">
                                                    
													<table width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td align="center" valign="top">There is no event as on date.
                                                            <br />

                                                            <br />
                                                            Please visit the site later.
															</td>
														</tr>
													</table>
											</td>
										</tr>
                                            
                                           

									</table>
									
									</div>
										
									</td>
									<td width="1"><IMG height="1" alt="" src="Images/spacer.gif" width="1"></td>
								</tr>
                                                                                                        

                                                     </div>
                                                     </div> 
                       

   
           

               <div class="footer">  <img src="Images/footer2014.gif" /></div>
            </div>


          
		</form>
        </body>

</html>

