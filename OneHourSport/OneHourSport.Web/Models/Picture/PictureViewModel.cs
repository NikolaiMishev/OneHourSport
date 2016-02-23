namespace OneHourSport.Web.Models.Picture
{
    using System;
    using AutoMapper;
    using OneHourSport.Models;
    using OneHourSport.Web.Infrastructure;

    public class PictureViewModel : IMapFrom<Picture>, IHaveCustomMappings
    {
        public int PictureId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Picture, PictureViewModel>("PictureViewModel")
                 .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Id));
        }
    }
}