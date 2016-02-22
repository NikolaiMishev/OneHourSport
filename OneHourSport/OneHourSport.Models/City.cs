namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class City : IDeletableEntity, IAuditInfo
    {
        public City()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Name { get; set; }
    }
}