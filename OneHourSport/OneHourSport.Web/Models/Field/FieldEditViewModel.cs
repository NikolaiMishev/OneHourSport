namespace OneHourSport.Web.Models.Field
{
    using OneHourSport.Models;
    using OneHourSport.Web.Infrastructure;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class FieldEditViewModel : IMapFrom<SportField>
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }
        
        public bool isCovered { get; set; }
        
        public IEnumerable<HttpPostedFileBase> EditProfilePictures { get; set; }
    }
}