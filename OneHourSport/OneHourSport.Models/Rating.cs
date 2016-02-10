namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public Rating()
        {
        }

        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        public string RecieverId { get; set; }

        [Required]
        public virtual User Reciever { get; set; }
    }
}
