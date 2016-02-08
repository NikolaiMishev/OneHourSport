namespace OneHourSport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SportComplex
    {
        private ICollection<SportField> fields;

        private ICollection<Comment> comments;
        
        public SportComplex()
        {
            this.Id = Guid.NewGuid();
            this.fields = new HashSet<SportField>();
            this.comments = new HashSet<Comment>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        public string Description { get; set; }

        public virtual Picture Picture { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourFrom { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourTo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public virtual City City { get; set; }
        
        public virtual ICollection<SportField> Fields
        {
            get { return this.fields; }
            set { this.fields = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
