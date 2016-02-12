namespace OneHourSport.Web.Models.Field
{
    using Common.Constants;
    using Infrastructure;
    using OneHourSport.Models;
    using System;
    using AutoMapper;
    using System.Linq;
    public class FieldDisplayViewModel : IMapFrom<SportField>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal PricePerHour { get; set; }

        public int SportComplexId { get; set; }

        public string SportComplexName { get; set; }

        public bool isCovered { get; set; }

        public string Location { get; set; }

        public SportCategory Category { get; set; }

        public int PictureId { get; set; }

        public int CommentsCount { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportField, FieldDisplayViewModel>("FieldDisplay")
                .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Pictures.FirstOrDefault().Id))
                .ForMember(r => r.CommentsCount, opts=>opts.MapFrom(r => r.Comments.Count()))
                .ForMember(r => r.SportComplexName, opts => opts.MapFrom(r => r.SportComplex.Name))
                .ForMember(r => r.Location, opts => opts.MapFrom(r => r.SportComplex.Address));

        }
    }
}