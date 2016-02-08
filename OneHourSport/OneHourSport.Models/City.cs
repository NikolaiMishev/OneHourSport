namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Name { get; set; }
    }
}