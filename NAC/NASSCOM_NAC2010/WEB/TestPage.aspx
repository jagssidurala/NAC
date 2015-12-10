<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page language="c#" ValidateRequest="false" Codebehind="TestPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.TestPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
  <HEAD>
		<TITLE>NACWelcomeText</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<META content="MSHTML 6.00.2900.3086" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<BODY>
		<FORM id="frmLogin" name="frmLogin" method="post" runat="server">
			<div style="LEFT: 0px; POSITION: relative; TOP: 0px"><span id="highlighter" style="FONT-SIZE: 18px; LEFT: 0px; CLIP: rect(0px 0px auto 0px); FONT-FAMILY: Verdana; POSITION: absolute; TOP: 0px; BACKGROUND-COLOR: yellow"></span></div>
			<script type="text/javascript">

				function SetbodyText()
				{
					document.getElementById("txtBody").innerText = document.getElementById("divBody").innerHTML;
					
					
				}
				//changes the fontname or fontsize or praagraph settings of the 
				//selected text in the div Body
				function ChangeFormat(sDropDown)
				{
					var sSelected;
					if (sDropDown=="Paragraph")
					{
						sSelected=document.NACWelcomeText.cmbParagraph[document.MailTemplate.cmbParagraph.selectedIndex].value	
						document.execCommand("FormatBlock", false, sSelected);
					}
					if (sDropDown=="FontName")
					{
						sSelected=document.NACWelcomeText.cmbFontNames[document.MailTemplate.cmbFontNames.selectedIndex].value	
						document.execCommand("FontName", false, sSelected);
					}
					if (sDropDown=="FontSize")
					{
						sSelected=document.NACWelcomeText.cmbFontSize[document.MailTemplate.cmbFontSize.selectedIndex].value	
						document.execCommand("FontSize", false, sSelected);
					}
				}
				// function to remove any leading spaces in a string
				function lTrim(sStr)
				{
					var sAlpha;
					var sRetStr = sStr;
					if (sStr)
						for (sAlpha = sRetStr.charAt(0); sAlpha == " "; sRetStr = sRetStr.substr(1,sRetStr.length - 1), sAlpha = sRetStr.charAt(0));
					return sRetStr; 
				}

				// function to remove any trailing spaces in a string
				function rTrim(sStr)
				{
					var sAlpha;
					var sRetStr = sStr;
					if (sStr)
						for (sAlpha=sRetStr.charAt(sRetStr.length - 1); sAlpha == " "; sRetStr = sRetStr.substr(0,sRetStr.length - 1), sAlpha = sRetStr.charAt(sRetStr.length - 1));
					return sRetStr; 
				}

				// function to remove all leading and trailing spaces in a string
				function allTrim(sStr)
				{
					return rTrim(lTrim(sStr));
				}
				
				// For checking if the required fields are empty
				// or if the user wants to overwrite the shown template  
				
				
				//for giving the toggle effect to images and applying the style
				//to the selected text. 
				function ToggleImages(effect)
				{
					var strEffect;
					strEffect=effect ;
					if (strEffect=='Cut')
					{
						MM_swapImage('Cut','','Images/cut_click.bmp',1);
						document.execCommand('Cut');
						divBody.focus();
					}
					if (strEffect=='Copy')
					{
						MM_swapImage('Copy','','Images/copy_click.bmp',1);
						document.execCommand('Copy');
						divBody.focus();
					}
					if (strEffect=='Paste')
					{
						MM_swapImage('Paste','','Images/Paste_click.bmp',1);
						document.execCommand('Paste');
						divBody.focus();
					}
					if (strEffect=="Bold")
					{
						MM_swapImage('Bold','','Images/bold_clicked.bmp',1);	
						document.execCommand("Bold");
						divBody.focus();
					}
					if (strEffect=="Italic")
					{
						MM_swapImage('Italic','','Images/italic_clicked.bmp',1);
						document.execCommand("Italic");
						divBody.focus();
					}
					if (strEffect=="Underline")
					{
						MM_swapImage('Underline','','Images/underline_clicked.bmp',1);
						document.execCommand("UnderLine");
						divBody.focus();
					}
					if (strEffect=="HyperLink")
					{
						var strtext;																	
						MM_swapImage('HyperLink','','Images/hyper_down.bmp',1);
						var strAnchor;	
						var strAnchorText;
						var anchor= document.selection.createRange().htmlText;		
				
				
						/*var anchor = EditorGetElement("A", document.selection.createRange().parentElement());
						var strtext = prompt("enter link location (eg. http://www.grapecity.com):", anchor ? anchor.href : "http://"); */
						
						var oSpan= window.document.createElement("Span");
						
						oSpan=window.document.body.insertAdjacentElement("beforeEnd",oSpan);
						oSpan.innerHTML=anchor;
						var oHref=oSpan.getElementsByTagName("A"); //firstChild;												
						
						if(oHref[0] == null)
						{
							strtext = prompt("enter link location (eg. http://www.grapecity.com):","http://");							
						}
						else
						{
							strAnchor=oHref[0].href;												
							strtext = prompt("enter link location (eg. http://www.grapecity.com):",strAnchor);							
						}						
						oSpan.removeNode(true);	
						MM_swapImage('HyperLink','','Images/hyper_up.bmp',1);
						
						if (typeof(strtext)=="object" || strtext == "" || strtext == "http://")
						{
						// do nothing						
						}
						else											
						{
						  	oSelection = document.selection.createRange();							  												
							strAnchorText= "<A style='text-decoration : underline;color:blue;'  href='" + strtext + "'>" + oSelection.text + "</A>";
							oSelection.pasteHTML(strAnchorText); 													
						}						
					divBody.focus();
					}
					if (strEffect=="LeftAlign")
					{
						MM_swapImage('LeftAlign','','Images/leftalign_clicked.bmp',1);
						document.execCommand("JustifyLeft");
						divBody.focus();
					}
					if (strEffect=="MiddleAlign")
					{
						MM_swapImage('MiddleAlign','','Images/middlealign_clicked.bmp',1);
						document.execCommand("JustifyCenter");
						divBody.focus();
					}
					if (strEffect=="RightAlign")
					{
						MM_swapImage('RightAlign','','Images/rightalign_clicked.bmp',1);
						document.execCommand("JustifyRight");
						divBody.focus();
					}
					if (strEffect=="NumericBullet")
					{
						MM_swapImage('NumericBullet','','Images/numbredbulleting_clicked.bmp',1);
						document.execCommand("InsertOrderedList");
						divBody.focus();
					}
					if (strEffect=="Bullet")
					{
						MM_swapImage('Bullet','','Images/bulleting_clicked.bmp',1);
						document.execCommand("InsertUnorderedList");
						divBody.focus();
					}
					if (strEffect=="IndentRight")
					{
						MM_swapImage('IndentRight','','Images/indent2_click.bmp',1);
						document.execCommand("Indent");
						divBody.focus();
					}
					if (strEffect=="IndentLeft")
					{
						MM_swapImage('IndentLeft','','Images/indent1_click.bmp',1);
						document.execCommand("Outdent");
						divBody.focus();
					}
				}
				
				
				function EditorGetElement(tagName, start)
				{
					while (start && start.tagName != tagName) {
						start = start.parentElement;
						}
					return start;
				}

				// For rating the page
				function vote()
				{
				open("vote-pop.asp","newWindow","scrollbars= no toolbar=no,location=no,width=300, height=300 top=0 left=10");
				}

				// For Preloading image
				function MM_preloadImages() { //v3.0
				var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
					var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
					if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
				}
				
				// For swapping image
				function MM_swapImage() { //v3.0
				var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
				if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
				}

				// For restoring the image
				function MM_swapImgRestore() { //v3.0
				var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
				}

				// Jumping to a given option in menu
				function MM_jumpMenu(targ,selObj,restore){ //v3.0
				eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
				if (restore) selObj.selectedIndex=0;
				}
				
				// Searching for an object (invoke by SwapImage function)
				function MM_findObj(n, d) { //v4.0
				var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
					d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
				if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
				for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
				if(!x && document.getElementById) x=document.getElementById(n); return x;
				}
				
				// For opening a new window
				function NewWindow(mypage, myname, w, h, scroll) {
				var winl = (screen.width - w) / 2;
				var wint = (screen.height - h) / 2;
				winprops = 'height='+h+',width='+w+',top='+wint+',left='+winl+',scrollbars='+scroll+',resizable'
				win = window.open(mypage, myname, winprops)
				if (parseInt(navigator.appVersion) >= 4) { win.window.focus(); }
				}
				
				// For preloading images
				function preloadNasscom_files() {
				if (document.Nasscom_files) {
					var imgFiles = preloadNasscom_files.arguments;
					var preloadArray = new Array();
					for (var i=0; i<imgFiles.length; i++) {
					preloadArray[i] = new Image;
					preloadArray[i].src = imgFiles[i];
					}
				}
				}
				
				// For swapping images
				function swapImage() {
				var i,j=0,objStr,obj,swapArray=new Array,oldArray=document.swapImgData;
				for (i=0; i > (swapImage.arguments.length-2); i+=3) {
					objStr = swapImage.arguments[(navigator.appName == 'Netscape')?i:i+1];
					if ((objStr.indexOf('document.layers[')==0 && document.layers==null) ||
						(objStr.indexOf('document.all[')   ==0 && document.all   ==null))
					objStr = 'document'+objStr.substring(objStr.lastIndexOf('.'),objStr.length);
					obj = eval(objStr);
					if (obj != null) {
					swapArray[j++] = obj;
					swapArray[j++] = (oldArray==null || oldArray[j-1]!=obj)?obj.src:oldArray[j];
					obj.src = swapImage.arguments[i+2];
				} }
				document.swapImgData = swapArray;
				}
				
				// For restoring the images
				function swapImgRestore() {
				if (document.swapImgData != null)
					for (var i=0; i<(document.swapImgData.length-1); i+=2)
					document.swapImgData[i].src = document.swapImgData[i+1];
				}
				//CR-526, 24Aug 2005 - Satinder -(MTI)
				// for asking for confirmation for delete Template
				function ValidateDelete()
				{
					return confirm('Are you Sure you want to delete the Template?');
				}

			</script>			
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<TBODY>
					<TR class="white_bg">
						<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
						<TD vAlign="top" align="center">						
						<ajax:AjaxPanel id="AjaxPanel" runat="server" Height="100%">
							<TABLE class="black_bg" id="Table2" cellSpacing="0" cellPadding="0" width="741" align="center"
								border="0">
								<TBODY>
									<TR class="white_bg" vAlign="top" align="left">
										<TD>
											<TABLE id="tblHeader" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<TR vAlign="top" align="left">
														<td>
															<table id="tblHeader1" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr vAlign="top" align="left">
																	<td width="39%" background="images/header_bg.gif"><IMG height="85" src="images/logo1.gif"></td>
																	<td align="right" background="images/header_bg.gif">&nbsp;<IMG id="imgStateLogo" height="86" src="images/ag_logo.gif" runat="server">
																	</td>
																</tr>
															</table>
														</td>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
									<TR class="blue_bg" vAlign="top" align="left">
										<TD class="header1" vAlign="middle">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr vAlign="top">
													<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;&nbsp;<asp:label id="lblState" runat="server"></asp:label>&nbsp;NAC</td>
													<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
												</tr>
											</table>
										</TD>
									</TR>
									<TR class="white_bg" vAlign="top" align="center">
										<TD align="center"><BR>
											<TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
												<TBODY>
													<TR>
														<TD vAlign="top" align="left" width="70%">
															<!--For Nagaland. Welcome Message -->
															<!-- End Nagaland. Welcome Message -->
															<!--For Rajasthan Welcome Message -->
															<!--Mail Formatting -->
															<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
																<tr>
																	<td colspan="2" style="FONT-WEIGHT: bold">
																		<asp:Label ID="lblMessage" Runat="server" Visible="False" CssClass="errarea"></asp:Label>
																	</td>
																</tr>
																<tr>
																	<td class="main_black">User TypeId:</td>
																	<td><asp:dropdownlist id="cmbUserType" Runat="server" Width="184px">
																			<asp:ListItem Value="1">Candidate</asp:ListItem>
																			<asp:ListItem Value="2">Admin</asp:ListItem>
																		</asp:dropdownlist></td>
																</tr>
																<tr>
																	<td class="main_black">State ID:</td>
																	<td><asp:dropdownlist id="cmbStates" Runat="server" Width="184px"></asp:dropdownlist></td>
																</tr>
																<tr>
																	<td class="main_black">Test Name:</td>
																	<td><asp:dropdownlist id="cmbTestName" Runat="server" AutoPostBack="True" Width="184px" onselectedindexchanged="cmbTestName_SelectedIndexChanged">																			
																			<asp:ListItem Value="NACTest1">NACTest1</asp:ListItem>
																			<asp:ListItem Value="NACTest2">NACTest2</asp:ListItem>
																			<asp:ListItem Value="NACTest3">NACTest3</asp:ListItem>
																	</asp:dropdownlist></td>
																</tr>
																<TR>
																	<TD vAlign="top" class="main_black">Body:</TD>
																	<TD vAlign="top">
																		<table cellSpacing="0" cellPadding="0" width="500" bgColor="gainsboro" border="1">
																			<TBODY>
																				<tr>
																					<td><SELECT class="InputFont" id="cmbParagraph" onchange="ChangeFormat('Paragraph');" name="cmbParagraph"
																							runat="server">
																							<OPTION value="Normal" selected>Normal</OPTION>
																							<OPTION value="Formatted">Formatted</OPTION>
																							<OPTION value="Address">Address</OPTION>
																							<OPTION value="Heading 1">Heading 1</OPTION>
																							<OPTION value="Heading 2">Heading 2</OPTION>
																							<OPTION value="Heading 3">Heading 3</OPTION>
																							<OPTION value="Heading 4">Heading 4</OPTION>
																							<OPTION value="Heading 5">Heading 5</OPTION>
																							<OPTION value="Heading 6">Heading 6</OPTION>
																							<OPTION value="Numbered List">Numbered List</OPTION>
																							<OPTION value="Bulleted List">Bulleted List</OPTION>
																							<OPTION value="Directory List">Directory List</OPTION>
																							<OPTION value="Menu List">Menu List</OPTION>
																							<OPTION value="Definition Term">Definition Term</OPTION>
																							<OPTION value="Definition">Definition</OPTION>
																						</SELECT>&nbsp;&nbsp;<SELECT class="InputFont" id="cmbFontNames" onchange="ChangeFormat('FontName');" name="cmbFontNames"
																							runat="server">
																							<OPTION value="System" selected>System</OPTION>
																							<OPTION value="Terminal">Terminal</OPTION>
																							<OPTION value="Fixedsys">Fixedsys</OPTION>
																							<OPTION value="Roman">Roman</OPTION>
																							<OPTION value="Modern">Modern</OPTION>
																							<OPTION value="Script">Script</OPTION>
																							<OPTION value="Small Fonts">Small Fonts</OPTION>
																							<OPTION value="MS Serif">MS Serif</OPTION>
																							<OPTION value="Courier">Courier</OPTION>
																							<OPTION value="MS Sans Serif">MS Sans Serif</OPTION>
																							<OPTION value="Marlett">Marlett</OPTION>
																							<OPTION value="Arial">Arial</OPTION>
																							<OPTION value="Courier New">Courier New</OPTION>
																							<OPTION value="Lucida Console">Lucida Console</OPTION>
																							<OPTION value="Lucida Sans Unicode">Lucida Sans Unicode</OPTION>
																							<OPTION value="Times New Roman">Times New Roman</OPTION>
																							<OPTION value="Wingdings">Wingdings</OPTION>
																							<OPTION value="Symbol">Symbol</OPTION>
																							<OPTION value="Verdana">Verdana</OPTION>
																							<OPTION value="Arial Black">Arial Black</OPTION>
																							<OPTION value="Comic Sans MS">Comic Sans MS</OPTION>
																							<OPTION value="Impact">Impact</OPTION>
																							<OPTION value="Georgia">Georgia</OPTION>
																							<OPTION value="Palatino Linotype">Palatino Linotype</OPTION>
																							<OPTION value="Tahoma">Tahoma</OPTION>
																							<OPTION value="Trebuchet MS">Trebuchet MS</OPTION>
																							<OPTION value="Webdings">Webdings</OPTION>
																							<OPTION value="Microsoft Sans Serif">Microsoft Sans Serif</OPTION>
																							<OPTION value="Map Symbols">Map Symbols</OPTION>
																							<OPTION value="Arial Narrow">Arial Narrow</OPTION>
																							<OPTION value="Arial Unicode MS">Arial Unicode MS</OPTION>
																							<OPTION value="Batang">Batang</OPTION>
																							<OPTION value="Book Antiqua">Book Antiqua</OPTION>
																							<OPTION value="Bookman Old Style">Bookman Old Style</OPTION>
																							<OPTION value="Century">Century</OPTION>
																							<OPTION value="Century Gothic">Century Gothic</OPTION>
																							<OPTION value="Garamond">Garamond</OPTION>
																							<OPTION value="Haettenschweiler">Haettenschweiler</OPTION>
																							<OPTION value="Monotype Corsiva">Monotype Corsiva</OPTION>
																							<OPTION value="MS Mincho">MS Mincho</OPTION>
																							<OPTION value="MS Outlook">MS Outlook</OPTION>
																							<OPTION value="PMingLiU">PMingLiU</OPTION>
																							<OPTION value="SimSun">SimSun</OPTION>
																							<OPTION value="Wingdings 2">Wingdings 2</OPTION>
																							<OPTION value="Wingdings 3">Wingdings 3</OPTION>
																							<OPTION value="MT Extra">MT Extra</OPTION>
																							<OPTION value="Copperplate Gothic Bold">Copperplate Gothic Bold</OPTION>
																							<OPTION value="Copperplate Gothic Light">Copperplate Gothic Light</OPTION>
																						</SELECT>&nbsp;&nbsp;
																						<SELECT class="InputFont" id="cmbFontSize" onchange="ChangeFormat('FontSize');" name="cmbFontSize"
																							runat="server">
																							<OPTION value="1">1</OPTION>
																							<OPTION value="2" selected>2</OPTION>
																							<OPTION value="3">3</OPTION>
																							<OPTION value="4">4</OPTION>
																							<OPTION value="5">5</OPTION>
																							<OPTION value="6">6</OPTION>
																							<OPTION value="7">7</OPTION>
																							<OPTION value="8">8</OPTION>
																						</SELECT><br>
																						<hr noShade SIZE="1">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Cut');" height="23"
																							src="Images//cut_up.bmp" align="top" border="0" name="Cut" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Copy');" height="23"
																							src="Images//Copy_up.bmp" align="top" border="0" name="Copy" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Paste');" height="23"
																							src="Images//Paste_up.bmp" align="top" border="0" name="Paste" unselectable="On">
																						<asp:imagebutton id="btnLine2" runat="server" Height="25px" BackColor="Transparent" ImageUrl="Images//VerticalLine.bmp"></asp:imagebutton><IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Bold');" height="23"
																							src="Images//Bold_up.bmp" align="top" border="0" name="Bold" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Italic');" height="23"
																							src="Images//Italic_up.bmp" align="top" border="0" name="Italic" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Underline');" height="23"
																							src="Images//underline_up.bmp" align="top" border="0" name="Underline" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('HyperLink');" height="23"
																							src="Images//hyper_up.bmp" align="top" border="0" name="HyperLink" unselectable="On">
																						<asp:imagebutton id="btnLine4" runat="server" Height="25px" BackColor="Transparent" ImageUrl="Images//VerticalLine.bmp"></asp:imagebutton><IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('LeftAlign');" height="23"
																							src="Images//leftalign_up.bmp" align="top" border="0" name="LeftAlign" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('MiddleAlign');" height="23"
																							src="Images//middlealign_up.bmp" align="top" border="0" name="MiddleAlign" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('RightAlign');" height="23"
																							src="Images//rightalign_up.bmp" align="top" border="0" name="RightAlign" unselectable="On">
																						<asp:imagebutton id="btnLine3" runat="server" Height="25px" BackColor="Transparent" ImageUrl="Images//VerticalLine.bmp"></asp:imagebutton><IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('NumericBullet');" height="23"
																							src="Images//numbredbulleting_up.bmp" align="top" border="0" name="NumericBullet" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('Bullet');" height="23"
																							src="Images//bulleting_up.bmp" align="top" border="0" name="Bullet" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('IndentRight');" height="23"
																							src="Images//indent2_up.bmp" align="top" border="0" name="IndentRight" unselectable="On">
																						<IMG onmouseup="MM_swapImgRestore();" onmousedown="ToggleImages('IndentLeft');" height="23"
																							src="Images//indent1_up.bmp" align="top" border="0" name="IndentLeft" unselectable="On">
																						<br>
																						<hr noShade SIZE="1">
																						<div id="divBody" contentEditable="true" style="BORDER-RIGHT: 1px solid; PADDING-RIGHT: 3px; BORDER-TOP: 1px solid; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; OVERFLOW: auto; BORDER-LEFT: 1px solid; WIDTH: 500px; PADDING-TOP: 3px; BORDER-BOTTOM: 1px solid; HEIGHT: 300px; BACKGROUND-COLOR: white; font-face: Arial"
																							runat="server"></div>
																						<INPUT id="txtBody" type="hidden" name="txtBody" runat="server">
																					</td>
																				</tr>
																	</TD>
																</TR>
															</TABLE>
													<tr>
														<td colspan="2" align="center">
															<asp:button id="btnSubmit" runat="server" Cssclass="main_black" Text="Save welcome text" EnableViewState="False"
																Width="178px" onclick="btnSubmit_Click"></asp:button>
														</td>
													</tr>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<br>
			</TD> </TR> </TBODY> </TABLE></ajax:AjaxPanel></TD>
			<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td></TR>
			<TR>
				<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></TD>
				<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
				<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
			</TR></TBODY></TABLE>
		</FORM>
	</BODY>
</HTML>
