namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
        }

        public int Id { get; set; }

        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
