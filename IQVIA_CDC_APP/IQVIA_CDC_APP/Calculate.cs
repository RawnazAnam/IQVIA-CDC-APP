using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQVIA_CDC_APP
{
    public class Calculate
    {
        DataTable otherDt = new DataTable();
        object sumObject;
        public DataTable calculate(DataTable dt)
        {
            string [] states = { "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY" };

            DataTable stateTable=new DataTable();

            for (int i = 0; i < states.Length; i++)
            {

                var rows = from row in dt.AsEnumerable()
                           where row.Field<string>("state").Trim() == states[i]
                           select row;
                try
                {
                    DataTable temp = rows.CopyToDataTable();

                    DataColumn col = temp.Columns[0];
                    DataTable tbl = col.Table;
                    var first = tbl.AsEnumerable()
                   .Select(cols => cols.Field<DateTime>(col.ColumnName))
                   .OrderByDescending(p => p.Ticks)
                   .FirstOrDefault();

                    var rows1 = from row in temp.AsEnumerable()
                                where row.Field<DateTime>("submission_date") == first
                                select row;

                    DataTable tb2 = rows1.CopyToDataTable();

                    stateTable.Merge(tb2);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            /*DataTable dtCloned = stateTable.Clone();
            dtCloned.Columns[7].DataType = typeof(Int32);
            foreach (DataRow row in stateTable.Rows)
            {
                dtCloned.ImportRow(row);
            }*/

           
            sumObject = stateTable.Compute("Sum(tot_death)", string.Empty);

           // int sum = Int32.Parse((string)sumObject);

            DataView dv = stateTable.DefaultView;

            dv.Sort = "tot_death desc";
            DataTable sortedDT = dv.ToTable();
            otherDt = sortedDT;
            return sortedDT;
        }

        public int getSum()
        { 
        int sum = Convert.ToInt32(sumObject);
            return sum;
        }

        public DataTable getState(string state, DataTable dt)
        {
            string j=otherDt.Rows.Count.ToString();
            DataTable stateTable = new DataTable();
            var rows = from row in dt.AsEnumerable()
                       where row.Field<string>("state").Trim() == state
                       select row;

            DataTable temp = rows.CopyToDataTable();
            stateTable.Merge(temp);
            return stateTable;
        }

    }
}