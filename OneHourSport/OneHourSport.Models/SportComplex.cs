namespace OneHourSport.Models
{
    using System;
    using System.Collections.Generic;

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

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Picture Picture { get; set; }

        public int WorkHourFrom { get; set; }

        public int WorkHourTo { get; set; }

        public string Address { get; set; }

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
        
        // Ratings -
    }
}
