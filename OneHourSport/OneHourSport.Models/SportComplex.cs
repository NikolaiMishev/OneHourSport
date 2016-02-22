namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SportComplex : IDeletableEntity, IAuditInfo
    {
        private ICollection<SportField> fields;
        
        public SportComplex()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.fields = new HashSet<SportField>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

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

        public string OwnerId { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        public virtual City City { get; set; }
        
        public virtual ICollection<SportField> Fields
        {
            get { return this.fields; }
            set { this.fields = value; }
        }
    }
}
