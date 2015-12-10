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
    /// <summary>
    /// Summary description for BLImportExportXLS.
    /// </summary>
    public class BLImportExportXLS
    {
        IDBManager dbManager = new DBManager(DataProvider.SqlServer);
        private string strCandidateRegistrationList;
        private string strConn;
        private DataAccessLayer.DBConnection conn;

        public string CandidateRegistrationList
        {
            get
            {
                return strCandidateRegistrationList;
            }
            set
            {
                strCandidateRegistrationList = value;
            }
        }
        public DataTable ExportTJVisitorToExcel()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@VisitorRegistrationIdList", CandidateRegistrationList, ParameterDirection.Input);
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "ExportTJVisitorToExcel").Tables[0];
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

        public DataTable ExportCandidateListByAdmin()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@CandidateRegistrationList", CandidateRegistrationList, ParameterDirection.Input);
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "ExportCandidateListByAdmin").Tables[0];
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

        //Added By manoj on 18 Nov 2010	
        public DataTable ExportCandidateListByCompanyV2()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@CandidateRegistrationList", CandidateRegistrationList, ParameterDirection.Input);
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "ExportCandidateListByCompanyV2").Tables[0];
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


        //Added By manoj on 05 May 2011
        public DataTable ExportCandidateListByAdminV2()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@CandidateRegistrationList", CandidateRegistrationList, ParameterDirection.Input);

                // Added and Commented by Sonali
                //return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"ExportCandidateListByAdminV2").Tables[0];
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "ExportSelectedCandidateListByAdmin").Tables[0];

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


        public DataTable ExportCandidateListByETS()
        {
            try
            {
                conn = new DBConnection();
                strConn = conn.GetConnectionString();
                dbManager = new DBManager(DataProvider.SqlServer);
                dbManager.CreateParameters(1);
                dbManager.ConnectionString = strConn.ToString();
                dbManager.Open();
                dbManager.AddParameters(0, "@CandidateRegistrationList", CandidateRegistrationList, ParameterDirection.Input);
                return dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure, "ExportCandidateListByETS").Tables[0];
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



        public BLImportExportXLS()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
