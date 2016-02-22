namespace OneHourSport.Models
{
    using Common.Constants;
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Skill : IDeletableEntity, IAuditInfo
    {
        public Skill()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public SportCategory Category { get; set; }
        
        public string CreatorId { get; set; }
        
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public string ResieverId { get; set; }
        
        [ForeignKey("ResieverId")]
        public virtual User Resiever { get; set; }
    }
}
