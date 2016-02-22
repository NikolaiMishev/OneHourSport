namespace OneHourSport.Web.Models.Field
{
    using Comment;
    using Infrastructure;
    using OccupiedHour;
    using OneHourSport.Common.Constants;
    using OneHourSport.Models;
    using OneHourSport.Web.Models.Picture;
    using System.Collections.Generic;
    using AutoMapper;
    using System.Linq;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class FieldDetailsViewModel : IMapFrom<SportField>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool CanBeRatedByUser { get; set; }

        [UIHint("Description")]
        public string Description { get; set; }
        
        public decimal PricePerHour { get; set; }

        public int SportComplexId { get; set; }

        public SportComplex SportComplex { get; set; }

        public bool isAprooved { get; set; }

        public bool isCovered { get; set; }

        public SportCategory Category { get; set; }

        public ICollection<PictureViewModel> Pictures  { get; set; }

        public IList<OccupiedHourViewModel> OccupiedHours { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public int Rating { get; set; }

        public int WorkHoursCount { get; set; }

        public int WorkHourFrom { get; set; }

        public int WorkHourTo { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportField, FieldDetailsViewModel>("FieldDetails")
                .ForMember(r => r.Rating, opts => opts.MapFrom(r => r.Ratings.Count > 0 ? (int)Math.Ceiling((double)r.Ratings.Sum(rg => rg.Value) / r.Ratings.Count) : 0))
                .ForMember(r => r.WorkHourFrom, opts => opts.MapFrom(r => r.SportComplex.WorkHourFrom))
                .ForMember(r => r.WorkHourTo, opts => opts.MapFrom(r => r.SportComplex.WorkHourTo))
                .ForMember(r => r.WorkHoursCount, opts => opts.MapFrom(r => r.SportComplex.WorkHourTo - r.SportComplex.WorkHourFrom));


        }
    }
}