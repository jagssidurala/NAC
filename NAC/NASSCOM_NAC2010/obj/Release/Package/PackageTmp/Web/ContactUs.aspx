<%@ Register TagPrefix="uc1" TagName="nac_headermenu" Src="~/Web/Controls/nac_headermenu.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="NASSCOM_NAC.Web.ContactUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>NAC Contact Us</title>
    <link href="Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="js/common.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script language="JavaScript" type="text/JavaScript">
       

        function ValidateEmailAddress(eV) {
            var varControlId;
            var varValue;
            var varSubString;
            varControlId = eV.name;
            varValue = document.getElementById(varControlId).value;

            if ((!(emailCheck(varValue))) && Trim(varValue) != "") {
                alert("Please enter valid email address");
                document.getElementById("txtEmailID").focus();
                return false;
            }
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
                return false;
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
                return false;
            }

        }

        function ValidateControls() {
            strText = document.getElementById("ddlfeedbackType").value;
            if ((strText) == 0) {
                alert("Please select feedback type");
                document.getElementById("ddlfeedbackType").focus();
                return false;
            }


            strText = document.getElementById("txtSubject").value;

            if (Trim(strText) == "") {
                alert("Please enter Subject");
                document.getElementById("txtSubject").focus();
                return false;
            }

            if (Trim(strText).length > 50) {
                alert("Subject cant be more than 50 Characters");
                document.getElementById("txtSubject").focus();
                return false;
            }


            strText = document.getElementById("txtMessage").value;

            if (Trim(strText) == "") {
                alert("Please enter Message");
                document.getElementById("txtMessage").focus();
                return false;
            }

            if (Trim(strText).length > 400) {
                alert("Message cant be more than 400 Characters");
                document.getElementById("txtMessage").focus();
                return false;
            }

            strText = document.getElementById("txtEmailID").value;

            if (Trim(strText) == "") {
                alert("Please enter EmailID");
                document.getElementById("txtEmailID").focus();
                return false;
            }

            strSTDCode = document.getElementById("txtCode").value;
            strLandLineNo = document.getElementById("txtLandline").value;
            strMobileNo = document.getElementById("txtMobileNumber").value;

            if (Trim(strSTDCode) != "") {
                if (strSTDCode.length < 3) {
                    alert("Please enter valid STD Code. STD Code cant be less than 3 digits");
                    document.getElementById("txtCode").focus();
                    return false;
                }
            }

            if (Trim(strLandLineNo) != "") {
                if (strLandLineNo.length < 7) {
                    alert("Please enter valid LandLine No. Landline No. cant be less than 7 digits");
                    document.getElementById("txtLandline").focus();
                    return false;
                }
            }

            if (Trim(strSTDCode) != "" && Trim(strLandLineNo) == "") {
                alert("Please enter LandLine No. for the STD Code entered.");
                document.getElementById("txtLandline").focus();
                return false;
            }

            if (Trim(strLandLineNo) != "" && Trim(strSTDCode) == "") {
                alert("Please enter STD Code for the Landline Number entered.");
                document.getElementById("txtCode").focus();
                return false;
            }

            if (Trim(strLandLineNo) != "" && Trim(strSTDCode) == "") {
                alert("Please enter STD Code for the Landline Number entered.");
                document.getElementById("txtCode").focus();
                return false;
            }
            if (Trim(strLandLineNo) == "" && Trim(strMobileNo) == "") {
                alert("Provide either Mobile No or Landline No.");
                document.getElementById("txtMobileNumber").focus();
                return false;
            }
        }


    </script>
    <style type="text/css">
        .style1
        {
            height: 48px;
        }
    </style>
</head>
<body>
    <form id="frmContactUs" runat="server" >
    <div class="outerbody">
    <uc1:nac_headermenu id="Nac_headermenu1" runat="server"></uc1:nac_headermenu>
       
            <table align="center" cellpadding ="0" cellspacing="0"><tr><td>
           
                <div class="inner-content" >
                    <h2>
                        Contact us</h2>
                    <div class="contact_form">
                        <div class="msg_txt">
                        </div>
                        <div class="form">
                            <table id="tblContactUs" runat="server" width="475px">
                                <tr>
                                    <td>
                                        <div id="webform-component-email" class="webform-component webform-component-email">
                                            <div id="edit-submitted-email-wrapper" class="form-item">
                                                <label for="edit-submitted-email">
                                                    Type:</label>
                                                <asp:DropDownList ID="ddlfeedbackType" runat="server" class="form-select" name="select">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webform-component-first-name" class="webform-component webform-component-textfield">
                                            <div id="edit-submitted-first-name-wrapper" class="form-item">
                                                <label for="edit-submitted-first-name">
                                                    Subject: <span title="This field is required." class="form-required">*</span></label>
                                                <asp:TextBox runat="server" class="form-text required" value="" size="80" ID="txtSubject"
                                                    name="submitted[first_name]" MaxLength="50">                                          
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webform-component-last-name" class="webform-component webform-component-textfield">
                                            <div id="edit-submitted-last-name-wrapper" class="form-item">
                                                <label for="edit-submitted-last-name">
                                                    Message: <span title="This field is required." class="form-required">*</span></label>
                                                <textarea class="form-textarea required" id="txtMessage" name="textarea" rows="7"
                                                    cols="60" runat="server"></textarea>
                                            </div>
                                            <div class="charLeft" align="right" id="countCharacter">400 characters left</div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webform-component-topic" class="webform-component webform-component-select">
                                            <div id="edit-submitted-topic-wrapper" class="form-item">
                                                <label for="edit-submitted-topic">
                                                    email ID: <span title="This field is required." class="form-required">*</span></label>
                                                <asp:TextBox runat="server" class="form-text required" value="" size="60" ID="txtEmailID"
                                                    name="submitted[phone]2" MaxLength="128">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    <div align="center" style="margin-left:100px;">Provide either Mobile No or Landline No</div>
                                        <div id="webform-component-city" class="webform-component webform-component-textfield">
                                            <div id="edit-submitted-city-wrapper" class="form-item">
                                                <label for="edit-submitted-city">
                                                    Contact Number (Mobile) :
                                                </label>
                                                <asp:TextBox runat="server" class="form-text" value="" size="60" ID="txtMobileNumber"
                                                    name="submitted[city]" MaxLength="10">                                       
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <div id="webform-component-country" class="webform-component webform-component-select">
                                            <div id="edit-submitted-country-wrapper" class="form-item">
                                                <label for="edit-submitted-country">
                                                    (Landline):
                                                </label>
                                                <asp:TextBox runat="server" class="form-text-code" value="" size="60" ID="txtCode"
                                                    name="submitted[phone]3" MaxLength="5" /></asp:TextBox>
                                                <asp:TextBox runat="server" class="form-text-num" value="" size="60" ID="txtLandline"
                                                    name="submitted[phone]3" MaxLength="10"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div style="margin-left:190px; font-size:10px;">
                                        STD</div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webform-component-phone" class="webform-component webform-component-textfield">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="webform-component-comments" class="webform-component webform-component-textarea">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-actions" id="edit-actions">
                                            <asp:Button runat="server" type="submit" class="form-submit" value="Submit" ID="btnSubmit"
                                                name="op" Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                                            
                        </div>
                    </div>
                </div>
           
            </td></tr></table>
            <asp:Label runat="server" ID="lblMessage" Visible="false" ></asp:Label>
            <div class="footerbottom">
                </div>
      <!--  </div>-->
        </div>
    </form>
    <script type='text/javascript'>
     function CountLeft(text, max) {
            if (text.val().length > max)
                text.val(text.val().substring(0, max));
            else
                jQuery(".charLeft").html((max - text.val().length) + " characters left");
        }

        jQuery("#txtMessage").keyup(
        function (event) {
            CountLeft(jQuery(this), 400);
        }
        ); 
        </script>
</body>
</html>
