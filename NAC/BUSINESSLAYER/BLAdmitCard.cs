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
    /// Summary description for BLAdmitCard.
    /// </summary>
    public class BLAdmitCard
    {
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private string strConn;
        private DataAccessLayer.DBConnection conn;


        public BLAdmitCard() { }

        public DataSet GenerateAdmitCard(string RegistrationId)
        {
            try
            {
                DataSet dsAdmitCard = new DataSet();
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@RegistrationId", RegistrationId);
                dsAdmitCard = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetAdmitCardDetails");
                return dsAdmitCard;

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

        public DataSet GenerateMultipleAdmitCard(string RegistrationId)
        {
            try
            {
                DataSet dsAdmitCard = new DataSet();
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@strRegistration", RegistrationId);
                dsAdmitCard = dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetMultipleAdmitCardDetails");
                return dsAdmitCard;

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

        public DataTable GetUserDetailToSendAMail(string RegistrationId)
        {
            try
            {

                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@RegistrationId", RegistrationId);
                return ((DataTable)dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetUserDetailToSendAMail").Tables[0]);

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
