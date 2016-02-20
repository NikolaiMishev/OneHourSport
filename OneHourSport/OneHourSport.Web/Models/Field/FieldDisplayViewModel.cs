namespace OneHourSport.Web.Models.Field
{
    using Common.Constants;
    using Infrastructure;
    using OneHourSport.Models;
    using AutoMapper;
    using Contracts;

    using System.Linq;
    using System;
    public class FieldDisplayViewModel : IMapFrom<SportField>, IHaveCustomMappings, IPageable
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsMine { get; set; }

        public int SportComplexId { get; set; }

        public string SportComplexName { get; set; }

        public bool isCovered { get; set; }

        public string Location { get; set; }

        public SportCategory Category { get; set; }

        public int PictureId { get; set; }

        public int CommentsCount { get; set; }

        public int Rating { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportField, FieldDisplayViewModel>("FieldDisplay")
                .ForMember(r => r.Rating, opts => opts.MapFrom(r => r.Ratings.Count > 0 ? (int)Math.Ceiling((double)r.Ratings.Sum(rg => rg.Value) / r.Ratings.Count) : 0))
                .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Pictures.FirstOrDefault().Id))
                .ForMember(r => r.CommentsCount, opts => opts.MapFrom(r => r.Comments.Count()))
                .ForMember(r => r.SportComplexName, opts => opts.MapFrom(r => r.SportComplex.Name))
                .ForMember(r => r.Location, opts => opts.MapFrom(r => r.SportComplex.Address));

        }
    }
}