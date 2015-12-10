//***********************************************************
//This function checks whether given date is valid or not
//***********************************************************
function isValidDate(dateStr) 
{
	// Checks for the following valid date format:
	// DD-MM-YYYY
	// Also separates date into month, day, and year variables
		
	var strError = "";
	var today ,tempDate;
	var daysMinus=-7;
	today=new Date();
	tempDate=new Date();
	// To require a 4 digit year entry
	var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{2,4})$/;
	var matchArray = dateStr.match(datePat); 
	if (matchArray == null) 
	{
		strError = "Date is not in a valid format.\n mm/dd/yy or mm/dd/yyyy"; // -1		
		return strError;
	}
	month = matchArray[3]; // parse date into variables
	day = matchArray[1];
	year = matchArray[4];
	if (month < 1 || month > 12) 
	{ // check month range
		strError = "Month must be between 1 and 12."; //-2
		return strError;
	}
	if (day < 1 || day > 31) 
	{
		strError = "Day must be between 1 and 31."; //-3
		return strError;
	}
	if ((month==4 || month==6 || month==9 || month==11) && day==31) 
	{
		strError = "Month "+month+" doesn't have 31 days!"; //-4
		return strError;
	}
	if (month == 2) 
	{ // check for february 29th
		var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
		if (day>29 || (day==29 && !isleap)) 
		{
			strError = "February " + year + " doesn't have " + day + " days!"; //-5
			return strError;
		}
	}
	if (year < 1753) 
	{
			strError = "Year is not valid!"; //-5
			return strError;
	}
	dateStr=new Date(dateStr);
	
	tempDate=whenIs(today,daysMinus);
	
	return strError;
}

//**********************************************************************
//-- This function returns the date that is n days from any date object.
//**********************************************************************
function whenIs(anyDate, n)
{  
   var newDate = new Date()
   newDate.setTime(anyDate.getTime()+(n*1000*60*60*24))
   return newDate
}

//**********************************************************************
// function to remove any trailing spaces in a string 
//**********************************************************************
function lTrim(sStr)
{
			var sAlpha;
			var sRetStr = sStr;
			if (sStr)
				for (sAlpha = sRetStr.charAt(0); sAlpha == " "; sRetStr = sRetStr.substr(1,sRetStr.length - 1), sAlpha = sRetStr.charAt(0));
					return sRetStr; 
}
//**********************************************************************
// function to remove any trailing spaces in a string
//**********************************************************************				
function rTrim(sStr)
{
		var sAlpha;
		var sRetStr = sStr;
		if (sStr)
		for (sAlpha=sRetStr.charAt(sRetStr.length - 1); sAlpha == " "; sRetStr = sRetStr.substr(0,sRetStr.length - 1), sAlpha = sRetStr.charAt(sRetStr.length - 1));
			return sRetStr; 
}

//**********************************************************************
// function to remove all leading and trailing spaces in a string
//**********************************************************************				
function allTrim(sStr)
{
		return rTrim(lTrim(sStr));
}

//**********************************************************************
//  This function checks whether given EmailId is valid or not
//**********************************************************************
function emailCheck (emailStr) 
{
  var emailPat=/^(.+)@(.+)$/
  var specialChars="\\(\\)<>@,;:\\\\\\\"\\.\\[\\]!#$%^&*+=|\\\{}'?/~`"
  var validChars="\[^\\s" + specialChars + "\]"
  var quotedUser="(\"[^\"]*\")"

  var ipDomainPat=/^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/
  var atom=validChars + '+'
  var word="(" + atom + "|" + quotedUser + ")"

  var userPat=new RegExp("^" + word + "(\\." + word + ")*$")

  var domainPat=new RegExp("^" + atom + "(\\." + atom +")*$")

  var matchArray=emailStr.match(emailPat)
	if (matchArray==null) 
	{
		return false
	}
  var user=matchArray[1]
  var domain=matchArray[2]

	if (user.match(userPat)==null) 
	{		
		// user is not valid
		//alert("The username doesn't seem to be valid.")
		//field.focus();   
		return false
	}
  var IPArray=domain.match(ipDomainPat)
	if (IPArray!=null) 
	{
		for (var i=1;i<=4;i++) 
		{
			if (IPArray[i]>255) 
			{
		//        alert("Destination IP address is invalid!")
		//        field.focus();   
				return false
			}
		}
		return true
	}
  var domainArray=domain.match(domainPat)
	if (domainArray==null) 
	{
		//alert("The domain name doesn't seem to be valid.")
		//field.focus();   
		return false
	}
  var atomPat=new RegExp(atom,"g") 
  var domArr=domain.match(atomPat)
  var len=domArr.length
	if (domArr[domArr.length-1].length<2 || domArr[domArr.length-1].length>4) 
	{    
		//alert("The address must end in a three-letter domain, or two lettercountry.")
		//field.focus();   
		return false
	}
	if (len<2) 
	{
		var errStr="This address is missing a hostname!"
		//alert(errStr)
		//field.focus();   
		return false
	}
  return true;
}

//**********************************************************************
//check whether string is empty(Null) or not
//**********************************************************************
function IsNull(Untrimmed) 
{
	var Trimmed = ''
	for (var i = 0; i < Untrimmed.length; i++) 
	{
		if (Untrimmed.charCodeAt(i)!=32) 
			{
				Trimmed +=Untrimmed[i]
			}
	}
	return Trimmed
} 

//**********************************************************************
//  This function will check whether given string is numeric or not
//**********************************************************************
function IsNumeric(checkStr)
{
	var checkOK1 = "0123456789";
	var allValid = true;
	var allNum = "";
	
	for (i = 0; i < checkStr.length; i++)
		{
			ch = checkStr.charAt(i);
			for (j = 0; j < checkOK1.length; j++)
				{
					if (ch == checkOK1.charAt(j))
						break;
				}
			if (j == checkOK1.length)
				{
					allValid = false;
					break;
				}
			allNum += ch;
		}		

	return allValid ;		
}

//**********************************************************************
//  This function will check whether given string is alphabet or not
//**********************************************************************
function IsAlphabet(checkStr)
{
	var checkOK1 = "abcdefghijklmnopqrstuvwxyz ";
	var allValid = true;
	var allNum = "";
	
	for (i = 0; i < checkStr.length; i++)
		{
			ch = checkStr.charAt(i).toLowerCase();;
			for (j = 0; j < checkOK1.length; j++)
				{
					if (ch == checkOK1.charAt(j))
						break;
				}
			if (j == checkOK1.length)
				{
					allValid = false;
					break;
				}
			allNum += ch;
		}		

	return allValid ;		
}

//**********************************************************************
// This function checks whether given string contains '<' character
//**********************************************************************
function IsAngularBracket(checkStr)
{
	for (i = 0; i < checkStr.length; i++)
		{
			ch = checkStr.charAt(i);
			if (ch == "<")
				return true ;
		}		

	return false ;		
}

//**********************************************************************
// This function checks whether given string contains '>' character
//**********************************************************************
function IsAngularBracketRight(checkStr)
{
	for (i = 0; i < checkStr.length; i++)
		{
			ch = checkStr.charAt(i);
			if (ch == ">")
				return true ;
		}		

	return false ;		
}

//**********************************************************************
// This function checks whether given string contains special character
//**********************************************************************
function IsSpecialChar(checkStr)
{
	var iChars = "!@#$%^&amp;*()+=-[]\';,./{}|\":&lt;&gt;?";
	for (var i = 0; i < checkStr; i++) 
	{
  		if (iChars.indexOf(checkStr.charAt(i)) != -1) 
  		{
  			//document.write("Containts special characters.");
  			return false;
  		}
	 }	
}


