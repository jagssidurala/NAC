using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Xml; 
 
namespace DataAccessLayer
{
	public sealed class DBManager: IDBManager,IDisposable
	{
		private IDbConnection idbConnection;
		private IDataReader idataReader;
		private IDbCommand idbCommand;
		private DataProvider providerType;
		private IDbTransaction idbTransaction =null;
		private IDbDataParameter[]idbParameters =null;
		private string strConnection;

		public DBManager()
		{
 
		}
 
		public DBManager(DataProvider providerType)
		{
			this.providerType = providerType;
		}
 
		public DBManager(DataProvider providerType,string
			connectionString)
		{
			this.providerType = providerType;
			this.strConnection = connectionString;
		}
 
		public IDbConnection Connection
		{
			get
			{
				return idbConnection;
			}
		}
 
		public IDataReader DataReader
		{
			get
			{
				return idataReader;
			}
			set
			{
				idataReader = value;
			}
		}
 
		public DataProvider ProviderType
		{
			get
			{
				return providerType;
			}
			set
			{
				providerType = value;
			}
		}
 
		public string ConnectionString
		{
			get
			{
				return strConnection;
			}
			set
			{
				strConnection = value;
			}
		}
 
		public IDbCommand Command
		{
			get
			{
				return idbCommand;
			}
		}
 
		public IDbTransaction Transaction
		{
			get
			{
				return idbTransaction;
			}
		}
 
		public IDbDataParameter[]Parameters
		{
			get
			{
				return idbParameters;
			}
		}
		
		public void Open()
		{
			idbConnection =
				DBManagerFactory.GetConnection(this.providerType);
			idbConnection.ConnectionString =this.ConnectionString;
			if (idbConnection.State !=ConnectionState.Open)
				idbConnection.Open();
			this.idbTransaction=idbConnection.BeginTransaction(); //initating transaction 
			this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
		}
 
		public void Close()
		{
			if (idbConnection.State !=ConnectionState.Closed)
				idbConnection.Close();
		}
 
		public void Dispose()
		{
			GC.SuppressFinalize(this); 
			this.Close();
			this.idbCommand = null;
			this.idbTransaction = null;
			this.idbConnection = null;
		}
 
		public void CreateParameters(int paramsCount)
		{
			idbParameters = new IDbDataParameter[paramsCount];
			idbParameters =DBManagerFactory.GetParameters(this.ProviderType,
				paramsCount);
		}
 
		public void AddParameters(int index, string paramName,object objValue,ParameterDirection dir)
		{
			if (index < idbParameters.Length)
			{
				idbParameters[index].ParameterName =paramName;
				idbParameters[index].Value = objValue;
				idbParameters[index].Direction=dir; 
			}
		}
		public void  AddParameters(int index, string paramName,  object objValue)
		{
			if (index < idbParameters.Length)
			{
				idbParameters[index].ParameterName =paramName;
				idbParameters[index].Value = objValue;
		
		

			}
		}
 
		public void BeginTransaction()
		{
			if (this.idbTransaction == null)
				idbTransaction =
					DBManagerFactory.GetTransaction(this.ProviderType);
			this.idbCommand.Transaction =idbTransaction;
		}

		public void BeginTransaction(System.Data.IsolationLevel isolationLevel)
		{
			if (this.idbTransaction == null)
				idbTransaction =
					DBManagerFactory.GetTransaction(this.ProviderType,isolationLevel);
			this.idbCommand.Transaction =idbTransaction;
			//this.idbCommand.Transaction. =isoloationLevel;
			
		}
 
		public void CommitTransaction()
		{
			if (this.idbTransaction != null)
				this.idbTransaction.Commit();
			else
				this.idbTransaction.Rollback();
			idbTransaction = null;
		}
		public void RollbackTransaction()
		{
			if (this.idbTransaction != null)
				this.idbTransaction.Rollback();
			idbTransaction = null;
		}
 
 
		public IDataReader ExecuteReader(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
			idbCommand.Connection = this.Connection;
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			this.DataReader =idbCommand.ExecuteReader();
			idbCommand.Parameters.Clear();
			return this.DataReader;
		}
 
		public void CloseReader()
		{
			if (this.DataReader != null)
				this.DataReader.Close();
		}
 
		private void AttachParameters(IDbCommand command,
			IDbDataParameter[]commandParameters)
		{
			foreach (IDbDataParameter idbParameter in commandParameters)
			{
				if ((idbParameter.Direction == ParameterDirection.InputOutput)&&(idbParameter.Value == null))
				{
					idbParameter.Value = DBNull.Value;
				}
				command.Parameters.Add(idbParameter);
			}
		}
 
		private void PrepareCommand(IDbCommand command, IDbConnection
			connection,
			IDbTransaction transaction, CommandType commandType, string
			commandText,
			IDbDataParameter[]commandParameters)
		{
			command.Connection = connection;
			command.CommandText = commandText;
			command.CommandType = commandType;
 
			if (transaction != null)
			{
				command.Transaction = transaction;
			}
 
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}
		}
 
		public int ExecuteNonQuery(CommandType commandType, string
			commandText)
		{
			int returnValue=0;
			try
			{
				//this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
				PrepareCommand(idbCommand,this.Connection, this.Transaction,commandType, commandText,this.Parameters);

				 returnValue =idbCommand.ExecuteNonQuery();
				
				idbCommand.Parameters.Clear();
				//CommitTransaction();
			}
			catch
			{
				throw;
			}
			
			return returnValue;
		}
		public int ExecuteNonQuery_SP(CommandType commandType, string commandText,string OutParaName)
		{
			
			//this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
			int returnValue;
			try
			{
				PrepareCommand(idbCommand,this.Connection, this.Transaction,commandType, commandText,this.Parameters);
				returnValue =idbCommand.ExecuteNonQuery();
				SqlParameter RetParameter= (SqlParameter)idbCommand.Parameters[OutParaName];
				if (RetParameter.Direction==ParameterDirection.Output)
				{

					returnValue=System.Convert.ToInt16(RetParameter.Value.ToString());
				}
				idbCommand.Parameters.Clear();
			}
			catch
			{
				throw;
			}
			return returnValue;
			
		}
		public object param_value(int index)
		{
			return idbParameters[index].Value;
		}

		public object ExecuteScalar(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			object returnValue = idbCommand.ExecuteScalar();
			idbCommand.Parameters.Clear();
			return returnValue;
		}
 
		public DataSet ExecuteDataSet(CommandType commandType, string
			commandText)
		{
			this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			IDbDataAdapter dataAdapter =DBManagerFactory.GetDataAdapter
				(this.ProviderType);
			dataAdapter.SelectCommand = idbCommand;
			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet);
			idbCommand.Parameters.Clear();
			return dataSet;
		}
		public XmlReader Execute_XML_Reader(CommandType commandType, string
			commandText)
		{
			SqlCommand comm=new SqlCommand();
			this.idbCommand =DBManagerFactory.GetCommand(this.ProviderType);
			PrepareCommand(idbCommand,this.Connection, this.Transaction,
				commandType,
				commandText, this.Parameters);
			comm=(SqlCommand)this.Command; 
			XmlReader red=	comm.ExecuteXmlReader(); 
//			IDbDataAdapter dataAdapter =DBManagerFactory.GetDataAdapter
//				(this.ProviderType);
//			dataAdapter.SelectCommand = idbCommand;
//			DataSet dataSet = new DataSet();
//			dataAdapter.Fill(dataSet);
//			idbCommand.Parameters.Clear();
			return red;
		}

	}
}