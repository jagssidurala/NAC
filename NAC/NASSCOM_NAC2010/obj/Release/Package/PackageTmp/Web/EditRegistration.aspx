<%@ Page language="c#" Codebehind="EditRegistration.aspx.cs" enableEventValidation="true" AutoEventWireup="True" Inherits="NASSCOM_NAC.EditRegistration" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registration</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
         <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<LINK href="stylesheet/nasscom.css" type="text/css" rel="stylesheet">
        <!--[if IE]>
<link rel="stylesheet" href="Stylesheet/cssfile.css" type="text/css" />
<![endif]-->
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
        <SCRIPT language="javascript" src="js/jquery-1.jss"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
		function avoidEnter() 
			{ 
				if (window.event.keyCode == 13) 
				{ 
					window.event.cancelBubble = true; 
					window.event.returnValue = false; 
				} 
			} 
			
			// If the element's string matches the regular expression it is numbers and letters
			function fillOnlyAlphanumericValue(ev)
			{
				var varControlId;
		        var varValue;
		        varControlId = ev.name;
		        varValue = document.getElementById(varControlId).value;
				var alphaExp = /^[0-9a-zA-Z]+$/;
				if(ev.value=="")
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
				}
				
				else if(ev.value.match(alphaExp))
				{
					document.getElementById(varControlId).style.backgroundColor = 'white';
					return true;
				}
				else
				{
					alert("Please enter a valid passport number.");
					document.getElementById(varControlId).value = "";
					document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
				}
			}
			
			
			function BlankFileUpload()
		    {
		    
		    var oldElement = document.getElementById("filUpload");
			var newElement=document.createElement("filUpload");
			newElement.innerHTML="<input name='filUpload' id='filUpload' type='file' class='btn2' size='40'>";
			oldElement.parentNode.replaceChild(newElement,oldElement);
//		   document.getElementById("filUpload").outerHTML = "<input name='filUpload' id='filUpload' type='file' class='btn2' size='40'>";
			document.getElementById("hdImage").value='-1';
			document.getElementById("imgUploadPhotograph").style.visibility = 'hidden';
			document.getElementById("filUpload").value = "";
			document.getElementById("rowPhoto").style.display = "none";
			document.getElementById("rowUpload").style.display = "block";
			document.getElementById("rowUploadMsg").style.display = "block";
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
			
			function BodyLoad()
			{
				HideDiv("password");
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
				if((ext == 'jpg') ||(ext == 'peg') ||(ext == 'gif'))
				{
					bFileFormat = true;
				}   
				
				if(bFileFormat == false)
				 {
					alert('You selected a .' + ext + ' file; please select a .jpg/.jpeg/.gif file instead!');
					document.getElementById("filUpload").value = "";
					return false;
				 }				  
				else
					return true; 
		     }

		     function fillonlyAlphaComma(evt) {
		         if (!Form1.txtLanguageSkills.value.match(/^[a-zA-Z ,]+$/)) {
		             alert("Please enter only alphabets with comma");
		             document.getElementById("txtLanguageSkills").focus();
		             document.getElementById("txtLanguageSkills").style.backgroundColor = 'yellow';
		             return false;
		         }
		         else
		             document.getElementById("txtLanguageSkills").style.backgroundColor = 'white';

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
			
		   /* //Changing College level on selection of Qualification Type.
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
					document.getElementById("divHighestEducationYear").innerText = "Year of Graduation:";				
					//document.getElementById("dvGraduationYear").style.display="";	
					//document.getElementById("dvPGYear").style.display="none";	
					//document.getElementById("dvPGSpecialization").style.display="none";	
					document.getElementById("dvPGSpecialization").style.display="none";			
				}
				else if (varCheckOther == 'post graduate')
				{
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "right";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
					document.getElementById("divHighestEducationYear").style.textAlign = "right";
					document.getElementById("divHighestEducationYear").innerText = "Year of Post Graduation:";
					//document.getElementById("dvGraduationYear").style.display="none";	
					//document.getElementById("dvPGYear").style.display="";	
					//document.getElementById("dvPGSpecialization").style.display="";	
					document.getElementById("dvPGSpecialization").style.display="";
				}
				else
				{
					//document.getElementById("dvGraduationYear").style.display="none";	
					//document.getElementById("dvPGYear").style.display="none";	
					//document.getElementById("dvPGSpecialization").style.display="none";	
					document.getElementById("dvPGSpecialization").style.display="none";	
				}
		    } */

            //aku
			function RemoveJunk(e) {
			    var k;
			    document.all ? k = e.keyCode : k = e.which;
			    return ((k > 63 && k < 91) || (k > 96 && k < 123) || (k >= 48 && k <= 57));
			}

			function validateNum(evt) {
			    var theEvent = evt || window.event;
			    var key = theEvent.keyCode || theEvent.which;
			    key = String.fromCharCode(key);
			    var regex = /[0-9]/;
			    if (!regex.test(key)) {
			        theEvent.returnValue = false;
			        if (theEvent.preventDefault) theEvent.preventDefault();
			    }
			}

			function validatePercent(evt) {
			    var theEvent = evt || window.event;
			    var key = theEvent.keyCode || theEvent.which;
			    key = String.fromCharCode(key);
			    var regex = /[0-9]/;
			    if (!regex.test(key)) {
			        theEvent.returnValue = false;
			        if (theEvent.preventDefault) theEvent.preventDefault();
			    }
			}


			function validateAlpha(evt) {
			    var theEvent = evt || window.event;
			    var key = theEvent.keyCode || theEvent.which;
			    key = String.fromCharCode(key);
			    //var regex = /[a-zA-Z]/;
			    var regex = /^[a-zA-Z ]*$/;
			    if (!regex.test(key)) {
			        theEvent.returnValue = false;
			        if (theEvent.preventDefault) theEvent.preventDefault();
			    }
			}


			function validatePassport(evt) {
			    var theEvent = evt || window.event;
			    var key = theEvent.keyCode || theEvent.which;
			    key = String.fromCharCode(key);
			    //var regex = /[a-zA-Z]/;
			    var regex = /^[0-9a-zA-Z]|\-+$/;
			    if (!regex.test(key)) {
			        theEvent.returnValue = false;
			        if (theEvent.preventDefault) theEvent.preventDefault();
			    }
			}

			function validateAlphaComma(evt) {
			    var theEvent = evt || window.event;
			    var key = theEvent.keyCode || theEvent.which;
			    key = String.fromCharCode(key);
			    var regex = /[a-zA-Z ]|\,/;
			    if (!regex.test(key)) {
			        theEvent.returnValue = false;
			        if (theEvent.preventDefault) theEvent.preventDefault();
			    }
			}


			function validateFile() {

			    var fi = document.getElementById('filUpload');
			    alert(fi.size);

			    var strFileName = document.getElementById("filUpload").value;
			    var strExtName = strFileName.substring(strFileName.lastIndexOf('.')).toLowerCase();
			    // alert(strFileName);
			    //  alert(strExtName);

			    var varFlag = CheckFileExtension();
			    if (varFlag == false) {
			        document.getElementById("filUpload").focus();
			        return false;
			    }


			    var objFSO = new ActiveXObject("Scripting.FileSystemObject");
			    var e = objFSO.getFile(strFileName);
			    var fileSize = e.size;
			    //file size limit for 10mb
			    //  alert(fileSize);
			    if (fileSize > 1048576) {
			        alert("Your image size is more than 1 MB.");
			        return false;
			    }
			    else if (fileSize = 0) {
			        alert("Your image size is less than 1 KB.");
			        return false;
			    }
			    else
			        return true;
			}


			function CheckPassword() {

			    var strText = document.getElementById("txtPassword").value;

			    var count = 0;
                
			    if (strText.length < 6) {
			        count += 1;
			    }

			    if (count > 0) {
			        alert("Please enter valid password.");
			        document.getElementById("txtPassword").focus();
			        document.getElementById("txtPassword").style.backgroundColor = 'yellow';
			        return false;
			    }
			    else {
			        document.getElementById("txtPassword").style.backgroundColor = 'white';
			    }
			}

		    //Changing College level on selection of Qualification Type.
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
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";					
					document.getElementById("divHighestEducationObtainedFrom").textContent = "College Name:*";
					document.getElementById("divHighestEducationYear").style.textAlign = "left";
					document.getElementById("divHighestEducationYear").innerText="Year of Graduation"	
					document.getElementById("divHighestEducationYear").textContent="Year of Graduation"	
						
					document.getElementById("dvPGSpecialization").style.display="none";			
				}
				else if (varCheckOther == 'post graduate')
				{
					document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
					document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
					document.getElementById("divHighestEducationObtainedFrom").textContent = "College Name:*";
					document.getElementById("divHighestEducationYear").style.textAlign = "left";
					document.getElementById("divHighestEducationYear").innerText="Year of Post Graduation"
					document.getElementById("divHighestEducationYear").textContent="Year of Post Graduation"
			
					document.getElementById("dvPGSpecialization").style.display="";	
				}
				else
				{
					
				
					document.getElementById("dvPGSpecialization").style.display="none";	
				}
		    }	
		    
			//Validating User INPUT
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

	            strText = document.getElementById("filUpload").value;

	            if (Trim(strText) == "") {
	                if ($('#rowUpload').is(':visible')) {
	                    alert('Please select a photograph to upload');
	                    document.getElementById("filUpload").focus();
	                    document.getElementById("filUpload").style.backgroundColor = 'yellow';
	                    return false;
	                }
	            }
	            else {
	                document.getElementById("filUpload").style.backgroundColor = 'white';
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
				
				
				//validate 12th passing year			
				
				strText = document.getElementById("ddlPassingYear12th").value;  
									
				if (strText == 0)
				{
					alert("Please select 12Th Passing year");
					document.getElementById("ddlPassingYear12th").focus();
					document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
	            }

                if (document.getElementById("ddlYear").value != '0' && document.getElementById("ddlPassingYear12th").value != '0') 
                {
                    if (document.getElementById("ddlPassingYear12th").value - document.getElementById("ddlYear").value < 16)
                    {
                        alert("Minimum 16 years of difference required between and year of birth and year of passing 12th");
				        document.getElementById("ddlPassingYear12th").focus();
				        document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
				        document.getElementById("ddlYear").style.backgroundColor = 'yellow';
				        return false;
				    }
				}

                /////////////
				if (document.getElementById("ddlGraduationYear").value != '0' && document.getElementById("ddlPassingYear12th").value != '0')
                {
				    //alert(document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value);
                    if (document.getElementById("ddlQualification").value == '1') 
                    {

				        if (document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value < 3) 
                        {
				            alert("Minimum 3 years of difference required between year of passing 12th and year of passing graduation");
				            document.getElementById("ddlPassingYear12th").focus();
				            document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
				            document.getElementById("ddlGraduationYear").style.backgroundColor = 'yellow';
				            return false;
				        }
				        else
                        {
				            document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
				            document.getElementById("ddlGraduationYear").style.backgroundColor = 'white';
				        }

				    }
                }

				 if (document.getElementById("ddlQualification").value == '3') 
                 {
				    if (document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value < 5) 
                    {
				        alert("Minimum 5 years of difference required between year of passing 12th and year of passing post graduation");
				        document.getElementById("ddlPassingYear12th").focus();
				        document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
				        document.getElementById("ddlGraduationYear").style.backgroundColor = 'yellow';
				        return false;
				    }
				    else 
                    {
				        document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
				        document.getElementById("ddlGraduationYear").style.backgroundColor = 'white';
				    }
				 }
				

				/////////////
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
				//var varCentreCheck = <%=Convert.ToInt32(Session["StateId"])%>;  				
				//if ((strText) == 0 && varCentreCheck != 1)//&& varCentreCheck != 6)
				if ((strText) == 0 )
				{
					//if ((strText) == 0 && varCentreCheck != 6)
					//{
						alert("Please select test centre");
						document.getElementById("ddlTestCentre").focus();
						document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
						return false;
					//}
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

	            if (document.getElementById("chkAuthorization").checked == false) {
	                alert("Please accept the Authorization");
	                document.getElementById("chkAuthorization").focus();
	                document.getElementById("chkAuthorization").style.backgroundColor = 'yellow';
	                return false;
	            }
	            else {
	                document.getElementById("chkAuthorization").style.backgroundColor = 'white';
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
				
				if(!window.confirm("Are you sure you want to submit the details?"))
					{
						return false;
					}
				return true;
			}		
					var maxWidth=100;
  // height to resize large images to
			var maxHeight=100;
  // valid file types
		var fileTypes=["bmp","gif","png","jpg","jpeg"];
  // the id of the preview image tag
		var outImage="previewField";
  // what to display when the image is not valid
		var defaultPic="spacer.gif";
		function preview(what){
  var source=what.value;
  document.getElementById("hdImagepath").value = what.value;
  var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
  for (var i=0; i<fileTypes.length; i++) if (fileTypes[i]==ext) break;
  
}
var globalPic;
function applyChanges(){
  var field=document.getElementById(outImage);
  var x=parseInt(globalPic.width);
  var y=parseInt(globalPic.height);
  if (x>maxWidth) {
    y*=maxWidth/x;
    x=maxWidth;
  }
  if (y>maxHeight) {
    x*=maxHeight/y;
    y=maxHeight;
  }
  field.style.display=(x<1 || y<1)?"none":"";
  field.src = aventail.translate_url(globalPic.src);
  field.width=x;
  field.height=y;
}
		</script>
	    <style type="text/css">
            .style1
            {
                height: 23px;
            }
            .style2
            {
                font-size: 11px;
                color: #a11d21;
                font-family: Verdana;
                text-decoration: none;
                height: 23px;
            }
            .style3
            {
                width: 528px;
            }
            .style4
            {
                height: 23px;
                width: 528px;
            }
            .style5
            {
                font-size: 11px;
                color: #a11d21;
                font-family: Verdana;
                text-decoration: none;
                width: 528px;
            }
            .style6
            {
                width: 100%;
            }
        </style>
	</HEAD>
	<body>
		<form onkeypress="avoidEnter();" id="frmEditRegistration" method="post" runat="server">
		
                                  <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Edit Regsitration Details 
                        <asp:label id="lblStateName" Runat="server" Visible="False"></asp:label></h2>

									
                                    <table id="Table4" border="0" cellspacing="0" cellpadding="3" width="100%">
										<TR>
											<TD class="small_maroon" width="43%" colSpan="3">All (*) marked are mandatory 
												fields&nbsp;&nbsp;&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD class="lightblue_bg" colSpan="3"><STRONG>PERSONAL DETAILS</STRONG></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD width="43%">First Name:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtFirstName" MaxLength="30" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon" width="2%"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Middle Name:
											</TD>
											<TD class="style3">
												<asp:textbox id="txtMiddleName" MaxLength="30" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Last Name:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtLastName" MaxLength="30" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Date of Birth:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlDay" Runat="server" CssClass="txtarea">
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
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlMonth" Runat="server" CssClass="txtarea">
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
												</asp:dropdownlist>
												<asp:dropdownlist id="ddlYear" Runat="server" CssClass="txtarea">													
												</asp:dropdownlist></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Gender:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:radiobuttonlist id="rblGender" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal">
													<asp:ListItem Value="M">Male</asp:ListItem>
													<asp:ListItem Value="F">Female</asp:ListItem>
												</asp:radiobuttonlist></TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Residential Address:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtResidentialAddress" runat="server" MaxLength="400" CssClass="txtarea" Columns="1"
													Rows="4" TextMode="MultiLine" Width="300px"></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>City:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtCity" MaxLength="100" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Pincode:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtPinCode" MaxLength="6" Runat="server" CssClass="txtbox"  onkeypress='validateNum(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Phone Number (Landline):<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3"><FONT class="rblbox">(STD Code)</FONT>
												<asp:textbox id="txtSTDCode" MaxLength="6" Runat="server" CssClass="txtbox" Width="50px"  onkeypress='validateNum(event)'></asp:textbox>&nbsp;
												<asp:textbox id="txtPhoneNumber" MaxLength="10" Runat="server" CssClass="txtbox"  onkeypress='validateNum(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Phone Number (Cellphone):
											</TD>
											<TD class="style3">
												<asp:textbox id="txtCellPhone" MaxLength="15" Runat="server" CssClass="txtbox"  onkeypress='validateNum(event)'></asp:textbox></TD>
											<TD class="small_maroon">&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left" id="rowPhoto">
											<TD>Photograph:
											</TD>
											<TD class="style3" valign="bottom">
												<INPUT style="Z-INDEX: 0" id="hdImage" value="0" type="hidden" name="hdImage" runat="server"> 
                                                <table cellpadding="0" cellspacing="0" class="style6">
                                                    <tr>
                                                        <td Width="100px">
												<asp:image id="imgUploadPhotograph" Height="100px" Runat="server" Width="100px" ImageUrl="Images/defaultphoto.jpg"></asp:image>
                                                        </td>
                                                        <td valign="bottom">
                                                            &nbsp;<INPUT id="btnFileUpload" class="btn2" onclick="BlankFileUpload();" value="Remove" type="button"></td>
                                                        <td valign="bottom"  class="small_maroon" width="100%">
                                                            &nbsp;
                                                            Click on remove to change the current photograph</td>
                                                    </tr>
                                                </table>
&nbsp;</TD>
											<TD class="small_maroon">&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left" id="rowUpload" style="display:none">
											<TD>Upload Photograph:
											<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3"><INPUT id="filUpload" size="40" class="txtbox" onchange="preview(this)" type="file" name="filUpload"
													runat="server">&nbsp;
												<!--	<asp:button id="btnRemoveImage"  class="main_black" runat="server" CssClass="btn2" Text="Remove"></asp:button> -->
												<asp:literal id="ltrlErrorReview" runat="server"></asp:literal></TD>
											<TD class="small_maroon">&nbsp;</TD>
										</TR>
										<TR class="main_black" id="rowUploadMsg" style="display:none">
											<TD class="small_maroon" colSpan="3">* To upload your photograph, click on 'browse' 
												button and select photograph from the computer where you have saved the 
												photograph.&nbsp; The photograph size must not be greater than 1 MB It must be in .jpg, .jpeg or .gif format only.</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Email Id:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtEmailID" MaxLength="30" Runat="server" CssClass="txtbox"></asp:textbox></TD>
											<TD class="small_maroon">&nbsp;</TD>
										</TR>
                                        <TR class="main_black">
											<TD class="small_maroon" colSpan="3">* Please ensure you are entering a valid e-mail ID.</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Mother's Full Name:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtMothersName" MaxLength="50" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Father's Full Name:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtFathersName" MaxLength="50" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Annual Household Income:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlHouseholdIncome" Runat="server" CssClass="txtarea"></asp:dropdownlist></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>You belong to:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:radiobuttonlist id="rblYouBelongTo" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal"
													Width="120px">
													<asp:ListItem Value="Village">Village</asp:ListItem>
													<asp:ListItem Value="City">City</asp:ListItem>
												</asp:radiobuttonlist></TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Highest Educational Qualification:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<P>
													<asp:dropdownlist id="ddlQualification" Runat="server" CssClass="txtarea" Width="176px"></asp:dropdownlist><INPUT id="hdQualification" value="0" type="hidden" name="hdQualificationDetails" runat="server"><INPUT id="hdImagepath" type="hidden" name="hdImagepath" runat="server"><INPUT id="hdpassword" type="hidden" name="hdpassword" runat="server"><INPUT id="hdconfpassword" type="hidden" name="hdconfpassword" runat="server"></P>
											</TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" id="dvPostGraduate" align="left">
											<TD id="divHighestEducationObtainedFrom" runat="server">
												<asp:label id="lblCollege" runat="server"></asp:label><FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtHighestEducationObtainedFrom" MaxLength="50" Runat="server" CssClass="txtbox"></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR id="dvHighEduYear" class="main_black" vAlign="top" align="left">
											<TD id="divHighestEducationYear" align="left" runat="server" class="style1"></TD>
											<TD id="TdYG1" align="left" class="style4">
												<asp:dropdownlist id="ddlGraduationYear" Runat="server" CssClass="txtarea" Width="88px" BackColor="White">													
												</asp:dropdownlist></TD>
											<TD class="style2"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left" runat="server" id="dvPGSpecialization">
											<TD id="Td3">Specialization in PG:</TD>
											<TD align="left" class="style3">
												<asp:textbox id="txtPGSpecialization" MaxLength="50" Runat="server" CssClass="txtbox" BackColor="White"></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR id="dvPostGraduate2" class="main_black" vAlign="top" align="left">
											<TD>College Address:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtCollegeAddress" runat="server" MaxLength="100" CssClass="txtarea" Columns="30"
													Rows="4" TextMode="MultiLine" Width="250px"></asp:textbox></TD>
											<TD class="small_black"></TD>
										</TR>
										<TR class="main_black" id="dvPostGraduate1" vAlign="top">
											<TD>College City:<FONT class="small_maroon">*</FONT></TD>
											<TD align="left" class="style3">
												<asp:textbox id="txtHighestEducationCity" MaxLength="10" Runat="server" CssClass="txtbox"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
											<TD class="small_maroon" align="left"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Qualification Details:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlQualificationDetails" Runat="server" CssClass="txtarea" Width="104px"></asp:dropdownlist><INPUT style="VISIBILITY: visible" id="txtOtherQualification" class="txtarea" onfocus="this.value = ''; return true;"
													value="Specify other" maxLength="50" name="txtOtherQualification" Runat="server">
												<INPUT id="hdQualificationDetails" value="0" type="hidden" name="hdQualificationDetails"
													runat="server"> <INPUT id="hdQualificationDetailsName" value="0" type="hidden" name="hdQualificationDetailsName"
													runat="server">
											</TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Aggregate Percentage Scored:<FONT class="small_maroon">*<br />
                                                </FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtPercentageScored" MaxLength="3" Runat="server" CssClass="txtbox" Width="70px" onkeypress='validatePercent(event)'></asp:textbox>%
											</TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Medium of Instruction upto 10th:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlMediumOfInstruction" Runat="server" CssClass="txtarea">
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
												</asp:dropdownlist></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Medium of Instruction in 12th:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlMediumOfInstructionIn12Th" Runat="server" CssClass="txtarea">
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
												</asp:dropdownlist></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Year of passing 12th:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlPassingYear12th" Runat="server" CssClass="txtarea" Width="88px" BackColor="White">													
												</asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>&nbsp;</TD>
											<TD class="style5">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD class="lightblue_bg" colSpan="3"><STRONG>PROFESSIONAL DETAILS</STRONG></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Employment Status:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:radiobuttonlist id="rblEmploymentStatus" Runat="server" CssClass="rblbox" RepeatColumns="2" RepeatDirection="Horizontal"
													Width="176px">
													<asp:ListItem Value="Employed">Employed</asp:ListItem>
													<asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
												</asp:radiobuttonlist></TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Current Location:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style5">
												<asp:textbox id="txtCurrentLocation" MaxLength="50" Runat="server" CssClass="txtbox" BackColor="White" onkeypress='validateAlpha(event)'></asp:textbox>(city 
												where you presently stay)
											</TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Language Skills:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style5">
												<asp:textbox id="txtLanguageSkills" MaxLength="50" Runat="server" CssClass="txtbox" BackColor="White" onkeypress='validateAlphaComma(event)'></asp:textbox>(language 
												that you are proficient in)
											</TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Willing to work out of hometown:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:radiobuttonlist id="rblWillingToWorkOutOfHomeTown" Runat="server" CssClass="rblbox" RepeatColumns="2"
													RepeatDirection="Horizontal" Width="80px">
													<asp:ListItem Value="Yes">Yes</asp:ListItem>
													<asp:ListItem Value="No">No</asp:ListItem>
												</asp:radiobuttonlist></TD>
											<TD class="small_maroon" vAlign="middle"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Do you have a passport?:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlPassport" Runat="server" CssClass="txtarea" BackColor="White">
													<asp:ListItem Value="0">Select</asp:ListItem>
													<asp:ListItem Value="Yes">Yes</asp:ListItem>
													<asp:ListItem Value="No">No</asp:ListItem>
												</asp:dropdownlist>&nbsp;&nbsp;
											</TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR id="dvPassport1" class="main_black" vAlign="top" align="left" runat="server">
											<TD>Fill in the passport no:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:textbox id="txtPassport" MaxLength="50" Runat="server" CssClass="txtbox" BackColor="White"  onkeypress='validatePassport(event)'></asp:textbox><!--<input id="Hidden1" type="hidden" value="0" name="hdPassport" runat="server">--></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>&nbsp;</TD>
											<TD class="style5">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD class="lightblue_bg" colSpan="3"><STRONG>NAC TEST DETAILS</STRONG></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Test City:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<DIV id="divDropTestCity" runat="server">
													<asp:dropdownlist id="ddlTestCity" Runat="server" CssClass="txtarea" AutoPostBack="False" BackColor="White"></asp:dropdownlist><SPAN class="small_maroon"><I>(please 
															select city) </I><SPAN>
												</DIV>
												<DIV id="divLblTestCity" runat="server">
													<asp:label id="lblTestCity" Runat="server"></asp:label></DIV>
												<FONT class="small_maroon"></FONT></SPAN></SPAN></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Test Centre:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<DIV id="divDropTestCentre" runat="server">
													<asp:dropdownlist id="ddlTestCentre" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist><SPAN class="small_maroon"><I>(please 
															select test centre)</I><SPAN></DIV>
												<DIV id="divLblTestCentre" runat="server">
													<asp:label id="lblTestCentre" Runat="server"></asp:label></DIV>
												<FONT class="small_maroon"></FONT><INPUT id="hdTestCentre" value="0" type="hidden" name="hdTestCentre" runat="server"><INPUT id="hdTestCentreName" type="hidden" name="hdTestCentreName" runat="server">
												</SPAN></SPAN></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>&nbsp;</TD>
											<TD class="style5">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD class="lightblue_bg" colSpan="3"><STRONG>SECURITY </STRONG>
											</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Password:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style5">
												<asp:textbox id="txtPassword" MaxLength="12" Runat="server" CssClass="txtbox" 
                                                    TextMode="Password" onkeypress="return RemoveJunk(event)" onblur="CheckPassword(this)"></asp:textbox>&nbsp;<BR>
													
													Password should be 6 - 12 characters.
                                                    <br />
                                                    Password must contain only alphabets and numerics only.&nbsp; 
											</TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Confirm Password:<FONT class="small_maroon">*</FONT>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtConfirmPassword" MaxLength="12" Runat="server" 
                                                    CssClass="txtbox" TextMode="Password"></asp:textbox></TD>
											<TD class="small_maroon"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 25px" class="small_maroon" colSpan="3">* Please note down this 
												password - You should use the same to view your NAC score card after the test</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="left">
											<TD>Select a photo-Id document:<FONT class="small_maroon">*</FONT></TD>
											<TD class="style3">
												<asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" CssClass="txtarea">
													<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
													<asp:ListItem Value="Driving License">Driving License</asp:ListItem>
													<asp:ListItem Value="Passport">Passport</asp:ListItem>
													<asp:ListItem Value="PAN">PAN</asp:ListItem>
													<asp:ListItem Value="Voter ID">Voter ID</asp:ListItem>
													<asp:ListItem Value="College I-Card">College I-Card</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD class="small_maroon"></TD>
										</TR>
										
										<tr class="main_black" vAlign="top" align="left">
											<TD>Photo-Id Document Number:<FONT class="small_maroon">*</FONT>
												<BR>
											</TD>
											<TD class="style3">
												<asp:textbox id="txtPhotoIdNumber" MaxLength="100" Runat="server" CssClass="txtbox"></asp:textbox></TD>
											<TD class="small_maroon"></TD>
                                            </tr> 
                                            <TR class="main_black" vAlign="top" align="left">
												<TD>&nbsp;</TD>
												<TD class="small_maroon">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="lightblue_bg" colSpan="3"><STRONG>AUTHORIZATION</STRONG>
												</TD>
											</TR>

                                            <TR class="main_black" vAlign="top" align="left">
												<TD style="HEIGHT: 22px" colSpan="3"><FONT class="small_maroon">*</FONT>
													<asp:checkbox id="chkAuthorization" runat="server" Text=""></asp:checkbox>&nbsp;<SPAN style="FONT-SIZE: 12px; COLOR: #7f7f7f; FONT-FAMILY:  Arial,Verdana, Helvetica, sans-serif">
														I authorize NASSCOM to share all my details, as indicated in the Registration 
														Form, and my test scores with prospective employers who are interested to look at my profile for recruitment purposes.</SPAN>
												</TD>
											</TR>

										<TR class="main_black" vAlign="top" align="left">
											<TD>&nbsp;</TD>
											<TD class="style5">&nbsp;
												<asp:label id="lblMessage" Runat="server" ForeColor="Red" Font-Bold="True" Visible="False"></asp:label></TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR class="main_black" vAlign="top" align="center">
											<TD colSpan="3">
												<asp:button id="btnSave" runat="server" Text="Submit" onclick="btnSave_Click"></asp:button>&nbsp;</TD>
										</TR>
									</TABLE>
								   </div>
            </div>           

               <div class="footer">  <img src="Images/footer2014.gif" /></div>
            </div>
							
		</form>
	</body>
</HTML>
