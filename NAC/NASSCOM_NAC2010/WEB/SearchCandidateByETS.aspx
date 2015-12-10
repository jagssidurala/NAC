<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<%@ Page language="c#" Codebehind="SearchCandidateByETS.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.SearchCandidateByETS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Candidate List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="javascript" type="text/javascript">
		
		function NoJobFairOrScoreCard()
		{
		    alert('No data found!');
		    return false;
		}
		
	  function SelectCandidate()
	  {
	      var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);   
	       
	      if(varSelectedCandidateCount > 0)
	      {
	         return true;
	      }
	      else
	      {
	          alert("Please select candidate from candidate list");
	          return false;
	      }
	       
	  }
		
	
	function ConfirmMessage()
	{
	    if(SelectCandidate())
	     {
	        if(window.confirm('Are you sure, you want to disable the candidate?'))
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
	 
	function SetComponentStatus()
	{
		document.getElementById("txtOtherQualification").style.visibility = "hidden";
	}

	function hideTextBox()
	{
		if(document.getElementById("ddlQualification").value == "0")
		{
		    document.getElementById("dvPostGraduate").style.display = "none";
		    document.getElementById("dvPostGraduate1").style.display = "none";
		    document.getElementById("dvPostGraduate2").style.display = "none";
		}
		else
		{
		    document.getElementById("dvPostGraduate").style.display = "";
		    document.getElementById("dvPostGraduate1").style.display = "";
		    document.getElementById("dvPostGraduate2").style.display = "";
		}
		                
	} 
		    
	function fillHiddenQualification()
	{
		
		document.getElementById("hdQualificationDetails").value = document.getElementById("ddlQualificationDetails").value;
		var varCheckOther;
		var box = document.getElementById("ddlQualificationDetails");	       
		var varOption = document.createElement('OPTION');
		varOption = box.options[box.selectedIndex];		        
		varCheckOther = varOption.text;		        
		varCheckOther = varCheckOther.toLowerCase();	
		    
		if(varCheckOther == 'others')
		    {
		        
		        document.getElementById("txtOtherQualification").style.visibility = "visible";
		        document.getElementById("txtOtherQualification").value = "CONTAINS WORD LIKE";
		    }
		    else
		    {
				document.getElementById("txtOtherQualification").value = "";
				document.getElementById("txtOtherQualification").style.visibility = "hidden";
		    }            
		    
		}
		    
		 function HideText()
		    {
				var strOtherQualification;
				strOtherQualification = document.getElementById("txtOtherQualification").value;
				strOtherQualification = strOtherQualification.toLowerCase();
				if (Trim(strOtherQualification)== 'specify other')
				{
					document.Form1.txtOtherQualification.value = "";
				}
			}
			
		function ChangeCollegeLabelOnLoad()
		{
			
			var varCheckOther;
			var box = document.getElementById("ddlQualification");
			var varOption = document.createElement('OPTION');	
			
			varOption = box.options[box.selectedIndex];	
			varCheckOther = varOption.text;
			varCheckOther = varCheckOther.toLowerCase();
			
			if(varCheckOther == 'undergraduate/graduate')
			{				   
				document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
				document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
			}
			else
			{
				document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
				document.getElementById("divHighestEducationObtainedFrom").innerText = "Graduation done from (College Name):*";
			}
		}
		   
		function ChangeCollegeLabel()
		{
			//document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
			var varCheckOther;
			var box = document.getElementById("ddlQualification");
			var varOption = document.createElement('OPTION');
			
			
			document.getElementById("txtHighestEducationObtainedFrom").value = "";	
		    document.getElementById("txtCollegeAddress").value = "";	
		    document.getElementById("txtHighestEducationCity").value = "";	
			
			
			varOption = box.options[box.selectedIndex];	
			varCheckOther = varOption.text;
			varCheckOther = varCheckOther.toLowerCase();
			if(varCheckOther == 'undergraduate/graduate')
			{				   
				document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
				document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
			}
			else
			{
				document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
				document.getElementById("divHighestEducationObtainedFrom").innerText = "Graduation done from (College Name):*";
			}
		}
		
		function CheckAllCandidate()
		{
		  
		   var chkVar = document.getElementById("chkAll").checked;
		   var varTotalCandidateCount = parseInt(document.getElementById("hdTotalCandidateCount").value);
		   
		   if(chkVar)
		   {
		       var varForm = document.Form1;
		       document.getElementById("hdSelectedCandidateCount").value = varTotalCandidateCount;
		       for(i=0;i<varForm.length;i++)
				{
					e = varForm.elements[i];
					if(e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1))
					{
						e.checked = true;
							
					}
				}
			
		   }
		  	 
			
			
		}
		
		function DeselectAll()
		{
		
		   var chkVar = document.getElementById("chkAll").checked; 
		   if(!chkVar)
		   {
		       var varForm = document.Form1;
		       document.getElementById("hdSelectedCandidateCount").value = 0;
		       for(i=0;i<varForm.length;i++)
				{
					e = varForm.elements[i];
					if(e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1))
					{
					    						 
						e.checked = false;
						
					}
				}
		   }	
		   
		    
		
		}
	
		function CheckAll(checkAllBox)
		{
			var varForm = document.Form1;
			var chkVar = checkAllBox.checked;  
			var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);    
		 
			 
			for(i=0;i<varForm.length;i++)
			{
					e = varForm.elements[i];
					if(e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1)
					{
						if(chkVar)
						{
						   if(!e.checked)
						     {
						        varSelectedCandidateCount = varSelectedCandidateCount + 1;
						     }
							e.checked = true;
						}
						else
						{
							 if(e.checked)
						     {
						        varSelectedCandidateCount = varSelectedCandidateCount - 1;
						     }
							e.checked = false;
						}
					}
			}
			document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount;
		}
	
	
		
		function ChangeHeaderCheck(checkAll)
		{
			 
			var varForm = document.Form1;	 
			var IsCheckAll = true;
			var chkVar = checkAll.checked;
			var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);    
			
			if(chkVar)
			{
			    document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount + 1;
			}
			else
			{
			    document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount - 1;
			}
			
			
			for(i=0;i<varForm.length;i++)
			{
				e = varForm.elements[i];
				if(e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1)
				{
					if(e.checked == false && IsCheckAll)
					{
						IsCheckAll = false;	
						if(document.getElementById("hdHeaderCheckBox").value != "0")
						{
						   document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = false;
						   document.getElementById("chkAll").checked = false;
						}				 
						
					}				 		 
					
				}
			}
			
			if(IsCheckAll)
			{
				if(document.getElementById("hdHeaderCheckBox").value != "0")
				{
					document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = true;
				}	
			}
		}		
							
	function FillHiddenField()
	{
		document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
		document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
		document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;
	}	

 		
	function ValidateData()
	{			 
			 
			var varLastName;
			var varGender;
			var varTestState;
			var varTestCity;
			var varEmploymentStatus;
			var varQualification;
			var varTestCentre;
			var varWillingToRelocate;
			var varSerialNoFrom;
			var varSerialNoTo;
			var varRegistrationIDFrom;
			var varRegistrationIDTo;
			var varYouBelongTo;
			var varMediumOfInstruction;
			var varMediumOfInstructionIn12Th;
			var varSpeakingFrom;
			var varSpeakingTo;
			var varListeningFrom;
			var varListeningTo;
			var varWaitingFrom;
			var varWaitingTo;
			var varAnalyticalFrom;
			var varAnalyticalTo;
			var varResidenceCity;	
			var varDOBFrom;
			var varDOBTo;
			
			if(document.getElementById("ddlFromDay").value != "0" && document.getElementById("ddlFromMonth").value != "0" && document.getElementById("ddlFromYear").value != "0")
			{
			    
				 
				 varDOBFrom = document.getElementById("ddlFromDay").value + "-" + document.getElementById("ddlFromMonth").value + "-" + document.getElementById("ddlFromYear").value;

				if (isValidDate(varDOBFrom)!="")
				{
					alert("Please enter valid date");
					document.getElementById("ddlFromDay").focus();
					document.getElementById("ddlFromDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlFromDay").style.backgroundColor = 'white';
				}
			} 
			else
			{
			   varDOBFrom = "";
			}
			
			if(document.getElementById("ddlToDay").value != "0" && document.getElementById("ddlToMonth").value != "0" && document.getElementById("ddlToYear").value != "0")	
			{			    
				 
				 varDOBTo = document.getElementById("ddlToDay").value + "-" + document.getElementById("ddlToMonth").value + "-" + document.getElementById("ddlToYear").value;

				if (isValidDate(varDOBTo)!="")
				{
					alert("Please enter valid date");
					document.getElementById("ddlToDay").focus();
					document.getElementById("ddlToDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlToDay").style.backgroundColor = 'white';
				}
			}	
			else
			{
			    varDOBTo = "";
			}
			
			 
			 
			 
			 
			 
			varFirstName = document.getElementById("txtName").value;
			varLastName = document.getElementById("txtLastName").value;
			varGender = document.getElementById("ddlGender").value;
			varTestState = document.getElementById("ddlTestState").value;
			varTestCity = document.getElementById("ddlTestCity").value;
			varEmploymentStatus = document.getElementById("ddlEmploymentStatus").value;
			varQualification = document.getElementById("ddlqualification").value;
			varTestCentre = document.getElementById("ddlTestCentre").value;
			varWillingToRelocate = document.getElementById("ddlRelocate").value;
			varSerialNoFrom = document.getElementById("txtSerialNoFrom").value;
			varSerialNoTo = document.getElementById("txtSerialNoTo").value;
			varRegistrationIDFrom = document.getElementById("txtRegistrationIDFrom").value;
			varRegistrationIDTo = document.getElementById("txtRegistrationIDTo").value;
			varYouBelongTo = document.getElementById("rblYouBelongTo").value;
			varMediumOfInstruction = document.getElementById("ddlMediumOfInstruction").value;
			varMediumOfInstructionIn12Th = document.getElementById("ddlMediumOfInstructionIn12Th").value;
			varSpeakingFrom = document.getElementById("txtSpeakingFrom").value;
			varSpeakingTo = document.getElementById("txtSpeakingTo").value;
			varListeningFrom = document.getElementById("txtListeningFrom").value;
			varListeningTo = document.getElementById("txtListeningTo").value;
			varWaitingFrom = document.getElementById("txtWaitingFrom").value;
			varWaitingTo = document.getElementById("txtWaitingTo").value;
			varAnalyticalFrom = document.getElementById("txtAnalyticalFrom").value;
			varAnalyticalTo = document.getElementById("txtAnalyticalTo").value;
			varResidenceCity = document.getElementById("txtResidenceCity").value;
			
		   //Validating All State options
			var box = document.getElementById("ddlTestState");
			var varOption = document.createElement('OPTION');
			var varSelectAll;			
			varOption = box.options[box.selectedIndex];	
			varSelectAll = varOption.text;
			 
			 
			//Validating first name.
			strText = document.getElementById("txtName").value;
			
			if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtName").focus();
					document.getElementById("txtName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtName").style.backgroundColor = 'white';
				}				
		 
			 
			//Validating last name.
			strText = document.getElementById("txtLastName").value;
			
			if (IsAngularBracket(strText))
			{
				alert("Character '< ' is not allowed");
				document.getElementById("txtLastName").focus();
				document.getElementById("txtLastName").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtLastName").style.backgroundColor = 'white';
			}

		 
			
			//validating serial number.
			strText = document.getElementById("txtSerialNoFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtSerialNoFrom").focus();
				document.getElementById("txtSerialNoFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSerialNoFrom").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
			{
				alert("Please enter numeric data");
				document.getElementById("txtSerialNoFrom").focus();
				document.getElementById("txtSerialNoFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSerialNoFrom").style.backgroundColor = 'white';
			}	
			
			//Validating Serial Number.
			strText = document.getElementById("txtSerialNoTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtSerialNoTo").focus();
				document.getElementById("txtSerialNoTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSerialNoTo").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
			{
				alert("Please enter numeric data");
				document.getElementById("txtSerialNoTo").focus();
				document.getElementById("txtSerialNoTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSerialNoTo").style.backgroundColor = 'white';
			}		
		    
		    //Validating Residential City
		    strText = document.getElementById("txtResidenceCity").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtResidenceCity").focus();
				document.getElementById("txtResidenceCity").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtResidenceCity").style.backgroundColor = 'white';
			}
						 
			//Validating Registration Number.
			strText = document.getElementById("txtRegistrationIDFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtRegistrationIDFrom").focus();
				document.getElementById("txtRegistrationIDFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtRegistrationIDFrom").style.backgroundColor = 'white';
			}
			
			//Validating Registration Number.
			
			strText = document.getElementById("txtRegistrationIDTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtRegistrationIDTo").focus();
				document.getElementById("txtRegistrationIDTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtRegistrationIDTo").style.backgroundColor = 'white';
			}
			
			//Validating Speaking From Number.
			
			strText = document.getElementById("txtSpeakingFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtSpeakingFrom").focus();
				document.getElementById("txtSpeakingFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSpeakingFrom").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtSpeakingFrom").focus();
					document.getElementById("txtSpeakingFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSpeakingFrom").style.backgroundColor = 'white';
				}	

			//Validating Speaking From Number.
			
			strText = document.getElementById("txtSpeakingTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtSpeakingTo").focus();
				document.getElementById("txtSpeakingTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtSpeakingTo").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtSpeakingTo").focus();
					document.getElementById("txtSpeakingTo").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSpeakingTo").style.backgroundColor = 'white';
				}	
			
			//Validating Listening From Number.
			strText = document.getElementById("txtListeningFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtListeningFrom").focus();
				document.getElementById("txtListeningFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtListeningFrom").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtListeningFrom").focus();
					document.getElementById("txtListeningFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtListeningFrom").style.backgroundColor = 'white';
				}
			
			//Validating Listening To Number.
			
			strText = document.getElementById("txtListeningTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtListeningTo").focus();
				document.getElementById("txtListeningTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtListeningTo").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtListeningTo").focus();
					document.getElementById("txtListeningTo").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtListeningTo").style.backgroundColor = 'white';
				}
			
			//Validating Waiting From Number.
			
			strText = document.getElementById("txtWaitingFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtWaitingFrom").focus();
				document.getElementById("txtWaitingFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtWaitingFrom").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtWaitingFrom").focus();
					document.getElementById("txtWaitingFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWaitingFrom").style.backgroundColor = 'white';
				}
				
			//Validating Waiting To Number.
			
			strText = document.getElementById("txtWaitingTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtWaitingTo").focus();
				document.getElementById("txtWaitingTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtWaitingTo").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtWaitingTo").focus();
					document.getElementById("txtWaitingTo").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtWaitingTo").style.backgroundColor = 'white';
				}
			
			//Validating Analytical From Number.
			
			strText = document.getElementById("txtAnalyticalFrom").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtAnalyticalFrom").focus();
				document.getElementById("txtAnalyticalFrom").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtAnalyticalFrom").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtAnalyticalFrom").focus();
					document.getElementById("txtAnalyticalFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtAnalyticalFrom").style.backgroundColor = 'white';
				}
			
			//Validating Analytical To Number.
			strText = document.getElementById("txtAnalyticalTo").value;
			
			if (IsAngularBracket(strText))
			{			   
				alert("Character '< ' is not allowed");
				document.getElementById("txtAnalyticalTo").focus();
				document.getElementById("txtAnalyticalTo").style.backgroundColor = 'yellow';
				return false;
			}
			else
			{
				document.getElementById("txtAnalyticalTo").style.backgroundColor = 'white';
			}
			
			if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtAnalyticalTo").focus();
					document.getElementById("txtAnalyticalTo").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtAnalyticalTo").style.backgroundColor = 'white';
				}		
			
			
		 
			if((Trim(varFirstName) != "") || (Trim(varLastName) != "") || (varGender != "Select") || (varTestState != "0") || (varTestCity != "0") || (varEmploymentStatus != "Select") || (varQualification != "0") || (varTestCentre != "0") || (varWillingToRelocate != "Select") || (Trim(varSerialNoFrom) != "") || (Trim(varSerialNoTo) != "") || (Trim(varRegistrationIDFrom) != "") || (Trim(varRegistrationIDTo) != "") || varMediumOfInstruction != "0" || varMediumOfInstructionIn12Th != "0"  || (Trim(varSpeakingFrom) != "") || (Trim(varSpeakingTo) != "") || (Trim(varListeningFrom) != "") || (Trim(varListeningTo) != "") || (Trim(varWaitingFrom) != "") || (Trim(varWaitingTo) != "") || (Trim(varAnalyticalFrom) != "") || (Trim(varAnalyticalTo) != "") || varYouBelongTo != "0" || varSelectAll != "Select" || Trim(varResidenceCity) != "" || varDOBTo != "" || varDOBFrom != "")
			{			    
			  return true;
			}
			else
			{
			    alert("Please fill at least one search criteria");
			    return false;
			}
			 return false;	
		}	
	
		</script>
</HEAD>
	<BODY onload="SetComponentStatus(); hideTextBox(); ChangeCollegeLabelOnLoad();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="756" align="center"
				border="0">
				<tr class="white_bg">
					<td vAlign="top" align="center" width="7" background="images/tbg_left.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
					<td vAlign="top" align="center">
						<table class="black_bg" id="Table2" style="WIDTH: 741px; HEIGHT: 184px" cellSpacing="0"
							cellPadding="0" width="741" align="center" border="0">
							<tr class="white_bg" vAlign="top" align="left">
								<td style="HEIGHT: 30px"><uc1:nac_header id="Nac_header1" runat="server"></uc1:nac_header></td>
							</tr>
							<tr class="blue_bg" vAlign="top" align="left">
								<td class="header1" vAlign="middle">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td class="header1" vAlign="middle" align="left">&nbsp;&nbsp;Search Candidate</td>
											<td class="header1" vAlign="middle" align="right"><A class="header1" href="Welcome.aspx">Home&nbsp;&nbsp;&nbsp;</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="white_bg" vAlign="top" align="center">
								<td align="center"><br>
									<table id="Table4" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="center"
										border="0">
										<tr class="main_black" align="left">
											<td class="lightblue_bg" colSpan="6"><strong>Search Candidate</strong></td>
										</tr>
										<TR>
											<TD width="20%"></TD>
											<TD width="28%"></TD>
											<TD width="2%"></TD>
											<TD width="24%"></TD>
											<TD width="24%"></TD>
											<TD width="2%"></TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td vAlign="top" width="48%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">Name</legend>
													<table height="40" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td>First Name:</td>
															<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtName" runat="server" CssClass="txtbox" Width="170px" MaxLength="30"></asp:textbox></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Last Name:</td>
															<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txtLastName" runat="server" CssClass="txtbox" Width="170px" MaxLength="30"></asp:textbox></td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
											<td width="48%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">Medium Of Instruction</legend>
													<table height="40" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td align="left" style="HEIGHT: 21px">Upto 10th standard:</td>
															<td align="left" style="HEIGHT: 21px"><asp:dropdownlist id="ddlMediumOfInstruction" CssClass="txtarea" Runat="server">
																	<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="Assamese">Assamese</asp:ListItem>
																	<asp:ListItem Value="Bengali">Bengali</asp:ListItem>
																	<asp:ListItem Value="Gujarati">Gujarati</asp:ListItem>
																	<asp:ListItem Value="Hindi">Hindi</asp:ListItem>
																	<asp:ListItem Value="English">English</asp:ListItem>
																	<asp:ListItem Value="Kannada">Kannada</asp:ListItem>
																	<asp:ListItem Value="Kashmiri">Kashmiri</asp:ListItem>
																	<asp:ListItem Value="Malayalam">Malayalam</asp:ListItem>
																	<asp:ListItem Value="Marathi">Marathi</asp:ListItem>
																	<asp:ListItem Value="Oriya">Oriya</asp:ListItem>
																	<asp:ListItem Value="Punjabi">Punjabi</asp:ListItem>
																	<asp:ListItem Value="Tamil">Tamil</asp:ListItem>
																	<asp:ListItem Value="Telugu">Telugu</asp:ListItem>
																	<asp:ListItem Value="Urdu">Urdu</asp:ListItem>
																</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">In 12th standard:</td>
															<td align="left"><asp:dropdownlist id="ddlMediumOfInstructionIn12Th" CssClass="txtarea" Runat="server">
																	<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="Assamese">Assamese</asp:ListItem>
																	<asp:ListItem Value="Bengali">Bengali</asp:ListItem>
																	<asp:ListItem Value="Gujarati">Gujarati</asp:ListItem>
																	<asp:ListItem Value="Hindi">Hindi</asp:ListItem>
																	<asp:ListItem Value="English">English</asp:ListItem>
																	<asp:ListItem Value="Kannada">Kannada</asp:ListItem>
																	<asp:ListItem Value="Kashmiri">Kashmiri</asp:ListItem>
																	<asp:ListItem Value="Malayalam">Malayalam</asp:ListItem>
																	<asp:ListItem Value="Marathi">Marathi</asp:ListItem>
																	<asp:ListItem Value="Oriya">Oriya</asp:ListItem>
																	<asp:ListItem Value="Punjabi">Punjabi</asp:ListItem>
																	<asp:ListItem Value="Tamil">Tamil</asp:ListItem>
																	<asp:ListItem Value="Telugu">Telugu</asp:ListItem>
																	<asp:ListItem Value="Urdu">Urdu</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td vAlign="top" width="20%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">Test Locations</legend>
													<table id="Table3" height="65" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Test State:</td>
															<td align="left"><asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox"></asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Test City:</td>
															<td align="left"><asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox"></asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Test Centre:</td>
															<td align="left"><asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
											<td vAlign="top" width="48%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">User ID/Registration ID</legend>
													<table height="65" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td>&nbsp;</td>
															<td align="center">From</td>
															<td align="center">&nbsp;</td>
															<td align="center">To</td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>
																User ID:</td>
															<td align="center"><asp:textbox id="txtSerialNoFrom" runat="server" CssClass="txtbox" Width="70px" MaxLength="30"></asp:textbox></td>
															<td align="center">&nbsp;-&nbsp;</td>
															<td align="center"><asp:textbox id="txtSerialNoTo" runat="server" CssClass="txtbox" Width="70px" MaxLength="30"></asp:textbox></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td>Registration ID:</td>
															<td align="center"><asp:textbox id="txtRegistrationIDFrom" runat="server" CssClass="txtbox" Width="70px" MaxLength="30"></asp:textbox></td>
															<td align="center">&nbsp;-&nbsp;</td>
															<td align="center"><asp:textbox id="txtRegistrationIDTo" runat="server" CssClass="txtbox" Width="70px" MaxLength="30"></asp:textbox></td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td width="48%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">Personal Details</legend>
													<table height="110" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Gender:</td>
															<td align="left"><asp:dropdownlist id="ddlGender" runat="server" CssClass="txtbox">
																	<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="M">Male</asp:ListItem>
																	<asp:ListItem Value="F">Female</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Belong to:
															</td>
															<td align="left"><asp:dropdownlist id="rblYouBelongTo" runat="server" CssClass="txtbox">
																	<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="Village">Village</asp:ListItem>
																	<asp:ListItem Value="City">City</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Employment Status:
															</td>
															<td align="left"><asp:dropdownlist id="ddlEmploymentStatus" runat="server" CssClass="txtbox">
																	<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="Employed">Employed</asp:ListItem>
																	<asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Willing to relocate:
															</td>
															<td align="left"><asp:dropdownlist id="ddlRelocate" runat="server" CssClass="txtbox">
																	<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
																	<asp:ListItem Value="Yes">Yes</asp:ListItem>
																	<asp:ListItem Value="No">No</asp:ListItem>
																</asp:dropdownlist></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Residence city:
															</td>
															<td align="left"><asp:textbox id="txtResidenceCity" CssClass="txtbox" MaxLength="100" Runat="server"></asp:textbox></td>
														</tr>
														<tr class="main_black" vAlign="top" align="left">
															<td colSpan="2">
																<table cellSpacing="2" cellPadding="2" width="100%" border="0">
																	<tr class="main_black" vAlign="top" align="left">
																		<td colSpan="3">Date of birth:</td>
																	</tr>
																	<tr class="main_black" vAlign="top" align="left">
																		<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
																		<td>From:</td>
																		<td>
																			<!-- Start From Date --><asp:dropdownlist id="ddlFromDay" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
																				<asp:ListItem Value="01">01</asp:ListItem>
																				<asp:ListItem Value="02">02</asp:ListItem>
																				<asp:ListItem Value="03">03</asp:ListItem>
																				<asp:ListItem Value="04">04</asp:ListItem>
																				<asp:ListItem Value="05">05</asp:ListItem>
																				<asp:ListItem Value="06">06</asp:ListItem>
																				<asp:ListItem Value="07">07</asp:ListItem>
																				<asp:ListItem Value="08">08</asp:ListItem>
																				<asp:ListItem Value="09">09</asp:ListItem>
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
																			</asp:dropdownlist><asp:dropdownlist id="ddlFromMonth" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
																				<asp:ListItem Value="01">January</asp:ListItem>
																				<asp:ListItem Value="02">February</asp:ListItem>
																				<asp:ListItem Value="03">March</asp:ListItem>
																				<asp:ListItem Value="04">April</asp:ListItem>
																				<asp:ListItem Value="05">May</asp:ListItem>
																				<asp:ListItem Value="06">June</asp:ListItem>
																				<asp:ListItem Value="07">July</asp:ListItem>
																				<asp:ListItem Value="08">August</asp:ListItem>
																				<asp:ListItem Value="09">September</asp:ListItem>
																				<asp:ListItem Value="10">October</asp:ListItem>
																				<asp:ListItem Value="11">November</asp:ListItem>
																				<asp:ListItem Value="12">December</asp:ListItem>
																			</asp:dropdownlist><asp:dropdownlist id="ddlFromYear" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				<asp:ListItem Value="1979">1979</asp:ListItem>
																				<asp:ListItem Value="1978">1978</asp:ListItem>
																				<asp:ListItem Value="1977">1977</asp:ListItem>
																				<asp:ListItem Value="1976">1976</asp:ListItem>
																				<asp:ListItem Value="1975">1975</asp:ListItem>
																				<asp:ListItem Value="1974">1974</asp:ListItem>
																				<asp:ListItem Value="1973">1973</asp:ListItem>
																				<asp:ListItem Value="1972">1972</asp:ListItem>
																				<asp:ListItem Value="1971">1971</asp:ListItem>
																				<asp:ListItem Value="1970">1970</asp:ListItem>
																				<asp:ListItem Value="1969">1969</asp:ListItem>
																				<asp:ListItem Value="1968">1968</asp:ListItem>
																				<asp:ListItem Value="1967">1967</asp:ListItem>
																				<asp:ListItem Value="1966">1966</asp:ListItem>
																				<asp:ListItem Value="1965">1965</asp:ListItem>
																				<asp:ListItem Value="1964">1964</asp:ListItem>
																				<asp:ListItem Value="1963">1963</asp:ListItem>
																				<asp:ListItem Value="1962">1962</asp:ListItem>
																				<asp:ListItem Value="1961">1961</asp:ListItem>
																				<asp:ListItem Value="1960">1960</asp:ListItem>
																				<asp:ListItem Value="1959">1959</asp:ListItem>
																				<asp:ListItem Value="1958">1958</asp:ListItem>
																				<asp:ListItem Value="1957">1957</asp:ListItem>
																				<asp:ListItem Value="1956">1956</asp:ListItem>
																				<asp:ListItem Value="1955">1955</asp:ListItem>
																				<asp:ListItem Value="1954">1954</asp:ListItem>
																				<asp:ListItem Value="1953">1953</asp:ListItem>
																				<asp:ListItem Value="1952">1952</asp:ListItem>
																				<asp:ListItem Value="1951">1951</asp:ListItem>
																				<asp:ListItem Value="1950">1950</asp:ListItem>
																				<asp:ListItem Value="1949">1949</asp:ListItem>
																			</asp:dropdownlist>
																			<!-- END From Date --></td>
																	</tr>
																	<tr class="main_black" vAlign="top" align="left">
																		<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
																		<td>To:</td>
																		<td>
																			<!-- Start To Date --><asp:dropdownlist id="ddlToDay" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Day</asp:ListItem>
																				<asp:ListItem Value="01">01</asp:ListItem>
																				<asp:ListItem Value="02">02</asp:ListItem>
																				<asp:ListItem Value="03">03</asp:ListItem>
																				<asp:ListItem Value="04">04</asp:ListItem>
																				<asp:ListItem Value="05">05</asp:ListItem>
																				<asp:ListItem Value="06">06</asp:ListItem>
																				<asp:ListItem Value="07">07</asp:ListItem>
																				<asp:ListItem Value="08">08</asp:ListItem>
																				<asp:ListItem Value="09">09</asp:ListItem>
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
																			</asp:dropdownlist><asp:dropdownlist id="ddlToMonth" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
																				<asp:ListItem Value="01">January</asp:ListItem>
																				<asp:ListItem Value="02">February</asp:ListItem>
																				<asp:ListItem Value="03">March</asp:ListItem>
																				<asp:ListItem Value="04">April</asp:ListItem>
																				<asp:ListItem Value="05">May</asp:ListItem>
																				<asp:ListItem Value="06">June</asp:ListItem>
																				<asp:ListItem Value="07">July</asp:ListItem>
																				<asp:ListItem Value="08">August</asp:ListItem>
																				<asp:ListItem Value="09">September</asp:ListItem>
																				<asp:ListItem Value="10">October</asp:ListItem>
																				<asp:ListItem Value="11">November</asp:ListItem>
																				<asp:ListItem Value="12">December</asp:ListItem>
																			</asp:dropdownlist><asp:dropdownlist id="ddlToYear" CssClass="txtarea" Runat="server">
																				<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				<asp:ListItem Value="1979">1979</asp:ListItem>
																				<asp:ListItem Value="1978">1978</asp:ListItem>
																				<asp:ListItem Value="1977">1977</asp:ListItem>
																				<asp:ListItem Value="1976">1976</asp:ListItem>
																				<asp:ListItem Value="1975">1975</asp:ListItem>
																				<asp:ListItem Value="1974">1974</asp:ListItem>
																				<asp:ListItem Value="1973">1973</asp:ListItem>
																				<asp:ListItem Value="1972">1972</asp:ListItem>
																				<asp:ListItem Value="1971">1971</asp:ListItem>
																				<asp:ListItem Value="1970">1970</asp:ListItem>
																				<asp:ListItem Value="1969">1969</asp:ListItem>
																				<asp:ListItem Value="1968">1968</asp:ListItem>
																				<asp:ListItem Value="1967">1967</asp:ListItem>
																				<asp:ListItem Value="1966">1966</asp:ListItem>
																				<asp:ListItem Value="1965">1965</asp:ListItem>
																				<asp:ListItem Value="1964">1964</asp:ListItem>
																				<asp:ListItem Value="1963">1963</asp:ListItem>
																				<asp:ListItem Value="1962">1962</asp:ListItem>
																				<asp:ListItem Value="1961">1961</asp:ListItem>
																				<asp:ListItem Value="1960">1960</asp:ListItem>
																				<asp:ListItem Value="1959">1959</asp:ListItem>
																				<asp:ListItem Value="1958">1958</asp:ListItem>
																				<asp:ListItem Value="1957">1957</asp:ListItem>
																				<asp:ListItem Value="1956">1956</asp:ListItem>
																				<asp:ListItem Value="1955">1955</asp:ListItem>
																				<asp:ListItem Value="1954">1954</asp:ListItem>
																				<asp:ListItem Value="1953">1953</asp:ListItem>
																				<asp:ListItem Value="1952">1952</asp:ListItem>
																				<asp:ListItem Value="1951">1951</asp:ListItem>
																				<asp:ListItem Value="1950">1950</asp:ListItem>
																				<asp:ListItem Value="1949">1949</asp:ListItem>
																			</asp:dropdownlist>
																			<!-- End To Date --></td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
											<td vAlign="top" width="24%" colSpan="2">
												<fieldset align="left"><legend class="main_black_bold">Scores
													</legend>
													<table height="110" cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td align="center">&nbsp;</td>
															<td align="center">From</td>
															<td align="center"></td>
															<td align="center">To</td>
														</tr>
														<tr class="main_black" align="left">
															<td align="right">Speaking:</td>
															<td align="center"><asp:textbox id="txtSpeakingFrom" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
															<td align="center">-</td>
															<td align="center"><asp:textbox id="txtSpeakingTo" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
														</tr>
														<tr class="main_black" align="left">
															<td align="right">Listening:</td>
															<td align="center"><asp:textbox id="txtListeningFrom" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
															<td align="center">-</td>
															<td align="center"><asp:textbox id="txtListeningTo" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
														</tr>
														<tr class="main_black" align="left">
															<td align="right">&nbsp;Writing:</td>
															<td align="center"><asp:textbox id="txtWaitingFrom" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
															<td align="center">-</td>
															<td align="center"><asp:textbox id="txtWaitingTo" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
														</tr>
														<tr class="main_black" align="left">
															<td align="right">A&amp;Q:</td>
															<td align="center"><asp:textbox id="txtAnalyticalFrom" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
															<td align="center">-</td>
															<td align="center"><asp:textbox id="txtAnalyticalTo" runat="server" CssClass="txtbox" Width="50px" MaxLength="2"></asp:textbox></td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td width="2%"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td vAlign="top" width="98%" colSpan="4">
												<fieldset align="left"><legend class="main_black_bold">Educational Qualification
													</legend>
													<table cellSpacing="1" cellPadding="1" width="100%" border="0">
														<tr class="main_black" vAlign="top" align="left">
															<td align="left">Qualification:</td>
															<td align="left"><asp:dropdownlist id="ddlqualification" runat="server" CssClass="txtbox"></asp:dropdownlist><INPUT id="hdQualificationDetails" type="hidden" value="0" name="hdQualificationDetails"
																	runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
																&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															</td>
														</tr>
														<tr class="small_black" id="dvPostGraduate" style="DISPLAY: none" vAlign="top" align="left"
															runat="server">
															<td id="divHighestEducationObtainedFrom" align="left" runat="server">&nbsp;</td>
															<td class="small_black" align="left"><asp:textbox id="txtHighestEducationObtainedFrom" CssClass="txtbox" MaxLength="50" Runat="server"></asp:textbox></td>
														</tr>
														<tr class="small_black" id="dvPostGraduate2" style="DISPLAY: none" vAlign="top" align="left"
															runat="server">
															<td align="left">College Address:</td>
															<td align="left"><asp:textbox id="txtCollegeAddress" runat="server" CssClass="txtarea" Width="250px" MaxLength="100"
																	TextMode="MultiLine" Rows="4" Columns="30"></asp:textbox></td>
														</tr>
														<tr class="small_black" id="dvPostGraduate1" style="DISPLAY: none" vAlign="top" align="left"
															runat="server">
															<td align="left">College City:</td>
															<td align="left"><asp:textbox id="txtHighestEducationCity" CssClass="txtbox" MaxLength="10" Runat="server"></asp:textbox></td>
														</tr>
														<tr class="main_black" align="left">
															<td align="left">Qualification Details:</td>
															<td align="left"><asp:dropdownlist id="ddlQualificationDetails" CssClass="txtarea" Runat="server"></asp:dropdownlist><INPUT class="txtarea" id="txtOtherQualification" style="VISIBILITY: visible" onfocus="this.value = ''; return true;"
																	type="text" maxLength="50" value="CONTAINS WORD LIKE" name="txtOtherQualification" Runat="server">
															</td>
														</tr>
													</table>
												</fieldset>
											</td>
											<td vAlign="middle" align="center" width="30%"><asp:button id="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"></asp:button></td>
											<td width="2%"></td>
										</tr>
										<tr class="main_black" align="left">
											<td align="right" colSpan="4"></td>
											<td align="left"></td>
											<td width="2%"></td>
										</tr>
										<tr class="small_maroon" align="center" height="25">
											<td align="left" width="2%">&nbsp;<asp:checkbox id="chkAll" onclick="CheckAllCandidate(this); DeselectAll();" CssClass="chkbox"
													Runat="server" Text="Select All" Font-Bold="True"></asp:checkbox><input id="hdTotalCandidateCount" type="hidden" value="0" name="hdTotalCandidateCount"
													runat="server"><asp:button id="btnDeselectAll" Width="1px" Runat="server" Height="1px" onclick="btnDeselectAll_Click"></asp:button></td>
											<td align="center" width="80%" colSpan="4"><asp:label id="lblTotalRecord" Runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
											<td width="2%">&nbsp;</td>
										</tr>
										<tr class="main_black" align="center">
											<td colSpan="6"><asp:panel id="pnlSearch" Runat="server">
<asp:datagrid id=dgSearch runat="server" Width="100%" CssClass="main_black" Height="100%" OnItemDataBound="dgSearch_ItemDataBound" AllowSorting="True" ShowFooter="True" OnItemCreated="dgSearch_ItemCreated" AutoGenerateColumns="False" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnItemCommand="dgSearch_ItemCommand" BackColor="White" CellPadding="3" GridLines="Vertical" OnSortCommand="dgSearch_SortCommand">
														<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
														<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
														<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
														<FooterStyle ForeColor="Blue" BackColor="White"></FooterStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderTemplate>
																	<asp:CheckBox ID="chkHeader" CssClass="chkbox" onclick="CheckAll(this);" Runat="server"></asp:CheckBox>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Checkbox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" Runat="server"></asp:Checkbox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn SortExpression="RegistrationId ASC" HeaderText="Registration ID">
																<ItemTemplate>
																	<asp:Label ID="lblRegistration" Text='<%#DataBinder.Eval(Container.DataItem,"RegistrationId")%>' Runat="server">
																	</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="Name" SortExpression="Name ASC" HeaderText="Name"></asp:BoundColumn>
															<asp:BoundColumn DataField="Qualification" SortExpression="Qualification ASC" HeaderText="Qualification"></asp:BoundColumn>
															<asp:BoundColumn DataField="City" SortExpression="City ASC" HeaderText="City"></asp:BoundColumn>
															<asp:BoundColumn DataField="Email" SortExpression="Email ASC" HeaderText="Email"></asp:BoundColumn>
														</Columns>
													</asp:datagrid>
												</asp:panel></td>
										</tr>
										<tr class="small_maroon" align="center">
											<td colSpan="6"><asp:panel id="pnlMessage" Runat="server">
<asp:Label id=lblMessage CssClass="small_maroon" Runat="server" Text="NO RECORDS FOUND!" Font-Bold="True" ForeColor="red" Visible="True"></asp:Label>
												</asp:panel></td>
										</tr>
										<tr align="center">
											<td align="center" colSpan="6">&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnViewJobCard" runat="server" Text="Job Fair Card" onclick="btnViewJobCard_Click"></asp:button><asp:button id="btnCandidateDetails" runat="server" Text="Candidate Details" onclick="btnCandidateDetails_Click"></asp:button><asp:button id="btnScoreCard" runat="server" Text="Score Card" onclick="btnScoreCard_Click"></asp:button><asp:button id="btnAdmitCard" runat="server" Text="Admit Card" onclick="btnAdmitCard_Click"></asp:button><asp:button id="btnExportToExcel" runat="server" Text="Export To Excel" onclick="btnExportToExcel_Click"></asp:button><asp:label id="lblSortExp" Runat="server" Visible="False"></asp:label><input id="hdState" type="hidden" value="0" name="hdState" runat="server">
												<input id="hdCity" type="hidden" value="0" name="hdCity" runat="server"> <input id="hdCentre" type="hidden" value="0" name="hdCentre" runat="server">
												<input id="hdHeaderCheckBox" type="hidden" value="0" name="hdHeaderCheckBox" runat="server"><input id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
													runat="server">
											</td>
										</tr>
										<tr class="small_maroon" align="center" height="25">
											<td colSpan="6">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" align="center" width="7" background="images/tbg_right.gif"><IMG height="1" src="images/spacer.gif" width="7"></td>
				</tr>
				<TR class="white_bg">
					<TD vAlign="top" align="center" width="7" background="images/tbg_left.gif"></TD>
					<TD vAlign="bottom" align="center"><uc1:nac_footer id="Nac_footer1" runat="server"></uc1:nac_footer></TD>
					<TD vAlign="top" align="center" width="7" background="images/tbg_right.gif"></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
