using System;

namespace DataAccessLayer
{
	/// <summary>
	/// Summary description for DBQuery.
	/// </summary>
	public class DBQuery
	{
		public string ReadFromXML(string strQueryID,string strFile)
		{
			try
			{
				System.Data.DataSet datasetObj=new System.Data.DataSet()   ;
				datasetObj.ReadXml(strFile,System.Data.XmlReadMode.InferSchema);
				if (datasetObj !=null)
				{
					for (int i=0;i< datasetObj.Tables[0].Rows.Count;i++)
					{
						if (datasetObj.Tables[0].Rows[i].ItemArray[0].ToString()  == strQueryID) 
						{
							string strValue=datasetObj.Tables[0].Rows[i].ItemArray[1].ToString();
							datasetObj=null;
							return (strValue);
						}
					}
				}
				return "";
			}
			catch
			{
				
			}
			return "";
		}
	}
}
