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
  public  class BLRegistrationWindow
    {
       public BLRegistrationWindow()
        { 
        }

        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;


        private DateTime testDateFrom;

        public DateTime TestDateFrom
        {
            get { return testDateFrom; }
            set { testDateFrom = value; }
        }
        private DateTime testDateTo;

        public DateTime TestDateTo
        {
            get { return testDateTo; }
            set { testDateTo = value; }
        }
        private int testState;

        public int TestState
        {
            get { return testState; }
            set { testState = value; }
        }
        private int testCity;

        public int TestCity
        {
            get { return testCity; }
            set { testCity = value; }
        }
        private int testCentre;

        public int TestCentre
        {
            get { return testCentre; }
            set { testCentre = value; }
        }

      
        public DataSet GetDetails()
        {
            try
            {
                conn = new DBConnection();
                //Fetching connection string from Config file through GetConnectionString()
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.CreateParameters(5);
                int counter = 0;

                dbManager.AddParameters(counter++, "@TestDateFrom", TestDateFrom);
                dbManager.AddParameters(counter++, "@TestDateTo", TestDateTo);

                dbManager.AddParameters(counter++, "@TestState", TestState);
                dbManager.AddParameters(counter++, "@TestCity", TestCity);
                dbManager.AddParameters(counter++, "@TestCentre", TestCentre);

                return ((DataSet)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetActiveTest"));

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbManager.Close();
            }
            return null;
        }


      public int UpdateRegistrationDate(string strTestId,DateTime endDate)
      {
          int status = 0;
          try
          {
              conn = new DBConnection();
              //Fetching connection string from Config file through GetConnectionString()
              strConn = conn.GetConnectionString();
              dbManager = new DBManager(DataProvider.SqlServer);
              dbManager.ConnectionString = strConn.ToString();
              dbManager.Open();

              dbManager.CreateParameters(2);
              int counter = 0;

              dbManager.AddParameters(counter++, "@Testid", strTestId);
              dbManager.AddParameters(counter++, "@RegistrationEndDate", endDate);


              status = dbManager.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateRegistrationEndDate");
              dbManager.CommitTransaction();
          }
          catch (Exception ex)
          {
              dbManager.RollbackTransaction();
              throw ex;
          }
          finally
          {
              dbManager.Close();
          }

          return status;
      }
    }
}
