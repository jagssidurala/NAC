
	using System;
	using System.Data;
	using System.Data.Odbc;
	using System.Data.SqlClient;
	using System.Data.OleDb;
	using System.Data.OracleClient;
	using System.Xml; 
 
	namespace DataAccessLayer
	{
		public enum DataProvider
		{
			Oracle,SqlServer,OleDb,Odbc
		}
		public interface IDBManager
		{
			DataProvider ProviderType
			{
				get;
				set;
			}
 
			string ConnectionString
			{
				get;
				set;
			}
 
			IDbConnection Connection
			{
				get;
			}
			IDbTransaction Transaction
			{
				get;
			}

			IDataReader DataReader
			{
				get;
			}
			IDbCommand Command
			{
				get;
			}
 
			IDbDataParameter[]Parameters
			{
				get;
			}
		

 
			void Open();
			void BeginTransaction();
			void BeginTransaction(System.Data.IsolationLevel isolationLevel);
			void CommitTransaction();
			void RollbackTransaction();
			void CreateParameters(int paramsCount);
			void AddParameters(int index, string paramName, object objValue);
			void AddParameters(int index, string paramName, object objValue,ParameterDirection dir);
			IDataReader ExecuteReader(CommandType commandType, string commandText);
			DataSet ExecuteDataSet(CommandType commandType, string	commandText);
			object ExecuteScalar(CommandType commandType, string commandText);
			XmlReader Execute_XML_Reader(CommandType commandType, string commandText);
			int ExecuteNonQuery(CommandType commandType,string commandText);
            int ExecuteNonQuery_SP(CommandType commandType,string commandText,string OutParaName);
			void CloseReader();
			void Close();
			void Dispose();
			object param_value(int index);
		}
	}

