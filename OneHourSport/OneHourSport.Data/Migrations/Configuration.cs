namespace OneHourSport.Data.Migrations
{
    using Models;
    using Common.Constants;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<OneHourSportDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(OneHourSportDbContext context)
        {
            context.Configuration.LazyLoadingEnabled = true;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new MinimumLengthValidator(5);

            if (!roleManager.RoleExists(GlobalConstants.AdminRole))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.AdminRole));
            }

            if (!roleManager.RoleExists(GlobalConstants.ComplexRole))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.ComplexRole));
            }

            if (!roleManager.RoleExists(GlobalConstants.UserRole))
            {
                roleManager.Create(new IdentityRole(GlobalConstants.UserRole));
            }
           
            if (userManager.FindByName("admin") == null)
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0888111222",
                    FirstName = "Admin",
                    LastName = "Admin",

                };

                var result = userManager.Create(user, "admin");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
                }
            }
        }
    }
}
