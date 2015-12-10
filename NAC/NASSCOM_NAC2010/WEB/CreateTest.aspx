<%@ Page language="c#" Codebehind="CreateTest.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.Web.CreateTest" %>
<%@ Register TagPrefix="uc1" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Create Test</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
		<LINK href="../Web/Stylesheet/nasscomNew.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../Web/js/common.js"></SCRIPT>
		<SCRIPT language="javascript" src="js/datetimepicker_css.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		function ShowHideShift()
		{
		    //if (document.frmCreateTest.chkIsShiftTime.checked == true)
		    if (document.getElementById("chkIsShiftTime").checked == true)
			{
				document.getElementById('trShiftDetails').style.display='';
			}
			else
			{
				document.getElementById('ddlAddShift').value=0;
				document.getElementById('trShiftDetails').style.display='none';
				document.getElementById('trShift1').style.display='none';
				document.getElementById('trShift2').style.display='none';
				document.getElementById('trShift3').style.display='none';
				document.getElementById('trShift4').style.display='none';	
				document.getElementById('trShift5').style.display='none';	
				document.getElementById('trShift6').style.display='none';	
				document.getElementById('trShift7').style.display='none';	
				document.getElementById('trShift8').style.display='none';
				document.getElementById('trShift9').style.display='none';
				document.getElementById('trShift10').style.display='none';
				document.getElementById('trShift11').style.display='none';
				document.getElementById('trShift12').style.display='none';
				document.getElementById('trShift13').style.display='none';
				document.getElementById('trShift14').style.display='none';
				document.getElementById('trShift15').style.display='none';
				document.getElementById('trShift16').style.display='none';
				document.getElementById('trShift17').style.display='none';
				document.getElementById('trShift18').style.display='none';
				document.getElementById('trShift19').style.display='none';
				document.getElementById('trShift20').style.display='none';
				document.getElementById('trShift21').style.display='none';
				document.getElementById('trShift22').style.display='none';
				document.getElementById('trShift23').style.display='none';
				document.getElementById('trShift24').style.display='none';
				document.getElementById('trShift25').style.display='none';
			}
		}

		function ShowHideShiftDetails() {
		    var count;
		    count = document.getElementById('ddlAddShift').value;
		    switch (count) {
		        case '1':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = 'none';
		            document.getElementById('trShift3').style.display = 'none';
		            document.getElementById('trShift4').style.display = 'none';
		            document.getElementById('trShift5').style.display = 'none';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '2':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = 'none';
		            document.getElementById('trShift4').style.display = 'none';
		            document.getElementById('trShift5').style.display = 'none';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '3':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = 'none';
		            document.getElementById('trShift5').style.display = 'none';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '4':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = 'none';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '5':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '6':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '7':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '8':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '9':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '10':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '11':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '12':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '13':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '14':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '15':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '16':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '17':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '18':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '19':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '20':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '21':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = '';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '22':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = '';
		            document.getElementById('trShift22').style.display = '';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '23':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = '';
		            document.getElementById('trShift22').style.display = '';
		            document.getElementById('trShift23').style.display = '';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '24':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = '';
		            document.getElementById('trShift22').style.display = '';
		            document.getElementById('trShift23').style.display = '';
		            document.getElementById('trShift24').style.display = '';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		        case '25':
		            document.getElementById('trShift1').style.display = '';
		            document.getElementById('trShift2').style.display = '';
		            document.getElementById('trShift3').style.display = '';
		            document.getElementById('trShift4').style.display = '';
		            document.getElementById('trShift5').style.display = '';
		            document.getElementById('trShift6').style.display = '';
		            document.getElementById('trShift7').style.display = '';
		            document.getElementById('trShift8').style.display = '';
		            document.getElementById('trShift9').style.display = '';
		            document.getElementById('trShift10').style.display = '';
		            document.getElementById('trShift11').style.display = '';
		            document.getElementById('trShift12').style.display = '';
		            document.getElementById('trShift13').style.display = '';
		            document.getElementById('trShift14').style.display = '';
		            document.getElementById('trShift15').style.display = '';
		            document.getElementById('trShift16').style.display = '';
		            document.getElementById('trShift17').style.display = '';
		            document.getElementById('trShift18').style.display = '';
		            document.getElementById('trShift19').style.display = '';
		            document.getElementById('trShift20').style.display = '';
		            document.getElementById('trShift21').style.display = '';
		            document.getElementById('trShift22').style.display = '';
		            document.getElementById('trShift23').style.display = '';
		            document.getElementById('trShift24').style.display = '';
		            document.getElementById('trShift25').style.display = '';
		            break;
		        default:
		            document.getElementById('trShift1').style.display = 'none';
		            document.getElementById('trShift2').style.display = 'none';
		            document.getElementById('trShift3').style.display = 'none';
		            document.getElementById('trShift4').style.display = 'none';
		            document.getElementById('trShift5').style.display = 'none';
		            document.getElementById('trShift6').style.display = 'none';
		            document.getElementById('trShift7').style.display = 'none';
		            document.getElementById('trShift8').style.display = 'none';
		            document.getElementById('trShift9').style.display = 'none';
		            document.getElementById('trShift10').style.display = 'none';
		            document.getElementById('trShift11').style.display = 'none';
		            document.getElementById('trShift12').style.display = 'none';
		            document.getElementById('trShift13').style.display = 'none';
		            document.getElementById('trShift14').style.display = 'none';
		            document.getElementById('trShift15').style.display = 'none';
		            document.getElementById('trShift16').style.display = 'none';
		            document.getElementById('trShift17').style.display = 'none';
		            document.getElementById('trShift18').style.display = 'none';
		            document.getElementById('trShift19').style.display = 'none';
		            document.getElementById('trShift20').style.display = 'none';
		            document.getElementById('trShift21').style.display = 'none';
		            document.getElementById('trShift22').style.display = 'none';
		            document.getElementById('trShift23').style.display = 'none';
		            document.getElementById('trShift24').style.display = 'none';
		            document.getElementById('trShift25').style.display = 'none';
		            break;
		    }
		}
		
		function new_window(url)
		{
			newwindow=window.open(url,'Feedback','top=50,left=200,width=500,height=400,scrollbars=no');
			newwindow.focus();
		}
		
		function FillHiddenField()
		{
			document.getElementById("hdState").value = document.getElementById("ddlTestState").value;
			document.getElementById("hdCity").value = document.getElementById("ddlTestCity").value;
			document.getElementById("hdCentre").value = document.getElementById("ddlTestCentre").value;			
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
		    
			function ValidateData()
		{
		  
				var strText;

				strText = document.getElementById("ddlTestState").value;
				if(strText == 0)
				{
					alert("Please select Test State");
					document.getElementById("ddlTestState").focus();
					document.getElementById("ddlTestState").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestState").style.backgroundColor = 'white';
				}			
				 
				strText = document.getElementById("ddlTestCity").value;
				if(strText == 0)
				{
					alert("Please select Test City");
					document.getElementById("ddlTestCity").focus();
					document.getElementById("ddlTestCity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCity").style.backgroundColor = 'white';
				}		
				
				strText = document.getElementById("ddlTestCentre").value;
				if(strText == 0)
				{
					alert("Please select Test Centre");
					document.getElementById("ddlTestCentre").focus();
					document.getElementById("ddlTestCentre").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("ddlTestCentre").style.backgroundColor = 'white';
				}		
				
				strText = document.getElementById("txtCentreCapacity").value;
				if(strText == '')
				{
					alert("Please enter centre capacity");
					document.getElementById("txtCentreCapacity").focus();
					document.getElementById("txtCentreCapacity").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCentreCapacity").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtTestDateTime").value;
				if(strText == 0)
				{
					alert("Please select Test DateTime");
					document.getElementById("txtTestDateTime").focus();
					document.getElementById("txtTestDateTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtTestDateTime").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtTestName").value;
				if(strText == '')
				{
					alert("Please enter test name");
					document.getElementById("txtTestName").focus();
					document.getElementById("txtTestName").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtTestName").style.backgroundColor = 'white';
				}
			
				//added by ankit for registration start date/time
				
				strText = document.getElementById("txtRegStartDateTime").value;
				if(strText == 0)
				{
					alert("Please select Registration Start DateTime");
					document.getElementById("txtRegStartDateTime").focus();
					document.getElementById("txtRegStartDateTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					var regStartDate = new Date(document.getElementById("txtRegStartDateTime").value);
					var testDate = new Date(document.getElementById("txtTestDateTime").value);
					
					if(regStartDate > testDate)
					{
						alert("Registration Start DateTime cannot be greater than Test DateTime");
						document.getElementById("txtRegStartDateTime").focus();
						document.getElementById("txtRegStartDateTime").style.backgroundColor = 'yellow';
						return false;
					}
					else
						document.getElementById("txtRegStartDateTime").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtRegEndDateTime").value;
				if(strText == 0)
				{
					alert("Please select Registration End DateTime");
					document.getElementById("txtRegEndDateTime").focus();
					document.getElementById("txtRegEndDateTime").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					var regStartDate = new Date(document.getElementById("txtRegStartDateTime").value);
					var regEndDate = new Date(document.getElementById("txtRegEndDateTime").value);
					var testDate = new Date(document.getElementById("txtTestDateTime").value);
					
					if(regEndDate > testDate)
					{
						alert("Registration End DateTime cannot be greater than Test DateTime");
						document.getElementById("txtRegEndDateTime").focus();
						document.getElementById("txtRegEndDateTime").style.backgroundColor = 'yellow';
						return false;
					}
					
					else if(regEndDate < regStartDate)
					{
						alert("Registration End DateTime cannot be lesser than Registration  Start DateTime");
						document.getElementById("txtRegEndDateTime").focus();
						document.getElementById("txtRegEndDateTime").style.backgroundColor = 'yellow';
						return false;
					}
					else
						document.getElementById("txtRegEndDateTime").style.backgroundColor = 'white';
	}


	            if (document.getElementById("chkIsShiftTime").checked == true)
			   //if(document.frmCreateTest.chkIsShiftTime.checked == true)
				{
					strText = document.getElementById('ddlAddShift').value;
					if(strText==0)
					{
						alert('Please select number of shifts');
						document.getElementById("ddlAddShift").focus();
						document.getElementById("ddlAddShift").style.backgroundColor = 'yellow';
						return false;
					}
					else
					{
						document.getElementById("ddlAddShift").style.backgroundColor = 'white';
						var count=0;
						count = document.getElementById('ddlAddShift').value;
						for(var i=1; i<=count; i++)
						{
							if(document.getElementById('txtCapacity'+i).value=="")
							{
								alert('Please select shift capacity');
								document.getElementById("txtCapacity"+i).focus();
								document.getElementById("txtCapacity"+i).style.backgroundColor = 'yellow';
								return false;
							}
							else if(!IsNumeric(document.getElementById('txtCapacity'+i).value))
							{
								alert('Please enter numeric value only');
								document.getElementById('txtCapacity'+i).value=""
								document.getElementById("txtCapacity"+i).focus();
								document.getElementById("txtCapacity"+i).style.backgroundColor = 'yellow';
								return false;
							}
							else
							{
								document.getElementById("txtCapacity"+i).style.backgroundColor = 'white';
							}
						}
						
						var testDate = new Date(document.getElementById("txtTestDateTime").value);
						for(var j=1; j<=count; j++)
						{
							var shiftDate = new Date(document.getElementById('txtShiftTime'+j).value);
							if(document.getElementById('txtShiftTime'+j).value == '')
							{
								alert('Shift DateTime cannot be blank');
								document.getElementById('txtShiftTime'+j).focus();
								document.getElementById('txtShiftTime'+j).style.backgroundColor = 'yellow';
								return false;								
							}
							
							
							else if(shiftDate < testDate)
							{
								alert('Shift DateTime cannot be less than Test DateTime');
								document.getElementById('txtShiftTime'+j).focus();
								document.getElementById('txtShiftTime'+j).style.backgroundColor = 'yellow';
								return false;								
							}
							else
							{
								document.getElementById('txtShiftTime'+j).style.backgroundColor = 'white';
							}
							for(var i=j+1; i<=count; i++)
							{
									if(document.getElementById('txtShiftTime'+j).value == document.getElementById('txtShiftTime'+i).value)
									{
										alert('Shifts DateTime cannot be same');
										document.getElementById('txtShiftTime'+j).focus();
										document.getElementById('txtShiftTime'+i).style.backgroundColor = 'yellow';
										document.getElementById('txtShiftTime'+j).style.backgroundColor = 'yellow';
										return false;								
									}
									else
									{
										document.getElementById('txtShiftTime'+i).style.backgroundColor = 'white';
										document.getElementById('txtShiftTime'+j).style.backgroundColor = 'white';
									}
							}
							
						}
					}
				}
				//return true;
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmCreateTest" method="post" runat="server">
			<div align="center">
				<table id="table1" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td>
							<table id="Table_01" cellSpacing="0" cellPadding="0" width="888" border="0">
								<tr>
									<td rowSpan="10">&nbsp;</td>
									<td vAlign="top"><IMG height="124" src="../Web/Images/BANNER.jpg" width="942"></td>
									<td width="4" rowSpan="10">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top">&nbsp;&nbsp; <A class="link" style="WIDTH: 0%; HEIGHT: 14px" href="Welcome.aspx">
											Home</A>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
									</td>
								</tr>
								<tr>
									<td vAlign="top">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        	<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="680" align="center" border="1">
												<TR>
													<TD align="center" colSpan="3"><STRONG><FONT size="4">
																<asp:label id="Label4" runat="server" CssClass="pageheader">Create Test</asp:label></FONT></STRONG></TD>
												</TR>
												<TR>
													<TD align="left" width="30%"></TD>
													<TD width="70%" colSpan="2">
														<asp:Label id="lblErrorMsg" runat="server" CssClass="errarea"></asp:Label></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD align="left" width="30%">Test State:<FONT class="small_maroon">*</FONT></TD>
													<TD width="70%" colSpan="2">
														<asp:dropdownlist id="ddlTestState" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestState_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD align="left" width="30%">Test City:<FONT class="small_maroon">*</FONT></TD>
													<TD colSpan="2">
														<asp:dropdownlist id="ddlTestCity" runat="server" CssClass="txtbox" AutoPostBack="True" onselectedindexchanged="ddlTestCity_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
														<asp:Button id="btnSaveEditCity" runat="server" Text="Add/Edit" onclick="btnSaveEditCity_Click"></asp:Button>
														<asp:Label id="lblErrorCity" runat="server" CssClass="errarea"></asp:Label></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD align="left" width="30%">Test Centre:<FONT class="small_maroon">*</FONT></TD>
													<TD colSpan="2">
														<asp:dropdownlist id="ddlTestCentre" runat="server" CssClass="txtbox"></asp:dropdownlist>&nbsp;
														<asp:Button id="btnSaveEditCentre" runat="server" Text="Add/Edit" onclick="btnSaveEditCentre_Click"></asp:Button>
														<asp:Label id="lblErrorCentre" runat="server" CssClass="errarea"></asp:Label></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Centre&nbsp;Capacity:<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:textbox id="txtCentreCapacity" runat="server" CssClass="smallTextBox" MaxLength="4"></asp:textbox></TD>
												</TR>
												<TR class="small_maroon" id="trCentreDetails" align="left" runat="server">
													<TD width="30%">&nbsp;</TD>
													<TD>Capacity:
														<asp:Label id="lblCentreCapacity" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 
														Registered Count:
														<asp:Label id="lblCentreRegCount" runat="server"></asp:Label></TD>
												</TR>
												<TR align="left">
													<TD class="main_black" style="WIDTH: 30%" align="left" width="30%">Test Type:<FONT class="small_maroon">*
														</FONT>
													</TD>
													<TD>
														<asp:RadioButtonList id="rbtnlstTestType" runat="server" Width="88px" CssClass="main_black" RepeatDirection="Horizontal">
															<asp:ListItem Value="0" Selected="True">Final</asp:ListItem>
															<asp:ListItem Value="1">Diagnostic</asp:ListItem>
														</asp:RadioButtonList></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Test Date:<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:TextBox id="txtTestDateTime" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtTestDateTime','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif">
													</TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Activity Name:<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:textbox id="txtTestName" runat="server"></asp:textbox></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Registration Start Date:<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:TextBox id="txtRegStartDateTime" runat="server" Width="120px" 
                                                            MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtRegStartDateTime','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif">
													</TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Registration End Date:<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:TextBox id="txtRegEndDateTime" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtRegEndDateTime','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif">
													</TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%" align="left" width="30%">Click if Multiple Shifts:</TD>
													<TD>
														<asp:checkbox id="chkIsShiftTime" runat="server"></asp:checkbox></TD>
												</TR>
												<TR class="main_black" id="trShiftDetails" align="left" runat="server">
													<TD style="WIDTH: 30%" align="left" width="30%">No. of shifts<FONT class="small_maroon">*</FONT></TD>
													<TD>
														<asp:DropDownList id="ddlAddShift" runat="server">
															<asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9">9</asp:ListItem>
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
														</asp:DropDownList></TD>
												</TR> <!--	<TR id="Tr1" runat="server">
												<TD style="WIDTH: 263px" align="left" width="263">&nbsp;</TD>
												<TD class="main_black" width="30%">Shift DateTime:<FONT class="small_maroon">*</FONT>
													<asp:TextBox id="Textbox4" runat="server" Width="120px" ReadOnly="true" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('Textbox4','MMddyyyy','arrow',true,'24')"
														src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
													<asp:TextBox id="Textbox3" runat="server" Width="50px" MaxLength="3"></asp:TextBox></TD>
											</TR> -->
												<TR id="trShift1" runat="server">
													<TD align="left" width="30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime1" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime1','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity1" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift2" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black" style="WIDTH: 20%">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime2" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime2','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity2" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift3" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime3" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime3','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity3" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift4" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime4" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime4','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity4" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift5" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime5" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime5','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity5" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift6" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime6" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime6','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity6" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift7" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime7" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime7','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity7" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift8" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime8" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime8','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity8" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift9" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime9" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime9','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity9" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift10" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime10" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime10','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity10" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift11" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime11" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime11','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity11" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift12" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime12" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime12','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity12" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift13" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime13" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime13','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity13" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift14" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime14" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime14','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity14" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift15" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime15" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime15','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity15" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift16" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime16" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime16','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity16" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift17" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime17" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime17','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity17" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift18" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime18" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime18','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity18" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift19" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime19" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime19','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity19" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift20" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime20" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime20','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity20" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift21" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime21" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime21','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity21" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift22" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime22" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime22','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity22" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift23" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime23" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime23','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity23" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift24" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime24" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime24','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity24" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR id="trShift25" runat="server">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD class="main_black">Shift DateTime:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtShiftTime25" runat="server" Width="120px" MaxLength="25"></asp:TextBox>&nbsp;<IMG style="CURSOR: pointer" onclick="javascript:NewCssCal('txtShiftTime25','MMddyyyy','arrow',true,'24')"
															src="images/cal.gif"> &nbsp; Capacity:<FONT class="small_maroon">*</FONT>
														<asp:TextBox id="txtCapacity25" runat="server" CssClass="smallTextBox" MaxLength="3"></asp:TextBox></TD>
												</TR>
												<TR class="main_black" align="left">
													<TD style="WIDTH: 30%">&nbsp;</TD>
													<TD width="70%">
														<asp:button id="btnSubmit" runat="server" Text="Submit" Font-Size="Larger" onclick="btnSubmit_Click"></asp:button></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="3"></TD>
												</TR>
											</TABLE>
                                        </ContentTemplate>
                                        <Triggers>
                                        
                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                                        
                                        </Triggers>
                                        </asp:UpdatePanel>
									</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										
										</td>
								</tr>
								<tr>
									<td style="HEIGHT: 20px" vAlign="top">&nbsp;</td>
								</tr>
								<tr>
									<td vAlign="top" align="center">
										<DIV class="landingFooter">
                                         <tr><td valign="top" align="center">
                                        <uc1:nacyearlyfooter  ID="nacyearlyfooter" runat="server"></uc1:nacyearlyfooter> 
									    </td></tr>
											<%--<DIV class="divLeft"><IMG src="../WEB/Images/footerDB.jpg"><A href="mailto:nac@nasscom.in"></A></DIV>--%>
										</DIV>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
