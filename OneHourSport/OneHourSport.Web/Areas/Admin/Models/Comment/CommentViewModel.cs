﻿namespace OneHourSport.Web.Areas.Admin.Models.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Infrastructure;
    using AutoMapper;
    

    public class CommentViewModel : IMapFrom<OneHourSport.Models.Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Text { get; set; }
                
        public string CreatorName { get; set; }

        [UIHint("CommentsDate")]
        public DateTime DateCreated { get; set; }
        
        public string FieldName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<OneHourSport.Models.Comment, CommentViewModel>("CommentViewModel")
                .ForMember(r => r.FieldName, opt => opt.MapFrom(r => r.Field.Name))
                .ForMember(r => r.CreatorName, opt => opt.MapFrom(r => r.Creator.UserName));
        }
    }
}