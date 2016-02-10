namespace OneHourSport.Web.Models.Account
{
    using System;
    using AutoMapper;
    using Infrastructure;
    using OneHourSport.Models;
    using System.Linq;
    using Common.Constants;
    using System.Collections.Generic;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string UserName { get; set; }

        public bool IsComplex { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int PictureId { get; set; }

        public int FootBallVotes { get; set; }

        public int VolayBallVotes { get; set; }

        public int BasketBallVotes { get; set; }

        public int TennisVotes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsViewModel>("UserDetails")
                 .ForMember(r => r.FootBallVotes, opts => opts.MapFrom(r => r.Skills.Where(x => x.Category == SportCategory.FootBall).Count()))
                 .ForMember(r => r.VolayBallVotes, opts => opts.MapFrom(r => r.Skills.Where(x => x.Category == SportCategory.VoleyBall).Count()))
                 .ForMember(r => r.BasketBallVotes, opts => opts.MapFrom(r => r.Skills.Where(x => x.Category == SportCategory.BasketBall).Count()))
                 .ForMember(r => r.TennisVotes, opts => opts.MapFrom(r => r.Skills.Where(x => x.Category == SportCategory.Tennis).Count()))
                 .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Picture.Id));


        }
    }
}