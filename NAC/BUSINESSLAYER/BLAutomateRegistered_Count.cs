using System;
using System.Collections;
using System.Text;
using System.Data;
using DataAccessLayer;
using DataBaseAccessLayer;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using Common;
using System.Data.SqlClient;
using ExceptionHandling;
namespace BusinessLayer
{
   public class BLAutomateRegistered_Count
    {
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;
        private DateTime testDateFrom;
        private DateTime testDateTo;

        public BLAutomateRegistered_Count()
		{
			/*
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
		
			}*/
		}


        public DataTable FillTestNameForDates(DateTime TestDateFrom, DateTime TestDateTo)
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(2);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestDateFrom", TestDateFrom, ParameterDirection.Input);
                dbManager.AddParameters(1, "@TestDateTo", TestDateTo, ParameterDirection.Input);
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetTestAgainstDates").Tables[0];

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

        public DataSet GetData4Grid(string TestName, DateTime TestDateFrom, DateTime TestDateTo)
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(3);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestName", TestName, ParameterDirection.Input);
                dbManager.AddParameters(1, "@TestDateFrom", TestDateFrom, ParameterDirection.Input);
                dbManager.AddParameters(2, "@TestDateTo", TestDateTo, ParameterDirection.Input);
                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetRegistrationDatabase"));

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
