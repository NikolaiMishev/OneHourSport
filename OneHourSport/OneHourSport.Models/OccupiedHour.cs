namespace OneHourSport.Models
{
    using System;

    public class OccupiedHour
    {
        public OccupiedHour()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public int HourFrom { get; set; }

        public int HourTo { get; set; }

        public string OccupiedById { get; set; }

        public virtual User OccupiedBy { get; set; }

        public string SportFieldId { get; set; }

        public virtual SportField SportField { get; set; }
    }
}
