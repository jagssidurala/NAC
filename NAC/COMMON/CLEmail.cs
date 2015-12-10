//Designed and Developed by Momentum Technologies
//
// Description   :   class containing common functions for send the mail.
// Date Created  :   7 Sep 06
// Author        :   Kamesh
// Revision History:
// Modified By		     Date			Summary of changes

using System;
//using System.Web.Mail;
using System.Web;
using System.Net.Mail;
using System.Net;


namespace Common
{
	/// <summary>
	/// Summary description for CLEmail.
	/// </summary>
	/// 
	
	/// 
	public class CLEmail
	{
		public const string EmailInvitation = "IM";
		public const string EmailReminder= "RM";
		public const string EmailFinalResult = "FM";
		public CLEmail()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		// This function is used to send the mail through SMTP Server
		public void SendMail(string sBody,string sFrom,string sSubject,string sSendTo,string sSMTPServerIP) 
		{
            MailMessage objEmail = new MailMessage(sFrom, sSendTo, sSubject, sBody);			
			objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(sSMTPServerIP, 25);
            NetworkCredential networkCredential = new NetworkCredential("nacdb@mail.nasscom.in", "p@$$word@1");
            client.Credentials = (ICredentialsByHost)networkCredential;
    
			try 
			{ 
				//SmtpMail.Send(objEmail); 
                client.Send(objEmail);
			} 
			catch (Exception Ex)
			{ 
				throw Ex;
			}

            finally
            {
                objEmail.Dispose();
            }
		}

		public void SendMailWithAttachment(string sBody,string sFrom,string sSubject,string sSendTo,string sSMTPServerIP,string sAttachment) 
		{

            MailMessage objEmail = new MailMessage(sFrom, sSendTo, sSubject, sBody);

			objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
			objEmail.Attachments.Add(new Attachment(sAttachment));

            SmtpClient client = new SmtpClient(sSMTPServerIP, 25);           
            NetworkCredential networkCredential = new NetworkCredential("nacdb@mail.nasscom.in", "p@$$word@1");
            client.Credentials = (ICredentialsByHost)networkCredential;
     
            try
            {
                //SmtpMail.Send(objEmail); 
                client.Send(objEmail);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            finally
            {
                objEmail.Dispose();
            }
		}


	}
}
