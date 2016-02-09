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
        public string Path { get; set; }
    }
}
