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
        
        public virtual User Creator { get; set; }
        
        public int SportFieldId { get; set; }
        
        public virtual SportField SportField { get; set; }
    }
}
