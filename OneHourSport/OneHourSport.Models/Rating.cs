namespace OneHourSport.Models
{
    using System;

    public class Rating
    {
        public Rating()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public int Value { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
        
        public string RecieverId { get; set; }

        public virtual User Reciever { get; set; }
    }
}
