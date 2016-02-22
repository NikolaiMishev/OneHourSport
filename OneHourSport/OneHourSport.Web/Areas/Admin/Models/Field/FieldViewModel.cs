namespace OneHourSport.Web.Areas.Admin.Models.Field
{
    using System;
    using AutoMapper;
    using OneHourSport.Common.Constants;
    using OneHourSport.Models;
    using OneHourSport.Web.Infrastructure;

    public class FieldViewModel : IMapFrom<SportField>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerHour { get; set; }

        public bool isAprooved { get; set; }

        public bool isCovered { get; set; }

        public SportCategory Category { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportField, FieldViewModel>("FieldViewModel")
                .ForMember(r => r.Description, opt => opt.MapFrom(r => r.Description.Length > 50 ? r.Description.Substring(0, 50)+"..." : r.Description));
        }
    }
}