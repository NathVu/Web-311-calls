using System;
using System.Collections.Generic;
using System.Text;
using SODA;

namespace CallsData
{
    class SodaConnector
    {

        public SodaConnector() { }

        public IEnumerable<Dictionary<string, object>> LoadDB(DateTime date)
        {
            SODA.SodaClient client = new SodaClient("https://data.cityofnewyork.us", Properties.Resources.SODA_API_Key);

            SODA.Resource<Dictionary<string, object>> dataset = client.GetResource<Dictionary<string, object>>("fhrw-4uyv");
            SoqlQuery soql = this.GetQueryDate(date);
            IEnumerable<Dictionary<string, object>> results = dataset.Query<Dictionary<string, object>>(soql);
            return results;
        }

        public SODA.SoqlQuery GetQueryDate(DateTime date)
        {
            DateTime today = date;
            String year = today.Year.ToString();
            String month;
            if (today.Month / 10 != 0)
            {
                month = today.Month.ToString();
            }
            else
            {
                month = "0" + today.Month.ToString();
            }

            String yday = (today.Day - 3).ToString();

            String ydate = "\"" + year + "-" + month + "-" + yday + "T00:00:00.000\"";

            string cdate = "created_date";

            SODA.SoqlQuery soql;
            if (today.Hour < 10)
            {
                soql = new SoqlQuery().Select("*").Where(cdate + ">" + date);
            }
            else
            {
                soql = new SoqlQuery().Select("*").Where(cdate + ">" + ydate);
            }

            return soql;
        }

    }
}
