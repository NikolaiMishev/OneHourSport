namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.DateCreated = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment lenght is not in bounts!")]
        public string Text { get; set; }

        [Required]
        public virtual User Creator { get; set; }
        
        public DateTime DateCreated { get; }

        public int FieldId { get; set; }

        public virtual SportField Field { get; set; }
    }
}
