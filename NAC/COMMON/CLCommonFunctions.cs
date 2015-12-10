using System;
using System.Web.UI;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Common
{
    /// <summary>
    /// Summary description for CLCommonFunctions.
    /// </summary>
    public class CLCommonFunctions
    {

       
    
        public CLCommonFunctions()
        {

        }

      public const int StartDOBDropdown =1940;
      public const int StartGraduationDropdown =1970;
      public const int Start12Dropdown =1960;
      public const int StartTestDateDropdown =1949;
        
   
        public static string AlignValue(int toAlign, int toPlaces)
        {
            int Length = toAlign.ToString().Length;
            int ZerosToPad = toPlaces - Length;
            string AlignString = "";
            for (int Counter = 0; Counter < ZerosToPad; Counter++)
            {
                AlignString = AlignString + "0";
            }
            AlignString = AlignString + toAlign.ToString();
            return AlignString;
        }

        public static string ReturnDate(string strDate, int Format)
        {
            string dtReturnDate = "";
            string[] arrStrDate = strDate.Split('/');
            switch (Format)
            {

                case 0:

                    dtReturnDate = arrStrDate[1].ToString() + "/" + arrStrDate[0].ToString() + "/" + arrStrDate[2].ToString().Substring(0, 4);
                    break;
                case 1:

                    string MM = arrStrDate[0].ToString();
                    if ((MM == "01") || (MM == "1"))
                        MM = "Jan";
                    else if ((MM == "02") || (MM == "2"))
                        MM = "Feb";
                    else if ((MM == "03") || (MM == "3"))
                        MM = "Mar";
                    else if ((MM == "04") || (MM == "4"))
                        MM = "Apr";
                    else if ((MM == "05") || (MM == "5"))
                        MM = "May";
                    else if ((MM == "06") || (MM == "6"))
                        MM = "Jun";
                    else if ((MM == "07") || (MM == "7"))
                        MM = "Jul";
                    else if ((MM == "08") || (MM == "8"))
                        MM = "Aug";
                    else if ((MM == "09") || (MM == "9"))
                        MM = "Sep";
                    else if (MM == "10")
                        MM = "Oct";
                    else if (MM == "11")
                        MM = "Nov";
                    else if (MM == "12")
                        MM = "Dec";

                    dtReturnDate = arrStrDate[1].ToString() + " " + MM + ", " + arrStrDate[2].ToString().Substring(0, 4) + " " + arrStrDate[2].ToString().Substring(4, arrStrDate[2].Length - 10) + " " + arrStrDate[2].ToString().Substring(arrStrDate[2].ToString().Length - 2, 2);
                    break;
                default:
                    dtReturnDate = arrStrDate[1].ToString() + "/" + arrStrDate[0].ToString() + "/" + arrStrDate[2].ToString().Substring(0, 4);
                    break;

            }
            return dtReturnDate;
        }

        public DateTime ReturnDate(string strDate)
        {
            DateTime dtReturnDate;
            string[] arrStrDate = strDate.Split('/');
            dtReturnDate = DateTime.Parse(arrStrDate[1].ToString() + "/" + arrStrDate[0].ToString() + "/" + arrStrDate[2].ToString());
            return dtReturnDate;
        }

        public string CreateSeries(string PassId)
        {
            string ReturnId = "";

            if (PassId.Length == 1)
                ReturnId = "0000" + PassId.ToString();
            else if (PassId.Length == 2)
                ReturnId = "000" + PassId.ToString();
            else if (PassId.Length == 3)
                ReturnId = "00" + PassId.ToString();
            else if (PassId.Length == 4)
                ReturnId = "0" + PassId.ToString();
            else if (PassId.Length == 5)
                ReturnId = PassId.ToString();

            return ReturnId;

        }

        public static void CheckSession()
        {
            HttpContext c = HttpContext.Current;
            string strRequestURL = c.Request.Url.AbsoluteUri;

            if (c.Session.Keys.Count == 0)
                c.Server.Transfer(strRequestURL);

            if ((c.Session.Keys.Count > 1) && (c.Session["UserID"].ToString() == ""))
            {
                try
                {
                    c.Session.Abandon();
                    c.Server.Transfer("PinDefault.aspx");
                }
                catch (ThreadAbortException ex)
                {
                    throw ex;
                }
            }


        }

        public static DataTable CreateDataTable(string[] arrColumnName, string[] arrColumnType)
        {

            System.Data.DataTable myDataTable = new DataTable("TempTable");
            for (int i = 0; i <= arrColumnName.Length - 1; i++)
            {
                // Declare variables for DataColumn and DataRow objects.
                DataColumn myDataColumn;
                // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
                myDataColumn = new DataColumn();
                if (arrColumnType[i].Equals("String"))
                    myDataColumn.DataType = System.Type.GetType("System.String");
                else if (arrColumnType[i].Equals("Int"))
                    myDataColumn.DataType = System.Type.GetType("System.Int");
                myDataColumn.ColumnName = arrColumnName[i];
                // Add the Column to the DataColumnCollection.
                myDataTable.Columns.Add(myDataColumn);
            }
            return myDataTable;

        }


        //Comman Function for year binding to dropdown
        //public ArrayList ReturnYearList(int startYear)
        //{
        //    int thisYear = Convert.ToInt32(System.DateTime.Now.Year);
        //    ArrayList collection = new ArrayList();
        //    collection.Add(new ListItem( "0","Year"));
           
        //    for (int i = thisYear; i >= startYear; i--)
        //    {
        //        collection.Add(new ListItem((i.ToString()), i.ToString()));

        //    }

        //    return collection;
        //}



        public DataTable ReturnYearList(int startYear)
        {
            int thisYear = Convert.ToInt32(System.DateTime.Now.Year);
            DataTable dtyear = new DataTable();
            DataColumn dcYear = new DataColumn("Year", typeof(System.String));
            DataColumn dcValue = new DataColumn("Value", typeof(System.Int32));
            dtyear.Columns.Add(dcYear);
            dtyear.Columns.Add(dcValue);

            DataRow dr = dtyear.NewRow();
            dr["Year"] = "Year";
            dr["Value"] = 0;
            dtyear.Rows.Add(dr);

            DataRow dr1 = null;
            for (int i = thisYear+1; i >= startYear; i--)
            {
                dr1 = dtyear.NewRow();

                dr1["Year"] = i.ToString();
                dr1["Value"] = i;
                dtyear.Rows.Add(dr1);
            }
            return dtyear;

        }

        public DataTable ReturnMonthList()
        {
            
            DataTable dtMonth = new DataTable();
            DataColumn dcMonth = new DataColumn("Month", typeof(System.String));
            DataColumn dcValue = new DataColumn("Value", typeof(System.Int32));
            dtMonth.Columns.Add(dcMonth);
            dtMonth.Columns.Add(dcValue);
            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;
            DataRow dr = dtMonth.NewRow();
            dr["Month"] = "Month";
            dr["Value"] = 0;
            dtMonth.Rows.Add(dr);
           
            DataRow dr1 = null;
            for (int i = 0; i < names.Length-1; i++)
            {
                dr1 = dtMonth.NewRow();

                dr1["Month"] = names[i];
                dr1["Value"] = i+1;
                dtMonth.Rows.Add(dr1);
            }
            return dtMonth;

        }

        public DataTable ReturnDayList()
        {

            DataTable dtDay = new DataTable();
            DataColumn dcDay = new DataColumn("Day", typeof(System.String));
            DataColumn dcValue = new DataColumn("Value", typeof(System.Int32));
            dtDay.Columns.Add(dcDay);
            dtDay.Columns.Add(dcValue);
            DataRow dr = dtDay.NewRow();
            dr["Day"] = "Day";
            dr["Value"] = 0;
            dtDay.Rows.Add(dr);

            DataRow dr1 = null;
            for (int i = 1; i <=31; i++)
            {
                dr1 = dtDay.NewRow();

                dr1["Day"] =i.ToString ();
                dr1["Value"] = i;
                dtDay.Rows.Add(dr1);
            }
            return dtDay;

        }

    }


}

 