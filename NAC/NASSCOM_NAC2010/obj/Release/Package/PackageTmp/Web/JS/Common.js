//-- This function checks whether given date is valid or not
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
		//strError = "Date is not in a valid format.\n mm/dd/yy or mm/dd/yyyy"; // -1
		strError = "Date is not in a valid format.\n dd/mm/yyyy"; // -1
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
	
	return strError;  // date is valid
}
	
//-- This function returns the date that is n days from any date object.
function whenIs(anyDate, n)
{
   //-- Returns the date that is n days from any date object.
   var newDate = new Date()
   newDate.setTime(anyDate.getTime()+(n*1000*60*60*24))
   return newDate
}
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

//  This function checks whether given EmailId is valid or not
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
  if (domArr[domArr.length-1].length<2 || 
    //10 Jun,2004 - Sandeep(MTI) - The domain can be 4 letter after the "." (initially it was 3)
    domArr[domArr.length-1].length>4) 
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

function TrimAll(sString) 
{
while (sString.substring(0,1) == ' ')
{
sString = sString.substring(1, sString.length);
}
while (sString.substring(sString.length-1, sString.length) == ' ')
{
sString = sString.substring(0,sString.length-1);
}
return sString;
}

//  This function will check whether given string is numeric or not
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

//  This function will check whether given string is alphabet or not
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

// Use this function only in conditional expression just to check whether string is empty or not
function Trim(Untrimmed) 
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

// This function checks whether given string contains '<' character
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

// This function checks whether given string contains '>' character
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

// This function returns Expiry date for a given date 
// Expiry date : Given date + 1 year
function GetExpiryDate(strDate)
{
	var arrStr ;								
	arrStr = strDate.split("/");
	if (arrStr[1] == '2' || arrStr[1] == '02')
	{
		if (arrStr[0] == "29")
			arrStr[0] = "28"
	}
	arrStr[2] = parseInt(arrStr[2]) + 1 ;
	strDate = arrStr[0] + "/" + arrStr[1] + "/" + arrStr[2] ;
	return strDate ;
}

function CurrencyFormat(checkStr)
{
	
	var expPattern1 = "^[0-9]{1,5}[\.]{0,1}[0-9]{0,2}$" ;
	var expPattern2 = "^[0-9]{6,7}$" ;
	var expPattern3 = "^[0-9]{1,5}[\.]{1}$" ;

	var result1 = checkStr.match(expPattern1) ;
	var result2 = checkStr.match(expPattern2) ;
	var result3 = checkStr.match(expPattern3) ;

	if (result1 == null)
	{
		return false ;
	}
	if (result2 == null && result3 == null)
	{
		return true ;
	}
	else
	{
		return false ;
	}
}
	function CheckAllOptions()
	{
		var strID;
		var frm = window.document.forms("EasyMerge");

		for(i=0;i<frm.elements.length;i++)
		{
			strID=frm.elements(i).name;
			if(strID.search("chkResult")>=0) 
			{
			    if(frm.elements(i).checked)
				{
					// do nothing , checkbox is already checked
				}
				else
				{
					frm.elements(i).checked=true;
				}
			}					
		}
		
		return false;
	}
	
	// clears the selection of check boxes
	function ClearAllOptions()
	{
		var strID;
		var frm = window.document.forms("EasyMerge");

		for(i=0;i<frm.elements.length;i++)
		{
			strID=frm.elements(i).name;
			if(strID.search("chkResult")>=0) 
			{
			    if(frm.elements(i).checked)
				{
					frm.elements(i).checked=false;
				}
			}					
		}
		//document.all("txtHidden").value = 2 ;
		return false;
	}

//For 2 place of decimal entry
	function extractNumber(obj, decimalPlaces, allowNegative)
{
      var temp = obj;
      // avoid changing things if already formatted correctly
      var reg0Str = '[0-9]*';
      if (decimalPlaces > 0) {
            reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
      } else if (decimalPlaces < 0) {
            reg0Str += '\\.?[0-9]*';
      }
      reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
      reg0Str = reg0Str + '$';
      var reg0 = new RegExp(reg0Str);
      if (reg0.test(temp))
      { 
        return true;
      }
      else
      {
        return false;
      }
}

function Count(text,long)
{
	var maxlength = new Number(long); // Change number to your max length.
	if (text.value.length > maxlength){
		text.value = text.value.substring(0,maxlength);
		alert("Only " + long + " characters are allowed");
	}
}