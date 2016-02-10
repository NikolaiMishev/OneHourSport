namespace OneHourSport.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<OccupiedHour> hours;

        private ICollection<Skill> skills;
        
        public User()
        {
            this.hours = new HashSet<OccupiedHour>();
            this.skills = new HashSet<Skill>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        
        public bool IsComplex { get; set; }
        
        [Required]
        public override string PhoneNumber { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual SportComplex SportComplex { get; set; }

        public virtual ICollection<OccupiedHour> MyHours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public virtual ICollection<Skill> Skills
        {
            get { return this.skills; }
            set { this.skills = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
