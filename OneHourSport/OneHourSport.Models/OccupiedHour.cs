namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OccupiedHour
    {
        public OccupiedHour()
        {
        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int HourFrom { get; set; }

        [Required]
        public int HourTo { get; set; }

        public string OccupiedById { get; set; }

        [Required]
        public virtual User OccupiedBy { get; set; }

        public int SportFieldId { get; set; }

        [Required]
        public virtual SportField SportField { get; set; }
    }
}
