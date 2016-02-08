namespace OneHourSport.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<OccupiedHour> hours;

        private ICollection<Skill> skills;
        
        public User(string userName) 
            : base(userName)
        {
            this.hours = new HashSet<OccupiedHour>();
            this.skills = new HashSet<Skill>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
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
    }
}
