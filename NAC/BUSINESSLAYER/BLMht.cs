using System;
using CDO;
using ADODB;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLMht.
	/// </summary>
	public class BLMht : System.Web.UI.Page
	{

		private string getHtml(WebControl c)
		{
			System.IO.StringWriter sw;
			HtmlTextWriter tw;
			try
			{
				sw = new System.IO.StringWriter();				 
				tw = new HtmlTextWriter(sw);
				c.RenderControl(tw);
				sw.Close();
				tw.Close();
				return sw.ToString();
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			 
		} 

		private void fixImageLocation(ref string html, ref BLMhtImageCollection objBLMhtImageCollection)
		{
		     string curContentLocation;
			 int curIndex;			 
			 
 			foreach(BLMhtImage objBLMhtImage in objBLMhtImageCollection)
 			{
				 curContentLocation = objBLMhtImage.ContentLocation;
				if(curContentLocation.IndexOf(":") == -1)
				{
				   curIndex = html.IndexOf(curContentLocation);
					while(curIndex != -1)
					{
					    html = html.Insert(curIndex, "http://");
						curIndex = html.IndexOf(curContentLocation, curIndex + curContentLocation.Length);

					}
						objBLMhtImage.ContentLocation = "http://" + curContentLocation;
				}
			}
		} 

		public string convertWebControlToMHTString(WebControl control)
		{
		   return convertWebControlToMHTString(control, null);
		}

		public string convertWebControlToMHTString(WebControl control,BLMhtImageCollection mhtImageCollection)
		{
		      string html = getHtml(control);
//			if(mhtImageCollection == null)
//			{
			   
				fixImageLocation(ref html,ref mhtImageCollection);
//			}
			CDO.MessageClass msg = new MessageClass();
			ADODB.Stream stm = null;
			System.IO.MemoryStream MS = null;
		
			CDO.IBodyPart iBp;

			CDO.IBodyPart mainBody;
			mainBody = msg;

			mainBody.ContentMediaType = "multipart/related";


			iBp = mainBody.AddBodyPart(-1);
			iBp.ContentMediaType = "text/html";
			iBp.ContentTransferEncoding = "quoted-printable";
			stm = iBp.GetDecodedContentStream();
			stm.WriteText(html,ADODB.StreamWriteEnum.stWriteLine);
			stm.Flush();

//			if(mhtImageCollection == null)
//			{
			     
				foreach(BLMhtImage oMhtImage in mhtImageCollection)
				{
					iBp = mainBody.AddBodyPart(-1);
					iBp.ContentMediaType = "image/" + oMhtImage.ImageFormat.ToString().ToLower();
					iBp.ContentTransferEncoding = "base64";
					iBp.Fields.Append("urn:schemas:mailheader:content-location", DataTypeEnum.adBSTR,0,ADODB.FieldAttributeEnum.adFldMayBeNull, oMhtImage.ContentLocation);
					iBp.Fields.Update();
					iBp.Fields.Refresh();
					try
					{
						MS = new System.IO.MemoryStream();
						oMhtImage.Image.Save(MS,oMhtImage.ImageFormat);
						byte[] bytearray = MS.ToArray();
						stm = iBp.GetDecodedContentStream();
						stm.Write(bytearray);
						stm.Flush();
					}
					catch(Exception ex)
					{
						throw(ex);

					}
					finally
					{
						MS.Close();
						stm.Close();

					}
					  
				}
				
		//	}
			stm = mainBody.GetStream();
			return stm.ReadText(stm.Size);
		} 
 

		public string convertWebPageToMHTString(string url)
		{
		    CDO.MessageClass msg = new MessageClass();
			ADODB.Stream stm = null;
			try
			{
				msg.MimeFormatted = true;
				msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressNone, "","");
				stm = msg.GetStream();
				return stm.ReadText(stm.Size);
			}
			catch(Exception ex)
			{
				throw(ex);
			}
			finally
			{
				stm.Close();
			}
			
			

		}

		public void sendMHTFile(string MHTString, string filename)
		{
		    Response.Clear();
		    Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/msword";
			Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
			Response.Write(MHTString);
			Response.Flush();
			Response.Close();
		}

		public BLMht()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
