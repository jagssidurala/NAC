<%@ Register TagPrefix="uc2" TagName="nac_headermenu1" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Register TagPrefix="uc3" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<%@ Page language="c#" Codebehind="SkillCompetency.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.SkillCompetency" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   	<title>NAC - Skill Matrix</title>
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
    <style type="text/css">
        #table1
        {
            height: 401px;
            width: 100%;
        }
    </style>
</head>

    <body>
		<form id="Form2" method="post" runat="server">
		
			 <div class="outerbody">			
		
									 <uc2:nac_headermenu1 id="Nac_headermenu2" runat="server"></uc2:nac_headermenu1>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2>NAC Test Matrix – Testing Themes</h2>                                                    
                                                    <p>
                                                    <table border="0" id="table1" cellspacing="0" cellpadding="0" bordercolor="#cccccc">
															<tr>
																<td>
																	<table width="100%" border="1" cellpadding="4" cellspacing="0" class="grey_bg" id="table2"
																		bordercolor="#cccccc">
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" bgcolor="#a81e37" style="TEXT-ALIGN: center">
																				<font color="#ffffff"><strong>Skills</strong></font></td>
                                                                            <td width="16%" align="left" valign="middle" class="textNormal" bgcolor="#a81e37" style="TEXT-ALIGN: center">
																				<font color="#ffffff"><strong>Competencies Checked</strong></font></td>
																		
																			<td width="10%" align="left" valign="middle" class="textNormal" bgcolor="#a81e37" style="TEXT-ALIGN: center">
																				<font color="#ffffff"><strong>Duration<br>(in mins.)</strong></font></td>
																			<td width="25%" align="left" valign="middle" class="textNormal" bgcolor="#a81e37" style="TEXT-ALIGN: center">
																				<font color="#ffffff"><strong>Mode of delivery</strong></font></td>
																		</tr>
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" style="TEXT-ALIGN: left"><strong>
																					Speaking & Listening 
                                                                                <br />
                                                                                - </strong>Sentence Mastery<br />
&nbsp;- Vocabulary<br />
&nbsp;- Fluency<br />
&nbsp;- Pronunciation </td>
																			<td width="55%" align="left"  class="textNormal" style="TEXT-ALIGN: left">
																				Ability to understand spoken English and speak it intelligibly at a native-like conversational pace on everyday topics.&nbsp;</td>
																			<td width="16%" align="center"   style="TEXT-ALIGN: center">10</td>
																			<td width="34%" align="center" valign="middle" class="textNormal">Online&nbsp;</td>
																		
																		</tr>
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" style="TEXT-ALIGN: left"><strong>
																					Analytical Ability</strong></td>
																			<td width="55%" align="left"  class="textNormal" style="TEXT-ALIGN: left">
																				Approach towards problem solving, understanding and accuracy while analyzing and organizing the given data to solve a given questions / problems / puzzles etc.&nbsp;</td>
																			<td width="16%" align="center"   style="TEXT-ALIGN: center">20</td>
																			<td width="34%" align="center" valign="middle" class="textNormal">Online&nbsp;</td>
																		
																		</tr>
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" style="TEXT-ALIGN: left"><strong>
																					Quantitative Ability</strong></td>
																			<td width="55%" align="left"  class="textNormal" style="TEXT-ALIGN: left">
																				Ability to apply logic and calculations while tackling day-to-day arithmetic, involving simple-to-complicated problems / situations, understanding and accuracy while exercising calculations for arriving at answer / solution / conclusion for a given problem/puzzle.&nbsp;</td>
																			<td width="16%" align="center"   style="TEXT-ALIGN: center">20</td>
																		<td width="34%" align="center" valign="middle" class="textNormal">Online&nbsp;</td>
																			
																		</tr>
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" style="TEXT-ALIGN: left"><strong>
																					<strong>English Writing</strong>
																<br>
																&nbsp;</strong>- Grammar
																<br>
																&nbsp;- Content
																<br>
																&nbsp;- Vocabulary
																<br>
																&nbsp;- Spelling &amp; Punctuation</td>
																			<td width="55%" align="left"  class="textNormal" style="TEXT-ALIGN: left">
																				Ability to use correct grammar, appropriate vocabulary, spellings and punctuation in written communication.&nbsp;</td>
																			<td width="16%" align="center"   style="TEXT-ALIGN: center">20</td>
																			<td width="34%" align="center" valign="middle" class="textNormal">Online&nbsp;</td>
																			
																		</tr>
																		
																		
																		<tr>
																			<td width="15%" align="left" valign="middle" class="textNormal" style="TEXT-ALIGN: left"><strong>
																					<strong>Keyboard Skills</strong>
																<br>
																                </strong>&nbsp;- Typing Speed
																<br>
																&nbsp;- Typing Accuracy</td>
																			<td width="55%" align="left"  class="textNormal" style="TEXT-ALIGN: left">
																				Replication ability while typing / keying-in the given content, speed and accuracy while typing.&nbsp;</td>
																			<td width="16%" align="center"   style="TEXT-ALIGN: center">65</td>
																			<td width="34%" align="center" valign="middle" class="textNormal">Online&nbsp;</td>
																		
																		</tr>
																		<tr>
																			<td width="15%" align="left" valign="top" class="textNormal">&nbsp;</td>
																			<td width="8%" align="right" valign="top" class="textNormal">
																				<em>Total duration</em></td>
																			<td width="16%" align="center" valign="top" class="textNormal"bgcolor="#a81e37" ><font color="#ffffff"><strong>75 mins.</strong></td>
																			<td width="34%" align="left" valign="top" class="textNormal">&nbsp;</td>
																			<td width="25%" align="left" valign="top" class="textNormal">&nbsp;</td>
																		</tr>
																	</table>
																</td>
															</tr>
														</table>
                                                    </p>
                                                    
                                                    
                                                    
                                                    
                                                                                                        

                                                     </div>
                                                     </div> 
                       

   
           
<%--
               <div class="footer">  <img src="Images/footer.gif" /></div>--%>
               <uc3:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc3:nacyearlyfooter>
            </div>



          
		</form>
	</body>
</HTML>
