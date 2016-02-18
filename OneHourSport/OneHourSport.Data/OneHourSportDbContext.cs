namespace OneHourSport.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using OneHourSport.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System;
    using Common.Constants;
    public class OneHourSportDbContext : IdentityDbContext<User>, IOneHourSportDbContext
    {
        public OneHourSportDbContext() 
            : base(GlobalConstants.ConnectionString, throwIfV1Schema: false)
        {
        }

        DbSet<TEntity> IOneHourSportDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override IDbSet<User> Users { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<OccupiedHour> OccupiedHours { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Skill> Skills { get; set; }
        
        public virtual IDbSet<SportComplex> SportComplexes { get; set; }

        public virtual IDbSet<SportField> SportFields { get; set; }

        public static OneHourSportDbContext Create()
        {
            return new OneHourSportDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
