namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OccupiedHour : IDeletableEntity, IAuditInfo
    {
        public OccupiedHour()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

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
