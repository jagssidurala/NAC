using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using DataBaseAccessLayer;

namespace BusinessLayer
{
    public class BLContactUs
    {
        //Variable decalaration for DB Access
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private DataAccessLayer.DBConnection conn;
        private string strConn;

        //Variable declaration for saving feedback values

        private int queryType;
        private string feedbackSubject;
        private string feedbackMessage;
        private string emailID;
        private string mobilePhone;
        private string stdCode;
        private string landlinePhoneNo;

        //Properties

        public int QueryType
        {
            get { return queryType; }
            set { queryType = value; }
        }

        public string FeedbackSubject
        {
            get { return feedbackSubject; }
            set { feedbackSubject = value; }
        }


        public string FeedbackMessage
        {
            get { return feedbackMessage; }
            set { feedbackMessage = value; }
        }


        public string EmailID
        {
            get { return emailID; }
            set { emailID = value; }
        }


        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        public string STDCode
        {
            get { return stdCode; }
            set { stdCode = value; }
        }

        public string LandlinePhoneNo
        {
            get { return landlinePhoneNo; }
            set { landlinePhoneNo = value; }
        }

        //Populate feedback type dropdown
        public DataTable FillFeedbackType()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "GetFeedbackType").Tables[0];

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

        //Insert values in database
        public int InsertFeedbackDetails()
        {
            int flag = 0;
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.BeginTransaction(IsolationLevel.RepeatableRead);
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "@QueryType", QueryType, ParameterDirection.Input);
                dbManager.AddParameters(1, "@FeedbackSubject", FeedbackSubject, ParameterDirection.Input);
                dbManager.AddParameters(2, "@FeedbackMessage", FeedbackMessage, ParameterDirection.Input);
                dbManager.AddParameters(3, "@EmailID", EmailID, ParameterDirection.Input);
                dbManager.AddParameters(4, "@MobilePhone", MobilePhone, ParameterDirection.Input);
                dbManager.AddParameters(5, "@STDCode", STDCode, ParameterDirection.Input);
                dbManager.AddParameters(6, "@LandlinePhoneNo", LandlinePhoneNo, ParameterDirection.Input);
                flag = Convert.ToInt32(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, "AddFeedbackDetail"));
                dbManager.CommitTransaction();
                dbManager.Close();                
                return flag;

            }
            catch
            {
                dbManager.RollbackTransaction();
                dbManager.Close();
                dbManager.Dispose();
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
