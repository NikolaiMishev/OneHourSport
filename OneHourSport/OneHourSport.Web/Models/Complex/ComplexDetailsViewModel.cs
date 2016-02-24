namespace OneHourSport.Web.Models.Complex
{
    using System;
    using System.Collections.Generic;
    using Field;

    using AutoMapper;
    using Infrastructure;
    using OneHourSport.Models;

    public class ComplexDetailsViewModel : IMapFrom<SportComplex>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string OwnerId { get; set; }
        
        public string Description { get; set; }
        
        public int WorkHourFrom { get; set; }
        
        public int WorkHourTo { get; set; }

        public int Rating { get; set; }

        public string Address { get; set; }
        
        public string CityName { get; set; }

        public int PictureId { get; set; }

        public bool IsMine { get; set; }

        public string OwnerName { get; set; }

        public ICollection<FieldDisplayViewModel> MyFields { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<SportComplex, ComplexDetailsViewModel>("ComplexDetails")
                 .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Picture.Id))
                 .ForMember(r => r.CityName, opts => opts.MapFrom(r => r.City.Name));
        }
    }
}