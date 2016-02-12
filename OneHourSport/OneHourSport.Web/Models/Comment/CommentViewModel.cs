namespace OneHourSport.Web.Models.Comment
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;

    public class CommentViewModel : IMapFrom<OneHourSport.Models.Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public string Text { get; set; }
        
        public DateTime DateCreated { get; }

        public int FieldId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OneHourSport.Models.Comment, CommentViewModel>("CommentViewModel")
                .ForMember(r => r.CreatorId, opts => opts.MapFrom(r => r.Creator.Id))
                .ForMember(r => r.CreatorName, opts => opts.MapFrom(r => r.Creator.UserName))
                .ForMember(r => r.FieldId, opts => opts.MapFrom(r => r.Field.Id));
        }
    }
}