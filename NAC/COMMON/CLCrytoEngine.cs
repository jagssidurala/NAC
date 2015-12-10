///====================================================================
/// Name: CLCrytoEngine.cs
/// 
///     This will handle encryption and decryption of strings, string 
///     arrays, DataSets and DataTables
///     
/// Construction Date: 06 Sep, 2006
/// Author: Sachin Dhir
///
/// Last Revision Date: 
/// Last Revision By:  
/// Last Revision Change: 
/// ====================================================================
/// Copyright (C) 2006-2007 NASSCOM  All Rights Reserved.
/// ====================================================================



using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;

namespace Common
{
	/// <summary>
	/// CryptoEngine class contains static methods to encrypt and decrypt strings.
	/// </summary>
	public class CLCrytoEngine
	{
		#region Encryption Key
		/// <summary>
		/// EncryptionKey is a static readonly variable to store Encryption key used in
		/// hashing and encryption process
		/// </summary>
		private static readonly string EncryptionKey = "QC834734HXD32SKDFH2834YNE89S3QI2EYS1WMQWSU28N1XWU";
		#endregion

		#region Encrypt(string) method
		/// <summary>
		/// Encrypt a string using dual encryption method. Return an encrypted string.
		/// </summary>
		/// <param name="toEncrypt">string to be encrypted</param>
		/// <returns>encrypted string</returns>
		public static string Encrypt(string toEncrypt)
		{
			//return toEncrypt;
			byte[] keyArray;
			byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			//Using MD5 Algorithm for hashing
			MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

			//Computing Hash value for EncryptionKey provided
			keyArray = objHashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(EncryptionKey));

			//Releasing the resources allocated while hashing
			objHashMD5.Clear();

			//Using 3DES Algorithm for encryption
			TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();

			//Setting Key, Mode and Padding mode properties of 3DES
			tDES.Key = keyArray;
			tDES.Mode = CipherMode.ECB;
			tDES.Padding = PaddingMode.PKCS7;

			//Creates symmetric encryptor object
			ICryptoTransform cTransform = tDES.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			//Releasing the resources allocated while decryption
			tDES.Clear();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
		#endregion

		#region Decrypt(string) method
		/// <summary>
		/// Decrypt a string using dual encryption method. Returns a decrypted string.
		/// </summary>
		/// <param name="toDecrypt">encrypted string</param>
		/// <returns>decrypted string</returns>
		public static string Decrypt(string toDecrypt)
		{
			//return(toDecrypt);
			byte[] keyArray;
			byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

			//Using MD5 Algorithm for hashing
			MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

			//Computing Hash value for EncryptionKey provided
			keyArray = objHashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(EncryptionKey));
			
			//Releasing the resources allocated while hashing
			objHashMD5.Clear();			
			
			//Using 3DES Algorithm for decryption
			TripleDESCryptoServiceProvider tDES = new TripleDESCryptoServiceProvider();

			//Setting Key, Mode and Padding mode properties of 3DES
			tDES.Key = keyArray;
			tDES.Mode = CipherMode.ECB;
			tDES.Padding = PaddingMode.PKCS7;

			//Creates symmetric decryptor object
			ICryptoTransform cTransform = tDES.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
               
			//Releasing the resources allocated while decryption
			tDES.Clear();
			return UTF8Encoding.UTF8.GetString(resultArray);
		}
		#endregion

		#region Encrypt(string[]) method
		/// <summary>
		/// Encrypt an array of strings using dual encryption method. 
		/// Returns an array of encrypted strings.
		/// </summary>
		/// <param name="toDecrypt">array of strings</param>
		/// <returns>array of encrypted strings</returns>
		public static string[] Encrypt(string[] toEncrypt)
		{
			int Counter = 0;
			string[] EncryptedCollection = new string[toEncrypt.Length];
			for(Counter = 0 ; Counter < toEncrypt.Length ; Counter++)
			{
				//Call Encrypt() method to encrypt each string in the array
				EncryptedCollection[Counter] = Encrypt(toEncrypt[Counter]);
			}
			//returns encrypted string array
			return EncryptedCollection;
		}
		#endregion

		#region Decrypt(string[]) method
		/// <summary>
		/// Decrypt an array of encrypted strings using dual encryption method. 
		/// Returns an array of decrypted strings.
		/// </summary>
		/// <param name="toDecrypt">array of encrypted strings</param>
		/// <returns>array of decrypted strings</returns>
		public static string[] Decrypt(string[] toDecrypt)
		{
			int Counter = 0;
			string[] DecryptedCollection = new string[toDecrypt.Length];
			for(Counter = 0 ; Counter < toDecrypt.Length ; Counter++)
			{
				//Call Decrypt() method to decrypt each encrypted string in the array
				DecryptedCollection[Counter] = Decrypt(toDecrypt[Counter]);
			}
			//returns decrypted string array
			return DecryptedCollection;
		}
		#endregion

		#region Encrypt(DataTable) method
		/// <summary>
		/// Decrypt contents of DataTable using dual encryption method. 
		/// Returns encrypted DataTable.
		/// </summary>
		/// <param name="toDecrypt">DataTable</param>
		/// <returns>encrypted DataTable</returns>
		public static DataTable Encrypt(DataTable toEncrypt)
		{
			DataTable DataTableTemp = new DataTable();
			DataTableTemp = toEncrypt.Clone();

			for(int RowCounter = 0 ; RowCounter < toEncrypt.Rows.Count; RowCounter++)
			{
				//Call Decrypt() method to encrypt each row in the DataTable
				DataTableTemp.Rows.Add(ConvertToEncryptedStringArray(toEncrypt.Rows[RowCounter].ItemArray));
			}
			DataTableTemp.AcceptChanges();
			toEncrypt.Dispose();
			//returns decrypted DataTable
			return DataTableTemp;
		}
		#endregion

		#region Decrypt(DataTable) method
		/// <summary>
		/// Decrypt contents of encrypted DataTable using dual encryption method. 
		/// Returns DataTable.
		/// </summary>
		/// <param name="toDecrypt">encrypted DataTable</param>
		/// <returns>decrypted DataTable</returns>
		public static DataTable Decrypt(DataTable toDecrypt)
		{
			DataTable DataTableTemp = new DataTable();
			DataTableTemp = toDecrypt.Clone();
			for(int RowCounter = 0 ; RowCounter < toDecrypt.Rows.Count; RowCounter++)
			{
				//Call ConvertToDecryptedStringArray() method to decrypt each row in the DataTable
				DataTableTemp.Rows.Add(ConvertToDecryptedStringArray(toDecrypt.Rows[RowCounter].ItemArray));
			}
			DataTableTemp.AcceptChanges();
			toDecrypt.Dispose();
			//returns decrypted DataTable
			return DataTableTemp;
		}
		#endregion

		#region Encrypt(DataSet) method
		/// <summary>
		/// Decrypt contents of DataSet using dual encryption method. 
		/// Returns encrypted DataSet.
		/// </summary>
		/// <param name="toDecrypt">DataSet</param>
		/// <returns>encrypted DataSet</returns>
		public static DataSet Encrypt(DataSet toEncrypt)
		{
			DataSet DataSetTemp = new DataSet();
			DataSetTemp = toEncrypt.Clone();
			for(int TableCounter = 0 ; TableCounter < toEncrypt.Tables.Count ; TableCounter++)
			{
				for(int RowCounter = 0 ; RowCounter < toEncrypt.Tables[TableCounter].Rows.Count; RowCounter++)
				{
					//Call Encrypt() method to encrypt each row of tables in the DataSet
					DataSetTemp.Tables[TableCounter].Rows.Add(ConvertToEncryptedStringArray(toEncrypt.Tables[TableCounter].Rows[RowCounter].ItemArray));
				}
			}		
			DataSetTemp.AcceptChanges();
			toEncrypt.Dispose();
			//returns encrypted DataSet
			return DataSetTemp;
		}
		#endregion

		#region Decrypt(DataSet) method
		/// <summary>
		/// Decrypt contents of encrypted DataSet using dual encryption method. 
		/// Returns DataSet.
		/// </summary>
		/// <param name="toDecrypt">encrypted DataSet</param>
		/// <returns>decrypted DataSet</returns>
		public static DataSet Decrypt(DataSet toDecrypt)
		{
			
			DataSet DataSetTemp = new DataSet();
			DataSetTemp = toDecrypt.Clone();
			for(int TableCounter = 0 ; TableCounter < toDecrypt.Tables.Count ; TableCounter++)
			{
				for(int RowCounter = 0 ; RowCounter < toDecrypt.Tables[TableCounter].Rows.Count; RowCounter++)
				{
					DataSetTemp.Tables[TableCounter].Rows.Add(ConvertToDecryptedStringArray(toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray));
				}
			}		
			DataSetTemp.AcceptChanges();
			toDecrypt.Dispose();
			return DataSetTemp;
		}
		#endregion

		#region SelectiveDecrypt(DataSet) method
		/// <summary>
		/// Decrypt contents of encrypted DataSet excluding first integer column as identity
		/// using dual encryption method. 
		/// Returns decrypted DataSet.
		/// </summary>
		/// <param name="toDecrypt">encrypted DataSet with first column not encrypted</param>
		/// <returns>decrypted DataSet</returns>
		public static DataSet SelectiveDecrypt(DataSet toDecrypt)
		{
			
			DataSet DataSetTemp = new DataSet();
			DataSetTemp = toDecrypt.Clone();
			for(int TableCounter = 0 ; TableCounter < toDecrypt.Tables.Count ; TableCounter++)
			{
				for(int RowCounter = 0 ; RowCounter < toDecrypt.Tables[TableCounter].Rows.Count; RowCounter++)
				{
					//Creating a new Row to temporary DataSet
					DataRow oDataRow = DataSetTemp.Tables[TableCounter].NewRow();
					//Updating Row
					oDataRow.BeginEdit();
					oDataRow[0] = toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(0).ToString();
					for(int ColCounter = 1; ColCounter < toDecrypt.Tables[TableCounter].Columns.Count ; ColCounter++)
					{
						string tempValue = Decrypt(toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(ColCounter).ToString());
						oDataRow[ColCounter] = tempValue;
					}
					oDataRow.EndEdit();
					//Adding updated row to temporary DataSet
					DataSetTemp.Tables[TableCounter].Rows.Add(oDataRow);
					//Commit changes to the DataSet
					DataSetTemp.AcceptChanges();
				}
			}		
			DataSetTemp.AcceptChanges();
			toDecrypt.Dispose();
			return DataSetTemp;
		}
		#endregion

		#region
		public static DataSet SelectiveDecrypt1(DataSet toDecrypt)
		{
			
			DataSet DataSetTemp = new DataSet();
			DataSetTemp = toDecrypt.Clone();
			for(int TableCounter = 0 ; TableCounter < toDecrypt.Tables.Count ; TableCounter++)
			{
				if(TableCounter == 0)
				{
					for(int RowCounter = 0 ; RowCounter < toDecrypt.Tables[TableCounter].Rows.Count; RowCounter++)
					{
						//Creating a new Row to temporary DataSet
						DataRow oDataRow = DataSetTemp.Tables[TableCounter].NewRow();
						//Updating Row
						oDataRow.BeginEdit();
						oDataRow[0] = toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(0).ToString();
						oDataRow[1] = toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(1).ToString();
						for(int ColCounter = 2; ColCounter < toDecrypt.Tables[TableCounter].Columns.Count ; ColCounter++)
						{
							string tempValue = Decrypt(toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(ColCounter).ToString());
							oDataRow[ColCounter] = tempValue;
						}
						oDataRow.EndEdit();
						//Adding updated row to temporary DataSet
						DataSetTemp.Tables[TableCounter].Rows.Add(oDataRow);
						//Commit changes to the DataSet
						DataSetTemp.AcceptChanges();
					}
				}
				else
				{
					for(int RowCounter = 0 ; RowCounter < toDecrypt.Tables[TableCounter].Rows.Count; RowCounter++)
					{
						//Creating a new Row to temporary DataSet
						DataRow oDataRow = DataSetTemp.Tables[TableCounter].NewRow();
						//Updating Row
						oDataRow.BeginEdit();
						oDataRow[0] = toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(0).ToString();
						
						for(int ColCounter = 1; ColCounter < toDecrypt.Tables[TableCounter].Columns.Count ; ColCounter++)
						{
							string tempValue = Decrypt(toDecrypt.Tables[TableCounter].Rows[RowCounter].ItemArray.GetValue(ColCounter).ToString());
							oDataRow[ColCounter] = tempValue;
						}
						oDataRow.EndEdit();
						//Adding updated row to temporary DataSet
						DataSetTemp.Tables[TableCounter].Rows.Add(oDataRow);
						//Commit changes to the DataSet
						DataSetTemp.AcceptChanges();
					}
				}
			}		
			DataSetTemp.AcceptChanges();
			toDecrypt.Dispose();
			return DataSetTemp;
		}
		#endregion

		#region ConvertToDecryptedStringArray(object[]) method
		/// <summary>
		/// Decrypt contents of object array using dual encryption method. 
		/// Returns decrypted string array.
		/// </summary>
		/// <param name="toConvert">object array</param>
		/// <returns>decrypted string array</returns>
		private static string[] ConvertToDecryptedStringArray(object[] toConvert)
		{
			string[] ConvertedStringArray = new string[toConvert.Length];
			for(int counter = 0; counter < toConvert.Length ; counter++)
			{
				ConvertedStringArray[counter] = Decrypt(toConvert[counter].ToString());
			}
			return ConvertedStringArray;
		}
		#endregion

		#region ConvertToEncryptedStringArray(object[]) method
		/// <summary>
		/// Encrypt contents of object array using dual encryption method. 
		/// Returns encrypted string array.
		/// </summary>
		/// <param name="toConvert">object array</param>
		/// <returns>encrypted string array</returns>
		private static string[] ConvertToEncryptedStringArray(object[] toConvert)
		{
			string[] ConvertedStringArray = new string[toConvert.Length];
			for(int counter = 0; counter < toConvert.Length ; counter++)
			{
				ConvertedStringArray[counter] = Encrypt(toConvert[counter].ToString());
			}
			return ConvertedStringArray;
		}
		#endregion
	}
}
