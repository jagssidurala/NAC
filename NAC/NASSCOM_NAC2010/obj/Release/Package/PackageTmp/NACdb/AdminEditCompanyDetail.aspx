<%@ Page language="c#" Codebehind="AdminEditCompanyDetail.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.AdminEditCompanyDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Admin Edit Company Detail</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<LINK rel="stylesheet" type="text/css" href="../Web/Stylesheet/nasscomNew.css">
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{
				var strText;			      
				//Validate Company Name		
				strText = document.getElementById("txtCompanyName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter company name");
					document.getElementById("txtCompanyName").focus();
					document.getElementById("txtCompanyName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanyName").style.backgroundColor = 'white';
				}
				
				//Validate Company Address		
				strText = document.getElementById("txtCompanyAddress").value;
				if (Trim(strText) == "")
				{
					alert("Please enter company address");
					document.getElementById("txtCompanyAddress").focus();
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'yellow';
					return false;
				}
				
				else if(strText.length > 100)
				{
					alert("CompanyAddress exceeding maximum limit of 100 characters.");
					document.getElementById("txtCompanyAddress").focus();
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCompanyAddress").style.backgroundColor = 'white';
				}
				
				//Validate Official Phone
				strText = document.getElementById("txtOfficialPhone").value;
				if (Trim(strText) == "")
				{
					alert("Please enter official phone number");
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if(strText.length < 7)
				{
					alert("Official Phone No. can't be less than 7 digits");
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsNumeric(strText))
				{
					alert("Please enter a valid official phone number");
					document.getElementById("txtOfficialPhone").value ='';
					document.getElementById("txtOfficialPhone").focus();
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtOfficialPhone").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Name
				strText = document.getElementById("txtSPOCName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter SPOC name");
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsAlphabet(strText))
				{
					alert("Please enter a valid SPOC name");
					document.getElementById("txtSPOCName").value ='';
					document.getElementById("txtSPOCName").focus();
					document.getElementById("txtSPOCName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCName").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Phone
				strText = document.getElementById("txtSPOCPhone").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +" phone number");
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if(strText.length < 7)
				{
					alert("Please enter a valid "+ document.getElementById("txtSPOCName").value +"'s phone number. Can't be less than 7 digits");
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!IsNumeric(strText))
				{
					alert("Please enter a valid "+ document.getElementById("txtSPOCName").value +"'s phone number");
					document.getElementById("txtSPOCPhone").value ='';
					document.getElementById("txtSPOCPhone").focus();
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSPOCPhone").style.backgroundColor = 'white';
				}
				
				//Validate SPOC Email
				strText = document.getElementById("txtSPOCEmail").value;
				if (Trim(strText) == "")
				{
					alert("Please enter "+ document.getElementById("txtSPOCName").value +" email ID");
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else if (!(emailCheck(strText)) && Trim(strText)!="")
				{
					alert("Please enter valid email address");
					document.getElementById("txtSPOCEmail").value ='';
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else if(Trim(strText).search("@gmail.com")>=0 || Trim(strText).search("@yahoo.co")>=0 || Trim(strText).search("@rediff.co")>=0 || Trim(strText).search("@zapak.co")>=0 || Trim(strText).search("@hotmail.co")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").value ='';
						document.getElementById("txtSPOCEmail").focus();
						document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
						return false;
					}
					
				
				else
				{
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'white';
				}
				
				//Validate agreement expiry date
				if(ValidateDate())
				{
					if (confirm("Are you sure you want to save?") == true)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			
			function ValidateDate()
			{
			
				var currentDate = new Date();
				var expiryDate = new Date();
				var strText;
				
				if(document.getElementById("ddlDay").value == "0")
				{
					alert("Please enter day");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				if(document.getElementById("ddlMonth").value == "0")
				{
					alert("Please enter Month");
					document.getElementById("ddlMonth").focus();
					document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
					return false;
				}
				if(document.getElementById("ddlYear").value == "0")
				{
					alert("Please enter year");
					document.getElementById("ddlYear").focus();
					document.getElementById("ddlYear").style.backgroundColor = 'yellow';
					return false;
				}
							      
				if(document.getElementById("ddlDay").value != "0" && document.getElementById("ddlMonth").value != "0" && document.getElementById("ddlYear").value != "0")
				{
					strText = document.getElementById("ddlDay").value + "-" + document.getElementById("ddlMonth").value + "-" + document.getElementById("ddlYear").value;
					expiryDate = expiryDate.setFullYear(document.getElementById("ddlYear").value,document.getElementById("ddlMonth").value - 1, document.getElementById("ddlDay").value);
					if (isValidDate(strText)!="")
					{
						alert("Please enter valid date");
						document.getElementById("ddlDay").focus();
						document.getElementById("ddlDay").style.backgroundColor = 'yellow';
						return false;
					}
					else if(currentDate >= expiryDate)
					{
						alert("Past or current date for Agreement expiry is not allowed");
						document.getElementById("ddlDay").focus();
						document.getElementById("ddlDay").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("ddlDay").style.backgroundColor = 'white';
						return true;
					}
				}
			}
			
			  function fillOnlyAlphabetValue(eV)
			  {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!IsAlphabet(varValue))
				{
					alert("Please enter alphabets only");
					document.getElementById(varControlId).value='';
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}	
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
				}
			}
		    
		    function ValidateEmailAddress(eV)
		    {
				var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (!(emailCheck(varValue)) && Trim(varValue)!="")
				{
					alert("Please enter valid email address");
					document.getElementById("txtSPOCEmail").value='';
					document.getElementById("txtSPOCEmail").focus();
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					if(varValue.search("gmail")>=0 || varValue.search("yahoo")>=0 || varValue.search("rediff")>=0 || varValue.search("zapak")>=0 || varValue.search("hotmail")>=0)
					{
						alert("Please enter official email ID");
						document.getElementById("txtSPOCEmail").value='';
						document.getElementById("txtSPOCEmail").focus();
						document.getElementById("txtSPOCEmail").style.backgroundColor = 'yellow';
						return false;
					}
					document.getElementById("txtSPOCEmail").style.backgroundColor = 'white';
				}		        
		        
		    }
		    
		    function fillOnlyNumericValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        if (!IsNumeric(varValue))
				{
					alert("Please enter numeric values");
					document.getElementById(varControlId).value = '';
					document.getElementById(varControlId).focus();
					document.getElementById(varControlId).style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
				}		        
		    }
		    
		     function imposeMaxLength(Object, MaxLen, evt)
		 {
			evt = (evt) ? evt : event;
			var charCode = (evt.charCode) ? evt.charCode :((evt.which) ? evt.which : evt.keyCode);
			if ((charCode == 8) || (charCode == 46)|| (charCode == 9)|| (charCode == 16))
			{
				return true;
			} 
			else 
			{
			//alert(key.keyCode);
			return (Object.value.length <= MaxLen);
			}
		 }
		 
		  function checkBlankValue(eV)
			  {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        
		        if (Trim(varValue) != "")
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
				}
			}
			
		function isNumberKey(evt)
		{
			var charCode = (evt.which) ? evt.which : event.keyCode
			if (charCode > 31 && (charCode < 48 || charCode > 57))
				return false;
			return true;
		}
      
    function isAlpha(code)
			{
			
				//var code = e.keyCode ? event.keyCode : e.which ? e.which : e.charCode;
				//alert(code);
				if ((code >= 65 && code <= 90)||(code >= 97 && code <= 122) ||(code >= 35 && code <= 40) || code==46 || code==8 || code==17 || code==127 || code==9 || code==16  || code==32 || code==46 )
				{return true;}
				else {return false;}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			<div align="center">
				<TABLE id="Table1" border="0" cellSpacing="1" align="center">
					<TR>
						<TD colSpan="2" align="center"><STRONG><FONT size="4"><asp:label id="Label7" runat="server" CssClass="pageheader">Edit Company Detail</asp:label></FONT></STRONG></TD>
					</TR>
					<tr>
						<td colSpan="2">&nbsp;</td>
					</tr>
					<TR>
						<TD><asp:label id="Label1" runat="server" CssClass="label_black_bold">Company Name</asp:label></TD>
						<TD><asp:textbox id="txtCompanyName" runat="server" CssClass="newUserTextbox" MaxLength="50" Width="180px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label2" runat="server" CssClass="label_black_bold">Company Address</asp:label></TD>
						<TD><asp:textbox id="txtCompanyAddress" runat="server" MaxLength="100" Width="180px" TextMode="MultiLine"
								Font-Size="11px" BorderColor="#CCCCCC" BorderStyle="Solid" Font-Names="Tahoma"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label3" runat="server" CssClass="label_black_bold">Official Phone No.</asp:label></TD>
						<TD><asp:textbox id="txtOfficialPhone" runat="server" CssClass="newUserTextbox" MaxLength="15" Width="180px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label4" runat="server" CssClass="label_black_bold">Company SPOC for NAC</asp:label></TD>
						<TD><asp:textbox id="txtSPOCName" runat="server" CssClass="newUserTextbox" MaxLength="50" Width="180px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label5" runat="server" CssClass="label_black_bold">Company SPOC's phone number</asp:label></TD>
						<TD><asp:textbox id="txtSPOCPhone" runat="server" CssClass="newUserTextbox" MaxLength="15" Width="180px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label6" runat="server" CssClass="label_black_bold">Company SPOC's email ID</asp:label></TD>
						<TD><asp:textbox id="txtSPOCEmail" runat="server" CssClass="newUserTextbox" MaxLength="50" Width="180px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label8" runat="server" CssClass="label_black_bold"> Agreement Expiry Date</asp:label></TD>
						<TD><asp:dropdownlist id="ddlDay" runat="server">
								<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
								<asp:ListItem Value="1">01</asp:ListItem>
								<asp:ListItem Value="2">02</asp:ListItem>
								<asp:ListItem Value="3">03</asp:ListItem>
								<asp:ListItem Value="4">04</asp:ListItem>
								<asp:ListItem Value="5">05</asp:ListItem>
								<asp:ListItem Value="6">06</asp:ListItem>
								<asp:ListItem Value="7">07</asp:ListItem>
								<asp:ListItem Value="8">08</asp:ListItem>
								<asp:ListItem Value="9">09</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
								<asp:ListItem Value="13">13</asp:ListItem>
								<asp:ListItem Value="14">14</asp:ListItem>
								<asp:ListItem Value="15">15</asp:ListItem>
								<asp:ListItem Value="16">16</asp:ListItem>
								<asp:ListItem Value="17">17</asp:ListItem>
								<asp:ListItem Value="18">18</asp:ListItem>
								<asp:ListItem Value="19">19</asp:ListItem>
								<asp:ListItem Value="20">20</asp:ListItem>
								<asp:ListItem Value="21">21</asp:ListItem>
								<asp:ListItem Value="22">22</asp:ListItem>
								<asp:ListItem Value="23">23</asp:ListItem>
								<asp:ListItem Value="24">24</asp:ListItem>
								<asp:ListItem Value="25">25</asp:ListItem>
								<asp:ListItem Value="26">26</asp:ListItem>
								<asp:ListItem Value="27">27</asp:ListItem>
								<asp:ListItem Value="28">28</asp:ListItem>
								<asp:ListItem Value="29">29</asp:ListItem>
								<asp:ListItem Value="30">30</asp:ListItem>
								<asp:ListItem Value="31">31</asp:ListItem>
							</asp:dropdownlist><asp:dropdownlist id="ddlMonth" runat="server">
								<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
								<asp:ListItem Value="1">January</asp:ListItem>
								<asp:ListItem Value="2">February</asp:ListItem>
								<asp:ListItem Value="3">March</asp:ListItem>
								<asp:ListItem Value="4">April</asp:ListItem>
								<asp:ListItem Value="5">May</asp:ListItem>
								<asp:ListItem Value="6">June</asp:ListItem>
								<asp:ListItem Value="7">July</asp:ListItem>
								<asp:ListItem Value="8">August</asp:ListItem>
								<asp:ListItem Value="9">September</asp:ListItem>
								<asp:ListItem Value="10">October</asp:ListItem>
								<asp:ListItem Value="11">November</asp:ListItem>
								<asp:ListItem Value="12">December</asp:ListItem>
							</asp:dropdownlist><asp:dropdownlist id="ddlYear" runat="server">
								<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
								<asp:ListItem Value="2015">2015</asp:ListItem>
								<asp:ListItem Value="2014">2014</asp:ListItem>
								<asp:ListItem Value="2013">2013</asp:ListItem>
								<asp:ListItem Value="2012">2012</asp:ListItem>
								<asp:ListItem Value="2011">2011</asp:ListItem>
								<asp:ListItem Value="2010">2010</asp:ListItem>
								<asp:ListItem Value="2009">2009</asp:ListItem>
								<asp:ListItem Value="2008">2008</asp:ListItem>
								<asp:ListItem Value="2007">2007</asp:ListItem>
								<asp:ListItem Value="2006">2006</asp:ListItem>
								<asp:ListItem Value="2005">2005</asp:ListItem>
								<asp:ListItem Value="2004">2004</asp:ListItem>
								<asp:ListItem Value="2003">2003</asp:ListItem>
								<asp:ListItem Value="2002">2002</asp:ListItem>
								<asp:ListItem Value="2001">2001</asp:ListItem>
								<asp:ListItem Value="2000">2000</asp:ListItem>
								<asp:ListItem Value="1999">1999</asp:ListItem>
								<asp:ListItem Value="1998">1998</asp:ListItem>
								<asp:ListItem Value="1997">1997</asp:ListItem>
								<asp:ListItem Value="1996">1996</asp:ListItem>
								<asp:ListItem Value="1995">1995</asp:ListItem>
								<asp:ListItem Value="1994">1994</asp:ListItem>
								<asp:ListItem Value="1993">1993</asp:ListItem>
								<asp:ListItem Value="1992">1992</asp:ListItem>
								<asp:ListItem Value="1991">1991</asp:ListItem>
								<asp:ListItem Value="1990">1990</asp:ListItem>
								<asp:ListItem Value="1989">1989</asp:ListItem>
								<asp:ListItem Value="1988">1988</asp:ListItem>
								<asp:ListItem Value="1987">1987</asp:ListItem>
								<asp:ListItem Value="1986">1986</asp:ListItem>
								<asp:ListItem Value="1985">1985</asp:ListItem>
								<asp:ListItem Value="1984">1984</asp:ListItem>
								<asp:ListItem Value="1983">1983</asp:ListItem>
								<asp:ListItem Value="1982">1982</asp:ListItem>
								<asp:ListItem Value="1981">1981</asp:ListItem>
								<asp:ListItem Value="1980">1980</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="lblLoginId" runat="server" CssClass="label_black_bold">LoginId</asp:label></TD>
						<TD colSpan="2" align="left"><asp:label id="lblLoginIdValue" runat="server" CssClass="label_black"></asp:label></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="lblPassword" runat="server" CssClass="label_black_bold">Password</asp:label></TD>
						<TD colSpan="2" align="left"><asp:textbox id="txtPassword" runat="server" MaxLength="20" Enabled="False"></asp:textbox></TD>
					</TR>
					<tr>
						<td colSpan="2" align="center">&nbsp;<asp:label id="lblError" runat="server" CssClass="errorMessage"></asp:label></td>
					</tr>
					<TR>
						<TD colSpan="2" align="center"><asp:button id="btnCancel" tabIndex="1" runat="server" CssClass="button" Text="Cancel" onclick="btnCancel_Click"></asp:button>&nbsp;
							<asp:button id="btnSubmit" runat="server" CssClass="button" Text="Save" onclick="btnSubmit_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</div>
		</form>
	</body>
</HTML>
