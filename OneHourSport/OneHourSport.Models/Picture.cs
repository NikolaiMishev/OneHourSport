namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 2)]
        public string Extension { get; set; }
    }
}
