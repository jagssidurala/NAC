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
	/// Summary description for BLRegistrationPermissions.
	/// </summary>
	public class BLRegistrationPermissions
	{

		IDBManager dbManager = new DBManager(DataProvider.SqlServer);

		private string strConn;	
		private DataAccessLayer.DBConnection conn;

		private int  intStateID;
		private int  intCityID;
		private int  intCentreID;
		private int  intCurrentPage;
		private int  intPageSize;

		public int StateID
		{  
			get
			{	
				return intStateID;
			}
			set
			{				 
				intStateID = value;
			}
		}	

		public int CityID
		{  
			get
			{	
				return intCityID;
			}
			set
			{				 
				intCityID = value;
			}
		}	

		public int CentreID
		{  
			get
			{	
				return intCentreID;
			}
			set
			{				 
				intCentreID = value;
			}
		}	

		public int CurrentPage
		{  
			get
			{	
				return intCurrentPage;
			}
			set
			{				 
				intCurrentPage = value;
			}
		}	

		public int PageSize
		{  
			get
			{	
				return intPageSize;
			}
			set
			{				 
				intPageSize = value;
			}
		}	


		#region RegistrationPermissionDetail()

		public DataSet RegistrationPermissionDetail()
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

				dbManager.AddParameters(0, "@StateId", StateID);
				dbManager.AddParameters(1, "@CityId", CityID);
				dbManager.AddParameters(2, "@CentreId", CentreID);				
				dbManager.AddParameters(3, "@CurrentPage", CurrentPage);
				dbManager.AddParameters(4, "@PageSize", PageSize);
				 
				 			
			
				return ((DataSet) dbManager.ExecuteDataSet(System.Data.CommandType.StoredProcedure,"GetCentreStatusDetail"));				 
				 
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				dbManager.Close();
			}
		}


		#endregion 

		public BLRegistrationPermissions()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
