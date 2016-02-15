namespace OneHourSport.Web.Models.Shedule
{
    using OccupiedHour;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SheduleViewModel
    {
        public int WorkHourFrom { get; set; }

        public int WorkHourTo { get; set; }

        public int WorkHoursCount { get; set; }

        public string CurrentUserUsername { get; set; }

        public DateTime Date { get; set; }

        public int FieldId { get; set; }

        public List<OccupiedHourViewModel> OccupiedHours { get; set; }

    }
}