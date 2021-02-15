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
            html += "<thead>";
            html += "<tr>";
            html += "<th>" + "State" + "</th>";
            html += "<th>" + "Submisson Date" + "</th>";
            html += "<th>" + "Total Deaths" + "</th>";
            html += "<th>" + "Percentage" + "</th>";


            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";


            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                
                    html += "<td>" + dt.Rows[i][1].ToString() + "</td>";
                html += "<td>" + dt.Rows[i][0].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["tot_death"].ToString() + "</td>";
                html += "<td>" + dt.Rows[i]["Percentage"].ToString() + "</td>";



                html += "</tr>";
            }
            html += "</tbody>";

            html += "</table>";
            return html;
        }
    }
}