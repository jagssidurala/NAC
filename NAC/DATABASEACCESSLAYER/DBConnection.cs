
//////////////////////////////////////////////////////////////////////////////////////
//
//			Project		:	eElection
//			Module		:	Get Database Connection String
//			Decription	:	This will retrieves the registry entry containing 
//							Connection String
//			Author		:	Sachin Dhir
//			Date		:	07 Sep, 2K6
//			Version		:	1.0
//
//////////////////////////////////////////////////////////////////////////////////////
//
//			History
//			-------
//
//////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Configuration;
using Common;

namespace DataAccessLayer
{
	/// <summary>
	/// DBConnection retrieves Connection String from registry
	/// </summary>
	public class DBConnection
	{
		
		//ConnectionString stores the connection string
		////private string ConnectionString = "";

		/// <summary>
		/// GetConnectionString() method opens registry key containing server name, database name, 
		/// user name and password required to connect to database; decrypt them and returns 
		/// required Connection String
		/// </summary>
		/// <returns>string containing Connection String</returns>
		public  DBConnection()
		{
			
		}

		#region GetConnectionString() - Get Connection String from web.config

		public string GetConnectionString()
		{
			return ConfigurationSettings.AppSettings["ConnnectionString"].ToString();
		}
		#endregion
	}
}
