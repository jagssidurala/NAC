<%@ Page language="c#" Codebehind="Edit_Registration.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Edit_Registration" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Edit_Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			//Checking file extention of image
			function CheckFileExtension()
		     {			       	 
		            
				var ext = document.getElementById("filUpload").value;
				var extFour;
				var bFileFormat = false;
								
				ext = ext.substring(ext.length-3,ext.length);
				ext = ext.toLowerCase();
				extFour = ext.substring(ext.length-4,ext.length);
				extFour = extFour.toLowerCase();
				if((ext == 'jpg') ||(ext == 'gif'))
				{
					bFileFormat = true;
				}   
				
				if(bFileFormat == false)
				 {
					alert('You selected a .' + ext + ' file; please select a .jpg or .gif file instead!');
					document.getElementById("filUpload").value = "";
					return false;
				 }				  
				else
					return true; 
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
				       
					  alert("Please enter alphabet");
					  document.getElementById(varControlId).value = "";
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
		       if ((!(emailCheck(varValue))) && Trim(varValue) != "")
				{
					alert("Please enter valid email address");
					document.getElementById("txtEmailID").focus();
					document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtEmailID").style.backgroundColor = 'white';
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
				       
					  alert("Please enter numeric data");
					  document.getElementById(varControlId).value = "";
					  document.getElementById(varControlId).focus();
					  document.getElementById(varControlId).style.backgroundColor = 'yellow';
					  return false;
					}		        
		    }
		    
			function fillHiddenCentre()
			{
			    var box = document.getElementById("ddlTestCentre");
				var varOption = document.createElement('OPTION');				 		
				varOption = box.options[box.selectedIndex];	
				document.getElementById("hdTestCentre").value = document.getElementById("ddlTestCentre").value;
				document.getElementById("hdTestCentreName").value = varOption.text;
			}
			
			//Checking that Others is selected from Qualification Details or not
		    function CheckedValue()
		    {
		        var varCheckOther;
		        var box = document.getElementById("ddlQualificationDetails");	       
		        var varOption = document.createElement('OPTION');
		    
		        varOption = box.options[box.selectedIndex];		        
		        varCheckOther = varOption.text;		        
		        varCheckOther = varCheckOther.toLowerCase();
		        
		        if(varCheckOther == 'others')
		        {
		            
		            return true;
		        }
		        else
		        {
		            return false;
		        }  
		    }

			//Initializing Hidden Textbox(txtOtherQualification) with selected Qualification Details
		    function fillHiddenQualification()
		    {
				document.getElementById("hdQualificationDetails").value = document.getElementById("ddlQualificationDetails").value;
				var varCheck;
				
				var boxQualification = document.getElementById("ddlQualificationDetails");
				var varQualification = document.createElement('OPTION');
				varQualification = boxQualification.options[boxQualification.selectedIndex];	
				varCheck = varQualification.text;
				varCheck = varCheck.toLowerCase();
				document.getElementById("hdQualificationDetailsName").value = varCheck;
				if(varCheck == 'others')
				{
					document.getElementById("txtOtherQualification").style.visibility = "visible";
					document.getElementById("txtOtherQualification").style.display = "";
					document.getElementById("txtOtherQualification").value = "Specify other";
				}
				else
				{
					document.getElementById("txtOtherQualification").value = "";
					document.getElementById("txtOtherQualification").style.visibility = "hidden";
					document.getElementById("txtOtherQualification").style.display = "none";
				}
		    }
		    
		    //Changing College level on selection of Qualification Type.
		    function ChangeCollegeLabel()
		    {
				document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
				var varCheckOther;
				var box = document.getElementById("ddlQualification");
				var varOption = document.createElement('OPTION');
				varOption = box.options[box.selectedIndex];	
				varCheckOther = varOption.text;
				varCheckOther = varCheckOther.toLowerCase();
				if(varCheckOther == 'undergraduate/graduate')
				{
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "right";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";					
					document.getElementById("divHighestEducationYear").style.textAlign = "right";
					document.getElementById("divHighestEducationYear").innerText = "Year Of Graduation:";
					
					document.getElementById("dvEduFrom").style.display="";
					document.getElementById("dvHighEduYear").style.display="";
					document.getElementById("dvPGSpecialization").style.display="none";
					document.getElementById("dvPostGraduate2").style.display="";
					document.getElementById("dvCollegeCity").style.display="";			
				}
				else if (varCheckOther == 'post graduate')
				{
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "right";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "Graduation done from (College Name):*";
					document.getElementById("divHighestEducationYear").style.textAlign = "right";
					document.getElementById("divHighestEducationYear").innerText = "Year Of Post Graduation:";
					
					document.getElementById("dvEduFrom").style.display="";
					document.getElementById("dvHighEduYear").style.display="";
					document.getElementById("dvPGSpecialization").style.display="";
					document.getElementById("dvPostGraduate2").style.display="";
					document.getElementById("dvCollegeCity").style.display="";	
				}
				else
				{	
					document.getElementById("dvEduFrom").style.display="none";
					document.getElementById("dvHighEduYear").style.display="none";
					document.getElementById("dvPGSpecialization").style.display="none";
					document.getElementById("dvPostGraduate2").style.display="none";
					document.getElementById("dvCollegeCity").style.display="none";					
				}
		    }
		    
			//Validating User INPUT
			function ValidateData()
			{
			    var strText;
			    
				//Validate First Name for blank data.
				strText = document.getElementById("txtFirstName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter first name");
					document.getElementById("txtFirstName").focus();
					document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtFirstName").style.backgroundColor = 'white';
				}
				
				//Checking first name for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtFirstName").focus();
					document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtFirstName").style.backgroundColor = 'white';
				}


				//Validate Middle Name for balnk data.
				strText = document.getElementById("txtMiddleName").value;			       					  
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtMiddleName").focus();
					document.getElementById("txtMiddleName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtMiddleName").style.backgroundColor = 'white';
				}
				
				//Validate Last Name for blank data.
				strText = document.getElementById("txtLastName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter last name");
					document.getElementById("txtLastName").focus();
					document.getElementById("txtLastName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtLastName").style.backgroundColor = 'white';
				}

				//Validating Last Name for special character.
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

				//Validate Date of Birth
				//Checking that Day is selected or not.         
				strText = document.getElementById("ddlDay").value;   
				if ((strText) == 0)
				{
					alert("Please select day");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlDay").style.backgroundColor = 'white';
				}

				//Checking that Month is selected or not. 
				strText = document.getElementById("ddlMonth").value;   
				if ((strText) == 0)
				{
					alert("Please select month");
					document.getElementById("ddlMonth").focus();
					document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMonth").style.backgroundColor = 'white';
				}

				//Checking that Year is selected or not. 
				strText = document.getElementById("ddlYear").value;  
				if ((strText) == 0)
				{
					alert("Please select year");
					document.getElementById("ddlYear").focus();
					document.getElementById("ddlYear").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlYear").style.backgroundColor = 'white';
				}

				//Checking field for valid Date.
				strText = document.getElementById("ddlDay").value + "-" + document.getElementById("ddlMonth").value + "-" + document.getElementById("ddlYear").value
				if (isValidDate(strText)!="")
				{
					alert("Please enter valid date");
					document.getElementById("ddlDay").focus();
					document.getElementById("ddlDay").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlDay").style.backgroundColor = 'white';
				}
                         
                         
				//Validate that Gender field is salected or not.
				if(window.document.forms[0].rblGender[0].checked==false && window.document.forms[0].rblGender[1].checked==false)
				{
					alert("Please select gender");
					document.getElementById("rblGender_0").focus();
					return false;
				}
								 
			
				//Checking Residential address is blank or not.	
				strText = document.getElementById("txtResidentialAddress").value;
				if (Trim(strText) == "")
				{
					alert("Please enter residential address");
					document.getElementById("txtResidentialAddress").focus();
					document.getElementById("txtResidentialAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtResidentialAddress").style.backgroundColor = 'white';
				}

				//Checking length of residential address.
				if ((strText.length) > 400)
				{
				alert("Please enter residential address less then 400 character");
				document.getElementById("txtResidentialAddress").focus();
				document.getElementById("txtResidentialAddress").style.backgroundColor = 'yellow';
				return false;
				}
				else
				{
					document.getElementById("txtResidentialAddress").style.backgroundColor = 'white';
				}
				
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtResidentialAddress").focus();
					document.getElementById("txtResidentialAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtResidentialAddress").style.backgroundColor = 'white';
				}
	
				//Validate city	name for blank data.
				strText = document.getElementById("txtCity").value;
				if (Trim(strText) == "")
				{
					alert("Please enter city name");
					document.getElementById("txtCity").focus();
					document.getElementById("txtCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCity").style.backgroundColor = 'white';
				}
				
				//Validate city name for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCity").focus();
					document.getElementById("txtCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCity").style.backgroundColor = 'white';
				}
														
				//Validate Pincode for blank data.
				strText = document.getElementById("txtPinCode").value;
				if (Trim(strText) == "")
				{
					alert("Please enter pincode");
					document.getElementById("txtPinCode").focus();
					document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPinCode").style.backgroundColor = 'white';
				}

				//Validate pin number for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtPinCode").focus();
					document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPinCode").style.backgroundColor = 'white';
				}

				//Validate pin number for numeric data.
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtPinCode").focus();
					document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPinCode").style.backgroundColor = 'white';
				}

							
				//Validate Phone Number Land Line					
							 
				// Validating STD Code for Bank data.
				strText = document.getElementById("txtSTDCode").value;
				if (Trim(strText) == "")
				{
					alert("Please enter std code");
					document.getElementById("txtSTDCode").focus();
					document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSTDCode").style.backgroundColor = 'white';
				}

				//Validatting STD Number for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtSTDCode").focus();
					document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSTDCode").style.backgroundColor = 'white';
				}
				
				//Validating STD Number for Numeric data.
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtSTDCode").focus();
					document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtSTDCode").style.backgroundColor = 'white';
				}
														 
				//Validating phone number for blank data.
				strText = document.getElementById("txtPhoneNumber").value;
				if (Trim(strText) == "")
				{
					alert("Please enter phone number");
					document.getElementById("txtPhoneNumber").focus();
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
				}
				
				//Validating phone number for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtPhoneNumber").focus();
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
				}

				//Validating phone number for numeric data.
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtPhoneNumber").focus();
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
				}
							
				//Validating cell number for blank data.
				strText = document.getElementById("txtCellPhone").value;
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCellPhone").focus();
					document.getElementById("txtCellPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCellPhone").style.backgroundColor = 'white';
				}

				//Validating phone number for nemeric data.
				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtPhoneNumber").focus();
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
				}
							 
				//Validate Upload Photograph (Checking file extention for valid file)
				strText = document.getElementById("filUpload").value;
				if (Trim(strText) != "")
				{
					var varFlag = CheckFileExtension();
					if (varFlag == false)
					{
						document.getElementById("filUpload").focus();
						return false;
					}
				}
													
	 			//Validate Email Id	for special characters.
//				strText=document.getElementById("txtEmailID").value;
//				if (IsAngularBracket(strText))
//				{
//					alert("Please enter numeric data");
//					document.getElementById("txtEmailID").focus();
//					document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
//					return false;
//				}
//				else
//				{
//					document.getElementById("txtEmailID").style.backgroundColor = 'white';
//				}

				//Checking that email id is valid or not.
//				if ((!(emailCheck(strText))) && Trim(strText) != "")
//				{
//					alert("Please enter valid email address");
//					document.getElementById("txtEmailID").focus();
//					document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
//					return false;
//				}
//				else
//				{
//					document.getElementById("txtEmailID").style.backgroundColor = 'white';
	//				}

	//Validate Email Id			

	strText = document.getElementById("txtEmailID").value;


	if (IsAngularBracket(strText)) {
	    alert("Please enter numeric data");
	    document.getElementById("txtEmailID").focus();
	    document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
	    return false;
	}
	else {
	    document.getElementById("txtEmailID").style.backgroundColor = 'white';
	}

	if ((!(emailCheck(strText))) && Trim(strText) != "") {
	    alert("Please enter valid email address");
	    document.getElementById("txtEmailID").focus();
	    document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
	    return false;
	}
	else {
	    document.getElementById("txtEmailID").style.backgroundColor = 'white';
	}

	if (Trim(strText) == "") {
	    alert("Please enter Email Id");
	    document.getElementById("txtEmailID").focus();
	    document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
	    return false;
	}
	else {
	    document.getElementById("txtEmailID").style.backgroundColor = 'white';
	}
							
				//Validate Mother's Full Name for blank data.				
				strText = document.getElementById("txtMothersName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter mothers name");
					document.getElementById("txtMothersName").focus();
					document.getElementById("txtMothersName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtMothersName").style.backgroundColor = 'white';
				}
				
				
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtPhoneNumber").focus();
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
				}
							
				//Validating Father's Full Name for blank data.				
				strText = document.getElementById("txtFathersName").value;
				if (Trim(strText) == "")
				{
					alert("Please enter father name");
					document.getElementById("txtFathersName").focus();
					document.getElementById("txtFathersName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtFathersName").style.backgroundColor = 'white';
				}

				//Validating Father's Name for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtFathersName").focus();
					document.getElementById("txtFathersName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtFathersName").style.backgroundColor = 'white';
				}
							  
				//Validating House hold income for salacted value.
				strText = document.getElementById("ddlHouseholdIncome").value; 
				if ((strText) == 0)
				{
					alert("Please select house hold income");
					document.getElementById("ddlHouseholdIncome").focus();
					document.getElementById("ddlHouseholdIncome").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlHouseholdIncome").style.backgroundColor = 'white';
				}
							
				//Validating that you belongs to option is selacted or not.	
				if(window.document.forms[0].rblYouBelongTo[0].checked==false && window.document.forms[0].rblYouBelongTo[1].checked==false)	
				{
					alert("Please select you belong to");
					document.getElementById("rblYouBelongTo_0").focus();
					return false;
				}	
							
				//Validating that Highest Educational qualification	is salected or not.
				strText = document.getElementById("ddlQualification").value; 
				if (strText == 0)
				{
					alert("Please select qualification");
					document.getElementById("ddlQualification").focus();
					document.getElementById("ddlQualification").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlQualification").style.backgroundColor = 'white';
				}

				//Validating that Highest Education Obtained from is blank or not.
				strText = document.getElementById("txtHighestEducationObtainedFrom").value;
				if (strText == "")
				{
					alert("Please enter highest education obtained from");
					document.getElementById("txtHighestEducationObtainedFrom").focus();
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'white';
				}
				//Validating Highest Education Obtained from for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtHighestEducationObtainedFrom").focus();
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'white';
				}
							
					
				//Validating that College Address is blank or not.
				strText = document.getElementById("txtCollegeAddress").value;
				if (Trim(strText) == "")
				{
					alert("Please enter college address");
					document.getElementById("txtCollegeAddress").focus();
					document.getElementById("txtCollegeAddress").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCollegeAddress").style.backgroundColor = 'white';
				}
				
				//Validating Highest Education Obtained from for special character.
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtCollegeAddress").focus();
					document.getElementById("txtCollegeAddress").style.backgroundColor = 'yellow';
					return false;
				}	
				else
				{
					document.getElementById("txtCollegeAddress").style.backgroundColor = 'white';
				}						
				
				//Validate Highest Education Obtained from					
				strText = document.getElementById("txtHighestEducationCity").value;
				if (strText == "")
				{
					alert("Please enter highest education city name");
					document.getElementById("txtHighestEducationCity").focus();
					document.getElementById("txtHighestEducationCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtHighestEducationCity").style.backgroundColor = 'white';
				}


				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtHighestEducationCity").focus();
					document.getElementById("txtHighestEducationCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtHighestEducationCity").style.backgroundColor = 'white';
				}
							
				//Validate Qualification Details
				strText = document.getElementById("ddlQualificationDetails").value;   
				if ((strText) == 0)
				{
					alert("Please select qualification detail");
					document.getElementById("ddlQualificationDetails").focus();
					document.getElementById("ddlQualificationDetails").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlQualificationDetails").style.backgroundColor = 'white';
				}

				if(CheckedValue())
				{
					strText = document.getElementById("txtOtherQualification").value;  
					if (strText == "")
					{
						alert("Please enter educational detail");
						document.getElementById("txtOtherQualification").focus();
						document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
					}
					
					strText = document.getElementById("txtOtherQualification").value;  
					if (strText == "Specify other")
					{
						alert("Please enter educational detail");
						document.getElementById("txtOtherQualification").focus();
						document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
					}

					if (IsAngularBracket(strText))
					{
						alert("Character '< ' is not allowed");
						document.getElementById("txtOtherQualification").focus();
						document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
					}
				}
							
				//Validate Aggregate Percentage Scored			
				strText = document.getElementById("txtPercentageScored").value;
				if (Trim(strText) == "")
				{
					alert("Please enter aggregate percentage scored");
					document.getElementById("txtPercentageScored").focus();
					document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
				}
							
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtPercentageScored").focus();
					document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
				}

				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtPercentageScored").focus();
					document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
				}
				
				//validate 12th passing year
				strText = document.getElementById("ddlPassingYear12Th").value;  
									
				if (strText == 0)
				{
					alert("Please select 12Th Passing year");
					document.getElementById("ddlPassingYear12Th").focus();
					document.getElementById("ddlPassingYear12Th").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlPassingYear12Th").style.backgroundColor = 'white';
				}	
				//validate emp status
				if(window.document.forms[0].rblEmploymentStatus[0].checked==false && window.document.forms[0].rblEmploymentStatus[1].checked==false)			
				{
					alert("Please select employment status");
					document.getElementById("rblEmploymentStatus_0").focus();
					return false;
				}
				
				//validate current location and language skills
				strText = document.getElementById("txtCurrentLocation").value;					
				if (Trim(strText) == "")
				{
					alert("Please enter Current Location");
					document.getElementById("txtCurrentLocation").focus();
					document.getElementById("txtCurrentLocation").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCurrentLocation").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtLanguageSkills").value;					
				if (Trim(strText) == "")
				{
					alert("Please enter Language skills");
					document.getElementById("txtLanguageSkills").focus();
					document.getElementById("txtLanguageSkills").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtLanguageSkills").style.backgroundColor = 'white';
				}	
							
				//Validate Willing to work out of hometown
				if(window.document.forms[0].rblWillingToWorkOutOfHomeTown[0].checked==false && window.document.forms[0].rblWillingToWorkOutOfHomeTown[1].checked==false)		
				{
					alert("Please select willing to work out of home town");
					document.getElementById("rblWillingToWorkOutOfHomeTown_0").focus();
					return false;
				}	
				//validate passport
				//Passport				
				strText = document.getElementById("ddlPassport").value;     
									
				if ((strText) == "0")
				{
					alert("Please select Passport.");
					document.getElementById("ddlPassport").focus();
					document.getElementById("ddlPassport").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPassport").style.backgroundColor = 'white';
				}        				
				
				if ((strText) == "Yes")
				{
					strText = document.getElementById("txtPassport").value;
					
					if (strText == "")
					{
						alert("Please enter Passport Detail.");
						document.getElementById("txtPassport").focus();
						document.getElementById("txtPassport").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("txtPassport").style.backgroundColor = 'white';
					}

					if (IsAngularBracket(strText))
					{
						alert("Character '< ' is not allowed");
						document.getElementById("txtPassport").focus();
						document.getElementById("txtPassport").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("txtPassport").style.backgroundColor = 'white';
					}				
				}
				else
				{
					document.getElementById("ddlPassport").style.backgroundColor = 'white';
				}	

				//Validate Test City
				strText = document.getElementById("ddlTestCity").value;                     
				if ((strText) == 0)
				{
					alert("Please select test city");
					document.getElementById("ddlTestCity").focus();
					document.getElementById("ddlTestCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCity").style.backgroundColor = 'white';
				}
							
				//Validate Test Centre
				strText = document.getElementById("ddlTestCentre").value; 
							 
				if ((strText) == 0)
				{
					alert("Please select test centre");
					document.getElementById("ddlTestCentre").focus();
					document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCentre").style.backgroundColor = 'white';
				}
							                         
				strText = document.getElementById("txtPassword").value;
											
				if (Trim(strText) == "")
				{
					alert("Please enter password");
					document.getElementById("txtPassword").focus();
					document.getElementById("txtPassword").style.backgroundColor = 'yellow';
					return false;
				}
                           
				//Validate Confirm Password           
				strText = document.getElementById("txtPassword").value;						
				if (Trim(strText) == "")
				{
					alert("Please enter password");
					document.getElementById("txtPassword").focus();
					document.getElementById("txtPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPassword").style.backgroundColor = 'white';
				}
                           
				//Validate Confirm Password           
				var confirmText = document.getElementById("txtConfirmPassword").value;
				if (Trim(confirmText) == "")
				{
					alert("Please enter confirm password");
					document.getElementById("txtConfirmPassword").focus();
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
				}
			
				if (document.getElementById("txtConfirmPassword").value != document.getElementById("txtPassword").value)
				{
					alert("Please enter confirm password same as password");
					document.getElementById("txtConfirmPassword").focus();
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
				}
				
				//Validate Photo Id document			
				strText = document.getElementById("ddlPhotoIdDocument").value;  
				if (strText == 0)
				{
					alert("Please select photo id document");
					document.getElementById("ddlPhotoIdDocument").focus();
					document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'yellow';
					return false;
				}  
				else
				{
					document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'white';
				}    
								  
					      
				strText = document.getElementById("txtPhotoIdNumber").value;
				if (Trim(strText) == "")
				{
					alert("Please enter photo id number");
					document.getElementById("txtPhotoIdNumber").focus();
					document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'white';
				} 
					
				
				if (IsAngularBracket(strText))
				{
					alert("Character '< ' is not allowed");
					document.getElementById("txtPhotoIdNumber").focus();
					document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'white';
				} 
			}
		</script>
		<script>
			var req;

			function Initialize()
			{
				try
				{
					req=new ActiveXObject("Msxml2.XMLHTTP");
				}
				catch(e)
				{
					try
					{
						req=new ActiveXObject("Microsoft.XMLHTTP");
					}
					catch(oc)
					{
						req=null;
					}
				}

				if(!req&&typeof XMLHttpRequest!="undefined")
				{
					req=new XMLHttpRequest();
				}
				
			}
			
			function GetParameter( name )
			{
				name = name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
				var regexS = "[\\?&]"+name+"=([^&#]*)";
				var regex = new RegExp( regexS );
				var results = regex.exec( window.location.href );
				if( results == null )
					return "";
				else
					return results[1];
			}

			function SendQuery(key)
			{					
				Initialize();	
				var url=window.location.href;					
				url=url.substr(0,url.search("Edit_Registration.aspx"));				
				var url=url+"PasswordCheck.aspx?k="+key+"&CandidateID="+GetParameter("CandidateID");				
				if(req!=null)
				{
					req.onreadystatechange = Process;
					req.open("GET", url, true);
					req.send(null);
			        
				}
				
			}

			function Process()
			{
				if (req.readyState == 4) 
					{					
					// only if "OK"
						if (req.status == 200) 
						{
							if(req.responseText=="")
								HideDiv("password");
							else
							{
								ShowDiv("password");
								document.getElementById("password").innerHTML =req.responseText;
								if (req.responseText=="Password already exist")
								{
									document.getElementById("txtPassword").focus();
									document.getElementById("txtPassword").value="";
								}
								else
								{
									document.getElementById("txtPassword").style.backgroundColor = 'white';
									HideDiv("password");
								}
									
							}
						}
						else 
						{
							document.getElementById("password").innerHTML="There was a problem retrieving data:<br>"+req.statusText;
						}
					}
			}

			function ShowDiv(divid) 
			{
			if (document.layers) document.layers[divid].visibility="show";
			else document.getElementById(divid).style.visibility="visible";
			}

			function HideDiv(divid) 
			{
			if (document.layers) document.layers[divid].visibility="hide";
			else document.getElementById(divid).style.visibility="hidden";
			}

			function BodyLoad()
			{
				HideDiv("password");
				
				
			}
			function HidePassport()
			{						
				if(document.getElementById("ddlPassport").value == "No")
		        {	            
		            document.getElementById("dvPassport1").style.display = "none";     		                       		           
		         
		        }
		        else
		        {		        
					 document.getElementById("dvPassport1").style.display = "";          		                    
		        }
			}
		</script>
        <style type="text/css">
            .style1
            {
                height: 22px;
            }
            .style2
            {
                font-size: 11px;
                color: #a11d21;
                font-family: Verdana;
                text-decoration: none;
                height: 22px;
            }
        </style>
</HEAD>
	<body onload="BodyLoad();">
		<form id="frmEditRegistration" method="post" runat="server">
		
                                 <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Edit Regsitration Details 
                        <asp:label id="lblStateName" Runat="server" Visible="False"></asp:label></h2>


									<table id="Table4" cellSpacing="0" cellPadding="3" width="100%" border="0">
										<TR>
											<TD class="small_maroon" width="43%" colSpan="3">All (*) marked are mandatory 
												fields&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>PERSONAL DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td width="43%">First Name:<font class="small_maroon">*</font></td>
											<td width="55%"><asp:textbox id="txtFirstName" MaxLength="30" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon" width="2%"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Middle Name:
											</td>
											<td><asp:textbox id="txtMiddleName" MaxLength="30" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Last Name:<FONT class="small_maroon">*</FONT></td>
											<td><asp:textbox id="txtLastName" MaxLength="30" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Date of Birth:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:dropdownlist id="ddlDay" Runat="server" CssClass="txtarea">
													<asp:ListItem Value="0">Day</asp:ListItem>
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
												</asp:dropdownlist><asp:dropdownlist id="ddlMonth" Runat="server" CssClass="txtarea">
													<asp:ListItem Value="0">Month</asp:ListItem>
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
												</asp:dropdownlist><asp:dropdownlist id="ddlYear" Runat="server" CssClass="txtarea">													
												</asp:dropdownlist></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Gender:<FONT class="small_maroon">*</FONT></td>
											<td><asp:radiobuttonlist id="rblGender" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal">
													<asp:ListItem Value="M">Male</asp:ListItem>
													<asp:ListItem Value="F">Female</asp:ListItem>
												</asp:radiobuttonlist></td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Residential Address:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:textbox id="txtResidentialAddress" runat="server" MaxLength="400" CssClass="txtarea" Columns="1"
													Rows="4" TextMode="MultiLine" Width="300px"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>City:<FONT class="small_maroon">*</FONT></td>
											<td><asp:textbox id="txtCity" MaxLength="100" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Pincode:<FONT class="small_maroon">*</FONT></td>
											<td><asp:textbox id="txtPinCode" MaxLength="6" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Phone Number (Landline):<FONT class="small_maroon">*</FONT>
											</td>
											<td><font class="rblbox">(STD Code)</font><asp:textbox id="txtSTDCode" MaxLength="6" Runat="server" CssClass="txtbox" Width="50px"></asp:textbox>
												&nbsp;<asp:textbox id="txtPhoneNumber" MaxLength="10" Runat="server" CssClass="txtbox"></asp:textbox>
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Phone Number (Cellphone):
											</td>
											<td><asp:textbox id="txtCellPhone" MaxLength="15" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Photograph:
											</td>
											<td><asp:image id="imgUploadPhotograph" Runat="server" Width="100px" Height="100px" ImageUrl="Images/defaultphoto.jpg"></asp:image></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Upload Photograph:
											</td>
											<td><INPUT class="btn2File" id="filUpload" size="40" type="file" name="filUpload" runat="server">
												<span Class="Submitbutton"><asp:button  id="btnRemoveImage" runat="server" CssClass="btn2" Text="Remove"></asp:button></span><asp:literal id="ltrlErrorReview" runat="server"></asp:literal></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<TR class="main_black">
											<TD class="small_maroon" colSpan="3">* To upload your photograph, click on 'browse' 
												button and select photograph from the computer where you have saved the 
												photograph. It must be in .jpg or .jpeg format only.</TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td>Email:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:textbox id="txtEmailID" MaxLength="30" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon">&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Mother's Full Name:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:textbox id="txtMothersName" MaxLength="50" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Father's Full Name:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:textbox id="txtFathersName" MaxLength="50" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Annual Household Income:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:dropdownlist id="ddlHouseholdIncome" Runat="server" CssClass="txtarea"></asp:dropdownlist></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>You belong to:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:radiobuttonlist id="rblYouBelongTo" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal"
													Width="120px">
													<asp:ListItem Value="Village">Village</asp:ListItem>
													<asp:ListItem Value="City">City</asp:ListItem>
												</asp:radiobuttonlist></td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Highest Educational Qualification:<FONT class="small_maroon">*</FONT>
											</td>
											<td>
												<P><asp:dropdownlist id="ddlQualification" Runat="server" CssClass="txtarea" Width="176px"></asp:dropdownlist><INPUT id="hdQualification" type="hidden" value="0" name="hdQualificationDetails" runat="server"></P>
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="small_black" vAlign="top" align="left" id="dvEduFrom">
											<td id="divHighestEducationObtainedFrom" class="main_black" runat="server"><asp:label id="lblCollege" runat="server"></asp:label><FONT class="small_maroon">*</FONT></td>
											<td><asp:textbox id="txtHighestEducationObtainedFrom" MaxLength="50" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="small_black" id="dvHighEduYear" vAlign="top" align="left">
											<td id="divHighestEducationYear" align="left" runat="server"></td>
											<td id="TdYG1" align="left"><asp:dropdownlist id="ddlGraduationYear" Runat="server" CssClass="txtarea" BackColor="White" Width="88px">
												
												</asp:dropdownlist></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="small_black" id="dvPGSpecialization" vAlign="top" align="left" runat="server">
											<td id="Td3" class="main_black" >Specialization in PG:</td>
											<td align="left"><asp:textbox id="txtPGSpecialization" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"></asp:textbox></td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="small_black" id="dvPostGraduate2" vAlign="top" align="left">
											<td class="main_black">College Address:<FONT class="small_maroon">*</FONT>
											</td>
											<td style="WIDTH: 250px"><asp:textbox id="txtCollegeAddress" runat="server" MaxLength="100" CssClass="txtarea" Columns="30"
													Rows="4" TextMode="MultiLine" Width="250px"></asp:textbox></td>
											<td class="small_black"></td>
										</tr>
										<tr class="main_black" vAlign="top"  id="dvCollegeCity">
											<td class="main_black">College City:<FONT class="small_maroon">*</FONT></td>
											<td><asp:textbox id="txtHighestEducationCity" MaxLength="50" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon" align="left"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Qualification Details:<FONT class="small_maroon">*</FONT>
											</td>
											<td><asp:dropdownlist id="ddlQualificationDetails" Runat="server" CssClass="txtarea" Width="104px"></asp:dropdownlist><INPUT class="txtarea" id="txtOtherQualification" style="VISIBILITY: visible" onfocus="this.value = ''; return true;"
													type="text" maxLength="50" value="Specify other" name="txtOtherQualification" Runat="server">
												<INPUT id="hdQualificationDetails" type="hidden" value="0" name="hdQualificationDetails"
													runat="server"> <INPUT id="hdQualificationDetailsName" type="hidden" value="0" name="hdQualificationDetailsName"
													runat="server">
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="style1">Aggregate Percentage Scored:<FONT class="small_maroon">*</FONT></td>
											<td class="style1"><asp:textbox id="txtPercentageScored" MaxLength="3" Runat="server" CssClass="txtbox" Width="70px"></asp:textbox>%
											</td>
											<td class="style2"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Medium of Instruction upto 10th:<FONT class="small_maroon">*</FONT></td>
											<td><asp:dropdownlist id="ddlMediumOfInstruction" Runat="server" CssClass="txtarea">
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
											<TD class="small_maroon"></TD>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Medium of Instruction in 12th:<FONT class="small_maroon">*</FONT></td>
											<td><asp:dropdownlist id="ddlMediumOfInstructionIn12Th" Runat="server" CssClass="txtarea">
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
											<TD class="small_maroon"></TD>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Year of passing 12th:<FONT class="small_maroon">*</FONT></td>
											<td><asp:dropdownlist id="ddlPassingYear12th" Runat="server" CssClass="txtarea" BackColor="White" Width="88px">
												
												</asp:dropdownlist><font class="small_maroon"></font></td>
											<TD class="small_maroon"></TD>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>PROFESSIONAL DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Employment Status:<FONT class="small_maroon">*</FONT></td>
											<td><asp:radiobuttonlist id="rblEmploymentStatus" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal"
													Width="176px">
													<asp:ListItem Value="Employed">Employed</asp:ListItem>
													<asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
												</asp:radiobuttonlist></td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Current Location:<FONT class="small_maroon">*</FONT></td>
											<td class="small_maroon"><asp:textbox id="txtCurrentLocation" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"></asp:textbox>
											(city where you presently stay)
											</td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Language Skills:<FONT class="small_maroon">*</FONT></td>
											<td class="small_maroon"><asp:textbox id="txtLanguageSkills" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"></asp:textbox>
											(language that you are proficient in)
											</td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Willing to work out of hometown:<FONT class="small_maroon">*</FONT></td>
											<td><asp:radiobuttonlist id="rblWillingToWorkOutOfHomeTown" Runat="server" CssClass="rblbox" RepeatColumns="2"
													RepeatDirection="Horizontal">
													<asp:ListItem Value="Yes">Yes</asp:ListItem>
													<asp:ListItem Value="No">No</asp:ListItem>
												</asp:radiobuttonlist></td>
											<td class="small_maroon" vAlign="middle"></td>
										</tr>
										
										<tr class="main_black" vAlign="top" align="left">
											<td>Do you have a passport?:<FONT class="small_maroon">*</FONT></td>
											<td><asp:dropdownlist id="ddlPassport" Runat="server" CssClass="txtarea" BackColor="White">
													<asp:ListItem Value="Yes">Yes</asp:ListItem>
													<asp:ListItem Value="No">No</asp:ListItem>
												</asp:dropdownlist>&nbsp;&nbsp;
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" id="dvPassport1" vAlign="top" align="left" runat="server">
											<td>Fill in the passport no:<FONT class="small_maroon">*</FONT></td>
											<td>
												<asp:textbox id="txtPassport" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"></asp:textbox>
												<!--<input id="Hidden1" type="hidden" value="0" name="hdPassport" runat="server">-->
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>NAC TEST DETAILS</strong></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Test City:<FONT class="small_maroon">*</FONT>
											</td>
											<td>
												<div id="divDropTestCity" runat="server"><asp:dropdownlist id="ddlTestCity" Runat="server" CssClass="txtarea" BackColor="White" AutoPostBack="False"
														Enabled="False"></asp:dropdownlist><SPAN class="small_maroon">(please 
																select city) </SPAN></div>
												<div id="divLblTestCity" runat="server"><asp:label id="lblTestCity" Runat="server"></asp:label></div>
												<font class="small_maroon"></font>
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Test Centre:<FONT class="small_maroon">*</FONT>
											</td>
											<td>
												<div id="divDropTestCentre" runat="server"><asp:dropdownlist id="ddlTestCentre" Runat="server" CssClass="txtarea" BackColor="White" Enabled="False"></asp:dropdownlist><SPAN class="small_maroon">(please 
																select test centre) </SPAN></div>
												<div id="divLblTestCentre" runat="server"><asp:label id="lblTestCentre" Runat="server"></asp:label></div>
												<font class="small_maroon"></font><input id="hdTestCentre" type="hidden" value="0" name="hdTestCentre" runat="server"><input id="hdTestCentreName" type="hidden" name="hdTestCentreName" runat="server">
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td class="lightblue_bg" colSpan="3"><strong>SECURITY </strong>
											</td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td>Password:<FONT class="small_maroon">*</FONT>
											</td>
											<td class="small_maroon"><asp:textbox id="txtPassword" MaxLength="8" Runat="server" CssClass="txtbox"></asp:textbox>
												<div id="password">
												</div>
													
													Password should be 6 - 12 characters.
                                                    <br />
                                                    Password must contain only alphabets and numerics only.
											</td>
											<td class="small_maroon"></td>
										</tr>
										<tr class="main_black" vAlign="top" align="left">
											<td style="HEIGHT: 24px">Confirm Password:<FONT class="small_maroon">*</FONT>
											</td>
											<td style="HEIGHT: 24px"><asp:textbox id="txtConfirmPassword" MaxLength="8" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon" style="HEIGHT: 24px"></td>
										</tr>
										<TR>
											<TD class="small_maroon" style="HEIGHT: 25px" colSpan="3">* Please note down this 
												password – You should use the same to view your NAC score card after the test</TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td>Select a photo ID document:<FONT class="small_maroon">*</FONT></td>
											<td><asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
													<asp:ListItem Value="Driving License">Driving License</asp:ListItem>
													<asp:ListItem Value="Passport">Passport</asp:ListItem>
													<asp:ListItem Value="PAN">PAN</asp:ListItem>
													<asp:ListItem Value="Voter ID">Voter ID</asp:ListItem>
													<asp:ListItem Value="College I-Card">College I-Card</asp:ListItem>
												</asp:dropdownlist></td>
											<td class="small_maroon"></td>
										</tr>
										<TR>
											<TD class="small_maroon" style="HEIGHT: 25px" colSpan="3">* Your photograph on the 
												admission card must match the one on the photo-ID document</TD>
										</TR>
										<tr class="main_black" vAlign="top" align="left">
											<td>Photo ID Document Number:<FONT class="small_maroon">*</FONT>
												<br>
											</td>
											<td><asp:textbox id="txtPhotoIdNumber" MaxLength="100" Runat="server" CssClass="txtbox"></asp:textbox></td>
											<td class="small_maroon"></td>
										<tr class="main_black" vAlign="top" align="left">
											<td>&nbsp;</td>
											<td class="small_maroon">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
										<tr class="main_black" vAlign="top" align="center">
											<td colSpan="3"><asp:button id="btnSave" runat="server" Text="Submit" onclick="btnSave_Click"></asp:button>&nbsp;</td>
										</tr>
									</table>
								
                                 </div>
            </div>           

            
                 <uc1:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc1:nacyearlyfooter> 
            </div>
							
						
					
		</form>
	</body>
</HTML>
