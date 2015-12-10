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
    public class BLDatesExtensionByAdmin
    {
        public BLDatesExtensionByAdmin()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;

        private string eventName;
        private string testCenter;
        private int testId;
        private int cityId;
        private string systemIP;
        private DateTime testDate;
        private DateTime updatedTestDate;
        private DateTime registrationEndDate;
        private DateTime updatedRegistrationEndDate;

        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }

        public string TestCenter
        {
            get { return testCenter; }
            set { testCenter = value; }
        }

        public int TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        public string SystemIP
        {
            get { return systemIP; }
            set { systemIP = value; }
        }
        public DateTime TestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }

        public DateTime UpdatedTestDate
        {
            get { return updatedTestDate; }
            set { updatedTestDate = value; }
        }

        public DateTime RegistrationEndDate
        {
            get { return registrationEndDate; }
            set { registrationEndDate = value; }
        }

        public DateTime NewRegistrationEndDate
        {
            get { return updatedRegistrationEndDate; }
            set { updatedRegistrationEndDate = value; }
        }

        public DataTable FillTestEvent()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetActiveEvents").Tables[0];
            }
            catch
            {
                throw;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public DataSet FillTestDetails()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                DataSet dsTestDetails = new DataSet();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestId", TestId, ParameterDirection.Input);
                dsTestDetails = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetTestDetails");
                return dsTestDetails;
            }
            catch
            {
                throw;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

        public void UpdateRegistrationEndDate()
        {
             try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(3);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@TestId", TestId, ParameterDirection.Input);
                dbManager.AddParameters(1, "@NewRegistrationEndDate", NewRegistrationEndDate, ParameterDirection.Input);
                dbManager.AddParameters(2, "@SystemIP", SystemIP, ParameterDirection.Input);
                dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, "UpdateRegistrationEndDate");
                dbManager.CommitTransaction();                
            }
            catch
            {
                throw;
            }
            finally
            {
                dbManager.Close();
                dbManager.Dispose();
            }
        }

    }
}
