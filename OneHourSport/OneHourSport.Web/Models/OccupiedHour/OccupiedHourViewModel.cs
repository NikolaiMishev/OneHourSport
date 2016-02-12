namespace OneHourSport.Web.Models.OccupiedHour
{
    using OneHourSport.Web.Infrastructure;
    using System;
    using AutoMapper;

    public class OccupiedHourViewModel : IMapFrom<OneHourSport.Models.OccupiedHour>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public int HourFrom { get; set; }
        
        public int HourTo { get; set; }

        public string OccupiedById { get; set; }
        
        public  string OccupiedByUsername { get; set; }

        public int SportFieldId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OneHourSport.Models.OccupiedHour, OccupiedHourViewModel>("OccupiedHour")
                .ForMember(r => r.OccupiedById, opts => opts.MapFrom(r => r.OccupiedBy.Id))
                .ForMember(r => r.OccupiedByUsername, opts => opts.MapFrom(r => r.OccupiedBy.UserName))
                .ForMember(r => r.SportFieldId, opts => opts.MapFrom(r => r.SportField.Id));
        }
    }
}