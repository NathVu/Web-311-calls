using System;
using System.Collections.Generic;
using System.Text;

namespace CallsData
{
    class RowHandler
    {
        public int total;
        public int Curr_min = 0;
        public int Curr_max = 500;
        public int rowsRemaining = 500;
        public int filter_min = 0;
        public int filter_max = 0;
        public int filter_total = 0;
        public int filter_remaining = 0;
        public bool is_filter = false;

        public RowHandler() { }

        public RowHandler(int start, int max)
        {
            this.Curr_min = start;
            this.Curr_max = max;
            this.rowsRemaining = max;
        }


        public void UpdateValuesUp()
        {
            if ((this.Curr_max + 500) > this.total && (this.Curr_min + 500) > this.total)
            {
                this.Curr_min = 0;
                this.Curr_max = 500;
                this.rowsRemaining = 500;
            }
            else if ((this.Curr_max + 500) > this.total)
            {
                this.Curr_min += 500;
                this.Curr_max = total;
                this.rowsRemaining = this.total % 500;
            }
            else
            {
                this.Curr_min += 500;
                this.Curr_max += 500;
            }
        }

        public void UpdateValuesDown()
        {
            if ((this.Curr_min - 500) < 0)
            {
                this.rowsRemaining = total % 500;
                this.Curr_max = this.total;
                this.Curr_min = this.total - (this.total % 500);
            }
            else
            {
                this.Curr_min -= 500;
                this.Curr_max -= 500;
                this.rowsRemaining = 500;
            }
        }

        public void FilterUp()
        {
            if ((this.filter_min + 500) > this.filter_total)
            {
                this.filter_min = 0;
                this.filter_max = 500;
                this.filter_remaining = 500;
            }
            else if ((this.filter_max + 500) > this.filter_total)
            {
                this.filter_min += 500;
                this.filter_max = this.filter_total;
                this.filter_remaining = this.filter_total % 500;
            }
            else
            {
                this.filter_min += 500;
                this.filter_max += 500;
                this.filter_remaining = 500;
            }
        }

        public void FilterDown()
        {
            if ((this.filter_min - 500) < 0)
            {
                this.filter_min = this.filter_total - (this.filter_total % 500);
                this.filter_max = this.filter_total;
                this.filter_remaining = 0;
            }
            else
            {
                this.filter_min -= 500;
                this.filter_max -= 500;
                this.filter_remaining = 500;
            }
        }
    }
}
