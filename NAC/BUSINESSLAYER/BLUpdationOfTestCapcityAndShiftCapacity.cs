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
    public class BLUpdationOfTestCapcityAndShiftCapacity
    {
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;
        public BLUpdationOfTestCapcityAndShiftCapacity()
        {

        }
        public DataSet GetTestAndShiftCapacity(DateTime TestDate, int TestState, int TestCity, int TestCentre)
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(4);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestDate", TestDate, ParameterDirection.Input);
                dbManager.AddParameters(1, "@TestState", TestState, ParameterDirection.Input);
                dbManager.AddParameters(2, "@TestCity", TestCity, ParameterDirection.Input);
                dbManager.AddParameters(3, "@TestCentre", TestCentre, ParameterDirection.Input);
                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "UspGetTestAndShiftCapacity"));

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
        public void UpdateTestCapcityAndShiftCapacity(int ShiftId, int TestId, int TestCount, int ShiftCount)
        {
            try
            {
                conn = new DBConnection();
                //Fetching connection string from Config file through GetConnectionString()
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(4);		//Number of parameters to be passed in StoredProcedure				
                dbManager.AddParameters(0, "@TestId", TestId, ParameterDirection.Input);
                dbManager.AddParameters(1, "@ShiftID", ShiftId, ParameterDirection.Input);
                dbManager.AddParameters(2, "@ShiftCapacity", ShiftCount, ParameterDirection.Input);
                dbManager.AddParameters(3, "@TestCapacity", TestCount, ParameterDirection.Input);
                dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "UspUpdateTestCapcityAndShiftCapacity");
                dbManager.CommitTransaction();
                dbManager.Close();
            }
            catch (Exception SysEx)
            {
                dbManager.RollbackTransaction();
                //ErrorLogger.ErrorRoutine(false,SysEx);
                //To Pass Execption in exception class for show exception
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public DataSet UspGetTestDateDetails(DateTime TestDate, int TestState, int TestCity, int TestCentre)
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(4);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestDate", TestDate, ParameterDirection.Input);
                dbManager.AddParameters(1, "@TestState", TestState, ParameterDirection.Input);
                dbManager.AddParameters(2, "@TestCity", TestCity, ParameterDirection.Input);
                dbManager.AddParameters(3, "@TestCentre", TestCentre, ParameterDirection.Input);
                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "UspGetTestDateDetails"));
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

        public void UpdateTestDateAndTestTime(int ShiftId, int TestId, int IsShiftTime, DateTime TestDate, DateTime TestTime)
        {
            try
            {
                conn = new DBConnection();
                //Fetching connection string from Config file through GetConnectionString()
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.BeginTransaction();
                dbManager.CreateParameters(5);		//Number of parameters to be passed in StoredProcedure				
                dbManager.AddParameters(0, "@TestId", TestId, ParameterDirection.Input);
                dbManager.AddParameters(1, "@ShiftID", ShiftId, ParameterDirection.Input);
                dbManager.AddParameters(2, "@IsShiftTime", IsShiftTime, ParameterDirection.Input);
                dbManager.AddParameters(3, "@TestDate", TestDate, ParameterDirection.Input);
                dbManager.AddParameters(4, "@TestTime", TestTime, ParameterDirection.Input);
                dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "UspUpdateTestDateAndTestTime");
                dbManager.CommitTransaction();
                dbManager.Close();
            }
            catch (Exception SysEx)
            {
                dbManager.RollbackTransaction();
                //ErrorLogger.ErrorRoutine(false,SysEx);
                //To Pass Execption in exception class for show exception
                ExceptionHandling.ELExceptionHandler.ProcessErrorWithPageThrow(SysEx);
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }
    }
}

