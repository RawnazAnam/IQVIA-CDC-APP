using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace IQVIA_CDC_APP
{
    public partial class Home : System.Web.UI.Page
    {
        //DataTable temp = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)    // if it's the first page load

            {

                var json = new WebClient().DownloadString("https://data.cdc.gov/resource/9mfq-cb36.json");

                //DataTable data = JsonConvert.DeserializeObject<DataTable>(json);
                var result = JsonConvert.DeserializeObject < List<CDCobject>>(json);

                ConvertToDataTable converter = new ConvertToDataTable();

                DataTable data = converter.convertToDataTable(result);
                Calculate obj = new Calculate();

                DataTable dt = obj.calculate(data);

                ddlState.DataSource = dt;
                ddlState.DataTextField = "state";
                ddlState.DataValueField = "state";
                ddlState.DataBind();

                cdcData.DataSource = dt;

                cdcData.DataBind();
                //temp = dt.Copy();
                int sum = obj.getSum();

                for (int i = 0; i < cdcData.Rows.Count; i++)
                {
                    
                    int num = Convert.ToInt32(cdcData.Rows[i].Cells[2].Text);
                    double percentage = num * 100.0 / sum ;
                    percentage = Math.Round(percentage, 2);
                    cdcData.Rows[i].Cells[3].Text = percentage + " %";
                }

                dtToHtml test1 = new dtToHtml();
                string t = test1.ConvertDataTableToHTML(dt);
                divDisplay.InnerHtml = t;

            }

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStates(ddlState.SelectedValue);
        }
        public void ShowStates(String selectedState)

        {

            var json = new WebClient().DownloadString("https://data.cdc.gov/resource/9mfq-cb36.json");

            //DataTable data = JsonConvert.DeserializeObject<DataTable>(json);
            var result = JsonConvert.DeserializeObject<List<CDCobject>>(json);

            ConvertToDataTable converter = new ConvertToDataTable();

            DataTable data = converter.convertToDataTable(result);
            Calculate obj = new Calculate();

            DataTable dt = obj.calculate(data);
           
            
            DataTable table=obj.getState(selectedState, dt);
            cdcData.DataSource = table;
            cdcData.DataBind();

            int sum = obj.getSum();

            for (int i = 0; i < cdcData.Rows.Count; i++)
            {

                int num = Convert.ToInt32(cdcData.Rows[i].Cells[2].Text);
                double percentage = num * 100.0 / sum;
                percentage = Math.Round(percentage, 2);
                cdcData.Rows[i].Cells[3].Text = percentage + " %";
            }


        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}