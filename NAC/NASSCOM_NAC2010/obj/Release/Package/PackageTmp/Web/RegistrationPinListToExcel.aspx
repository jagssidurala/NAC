<%@ Page language="c#" Codebehind="RegistrationPinListToExcel.aspx.cs" EnableViewState="false" AutoEventWireup="True" Inherits="NASSCOM_NAC.RegistrationPinListToExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RegistrationPinToExcel</title>
		<%
		    Response.Clear();
			Response.Buffer = true;
			Response.ContentType = "application/vnd.ms-excel";
			Response.AddHeader("Content-Disposition", "attachment:filename=RegistrationPinToExcel.xls");
			Response.Flush();
		%>
		<style type="text/css">		   
		    .ExlsTableFormHeaderFont { FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: #990000; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #e0e0e0; TEXT-ALIGN: center }		   
		    .ExlsTableInnerTable { BORDER-RIGHT: #dadada 1pt solid; BORDER-TOP: #dadada 1pt solid; BORDER-LEFT: #dadada 1pt solid; COLOR: #000000; BORDER-BOTTOM: #dadada 1pt solid; FONT-FAMILY: Verdana; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: #ffffff }		   
		    .ExlsTableDataGridBody { BORDER-RIGHT: white 1px solid; BORDER-TOP: white 1px solid; FONT-SIZE: 8pt; BORDER-LEFT: white 1px solid; COLOR: #990000; BORDER-BOTTOM: white 1px solid; FONT-FAMILY: Verdana; BACKGROUND-COLOR: #f5f4f4 }		   
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table>
			<tr>
				<td>
					<asp:DataGrid id="dgRegistrationPinList" CssClass="ExlsTableDataGridBody" runat="server" EnableViewState="False"
						ShowFooter="True">
						<FooterStyle BorderWidth="0px" ForeColor="White" BackColor="#000084"></FooterStyle>
						<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#000084"></HeaderStyle>
					</asp:DataGrid>
				</td>
			</tr>
		</table>
	</body>
</HTML>
