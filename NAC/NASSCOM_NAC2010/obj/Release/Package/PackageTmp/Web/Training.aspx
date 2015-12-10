<%@ Register TagPrefix="uc2" TagName="nac_headermenu" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="NASSCOM_NAC.Web.Training" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NAC - Training & Development</title>
   
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
		
			 <div class="outerbody">			
		
									 <uc2:nac_headermenu id="Nac_headermenu1" runat="server"></uc2:nac_headermenu>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2>Training And Development</h2>
                         
													<p>NASSCOM with its key BPO member companies like Accenture, Convergys, Deloitte, Dell, Genpact, and IBM have collaborated to collectively have developed this program, the Global Business Foundation Skills (GBFS). The GBFS program is aimed to empower students with foundation skills necessary for the BPO industry. 
													For more information about the GBFS program, you can download the 
													<a style="TEXT-DECORATION: underline" href="../Web/Download.aspx?FileName=GBFS - OBF - Published V1.pdf"
																		target="_blank" class="small_blue">Outcomes Based Framework</a>
													 for GBFS.</p>
                                                    
                                                     </div>
                                                     </div> 
                       

   
           

              <%-- <div class="footer">  <img src="Images/footer.gif" /></div>--%>
                 <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>


          
		</form>
	</body>
</html>
