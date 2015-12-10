<%@ Register TagPrefix="uc2" TagName="nac_headermenu" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page language="c#" Codebehind="Faq.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Faq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NAC - FAQs</title>
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
</head>
<body>
		<form id="Form2" method="post" runat="server">
		
			 <div class="outerbody">			
		
									<uc2:nac_headermenu id="Nac_headermenu1" runat="server"></uc2:nac_headermenu>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2>Frequently Asked Questions (FAQ)</h2>
                         
													
                                              <table cellspacing="0" cellpadding="0" border="0" align="center">
                                              <tr>
												<td>
												<ul>
													<li class="textNormal">
													<b>
													Where does Indian BPO 
													industry stand today?</b><br>Indian BPO sector continues to grow from strength to strength, witnessing high levels of activity - both onshore as well as offshore. The industry clocked export revenue of US$ 12.7 billion in FY2008-09 registering about 18% growth from FY2007-08. The BPO sector also created 86,000 jobs in FY08-09 adding the total employment to around 7,86,000 in the same period. According to various research agencies, the BPO sector is poised to register an evenhanded growth rate and is expected to generate 6 times more employment in next 12 years.<br>&nbsp;
													<li class="textNormal">
													 <b>What role do BPO companies 
												play in NAC?</b><br>This initiative will always be driven by the ‘need of the BPO industry' when it comes to the human talent / skills required for different types of jobs that the industry offers, hence BPO companies are bound to play a vital role here. During the phase-I of the NAC, companies helped devise the NAC program and define its core objective.<br>
													<br>During the current phase and the times to come, industry will play a more crucial role in lending credibility / endorsement to the NAC and will help ensuring that this program gets differentiated amongst other similar products which are available in the market. Companies would support the program by various means and ensure that, over a period of time, NAC is mandated to be the first-level filter while they hire for entry-level positions.<br>&nbsp;
													<li class="textNormal">
													<b>What are the skills being 
												assessed in NAC?</b><br>Please see "NAC Test Matrix" section on the homepage<br>&nbsp;
													<li class="textNormal"><b>What is the minimum educational qualification / eligibility required to participate in the program?</b><br>At least Final-Year Undergraduate (according to the '10+2+3' system) – all 'General' streams<br>&nbsp;
													<li class="textNormal"><b>Are there any training programs / courses that one needs to attend before attempting NAC?</b><br>Since NAC encapsulates skills which are extremely basic in nature, NASSCOM does not recommend going for training/coaching before someone attempts NAC test. However, there are very many training programs, specific to BPO skills, which are available across the country that may be attended if found convincing by any candidate. However, NASSCOM does not endorse any such training program.<br>&nbsp;
													<li class="textNormal"><b>How to participate in the program and take the test?</b><br>Currently, one can take the test <u>only</u> if:
<ul>
<li>A state is holding the test and is inviting candidates for it
<li>A college/university/institute is holding the test for its own students<br>&nbsp;</ul>
In the current scenario, <u>one cannot take the test as an individual</u>; however, necessary backend work is underway in order to have the 'retail drives' in place where individual candidates will be able to register themselves and take the test.<br>&nbsp;
													
													<li class="textNormal"><b>Does one need to pay for this program?</b>
													<br>Under the two currently-running models/approaches (as mentioned above) may/may not require the candidate to pay for the test as this is completely at the discretion of the client organizing for the test (e.g. state / college / university / institute). However, once the retail model is launched, candidates will essentially have to pay a nominal registration fee.<br>&nbsp;
													<li class="textNormal"><b>Will people have access to NAC from small / tier-II, III cities?</b>
													<br>Once the 'retail model' is launched, candidates will be able to appear for NAC even from the small cities; however, it would be a gradual process. If the facility/center is not available in certain regions, one will have to go to the nearest available test center.<br>&nbsp;
													<li class="textNormal"><b>What is the progress on NAC initiative?</b><br>So far, NAC has been conducted in 14 states across India and has also been done for few individual colleges/universities with a total number of 19,000+ candidates appearing for it. There are multiple states that will be covered gradually and the dialogue is on with some of them. Schedules regarding the same shall be published at NAC website time-to-time and shall also be made known to the public through various media sources.<br>&nbsp;
													<li class="textNormal"><b>Who will own this program going forward?</b><br>NASSCOM, on behalf of the industry, will continue to play the central role. However, the business & governing model of this program, in view of long term, is under consideration.<br>&nbsp;
													<li class="textNormal"><b>Whom should we contact at NASSCOM for further details?</b><br>For further details on NAC, please contact Dr. Sandhya Chintala, Director (Education Initiatives) / Mr. Nikhil Gupta, Manager (Education Initiatives) at <a href="mailto:nac@nasscom.in">nac@nasscom.in</a><br>&nbsp;
												</ul>
												</td>
											</tr>
                                            

                                            </table>
                                            
                                                
                                               		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../Web/Download.aspx?FileName=NAC Sample Paper1.0.pdf" target="_blank" class="small_blue">
																		<strong>Download NAC Sample Paper</strong><br>
																		<br>
																	</a>
                                                                                                     

                                                     </div>
                                                     </div> 
                       

   
           

            <%--   <div class="footer">  <img src="Images/footer.gif" /></div>--%>
               <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>


          
		</form>
	</body>

	
</html>
