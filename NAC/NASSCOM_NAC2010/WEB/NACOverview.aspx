<%@ Register TagPrefix="uc2" TagName="nac_headermenu1" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NACOverview.aspx.cs" Inherits="NASSCOM_NAC.Web.NACOverview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Benefit - NAC</title>
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
                    <h2>Overview</h2>
                    <p>
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td align="left" valign="top" class="small_black"><p align="justify"><span class="maroon_head"><strong><a name="1"></a>ABOUT 
															NAC – NASSCOM ASSESSMENT OF COMPETENCE</strong></span><br>
													<br>
													The ITeS-BPO industry is growing at an overwhelming pace and giving a major 
													fillip to the Indian economy. India has established its leadership position 
													globally in the offshoring market and now the availability of skilled manpower 
													is one of the key barriers to the fast growth of the industry.NASSCOM along 
													with program manager, has been working with the Indian ITeS-BPO industry 
													players to create a national assessment and certification program - the NASSCOM 
													Assessment of Competence (NAC). The initiative is aimed at creating a robust 
													and continuous pipeline of talent. This will be done by continuously assessing 
													candidates on key skills through a national standard assessment, thus making it 
													easier for firms to screen candidates and also provide training need analysis 
													to candidates. This will then be tied in to training and development efforts to 
													help more candidates become competent to work in the industry. NASSCOM is 
													following a multi-pronged approach to facilitate manpower development for the 
													short and long term. By following a two-phase strategy, NASSCOM is aiming to 
													build a pool of ITeS-BPO manpower which will be pre-certified, in tune with the 
													needs of the industry and thereby gear up for the future requirements of the 
													sector. In Phase I of this initiative, NASSCOM is looking at creating an 
													Assessment and Certification Program which becomes an industry standard and 
													ensures the transformation of a "trainable" workforce into an "employable" 
													workforce.
												</p>
												<table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td align="right" valign="top">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="left" valign="top" class="small_black"><p align="justify"><span class="maroon_head"><strong><a name="2"></a>CONCEPTUALIZATION 
															OF NAC</strong></span><br>
													<br>
													In-depth meetings with close to 35 players in the ITeS-BPO industry were 
													conducted to understand their recruitment practices, cause of attrition desired 
													skills in a candidate, etc. Based on this, a job-skill matrix was developed 
													which formed the basis for the design of this assessment program. Core and 
													Working Committees from the industry were formed and constant interactions were 
													made to make sure that the program has everything that the industry requires in 
													terms of a pre-employment assessment. An evaluation committee was set up to 
													finalize the vendors and decide on the approach to the pilot.Multi-tier 
													evaluation of the vendors happened after the initial interaction. The 
													identified vendors provided the content and technology to run the test. Amongst 
													the current endorsers for NAC are companies like Genpact, Accenture, Convergys, 
													IBM, WNS &amp; EXL. Discussions have been initiated by NASSCOM with other 
													companies as well to get more endorsements.
												</p>
												<table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td align="right" valign="top">
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="left" valign="top" class="small_black"><p align="justify"><span class="maroon_head"><strong><a name="3"></a>
                                                ELIGIBILITY</strong></span><br>
													<ul type="square">
														<li>
															<strong>Eligibility for NAC</strong>
															<br>
															-&nbsp;&nbsp;Any candidate appearing in 'final year' of under-graduation or an 
															equivalent course is eligible to sit for NAC assessment
															<br>
															-&nbsp;&nbsp;Each College / University should be able to provide at least 
															70-80% of their 'final-year student population' to take NAC assessment
															<br>
															<br>
														<li>
															<strong>NAC Commercials</strong>
															<br>
															The price per NAC test is <u>Rs.360</u> (plus taxes, if any)
															<br>
															<font size="1">Rs.70 as infrastructure charges will be extra in case of test taking 
																place at any of the designated 'NAC retail centers'</font>
														</li>
													</ul>
												<P></P>
											</td>
										</tr>
                                       </table>
                                    </div>
                                </div> 
                       
                       </p>
   
           

             <%--  <div class="footer">  <img src="Images/footer.gif" /></div>--%>
                <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>


          
		</form>
        </body>

</html>
