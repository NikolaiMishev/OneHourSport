namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
            this.DateCreated = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string CreatorId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5,ErrorMessage = "Comment lenght is not in bounts!")]
        public string Text { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        public string ComplexId { get; set; }
        
        public virtual SportComplex Complex { get; set; }

        public DateTime DateCreated { get; }

        public string FieldId { get; set; }

        public virtual SportField Field { get; set; }
    }
}
