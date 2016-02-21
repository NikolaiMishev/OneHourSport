namespace OneHourSport.Web.Models.Game
{
    using OneHourSport.Web.Infrastructure;
    using System;
    using AutoMapper;
    using Contracts;

    public class GameViewModel : IMapFrom<OneHourSport.Models.OccupiedHour>, IHaveCustomMappings, IPageable
    {
        public DateTime Date { get; set; }

        public int HourFrom { get; set; }

        public int HourTo { get; set; }

        public string FieldName { get; set; }
        
        public int SportFieldId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OneHourSport.Models.OccupiedHour, GameViewModel>("Gameview")
                .ForMember(r => r.FieldName, opts => opts.MapFrom(r => r.SportField.Name));
        }
    }
}