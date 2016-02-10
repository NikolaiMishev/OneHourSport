namespace OneHourSport.Web.Models.Complex
{
    using Infrastructure;
    using OneHourSport.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using AutoMapper;
    using System.Linq;
    using System.IO;
    public class ComplexRequestViewModel : IMapFrom<SportComplex>, IHaveCustomMappings
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        public string Description { get; set; }
        
        public HttpPostedFileBase ProfilePicture { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourFrom { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourTo { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CityName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ComplexRequestViewModel, SportComplex>("ComplexCreate")
                .ForMember(r => r.City, opts => opts.MapFrom(r => new City { Name = r.CityName })); ;
        }
    }
}