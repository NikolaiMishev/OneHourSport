namespace OneHourSport.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using OneHourSport.Models;
    using System.Data.Entity;

    public class OneHourSportDbContext : IdentityDbContext<User>, IOneHourSportDbContext
    {
        public OneHourSportDbContext() 
            : base("OneHourSportConnectionString", throwIfV1Schema: false)
        {
        }

        public override IDbSet<User> Users { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<OccupiedHour> OccupiedHours { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Skill> Skills { get; set; }

        public virtual IDbSet<SportCategory> SportCategories { get; set; }

        public virtual IDbSet<SportComplex> SportComplexes { get; set; }

        public virtual IDbSet<SportField> SportFields { get; set; }
    }
}
