<%@ Register TagPrefix="uc2" TagName="nac_headermenu1" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Benefits.aspx.cs" Inherits="NASSCOM_NAC.Web.Benefits" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NAC - Benefits</title>
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/jscript">
    </script>
</head>
<body>
   <form id="Form1" method="post" runat="server">
		
			 <div class="outerbody">			
		
									 <uc2:nac_headermenu1 id="Nac_headermenu2" runat="server"></uc2:nac_headermenu1>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2>Key Benefits To Various Stakeholders</h2>
                         
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
                                                     </div>
													<strong>Job Aspirants / Test Takers</strong>
													<ul>
														<li>
														A common, transparent recruitment process across all BPO companies
														<li>
														No need to go through the same recruitment process at different companies
														<li>
														Ability to identify self strengths and weaknesses through test scores
														<li>
														Ability to do a 'training need analysis', which will help them improve on weak 
														areas through training programs
														<li>
															Employment facilitation using NAC scores
														</li>
													</ul>
													<strong>Educational Institutes</strong>
													<ul>
														<li>
														Identifying the training needs of students and analyzing the gaps
														<li>
														Aligning the course curricula with industry requirements – bridging the 
														"education" to "employability" gap
														<li>
														Preparing the students on skills that act as pre-requisites to work in the 
														industry
														<li>
															Contributing to the industry by preparing the students through a pre-defined 
															approach
														</li>
													</ul>
													<strong>Government</strong>
													<ul>
														<li>
														Employment generation through increased employability of talent
														<li>
														Help in attracting serious investors
														<li>
														Preparing the students on skills that act as pre-requisites to work in the 
														industry
														<li>
															Will help create a concept of 'education' to 'employability'
														</li>
													</ul>
													<table width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td align="right" valign="top">
															</td>
														</tr>
													</table>
											</td>
										</tr>
                                            
                                            <tr>
											<td align="left" valign="top" class="small_black"><a name="6"></a><h2>Employment 
                                                Facilitation For NAC TEST Takers</h2>
												
												<p>
														Scores of all NAC test takers are shared, primarily with all the endorsing 
														companies, and companies directly connect to those who perform well in the NAC 
														assessment and meet defined job criteria.&nbsp;&nbsp;
												<table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td align="right" valign="top">
														</td>
													</tr>
												</table>
                                                </p>
											</td>
										</tr>

											</table>
									
									</div>
										
									</td>
									<td width="1"><IMG height="1" alt="" src="Images/spacer.gif" width="1"></td>
								</tr>
                                                                                                        

                                                     </div>
                                                     </div> 
                       

   
           

               <%--<div class="footer">  <img src="Images/footer.gif" /></div>--%>
                  <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>


          
		</form>
        </body>

</html>

