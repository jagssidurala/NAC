
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registration</title>
		<meta name="ProgId" content="SharePoint.WebPartPage.Document">
		<meta name="WebPartPageExpansion" content="full">
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link rel="stylesheet" href="Stylesheet/nasscomNew.css" type="text/css" media="screen">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		    
			history.forward(1);
		
		function avoidEnter() 
			{ 
				if (window.event.keyCode == 13) 
				{ 
					window.event.cancelBubble = true; 
					window.event.returnValue = false; 
				} 
			} 
		 
		 function fillOnlyPercentageValue(eV)
		    {
				var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        if (!extractNumber(varValue,2,false))
				    {
					    alert("Please enter a valid Percentage.");
					    document.getElementById(varControlId).value = "";
					    document.getElementById(varControlId).focus();
					    document.getElementById(varControlId).style.backgroundColor = 'yellow';
					    return false;
					 }
				else if((varValue>100 || varValue<0))
		        {
                        alert("Please enter a valid value");
                        document.getElementById(varControlId).value = "";
                        document.getElementById(varControlId).focus();
                        document.getElementById(varControlId).style.backgroundColor = 'yellow';
                        return false;
		        }
				else
				{
				   document.getElementById(varControlId).style.backgroundColor = 'white';
				}
				
				return true;
		    }
		    
		    function CheckConfirmPassword()
		    {
				var confirmText = document.getElementById("txtConfirmPassword").value;

				if (document.getElementById("txtConfirmPassword").value != document.getElementById("txtPassword").value)
				{
					alert("Confirm password doesn't match with the password");
					document.getElementById("txtPassword").focus();
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
					document.getElementById("txtPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
					document.getElementById("txtPassword").style.backgroundColor = 'white';
				}
		    }
		    
		    function ValidateMobile(ev)
			{
				var varControlId;
		        var varValue;
		        varControlId = ev.name;
		        varValue = document.getElementById(varControlId).value;
				if(varValue.length != 10 && Trim(varValue) != "")
				{
		            alert("Please enter 10 digit Mobile No.");
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
				}
				else
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
				}
			}
		 
		    function BlankFileUpload()
		    {
		       document.getElementById("filUpload").outerHTML = "<input name='filUpload' id='filUpload' type='file' class='btn2' size='40'>";
		    }
		    
		    function SamePasswordAlert()
		    {
				alert("This Password already exists.\nPlease change it!.")
		    }
		    
		    function fillOnlyAlphabetValue(eV)
		    {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       // varSubString = document.getElementById(varControlId).value;
		       // varSubString = varSubString.substring(0,varSubString.length - 1);
		        
				 
		        
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
		       // varSubString = document.getElementById(varControlId).value;
		       // varSubString = varSubString.substring(0,varSubString.length - 1);
		        
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
		       // varSubString = document.getElementById(varControlId).value;
		       // varSubString = varSubString.substring(0,varSubString.length - 1);
		        
				 
		        
		        if (!IsNumeric(varValue))
				    {
				       
					  alert("Please enter numeric data");
					  document.getElementById(varControlId).value = "";
					  document.getElementById(varControlId).focus();
					  document.getElementById(varControlId).style.backgroundColor = 'yellow';
					  return false;
					}
				else
					{
						document.getElementById(varControlId).style.backgroundColor = 'white';
					}		        
		    }

		     
		    function CheckFileExtension()
		     {			       	 
				var ext = document.getElementById("filUpload").value;
				var extFour;
				var bFileFormat = false;
								
				//document.getElementById("btnFileUpload").value = document.getElementById("filUpload").value;
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
		     
		    function ChangeCollegeLabel()
		    {
				//document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
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
					document.getElementById("divHighestEducationYear").innerText="Year of Graduation"	
						
					document.getElementById("dvPGSpecialization").style.display="none";			
				}
				else if (varCheckOther == 'post graduate')
				{
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "right";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "Graduation done from (College Name):*";
					document.getElementById("divHighestEducationYear").style.textAlign = "right";
					document.getElementById("divHighestEducationYear").innerText="Year of Post Graduation"
			
					document.getElementById("dvPGSpecialization").style.display="";	
				}
				else
				{
					
				
					document.getElementById("dvPGSpecialization").style.display="none";	
				}
		    }		     
		    
		    function hideTextBox()
		    {
		        
		    if(document.getElementById("ddlQualification").value == "0")
		        {
		            document.getElementById("dvPostGraduate").style.display = "none";
		            document.getElementById("dvPostGraduate1").style.display = "none";
		            document.getElementById("dvPostGraduate2").style.display = "none";
		            document.getElementById("dvHighEduYear").style.display = "none";
		           
		            document.getElementById("dvPGSpecialization").style.display = "none";
		        }
		        else
		        {
		            document.getElementById("dvPostGraduate").style.display = "";
		            document.getElementById("dvPostGraduate1").style.display = "";
		            document.getElementById("dvPostGraduate2").style.display = "";
		            document.getElementById("dvHighEduYear").style.display = "";
		            
		            document.getElementById("dvPGSpecialization").style.display = "";
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
		     
		     function fillHiddenQualification()
		     {
		     
		        document.getElementById("hdQualificationDetails").value = document.getElementById("ddlQualificationDetails").value;
		       
		        
		       var varCheckOther;
		       var box = document.getElementById("ddlQualificationDetails");	       
		       var varOption = document.createElement('OPTION');
		       
		         varOption = box.options[box.selectedIndex];		        
		         varCheckOther = varOption.text;		        
		         varCheckOther = varCheckOther.toLowerCase();
		        
		       document.getElementById("hdQualificationDetailsName").value = varCheckOther;
		          
		        if(varCheckOther == 'others')
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
		     
			function ValidateData()
			{
			      var strText;
			      
				  //Validate First Name
					
			
					
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
				
				
				if (!IsAlphabet(strText))
				{
					alert("Please enter alphabet");
					document.getElementById("txtFirstName").focus();
					document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtFirstName").style.backgroundColor = 'white';
				}

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


					//Validate Middle Name
					
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

					//Validate Last Name
						   
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
                         
                         
					//Validate Gender
							  
								
				if(window.document.forms[0].rblGender[0].checked==false && window.document.forms[0].rblGender[1].checked==false)
				{
					alert("Please select gender");
					document.getElementById("rblGender_0").focus();
					return false;
				}
								 
							 
								
					//Validate Residential Address							 
							
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
				
				
				
				
					//Validate city						 

							
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
														
					//Validate Pincode							 
							
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
							 
							  // STD Code
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
														 
							//Phone Number
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
							
					//Validate Mobile Number
					
							 
							 
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

				if (!IsNumeric(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtCellPhone").focus();
					document.getElementById("txtCellPhone").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCellPhone").style.backgroundColor = 'white';
				}
							 
					//Validate Upload Photograph
					
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
				
				
													
	 				//Validate Email Id			
							
				strText=document.getElementById("txtEmailID").value;

					
				if (IsAngularBracket(strText))
				{
					alert("Please enter numeric data");
					document.getElementById("txtEmailID").focus();
					document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtEmailID").style.backgroundColor = 'white';
				}

				if ((!(emailCheck(strText))) && Trim(strText) != "")
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
							
					//Validate Mother's Full Name					
							 
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
							
					//Validate Father's Full Name					
							 
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
							  
					//Validate Annual Household Income
					
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
							
					//Validate You belong to		
						
				if(window.document.forms[0].rblYouBelongTo[0].checked==false && window.document.forms[0].rblYouBelongTo[1].checked==false)	
				{
					alert("Please select you belong to");
					document.getElementById("rblYouBelongTo_0").focus();
					return false;
				}	
							
					//Validate Highest Educational qualification					
							 
							
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

					//Validate Highest Education Obtained			
							 
				strText = document.getElementById("txtHighestEducationObtainedFrom").value;
					
				if (strText == "")
				{
					alert("Please enter college name");
					document.getElementById("txtHighestEducationObtainedFrom").focus();
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'white';
				}

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
					
				//Validate College Address	
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
					alert("Please enter college city");
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
				}
								//txtOtherQualification
							
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

				strText = document.getElementById("ddlMediumOfInstruction").value;                       
				if ((strText) == 0)
				{
					alert("Please select medium of instruction upto 10");
					document.getElementById("ddlMediumOfInstruction").focus();
					document.getElementById("ddlMediumOfInstruction").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMediumOfInstruction").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlMediumOfInstructionIn12Th").value;                       
				if ((strText) == 0)
				{
					alert("Please select medium of instruction upto 12");
					document.getElementById("ddlMediumOfInstructionIn12Th").focus();
					document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlMediumOfInstruction").value;                       
				if ((strText) == 0)
				{
					alert("Please select medium of instruction upto 10");
					document.getElementById("ddlMediumOfInstruction").focus();
					document.getElementById("ddlMediumOfInstruction").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("ddlMediumOfInstructionIn12Th").value;                       
				if ((strText) == 0)
				{
					alert("Please select medium of instruction upto 12");
					document.getElementById("ddlMediumOfInstructionIn12Th").focus();
					document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'white';
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
				var varCentreCheck = <%=Convert.ToInt32(Session["StateId"])%>;  				
				if ((strText) == 0 && varCentreCheck != 1)//&& varCentreCheck != 6)
				{
					if ((strText) == 0 && varCentreCheck != 6)
					{
						alert("Please select test centre");
						document.getElementById("ddlTestCentre").focus();
						document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
						return false;
					}
				}
				else
				{
					document.getElementById("ddlTestCentre").style.backgroundColor = 'white';
				}
							
					//Validate Password
					
                            
                           
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
				
				if(document.getElementById("chkAuthorization").checked == false)
			    {
			        alert("Please accept the Authorization");
					document.getElementById("chkAuthorization").focus();
					document.getElementById("chkAuthorization").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("chkAuthorization").style.backgroundColor = 'white';
				}
				
				if(!window.confirm("Are you sure you want to submit the details?"))
					{
						return false;
					}
				return true;
			}	

			function SetComponentStatus()
			{
				//document.getElementById("txtOtherQualification").style.visibility = "hidden";
				strText = document.getElementById("ddlQualificationDetails").value;                       
				if ((strText) == 0)
				{
				document.getElementById("txtOtherQualification").style.visibility = "hidden";
				}
				HidePassport();
			}
			function RemovePhotograph()
			{
				document.getElementById("filUpload").value = "";
			}
			function HidePassport()
			{						
				if(document.getElementById("ddlPassport").value == "Yes")
				{					
					document.getElementById("dvPassport1").style.display = "";          		                    	            
		        }
		        else
		        {	
					document.getElementById("dvPassport1").style.display = "none";          		            		                       		           	        					 
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

			function SendQuery(key)
			{			
				Initialize();			
				var url=window.location.href;					
				url=url.substr(0,url.search("Registration.aspx"));				
				var url=url=url+"PasswordCheck.aspx?k="+key;				
				
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
			
		</script>
	</HEAD>
	<body onload="SetComponentStatus();BodyLoad();hideTextBox();ChangeCollegeLabel();">
		<form onkeypress="avoidEnter();" id="Form1" method="post" runat="server">
			<INPUT id="hdTestCentreName" type="hidden" name="hdTestCentreName" runat="server">
			<INPUT id="hdTestCentre" type="hidden" value="0" name="hdTestCentre" runat="server"><INPUT id="hdconfpassword" type="hidden" name="hdconfpassword" runat="server">
			<INPUT id="hdpassword" type="hidden" name="hdpassword" runat="server"><INPUT id="hdImagepath" type="hidden" name="hdImagepath" runat="server"><INPUT id="hdQualificationDetailsName" type="hidden" value="0" name="hdQualificationDetailsName"
				runat="server"><INPUT id="hdQualificationDetails" type="hidden" value="0" name="hdQualificationDetails"
				runat="server">
			<div align="center">
				<table border="0" id="table1" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellpadding="0" cellspacing="0" width="888">
								<tr>
									<td rowspan="6">
										&nbsp;</td>
									<td valign="top">
										&nbsp;</td>
									<td rowspan="6" width="4">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<h1>&nbsp;&nbsp;&nbsp; Registration Form</h1>
									</td>
								</tr>
								<tr>
									<td valign="top">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<table id="table5" cellSpacing="0" cellPadding="0" width="756" align="center" border="0" class="divForm">
											<tr>
												<td vAlign="top" align="center">
													<TABLE class="black_bg" id="table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TBODY>
															<TR class="white_bg" vAlign="top" align="left">
																<TD>
																</TD>
															</TR>
															<TR class="blue_bg" vAlign="top" align="left">
																<TD>
																	<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" id="table7">
																		<TR class="blue_bg" vAlign="top" align="left">
																			<TD vAlign="top" align="left">
																				<h1>&nbsp;&nbsp;REGISTRATION FORM&nbsp;
																					<asp:label id="lblStateName" Runat="server"></asp:label>
																				</h1>
																			</TD>
																			<TD class="header1" vAlign="middle" align="right">&nbsp;</TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<TR class="white_bg" vAlign="top" align="left">
																<TD align="center"><BR>
																	<TABLE id="table8" cellSpacing="0" cellPadding="3" width="94%" border="0">
																		<TR>
																			<TD colSpan="3">
																				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" id="table9">
																					<TR vAlign="top">
																						<TD class="textNormal" align="left" width="60%">All (*) marked are mandatory fields 
																							&nbsp;&nbsp;
																							<asp:label id="lblExistMessage" Runat="server" ForeColor="Red" Font-Bold="True"></asp:label></TD>
																						<TD class="textNormal" id="tdInstructions" align="right" width="40%" runat="server">
																						
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="lightblue_bg" colSpan="3" height="36">
																				<h1 class="textNormal"><STRONG>PERSONAL DETAILS</STRONG></h1>
																			</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD width="43%" class="textNormal">First Name:<FONT class="small_maroon">*</FONT></TD>
																			<TD width="55%"><asp:textbox id="txtFirstName" Runat="server" BackColor="White" MaxLength="30" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon" width="2%"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Middle Name:
																			</TD>
																			<TD><asp:textbox id="txtMiddleName" Runat="server" BackColor="White" MaxLength="30" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Last Name:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:textbox id="txtLastName" Runat="server" BackColor="White" MaxLength="30" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Date of Birth:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:dropdownlist id="ddlDay" Runat="server" BackColor="White" CssClass="txtarea">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlMonth" Runat="server" BackColor="White" CssClass="txtarea">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlYear" Runat="server" BackColor="White" CssClass="txtarea">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				</asp:dropdownlist></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Gender:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:radiobuttonlist id="rblGender" Runat="server" BackColor="White" CssClass="rblbox" Width="88px" RepeatColumns="2"
																					RepeatDirection="Horizontal">
																					<asp:ListItem Value="M">Male</asp:ListItem>
																					<asp:ListItem Value="F">Female</asp:ListItem>
																				</asp:radiobuttonlist></TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Residential Address:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD style="WIDTH: 250px"><asp:textbox id="txtResidentialAddress" runat="server" BackColor="White" MaxLength="100" CssClass="txtarea"
																					Width="250px" Columns="30" Rows="4" TextMode="MultiLine"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">City:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:textbox id="txtCity" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Pincode:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:textbox id="txtPinCode" Runat="server" BackColor="White" MaxLength="6" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Phone Number (Landline):<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><FONT class="rblbox">(STD Code)</FONT>
																				<asp:textbox id="txtSTDCode" Runat="server" BackColor="White" MaxLength="6" CssClass="txtbox"
																					Width="50px"></asp:textbox>&nbsp;
																				<asp:textbox id="txtPhoneNumber" Runat="server" BackColor="White" MaxLength="10" CssClass="txtbox"></asp:textbox>&nbsp;
																			</TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Phone Number (Cellphone):
																			</TD>
																			<TD><asp:textbox id="txtCellPhone" Runat="server" BackColor="White" MaxLength="10" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon">&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Upload Photograph:
																			</TD>
																			<TD colSpan="2"><INPUT class="btn2" id="filUpload" type="file" size="40" name="filUpload" runat="server">&nbsp;
																				<INPUT class="btn2" id="btnFileUpload" onclick="BlankFileUpload();" type="button" value="Remove">
																			</TD>
																		</TR>
																		<TR>
																			<TD class="textNormal" colSpan="3"><FONT class="small_maroon">*</FONT> To upload 
																				your photograph, click on 'browse' button and select photograph from the 
																				computer where you have saved the photograph. It must be in .jpg or .jpeg 
																				format only.</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Email ID:
																			</TD>
																			<TD><asp:textbox id="txtEmailID" Runat="server" BackColor="White" MaxLength="30" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon">&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD style="HEIGHT: 24px" class="textNormal">Mother's Full Name:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD style="HEIGHT: 24px"><asp:textbox id="txtMothersName" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon" style="HEIGHT: 24px"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Father's Full Name:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:textbox id="txtFathersName" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Annual Household Income:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:dropdownlist id="ddlHouseholdIncome" Runat="server" BackColor="White" CssClass="txtarea"></asp:dropdownlist></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">You belong to:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:radiobuttonlist id="rblYouBelongTo" Runat="server" BackColor="White" CssClass="rblbox" Width="112px"
																					RepeatColumns="2" RepeatDirection="Horizontal">
																					<asp:ListItem Value="Village">Village</asp:ListItem>
																					<asp:ListItem Value="City">City</asp:ListItem>
																				</asp:radiobuttonlist></TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Highest Educational Qualification:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:dropdownlist id="ddlQualification" Runat="server" BackColor="White" CssClass="txtarea"></asp:dropdownlist></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="small_black" id="dvPostGraduate" style="DISPLAY: none" vAlign="top" align="left">
																			<TD id="divHighestEducationObtainedFrom" style="HEIGHT: 19px" align="right" runat="server"
																				class="textNormal"></TD>
																			<TD style="HEIGHT: 19px" align="left"><asp:textbox id="txtHighestEducationObtainedFrom" Runat="server" BackColor="White" MaxLength="50"
																					CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon" style="HEIGHT: 19px"></TD>
																		</TR>
																		<TR class="small_black" id="dvHighEduYear" style="DISPLAY: none" vAlign="top" align="left">
																			<TD id="divHighestEducationYear" align="right" class="textNormal"></TD>
																			<TD id="TdYG1" align="left"><asp:dropdownlist id="ddlGraduationYear" Runat="server" BackColor="White" CssClass="txtarea" Width="88px">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="small_black" id="dvPGSpecialization" style="DISPLAY: none" vAlign="top" align="left">
																			<TD id="Td3" align="right" class="textNormal">Specialization in PG:</TD>
																			<TD align="left"><asp:textbox id="txtPGSpecialization" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="small_black" id="dvPostGraduate2" style="DISPLAY: none" vAlign="top" align="left">
																			<TD align="right" class="textNormal">College Address:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD style="WIDTH: 250px" vAlign="middle"><asp:textbox id="txtCollegeAddress" runat="server" BackColor="White" MaxLength="100" CssClass="txtarea"
																					Width="250px" Columns="30" Rows="4" TextMode="MultiLine"></asp:textbox></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="small_black" id="dvPostGraduate1" style="DISPLAY: none" vAlign="top" align="left">
																			<TD align="right" class="textNormal">College City:<FONT class="small_maroon">*</FONT></TD>
																			<TD align="left"><asp:textbox id="txtHighestEducationCity" Runat="server" BackColor="White" MaxLength="10" CssClass="txtbox"></asp:textbox><FONT class="small_maroon"></FONT></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Qualification Details:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD><asp:dropdownlist id="ddlQualificationDetails" Runat="server" BackColor="White" CssClass="txtarea"></asp:dropdownlist>&nbsp;&nbsp;<INPUT class="txtarea" id="txtOtherQualification" style="VISIBILITY: visible" onfocus="this.value = ''; return true;"
																					type="text" maxLength="50" value="Specify other" name="txtOtherQualification" Runat="server">
																			</TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Aggregate Percentage Scored:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:textbox id="txtPercentageScored" Runat="server" BackColor="White" MaxLength="5" CssClass="txtbox"
																					Width="70px"></asp:textbox>%</TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal" height="21">Medium of Instruction upto 10th:<FONT class="small_maroon">*</FONT></TD>
																			<TD height="21"><asp:dropdownlist id="ddlMediumOfInstruction" Runat="server" BackColor="White" CssClass="txtarea">
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
																				</asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
																			<TD class="small_maroon" height="21"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Medium of Instruction in 12th:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:dropdownlist id="ddlMediumOfInstructionIn12Th" Runat="server" BackColor="White" CssClass="txtarea">
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
																				</asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Year of passing 12th:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:dropdownlist id="ddlPassingYear12th" Runat="server" BackColor="White" CssClass="txtarea" Width="88px">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				</asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">&nbsp;</TD>
																			<TD class="small_maroon">&nbsp;</TD>
																			<TD>&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal" colSpan="3"><STRONG>PROFESSIONAL DETAILS</STRONG></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Employment Status:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:radiobuttonlist id="rblEmploymentStatus" Runat="server" BackColor="White" CssClass="rblbox" Width="160px"
																					RepeatColumns="2" RepeatDirection="Horizontal">
																					<asp:ListItem Value="Employed">Employed</asp:ListItem>
																					<asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
																				</asp:radiobuttonlist></TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Current Location:<FONT class="small_maroon">*</FONT></TD>
																			<TD class="small_maroon"><asp:textbox id="txtCurrentLocation" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox>(city 
																				where you presently stay)
																			</TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Language Skills:<FONT class="small_maroon">*</FONT></TD>
																			<TD class="small_maroon"><asp:textbox id="txtLanguageSkills" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox>(language 
																				that you are proficient in)
																			</TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Willing to work out of hometown:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:radiobuttonlist id="rblWillingToWorkOutOfHomeTown" Runat="server" BackColor="White" CssClass="rblbox"
																					Width="96px" RepeatColumns="2" RepeatDirection="Horizontal">
																					<asp:ListItem Value="Yes">Yes</asp:ListItem>
																					<asp:ListItem Value="No">No</asp:ListItem>
																				</asp:radiobuttonlist></TD>
																			<TD class="small_maroon" vAlign="middle"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Do you have a passport?:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:dropdownlist id="ddlPassport" Runat="server" BackColor="White" CssClass="txtarea">
																					<asp:ListItem Value="0">Select</asp:ListItem>
																					<asp:ListItem Value="Yes">Yes</asp:ListItem>
																					<asp:ListItem Value="No">No</asp:ListItem>
																				</asp:dropdownlist>&nbsp;&nbsp;
																			</TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" id="dvPassport1" vAlign="top" align="left" runat="server">
																			<TD class="textNormal">Fill in the passport no:<FONT class="small_maroon">*</FONT></TD>
																			<TD><asp:textbox id="txtPassport" Runat="server" BackColor="White" MaxLength="50" CssClass="txtbox"></asp:textbox><!--<input id="Hidden1" type="hidden" value="0" name="hdPassport" runat="server">--></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">&nbsp;</TD>
																			<TD class="small_maroon">&nbsp;</TD>
																			<TD>&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal" colSpan="3"><STRONG>NAC TEST DETAILS</STRONG></TD>
																		</TR>
																		<TR class="main_black" id="trTestCity" vAlign="top" align="left" runat="server">
																			<TD class="textNormal">Test City:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD>
																				<DIV id="divDropTestCity" runat="server"><asp:dropdownlist id="ddlTestCity" Runat="server" BackColor="White" CssClass="txtarea" AutoPostBack="False"></asp:dropdownlist><SPAN class="small_maroon"><I>(please 
																							select city) </I><SPAN>
																				</DIV>
																				<DIV id="divLblTestCity" runat="server"><asp:label id="lblTestCity" Runat="server"></asp:label></DIV>
																				<FONT class="small_maroon"></FONT></SPAN></SPAN></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" id="trTestCentre" vAlign="top" align="left" runat="server">
																			<TD class="textNormal">Test Centre:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD>
																				<DIV id="divDropTestCentre" runat="server"><asp:dropdownlist id="ddlTestCentre" Runat="server" BackColor="White" CssClass="txtarea"></asp:dropdownlist><SPAN class="small_maroon"><I>(please 
																							select test centre)</I><SPAN></DIV>
																				<DIV id="divLblTestCentre" runat="server"><asp:label id="lblTestCentre" Runat="server"></asp:label></DIV>
																				<FONT class="small_maroon"></FONT></SPAN></SPAN></TD>
																			<TD class="small_maroon"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">&nbsp;</TD>
																			<TD class="small_maroon">&nbsp;</TD>
																			<TD>&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal" colSpan="3"><STRONG>SECURITY </STRONG>
																			</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Password:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD class="textNormal"><asp:textbox id="txtPassword" Runat="server" BackColor="White" MaxLength="8" CssClass="txtbox"
																					TextMode="Password"></asp:textbox><!-- onBlur = "SendQuery(this.value)"-->
																				<DIV id="password"></DIV>
																				<BR>
																				(can contain alphabet/number/special character - should not be more than 8 
																				characters)
																			</TD>
																			<TD class="textNormal"></TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Confirm Password:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD class="textNormal"><asp:textbox id="txtConfirmPassword" Runat="server" BackColor="White" MaxLength="8" CssClass="txtbox"
																					TextMode="Password"></asp:textbox><FONT class="small_maroon"></FONT></TD>
																			<TD class="textNormal"></TD>
																		</TR>
																		<TR>
																			<TD class="textNormal" style="HEIGHT: 25px" colSpan="3">* Please note down this 
																				password - You should use the same to view your NAC score card after the test</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Select a photo-ID document:<FONT class="small_maroon">*</FONT></TD>
																			<TD class="textNormal"><asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" BackColor="White" CssClass="txtarea"></asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
																			<TD class="textNormal"></TD>
																		</TR>
																		<TR>
																			<TD class="textNormal" style="HEIGHT: 25px" colSpan="3">* Your photograph on the 
																				admission card must match the one on the photo-ID document</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD class="textNormal">Photo-ID Document Number:<FONT class="small_maroon">*</FONT>
																			</TD>
																			<TD class="textNormal"><asp:textbox id="txtPhotoIdNumber" Runat="server" BackColor="White" MaxLength="15" CssClass="txtbox"></asp:textbox><FONT class="small_maroon"></FONT></TD>
																			<TD class="textNormal"></TD>
																		</TR>
																		<tr class="main_black" vAlign="top" align="left">
																			<td class="textNormal" style="TEXT-ALIGN: left">&nbsp;</td>
																			<td class="textNormal" style="TEXT-ALIGN: left">&nbsp;</td>
																			<td class="textNormal" style="TEXT-ALIGN: left">&nbsp;</td>
																		</tr>
																		<tr class="main_black" vAlign="top" align="left">
																			<td class="textNormal" colSpan="3" style="TEXT-ALIGN: left"><strong>AUTHORIZATION</strong>
																			</td>
																		</tr>
																		<tr class="main_black" vAlign="top" align="left">
																			<td colSpan="3" class="textNormal" style="TEXT-ALIGN: left">
																				<p style="TEXT-ALIGN: justify"><FONT class="small_maroon">*</FONT><asp:checkbox id="chkAuthorization" runat="server" Text=""></asp:checkbox>&nbsp;<span style="FONT-SIZE: 12px; COLOR: #7f7f7f; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif">
																						I authorize NASSCOM to share all my details, as indicated in the Registration<br>
																						&nbsp;Form, and my &nbsp;test scores with prospective employers who are 
																						interested to look at my profile for&nbsp;recruitment purposes.</span></p>
																			</td>
																		</tr>
																		<tr class="main_black" vAlign="top" align="left">
																			<td>&nbsp;</td>
																			<td class="small_maroon">&nbsp;</td>
																			<td>&nbsp;</td>
																		</tr>
																		<TR class="main_black" vAlign="top" align="left">
																			<TD>&nbsp;</TD>
																			<TD class="small_maroon"><asp:label id="lblMessage" Runat="server" ForeColor="Red" Font-Bold="True" Visible="False"></asp:label></TD>
																			<TD>&nbsp;</TD>
																		</TR>
																		<TR class="main_black" vAlign="top" align="center">
																			<TD colSpan="3"><asp:button id="Save" runat="server" Text="Submit"></asp:button></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
															<tr class="white_bg" vAlign="top" align="left">
																<td></td>
															</tr>
														</TBODY>
													</TABLE>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">
										&nbsp;</td>
								</tr>
								<tr>
									<td valign="top">
										<img src="Images/footerHome.jpg" width="891" height="49" alt=""></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
