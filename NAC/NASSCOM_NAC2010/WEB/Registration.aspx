<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="nac_footer" Src="Controls/nac_footer.ascx" %>
<%@ Page EnableEventValidation="false" language="c#" Codebehind="Registration.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.Registration" %>
<%@ Register TagPrefix="uc1" TagName="nac_header" Src="Controls/nac_header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Registration</title>

 		<link href="Stylesheet/nasscom.css" type="text/css" rel="stylesheet" />
   
		<SCRIPT language="javascript" src="js/common.js"></SCRIPT>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<script language="JavaScript" type="text/JavaScript">

		    history.forward(1);

		    function avoidEnter() {
		        if (window.event.keyCode == 13) {
		            window.event.cancelBubble = true;
		            window.event.returnValue = false;
		        }
		    }

		    // If the element's string matches the regular expression it is numbers and letters
		    function fillOnlyAlphanumericValue(ev) {
		        var varControlId;
		        var varValue;
		        varControlId = ev.name;
		        varValue = document.getElementById(varControlId).value;
		        var alphaExp = /^[0-9a-zA-Z]+$/;
		        if (ev.value == "") {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		            return true;
		        }

		        else if (ev.value.match(alphaExp)) {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		            return true;
		        }
		        else {
		            alert("Please enter a valid passport number.");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		    }



		    function fillOnlyPercentageValue(eV) {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		        if (!extractNumber(varValue, 2, false)) {
		            alert("Please enter a valid Percentage.");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else if ((varValue > 100 || varValue < 0)) {
		            alert("Please enter a valid value");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		        }

		        return true;
		    }

		    function CheckConfirmPassword() {
		        var confirmText = document.getElementById("txtConfirmPassword").value;

		        if (document.getElementById("txtConfirmPassword").value != document.getElementById("txtPassword").value) {
		            alert("Confirm password doesn't match with the password");
		            document.getElementById("txtPassword").focus();
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
		            document.getElementById("txtPassword").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
		            document.getElementById("txtPassword").style.backgroundColor = 'white';
		        }
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


		    function ValidateMobile(ev) {
		        var varControlId;
		        var varValue;
		        varControlId = ev.name;
		        varValue = document.getElementById(varControlId).value;
		        if (varValue.length != 10 && Trim(varValue) != "") {
		            alert("Please enter 10 digit Mobile No.");
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		        }
		    }

		    function BlankFileUpload() {

		        var oldElement = document.getElementById("filUpload");
		        var newElement = document.createElement("filUpload");
		        newElement.innerHTML = "<input name='filUpload' id='filUpload' type='file' class='btn2' size='40'>";
		        oldElement.parentNode.replaceChild(newElement, oldElement);
		        }

		    function SamePasswordAlert() {
		        alert("This Password already exists.\nPlease change it!.")
		    }

		    function fillOnlyAlphabetValue(eV) {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       

		        if (!IsAlphabet(varValue)) {

		            alert("Please enter alphabet");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		            return true;
		        }
		    }

		    function ValidateEmailAddress(eV) {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       
		        if ((!(emailCheck(varValue))) && Trim(varValue) != "") {
		            alert("Please enter valid email address");
		            document.getElementById("txtEmailID").focus();
		            document.getElementById("txtEmailID").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtEmailID").style.backgroundColor = 'white';
		        }

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


		    function fillOnlyNumericValue(eV) {
		        var varControlId;
		        var varValue;
		        var varSubString;
		        varControlId = eV.name;
		        varValue = document.getElementById(varControlId).value;
		       

		        if (!IsNumeric(varValue)) {

		            alert("Please enter numeric data");
		            document.getElementById(varControlId).value = "";
		            document.getElementById(varControlId).focus();
		            document.getElementById(varControlId).style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById(varControlId).style.backgroundColor = 'white';
		        }
		    }


		    function CheckFileExtension() {
		        var ext = document.getElementById("filUpload").value;
		        var extFour;
		        var bFileFormat = false;

		        //document.getElementById("btnFileUpload").value = document.getElementById("filUpload").value;
		        ext = ext.substring(ext.length - 3, ext.length);
		        ext = ext.toLowerCase();
		        extFour = ext.substring(ext.length - 4, ext.length);
		        extFour = extFour.toLowerCase();
		        if ((ext == 'jpg') || (ext == 'peg') || (ext == 'gif')) {
		            bFileFormat = true;
		        }

		        if (bFileFormat == false) {
		            alert('You selected a .' + ext + ' file; please select a .jpg/.jpeg/.gif file instead!');
		            document.getElementById("filUpload").value = "";
		            return false;
		        }
		        else
		            return true;
		    }

		    function HideText() {
		        var strOtherQualification;
		        strOtherQualification = document.getElementById("txtOtherQualification").value;
		        strOtherQualification = strOtherQualification.toLowerCase();
		        if (Trim(strOtherQualification) == 'specify other') {
		            document.Form1.txtOtherQualification.value = "";
		        }
		    }

		    //Changing College level on selection of Qualification Type.
		    function ChangeCollegeLabel() {
		        //document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
		        var varCheckOther;
		        var box = document.getElementById("ddlQualification");
		        var varOption = document.createElement('OPTION');
		        varOption = box.options[box.selectedIndex];
		        varCheckOther = varOption.text;
		        varCheckOther = varCheckOther.toLowerCase();
		        if (varCheckOther == 'undergraduate/graduate') {
		            document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
		            document.getElementById("divHighestEducationObtainedFrom").textContent = "College Name:*";
		            document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
		            document.getElementById("divHighestEducationYear").style.textAlign = "left";
		            document.getElementById("divHighestEducationYear").textContent = "Year of Graduation"
		            document.getElementById("divHighestEducationYear").innerText = "Year of Graduation"

		            document.getElementById("dvPGSpecialization").style.display = "none";
		        }
		        else if (varCheckOther == 'post graduate') {
		            document.getElementById("divHighestEducationObtainedFrom").style.textAlign = "left";
		            document.getElementById("divHighestEducationObtainedFrom").textContent = "College Name:*";
		            document.getElementById("divHighestEducationObtainedFrom").innerText = "College Name:*";
		            document.getElementById("divHighestEducationYear").style.textAlign = "left";
		            document.getElementById("divHighestEducationYear").textContent = "Year of Post Graduation"
		            document.getElementById("divHighestEducationYear").innerText = "Year of Post Graduation"

		            document.getElementById("dvPGSpecialization").style.display = "";
		        }
		        else {


		            document.getElementById("dvPGSpecialization").style.display = "none";
		        }
		    }

		    function hideTextBox() {

		        if (document.getElementById("ddlQualification").value == "0") {
		            document.getElementById("dvPostGraduate").style.display = "none";
		            document.getElementById("dvPostGraduate1").style.display = "none";
		            document.getElementById("dvPostGraduate2").style.display = "none";
		            document.getElementById("dvHighEduYear").style.display = "none";

		            document.getElementById("dvPGSpecialization").style.display = "none";
		        }
		        else {
		            document.getElementById("dvPostGraduate").style.display = "";
		            document.getElementById("dvPostGraduate1").style.display = "";
		            document.getElementById("dvPostGraduate2").style.display = "";
		            document.getElementById("dvHighEduYear").style.display = "";

		            document.getElementById("dvPGSpecialization").style.display = "";
		        }

		    }

		    function fillHiddenCentre() {
		        var box = document.getElementById("ddlTestCentre");
		        var varOption = document.createElement('OPTION');
		        varOption = box.options[box.selectedIndex];

		        document.getElementById("hdTestCentre").value = document.getElementById("ddlTestCentre").value;
		        document.getElementById("hdTestCentreName").value = varOption.text;
		    }

		    function fillHiddenQualification() {

		        document.getElementById("hdQualificationDetails").value = document.getElementById("ddlQualificationDetails").value;


		        var varCheckOther;
		        var box = document.getElementById("ddlQualificationDetails");
		        var varOption = document.createElement('OPTION');

		        varOption = box.options[box.selectedIndex];
		        varCheckOther = varOption.text;
		        varCheckOther = varCheckOther.toLowerCase();

		        document.getElementById("hdQualificationDetailsName").value = varCheckOther;

		        if (varCheckOther == 'others') {

		            document.getElementById("txtOtherQualification").style.visibility = "visible";
		            document.getElementById("txtOtherQualification").style.display = "";
		            document.getElementById("txtOtherQualification").value = "Specify other";
		        }
		        else {
		            document.getElementById("txtOtherQualification").value = "";
		            document.getElementById("txtOtherQualification").style.visibility = "hidden";
		            document.getElementById("txtOtherQualification").style.display = "none";
		        }

		    }

		    function RemoveJunk(e) {
		        var k;
		        document.all ? k = e.keyCode : k = e.which;
		        return ((k > 63 && k < 91) || (k > 96 && k < 123) || (k >= 48 && k <= 57));
		    }


		    function CheckedValue() {
		        var varCheckOther;
		        var box = document.getElementById("ddlQualificationDetails");
		        var varOption = document.createElement('OPTION');

		        varOption = box.options[box.selectedIndex];
		        varCheckOther = varOption.text;
		        varCheckOther = varCheckOther.toLowerCase();

		        if (varCheckOther == 'others') {

		            return true;
		        }
		        else {
		            return false;
		        }
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
		        // alert(fi.size);

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


		    function ValidateData() {
		        var strText;

		        //Validate First Name



		        strText = document.getElementById("txtFirstName").value;

		        if (Trim(strText) == "") {
		            alert("Please enter first name");
		            document.getElementById("txtFirstName").focus();
		            document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtFirstName").style.backgroundColor = 'white';
		        }


		        if (!IsAlphabet(strText)) {
		            alert("Please enter alphabet");
		            document.getElementById("txtFirstName").focus();
		            document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtFirstName").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtFirstName").focus();
		            document.getElementById("txtFirstName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtFirstName").style.backgroundColor = 'white';
		        }


		        //Validate Middle Name

		        strText = document.getElementById("txtMiddleName").value;

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtMiddleName").focus();
		            document.getElementById("txtMiddleName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtMiddleName").style.backgroundColor = 'white';
		        }

		        //Validate Last Name

		        strText = document.getElementById("txtLastName").value;
		        if (Trim(strText) == "") {
		            alert("Please enter last name");
		            document.getElementById("txtLastName").focus();
		            document.getElementById("txtLastName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtLastName").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtLastName").focus();
		            document.getElementById("txtLastName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtLastName").style.backgroundColor = 'white';
		        }

		        //Validate Date of Birth


		        strText = document.getElementById("ddlDay").value;

		        if ((strText) == 0) {
		            alert("Please select day");
		            document.getElementById("ddlDay").focus();
		            document.getElementById("ddlDay").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlDay").style.backgroundColor = 'white';
		        }


		        strText = document.getElementById("ddlMonth").value;
		        if ((strText) == 0) {
		            alert("Please select month");
		            document.getElementById("ddlMonth").focus();
		            document.getElementById("ddlMonth").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlMonth").style.backgroundColor = 'white';
		        }

		        strText = document.getElementById("ddlYear").value;
		        if ((strText) == 0) {
		            alert("Please select year");
		            document.getElementById("ddlYear").focus();
		            document.getElementById("ddlYear").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlYear").style.backgroundColor = 'white';
		        }

		        strText = document.getElementById("ddlDay").value + "-" + document.getElementById("ddlMonth").value + "-" + document.getElementById("ddlYear").value

		        if (isValidDate(strText) != "") {
		            alert("Please enter valid date");
		            document.getElementById("ddlDay").focus();
		            document.getElementById("ddlDay").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlDay").style.backgroundColor = 'white';
		        }


		        //Validate Gender


		        if (window.document.forms[0].rblGender[0].checked == false && window.document.forms[0].rblGender[1].checked == false) {
		            alert("Please select gender");
		            document.getElementById("rblGender_0").focus();
		            return false;
		        }



		        //Validate Residential Address							 

		        strText = document.getElementById("txtResidentialAddress").value;

		        if (Trim(strText) == "") {
		            alert("Please enter residential address");
		            document.getElementById("txtResidentialAddress").focus();
		            document.getElementById("txtResidentialAddress").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtResidentialAddress").style.backgroundColor = 'white';
		        }

		        if ((strText.length) > 400) {
		            alert("Please enter residential address less then 400 character");
		            document.getElementById("txtResidentialAddress").focus();
		            document.getElementById("txtResidentialAddress").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtResidentialAddress").style.backgroundColor = 'white';
		        }




		        //Validate city						 


		        strText = document.getElementById("txtCity").value;

		        if (Trim(strText) == "") {
		            alert("Please enter city name");
		            document.getElementById("txtCity").focus();
		            document.getElementById("txtCity").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCity").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtCity").focus();
		            document.getElementById("txtCity").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCity").style.backgroundColor = 'white';
		        }

		        //Validate Pincode							 

		        strText = document.getElementById("txtPinCode").value;

		        if (Trim(strText) == "") {
		            alert("Please enter pincode");
		            document.getElementById("txtPinCode").focus();
		            document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPinCode").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtPinCode").focus();
		            document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPinCode").style.backgroundColor = 'white';
		        }


		        if (!IsNumeric(strText)) {
		            alert("Please enter numeric data");
		            document.getElementById("txtPinCode").focus();
		            document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else if ((strText.length) != 6) {
		            alert("Please enter valid pin code");
		            document.getElementById("txtPinCode").focus();
		            document.getElementById("txtPinCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPinCode").style.backgroundColor = 'white';
		        }


		        //Validate Phone Number Land Line					

		        // STD Code
		        strText = document.getElementById("txtSTDCode").value;

		        if (Trim(strText) == "") {
		            alert("Please enter std code");
		            document.getElementById("txtSTDCode").focus();
		            document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtSTDCode").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtSTDCode").focus();
		            document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtSTDCode").style.backgroundColor = 'white';
		        }

		        if (!IsNumeric(strText)) {
		            alert("Please enter numeric data");
		            document.getElementById("txtSTDCode").focus();
		            document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else if (((strText.length) < 3) || ((strText.length) > 5)) {
		            alert("Please enter valid STD code");
		            document.getElementById("txtSTDCode").focus();
		            document.getElementById("txtSTDCode").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtSTDCode").style.backgroundColor = 'white';
		        }

		        //Phone Number
		        strText = document.getElementById("txtPhoneNumber").value;

		        if (Trim(strText) == "") {
		            alert("Please enter phone number");
		            document.getElementById("txtPhoneNumber").focus();
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtPhoneNumber").focus();
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
		        }

		        if (!IsNumeric(strText)) {
		            alert("Please enter numeric data");
		            document.getElementById("txtPhoneNumber").focus();
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else if (((strText.length) < 6) || ((strText.length) > 10)) {
		            alert("Please enter valid phone number");
		            document.getElementById("txtPhoneNumber").focus();
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
		        }

		        //Validate Mobile Number



		        strText = document.getElementById("txtCellPhone").value;
		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtCellPhone").focus();
		            document.getElementById("txtCellPhone").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCellPhone").style.backgroundColor = 'white';
		        }

		        if (!IsNumeric(strText)) {
		            alert("Please enter numeric data");
		            document.getElementById("txtCellPhone").focus();
		            document.getElementById("txtCellPhone").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCellPhone").style.backgroundColor = 'white';
		        }

		        //Validate Upload Photograph

		        strText = document.getElementById("filUpload").value;

		        if (Trim(strText) == "") {
		            alert('Please select a photograph to upload');
		            document.getElementById("filUpload").focus();
		            document.getElementById("filUpload").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("filUpload").style.backgroundColor = 'white';
		        }

		        if (Trim(strText) != "") {
		            var varFlag = CheckFileExtension();
		            if (varFlag == false) {
		                document.getElementById("filUpload").focus();
		                return false;
		            }
		            else {
		                document.getElementById("hdImagepath").value = document.getElementById("filUpload").value;
		            }
		        }



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


		        //Validate Mother's Full Name					

		        strText = document.getElementById("txtMothersName").value;

		        if (Trim(strText) == "") {
		            alert("Please enter mothers name");
		            document.getElementById("txtMothersName").focus();
		            document.getElementById("txtMothersName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtMothersName").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtPhoneNumber").focus();
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPhoneNumber").style.backgroundColor = 'white';
		        }

		        //Validate Father's Full Name					

		        strText = document.getElementById("txtFathersName").value;

		        if (Trim(strText) == "") {
		            alert("Please enter father name");
		            document.getElementById("txtFathersName").focus();
		            document.getElementById("txtFathersName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtFathersName").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtFathersName").focus();
		            document.getElementById("txtFathersName").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtFathersName").style.backgroundColor = 'white';
		        }

		        //Validate Annual Household Income

		        strText = document.getElementById("ddlHouseholdIncome").value;

		        if ((strText) == 0) {
		            alert("Please select house hold income");
		            document.getElementById("ddlHouseholdIncome").focus();
		            document.getElementById("ddlHouseholdIncome").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlHouseholdIncome").style.backgroundColor = 'white';
		        }

		        //Validate You belong to		

		        if (window.document.forms[0].rblYouBelongTo[0].checked == false && window.document.forms[0].rblYouBelongTo[1].checked == false) {
		            alert("Please select you belong to");
		            document.getElementById("rblYouBelongTo_0").focus();
		            return false;
		        }

		        //Validate Highest Educational qualification					


		        strText = document.getElementById("ddlQualification").value;
		        if (strText == 0) {
		            alert("Please select qualification");
		            document.getElementById("ddlQualification").focus();
		            document.getElementById("ddlQualification").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlQualification").style.backgroundColor = 'white';
		        }

		        //Validate Highest Education Obtained			

		        strText = document.getElementById("txtHighestEducationObtainedFrom").value;

		        if (strText == "") {
		            alert("Please enter college name");
		            document.getElementById("txtHighestEducationObtainedFrom").focus();
		            document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtHighestEducationObtainedFrom").focus();
		            document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtHighestEducationObtainedFrom").style.backgroundColor = 'white';
		        }

		        //Validate College Address	
		        strText = document.getElementById("txtCollegeAddress").value;

		        if (Trim(strText) == "") {
		            alert("Please enter college address");
		            document.getElementById("txtCollegeAddress").focus();
		            document.getElementById("txtCollegeAddress").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCollegeAddress").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtCollegeAddress").focus();
		            document.getElementById("txtCollegeAddress").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCollegeAddress").style.backgroundColor = 'white';
		        }

		        //Validate Highest Education Obtained from					


		        strText = document.getElementById("txtHighestEducationCity").value;

		        if (strText == "") {
		            alert("Please enter college city");
		            document.getElementById("txtHighestEducationCity").focus();
		            document.getElementById("txtHighestEducationCity").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtHighestEducationCity").style.backgroundColor = 'white';
		        }


		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtHighestEducationCity").focus();
		            document.getElementById("txtHighestEducationCity").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtHighestEducationCity").style.backgroundColor = 'white';
		        }

		        //Validate Qualification Details



		        strText = document.getElementById("ddlQualificationDetails").value;
		        if ((strText) == 0) {
		            alert("Please select qualification detail");
		            document.getElementById("ddlQualificationDetails").focus();
		            document.getElementById("ddlQualificationDetails").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlQualificationDetails").style.backgroundColor = 'white';
		        }

		        if (CheckedValue()) {

		            strText = document.getElementById("txtOtherQualification").value;
		            if (strText == "") {
		                alert("Please enter educational detail");
		                document.getElementById("txtOtherQualification").focus();
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
		            }

		            if (IsAngularBracket(strText)) {
		                alert("Character '< ' is not allowed");
		                document.getElementById("txtOtherQualification").focus();
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtOtherQualification").value;
		            if (strText == "Specify other") {
		                alert("Please enter educational detail");
		                document.getElementById("txtOtherQualification").focus();
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtOtherQualification").style.backgroundColor = 'white';
		            }
		        }
		        //txtOtherQualification

		        //Validate Aggregate Percentage Scored			


		        strText = document.getElementById("txtPercentageScored").value;

		        if (Trim(strText) == "") {
		            alert("Please enter aggregate percentage scored");
		            document.getElementById("txtPercentageScored").focus();
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
		        }

		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtPercentageScored").focus();
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
		        }

		        if (!IsNumeric(strText)) {
		            alert("Please enter numeric data");
		            document.getElementById("txtPercentageScored").focus();
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPercentageScored").style.backgroundColor = 'white';
		        }

		        strText = document.getElementById("ddlMediumOfInstruction").value;
		        if ((strText) == 0) {
		            alert("Please select medium of instruction upto 10");
		            document.getElementById("ddlMediumOfInstruction").focus();
		            document.getElementById("ddlMediumOfInstruction").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlMediumOfInstruction").style.backgroundColor = 'white';
		        }

		        strText = document.getElementById("ddlMediumOfInstructionIn12Th").value;
		        if ((strText) == 0) {
		            alert("Please select medium of instruction upto 12");
		            document.getElementById("ddlMediumOfInstructionIn12Th").focus();
		            document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlMediumOfInstructionIn12Th").style.backgroundColor = 'white';
		        }


		        //validate 12th passing year			

		        strText = document.getElementById("ddlPassingYear12th").value;

		        if (strText == 0) {
		            alert("Please select 12th Passing year");
		            document.getElementById("ddlPassingYear12th").focus();
		            document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
		            return false;
		        }

		        //AKU
		        //Check that difference between year of birth and year of passing 12th is not less than 16
		        if (document.getElementById("ddlYear").value != '0' && document.getElementById("ddlPassingYear12th").value != '0') {
		            if (document.getElementById("ddlPassingYear12th").value - document.getElementById("ddlYear").value < 16) {
		                alert("Minimum 16 years of difference required between year of birth and year of passing 12th");
		                document.getElementById("ddlPassingYear12th").focus();
		                document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
		                document.getElementById("ddlYear").style.backgroundColor = 'yellow';
		                return false;
		            }

		        }


		        if (document.getElementById("ddlGraduationYear").value != '0' && document.getElementById("ddlPassingYear12th").value != '0') {
		            //alert(document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value);
		            if (document.getElementById("ddlQualification").value == '1') {

		                if (document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value < 3) {
		                    alert("Minimum 3 years of difference required between year of passing 12th and year of passing graduation");
		                    document.getElementById("ddlPassingYear12th").focus();
		                    document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
		                    document.getElementById("ddlGraduationYear").style.backgroundColor = 'yellow';
		                    return false;
		                }
		                else {
		                    document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
		                    document.getElementById("ddlGraduationYear").style.backgroundColor = 'white';
		                }

		            }
		        }
		        if (document.getElementById("ddlQualification").value == '3') {
		            if (document.getElementById("ddlGraduationYear").value - document.getElementById("ddlPassingYear12th").value < 5) {
		                alert("Minimum 5 years of difference required between year of passing 12th and year of passing post graduation");
		                document.getElementById("ddlPassingYear12th").focus();
		                document.getElementById("ddlPassingYear12th").style.backgroundColor = 'yellow';
		                document.getElementById("ddlGraduationYear").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
		                document.getElementById("ddlGraduationYear").style.backgroundColor = 'white';
		            }
		        }


		        else {
		            document.getElementById("ddlPassingYear12th").style.backgroundColor = 'white';
		            document.getElementById("ddlGraduationYear").style.backgroundColor = 'white';
		        }

		        if (window.document.forms[0].rblEmploymentStatus[0].checked == false && window.document.forms[0].rblEmploymentStatus[1].checked == false) {
		            alert("Please select employment status");
		            document.getElementById("rblEmploymentStatus_0").focus();
		            return false;
		        }
		        //validate current location and language skills
		        strText = document.getElementById("txtCurrentLocation").value;

		        if (Trim(strText) == "") {
		            alert("Please enter Current Location");
		            document.getElementById("txtCurrentLocation").focus();
		            document.getElementById("txtCurrentLocation").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtCurrentLocation").style.backgroundColor = 'white';
		        }

		        strText = document.getElementById("txtLanguageSkills").value;

		        if (Trim(strText) == "") {
		            alert("Please enter Language skills");
		            document.getElementById("txtLanguageSkills").focus();
		            document.getElementById("txtLanguageSkills").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtLanguageSkills").style.backgroundColor = 'white';
		        }
		        //Validate Willing to work out of hometown							

		        if (window.document.forms[0].rblWillingToWorkOutOfHomeTown[0].checked == false && window.document.forms[0].rblWillingToWorkOutOfHomeTown[1].checked == false) {
		            alert("Please select willing to work out of home town");
		            document.getElementById("rblWillingToWorkOutOfHomeTown_0").focus();
		            return false;
		        }

		        //validate passport

		        //Passport				
		        strText = document.getElementById("ddlPassport").value;

		        if ((strText) == "0") {
		            alert("Please select Passport.");
		            document.getElementById("ddlPassport").focus();
		            document.getElementById("ddlPassport").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPassport").style.backgroundColor = 'white';
		        }

		        if ((strText) == "Yes") {
		            strText = document.getElementById("txtPassport").value;

		            if (strText == "") {
		                alert("Please enter Passport Detail.");
		                document.getElementById("txtPassport").focus();
		                document.getElementById("txtPassport").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtPassport").style.backgroundColor = 'white';
		            }

		            if (IsAngularBracket(strText)) {
		                alert("Character '< ' is not allowed");
		                document.getElementById("txtPassport").focus();
		                document.getElementById("txtPassport").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtPassport").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            document.getElementById("ddlPassport").style.backgroundColor = 'white';
		        }


		        //Validate Test City	
		        strText = document.getElementById("ddlTestCity").value;

		        if ((strText) == 0) {
		            alert("Please select test city");
		            document.getElementById("ddlTestCity").focus();
		            document.getElementById("ddlTestCity").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlTestCity").style.backgroundColor = 'white';
		        }

		        //Validate Test Centre		 
		        strText = document.getElementById("ddlTestCentre").value;
		        //var varCentreCheck = <%=Convert.ToInt32(Session["StateId"])%>;  				
		        //if ((strText) == 0 && varCentreCheck != 1)//&& varCentreCheck != 6)
		        if ((strText) == 0) {
		            //if ((strText) == 0 && varCentreCheck != 6)
		            //{
		            alert("Please select test centre");
		            document.getElementById("ddlTestCentre").focus();
		            document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
		            return false;
		            //}
		        }
		        else {
		            document.getElementById("ddlTestCentre").style.backgroundColor = 'white';
		        }

		        //Validate Password



		        strText = document.getElementById("txtPassword").value;

		        if (Trim(strText) == "") {
		            alert("Please enter password");
		            document.getElementById("txtPassword").focus();
		            document.getElementById("txtPassword").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            var count = 0;
		            if ((strText.length) < 6) {
		                count += 1
		            }
		            //UpperCase
		            //				   if (/[A-Z]/.test(strText)) {
		            //				        count += 1
		            //				    }
		            //Lowercase
		            //				    if (/[a-z]/.test(strText)) {
		            //				        count += 1
		            //				    }
		            //				    //Numbers  
		            //				    if (/\d/.test(strText)) {
		            //				        count += 1
		            //				    }
		            //Non alphas( special chars)
		            //				    if (/\W/.test(strText)) {
		            //				        count += 1
		            //				    }

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

		        //Validate Confirm Password          
		        var confirmText = document.getElementById("txtConfirmPassword").value;

		        if (Trim(confirmText) == "") {
		            alert("Please enter confirm password");
		            document.getElementById("txtConfirmPassword").focus();
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
		        }


		        if (document.getElementById("txtConfirmPassword").value != document.getElementById("txtPassword").value) {
		            alert("Please enter confirm password same as password");

		            document.getElementById("txtConfirmPassword").focus();
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtConfirmPassword").style.backgroundColor = 'white';
		        }

		        //Validate Photo Id document			 
		        strText = document.getElementById("ddlPhotoIdDocument").value;

		        if (strText == 0) {
		            alert("Please select photo id document");
		            document.getElementById("ddlPhotoIdDocument").focus();
		            document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("ddlPhotoIdDocument").style.backgroundColor = 'white';
		        }


		        strText = document.getElementById("txtPhotoIdNumber").value;

		        if (Trim(strText) == "") {
		            alert("Please enter photo id number");
		            document.getElementById("txtPhotoIdNumber").focus();
		            document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
		            document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'white';
		        }


		        if (IsAngularBracket(strText)) {
		            alert("Character '< ' is not allowed");
		            document.getElementById("txtPhotoIdNumber").focus();
		            document.getElementById("txtPhotoIdNumber").style.backgroundColor = 'yellow';
		            return false;
		        }
		        else {
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

		        if (!window.confirm("Are you sure you want to submit the details?")) {
		            return false;
		        }
		        return true;
		    }

		    function SetComponentStatus() {
		        //document.getElementById("txtOtherQualification").style.visibility = "hidden";
		        strText = document.getElementById("ddlQualificationDetails").value;
		        if ((strText) == 0) {
		            document.getElementById("txtOtherQualification").style.visibility = "hidden";
		        }
		        HidePassport();
		    }
		    function RemovePhotograph() {
		        document.getElementById("filUpload").value = "";
		    }
		    function HidePassport() {
		        if (document.getElementById("ddlPassport").value == "Yes") {
		            document.getElementById("dvPassport1").style.display = "";
		        }
		        else {
		            document.getElementById("dvPassport1").style.display = "none";
		        }
		    }
			
		</script>
		<script>
		    var req;

		    function Initialize() {
		        try {
		            req = new ActiveXObject("Msxml2.XMLHTTP");
		        }
		        catch (e) {
		            try {
		                req = new ActiveXObject("Microsoft.XMLHTTP");
		            }
		            catch (oc) {
		                req = null;
		            }
		        }

		        if (!req && typeof XMLHttpRequest != "undefined") {
		            req = new XMLHttpRequest();
		        }

		    }

		    function SendQuery(key) {
		        Initialize();
		        var url = window.location.href;
		        url = url.substr(0, url.search("Registration.aspx"));
		        var url = url = url + "PasswordCheck.aspx?k=" + key;

		        if (req != null) {
		            req.onreadystatechange = Process;
		            req.open("GET", url, true);
		            req.send(null);

		        }

		    }

		    function Process() {
		        if (req.readyState == 4) {
		            // only if "OK"
		            if (req.status == 200) {
		                if (req.responseText == "")
		                    HideDiv("password");
		                else {
		                    ShowDiv("password");
		                    document.getElementById("password").innerHTML = req.responseText;
		                    if (req.responseText == "Password already exist") {
		                        document.getElementById("txtPassword").focus();
		                        document.getElementById("txtPassword").value = "";
		                    }
		                    else {
		                        document.getElementById("txtPassword").style.backgroundColor = 'white';
		                        HideDiv("password");
		                    }

		                }
		            }
		            else {
		                document.getElementById("password").innerHTML = "There was a problem retrieving data:<br>" + req.statusText;
		            }
		        }
		    }

		    function ShowDiv(divid) {
		        if (document.layers) document.layers[divid].visibility = "show";
		        else document.getElementById(divid).style.visibility = "visible";
		    }

		    function HideDiv(divid) {
		        if (divid != 'password') {
		            if (document.layers) document.layers[divid].visibility = "hide";
		            else document.getElementById(divid).style.visibility = "hidden";
		        }
		    }
		    function BodyLoad() {
		        HideDiv("password");
		    }
			
		</script>
	    <style type="text/css">
            .style1
            {
                height: 24px;
            }
            .style2
            {
                font-size: 11px;
                color: #a11d21;
                font-family: Arial;
                text-decoration: none;
                height: 24px;
            }
        </style>
	    </HEAD>
	<body onload="SetComponentStatus();BodyLoad();hideTextBox();ChangeCollegeLabel();">
		<form onkeypress="avoidEnter();" id="Form1" name="Form1" method="post" runat="server">

			 <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headerlogo1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left">Registration Form 
                        <asp:label id="lblStateName" Runat="server" Visible="False"></asp:label></h2>
                         
													
                <table cellspacing="0" cellpadding="0" border="0" align="center">
                    <TR class="white_bg" vAlign="top" align="left">
									<TD align="center"><BR>
										<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="3" width="100%">
											<TR>
												<TD colSpan="3">
													<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR vAlign="top">
															<TD class="small_maroon" width="60%" align="left">All (*) marked are mandatory 
																fields &nbsp;&nbsp;
																<asp:label id="lblExistMessage" Runat="server" Font-Bold="True" ForeColor="Red"></asp:label></TD>
															<TD id="tdInstructions" class="small_maroon" width="40%" align="right" runat="server"><%if (intStateId == 8){ %><A href="APInstruction.aspx" target="_blank">Instructions 
																	for form filling </A>&nbsp;&nbsp;
																<%}else{%>
																<A id="lnkInstructions" href="SampleRegistration.aspx" target="_blank">Instructions 
																	for form filling </A>&nbsp;&nbsp;
																<%}%>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="lightblue_bg" colSpan="3"><STRONG>PERSONAL DETAILS</STRONG></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD width="43%">First Name:<FONT class="small_maroon">*</FONT></TD>
												<TD width="55%">
													<asp:textbox id="txtFirstName" Runat="server" CssClass="txtbox" MaxLength="30" BackColor="White" onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD class="small_maroon" width="2%"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Middle Name:
												</TD>
												<TD>
													<asp:textbox id="txtMiddleName" Runat="server" CssClass="txtbox" MaxLength="30" BackColor="White" onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Last Name:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:textbox id="txtLastName" Runat="server" CssClass="txtbox" MaxLength="30" BackColor="White" onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Date of Birth:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:dropdownlist id="ddlDay" Runat="server" CssClass="txtarea" BackColor="White">
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
													</asp:dropdownlist>
													<asp:dropdownlist id="ddlMonth" Runat="server" CssClass="txtarea" BackColor="White">
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
													</asp:dropdownlist>
													<asp:dropdownlist id="ddlYear" Runat="server" CssClass="txtarea" BackColor="White">														
													</asp:dropdownlist></TD>

												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Gender:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:radiobuttonlist id="rblGender" Runat="server" CssClass="rblbox" BackColor="White" RepeatDirection="Horizontal"
														RepeatColumns="2" Width="88px">
														<asp:ListItem Value="M">Male</asp:ListItem>
														<asp:ListItem Value="F">Female</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Residential Address:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD style="WIDTH: 250px">
													<asp:textbox id="txtResidentialAddress" runat="server" CssClass="txtarea" MaxLength="100" BackColor="White"
														Width="250px" TextMode="MultiLine" Rows="4" Columns="30"></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>City:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:textbox id="txtCity" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Pincode:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:textbox id="txtPinCode" Runat="server" CssClass="txtbox" MaxLength="6" BackColor="White" 
                                                     onkeypress='validateNum(event)'></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Phone Number (Landline):<FONT class="small_maroon">*</FONT>
												</TD>
												<TD><FONT class="rblbox">(STD Code)</FONT>
													<asp:textbox id="txtSTDCode" Runat="server" CssClass="txtbox" MaxLength="6" BackColor="White"
														Width="50px" onkeypress='validateNum(event)'></asp:textbox>&nbsp;
													<asp:textbox id="txtPhoneNumber" Runat="server" CssClass="txtbox" MaxLength="10" BackColor="White" onkeypress='validateNum(event)'></asp:textbox>&nbsp;
												</TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Phone Number (Cellphone):
												</TD>
												<TD>
													<asp:textbox id="txtCellPhone" Runat="server" CssClass="txtbox" MaxLength="10" BackColor="White"  onkeypress='validateNum(event)'></asp:textbox></TD>
												<TD class="small_maroon">&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD style="HEIGHT: 24px">Upload Photograph:<FONT class="small_maroon">*</FONT>
												</TD>
												<td colspan="2">
                                                    <input id="filUpload" class="btn2File" size="40" type="file" name="filUpload" onchange = "validateFile();"
                                                        runat="server"/>&nbsp;
													<input id="btnFileUpload" class="btn2" onclick="BlankFileUpload();" value="Remove" type="button"/>
												</td>
											</TR>
                                           
											<TR>
												<TD class="small_maroon" colSpan="3"><FONT class="small_maroon">*</FONT> To upload 
													your photograph, click on 'browse' button and select photograph from the 
													computer where you have saved the photograph. The photograph size must not be greater than 1 MB.It must be in .jpg, .jpeg or .gif 
													format only.</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD style="HEIGHT: 24px">Email Id:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:textbox id="txtEmailID" Runat="server" CssClass="txtbox" MaxLength="30" BackColor="White"></asp:textbox></TD>
												<TD class="small_maroon">&nbsp;</TD>
											</TR>

                                            <TR>
												<TD class="small_maroon" colSpan="3"><FONT class="small_maroon">*</FONT> Please ensure you are entering a valid e-mail ID.</TD>
											</TR>

											<TR class="main_black" vAlign="top" align="left">
												<TD style="HEIGHT: 24px">Mother's Full Name:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD style="HEIGHT: 24px">
													<asp:textbox id="txtMothersName" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD style="HEIGHT: 24px" class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Father's Full Name:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:textbox id="txtFathersName" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"  onkeypress='validateAlpha(event)'></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Annual Household Income:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:dropdownlist id="ddlHouseholdIncome" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>You belong to:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:radiobuttonlist id="rblYouBelongTo" Runat="server" CssClass="rblbox" BackColor="White" RepeatDirection="Horizontal"
														RepeatColumns="2" Width="112px">
														<asp:ListItem Value="Village">Village</asp:ListItem>
														<asp:ListItem Value="City">City</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Highest Educational Qualification:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:dropdownlist id="ddlQualification" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR style="DISPLAY: none" class = "main_black"  id="dvPostGraduate" class="small_black" vAlign="top" align="left">
												<TD style="HEIGHT: 19px" id="divHighestEducationObtainedFrom" align="right" runat="server"  onkeypress='validateAlpha(event)'></TD>
												<TD style="HEIGHT: 19px" align="left">
													<asp:textbox id="txtHighestEducationObtainedFrom" Runat="server" CssClass="txtbox" MaxLength="50"
														BackColor="White"></asp:textbox></TD>
												<TD style="HEIGHT: 19px" class="small_maroon"></TD>
											</TR>
											<TR style="DISPLAY: none" id="dvHighEduYear" class="main_black" vAlign="top" align="left">
												<TD id="divHighestEducationYear" align="right"></TD>
												<TD id="TdYG1" align="left">
													<asp:dropdownlist id="ddlGraduationYear" Runat="server" CssClass="txtarea" BackColor="White" Width="88px">
													</asp:dropdownlist></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR style="DISPLAY: none" id="dvPGSpecialization" class="small_black" vAlign="top" align="left">
												<TD id="Td3" class="main_black">Specialization in PG:</TD>
												<TD align="left">
													<asp:textbox id="txtPGSpecialization" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White"></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR style="DISPLAY: none" id="dvPostGraduate2" class="small_black" vAlign="top" align="left">
												<TD  class="main_black">College Address:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD style="WIDTH: 250px" vAlign="middle">
													<asp:textbox id="txtCollegeAddress" runat="server" CssClass="txtarea" MaxLength="100" BackColor="White"
														Width="250px" TextMode="MultiLine" Rows="4" Columns="30"></asp:textbox></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR style="DISPLAY: none" id="dvPostGraduate1" class="small_black" vAlign="top" align="left">
												<TD  class="main_black">College City:<FONT class="small_maroon">*</FONT></TD>
												<TD align="left">
													<asp:textbox id="txtHighestEducationCity" Runat="server" CssClass="txtbox" MaxLength="10" BackColor="White"  onkeypress='validateAlpha(event)'></asp:textbox><FONT class="small_maroon"></FONT></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="style1">Qualification Details:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD class="style1">
													<asp:dropdownlist id="ddlQualificationDetails" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist>&nbsp;&nbsp;<INPUT style="VISIBILITY: visible" id="txtOtherQualification" class="txtarea" onfocus="this.value = ''; return true;"
														value="Specify other" maxLength="50" name="txtOtherQualification" Runat="server"><INPUT id="hdQualificationDetails" value="0" type="hidden" name="hdQualificationDetails"
														runat="server"><INPUT id="hdQualificationDetailsName" value="0" type="hidden" name="hdQualificationDetailsName"
														runat="server"><INPUT id="hdImagepath" type="hidden" name="hdImagepath" runat="server"><INPUT id="hdpassword" type="hidden" name="hdpassword" runat="server"><INPUT id="hdconfpassword" type="hidden" name="hdconfpassword" runat="server">
												</TD>
												<TD class="style2"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Aggregate Percentage Scored:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:textbox id="txtPercentageScored" Runat="server" CssClass="txtbox" 
                                                        MaxLength="2" BackColor="White"
														Width="70px" onkeypress='validatePercent(event)'></asp:textbox>%</TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Medium of Instruction upto 10th:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:dropdownlist id="ddlMediumOfInstruction" Runat="server" CssClass="txtarea" BackColor="White">
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
												<TD>Medium of Instruction in 12th:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:dropdownlist id="ddlMediumOfInstructionIn12Th" Runat="server" CssClass="txtarea" BackColor="White">
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
												<TD>Year of passing 12th:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:dropdownlist id="ddlPassingYear12th" Runat="server" CssClass="txtarea" BackColor="White" Width="88px">														
													</asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>&nbsp;</TD>
												<TD class="small_maroon">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="lightblue_bg" colSpan="3"><STRONG>PROFESSIONAL DETAILS</STRONG></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Employment Status:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:radiobuttonlist id="rblEmploymentStatus" Runat="server" CssClass="rblbox" BackColor="White" RepeatDirection="Horizontal"
														RepeatColumns="2" Width="160px">
														<asp:ListItem Value="Employed">Employed</asp:ListItem>
														<asp:ListItem Value="Unemployed">Unemployed</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Current Location:<FONT class="small_maroon">*</FONT></TD>
												<TD class="small_maroon">
													<asp:textbox id="txtCurrentLocation" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White" onkeypress='validateAlpha(event)'></asp:textbox>(city 
													where you presently stay)
												</TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Language Skills:<FONT class="small_maroon">*</FONT></TD>
												<TD class="small_maroon">
													<asp:textbox id="txtLanguageSkills" Runat="server" CssClass="txtbox" MaxLength="50" BackColor="White" onkeypress='validateAlphaComma(event)'></asp:textbox>(language 
													that you are proficient in)
												</TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Willing to work out of hometown:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:radiobuttonlist id="rblWillingToWorkOutOfHomeTown" Runat="server" CssClass="rblbox" BackColor="White"
														RepeatDirection="Horizontal" RepeatColumns="2" Width="96px" onselectedindexchanged="rblWillingToWorkOutOfHomeTown_SelectedIndexChanged">
														<asp:ListItem Value="Yes">Yes</asp:ListItem>
														<asp:ListItem Value="No">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD class="small_maroon" vAlign="middle"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Do you have a passport?:<FONT class="small_maroon">*</FONT></TD>
												<TD>
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
												<TD>
													<asp:textbox id="txtPassport" Runat="server" CssClass="txtbox" MaxLength="10" 
                                                        BackColor="White" onkeypress='validatePassport(event)'></asp:textbox><!--<input id="Hidden1" type="hidden" value="0" name="hdPassport" runat="server">--></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>&nbsp;</TD>
												<TD class="small_maroon">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="lightblue_bg" colSpan="3"><STRONG>NAC TEST DETAILS</STRONG></TD>
											</TR>
											<TR id="trTestCity" class="main_black" vAlign="top" align="left" runat="server">
												<TD>Test City:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<DIV id="divDropTestCity" runat="server">
														<asp:dropdownlist id="ddlTestCity" Runat="server" CssClass="txtarea" BackColor="White" AutoPostBack="False"></asp:dropdownlist><SPAN class="small_maroon">(please 
																select city) <SPAN>
													</DIV>
													<DIV id="divLblTestCity" runat="server">
														<asp:label id="lblTestCity" Runat="server"></asp:label></DIV>
													<FONT class="small_maroon"></FONT></SPAN></SPAN></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR id="trTestCentre" class="main_black" vAlign="top" align="left" runat="server">
												<TD>Test Centre:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<DIV id="divDropTestCentre" runat="server">
														<asp:dropdownlist id="ddlTestCentre" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist><SPAN class="small_maroon">(please 
																select test centre)<SPAN></DIV>
													<DIV id="divLblTestCentre" runat="server">
														<asp:label id="lblTestCentre" Runat="server"></asp:label></DIV>
													<FONT class="small_maroon"></FONT><INPUT id="hdTestCentre" value="0" type="hidden" name="hdTestCentre" runat="server"><INPUT id="hdTestCentreName" type="hidden" name="hdTestCentreName" runat="server">
													</SPAN></SPAN></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>&nbsp;</TD>
												<TD class="small_maroon">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD class="lightblue_bg" colSpan="3"><STRONG>SECURITY </STRONG>
												</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Password:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD class="small_maroon">
													<asp:textbox id="txtPassword" Runat="server" CssClass="txtbox" MaxLength="12" BackColor="White"
														TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" 
                                                        onkeypress="return RemoveJunk(event)"></asp:textbox><!-- onBlur = "SendQuery(this.value)"-->
													
													<br />
													
													Password should be 6 - 12 characters.
                                                    <br />
                                                    Password must contain only alphabets and numerics only.</TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Confirm Password:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:textbox id="txtConfirmPassword" Runat="server" CssClass="txtbox" 
                                                        MaxLength="12" BackColor="White"
														TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false"></asp:textbox><FONT class="small_maroon"></FONT></TD>
												<TD class="small_maroon"></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 25px" class="small_maroon" colSpan="3">* Please note down this 
													password - You should use the same to view your NAC score card after the test.</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>Select a photo-Id document:<FONT class="small_maroon">*</FONT></TD>
												<TD>
													<asp:dropdownlist id="ddlPhotoIdDocument" Runat="server" CssClass="txtarea" BackColor="White"></asp:dropdownlist><FONT class="small_maroon"></FONT></TD>
												<TD class="small_maroon"></TD>
											</TR>											
											<TR class="main_black" vAlign="top" align="left">
												<TD>Photo-Id Document Number:<FONT class="small_maroon">*</FONT>
												</TD>
												<TD>
													<asp:textbox id="txtPhotoIdNumber" Runat="server" CssClass="txtbox" MaxLength="15" BackColor="White"></asp:textbox><FONT class="small_maroon"></FONT></TD>
												<TD class="small_maroon"></TD>
											</TR>
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
												<TD style="HEIGHT: 22px" colSpan="3" class="small_maroon" align="center"><SPAN>												
														<strong>Having difficulty in filling up form?</strong>&nbsp; <A id="A1" href="Contactus.aspx" target="_blank"><b>Contact us</b></A></SPAN>
												</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="left">
												<TD>&nbsp;</TD>
												<TD class="small_maroon">
													<asp:label id="lblMessage" Runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:label></TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR class="main_black" vAlign="top" align="center">
												<TD colSpan="3">
													<asp:button id="Save" runat="server" Text="Submit" onclick="Save_Click"></asp:button>&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>

                                             
                </table>
                                            
                                                                   

            </div>
            </div>           

               <div class="footer">  <img src="Images/footer2014.gif" /></div>
            </div>
		</form>
	</body>
</HTML>
