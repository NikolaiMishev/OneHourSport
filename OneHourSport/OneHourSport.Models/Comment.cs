namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        
        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment lenght is not in bounds!")]
        public string Text { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public virtual User Creator { get; set; }
        
        public DateTime DateCreated { get; private set; }

        public int FieldId { get; set; }

        public virtual SportField Field { get; set; }
    }
}
