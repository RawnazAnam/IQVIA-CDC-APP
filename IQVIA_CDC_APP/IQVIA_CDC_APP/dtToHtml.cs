using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IQVIA_CDC_APP
{
    public class dtToHtml
    {

        public string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table id= \"example\" class=\"table table-striped table - bordered\" style=\"width: 100 % \">";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if(dt.Columns[i].ColumnName.Equals("state")|| dt.Columns[i].ColumnName.Equals("submission_date")|| dt.Columns[i].ColumnName.Equals("tot_death"))
                {

                    html += "<td>" + dt.Columns[i].ColumnName + "</td>";
                }
                
            }
                
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                
                    html += "<td>" + dt.Rows[i][1].ToString() + "</td>";
                html += "<td>" + dt.Rows[i][0].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["tot_death"].ToString() + "</td>";


                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
    }
}