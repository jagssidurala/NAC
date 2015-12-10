<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nac_headermenu.ascx.cs" Inherits="NASSCOM_NAC.Web.Controls.nac_headermenu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



    <link href="/Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />
    <!--[if IE]>
<link href="resources/styleIE.css" type="text/css" rel="stylesheet" />
<![endif]-->

    <script>
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
    <script language="javascript" src="/Web/js/common.js"></script>
       
   
        <div class="site-wrapper">
            <div class="header" align="left">
                <img id="Img1" src="~/Web/Images/logo.jpg" border="0" runat="server" />
            </div>
            <div class="navigation" align="left">
                <ul>
                    <li id="home" runat = "server"><a id="A1" href="~/HomePage.aspx" runat="server">Home</a></li>
                   
                    <li id="about" runat = "server"><a href="#">About NAC</a>
                        <div class="drop" id="initiative1">
                            <ul>
                                <li class="odd "><a id="A2" href="~/web/NACOverview.aspx" runat="server">Overview</a></li><li class="odd ">
                                    <a id="A3" href="~/web/skillcompetency.aspx" runat="server">Skill Matrix</a></li><li class="odd bordernone">
                                    <a id="A4" href="~/web/Training.aspx" runat="server">Training & Development</a></li></ul>
                                         
                        </div>
                    </li>
                    <li id="benefits" runat = "server"><a id="A5" href="~/Web/Benefits.aspx" runat="server">Benefits</a></li>
                    <li id="requestnac" runat = "server"><a id="A6" href="~/Web/RequestForNAC.aspx" runat="server">Request for conducting NAC</a></li>
                    <li id="faq" runat = "server"><a id="A7" href="~/Web/faq.aspx" runat="server">FAQ</a></li>
                    <li id="contact" runat = "server"><a id="A8" href="~/Web/ContactUs.aspx" runat="server">Contact US</a></li>
                </ul>
            </div> 
         </div>           
   