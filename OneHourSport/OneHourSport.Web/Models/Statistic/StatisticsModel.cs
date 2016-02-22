namespace OneHourSport.Web.Models.Statistic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class StatisticsModel
    {
        public ICollection<int> NewStats { get; set; }

        public ICollection<int> OldStats { get; set; }

        public int MaxUserVisits { get; set; }
    }
}