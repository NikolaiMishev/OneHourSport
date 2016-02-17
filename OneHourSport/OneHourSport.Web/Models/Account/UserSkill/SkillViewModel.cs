namespace OneHourSport.Web.Models.Account.UserSkill
{
    using System;
    using AutoMapper;
    using Common.Constants;
    using Infrastructure;
    using OneHourSport.Models;

    public class SkillViewModel : IMapFrom<Skill>, IHaveCustomMappings
    {
        public SportCategory Category { get; set; }

        public string CreatorId { get; set; }

        public string CreatorUsername { get; set; }

        public string ResieverId { get; set; }

        public string ResieverUsername { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Skill, SkillViewModel>("SkillViewModel")
                .ForMember(r => r.CreatorUsername, opts => opts.MapFrom(r => r.Creator.UserName))
                .ForMember(r => r.ResieverUsername, opts => opts.MapFrom(r => r.Resiever.UserName));

        }
    }
}