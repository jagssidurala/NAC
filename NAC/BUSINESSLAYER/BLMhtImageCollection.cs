using System;
using System.Collections;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for BLMhtImageCollection.
	/// </summary>
	public class BLMhtImageCollection : ArrayList
	{
		private BLMhtImage[] objBLMhtImage = new BLMhtImage[100];

		public void add(BLMhtImage value)
		{
		     base.Add(value);
		}
 
		public void insert(int index, BLMhtImage value)
		{
		   base.Insert(index,value);
		}

		public BLMhtImage this [int index]   // Indexer declaration
		{
			get 
			{
				return objBLMhtImage[index];
			}
			set 
			{
				objBLMhtImage[index] = value;
			}
		}

    

		public BLMhtImageCollection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
