namespace OneHourSport.Models
{
    using System;
    using System.Collections.Generic;

    public class SportField
    {
        private ICollection<OccupiedHour> hours;

        private ICollection<Comment> comments;

        private ICollection<Rating> ratings;


        public SportField()
        {
            this.Id = Guid.NewGuid();
            this.hours = new HashSet<OccupiedHour>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerHour { get; set; }
        
        public string SportComplexId { get; set; }

        public virtual SportComplex SportComplex { get; set; }

        public bool isAprooved { get; set; }

        public bool isCovered { get; set; }

        public virtual Picture Picture { get; set; }
        
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
