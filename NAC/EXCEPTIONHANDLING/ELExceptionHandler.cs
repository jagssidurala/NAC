using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Diagnostics; 
using System.IO;
using System.Text;

namespace ExceptionHandling
{
	/// <summary>
	/// Summary description for ELExceptionHandler.
	/// </summary>
	public class ELExceptionHandler
	{
		private static string ErrorMessage = null;
		public ELExceptionHandler()
		{
			
		}

		private static string GetErrorMessage(string ExceptionType)
		{
			string Message = null;
			switch(ExceptionType)
			{
				case "NullReferenceException":
					Message = "Object Refernce Not Set";
					break;
				case "FileException":
					Message = "File Exception";
					break;
				case "IOException":
					Message = "I/O Exception";
					break;
				case "SqlException":
					Message = "SQL Exception";
					break;
				case "SystemException":
					Message = "System Exception";
					break;
				case "ApplicationException":
					Message = "Application Error";
					break;
				default:
					Message = "Critical Error";
					break;
			}
			return Message;
		}

		public static string ProcessErrorWithoutPageThrow(Exception oException)
		{
			
			return GetErrorMessage(oException.GetType().Name);
		}

		public static void ProcessErrorWithPageThrow(Exception oException)
		{
			ErrorMessage = GetErrorMessage(oException.GetType().Name);
			HttpContext oContext = HttpContext.Current;
			ErrorMessage = " There is some error,please contact Adminstrator...";
			oContext.Session["ErrorMessage"] = ErrorMessage;
			oContext.Server.Transfer("ErrorPage.aspx");
		}
	}
}
