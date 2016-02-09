namespace OneHourSport.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SportField
    {
        private ICollection<OccupiedHour> hours;

        private ICollection<Comment> comments;

        private ICollection<Rating> ratings;

        private ICollection<Picture> pictures;



        public SportField()
        {
            this.Id = Guid.NewGuid();
            this.hours = new HashSet<OccupiedHour>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
            this.pictures = new HashSet<Picture>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }

        public string SportComplexId { get; set; }

        [Required]
        public virtual SportComplex SportComplex { get; set; }

        public bool isAprooved { get; set; }

        public bool isCovered { get; set; }

        public virtual SportCategory Category { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

        public virtual ICollection<OccupiedHour> OccupiedHours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
