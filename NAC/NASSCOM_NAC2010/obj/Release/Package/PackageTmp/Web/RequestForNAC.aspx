<%@ Register TagPrefix="uc2" TagName="nac_headermenu" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestForNAC.aspx.cs" Inherits="NASSCOM_NAC.Web.RequestForNAC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <h2>Request For Conducting NAC</h2>
                         
													<p>
                                                    <br>
													With the participation of the Industry Council, 'Globarena Technologies Pvt. 
													Ltd.' has been chosen by NASSCOM as the official vendor for holding the NAC 
													administrations across the country. Under the aegis of NASSCOM, Globarena can 
													spearhead and conduct NAC assessment for individual colleges, universities, 
													companies, etc.
													<br>
													<br>
													<u>About Globarena Technologies Pvt. Ltd.</u>
													<br>
													<br>
													Globarena Technologies is an ISO 9001:2008 certified company with a PAN India 
													presence with over a decade’s experience in the education service industry 
													providing training, eLearning, assessment and examination solutions. Globarena 
													has been working closely with many colleges, universities, government 
													department, corporate and has developed eLearning content and delivered 
													training programmes in the areas of English language skills, aptitude skills, 
													soft skills, IT and domains skills.
													<br>
													<br>
													Currently, the company works with over 18 universities, 1500+ institutions and 
													3 state government departments on various educational and eLearning initiatives 
													impacting over 30 Lakh students through its products and services. Globarena 
													Technologies has over 1000 hours of self-learn programs that can be delivered 
													to students though multimode delivery mechanism (i.e., LAN and/or WEB)

                                                    <br>
                                                    <br>
													<u>For conducting NAC event, please connect with the NAC vendor using the following 
														information: </u>
													<br>
													<br>
													Globarena Technologies Private Limited
													<br>
													F-28, Madhuranagar, Yousufguda, Hyderabad - 500038
													<br>
													Andhra Pradesh, India
													<br>
													Tel: 91-40-23750190/91
													<br>
                                                    <br>
													<a href="http://www.globarena.com">www.globarena.com </a>

                                                   </p>

                                                   <p>
														<a href="../../Web/Download.aspx?FileName=NAC Infrastructure Requirements - Consolidated.pdf"
																		target="_blank" class="small_blue"><strong>Download NAC Infrastructure Requirements</strong><br>
														<br>
														</a>
												</p>
                                                    
                                                     </div>
                                                     </div> 
                       

   
           

            <%--   <div class="footer">  <img src="Images/footer.gif" /></div>--%>
               <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>


          
		</form>
	</body>
</html>
