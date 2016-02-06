namespace OneHourSport.Models
{
    using System;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string CreatorId { get; set; }

        public string Text { get; set; }

        public virtual User Creator { get; set; }

        public string ComplexId { get; set; }

        public virtual SportComplex Complex { get; set; }

        public string FieldId { get; set; }

        public virtual SportField Field { get; set; }
    }
}
