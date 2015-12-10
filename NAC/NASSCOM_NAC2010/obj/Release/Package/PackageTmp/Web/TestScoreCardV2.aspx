<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<%@ Page language="c#" Codebehind="TestScoreCardV2.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TestScoreCardV2" %>


<html>
	<head>
		<title>NASSCOM Assessment of Competence –Technology SCORE CARD</title>
        <link href="Stylesheet/style.css" type="text/css" rel="stylesheet"> 
        </head>
	<body>
    		
		
		<form id="form1" runat="server">
    		
		
		<div id="bigcontainer">
			<div id="container">
				<div id="header">
					<div class="logo">
                        <asp:image id="imgLogo" runat="server" Height="95px" 
                            Width="192px"></asp:image></div>
					<div class="pagetitle"><h1>NASSCOM Assessment of Competence&nbsp; 
                    <asp:label id="lblDiagnostic" Runat="server"></asp:label>
                    <br>
                        SCORE CARD</h1>
					</div>
				</div>
				<div class="userdetails">
				<span class="title"><h3><strong>CANDIDATE DETAILS</strong></h3></span>
				
					<table cellspacing="2" bgcolor="#000000" border="0" cellpadding="5" align="center" id="Table1" > 
 
					
                        <tr>
							<th>
								<strong>Registration ID</strong></th>
							<td ><asp:label id="lblRegistrationId" Runat="server"></asp:label></td>
                            <td class="imageholder" rowspan="5" align="center" valign="middle">											
								<asp:Image id="imgCandidate" runat="server" CssClass="border"  Width="95" Height="110" BorderWidth="0"
									AlternateText=""></asp:Image>
							</td>
						</tr>
						<tr>
							<th>
								<strong>Name</strong></th>
								<td><span><asp:label id="lblName" Runat="server"></asp:label></span></td>
						</tr>
						<tr>
							<th>
								<strong>Date of Birth</strong></th>
							<td><span><asp:label id="lblDOB" Runat="server"></asp:label></span></td>
						</tr>
						<tr>
							<th>
								<strong>Test Location</strong></th>
							<td><span><asp:label id="lblTestLocation" Runat="server"></asp:label></span></td>
						</tr>
						<tr>
							<th>
								<strong>Test Date</strong></th>
							<td><span><asp:label id="lblTestDate" Runat="server"></asp:label></span></td>
						</tr>
					</table>
				</div>
				<div class="testScore1">
					<h2>Test Scores</h2>
					<table  cellspacing="2" bgcolor="#000000"  cellpadding="5" align="center" id="Table2">
						<thead>
							<tr>
								<td>Skill</td>
								<td>Score Range</td>
								<td>Your Score</td>
							</tr>
						</thead>
						<tr>
							<td class="skillmain leftalign boldtext"><strong>Analytical Ability</strong></td>
							<td class="skillmain"><asp:label id="lblPg1AnalyticalRange" runat="server" ></asp:label></td>
							<td class="skillmain boldtext"><asp:label id="lblPg1AnalyticalScore" runat="server" ></asp:label></td>
						</tr>
                        <tr>
							<td colspan="3">&nbsp;</td>
						</tr>
                        <tr>
							<td class="skillmain leftalign boldtext"><strong>Quantitative Ability</strong></td>
							<td class="skillmain"><asp:label id="lblPg1QuantitativeRange" runat="server" ></asp:label></td>
							<td class="skillmain boldtext"><asp:label id="lblPg1QuantitativeScore" runat="server" ></asp:label></td>
						</tr>
                        <tr>
							<td colspan="3">&nbsp;</td>
						</tr>
                        <tr>
							<td class="skillmain leftalign boldtext"><strong>English Writing</strong></td>
							<td class="skillmain"><asp:label id="lblPg1EWOverallRange" runat="server" ></asp:label></td>
							<td class="skillmain boldtext"><asp:label id="lblPg1EWOverallScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Grammer</td>
							<td class="leftalign"><asp:label id="lblPg1EWGrammarRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1EWGrammarScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Content</td>
							<td class="leftalign"><asp:label id="lblPg1EWContentRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1EWContentScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Vocabulary</td>
							<td class="leftalign"><asp:label id="lblPg1EWVocabularyRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1EWVocabularyScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Spelling &amp; Punctuation</td>
							<td class="leftalign"><asp:label id="lblPg1EWSpellingRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1EWSpellingScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td colspan="3">&nbsp;</td>
							
						</tr>
                        <tr>
							<td class="skillmain leftalign boldtext"><strong>Speaking &amp;Listening</strong></td>
							<td class="skillmain"><asp:label id="lblPg1SLOverallRange" runat="server" ></asp:label></td>
							<td class="skillmain boldtext"><asp:label id="lblPg1SLOverallScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Sentence Mastery</td>
							<td class="leftalign"><asp:label id="lblPg1SLSentenceRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1SLSentenceScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Vocabulary</td>
							<td class="leftalign"><asp:label id="lblPg1SLVocabularyRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1SLVocabularyScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Fluency</td>
							<td class="leftalign"><asp:label id="lblPg1SLFluencyRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1SLFluencyScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td class="leftalign">- Pronunciation</td>
							<td class="leftalign"><asp:label id="lblPg1SLPronunciationRange" runat="server" ></asp:label></td>
							<td class="boldtext"><asp:label id="lblPg1SLPronunciationScore" runat="server" ></asp:label></td>
						</tr>
						<tr>
							<td colspan="3">&nbsp;</td>
							
						</tr>
						<tr>
							<td class="skillmain leftalign boldtext"><strong>Keyboard Skills<br/>
							- Typing Skill (Words per minute)<br/>
							- Typing Accuracy (%age)
							</strong>
							</td>
							<td class="skillmain">&nbsp;<br/>
							-<br/>
							-
							</td>
							<td class="skillmain boldtext"><span>&nbsp;</span><br/>
							<asp:label id="lblPg1KSTAccuracyRange" runat="server" ></asp:label>
							<br/>
							<asp:label id="lblPg1KSTAccuracyScore" runat="server" ></asp:label>
							</td>
						</tr>
						<tr>
							<td colspan="3">&nbsp;</td>
							
						</tr>
						<tr>
							<td colspan="3" class="leftalign"><div class="noteOther" ><span><b>Note:</b></span> <span>- NAC Score Report is valid for a year from the date of issue
						<br />
						 - 'NA' is equivalent to 'no attempt'<br />
						- In the Speaking &amp; Listening Test, score of '20' is equivalent to '0'
						
						  <asp:label id="lbldignosticnote" runat="server" ></asp:label>
						</span>
						</div></td>
							
						</tr>
					</table>					
					<div class="note2">
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
NASSCOM Assessment of Competence (NAC) is the official 
                        skills &amp; competency program for the entry level employment opportunities&nbsp;&nbsp;in the ITES-BPO sector</div>
				</div>
			
           
            </div>
            </div>
				<br />	
                <br />	
			   <br />	
			   <br />	
		   <br />	

	<div id="Div1">
			<div id="Div2" class="noborder">
				<div class="analysis">
					<table cellspacing="2" bgcolor="#000000" cellpadding="5" align="center" id="Table3">
						<thead>
							<tr>
								<td colspan="2">Skill Definition & Candidate Score Analysis</td>
							</tr>
						</thead>
						<tr>
							<td class="skill">Analytical Ability</td>
							<td class="skill1" >The objective is to test candidate's approach towards problem solving. The key 
								performance indicators are understanding and accuracy while analyzing and 
								organizing the given data to solve a given question / problem / puzzle etc.
                                <br><br>
                              
                                <asp:label id="lblPg2AnalyticalRange" runat="server" ForeColor="Black" Font-Bold="true"></asp:label>
                                <asp:label id="lblPg2AnalyticalRemarks" runat="server" ForeColor="Black"></asp:label>
														 
							</td>
						</tr>
                        <br><br>
						<tr>
							<td class="skill">Quantitative Ability</td>
							<td class="skill1">The objective is to test candidate's ability to apply logic and calculations while tackling day to day arithmetic, involving simple to complicated problems/situations. The key performance indicators are understanding and accuracy while exercising calculations for arriving at answer/solution/conclusion for a given problem/puzzle<br>
								<br />
                                <asp:label id="lblPg2QuantitativeRange" runat="server" ForeColor="Black" Font-Bold="true"></asp:label>
                                <asp:label id="lblPg2QuantitativeRemarks" runat="server" ForeColor="Black"></asp:label><br><br>
							</td>
                          </tr>
						<tr>
							<td class="skill">English Writing</td>
							<td  class="skill1"> <B>Overall  </B><asp:label id="lblPg2EWOverallScore" runat="server" ForeColor="Black" Font-Bold="true"></asp:label>
                            <br><br>
                          
                            The objective is to test a candidate's ability to use correct grammar, appropriate 
							vocabulary, spellings and punctuation in written communication. 
							
                            <br><br><asp:label id="lblPg2EWOverallRange" runat="server" ForeColor="Black" Font-Bold="true"></asp:label>
                            <asp:label id="lblPg2EWOverallRemarks" runat="server" ForeColor="Black"></asp:label><br> <br>
							
                            	<B>Grammar<asp:label id="lblPg2EWGrammarRange" runat="server" ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2EWGrammarRemarks" runat="server" ForeColor="Black"></asp:label><br><br>
                              
                                <B>Content<asp:label id="lblPg2EWContentRange" runat="server" ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2EWContentRemarks" runat="server" ForeColor="Black"></asp:label><br><br>

                                 <B>Vocabulary<asp:label id="lblPg2EWVocabularyRange" runat="server" 
                                    ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2EWVocabularyRemarks" runat="server" ForeColor="Black"></asp:label><br><br>

                                  <B>Spelling and Punctuation<asp:label id="lblPg2EWSpellingRange" 
                                    runat="server" ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2EWSpellingRemarks" runat="server" ForeColor="Black"></asp:label><br><br>

								</td>
						</tr>
						<tr>
							<td class="skill">Keyboard Skills</td>
							<td  class="skill1">
								Assessment of English Usage building block through evaluation 
								of Grammar. Topics that were assessed are Noun, Pronoun, Article, Tenses, Verb, 
								Adverb, Adjectives, Prepositions, Conjunction, Subject-Verb Agreement, 
								Modifiers.<br><br>
								
								 <B>Typing Speed<asp:label id="lblPg2KSTSpeedRange" runat="server" 
                                    ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2KSTSpeedRemarks" runat="server" ForeColor="Black"></asp:label><br><br>
                                
                                <B>Typing Accuracy<asp:label id="lblPg2KSTAccuracyRange" runat="server" 
                                    ForeColor="Black" Font-Bold="true"></asp:label></B>
                                <asp:label id="lblPg2KSTAccuracyRemarks" runat="server" ForeColor="Black"></asp:label><br><br>
                               
                                </td>
						</tr>
                        <tr>
							<td class="skill">Speaking Listening</td>
							<td  class="skill1">
								 <B>Overall </B> <asp:label id="lblPg2SLOverallScore" runat="server" 
                                    ForeColor="Black" Font-Bold="true"></asp:label>
								<br>
                                The Overall Score of the test represents the ability to understand spoken English 
								and speak it intelligibly at a native-like conversational pace on everyday 
								topics. Scores are based on a weighted combination of four diagnostic sub 
								scores. Scores are reported in the range from 20 to 80.
                               
                                <br><br>
								 <B><asp:label id="lblPg2SLOverallRange" runat="server" ForeColor="Black"></asp:label></B>
                                <asp:label id="lblPg2SLOverallRemarks" runat="server" ForeColor="Black"></asp:label><br><br>
                                
                                <B>Sentence Mastery<asp:label id="lblPg2SLSentenceScore" runat="server" 
                                    ForeColor="Black"></asp:label></B><br>
                                SentenceMastery reflects the ability to understand, recall and produce English phrases 
								and clauses in complete sentences. Performance depends on accurate syntactic 
								processing and appropriate usage of words, phrases and clauses in meaningful 
								sentence structures.<br><br>
                               
                                <B><asp:label id="lblPg2SLSentenceRange" runat="server" ForeColor="Black"></asp:label></B>
                                <asp:label id="lblPg2SLSentenceRemarks" runat="server" ForeColor="Black"></asp:label>
                                <br><br>
                                
                                 <B>Vocabulary<asp:label id="lblPg2SLVocabularyScore" runat="server" 
                                    ForeColor="Black"></asp:label></B><br>
                                Vocabulary reflects the ability to understand common everyday words spoken in sentence 
								context and to produce such words as needed. Performance depends on familiarity 
								with the form and meaning of everyday words and their use in connected speech.<br><br>
                              
                                 <B><asp:label id="lblPg2SLVocabularyRange" runat="server" ForeColor="Black"></asp:label></B>
                                <asp:label id="lblPg2SLVocabularyRemarks" runat="server" ForeColor="Black"></asp:label>
                                <br><br>
                                
                                <B>Fluency<asp:label id="lblPg2SLFluencyScore" runat="server" ForeColor="Black"></asp:label></B>
                              <br>
                               Fluency reflects the rhythm, phrasing and timing evident in constructing, reading and 
							   repeating sentences.<br><br>
                              
                                 <B><asp:label id="lblPg2SLFluencyRange" runat="server" ForeColor="Black"></asp:label></B>
                                <asp:label id="lblPg2SLFluencyRemarks" runat="server" ForeColor="Black"></asp:label>
                                <br><br>

                                 <B>Pronunciation<asp:label id="lblPg2SLPronunciationScore" runat="server" 
                                    ForeColor="Black"></asp:label></B>
                                 Pronunciation reflects the ability to produce consonants, vowels and stress in a native-like 
							     manner in sentence context. Performance depends on knowledge of the 
							     phonological structure of everyday words.<br><br>
                              
                                 <B><asp:label id="lblPg2SLPronunciationRange" runat="server" ForeColor="Black"></asp:label></B>
                                <asp:label id="lblPg2SLPronunciationRemarks" runat="server" ForeColor="Black"></asp:label>
                                <br>



                                </td>
						</tr>
						
						<tr>
							<td colspan="2"><i>*Percentile Scores shall be provided over a period of time once a reasonable volume of test takers is generated</i></td>
						</tr>
					</table>
						
					<div class="note2">
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
NASSCOM Assessment of Competence (NAC) is the official 
                        skills &amp; competency program for the entry level employment opportunities&nbsp;&nbsp;in the ITES-BPO sector</div>
				</div>
					
				</div>
			</div>
		</div>

	   
	    </form>

	   
	</body>
</html>

