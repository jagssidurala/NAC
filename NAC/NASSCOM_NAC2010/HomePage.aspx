<%@ Register TagPrefix="uc1" TagName="nac_headermenu" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Page Language="C#" ClientTarget="uplevel" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="NASSCOM_NAC.HomePageV2" %>
<%@ Register TagPrefix="uc2" TagName="nacyearlyfooter" Src="~/Web/Controls/nacyearlyfooter.ascx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>NAC</title>
    <link href="Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />
    <LINK href="Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
    <!--[if IE]>
<link href="resources/styleIE.css" type="text/css" rel="stylesheet" />
<![endif]-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">
    </script>
    <script>
        var bpPopup;
         function popUp(url, width, height) {

             bpPopup = window.open(url, "bpPopup", 'top=300,left=210, width=400,height=150,scrollbars=no');
            bpPopup.focus();

        }



        $(document).ready(function () {
            $("#arrow1").click(function () {
                $("#candidate").slideDown("slow");
                $("#company").slideUp("slow");
                $("#college").slideUp("slow");
                $("#arrowimg1").attr("src", "Web/Images/tabarrowdup.jpg");
                $("#arrowimg2").attr("src", "Web/Images/tabarrowdown.jpg");
                $("#arrowimg3").attr("src", "Web/Images/tabarrowdown.jpg");
            });

            $("#arrow2").click(function () {
                $("#candidate").slideUp("slow");
                $("#company").slideDown("slow");
                $("#college").slideUp("slow");
                $("#arrowimg1").attr("src", "Web/Images/tabarrowdown.jpg");
                $("#arrowimg2").attr("src", "Web/Images/tabarrowdup.jpg");
                $("#arrowimg3").attr("src", "Web/Images/tabarrowdown.jpg");
            });

            $("#arrow3").click(function () {
                $("#candidate").slideUp("slow");
                $("#company").slideUp("slow");
                $("#college").slideDown("slow");
                $("#arrowimg1").attr("src", "Web/Images/tabarrowdown.jpg");
                $("#arrowimg2").attr("src", "Web/Images/tabarrowdown.jpg");
                $("#arrowimg3").attr("src", "Web/Images/tabarrowdup.jpg");
            });

            $("#btnCompanyLogin").click(function () {
                $("#candidate").slideUp("slow");
                $("#company").slideDown("slow");
            });

        });


    </script>
    <script language="javascript" src="Web/js/common.js"></script>
    <script language="JavaScript" type="text/JavaScript"></script>
    <script type="text/javascript" src="Web/js/jquery-1.js"></script>
	<script type="text/javascript" src="Web/js/jquery_003.js"></script>		
	<script type="text/javascript" src="Web/js/javascript_fun.js"></script>
    <script type="text/javascript">
        // Popup window code
        function newPopup(url) {
            popupWindow = window.open(
		url, 'popUpWindow', 'height=363,width=446,left=450,top=250,resizable=no,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=yes')
        }

        function popupwindow(url, title, w, h) {
//            var left = (screen.width / 2) - (w / 2);
//            var top = (screen.height / 2) - (h / 2);
//            var new_left = window.screenX + (((window.outerWidth / 2) - (w / 2)));
//            var new_top = window.screenY + (((window.outerHeight / 2) - (w / 2)));
            alert("Please send in a request to NASSCOM at nacdb@mail.nasscom.in ");
//            alert(left);
//            alert(top);
//            alert(new_left);
//            alert(new_top);
           // return window.open(url, title, 'width=' + w + ', height=' + h + ', top=' + new_top + ', left=' + new_left + ',toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, copyhistory=no');
        }

       
        

</script>
    <script language="javascript" type="text/JavaScript">

        function ValidateLogin() {
            var strCheck;
            strCheck = document.getElementById("txtNacRegId").value;
            if (Trim(strCheck) == "") {
                alert("Please enter NAC Registration ID");
                document.getElementById("txtNacRegId").focus();
                return false;
            }
            strCheck = document.getElementById("ddlPhotoIdDocument").value;
            if (strCheck == 0) {
                alert("Please enter Photo-ID Document");
                document.getElementById("ddlPhotoIdDocument").focus();
                return false;
            }
            strCheck = document.getElementById("txtPhotoIdNumber").value;
            if (Trim(strCheck) == "") {
                alert("Please enter Document No");
                document.getElementById("txtPhotoIdNumber").focus();
                return false;
            }
            strCheck = document.getElementById("txtPassword").value;
            if (Trim(strCheck) == "") {
                alert("Please enter Password");
                document.getElementById("txtPassword").focus();
                return false;
            }
            return true;
        }

        function ValidateCompanyLogin() {
            var strCheck;
            strCheck = document.getElementById("txtUserName").value;
            if (Trim(strCheck) == "") {
                alert("Please enter User Name");
                document.getElementById("txtUserName").focus();
                return false;
            }
            strCheck = document.getElementById("txtPwrd").value;
            if (Trim(strCheck) == "") {
                alert("Please enter Password");
                document.getElementById("txtPwrd").focus();
                return false;
            }
            return true;
        }

        function ValidateNewUserLogin() {
            var strCheck;
            strCheck = document.getElementById("txtUserID").value;
            if (Trim(strCheck) == "") {
                alert("Please enter User ID");
                document.getElementById("txtUserID").focus();
                return false;
            }
            strCheck = document.getElementById("txtUserPassword").value;
            if (Trim(strCheck) == "") {
                alert("Please enter Password");
                document.getElementById("txtUserPassword").focus();
                return false;
            }
            return true;
        }


        function RemoveJunk(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 63 && k < 91) || (k > 96 && k < 123) || (k >= 48 && k <= 57));
        }


        $(function () {
            $("#txtUserPassword").bind('keypress', function (e) {
                if (e.keyCode == '9' || e.keyCode == '16') {
                    return;
                }
                var code;
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                if (e.which == 46)
                    return false;
                if (code == 8 || code == 46)
                    return true;
                if (code < 48 || code > 57)
                    return false;
                if (code < 65 || code > 90)
                    return false;
                if (code < 97 || code > 122)
                    return false;
            }
                );

            $("#txtUserPassword").bind('mouseleave', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^A-Za-z0-9]+/g, "")
                    $(this).val(val);
                }

            });
            $("#txtUserPassword").bind('focusout', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^A-Za-z0-9]+/g, "")
                    $(this).val(val);
                }

            });
            $("#txtUserPassword").bind('keypress', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^A-Za-z0-9]+/g, "")
                    $(this).val(val);

                }
            });

        });





        $(function () {
            $("#txtUserID").bind('keypress', function (e) {
                if (e.keyCode == '9' || e.keyCode == '16') {
                    return;
                }
                var code;
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                if (e.which == 46)
                    return false;
                if (code == 8 || code == 46)
                    return true;
                if (code < 48 || code > 57)
                    return false;
            }
                );

            $("#txtUserID").bind('mouseleave', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "")
                    $(this).val(val);
                }

            });
            $("#txtUserID").bind('focusout', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "")
                    $(this).val(val);
                }

            });
            $("#txtUserID").bind('keypress', function (e) {
                var val = $(this).val();
                if (val != '0') {
                    val = val.replace(/[^0-9]+/g, "")
                    $(this).val(val);

                }
            });

        });





      
    </script>


</head>
<body>
    <form id="frmHome" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="outerbody">
       
         <uc1:nac_headermenu id="Nac_headermenu1" runat="server"></uc1:nac_headermenu>
           
         <table align="center" cellpadding ="0" cellspacing="0">
         <tr>
         <td>
            <div class="banner" id="slideshow">
                <img src="Web/Images/1-banner.jpg" alt="banner" />
                <img alt="" src="Web/Images/2-banner.jpg" class=""  />

			    <img alt="" src="Web/Images/3-banner.jpg" class="first" /> 
				
			    <img alt="" src="Web/Images/4-banner.jpg" class="" /> 
			

			</div>



              
            <div class="content-wrapper-shell">
                <div class="top-content bottombdr">
                    <div id="box1" class="innerbox innerbox_sidebdr first innerbox_bg ">
                        <h2>
                            Skill <span>Matrix</span></h2>
                        <p>
                            <strong>Speaking</strong> : Parameters assessed will be Prosody, Voice Clarity, Fluency and Grammar. 
                            Duration will include preparation time taken by candidate (5 minutes). 
                            Candidates will be assessed on Accent ... </p>
                        <span class="readmore"><a href="Web/SkillCompetency.aspx">Read more</a></span>
                    </div>
                    <div id="box2" class="innerbox innerbox_sidebdr innerbox_bg">
                        <h2>
                            FAQ</h2>
                        <p>
                            Indian BPO sector continues to grow from strength to strength, 
                            witnessing high levels of activity - both onshore as well as offshore. 
                            The industry clocked export revenue of US$ 12.7 billion 
                            in FY2008-09...</p>
                        <span class="readmore"><a href="Web/faq.aspx">Read more</a></span>
                    </div>
                    <div id="box3" class="innerbox innerbox_sidebdr innerbox_bg">
                        <h2>
                            Downloads</h2>
                        <p align="center">
                            <br />
                            <img src="Web/Images/download-icon.jpg" /></p>
                        <p>
                            <a class="link" href="Web/Download.aspx?FileName=NAC Sample Paper1.0.pdf" target="_blank">
                                Download NAC Sample Paper</a></p>
                        <p>
                            <a class="link" href="Web/Download.aspx?FileName=NASSCOM's BPO Career Guide.pdf"
                                target="_blank">NASSCOM's BPO Career Guide</a></p>
                    </div>
                    <div class="formbox">
                        <div class="formtab" id="CandidateFormTab" runat="server">
                            <h2>
                                Candidate <span>Login</span></h2>
                            <span id="arrow1" class="arrow">
                                <img id="arrowimg1" src="Web/Images/tabarrowdup.jpg" /></span>
                            <div id="candidate" class="formcontent">
                                <asp:UpdatePanel ID="userUpdatePanel" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="rblUserType" runat="server" RepeatDirection="Horizontal"
                                            Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="rdList_selectedindexchanged">
                                            <asp:ListItem Text="New User" Value="NewUser" Selected="True" />
                                            <asp:ListItem Text="Already Registered" Value="AlreadyRegistered" />
                                        </asp:RadioButtonList>
                                        <div class="form-box">
                                            <table id="tblRegisteredLogin" class="test" border="0" cellspacing="1" cellpadding="1"
                                                width="100%" runat="server" visible="false">
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Registration ID:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNacRegId" MaxLength="100" CssClass="txtbox" runat="server" Font-Names="Arial"
                                                            ForeColor="#333333" Width="140px" BackColor="White" 
                                                            AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Photo ID:</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPhotoIdDocument" CssClass="txtarea" runat="server" Width="140px"
                                                            BackColor="White">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="rowPhotoIDNumber" runat="server">
                                                    <td>
                                                        <label>
                                                            Photo ID Number:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPhotoIdNumber" MaxLength="100" CssClass="txtbox" runat="server"
                                                            Width="140px" BackColor="White" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Password:</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" MaxLength="50" CssClass="txtbox" runat="server" TextMode="Password"
                                                            Width="140px" BackColor="White" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap class="main_black"><a href="JavaScript:newPopup('web/ForgotPassword.aspx');">Forgot Password</a>
                                                    </td>
                                                    <td>
                                                        <div class="blue_btn">
                                                           <asp:Button ID="btnLogin" runat="server" class="blue_btn span" EnableViewState="False"
                                                                Text="Login" CommandArgument="Submit" OnClick="btnLogin_Click"></asp:Button>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblNewUser" class="test2" border="0" cellspacing="1" cellpadding="1" width="100%"
                                                runat="server">
                                               

                                                <tr id="rowUserID" runat="server">
                                                    <td>
                                                        <asp:Label runat="server" Width="100px">User ID:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUserID" MaxLength="100" CssClass="txtbox" runat="server" Font-Names="Arial"
                                                            ForeColor="#333333" Width="140px" BackColor="White" 
                                                              autocomplete="off"  onkeypress="return RemoveJunk(event)"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label runat="server" Width="100px">Password:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUserPassword" MaxLength="50" CssClass="txtbox" runat="server" onkeypress="return RemoveJunk(event)"
                                                            TextMode="Password" Width="140px" BackColor="White" AutoCompleteType="Disabled"  autocomplete="off"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <div class="blue_btn">
                                                            <asp:Button ID="btnNewUserLogin" runat="server" class="blue_btn span" EnableViewState="False"
                                                                Text="Login" CommandArgument="Submit" OnClick="btnNewUserLogin_Click" ></asp:Button>
                                                        </div>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td class="small_maroon" colspan="2">
                                                      For current NAC events &#8211; <a href="Web/Events.aspx">Click here</a>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblCandidateErrorMessage" border="0" cellspacing="1" cellpadding="1" width="100%"
                                                runat="server" visible="true">
                                                <tr>
                                                    <td>
                                                        <span class="error">
                                                            <asp:Label ID="lblCandidateLoginError" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="rblUserType" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="btnNewUserLogin" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="formtab" id="CompanyFormTab" runat="server">
                            <h2>
                                Company <span>Login</span></h2>
                            <span id="arrow2" class="arrow">
                                <img id="arrowimg2" src="Web/Images/tabarrowdown.jpg" /></span>
                            <div id="company" class="formcontent" style="display: none">
                                <div class="form-box">
                                    <table id="tblCompanyLogin" border="0" cellspacing="1" cellpadding="1" width="100%"
                                        runat="server">
                                        <tr>
                                            <td>
                                                <label>
                                                    Username:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" MaxLength="100" CssClass="txtbox" runat="server" Font-Names="Arial"
                                                    ForeColor="#333333" Width="140px" AutoCompleteType="Disabled"  autocomplete="off"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Password:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPwrd" MaxLength="100" CssClass="txtbox" runat="server" Font-Names="Arial"
                                                    ForeColor="#333333" TextMode="Password" Width="140px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="tblRegisterHere" border="0" cellspacing="1" cellpadding="1" width="100%"
                                        runat="server">
                                        <tr>
                                            <td>
                                                <div class="forgotpassword">
                                                    New User? 
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl = "#" onclick = "popupwindow('NACdb/RegisterInfoForCompany.aspx','', '400','150')" >Register here</asp:HyperLink>


                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="companyUpdatePanel" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table id="tblForgotPassword" border="0" cellspacing="1" cellpadding="1" width="100%"
                                                runat="server">
                                                <tr>
                                                    <td>
                                                        <div class="forgotpassword">
                                                            <a href="NACdb/ForgotPassword.aspx">Forgot Password</a></div>
                                                    </td>
                                                    <td>
                                                        <div class="blue_btn">
                                                            <asp:Button ID="btnCompanyLogin" runat="server" class="blue_btn span" EnableViewState="False"
                                                                Text="Login" CommandArgument="Submit" OnClick="btnCompanyLogin_Click"></asp:Button>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblCompanyErrorMessage" border="0" cellspacing="1" cellpadding="1" width="100%"
                                                runat="server" visible="true">
                                                <tr>
                                                    <td>
                                                        <span class="error">
                                                            <asp:Label ID="lblCompanyLoginError" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnCompanyLogin" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="bottom-content bottom">
                <div id="box4" class="innerbox bottom innerbox_sidebdr first centeralign">
                    <a href="Web/Training.aspx">
                        <img src="Web/Images/traing-dev.gif" alt="Training &amp; development" class="img"
                            align="center" /></a>
                </div>
                <div id="box5" class="innerbox bottom innerbox_sidebdr centeralign">
                    <a href="Web/RequestForNAC.aspx">
                        <img src="Web/Images/requestNAC.gif" class="img" alt="Request for conducting NAC" /></a>
                </div>
                <div id="box6" class="innerbox bottom innerbox_sidebdr centeralign">
                    <a href="Web/RegisteredLogin.aspx">
                        <img src="Web/Images/getNACScoreCard1.jpg" class="img" alt="NAC Score Card" /></a>
                </div>
                <div id="box7" class="innerbox-right bottom centeralign">
                    <a href="Web/Events.aspx">
                        <img src="Web/Images/current-events.gif" class="img" alt="Current Events" /></a>
                </div>
            </div>
            </td>
		</tr>
		</table>
    </div>
    
  <div class="footer">
        <img src="Web/Images/footer2014.gif" />
     </div>


  

    </form>
</body>
</html>
