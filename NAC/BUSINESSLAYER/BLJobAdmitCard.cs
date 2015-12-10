using System;
using DataBaseAccessLayer;
using DataAccessLayer;
using System.Web;
using System.Data;  
using Common;
using System.Data.SqlClient;
using ExceptionHandling;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for JobAdmitCard.
	/// </summary>
	public class BLJobAdmitCard
	{
		IDBManager dbManager = new DBManager(DataProvider.SqlServer);
		public BLJobAdmitCard()
		{
			//
			// TODO: Add constructor logic here
			//

			try
			{
				DataAccessLayer.DBConnection objDb=new DBConnection();
				string Con=objDb.GetConnectionString(); 
				dbManager.ConnectionString =Con.ToString();
				dbManager.Open();
			}
			catch(Exception SysEx)
			{
				throw SysEx;
			
			}
		}

		public DataSet GenerateMultipleJobAdmitCard(string strItemList)
		{
			try
			{
				
				DataSet dsJobAdmitCard = new DataSet();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@ItemList", strItemList);
				dsJobAdmitCard =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetMultipleJobAdmitSheet");
				return dsJobAdmitCard;
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}
		public DataSet GenerateJobAdmitCard(string strPinNo)
		{
			try
			{
				
				DataSet dsJobAdmitCard = new DataSet();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@PinNo", strPinNo);
				dsJobAdmitCard =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetJobAdmitSheet");
				return dsJobAdmitCard;
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		public DataSet GenerateJobAdmitCard_MT(string strPinNo)
		{
			try
			{
				
				DataSet dsJobAdmitCard = new DataSet();
				dbManager.CreateParameters(1);
				dbManager.AddParameters(0, "@PinNo", strPinNo);
				dsJobAdmitCard =dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetJobAdmitSheet_MT");
				return dsJobAdmitCard;
				
			}
			catch (Exception SysEx)
			{
				throw SysEx;
			}
			finally
			{
				dbManager.Close(); 
				dbManager.Dispose(); 
			}
		}

		

	}

}
