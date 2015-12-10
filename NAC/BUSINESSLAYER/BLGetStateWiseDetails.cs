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
   public class BLGetStateWiseDetails
    {
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;
        public BLGetStateWiseDetails()
        {

        }
        public DataSet GetStateWiseCandidateDetails(string TestDateFrom, string TestDateTo ,int TestState)
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(3);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@StartDate", TestDateFrom, ParameterDirection.Input);
                dbManager.AddParameters(1, "@EndDate", TestDateTo, ParameterDirection.Input);
                dbManager.AddParameters(2, "@StateId", TestState, ParameterDirection.Input);
                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "UspGetStateWiseTestDetails"));

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
        public DataSet GetStateWiseCandidateDetails()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(0);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "UspGetStateWiseTestDetails"));

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
