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
	/// Summary description for AttendanceWebService1.
	/// </summary>
     [WebService(Namespace = "http://180.179.101.153/")]
	public class AttendanceWebService1 : System.Web.Services.WebService
	{
		public AttendanceWebService1()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}
		BLWSCandidateAttendance objAttendance = new BLWSCandidateAttendance();
		
		 [WebMethod]
		 public Candidate[] MarkCandidateAttendance(CandidateAttendanceRequest Request)
		 {
			 int ctr = 0;
			 Candidate[] Response = new Candidate[Request.AttendanceList.Length];
			 try
			 {
				 foreach(CandidateReq candidate in Request.AttendanceList)
				 {
					 if(candidate.RegistrationId == null || Convert.ToString(candidate.RegistrationId).Trim() =="" )
					 {
						 Response[ctr] = new Candidate();
						 Response[ctr].RegistrationId=Convert.ToString(candidate.RegistrationId);
						 Response[ctr].ResponseID="101";
						 Response[ctr].Message="NOK-Registration Id is mandatory field.";

					 }
					 else
					 {
						 Response[ctr] = objAttendance.MarkCandidateAttendance(candidate);
					 }

					 ctr++;
				 }
				 return Response;
					
			 }
			 catch(Exception ex)

			 {
				 return Response;
			
			 }
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

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}
	}
}
