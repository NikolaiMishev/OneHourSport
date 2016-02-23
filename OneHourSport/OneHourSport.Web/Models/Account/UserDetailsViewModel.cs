namespace OneHourSport.Web.Models.Account
{
    using System;
    using AutoMapper;
    using Infrastructure;
    using OneHourSport.Models;
    using System.Linq;
    using Common.Constants;
    using System.Collections.Generic;
    using UserSkill;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string UserName { get; set; }

        public bool IsComplex { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int PictureId { get; set; }
        
        
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsViewModel>("UserDetails")
                 .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Picture.Id));
        }
    }
}