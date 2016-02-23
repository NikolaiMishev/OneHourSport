namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : IDeletableEntity, IAuditInfo
    {
        public Comment()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment lenght is not in bounds!")]
        public string Text { get; set; }

        public string CreatorId { get; set; }
        
        public virtual User Creator { get; set; }
        
        public int FieldId { get; set; }

        public virtual SportField Field { get; set; }
    }
}
