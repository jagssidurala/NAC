using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using BusinessLayer;
using System.IO;


namespace NASSCOM_NAC.WebService
{
	/// <summary>
	/// Summary description for AuthenticationWebService.
	/// </summary>
	
	[WebService(Namespace="http://www.nac.nasscom.in/")]
	public class AuthenticationWebService : System.Web.Services.WebService
	{
		public AuthenticationWebService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod]
		public CandidateAuthenticationResponse CandidateAuthentication(CandidateAuthenticationRequest Request)
		{
			BLWSCandidateAuthentication objAuth = new BLWSCandidateAuthentication();
			try
			{
				objAuth.AuthenticationResponse.RegistrationId=Request.RegistrationId;
				objAuth.AuthenticationResponse.FirstName=Request.FirstName;
				objAuth.AuthenticationResponse.LastName=Request.LastName;
				objAuth.AuthenticationResponse.DOB=Request.DOB;
			
				if ( (Convert.ToString(Request.RegistrationId).Trim()=="") || (Request.RegistrationId== null) )
				{
					objAuth.AuthenticationResponse.Response.ResponseID="101";
					objAuth.AuthenticationResponse.Response.Message="NOK-Registration Id is mandatory field.";
					return objAuth.AuthenticationResponse;
				}
			
				else if ((Convert.ToString(Request.FirstName).Trim()=="") || (Request.FirstName== null)  )
				{
					objAuth.AuthenticationResponse.Response.ResponseID="102";
					objAuth.AuthenticationResponse.Response.Message="NOK-First Name is mandatory field.";
					return objAuth.AuthenticationResponse;
				}
			
				else if ((Convert.ToString(Request.LastName).Trim()=="") || (Request.LastName== null) )
				{
					objAuth.AuthenticationResponse.Response.ResponseID="103";
					objAuth.AuthenticationResponse.Response.Message="NOK-Last Name is mandatory field.";
					return objAuth.AuthenticationResponse;
				}
			
				else if ((Convert.ToString(Request.DOB).Trim()=="") || (Request.DOB == null) )
				{
					objAuth.AuthenticationResponse.Response.ResponseID="104";
					objAuth.AuthenticationResponse.Response.Message="NOK-Date Of Birth is mandatory field.";
					return objAuth.AuthenticationResponse;
				}

				try
				{
					DateTime DateOfBirth = Convert.ToDateTime(Request.DOB);
				}
				catch
				{
					objAuth.AuthenticationResponse.Response.ResponseID="105";
					objAuth.AuthenticationResponse.Response.Message="NOK-Incorrect Date Of Birth format.";
					return objAuth.AuthenticationResponse;
				}

				return objAuth.AuthenticateCandidateDetails(Request);
					
			}
			catch(Exception ex)
			{
				objAuth.AuthenticationResponse.Response.ResponseID="999";
				objAuth.AuthenticationResponse.Response.Message="NOK-Some error occurred while processing your request. Please contact administrator.";
				return objAuth.AuthenticationResponse;
			}

		}
	}
}
