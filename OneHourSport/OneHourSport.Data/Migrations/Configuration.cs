namespace OneHourSport.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<OneHourSport.Data.OneHourSportDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OneHourSport.Data.OneHourSportDbContext context)
        {
            //context.Configuration.LazyLoadingEnabled = true;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<User>(new UserStore<User>(context));
            //userManager.PasswordValidator = new MinimumLengthValidator(5);

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            if (!roleManager.RoleExists("complex"))
            {
                roleManager.Create(new IdentityRole("complex"));
            }

            //var user = new User
            //{
            //    UserName = "admin",
            //    Email = "admin@gmail.com",
            //    PhoneNumber = "0888111222",
            //    FirstName = "Admin",
            //    LastName = "Admin"
            //};

            //if (userManager.FindByName("admin") == null)
            //{
            //    var result = userManager.Create(user, "admin");
            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRole(user.Id, "admin");
            //    }
            //}





            //context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            //{
            //    Name = "complex"
            //});

            //context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
            //{
            //    Name = "admin"
            //});

            //context.Users.AddOrUpdate(new Models.User
            //{
            //     Email = "admin@site.com",

            //})

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
