namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating : IDeletableEntity, IAuditInfo
    {
        public Rating()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        public string CreatorId { get; set; }
        
        public virtual User Creator { get; set; }
        
        public int SportFieldId { get; set; }
        
        public virtual SportField SportField { get; set; }
    }
}
