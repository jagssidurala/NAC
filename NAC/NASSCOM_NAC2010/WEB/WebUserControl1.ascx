<%@ Control Language="c#" AutoEventWireup="false" Codebehind="WebUserControl1.ascx.cs" Inherits="NASSCOM_NAC.Web.WebUserControl1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="tiny_mce/tiny_mce.js"></script>
<script>
			tinyMCE.init({
				mode : "textareas",
				theme : "advanced",
				plugins : "table,save,advhr,advimage,advlink,preview,zoom,flash,searchreplace,contextmenu,paste,directionality,fullscreen",
//				theme_advanced_buttons4_add : "fontselect,fontsizeselect",
				theme_advanced_buttons1_add_before : "forecolor,backcolor",
				
				theme_advanced_buttons2_add : "fontselect,fontsizeselect",
				//theme_advanced_buttons2_add_before : "",				

				theme_advanced_buttons3_add : "advhr",
				theme_advanced_buttons3_add_before: "cut,copy,paste,separator,search,replace,separator",				
				theme_advanced_toolbar_location : "top",
				theme_advanced_toolbar_align : "left",
				theme_advanced_path_location : "bottom",
				content_css : "example_full.css",
				plugin_insertdate_dateFormat : "%Y-%m-%d",
				plugin_insertdate_timeFormat : "%H:%M:%S",
				extended_valid_elements : "a[name|href|target|title|onclick],img[class|src|border=0|alt|title|hspace|vspace|width|height|align|onmouseover|onmouseout|name],hr[class|width|size|noshade],font[face|size|color|style],span[class|align|style]",
				external_link_list_url : "example_link_list.js",
				external_image_list_url : "example_image_list.js",
				flash_external_list_url : "example_flash_list.js"
				//file_browser_callback : "fileBrowserCallBack"
			});

			function fileBrowserCallBack(field_name, url, type) {
				// This is where you insert your custom filebrowser logic
				//alert("Filebrowser callback: " + field_name + "," + url + "," + type);
			}

</script>
<TEXTAREA id="selDesc" name="selDesc" rows="24" cols="70" runat="server"></TEXTAREA>
<br>
<asp:Button ID="cmdSave" runat="server" Text="Save" /><br>
<br>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
