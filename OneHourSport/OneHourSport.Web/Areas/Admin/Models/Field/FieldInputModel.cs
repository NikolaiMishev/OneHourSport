namespace OneHourSport.Web.Areas.Admin.Models.Field
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;
    
    public class FieldInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }
        
        public bool isAprooved { get; set; }

        public bool isCovered { get; set; }

        public SportCategory Category { get; set; }
    }
}