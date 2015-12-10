///====================================================================
/// Name: CLEnums.cs
/// 
///     This will handle various enumerations to be used at
	/// various layers across system.
///     
/// Construction Date: 06 Sep, 2006
/// Author: Sachin Dhir
///
/// Last Revision Date: 
/// Last Revision By:  
/// Last Revision Change: 
/// ====================================================================
/// Copyright (C) 2006-2007 NASSCOM  All Rights Reserved. Ankit
/// ====================================================================

using System;

namespace Common
{
	/// <summary>
	/// This class will handle various enumerations to be used at
	/// various layers across system.
	/// </summary>
	/// 

	public class CLEnums
	{
		public enum InvitationMail
		{
			HasSent = 1,
			NotSent = 0
		}
		//UserType enum will handle type of user : Member or Administrator
		public enum UserType
		{
			User =3,
			Admin = 1,
			Auditor = 2
		}

		//IsContestant enum will handle whether the user is contestant or not.
		public enum IsContestant
		{
			No = 0,
			Yes
		}

		public enum IsNew
		{
			No = 0,
			Yes
		}

		public enum Has_Profiles_Imported
		{
			No = 0,
			Yes
		}

		public enum Date_Format
		{
			ddMMYYYY = 0,
			ddMMMYYYYHHmm = 1
		}

		public enum IsShuffled
		{
			No = 0,
			Yes = 1
		}
	}
}
