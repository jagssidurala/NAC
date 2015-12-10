<%@ Page language="c#"  AutoEventWireup="false"  %>
<html>
  <head>
    <title>Download</title>
     <%
		    Response.Clear();
			Response.Buffer = true;
			Response.ContentType = "application/pdf";
			Response.AddHeader("Content-Disposition", "attachment:filename=\"" + Request.QueryString["FileName"].Trim() + "\"" );
			Response.WriteFile("PDF/" + Request.QueryString["FileName"].Trim());
			Response.End();
		%>
   
  </head>
  <body >
	
    <form id="Form1" method="post" runat="server">

     </form>
	
  </body>
</html>
