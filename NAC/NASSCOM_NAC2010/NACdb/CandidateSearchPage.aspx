<%@ Page language="c#" Codebehind="CandidateSearchPage.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.CandidateSearchPage" EnableEventValidation ="false" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Candidate Search Page</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="../Web/stylesheet/nasscom.css">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		 <link href="../Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
		<link rel="stylesheet" href="../Web/Stylesheet/nasscomNew.css" type="text/css">
         <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<script language="javascript" type="text/javascript">

		    function ConfirmMessage(msg) {
		        return confirm(msg);
		    }


		    function SelectCandidate_NotWorking() {
		        var varForm = document.frmSearch;

		        var varSelectedCandidateCount = 0;


		        for (i = 0; i < varForm.length; i++) {
		            e = varForm.elements[i];
		            if (e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1) {
		                if (e.checked) {
		                    varSelectedCandidateCount = varSelectedCandidateCount + 1;
		                }


		            }
		        }
		        //alert(varSelectedCandidateCount);
		        if (varSelectedCandidateCount > 0) {
		            return true;
		        }
		        else {
		            alert("Please select candidate from candidate list");
		            return false;
		        }
		    }



		    function SelectCandidate() {
		        //alert(document.getElementById("hdSelectedCandidateCount").value);
		        //var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);   
		        var varSelectedCandidateCount = parseInt(document.getElementById("Hidden1").value);
		        var varSelectedCandidateCount2 = parseInt(document.getElementById("hdSelectedCandidateCount").value);
		        if (varSelectedCandidateCount > 0 || varSelectedCandidateCount2 > 0) {
		            return true;
		        }
		        else {
		            alert("Please select candidate from candidate list");
		            return false;
		        }
		    }

		    function CheckAllCandidate() {

		        var chkVar = document.getElementById("chkAll").checked;
		        var varTotalCandidateCount = parseInt(document.getElementById("hdTotalCandidateCount").value);

		        if (chkVar) {
		            var varForm = document.frmSearch;
		            document.getElementById("hdSelectedCandidateCount").value = varTotalCandidateCount;
		            for (i = 0; i < varForm.length; i++) {
		                e = varForm.elements[i];
		                if (e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1)) {
		                    e.checked = true;

		                }
		            }
		        }
		    }

		    function DeselectAll() {

		        var chkVar = document.getElementById("chkAll").checked;
		        if (!chkVar) {
		            var varForm = document.frmSearch;
		            document.getElementById("hdSelectedCandidateCount").value = 0;
		            for (i = 0; i < varForm.length; i++) {
		                e = varForm.elements[i];
		                if (e.type == 'checkbox' && (e.name.indexOf("chkSelect") != -1 || e.name.indexOf("chkHeader") != -1)) {

		                    e.checked = false;

		                }
		            }
		        }
		    }

		    function CheckAll(checkAllBox) {
		        var varForm = document.frmSearch;
		        var chkVar = checkAllBox.checked;
		        var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);


		        for (i = 0; i < varForm.length; i++) {
		            e = varForm.elements[i];
		            if (e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1) {
		                if (chkVar) {
		                    if (!e.checked) {
		                        varSelectedCandidateCount = varSelectedCandidateCount + 1;
		                    }
		                    e.checked = true;

		                }
		                else {
		                    if (e.checked) {
		                        varSelectedCandidateCount = varSelectedCandidateCount - 1;
		                    }
		                    e.checked = false;
		                    document.getElementById("chkAll").checked = false;

		                }
		            }

		        }
		        document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount;

		        if (document.getElementById("chkHeader").value == "0") {
		            //document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = false;
		            document.getElementById("chkAll").checked = false;
		        }

		    }

		    function FillHiddenField() {
		        document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
		        document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
		        document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;
		        document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
		        document.getElementById("hdGraduationStream").value = document.getElementById("ddlGraduationStream").value;
		    }

		    function fillHiddenQualification() {
		        document.getElementById("hdQualification").value = document.getElementById("ddlQualification").value;
		        document.getElementById("hdGraduationStream").value = document.getElementById("ddlGraduationStream").value;
		        var varCheckOther;
		        var box = document.getElementById("ddlGraduationStream");
		        var varOption = document.createElement('OPTION');
		        varOption = box.options[box.selectedIndex];
		        varCheckOther = varOption.text;
		        varCheckOther = varCheckOther.toLowerCase();
		    }


		    function ChangeHeaderCheck(checkAll) {

		        var varForm = document.frmSearch;
		        var IsCheckAll = true;
		        var chkVar = checkAll.checked;
		        var varSelectedCandidateCount = parseInt(document.getElementById("hdSelectedCandidateCount").value);

		        if (chkVar) {
		            document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount + 1;
		        }
		        else {
		            document.getElementById("hdSelectedCandidateCount").value = varSelectedCandidateCount - 1;
		        }


		        for (i = 0; i < varForm.length; i++) {
		            e = varForm.elements[i];
		            if (e.type == 'checkbox' && e.name.indexOf("chkSelect") != -1) {
		                if (e.checked == false && IsCheckAll) {
		                    IsCheckAll = false;
		                    if (document.getElementById("hdHeaderCheckBox").value != "0") {
		                        document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = false;
		                        document.getElementById("chkAll").checked = false;
		                    }

		                }

		            }
		        }

		        if (IsCheckAll) {
		            if (document.getElementById("hdHeaderCheckBox").value != "0") {
		                document.getElementById(document.getElementById("hdHeaderCheckBox").value).checked = true;
		            }
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

		    function ValidateData() {
		        var varRegistrationID;
		        var varTestDateFrom;
		        var varTestDateTo;

		        var varTestState;
		        var varTestStateText;
		        var varTestCity;

		        var varDOBDateFrom;
		        var varDOBDateTo;
		        var varGender;
		        //var varEmploymentStatus;	
		        var varYearOfPassing12;
		        var varGraduationPercentageMin;
		        var varGraduationPercentageMax;
		        var varQualification;
		        var varGraduationStream;
		        var varGraduationYearOfPassing;

		        var varAnalyticalMin;
		        var varQuantitativeMin;

		        var varEWOverallMin;
		        var varEWGrammarMin;
		        var varEWContentMin;
		        var varEWVocabularyMin;
		        var varEWSpellingMin;

		        var varSLOverallMin;
		        var varSLSentenceMin;
		        var varSLVocabularyMin;
		        var varSLFluencyMin;
		        var varSLPronunciationMin;

		        var varKSTSpeedMin;
		        var varKSTAccuracyMin;

		        var varAnalyticalMax;
		        var varQuantitativeMax;

		        var varEWOverallMax;
		        var varEWGrammarMax;
		        var varEWContentMax;
		        var varEWVocabularyMax;
		        var varEWSpellingMax;

		        var varSLOverallMax;
		        var varSLSentenceMax;
		        var varSLVocabularyMax;
		        var varSLFluencyMax;
		        var varSLPronunciationMax;

		        var varKSTSpeedMax;
		        var varKSTAccuracyMax;

		        if (document.getElementById("ddlTestDayFrom").value != "0" && document.getElementById("ddlTestMonthFrom").value != "0" && document.getElementById("ddlTestYearFrom").value != "0") {
		            varTestDateFrom = document.getElementById("ddlTestDayFrom").value + "-" + document.getElementById("ddlTestMonthFrom").value + "-" + document.getElementById("ddlTestYearFrom").value;

		            if (isValidDate(varTestDateFrom) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlTestDayFrom").focus();
		                document.getElementById("ddlTestDayFrom").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {

		                document.getElementById("ddlTestDayFrom").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            varTestDateFrom = "";

		        }

		        if (document.getElementById("ddlTestDayTo").value != "0" && document.getElementById("ddlTestMonthTo").value != "0" && document.getElementById("ddlTestYearTo").value != "0") {
		            varTestDateTo = document.getElementById("ddlTestDayTo").value + "-" + document.getElementById("ddlTestMonthTo").value + "-" + document.getElementById("ddlTestYearTo").value;

		            if (isValidDate(varTestDateTo) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlTestDayTo").focus();
		                document.getElementById("ddlTestDayTo").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("ddlTestDayTo").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            varTestDateTo = "";
		        }

		        if ((document.getElementById("ddlTestDayTo").value != "0" && document.getElementById("ddlTestMonthTo").value != "0" && document.getElementById("ddlTestYearTo").value != "0") &&
			(document.getElementById("ddlTestDayFrom").value != "0" && document.getElementById("ddlTestMonthFrom").value != "0" && document.getElementById("ddlTestYearFrom").value != "0")) {
		            var varTestDateFrom = document.getElementById("ddlTestYearFrom").value + "" + document.getElementById("ddlTestMonthFrom").value + "" + document.getElementById("ddlTestDayFrom").value;
		            var varTestDateTo = document.getElementById("ddlTestYearTo").value + "" + document.getElementById("ddlTestMonthTo").value + "" + document.getElementById("ddlTestDayTo").value;

		            if (varTestDateFrom > varTestDateTo) {
		                alert("Test Date(From) cannot be greater than Test date(To) ");
		                document.getElementById("ddlTestYearFrom").focus();
		                return false;
		            }
		        }

		        if (document.getElementById("ddlDOBdayFrom").value != "0" && document.getElementById("ddlDOBmonthFrom").value != "0" && document.getElementById("ddlDOByearFrom").value != "0") {
		            varDOBDateFrom = document.getElementById("ddlDOBdayFrom").value + "-" + document.getElementById("ddlDOBmonthFrom").value + "-" + document.getElementById("ddlDOByearFrom").value;

		            if (isValidDate(varDOBDateFrom) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlDOBdayFrom").focus();
		                document.getElementById("ddlDOBdayFrom").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {

		                document.getElementById("ddlDOBdayFrom").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            varDOBDateFrom = "";

		        }

		        if (document.getElementById("ddlDOBdayTo").value != "0" && document.getElementById("ddlDOBmonthTo").value != "0" && document.getElementById("ddlDOByearTo").value != "0") {
		            varDOBDateTo = document.getElementById("ddlDOBdayTo").value + "-" + document.getElementById("ddlDOBmonthTo").value + "-" + document.getElementById("ddlDOByearTo").value;

		            if (isValidDate(varDOBDateTo) != "") {
		                alert("Please enter valid date");
		                document.getElementById("ddlDOBdayTo").focus();
		                document.getElementById("ddlDOBdayTo").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("ddlDOBdayTo").style.backgroundColor = 'white';
		            }
		        }
		        else {
		            varDOBDateTo = "";
		        }



		        if ((document.getElementById("ddlDOBdayFrom").value != "0" && document.getElementById("ddlDOBmonthFrom").value != "0" && document.getElementById("ddlDOByearFrom").value != "0") &&
		(document.getElementById("ddlDOBdayTo").value != "0" && document.getElementById("ddlDOBmonthTo").value != "0" && document.getElementById("ddlDOByearTo").value != "0")) {
		            var varDOBDateFrom = document.getElementById("ddlDOByearFrom").value + "" + document.getElementById("ddlDOBmonthFrom").value + "" + document.getElementById("ddlDOBdayFrom").value;
		            var varDOBDateTo = document.getElementById("ddlDOByearTo").value + "" + document.getElementById("ddlDOBmonthTo").value + "" + document.getElementById("ddlDOBdayTo").value;

		            if (varDOBDateFrom > varDOBDateTo) {
		                alert("Date of Birth(From) cannot be greater than Date of Birth(To) ");
		                document.getElementById("ddlDOByearFrom").focus();
		                return false;
		            }
		        }

		        varRegistrationID = document.getElementById("txtRegId").value;

		        varTestState = document.getElementById("ddlTestState").value;
		        var IndexValue = document.getElementById("ddlTestState").selectedIndex;
		        var varTestStateText = document.getElementById("ddlTestState").options[IndexValue].innerText;
		        varTestCity = document.getElementById("ddlTestCity").value;

		        varGender = document.getElementById("ddlGender").value;
		        //varEmploymentStatus = document.getElementById("ddlEmploymentStatus").value;	
		        varYearOfPassing12 = document.getElementById("ddlYearOfPassing12").value;
		        varGraduationPercentageMin = document.getElementById("txtGraduationPercentageMin").value;
		        //varGraduationPercentageMax = document.getElementById("txtGraduationPercentageMax").value;
		        varQualification = document.getElementById("ddlQualification").value;
		        varGraduationStream = document.getElementById("ddlGraduationStream").value;
		        varGraduationYearOfPassing = document.getElementById("ddlYearOfGraduation").value;

		        varAnalyticalMin = document.getElementById("txtAnalyticalMin").value;
		        varQuantitativeMin = document.getElementById("txtQuantitativeMin").value;

		        varEWOverallMin = document.getElementById("txtEWOverallMin").value;
		        varEWGrammarMin = document.getElementById("txtEWGrammarMin").value;
		        varEWContentMin = document.getElementById("txtEWContentMin").value;
		        varEWVocabularyMin = document.getElementById("txtEWVocabularyMin").value;
		        varEWSpellingMin = document.getElementById("txtEWSpellingMin").value;

		        varSLOverallMin = document.getElementById("txtSLOverallMin").value;
		        varSLSentenceMin = document.getElementById("txtSLSentenceMin").value;
		        varSLVocabularyMin = document.getElementById("txtSLVocabularyMin").value;
		        varSLFluencyMin = document.getElementById("txtSLFluencyMin").value;
		        varSLPronunciationMin = document.getElementById("txtSLPronunciationMin").value;

		        varKSTSpeedMin = document.getElementById("txtKSTSpeedMin").value;
		        varKSTAccuracyMin = document.getElementById("txtKSTAccuracyMin").value;

		        /*
		        varAnalyticalMax = document.getElementById("txtAnalyticalMax").value;
		        varQuantitativeMax = document.getElementById("txtQuantitativeMax").value;
		        varEWOverallMax = document.getElementById("txtEWOverallMax").value;
		        varEWGrammarMax = document.getElementById("txtEWGrammarMax").value;
		        varEWContentMax = document.getElementById("txtEWContentMax").value;

		        varEWSpellingMax = document.getElementById("txtEWSpellingMax").value;
		        varSLOverallMax = document.getElementById("txtSLOverallMax").value;
		        varSLSentenceMax = document.getElementById("txtSLSentenceMax").value;
		        varSLVocabularyMax = document.getElementById("txtSLVocabularyMax").value;
		        varSLFluencyMax = document.getElementById("txtSLFluencyMax").value;
		        varSLPronunciationMax = document.getElementById("txtSLPronunciationMax").value;
		        varKSTSpeedMax = document.getElementById("txtKSTSpeedMax").value;
		        varKSTAccuracyMax = document.getElementById("txtKSTAccuracyMax").value; 
		        */


		        if (varRegistrationID == "" && varTestDateFrom == "" && varTestDateTo == "" && varDOBDateFrom == "" && varDOBDateTo == "" &&
			 (varTestState == "0" && varTestStateText == "Select") && varTestCity == "0" && varGender == "Select" &&
			  varYearOfPassing12 == "0" && varGraduationPercentageMin == "" &&
		        /*  varGraduationPercentageMax==""	&&*/
			    varQualification == "0" && varGraduationStream == "0" && varGraduationYearOfPassing == "0" &&
			    varAnalyticalMin == "" && varQuantitativeMin == "" && varEWOverallMin == "" && varEWGrammarMin == "" &&
			     varEWContentMin == "" && varEWVocabularyMin == "" && varEWSpellingMin == "" && varSLOverallMin == "" && varSLSentenceMin == "" &&
			      varSLVocabularyMin == "" && varSLFluencyMin == "" && varSLPronunciationMin == "" && varKSTSpeedMin == "" &&
			       varKSTAccuracyMin == ""
		        /*   && varAnalyticalMax=="" && varQuantitativeMax=="" && varEWOverallMax=="" &&
		        varEWGrammarMax=="" && varEWContentMax==""	&& varEWVocabularyMax==""	&& varEWSpellingMax==""	&&
		        varSLOverallMax=="" && varSLSentenceMax=="" && varSLVocabularyMax=="" && varSLFluencyMax=="" &&
		        varSLPronunciationMax=="" && varKSTSpeedMax=="" && varKSTAccuracyMax=="" */
			        ) {
		            alert('Please enter a search criteria');
		            return false;
		        }
		        else {
		            var strText;
		            strText = document.getElementById("txtRegId").value;
		            if ((Trim(strText) == "" && strText.length != 0) || (strText.length > 0 && strText.length < 15)) {
		                alert("Please enter a valid RegistrationId");
		                document.getElementById("txtRegId").focus();
		                document.getElementById("txtRegId").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtRegId").style.backgroundColor = 'white';
		            }
		            /*
		            strText = document.getElementById("txt10thPercentageMin").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txt10thPercentageMin").focus();
		            document.getElementById("txt10thPercentageMin").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txt10thPercentageMin").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txt10thPercentageMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txt10thPercentageMax").focus();
		            document.getElementById("txt10thPercentageMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txt10thPercentageMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txt12thPercentageMin").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txt12thPercentageMin").focus();
		            document.getElementById("txt12thPercentageMin").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txt12thPercentageMin").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txt12thPercentageMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txt12thPercentageMax").focus();
		            document.getElementById("txt12thPercentageMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txt12thPercentageMax").style.backgroundColor = 'white';
		            }
		            */
		            strText = document.getElementById("txtGraduationPercentageMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtGraduationPercentageMin").focus();
		                document.getElementById("txtGraduationPercentageMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtGraduationPercentageMin").style.backgroundColor = 'white';
		            }

		            /*
		            strText = document.getElementById("txtGraduationPercentageMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtGraduationPercentageMax").focus();
		            document.getElementById("txtGraduationPercentageMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtGraduationPercentageMax").style.backgroundColor = 'white';
		            }
		            */

		            strText = document.getElementById("txtAnalyticalMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtAnalyticalMin").focus();
		                document.getElementById("txtAnalyticalMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtAnalyticalMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtQuantitativeMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtQuantitativeMin").focus();
		                document.getElementById("txtQuantitativeMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtQuantitativeMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWOverallMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtEWOverallMin").focus();
		                document.getElementById("txtEWOverallMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtEWOverallMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWGrammarMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtEWGrammarMin").focus();
		                document.getElementById("txtEWGrammarMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtEWGrammarMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWContentMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtEWContentMin").focus();
		                document.getElementById("txtEWContentMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtEWContentMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWVocabularyMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtEWVocabularyMin").focus();
		                document.getElementById("txtEWVocabularyMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtEWVocabularyMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWSpellingMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtEWSpellingMin").focus();
		                document.getElementById("txtEWSpellingMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtEWSpellingMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLOverallMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtSLOverallMin").focus();
		                document.getElementById("txtSLOverallMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtSLOverallMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLSentenceMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtSLSentenceMin").focus();
		                document.getElementById("txtSLSentenceMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtSLSentenceMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLVocabularyMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtSLVocabularyMin").focus();
		                document.getElementById("txtSLVocabularyMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtSLVocabularyMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLFluencyMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtSLFluencyMin").focus();
		                document.getElementById("txtSLFluencyMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtSLFluencyMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLPronunciationMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtSLPronunciationMin").focus();
		                document.getElementById("txtSLPronunciationMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtSLPronunciationMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtKSTSpeedMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtKSTSpeedMin").focus();
		                document.getElementById("txtKSTSpeedMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtKSTSpeedMin").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtKSTAccuracyMin").value;
		            if (!IsNumeric(strText)) {
		                alert("Please enter numbers only");
		                document.getElementById("txtKSTAccuracyMin").focus();
		                document.getElementById("txtKSTAccuracyMin").style.backgroundColor = 'yellow';
		                return false;
		            }
		            else {
		                document.getElementById("txtKSTAccuracyMin").style.backgroundColor = 'white';
		            }
		            /*
		            strText = document.getElementById("txtAnalyticalMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtAnalyticalMax").focus();
		            document.getElementById("txtAnalyticalMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtAnalyticalMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtQuantitativeMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtQuantitativeMax").focus();
		            document.getElementById("txtQuantitativeMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtQuantitativeMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtEWOverallMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtEWOverallMax").focus();
		            document.getElementById("txtEWOverallMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtEWOverallMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtEWGrammarMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtEWGrammarMax").focus();
		            document.getElementById("txtEWGrammarMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtEWGrammarMax").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtEWVContentMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtEWContentMax").focus();
		            document.getElementById("txtEWContentMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtEWContentMax").style.backgroundColor = 'white';
		            }
								
		            strText = document.getElementById("txtEWVocabularyMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtEWVocabularyMax").focus();
		            document.getElementById("txtEWVocabularyMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtEWVocabularyMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtEWSpellingMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtEWSpellingMax").focus();
		            document.getElementById("txtEWSpellingMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtEWSpellingMax").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtSLOverallMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtSLOverallMax").focus();
		            document.getElementById("txtSLOverallMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtSLOverallMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtSLSentenceMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtSLSentenceMax").focus();
		            document.getElementById("txtSLSentenceMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtSLSentenceMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtSLVocabularyMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtSLVocabularyMax").focus();
		            document.getElementById("txtSLVocabularyMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtSLVocabularyMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtSLFluencyMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtSLFluencyMax").focus();
		            document.getElementById("txtSLFluencyMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtSLFluencyMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtSLPronunciationMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtSLPronunciationMax").focus();
		            document.getElementById("txtSLPronunciationMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtSLPronunciationMax").style.backgroundColor = 'white';
		            }
				
		            strText = document.getElementById("txtKSTSpeedMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtKSTSpeedMax").focus();
		            document.getElementById("txtKSTSpeedMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtKSTSpeedMax").style.backgroundColor = 'white';
		            }

		            strText = document.getElementById("txtKSTAccuracyMax").value;
		            if(!IsNumeric(strText))
		            {
		            alert("Please enter numbers only");
		            document.getElementById("txtKSTAccuracyMax").focus();
		            document.getElementById("txtKSTAccuracyMax").style.backgroundColor = 'yellow';
		            return false;
		            }
		            else
		            {
		            document.getElementById("txtKSTAccuracyMax").style.backgroundColor = 'white';
		            }
		            */
		            return true;
		        }
		    }
		
		</script>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="frmSearch" method="post" runat="server">
			<INPUT id="hdCentre" value="0" type="hidden" name="hdCentre" runat="server"> <input id="hdCity" value="0" type="hidden" name="hdCity" runat="server">
			<INPUT id="hdState" value="0" type="hidden" name="hdState" runat="server">
			
				<!--<table id="table1" border="0" cellSpacing="0" cellPadding="0">
					<tr>
						<td>
							<table id="Table_01" border="0" cellSpacing="0" cellPadding="0" width="888">
								<tr>
									<td style="WIDTH: 918px" vAlign="top"><IMG src="../Web/Images/BANNER.jpg" width="942" height="124"></td>
								</tr>


-->
 <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headermenu1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">

                <table id="table6" border="0" cellSpacing="0" cellPadding="0">
								


								<tr>
									<td style="WIDTH: 919px; HEIGHT: 18px" vAlign="top" align="center">



										<table id="table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td vAlign="top">
													<table id="table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td vAlign="top" width="20%">
																<fieldset align="left"><legend class="main_black_bold">Test Details</legend>
																	<table id="table4" border="0" cellSpacing="1" cellPadding="1" width="100%" height="90">
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td style="WIDTH: 128px" width="128">NAC Reg ID:</td>
																			<td colSpan="2"><asp:textbox id="txtRegId" runat="server" MaxLength="15" CssClass="txtbox"></asp:textbox></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td style="WIDTH: 128px" width="128">Test Date:</td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td style="WIDTH: 128px" rowSpan="2" width="128" align="right">&nbsp;</td>
																			<td>From:<!-- Start From Date --></td>
																			<td><asp:dropdownlist id="ddlTestDayFrom" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestMonthFrom" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestYearFrom" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td>To:</td>
																			<td><asp:dropdownlist id="ddlTestDayTo" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestMonthTo" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlTestYearTo" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																</fieldset>
															</td>
														</tr>
                                                        <tr>
															<td height="42">&nbsp;</td>
														</tr>
													</table>
													<table id="table8" border="0" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                height="100%">
                                                <tr class="main_black_small" valign="top" align="left">
                                                    <td valign="top" width="20%">
                                                        <fieldset align="left">
                                                            <legend class="main_black_bold">Test Locations</legend>
                                                            <table id="table9" border="0" cellspacing="1" cellpadding="1" width="100%" height="49">
                                                                <tr class="main_black_small" valign="top" align="left">
                                                                    <td width="90" align="left">
                                                                        Test State:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlTestState" runat="server" CssClass="txtbox">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr class="main_black_small" valign="top" align="left">
                                                                    <td width="90" align="left">
                                                                        Test City:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlTestCity" runat="server" CssClass="txtbox">
                                                                        </asp:DropDownList>
                                                                       <%-- <asp:DropDownList ID="ddlTestCentre" runat="server" CssClass="txtbox">
                                                                        </asp:DropDownList>--%>
                                                                    </td>
                                                                </tr>

                                                                <tr class="main_black_small" valign="top" align="left">
                                                                    <td width="90" align="left">
                                                                        Test Centre:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:DropDownList ID="ddlTestCentre" runat="server" CssClass="txtbox">
                                                                        </asp:DropDownList>
                                                                     
                                                                    </td>
                                                                </tr>


                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                            </table>
													<table id="tblSpace" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td height="42">&nbsp;
															</td>
														</tr>
													</table>
													<table id="table10" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center"
														height="100%">
														<tr class="main_black_small" vAlign="top" align="left">
															<td width="28%">
																<fieldset align="left"><legend class="main_black_bold">Personal/Educational Details</legend>
																	<table id="table11" border="0" cellSpacing="1" cellPadding="1" width="100%" height="15">
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td>Date Of Birth:</td>
																		</tr>
																		<TR class="main_black_small" vAlign="top" align="left">
																			<TD style="PADDING-RIGHT: 5px" align="right">From:</TD>
																			<TD colSpan="2" align="left"><asp:dropdownlist id="ddlDOBdayFrom" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlDOBmonthFrom" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlDOByearFrom" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																		</TR>
																		<TR class="main_black_small" vAlign="top">
																			<TD style="PADDING-RIGHT: 5px" align="right">To:</TD>
																			<TD colSpan="2" align="left"><asp:dropdownlist id="ddlDOBdayTo" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlDOBmonthTo" CssClass="txtarea" Runat="server">
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
																				</asp:dropdownlist><asp:dropdownlist id="ddlDOByearTo" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																		</TR>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">Gender:</td>
																			<td colSpan="2" align="left"><asp:dropdownlist id="ddlGender" runat="server" CssClass="txtbox">
																					<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
																					<asp:ListItem Value="M">Male</asp:ListItem>
																					<asp:ListItem Value="F">Female</asp:ListItem>
																				</asp:dropdownlist></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">Year of Passing 12th:
																			</td>
																			<td colSpan="2" align="left"><asp:dropdownlist id="ddlYearOfPassing12" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				</asp:dropdownlist></td>
																		</tr>
																		<!--<tr style="VISIBILITY: hidden" class="main_black_small" vAlign="top" align="left">
																			<td align="left">10th Percentage:
																			</td>
																			<td align="left">Min:<asp:textbox id="txt10thPercentageMin" CssClass="txtbox" MaxLength="2" Runat="server" Width="50px"></asp:textbox></td>
																			&nbsp;
																			<td>Max:<asp:textbox id="txt10thPercentageMax" CssClass="txtbox" MaxLength="2" Runat="server" Width="50px"></asp:textbox></td>
																		</tr> 
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">12th Percentage:
																			</td>
																			<td align="left">Min:<asp:textbox id="txt12thPercentageMin" CssClass="txtbox" MaxLength="2" Runat="server" Width="50px"></asp:textbox></td>
																			&nbsp;
																			<td>Max:<asp:textbox id="txt12thPercentageMax" CssClass="txtbox" MaxLength="2" Runat="server" Width="50px"></asp:textbox></td>
																		</tr>-->
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">Graduation/PG Percentage:
																			</td>
																			<td align="left">Min:<asp:textbox id="txtGraduationPercentageMin" MaxLength="3" CssClass="txtbox_Small" Runat="server"
																					Width="50px"></asp:textbox></td>
																			&nbsp;
																			<td style="VISIBILITY: hidden">Max:<asp:textbox id="txtGraduationPercentageMax" MaxLength="2" CssClass="txtbox" Runat="server" Width="50px"></asp:textbox></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<TD align="left">Qualification Type</TD>
																			<TD colSpan="2" align="left"><asp:dropdownlist id="ddlQualification" runat="server" CssClass="txtbox"></asp:dropdownlist><INPUT id="hdQualification" value="0" type="hidden" name="hdQualification" runat="server"><INPUT id="hdGraduationStream" value="0" type="hidden" name="hdGraduationStream" runat="server"></TD>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">Graduation/PG&nbsp;Stream:
																			</td>
																			<td colSpan="2" align="left"><asp:dropdownlist id="ddlGraduationStream" runat="server" CssClass="txtbox"></asp:dropdownlist></td>
																		</tr>
																		<tr class="main_black_small" vAlign="top" align="left">
																			<td align="left">Year&nbsp;of&nbsp;Graduation/PG:
																			</td>
																			<td colSpan="2" align="left"><asp:dropdownlist id="ddlYearOfGraduation" CssClass="txtarea" Runat="server">
																					<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
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
																				</asp:dropdownlist></td>
																		</tr>
																	</table>
																</fieldset>
															</td>
														</tr>
													</table>
													<table id="table14" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td>&nbsp;</td>
														</tr>
														<tr>
															<td>&nbsp;</td>
														</tr>
													</table>
												</td>
												<td width="10">&nbsp;
												</td>
												<TD style="WIDTH: 49%" vAlign="top" rowSpan="4">
													<fieldset align="left"><legend class="main_black_bold">NAC Scores
														</legend>
														<table id="table5" border="0" cellSpacing="1" cellPadding="1" width="100%" height="110">
															<tr class="main_black_small" vAlign="top" align="left">
																<td align="center">&nbsp;</td>
																<td align="center">Score Range</td>
																<td style="VISIBILITY: hidden" align="center"></td>
																<td align="center">Min</td>
															</tr>
															<tr class="main_black" align="left">
																<td style="FONT-WEIGHT: bold" align="left">Analytical Ability:</td>
																<td class="main_black_small" align="center">0-16</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtAnalyticalMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtAnalyticalMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black" align="left">
																<td style="FONT-WEIGHT: bold" align="left">Quantitative Ability:</td>
																<td class="main_black_small" align="center">0-16</td>
																<td style="VISIBILITY: hidden" align="center">-</td>
																<td align="center"><asp:textbox id="txtQuantitativeMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtQuantitativeMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></td>
															</tr>
															<TR class="main_black" align="left">
																<td style="FONT-WEIGHT: bold" align="left">English Writing:</td>
																<td class="main_black_small" align="center">0-20</td>
																<td style="VISIBILITY: hidden" align="center">-</td>
																<td align="center"><asp:textbox id="txtEWOverallMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtEWOverallMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></td>
															</TR>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Grammar:</td>
																<td class="main_black_small" align="center">0-5</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtEWGrammarMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtEWGrammarMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Content:</td>
																<td class="main_black_small" align="center">0-6</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtEWContentMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtEWContentMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Vocabulary:</td>
																<td class="main_black_small" align="center">0-5</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtEWVocabularyMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtEWVocabularyMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Spelling &amp; Punctuation:</td>
																<td class="main_black_small" align="center">0-4</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtEWSpellingMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtEWSpellingMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<TR class="main_black" align="left">
																<td style="FONT-WEIGHT: bold" align="left">Speaking &amp; Listening:</td>
																<td class="main_black_small" align="center">20-80</td>
																<td style="VISIBILITY: hidden" align="center">-</td>
																<td align="center"><asp:textbox id="txtSLOverallMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtSLOverallMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></td>
															</TR>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Sentence Mastery:</td>
																<td class="main_black_small" align="center">20-80</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtSLSentenceMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtSLSentenceMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Vocabulary:</td>
																<td class="main_black_small" align="center">20-80</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtSLVocabularyMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtSLVocabularyMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Fluency:</td>
																<td class="main_black_small" align="center">20-80</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtSLFluencyMin" runat="server" MaxLength="2" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtSLFluencyMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Pronunciation:</td>
																<td class="main_black_small" align="center">20-80</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtSLPronunciationMin" runat="server" MaxLength="2" CssClass="txtbox_Small"
																		Width="50px"></asp:textbox><asp:textbox id="txtSLPronunciationMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<TR class="main_black" align="left">
																<td style="FONT-WEIGHT: bold" colSpan="2" align="left">Keyboard Skills:</td>
																<td align="center"></td>
																<td align="center"></td>
															</TR>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Typing Speed (WPM):</td>
																<td class="main_black_small" align="center">-</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtKSTSpeedMin" runat="server" MaxLength="3" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtKSTSpeedMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
															<tr class="main_black_small" align="left">
																<td align="left">&nbsp;&nbsp;Typing Accuracy (%age):</td>
																<td class="main_black_small" align="center">-</td>
																<TD style="VISIBILITY: hidden" align="center">-</TD>
																<TD align="center"><asp:textbox id="txtKSTAccuracyMin" runat="server" MaxLength="3" CssClass="txtbox_Small" Width="50px"></asp:textbox><asp:textbox id="txtKSTAccuracyMax" runat="server" MaxLength="2" CssClass="txtbox" Width="50px"
																		Visible="False"></asp:textbox></TD>
															</tr>
														</table>
													</fieldset>
												</TD>
											</tr>
											<tr>
												<td vAlign="top">&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
								<TR class="main_black_small" vAlign="top" align="left">
									<TD style="WIDTH: 918px" vAlign="top" width="918" align="center">
                                        <asp:button id="btnSearch" runat="server" CssClass="btn2" 
                                            EnableViewState="False" Text="Search"
											CommandArgument="Submit" onclick="btnSearch_Click"></asp:button>&nbsp;
										<asp:button id="btnReset" runat="server" CssClass="btn2" 
                                            EnableViewState="False" Text="Reset" onclick="btnReset_Click"></asp:button>&nbsp;
										<asp:button id="btnBack" runat="server" CssClass="btn2" EnableViewState="False" 
                                            Text="Back" onclick="btnBack_Click"></asp:button>&nbsp;
									</TD>
								</TR>
								<tr class="main_black_small" align="left">
									<td style="WIDTH: 918px" align="right"></td>
								</tr>
								<tr id="trChkAll" class="small_maroon" height="25" align="center">
									<td style="WIDTH: 918px" width="918" align="left">&nbsp;
										<asp:checkbox id="chkAll" onclick="CheckAllCandidate(); DeselectAll();" CssClass="chkbox" Runat="server"
											Text="Select All" Font-Bold="True" AutoPostBack="True" oncheckedchanged="btnDeselectAll_Click"></asp:checkbox><asp:button id="btnDeselectAll" Runat="server" Width="1px" Visible="False" Height="1px"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="lblTotalRecord" runat="server"></asp:label><INPUT id="hdHeaderCheckBox" value="0" type="hidden" name="hdHeaderCheckBox" runat="server"><INPUT id="hdTotalCandidateCount" value="0" type="hidden" name="hdTotalCandidateCount"
											runat="server">
										<asp:button id="Button1" Runat="server" Width="1px" Visible="False" Height="1px"></asp:button></td>
								</tr>
								<tr class="main_black_small" align="center">
									<td style="WIDTH: 918px"><asp:panel id="pnlSearch" Runat="server">
											<asp:datagrid id="dgSearch" runat="server" CssClass="main_black_small" Width="100%" Height="100%"
												GridLines="Vertical" CellPadding="3" BackColor="White" OnItemCreated="dgSearch_ItemCreated"
												OnItemCommand="dgSearch_ItemCommand" OnItemDataBound="dgSearch_ItemDataBound" OnPageIndexChanged="dgSearch_PageIndexChanged"
												BorderWidth="1px" BorderStyle="None" BorderColor="#999999" AutoGenerateColumns="False" OnSortCommand="dgSearch_SortCommand"
												ShowFooter="True" AllowSorting="True">
												<FooterStyle ForeColor="Blue" BackColor="White"></FooterStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<Columns>
													<asp:TemplateColumn>
														<HeaderTemplate>
															<asp:CheckBox ID="chkHeader" CssClass="chkbox" onclick="CheckAll(this);" Runat="server"></asp:CheckBox>
														</HeaderTemplate>
														<ItemTemplate>
															<asp:Checkbox ID="chkSelect" Checked="False" onclick="ChangeHeaderCheck(this);" Runat="server"></asp:Checkbox>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn SortExpression="RegistrationId ASC" HeaderText="Registration Id">
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
											<INPUT id="hdSelectedCandidateCount" type="hidden" value="0" name="hdSelectedCandidateCount"
												runat="server">
										</asp:panel><INPUT id="Hidden1" value="0" type="hidden" name="hdSelectedCandidateCount" runat="server"></td>
								</tr>
								<tr class="small_maroon" align="center">
									<td style="WIDTH: 918px" align="center"><asp:panel id="pnlMessage" Runat="server" HorizontalAlign="Center">
											<asp:Label id="lblMessage" CssClass="small_maroon" Runat="server" Visible="True" Text="NO RECORDS FOUND!"
												Font-Bold="True" ForeColor="red"></asp:Label>
										</asp:panel></td>
								</tr>
							
						
					<tr>
						<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
					</tr>
					<tr>
						<td vAlign="top" align="center"></td>
					</tr>
					<tr>
						<td align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnScoreCard" 
                                runat="server" CssClass="btn2" Text="Score Card" onclick="btnScoreCard_Click"></asp:button>&nbsp;<asp:button 
                                id="btnExportToExcel" runat="server" CssClass="btn2" Text="Export To Excel" 
                                onclick="btnExportToExcel_Click"></asp:button>&nbsp;
							<asp:label id="lblSortExp" runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
						<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
					</tr>
                    </TABLE>

               <div class="footer">  <img src="../Web/Images/footer2014.gif" />
               
               </div>

            </div>
					
		</FORM>
		
	</BODY>
</HTML>
