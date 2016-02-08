namespace OneHourSport.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SportCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }
    }
}
