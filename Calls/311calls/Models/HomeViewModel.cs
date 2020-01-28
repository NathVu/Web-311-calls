using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CallsData;

namespace _311calls.Models
{
    public class HomeViewModel
    {
        public List<Json311> JsonData { get; set; }
        public RowHandler rowHandler { get; set; }
        public int CurrentFloor { get; set; }
        public int CurrentCeil { get; set; }
        public int CurrentMax { get; set; }
        public bool ActiveSearch { get; set; }
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        public bool SearchDates { get; set; }
        [DisplayName("Search Agencies")]
        public string AgencySearch { get; set; }
        public string CurrentSearch { get; set; }
        public int ChangeUp { get; set; }
        public int ChangeDown { get; set; }
        public bool NextSet { get; set; }
        public bool PreviousSet { get; set; }
        public void Validate()
        {
            if (SearchDates)
            {
                if(!(EndDate.HasValue && StartDate.HasValue))
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
