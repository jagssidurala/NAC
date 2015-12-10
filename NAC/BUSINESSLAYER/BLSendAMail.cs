using System;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLSendAMail.
	/// </summary>
	public class BLSendAMail
	{
				private string strUserId;
				private string strEmailId;
				private string strCandidateName;
				private string strPhotoIDDocument;
				private string strPhotoIDDocumentNumber;
				private string strPassword;
				private string strFileName;

		public string UserId
		{
		
			get
			{	
				return strUserId;
			}
			set
			{				 
				strUserId = value;
			}
		
		}

		public string EmailId
		{
		
			get
			{	
				return strEmailId;
			}
			set
			{				 
				strEmailId = value;
			}
		
		}

		public string CandidateName
		{
		
			get
			{	
				return strCandidateName;
			}
			set
			{				 
				strCandidateName = value;
			}
		
		}

		public string PhotoIDDocument
		{
		
			get
			{	
				return strPhotoIDDocument;
			}
			set
			{				 
				strPhotoIDDocument = value;
			}
		
		}

		public string PhotoIDDocumentNumber
		{
		
			get
			{	
				return strPhotoIDDocumentNumber;
			}
			set
			{				 
				strPhotoIDDocumentNumber = value;
			}
		
		}

		public string Password
		{
		
			get
			{	
				return strPassword;
			}
			set
			{				 
				strPassword = value;
			}
		
		}

		public string FileName
		{
		
			get
			{	
				return strFileName;
			}
			set
			{				 
				strFileName = value;
			}
		
		}



		public BLSendAMail()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
