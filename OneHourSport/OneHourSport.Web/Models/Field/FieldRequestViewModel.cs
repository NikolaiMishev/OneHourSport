namespace OneHourSport.Web.Models.Field
{
    using Common.Constants;
    using Infrastructure;
    using OneHourSport.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class FieldRequestViewModel : IMapFrom<SportField>, IMapTo<SportField>
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }
        
        public bool isCovered { get; set; }

        public SportCategory Category { get; set; }
        
        public IEnumerable<HttpPostedFileBase> ProfilePictures { get; set; }
    }
}