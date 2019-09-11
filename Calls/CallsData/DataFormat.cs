using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallsData
{
    public class DataFormat
    {

        public List<Json311> ParseData(Dictionary<string, object>[] dataset)
        {
            List<Json311> dataList = new List<Json311>();
            DateTime date = DateTime.Today.Date.AddDays(-1);
            for (int i = 0; i < dataset.Length; i++)
            {
                Json311 dItem = new Json311(dataset[i]);
                if (dItem.Created_date < date)
                {
                    dataList.Add(dItem);
                }
            }
            return dataList;
        }

        public Dictionary<string, object>[] GetData(DateTime date)
        {
            SodaConnector test = new SodaConnector();
            IEnumerable<Dictionary<string, object>> results = test.LoadDB(date);

            Dictionary<string, object>[] results_arr = results.ToArray();
            return results_arr;
        }
    }

}
