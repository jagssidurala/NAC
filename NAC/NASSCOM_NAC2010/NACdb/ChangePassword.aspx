<%@ Page language="c#" Codebehind="ChangePassword.aspx.cs" AutoEventWireup="True" Inherits="NASSCOM_NAC.NACdb.ChangePassword" %>
<%@ Register TagPrefix="uc2" TagName="nac_headerlogo" Src="~/Web/Controls/nac_headerlogo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangePassword</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Web/stylesheet/nasscom.css" type="text/css" rel="stylesheet">
        <link href="../Web/Stylesheet/styleV2.css" type="text/css" rel="stylesheet" />	
		<link rel="stylesheet" href="../Web/Stylesheet/nasscomNew.css" type="text/css">
         <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
		<SCRIPT language="javascript" src="../web/js/common.js"></SCRIPT>
		<script language="JavaScript" type="text/JavaScript">
		
			function ValidateData()
			{

				var elem = document.getElementById('lblError');
			
					if (elem != null)
					if(typeof(elem.textContent) != 'undefined')
					elem.textContent = '';
					else
					elem.innerText = '';
					
				var strText;			      
				
				strText = document.getElementById("txtCurrentPassword").value;
				if (Trim(strText) == "")
				{
					alert("Please enter current password");
					document.getElementById("txtCurrentPassword").focus();
					document.getElementById("txtCurrentPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtCurrentPassword").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtNewPassword").value;
				if (Trim(strText) == "")
				{
					alert("Please enter a new password");
					document.getElementById("txtNewPassword").focus();
					document.getElementById("txtNewPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtNewPassword").style.backgroundColor = 'white';
				}
				
				strText = document.getElementById("txtConfirmNewPassword").value;
				if (Trim(strText) == "")
				{
					alert("Please enter new password to confirm");
					document.getElementById("txtConfirmNewPassword").focus();
					document.getElementById("txtConfirmNewPassword").style.backgroundColor = 'yellow';
					return false;
				}
				else
				{
					document.getElementById("txtConfirmNewPassword").style.backgroundColor = 'white';
				}
				
				if(document.getElementById("txtNewPassword").value != document.getElementById("txtConfirmNewPassword").value)
				{
					alert("New password & confirm new password do not match");
					document.getElementById("txtNewPassword").value='';
					document.getElementById("txtConfirmNewPassword").value='';
					document.getElementById("txtNewPassword").focus();
					document.getElementById("txtNewPassword").style.backgroundColor = 'yellow';
					return false;
				}
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmHome" method="post" runat="server">
			 <div class="outerbody" align="center">			
		
									<uc2:nac_headerlogo id="Nac_headermenu1" runat="server"></uc2:nac_headerlogo>
										
			  
               <div class="content-wrapper-shell-inner">
                     <div class="inner-content">
                    <h2 align="left" > </h2>


                                <table id="Table2" border="0" cellpadding="0" cellspacing="0" >
								<tr>
									<td valign="top" style="HEIGHT: 18px" align="center">
										<table>
											<tr>
												<td colspan="2" align="center"><STRONG><FONT size="4">
															<asp:Label id="Label1" runat="server" CssClass="pageheader">Change Password</asp:Label></FONT></STRONG></td>
											</tr>
											<tr>
												<td colspan="2" align="center">&nbsp;</td>
											</tr>
											<tr>
												<td>
													<asp:Label id="Label2" runat="server" CssClass="label_black_bold">Current Password</asp:Label></td>
												<td>
													<asp:TextBox id="txtCurrentPassword" runat="server" TextMode="Password" MaxLength="12" CssClass="newUserTextbox" autocomplete="off" ></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td>
													<asp:Label id="Label3" runat="server" CssClass="label_black_bold">New Password</asp:Label></td>
												<td>
													<asp:TextBox id="txtNewPassword" runat="server" TextMode="Password" MaxLength="12" CssClass="newUserTextbox" autocomplete="off" ></asp:TextBox>
												</td>
											</tr>
											<TR>
												<td>
													<asp:Label id="Label4" runat="server" CssClass="label_black_bold">Confirm New Password</asp:Label></td>
												<td>
													<asp:TextBox id="txtConfirmNewPassword" runat="server" TextMode="Password" MaxLength="12" CssClass="newUserTextbox" autocomplete="off" ></asp:TextBox>
												</td>
											</TR>
											<tr>
												<td colspan="2" align="right">
													<asp:Button id="btnSave" runat="server" Text="Save" CssClass="btn2" onclick="btnSave_Click"></asp:Button>&nbsp;
													<asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="btn2" onclick="btnCancel_Click"></asp:Button></td>
											</tr>
											<tr>
												<td colspan="2" align="center">
													<asp:Label id="lblError" runat="server" CssClass="errormessage"></asp:Label>
												</td>
											</tr>
										</table>
									 </div>
                        </div>           

               <div class="footer">  <img src="../Web/Images/footer2014.gif" />
               
               </div>

            </div>


		</form>
	</body>
</HTML>
