using System;
using System.Drawing;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLMhtImage.
	/// </summary>
	public class BLMhtImage
	{

		 private System.Drawing.Image image;
		 private string strContentLocation;
		 private System.Drawing.Imaging.ImageFormat objImageFormat;

		public System.Drawing.Image Image
		{
		
			get
			{	
				return image;
			}
			set
			{				 
				image = value;
			}
		
		}

		public string ContentLocation
		{
		
			get
			{	
				return strContentLocation;
			}
			set
			{				 
				strContentLocation = value;
			}
		
		}


		public System.Drawing.Imaging.ImageFormat ImageFormat
		{
		
			get
			{	
				return objImageFormat;
			}
			set
			{				 
				objImageFormat = value;
			}
		
		}
 

		public BLMhtImage(System.Drawing.Image image, string strContentLocation, System.Drawing.Imaging.ImageFormat objImageFormat)
		{
			 this.Image = image;
			 this.ContentLocation = strContentLocation;
			 this.ImageFormat = objImageFormat;
		}
	}
}
