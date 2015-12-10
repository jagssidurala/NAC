///====================================================================
/// Name: DBMangerLinkServer.cs
/// 
///     Class used to execute Stored Procedures to fetch data without 
///     Transactions.
///     This class is mainly designed to fetch data from Remote Server.
///     
/// Construction Date: 11 Sep, 2006
/// Author: Sachin Dhir
///
/// Last Revision Date: 
/// Last Revision By:  
/// Last Revision Change: 
/// ====================================================================
/// Copyright (C) 2006-2007 NASSCOM  All Rights Reserved.
/// ====================================================================

using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using DataAccessLayer;
using Microsoft.Win32;
using Common;

namespace DataBaseAccessLayer
{
	/// <summary>
	/// Summary description for DBMangerLinkServer.
	/// </summary>
	public sealed class DBMangerLinkServer
	{

		private SqlConnection DbConnection;
		private SqlCommand DbCommand;
		private SqlDataAdapter DbAdapter;

		//ConnectionString stores the connection string
		private string ConnectionString = "";

		//RegistryKeyName stores registry key name that stores connection string
		//private string RegistryKeyName = @"Software\NASSCOM_eElection";


		public DBMangerLinkServer()
		{
			DbConnection= new SqlConnection();
			DbConnection.ConnectionString = GetConnectionString();
		}

		public string GetConnectionString()
		{
			//ServerName stores Server Name
			string ServerName;
			//DatabaseName stores Database Name
			string DatabaseName;
			//UserName stores Login User Name
			string UserName;
			//Password stores Login User Password
			string Password;

			//Opening Registry key in read mode and retrieving Registry Key
			//RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(RegistryKeyName,false);
			
			//if(RegKey != null)
			//{
				//Retrieving Sub Key values
////				ServerName = CLCrytoEngine.Decrypt(RegKey.GetValue("ServerName").ToString());
////				DatabaseName = CLCrytoEngine.Decrypt(RegKey.GetValue("DbName").ToString());
////				UserName = CLCrytoEngine.Decrypt(RegKey.GetValue("UserName").ToString());
////				Password = CLCrytoEngine.Decrypt(RegKey.GetValue("Password").ToString());

			ServerName =  CLCrytoEngine.Decrypt(ConfigurationSettings.AppSettings["ServerName"].ToString());
			DatabaseName = CLCrytoEngine.Decrypt(ConfigurationSettings.AppSettings["DbName"].ToString());
			UserName = CLCrytoEngine.Decrypt(ConfigurationSettings.AppSettings["UserName"].ToString());
			Password = CLCrytoEngine.Decrypt(ConfigurationSettings.AppSettings["Password"].ToString());

				//Constructing Connection string
				ConnectionString = "server="+ ServerName +";database="+ DatabaseName +";User ID="+ UserName  +";Password="+ Password +";";
				
				return ConnectionString;
//			}
//			else
//			{
//				throw new Exception("Connection String does not exist.");
//			}
		}


		#region Open/Close Database Connection
		public void OpenConnection()
		{
			if (DbConnection.State == ConnectionState.Closed)
			{
				DbConnection.Open();
			}
		}

		public void CloseConnection()
		{
			if (DbConnection.State == ConnectionState.Open)
			{
				DbConnection.Close();
			}
		}
		#endregion

		//Exceute Procedures to fetch data without Transaction
		public DataSet ExecuteProcedure(String ProcedureName,SqlParameter[] Parameter)
		{
			try
			{
				DataSet dtSet = new DataSet();
				DbCommand = new SqlCommand();
				DbCommand.CommandType = CommandType.StoredProcedure;
				DbCommand.CommandText = ProcedureName;
				for(int index = 0;index < Parameter.Length;index++)
				{
					DbCommand.Parameters.Add(Parameter[index]);
				}
				OpenConnection();
				DbCommand.Connection = DbConnection;
				DbAdapter = new SqlDataAdapter(DbCommand);
				dtSet = new DataSet();
				DbAdapter.Fill(dtSet);
				return dtSet;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				CloseConnection();
			}
		}

	}
}
